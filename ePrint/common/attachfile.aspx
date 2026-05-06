<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="attachfile.aspx.cs" Inherits="ePrint.common.attachfile"  MasterPageFile="~/Templates/popUpMasterPage_new.Master" %>

<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="Estyle" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:Estyle ID="Estyle1" runat="server" />
    <input type="hidden" id="hdnError" />
    <table cellpadding="0" cellspacing="7" border="0" width="97%" align="center">
        <%--class="borderWithoutTop"--%>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="normaltext"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellspacing="0" cellpadding="2" align="center" width="98%" border="0">
                                <tr>
                                    <td colspan="3" height="5px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <b>
                                            <%=objLangClass.GetLanguageConversion("Attach_File_From_Local_Disk")%>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" height="10px"></td>
                                </tr>
                                <tr>
                                    <td class="Normaltext" style="width: 10%" nowrap="nowrap">
                                        <b style="margin-left: -4px;">&nbsp;
                                            <%=objLangClass.GetLanguageConversion("File1")%></b>
                                    </td>
                                    <td class="Normaltext">
                                        <input id="hdnRefreshData" runat="server" type="hidden" value="" />
                                        <asp:FileUpload CssClass="normaltext" Width="195px" ID="FileUpload1" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                            ValidationGroup="checkfiletype" ErrorMessage="Invalid file format" ControlToValidate="FileUpload1"> </asp:CustomValidator>
                                    </td>
                                    <td width="40%">
                                        <asp:CheckBox ID="chkFile1" Text="Save as master document" CssClass="normaltext"
                                            runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Normaltext" nowrap="nowrap">
                                        <b>&nbsp;<%=objLangClass.GetLanguageConversion("File2")%></b>
                                    </td>
                                    <td class="Normaltext">
                                        <asp:FileUpload CssClass="normaltext" Width="195px" ID="FileUpload2" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ValidateFileUpload2"
                                            ValidationGroup="checkfiletype" ErrorMessage="Invalid file format" ControlToValidate="FileUpload2"> </asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkFile2" Text="Save as master document" CssClass="normaltext"
                                            runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Normaltext" nowrap="nowrap">
                                        <b>&nbsp;<%=objLangClass.GetLanguageConversion("File3")%></b>
                                    </td>
                                    <td class="Normaltext">
                                        <asp:FileUpload CssClass="normaltext" Width="195px" ID="FileUpload3" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidateFileUpload3"
                                            ValidationGroup="checkfiletype" ErrorMessage="Invalid file format" ControlToValidate="FileUpload3"> </asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkFile3" Text="Save as master document" CssClass="normaltext"
                                            runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Redver7" colspan="2">
                                        <%=objLangClass.GetLanguageConversion("Import_Note_Campaign")%>.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span id="errormsg" class="spanerrorMsg" style="width: auto; display: none; padding-right: 5px;">Please select at least one file</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE2">
                                <tr>
                                    <td align="center">
                                        <table cellspacing="2" cellpadding="2" width="99%" align="center" border="0" style="display: none">
                                            <tr>
                                                <td>
                                                    <b>
                                                        <%=objLanguage.convert("Attach file from Master document")%>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5px"></td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                    <asp:GridView AllowSorting="true" ID="GridViewdocument" Width="300px" CssClass="GridviewBorder"
                                                        AutoGenerateColumns="false" runat="server" DataKeyNames="documentID" OnRowDataBound="GridViewdocument_RowDataBound"
                                                        SkinID="GridStyle" GridLines="None" CellPadding="1" CellSpacing="1">
                                                        <HeaderStyle></HeaderStyle>
                                                        <%--CssClass="bgImageDGHeader"--%>
                                                        <AlternatingRowStyle Height="20px" CssClass="NewAlternative" />
                                                        <RowStyle Height="20px" BorderWidth="0px" CssClass="NewTableRows" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderStyle Width="1%" HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="1px"></ItemStyle>
                                                                <HeaderTemplate>
                                                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <input type="checkbox" runat="server" id="DocumentId" onclick="CheckChanged();" name="LeadId"
                                                                        value='<%#Eval("filename")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="File Description" SortExpression="title">
                                                                <HeaderStyle CssClass="leftAlign" Width="200px" HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle CssClass="leftAlign" HorizontalAlign="Left" Width="200px"></ItemStyle>
                                                                <ItemTemplate>
                                                                    &nbsp;<a onclick="return downloadDocument('<%#Eval("filename")%>')" href="javascript://"><%#Eval("Title")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle CssClass="headertext" HorizontalAlign="Left" Width="20%"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle CssClass="Error" Height="25px" HorizontalAlign="Center" Width="100%" />
                                                        <EmptyDataTemplate>
                                                            <%=objLanguage.convert("No documents found.")%>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td>
                                        <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="1" cellpadding="0" align="center" width="98%" border="0">
                    <tr>
                        <td align="left">
                            <input id="Button2" runat="server" style="width: 50px; display: none;" onclick="javascript: window.close();"
                                type="button" value="Cancel" class="button" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAttch" CausesValidation="false" CssClass="Button" Text="attch" OnClick="Button1_ServerClick1"
                                OnClientClick="return fileuploadvalidate();" runat="server" />
                        </td>
                        <td width="100%"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Panel runat="server" Visible="false" ID="plhscript">
        <script language="javascript" type="text/javascript">
            var myHdnRefreshData = document.getElementById(<%= "'" + hdnRefreshData.ClientID + "'" %>).value;
            var OriginalFileName = '<%=OriginalFileName %>';
            var txtattachment;

            if ('<%=sectionname %>' == "estimate") {
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCtemplate1_EmailTemplate_hid_FileNames'].value='" + OriginalFileName + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCtemplate1_EmailTemplate_txtattachment'].value='" + myHdnRefreshData + "'");
            }
            else if ('<%=sectionname %>' == "client") {
                txtattachment = window.parent.frames.document.getElementById("txtattachment");
                if (txtattachment.value == "") {
                    txtattachment.value = txtattachment.value + myHdnRefreshData;
                }
                else {
                    txtattachment.value = txtattachment.value + ", " + myHdnRefreshData;
                }
            }
            else {
                if (eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_txtattachment'].value") != '') {
                    eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_txtattachment'].value+=','+'" + myHdnRefreshData + "'");
                }
                else {
                    eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_txtattachment'].value='" + myHdnRefreshData + "'");
                }
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
                return oWindow;
            }


            function CloseOnReload() {
                GetRadWindow().Close();
            }
            CloseOnReload();

        </script>
    </asp:Panel>
    <script language="javascript" type="text/javascript">
        function Window_Close() {
            selects = parent.window.document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].disabled = false;
            }
            parent.window.document.getElementById("divAttachMent").style.visibility = 'hidden';
            parent.window.document.getElementById('dimmer').style.visibility = 'hidden';
            return false;

        }

        function downloadDocument(val) {

            var url = 'DownLoadDocument.aspx?Filename=' + val;
            alert(url);
            window.radopen(url, 'Lead', 'width=730,height=610,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;
        }
    </script>
    <script type="text/javascript">
        function ValidateFileUpload1(Source, args) {
            var upload1 = document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1");
            var FileUploadPath = upload1.value;
            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "exe" || Extension == "asp" || Extension == "php" || Extension == "dll" || Extension == "aspx" || Extension == "jar") {
                    args.IsValid = false; // Not valid file type
                }
                else {
                    args.IsValid = true; // Valid file type
                }
            }
        }
        function ValidateFileUpload2(Source, args) {
            var upload2 = document.getElementById("ctl00_ContentPlaceHolder1_FileUpload2");
            var FileUploadPath = upload2.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                if (Extension == "exe" || Extension == "asp" || Extension == "php" || Extension == "dll" || Extension == "aspx" || Extension == "jar") {
                    args.IsValid = false; // Not valid file type
                }
                else {
                    args.IsValid = true; // Valid file type
                }
            }
        }

        function ValidateFileUpload3(Source, args) {
            var upload3 = document.getElementById("ctl00_ContentPlaceHolder1_FileUpload3");
            var FileUploadPath = upload3.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                if (Extension == "exe" || Extension == "asp" || Extension == "php" || Extension == "dll" || Extension == "aspx" || Extension == "jar") {
                    args.IsValid = false; // Not valid file type
                }
                else {
                    args.IsValid = true; // Valid file type
                }
            }
        }


    </script>
    <script lang="javascript" type="text/javascript">
        function fileuploadvalidate() {
            var FileUpload1 = document.getElementById("<%= FileUpload1.ClientID %>");
            var FileUpload2 = document.getElementById("<%= FileUpload2.ClientID %>");
            var FileUpload3 = document.getElementById("<%= FileUpload3.ClientID %>");
            var errormsg = document.getElementById("errormsg");
            var file1 = FileUpload1.value;
            var file2 = FileUpload2.value;
            var file3 = FileUpload3.value;
            if (file1 == '' && file2 == '' && file3 == '') {
                errormsg.style.display = "block";
                return false;
            }
            else { return true; }

        }
    </script>
</asp:Content>

