<%@ page language="C#" autoeventwireup="true" CodeBehind="artwork_files_upload.aspx.cs" Inherits="ePrint.Estimates.artwork_files_upload" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlTest" runat="server" Visible="false">

                <script>
                    var strNum = "<%=strNum %>"
                    var FirstTag = window.parent;

                    var file = FirstTag.document.getElementById("file_" + strNum + "");
                    file.style.display = "none";

                    var lblFileName_ = FirstTag.document.getElementById("lblFileName_" + strNum + "");

                    var file_name = "<%=file_name %>";
                    file_name = file_name.replace(/\s|\,/g, "_");
                    var pa = "<%=strDownLoad %>" + file_name;
                    lblFileName_.innerHTML = "<a href='" + pa + "'  target='_Blank' >" + file_name + "</a>&nbsp;&nbsp;<img src='../images/close.gif' onclick=RemoveFromArray('" + strNum + "'); />";
                    lblFileName_.value = file_name;
                    var img = FirstTag.document.getElementById("img_" + strNum + "");
                    img.style.display = "none";

                    FirstTag.endLoad(strNum, file_name);

                </script>

            </asp:Panel>
        </div>
    </form>
</body>
</html>

