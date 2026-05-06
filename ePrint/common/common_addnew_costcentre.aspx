<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/loginPopoupMaster.master" AutoEventWireup="true" CodeBehind="common_addnew_costcentre.aspx.cs" Inherits="ePrint.common.common_addnew_costcentre" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
        rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>

    <div id="divBackGroundNew" style="display: none;">
    </div>
    <table style="margin-left: 3px; margin-top: -10px; margin-bottom: -3px;" width="100%"
        align="center">
        <tr>
            <td class="bglabel" style="width: 92%; margin: 0px">
                <div>
                    <asp:Label ID="lblcostcode" runat="server"><%=objLanguage.GetLanguageConversion("Code") %></asp:Label>
                    <span style="color: Red; margin-left: 2px">*</span>
                </div>
            </td>

            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

            <td valign="top" style="width: 70%">
                <asp:TextBox ID="txtcostcentercode" Width="200px" runat="server" Text='<%# Bind("CostCentreCode") %>'
                    AutoCompleteType="disabled" CssClass="textboxnew" onblur="javascript:checkCostDuplicacy(this.value);" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                <span id="spanDeptName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">Please Enter Cost Centre
                </span>
                <asp:HiddenField ID="hdncostcenterid" Value='<%# Bind("CostCentreID") %>' runat="server" />
                <%--<div>
                    <asp:RequiredFieldValidator ID="rfv_txtcostcentercode" runat="server" CssClass="RFV_Message"
                        Display="Dynamic" ControlToValidate="txtcostcentercode" ForeColor="" Style="width: auto;
                        padding-left: 4px; padding-right: 4px;">
                    <%=objLanguage.GetLanguageConversion("Please_enter_CostCenter_Code")%></asp:RequiredFieldValidator>
                </div>--%>
            </td>
        </tr>
        <tr>
            <td class="bglabel" style="width: 92%">
                <div>
                    <asp:Label ID="lbl_costcentername" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Name") %></asp:Label>
                    <span style="color: Red; margin-left: 2px">*</span>
                </div>
            </td>
            <td valign="top" style="width: 70%">
                <asp:TextBox ID="txtcostcentername" runat="server" Text='<%# Bind("CostCentreName") %>'
                    Width="200px" CssClass="textboxnew"></asp:TextBox>
                <div>
                    <div>
                        <asp:RequiredFieldValidator ID="rfv_txtcostcentername" runat="server" CssClass="RFV_Message"
                            Display="Dynamic" ControlToValidate="txtcostcentername" ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px">
                        <%=objLanguage.GetLanguageConversion("Please_enter_CostCenter_Name")%></asp:RequiredFieldValidator>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 3px"></td>
            <td>
                <asp:CheckBox ID="chk_CostDefault" runat="server" Text="Make this as Default." />
                <asp:HiddenField ID="hdn_Defaultcostcenter" runat="server" Value='<%#Bind("IsDefault")%>' />
            </td>
        </tr>
        <tr style="height: 2px">
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="chk_ApplyDept" runat="server" Text="Apply to all existing department" />
                <asp:HiddenField ID="hdn_applydepy" runat="server" Value='<%#Bind("IsApplyDepartment")%>' />
            </td>
        </tr>
        <tr>
        </tr>
        <tr style="height: 10px">
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="button" OnClientClick="javascript:return window.close();" />
                <div id="div_btnadd" style="display: block">
                    <asp:Button ID="btnsave" Text="Save" runat="server" OnClick="btnsave_onclick" OnClientClick="javascript:var a=validate('save');if(a)loadingimg_1('div_btnadd','div_btnaddprocess');return a;" Style="margin-left: 3px"
                        CssClass="button" />
                </div>
                <div id="div_btnaddprocess" class="button" align="center" style="width: 35px; display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                </div>
            </td>
        </tr>
    </table>
    <script>

        function loadingimg_1(div1, div2) {
            document.getElementById(div1).style.display = "none";
            document.getElementById(div2).style.display = "block";
        }


        var DepartmentID =<%=DepartmentID%>;
        var ClientID =<%=ClientID %>;
        var CompanyID =<%=CompanyID %>;
        var costcentreid =<%=CostCentreID%>;

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function LoadCostCentre() {
            debugger;
            var pw = window.parent;
            pw.CallLoadCostCentre(CompanyID, ClientID, DepartmentID, costcentreid);

        }

        ///////////////////////////////////////////////////////////////////////////


        var ChkDeptDuplicacy = false;

        function onTimeout1(request, context) { }

        function onError1(objError) { }

        function GetResult(results) {
            var flag = true;
            if (results == -1) {
                spanDeptName.innerHTML = "Cost centre already exists";
                spanDeptName.style.display = "block";
                ChkDeptDuplicacy = true;
                flag = false;
            }
            else {
                spanDeptName.style.display = "none";
                ChkDeptDuplicacy = false;
                flag = true;
            }

            if (flag)
                return true;
            else
                return false;
        }

        function checkCostDuplicacy(DeptName) {
            debugger;
            DeptName = SpecialEncode(DeptName)
            PageMethods.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, costcentreid, GetResult, onTimeout1, onError1);
        }



        function validate(val) {
            debugger;
            asyncState = false;
            var flag = true;
            var txtcostcentercode = document.getElementById("ctl00_ContentPlaceHolder1_txtcostcentercode");
            if (val == 'save') {
                CallonBlur(txtcostcentercode.value, 'spanDeptName');

                if (trim12(txtcostcentercode.value) == '') {
                    spanDeptName.style.display = "block";
                    flag = false;
                }
                else if (txtcostcentercode.value != '') {
                    checkCostDuplicacy(SpecialEncode(txtcostcentercode.value));
                    if (ChkDeptDuplicacy) {
                        flag = false;
                    }
                }
            }

            if (flag)
                return true;
            else
                return false;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


