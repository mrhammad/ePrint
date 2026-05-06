<%@ page title="" language="C#" masterpagefile="~/Templates/UserEditProfile.master" autoeventwireup="true" CodeBehind="change_password.aspx.cs" Inherits="ePrint.settings.change_password" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div style="width: 100%; border: 0px solid red" class="mis_header_panel">
            <div align="left" style="width: 100%">
                <div style="width: 34%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div>
                <div align="left">
                    <div class="bglabel" style="width: 14%">
                        <%=objLanguage.GetLanguageConversion("Current_Password")%>
                    </div>
                    <div class="box" style="white-space: nowrap;">
                        <asp:TextBox ID="txtOldPassword" runat="server" SkinID="textPad" MaxLength="25" TextMode="Password">
                        </asp:TextBox>
                    </div>
                </div>

                <div align="left">
                    <div class="bglabel" style="width: 14%">
                        <%=objLanguage.GetLanguageConversion("New_Password")%>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box" style="white-space: nowrap;">
                        <asp:TextBox ID="txtpassword" runat="server" SkinID="textPad" MaxLength="25" TextMode="Password">
                        </asp:TextBox>
                        <span id="span_txtpassword" class="errorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                            <%=objLanguage.GetLanguageConversion("Password_Cant_Accept_Single_Quote")%>
                        </span>
                        <asp:RequiredFieldValidator ID="rvfpassword" runat="server" ErrorMessage="Please enter Password"
                            CssClass="errorMsg" ForeColor="" ControlToValidate="txtpassword" Display="Dynamic"
                            Style="width: auto; padding-left: 4px; padding-right: 4px">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div align="left">
                        <div class="bglabel" style="width: 14%">
                            <%=objLanguage.GetLanguageConversion("Confirm_Password")%>
                            <span style="color: red">*</span>
                        </div>
                        <div class="box" style="white-space: nowrap;">
                            <asp:TextBox ID="txtconfirmpassword" runat="server" SkinID="textPad" MaxLength="25"
                                TextMode="Password">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Confirm Password"
                                CssClass="errorMsg" ForeColor="" ControlToValidate="txtconfirmpassword" Display="Dynamic"
                                Style="width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_ConfirmPassword") %></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvpassword" runat="server" ControlToCompare="txtpassword"
                                CssClass="errorMsg" ForeColor="" ControlToValidate="txtconfirmpassword" Display="Dynamic"
                                ErrorMessage="Password mismatch" Style="width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objLanguage.GetLanguageConversion("Password_Mismatch")%>
                            </asp:CompareValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div style="width: 81%; border: 0px solid;">
                <div class="bglabelEmpty" style="width: 17%">
                </div>
                <div class="box" style="width: 450px">
                    <div style="float: left;">
                        <div id="div_btnCancel" style="display: block">
                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel" OnClick="btncancel_Click"
                                runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                            </telerik:RadButton>
                        </div>
                        <div id="div_btncancelprocess" class="button" align="center" style="height: 14px; width: 38px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left; margin-bottom: 10px">
                        <div id="div_btnSave" style="display: block">
                            <%--<telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                            runat="server" Text="save" OnClick="btnSave_OnClick" OnClientClick="return Validatecmpnyname();">
                                        </telerik:RadButton>--%>
                            <asp:Button ID="btnSave" runat="server" Text="save" CssClass="button" OnClick="btsave_Click" OnClientClick="javascript: validate()" />
                        </div>
                        <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 26px; margin-left:1px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validate() {
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate();
            }
            if (Page_IsValid) {
                document.getElementById('div_btnSave').style.display = 'none';
                document.getElementById('div_btnsaveprocess').style.display = "block";
            }
        }

   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


