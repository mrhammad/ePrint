<%@ page language="C#" validaterequest="false" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="company_logo.aspx.cs" Inherits="ePrint.settings.company_logo" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function chkUnCheck() {
            var chkId = document.getElementById("ctl00_ContentPlaceHolder1_chkdefault");
            chkId.checked = false;
        }
        function rdUnCheck() {
            var chkId = document.getElementById("ctl00_ContentPlaceHolder1_chkdefault");
            var txttext = document.getElementById("ctl00_ContentPlaceHolder1_txttext");
            var FileUpload1 = document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1");
            var txttemplate = document.getElementById("ctl00_ContentPlaceHolder1_txttemplate");

            var rdtext = document.getElementById("ctl00_ContentPlaceHolder1_rdtext");
            var rdimage = document.getElementById("ctl00_ContentPlaceHolder1_rdimage");
            var rdtemplate = document.getElementById("ctl00_ContentPlaceHolder1_rdtemplate");
            rdtext.checked = false;
            rdimage.checked = false;
            rdtemplate.checked = false;

            if (chkId.checked) {
                txttext.checked = true;
            }
            else {
                rdtext.checked = true;
            }
        }
    </script>
    <script>

        function hide_textbox() {

            var rdtext = document.getElementById("ctl00_ContentPlaceHolder1_rdtext");
            var rdimage = document.getElementById("ctl00_ContentPlaceHolder1_rdimage");
            var rdtemplate = document.getElementById("ctl00_ContentPlaceHolder1_rdtemplate");
            if (rdtext.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_txttemplate").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_txttext").disabled = false;
                document.getElementById("<%=lblfilename.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=LinkButton1.ClientID%>").onclick = function () { return false; }
                document.getElementById("ctl00_ContentPlaceHolder1_lblfilename").style.textDecoration = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_lblError").style.display = "none";
            }
            else if (rdimage.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_txttext").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_txttemplate").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").disabled = false;
                document.getElementById("<%=lblfilename.ClientID%>").onclick = function () { return true; }
                document.getElementById("<%=LinkButton1.ClientID%>").onclick = function () { return true; }
            }
            else if (rdtemplate.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_txttext").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_txttemplate").disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_lblfilename").style.textDecoration = "none";
                document.getElementById("<%=LinkButton1.ClientID%>").onclick = function () { return false; }
                document.getElementById("<%=lblfilename.ClientID%>").onclick = function () { return false; }
                document.getElementById("ctl00_ContentPlaceHolder1_lblError").style.display = "none";
            }

}

    </script>
      <script type="text/javascript" src="../js/jquery-1.3.2.js" language="javascript"></script>
    <script type="text/javascript" src="../js/helptext.js" language="javascript"></script>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" class="estore_settingBox"
        border="0">
        <%-- <tr>
            <td class="" style="display: none;">
                <table id="jkkjkj" cellspacing="0" cellpadding="0" width="100%" border="0" height="23">
                    <tr>
                        <td width="0%" class="bgcustomize" valign="top">
                            <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                        </td>
                        <td width="100%" class="bgcustomize">
                            <a runat="server" id="lblheader" href="#" class="subnavigator" style="float: left;">
                                Welcome Admin</a>
                        </td>
                        <td width="0%" class="bgcustomize" valign="top">
                            <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr valign="top">
            <td valign="top">
                <UC:Header_MIS ID="header_mis" runat="server" />
                <table width="100%" align="center" border="0" style="padding: 5px 0px 0px 10px;">
                    <tr>
                        <td align="left" colspan="2">
                            <div align="left" style="width: 100%">
                                <div style="width: 55%">
                                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                        <ContentTemplate>
                                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td class="normaltext bglabel" style="width: 150px;">
                            <asp:RadioButton ID="rdtext" Checked="true" GroupName="logo" Text="Text" CssClass="normaltext"
                                Style="margin-left: -4px;" runat="server" onchange ="javascript:clicked();"/>
                        </td>
                        <td>
                            <asp:TextBox ID="txttext" runat="server" CssClass="txtbox" Width="60%" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left">
                        <td class="normaltext bglabel" style="width: 150px;">
                            <asp:RadioButton ID="rdimage" Checked="true" Text="Image" GroupName="logo" CssClass="normaltext"
                                Style="margin-left: -4px;" runat="server"/>
                            <a id="img_Help_ShortDescritpion_Link_Image" runat="server" href="javascript:void(0);"
                                class="tooltip" title=" File exstensions allowed: .gif, .png, .jpg, .jpeg, .tiff, .tif, .bmp">
                                <img alt="" id="img_help_ShortDescription" runat="server" src="../images/Help-icon.png"
                                    style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                    class="tooltip" /></a>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" size="30" CssClass="txtbox" runat="server" />
                            
                            <div style="clear: both; display:none;">
                            </div>
                            <asp:Label ID="lblOld" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblfilename" runat="server" CssClass="Normaltext" Visible="false"></asp:Label>&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgDelete_Click" Visible="false">
                                <asp:ImageButton ImageUrl="~/images/close.gif" ToolTip="Delete" runat="server" ID="imgDelete"
                                    OnClick="imgDelete_Click" />
                            </asp:LinkButton>
                            <div style="clear: both">
                            </div>
                            <asp:Label ID="lbl_msg" runat="server" Text="(Uploaded image size will be resized to 300px/300px)"
                                Style="clear: both;" CssClass="smallerfontgrey"><%=objLanguage.GetLanguageConversion("Uploaded_Image_Size_Will_Be_Resized_To_300px_300px")%></asp:Label>
                        </td>
                    </tr>
                    <tr><td></td><td><asp:Label CssClass="spanerrorMsg" ID="lblError" style="display:none; width:auto; padding-left:5px; padding-right:5px;" runat="server" Text="Please upload only image file"><%=objLanguage.GetLanguageConversion("Please_Upload_Only_Image_File")%></asp:Label></td></tr>
                    <asp:Panel ID="pnlimage" runat="server" Visible="false">
                    </asp:Panel>
                    <tr valign="top">
                        <td class="normaltext bglabel" style="width: 150px;" nowrap="nowrap">
                            <asp:RadioButton ID="rdtemplate" GroupName="logo" Text="Custom HTML" CssClass="normaltext"
                                Style="margin-left: -4px;" runat="server" onchange="javascript:clicked();"/>
                        </td>
                        <td>
                            <asp:TextBox ID="txttemplate" runat="server" CssClass="txtbox" Width="550"
                                TextMode="MultiLine" Rows="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr valign="top" align="left" style="display: none;">
                        <td class="normaltext" width="10%">
                        </td>
                        <td class="normaltext">
                            <asp:CheckBox ID="chkdefault" CssClass="normalText" Text="Restore Default" runat="server" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td class="normaltext" width="10%">
                        </td>
                        <td>
                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
                            <div>
                                <span class="graytext">
                                    <%=objlang.GetLanguageConversion("Formula_Tags") %>: [$CurrentYear$], <span id="spn">
                                        [$PreviousYear$]</span></span>
                            </div>
                        </td>
                    </tr>
                    <tr align="left">
                        <td class="normaltext" width="10%">
                        </td>
                        <td>
                            <div id="div_btnsave" style="display: block">
                                <asp:Button ID="btnsave" CssClass="button" CausesValidation="false"
                                    Text="Save" OnClick="btnsave_Click" OnClientClick="var a= validateing();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a;" runat="server"/>
                            </div>
                            <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px;
                                display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </td>
                        <td width="80%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr valign="top" style="display: none">
            <td align="left">
                <table cellspacing="2" cellpadding="2" width="100%" border="0">
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
            </td>
        </tr>
    </table>
    <div id="divLowResolution" class="CenterDiv" align="left" style="width: 550px; display: none;
        position: absolute; left: 30%; top: 30%; background-color: FloralWhite;">
        <div align="center" class="bgcustomize" style="width: 100%; padding: 3px 0px 3px 0px;">
            <div style="float: left; width: 95%; border: 0px solid">
                <span class="navigatorpanel" style="vertical-align: middle">Image Upload</span></div>
            <div style="float: right; border: 0px solid">
                <a href="#" onclick="javascript:CloseRes('close');return false;">
                    <img src="<%=strImagepath%>close1.jpg" border="0" width="11px" height="11px" title="Close" /></a></div>
            <div style="clear: both">
            </div>
        </div>
        <div class="borderWithoutTop">
            <div id="padding">
                <div align="left" style="width: 100%;">
                    <div align="left">
                        <span class="normlaText">The logo you uploaded is of low resolution and might not appear
                            clearly in the templates</span>
                        <br />
                        <br />
                        Do you want to upload a high resolution logo (300dpi is preferrable)?
                    </div>
                </div>
                <div class="only10px">
                </div>
                <div align="left">
                    <div class="bglabelEmpty">
                        &nbsp;</div>
                    <div style="float: left">
                        <asp:Button ID="btnReupload" runat="server" Text="ReUpload" CssClass="button" Width="65px"
                            OnClientClick="javascript:CloseRes('reup');return false;" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;</div>
                    <div style="float: left">
                        <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="button" Width="65px"
                            OnClick="btnContinue_OnClick" />
                    </div>
                </div>
                <div class="only5px">
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_UpType" runat="server" Value="1" />
    <asp:HiddenField ID="hid_FileName" runat="server" Value="" />
    <script>
        var hid_UpType = document.getElementById("<%=hid_UpType.ClientID %>");
        function CheckResolution(res) {

            document.getElementById("divLowResolution").style.display = "block";

        }
        function CloseRes(type) {
            document.getElementById("divLowResolution").style.display = "none";
            var logotype = '<%=type %>';
            if (type == "close") {
                hid_UpType.value = 0;
            }
            else if (type == "reup") {
                hid_UpType.value = 1;

            }
            else if (type == "cont") {
                hid_UpType.value = 0;

            }
        }

    </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <script lang="javascript" type="text/javascript">
         function validateing() {
             var FileUpload1 = document.getElementById("<%= FileUpload1.ClientID %>");
             var rdimage = document.getElementById("<%= rdimage.ClientID %>");
             var file = FileUpload1.value;
             var lblError = document.getElementById("<%= lblError.ClientID %>");
            if (file == '' && rdimage.checked == true) { lblError.style.display = "block"; return false; }
            else { lblError.style.display = "none"; return true; }
        }

        function clicked() {
            var lblError = document.getElementById("<%= lblError.ClientID %>");
             var rdtext = document.getElementById("ctl00_ContentPlaceHolder1_rdtext");
             var rdtemplate = document.getElementById("ctl00_ContentPlaceHolder1_rdtemplate");
             if (rdtemplate.checked == true || rdtext.checked == true) { lblError.style.display = "none"; }
             else { lblError.style.display = "block"; }
         }
    </script>
</asp:Content>

