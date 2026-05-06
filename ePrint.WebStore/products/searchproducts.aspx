<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/masterPageDefault.master" AutoEventWireup="true" CodeBehind="searchproducts.aspx.cs" Inherits="ePrint.WebStore.searchproducts" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </telerik:RadScriptManager>
    <script type="text/javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var strSitepath = '<%=strSitePath %>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=companyID %>';
    </script>
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/product_item.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-1.7.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="ProductCatagoryMain_div" class="width100p">
        <div id="ProductCatagoryMain_Outerdiv">
            <div id="ProductCatagoryContent_div">
                <table class="width100p">
                    <tr>
                        <td>
                            <div>
                                <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
                                    <Windows>
                                        <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" VisibleTitlebar="true"
                                            VisibleStatusbar="false" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move">
                                            <ContentTemplate>
                                                <div id="dialog">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <div id="divQuickAddnotification">
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img id="imgSucess" runat="server" alt="" />
                                                                            </td>
                                                                            <td>
                                                                                <div id="divQuickaddLabelSucess">
                                                                                    <asp:Label ID="lblSucess" runat="server" Text="No items in cart"></asp:Label>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr class="quickaddsplittd">
                                                            <td>
                                                                <asp:Button ID="btnQuickNotificationOk" CssClass="btnConfirmationDialogueQuickAdd"
                                                                    runat="server" class="x-btn Grey main" OnClientClick="javascript:HideDialog();return false"></asp:Button>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnGotoCart" runat="server" Text="Go to Shopping Cart" CssClass="btnConfirmationDialogueQuickAdd"
                                                                    OnClientClick="displayloading();return false"></asp:Button>
                                                                <div id="div_btnGotoCart" class="btnGotoCartLoading">
                                                                    <img border="0" class="trans" src="../images/radimg1.gif">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ContentTemplate>
                                        </telerik:RadWindow>
                                    </Windows>
                                </telerik:RadWindowManager>
                            </div>
                            <div id="left_div">
                                <div id="heading" class="Header_Background">
                                    <div id="div_SearchResult_Label">
                                        <span id="spn_headding" runat="server">
                                            <%=objLanguage.GetLanguageConversion("Search_results") %>
                                        </span>
                                    </div>
                                    <div id="div_SearchResult_CountLabel">
                                        <asp:Label ID="lbl_searchResult" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <style type="text/css">
        .ProductCatagoryImage
        {
            max-width: 200px;
            max-height: 150px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        var Rewritemodule = '<%=Rewritemodule %>';
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var right_div = document.getElementById("right_div");
        var left_div = document.getElementById("left_div");
        var strSitePath = '<%=strSitePath %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
        function loadradwindow() {
            var RadPopupwin;
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            RadPopupwin.setSize(530, 180);
            RadPopupwin.show();
        }
        function closeredwindow() {
            RadPopupwin = $find("<%= RadWindow1.ClientID %>");
            RadPopupwin.close();
        }
    </script>
</asp:Content>
