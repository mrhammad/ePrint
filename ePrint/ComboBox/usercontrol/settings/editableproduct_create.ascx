<%@ control language="C#" autoeventwireup="true" inherits="usercontrol_settings_editableproduct_create, App_Web_editableproduct_create.ascx.52510c18" %>
<script type="text/javascript">

    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById("<%=FileUpladPdf.ClientID%>");
        var FileUploadPath = fuData.value;


        if (FileUploadPath == '') {
            // There is no file selected
            args.IsValid = false;
        }
        else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "pdf") {
                args.IsValid = true; // Valid file type
            }
            else {
                fuData.value = '';
                args.IsValid = false; // Not valid file type                        
            }
        }
    }
    
</script>
<div id="Div_EditableProduct" style="display: none; color: Black;">
    <div>
        <div id="div_Template">
            <div align="left" style="float: left; width: 50%;">
                <div align="left" style="float: left; padding: 5px 0px 0px 5px; font-weight: bold;">
                    <asp:Label ID="Label8" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Template") %></asp:Label>
                </div>
                <div class="bglabel" style="height: 16px;">
                    <asp:Label ID="lbl_upldpdf" runat="server" Text="Upload PDF"><%=objLanguage.GetLanguageConversion("Upload_PDF") %></asp:Label>
                </div>
                <div class="box">
                    <table cellpadding="0" cellspacing="0" style="margin-top: -2px; width: 500px">
                        <tr>
                            <td style="width: 150px">
                                <asp:FileUpload ID="FileUpladPdf" runat="server" CssClass="textboxnew" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                    ControlToValidate="FileUpladPdf" ErrorMessage="Only PDF files are allowed" ValidationGroup="Test"></asp:CustomValidator>
                            </td>
                            <td>
                                <div style="padding-left: 10px">
                                    <asp:Label ID="lblPDF" runat="server" Style="margin: 15px;" Visible="false"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="bglabel" style="height: 16px;">
                    <%=objLanguage.GetLanguageConversion("Overprint_File_Required")%>
                </div>
                <div class="box">
                    <asp:CheckBox ID="Chk_OverPrint" runat="server" />
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left" style="float: left; width: 50%;">
                <div class="bglabel">
                    <asp:Label ID="Label22" runat="server" Text=""><%=objLanguage.GetLanguageConversion("PDF_has_Crop_Marks")%></asp:Label>
                </div>
                <div class="box">
                    <asp:Label ID="Label5" runat="server" Text="Width "><%=objLanguage.GetLanguageConversion("Width")%></asp:Label>
                    <asp:TextBox ID="txt_Width" runat="server" Width="50px"></asp:TextBox>
                    <asp:Label ID="lbl_widthmeasure" runat="server"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Height "><%=objLanguage.GetLanguageConversion("Height")%></asp:Label>
                    <asp:TextBox ID="txt_height" runat="server" Width="50px"></asp:TextBox>
                    <asp:Label ID="lbl_heightmeasure" runat="server"></asp:Label>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left" style="float: left; width: 50%;">
                <div align="left" style="float: left; padding: 5px 0px 0px 5px; font-weight: bold;">
                    <asp:Label ID="lblPreview" runat="server" Text="Previews"><%=objLanguage.GetLanguageConversion("Previews")%></asp:Label>
                </div>
                <div class="bglabel" style="height: 30px;">
                    <asp:Label ID="lblPDFpreviews" runat="server" Text="PDF previews"><%=objLanguage.GetLanguageConversion("PDF_Previews")%></asp:Label>
                </div>
                <div class="box">
                    <asp:CheckBox ID="chkPdfAllowPreview" runat="server" Text="Allow PDF previews" />
                    <br />
                    <asp:CheckBox ID="chkPdfPreviewMandatory" runat="server" Text="PDF previews mandatory" Checked="true" />
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left" style="float: left; width: 50%;">
                <div class="bglabel">
                    <asp:Label ID="lblPDFwatermarks" runat="server" Text="PDF watermarks"><%=objLanguage.GetLanguageConversion("PDF_watermarks")%></asp:Label>
                </div>
                <div class="box">
                    <asp:CheckBox ID="chkAllowWaterMarks" runat="server" Text="Allow watermarks to all PDF previews" />
                    <br />
                    &nbsp;<asp:TextBox ID="txtWaterMark" runat="server" Text="Sample" Width="150px" onclick="clearText(this);"
                        CssClass="fontgrey" MaxLength="25"></asp:TextBox><%--onmouseout="defaultText(this);" --%>
                    <asp:Label ID="lbl" runat="server" Text="" CssClass="smallfontgrey" ForeColor="black"><%=objLanguage.GetLanguageConversion("Max_25_Char")%></asp:Label>
                </div>
            </div>
        </div>
        <div style="height: 15px" class="onlyEmpty">
        </div>
        <div style="float: left; padding-left: 15%">
            <asp:Button runat="server" ID="Button1" Text="Previous" CssClass="button" OnClientClick="Javascript:gettabs('ac');return false;" />
        </div>
        <div style="float: left; padding-left: 10px">
            <asp:Button runat="server" ID="nxt" Text="Next" CssClass="button" OnClientClick="Javascript:gettabs('ao');return false;" />
        </div>
        <div style="float: left; padding-left: 10px">
            <div style="float: left; display: block">
                <asp:Button runat="server" ID="btnSaveStay" Text="Save & Stay" CssClass="button"
                    OnClientClick="javascript:var a=EditSavevalidate();if(a)loadingimage(this.id,'div_btnsavestayprocess');return a;"
                    OnClick="btnSaveStay_Click" ValidationGroup="Test" />
                 <div id="div_btnsavestayprocess" style="display: none">
                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
            </div>
            </div>
           
        </div>
        <div style="float: left; padding-left: 10px">
            <div style="float: left; display: block;">
                <asp:Button runat="server" ID="btnSave" CssClass="button" OnClientClick="javascript:var a=EditSavevalidate();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                    OnClick="btnSave_Click" Text="Save" ValidationGroup="Test" />
                <div id="div_btnsaveprocess" style="display: none">
                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
            </div>
            </div>
            
        </div>
        <div style="height: 10px" class="onlyEmpty">
        </div>
    </div>
</div>
