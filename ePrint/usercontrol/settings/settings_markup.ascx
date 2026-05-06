<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="settings_markup.ascx.cs" Inherits="ePrint.usercontrol.settings.settings_markup" %>

<div class="navigatorpanel">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel">Settings:&nbsp;Edit System Markup</asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>
<div class="borderWithoutTop">
    <div id="padding">
        <div align="left" style="width: 100%">
            <div style="float: left; width: 500px;" nowrap="nowrap">
                <div class="bglabel">
                    <asp:Label ID="lblMarkupName" runat="server" CssClass="normalText">Markup Name</asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="txtMarkupName" runat="server" SkinID="textPad"></asp:TextBox>
                </div>
                <div class="bglabel">
                    <asp:Label ID="lblMarkupRate" runat="server" CssClass="normalText">Rate %</asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="txtMarkupRate" runat="server" SkinID="textPad"></asp:TextBox>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div style="float: left; width: 100%">
                <div style="float: left; width: 20%">
                    &nbsp;</div>
                <div style="float: left">
                    <asp:Button ID="btnMarkupRatesSave" runat="server" Text="Save" CssClass="button"
                        Width="65px" OnClientClick="javascript:return false;" CausesValidation="false" /></div>
                <%--OnClick="btnMarkupRatesSave_OnClick"--%>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left">
                    <asp:Button ID="btnMarkupRatesCancel" runat="server" Text="Cancel" CssClass="button"
                        Width="65px" OnClientClick="javascript:window.close();return false;" /></div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" Width="65px"
                        OnClientClick="javascript:return false;" Visible="false" /></div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left" onclick="javascript:ChangeUrl(this.id,'../common/common_popup.aspx?type=markup&pg=setting&page=add');">
                    <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" Width="65px"
                        OnClientClick="javascript:return false;" Visible="false" /></div>
            </div>
            <div class="only5px">
            </div>
        </div>
    </div>
</div>

<script>
    function ChangeUrl(x, url) {
        window.location.href = url;
    }
</script>

