<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="Pricecatalog_import.aspx.cs" Inherits="ePrint.ProductCatalogue.Pricecatalog_import" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/inventory.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <script type="text/javascript">
        function Clear() {

            return true;
        }
    </script>
    <div id="waitmessage" style="z-index: -1; left: 0px; visibility: hidden; width: 300px; position: absolute; top: 200px; height: 100px">
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
    <div align="left" id="pnldetails">
        <div align="left">
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objlang.GetLanguageConversion("Products") %>
                                        :&nbsp;<%=objlang.GetLanguageConversion("Product_Catalogue_Import")%></span>
                                    <asp:HiddenField ID="hdnisdelete" Value="0" runat="server" />
                                    <asp:HiddenField ID="hdnisdeleteqty" Value="0" runat="server" />
                                    <input type="hidden" id="hdnInnerHtml" value="" runat="server" />
                                    <input type="hidden" id="hdnInnerHtmlForPriceMatrix" value="" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="float: left;">
                <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                    <tr valign="top">
                        <td>
                            <div id="div2" runat="server" style="display: none">
                                <table cellspacing="1" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <asp:PlaceHolder ID="plhCreateExcelSheet" Visible="true" runat="server"></asp:PlaceHolder>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <%-- <div class="borderWithoutTop">--%>
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <div align="left">
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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
                                    <asp:FileUpload ID="fileCsv" runat="server" CssClass="textboxnew" />

                                    <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                                    <asp:LinkButton ID="lnkFileConverter" runat="server" OnClientClick="openFileConverter();return false;"
                                        Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="vg1" CssClass="RFV_Message"
                                        ControlToValidate="fileCsv" ErrorMessage="Please select file name for import"
                                        SetFocusOnError="true" Display="Dynamic" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;"
                                        ForeColor=""></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="valRegEx" ValidationGroup="vg1" runat="server"
                                        ControlToValidate="fileCsv" CssClass="RFV_Message" ValidationExpression="^.*\.xls[xm]?$"
                                        ErrorMessage="*Only Excel files are allowed!." Display="Dynamic" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;"
                                        ForeColor=""></asp:RegularExpressionValidator>
                                </div>
                                <div align="left" id="div_importaption" runat="server" visible="false">
                                    <div class="bglabel" style="height: 60px">
                                        <%=objlang.GetLanguageConversion("Import_Action") %>
                                    </div>
                                    <div class="box">
                                        <asp:RadioButton ID="rdoInsert" Text="Append existing record, insert new" runat="server"
                                            Checked="true" GroupName="rdnAppend" />
                                    </div>
                                    <div class="box">
                                        <asp:RadioButton ID="rdoDelete" Text="Delete existing record and insert all records as new"
                                            runat="server" GroupName="rdnAppend" />
                                    </div>
                                </div>
                                <div style="clear: both; padding-top: 2px">
                                </div>
                                <div align="left" id="divDuplicaterecords" runat="server">
                                    <div class="bglabel">
                                        <%=objlang.GetLanguageConversion("Duplicate_Records")%>
                                    </div>
                                    <div class="box">
                                        <asp:DropDownList ID="ddlDuplicateRecords" runat="server" CssClass="normaltext" Width="182px">
                                            <asp:ListItem Text="---Select---" Value="---Select---"></asp:ListItem>
                                            <asp:ListItem Text="Ignore" Value="ignore"></asp:ListItem>
                                            <asp:ListItem Text="Update" Value="update"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:CompareValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vg1" CssClass="RFV_Message"
                                        ControlToValidate="ddlDuplicateRecords" ValueToCompare="---Select---"
                                            Operator="NotEqual" ErrorMessage="you needs to select either the Ignore or Update option"
                                        SetFocusOnError="true" Display="Dynamic" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;"
                                        ForeColor=""></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="bglabel" style="height: 19px">
                                    Upload Products Thumbnail
                                    
                                </div>
                                <div class="box" style="width: 69%;">
                                    <asp:FileUpload ID="FileUploadZip" runat="server" CssClass="textboxnew" />

                                    <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="openFileConverter();return false;"
                                        Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                                </div>
                                <div class="box" style="display: none;">
                                    <asp:CheckBox ID="chkdelete" runat="server" Text="Delete Existing Product Catalogue"
                                        Font-Bold="true" />
                                </div>
                                <div style="clear: both;" class="only10px">
                                </div>
                                <div>
                                </div>
                                <div style="width: 100%">
                                    <table>
                                        <tr>
                                            <td>
                                                <span style="font-weight: bold">
                                                    <%--<%=objlang.GetLanguageConversion("Download_File")%>--%>
                                                    <%=objlang.GetLanguageConversion("Download_existing_Products")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="left" style="padding-left: 5px; display: none;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnkexistdefault" CssClass="lineBlu" runat="server" Text="Download Product Catalogue"
                                                        OnClick="lnkexistdefault_Click" Font-Size="8" CausesValidation="false"></asp:LinkButton>
                                                </div>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <div align="left" style="padding-left: 5px; display: none;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnkDownLoadDefault" CssClass="lineBlu" runat="server" Text="Download Sample File1"
                                                        OnClick="lnkDownLoadDefault_Click" OnClientClick="javascript:getInnerHtml();"
                                                        Font-Size="8" CausesValidation="false"></asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px;">
                                                <div align="left" style="padding-left: 5px;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnkexistdefaultwithpricesellingprice" CssClass="lineBlu" runat="server"
                                                        Text="Download Product Catalogue" OnClick="lnkexistdefaultwithpricesellingprice_Click"
                                                        Font-Size="8" CausesValidation="false">  </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px;">
                                                <div align="left" style="padding-left: 5px;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnkexistdefaultWithPriceMatrix" CssClass="lineBlu" runat="server"
                                                        Text="Download Product Catalogue" OnClick="lnkexistdefaultWithPriceMatrix_Click"
                                                        Font-Size="8" CausesValidation="false">  </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px;">
                                                <div align="left" style="padding-left: 5px;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnkDownLoadDefaultWithPriceMatrix" CssClass="lineBlu" runat="server"
                                                        Text="Download Sample File" OnClick="lnkDownLoadDefaultWithPriceMatrix_Click"
                                                        OnClientClick="javascript:getInnerHtmlForPriceMatrix();" Font-Size="8" CausesValidation="false">  </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px;">
                                                <div align="left" style="padding-left: 5px;">
                                                    <img src="../images/download5.jpg" style="vertical-align: middle" />
                                                    <asp:LinkButton ID="lnlDownLoadDefaultPriceMatrixWithSellingPrice" CssClass="lineBlu"
                                                        OnClick="lnlDownLoadDefaultPriceMatrixWithSellingPrice_OnClick" runat="server"
                                                        Text="Download Sample File With Cost and Selling Price" OnClientClick="javascript:getInnerHtmlForPriceMatrix();"
                                                        Font-Size="8" CausesValidation="false">  </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="height: 10px">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div style="float: left; width: 30%">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                            <div id="div_cancel" style="display: block">
                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="Button9" OnClientClicked="displayLoading"
                                    runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                </telerik:RadButton>
                            </div>
                            <div id="div_btnCancelProcess" class="button" align="center" style="width: 58px; display: none; height: 12.5px">
                                <img src="<%=strImagepath %>radimg1.gif" style="margin-top: -3px" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                            <div id="div_import" style="display: block">
                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnImport"
                                    runat="server" Text="Import" ValidationGroup="vg1"  OnClick="btnImport_Click">
                                </telerik:RadButton>
                            </div>
                            <div id="div_btnImportProcess" class="button" align="center" style="width: 58px; display: none; height: 12.5px;">
                                <img src="<%=strImagepath %>radimg1.gif" style="margin-top: -3px" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 47%;">
                        <div id="padding" style="width: 100%; border-top: 1px solid #CCCCCC; border-left: 1px solid #CCCCCC; border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC"
                            class="bglabel">
                            <span style="font-weight: bold">
                                <%--<%=objlang.GetLanguageConversion("Product_Catalogue_Import_Process_Steps")%>--%>
                                <%=objlang.GetLanguageConversion("Product_Catalogue_Import_Process")%>
                            </span>
                            <div style="clear: both; height: 5px">
                            </div>
                            <ol>
                                <li>
                                    <%=objlang.GetLanguageConversion("Review_the_article")%> <a href="https://hexicomsupport.freshdesk.com/support/solutions/articles/24000044101">Product Catalogue Import Process</a><br />
                                    <br />
                                    <%=objlang.GetLanguageConversion("The_article_contains_a_file")%><br />
                                    <br />
                                    <%=objlang.GetLanguageConversion("Further_questions_can")%> <span style="color: #10357f;">support@hexicomsoftware.com</span>
                                </li>
                            </ol>
                            <ol style="display: none">
                                <li>
                                    <%=objlang.GetLanguageConversion("Step1_For_Import_ProductCatalogue_Process")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Step2_For_Import_ProductCatalogue_Process")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Step3_For_Import_ProductCatalogue_Process")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Step4_For_Import_ProductCatalogue_Process")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Step5_For_Import_ProductCatalogue_Process")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Step6_For_Import_ProductCatalogue_Process")%></li>
                            </ol>
                            <div style="clear: both">
                                &nbsp;
                            </div>
                            <span style="font-weight: bold; display: none">
                                <%=objlang.GetLanguageConversion("Product_Catalogue_Useful_Tips")%>:</span>
                            <div style="clear: both; height: 5px">
                            </div>
                            <ol style="display: none">
                                <li>
                                    <%=objlang.GetLanguageConversion("Blank_Category_Name_Product_will_not_import_to_the_system_Its_Mandatory_field")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("For_Simple_Matrix_Product_Type_To_Quantity_Column_Should_Left_Blank")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("For_Following_Coloumns_Use_Values_Yes_Or_No")%>:
                                    <ul>
                                        <li>
                                            <%=objlang.GetLanguageConversion("UserArtworkFirstRowMandatory")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("ProductVisibletoStore")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("AllowUsertoUploadArtworkFile")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Show_Print_Ready_File")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Show_Stock")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Show_Price_Subtotal_Tax")%></li>
                                    </ul>
                                </li>
                                <li>
                                    <%=objlang.GetLanguageConversion("For_Column_UserArtworkFileCount_Possible_Values_Are_Only_Other_Value_Will_Be_Ignored")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Product_Catalogue_OwnserShip_Useful_Tip")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Separate_multiple_customer_names_with_a_comma")%></li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Product_Catalogue_Product_Type_Useful_Tip")%>
                                </li>
                                <li>
                                    <%=objlang.GetLanguageConversion("Please_fill_either_any_of_these_value_in_Price_Matrix_Type_column")%>
                                    <ul>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Simple_Matrix")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Price_Bands")%></li>
                                        <li>
                                            <%=objlang.GetLanguageConversion("Signange_Matrix")%></li>
                                    </ul>
                                </li>
                            </ol>
                            <div style="clear: both">
                                &nbsp;
                            </div>
                            <span style="font-weight: bold; display: none">
                                <%=objlang.GetLanguageConversion("When_Product_will_be_updated")%></span>
                            <div style="clear: both; height: 5px">
                            </div>
                            <ol style="display: none;">
                                <%=objlang.GetLanguageConversion("Please_Note_Item_Code_is_unique_field_If_you_leave_the_Item_Code_blank_the_system_will_generate_a_new_Item_Code_If_you_enter_an_item_code_already_exists_in_the_system_the_system_will_update_the_record_unless_you_have_choosen_to_ignore_duplicate_records")%>.
                            </ol>
                        </div>
                    </div>
                    <div align="left" style="width: 100%;">
                        <div style="float: left; width: 21%">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;
                    </div>
                    <div>
                        <asp:GridView ID="GridImport" Visible="false" runat="server" AutoGenerateColumns="true"
                            SkinID="GridStyle" CssClass="gv" GridLines="none" OnRowCreated="GridImport_OnRowCreated"
                            Width="100%">
                            <RowStyle CssClass="NewTableRows" />
                            <AlternatingRowStyle CssClass="NewAlternative" />
                            <FooterStyle CssClass="gv-footer" />
                            <HeaderStyle CssClass="bgcustomize navigatorpanel" />
                            <PagerStyle CssClass="gv-pager" />
                            <EditRowStyle CssClass="gridEditColor" />
                            <HeaderStyle CssClass="bgcustomize navigatorpanel" Height="22px" />
                            <EmptyDataTemplate>
                                <div id="Div1" class="emptyrecords" align="center">
                                    <span class="HeaderText" style="text-align: center">
                                        <%=objlang.GetValueOnLang("No record(s) found")%></span>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="divSubmit" visible="false" runat="server" align="left" style="width: 100%; padding-top: 10px;">
                        <div style="float: left;">
                            &nbsp;
                        </div>
                        <div>
                            <asp:Button ID="btnSubmit" CausesValidation="false" runat="server" CssClass="button"
                                Text="Submit" Width="65px" OnClick="btnSubmit_Click" OnClientClick="chkret();" />
                        </div>
                    </div>
                </div>
            </div>
            <%--  </div>--%>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function getInnerHtml() {
            var element = document.getElementById("ctl00_ContentPlaceHolder1_div2");
            var store = document.getElementById("ctl00_ContentPlaceHolder1_hdnInnerHtml");
            store.value = element.innerHTML;

        }
        function getInnerHtmlForPriceMatrix() {
            var element = document.getElementById("ctl00_ContentPlaceHolder1_div2");
            var store = document.getElementById("ctl00_ContentPlaceHolder1_hdnInnerHtmlForPriceMatrix");
            store.value = element.innerHTML;

        }
      
        function chkdelete() {
            var chkdelete = document.getElementById("<%=chkdelete.ClientID%>");

            if (chkdelete.checked == true) {
                return window.confirm("Are you sure you want to delete the exsisting Product Catalogue" + '\n' + "This is irreversable");

            }



        }
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

                var ret = chkdelete();
                var hdnisdelete = document.getElementById("<%=hdnisdelete.ClientID%>");

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

        function displayLoading() {
            document.getElementById('div_cancel').style.display = 'none';
            document.getElementById('div_btnCancelProcess').style.display = 'block';

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

        function openFileConverter() {
            var sitePath = "<%= strSitepath%>";
            PopupCenter(sitePath + "Fileconverter.aspx", "1040", "550");
        }


    </script>
</asp:Content>