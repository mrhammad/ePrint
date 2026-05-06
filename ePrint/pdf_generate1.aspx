<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdf_generate1.aspx.cs" Inherits="ePrint.pdf_generate1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnPdf" runat="server" Value="" />

    <asp:HiddenField ID="hdnisSplit" runat="server" Value="" />
    <asp:HiddenField ID="hdnisKeepWithPrevious" runat="server" Value="False" />




    <asp:LinkButton ID="lnkPdf" runat="server" OnClick="lnkPdf_OnClick"></asp:LinkButton>
    <asp:Panel ID="pnl_hideLoad" runat="server" Visible="false">
        <script type="text/javascript">
            window.parent.document.getElementById("ds00").style.display = "none";
            window.parent.document.getElementById("div_Load").style.display = "none";
            window.parent.document.getElementById("Iframe_forAll").style.height = "890px";
            setTimeout(function () {
                var btn = document.getElementById('<%= lnkPdf.ClientID %>');
              if (btn) btn.click();
          }, 500);
        </script>
    </asp:Panel>
    </form>
</body>
</html>