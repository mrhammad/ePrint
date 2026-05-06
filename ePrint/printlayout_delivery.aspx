<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printlayout_delivery.aspx.cs" Inherits="ePrint.printlayout_delivery" %>--%>

<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage.master" CodeBehind="printlayout_delivery.aspx.cs" autoeventwireup="true" inherits="ePrint.printlayout_delivery" title="Print Layout" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .bgImgPPWLabel
        {
            background-image: url(    '<%=strImagepath %>PPW_Label_New-rotate.jpg' );
            background-repeat: repeat-y;
            position: absolute;
            width: 378px;
        }
        #rotate
        {
            overfolw-x: hidden;
        }
        .ppwfn
        {
            font-family: Arial;
            font-size: 22px;
        }
        .ppwmargin
        {
            color: black;
            margin-left: 5px;
        }
        .ppwboxofmargin
        {
            color: black;
            margin-left: 200px;
            font-weight: bold;
        }
        .ppwaddress
        {
            color: black;
            margin-left: 120px;
        }
        .masplabel
        {
            width: 378px;
            height: 189px;
            font-family: Arial;
            font-size: 22px;
            color: black;
            margin-left: 10px;
        }
    </style>
    <asp:HiddenField ID="hdn_LabelVal" runat="server" Value="" />
    <div>
        <asp:PlaceHolder ID="plhlayout" runat="server"></asp:PlaceHolder>
    </div>
    <script language="javascript" type="text/javascript">
        window.onload = window.print();

        function printView() {
            window.print();
        }       
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

