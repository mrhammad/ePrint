<%@ page title="" language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="MasterStyleSheet.aspx.cs" Inherits="ePrint.StoreSettings.MasterStyleSheet" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span runat="server" id="spn_Navigationpanel" class="navigatorpanel">
                                <asp:Label ID="lbl_header" runat="server" Text="Master StyleSheet"></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div >  <%--class="borderWithoutTop"--%>
        <div id="padding">
            <asp:TextBox ID="txt_editStyleSheet" runat="server" CssClass="textboxnew" Width="1000"
                ReadOnly="true" TextMode="MultiLine" Rows="35"></asp:TextBox><%--Font-Size="10px"--%>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>