<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="ePrint.print" enableviewstatemac="false" enableEventValidation="false" theme="Theme1"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function printfun() {
            window.print();
        }
    </script>
</head>
<body>
    <style type="text/css">
        div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
        {
            border-style: solid;
            border-color: #C9C9C9;
            border-width: 0 0 1px 0px;
        }
        .RadGrid .rgHeader, .RadGrid th.rgResizeCol
        {
            padding-top: 2px;
            text-align: left;
            font-weight: normal;
            padding-bottom: -4px;
        }
        .RadGrid .rgFilterRow td
        {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .RowMouseOver td
        {
            background-color: #D8D8D8 !important;
            height: auto;
        }
        .RowMouseOut
        {
            background: #ffffff;
            height: auto;
        }
        
        .RadGrid .rgSelectedRow
        {
            background-color: #8F8F8F !important;
            background-image: none !important;
            height: auto;
        }
        
        .RadGrid_Default .rgCommandCell
        {
            border-right: 0px solid rgb(242, 242, 242);
            border-width: 0px 0px 0px;
            border-style: inherit;
            -moz-border-top-colors: none;
            -moz-border-right-colors: none;
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            border-image: none;
            border-color: rgb(153, 153, 153) rgb(242, 242, 242);
            padding: 0px;
            border: 0px solid red;
        }
        .RadGrid_Default .rgCommandTable
        {
            border-right: 0px none;
            border-left: 0px none;
            -moz-border-top-colors: none;
            -moz-border-right-colors: none;
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            border-image: none;
            border-width: 0px 0px;
            border-style: solid none;
            border-color: rgb(253, 253, 253) -moz-use-text-color rgb(231, 231, 231);
        }
        .RadGrid .rgClipCells .rgHeader, .RadGrid .rgClipCells .rgFilterRow > td, .RadGrid .rgClipCells .rgRow > td, .RadGrid .rgClipCells .rgAltRow > td, .RadGrid .rgClipCells .rgEditRow > td, .RadGrid .rgClipCells .rgFooter > td
        {
            overflow: visible;
        }
        .RadGrid_Default .rgEditForm
        {
            border-bottom: 1px solid rgb(130, 130, 130);
            background-color: White;
        }
    </style>
    <form id="form1" runat="server">
    <script src="js/changeStyle.js" type="text/javascript"></script>
    <link href="App_Themes/Theme1/item.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <div style="margin-top: 8px; margin-left: 10px;">
        <table border="0" cellpadding="0" cellspacing="0" width="99%">           
            <tr>
                <td>
                    <div style="margin-top: 5px;">
                        <asp:PlaceHolder ID="plsEstimatecountbyStatus" runat="server"></asp:PlaceHolder>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:PlaceHolder ID="plsGrid" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

