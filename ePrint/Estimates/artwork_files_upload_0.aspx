<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="artwork_files_upload_0.aspx.cs" Inherits="ePrint.Estimates.artwork_files_upload_0" title="File Upload" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div id="divMainContent" style="border: 0px solid; height: 250px;">
        <div style="display: none;">
            <form method="POST" name="form99" enctype="multipart/form-data">
                <input type="file" id="File1" name="photo" onchange="upload(form0,'0');" />
            </form>
        </div>
        <div>
            <%--class="borderWithoutTop"--%>
            <div style="padding-left: 10px;">
                <div class="only10px">
                    &nbsp;
                </div>
                <span class="normalText">
                    <%=objLanguage.GetLanguageConversion("OutworkFile_Upload_Lable")%>
                </span>
                <div style="margin-top: 3px;">
                    <span class="graytext" style="font-style: normal; font-weight: lighter;">
                        <%=objLanguage.GetLanguageConversion("Outwork_Note")%></span>
                </div>
                <div id="Div_AddMore" style="height: 190px; overflow-y: scroll;">
                </div>
                <div align="left">
                    <asp:PlaceHolder ID="plhFiles" runat="server"></asp:PlaceHolder>
                </div>
                <div align="left" class="only10px" style="margin: 0px 0px 10px 0px">
                    <div style="float: left; width: 18px;">
                        &nbsp;
                    </div>
                    <div style="float: left;">
                        <div style="float: left;">
                            <asp:Button ID="Button1" runat="server" Style="display: none;" CssClass="button"
                                OnClientClick="btnDone('cancel');" Text="Cancel" />
                        </div>
                        <div style="float: left; margin: 0px 0px 0px 0px">
                            <asp:Button ID="btn_AllowMore" runat="server" CssClass="button" Text="Add More" OnClientClick="AddMore_FileUpload();return false;" />
                        </div>
                        <div style="float: left; margin: 0px 0px 10px 5px">
                            <asp:Button ID="btnDone" runat="server" CssClass="button" OnClientClick="btnDone('done');"
                                Text="Upload" />
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var StoreName = new Array();
        var IsLoading = false;
        var IsSubmited = false;
        var Div_AddMore = document.getElementById("Div_AddMore");
        var pgmode = "<%=QueryType%>";
        var pw = window.parent;
        var n = 0;
        var EstimateID = "<%=EstimateID%>";
        var JobID = "<%=JobID%>";
        var InvoiceID = "<%=InvoiceID%>";
        var pg = "<%=pg%>";
        function UploadValidation(num) {
            var returnvalue = true;
            var imagePath = document.getElementById("file_" + num);
            var isValidFile = document.getElementById("lblFileError_" + num);
            var pathLength = imagePath.value.length;
            if (pathLength > 0) {
                var lastDot = imagePath.value.lastIndexOf(".");
                var fileType = imagePath.value.substring(lastDot, pathLength);
                var cut = fileType.toLowerCase();
                if (cut != ".exe" && cut != ".asp" && cut != ".php" && cut != ".dll" && cut != ".aspx" && cut != ".ascx" && cut != ".jar") {
                    isValidFile.style.display = 'none';
                    returnvalue = true;
                }
                else {
                    isValidFile.innerHTML = "Please select valid file, your file extension is '" + cut + "'.";
                    isValidFile.className = "spanerrorMsg";
                    isValidFile.style.width = '300px';
                    isValidFile.style.display = 'block';
                    returnvalue = false;
                }
            }
            else {
                returnvalue = true;
            }
            return returnvalue;
        }

        function upload(para1, num, Obj) {
            if (UploadValidation(num)) {
                var btnDone = document.getElementById("<%=btnDone.ClientID %>")
                btnDone.style.display = "none";
                IsLoading = true;
                document.getElementById("img_" + num + "").style.display = "block";
                para1.action = "artwork_files_upload.aspx?s=" + num + "&pg=" + pg + "&EstimateID=" + EstimateID + "&JobID=" + JobID + "&InvoiceID=" + InvoiceID;
                para1.submit();
            }
        }
        function endLoad(num, fileName) {
            fileName = fileName.replace(/\s|\,/g, "_"); // for bugid 4567
            StoreName.push(fileName);
            var dd = Number(Number(num) + Number(1));
            if (document.getElementById("divFilesUpload_" + dd + "") != null) {
                document.getElementById("divFilesUpload_" + dd + "").style.display = "block";
            }
            window.parent.UploadedFiles = '';
            for (var i = 0; i < StoreName.length; i++) {
                window.parent.UploadedFiles += StoreName[i] + "«";
            }
            pw.hdn_IsAddEdit.value = n;

            var btnDone = document.getElementById("<%=btnDone.ClientID %>")
            btnDone.style.display = "block";
        }
        function RemoveFromArray(num) {
            if (window.confirm('Are you sure, you want to delete this file ?')) {
                //StoreName[num] = '';
                var hdn_ArtworkFileSave = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_divprintbroker_hdn_ArtworkFileSave");
                var DeletedFile = document.getElementById("lblFileName_" + num + "").textContent;
                DeletedFile = DeletedFile.trim();
                for (i = 0; i < StoreName.length; i++) {
                    if (StoreName[i].indexOf(DeletedFile) > -1) {
                        StoreName[i] = '';
                        hdn_ArtworkFileSave.value = hdn_ArtworkFileSave.value + '«' + DeletedFile;
                        break;
                    }
                }
                document.getElementById("lblFileName_" + num + "").innerHTML = '';
                document.getElementById("file_" + num + "").value = "";
                document.getElementById("file_" + num + "").style.display = "block";

                window.parent.UploadedFiles = ''
                for (var i = 0; i < StoreName.length; i++) {
                    window.parent.UploadedFiles += StoreName[i] + "«";
                }
            }
        }

        function Test() {
            if (IsSubmited == false) {
                var data = "If you navigate from this page, you will lose your data";
                return data;
            }
            else {
                return true;
            }
        }
        function btnDone(para) {
            if (window.parent.UploadedFiles != '') {
                window.onbeforeunload = null;
                window.close();
            }
            else if (para == 'done') {
                alert('Please upload at least one file.');
            }
            else if (para == 'cancel') {
                window.onbeforeunload = null;
                window.close();
            }
            window.close();
        }

        // File Uploading...
        function OnLoad_FileUpload(m) {
            var str = '';
            for (var i = 0; i <= m; i++) {
                var counter = 0;
                if (i == 0) {
                    counter = 100000;
                }
                else {
                    counter = i - 1;
                }
                var StrDisplay = i == 0 ? "none;" : "block";
                str += "<div id='divFilesUpload_" + counter + "' style='clear:both;display:" + StrDisplay + ";'>";
                str += "<form method='POST' name='form_" + counter + "' enctype='multipart/form-data' target='photoFrame_" + counter + "'>";
                str += "<div align='left' class='normalText'><div style='float:left' >" + (counter + 1) + ".&nbsp;</div><div style='float:left'>";
                str += "<input type='file' id='file_" + counter + "' name='file_" + counter + "' onchange=upload(form_" + counter + ",'" + counter + "',this); style='width:250px;' /> ";
                str += "<div class='onlyEmpty'></div>";
                str += "<iframe id='Iframe_" + counter + "' name='photoFrame_" + counter + "'  class='hidden' src=''  ></iframe>";
                str += "<label id='lblFileName_" + counter + "'  ></label>";
                str += "<label id='lblFileError_" + counter + "'  ></label>";
                str += "</div><div style='float:left;padding-left:10px;'>";
                str += "<img id='img_" + counter + "' src='<%=strImagepath%>loading4.gif' border='0px' style='display:none;' />";
                str += "</div></div>";
                str += "</form>";
                str += "</div>";
                str += "<div class='only5px'></div>";
                n = counter + 1;
            }
            Div_AddMore.innerHTML = str;
        }

        // Add More File Uploading...
        function AddMore_FileUpload() {
            if (n < 30) {
                var str = '';
                var StrDisplay = n == 0 ? "display:block;" : "display:block";
                str += "<div id='divFilesUpload_" + n + "' style='clear:both;display:block;'>";
                str += "<form method='POST' name='form_" + n + "' enctype='multipart/form-data' target='photoFrame_" + n + "'>";
                str += "<div align='left' class='normalText'><div style='float:left' >" + (n + 1) + ".&nbsp;</div><div style='float:left'>";
                str += "<input type='file' id='file_" + n + "' name='file_" + n + "' onchange=upload(form_" + n + ",'" + n + "',this); style='width:250px;' /> ";
                str += "<div class='onlyEmpty'></div>";
                str += "<iframe id='Iframe_" + n + "' name='photoFrame_" + n + "'  class='hidden' src=''  ></iframe>";
                str += "<label id='lblFileName_" + n + "'  ></label>";
                str += "<label id='lblFileError_" + n + "'  ></label>";
                str += "</div><div style='float:left;padding-left:10px;'>";
                str += "<img id='img_" + n + "' src='<%=strImagepath%>loading4.gif' border='0px' style='display:none;' />";
                str += "</div></div>";
                str += "</form>";
                str += "</div>";
                str += "<div class='only5px'></div>";
                n++;
                Div_AddMore.innerHTML += str;
            }
            else {
                alert("You can upload only 30 files");
            }
        }
        if (pgmode == 'add') {
            if (pw.hdn_IsAddEdit.value != "0") {
                var arr = window.parent.UploadedFiles.split('«');
                OnLoad_FileUpload(Number(pw.hdn_IsAddEdit.value));
            }
            else {
                OnLoad_FileUpload(3);
            }
        }
        else if (pgmode == 'edit') {
            var arr1 = window.parent.UploadedFiles.split('«');
            if (arr1.length > 3) {
                n = arr1.length - 1;
                OnLoad_FileUpload(arr1.length - 1);
            }
            else {
                OnLoad_FileUpload(3);
            }
        }
        function WhenPageLoad() {
            var countUp = 0;
            if (trim12(window.parent.UploadedFiles) != null) {
                var arr1 = window.parent.UploadedFiles.split('«');
                StoreName.length = 0;
                for (var i = 0; i < (arr1.length - 1) ; i++) {
                    if (arr1[i] != '') {
                        arr1[i].replace(/\s|\,/g, "_"); // for bugid 4567
                        if (document.getElementById("divFilesUpload_" + i + "") != null) {
                            document.getElementById("divFilesUpload_" + i + "").style.display = "block";
                        }
                        var pa = "<%=strDownLoad %>" + arr1[i];
                        document.getElementById("lblFileName_" + i + "").innerHTML = "<a href='" + pa + "'  target='_Blank'  >" + arr1[i] + "</a>&nbsp;&nbsp;<img src='../images/close.gif' onclick=RemoveFromArray('" + i + "'); />";
                        document.getElementById("lblFileName_" + i + "").value = arr1[i];
                        document.getElementById("file_" + i + "").style.display = "none";
                        StoreName.push(arr1[i]);
                        countUp++;
                    }
                }

            }
        }

        WhenPageLoad();

    </script>
</asp:Content>

