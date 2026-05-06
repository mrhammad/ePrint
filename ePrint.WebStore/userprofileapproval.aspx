<%@ page language="C#" autoeventwireup="true" masterpagefile="~/templates/MasterPageDefault.master" CodeBehind="userprofileapproval.aspx.cs" Inherits="ePrint.WebStore.userprofileapproval" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script src="js/commonloading.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateExistanceOfPassword(Value, StoreUserID) {
            AutoFill.ExistanceOfPassword(Value, StoreUserID, GetApproverID);
        }
        function GetApproverID(result) {
            if (result != 0) {
                return true;
            }
            else {
                //alert("designated approver Password not contains in this Account");

                return false;
            }
        }
    </script>
    <div id="UserProfileApproval">
        <div id="createAccountMain_div">
            <div id="createAccount_background">
                <div id="createAccount_content">
                    <asp:Panel ID="UserDetailPanel" runat="server">
                        <div class="Header_Background">
                            <strong>The following user edit this field and request to approve</strong>
                        </div>
                        <table class="ApprovalTable">
                            <tr>
                                <td class="ApprovalTable_Td1">
                                    <asp:Label ID="firstName" runat="server" Text="First Name "></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td2">
                                    <asp:Label ID="lblFirstname" runat="server"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td3 fontBold">
                                    <asp:Label ID="lbllast" runat="server" Text="Last Name "></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td5">
                                    <asp:Label ID="lbllastName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="paddingTop5">
                                </td>
                            </tr>
                            <tr>
                                <td class="ApprovalTable_Td3 fontBold paddingTop5">
                                    <asp:Label ID="lblMiddle" runat="server" Text="Home Address"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td2 paddingTop5">
                                    <asp:Label ID="lblHomeAddress" runat="server"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td3 fontBold paddingTop5 DisplayNone">
                                    <asp:Label ID="lblDepartment" runat="server" Text="Department Echo"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td2 fontBold paddingTop5 DisplayNone">
                                    <asp:Label ID="lblDepartmentEcho" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div id="DivAddress" runat="server">
                            <div class="lblContactDiv">
                                <asp:Label ID="Label6" CssClass="contactAddressTest" runat="server" Text="Contact Address"></asp:Label>
                            </div>
                            <table class="ApprovalTable">
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lbl_BillAddress1" runat="server" Text="Address1"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblBillAddress1" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lbl_BillAddress2" runat="server" Text="Address2"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblBillAddress2" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lbl_BillCity" runat="server" Text="Address3"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblAddress3" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lbl_BillState" runat="server" Text="Address4"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblAddress4" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lblBillZipCode" runat="server" Text="Address5"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblAddress5" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lblBillCountry" runat="server" Text="Country "></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lblBillTelephone" runat="server" Text="Telephone "></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblTelephone" runat="server"></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ProfileText2">
                                        <asp:Label ID="lblBillFax" runat="server" Text="Fax"></asp:Label>
                                    </td>
                                    <td class="Padding2">
                                        <asp:Label ID="lblFax" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="heightAuto paddingBottom5">
                            <br />
                            <asp:Label ID="lblContact" CssClass="contactAddressTest" runat="server" Text="Login Information"></asp:Label>
                        </div>
                        <table class="ApprovalTable">
                            <tr>
                                <td class="ProfileText3">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
                                </td>
                                <td class="Padding4">
                                    <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td3 ProfileText">
                                    <asp:Label ID="LblPass" runat="server" Text="Password"></asp:Label>
                                </td>
                                <td class="ApprovalTable_Td3 Padding">
                                    <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="lblContactDiv" id="div_Approver_Header" runat="server">
                            <asp:Label ID="Label4" CssClass="contactAddressTest" runat="server" Text="Approver Email Address"></asp:Label>
                        </div>
                        <table class="ApprovalTable">
                            <tr>
                                <td class="ProfileText2">
                                    <asp:Label ID="lblEmail1" runat="server" Text="Email Address"></asp:Label>
                                </td>
                                <td class="Padding">
                                    <asp:Label ID="lblApproverEmail" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div id="DivApproverPassword" runat="server">
                            <div class="lblApproverPasswordDiv" id="div1" runat="server">
                                <asp:Label ID="Label5" CssClass="contactAddressTest" runat="server" Text="Please Enter Approver Password"></asp:Label>
                            </div>
                            <table class="ApprovalTable">
                                <tr>
                                    <td class="Padding3">
                                        <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
                                        <label id="Label2" class="mandatoryField">
                                            *</label>
                                    </td>
                                    <td class="Padding paddingLeft5">
                                        <div>
                                            <asp:TextBox ID="txtApproverPassword" TextMode="Password" class="ws_txtWidth260"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblReqiPassword" runat="server" Visible="false" CssClass="ColorRed"><%=objLanguage.GetLanguageConversion("Approver_password_not_contains_in_this_Account")%></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table>
                            <tr>
                                <td class="PaddingButton">
                                    <div id="divDisApproved" runat="server" class="DisplayBlock floatLeft">
                                        <asp:Button ID="btnDisapproved" runat="server" class="x-btnpro Grey main" Text="Reject"
                                            OnClientClick="javascript:loadingimg('ctl00_ContentPlaceHolder1_divDisApproved','DicDisLoading');return false;"
                                            OnClick="btnDisapproved_Click" ValidationGroup="EditAccount" />
                                    </div>
                                    <div id="DicDisLoading" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>images/radimg1.gif" class="loadingImgPosition" alt="loading"
                                            border="0" />
                                    </div>
                                </td>
                                <td class="PaddingButton clearLeft">
                                    <div id="div_Approved" runat="server" class="DisplayBlock floatLeft">
                                        <asp:Button ID="btnApproved" runat="server" class="x-btnpro Grey main" OnClientClick="javascript:loadingimg('ctl00_ContentPlaceHolder1_div_Approved','div_btnsaveprocess'); return false;"
                                            Text="Approve" OnClick="btnApproved_Click" ValidationGroup="EditAccount" />
                                    </div>
                                    <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>images/radimg1.gif" class="loadingImgPosition" alt="loading"
                                            border="0" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div class="EmptyCell">
                        </div>
                        <telerik:RadWindow ID="RadWindow2" Skin="Default" runat="server" Height="210px" Width="450px"
                            EnableShadow="true" VisibleOnPageLoad="true" Visible="false" Top="250px" Left="510px"
                            ShowContentDuringLoad="false" Behaviors="Close,Move,Reload">
                            <ContentTemplate>
                                <div class="disapprove_WindowDiv">
                                    <table border="0" cellpadding="0" cellspacing="0" class="width100p">
                                        <tr>
                                            <td class="disapprove_WindowTbl_TD1">
                                                <asp:Label ID="lblDis" runat="server" Text="Reject Reason"></asp:Label>
                                                <label id="Label3" class="mandatoryField">
                                                </label>
                                            </td>
                                            <td>
                                                <div>
                                                    <asp:TextBox ID="txtDisApproved" runat="server" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                                <div class="Validationfont ColorRed">
                                                    <asp:RequiredFieldValidator ID="RequiredlstDepartment" runat="server" ValidationGroup="Reject"
                                                        ControlToValidate="txtDisApproved" Display="Dynamic" ErrorMessage="Please Enter Reject Reason">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="clearTop">
                                                <asp:Button ID="btnOk" runat="server" class="x-btnpro Grey main" OnClick="btnOk_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function loadingimg(div1, div2) {
            document.getElementById(div1).style.display = "none";
            document.getElementById(div2).style.display = "block";
            window.radopen("RadWindowReason");
        }
    </script>
</asp:Content>
