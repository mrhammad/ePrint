<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ordering_Process.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.Ordering_Process" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<html>
<head>
    <title></title>
    <link href="/css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.8.21.custom.min.js"></script>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <script language="javascript" type="text/javascript">

        function ShowCheckDept() {

            var rdo = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAll_Dept");
            if (rdo.checked) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").disabled = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").disabled = true;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").checked = false;

            }
            else {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").disabled = true;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").disabled = false;
            }
        }

        function ShowCheckUser() {

            var rdo = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAllUsers");
            if (rdo.checked) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").disabled = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").disabled = true;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").checked = false;

            }
            else {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").disabled = true;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").disabled = false;
            }
        }

        function ShowCheckUserMainCheckbox() {
            var chk = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkUserOrderingProcess");

            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").disabled = false;

            if (chk.checked == false) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "DivBackColor";

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAllUsers").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoUser").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").checked = false;
            }
            else {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divUserOrderingProcess123").className = "";

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAllUsers").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoUser").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserMain").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserDept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUserUser").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptMain").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptUser").disabled = true;
            }

            ShowUserOrderingProcess();
            return false;
        }

        function ShowCheckDeptMainCheckbox() {
            var chk = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkDeptOrderingProcess");

            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").disabled = false;

            if (chk.checked == false) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "DivBackColor";


                // document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAll_Dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoBelong_Dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").checked = false;
            }
            else {
                //  document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_divDeptOrderingProcess123").className = "";
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoBelong_Dept").checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdoAll_Dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllMain_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllDept_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkAllUser_dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongMain_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongDept_dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkBelongUser_dept").disabled = true;
            }

            // ShowDeptOrderingProcess();
            return false;
        }


        function replenishcheck_onpageload() {

            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkenablestkreplenished").checked) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = false;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmainappr").disabled = false;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmaindeptappr").disabled = false;

                //                if ('<%=ReplenishBoolVal%>'.toLowerCase() == 'true') {
                //                    document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmainappr").disabled = false;
                //                    document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmaindeptappr").disabled = false;
                //                }
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblall").style.color = "black";
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmainappr").style.color = "black";
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmaindeptappr").style.color = "black";

            }
            else {
                //document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = true;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmainappr").disabled = true;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmaindeptappr").disabled = true;


                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblall").style.color = "gray"

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = true;;
            }

        }
        function replenishcheck() {

            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_chkenablestkreplenished").checked) {

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_hdnFirstChk").value = "true";

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = false;

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblall").style.color = "black";
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmainappr").style.color = "black";
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmaindeptappr").style.color = "black";

                //                if ('<%=ReplenishBoolVal%>'.toLowerCase() == 'true') {
                //                    document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmainappr").disabled = false;
                //                    document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmaindeptappr").disabled = false;
                //                }

            }
            else {
                //document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = true;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmainappr").disabled = true;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_rdbstkrepmaindeptappr").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").checked = false;


                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblall").style.color = "gray"

                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").disabled = true;;
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmainappr").style.color = "gray";
                //                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_lblmaindeptappr").style.color = "gray";
            }

        }

        function CheckReplinish_User() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").checked) {
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked = true;
            }
        }
        function CheckReplinish_Dept() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked) {
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked = true;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").checked) {
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked = true;
            }
        }

        function CheckReplinish_Main() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Main").checked == false) {
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Dept").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i0_Chk_Users").checked = false;
            }

        }
    </script>
    <%--<script src="/js/js_ShowHide.js" type="text/javascript"></script>--%>
</head>
<body>
    <asp:HiddenField ID="hdnFirstChk" runat="server" />
    <asp:HiddenField ID="hdnaccordionIndex" runat="server" Value="0" />
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Height="100%" Skin="Default"
        ExpandMode="MultipleExpandedItems" CssClass="New" Style="padding-top: 5px;">
        <Items>
            <telerik:RadPanelItem Text="Product Details" Font-Bold="true" Expanded="true" CssClass="rounded-ReportTopcorners"
                Selected="true">
                <ContentTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="width: 670px; height: 36px;">
                                    <table cellpadding="0" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-left: 32px; padding-top: 1px;">
                                        <tr>
                                            <td style="width: 325px;">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Ordering_Process") %></h3>
                                            </td>
                                            <td style="width: 115px;" align="center" id="tdMainAppSys" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Main_Approvers") %>
                                                </h3>
                                            </td>
                                            <td style="width: 110px;" align="left" id="tdDeptAppSys" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Dept_Approvers") %>
                                                </h3>
                                            </td>
                                            <td style="width: 30px;" align="center" id="tdUserAppSys" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Users") %>
                                                </h3>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="div3" runat="server" style="width: 663px;">
                        <table cellpadding="0" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-left: 35px;">
                            <tr>
                                <td></td>
                                <td style="width: 290px;"></td>
                                <td style="width: 95px;" align="left"></td>
                                <td style="width: 100px;" align="left"></td>
                                <td style="width: 30px;" align="center"></td>
                            </tr>
                            <tr>
                                <td class="cellsSlider">
                                    <asp:CheckBox ID="chkAllowOrder" runat="server" onclick="javascript:ShowAllowOrderBehalf();return" />
                                </td>
                                <td colspan="4">
                                    <div style="margin-top: -2px;">
                                        <b>
                                            <asp:Label ID="Label6" runat="server"><%=objLanguage.GetLanguageConversion("Allow_order_on_behalf_of")%>
                                            </asp:Label>
                                        </b>
                                    </div>
                                    <div>
                                        <div id="divAllowOrderBehalf" runat="server" style="display: block;">
                                            <div id="divAllowOrderBehalf123" runat="server" style="display: none; height: 155px; width: 700px; float: left;">
                                            </div>
                                            <table width="100%">
                                                <tr>
                                                    <td class="cellsSlider">
                                                        <asp:CheckBox ID="chkUserOrderingProcess" runat="server" onclick="javascript:ShowCheckUserMainCheckbox();return" />
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <asp:Label ID="Label24" runat="server"><%=objLanguage.GetLanguageConversion("Users")%>
                                                            </asp:Label>
                                                        </div>
                                                        <div>
                                                            <div id="divUserOrderingProcess123" runat="server" style="display: none; height: 50px; width: 700px; float: left;">
                                                            </div>
                                                            <div id="divUserOrderingProcess" runat="server" class="divRightsNPrivileges" style="display: block;">
                                                                <table width="102.5%" cellpadding="0" cellspacing="0" style="border: 0px solid red;">
                                                                    <tr>
                                                                        <td width="295px">
                                                                            <asp:RadioButton ID="rdoAllUsers" runat="server" GroupName="Users" onClick="javascript:ShowCheckUser();" />
                                                                            <asp:Label ID="Label12" runat="server"><%=objLanguage.GetLanguageConversion("All_Users")%>
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td width="100px" align="left">
                                                                            <asp:CheckBox ID="chkAllUserMain" Style="padding-left: 34px;" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                        <td width="134px" align="center">
                                                                            <asp:CheckBox ID="chkAllUserDept" Style="padding-left: 0px;" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                        <td width="35px" align="center">
                                                                            <asp:CheckBox ID="chkAllUserUser" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButton ID="rdoUser" runat="server" GroupName="Users" onClick="javascript:ShowCheckUser();" />
                                                                            <asp:Label ID="Label13" runat="server"><%=objLanguage.GetLanguageConversion("Only_Users_in_their_department")%>
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td align="left" width="100px">
                                                                            <asp:CheckBox ID="chkDeptMain" Style="padding-left: 34px;" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                        <td align="center" width="134px">
                                                                            <asp:CheckBox ID="chkDept" Style="padding-left: 0px;" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                        <td align="center" width="35px">
                                                                            <asp:CheckBox ID="chkDeptUser" runat="server"></asp:CheckBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="cellsSlider">
                                                        <asp:CheckBox ID="chkDeptOrderingProcess" runat="server" onclick="javascript:ShowCheckDeptMainCheckbox();return" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label25" runat="server"><%=objLanguage.GetLanguageConversion("Departments")%> 
                                                        </asp:Label>
                                                        <div id="divDeptOrderingProcess123" runat="server" style="display: none; height: 55px; width: 700px; float: left;">
                                                        </div>
                                                        <div id="divDeptOrderingProcess" runat="server" class="divRightsNPrivileges" style="display: block;">
                                                            <table width="102.5%">
                                                                <tr>
                                                                    <td width="295px" style="border: 0px solid red;">
                                                                        <asp:RadioButton ID="rdoAll_Dept" runat="server" GroupName="Department" onClick="javascript:ShowCheckDept();" /><asp:Label
                                                                            ID="Label17" runat="server"><%=objLanguage.GetLanguageConversion("All_Departments")%>
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td width="100px" align="left">
                                                                        <asp:CheckBox ID="chkAllMain_dept" Style="padding-left: 34px;" runat="server"></asp:CheckBox>
                                                                    </td>
                                                                    <td width="130px" align="center" style="border: 0px solid red;">
                                                                        <asp:CheckBox ID="chkAllDept_dept" runat="server" Style="padding-left: 3px;"></asp:CheckBox>
                                                                    </td>
                                                                    <td width="35px" align="center">
                                                                        <asp:CheckBox ID="chkAllUser_dept" runat="server" Style="padding-left: 6px;"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rdoBelong_Dept" runat="server" GroupName="Department" onClick="javascript:ShowCheckDept();" /><asp:Label
                                                                            ID="Label18" runat="server"><%=objLanguage.GetLanguageConversion("Only_Their_Own_Department")%>
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left" width="100px">
                                                                        <asp:CheckBox ID="chkBelongMain_dept" Style="padding-left: 34px;" runat="server"></asp:CheckBox>
                                                                    </td>
                                                                    <td align="center" width="130px">
                                                                        <asp:CheckBox ID="chkBelongDept_dept" Style="padding-left: 3px;" runat="server"></asp:CheckBox>
                                                                    </td>
                                                                    <td align="center" width="35px">
                                                                        <asp:CheckBox ID="chkBelongUser_dept" Style="padding-left: 6px;" runat="server"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <a></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div style="clear: both; height: 20px">
                        </div>
                        <table id="tblstkreplnsh" runat="server" cellpadding="0" cellspacing="0" width="800px"
                            class="PrilivegeTab" style="padding-bottom: 6px; padding-left: 35px; padding-top: 0px; display: none">
                            <tr>
                                <%-- <td>
                                    <asp:CheckBox ID="chkenablestkreplenished" runat="server" onclick="javascript:replenishcheck();" />
                                </td>--%>
                                <td>
                                    <b>
                                        <asp:Label ID="lblstkreplenishhdr" runat="server">Stock Replenishment</asp:Label></b>
                                </td>
                                <%--<td>
                                </td>
                                <td>
                                </td>--%>
                                <%--<td>
                                </td>--%>
                            </tr>
                            <tr>
                                <td width="350px">
                                    <%--<asp:RadioButton ID="rdbstkrepallusr" Checked="true" runat="server" GroupName="rdbstlrepl" />--%>
                                    <asp:CheckBox ID="chkenablestkreplenished" runat="server" onclick="javascript:replenishcheck();" />
                                    <asp:Label ID="lblall" runat="server">Enable Stock Replenisment</asp:Label>
                                </td>
                                <td align="left" width="100px">
                                    <asp:CheckBox ID="Chk_Main" Checked="true" Style="padding-left: 38px;" runat="server"
                                        onclick="javascript:CheckReplinish_Main();" />
                                </td>
                                <td align="center" width="130px">
                                    <asp:CheckBox ID="Chk_Dept" Style="padding-left: 20px;" runat="server" onclick="javascript:CheckReplinish_Dept();" />
                                </td>
                                <td align="center" width="35px">
                                    <asp:CheckBox ID="Chk_Users" Style="padding-left: 23px;" runat="server" onclick="javascript:CheckReplinish_User();" />
                                </td>
                            </tr>
                            <%-- <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbstkrepmainappr" runat="server" GroupName="rdbstlrepl" />
                                    <asp:Label ID="lblmainappr" runat="server">Only Main Approver can Replenish the stock</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbstkrepmaindeptappr" runat="server" GroupName="rdbstlrepl" />
                                    <asp:Label ID="lblmaindeptappr" runat="server">Only Department Approver and Main Approver can Replenish the stock</asp:Label>
                                </td>
                            </tr>--%>
                        </table>
                        <table id="tblReplenishNote" runat="server" cellpadding="0" cellspacing="0" class="PrilivegeTab" style="padding-bottom: 6px; padding-left: 35px; padding-top: 0px; width: 900px; display: none">
                            <tr>
                                <td style="line-height: 110%">
                                    <span class="smallerfontgrey">Please note in the case of products that do not draw their stock from themselves (Kit products) the replenishment option will not be available for the end user in the eStore.</span>

                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem Text="Shopping Cart Options" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                Expanded="false">
                <ContentTemplate>
                    <div class="divOrderingProcesstab2">
                        <table style="margin-left: 1px; padding-bottom: 8px;" cellpadding="0" cellspacing="0">
                            <tr>
                                <th style="width: 348px;">Cart Option</th>
                                <th style="width: 153px; padding-left: 2px;">Screen Name</th>
                                <th style="width: 78px;">Show</th>
                                <th>Required</th>
                            </tr>
                            <tr style="padding-top: 0px;">
                                <td>Job Name</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtJobName" Style="width: 140px; margin-left: 2px;"></asp:TextBox></td>
                                <td>
                                    <asp:CheckBox runat="server" Checked="false" ID="chkJobNameShow" onchange="job_DisplayCheckbox()" Style="margin-left: 8px;" /></td>
                                <td style="text-align: center;">
                                    <asp:CheckBox runat="server" Checked="false" Enabled="false" ID="chkJobNameRequired" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" style="margin-left: -3px; padding-bottom: 5px" cellpadding="0" cellspacing="0" id="tblMarkAllSetting" runat="server">
                            <tr>
                                <td class="cellsSlider">
                                    <div id="divchkmarkall">
                                        <asp:CheckBox ID="chkMarkall" runat="server" />
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:Label ID="lblmarkallshpingcart" runat="server"><%=objLanguage.GetLanguageConversion("Mark_all_shopping_cart_items")%>
                                        </asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem Text="Checkout Page Options" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                Expanded="false">
                <ContentTemplate>
                    <div class="divOrderingProcesscheckouttab">
                        <div>
                            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                <tr>
                                    <td>
                                        <div id="OrderInformation" runat="server" style="margin-top: -30px; margin-bottom: 5px;">
                                            <div class="bglabel" style="width: auto; margin-bottom: 5px; margin-top: 33px;">
                                                <asp:Label ID="Label10" runat="server" CssClass="normaltext">Step 1: <%=objLanguage.GetLanguageConversion("Show_Order_Information")%> </asp:Label>
                                            </div>
                                            <div>
                                                <asp:CheckBox ID="chk_EnableOrder" onchange="Show_EnableOrder()" runat="server" Style="margin-top: 42px; position: absolute;" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_Orderinfo" runat="server" Text="Order Information" Style="font-weight: bold;"></asp:Label>
                                    </td>
                                    <td style="width: 153px;" align="left">
                                        <asp:Label ID="lbl_Ordinfo_Screenname" runat="server" Text="Screen Name" Style="font-weight: bold;"></asp:Label>
                                    </td>
                                    <td style="width: 65px;" align="left">
                                        <asp:Label ID="lbl_Ordinfo_show" runat="server" Text="Show" Style="font-weight: bold;"></asp:Label>
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:Label ID="lbl_Ordinfo_required" runat="server" Text="Required" Style="font-weight: bold;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_OrderTitle" runat="server" Text="Order Title"><%=objLanguage.GetLanguageConversion("Order_Title")%></asp:Label>
                                    </td>
                                    <td style="width: 150px;" align="left">
                                        <asp:TextBox ID="txt_OrdTit_Screen" runat="server" Style="width: 140px;"></asp:TextBox>
                                    </td>
                                    <td style="width: 65px; padding-left: 8px;" align="left">
                                        <asp:CheckBox ID="chk_OrdTit_Show" onchange="Order_Displaycheck()" runat="server" />
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:CheckBox ID="chk_OrdTit_Req" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_OrdNum" runat="server" Text="Order Number"><%=objLanguage.GetLanguageConversion("Order_Number")%></asp:Label>
                                    </td>
                                    <td style="width: 150px;" align="left">
                                        <asp:TextBox ID="txt_OrdNum_Screen" runat="server" Style="width: 140px;"></asp:TextBox>
                                    </td>
                                    <td style="width: 65px; padding-left: 8px;" align="left">
                                        <asp:CheckBox ID="chk_OrdNum_Show" onchange="Order_Displaycheck()" runat="server" />
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:CheckBox ID="chk_OrdNum_Req" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_DelReq" runat="server" Text="Delivery Required By"><%=objLanguage.GetLanguageConversion("Delivery_Required_By")%></asp:Label>
                                    </td>
                                    <td style="width: 150px;" align="left">
                                        <asp:TextBox ID="txt_DelReq_Screen" runat="server" Style="width: 140px;"></asp:TextBox>
                                    </td>
                                    <td style="width: 65px; padding-left: 8px;" align="left">
                                        <asp:CheckBox ID="chk_DelReq_Show" onchange="Order_Displaycheck()" runat="server" />
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:CheckBox ID="chk_DelReq_Req" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_Comments" runat="server" Text="Comments"><%=objLanguage.GetLanguageConversion("Comments")%></asp:Label>
                                    </td>
                                    <td style="width: 150px;" align="left">
                                        <asp:TextBox ID="txt_Comments_Screen" runat="server" Style="width: 140px;"></asp:TextBox>
                                    </td>
                                    <td style="width: 65px; padding-left: 8px;" align="left">
                                        <asp:CheckBox ID="chek_Comments_Show" onchange="Order_Displaycheck()" runat="server" />
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:CheckBox ID="chk_Comments_Req" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 350px; border: 0px solid red;">
                                        <asp:Label ID="lbl_costcenter" runat="server" Text="Show Cost Centre"><%=objLanguage.GetLanguageConversion("Cost_Centre")%></asp:Label>
                                    </td>
                                    <td style="width: 150px;" align="left">
                                        <asp:TextBox ID="txt_costcenter_screen" runat="server" Style="width: 140px;"></asp:TextBox>
                                    </td>
                                    <td style="width: 65px; padding-left: 8px;" align="left">
                                        <asp:CheckBox ID="chkCostCenter" onchange="Order_Displaycheck()" runat="server" />
                                    </td>
                                    <td style="width: 65px; padding-right: 0px;" align="center">
                                        <asp:CheckBox ID="chkCostCenter_Req" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="ShowAddressInformation" runat="server">
                            <div id="Div1" runat="server" style="margin-top: 20px;">
                                <div class="bglabel" style="width: auto; margin-bottom: 5px;">
                                    <asp:Label ID="Label11" runat="server" CssClass="normaltext">Step 2: <%=objLanguage.GetLanguageConversion("Show_Address_Information")%></asp:Label>
                                </div>
                                <div>
                                    <asp:CheckBox ID="Chk_EnableAddress" onchange="Check_ShowAddressInfo()" runat="server"
                                        Style="margin-top: 10px; position: absolute;" />
                                </div>
                            </div>
                        </div>
                        <div id="Divtbl_address" runat="server" style="float: left; padding-bottom: 10px;">
                            <table id="tbl_address" runat="server" style="border-top: 1px;" width="100%" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <th scope="col" class="rg_Header" style="font-weight: bold; text-align: left; width: 474px;">
                                        <asp:Label ID="lblFieldName" runat="server"><%=objLanguage.GetLanguageConversion("Field_Name")%></asp:Label>
                                    </th>
                                    <th scope="col" class="rg_Header" style="font-weight: bold; text-align: center; padding-left: 28px;">
                                        <asp:Label ID="lblDisplay" runat="server"><%=objLanguage.GetLanguageConversion("Show")%></asp:Label>
                                    </th>
                                    <th id="Required" runat="server" scope="col" class="rg_Header" style="font-weight: bold; text-align: center; padding-left: 40px;">
                                        <asp:Label ID="lblMandatory" runat="server"><%=objLanguage.GetLanguageConversion("Required")%></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDelAddress" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 38px;">
                                        <asp:CheckBox ID="Chk_Display_Del" Checked="false" onchange="Check_ToShowDel_InvAddress()"
                                            runat="server" />
                                    </td>
                                    <td id="Del_Mandatory" runat="server" align="center" style="padding-left: 50px;">
                                        <asp:CheckBox ID="Chk_Mandotory_Del" runat="server" Checked="false" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_InvAddress" runat="server"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 38px;">
                                        <asp:CheckBox ID="Chk_Display_Inv" onchange="Check_ToShowDel_InvAddress()" runat="server" />
                                    </td>
                                    <td id="Inv_Mandatory" runat="server" align="center" style="padding-left: 50px;">
                                        <asp:CheckBox ID="chk_Mandotory_Inv" Checked="false" runat="server" Enabled="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Div2" runat="server" style="float: left; padding-top: 7px;">
                            <table id="Table1" runat="server" style="border-top: 1px;" width="100%" cellpadding="0" cellspacing="0">
                                <tr style="height: 28px;">
                                    <th colspan="2" scope="col" class="rg_Header" style="font-weight: bold; text-align: left; width: 474px;">
                                        <asp:Label ID="lblDelWorkDays" runat="server" Text=""></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 350px;">
                                        <asp:Label ID="lblDeliveryDate" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 232px;">
                                        <input type="text" id="txtEstimateDelivery" style="width: 35px;" value="5" maxlength="3"
                                            runat="server" onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);" /><br />
                                        <asp:RequiredFieldValidator ID="rfvEstimateDelivery" runat="server" ControlToValidate="txtEstimateDelivery"
                                            ErrorMessage="" CssClass="spanerrorMsg" Display="Dynamic"> 
                                        <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblWorkingDays" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlWorkingdaysFrom">
                                            <asp:ListItem Text="Sunday" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Monday" Value="2" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Tuesday" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Wednesday" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Thursday" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Friday" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Saturday" Value="7"></asp:ListItem>
                                        </asp:DropDownList>
                                        <span>&nbsp;To&nbsp; </span>
                                        <asp:DropDownList ID="ddlWorkingDaysTo" runat="server">
                                            <asp:ListItem Text="Sunday" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Monday" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Tuesday" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Wednesday" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Thursday" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Friday" Value="6" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Saturday" Value="7"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblShowDates" runat="server">Allow Production Dates</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkShowDates" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <table id="CheckoutProcess_Header" runat="server" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div style="width: 670px; height: 36px;">
                                        <table cellpadding="0" cellspacing="0" width="700px" class="PrilivegeTab" style="padding-top: 8px;">

                                            <tr>
                                                <td style="width: 170px;">
                                                    <h3 class="h3Main">
                                                        <%=objLanguage.GetLanguageConversion("Checkout_Process")%></h3>
                                                </td>
                                                <td style="width: 10px;" align="center" id="td7" runat="server">
                                                    <h3 class="h3Main">
                                                        <%=objLanguage.GetLanguageConversion("Main_Approvers") %>
                                                    </h3>
                                                </td>
                                                <td style="width: 30px;" align="left" id="td8" runat="server">
                                                    <h3 class="h3Main">
                                                        <%=objLanguage.GetLanguageConversion("Dept_Approvers") %>
                                                    </h3>
                                                </td>
                                                <td style="width: 30px;" align="left" id="td9" runat="server">
                                                    <h3 class="h3Main">
                                                        <%=objLanguage.GetLanguageConversion("Users") %>
                                                    </h3>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_CheckoutProcess" runat="server" border="0" cellpadding="0" cellspacing="0"
                            style="margin-top: 8px;">
                            <tr>
                                <td colspan="5" style="height: 2px;"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="font-weight: bold;">
                                    <%--<asp:Label ID="Label19" runat="server"><%=objLanguage.GetLanguageConversion("Checkout_Process")%>
                                    </asp:Label>--%>
                                </td>
                                <td align="left" style="border: 0px solid red; width: 50px;"></td>
                                <td align="left" style="border: 0px solid red;"></td>
                                <td align="right" style="border: 0px solid red;"></td>
                            </tr>
                            <tr>
                                <td class="OrderMngrcellsSlider">
                                    <asp:CheckBox ID="chkChangeAddress" runat="server" Style="display: none;" /><%--onclick="javascript:SelectChangeAddress();return"--%>
                                    <asp:CheckBox ID="Chk_AllowUser_to_vie_changAddress" runat="server" onclick="javascript:Change_Or_ViewAddress();return" />
                                </td>
                                <td style="width: 280px; border: 0px solid red;">
                                    <asp:Label ID="Label5" runat="server"><%=objLanguage.GetLanguageConversion("Allow_user_to_viewchange_addresses")%>
                                    </asp:Label>
                                    <div id="div4" runat="server" class="divRightsNPrivileges" style="display: block;">
                                        <table width="193%" cellpadding="0" cellspacing="0" style="border: 0px solid red;">
                                            <tr>
                                                <td width="335px">
                                                    <asp:RadioButton ID="Rdb_UserSeeCompAddrees" runat="server" GroupName="Addresses"
                                                        onclick="javascript:SelectCompAddress();" /><%--onClick="javascript:ShowCheckUser();"--%>
                                                    <asp:Label ID="Label7" runat="server"><%=objLanguage.GetLanguageConversion("User_can_see_company_addresses")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:CheckBox ID="chkSelectAdrs_Main" Style="padding-left: 28px;" runat="server"></asp:CheckBox>
                                                </td>
                                                <td style="width: 134px; padding-right: 4px;" align="center">
                                                    <asp:CheckBox ID="chkSelectAdrs_Dept" runat="server"></asp:CheckBox>
                                                </td>
                                                <td align="center" width="35px">
                                                    <asp:CheckBox ID="chkSelectAdrs_User" Style="padding-right: 1px;" runat="server"></asp:CheckBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="335px">
                                                    <asp:RadioButton ID="Rdb_UserSeeOnlyDeptAddrees" runat="server" GroupName="Addresses"
                                                        onClick="javascript:SeeonlyDeptAddress();" /><%--onClick="javascript:ShowCheckUser();"--%>
                                                    <asp:Label ID="Label8" runat="server"><%=objLanguage.GetLanguageConversion("User_can_see_only_department_addresses")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:CheckBox ID="Chk_SeeDeptAddress_MainAppr" Style="padding-left: 28px;" runat="server"></asp:CheckBox>
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:CheckBox ID="Chk_SeeDeptAddress_DeptAppr" Style="padding-right: 4px;" runat="server"></asp:CheckBox>
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:CheckBox ID="Chk_SeeDeptAddress_AllUser" Style="padding-right: 1px;" runat="server"></asp:CheckBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="cellsSlider">
                                    <asp:CheckBox ID="chkAdd_EditAddress" runat="server" onclick="javascript:UserAdd_EditAddress();return" /><%--onclick="javascript:SelectChangeAddress();return"--%>
                                </td>
                                <td style="width: 280px; border: 0px solid red;">
                                    <asp:Label ID="Label20" runat="server"><%=objLanguage.GetLanguageConversion("User_can_addedit_new_addresses_and_saved_in_company_address_book")%>
                                    </asp:Label>
                                </td>
                                <td style="width: 100px;" align="left">
                                    <asp:CheckBox ID="chkAdd_EditAddress_Main" Style="padding-left: 48px;" runat="server"></asp:CheckBox>
                                </td>
                                <td style="width: 134px;" align="left">
                                    <asp:CheckBox ID="chkAdd_EditAddress_Dept" Style="padding-left: 76px;" runat="server"></asp:CheckBox>
                                </td>
                                <td style="width: 74px; padding-right: 0px; padding-left: 3px;" align="center">
                                    <asp:CheckBox ID="chkAdd_EditAddress_User" runat="server"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cellsSlider">
                                    <asp:CheckBox ID="chkAdd_Address" runat="server" onclick="javascript:UserAdd_Address();return" />
                                </td>
                                <td style="width: 280px; border: 0px solid red;">
                                    <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("User_can_add_new_addresses_and_saved_in_company_address_book")%>
                                    </asp:Label>
                                </td>
                                <td style="width: 100px;" align="left">
                                    <asp:CheckBox ID="chkAdd_Address_Main" Style="padding-left: 48px;" runat="server"></asp:CheckBox>
                                </td>
                                <td style="width: 134px;" align="left">
                                    <asp:CheckBox ID="chkAdd_Address_Dept" Style="padding-left: 76px;" runat="server"></asp:CheckBox>
                                </td>
                                <td style="width: 74px; padding-right: 0px; padding-left: 3px;" align="center">
                                    <asp:CheckBox ID="chkAdd_Address_User" runat="server"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="cellsSlider">
                                    <asp:CheckBox ID="chkSelectAddress" runat="server" onclick="javascript:AddNewAddress_NotSave();return" />
                                </td>
                                <td style="width: 315px; border: 0px solid red;">
                                    <asp:Label ID="Label21" runat="server"><%=objLanguage.GetLanguageConversion("User_can_add_new_addresses_and_not_saved_in_company_address_book")%>
                                    </asp:Label>
                                </td>
                                <td align="left" width="100px">
                                    <asp:CheckBox ID="chkAddNewAdd_NotSave_Main" Style="padding-left: 48px;" runat="server"></asp:CheckBox>
                                </td>
                                <td style="width: 134px;" align="left">
                                    <asp:CheckBox ID="chkAddNewAdd_NotSave_Dept" Style="padding-left: 76px;" runat="server"></asp:CheckBox>
                                </td>
                                <td align="center" style="width: 65px;">
                                    <asp:CheckBox ID="chkAddNewAdd_NotSave_User" Style="padding-left: 3px;" runat="server"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="height: 2px;"></td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem Text="Confirm Before Order" Font-Bold="true" Expanded="false"
                CssClass="rounded-ReportTopcorners">
                <ContentTemplate>
                    <div class="divOrderingProcesstab3">
                        <div align="left" style="width: 100%; padding-bottom: 10px; border: 0px solid red">
                            <div style="width: 60%">
                                <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div style="padding-left: 25px; padding-top: 5px">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div style="float: left; padding-left: 5px;">
                                                <asp:CheckBox ID="chk_isterms" runat="server" Checked="false" />
                                            </div>
                                        </td>
                                        <td></td>
                                        <div style="width: 20%; margin-left: 3%; position: absolute;">
                                            <asp:Label ID="lblterms" runat="server" Text="Enable Terms and Conditions" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Enable_Terms_And_Conditions")%></asp:Label>
                                        </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 60%; margin-top: 5px;">
                                                <telerik:RadEditor ID="Radeditor" Style="margin-left: 25px; height: 367px; min-height: 367px;"
                                                    runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                    ImageManager-ViewMode="Grid" ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute"
                                                    ContentAreaMode="Iframe" OnClientLoad="RadeditorWrapper">
                                                    <Content>
                                                                          
                                                    </Content>
                                                </telerik:RadEditor>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </ContentTemplate>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem Text="Order Manager Options" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                Expanded="false">
                <ContentTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="width: 670px; height: 36px;">
                                    <table cellpadding="0" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-left: 32px; padding-top: 1px;">
                                        <tr>
                                            <td style="width: 325px;">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Ordering_Process") %></h3>
                                            </td>
                                            <td style="width: 115px;" align="center" id="td1" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Main_Approvers") %>
                                                </h3>
                                            </td>
                                            <td style="width: 110px;" align="left" id="td2" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Dept_Approvers") %>
                                                </h3>
                                            </td>
                                            <td style="width: 30px;" align="center" id="td3" runat="server">
                                                <h3 class="h3Main">
                                                    <%=objLanguage.GetLanguageConversion("Users") %>
                                                </h3>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="divOrderMangertab4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="OrderMngrcellsSlider"></td>
                                <td>
                                    <asp:Label ID="lblestoreOrders" CssClass="OrderMngrHeader" runat="server"><%=objLanguage.GetLanguageConversion("eStore_Orders")%>
                                    </asp:Label>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" width="136%">
                                            <tr>
                                                <td style="border: 0px solid red;">
                                                    <%--<asp:RadioButton ID="rdoIs_Only_User_Orders" runat="server" GroupName="hidemisorders" />--%>
                                                    <asp:Label ID="lblIs_Only_User_Orders" runat="server"><%=objLanguage.GetLanguageConversion("See_all_orders")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeAllOrder_Main" Style="padding-left: 45px;" Checked="true"
                                                        runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeAllOrder_Dept" Style="padding-left: 30px;" runat="server" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_User_All_Orders" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hidemisorders" onclick="javascript:SeeAllOrders()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:RadioButton ID="rdoIs_Only_User_DepartmentOrders" runat="server" GroupName="hidemisorders" />--%>
                                                    <asp:Label ID="lblIs_Only_User_DepartmentOrders" runat="server"><%=objLanguage.GetLanguageConversion("See_all_department_orders")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeAllDptOrder_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeAllDptOrder_Dept" Style="padding-left: 30px;" runat="server" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_Only_User_DepartmentOrders" Style="padding-left: 25px;"
                                                        runat="server" GroupName="hidemisorders" onclick="javascript:SeeAllDeptOrders()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:RadioButton ID="rdoIs_User_All_Orders" runat="server" GroupName="hidemisorders" />--%>
                                                    <asp:Label ID="lblIs_User_All_Orders" runat="server"><%=objLanguage.GetLanguageConversion("See_only_your_orders")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeetheirOrder_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeetheirOrder_Dept" Style="padding-left: 30px;" runat="server" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_Only_User_Orders" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hidemisorders" onclick="javascript:SeeAllTheirOrders()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="OrderMngrcellsSlider">
                                    <asp:CheckBox ID="chkHideMisJob" runat="server" onclick="javascript:HideMisJobs()" />
                                </td>
                                <td>
                                    <asp:Label ID="lblHideMISjob" CssClass="OrderMngrHeader" runat="server"><%=objLanguage.GetLanguageConversion("Hide_MIS_Job")%>
                                    </asp:Label>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" width="136%">
                                            <tr>
                                                <td>
                                                    <%-- <asp:RadioButton ID="rdoIs_User_All_Jobs" runat="server" GroupName="hidemisjob" />--%>
                                                    <asp:Label ID="lblIs_User_All_Jobs" runat="server"><%=objLanguage.GetLanguageConversion("See_all_jobs")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeAllJobs_Main" Style="padding-left: 45px;" Checked="true"
                                                        runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeAllJobs_Dept" Style="padding-left: 30px;" runat="server" GroupName="hidemisjobDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_User_All_Jobs" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hidemisjob" onclick="javascript:SeeAllJobs()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:RadioButton ID="rdoIs_Only_User_DepartmentJobs" runat="server" GroupName="hidemisjob" />--%>
                                                    <asp:Label ID="lblIs_Only_User_DepartmentJobs" runat="server"><%=objLanguage.GetLanguageConversion("See_all_department_jobs")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeAllDeptJobs_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeAllDeptJobs_Dept" Style="padding-left: 30px;" runat="server" GroupName="hidemisjobDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_Only_User_DepartmentJobs" Style="padding-left: 25px;"
                                                        runat="server" GroupName="hidemisjob" onclick="javascript:SeeAllDeptJobs()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 0px solid red;">
                                                    <%--<asp:RadioButton ID="rdoIs_Only_User_Jobs" runat="server" GroupName="hidemisjob" />--%>
                                                    <asp:Label ID="lblIs_Only_User_Jobs" runat="server"><%=objLanguage.GetLanguageConversion("See_only_your_jobs")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeonlytheirJobs_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeonlytheirJobs_Dept" Style="padding-left: 30px;" runat="server" GroupName="hidemisjobDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_Only_User_Jobs" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hidemisjob" onclick="javascript:SeeOnlyTheirJobs()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="OrderMngrcellsSlider">
                                    <asp:CheckBox ID="chkHideMISinvoice" runat="server" onclick="javascript:HideMISInvoice()" />
                                </td>
                                <td>
                                    <asp:Label ID="lblHideMISInvoice" CssClass="OrderMngrHeader" runat="server"><%=objLanguage.GetLanguageConversion("Hide_MIS_Invoice")%>
                                    </asp:Label>
                                    <div>
                                        <table cellpadding="0" cellspacing="0" width="136%">
                                            <tr>
                                                <td style="border: 0px solid red;">
                                                    <%--<asp:RadioButton ID="rdoIs_only_User_Invoice" runat="server" GroupName="hidemisinvoice" />--%>
                                                    <asp:Label ID="lblIs_only_User_Invoice" runat="server"><%=objLanguage.GetLanguageConversion("See_all_invoices")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeAllInoices_Main" Style="padding-left: 45px;" Checked="true"
                                                        runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeAllInoices_Dept" Style="padding-left: 30px;" runat="server" GroupName="hideInvoiceDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_User_All_Invoice" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hideInvoice" onclick="javascript:SeeAllInvoice()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:RadioButton ID="rdoIs_only_user_DepartmentInvoice" runat="server" GroupName="hidemisinvoice" />--%>
                                                    <asp:Label ID="lblIs_only_user_DepartmentInvoice" runat="server"><%=objLanguage.GetLanguageConversion("See_all_department_invoices")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeDeptInvoices_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeDeptInvoices_Dept" Style="padding-left: 30px;" runat="server" GroupName="hideInvoiceDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_only_user_DepartmentInvoice" Style="padding-left: 25px;"
                                                        runat="server" GroupName="hideInvoice" onclick="javascript:SeeAllDeptInvoice()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%--<asp:RadioButton ID="rdoIs_User_All_Invoice" runat="server" GroupName="hidemisinvoice" />--%>
                                                    <asp:Label ID="lblIs_User_All_Invoice" runat="server"><%=objLanguage.GetLanguageConversion("See_only_your_invoices")%>
                                                    </asp:Label>
                                                </td>
                                                <td width="100px" align="left">
                                                    <asp:RadioButton ID="Rdb_SeeOnlyTheirInvoices_Main" Style="padding-left: 45px;" runat="server" />
                                                </td>
                                                <td width="134px" align="center">
                                                    <asp:RadioButton ID="Rdb_SeeOnlyTheirInvoices_Dept" Style="padding-left: 30px;" runat="server" GroupName="hideInvoiceDept" />
                                                </td>
                                                <td width="35px" align="center">
                                                    <asp:RadioButton ID="rdoIs_only_User_Invoice" Style="padding-left: 25px;" runat="server"
                                                        GroupName="hideInvoice" onclick="javascript:SeeOnlyTheirInvoice()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="OrderMngrcellsSlider">
                                    <asp:CheckBox ID="chkAttachConNumToUrl" runat="server" onclick="javascript:HideMisJobs()" />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" CssClass="OrderMngrHeader" runat="server">Attach Consignment Note Number onto URL
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadPanelItem>

                <telerik:RadPanelItem Text="Order Manager View" Font-Bold="true" CssClass="rounded-ReportTopcorners"
        Expanded="false">
        <ContentTemplate>
            <div class="divOrderingProcesstab6">
                
                <table border="0" style="margin-left: 10px; padding-bottom: 5px" cellpadding="0" cellspacing="0" id="Table2" runat="server">
                     <tr>
                        <td style="line-height: 110%">
                            <span class="smallerfontgrey">Show in views</span>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="left" style="margin-top: -4px">
                                <asp:CheckBoxList ID="chkColumnsList" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                    Width="830px" CssClass="chkBoxListPurchase">
                                    <asp:ListItem Text="Department" Value="isDepartment"></asp:ListItem>
                                    <asp:ListItem Text="Raised By" Value="isRaisedBy"></asp:ListItem>
                                    <asp:ListItem Text="Order Status" Value="isOrderStatus"></asp:ListItem>
                                    <asp:ListItem Text="Job Name" Value="isJobName"></asp:ListItem>
                                    <asp:ListItem Text="Delivery Date" Value="isDeliveryDate"></asp:ListItem>
                                    <asp:ListItem Text="Raised Date" Value="isRaisedDate"></asp:ListItem>
                                    <asp:ListItem Text="Custom Date 1" Value="isCustomDate1"></asp:ListItem>
                                    <asp:ListItem Text="Custom Date 2" Value="isCustomDate2"></asp:ListItem>
                                    <asp:ListItem Text="Custom Date 3" Value="isCustomDate3"></asp:ListItem>
                                    <asp:ListItem Text="Custom Date 4" Value="isCustomDate4"></asp:ListItem>
                                    <asp:ListItem Text="Custom Date 5" Value="isCustomDate5"></asp:ListItem>
                                    <asp:ListItem Text="Job Status" Value="isJobStatus"></asp:ListItem>
                                    <asp:ListItem Text="Proof Status" Value="isProofStatus"></asp:ListItem>

                                    </asp:CheckBoxList>
                            </div>
                        </td>

                    </tr>

                     <tr>
                        <td style="line-height: 110%">
                            <span class="smallerfontgrey">Show Older than</span>

                        </td>
                    </tr>
                     <tr>
                         <td>
                          <div align="left" style="margin-bottom: 8px;">
                                <asp:Label ID="lblFilterDateType" runat="server" Text="Filter Date Type:" CssClass="filterLabel" />
                                <asp:DropDownList ID="ddlFilterDateType" runat="server" CssClass="filterDropdown">
                                    <asp:ListItem Text="None" Value="none" />
                                    <asp:ListItem Text="Delivery Date" Value="deliverydate" />
                                    <asp:ListItem Text="Order Date" Value="orderdate" />
                                    <asp:ListItem Text="Custom Date 1" Value="customdate1" />
                                    <asp:ListItem Text="Custom Date 2" Value="customdate2" />
                                    <asp:ListItem Text="Custom Date 3" Value="customdate3" />
                                    <asp:ListItem Text="Custom Date 4" Value="customdate4" />
                                    <asp:ListItem Text="Custom Date 5" Value="customdate5" />
                                </asp:DropDownList>

                                &nbsp;&nbsp;

                                <asp:Label ID="lblFilterDateRange" runat="server" Text="Filter Date Range:" CssClass="filterLabel" />
                                <asp:DropDownList ID="ddlFilterDateRange" runat="server" CssClass="filterDropdown">
                                    <asp:ListItem Text="All" Value="ALL" />
                                    <asp:ListItem Text="1 Month" Value="1M" />
                                    <asp:ListItem Text="2 Months" Value="2M" />
                                    <asp:ListItem Text="3 Months" Value="3M" />
                                    <asp:ListItem Text="6 Months" Value="6M" />
                                    <asp:ListItem Text="1 Year" Value="1Y" />
                                    <asp:ListItem Text="2 Years" Value="2Y" />
                                    <asp:ListItem Text="3 Years" Value="3Y" />
                                </asp:DropDownList>
                            </div>
                         </td>

                     </tr>

                </table>
            </div>
        </ContentTemplate>
    </telerik:RadPanelItem>


        </Items>
    </telerik:RadPanelBar>
    <div class="divOrdermngrSave">
        <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
            OnClientClick="javascript:var a=validate_Account_OrderingProcess();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
            Text="Save" />
    </div>
    <div id="div_btnsaveprocess" style="display: none">
        <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 0.5px" class="loadingimg"
            alt="loading" border="0" />
    </div>
    <asp:HiddenField ID="hdnPendCount" runat="server" Value="" />
    <%-- <script language="javascript" type="text/javascript">
        Default_Select('PL'); // To select default address settings
    </script>--%>
    <script language="javascript" type="text/javascript">
        var txtScreenName1 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_txt_OrdTit_Screen');
        var txtScreenName2 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_txt_OrdNum_Screen');
        var txtScreenName3 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_txt_DelReq_Screen');
        var txtScreenName4 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_txt_Comments_Screen');
        var txtScreenName5 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_txt_costcenter_screen');

        var Mandatory1 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_OrdTit_Req');
        var Mandatory2 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_OrdNum_Req');
        var Mandatory3 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_DelReq_Req');
        var Mandatory4 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_Comments_Req');
        var Mandatory5 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkCostCenter_Req');

        var Dispaly1 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_OrdTit_Show');
        var Dispaly2 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_OrdNum_Show');
        var Dispaly3 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_DelReq_Show');
        var Dispaly4 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chek_Comments_Show');
        var Dispaly5 = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkCostCenter');


        var chk_EnableOrder = document.getElementById('<%=chk_EnableOrder.ClientID%>');
        var Show_Address_Information = document.getElementById('<%=Chk_EnableAddress.ClientID%>');

        var Is_DelAddress_Mand = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_Mandotory_Del');
        var Is_InvAddress_Mand = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chk_Mandotory_Inv');
        var Is_DelAddress_Disp = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_Display_Del');
        var Is_InvAddress_Disp = document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_Display_Inv');




        function Show_EnableOrder() {

            if (chk_EnableOrder.checked) {
                txtScreenName1.disabled = false;
                txtScreenName2.disabled = false;
                txtScreenName3.disabled = false;
                txtScreenName4.disabled = false;
                txtScreenName5.disabled = false;
                if (Dispaly1.checked == true) {
                    Mandatory1.disabled = false;
                }
                else {
                    Mandatory1.disabled = true;
                }
                if (Dispaly2.checked == true) {
                    Mandatory2.disabled = false;
                }
                else {
                    Mandatory2.disabled = true;
                }
                if (Dispaly3.checked == true) {
                    Mandatory3.disabled = false;
                }
                else {
                    Mandatory3.disabled = true;
                }
                if (Dispaly4.checked == true) {
                    Mandatory4.disabled = false;
                }
                else {
                    Mandatory4.disabled = true;
                }
                if (Dispaly5.checked == true) {
                    Mandatory5.disabled = false;
                }
                else {
                    Mandatory5.disabled = true;
                }
                Dispaly1.disabled = false;
                Dispaly2.disabled = false;
                Dispaly3.disabled = false;
                Dispaly4.disabled = false;
                Dispaly5.disabled = false;

                if (Dispaly1.checked == false && Dispaly2.checked == false && Dispaly3.checked == false && Dispaly4.checked == false && Dispaly5.checked == false) {

                    Dispaly1.checked = true;
                    Mandatory1.disabled = false;
                }

            }
            else {
                txtScreenName1.disabled = true;
                txtScreenName2.disabled = true;
                txtScreenName3.disabled = true;
                txtScreenName4.disabled = true;
                txtScreenName5.disabled = true;

                Mandatory1.disabled = true;
                Mandatory2.disabled = true;
                Mandatory3.disabled = true;
                Mandatory4.disabled = true;
                Mandatory5.disabled = true;

                Dispaly1.disabled = true;
                Dispaly2.disabled = true;
                Dispaly3.disabled = true;
                Dispaly4.disabled = true;
                Dispaly5.disabled = true;

                Mandatory1.checked = false;
                Mandatory2.checked = false;
                Mandatory3.checked = false;
                Mandatory4.checked = false;

                Dispaly1.checked = false;
                Dispaly2.checked = false;
                Dispaly3.checked = false;
                Dispaly4.checked = false;
            }

        }

        function Order_Displaycheck() {
            if (Dispaly1.checked == false && Dispaly2.checked == false && Dispaly3.checked == false && Dispaly4.checked == false && Dispaly5.checked == false) {
                chk_EnableOrder.checked = false;
                Show_EnableOrder();
            }
            //
            if (Dispaly1.checked == true) {
                Mandatory1.disabled = false;
            }
            else {
                Mandatory1.checked = false;
                Mandatory1.disabled = true;
            }
            if (Dispaly2.checked == true) {
                Mandatory2.disabled = false;
            }
            else {
                Mandatory2.disabled = true;
                Mandatory2.checked = false;
            }
            if (Dispaly3.checked == true) {
                Mandatory3.disabled = false;
            }
            else {
                Mandatory3.checked = false;
                Mandatory3.disabled = true;
            }
            if (Dispaly4.checked == true) {
                Mandatory4.disabled = false;
            }
            else {
                Mandatory4.disabled = true;
                Mandatory4.checked = false;
            }
            if (Dispaly5.checked == true) {
                Mandatory5.disabled = false;
            }
            else {
                Mandatory5.checked = false;
                Mandatory5.disabled = true;
            }
            //            
        }

        function Check_ShowAddressInfo() {
            if (Show_Address_Information != null) {
                if (Show_Address_Information.checked) {

                    Is_DelAddress_Disp.disabled = false;
                    Is_InvAddress_Disp.disabled = false;
                    Is_DelAddress_Disp.checked = true;
                    Is_DelAddress_Mand.checked = true;

                    if (Is_DelAddress_Disp.checked == false && Is_InvAddress_Disp.checked == false) {
                        Is_DelAddress_Disp.checked = true;
                    }
                }

                else {
                    Is_DelAddress_Mand.disabled = true;
                    Is_InvAddress_Mand.disabled = true;
                    Is_DelAddress_Disp.disabled = true;
                    Is_InvAddress_Disp.disabled = true;
                }
            }
            else {
                Is_DelAddress_Disp.checked = false;
                Is_InvAddress_Disp.checked = false;
            }

        }
        AccountType = '<%=AccountType %>';
        function Check_ToShowDel_InvAddress() {
            var AccountType = '<%=AccountType %>';
            if (AccountType.toLowerCase() == 'x') {
                if (Is_DelAddress_Disp.checked == false && Is_InvAddress_Disp.checked == false) {
                    if (Show_Address_Information != null || Show_Address_Information != undefined) {
                        Show_Address_Information.checked = false;
                    }
                    Check_ShowAddressInfo();
                }
                else {
                    if (Is_DelAddress_Disp.checked == true && Is_InvAddress_Disp.checked == true)
                        if (Show_Address_Information != null || Show_Address_Information != undefined) {
                            Show_Address_Information.checked = true;
                        }
                }

                if (Is_DelAddress_Disp.checked == true) {
                    Is_DelAddress_Mand.disabled = false;
                    Is_DelAddress_Mand.checked = true
                }
                else {
                    Is_DelAddress_Mand.disabled = true;
                    Is_DelAddress_Mand.checked = false;
                }
                if (Is_InvAddress_Disp.checked == true) {
                    Is_InvAddress_Mand.disabled = false;
                    Is_InvAddress_Mand.checked = true
                }
                else {
                    Is_InvAddress_Mand.disabled = true;
                    Is_InvAddress_Mand.checked = false;
                }
            }
            else {
                if (Is_DelAddress_Disp.checked == true) {
                    Is_DelAddress_Mand.disabled = false;
                }
                else {
                    Is_DelAddress_Mand.checked = false;
                    Is_DelAddress_Mand.disabled = true;
                }
                if (Is_InvAddress_Disp.checked == true) {
                    Is_InvAddress_Mand.disabled = false;

                }
                else {
                    Is_InvAddress_Mand.checked = false;
                    Is_InvAddress_Mand.disabled = true;
                }

            }
        }

        if (AccountType.toLowerCase() == 'x') {
            if (chk_EnableOrder.checked == false) {
                txtScreenName1.disabled = true;
                txtScreenName2.disabled = true;
                txtScreenName3.disabled = true;
                txtScreenName4.disabled = true;

                Mandatory1.disabled = true;
                Mandatory2.disabled = true;
                Mandatory3.disabled = true;
                Mandatory4.disabled = true;

                Dispaly1.disabled = true;
                Dispaly2.disabled = true;
                Dispaly3.disabled = true;
                Dispaly4.disabled = true;

                Mandatory1.checked = false;
                Mandatory2.checked = false;
                Mandatory3.checked = false;
                Mandatory4.checked = false;

                Dispaly1.checked = false;
                Dispaly2.checked = false;
                Dispaly3.checked = false;
                Dispaly4.checked = false;
            }
            if (Show_Address_Information.checked == false) {
                Is_DelAddress_Disp.disabled = true;
                Is_InvAddress_Disp.disabled = true;
            }
        }



        function Change_Or_ViewAddress() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_AllowUser_to_vie_changAddress').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeCompAddrees').checked = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').checked = true;

                //
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').disabled = false;
                //
            }
            else if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_AllowUser_to_vie_changAddress').checked == false) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeCompAddrees').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeOnlyDeptAddrees').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').checked = false;

                //
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').disabled = true;
                //
            }

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled == true) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled == false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').disabled == false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').disabled == false;
            }
        }

        function UserAdd_EditAddress() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_User').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').checked = false;



                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_User').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').disabled = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').disabled = false;
            }

        }
        // save new address
        function UserAdd_Address() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Main').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_User').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_User').checked = false;



                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').disabled = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').disabled = false;
            }

        }
        function SeeonlyDeptAddress() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_AllowUser_to_vie_changAddress').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeOnlyDeptAddrees').checked = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeOnlyDeptAddrees').checked = false;
            }

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeOnlyDeptAddrees').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').checked = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').disabled = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').disabled = false;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDept_MaintAppr').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDept_DeptAppr').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDept_AllUser').checked = true;
            }
        }
        function SeeAllOrders() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Orders').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Orders').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllOrder_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDptOrder_Dept').checked = false;
            }
        }
        function SeeAllDeptOrders() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentOrders').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDptOrder_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllOrder_Dept').checked = false;
            }
        }
        function SeeAllTheirOrders() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Orders').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Orders').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDptOrder_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllOrder_Dept').checked = false;
            }
        }
        function SeeAllJobs() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllJobs_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDeptJobs_Dept').checked = false;
            }
        }
        function SeeAllDeptJobs() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentJobs').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDeptJobs_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllJobs_Dept').checked = false;
            }
        }

        function SeeOnlyTheirJobs() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDeptJobs_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllJobs_Dept').checked = false;
            }
        }

        function SeeAllInvoice() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllInoices_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeDeptInvoices_Dept').checked = false;
            }
        }

        function SeeAllDeptInvoice() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_user_DepartmentInvoice').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeDeptInvoices_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllInoices_Dept').checked = false;
            }
        }

        function SeeOnlyTheirInvoice() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeDeptInvoices_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllInoices_Dept').checked = false;
            }
        }

        function SelectCompAddress() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_AllowUser_to_vie_changAddress').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeCompAddrees').checked = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeCompAddrees').checked = false;
            }


            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Rdb_UserSeeCompAddrees').checked) {

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').checked = true;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAdrs_User').disabled = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_MainAppr').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_DeptAppr').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_Chk_SeeDeptAddress_AllUser').disabled = true;
            }
        }

        function AddNewAddress_NotSave() {
            debugger;
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkSelectAddress').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAddNewAdd_NotSave_User').checked = false;



                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').checked = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_EditAddress_User').disabled = false;

                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Main').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_Dept').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i2_chkAdd_Address_User').disabled = false;
            }
        }

        function HideMisJobs() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_chkHideMisJob').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentJobs').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentJobs').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeAllDeptJobs_Dept').checked = true;
            }
        }

        function HideMisJobsOnLoad() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_chkHideMisJob').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentJobs').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Jobs').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_DepartmentJobs').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_Only_User_Jobs').disabled = false;

            }
        }

        function HideMISInvoice() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_chkHideMISinvoice').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_user_DepartmentInvoice').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_user_DepartmentInvoice').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').checked = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_Rdb_SeeDeptInvoices_Dept').checked = true;
            }
        }

        function HideMISInvoiceOnLoad() {

            if (document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_chkHideMISinvoice').checked) {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_user_DepartmentInvoice').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_User_Invoice').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_only_user_DepartmentInvoice').disabled = false;
                document.getElementById('ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i4_rdoIs_User_All_Invoice').disabled = false;
            }
        }


        function job_DisplayCheckbox() {
            var jobNameShow = document.getElementById('<%= chkJobNameShow.ClientID%>')
            var jobNameRequired = document.getElementById('<%= chkJobNameRequired.ClientID%>');

            if (jobNameShow.checked == false) {
                jobNameRequired.checked = false;
                jobNameRequired.disabled = true;
            }
            else {
                jobNameShow.checked = true;
                jobNameRequired.disabled = false;

            }

        }

        function RadeditorWrapper(editor, args) {
            var RareditorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            RareditorIframe.style.height = "100%";
            var RadeditorWrapperHeight = document.getElementById("ctl00_ContentPlaceHolder1_UCOrdering_RadPanelBar1_i3_RadeditorWrapper");
            RadeditorWrapperHeight.style.height = "154px";
        }
    </script>
</body>
</html>

