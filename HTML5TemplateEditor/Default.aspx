<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HTML5TemplateEditor._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Jquery-1.11.1.js" type="text/javascript"></script>
    <script src="js/Jquery-ui-1.11.0.js" type="text/javascript"></script>
    <script src="js/jquery.ui.touch-punch.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>

<%--<script>

    var url = "http://localhost:19621/TemplateEditorService.svc/" + "VerticalGroupDetails";
    alert(url);

    $(document).ready(function () {
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify({ Companyid: 1534, templateid: 197, _key: null }),
            dataType: "json",
            processData: false,
            contentType: "application/json; charset=utf-8",
            success: function (ListVerticalGroup) {
                VerticalGroupingData = JSON.parse(JSON.stringify(ListVerticalGroup.d));
            }
        });
    });
</script>--%>



