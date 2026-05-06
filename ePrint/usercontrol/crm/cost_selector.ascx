<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cost_selector.ascx.cs" Inherits="ePrint.usercontrol.crm.cost_selector" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content" style="width: 550px">
    <div align="left" style="float: left; width: 550px;">
        <table border="0" class="outerTable" cellpadding="0" cellspacing="0" width="550px">
            <tr>
                <td style="width: 10%;">
                    <span class="bglabelnew" style="width: 91%; margin-left: 1px">
                        <%=objLangClass.GetLanguageConversion("Code")%><span style="color: red;"> *</span></span>
                </td>
                <td class="box" valign="top">
                    <asp:TextBox ID="txtcostcentercode" Width="300px" CssClass="textboxnew" runat="server" onblur="javascript:checkCostDuplicacy(this.value);" onKeydown="Javascript: if(event.keyCode==13) return false;"
                        Text='<%# Bind("CostCentreCode") %>'></asp:TextBox>
                    <span id="spanDeptName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">Please Enter Cost Centre
                    </span>
                    <%--<asp:RequiredFieldValidator ID="RFVtxtcostcentercode" runat="server" ErrorMessage="Please enter cost"
                        ControlToValidate="txtcostcentercode" CssClass="errorMsg box" Display="Dynamic"
                        ForeColor="" Style="width: auto; padding-left: 4px; margin-top: 3px; padding-right: 4px;
                        display: none"></asp:RequiredFieldValidator>--%>
                    <asp:HiddenField ID="hdncostcenterid" Value='<%# Bind("CostCentreID") %>' runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    <span class="bglabelnew" style="width: 91%; margin-left: 1px">
                        <%=objLangClass.GetLanguageConversion("Name")%><span style="color: red;"> *</span></span>
                </td>
                <td class="box" valign="top">
                    <asp:TextBox ID="txtcostcentername" runat="server" CssClass="textboxnew" Text='<%# Bind("CostCentreName") %>'
                        Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtcostcentername" runat="server" ErrorMessage="Please enter name"
                        Style="width: auto; padding-left: 4px; padding-right: 4px; margin-top: 3px; display: none"
                        ControlToValidate="txtcostcentername" CssClass="errorMsg box" Display="Dynamic"
                        ForeColor=""></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 3px; width: 10%"></td>
                <td align="left">
                    <asp:CheckBox ID="chk_CostDefault" runat="server" />
                    <span style="width: 91%; margin-left: -4px">
                        <%=objLangClass.GetLanguageConversion("Make_this_as_Default")%></span>
                    <asp:HiddenField ID="hdn_Defaultcostcenter" runat="server" Value='<%#Bind("IsDefault")%>' />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;"></td>
                <td align="left">
                    <asp:CheckBox ID="chk_ApplyDept" runat="server" />
                    <span style="width: 91%; margin-left: -4px">
                        <%=objLangClass.GetLanguageConversion("Apply_to_all_existing_department")%></span>
                    <asp:HiddenField ID="hdn_applydepy" runat="server" Value='<%#Bind("IsApplyDepartment")%>' />
                </td>
            </tr>
            <tr>
                <td style="height: 3px;" colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 20%"></td>
                <td>
                    <div id="div_cancel" runat="server" style="float: left; margin: 0px 10px 0px 0px;">
                        <div id="div_btncancel" style="display: block">
                            <asp:Button ID="btncancel" Text='<%#objLangClass.GetLanguageConversion("Cancel") %>'
                                CommandName="Cancel" runat="server" CssClass="button" CausesValidation="false"
                                OnClick="btncancel_Click" OnClientClick="javascript:return loadingimage(this.id,'div_cancelprocess')" />
                        </div>
                        <div id="div_cancelprocess" class="button" align="center" style="width: 35px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                    <div id="div_add" runat="server" style="float: left; display: block">
                        <div id="div_btnadd" style="display: block">
                            <asp:Button ID="btnsave" Text='<%#objLangClass.GetLanguageConversion("Save") %>'
                                runat="server" Style="margin-left: 3px" CssClass="button" OnClick="btnsave_Click" OnClientClick="javascript:var a=validate('save');if(a)loadingimg('div_btnadd','div_btnaddprocess');return a;" />
                        </div>
                        <div id="div_btnaddprocess" class="button" align="center" style="width: 35px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="300" Height="250" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript" language="javascript">

    var txtcostcentercode = document.getElementById("<%=txtcostcentercode.ClientID %>");
    var hdncostcenterid = document.getElementById("<%=hdncostcenterid.ClientID %>");

    var hdn_Defaultcostcenter = document.getElementById("<%=hdn_Defaultcostcenter.ClientID %>");
    var hdn_applydepy = document.getElementById("<%=hdn_applydepy.ClientID %>");


</script>
<script type="text/javascript" language="javascript">

    function Close() {
        var oWindow = GetRadWindow();
        oWindow.close();
    }

    function CloseSave() {
        var oWindow = GetRadWindow();
        oWindow.close();
        oWindow.BrowserWindow.location.reload();
    }

    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>
<script language="javascript" type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    var ClientID = '<%=ClientID %>';
    var CompanyID = '<%=CompanyID %>';
    var CostID = '<%=CostID %>';
    var mode = '<%=mode %>';
    var rtnCostID = '<%=rtnCostID %>';

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
        AutoFill.Check_Cost_Centre_Duplicacy(CompanyID, ClientID, DeptName, CostID, GetResult, onTimeout1, onError1);
    }



    function validate(val) {
        debugger;
        asyncState = false;
        var flag = true;
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
<%--<div>
    <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="Please Enter Code"
        ValidationGroup="Save" ControlToValidate="txtcostcentercode" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="Please Enter Name"
        ValidationGroup="Save" ControlToValidate="txtcostcentername" Display="None"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Save"
        ShowMessageBox="True" ShowSummary="False" />
</div>--%>

<asp:Panel ID="pnlCostCenter" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">


        function SendCostCenter() {
            var pw = window.parent;
            pw.SetTabs('CostCenter', 'yes');
            setTimeout("TakeOut()", 600);
            return false;
        }
        function TakeOut() {
            window.close();
        }
        SendCostCenter();
    </script>
</asp:Panel>
