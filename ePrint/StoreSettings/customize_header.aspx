<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="customize_header.aspx.cs" Inherits="ePrint.StoreSettings.customize_header"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        var AccountID = '<%=AccountID %>';
    </script>
    <script type="text/javascript" src="../js/jquery-1.3.2.js" language="javascript"></script>
    <script type="text/javascript" src="../js/helptext.js" language="javascript"></script>
    <!--POPUP START-->
    <!--POPUP END-->
    <div class="estore_settingBox">
        <div align="left" id="pnldetails">
            <div align="left">
                <UC:Header ID="header" runat="server" />
                <%--    <span class="navigatorpanel">
                    <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Customize_Header")%>&nbsp;
                    <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                        href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                        <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                    </a></span>--%>
                <div style="clear: both;">
                </div>
                <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="padding: 3px 0px 0px 8px; margin-top: -5px;">
                    <table cellspacing="2" cellpadding="2" width="100%" align="center" border="0">
                        <tr>
                            <td width="1">
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td class="normaltext bglabel" style="width: 150px;">
                                <asp:RadioButton ID="rdtext" Checked="true" GroupName="logo" Text='Text' CssClass="normaltext"
                                    Style="margin-left: -4px;" runat="server" onclick="CheckallRadiobutton()" />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_text" runat="server" CssClass="txtbox" Width="60%" MaxLength="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td class="normaltext bglabel" style="width: 150px;">
                                <div>
                                    <asp:RadioButton ID="rdimage" Checked="false" GroupName="logo" Text='Image' CssClass="normaltext"
                                        Style="margin-left: -4px;" runat="server" onclick="CheckallRadiobutton()" />
                                    <a id="img_Help_ShortDescritpion_Link_Image" runat="server" href="javascript:void(0);"
                                        class="tooltip" title=" File exstensions allowed: .gif, .png, .jpg, .jpeg, .tiff, .tif, .bmp">
                                        <img alt="" id="img_help_ShortDescription" runat="server" src="../images/Help-icon.png"
                                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" /></a>
                                </div>
                                <div id="divsize" runat="server" style="margin: 10px 0px 2px 17px;">
                                    <asp:Label ID="lblsize" runat="server" Text="Size"></asp:Label></div>
                            </td>
                            <td>
                                <div>
                                    <div style="float: left;">
                                        <asp:FileUpload ID="fu_header" size="30" CssClass="txtbox" runat="server" Style="display: block;" />
                                        <div id="div_customizeSize" runat="server">
                                            <div>
                                                <asp:RadioButton onclick="javascript:ChangeTextBox()" GroupName="logosize" ID="rdologosize"
                                                    runat="server" Text="Image will be resized proportionately to a max width of 950 pixels">
                                                </asp:RadioButton>
                                            </div>
                                            <div>
                                                <div style="float: left; width: 260px;">
                                                    <asp:RadioButton onclick="javascript:ChangeTextBox()" GroupName="logosize" ID="chk_imgSize"
                                                        runat="server" Checked="false" Text='Change Image width to ' />
                                                    <div id="div_HeightWidht" runat="server" style="float: right; margin: 2px 10px 0px 0px;">
                                                        <div>
                                                            <%--<asp:Label ID="lbl_width" runat="server" Text="Width"></asp:Label>--%>
                                                            <asp:TextBox Enabled="false" ID="txt_width" runat="server" Style="width: 50px; height: 13px;"
                                                                MaxLength="4" onkeyup='javascript:checkForNumbers(this.value,"w");'></asp:TextBox>
                                                            <asp:Label ID="lbl_px" runat="server" Text="pixels"></asp:Label>
                                                        </div>
                                                        <div style="float: left; width: 100px; display: none;">
                                                            <asp:Label ID="lbl_height" runat="server" Text="Height"></asp:Label>
                                                            <asp:TextBox ID="txt_height" runat="server" Style="width: 50px" MaxLength="4" onkeyup='javascript:checkForNumbers(this.value,"h");'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 400px;">
                                                <asp:RadioButton GroupName="logosize" onclick="javascript:ChangeTextBox()" ID="rdomakeitcentpercent"
                                                    runat="server" Text='Make Image Width 100% wide' />
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; margin: 3px 0px 0px 5px">
                                        <asp:Label CssClass="error" ID="lblError" runat="server" Text="Please upload image file"
                                            Style="display: none; width: 200px;"><%=objLanguage.GetLanguageConversion("Please_Upload_Image_File")%></asp:Label></div>
                                    <asp:HiddenField ID="hd_image" runat="server" />
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div_imageLink" runat="server" style="margin: 0px 0px 0px 0px;">
                                    <div style="float: left; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;">
                                        <asp:Label ID="lbl_curImg" runat="server" Text="Current Image:" Style="display: none;"><%=objLanguage.GetLanguageConversion("Current_Image")%>:</asp:Label>
                                    </div>
                                    <div style="float: left; padding: 0px 0px 0px 5px">
                                        <a id="href_image" runat="server">
                                            <asp:Label ID="lbl_image" runat="server" Text="" Style="display: none;" ForeColor="Red"></asp:Label>
                                        </a>
                                    </div>
                                    <div style="float: left; padding: 0px 0px 0px 10px">
                                        <a id="A3" href="javascript:void(0);" runat="server">
                                            <asp:Label ID="lbl_remove" runat="server" Text="Change" Style="display: none;" onclick="javascript:ChangeImage();"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div style="float: left; padding: 5px 0px 0px 5px;">
                                    <%--<asp:Label ID="lbl_msg" runat="server" Text="(Uploaded image max width is 950px, please check your image is no larger than 950px before uploading)"
                                        Style="clear: both;" CssClass="smallerfontgrey">(<%=objLanguage.GetLanguageConversion("Uploaded_Image_Max_Width_WillBe_950px_BeforeUploading")%>)</asp:Label><br />--%>
                                   <%-- <asp:Label ID="lbl_ImgNote" runat="server" CssClass="smallerfontgrey" Text="Please note the image will take upto 10min to apply in store"><%=objLanguage.GetLanguageConversion("Please_Note_The_Image_Will_Take_Upto_10min_To_Apply_In_Store")%></asp:Label>--%>
                                </div>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td class="normaltext bglabel" style="width: 150px;" nowrap="nowrap">
                                <asp:RadioButton ID="rdtemplate" GroupName="logo" Text='Custom HTML' CssClass="normaltext"
                                    Style="margin-left: -4px;" runat="server" onclick="CheckallRadiobutton()" />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_template" runat="server" CssClass="txtbox" Width="550" MaxLength="50000"
                                    TextMode="MultiLine" Rows="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left" style="display: none;">
                            <td class="normaltext" width="10%">
                            </td>
                            <td class="normaltext">
                                <asp:CheckBox ID="chkdefault" CssClass="normalText" Text='Restore Default' runat="server" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td class="normaltext" width="10%">
                            </td>
                            <td>
                                <div style="margin: 7px 0px 10px 0px;">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" OnClick="btn_Save_Click"
                                            OnClientClick="javascript:var a=validate();if(a!=false)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 0.5px" class="loadingimg"
                                            alt="loading" border="0" />
                                    </div>
                                </div>
                            </td>
                            <td width="80%">
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="clear: both;">
                </div>
                <%-- </div>--%>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var rdimage = document.getElementById("<%=rdimage.ClientID %>");
        var lblError = document.getElementById("<%=lblError.ClientID %>");
        var fu_header = document.getElementById("<%=fu_header.ClientID %>");
        var hd_image = document.getElementById("<%=hd_image.ClientID %>");
        var div_customizeSize = document.getElementById("<%=div_customizeSize.ClientID %>");
        var chk_imgSize = document.getElementById("<%=chk_imgSize.ClientID %>");
        var div_HeightWidht = document.getElementById("<%=div_HeightWidht.ClientID %>");
        var txt_width = document.getElementById("<%=txt_width.ClientID %>");
        var txt_height = document.getElementById("<%=txt_height.ClientID %>");

        var rdomakeitcentpercent = document.getElementById("<%=rdomakeitcentpercent.ClientID %>");
        var divsize = document.getElementById("<%=divsize.ClientID %>");

        var rdtext = document.getElementById("<%=rdtext.ClientID %>");
        var rdtemplate = document.getElementById("<%=rdtemplate.ClientID %>");
        var rdologosize = document.getElementById("<%=rdologosize.ClientID %>");


        function ChangeImage() {
            document.getElementById("<%=fu_header.ClientID %>").style.display = "block";
            document.getElementById("<%=div_customizeSize.ClientID %>").style.display = "block";
            document.getElementById("<%=div_imageLink.ClientID %>").style.display = "none";

            rdomakeitcentpercent.checked = false;
            chk_imgSize.checked = false;
            rdologosize.checked = true;
            divsize.style.display = "block";

            hd_image.value = "";
        }

        function CheckallRadiobutton() {
            if (rdimage.checked) {
                chk_imgSize.disabled = false;
                rdologosize.disabled = false;
                rdomakeitcentpercent.disabled = false;
                rdologosize.checked = true;
                txt_width.disabled = true;

                document.getElementById("<%=fu_header.ClientID%>").disabled = false;

                document.getElementById("<%=txt_text.ClientID%>").disabled = true;
                document.getElementById("<%=txt_template.ClientID%>").disabled = true;
                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = false;
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { ChangeImage(); return true; }
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return true; }
            }
            else if (rdtext.checked) {
                document.getElementById("<%=fu_header.ClientID%>").disabled = true;
                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = true;
                document.getElementById("<%=href_image.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=A3.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { return false; }

                document.getElementById("<%=txt_text.ClientID%>").disabled = false;
                document.getElementById("<%=txt_template.ClientID%>").disabled = true;

                txt_width.disabled = true;
                chk_imgSize.disabled = true;
                rdologosize.disabled = true;
                rdomakeitcentpercent.disabled = true;

                rdologosize.checked = false;
                chk_imgSize.checked = false;
                rdomakeitcentpercent.checked = false;
            }
            else if (rdtemplate.checked) {
                document.getElementById("<%=fu_header.ClientID%>").disabled = true;
                document.getElementById("<%=txt_text.ClientID%>").disabled = true;
                document.getElementById("<%=txt_template.ClientID%>").disabled = false;

                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = true;
                document.getElementById("<%=href_image.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=A3.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { return false; }

                txt_width.disabled = true;
                chk_imgSize.disabled = true;
                rdologosize.disabled = true;
                rdomakeitcentpercent.disabled = true;

                rdologosize.checked = false;
                chk_imgSize.checked = false;
                rdomakeitcentpercent.checked = false;
            }
}

function ChangeTextBox() {
    if (chk_imgSize.checked) {
        txt_width.disabled = false;
        rdologosize.checked = false;
        rdomakeitcentpercent.checked = false;
    }
    else if (rdologosize.checked) {
        txt_width.disabled = true;
        chk_imgSize.checked = false;
        rdomakeitcentpercent.checked = false;
    }
    else {
        txt_width.disabled = true;
        chk_imgSize.checked = false;
        rdologosize.checked = false;
    }
}


function hide_textbox() {

    var text = document.getElementById("<%=rdtext.ClientID %>");
            var html = document.getElementById("<%=rdtemplate.ClientID %>");
            var image = document.getElementById("<%=rdimage.ClientID%>");
            if (text.checked == true) {
                document.getElementById("<%=txt_template.ClientID%>").disabled = true;
                document.getElementById("<%=fu_header.ClientID%>").disabled = true;
                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = true;
                document.getElementById("<%=txt_text.ClientID%>").disabled = false;
                document.getElementById("<%=href_image.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=A3.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { return false; }
            }
            else if (html.checked == true) {
                document.getElementById("<%=txt_text.ClientID%>").disabled = true;
                document.getElementById("<%=txt_template.ClientID%>").disabled = false;
                document.getElementById("<%=fu_header.ClientID%>").disabled = true;
                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = true;
                document.getElementById("<%=href_image.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=A3.ClientID%>").style.textDecoration = "none";
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { return false; }
            }
            else if (image.checked == true) {
                document.getElementById("<%=txt_text.ClientID%>").disabled = true;
                document.getElementById("<%=txt_template.ClientID%>").disabled = true;
                document.getElementById("<%=fu_header.ClientID%>").disabled = false;
                document.getElementById("<%=chk_imgSize.ClientID%>").disabled = false;
                document.getElementById("<%=lbl_remove.ClientID%>").onclick = function () { ChangeImage(); return true; }
                document.getElementById("<%=lbl_image.ClientID%>").onclick = function () { return true; }

            }


}


function validate() {
    if (validate_Account()) {
        if (rdimage.checked) {
            if (hd_image.value == "") {
                if (fu_header.value == "") {
                    lblError.style.display = "block";
                    return false;
                }
            }
        }
    }
    else {
        return false;
    }
}

function customizeImgSize() {
    if (rdimage.checked) {
        if (fu_header.value != "") {
            if (chk_imgSize.checked) {
                div_HeightWidht.style.display = "block";
                txt_width.focus();
            }
            else {
                div_HeightWidht.style.display = "none";
            }
        }
        else {
            alert('<%=objLanguage.GetLanguageConversion("Please_Select_Any_Image")%>');
                    chk_imgSize.checked = false;
                }
            }
            else {
                alert('<%=objLanguage.GetLanguageConversion("Please_Select_Image_Section") %>');
                chk_imgSize.checked = false;
            }
        }

        function checkForNumbers(val, type) {
            if (!Number(val)) {
                if (type == 'w')
                    txt_width.value = "";
                else
                    txt_height.value = "";
            }
        }

        //        function Show_accountListDiv() {
        //            showDivPopupCenter('div_accountsList', '200');
        //          
        //        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

