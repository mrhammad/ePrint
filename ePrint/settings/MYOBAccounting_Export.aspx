<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/settingpage.master" CodeBehind="MYOBAccounting_Export.aspx.cs" Inherits="ePrint.settings.MYOBAccounting_Export" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="ds00" style="display: block;">
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_Load" class="loading_new">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">MYOB Accounting </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div class="">
        <div id="padding">
            <iframe id="iframeMyObAPI" scrolling="no" width="100%" height="350" frameborder="0">
            </iframe>
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1200" Height="600" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <asp:LinkButton ID="lnkCallXeroApi" runat="server"></asp:LinkButton>
    <script type="text/javascript">
        var MyObPath = "<%=myobapiPath%>";
        PopupCenter(MyObPath, '1040', '600');

        function RadWinClose() {
            document.getElementById("ds00").style.display = "none";
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }

        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

