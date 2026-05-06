<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Registration_Option.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.Registration_Option" %>

<html>
<head>
    <title></title>
    <script type="text/javascript" src="<%=strSitepath%>js/approvalsystem.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath%>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath%>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript" language="javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath%>js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            var defaul = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoDeptDefault");
            var DeptList = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoDeptList");
            var divDefaultDept = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_divDefaultDept");

            $(DeptList).click(function () {
                $(divDefaultDept).hide('slow');
            });
            $(defaul).click(function () {
                $(divDefaultDept).show('slow');
            });
        });
    </script>
</head>
<body>
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
    <div style="clear: both; padding-top: 6px">
    </div>
    <%--<div class="rounded-corners" style="border: 1px solid #AAAAAA; background-repeat: repeat-x;
        width: 58%; overflow: auto;">--%>
    <div style="background-repeat: repeat-x; width: 58%; overflow: auto;">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div style="width: 663px;">
                        <table cellpadding="3" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-top: 1px;">
                            <%--<tr>
                                <td>
                                    <h3 class="h3Main">
                                        <%=objLanguage.GetLanguageConversion("Registration_Option") %>
                                    </h3>
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <div id="div1" runat="server">
            <table cellpadding="3" cellspacing="0" width="100%" class="PrilivegeTab" style="margin-left: -12px; padding-top: 1px;">
                <tr>
                    <td width="3%">
                        <asp:CheckBox ID="chkIsselfregister" runat="server" onclick="EnableDisable()" />
                    </td>
                    <td>
                        <asp:Label ID="lblselfregister" runat="server"><%=objLanguage.GetLanguageConversion("Allow_User_to_Self_Register")%></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%" style="padding-bottom: 6px; margin-top: -5px;">
                <tr>
                    <td style="width: 2%"></td>
                    <td>
                        <asp:RadioButton ID="rdoDeptList" runat="server" Checked="true" GroupName="RegDept" />
                        <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("User_should_be_presented_with_list_of_departments_to_choose") %>
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 2%"></td>
                    <td>
                        <asp:RadioButton ID="rdoDeptDefault" runat="server" GroupName="RegDept" />
                        <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("User_cannot_select_change_department")%>
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div id="divDefaultDept" runat="server" style="display: none;">
                            <%--class="divRightsNPrivileges"--%>
                            <table style="padding-left: 25px;">
                                <tr>
                                    <td>
                                        <%--<asp:CheckBox ID="chkDefaulDept" runat="server" />--%>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Default_Department_Is")%> </asp:Label>
                                        <asp:DropDownList ID="ddlDefaultDept" runat="server" Style="width: 200px;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 2%"></td>
                    <td>
                        <asp:CheckBox ID="chkAllowAddDept" runat="server" GroupName="RegDept" />

                        <asp:Label ID="lblAllowAddDept" runat="server"><%=objLanguage.GetLanguageConversion("Allow_user_to_create_a_new_department")%>
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 2%"></td>
                    <td>
                        <asp:CheckBox ID="rdoPrefilcontact" runat="server" GroupName="RegDept" />
                        <%-- onclick="javascript:CheckUncheck()"--%>
                        <asp:Label ID="Label9" runat="server"><%=objLanguage.GetLanguageConversion("Prefil_contact_address_with_department_delivery_address")%>
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 2%">
                        <%-- onclick="javascript:CheckUncheck1()"--%>
                    </td>
                    <td>
                        <asp:CheckBox ID="RdoAllowuser" runat="server" GroupName="RegDept" />
                        <asp:Label ID="Label11" runat="server"><%=objLanguage.GetLanguageConversion("Allow_user_to_overwrite_with_a_different_address")%>
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 19px; padding-top: 15px;">
                        <asp:Label ID="Label4" runat="server"><%=objLanguage.GetLanguageConversion("User_can_only_register_with_email_address_containing")%></asp:Label>
                        <asp:TextBox ID="txtRegisterEmail" runat="server" Width="170px" Style="font-family: Verdana,Arial,sans-serif; font-size: 11px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 19px; padding-top: 15px;">
                        <asp:Label ID="lblDepartmentLabel" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtDepartmentLabel" runat="server" Width="170px" Style="font-family: Verdana,Arial,sans-serif; font-size: 11px;"
                            Text="Department"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" class="PrilivegeTab" style="margin-left: -10px; padding-top: 10px;">
                <tr>
                    <td width="3%">
                        <asp:CheckBox ID="chkSingleField" runat="server" />
                    </td>
                    <td style="padding-left: 6px">
                        <asp:Label ID="lblSingleField" runat="server"><%=objLanguage.GetLanguageConversion("Use_email_as_password")%></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="clear: both; padding-top: 10px">
    </div>
    <div style="padding-left: 19px">
        <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
            OnClientClick="javascript:var a = validate_Account();if(a) loadingimage(this.id,'div_btngensaveprocess');return a" Text="Save" />
        <div id="div_btngensaveprocess" style="display: none">
            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
        </div>
    </div>
    <asp:HiddenField ID="hdnPendCount" runat="server" Value="" />
    <script type="text/javascript">
        function CheckUncheck() {
            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoPrefilcontact");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_RdoAllowuser");

            if (chk1.checked) {

                chk2.checked = false;
            }
            else {
                chk1.checked = false;
            }
        }

        function CheckUncheck1() {

            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoPrefilcontact");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_RdoAllowuser");

            if (chk2.checked) {

                chk1.checked = false;
            }
            else {
                chk2.checked = false;
            }
        }

        function EnableDisable() {
            var chkIsselfregister = document.getElementById("<%=chkIsselfregister.ClientID %>");
            var rdoDeptList = document.getElementById("<%=rdoDeptList.ClientID %>");
            var rdoDeptDefault = document.getElementById("<%=rdoDeptDefault.ClientID %>");
            var RdoAllowuser = document.getElementById("<%=RdoAllowuser.ClientID %>");
            var txtRegisterEmail = document.getElementById("<%=txtRegisterEmail.ClientID %>");
            var rdoPrefilcontact = document.getElementById("<%=rdoPrefilcontact.ClientID %>");
            var chkAllowAddDept = document.getElementById("<%=chkAllowAddDept.ClientID %>");

            if (chkIsselfregister.checked) {
                rdoDeptList.disabled = false;
                rdoDeptDefault.disabled = false;
                RdoAllowuser.disabled = false;
                txtRegisterEmail.disabled = false;
                rdoPrefilcontact.disabled = false;
                chkAllowAddDept.disabled = false;
            }
            else {
                rdoDeptList.disabled = true;
                rdoDeptDefault.disabled = true;
                RdoAllowuser.disabled = true;
                txtRegisterEmail.disabled = true;
                rdoPrefilcontact.disabled = true;
                chkAllowAddDept.disabled = true;
            }
        }
    </script>
</body>
</html>

