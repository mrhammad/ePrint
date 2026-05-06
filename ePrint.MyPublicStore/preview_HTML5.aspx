<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_HTML5.aspx.cs" Inherits="ePrint.MyPublicStore.preview_HTML5" masterpagefile="~/Templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div align="center">
        <script src="js/commonloading.js" type="text/javascript"></script>
        <script type="text/javascript">
            function Onclick_My_product(PriceCatalogueCategoryID) {
                if (Rewritemodule.toLowerCase() == 'on') {
                    window.location = strSitepath + "products" + KeySeparator + PriceCatalogueCategoryID + FileExtension;
                }
                else {
                    window.location = strSitepath + "products/product.aspx?ID=" + PriceCatalogueCategoryID;
                }
            }
        </script>
        <div class="navigation_div navigation_div_PrevProd" id="navigation_div" runat="server"
            align="center">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="#" onclick="Onclick_My_product('0')">
                <asp:Label ID="lbl_nav_catagoty" runat="server" Text="Product Categories"><%=objLanguage.GetLanguageConversion("Product_Categories")%></asp:Label></a>&nbsp;>
            <a href="#" onclick="Onclick_My_product('<%=PriceCatalogueCategoryID %>')">
                <asp:Label ID="lbl_nav_product" runat="server" Text=""></asp:Label></a>&nbsp;>
            <asp:Label ID="lbl_nav_productName" runat="server" Text=""></asp:Label>&nbsp;>
            <asp:Label ID="Label1" runat="server" Text="">PDF Preview</asp:Label>
        </div>
        <div style="height: 550px; width: 100%; margin-top: 6px" align="center">
            <div align="center">
                <div align="center">
                    <asp:CheckBox ID="chkconform" runat="server" Style="margin-top: 6px; font-size: 13px"
                        Text="  I confirm that the PDF is correct" />
                </div>
                <div style="clear: both;">
                </div>
                <div align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnback" Style="margin-left: 2px; float: none; width: 80px; margin-top: 4px;"
                                    runat="server" Text="Cancel" OnClick="btnback_Click" class="x-btn Grey main"
                                    OnClientClick="javascript:loadingimg('ctl00_ContentPlaceHolder1_btnback', 'div_btnCancelprocess');" />
                                <div id="div_btnCancelprocess" class="x-btn Grey main" style="min-width: 32px; width: 40px;
                                    display: none; float: none; margin-top: 4px; margin-left: 0px; height: 15px;">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                </div>
                            </td>
                            <td>
                                <asp:Button ID="addtocart" Style="margin-left: 7px; float: none; margin-top: 4px;
                                    width: 176px" runat="server" Text="Confirm And Add To Cart" OnClick="addtocart_Click"
                                    class="x-btn Grey main" OnClientClick="javascript:return Confirm();" />
                                <div id="div_btnsaveprocess" class="x-btn Grey main" style="margin-left: 7px; float: none;
                                    margin-top: 4px; display: none; width: 135px; height: 15px;">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <iframe runat="server" id="pdfframe" scrolling="no" style="margin-left: 12px; margin-top: 8px;
                height: 450px;" width="98%"></iframe>
        </div>
        <script type='text/JavaScript'>

            function Confirm() {
                if (!document.getElementById('ctl00_ContentPlaceHolder1_chkconform').checked) {
                    alert("Please confirm before leaving the page!");
                    return false;
                }
                else {
                    loadingimg('ctl00_ContentPlaceHolder1_addtocart', 'div_btnsaveprocess');
                    return true;
                }

            }
        </script>
    </div>
</asp:Content>

