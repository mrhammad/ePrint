<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="tab_colour.aspx.cs" Inherits="ePrint.settings.tab_colour" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>




<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/rgbcolor.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function paletteOpen(fieldName) {
            document.forms[0]['hiddenid'].value = fieldName;
            var paletteField;
            paletteField = fieldName;
            palette = window.open("", "paletteWindow", "toolbar=0,location=0,menubar=0,scrollbars=0,resizable=0,width=300,height=200,top=300,left=500");
            palette.location.href = "<%=strSitepath %>" + "settings/color_picker.html"; //Changes by Swetha M.S
            palette.focus();
            return false;
        }

        function paletteFieldUpdate(fieldName) {
            paletteField = fieldName;
        }

        function colorFieldFill(color) {
            var hid = document.forms[0]['hiddenid'].value;
            eval("document.forms[0][\'ctl00_ContentPlaceHolder1_' + hid + '\'].value='" + color + "'");
            document.getElementById("divCLR_" + hid).style.backgroundColor = color;
        }

    </script>
    <input id="hiddenid" type="hidden" name="hiddenid">
    <%--<table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0" height="26">
        <tr style="height: 20px; display: none;">
            <td align="left" width="1%" class="bgcustomize" valign="top">
                <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
            </td>
            <td class="bgcustomize" align="left">
                <asp:Label ID="lbladdcustomizedfield" runat="server" CssClass="navigatorpanel"></asp:Label>
            </td>
            <td style="width: 10%" align="right" class="bgcustomize" nowrap="nowrap">
                <asp:HyperLink ID="HyperLink1" Visible="false" runat="server" NavigateUrl="taborder.aspx"
                    CssClass="subnavigator" Text="Edit Tab Order"></asp:HyperLink>
            </td>
            <td width="1%" class="bgcustomize" valign="top" align="right">
                <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
            </td>
        </tr>
    </table>--%>
    <table id="123" cellspacing="0" cellpadding="0" width="100%" align="center" border="0"
        class="estore_settingBox">
        <tr>
            <td>
                <UC:Header_MIS ID="header_mis" runat="server" />
                <table>
                    <tr>
                        <td style="padding: 5px 0px 0px 10px; width: 100%">
                            <div style="width: 700px">
                                <b>
                                    <asp:ValidationSummary ID="Validationsummary1" runat="Server" CssClass="error" 
                                        ForeColor="" Height="15px" Width="300px" Visible="false"></asp:ValidationSummary>
                                    <asp:PlaceHolder ID="PlaceError" runat="server"></asp:PlaceHolder>
                                </b>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 100%; padding-left: 10px;">
                            <div style="width: 100%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:PlaceHolder ID="plhgroupdetail" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td>
                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
                        </td>
                    </tr>--%>
                    <tr valign="top">
                        <td align="left">
                            <div>
                                <table cellspacing="6" cellpadding="5" width="100%" border="0" class=".div_spacing">
                                    <tr>

                                        <td align="left">
                                            <div style="display: inline; float: left">
                                                <div id="div_restore" style="display: block">
                                                    <asp:Button ID="Button3" runat="server" Text="Restore Default" OnClick="Button3_Click"
                                                        CssClass="button" OnClientClick="javascript:var a=window.confirm('Are you sure, you want to restore the default values?');if(a) loadingimg('div_restore','div_restoreprocess'); return a;" />
                                                    <%--<telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="Button3"
                                        runat="server" Text="Restore Default" OnClick="Button3_Click" OnClientClicked="javascript:return window.confirm('Are you sure, you want to restore the default values?');">
                                    </telerik:RadButton>--%>
                                                </div>
                                                <div id="div_restoreprocess" class="button" align="center" style="width: 93px; height: 14px;
                                                    display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="display: inline; float: left; margin-left: 6px">
                                                <div id="div_btnupdate" style="display: block;">
                                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="Button1"
                                                        runat="server" Text="Update" OnClick="Button1_Click">
                                                    </telerik:RadButton>
                                                </div>
                                                <div id="div_updateprocess" class="button" align="center" style="height: 14px; width: 44px;
                                                    display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div class="smallgraytext" style="padding-left: 10px; padding-bottom: 5px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Log_Out_And_Log_Back_Into_The_System_To_Ensure_This_Change_Takes_Effect")%>
                                </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script>
        var checkFinal = false;
        function ValidateColor() {
            checkFinal = true;
            var tbl_Color = document.getElementById("tbl_Color");
            var td = tbl_Color.getElementsByTagName("input");
            for (var i = 0; i < td.length; i++) {
                if (td[i].type == "text") {
                    var color = new RGBColor(td[i].value);
                    if (color.ok) {
                        td[i].value = color.toHex().toString().toUpperCase();
                        td[i].focus();
                    }
                    else {
                        td[i].value = "#000000";
                        td[i].focus();
                        break;
                    }
                }
            }
            if (checkFinal) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
