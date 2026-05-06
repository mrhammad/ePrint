<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="settings_headerpanel.ascx.cs" Inherits="ePrint.usercontrol.settings.settings_headerpanel" %>

<div style="border-bottom: 1px solid rgb(218, 218, 218);">
    <div class="DivButtonsHeader" style="border-radius: 5px 5px 5px 5px">
        <div>
            <div>
                <div class="divpadding" style="height: 20px;">
                    <div style="float: left; margin-top: 3px;">
                        <b>
                            <asp:Label ID="lblSettingName" runat="server"></asp:Label>:&nbsp; </b>
                    </div>
                    <div style="float: left; margin: 3px 0px 1px 0px;">
                        <asp:Label ID="lbleStore" runat="server"></asp:Label></div>
                    <div id="divdrpdn" align="left" runat="server" onmouseover="javascript:OpenMoreActions(); return false;"
                        onmouseout="javascript:ClosedMoreActions(); return false;" style="float: left;
                        margin: -2px 0px 0px 0px; display: none;" nowrap="nowrap">
                        <div id="divbtn" class="btnstyle" style="width: 250px; padding-left: 13px; text-align: left;"
                            onmouseover="javascript:OpenMoreActions(); return false;">
                            <asp:Label ID="lbleStore2" runat="server" Text=""></asp:Label>
                            <div style="width: 5px; float: right; padding-top: 2.5px">
                                <asp:Image ID="imgArrow" runat="server" ImageUrl="~/images/ArrowDown.gif" />
                            </div>
                        </div>
                        <div id="Div_AccountList" runat="server" class="Div_AccountList" onmouseover="javascript:OpenMoreActions(); return false;"
                            onmouseout="javascript:ClosedMoreActions(); return false;">
                            <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                    <div style="float: left; margin: 3px 0px 0px 10px;">
                        <a id="spn_change" runat="server" onclick="javascript:OpenMoreActions(); return false;"
                            style="text-decoration: underline; cursor: pointer; color: #10357F;">Change</a></div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:Button ID="btnSave" runat="server" OnClick="Save_OnClick" Style="display: none" />
<asp:HiddenField ID="hdnAccountId" runat="server" Value="" />
<script type="text/javascript" language="javascript">

    function OpenMoreActions() {
        document.getElementById("ctl00_ContentPlaceHolder1_header_Div_AccountList").style.display = "block";
        document.getElementById('<%=divdrpdn.ClientID %>').style.display = "block";
        document.getElementById('<%=lbleStore.ClientID %>').style.display = "none";
    }

    function ClosedMoreActions() {
        document.getElementById("ctl00_ContentPlaceHolder1_header_Div_AccountList").style.display = "none";
    }

    function AccountSelect(Id) {
        var AccountId = document.getElementById('<%=hdnAccountId.ClientID %>');
        AccountId.value = Id;
        document.getElementById('<%=btnSave.ClientID %>').click();
    }
</script>

