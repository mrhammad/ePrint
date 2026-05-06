<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="roles_edit.aspx.cs" Inherits="ePrint.settings.roles_edit" title="Settings: Role Edit" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="../common/usertype.js?VN='<%=VersionNumber%>'"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="../js/approvalsystem.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var IsWebStore = "<%=IsWebStore %>";
        function RemoveZeros(sender, args) {
            var tbValue = sender._textBoxElement.value;
            if (tbValue.indexOf(".00") != -1)
                sender._textBoxElement.value = tbValue.substr(0, tbValue.indexOf(".00"));
        }

        function ShowTypeList() {
            var Type = document.getElementById("ctl00_ContentPlaceHolder1_rdoShowType");
            if (Type.checked) {
                document.getElementById("divType").style.display = "block";
            }
            else {
                document.getElementById("divType").style.display = "none";
            }
        }

        function ReportCheck(id, count) {
            var ChkBxID = id;
            var ChkBxCount = count;
            if (document.getElementById(id).checked) {
                for (var i = 0; i < count; i++) {
                    var ChkShowReport = "ctl00_ContentPlaceHolder1_chk_ShowReport" + i;
                    document.getElementById(ChkShowReport).checked = true;
                    document.getElementById(ChkShowReport).disabled = false;
                    var ChkExportReport = "ctl00_ContentPlaceHolder1_chk_ExportReport" + i;
                    document.getElementById(ChkExportReport).checked = true;
                    document.getElementById(ChkExportReport).disabled = false;
                }
            }
            else {
                for (var i = 0; i < count; i++) {
                    var ChkShowReport = "ctl00_ContentPlaceHolder1_chk_ShowReport" + i;
                    document.getElementById(ChkShowReport).checked = false;
                    document.getElementById(ChkShowReport).disabled = true;
                    var ChkExportReport = "ctl00_ContentPlaceHolder1_chk_ExportReport" + i;
                    document.getElementById(ChkExportReport).checked = false;
                    document.getElementById(ChkExportReport).disabled = true;
                }
            }
        }

        function SelectAll_None(id, module, count) {
            debugger;
            var ModuleType = module;
            var ModuleCount = count;
            var SelectText = document.getElementById(id).innerHTML;

            var ChkShow = "ctl00_ContentPlaceHolder1_chk_Show" + ModuleCount;
            var ChkRead = "ctl00_ContentPlaceHolder1_chk_Read" + ModuleCount;
            var ChkAddEdit = "ctl00_ContentPlaceHolder1_chk_AddEdit" + ModuleCount;
            var ChkDelete = "ctl00_ContentPlaceHolder1_chk_Delete" + ModuleCount;
            var ChkArchive = "ctl00_ContentPlaceHolder1_chk_Archive" + ModuleCount;
            var ChkOthers = "ctl00_ContentPlaceHolder1_chk_Others" + ModuleCount;
            var ChkPrintEmail = "ctl00_ContentPlaceHolder1_chk_PrintEmail" + ModuleCount;
            var ChkExportImport = "ctl00_ContentPlaceHolder1_chk_ExportImport" + ModuleCount;
            var ChkRevert = "ctl00_ContentPlaceHolder1_chk_Revert" + ModuleCount;
            var ChkeStore = "ctl00_ContentPlaceHolder1_chk_eStore" + ModuleCount;

            var chk_CallTask = "ctl00_ContentPlaceHolder1_chk_CallTask" + ModuleCount;
            var chk_Forecast = "ctl00_ContentPlaceHolder1_chk_Forecast" + ModuleCount;
            var ChkRemove = "ctl00_ContentPlaceHolder1_chk_Remove" + ModuleCount;

            if (SelectText == "Select None") {
                if (module == "clients") {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                    document.getElementById(ChkOthers).checked = false;
                    document.getElementById(chk_CallTask).checked = false;
                    document.getElementById(chk_Forecast).checked = false;
                }
                else if (module == "estimates" || module == "purchases" || module == "invoices" || module == "webstoreorder") {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                    document.getElementById(ChkOthers).checked = false;
                    document.getElementById(ChkPrintEmail).checked = false;
                    document.getElementById(ChkRemove).checked = false;
                }
                else if (module == "digitalasset" || module == "campaign") {
                    document.getElementById(ChkShow).checked = false;
                }
                else if (module == "jobs") {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                    document.getElementById(ChkOthers).checked = false;
                    document.getElementById(ChkPrintEmail).checked = false;
                    document.getElementById(ChkRevert).checked = false;
                    document.getElementById(ChkRemove).checked = false;
                }
                else if (module == "deliverynote") {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                    document.getElementById(ChkPrintEmail).checked = false;
                    document.getElementById(ChkRemove).checked = false;
                }
                else if (module == "warehouse") {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                    document.getElementById(ChkOthers).checked = false;
                    document.getElementById(ChkExportImport).checked = false;
                }
                else if (module == "settings") {
                    document.getElementById(ChkShow).checked = false;
                    if (IsWebStore == "yes") {
                        document.getElementById(ChkeStore).checked = false;
                    }
                }
                else {
                    document.getElementById(ChkShow).checked = false;
                    document.getElementById(ChkRead).checked = false;
                    document.getElementById(ChkAddEdit).checked = false;
                    document.getElementById(ChkDelete).checked = false;
                    document.getElementById(ChkArchive).checked = false;
                }
                document.getElementById(id).innerHTML = "Select All";
            }
            else if (SelectText == "Select All") {
                if (module == "clients") {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                    document.getElementById(ChkOthers).checked = true;
                    document.getElementById(chk_CallTask).checked = true;
                    document.getElementById(chk_Forecast).checked = true;
                }
                else if (module == "estimates" || module == "purchases" || module == "invoices" || module == "webstoreorder") {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                    document.getElementById(ChkOthers).checked = true;
                    document.getElementById(ChkPrintEmail).checked = true;
                    document.getElementById(ChkRemove).checked = true;
                }
                else if (module == "digitalasset" || module == "campaign") {
                    document.getElementById(ChkShow).checked = true;
                }
                else if (module == "jobs") {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                    document.getElementById(ChkOthers).checked = true;
                    document.getElementById(ChkPrintEmail).checked = true;
                    document.getElementById(ChkRevert).checked = true;
                    document.getElementById(ChkRemove).checked = true;
                }
                else if (module == "deliverynote") {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                    document.getElementById(ChkPrintEmail).checked = true;
                    document.getElementById(ChkRemove).checked = true;
                }
                else if (module == "warehouse") {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                    document.getElementById(ChkOthers).checked = true;
                    document.getElementById(ChkExportImport).checked = true;
                }
                else if (module == "settings") {
                    document.getElementById(ChkShow).checked = true;
                    if (IsWebStore == "yes") {
                        document.getElementById(ChkeStore).checked = true;
                    }
                }
                else {
                    document.getElementById(ChkShow).checked = true;
                    document.getElementById(ChkRead).checked = true;
                    document.getElementById(ChkAddEdit).checked = true;
                    document.getElementById(ChkDelete).checked = true;
                    document.getElementById(ChkArchive).checked = true;
                }
                document.getElementById(id).innerHTML = "Select None";
            }
        }

        function IPFieldsEnable(ID) {
            document.getElementById("ctl00_ContentPlaceHolder1_lblMultipleIP_Condition").innerHTML = "";

            document.getElementById("ctl00_ContentPlaceHolder1_txtSingleIP").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtMultipleIP").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtFromIP").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_txtToIP").disabled = true;

            if (ID == "rdoSingleIP") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtSingleIP").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtSingleIP").focus();
            }
            else if (ID == "rdoMultipleIP") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtMultipleIP").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtMultipleIP").focus();
                document.getElementById("ctl00_ContentPlaceHolder1_lblMultipleIP_Condition").innerHTML = "";
            }
            else if (ID == "rdoRangeIP") {
                document.getElementById("ctl00_ContentPlaceHolder1_txtFromIP").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtToIP").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_txtFromIP").focus();
            }
        }

    </script>
    <script type="text/javascript" language="javascript">

        function Chk_Show(id, POS) {
            debugger;
            var chk = document.getElementById(id);
            if (chk.checked) {
                var ChkShow = "ctl00_ContentPlaceHolder1_chk_Show" + POS;
                document.getElementById(ChkShow).checked = true;
            }
        }
    </script>
    <style type="text/css">
        .Header
        {
            background-image: url(../images/header_bg.png);
            background-repeat: repeat-x;
            height: 26px;
            font-family: Verdana,Arial,Helvetica,sans-serif;
            font-size: 10px;
            font-weight: bold;
            color: #454545;
        }
        
        .divRightsNPrivileges
        {
            width: 100%;
            margin-top: 5px;
            padding-bottom: 5px;
            background-color: #EFEFEF;
        }
    </style>
    <script src="../js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ShowType = document.getElementById("ctl00_ContentPlaceHolder1_rdoShowType");
            var ShowAll = document.getElementById("ctl00_ContentPlaceHolder1_rdoShowAll");
            var ShowAllocation = document.getElementById("ctl00_ContentPlaceHolder1_rdoShowAllocation");
            var divType = document.getElementById("divType");
            $(ShowAll).click(function () {
                $(divType).show('slow');
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").disabled = true;
            });
            $(ShowAllocation).click(function () {
                $(divType).show('slow');
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").disabled = true;
            });
            $(ShowType).click(function () {
                $(divType).show('slow');
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").focus();
            });
        });

        function Testtype() {

            var MultipleType = document.getElementById("ctl00_ContentPlaceHolder1_rdoShowType");

            if (MultipleType.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_lstBxType").focus();

            }
        }

    </script>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objlang.GetLanguageConversion("Settings")%>:&nbsp;<%=objlang.GetLanguageConversion("Edit_Role")%></asp:Label>
                        </div>
                    </div>
                </div>
            </div>Inventory
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel">
            <div style="width: 100%;">
                <div align="left">
                    <div style="float: left; padding-left: 5px; padding-top: 5px; width: 100%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div id="padding">
                    <%--<div style="width: 100%; border: 0px solid">
                        <div align="right">
                            <span style="color: red;">*<%=objlang.GetLanguageConversion("fields_are_mandatory")%></span>
                        </div>
                    </div>--%>
                    <div align="left">
                        <div align="left" style="border: solid 0px red; width: 100%;">
                            <div align="left">
                                <div class="bglabel" style="float: left; width: 13%;">
                                    <%=objlang.GetLanguageConversion("Role_Name")%><span style="color: red">*</span>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtrole" runat="server" CssClass="txtBox" Width="175.5px" SkinID="textPad"></asp:TextBox>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="float: left; width: 13%; height: 30px">
                                    <%=objlang.GetLanguageConversion("Description")%>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtDescription" CssClass="txtBox" TextMode="MultiLine" SkinID="textPad"
                                        Width="175.5px" Height="35px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Panel ID="pnlDefaultRoles" runat="server">
                                <div style="clear: both;">
                                    &nbsp;</div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 13%;">
                                        <b>
                                            <%=objlang.GetLanguageConversion("Privilege_Rights")%></b>
                                    </div>
                                    <div style="float: left; width: 15px">
                                    </div>
                                    <span style="padding-left: 10px; padding-top: 4px; float: left"><b>
                                        <%=objlang.GetLanguageConversion("Tabs_available_for_this_role")%>:</b> </span>
                                </div>
                                <div style="clear: both; padding-top: 2px">
                                </div>
                                <div style="float: left; padding-left: 15%;">
                                    <div style="float: left; width: 60%;">
                                        <asp:PlaceHolder ID="plhaddusertype" runat="server"></asp:PlaceHolder>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;
                                </div>
                                <div id="div_SpecialPrivileges" runat="server">
                                    <div class="bglabel" style="float: left; width: 13%;">
                                        <%=objlang.GetLanguageConversion("Special_Privileges")%>
                                    </div>
                                    <span style="padding-left: 1%; float: left">
                                        <asp:CheckBox ID="chkbxSpecialPrivileges" runat="server" /></span>
                                    <div class="smallgraytext" style="padding-left: 2px; padding-top: 3px; float: left">
                                        <%=objLanguage.GetLanguageConversion("Hide_the_mark_up")%>
                                    </div>
                                </div>
                                <div id="div_msgForAdmin" runat="server" visible="false">
                                    <div style="clear: both">
                                        &nbsp;</div>
                                    <div style="float: left; width: 15%;">
                                        &nbsp;
                                    </div>
                                    <div class="smallgraytext">
                                        <%=objlang.GetValueOnLang("This is the default super admin access to the system and hence cannot be changed")%></div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;
                                </div>
                                <div align="left" style="width: 100%; display: block;">
                                    <div style="float: left; width: 15%;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <div style="float: left;">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="button" Visible="false" Text="Back"
                                                CausesValidation="false" OnClientClick="javascript:return cancelClick(path+'Settings/user_manager.aspx');" />
                                        </div>
                                        <div style="float: left">
                                            <div id="div_btndelete_default" style="display: block">
                                                <asp:Button ID="btnDeleteDefault" runat="server" CssClass="button" Text="Delete"
                                                    CausesValidation="false" OnClick="btnDelete_OnClick" />
                                            </div>
                                            <div id="div_deleteprocess_default" class="button" align="center" style="width: 37px;
                                                display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 5px">
                                            &nbsp;</div>
                                        <div style="float: left">
                                            <div id="div_btnsave" style="display: block">
                                                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_OnClick"
                                                    CausesValidation="true" OnClientClick="if(Page_ClientValidate()) {javascript:loadingimage(this.id,'div_btnsaveprocess');} else {return false;}" />
                                            </div>
                                            <div id="div_btnsaveprocess" class="button" align="center" style="width: 35px; display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div id="div_delcan" style="float: left; width: 10px" runat="server">
                                            &nbsp;</div>
                                        <div style="float: left; width: 10px;">
                                            &nbsp;</div>
                                        <div style="float: left; vertical-align: middle;">
                                            <b>
                                                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></b>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <asp:Panel ID="pnlCustomizeRoles" runat="server">
                <div style="padding: 20px 5px 25px 5px;">
                    <table width="100%" style="padding-left: 3px; padding-right: 3px;" align="left">
                        <tr>
                            <td>
                                <span style="font-weight: bold;">
                                    <%=objLanguage.GetLanguageConversion("Tabs_Options_available_for_this_role")%></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table width="100%" style="padding-left: 3px; padding-right: 3px;">
                        <tr>
                            <td>
                                <asp:PlaceHolder ID="plh_RolesNew" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                </div>
                  <div style="clear: both;">
                </div>
                 `<div style="padding: 20px 5px 0px 5px;">
                    <table cellpadding="2" cellspacing="0" width="1050px">
                        <tr class="Header">
                            <td width="175px" class="Font">
                                <asp:Label ID="Label12" runat="server" Text="">Locking</asp:Label>
                            </td>
                            <td width="650px">
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkLocking" runat="server" />
                            </td>
                            <td width="100px" style="padding-top: 5px">
                                <asp:Label ID="Label13" runat="server" Text="">Locking</asp:Label>
                            </td>


                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkIgnoreLocking" runat="server"/>
                            </td>
                            <td width="100px" style="padding-top:5px">
                                <asp:Label ID="lblIgnoreLocking" runat="server" Text="">Can Ignore Lock</asp:Label>
                            </td>

                        </tr>



                      
                    </table>
                </div>
                <div>
                    <table width="100%" style="margin-top: -5px; padding-left: 3px; padding-right: 3px;">
                        <tr>
                            <td>
                                <asp:PlaceHolder ID="plh_Reports" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                </div>
               
                <div style="padding: 20px 5px 0px 5px;">
                    <table cellpadding="2" cellspacing="0" width="1050px">
                        <tr class="Header">
                            <td width="175px" class="Font">
                                <asp:Label ID="lblCPM" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Cost_Profit_Margin")%></asp:Label>
                            </td>
                            <td width="650px">
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowCostExMarkup" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowCostExMarkup" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_Cost_Ex_Markup_And_Markup")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left" >
                                <asp:CheckBox ID="chkShowAdditional" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowAdditional" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_Additional")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowCostIncMarkup" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowCostIncMarkup" runat="server" Text="Show Cost Inc Markup"><%=objlang.GetLanguageConversion("Show_Cost_Inc_Markup")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowProfitMargin" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowProfitMargin" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_Profit")%>(%)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowProfitCurrency" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowProfitCurrency" runat="server"><%=objlang.GetLanguageConversion("Show_Profit")%>(<%= cmnClass.GetCurrencyinRequiredFormate("", true)%>)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowSubTotal" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowSubTotal" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_Sub_Total")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowTax" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowTax" runat="server" Text="Show Tax"><%=objlang.GetLanguageConversion("Show_Tax")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowSellingPrice" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowSellingPrice" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_Selling_Price")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowGrossProfitMargin" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowGrossProfitMargin" runat="server" Text=""><%=objlang.GetLanguageConversion("show_Gross_Profit")%>(%)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowGrossProfitCurrency" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowGrossProfitCurrency" runat="server"><%=objlang.GetLanguageConversion("Show_Gross_Profit")%>(<%= cmnClass.GetCurrencyinRequiredFormate("", true)%>)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowSupplier" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowSupplier" runat="server"><%=objlang.GetLanguageConversion("Show_Supplier_Name")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="chkShowPrice" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowPrice" runat="server"><%=objlang.GetLanguageConversion("Show_Price")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="ChkShowCalculated" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowCalculated" runat="server"><%=objlang.GetLanguageConversion("Show_Calculated_Costs")%></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="10px" align="left">
                                <asp:CheckBox ID="ChkShowSubItems" runat="server" />
                            </td>
                            <td width="650px" style="padding-top: 5px">
                                <asp:Label ID="lblShowSubItems" runat="server"><%=objlang.GetLanguageConversion("Show_Sub_Item_Costs")%></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left; vertical-align: middle; padding: 10px 5px 0px 5px;">
                    <b>
                        <asp:Label ID="lblMsg2" runat="server" Visible="false"></asp:Label></b>
                </div>
                <div style="clear: both;">
                </div>
                <div style="padding: 20px 5px 0px 5px;">
                    <div>
                        <table cellpadding="2" cellspacing="0" width="1050px">
                            <tr class="Header">
                                <td width="175px" class="Font">
                                    <asp:Label ID="lblRecordView" runat="server" Text="Records"><%=objlang.GetLanguageConversion("Records")%></asp:Label>
                                </td>
                                <td width="650px">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table width="100%">
                            <tr>
                                <td colspan="2" style="font-weight: bold;">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("For_View") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 5px">
                                    <asp:RadioButton ID="rdoShowAll" runat="server" GroupName="Show" /><%--onClick="javascript:ShowTypeList();" --%>
                                </td>
                                <td width="90%" style="padding-top: 8px">
                                    <asp:Label ID="Label1" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_all_Records")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 5px">
                                    <asp:RadioButton ID="rdoShowAllocation" runat="server" GroupName="Show" />
                                </td>
                                <td width="90%" style="padding-top: 8px">
                                    <asp:Label ID="Label2" runat="server" Text=""> <%=objlang.GetLanguageConversion("Show_as_per_allocation_Sales_Persons")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 5px">
                                    <asp:RadioButton ID="rdoShowType" runat="server" GroupName="Show" onclick="javascript:Testtype()" />
                                </td>
                                <td width="90%" style="padding-top: 8px">
                                    <asp:Label ID="Label3" runat="server" Text=""><%=objlang.GetLanguageConversion("Show_as_per_allocation_Customer_Type")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 0px">
                                </td>
                                <td width="90%" style="padding-top: 3px">
                                    <div id="divType" style="display: block;">
                                        <asp:ListBox ID="lstBxType" SelectionMode="Multiple" runat="server" Width="225px">
                                        </asp:ListBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="font-weight: bold; padding-top: 8px;">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("For_Update_Change") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 5px">
                                    <asp:RadioButton ID="rdoOtherRecords" runat="server" GroupName="Records" />
                                </td>
                                <td width="90%" style="padding-top: 8px">
                                    <asp:Label ID="Label5" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Can_edit_rerun_his_and_other_records")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="1%" style="padding-top: 5px">
                                    <asp:RadioButton ID="rdoHisRecords" runat="server" GroupName="Records" />
                                </td>
                                <td width="90%" style="padding-top: 8px">
                                    <asp:Label ID="Label4" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Can_edit_rerun_only_his_records")%></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="padding: 20px 5px 0px 5px;">
                    <div>
                        <table cellpadding="2" cellspacing="0" width="1050px">
                            <tr class="Header">
                                <td width="175px" class="Font">
                                    <asp:Label ID="lblSecurity" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Security")%></asp:Label>
                                </td>
                                <td width="650px">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table width="100%">
                            <tr>
                                <td width="90%" style="padding-top: 5px">
                                    <asp:Label ID="lblLock" runat="server" class="bglabel" Style="width: 13%;" Text=""><%=objLanguage.GetLanguageConversion("Lock_User_After")%></asp:Label><%--Text="Lock the system after"--%>
                                    &nbsp;&nbsp;<telerik:RadNumericTextBox ID="txtLock" runat="server" Width="50px" Style="text-align: right;"
                                        MaxValue="500">
                                        <ClientEvents OnBlur="RemoveZeros" OnValueChanged="RemoveZeros" OnLoad="RemoveZeros" />
                                    </telerik:RadNumericTextBox>
                                    <asp:Label ID="lblLock1" runat="server" Text=""><%=objLanguage.GetLanguageConversion("unsuccessfull_login_attempt")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="90%">
                                    <div class="div_rolesedit_margin">
                                        <asp:Label ID="lblForce" runat="server" class="bglabel" Style="width: 13%;" Text=""><%=objLanguage.GetLanguageConversion("Force_change_password_after")%></asp:Label>
                                        &nbsp;&nbsp;<telerik:RadNumericTextBox ID="txtForce" runat="server" Width="50px"
                                            Style="text-align: right;" MaxValue="500">
                                            <ClientEvents OnBlur="RemoveZeros" OnValueChanged="RemoveZeros" OnLoad="RemoveZeros" />
                                        </telerik:RadNumericTextBox>
                                        <asp:Label ID="lblForce1" runat="server" Text=""><%=objLanguage.GetLanguageConversion("days")%></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="90%">
                                    <div class="div_rolesedit_margin">
                                        <asp:Label ID="Label6" runat="server" class="bglabel" Style="width: 13%; height: 200px;"
                                            Text=" "><%=objLanguage.GetLanguageConversion("Allow_access_by_IP_Address")%></asp:Label><%--Text="Force User to change password after "--%>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        <asp:RadioButton ID="rdoSingleIP" runat="server" GroupName="IPAddress" onClick="javascript:IPFieldsEnable(this.value);" />
                                                    </td>
                                                    <td style="width: 80%;">
                                                        <asp:Label ID="Label8" runat="server" Text="" Style="padding-right: 34px;"><%=objLanguage.GetLanguageConversion("Single_IP")%></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSingleIP" runat="server" Enabled="false"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ControlToValidate="txtSingleIP" ErrorMessage="Please enter a valid IP Address"
                                                            ValidationExpression="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"
                                                            runat="server" ID="revSingleIPAddress"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        <asp:RadioButton ID="rdoMultipleIP" runat="server" GroupName="IPAddress" onClick="javascript:IPFieldsEnable(this.value);" />
                                                    </td>
                                                    <td style="width: 80%;">
                                                        <asp:Label ID="Label9" runat="server" Text="" Style="padding-right: 26px;"><%=objLanguage.GetLanguageConversion("Multiple_IP")%></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMultipleIP" runat="server" Enabled="false" TextMode="MultiLine"
                                                            Rows="5" Style="width: 200px; font-family: Verdana,Arial,Helvetica; font-size: 11px;"></asp:TextBox>
                                                        <asp:Label runat="server" ID="lblMultipleIP_Condition" Style="font-family: Verdana,Arial,Helvetica;
                                                            font-size: 11px; font-weight: bold; color: Red;"></asp:Label>
                                                        <asp:Label runat="server" ID="Label7" Style="font-family: Verdana,Arial,Helvetica;
                                                            font-size: 11px; font-weight: bold; color: Gray;" Text="Please enter one IP address per line"><%=objLanguage.GetLanguageConversion("Please_enter_one_IP_address_per_line")%></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        <asp:RadioButton ID="rdoRangeIP" runat="server" GroupName="IPAddress" onClick="javascript:IPFieldsEnable(this.value);" />
                                                    </td>
                                                    <td style="width: 80%;">
                                                        <asp:Label ID="Label10" runat="server"><%=objlang.GetLanguageConversion("IP_Range_From")%></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1%;">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromIP" runat="server" Enabled="false" onkeypress="return Commavalidation(event)"></asp:TextBox>
                                                        <asp:Label ID="Label11" runat="server"> <%=objlang.GetLanguageConversion("to")%> </asp:Label>
                                                        <asp:TextBox ID="txtToIP" runat="server" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="90%">
                                    <div class="div_rolesedit_margin">
                                        <asp:Label ID="lblRestrict" runat="server" class="bglabel" Style="width: 13%; height: 45px"
                                            Text="In case of unauthorized access alert user/admin"><%=objlang.GetLanguageConversion("In_case_of_unauthorized_access_alert_user_admin")%></asp:Label>
                                        <span style="margin-left: 1px;">&nbsp;</span>
                                        <asp:TextBox ID="txtRestrict" TextMode="MultiLine" Width="300px" Height="45px" runat="server"
                                            onblur="javascript:return MultipleEmailAddressesValidation(this.id, 'spnMessage')"></asp:TextBox>
                                        <%-- <asp:RegularExpressionValidator ID="RegExp_txtRestrict" runat="server" ErrorMessage="Please enter a valid email id"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"
                                        ForeColor="Red" ControlToValidate="txtRestrict" Display="Dynamic" Width="186px"></asp:RegularExpressionValidator>--%>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Style="padding-left: 15%; font-family: Verdana,Arial,Helvetica; color: Gray;
                                        font-size: 11px; font-weight: bold" ID="lblMessage" runat="server"><%=objLanguage.GetLanguageConversion("Multiple_Emali_Address_Note")%></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span id="spnMessage" class="spanerrorMsg" style="width: 200px; display: none; margin-left: 160px">
                                        Please enter valid email address </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="padding: 10px 20px 10px 0px; width: 98%;">
                        <table width="100%">
                            <tr>
                                <td width="15%">
                                </td>
                                <td>
                                    <div style="float: left; margin-left: 0px; margin-right: 8px;">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btnDelete" runat="server" CssClass="button" Width="85px" Text="Delete"
                                                CausesValidation="false" OnClick="btnDelete_OnClick" />
                                        </div>
                                        <div id="div_deleteprocess" class="button" align="center" style="width: 67px; height: 13px;
                                            display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; margin-left: 0px; margin-right: 8px;">
                                        <div id="div_UpdateRole" style="display: block">
                                            <asp:Button ID="btn_UpdateRole" runat="server" CssClass="button" Width="85px" Text="Save"
                                                OnClick="btn_UpdateRole_OnClick" CausesValidation="true" Style="float: right;
                                                padding: 3px 2px 5px;" OnClientClick="if(Page_ClientValidate()) {if(MultipleEmailAddressesValidation('ctl00_ContentPlaceHolder1_txtRestrict','spnMessage')) {javascript:loadingimg('div_UpdateRole','div_btn_UpdateRole');} else {return false;}} else {return false;}" />
                                        </div>
                                        <div id="div_btn_UpdateRole" class="button" align="center" style="width: 67px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <asp:Button ID="btn_CancelRole" runat="server" CssClass="button" Width="85px" Text="Back"
                                        CausesValidation="false" Visible="false" OnClientClick="javascript:return cancelClick(path+'Settings/user_manager.aspx');"
                                        Style="float: right; padding: 3px 2px 5px; margin-right: 8px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


