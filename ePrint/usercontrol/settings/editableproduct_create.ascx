<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editableproduct_create.ascx.cs" Inherits="ePrint.usercontrol.settings.editableproduct_create" %>
<script type="text/javascript">
    var IsStockExist_FromEditable = '<%=IsStockExist_FromEditable%>';
    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById("<%=FileUpladPdf.ClientID%>");
        var FileUploadPath = fuData.value;
       
        //Low Resolution PDF
        if (FileUploadPath == '') {
            // There is no file selected
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_CustomValidator1").style.display = "block";
            args.IsValid = false;
        }
        else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "pdf") {
                args.IsValid = true; // Valid file type                
                document.getElementById('ctl00_ContentPlaceHolder1_ucEditableProduct_Chk_OverPrint').checked = false;
                document.getElementById('ctl00_ContentPlaceHolder1_ucEditableProduct_Chk_OverPrint').disabled = true;
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_ucEditableProduct_Chk_OverPrint').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_CustomValidator1").style.display = "block";
                fuData.value = '';
                args.IsValid = false; // Not valid file type                        
            }
        }
    }

    $(document).ready(function () {
        document.getElementById("<%=div_Template1.ClientID%>").style.display = "block";
    });
</script>
<script type="text/javascript" language="javascript">
    function PdfMandatory(Type) {
        if (Type == "pdf") {
            document.getElementById("<%=chkPdfAllowPreview.ClientID%>").checked = true;
            PdfAllowEnable(Type)
        }
        else if (Type == "image") {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").checked = true;
            PdfAllowEnable(Type)
        }
        else if (Type == "both") {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").checked = true;
            PdfAllowEnable(Type)
        }
    }
    function PdfAllowEnable(Type) {
        if (Type == "pdf" && document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").checked == true) {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").disabled = true;
        }
        else if (Type == "image" && document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").checked == true) {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").disabled = true;
        }
        else if (Type == "both" && document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").checked == true) {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").disabled = true;
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPdfPreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").checked = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImagePreviewMandatory").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkPDFImageAllowPreview").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_ucEditableProduct_chkImageAllowPreview").disabled = false;
        }
    }

    function EditprodOptions() {

        document.getElementById("<%=div_Template1.ClientID%>").style.display = "block";

        if (document.getElementById("<%=ChkAllowCSV.ClientID%>").checked == true) {
            //document.getElementById("<%=div_Template1.ClientID%>").style.display = "none";
            document.getElementById("<%=Chk_OverPrint.ClientID%>").checked = false;
            document.getElementById("<%=chkPdfPreviewMandatory.ClientID%>").checked = false;
            document.getElementById("<%=chkAllowWaterMarks.ClientID%>").checked = false;
            document.getElementById("<%=chkPdfAllowPreview.ClientID%>").checked = false;

            document.getElementById("<%=txt_Width.ClientID%>").value = "0.00";
            document.getElementById("<%=txt_height.ClientID%>").value = "0.00";
            document.getElementById("<%=txtWaterMark.ClientID%>").value = "";

        }
        else {
            //document.getElementById("<%=div_Template1.ClientID%>").style.display = "block";
        }

    }

</script>
<div id="Div_EditableProduct" style="display: none; color: Black;">
    <%--<div>--%>
    <div id="div_Template">
        <div align="left" style="float: left; width: 50%;">
            <div align="left" style="float: left; padding: 5px 0px 0px 5px; font-weight: bold;">
                <asp:Label ID="Label8" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Template") %></asp:Label>
            </div>
            <div class="bglabel" style="height: 16px;" id="divPDF" runat="server">
                <asp:Label ID="lbl_upldpdf" runat="server" Text="Upload PDF"><%=objLanguage.GetLanguageConversion("Upld_PDF")%></asp:Label>
            </div>
            <div class="box">
                <table cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td style="width: 150px">
                            <asp:FileUpload ID="FileUpladPdf" runat="server" CssClass="textboxnew" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                ControlToValidate="FileUpladPdf" Style="display: none;" ErrorMessage="Only PDF files are allowed"
                                ValidationGroup="Test"></asp:CustomValidator>
                        </td>
                        <td>
                            <div style="padding-left: 10px">
                                <a href="javascript:void(0);" id="img_pdf" visible="false" runat="server" title="">
                                    <img alt="" id="img_pdfhelp" runat="server" src="~/images/Help-icon.png" style="cursor: pointer;
                                        width: 16px; height: 16px; margin: -10px 0px 0px 0px; border: solid 0px green;"
                                        class="tooltip" /></a>
                                <asp:Label ID="lblPDF" runat="server" Style="margin: 15px;" Visible="false"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="Div_AllowCSV" runat="server">
            <div class="bglabel" style="height: 16px; width: 14%;">
                <%=objLanguage.GetLanguageConversion("Enable_CSV_Upload")%>
            </div>
            <div class="box">
                <asp:CheckBox ID="ChkAllowCSV" runat="server" onclick="EditprodOptions();" />
                <a href="javascript:void(0);" id="CSV_helptext" runat="server" title="">
                    <img alt="" id="img1" runat="server" src="~/images/Help-icon.png" style="cursor: pointer;
                        width: 16px; height: 16px; margin: 3px 0px 0px 0px; border: solid 0px green;
                        padding-left: 5px;" class="tooltip" /></a>
            </div>
        </div>
    </div>
    <div id="div_Template1" runat="server">
        <div class="bglabel" style="height: 16px; width: 14%;">
            <%=objLanguage.GetLanguageConversion("Overprint_File_Required")%>
        </div>
        <div class="box">
            <asp:CheckBox ID="Chk_OverPrint" runat="server" />
        </div>
        <div class="onlyEmpty">
        </div>
        <div align="left" class="editablecropmarkmain_div">
            <div class="editablecropmark_div">
                <asp:Label ID="Label22" runat="server" Text=""><%=objLanguage.GetLanguageConversion("PDF_has_Crop_Marks_distanceFromEdge")%></asp:Label>
            </div>
            <div class="editablecropmarkwidth_div">
                <asp:Label ID="Label5" runat="server" Text="Width "><%=objLanguage.GetLanguageConversion("Width")%></asp:Label>
                <asp:TextBox ID="txt_Width" runat="server" Width="50px"></asp:TextBox>
                <asp:Label ID="lbl_widthmeasure" runat="server"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Height "><%=objLanguage.GetLanguageConversion("Height")%></asp:Label>
                <asp:TextBox ID="txt_height" runat="server" Width="50px"></asp:TextBox>
                <asp:Label ID="lbl_heightmeasure" runat="server"></asp:Label>
                &nbsp;
                <%-- <asp:Label ID="lblHelpText" class="smallgraytext" runat="server"><%=objLanguage.GetLanguageConversion("Note_After_setting_the_dimensions_required_to_hide_the_crop_marks_please_allow_10_minutes_for_the_change_to_take_place")%></asp:Label>--%>
                <a href="javascript:void(0);" id="img_helptext" runat="server" title="">
                    <img alt="" id="img_help_hidcrop" runat="server" src="~/images/Help-icon.png" style="cursor: pointer;
                        width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                        class="tooltip" /></a>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <div align="left" style="float: left; width: 50%;">
            <div align="left" style="float: left; padding: 5px 0px 0px 5px; font-weight: bold;">
                <asp:Label ID="lblPreview" runat="server" Text="Previews"><%=objLanguage.GetLanguageConversion("Previews")%></asp:Label>
            </div>
            <div class="bglabel" style="height: 103px;">
                <asp:Label ID="lblPDFpreviews" runat="server" Text="PDF previews"><%=objLanguage.GetLanguageConversion("PDF_Previews")%></asp:Label>
            </div>
            <div class="box">
                <asp:CheckBox ID="chkPdfAllowPreview" runat="server" Text="Allow PDF previews" onclick="javascript:PdfAllowEnable('pdf');" />
                <br />
                <asp:CheckBox ID="chkPdfPreviewMandatory" runat="server" Text="PDF previews mandatory"
                    onclick="javascript:PdfMandatory('pdf',this.id);" Style="padding-left: 15px;" />
                <br />
                <asp:CheckBox ID="chkImageAllowPreview" runat="server" Text="Allow Image previews"
                    onclick="javascript:PdfAllowEnable('image');" />
                <br />
                <asp:CheckBox ID="chkImagePreviewMandatory" runat="server" Text="Image previews mandatory"
                    Style="padding-left: 15px;" onclick="javascript:PdfMandatory('image',this.id);" />
                <br />
                <asp:CheckBox ID="chkPDFImageAllowPreview" runat="server" Text="Allow PDF and Image previews"
                    onclick="javascript:PdfAllowEnable('both');" />
                <br />
                <asp:CheckBox ID="chkPDFImagePreviewMandatory" runat="server" Text="PDF and Image previews mandatory"
                    Style="padding-left: 15px;" onclick="javascript:PdfMandatory('both',this.id);" />
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <div align="left" style="float: left; width: 50%;">
            <div class="bglabel">
                <asp:Label ID="lblPDFwatermarks" runat="server" Text="PDF watermarks"><%=objLanguage.GetLanguageConversion("PDF_watermarks")%></asp:Label>
            </div>
            <div class="box">
                <asp:CheckBox ID="chkAllowWaterMarks" runat="server" Text="Allow watermarks to PDF previews" />
                <br />
                &nbsp;<asp:TextBox ID="txtWaterMark" runat="server" Text="Watermark" Width="150px"
                    onclick="clearText(this);" CssClass="fontgrey" MaxLength="25" Style="margin-left: 30px;"></asp:TextBox><%--onmouseout="defaultText(this);" --%>
                <asp:Label ID="lbl" runat="server" Text="" CssClass="smallfontgrey" ForeColor="black"><%=objLanguage.GetLanguageConversion("Max_25_Char")%></asp:Label>
            </div>
        </div>
    </div>
    <div style="height: 15px" class="onlyEmpty">
    </div>
    <div style="float: left; padding-left: 15%">
        <asp:Button runat="server" ID="Button1" Text="Previous" CssClass="button" OnClientClick="Javascript:gettabs('es');return false;" />
    </div>
    <div style="float: left; padding-left: 10px">
        <asp:Button runat="server" ID="nxt" Text="Next" CssClass="button" OnClientClick="Javascript:gettabs('ao');return false;" />
    </div>
    <div style="float: left; padding-left: 10px">
        <div style="float: left; display: block">
            <asp:Button runat="server" ID="btnSaveStay" Text="Save & Stay" CssClass="button"
                OnClick="btnSaveStay_Click" ValidationGroup="Test" Visible="false" />
        </div>
        <div id="div_btnsavestayprocess" style="display: none">
            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
        </div>
    </div>
    <div style="float: left; padding-left: 10px">
        <div style="float: left; display: block;">
            <asp:Button runat="server" ID="btnSave" CssClass="button"
                OnClick="btnSave_Click" Text="Save" ValidationGroup="Test" />
        </div>
        <div id="div_btnsaveprocess" style="display: none">
            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
        </div>
    </div>
    <div style="height: 10px" class="onlyEmpty">
    </div>
    <%--</div>--%>
</div>
