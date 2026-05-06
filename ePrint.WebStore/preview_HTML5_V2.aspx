<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview_HTML5_V2.aspx.cs" Inherits="ePrint.WebStore.preview_HTML5_V2" MasterPageFile="~/Templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="js/commonloading.js" type="text/javascript"></script>
    <script src="js/pdf_preview.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID %>';
        var CompanyID = '<%=CompanyID %>';
        var templateName = '<%=TemplateName%>';
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
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
                            <div id="div_btnCancelprocess" class="x-btn Grey main" style="min-width: 32px; width: 40px; display: none; float: none; margin-top: 4px; margin-left: 0px; height: 15px;">
                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                            </div>
                        </td>
                        <td id="divAddToCart">
                            <asp:Button ID="addtocart" Style="margin-left: 7px; float: none; margin-top: 4px; width: auto;"
                                runat="server" Text="Confirm And Add To Cart" OnClick="addtocart_Click" class="x-btn Grey main"
                                OnClientClick="javascript:return Confirm();" />
                            <div id="div_btnsaveprocess" class="x-btn Grey main" style="margin-left: 7px; float: none; margin-top: 4px; display: none; width: 135px; height: 15px;">
                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                            </div>
                        </td>


                        <td id="divSave" style="display:none;">
                            <%--<asp:Button ID="Button1" Style="margin-left: 7px; float: none; margin-top: 4px; width: auto;"
                                runat="server" Text="Save" class="x-btn Grey main" OnClick="ApproveOrReject();" />--%>
                            <input type="button" id="btSave" value="Save" onclick="ApproveOrReject();" style="margin-left: 7px; float: none; margin-top: 4px; width: auto;" class="x-btn Grey main"/>
                            <div id="div1" class="x-btn Grey main" style="margin-left: 7px; float: none; margin-top: 4px; display: none; width: 135px; height: 15px;">
                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-top: 12px" runat="server" id="tdTypeSelect">
                            <input type="radio" name="rd_PreviewType" id="rd_PDFPreview" checked onchange="previewpdf_Changed(this);" /><label style="padding: 0px 5px 0px 3px; font-weight: bold;" for="rd_PDFPreview">Pdf Preview</label>
                            <input type="radio" name="rd_PreviewType" id="rd_ImagePreview" onchange="previewimage_Changed(this);" /><label style="padding: 0px 5px 0px 3px; font-weight: bold;" for="rd_ImagePreview">Image Preview</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <iframe runat="server" id="pdfframe" class="pdfframe" scrolling="no" style="margin-left: 12px; margin-top: 8px; height: 450px;"
            width="98%"></iframe>
        <div runat="server" id="imageframe" class="imageframe" style="height: auto; width: 98%; margin-left: 12px; margin-top: 8px; border: 1px solid; background: #525659">
            <div class="divTitle">
                <span style="float: left" id="title"><%=TemplateName%></span>
                <img style="float: right; cursor: pointer" title="Download" src="images/downloadImage.png" onclick="downloadImage_click();" />

            </div>

            <ul runat="server" class="slider" id="div_imagePreview" style="overflow: hidden"></ul>
            <div style="margin-top: 15px;">
                <input type="button" id="btn_previous" value="Previous" style="float: left" onclick="btnPrevoius_clicked();" />

                <span class="pageNo">1</span>  <span class="totalpage" id="totalPages">/ <%=totalPagesize %></span>

                <input type="button" id="btn_next" value="Next" style="float: right" onclick="btnNext_clciked();" />
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">


        //$(document).ready(function () {
        //    debugger;
        //    console.log("ready!");
        //    var bbb = decodeURIComponent(window.location.href.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent("OrderId").replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
        //    if (bbb != "") {

        //        $("#divAddToCart").hide();
        //        $("#divSave").show();
        //    }

        //});

        

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

</asp:Content>
