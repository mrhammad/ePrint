<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickbookAccounting_Online.aspx.cs" Inherits="ePrint.settings.QuickbookAccounting_Online"  masterpagefile="~/Templates/settingpage.master" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div align="left" id="pnldetails">
        <div align="left">
            
        </div>
    </div>
    <script language="javascript" type="text/javascript">

        var XeroPath = "<%=quickbooksAPIPath%>";
        PopupCenter(XeroPath, '1040', '600');

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
