<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="approval_system.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.approval_system" %>

<html>
<head>
    <title></title>
    <script type="text/javascript" src="../../js/approvalsystem.js"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.21.custom.min.js"></script>
    <style type="text/css">
        .ui-accordion-icons .ui-accordion-header a
        {
            padding-left: 0.5em;
        }
        .ui-icon
        {
            width: 0px;
            height: 0px;
            background-image: url(images/ui-icons_222222_256x240.png);
        }
        .ui-accordion .ui-accordion-content
        {
            padding: 0.5em 2.2em 1em 2.2em;
            border-top: 0px none;
            margin-top: -2px;
            position: relative;
            top: 1px;
            margin-bottom: 2px;
            overflow: auto;
            display: block;
        }
        
        .divRightsNPrivileges
        {
            width: 100%;
            margin-top: 5px;
            padding-bottom: 5px;
            background-color: #EFEFEF;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var AccountID = '<%=AccountID %>';
        $(function () {
            $("#accordion").accordion({
                collapsible: false,
                autoHeight: false,
                navigation: true,
                change: function (event, ui) {
                    var index = $(this).find("h3").index(ui.newHeader[0]);
                    var chkMainApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove");
                    var chkUserDesignatedApp = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignatedApp");
                    var chkSelfApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkSelfApproval");

                    if (index == 0) {
                        chkMainApprove.checked = true;
                        chkUserDesignatedApp.checked = false;
                        chkSelfApproval.checked = false;

                    }
                    else if (index == 1) {
                        chkUserDesignatedApp.checked = true;
                        chkMainApprove.checked = false;
                        chkSelfApproval.checked = false;
                    }
                    else {
                        chkUserDesignatedApp.checked = false;
                        chkMainApprove.checked = false;
                        chkSelfApproval.checked = true;
                    }
                }

            });

            var accordionindex = Number($("#ctl00_ContentPlaceHolder1_ApprovalSystem_hdnaccordionIndex").val());
            if (accordionindex == 0) {
                $("#accordion").accordion();
            }
            else {
                $("#accordion").accordion('activate', accordionindex);
            }


            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divAdvancedApprovers").style.visibility = 'visible';
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divAdvancedApproversDetails").style.visibility = 'visible';
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divUDApprovers").style.visibility = 'visible';
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divSelfApproval").style.visibility = 'visible';
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divUDApproversDetails").style.visibility = 'visible';
            document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divUDSelfApproval").style.visibility = 'visible';

        });

        function ValidateApprovalSystem() {
            if (validate_Account()) {
                var chkApprovalED = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAppSys_Enable");
                var chkMainApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove");
                var chkUserDesignatedApp = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignatedApp");
                var chkSelfApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkSelfApproval");

                var count = 0;

                var chkMain = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain");
                var chkDeptApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");
                var chkRequirePWD = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRequirePWD");
                var chkUserDesignateOwnApprover = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignateOwnApprover");
                var chkDAEmailAddEndsWith = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDAEmailAddEndsWith");
                var txtEmailEndsWith = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtEmailEndsWith");
                var chkMarkalltheitemsasApproved = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMarkalltheitemsasApproved");

                var chkNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval");
                var chkNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval");
                var chkEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval");

                var chkRepprovalByMainApp = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRepprovalByMainApp");

                var hdnchkmain = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnchkmain");
                var hdnchkMarkalltheitemsasApproved = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnchkMarkalltheitemsasApproved");
                var hdnDeptApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnDeptApprove");
                var hdnRepprovalByMainApp = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRepprovalByMainApp");
                var hdnRequirePWD = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnRequirePWD");
                var hdnMainApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnMainApprove");

                var hdnUserDesignatedApp = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnUserDesignatedApp");
                var hdnUserDesignateOwnApprover = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnUserDesignateOwnApprover");
                var hdnUserDesignateOwnApprover = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnUserDesignateOwnApprover");
                var hdnDAEmailAddEndsWith = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnDAEmailAddEndsWith");
                var hdntxtEmailEndsWith = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtEmailEndsWith");
                var hdnLastDADefault = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnLastDADefault");
                var chkLastDADefault = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkLastDADefault");

                var hdnNewOrderApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewOrderApproval");
                var hdntxtOrderForValues = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtOrderForValues");
                var hdntxtOrdResendApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtOrdResendApproval");
                var hdntxtDeleteOrders = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtDeleteOrders");
                var hdntxtAutoChangesStatus = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtAutoChangesStatus");
                var hdnddlstatus = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnddlstatus");
                var hdntxtOrdInformAdmin = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtOrdInformAdmin");

                var txtOrderForValues = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrderForValues");
                var txtOrdResendApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdResendApproval");
                var txtDeleteOrders = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtDeleteOrders");
                var txtAutoChangesStatus = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoChangesStatus");
                var ddlstatus = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_ddl_Status");
                var txtOrdInformAdmin = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdInformAdmin");

                var hdnEditProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnEditProfileApproval");

                var hdnNewProfileApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdnNewProfileApproval");
                var hdntxtProResendApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtProResendApproval");
                var hdntxtProDeleteOrders = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtProDeleteOrders");
                var hdntxtProInformAdmin = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtProInformAdmin");
                var hdntxtAutoEmail = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_hdntxtAutoEmail");

                var txtProResendApproval = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProResendApproval");
                var txtProDeleteOrders = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProDeleteOrders");
                var txtProInformAdmin = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProInformAdmin");
                var txtAutoEmail = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoEmail");

                if (!chkApprovalED.checked) {
                    if (chkMainApprove.checked) {
                        hdnMainApprove.value = "1";
                    }
                    else {
                        hdnMainApprove.value = "0";
                    }

                    if (chkUserDesignatedApp.checked) {
                        hdnUserDesignatedApp.value = "1";
                    }
                    else {
                        hdnUserDesignatedApp.value = "0";
                    }

                    if (chkMain.checked) {
                        hdnchkmain.value = "1";
                    }
                    else {
                        hdnchkmain.value = "0";
                    }

                    if (chkDeptApprove.checked) {
                        hdnDeptApprove.value = "1";
                    }
                    else {
                        hdnDeptApprove.value = "0";
                    }

                    if (chkRepprovalByMainApp.checked) {
                        hdnRepprovalByMainApp.value = "1";
                    }
                    else {
                        hdnRepprovalByMainApp.value = "0";
                    }

                    if (chkRequirePWD.checked) {
                        hdnRequirePWD.value = "1";
                    }
                    else {
                        hdnRequirePWD.value = "0";
                    }

                    if (chkUserDesignateOwnApprover.checked) {
                        hdnUserDesignateOwnApprover.value = "1";
                    }
                    else {
                        hdnUserDesignateOwnApprover.value = "0";
                    }

                    if (chkDAEmailAddEndsWith.checked) {
                        hdnDAEmailAddEndsWith.value = "1";
                        hdntxtEmailEndsWith.value = txtEmailEndsWith.value;
                    }
                    else {
                        hdnDAEmailAddEndsWith.value = "0";
                    }

                    if (chkLastDADefault.checked) {
                        hdnLastDADefault.value = "1";
                    }
                    else {
                        hdnLastDADefault.value = "0";
                    }

                    if (chkMarkalltheitemsasApproved.checked) {
                        hdnchkMarkalltheitemsasApproved.value = "1";
                    }
                    else {
                        hdnchkMarkalltheitemsasApproved = "0";
                    }

                    if (chkNewOrderApproval.checked) {
                        hdnNewOrderApproval.value = "1";
                        hdntxtOrderForValues.value = txtOrderForValues.value;
                        hdntxtOrdResendApproval.value = txtOrdResendApproval.value;
                        hdntxtDeleteOrders.value = txtDeleteOrders.value;
                        hdntxtAutoChangesStatus.value = txtAutoChangesStatus.value;
                        hdnddlstatus.value = ddlstatus.options[ddlstatus.selectedIndex].value;
                        hdntxtOrdInformAdmin.value = txtOrdInformAdmin.value;
                    }
                    else {
                        hdnNewOrderApproval.value = "0";
                    }

                    if (chkEditProfileApproval.checked) {
                        hdnEditProfileApproval.value = "1";
                    }
                    else {
                        hdnEditProfileApproval.value = "0";
                    }

                    if (chkNewProfileApproval.checked) {
                        hdnNewProfileApproval.value = "1";
                        hdntxtProResendApproval.value = txtProResendApproval.value;
                        hdntxtProDeleteOrders.value = txtProDeleteOrders.value;
                        hdntxtProInformAdmin.value = txtProInformAdmin.value;
                        hdntxtAutoEmail.value = txtAutoEmail.value;
                    }
                    else {
                        hdnNewProfileApproval.value = "0";
                    }
                }

                if (chkMainApprove.checked) {
                    if (chkMain.checked) {
                        count = 1;
                    }
                    else if (chkDeptApprove.checked) {
                        if (chkMain.checked) {
                            count = 1;
                        }
                        else {
                            count = 2;
                        }
                    }
                    else if (chkRequirePWD.checked) {
                        if (chkMain.checked) {
                            count = 1;
                        }
                        else {
                            count = 2;
                        }
                    }
                    else {
                        count = 2;
                    }
                }
                else if (chkUserDesignatedApp.checked) {
                    if (chkUserDesignateOwnApprover.checked) {
                        if (chkDAEmailAddEndsWith.checked) {
                            if (txtEmailEndsWith.value == '') {
                                alert('<%=objLanguage.GetLanguageConversion("please_enter_designated_approvers_email_address")%>');
                                return false;
                            }
                            else {
                                count = 1;
                            }

                        }
                        else {
                            count = 1;
                        }
                    }
                    else {
                        count = 3;
                    }
                }

            if (chkApprovalED.checked) {
                if (chkNewOrderApproval.checked) {
                    if (count == 1) {
                        return true;
                    }
                    else if (count == 2) {
                        alert('<%=objLanguage.GetLanguageConversion("Please_select_one_of_the_options_to_proceed")%>');
                            return false;
                        }
                        else if (count == 3) {
                            alert('<%=objLanguage.GetLanguageConversion("Please_check_one_of_the_options_to_proceed")%>');
                                return false;
                            }

                }
                else if (chkNewProfileApproval.checked) {
                    if (count == 1) {
                        return true;
                    }
                    else if (count == 2) {
                        alert('<%=objLanguage.GetLanguageConversion("Please_select_one_of_the_options_to_proceed")%>');
                            return false;
                        }
                        else if (count == 3) {
                            alert('<%=objLanguage.GetLanguageConversion("Please_check_one_of_the_options_to_proceed")%>');
                                return false;
                            }

                }
                else if (chkEditProfileApproval.checked) {
                    if (count == 1) {
                        return true;
                    }
                    else if (count == 2) {
                        alert('<%=objLanguage.GetLanguageConversion("Please_select_one_of_the_options_to_proceed")%>');
                            return false;
                        }
                        else if (count == 3) {
                            alert('<%=objLanguage.GetLanguageConversion("Please_check_one_of_the_options_to_proceed")%>');
                                return false;
                            }

                }
                else {
                    if (count == 1) {
                        alert('<%=objLanguage.GetLanguageConversion("please_check_one_from_rights_and_previleges")%>');
                            return false;
                        }
                        else if (count == 2) {
                            if (chkApprovalED.checked) {
                                alert('<%=objLanguage.GetLanguageConversion("Please_select_one_of_the_options_to_proceed")%>');
                                return false;
                            }
                            else {
                                return true;
                            }
                        }
                        else if (count == 3) {
                            alert('<%=objLanguage.GetLanguageConversion("Please_check_one_of_the_options_to_proceed")%>');
                            return false;
                        }

            }
}
}
else {
    return false;
}

}

function ShowDefaultDept() {
    var rdo = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoDeptDefault");
    if (rdo.checked) {
        $("#ctl00_ContentPlaceHolder1_ApprovalSystem_divDefaultDept").slideToggle("slow");
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divDefaultDept").style.display = "block";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divDefaultDept").style.display = "none";
    }
}

function ShowCheckDept() {

    var rdo = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoAll_Dept");
    if (rdo.checked) {

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllMain_dept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllDept_dept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUser_dept").disabled = false;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongMain_dept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongDept_dept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongUser_dept").disabled = true;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongMain_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongDept_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongUser_dept").checked = false;

    }
    else {

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllMain_dept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllDept_dept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUser_dept").disabled = true;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllMain_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllDept_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUser_dept").checked = false;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongMain_dept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongDept_dept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkBelongUser_dept").disabled = false;
    }
}

function ShowCheckUser() {

    var rdo = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoAllUsers");
    if (rdo.checked) {

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserMain").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserDept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserUser").disabled = false;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptMain").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptUser").disabled = true;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptMain").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptUser").checked = false;

    }
    else {

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserMain").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserDept").disabled = true;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserUser").disabled = true;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserMain").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserDept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAllUserUser").checked = false;

        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptMain").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDept").disabled = false;
        document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptUser").disabled = false;
    }
}

function ShowCheckUserMainCheckbox() {
    var chk = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkUserOrderingProcess");
    if (chk.checked == false) {
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoAllUsers").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoUser").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllUserMain").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllUserDept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllUserUser").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkDeptMain").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkDept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkDeptUser").checked = false;
    }
    ShowUserOrderingProcess();
    return false;
}

function ShowCheckDeptMainCheckbox() {
    var chk = document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkDeptOrderingProcess");
    if (chk.checked == false) {
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoAll_Dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_rdoBelong_Dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllMain_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllDept_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkAllUser_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkBelongMain_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkBelongDept_dept").checked = false;
        document.getElementById("ctl00_ContentPlaceHolder1_UCRegistration_chkBelongUser_dept").checked = false;
    }
    ShowDeptOrderingProcess();
    return false;
}

    </script>
    <%--<script src="../../js/js_ShowHide.js" type="text/javascript"></script>--%>
    <script>
        $(document).ready(function () {
            var defaul = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoDeptDefault");
            var DeptList = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoDeptList");
            var divDefaultDept = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_divDefaultDept");

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
    <div style="clear: both; padding-top: 2px">
    </div>
    <div style="width: 58.2%">
        <table cellpadding="2" cellspacing="0" class="tableslider" style="padding-left: 0.6%;">
            <tr>
                <td class="cellsSlider">
                    <asp:CheckBox ID="chkAppSys_Enable" onclick="javascript:disableenable();" runat="server" />
                </td>
                <td class="cells1" style="font-weight: bold;">
                    <div>
                        <%=objLanguage.GetLanguageConversion("Approval_System_Enabled")%>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both; padding-top: 5px">
    </div>
    <div id="accordion" style="width: 58.2%">
        <h3 id="divAdvancedApprovers" runat="server" style="visibility: hidden">
            <a href="#" id="firstTab" class="linkbtn" onclick="javascript:ShowMainApprovalPanel();return">
                <asp:CheckBox ID="chkMainApprove" Checked="true" runat="server" />
                <%=objLanguage.GetLanguageConversion("Main_Approver_Department_Approvers")%>
            </a>
        </h3>
        <div id="divAdvancedApproversDetails" runat="server" class="undertable" style="visibility: hidden">
            <table cellpadding="2" cellspacing="0" class="tableslider">
                <tr>
                    <td class="cellsSlider" colspan="2">
                        <asp:CheckBox ID="chkMain" runat="server" Style="float: left;" onclick="javascript: Check_uncheck_DeptApprove(); return" />
                        <div style="padding-left: 6px; padding-top: 2px; float: left;">
                            <%=objLanguage.GetLanguageConversion("Main_approver_can_approve")%>
                        </div>
                    </td>
                    <%--<td class="cells1">
                    </td>--%>
                </tr>
                <tr>
                    <td class="cellsSlider" style="padding-left: 24px;">
                        <asp:CheckBox ID="chkDeptApprove" runat="server" onclick="javascript:return ShowDepartmentApprovers()" />
                    </td>
                    <td class="cells1">
                        <div style="padding-left: 2px;">
                            <%--<%=objLanguage.GetLanguageConversion("Department_approvers_can_approve_Each_department_should_have_an_approver_selected_in_the_CRM")%>--%>
                            Department approvers can approve (Each department should have an approver selected in the CRM)
                        </div>
                        <div id="divDeptApprovers" class="innertd" runat="server" style="display: none;">
                            <table id="TabDept" runat="server">
                                <tr>
                                    <td style="padding-left: 4px;">
                                        <asp:CheckBox ID="chkRepprovalByMainApp" runat="server" />
                                    </td>
                                    <td class="innercells">
                                        <%=objLanguage.GetLanguageConversion("Department_approvers_orders_should_be_reapproved_by_main_approver")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="cellsSlider" style="padding-left: 24px;">
                        <asp:CheckBox ID="chkRequirePWD" runat="server" onclick="javascript:return CheckMainApprover()" />
                    </td>
                    <td class="cells1">
                        <div style="padding-left: 2px;">
                            <%=objLanguage.GetLanguageConversion("All_approvers_should_enter_the_password_during_approval_process")%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <h3 id="divUDApprovers" runat="server" style="visibility: hidden">
            <a href="#" id="secondtab" class="linkbtn" onclick="javascript:ShowUserDesignatedPanel();return">
                <asp:CheckBox ID="chkUserDesignatedApp" runat="server" /><%=objLanguage.GetLanguageConversion("User_Designated_Approvers")%>
            </a>
        </h3>
        <div id="divUDApproversDetails" runat="server" class="undertable" style="visibility: hidden">
            <table cellpadding="3" cellspacing="0" class="tableslider">
                <tr>
                    <td class="cellsSlider">
                        <asp:CheckBox ID="chkUserDesignateOwnApprover" runat="server" onclick="javascript:ShowUserDesignatedApprovers();return" />
                    </td>
                    <td class="cells1">
                        <%=objLanguage.GetLanguageConversion("User_can_designate_their_own_approver")%>
                        <div id="divUserDesignatedApprovers" runat="server" class="innertd" style="display: none;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkDAEmailAddEndsWith" runat="server" />
                                    </td>
                                    <td class="innercells" style="width: 500px; vertical-align: middle">
                                        <div style="float: left">
                                            <%=objLanguage.GetLanguageConversion("Designated_approvers_email_address_should_ends_with")%>
                                        </div>
                                        <div style="float: left; padding-left: 5px; margin-top: -6px">
                                            <asp:TextBox ID="txtEmailEndsWith" runat="server"></asp:TextBox></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkLastDADefault" runat="server" />
                                    </td>
                                    <td class="innercells">
                                        <%=objLanguage.GetLanguageConversion("Last_designated_approver_becomes_the_default")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <h3 id="divSelfApproval" runat="server" style="visibility: visible">
            <a href="#" id="thirdtab" class="linkbtn" onclick="javascript:ShowMarkalltheitemsasApproved();return">
                <asp:CheckBox ID="chkSelfApproval" runat="server" /><%=objLanguage.GetLanguageConversion("Self_Approval")%>
            </a>
        </h3>
        <div id="divUDSelfApproval" runat="server" class="undertable" style="visibility: visible">
            <table cellpadding="3" cellspacing="0" class="tableslider">
                <tr>
                    <td class="cellsSlider">
                        <asp:CheckBox ID="chkMarkalltheitemsasApproved" runat="server" />
                    </td>
                    <td>
                        <%=objLanguage.GetLanguageConversion("Mark_all_the_items_as_Approved")%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="clear: both; padding-top: 10px">
    </div>
    <div class="rounded-corners" style="border: 1px solid #AAAAAA; background-repeat: repeat-x;
        width: 58%; /*background-image: url(../images/AccordionModified.png); */ overflow: auto;">
        <table width="100%" cellpadding="0" cellspacing="0" style="background-image: url(../images/app-sys-grey.png);">
            <tr>
                <td class="belowlink">
                    <div style="font-size: 11px; vertical-align: middle; font-weight: bold; padding-left: 25px;
                        padding-top: 6px; -webkit-margin-before: 0em !important; -ms-margin-before: 0em !important;
                        -moz-margin-before: 0em !important; height: 23px">
                        <%=objLanguage.GetLanguageConversion("Rights_and_Privileges")%>
                    </div>
                </td>
            </tr>
        </table>
        <div id="div2" runat="server">
            <table cellpadding="3" cellspacing="0" width="100%" class="PrilivegeTab" style="padding-left: 33px;
                padding-bottom: 6px">
                <tr>
                    <td class="cellsSlider">
                        <asp:CheckBox ID="chkNewOrderApproval" runat="server" onclick="javascript:ShowNewOrdersReqApproval();ShowNewOrdersReqApproval2();return" />
                    </td>
                    <td style="width: 100%; margin-left: -19px;">
                        <div style="margin-top: 3px;" id='div_New_orders_requires'>
                            <asp:Label ID="orders" runat="server" Text="New orders requires approval"><%=objLanguage.GetLanguageConversion("New_orders_requires_approval")%></asp:Label>
                        </div>
                        <div style="padding-top: 3px;">
                            <div id="divNewOrdersReqApproval" runat="server" class="divRightsNPrivileges" style="display: none;">
                                <table width="100%">
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px;">
                                                <%=objLanguage.GetLanguageConversion("Approval_required_for_Orders_for_values_above")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtOrderForValues" Width="50px" Style="text-align: right" onkeypress="return isNumberKey(event)"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float: left; padding-left: 5px; padding-top: 5px; color: #9F9F9F">
                                                <%=objLanguage.GetLanguageConversion("leave_blank_if_you_want_all_orders_value_approval")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Resend_Approval_email_if_no_action_is_taken_after")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtOrdResendApproval" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Auto_Delete_orders_if_no_action_taken_after")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtDeleteOrders" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Auto_change_the_status")%>
                                            </div>
                                            <div style="float: left; padding: 5px 5px 0px 5px;">
                                                <asp:DropDownList ID="ddl_Status" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div style="float: left; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("of_the_order_if_no_action_taken_after")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtAutoChangesStatus" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Inform_Admin_about_Pending_Approval_if_not_approved_in")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtOrdInformAdmin" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr id="tr_NewProfileApproval">
                    <td class="cellsSlider">
                        <asp:CheckBox ID="chkNewProfileApproval" runat="server" onclick="javascript:ShowNewProfilesReqApproval();ShowNewProfilesReqApproval2();return" />
                    </td>
                    <td style="width: 100%; margin-left: -19px;">
                        <div style="margin-top: 3px;">
                            <asp:Label ID="Label10" runat="server" Text="New registration requires approval"><%=objLanguage.GetLanguageConversion("New_registration_requires_approval")%></asp:Label>
                        </div>
                        <div style="padding-top: 2px;">
                            <div id="divNewProfilesReqApproval" runat="server" class="divRightsNPrivileges" style="display: none;">
                                <table width="100%">
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px; padding-left: 3px">
                                                <%=objLanguage.GetLanguageConversion("Resend_Approval_email_if_no_action_is_taken_after")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtProResendApproval" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px; padding-left: 3px">
                                                <%=objLanguage.GetLanguageConversion("Auto_Reject_delete_users_if_no_action_taken_after")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtProDeleteOrders" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px; padding-left: 3px">
                                                <%=objLanguage.GetLanguageConversion("Inform_Admin_about_Pending_Approval_if_not_approved_in")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtProInformAdmin" Width="50px" Style="text-align: right" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                                            <div style="float: left; padding-left: 5px; padding-top: 5px">
                                                <%=objLanguage.GetLanguageConversion("Days_In_Small")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="innercells" style="width: 60%">
                                            <div style="float: left; padding-top: 5px; padding-left: 3px">
                                                <%=objLanguage.GetLanguageConversion("Auto_Approve_users_with_email_address_containing")%>
                                            </div>
                                        </td>
                                        <td class="innercells" style="width: 30%">
                                            <div style="float: left; padding-left: 5px">
                                                <asp:TextBox ID="txtAutoEmail" runat="server" Width="200px" Style="font-family: Verdana,Arial,sans-serif;
                                                    font-size: 11px;"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr id="tr_EditProfileApproval">
                    <td colspan="2" style="width: 100%;">
                        <div style="float: left;">
                            <asp:CheckBox ID="chkEditProfileApproval" runat="server" onclick="javascript:ShowEditProfilesReqApproval();return" />
                        </div>
                        <div style="float: left; padding-top: 3px; padding-left: 6px;">
                            <%=objLanguage.GetLanguageConversion("Edited_profile_also_requires_approval")%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="clear: both; padding-top: 10px">
    </div>
    <div>
        <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClientClick="javascript:return ValidateApprovalSystem();"
            OnClick="btnSaveSettings_Click" Text="Save" />
        <asp:Button ID="btnRevert" runat="server" CssClass="button" OnClick="btnRevert_Click"
            Style="display: none;" Text="Save" />
    </div>
    <asp:HiddenField ID="hdnPendCount" runat="server" Value="" />
    <asp:HiddenField ID="hdnchkmain" runat="server" Value="" />
    <asp:HiddenField ID="hdnDeptApprove" runat="server" Value="" />
    <asp:HiddenField ID="hdnchkMarkalltheitemsasApproved" runat="server" Value="" />
    <asp:HiddenField ID="hdnRepprovalByMainApp" runat="server" Value="" />
    <asp:HiddenField ID="hdnRequirePWD" runat="server" Value="" />
    <asp:HiddenField ID="hdnMainApprove" runat="server" Value="" />
    <asp:HiddenField ID="hdnUserDesignatedApp" runat="server" Value="" />
    <asp:HiddenField ID="hdnUserDesignateOwnApprover" runat="server" Value="" />
    <asp:HiddenField ID="hdnDAEmailAddEndsWith" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtEmailEndsWith" runat="server" Value="" />
    <asp:HiddenField ID="hdnLastDADefault" runat="server" Value="" />
    <asp:HiddenField ID="hdnNewOrderApproval" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtOrderForValues" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtOrdResendApproval" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtDeleteOrders" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtAutoChangesStatus" runat="server" Value="" />
    <asp:HiddenField ID="hdnddlstatus" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtOrdInformAdmin" runat="server" Value="" />
    <asp:HiddenField ID="hdnEditProfileApproval" runat="server" Value="" />
    <asp:HiddenField ID="hdnNewProfileApproval" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtProResendApproval" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtProDeleteOrders" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtProInformAdmin" runat="server" Value="" />
    <asp:HiddenField ID="hdntxtAutoEmail" runat="server" Value="" />
    <asp:HiddenField ID="hdnRegReqApproval_History" runat="server" Value="" />
    <asp:HiddenField ID="hdnEditProfileReqApproval_History" runat="server" Value="" />
    <asp:HiddenField ID="hdnNewOrderReqApproval_History" runat="server" Value="" />
    <asp:HiddenField ID="hdnPreviousApprovalType" runat="server" Value="" />
    <script type="text/javascript">
        function RevertType() {
           // alert('You are not authorised to change the Approval type since you have some pending Orders/Edit Profiles/Users which are need to be approved');
            alert('You can not change the approval settings while you have pending orders, profile edits, or users that require approval');
            var btnRevert = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_btnRevert");
            btnRevert.click();
        }



        function CheckUncheck() {

            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoPrefilcontact");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_RdoAllowuser");

            if (chk1.checked) {

                chk2.checked = false;
            }
            else {
                chk1.checked = false;
            }
        }

        function CheckUncheck1() {

            var chk1 = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_rdoPrefilcontact");
            var chk2 = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_RdoAllowuser");

            if (chk2.checked) {

                chk1.checked = false;
            }
            else {
                chk2.checked = false;
            }
        }

        function disableenable() {

            if (document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkAppSys_Enable").checked) {
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRequirePWD").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignateOwnApprover").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDAEmailAddEndsWith").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtEmailEndsWith").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignatedApp").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkLastDADefault").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrderForValues").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdResendApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtDeleteOrders").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_ddl_Status").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoChangesStatus").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdInformAdmin").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProResendApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProDeleteOrders").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProInformAdmin").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoEmail").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkSelfApproval").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMarkalltheitemsasApproved").disabled = false;

            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkRequirePWD").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignateOwnApprover").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDAEmailAddEndsWith").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtEmailEndsWith").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewOrderApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkNewProfileApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkEditProfileApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMainApprove").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkUserDesignatedApp").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkLastDADefault").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrderForValues").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdResendApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtDeleteOrders").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_ddl_Status").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoChangesStatus").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtOrdInformAdmin").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProResendApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProDeleteOrders").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtProInformAdmin").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_txtAutoEmail").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkSelfApproval").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMarkalltheitemsasApproved").disabled = true;
            }
        }
        disableenable();
    </script>
    <script language="javascript" type="text/javascript">
        function Check_uncheck_DeptApprove() {
            var chkMain = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkMain");
            var chkDeptApprove = document.getElementById("ctl00_ContentPlaceHolder1_ApprovalSystem_chkDeptApprove");
            if (chkMain.checked == false && chkDeptApprove.checked == true) {
                chkDeptApprove.checked = false;
                ShowDepartmentApprovers();
            }
        }
    </script>
</body>
</html>

