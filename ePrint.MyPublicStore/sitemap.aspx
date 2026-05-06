<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="ePrint.MyPublicStore.sitemap" masterpagefile="~/templates/MasterPageDefault.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="loginMain_div" class="contentArea_Background">
        <div id="ctl00_ContentPlaceHolder1_div_NavigationID" class="navigation_div">
            <%--<a href="http://localhost:58813/WebStore_Eprint/"><span id="ctl00_ContentPlaceHolder1_lbl_home">--%>
            <a href="<%=strSitePath %>"><span id="ctl00_ContentPlaceHolder1_lbl_home">Home</span>
            </a><span id="ctl00_ContentPlaceHolder1_lbl_spliter">&gt;</span> Sitemap
        </div>
        <div id="sitemap_Backgroung">
            <div class="sitemap_div">
                <div id="login_content">
                    <div id="loginHeader" class="Header_Background">
                        <strong><span id="ctl00_ContentPlaceHolder1_spnLoginID">Site Map</span></strong>
                    </div>
                    <br />
                    <div class="SiteMap_PlcHoldr_Div">
                        <asp:PlaceHolder runat="server" ID="phSiteMap"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style type="text/css">
        .sitemapRoot
        {
            color: #0066B3;
            font-size: 13px;
            cursor: pointer;
        }
        
        .sitemapCat
        {
            color: #0066B3;
            font-size: 13px;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript" src="<%#strSitePath%>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">

        var Rewritemodule = '<%=Rewritemodule %>';
        var KeySeparator = '<%=KeySeparator %>';
        var FileExtension = '<%=FileExtension %>';
        var strSitepath = '<%=strSitePath %>';

        function Onclick_Productnew() {

            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = "<%=strSitePath %>" + "products" + KeySeparator + 0 + FileExtension;
            } else {
                window.location = "<%=strSitePath%>" + "products/product.aspx?ID=0";
            }
        }

        function Onclick_Product(ID, Name) {
            if (Rewritemodule.toLowerCase() == "on") {
                window.location = "<%=strSitePath %>" + "products/" + RemoveIllegalChars(Name) + KeySeparator + ID + KeySeparator + "0" + FileExtension;
            }
            else {
                window.location = "<%=strSitePath %>" + "products/productdetails.aspx?ID=" + ID + "&amp;type=0";
            }
        }
    </script>
</asp:Content>


