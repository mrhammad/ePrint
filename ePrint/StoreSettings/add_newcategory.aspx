<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_newcategory.aspx.cs" Inherits="ePrint.StoreSettings.add_newcategory" %>

<script type="text/javascript" src="../js/jquery.min.js?VN='<%#VersionNumber%>'"></script>
<script type="text/javascript" src="../js/jquery.popup.js?VN='<%#VersionNumber%>'"></script>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" language="javascript" src="../js/commonloading.js?VN='<%#VersionNumber%>'"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"
        EnablePageMethods="true">
    </telerik:RadScriptManager>
    <asp:ScriptManagerProxy ID="SMproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script>
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function LaodImageGallery(CompanyID, ScopeIdentity) {
            if (ScopeIdentity == -1) {
                document.getElementById("spnexistscat").style.display = "block";
                txtCategory.focus();
                return false;
            }
            else {
                var pw = window.parent;
                if (CompanyID != 0) {
                    CompID = CompanyID;
                }
                GetResult(ScopeIdentity);
            }
        }
        function GetResult(result) {
            var pw = window.parent;
            var hdnCatID = pw.document.getElementById('hdnCatIDafterupld');
            hdnCatID.value = result;
            pw.$find('RadAjaxManager1').ajaxRequest(result);
        }

        function LaodImageCategory(CatID) {
            var ldimgwnd = window.parent;
            ldimgwnd.OnCategoryClick(CatID);
        }
    </script>
    <div id="divcatgorycontents" runat="server" style="padding: 20px 0px 0px 20px;">
        <div class="bglabelnew">
            <div style="float: left;">
                <asp:Label ID="lblCategory" runat="server" Text='Category' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                <span style="color: Red;">*</span>
            </div>
        </div>
        <div>
            <div style="float: left; width: 70%; max-width: 70%; padding: 4;">
                <asp:TextBox ID="txtCategory" CssClass="textboxnew_estNew" Width="99%" runat="server"
                    AutoCompleteType="Disabled" min-width="220px"></asp:TextBox>
                <asp:HiddenField ID="hdnCategoryNameEdited" runat="server" Value="" />
                <span id="spn_txtCategory" class="spanerrorMsg" style="display: none; width: 220px;">
                    <%=objLanguage.GetLanguageConversion("Please_Enter_Category_Name")%>
                </span><span id="spnexistscat" class="spanerrorMsg" style="display: none; width: 220px;">
                    <%=objLanguage.GetLanguageConversion("Category_Name_Already_Exists")%>
                </span>
            </div>
        </div>
        <div class="bglabelnew">
            <div style="float: left;">
                <asp:Label ID="lblParent" runat="server" Text='' CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div style="float: left; margin-left: 5px;">
            <telerik:RadComboBox ID="cboNewCategory" runat="server" Width="320">
            </telerik:RadComboBox>
        </div>
        <div style="float: left;">
            <div id="div_next" style="display: block; margin: 20px 0px 0px 6px;">
                <asp:Button ID="btnSave" CssClass="button" Text='Save' Width="65px" runat="server"
                    OnClick="btnSave_OnClick" OnClientClick="javascript:return Validate();" /></div>
        </div>
    </div>
    <asp:HiddenField ID="hdncategory_names" runat="server" Value="" />
    <div id="divNoCategory" style="display: none;" runat="server">
        <table style="background-color: #FFFFFF" frame="border" width="450" border="0" cellspacing="0"
            cellpadding="0" align="center">
            <tr valign="top">
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
                        <tr>
                            <td align="left" style="width: 138px" class="toptext1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table width="76%" border="0" cellspacing="0" cellpadding="0" align="right">
                                    <tr>
                                        <td align="left" class="normaltext">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 9">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="images_home/header.gif" width="400" height="193">--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 99%;
                                    margin-top: 10%">
                                    <tr>
                                        <td align="center">
                                            <div class="messageboxSessionLogoutNew" style="padding: 6px 0px 5px 0px; width: 70%;">
                                                <div>
                                                    <div>
                                                        This Category already deleted from the Gallery</div>
                                                    <div class="only5px">
                                                    </div>
                                                    <div>
                                                        <%-- <asp:Button ID="btnBack" runat="server" CssClass="button" Width="65px" Text="Back"
                                                            Style="padding: 3px 2px 5px;" OnClick="btnBack_OnClick" />--%>
                                                        <%-- <asp:Label ID="lblBack" runat="server" Style="color: #193D7E; cursor: pointer;" Text="Please click here to go back"></asp:Label>--%>
                                                        <asp:LinkButton ID="btnBack" runat="server" Text="Please click here to go back" OnClientClick="javascript:ClosePopUp();  return false;"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script>
        function Validate() {
            var valid = true;
            var txtCategory = document.getElementById("<%=txtCategory.ClientID %>");
            var categorynames = document.getElementById("<%=hdncategory_names.ClientID %>");
            document.getElementById("<%=hdnCategoryNameEdited.ClientID %>").value = txtCategory.value;
            var splitval = categorynames.value.split(',');
            if (txtCategory.value == "") {
                document.getElementById("spn_txtCategory").style.display = "block";
                txtCategory.focus();
                valid = false;
            }
            else {
                document.getElementById("spn_txtCategory").style.display = "none";
                for (var i = 0; i < splitval.length; i++) {
                    if (splitval[i].trim() != "") {
                        var Cat_ID = splitval[i].trim().split('~');
                        var Name = Cat_ID[0].trim();
                        var ID = Cat_ID[1].trim();

                        if (Name.toLowerCase() == txtCategory.value.trim().toLowerCase()) {
                            //commented for ticket id : 12084 , same category name can be saved
                            // document.getElementById("spnexistscat").style.display = "block";
                            // document.getElementById("spn_txtCategory").style.display = "none";
                            //valid = false;
                        }
                    }
                }
            }
            return valid;
        }
        function ClosePopUp() {
            GetRadWindow().close();
            var pw = window.parent;
            pw.location.reload();
        }
    </script>
</body>
</html>

