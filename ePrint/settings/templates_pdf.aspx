<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="templates_pdf.aspx.cs" Inherits="ePrint.settings.templates_pdf" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>js/item/general.js?VN=<%=VersionNumber %>" type="text/javascript"></script>
    <script src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <style>
        .RadGrid_Default
        {
            outline: none;
        }
        
        #ctl00_ContentPlaceHolder1_GridPDF thead th
        {
            border-top: 1px solid #828282;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridPDF">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPDF" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <div id="waitmessage" align="left" style="position: absolute; height: 50px; width: 200px;
        top: 45%; left: 45%; visibility: hidden;">
        &nbsp;&nbsp;<table cellpadding="0" cellspacing="10">
        </table>
    </div>
    <div align="left">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Templates_PDF")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="" class="mis_header_panel">
            <div align="left" style="width: 100%">
                <div style="width: 60%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <div style="float: left; width: 100%;">
                    <div class="bglabel" style="width: 20%">
                        <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Title")%></asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <div align="left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="textboxnew" Width="180px" MaxLength="255"><%--onblur="CallonBlur(this.value,'spn_txtTitle');"--%>
                            </asp:TextBox>
                        </div>
                        <div align="left">
                            <span id="spn_txtTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Title")%>
                            </span>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div id="div_FileUpload" style="float: left; width: 100%; display: block">
                    <div class="bglabel" style="width: 20%">
                        <asp:Label ID="lblPDf" runat="server" Text="Select PDF" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Select_PDF")%>
                        </asp:Label><span style="color: red"> *</span><br />
                        <span style="color: Gray">
                            <%=objLanguage.GetLanguageConversion("Select_RGB_Pdf_Note_For_TemplatePDF")%></span>
                    </div>
                    <div class="box">
                        <div align="left">
                            <asp:FileUpload ID="fuPDF" runat="server" CssClass="normalText" />
                        </div>
                        <div align="left" style="height:auto">
                            <span id="spn_File" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_PDF_To_Upload")%>
                            </span><span id="spn_FileError" class="spanerrorMsg" style="display: none; width: auto;
                                padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Upload_Only_Pdf_Format_Files")%></span><br />
                        </div>
                        <div style="margin-top: 10px;text-align:left">
                            <asp:CheckBox ID="chkPreFlightFiles" runat="server" Text="Preflight Files"></asp:CheckBox>
                            <asp:DropDownList ID="ddlPreFlightFiles" runat="server" Style="margin-top: -5px;
                                width: 185px;">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div id="div_EditFile" style="float: left; width: 100%; display: none">
                    <div class="bglabel" style="width: 20%" id="divPDFLabel">
                        <asp:Label ID="Label2" runat="server" Text="Select PDF" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Select_PDF")%>
                        </asp:Label>
                    </div>
                    <div class="box">
                        <div style="float: left;">
                            <a href="#" id="lnkFileName" runat="server"></a>&nbsp;&nbsp;&nbsp;<a href="#" id="lnkChangePDF"
                                style="text-decoration: underline" onclick="javascript:ChangePDF();"><%=objLanguage.GetLanguageConversion("Change_PDF")%></a>
                            <br />
                            <a href="#" id="lnkReportFile" runat="server"></a>
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div style="float: left; width: 100%;">
                    <div class="bglabel" style="width: 20%;">
                        <asp:Label ID="lblRetain" runat="server" Text="Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Retain_Pages_from_the_Template")%></asp:Label><br />
                        <%-- <div style="clear: both">
                        </div>--%>
                        <span style="color: Gray">
                            <%=objLanguage.GetLanguageConversion("Retain_Feature_TemplatePDF")%></span>
                    </div>
                    <div>
                        <span id="spn_First" style="padding-left: 3px">First </span>
                        <asp:TextBox ID="txtFirstPageNo" runat="server" CssClass="textboxnew" Width="41px"
                            Style="text-align: right; padding-right: 4px;" MaxLength="255" onkeyup="keyUP(event.keyCode)"
                            onkeydown="return isNumeric(event.keyCode);" onpaste="return false;"></asp:TextBox>
                        <span id="spn_pg1">Pages </span>
                    </div>
                    <div style="padding-top: 4px; padding-left: 20%;">
                        <span id="spn_Last" style="padding-left: 3px; padding-right: 1px;">Last </span>
                        <asp:TextBox ID="txtLastPageNo" runat="server" CssClass="textboxnew" Width="41px"
                            Style="text-align: right; padding-right: 4px;" MaxLength="255" onkeyup="keyUP(event.keyCode)"
                            onkeydown="return isNumeric(event.keyCode);" onpaste="return false;"></asp:TextBox>
                        <span id="spn_pg">Pages </span>
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div style="float: left; width: 90%; padding-top: 1%;">
                    <div style="float: left; width: 23.2%">
                        &nbsp;
                    </div>
                    <div style="display: inline; float: left">
                        <div id="div_btnCancel" style="display: block">
                            <telerik:RadButton ID="btnCancel" Skin="EprintbtnSkin" EnableEmbeddedSkins="false"
                                runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                            </telerik:RadButton>
                        </div>
                        <div id="div_btnCancelprocess" class="button" align="center" style="height: 14px;
                            width: 43px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="display: inline; float: left">
                        <div id="div_btnsave" style="display: block">
                            <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnSave_OnClick">
                            </asp:Button>
                        </div>
                        <div id="div_btnsaveprocessprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div class="only10px">
                </div>
                <div id="div_Resize" align="left" style="width: 60%; display: block">
                    <div align="left" style="width: 100%">
                        <div style="float: left">
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                    <div id="a">
                    </div>
                    <div id="div_Grid">
                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="false"
                            runat="server">
                            <ContentTemplate>
                                <telerik:RadGrid Width="90%" ID="GridPDF" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                    BorderWidth="0" ShowStatusBar="true" OnDeleteCommand="lnkDelete_OnClick" AllowAutomaticInserts="True"
                                    PagerStyle-AlwaysVisible="true" PageSize="50" AllowAutomaticUpdates="True" AllowPaging="True"
                                    AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" OnItemDataBound="GridPDF_OnRowDataBound"
                                    OnPageIndexChanged="GridPDF_PageIndexChanged" OnPageSizeChanged="GridPDF_PageSizeChanged"
                                    ItemStyle-Height="15px">
                                    <MasterTableView Width="100%" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                                        DataKeyNames="PDFID">
                                        <EditItemStyle></EditItemStyle>
                                        <Columns>
                                            <telerik:GridTemplateColumn SortExpression="PDFTitle" HeaderText="PDF Title" HeaderStyle-Width="45%"
                                                ItemStyle-Width="35%" UniqueName="PDFTitle" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                DataField="PDFTitle">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("PDF_Title")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnTitle" runat="server" Value='<%#Eval("PDFTitle")%>' />
                                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%#Eval("PDFID")%>' />
                                                    <asp:HiddenField ID="hdnName" runat="server" Value='<%#Eval("PDFName")%>' />
                                                    <asp:HiddenField ID="hdnKey" runat="server" Value='<%#Eval("PDFKey")%>' />
                                                    <asp:HiddenField ID="hdnReportFile" runat="server" Value='<%#Eval("ReportFileName")%>' />
                                                    <asp:HiddenField ID="hdnImageName" runat="server" Value='<%#Eval("ImageName")%>' />
                                                    <asp:HiddenField ID="hdnFirstPageNo" runat="server" Value='<%#Eval("FirstPageNo")%>' />
                                                    <asp:HiddenField ID="hdnLastPageNo" runat="server" Value='<%#Eval("LastPageNo")%>' />
                                                    <a id="Title" runat="server" href="#">
                                                        <div style="float: left; width: 99%; overflow: hidden; cursor: pointer;">
                                                            <asp:Label ID="lblItemTitleID" Text='<%#Eval("PDFID")%>' runat="server" Visible="false"></asp:Label>
                                                            <%#Eval("PDFTitle")%>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="IsReady" HeaderText="Ready For Use" HeaderStyle-Width="30%"
                                                ItemStyle-Width="30%" UniqueName="Description" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                DataField="IsReady">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblIsReady" runat="server"><%=objLanguage.GetLanguageConversion("Ready_For_Use")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="#" id="Ready_FOr_Use" runat="server">
                                                        <div style="float: left; overflow: hidden; cursor: pointer;">
                                                            <asp:Label ID="lblIsReady" Text='<%#Eval("IsReady")%>' runat="server"></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="DateUploaded" HeaderText="Date Uploaded" HeaderStyle-Width="45%"
                                                ItemStyle-Width="45%" UniqueName="DateUploaded" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                DataField="DateUploaded">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblDateUploaded" runat="server"><%=objLanguage.GetLanguageConversion("Date_Uploaded")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="#" id="Date_Uploaded" runat="server">
                                                        <div style="text-align: center; overflow: hidden; cursor: pointer;">
                                                            <asp:Label ID="lblDateUploaded" Text='<%#Eval("DateUploaded")%>' runat="server"></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn SortExpression="TemplatesNo" HeaderText="Templates #" HeaderStyle-Width="45%"
                                                ItemStyle-Width="45%" UniqueName="TemplatesNo" Visible="true" HeaderStyle-HorizontalAlign="Center"
                                                DataField="TemplatesNo">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblTemplatesNo" runat="server"><%=objLanguage.GetLanguageConversion("Templates_#")%></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="#" id="Templates_No" runat="server">
                                                        <div style="text-align: center; overflow: hidden; cursor: pointer;">
                                                            <asp:Label ID="lblTemplatesNo" Text='<%#Eval("TemplatesNo")%>' runat="server"></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-Wrap="false">
                                                <HeaderTemplate>
                                                    <input type="checkbox" style="display: none" id="checkAll" onclick="CheckAll(this);"
                                                        runat="server" name="checkAll" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <input type="checkbox" style="display: none" runat="server" id="Chkbx1" onclick="CheckChanged();"
                                                        name="Id" value='<%# DataBinder.Eval(Container, "DataItem.PDFID", "{0}") %>' />
                                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.PDFID", "{0}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="restoreDefault" HeaderText="Action" ItemStyle-HorizontalAlign="Center"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label3" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="Chkbx2" Style="display: none" />
                                                    <%--By Jagat 26/July/2012--%>
                                                    <center>
                                                        <asp:ImageButton OnClientClick="javascript:return OnDeleteClicked_CheckboxChecked('ctl00_ContentPlaceHolder1_GridPDF',this.id);"
                                                            OnClick="lnkDelete_OnClick" ImageUrl="~/Images/erase.png" ID="imgDelete" Height="15px"
                                                            ToolTip="Delete" runat="server" /></center>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:ObjectDataSource ID="odsPDF" runat="server" TypeName="Template"
                            SelectMethod="settings_template_pdf_select" UpdateMethod="settings_itemtitle_update">
                        </asp:ObjectDataSource>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            <%=objlang .GetValueOnLang ("Loading")%>...
        </div>
    </div>
    <asp:HiddenField ID="hid_PDFID" runat="server" Value="0" />
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hidGridName" runat="server" Value="" />
    <asp:HiddenField ID="hid_OldPDFName" runat="server" Value="" />
    <asp:HiddenField ID="hid_OldPDFKey" runat="server" Value="" />
    <asp:HiddenField ID="hid_NewPDFName" runat="server" Value="" />
    <asp:HiddenField ID="hid_ReportFileName" runat="server" Value="" />
    <asp:HiddenField ID="hid_OldReportFileName" runat="server" Value="" />
    <asp:HiddenField ID="hid_IsPreFlight" runat="server" Value="0" />
    <script>
        var txtTitle = document.getElementById("<%=txtTitle.ClientID %>");
        var txtFirstPageNo = document.getElementById("<%=txtFirstPageNo.ClientID %>");
        var txtLastPageNo = document.getElementById("<%=txtLastPageNo.ClientID %>");
        var fuPDF = document.getElementById("<%=fuPDF.ClientID %>");
        var lnkFileName = document.getElementById("<%=lnkFileName.ClientID %>");
        var lnkReportFile = document.getElementById("<%=lnkReportFile.ClientID%>");
        var div_EditFile = document.getElementById("div_EditFile");
        var div_FileUpload = document.getElementById("div_FileUpload");

        var hid_PDFID = document.getElementById("<%=hid_PDFID.ClientID %>");
        var hid_OldPDFName = document.getElementById("<%=hid_OldPDFName.ClientID %>");
        var hid_OldPDFKey = document.getElementById("<%=hid_OldPDFKey.ClientID %>");
        var hid_NewPDFName = document.getElementById("<%=hid_NewPDFName.ClientID %>");
        var chkPreFlightFiles = document.getElementById("<%=chkPreFlightFiles.ClientID %>");
        var ddlPreFlightFiles = document.getElementById("<%=ddlPreFlightFiles.ClientID %>");
        var hid_OldReportFileName = document.getElementById('<%=hid_OldReportFileName.ClientID %>');
        var hid_IsPreFlight = document.getElementById('<%=hid_IsPreFlight.ClientID %>');
        var divPDFLabel = document.getElementById("divPDFLabel");

        function isNumeric(keyCode) {
            return ((keyCode >= 48 && keyCode <= 57) || keyCode == 8 || keyCode == 46 || keyCode == 37 || keyCode == 39 || keyCode == 9 ||
                    (keyCode >= 96 && keyCode <= 105))
        }

        function EditPDF(PDFID, PDFTitle, PDFName, PDFKey, ImageName, FirstPageNo, LastPageNo, ReportFileName) {
            div_FileUpload.style.display = "none";
            div_EditFile.style.display = "block";

            hid_PDFID.value = "0";
            hid_PDFID.value = PDFID;
            hid_OldPDFName.value = PDFName;
            hid_OldReportFileName.value = ReportFileName;
            hid_OldPDFKey.value = PDFKey;
            txtFirstPageNo.value = FirstPageNo;
            txtLastPageNo.value = LastPageNo;
            txtTitle.value = SpecialDecode(PDFTitle);
            lnkFileName.innerHTML = PDFName;
            lnkFileName.href = path + "DocManager.ashx?doctype=tpdf&filename=" + PDFName;
            lnkFileName.target = "_blank";
            if (ReportFileName != "") {
                lnkReportFile.style.display = "block";
                lnkReportFile.innerHTML = "Report File.pdf";
                lnkReportFile.href = path + "DocManager.ashx?doctype=tpdf&filename=" + ReportFileName;
                lnkReportFile.target = "_blank";
                divPDFLabel.style.height = "20px";
            }
            else {
                lnkReportFile.style.display = "none";
                divPDFLabel.style.height = "auto";
            }
        }
        function ChangePDF() {
            div_FileUpload.style.display = "block";
            div_EditFile.style.display = "none";
            divPDFLabel.style.height = "auto";
        }

        var CheckFinal = false;
        function uploadCheck() {
            CheckFinal = true;
            if (txtTitle.value == "") {
                document.getElementById("spn_txtTitle").style.display = "block";
                CheckFinal = false;
            }
            else {
                document.getElementById("spn_txtTitle").style.display = "none";
            }
            if (div_FileUpload.style.display == "block") {
                if (fuPDF.value == "") {
                    document.getElementById("spn_File").style.display = "block";
                    CheckFinal = false;
                }
                else {
                    document.getElementById("spn_File").style.display = "none";
                }
                if (!isValidFile(fuPDF, "spn_FileError")) {
                    CheckFinal = false;
                }
            }
            showWaitMessage();
            if (CheckFinal) {
                if (hid_IsPreFlight.value == "1") {
                    if (chkPreFlightFiles.checked && ddlPreFlightFiles.selectedIndex == 0) {
                        alert("Please select profile");
                        ddlPreFlightFiles.focus();
                        return false;
                    }
                }
                hid_NewPDFName.value = txtTitle.value;
                hid_NewPDFName.value = fuPDF.value;
                return true;
            }
            else {
                return false;
            }
        }

        function isValidFile(FileUpload, spn_Error) {
            var spn_Error = document.getElementById(spn_Error);
            var imagePath = FileUpload;
            var pathLength = imagePath.value.length;
            if (pathLength > 0) {
                var lastDot = imagePath.value.lastIndexOf(".");

                var fileType = imagePath.value.substring(lastDot, pathLength);

                if (fileType.toLowerCase() != ".pdf") {
                    spn_Error.style.display = "block";
                    return false;
                }
                else {
                    spn_Error.style.display = "none";
                    return true;
                }
            }
        }

        function EnablePreFlightDdl(chkPreFlight, ddlPreFlight) {
            if (chkPreFlight.checked) {
                ddlPreFlight.disabled = false;
            }
            else {
                ddlPreFlight.disabled = true;
            }
        }
    </script>
    <script>
        //** Func to make grid scroll when In the Update Panel **//
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        //** Func to make grid scroll when In the Update Panel **//  

        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <script>
        function OnDeleteClicked_CheckboxChecked(GridID, ImageButtonID) {
            if (confirm('<%=objLanguage.GetLanguageConversion("PDF_Delete_Confirmation")%>')) {
                var chkidnew = ImageButtonID.replace("imgDelete", "Chkbx1");
                var chkid = document.getElementById(chkidnew);
                chkid.checked = true;
                return true;
            }
            else return false;
        }
        function changebgColor(chkobj) {
            var gridid = document.getElementById("<%=GridPDF.ClientID%>");
            changeGridColor(chkobj, gridid);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>



