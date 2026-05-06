<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="inventory_import.aspx.cs" Inherits="ePrint.settings.inventory_import" title="Settings: Inventory Import" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/inventory.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <style type="text/css">
        .bgcustomize th
        {
            color: Black;
            border-width: 0px 0px 1px;
            border-style: none none solid;
            border-color: -moz-use-text-color -moz-use-text-color rgb(130, 130, 130);
            background: linear-gradient(to bottom, rgb(253, 253, 253) 0%, rgb(248, 248, 248) 22%, rgb(241, 241, 241) 49%, rgb(236, 236, 236) 76%, rgb(234, 234, 234) 100%) repeat scroll 0% 0% transparent;
        }
    </style>
    <div align="left" id="pnldetails" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div align="left" class="mis_header_panel">
            <%--<div style="width: 100%;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Settings") %>:&nbsp;<%=objLanguage.GetLanguageConversion("Inventory_Import")%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>--%>
            <div>
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <div align="left">
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="">
                    <div align="left" style="width: 100%;">
                        <div>
                            <div id="divmsg" runat="server" class="invimport_divmessage">
                                <%=objLanguage.GetLanguageConversion("Showing_top_20_records_of_your_uploaded_file")%>
                            </div>
                            <div id="divSubmitBtn" visible="false" runat="server" align="left" class="invimport_divsumbit">
                                <div style="float: left;">
                                    &nbsp;</div>
                                <div>
                                    <asp:Button ID="btnCancel" CausesValidation="false" runat="server" CssClass="button"
                                        Text="Cancel" OnClick="btnCancel_OnClick" />
                                    <asp:Button ID="btnSubmitDetails" CausesValidation="false" runat="server" CssClass="button"
                                        Text="Submit" OnClick="btnSubmit_Click" Style="margin-left: 5px;" />
                                </div>
                            </div>
                            <asp:GridView ID="GridImport" Visible="false" runat="server" AutoGenerateColumns="true"
                                SkinID="GridStyle" GridLines="none" OnRowCreated="GridImport_OnRowCreated" Width="100%">
                                <RowStyle CssClass="NewTableRows" />
                                <AlternatingRowStyle CssClass="NewAlternative" />
                                <FooterStyle CssClass="gv-footer" />
                                <%--<HeaderStyle CssClass="bgcustomize navigatorpanel" />--%>
                                <PagerStyle CssClass="gv-pager" />
                                <EditRowStyle CssClass="gridEditColor" />
                                <%--<HeaderStyle CssClass="bgcustomize navigatorpanel" Height="22px" />--%>
                                <EmptyDataTemplate>
                                    <div id="Div1" class="emptyrecords" align="center">
                                        <span class="HeaderText" style="text-align: center">
                                            <%=objLanguage.GetLanguageConversion("No_Record_Found")%></span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="divSubmit" visible="false" runat="server" align="left" class="invimport_divSubmit">
                            <div>
                                <asp:Button ID="btn_Cancel" CausesValidation="false" runat="server" CssClass="button"
                                    Text="Cancel" OnClick="btnCancel_OnClick" />
                                <asp:Button ID="btnSubmit" CausesValidation="false" runat="server" CssClass="button"
                                    Text="Submit" OnClick="btnSubmit_Click" Style="margin-left: 5px;" />
                            </div>
                        </div>
                        <div style="float: left; width: 49%;">
                            <div align="left">
                                <div class="bglabel">
                                    <%=objLanguage.GetLanguageConversion("Select_Inventory_Category")%>
                                </div>
                                <div class="ddlsetting">
                                    <div align="left">
                                        <asp:DropDownList CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="ddlInvCategory_SelectedIndexChanged"
                                            ID="ddlInvCategory" runat="server" CssClass="normalText" Width="183px">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="rfv" class="RFV_Message" runat="server" visible="false" style="width: 174px;
                                        float: left">
                                        <span style="float: left; padding-left: 4px">
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Inv_Category")%></span>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="height: 60px">
                                    <%=objLanguage.GetLanguageConversion("Import_Action")%>
                                </div>
                                <div class="box">
                                    <asp:RadioButton ID="rdoInsert" Text="Append existing record, insert <br /> &nbsp; &nbsp; &nbsp; new"
                                        runat="server" onclick="javascript:rdoImportType_checked('i');" Checked="true" />
                                </div>
                                <div class="box">
                                    <div class="div_floatleft">
                                        <asp:RadioButton ID="rdoDelete" TextAlign="Right" onclick="javascript:rdoImportType_checked('d');"
                                            runat="server" />
                                    </div>
                                    <div class="invimport_rdodelete">
                                        <%=objLanguage.GetLanguageConversion("Delete_Existing_Record_And_Insert_All_Records_As_New")%></div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel">
                                    <%=objLanguage.GetLanguageConversion("Select_Excel_File")%><span style="padding-left:3px;color:Red">*</span>
                                </div>
                                <div class="box invimport_fileupload" style="padding-bottom:10px;">
                                    <asp:FileUpload ID="fileExcel" runat="server" CssClass="textboxnew" />
                                    <div style="clear: both">
                                    </div>
                                    <asp:RequiredFieldValidator ValidationGroup="vg1" CssClass="RFV_Message" ID="rfv1" ControlToValidate="fileExcel" runat="server" 
                                        ErrorMessage="Pleases select file name for import" style="width:auto; padding:2px 5px 2px 5px; color:black;"><%=objLanguage.GetLanguageConversion("Please_Select_File_Name_For_Import")%></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="fileExcel"
                                            ErrorMessage="Invalid file format"  CssClass="RFV_Message" style="width:auto; padding:2px 5px 2px 5px; color:black; margin-top:-6%;"
                                            ValidationExpression="^.+\.((xls)|(XLS)|(xlt)|(XLT)|(xlm)|(XLM)|(xlsx)|(XLSX)|(xlsm)|(XLSM)|(xltx)|(XLTX)|(xltm)|(XLTM))$"
                                            ValidationGroup="vg1" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                </div>
                                <div style="padding-left: 5px; float: left; margin: 2px 0px 10px 0px;">
                                    <asp:LinkButton ID="lnkDownLoadDefault" runat="server" Text="DOWNLOAD SAMPLE FILE"
                                        OnClick="lnkDownLoadDefault_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div style="float: right; width: 69%; padding: 1px 1px 1px 3px;">
                                <div align="left" style="width: 100%;">
                                    <div style="float: left;">
                                        <div id="div_Button9" style="display: block">
                                            <asp:Button ID="Button9" CausesValidation="false" runat="server" CssClass="button"
                                                Text="Cancel" Width="65px" OnClick="btnCancel_OnClick" />
                                        </div>
                                        <div id="div_Button9process" class="button" align="center" style="height: 14px; width: 47px;
                                            display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div id="div_upload" style="float: left;">
                                        <asp:Button ID="btnImport" runat="server" CssClass="button"
                                            Text="Import" Width="65px" OnClick="btnImport_Click" OnClientClick="VerifyAndSave('vg1');" />
                                    </div>
                                    <div id="div_UploadProcess" class="button" style="height: 14px; width: 47px;float:left;
                                            display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                     </div>
                                </div>
                            </div>
                            <div style="display: none">
                                <div style="clear: both;">
                                    &nbsp;</div>
                                <div align="left">
                                    <div style="float: left; width: 25px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 38%;">
                                        2.<%=objLanguage.GetLanguageConversion("Select_The_Stock_Category_And_SubCategory")%>
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:DropDownList ID="ddlstock" runat="server" CssClass="MaskDDL">
                                            <asp:ListItem Value="0">Films</asp:ListItem>
                                            <asp:ListItem Value="1">Inks</asp:ListItem>
                                            <asp:ListItem Value="2">Paper</asp:ListItem>
                                            <asp:ListItem Value="3">Plates</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="MaskDDL">
                                            <asp:ListItem Value="0">Films</asp:ListItem>
                                            <asp:ListItem Value="1">Inks</asp:ListItem>
                                            <asp:ListItem Value="2">Paper</asp:ListItem>
                                            <asp:ListItem Value="3">Plates</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                                <div align="left">
                                    <div style="float: left; width: 25px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 38%;">
                                        3.<%=objLanguage.GetLanguageConversion("Open_The_Suppliers_Inventory_Xls_File_Given_By_The_Supplier") %>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;:
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:Button ID="bth" runat="server" CssClass="button" Text="Browse" Width="65px" />
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                                <div align="left">
                                    <div style="float: left; width: 25px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 38%;">
                                        4.<%=objLanguage.GetLanguageConversion("Filter_The_List_Below_Based_On_Your_Keyword_Match")%>
                                        <br />
                                        &nbsp;&nbsp;&nbsp; criteria:
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:TextBox ID="txt" runat="server" CssClass="txtBox"></asp:TextBox>
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Filter" Width="65px" />
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                                <div align="left">
                                    <div style="float: left; width: 25px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 38%;">
                                        5.<%=objLanguage.GetLanguageConversion("Select_The_Data_Below_You_Wish_To_Import_From")%><br />
                                        &nbsp;&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("He_Xls_File_And_Import")%>
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 20%;">
                                        <asp:Button ID="Button2" runat="server" CssClass="button" Text="Import" Width="65px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="float: left; width: 50%">
                            <div style="width: 100%" class="bglabel">
                                <span style="font-weight: bold">
                                    <%=objLanguage.GetLanguageConversion("Inventory_Import_Process_Steps")%></span>
                                <div class="divEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("Select_The_Inventory_Category")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("Download_The_Sample_File_Input_Your_Data_As_Per_Columns_Laid_In_The_File")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <%--<span style="color: red">3.
                                    <%=objLanguage.GetLanguageConversion("Useing_External_ExcelFile_Note_Inventory_Import")%>.
                                </span>
                                <div class="onlyEmpty">
                                </div>
                                <div class="onlyEmpty">
                                </div>--%>
                                <span>3.
                                    <%=objLanguage.GetLanguageConversion("Select_That_File_And_Click_On_The_Import_Button") %></span>
                                <div class="onlyEmpty">
                                </div>
                                <%-- <span>5.
                                    <%=objLanguage.GetLanguageConversion("Check_The_Inputs_You_Have_Given_And_Then_Click_On_The_Submit_Button")%></span>
                                <div class="onlyEmpty">
                                </div>--%>
                                <span>4.
                                    <%=objLanguage.GetLanguageConversion("You_will_see_an_on_screen_display_of_your_import_which_you_can_check")%></span>
                                <div class="onlyEmpty">
                                </div>

                                 <span>5.
                                    <%=objLanguage.GetLanguageConversion("Use_the_Submit_button_to_finalise_the_import_process")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <div class="invhelptxt">
                                </div>
                                <span><b>
                                    <%=objLanguage.GetLanguageConversion("Useful_Tips_of_what_to_add_in_some_of_the_columns")%></b></span>
                                <div class="divEmpty">
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("For_Paper_Type_Roll_enter_as_Roll_for_Sheet_enter_as_Sheet")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("For_Inventory_Category_Paper_with_Paper_Type_Roll_then_enter_the_Length_meters_else_leave_blank")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("Columns_Inventory_Name_Paper_Type_Cost_Width_Height_Length_Basis_Weight_are_mandatory_fields")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("For_column_Large_Format_Material_Possible_values_are_Yes_or_No")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <div class="invhelptxt">
                                </div>
                                <span><b>
                                    <%=objLanguage.GetLanguageConversion("When_Inventory_will_be_updated")%></b></span>
                                <div class="divEmpty">
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <span>
                                    <%=objLanguage.GetLanguageConversion("If_your_import_action_is_Append_existing_record_insert_new_and_Item_Code_is_already_present_in_the_system_it_will_update_to_same_inventory")%></span>
                                <div class="onlyEmpty">
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                        </div>
                        <div class="only10px">
                        </div>
                        <div style="clear: both;">
                            &nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnActualFileName" runat="server" />
        <asp:HiddenField ID="hdnGUID" runat="server" />
        <asp:HiddenField ID="hdnFileName" runat="server" />
    </div>
    <script type="text/javascript">
        function rdoImportType_checked(val) {
            if (val == 'i') {
                if ((document.getElementById("<%=rdoInsert.ClientID %>")).checked) {
                    document.getElementById("<%=rdoDelete.ClientID %>").checked = false;
                }
            }

            if (val == 'd') {
                if ((document.getElementById("<%=rdoDelete.ClientID %>")).checked) {
                    document.getElementById("<%=rdoInsert.ClientID %>").checked = false;
                }
            }
        }
        
       
        function VerifyAndSave(groupName) {
            if (typeof (Page_ClientValidate) == 'function') {
                Page_ClientValidate(groupName);
            }
            if (Page_IsValid) {
                
                document.getElementById('div_upload').style.display = "none";
                document.getElementById('div_UploadProcess').style.display = "block";
            }
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
