<%@ page language="C#" autoeventwireup="true" CodeBehind="image_gallery.aspx.cs" Inherits="ePrint.StoreSettings.image_gallery" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../js/jquery.min.js?VN='<%#VersionNumber%>'"></script>
<script type="text/javascript" src="../js/jquery.popup.js?VN='<%#VersionNumber%>'"></script>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" language="javascript" src="../js/commonloading.js?VN='<%#VersionNumber%>'"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" href="../App_Themes/Theme1/item.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        #RadTabStrip1 {
            width: 200px !important;
        }

        .Striptext {
            font-family: "Verdana",Verdana, Verdana,Arial,Helvetica;
            font-size: 12px;
        }

        #flImageUploadAddButton, #flImageUploadDeleteButton {
            visibility: collapse;
            width: 100px;
            cursor: pointer;
            text-align: center;
            font: 11px "Verdana", Verdana, Arial, Helvetica, sans-serif;
            text-shadow: 0 1px 1px rgba(0,0,0,.3);
            -webkit-border-radius: .5em;
            -moz-border-radius: .5em;
            border-radius: .5em;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            box-shadow: 0 1px 2px rgba(0,0,0,.2);
            color: #2C2B2B;
            background: #EEEEEE;
            background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));
            background: -moz-linear-gradient(top, #E8E8E8, #F9F8F8);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#E8E8E8', endColorstr='#F9F8F8');
            border: solid 1px #a3a3a3;
        }

            #flImageUploadAddButton:hover {
                text-decoration: none;
                background: #C9C9C9;
                background: -webkit-gradient(linear, left top, left bottom, from(#A7D9F5), to(#EAF6FD));
                background: -moz-linear-gradient(top, #A7D9F5, #EAF6FD);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#A7D9F5', endColorstr='#EAF6FD');
            }

            #flImageUploadDeleteButton:hover {
                text-decoration: none;
                background: #C9C9C9;
                background: -webkit-gradient(linear, left top, left bottom, from(#A7D9F5), to(#EAF6FD));
                background: -moz-linear-gradient(top, #A7D9F5, #EAF6FD);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#A7D9F5', endColorstr='#EAF6FD');
            }

        .RadUpload .ruCheck {
            display: none;
        }

        .RadUpload_Default .ruRemove {
            display: none;
        }

        .RadUpload_Default .ruFakeInput {
            width: 260px;
            margin-left: 5px;
        }

        .RadUpload .ruBrowse {
            margin-left: 17px !important;
        }

        #flImageUpload {
            width: 450px !important;
        }

        .RadUpload .ruFileWrap {
            padding-right: 0.5em !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"
            EnablePageMethods="true">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cboCategory" />
                    </UpdatedControls>
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadTabStrip1" />
                    </UpdatedControls>
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="plhGalleryDetails" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <asp:ScriptManagerProxy ID="SMproxy" runat="server">
            <Services>
                <asp:ServiceReference Path="~/AutoFill.asmx" />
            </Services>
        </asp:ScriptManagerProxy>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="divtab" runat="server">
            <div class="exampleWrapper" style="margin: 20px 10px 0px 10px;">
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1"
                    OnClientTabSelected="OnTabSelected" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Gallery" Width="100px">
                            <TabTemplate>
                                <span class="Striptext">
                                    <%=objLanguage.GetLanguageConversion("Gallery")%>
                                </span>
                            </TabTemplate>
                        </telerik:RadTab>
                        <telerik:RadTab Text="Upload File" Width="100px" CssClass="Striptext">
                            <TabTemplate>
                                <span class="Striptext">
                                    <%=objLanguage.GetLanguageConversion("Upload_File")%></span>
                            </TabTemplate>
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <div id="divSearch" runat="server" style="float: right; display: none; margin-top: -30px;">
                    <div style="margin-right: 20px;" class="div_floatleft">
                        <div class="div_floatleft">
                            <asp:Button ID="btnSelectAll" runat="server" Text="Select All" OnClientClick="javascript:SelectAll(); return false;"
                                class="button" Style="width: 70px; margin-right: 10px; display: block;"></asp:Button>
                            <asp:Button ID="btnUnSelectAll" runat="server" Text="UnSelect All" OnClientClick="javascript:UnSelectAll(); return false;"
                                class="button" Style="width: 110px; margin-right: 10px; display: none;"></asp:Button>
                        </div>
                        <div class="div_floatleft">
                            <asp:Button ID="btnDeleteSelected" runat="server" Text="Delete Selected" OnClientClick="javascript:DeleteAll(); return false;"
                                class="button" Style="width: 110px;"></asp:Button>
                            <asp:LinkButton ID="btnlnkDeleteSelected" runat="server" Style="display: none;" OnClick="btnlnkDeleteSelected_OnClick"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="div_floatleft">
                        <div id="divSearchBox" style="float: left;">
                            <input id="txt_search" type="text" class="SearchBox" value="Enter Text Search" runat="server"
                                onclick="vaidate_Search();" onblur="defaultText();" onkeypress="return capturekey(event);" />
                        </div>
                        <div id="divSearchImage" class="div_floatleft">
                            <a id="href_search" href="#" onclick="Onclick_Search()">
                                <asp:Image ID="img_search" runat="server" ImageUrl="~/images/search_icon.png" alt=""
                                    Style="margin-top: 5px;" ToolTip="Search" />
                            </a>
                        </div>
                    </div>
                </div>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" EnableTheming="true"
                    ScrollBars="Vertical" Style="border: 1px solid; border-color: #98A6B3;" Height="360">
                    <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="overflow" >
                        <div id="divgalContent" runat="server" class="divgalContent">
                            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0">
                                <telerik:RadPageView runat="server" ID="PageView1">
                                    <div style="width: 100%;">
                                        <asp:PlaceHolder ID="plhGalleryDetails" runat="server"></asp:PlaceHolder>
                                    </div>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </div>
                        <div style="padding-left: 25px;" class="div_floatleft">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="button"
                                Style="display: none;"></asp:Button>
                        </div>
                        <%--  <div style="padding-left: 25px;" class="div_floatleft">
                        <asp:Button ID="Button1" runat="server" Text="Show More" OnClientClick="javascript:Showmore(); return false;"
                            class="button" Style="display: block;"></asp:Button>
                    </div>--%>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="overflow">
                        <div id="divimgs" runat="server" class="ImageLists" style="margin-bottom: 10px;">
                            <asp:UpdatePanel ID="panelIMg" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhImagedetails" runat="server"></asp:PlaceHolder>
                                    <asp:HiddenField ID="pnlstatus" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div id="divupld" runat="server" class="UploadImages">
                                <div style="float: left;" class="bglabelnew">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                </div>
                                <div class="combo_boxdiv">
                                    <telerik:RadComboBox ID="cboCategory" runat="server" Width="270">
                                    </telerik:RadComboBox>
                                </div>
                                <div style="float: left; margin-left: 15px;">
                                    <asp:Button ID="btnAddCtegory" runat="server" Text="Add New Category" OnClientClick="javascript:AddNewCategory();return false;"
                                        class="button" Width="150px"></asp:Button>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div class="scrollDiv">
                                    <asp:PlaceHolder runat="server" ID="Panel1" Visible="true">
                                        <div class="fileUpload">
                                            <telerik:RadUpload ID="flImageUpload" runat="server" AllowedFileExtensions="jpg,jpeg,png,gif,pdf"
                                                ControlObjectsVisibility="All" InitialFileInputsCount="5" BorderWidth="0" MaxFileInputsCount="5">
                                                <Localization Add="Add More Files"></Localization>
                                            </telerik:RadUpload>
                                        </div>
                                        <%-- <div style="float: left; padding: 10px 0px 0px 170px;">
                                        <span class="smallgraytext">
                                            <%=objLanguage.GetLanguageConversion("You_can_upload_up_to_5_files_at_once")%></span>
                                    </div>--%>
                                    </asp:PlaceHolder>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div class="btUplaod" style="margin-top: 0px;padding-top: 5%;">
                                    <div id="divbtnupld">
                                        <asp:Button ID="btnUplaod" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                            OnClientClick="javascript:var a= GetCategoryID();if(a)loadingimg('divbtnupld','div_process');return a"
                                            class="button" Style="width: 65px; margin-top: -25px;"></asp:Button>
                                    </div>
                                    <div id="div_process" class="button" align="center" style="width: 65px; display: none; margin-top: -25px;">
                                        <img src="../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                    <asp:HiddenField ID="hdnCatIDafterupld" runat="server" Value="" />
                                </div>
                                 <table>
                                <tr>
                                    <td>
                                        <div>
                                            <asp:Label runat="server" ID="lblImgguidance"><b><%=objLanguage.GetLanguageConversion("Image_guide_lines")%></b></asp:Label>

                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <asp:Label runat="server" class="smallgraytext" ID="Label15"><%=objLanguage.GetLanguageConversion("Please_upload_JPEG_or_PNG_file")%></asp:Label><br />
                                            <asp:Label runat="server" class="smallgraytext" ID="Label16"><%=objLanguage.GetLanguageConversion("PDF_singlePage")%></asp:Label><br />
                                            <asp:Label runat="server" class="smallgraytext" ID="Label3"><%=objLanguage.GetLanguageConversion("PDF_files_cropped")%></asp:Label><br />
                                            <asp:Label runat="server" class="smallgraytext" ID="Label18"><%=objLanguage.GetLanguageConversion("PDF_files_Background")%></asp:Label><br />
                                        </div>
                                    </td>
                                </tr>
                            </table>

                                <div style="float: left; padding-left: 6px; padding-top: 2px;">
                                </div>
                            </div>
                            
                        </div>                     
                        <div style="padding-left: 10px; float: left;">
                            <asp:Button ID="btncancel" runat="server" Style="display: none;" Text="Cancel" OnClick="btncancel_Click"
                                OnClientClick="javascript:btncancelClick(); return false;" class="button"></asp:Button>
                        </div>
                        <div style="float: left;">
                            <div style="float: left; padding: 0px 0px 0px 10px;" id="divsave">
                                <asp:Button ID="btnsave" runat="server" Text="Save Changes" OnClientClick="javascript:var a= UpLoadFilesDetail();if(a)loadingimg('divsave','div_processimg');return a"
                                    OnClick="btnUpdate_Click" class="button" Style="width: 100px; display: none;"></asp:Button>
                            </div>
                            <div id="div_processimg" align="center" class="button" style="width: 80px; display: none; position: relative; left: 12px;">
                                <img src="../images/radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>                          
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
            <asp:Button ID="btnDeleteRootImage" runat="server" Style="display: none;" OnClick="btnDeleteRootImage_Click" />
            <asp:Button ID="btnDeleteImageCategory" runat="server" Style="display: none;" OnClick="btnDeleteImageCategory_OnClick" />
            <asp:Button ID="btnCategory" runat="server" Style="display: none;" OnClick="btnCategory_Click" />
            <asp:Button ID="btnSearch" runat="server" Style="display: none;" OnClick="btnSearch_Click" />
            <asp:HiddenField ID="hdnSearchtext" runat="server" Value="" />
            <asp:HiddenField ID="hdnCategoryID" runat="server" Value="" />
            <asp:HiddenField ID="hdnParentCatID" runat="server" Value="" />
            <asp:HiddenField ID="hdnDeleterootImg" runat="server" Value="" />
            <asp:HiddenField ID="hdnDeleteCatImg" runat="server" Value="" />
            <asp:HiddenField ID="hdnImageDetails" runat="server" Value="" />
            <asp:HiddenField ID="hdnImageCount" runat="server" Value="0" />
            <asp:HiddenField ID="hdnCategoryIDs" runat="server" Value="" />
            <asp:HiddenField ID="hdnImageIDs" runat="server" Value="" />
            <asp:HiddenField ID="hdnInUseImageID" runat="server" Value="" />
            <asp:HiddenField ID="hdnInUseCategoryID" runat="server" Value="" />
        </div>
        <script>
            function OnTabSelected(sender, eventArgs) {
                var tab = document.getElementById("<%=RadTabStrip1.ClientID %>");
                if (tab.control._selectedIndex == 1) {
                    document.getElementById("<%=divSearch.ClientID %>").style.display = 'none';
                    document.getElementById("<%=RadPageView1.ClientID %>").style.display = 'none';
                    document.getElementById("<%=RadPageView2.ClientID %>").style.display = 'block';
                    document.getElementById("<%=divupld.ClientID %>").style.display = 'block';
                    if (pnlstatus.value == 'visible') {
                        document.getElementById("<%=divupld.ClientID %>").style.display = 'none';
                        document.getElementById("<%=btnsave.ClientID %>").style.display = 'block';
                        document.getElementById("<%=btncancel.ClientID %>").style.display = 'block';
                        document.getElementById("<%=panelIMg.ClientID %>").style.display = 'block';
                    }
                }
                else {
                    document.getElementById("<%=divSearch.ClientID %>").style.display = 'block';
                    document.getElementById("<%=RadPageView2.ClientID %>").style.display = 'none';
                    document.getElementById("<%=RadPageView1.ClientID %>").style.display = 'block';
                    document.getElementById("<%=divupld.ClientID %>").style.display = 'none';
                }
            }
        </script>
        <div id="divrad" style="display: none; position: absolute; vertical-align: middle; border: 0px solid; z-index: 100; width: 50%"
            align="center">
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                <Windows>
                    <telerik:RadWindow ID="addnewcategory" runat="server" Opacity="100" Title="" OnClientClose="RadWinClose"
                        EnableShadow="false" KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true"
                        Modal="true" Width="500" Style="z-index: 31000" Height="120" ShowContentDuringLoad="false"
                        Behaviors="Close,Move,Reload,Resize,Maximize">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
        <script type="text/javascript">
            function AddNewCategory() {
                var strSitePath = '<%=strSitePath %>';
                var popup = $find("<%=addnewcategory.ClientID %>");
                popup.setUrl(strSitePath + "StoreSettings/add_newcategory.aspx?from=StoreSettings/image_gallery?&type=new");
                popup.setSize(500, 300);
                popup.center();
                popup.show();
            }

            function EditImageCategory(ParentID, CatName, CatID) {
                var strSitePath = '<%=strSitePath %>';
                var popup = $find("<%=addnewcategory.ClientID %>");
                popup.setUrl(strSitePath + "StoreSettings/add_newcategory.aspx?from=StoreSettings/image_gallery?&ParentID=" + ParentID + "&CatName=" + CatName + "&CatID=" + CatID + "");
                popup.setSize(500, 300);
                popup.center();
                popup.show();
            }
            function EditImageDetails(imgID, CatID, Name, desc, tags, fileName) {
                var strSitePath = '<%=strSitePath %>';
                var popup = $find("<%=addnewcategory.ClientID %>");
                popup.setUrl(strSitePath + "StoreSettings/edit_image_details.aspx?from=StoreSettings/image_gallery?&imgID=" + imgID + "&CatID=" + CatID + "&Name=" + Name + "&Desc=" + desc + "&Tags=" + tags + "&FileName=" + fileName + "");
                popup.setSize(650, 400);
                popup.center();
                popup.show();
            }

            function RadWinClose() {
                document.getElementById("divrad").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
            }

        </script>
        <script type="text/javascript">
            function GetCategoryID() {

                var valid = true;
                var CategoryID = $find("<%=cboCategory.ClientID %>")._value;
                document.getElementById("<%=hdnCatIDafterupld.ClientID %>").value = CategoryID;
                var ItemCount = 0;
                var upload = $find("<%= flImageUpload.ClientID %>");
                var inputs = upload.getFileInputs();
                if (inputs.length != 0) {
                    for (var i = 0; i < inputs.length; i++) {
                        if (inputs[i].value != "") {
                            ItemCount++;
                            var fileExtention = inputs[i].files[0].name.substring(inputs[i].files[0].name.lastIndexOf('.') + 1, inputs[i].files[0].name.length);
                            if (upload._allowedFileExtensions.indexOf(fileExtention.toLowerCase()) == -1) {
                                alert('Please select valid file(allowed files: jpg,jpeg,png,gif,pdf)');
                                valid = false;
                                break;
                            }
                        }
                    }
                    if (ItemCount == 0) {
                        alert('Please select at least one file to upload');
                        valid = false;
                    }
                }
                //            else {
                //                alert('Please click Add button to upload files');
                //                valid = false;
                //            }
                return valid;
            }
            function UpLoadFilesDetail() {

                var ImageCount = document.getElementById("<%=hdnImageCount.ClientID %>").value;
                var ImageDetails = document.getElementById("<%=hdnImageDetails.ClientID %>");

                ImageDetails.value = "";
                for (var i = 0; i < ImageCount; i++) {
                    var ImageID = document.getElementById("ImageID_" + i);
                    var txtFileName = document.getElementById("txtFileName_" + i);
                    var MetaTags = document.getElementById("txttagName_" + i);
                    var txtDesc = document.getElementById("txtDesc_" + i);

                    ImageDetails.value = ImageDetails.value + ImageID.value + '§' + txtFileName.value + '§' + MetaTags.value + '§' + txtDesc.value + '¶';
                }

                return true;
            }

            function btncancelClick() {
                document.getElementById("<%=divupld.ClientID %>").style.display = 'block';
                document.getElementById("<%=panelIMg.ClientID %>").style.display = 'none';
                document.getElementById("<%=pnlstatus.ClientID %>").value = 'hide';
                document.getElementById("<%=btncancel.ClientID %>").style.display = 'none';
                document.getElementById("<%=btnsave.ClientID %>").style.display = 'none';
                return;
            }

            function mouseovershow(MainDiv) {
                var EditBlock = document.getElementById(MainDiv.id.replace('DivMain', 'DivEdit'));
                EditBlock.style.display = "block";
            }

            function mouseouthidDiv(MainDiv) {
                var EditBlock = document.getElementById(MainDiv.id.replace('DivMain', 'DivEdit'));
                EditBlock.style.display = "none";
            }

            function mouseovershowImage(MainDiv) {
                var RootImgEditBlock = document.getElementById(MainDiv.id.replace('DivRootImg', 'DivRootImgEdit'));
                RootImgEditBlock.style.display = "block";
            }

            function mouseouthidDivImage(MainDiv) {
                var RootImgEditBlock = document.getElementById(MainDiv.id.replace('DivRootImg', 'DivRootImgEdit'));
                RootImgEditBlock.style.display = "none";
            }


            function DeleteImage(ImageID, parentID) {

                Parnt_ID = parentID;
                var UserID = '<%=UserID %>';
                document.getElementById("<%=hdnInUseImageID.ClientID %>").value = '';
                document.getElementById("<%=hdnInUseImageID.ClientID %>").value = ImageID;
                AutoFill.IsGalleryImageAssigned(ImageID, UserID, GetResultImageCheck, onTimeout, onError);
            }

            function GetResultImageCheck(Action) {

                var UserID = '<%=UserID %>';
            if (Action == 'false') {
                var res = window.confirm('Are you sure you want to delete this image? It will be removed from any products that it is currently allocated to.');
                if (res == true) {
                    var ImgID = document.getElementById("<%=hdnInUseImageID.ClientID %>").value;
                    AutoFill.DeleteSingleInUseImage(ImgID, UserID);

                    document.getElementById("<%=hdnParentCatID.ClientID %>").value = Parnt_ID;
                    var clickButton = document.getElementById("<%= btnDeleteRootImage.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
            else {
                var res = window.confirm('Are you sure you want to delete Image');
                if (res == true) {
                    var ImgID = document.getElementById("<%=hdnInUseImageID.ClientID %>").value;
                    AutoFill.DeleteSingleInUseImage(ImgID, UserID);

                    document.getElementById("<%=hdnParentCatID.ClientID %>").value = Parnt_ID;
                    var clickButton = document.getElementById("<%= btnDeleteRootImage.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
        }


        var Parent_ID = '';
        function DeleteImageCategory(CategoryID, parentID) {
            Parent_ID = parentID;
            var UserID = '<%=UserID %>';
            document.getElementById("<%=hdnInUseCategoryID.ClientID %>").value = '';
            document.getElementById("<%=hdnInUseCategoryID.ClientID %>").value = CategoryID;
            AutoFill.IsGalleryCategoryAssigned(CategoryID, UserID, GetResultCategoryCheck, onTimeout, onError);
        }

        function GetResultCategoryCheck(Action) {
            var UserID = '<%=UserID %>';
            if (Action == 'false') {
                var res = window.confirm('Are you sure you want to delete this image? It will be removed from any products that it is currently allocated to.');
                if (res == true) {
                    var CategoryID = document.getElementById("<%=hdnInUseCategoryID.ClientID %>").value;
                    AutoFill.DeleteSingleInUseCategory(CategoryID, UserID);

                    document.getElementById("<%=hdnParentCatID.ClientID %>").value = Parent_ID;
                    var clickButton = document.getElementById("<%= btnDeleteImageCategory.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
            else {
                var res = window.confirm('Are you sure you want to delete this Category');
                if (res == true) {
                    var CategoryID = document.getElementById("<%=hdnInUseCategoryID.ClientID %>").value;
                    AutoFill.DeleteSingleInUseCategory(CategoryID, UserID);

                    document.getElementById("<%=hdnParentCatID.ClientID %>").value = Parent_ID;
                    var clickButton = document.getElementById("<%= btnDeleteImageCategory.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
        }

        function onTimeout(request, context) { }

        function onError(objError) {
        }

        function OnCategoryClick(CatID) {
            document.getElementById("<%=hdnCategoryID.ClientID %>").value = CatID;
            var clickButton = document.getElementById("<%= btnCategory.ClientID %>");
            clickButton.click();
        }
        </script>
        <script type="text/javascript">
            function defaultText() {
                txt_search.className = "SearchBox";
                divSearchBox.className = "divSearchBox";
                if (txt_search.value == "") {
                    txt_search.value = "Enter Text Search";
                }
            }
            function vaidate_Search() {
                txt_search.value = "";
                txt_search.className = "SearchBox";
                divSearchBox.className = "divSearchBoxColor";
            }
            function vaidate_Search() {
                txt_search.value = "";
                txt_search.className = "SearchBox";
                divSearchBox.className = "divSearchBoxColor";
            }
            function capturekey(e) {
                var evt = e ? e : window.event;
                var bt = document.getElementById("<%=img_search.ClientID %>");
                if (bt) {
                    if (evt.keyCode == 13) {
                        Onclick_Search();
                        return false;
                    }
                }
            }
            function vaidate_SearchImg() {
                if (txt_search.value == "" || txt_search.value == "Enter Text Search") {
                    alert("Please enter search text");
                    return false;
                }
                else {
                    return true;
                }
            }
            function Onclick_Search() {
                var search = true;
                search = vaidate_SearchImg();
                if (search) {
                    document.getElementById("<%=hdnSearchtext.ClientID %>").value = txt_search.value;
                    var clickButton = document.getElementById("<%= btnSearch.ClientID %>");
                    clickButton.click();
                }
                else
                    return false;
            }
            function SelectAll() {
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.id.indexOf("flImageUploadcheckbox") == -1) {
                        if (!e.disabled) {
                            e.checked = true;
                            document.getElementById("<%=btnUnSelectAll.ClientID %>").style.display = "block";
                            document.getElementById("<%=btnSelectAll.ClientID %>").style.display = "none";
                        }
                    }
                }
            }
            function UnSelectAll() {
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox') {
                        if (!e.disabled) {
                            e.checked = false;
                            document.getElementById("<%=btnUnSelectAll.ClientID %>").style.display = "none";
                            document.getElementById("<%=btnSelectAll.ClientID %>").style.display = "block";

                        }
                    }
                }
            }
            function DeleteAll() {
                var CatIDlist = "";
                var ImgIDlist = "";
                var CompanyID = '<%=CompanyID %>';
            var UserID = '<%=UserID %>';
            var frm = document.forms[0];
            var checked = false;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox') {
                    if (!e.disabled && e.checked == true) {
                        checked = true;
                        var strID = e.id.split('_');
                        if (strID[0] == 'chkCatMulDel') {
                            var strrplsed = 'hdnCatIDMultpleDel'; // strID[0].replace('chkCatMulDel', 'hdnCatIDMultpleDel');
                            CatIDlist = CatIDlist + document.getElementById(strrplsed + '_' + strID[1]).value + '§';
                        }
                        else if (strID[0] == 'chkImgMulDel') {
                            var strrplsed = 'hdnImgIDMultpleDel'; //strID[0].replace('chkImgMulDel', 'hdnImgIDMultpleDel');
                            ImgIDlist = ImgIDlist + document.getElementById(strrplsed + '_' + strID[1]).value + '~';
                        }
                        else if (strID[0] == 'chkChildCatMulDel') {
                            var strrplsed = 'hdnChildCatIDMultpleDel';  //strID[0].replace('chkChildCatMulDel', 'hdnChildCatIDMultpleDel');
                            CatIDlist = CatIDlist + document.getElementById(strrplsed + '_' + strID[1]).value + '§';
                        }
                        else if (strID[0] == 'chkChildImgMulDel') {
                            var strrplsed = 'hdnChildIDMultpleDel'; //strID[0].replace('chkChildImgMulDel', 'hdnChildIDMultpleDel');
                            ImgIDlist = ImgIDlist + document.getElementById(strrplsed + '_' + strID[1]).value + '~';
                        }
                        else if (strID[0] == 'chkSearchImgdelete') {
                            var strrplsed = 'hdnSearchMultpleDel';
                            ImgIDlist = ImgIDlist + document.getElementById(strrplsed + '_' + strID[1]).value + '~';
                        }
                    }
                }
            }
            if (checked) {
                document.getElementById("<%=hdnCategoryIDs.ClientID %>").value = CatIDlist;
                document.getElementById("<%=hdnImageIDs.ClientID %>").value = ImgIDlist;
                var res = window.confirm('Are you sure you want to delete?');
                if (res == true) {
                    AutoFill.DeleteMultipleImageCategory(CompanyID, UserID, CatIDlist, ImgIDlist, GetResult, onTimeout, onError);
                }
                else {
                    return false;
                }
            }
            else {
                alert('Please select files or folders to delete');
                return false;
            }
        }
        function GetResult(result) {
            if (result == 'false') {
                // alert('You can not delete, it is assigned to object in system');
                var res = window.confirm('Are you sure you want to delete this image? It will be removed from any products that it is currently allocated to.');
                if (res == true) {
                    var clickButton = document.getElementById("<%= btnlnkDeleteSelected.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
            else {
                //                var clickButton = document.getElementById("<%= btnlnkDeleteSelected.ClientID %>");
                //                clickButton.click();

                var res = window.confirm('Are you sure you want to delete?');
                if (res == true) {
                    var clickButton = document.getElementById("<%= btnlnkDeleteSelected.ClientID %>");
                    clickButton.click();
                }
                else {
                    return false;
                }
            }
        }
        function onTimeout(request, context) { }

        function onError(objError) {
        }
        </script>
    </form>
</body>
</html>

