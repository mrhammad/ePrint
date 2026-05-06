<%@ Page Title="products" Language="C#" MasterPageFile="~/templates/MasterPageDefault.master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="ePrint.WebStore.product" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-1.7.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
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
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    </telerik:RadAjaxManager>
    <div align="center" id="Product_Main_Div">
        <div id="Product_Main_Div_Padding">
            <div align="center" id="Product_Main_OuterDiv">
                <div align="center" id="contentbottom">
                    <table class="width100p">
                        <tr>
                            <td valign="top" class="Product_Catgry_Width">
                                <div id="div_ProductsDetailsList" runat="server" class="left_div">
                                    <div class="center_div_header Header_Background" align="left">
                                        <div class="Hederfont clearLeft">
                                            <%=objLanguage.GetLanguageConversion("Product_Categories")%>
                                        </div>
                                    </div>
                                    <div class="Product_Details_List_LeftPanel">
                                        <asp:PlaceHolder ID="plh_ProductsDetailsList" runat="server" Visible="false"></asp:PlaceHolder>
                                        <telerik:RadTreeView ID="radCategoryTree" runat="server" Enabled="true" CheckBoxes="false"
                                            CheckChildNodes="false" TriStateCheckBoxes="false" autopostbackoncheck="false"
                                            OnNodeExpand="RadTreeView1_NodeExpand" OnClientNodeCollapsed="onNodeCollapsed"
                                            Skin="Default" OnNodeClick="radCategoryTree_NodeClick" CssClass="Product_Details_List_RadTree Product_Details_List_RadTree_Font" />
                                    </div>
                                </div>
                            </td>
                            <td class="vertsep"></td>
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
                                <div id="center_div">
                                    <div id="heading" class="center_div_header Header_Background">
                                        <div class="Hederfont DisplayNone">
                                            <span id="spn_headding" runat="server">Product List </span>
                                        </div>
                                    </div>
                                    <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="right_div">
                                    <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function onNodeCollapsed(sender, args) {
            $find("ctl00_ContentPlaceHolder1_RadAjaxManager1").ajaxRequest();
        }
    </script>
    <script type="text/javascript" language="javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var Rewritemodule = '<%=Rewritemodule %>';
        var right_div = document.getElementById("right_div")
        var left_div = document.getElementById("left_div")
        var cnt_right = '<%=cnt_right %>';
        var strSitePath = '<%=strSitePath %>';
        var StoreUserID = '<%=StoreUserID %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=companyID %>';

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
    <style type="text/css">
        .RadTreeView_Default .rtHover .rtIn {
            color: #777;
            border-color: #B7B7B7;
            background-color: #F5F5F5;
            background: #F5F5F5;
            border-radius: 3px;
        }

        .RadTreeView_Default .rtSelected .rtIn {
            color: #454545;
            border-color: #B7B7B7;
            background: #E1E1E1;
            border-radius: 3px;
        }

        .RadTreeView_Default, .RadTreeView_Default a.rtIn, .RadTreeView_Default .rtEdit .rtIn input {
            color: rgb(68, 68, 68);
        }

        .ProductCatagoryImage {
            max-width: 200px;
            max-height: 150px;
        }

        .Catagory_Image {
            max-width: 200px;
            max-height: 150px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function getTitle(id) {
            var imgTitle = document.getElementById(id);
            var Title = imgTitle.title;
            imgTitle.title = SpecialDecode(Title);
        }
    </script>
</asp:Content>

