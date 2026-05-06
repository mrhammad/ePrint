<%@ page language="C#" autoeventwireup="true" CodeBehind="checkout_paypal.aspx.cs" Inherits="ePrint.WebStore.checkout_paypal"  enableEventValidation="false" viewStateEncryptionMode="Never" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form method="post" name="form1" id="form1" runat="server">
        <asp:PlaceHolder ID="plh_paypal" runat="server"></asp:PlaceHolder>
    </form>

    <script type="text/javascript">
        document.getElementById("form1").submit();
    </script>

</body>
</html>

