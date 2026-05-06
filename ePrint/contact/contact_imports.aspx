<%@ Page Title="CRM Imports" Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.Master" AutoEventWireup="true" CodeBehind="contact_imports.aspx.cs" Inherits="ePrint.contact.contact_imports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_DropDownList1 {
            margin-top:5px;
            margin-left:3px;
            padding:5px;
        }
    </style>
    <div id="padding" class="div_job_vwmargin">
        <div align="left" style="width: 100%;">
            <div style="float: left; width: 49%;">
                <div align="left">
                    <div align="left">
                        <div class="bglabel" style="height: 19px">
                            <%=objlang.GetLanguageConversion("Upload_File_To_Import")%>
                            <span style="color: Red; padding-left: 4px">*</span>
                        </div>
                        <div class="box" style="width: 69%;">
                            <asp:FileUpload ID="fileCsv" runat="server" accept=".csv" CssClass="textboxnew" />

                            <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                            <asp:LinkButton ID="lnkFileConverter" runat="server" OnClientClick="openFileConverter();return false;"
                                Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                        </div>
                        <div>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="vg1" CssClass="RFV_Message"
                                ControlToValidate="fileCsv" ErrorMessage="Please select file name for import"
                                SetFocusOnError="true" Display="Dynamic" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;"
                                ForeColor=""></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="valRegEx" ValidationGroup="vg1" runat="server"
                                ControlToValidate="fileCsv" CssClass="RFV_Message" ValidationExpression="^.*\.xls[xm]?$"
                                ErrorMessage="*Only Excel files are allowed!." Display="Dynamic" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;"
                                ForeColor=""></asp:RegularExpressionValidator>--%>
                        </div>
                        <div style="clear: both; padding-top: 2px">
                        </div>
                         <div id="waitmessage" style="z-index: -1; left: 0px;margin-left:80%;visibility:hidden; width: 300px">
                            &nbsp;&nbsp;<table class="loading" cellpadding="0" cellspacing="10">
                                <tr>
                                    <td align="right" bordercolor="#ffffff">
                                        <div style="float: left">
                                            <asp:Image ID="imgHourglass" runat="server" ImageUrl="~/images/load.gif" />
                                        </div>
                                        <div style="float: left; white-space: nowrap; padding-left: 5px; padding-top: 10px">
                                            <%=objlang.GetValueOnLang("Loading please wait")%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                       
                        <div align="left" style="margin-left:30%" runat="server">
                            <asp:Button ID="btnSubmit" OnClick="Btn_Import" OnClientClick="chkret();" CausesValidation="false" runat="server" CssClass="button"
                                Text="Import Data" Width="90px" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        function chkret() {


            if (document.getElementById("<%=rfv1.ClientID%>").style.display != '') {
                var IW = window.innerWidth ? window.innerWidth : document.body.clientWidth;
                var IH = self.outerheight;
                self.scrollTo(0, 0);
                if (document.all) {

                    document.all.waitmessage.style.left = (IW - 300) / 2;
                    document.all.waitmessage.style.visibility = 'visible';
                    document.all.waitmessage.style.zIndex = 99;
                }
                else if (document.getElementById) {


                    document.getElementById('waitmessage').style.visibility = 'visible';
                    document.getElementById('waitmessage').style.zIndex = 99;

                    var width = document.getElementById('waitmessage').style.width;
                    var height = document.getElementById('waitmessage').style.height;



                    width = width.replace('px', '');
                    height = height.replace('px', '');


                    document.getElementById('waitmessage').style.left = ((document.body.clientWidth - width) / 2) + "px";

                    var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;

                    document.getElementById('waitmessage').style.top = (top + (document.body.clientHeight - height) / 2) + "px";
                    var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
                    var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
                    var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth


                }
                else {
                    document.waitmessage.left = (IW - 300) / 2;
                    document.waitmessage.visibility = 'show';
                    document.waitmessage.zIndex = 99;
                }

                if (ret) {
                    hdnisdelete.value = "1";

                    return true;

                }
                else {
                    hdnisdelete.value = "0";

                    return false;
                }
            }
        }

        function VerifyAndSave(groupName) {
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate(groupName);
            }
            if (Page_IsValid) {

                document.getElementById('div_import').style.display = "none";
                document.getElementById('div_btnImportProcess').style.display = "block";
            }
        }
    </script>
</asp:Content>

