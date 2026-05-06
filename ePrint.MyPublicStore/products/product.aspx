<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="ePrint.MyPublicStore.products.product" MasterPageFile="~/templates/MasterPageDefault.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitePath %>js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager runat="server" ID="SM">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    </telerik:RadAjaxManager>--%>
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
                                                        <asp:Label ID="lblSucess" Text="ram" runat="server"></asp:Label>
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
                                        <img border="0" class="trans" src="<%=strSitePath %>images/radimg1.gif">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var HeightText = '<%=objLanguage.GetLanguageConversion("Height")%>';
        var WidthText = '<%=objLanguage.GetLanguageConversion("Width")%>';
        var ValidQty = '<%=objLanguage.GetLanguageConversion("Please_enter_the_valid_quantity")%>';
        var ValidWidthAndHeight = '<%=objLanguage.GetLanguageConversion("Please_enter_valid_Width_and_Height")%>';
        var AccountID = '<%=AccountID %>';
        var companyID = '<%=companyID %>';
    </script>
    <script src="<%=strSitePath %>js/product_item.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="ProductCatagoryMain_div" class="contentArea_Background">
        <div id="divNavigatePannel" runat="server" class="navigation_div">
            <a href="<%=strSitePath %>Default.aspx">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="#" onclick="Onclick_My_product('0')">
                <asp:Label ID="lbl_nav_catagoty" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Product_Categories") %></asp:Label></a>
            <asp:Label ID="lbl_nav" runat="server" Text=""></asp:Label>
        </div>
        <div id="ProductCatagoryContent_div">
            <div>
                <div class="row">
                    <div valign="top" class="ProductsDetails_td col-lg-2" style="width: auto">
                        <div id="div_ProductsDetailsList" class="left_div" runat="server">
                            <div class="center_div_header Header_Background">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Product_Categories")%>
                                </strong>
                            </div>
                            <div class="center_div_content">
                                <asp:PlaceHolder ID="plh_ProductsDetailsList" runat="server"></asp:PlaceHolder>
                                 <%--<telerik:RadTreeView ID="radCategoryTree" runat="server" Enabled="true" CheckBoxes="false"
                                            CheckChildNodes="false" TriStateCheckBoxes="false" autopostbackoncheck="false"
                                            OnNodeExpand="RadTreeView1_NodeExpand" OnClientNodeCollapsed="onNodeCollapsed"
                                            Skin="Default" OnNodeClick="radCategoryTree_NodeClick" CssClass="Product_Details_List_RadTree Product_Details_List_RadTree_Font" />--%>
                            </div>
                        </div>
                    </div>
                    <div valign="top" class="col-lg-8">
                        <div id="left_div">
                            <div id="heading" class="center_div_header Header_Background">
                                <strong><span id="spn_headding" runat="server"></span></strong>
                            </div>
                            <asp:PlaceHolder ID="plh_ProductsDetails" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                    <div valign="top" class="col-lg-2">
                        <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <%--<style type="text/css">
        .RadTreeView_Default .rtHover .rtIn
        {
            color: #777;
            border-color: #B7B7B7;
            background-color: #F5F5F5;
            background: #F5F5F5;
            border-radius: 3px;
        }
        .RadTreeView_Default .rtSelected .rtIn
        {
            color: #454545;
            border-color: #B7B7B7;
            background: #E1E1E1;
            border-radius: 3px;
        }
        .RadTreeView_Default, .RadTreeView_Default a.rtIn, .RadTreeView_Default .rtEdit .rtIn input
        {
            color: rgb(68, 68, 68);
        }
        #ctl00_ContentPlaceHolder1_radCategoryTree {
            height : auto;
            min-height : 200px;
        }
    </style>--%>
    <script type="text/javascript" src="<%=strSitePath %>js/general.js?VN='<%=VersionNumber%>'"></script>
      <%-- <script type="text/javascript">
           function onNodeCollapsed(sender, args) {
               $find("ctl00_ContentPlaceHolder1_RadAjaxManager1").ajaxRequest();
           }
       </script>--%>
    <style type="text/css">
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
        var Rewritemodule = '<%=Rewritemodule %>';
        function Onclick_Product(ID, Name) {
            var btnviewdetails = 'btnviewdetails' + ID;
            var btnProcesImg = 'div_process' + ID;
            if (Rewritemodule.toLowerCase() == 'on') {
                var a = window.location = "<%=strSitePath %>" + "products/" + RemoveIllegalChars(Name) + KeySeparator + ID + KeySeparator + "0" + FileExtension;
                loadingimage(btnviewdetails, btnProcesImg);
                return a;
            }
            else {
                window.location = "<%=strSitePath %>" + "products/productdetails.aspx?ID=" + ID + "&amp;type=0";
            }
        }

        function Onclick_Login(ID, Name) {
            ShowLoginonProduct(ID, Name);
        }

        function Onclick_My_product(PriceCatalogueCategoryID) {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = "<%=strSitePath %>" + "products" + KeySeparator + PriceCatalogueCategoryID + FileExtension;
            }
            else {
                window.location = "<%=strSitePath%>" + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
            }
        }

        var right_div = document.getElementById("right_div")
        var left_div = document.getElementById("left_div")
        var cnt_right = '<%=cnt_right %>';

        if (SystemName == 'ppw' && AccountType == 'p') {
            if (cnt_right == 0) {
                //left_div.style.width = "99.7%";
            }
            else {
                //left_div.style.width = "70%";
            }

        }
        else {

            if (cnt_right == 0) {
                //left_div.style.width = "755px";
            }
            else {
                //left_div.style.width = "570px";
            }

        }

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

        function getTitle(id) {
            var imgTitle = document.getElementById(id);
            var Title = imgTitle.title;
            imgTitle.title = SpecialDecode(Title);
        }
    </script>
</asp:Content>


