<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="StoreSettings.aspx.cs" Inherits="ePrint.StoreSettings.StoreSettings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left" id="pnldetails">
        <div align="left">
            <%--<div style="width: 100%;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel"><%=objLanguage.GetLanguageConversion("eStore_Settings") %>:&nbsp;<%=objLanguage.GetLanguageConversion("Home") %></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>--%>
            <div style="height: 290px">
                <div>
                    <span>
                        <%=objLanguage.GetLanguageConversion("Please_Choose_The_Options_From_The_Left_Hand_Panel_To_Proceed")%></span>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

