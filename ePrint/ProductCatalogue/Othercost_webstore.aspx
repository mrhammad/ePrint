<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="Othercost_webstore.aspx.cs" Inherits="ePrint.ProductCatalogue.Othercost_webstore" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="scrptmanagerproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var Category_ID = "no";
        var DecimalValue = 0;
        var ThreeDecimalValue = 0;
        var Mode = '<%=action %>';
        var Multiple_Choice_Question = '<%=objlang.GetLanguageConversion("Multiple_Choice_Question") %>';
        var Simple_Single_Question = '<%=objlang.GetLanguageConversion("Simple_Single_Question") %>';
        var Matrix = '<%=objlang.GetLanguageConversion("Matrix") %>';
        var Formula_Cost = '<%=objlang.GetLanguageConversion("formula_Cost") %>';
        var Cost_Display = '<%=objlang.GetLanguageConversion("Cost") %>';
        var Selling_Price_For1 = '<%=objlang.GetLanguageConversion("Selling_Price_For1") %>';
        var Pack_Selling_Price = '<%=objlang.GetLanguageConversion("Pack_Selling_Price") %>';
        var Cost_For1 = '<%=objlang.GetLanguageConversion("Cost_For1") %>';
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.7.2.custom.min.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var strImagepath = "<%=strImagepath%>";
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);
        ThreeDecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 3, '', false, false, false);
    </script>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div align="left">
        <div class="div_prodaddoptions_margin">
            <div align="left">
                <div style="width: 65%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%">
                <div align="right">
                    <span style="color: Red">*
                        <%=objlang.GetLanguageConversion("fields_are_mandatory")%></span>
                </div>
            </div>
            <div align="left" style="width: 100%; padding-left: 6px;">
                <div style="width: 49%; float: left;">
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("Name")%></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtName" runat="server" Width="100%" CssClass="textboxnew" MaxLength="200"
                                onblur="javascript:CopyName_toUserFriendlyname();"></asp:TextBox>
                            <%--findduplicate(this.value);--Ref Bug ID:653--%>
                            <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objlang.GetLanguageConversion ("Please_enter_Name") %>
                            </span><span id="spn_alreadyExist" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                <%=objlang.GetLanguageConversion("Name_already_exists")%></span>
                        </div>
                        <div class="bglabel">
                            <asp:Label ID="Label19" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtUserfriendly" runat="server" Width="100%" CssClass="textboxnew"
                                MaxLength="200"></asp:TextBox>
                            <span id="spn_txtUserfriendly" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objlang.GetLanguageConversion("Please_enter_User_friendly_Name")%></span>
                        </div>
                        <script>
                            function findduplicate(name) {
                                var compID = '<%=CompanyID %>';
                                var WebOtherCostid = '<%=ID %>';
                                var val = compID + "±" + name + "±" + WebOtherCostid;
                                PageMethods.FindDuplicate(val, FindSuccNew, ShowMsg_Failure);
                            }
                            function ShowMsg_Failure(error) {
                            }
                            var CheckDuplicate = false;
                            function FindSuccNew(result) {
                                if (result == -1) {
                                    document.getElementById("spn_alreadyExist").style.display = "block";
                                    CheckDuplicate = true;
                                }
                                else {
                                    document.getElementById("spn_alreadyExist").style.display = "none";
                                    CheckDuplicate = false;
                                }
                            }
                        </script>
                    </div>
                    <div align="left">
                        <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <div class="bglabel">
                                    <div style="float: left">
                                        <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("Category")%></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div style="float: right;">
                                        <div id="div_AddCategory" runat="server">
                                            <a onclick="AddCategory('add')">
                                                <img src="<%=strImagepath %>plus.gif" border="0px" style="cursor: pointer" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="box" style="width: 55%;">
                                    <div id="div_OtherCost_add_item" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 37%"
                                        align="center">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                                                </td>
                                                <td class="popup-top-middlebg">
                                                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                                        <b>
                                                            <%=objlang.GetLanguageConversion("Category_Name")%>
                                                        </b>
                                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                                    </div>
                                                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                                                        <div class="CancelButtonDiv">
                                                            <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                                runat="server" CausesValidation="false" OnClientClick="AddCategory('close');return false;" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td colspan="2" class="popup-top-rightcorner">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="popup-middle-leftcorner">&nbsp;
                                                </td>
                                                <td style="width: 15px; background-color: #ffffff">&nbsp;
                                                </td>
                                                <td class="popup-middlebg" align="center">
                                                    <div style="padding: 10px 5px 10px 0px; width: 430px">
                                                        <div class="" style="width: 100%">
                                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <div align="left">
                                                                            <div class="bglabel">
                                                                                <span class="normaltext">
                                                                                    <%=objlang.GetLanguageConversion("Category_Name")%></span> <span style="color: Red">*</span>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:TextBox ID="txtOtherCostCategoryName" SkinID="textPad" Width="175px" runat="server"
                                                                                    MaxLength="50" onblur="findduplicatenew(this.value);"></asp:TextBox>
                                                                                <span id="spn_txtOtherCostCategoryName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                                    <%=objlang.GetValueOnLang("Please enter Category Name")%></span> <span id="spn_alreadyExistCategory"
                                                                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                                        <%=objlang.GetLanguageConversion("Category_Name_Already_Exists")%></span>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bglabel">
                                                                                <asp:Label ID="Label6" CssClass="normaltext" runat="server"><%=objlang.GetLanguageConversion("Job_Card_Catagory")%></asp:Label>
                                                                                <span style="color: Red">*</span>
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:DropDownList ID="ddlJobcardCategory" runat="server" CssClass="normalText" Width="183px">
                                                                                    <asp:ListItem Text="Pre Press" Value="Pre Press"></asp:ListItem>
                                                                                    <asp:ListItem Text="Press" Value="Press"></asp:ListItem>
                                                                                    <asp:ListItem Text="Post Press" Value="Post Press"></asp:ListItem>
                                                                                    <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                                                                    <asp:ListItem Text="Packing" Value="Packing"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dispatch" Value="Dispatch"></asp:ListItem>
                                                                                    <asp:ListItem Text="Admin 2" Value="Admin 2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span id="Span3" class="smallgraytext" style="display: block; width: 250px">(<%=objlang.GetValueOnLang("Please specify where you would like this category to appear on the Job Card")%>)
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left">
                                                                            <div class="bglabelEmpty">
                                                                            </div>
                                                                            <div class="box">
                                                                                <asp:Button ID="btnCategorySave" Text="Save" CssClass="button" OnClick="btnCategorySave_OnClick"
                                                                                    runat="server" OnClientClick="javascript:return checkduplicateName();" />
                                                                                <asp:HiddenField ID="hdn_CategortID" runat="server" Value="0" />
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width: 10px; background-color: #ffffff">&nbsp;
                                                </td>
                                                <td align="right" class="popup-middle-rightcorner">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
                                                </td>
                                                <td class="popup-bottom-middlebg">&nbsp;
                                                </td>
                                                <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="normalText" Width="100%"
                                        onchange="javascript:CallonChange(this.value,'spn_ddlCategory');return false;">
                                    </asp:DropDownList>
                                    <span id="spn_ddlCategory" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                        <%=objlang.GetLanguageConversion("Please_select_Category")%></span>
                                    <asp:HiddenField ID="hid_CategoryID" runat="server"></asp:HiddenField>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label9" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("Calculation_Type")%></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div class="ddlsetting" style="width: 55%;">
                            <asp:DropDownList runat="server" ID="ddlMainCalculation" CssClass="normalText" Width="100%"
                                onchange="javascript:onchange_option(this.value);">
                            </asp:DropDownList>
                            <span id="spn_ddlMainCalculation" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objlang.GetValueOnLang("Please select Calculation Type")%></span>
                            <asp:HiddenField ID="hid_CalculationType" runat="server" Value="0" />
                        </div>
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="lblSupplier" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("Supplier")%></asp:Label>
                        </div>
                        <div class="ddlsetting" style="width: 55%;">
                            <asp:DropDownList runat="server" ID="ddlSupplier" CssClass="normalText" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div align="left" id="DivSubAddition" style="display: none;" runat="server">
                        <div class="bglabel">
                            <asp:Label ID="Label4" runat="server" CssClass="normaltext" Text="Sub Additional Option"></asp:Label>
                        </div>
                        <div class="ddlsetting" style="width: 55%;">
                            <asp:CheckBox ID="chkSubAdditionalOption" runat="server" onclick="javascript:chkSubAdditionalOption_Check();" AutoPostBack="false" />
                        </div>
                    </div>
                    <div align="left" runat="server" id="div_AccountCode">
                        <div class="bglabel">
                            <asp:Label ID="lblAccountCode" runat="server" Text="" CssClass="normalText"><%=objlang.GetLanguageConversion("Accounting_Code") %></asp:Label>
                        </div>
                        <div class="ddlsetting" style="width: 55%;">
                            <asp:DropDownList ID="ddlAccountCode" runat="server" CssClass="normalText" Width="100%">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div style="width: 49%; float: left;">
                    <div align="left">
                        <div class="bglabel" style="height: 88px">
                            <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objlang.GetLanguageConversion("Help_Text")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtDescription" runat="server" Width="100%" CssClass="textboxnew"
                                TextMode="MultiLine" Rows="3" MaxLength="1000" Height="84px" SkinID="textPad"
                                onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                            <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                <%=objlang.GetValueOnLang("Max. length of textbox is")%>: 3000</span>
                        </div>
                    </div>
                </div>
                <div style="width: 49%; float: left;" id="divMandatory" runat="server">
                    <div class="bglabel">
                        <asp:Label ID="lblMandatory" runat="server" CssClass="normaltext">Additional Option is mandatory</asp:Label>
                    </div>
                    <div class="box">
                        <asp:CheckBox ID="chkMandatory" runat="server" OnClick="disableOptions(this)" />
                    </div>
                </div>
                <div style="width: 49%; float: left;" id="divNote" runat="server">
                    <div class="bglabel" style="background-color: #fff;">
                        &nbsp;
                    </div>
                    <div class="box" style="width: 60% !important">
                        <span id="Span1" class="smallerfontgrey" style="font-size: 89%">Note: If this Additional Option is mandatory, the first label must not have a cost allocated to it</span>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="width: 100%; display: block;" align="left">
                <fieldset>
                    <legend><span id="spn_option">
                        <%=objlang.GetLanguageConversion("Simple_single_question")%></span></legend>
                    <div class="only5px">
                    </div>
                    <div id="div_single" align="left" style="display: none">
                        <div align="left" style="width: 100%;">
                            <div class="normalText" style="width: 100%; padding-left: 5px;">
                                <%=objlang.GetLanguageConversion("Enter_the_Question")%>
                            </div>
                            <div align="left" style="float: left; width: 100%;">
                                <div class="box">
                                    <asp:TextBox ID="txtQuestion" runat="server" Width="80%" CssClass="textboxnew" TextMode="MultiLine"
                                        MaxLength="250"></asp:TextBox>
                                    <span id="spn_txtQuestion" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                        <%=objlang.GetLanguageConversion("Please_Enter_The_Question")%></span>
                                    <div class="only10px">
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left" style="width: 100%;">
                            <div class="normalText" style="width: 100%; padding-left: 5px;">
                                <%=objlang.GetLanguageConversion("Formula")%>
                            </div>
                            <div align="left" style="float: left; width: 100%;">
                                <div class="box">
                                    <asp:TextBox ID="txtFormula" runat="server" Width="80%" CssClass="textboxnew" Text="<question> *"
                                        TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                    <span id="spn_txtFormula" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                        <%=objlang.GetLanguageConversion("Please_Enter_The_Formula")%></span>
                                </div>
                            </div>
                            <div class="only5px">
                            </div>
                            <div class="only5px">
                            </div>
                        </div>
                        <div>
                            <span class="graytext">
                                <%=objlang.GetLanguageConversion("Formula_Tags") %>
                                : [$ProductBasePrice$], <span id="spn">&ltquestion&gt</span>, [$OrderedHeight$],
                                [$OrderedWidth$], [$OrderedArea$], [$OrderedQuantity$], [$MultipleOf$] </span>
                        </div>
                    </div>

                    <div id="div_freetext" align="left" style="display: none">
                        <div align="left" style="width: 100%;">
                            <div class="normalText" style="width: 100%; padding-left: 5px;">
                                <%=objlang.GetLanguageConversion("Enter_the_Question")%>
                            </div>
                            <div align="left" style="float: left; width: 100%;">
                                <div class="box">
                                    <asp:TextBox ID="txtFreeText" runat="server" Width="80%" CssClass="textboxnew" TextMode="MultiLine"
                                        MaxLength="250"></asp:TextBox>
                                    <br/>
                                    <asp:CheckBox ID="chkHideAdditionalName" runat="server" Checked="true" AutoPostBack="false" />
                                    <asp:Label ID="lblHideAdditionalName" runat="server" CssClass="normaltext" Text="Hide Additional Option Name"></asp:Label>

                                    <span id="spn_txtFreeText" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                        <%=objlang.GetLanguageConversion("Please_Enter_The_Question")%></span>
                                    <div class="only10px">
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="div_multiple" align="left" style="display: none">
                        <div style="border: 0px solid" align="center">
                            <div style="float: left; width: 300px;">
                                &nbsp;
                            </div>
                            <div align="center" id="diverrorMessage" style="width: 40%; padding: 3px; float: left">
                                <span id="spn_MultipleChoice" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                    <%=objlang.GetLanguageConversion("Please_Enter_Value_For_Atlest_One_Row")%></span>
                            </div>
                        </div>
                        <div class="onlyEmpty" style="width: 50%">
                            <div class="bglabel">
                                <%=objlang.GetLanguageConversion("Calculation_Type")%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <asp:DropDownList ID="ddlCalculationType" onchange="Onchange_calculationType(this.value);"
                                    CssClass="normalText" runat="server" Width="95%">
                                    <asp:ListItem Selected="True" Text="Fixed Value" Value="fixed"></asp:ListItem>
                                    <asp:ListItem Text="Formula" Value="quantity"></asp:ListItem>
                                    <asp:ListItem Text="Additional Options Group" Value="Groups"></asp:ListItem>
                                </asp:DropDownList>
                                <script>
                                    var ddlCalculationType = document.getElementById("<%=ddlCalculationType.ClientID %>");
                                </script>
                            </div>
                        </div>
                        <div align="left" style="width: 50%; float: right; padding-right: 5px">
                            <div id="div_btnImportInventory" align="right" style="float: right">
                                <a id="btnImportInventory" href="#" style="text-decoration: underline; display: none"
                                    onclick="javascript:import_inventory();">
                                    <%=objlang.GetLanguageConversion("Import_Options_From_Inventory")%></a>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="float: left; width: 98%">
                            <div align="left" class="borderWithoutTop" style="width: 100%;">
                                <table id="tb_Multiplechoice" cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                                    <thead id="MultipleQuestionTableHead">
                                    </thead>
                                    <tbody id="MultipleQuestion">
                                        <asp:PlaceHolder ID="plhMultiple" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                            <asp:HiddenField ID="hid_Rows_On_Edit_multiple" runat="server" />
                            <asp:HiddenField ID="hid_data_multiple" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_deleted_row" runat="server" Value="" />
                            <div align="right" style="width: 100%;">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0px" align="right">
                                    <tr>
                                        <td style='float: right;' align='center'>
                                            <a id="href_add_more_Multiple" name="addmore" style="display: none;" href='#addmore'
                                                onclick="Click_Add_More_multiple()">
                                                <%=objlang.GetLanguageConversion("Add_More_Label")%></a>
                                        </td>
                                        <td style='width: 24%;' align='center'></td>
                                        <td style='width: 20%;' align='center'></td>
                                        <td style='width: 20%;' align='center'></td>
                                        <td style='width: 24%;' align='center'></td>
                                    </tr>
                                </table>
                                <div class="only5px">
                                </div>
                                <div class="only5px">
                                </div>
                            </div>
                            <div id="div_MultipleFormulaTag" runat="server" style="display: none;">
                                <span class="graytext">
                                    <%=objlang.GetLanguageConversion("Formula_Tags") %>
                                    : [$ProductBasePrice$], &ltquantity&gt , [$OrderedHeight$], [$OrderedWidth$], [$OrderedArea$], [$MultipleOf$]
                                </span>
                            </div>
                            <asp:HiddenField ID="hdn_finalsavetype" runat="server" Value="" />
                            <script>
                                $(document).ready(function () {
                                    $('#MultipleQuestion').sortable({
                                        helper: fixWidthHelper,
                                        update: function (event, ui) {
                                            // grabs the new positions now that we've finished sorting
                                            //$('#TableAddop tr').each(function () {
                                            var TotalRow = document.getElementById("PriceTable").rows.length;
                                            var new_position = ui.item.index();
                                            var hdn_RowNumber;
                                            var j = 0;
                                            for (var i = 0; i < $("#MultipleQuestion tr").length; i++) {
                                                var ID = $("#MultipleQuestion tr").eq(i)[0].firstChild.attributes[0].value.split('_');
                                                var index = ID[2];
                                                hdn_RowNumber = document.getElementById("hdn_Multiple_Rownumber_" + index);
                                                hdn_RowNumber.value = j;
                                                i += 1;
                                                j++;
                                                //var a = fixWidthHelper;
                                            }
                                        }

                                    }).disableSelection();

                                    function fixWidthHelper(e, ui) {
                                        ui.children().each(function () {
                                            $(this).width($(this).width());
                                        });
                                        return ui;
                                    }
                                });

                                function GetCurSym(Amount, IsExist) {

                                    return GetCurrencyinRequiredFormate("", true);
                                }

                                function CreateHeaderMultiple() {

                                    var uniData = "";
                                    uniData += "<div nowarp='nowrap' style='width:100%;background-color: #DDDDDD;border:solid 0px red;' align='center'>";

                                    uniData += "<table style='width:100%;' cellpadding='3px' cellspacing='3px' border='0px' >";
                                    uniData += "<tr>";
                                    uniData += "<td style='width: 30%;' align='left'>";

                                    uniData += '<%=objlang.GetLanguageConversion("Label") %>';
                                    uniData += "</td>";


                                    uniData += "<td style='width: 38%;' align='left'>";
                                    if (ddlCalculationType.options[ddlCalculationType.selectedIndex].value == "Groups") {

                                        uniData += "<span id='spn_FrmOrValue'>" + 'Groups' + "</span>";
                                    }
                                    else {
                                        uniData += "<span id='spn_FrmOrValue'>" + '<%=objlang.GetLanguageConversion("Formula_Cost") %>' + "</span>";
                                    }
                                    uniData += "</td>";

                                    uniData += "<td style='width: 15%;' align='center'>";
                                    if (ddlCalculationType.options[ddlCalculationType.selectedIndex].value == "Groups") {

                                        uniData += "<span id='spn_Markup' style='display:none;'>" + '<%=objlang.GetLanguageConversion("MarkUp") %>' + " (%)</span>";
                                    }
                                    else {
                                        uniData += "<span id='spn_Markup'>" + '<%=objlang.GetLanguageConversion("MarkUp") %>' + " (%)</span>";

                                    }
                                    uniData += "</td>";

                                    uniData += "<td id='td_sellingprice' style='width: 15%;' align='left'>";
                                    if (ddlCalculationType.options[ddlCalculationType.selectedIndex].value == "fixed") {
                                        uniData += "<span id='spn_sellingprice'>" + '<%=objlang.GetLanguageConversion("Selling_Price") %>' + " (" + GetCurSym('', true) + ")</span>";
                                    }
                                    uniData += "</td>";

                                    uniData += "<td style='width: 2%;' align='center'>";
                                    uniData += '<%=objlang.GetLanguageConversion("Action") %>';
                                    uniData += "</td>";

                                    uniData += "</tr>";
                                    uniData += "</table>";
                                    uniData += "</div>";

                                    return uniData;
                                }
                            </script>
                            <asp:Panel ID="pnlCheckRowMultiple" runat="server" Visible="false">
                                <script>
                                    var hid_Rows_On_Edit_multiple = document.getElementById("<%=hid_Rows_On_Edit_multiple.ClientID %>");
                                    if (hid_Rows_On_Edit_multiple.value < 150) {
                                        document.getElementById("href_add_more_Multiple").style.display = "block";
                                    }
                                    function Take_Data_DB_Multiple() {
                                        var hid_data_multiple = document.getElementById("<%=hid_data_multiple.ClientID %>");
                                        var arr = hid_data_multiple.value.split('µ');
                                        for (var j = 0; j < arr.length; j++) {
                                            if (arr[j] != '') {
                                                if (j == 0) {
                                                    var row_1 = document.createElement("tr");
                                                    var cell_1 = document.createElement("td");
                                                    cell_1.id = "td_header_multiple_";
                                                    cell_1.innerHTML = CreateHeaderMultiple();
                                                    row_1.appendChild(cell_1);
                                                    document.getElementById("MultipleQuestionTableHead").appendChild(row_1);
                                                }
                                                var row_new = document.createElement("tr");
                                                var cell_new = document.createElement("td");
                                                cell_new.id = "td_multiple_" + j + "";
                                                cell_new.innerHTML = arr[j];
                                                row_new.appendChild(cell_new);
                                                document.getElementById("MultipleQuestion").appendChild(row_new);
                                            }
                                        }
                                        TotalRowMultiple = hid_Rows_On_Edit_multiple.value; //                                                                                
                                    }
                                    Take_Data_DB_Multiple();
                                    if ('<%=IsMandatoryField%>'.toLocaleLowerCase() == 'false') {
                                        document.getElementById('hdn_IsMandatoryField_0').value = '1';
                                        document.getElementById('img_deleterow_0').style.display = 'none';
                                        document.getElementById('img_deleterow_0').remove();
                                        document.getElementById('spn_IsMandatoryField_0').style.display = null;
                                    }
                                </script>
                            </asp:Panel>
                            <script>

                                function CreateTableMultiple() {

                                    var uniData = "";
                                    uniData += CreateHeaderMultiple();
                                    uniData += "<div style='clear:both'></div>";

                                    var TempData_new = '';
                                    if (Mode != "edit") {
                                        for (var i = 0; i < 10; i++) {
                                            var txtValue = '';
                                            var spnValue = '';

                                            var clsName = "";
                                            if (i != 0) {
                                                if (i % 2 == 0) {
                                                    clsName = "";
                                                }
                                                else {
                                                    clsName = "#EFEFEF";

                                                }
                                            }
                                            var daa = ''
                                            TempData_new = CreateRowMultiple(i, clsName, daa);

                                            if (i == 0) {
                                                var row_1 = document.createElement("tr");
                                                var cell_1 = document.createElement("td");
                                                cell_1.id = "td_header_multiple_";
                                                cell_1.innerHTML = uniData;
                                                row_1.appendChild(cell_1);

                                                var row_2 = document.createElement("tr");
                                                var cell_2 = document.createElement("td");
                                                cell_2.id = "td_multiple_" + i + "";
                                                cell_2.innerHTML = TempData_new;
                                                row_2.appendChild(cell_2);

                                                document.getElementById("MultipleQuestionTableHead").appendChild(row_1);
                                                document.getElementById("MultipleQuestion").appendChild(row_2);
                                            }
                                            else {
                                                var row_new = document.createElement("tr");
                                                var cell_new = document.createElement("td");
                                                cell_new.id = "td_multiple_" + i + "";
                                                cell_new.innerHTML = TempData_new;
                                                row_new.appendChild(cell_new);
                                                document.getElementById("MultipleQuestion").appendChild(row_new);
                                            }
                                            lastRowMultiple = i;
                                            if (i < 150) {
                                                document.getElementById("href_add_more_Multiple").style.display = "block";
                                            }
                                            else {
                                                document.getElementById("href_add_more_Multiple").style.display = "none";
                                            }

                                        }
                                    }
                                    else {
                                        //FROM DB On EDIT CASE
                                    }
                                }
                                function CreateRowMultiple(i, clsName, uniData) {

                                    if (i % 2 == 0) {
                                        clsName = "";
                                    }
                                    else {
                                        clsName = "#EFEFEF";
                                    }

                                    var IsDisplay_new = 'display:none;';
                                    var ChangeDivWidth_new = '90%';


                                    uniData = "<div id='div_row_multiple" + i + "' style='background-color:" + clsName + ";height:25px;vertical-align:middle;' >";
                                    uniData += "<div class='only5px' style='width: 100%;'>";
                                    uniData += "<table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >";
                                    uniData += "<tr>";

                                    var label = '';
                                    if (queryString == "add" && i == 0) {
                                        label = "---Select---";
                                    }
                                    else {
                                        label = "";
                                    }

                                    uniData += "<td style='width: 30%;padding-left:5px' align='left'>";
                                    uniData += "<div id='div_label_" + i + "' style='float: left; width: " + ChangeDivWidth_new + ";' >";
                                    uniData += "<input id='txtlabel_" + i + "'   maxlength=250 type='text' style='width:250px;text-align:left;' class='textboxnew' value='" + label + "'/>";
                                    uniData += "<input type='hidden' name='Rownumber' id='hdn_Multiple_Rownumber_" + i + "' value='" + i + "'>";
                                    uniData += "</div>";
                                    uniData += "</td>";

                                    var fixed_or_qty = '';
                                    var qtyonblur = '';
                                    var maxlength = "1000";
                                    if (ddlCalculationType.value == "Groups") {
                                        fixed_or_qty = '';
                                    }
                                    else if (ddlCalculationType.value != "quantity") {
                                        fixed_or_qty = ThreeDecimalValue;
                                        qtyonblur = "onblur = 'CalculateMultipleSellPrice(this," + i + ")'";
                                        maxlength = "200";
                                    }

                                    else {
                                        fixed_or_qty = "<quantity>";
                                        maxlength = "1000";
                                    }


                                    uniData += "<td style='width: 38%;' align='left'>";
                                    uniData += "<input id='txtfixed_or_qty_" + i + "' type='text' maxlength='" + maxlength + "' style='width:400px;text-align:left;' " + qtyonblur + " class='textboxnew' value='" + fixed_or_qty + "' onclick='displayGroups(" + CompanyID + "," + i + ",event);' onkeyup='displayGroups(" + CompanyID + "," + i + ",event);' />";
                                    uniData += "</td>";
                                    uniData += "<input type='hidden' name='GroupID' id='hdn_GroupID_" + i + "' value='0'>";
                                    if (i == 0) {
                                        uniData += "<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_" + i + "' value='1'>";
                                    } else {
                                        uniData += "<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_" + i + "' value='0'>";
                                    }
                                    var Multiple_AssignOnBlur = "";
                                    if (i == 0) {
                                        Multiple_AssignOnBlur = "onblur=SetMarkupToAllMultiple(this,'" + i + "');Onbur_MultipleMarkup(this,'" + i + "');todecimal_function(this,this.value);";
                                    }
                                    else {
                                        Multiple_AssignOnBlur = "onblur=Onbur_MultipleMarkup(this,'" + i + "');todecimal_function(this,this.value);";
                                    }

                                    uniData += "<td style='width: 13%;' align='center'>";
                                    if (ddlCalculationType.value != "Groups") {
                                        uniData += "<input id='txtMarkup_multiple_" + i + "' " + Multiple_AssignOnBlur + " type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
                                    }
                                    else {
                                        uniData += "<input id='txtMarkup_multiple_" + i + "' " + Multiple_AssignOnBlur + " type='text' maxlength='20'  style='width:80px;text-align:right;display:none;' class='textboxnew' value='" + DecimalValue + "' />";
                                    }
                                    uniData += "</td>";


                                    uniData += "<td id='td_txtsellingprice_" + i + "' style='width: 15%;padding-left:1%;' align='left'>";
                                    var MarkupVisible = '';
                                    if (ddlCalculationType.value == "Groups") {
                                        MarkupVisible = "style='width:80px;text-align:right;display:none;'";
                                    }
                                    else if (ddlCalculationType.value != "quantity") {
                                        MarkupVisible = "style='width:80px;text-align:right;display:block;'";
                                    }

                                    else {
                                        MarkupVisible = "style='width:80px;text-align:right;display:none;'";
                                    }
                                    uniData += "<input id='txt_sellingprice_" + i + "' onblur=Calculate_MultipleMarkup(this,'" + i + "'); type='text' maxlength='20' " + MarkupVisible + "  class='textboxnew' value='" + ThreeDecimalValue + "'/>";
                                    uniData += "<span id='spn_choiceID_" + i + "' style='display:none;'>" + 0 + "</span>";

                                    uniData += "<span id='spn_InventoryID_" + i + "' style='display:none;'>" + 0 + "</span>";

                                    uniData += "</td>";

                                    uniData += "<td align='center' style='width:4%;'>";
                                    if (i == 0) {
                                        uniData += "<span align='right' style='color: Red;'>*</span>";
                                    }
                                    else {
                                        uniData += "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row_New(" + i + "); />";
                                    }
                                    uniData += "<img style='cursor:pointer;height:10px;width:10px;padding-left:5px;' src='" + strImagepath + "drag_drop.gif' border='0' title='Re-order'/>";
                                    uniData += "</td>";


                                    uniData += "</tr>";
                                    uniData += "</table>";

                                    uniData += "</div>";
                                    uniData += "<div id='Divtxtfixed_or_qty_" + i + "' style='display:none;'></div>";
                                    uniData += "</div>";
                                    return uniData;
                                }

                                var Groupname = '';
                                function displayGroups(companyID, index, e) {
                                    var ddlValue = ddlCalculationType.options[ddlCalculationType.selectedIndex].value;
                                    if (ddlValue.toString().trim() == "Groups") {
                                        var CustomerDiv = false;
                                        index_value = index;
                                        Groupname = document.getElementById("txtfixed_or_qty_" + index + "");
                                        if (e.type == "keyup") {
                                            document.getElementById("hdn_GroupID_" + index_value + "").value = "0";
                                        }
                                        this.textbox = Groupname.id;
                                        var innertextbox = document.getElementById(Groupname.id);
                                        var value = Groupname.value;
                                        if (CustomerDiv != false) {
                                            this.div = document.getElementById(CustomerDiv.id);
                                            this.list = this.div.getElementsByTagName('li');
                                        }
                                        var ac = this;
                                        if (e != undefined) {

                                            e = e || window.event;
                                            switch (e.keyCode) {
                                                case 38: //up 
                                                    {
                                                        ac.selectDiv(-1);
                                                        break;
                                                    }
                                                case 40: //down
                                                    {
                                                        ac.selectDiv(1);
                                                        break;
                                                    }
                                                case 13: //enter
                                                    {

                                                        CustomerDiv.style.visibility = 'hidden';
                                                        this.pointer = 0;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        this.pointer = 0;

                                                        ClickEvent = Groupname.id;

                                                        initGroup(ClickEvent, 1);
                                                        CustomerDiv.innerHTML = '';
                                                        setTimeout(function () {
                                                            AutoFill.GetGroupNames(CompanyID, value, onResponse_GetGroupName, onTimeout, onError);
                                                        }, 1500);
                                                    }
                                            }
                                        }

                                        else {
                                            this.pointer = 0;

                                            //if (buttonObj.value.length > 2) {

                                            ClickEvent = Groupname.id;
                                            initGroup(ClickEvent, 1);
                                            CustomerDiv.innerHTML = '';
                                            setTimeout(function () { AutoFill.GetGroupNames(CompanyID, value, onResponse_GetGroupName, onTimeout, onError); }, 10000);
                                        }
                                    }
                                }
                                function onResponse_GetGroupName(ListofGroups) {

                                    CustomerDiv.innerHTML = '';
                                    CustomerDiv.innerHTML = ListofGroups;
                                    CustomerDiv.style.display = 'block';

                                    CustomerDiv.style.left = getleftPosCustomer(Groupname) + 'px';
                                    CustomerDiv.style.top = getTopPosCustomer(Groupname) + 'px';
                                    if (document.getElementById("txtfixed_or_qty_" + index_value + "").value == "0") {
                                        document.getElementById("hdn_GroupID_" + index_value + "").value = "0";
                                    }
                                }
                                function initGroup(ID, Width) {
                                    try {

                                        CustomerDiv.style.display = 'none';
                                    }
                                    catch (err) {
                                    }
                                    var randomnumber = Math.floor(Math.random() * 10000000)
                                    CustomerDiv = document.createElement('DIV');
                                    CustomerDiv.id = randomnumber + 'Div' + ID;
                                    oldDiv = CustomerDiv.id;
                                    CustomerDiv.style.position = 'absolute';
                                    CustomerDiv.style.zIndex = 100000000;
                                    CustomerDiv.style.backgroundcolor = 'Gray';
                                    CustomerDiv.style.width = '200px';
                                    CustomerDiv.style.top = '63%';
                                    CustomerDiv.style.left = '36%';
                                    CustomerDiv.style.padding = '0px';
                                    CustomerDiv.style.display = 'none';
                                    document.body.appendChild(CustomerDiv);
                                }
                                function GetGroupName_Textbox(GroupID, GroupName) {

                                    var i = index_value;
                                    document.getElementById("hdn_GroupID_" + index_value + "").value = GroupID;
                                    document.getElementById("txtfixed_or_qty_" + index_value + "").value = GroupName;
                                }
                                function SetMarkupToAllMultiple(obj, index) {

                                    var ddlValue = ddlCalculationType.options[ddlCalculationType.selectedIndex].value;
                                    if (Number(obj.value) != 0 && !isNaN(obj.value)) {
                                        if (ddlValue == "fixed") {
                                            var Price = 0;
                                            var Markup = 0;
                                            var SellingPrice = 0;
                                            for (var i = 0; i < TotalRowMultiple; i++) {
                                                if ((document.getElementById("txtMarkup_multiple_" + i + "") != null && i == 0) || (document.getElementById("txtMarkup_multiple_" + i + "") != null && parseFloat(document.getElementById("txtMarkup_multiple_" + i + "").value) == 0 && i > 0)) {
                                                    document.getElementById("txtMarkup_multiple_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
                                                    Markup = document.getElementById("txtMarkup_multiple_" + i + "").value;

                                                    if (document.getElementById("txtfixed_or_qty_" + i + "") != null) {
                                                        Price = document.getElementById("txtfixed_or_qty_" + i + "").value;
                                                    }
                                                    SellingPrice = Number(Price) + ((Number(Price) * Number(Markup)) / 100);
                                                    document.getElementById("txt_sellingprice_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 3, '', false, false, false);
                                                }
                                            }
                                        }
                                        else if (ddlValue == "quantity") {
                                            for (var i = 0; i < TotalRowMultiple; i++) {
                                                if ((document.getElementById("txtMarkup_multiple_" + i + "") != null && i == 0) || (document.getElementById("txtMarkup_multiple_" + i + "") != null && parseFloat(document.getElementById("txtMarkup_multiple_" + i + "").value) == 0 && i > 0)) {
                                                    document.getElementById("txtMarkup_multiple_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
                                                }
                                            }
                                        }
                                    }
                                    else {
                                        obj.value = "0.00";
                                        document.getElementById("txtMarkup_multiple_" + index + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);
                                    }
                                }



                                var lastRowMultiple = 0;
                                var TotalRowMultiple = 10;
                                var queryString = '<%=Request.Params["type"] %>';
                                var index_value = '';
                                if (queryString == "edit") {
                                    TotalRowMultiple = document.getElementById("<%=hid_Rows_On_Edit_multiple.ClientID %>").value;
                                }

                                function Remove_Row_multiple(index) {
                                    var NoOfRows = 0;
                                    for (var i = 0; i < TotalRowMultiple; i++) {
                                        if (document.getElementById("div_row_multiple" + i + "") != null) {
                                            NoOfRows++;
                                        }
                                    }
                                    if (NoOfRows < 2) {
                                        alert('Multiple choice question should have at least one row !');
                                        return false;
                                    }
                                    NoOfRows = NoOfRows - 1;
                                    if (NoOfRows < 150) {
                                        document.getElementById("href_add_more_Multiple").style.display = "block";
                                    }
                                    else {
                                        document.getElementById("href_add_more_Multiple").style.display = "none";
                                    }
                                    var obj = document.getElementById("MultipleQuestion");

                                    var Child_Obj = document.getElementById("td_multiple_" + index + "");
                                    Child_Obj.innerHTML = "";
                                    //obj.removeChild(Child_Obj);
                                }

                                function Remove_Row_New(index) {
                                    var WebOtherCostid = '<%=ID %>';
                                    var NoOfRows = 0;
                                    for (var i = 0; i < TotalRow; i++) {
                                        if (document.getElementById("div_row_multiple" + i + "") != null) {
                                            NoOfRows++;
                                        }
                                    }
                                    NoOfRows = NoOfRows - 1;
                                    if (NoOfRows < 150) {
                                        document.getElementById("href_add_more").style.display = "block";
                                    }
                                    else {
                                        document.getElementById("href_add_more").style.display = "none";
                                    }
                                    if (document.getElementById("spn_choiceID_" + index + "") != null) {
                                        var DelID = document.getElementById("<%=hdn_deleted_row.ClientID %>");
                                        var ChoiceID = document.getElementById("spn_choiceID_" + index + "").innerHTML;
                                        if (Number(ChoiceID) != 0) {
                                            DelID.value = DelID.value + "§" + ChoiceID;
                                        }
                                    }
                                    var Child_Obj = document.getElementById("td_multiple_" + index + "");
                                    Child_Obj.innerHTML = "";
                                }

                                function Click_Add_More_multiple() {

                                    var Data = '';
                                    Data = CreateRowMultiple(TotalRowMultiple, "", Data);
                                    var row_new = document.createElement("tr");
                                    var cell_new = document.createElement("td");
                                    cell_new.id = "td_multiple_" + TotalRowMultiple + "";
                                    cell_new.innerHTML = Data;
                                    row_new.appendChild(cell_new);
                                    document.getElementById("MultipleQuestion").appendChild(row_new);

                                    TotalRowMultiple++;
                                    var CheckMax = 0;
                                    for (var i = 0; i < TotalRowMultiple; i++) {
                                        if (document.getElementById("div_row_multiple" + i + "") != null) {
                                            CheckMax++;
                                        }
                                    }
                                    if (CheckMax < MaxMultiple) {
                                        document.getElementById("href_add_more_Multiple").style.display = "block";
                                    }
                                    else {
                                        document.getElementById("href_add_more_Multiple").style.display = "none";
                                    }
                                }
                                //=======================   This will creates the Multiple Question row   =============================
                                CreateTableMultiple();

                                var MaxMultiple = 150;


                            </script>
                        </div>
                    </div>
                    <div id="div_Matrix" align="left" style="display: none;">
                        <div class="onlyEmpty" style="width: 50%">
                            <div class="bglabel">
                                <%=objlang.GetLanguageConversion("Price_Matrix_Type")%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <asp:DropDownList ID="ddlMatrixType" onchange="MatrixTypeChange_new(this.value);"
                                    CssClass="normalText" runat="server" Width="95%">
                                </asp:DropDownList>
                                <script>
                                    var ddlMatrixType = document.getElementById("<%=ddlMatrixType.ClientID %>");

                                </script>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="onlyEmpty">
                            <div style="float: left; width: 98%">
                                <div align="left" class="borderWithoutTop" style="width: 100%;">
                                    <table id="TableAddop" cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                                        <thead id="PriceTableHead">
                                        </thead>
                                        <tbody id="PriceTable">
                                        </tbody>
                                    </table>
                                </div>
                                <asp:HiddenField ID="hid_Rows_On_Edit" runat="server" />
                                <asp:HiddenField ID="hid_data" runat="server" Value="" />
                                <div align="right" style="width: 100%;">
                                    <table cellpadding="0" cellspacing="0" width="100%" border="0px" align="right">
                                        <tr>
                                            <td style='width: 24%;' align='center'></td>
                                            <td style='width: 20%;' align='center'></td>
                                            <td style='width: 20%;' align='center'></td>
                                            <td style='width: 24%;' align='center'></td>
                                            <td style='float: right;' align='center'>
                                                <a id="href_add_more" name="addmore" style="display: none;" href='#addmore' onclick="Click_Add_More()">
                                                    <%=objlang.GetLanguageConversion("Add_More") %></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <script>

                                    //                                    $(document).ready(function () {
                                    //                                        $('#PriceTable').sortable({
                                    //                                            helper: fixWidthHelper,
                                    //                                            update: function (event, ui) {
                                    //                                                // grabs the new positions now that we've finished sorting
                                    //                                                //$('#TableAddop tr').each(function () {
                                    //                                                var TotalRow = document.getElementById("PriceTable").rows.length;
                                    //                                                var new_position = ui.item.index();
                                    //                                                var hdn_RowNumber;
                                    //                                                var j = 0;
                                    //                                                for (var i = 0; i < $("#PriceTable tr").length; i++) {
                                    //                                                    var ID = $("#PriceTable tr").eq(i)[0].firstChild.attributes[0].value.split('_');
                                    //                                                    var index = ID[1];
                                    //                                                    hdn_RowNumber = document.getElementById("hdn_Matrix_Rownumber_" + index);
                                    //                                                    hdn_RowNumber.value = j;
                                    //                                                    i += 1;
                                    //                                                    j++;
                                    //                                                    //var a = fixWidthHelper;
                                    //                                                }
                                    //                                            }

                                    //                                        }).disableSelection();

                                    //                                        function fixWidthHelper(e, ui) {
                                    //                                            ui.children().each(function () {
                                    //                                                $(this).width($(this).width());
                                    //                                            });
                                    //                                            return ui;
                                    //                                        }
                                    //                                    });

                                    function CreateHeader() {

                                        var uniDataPrice = "";
                                        uniDataPrice += "<div nowarp='nowrap' style='width:100%;border:solid 0px red;' align='center'>";

                                        uniDataPrice += "<table style='width:100%;background-color: #DDDDDD;' cellpadding='3px' cellspacing='3px' border='0px' >";
                                        uniDataPrice += "<tr>";
                                        uniDataPrice += "<td style='width: 24%;' align='center'>";

                                        uniDataPrice += '<%=objlang.GetLanguageConversion("Quantity") %>';
                                        uniDataPrice += "</td>";
                                        uniDataPrice += "<td style='width: 20%;' align='center'>";
                                        uniDataPrice += "<span id='spn_cost'>" + '<%=objlang.GetLanguageConversion("cost_For1") %>' + " (" + GetCurSym('', true) + ")</span>";
                                        uniDataPrice += "</td>";



                                        uniDataPrice += "<td style='width: 20%;' align='center'>";
                                        uniDataPrice += '<%=objlang.GetLanguageConversion("MarkUp") %>';
                                        uniDataPrice += "</td>";

                                        uniDataPrice += "<td style='width: 24%;' align='center'>";
                                        uniDataPrice += "<span id='spn_header_sellingprice'>" + '<%=objlang.GetLanguageConversion("Selling_Price_For1") %>' + " (" + GetCurSym('', true) + ")</span>";
                                        uniDataPrice += "</td>";

                                        uniDataPrice += "<td align='center' style='padding-right:40px;'>";
                                        uniDataPrice += '<%=objlang.GetLanguageConversion("Action") %>';
                                        uniDataPrice += "</td>";


                                        uniDataPrice += "</tr>";
                                        uniDataPrice += "</table>";
                                        uniDataPrice += "</div>";

                                        return uniDataPrice;
                                    }
                                </script>
                                <asp:Panel ID="pnlCheckRow" runat="server" Visible="false">
                                    <script>
                                        var hid_Rows_On_Edit = document.getElementById("<%=hid_Rows_On_Edit.ClientID %>");
                                        if (hid_Rows_On_Edit.value < 150) {
                                            document.getElementById("href_add_more").style.display = "block";
                                        }
                                        function Take_Data_DB() {
                                            var hid_data = document.getElementById("<%=hid_data.ClientID %>");
                                            var arr = hid_data.value.split('µ');
                                            for (var j = 0; j < arr.length; j++) {
                                                if (arr[j] != '') {
                                                    if (j == 0) {
                                                        var row_1 = document.createElement("tr");
                                                        var cell_1 = document.createElement("th");
                                                        cell_1.id = "td_header";
                                                        cell_1.innerHTML = CreateHeader();
                                                        row_1.appendChild(cell_1);
                                                        document.getElementById("PriceTableHead").appendChild(row_1);
                                                    }
                                                    var row = document.createElement("tr");
                                                    var cell = document.createElement("td");
                                                    cell.id = "td_" + j + "";
                                                    cell.innerHTML = arr[j];
                                                    row.appendChild(cell);
                                                    document.getElementById("PriceTable").appendChild(row);
                                                }
                                            }
                                            TotalRow = hid_Rows_On_Edit.value;
                                            TotalRow = document.getElementById("PriceTable").rows.length;
                                            if (ddlMatrixType.value == "pricebands") {
                                                document.getElementById("spn_cost").innerHTML = "Cost For 1 (" + GetCurSym('', true) + ")";
                                                document.getElementById("spn_header_sellingprice").innerHTML = "Selling Price For 1 (" + GetCurSym('', true) + ")";
                                            }
                                            else if (ddlMatrixType.value == "simplematrix") {
                                                document.getElementById("spn_cost").innerHTML = "Cost (" + GetCurSym('', true) + ")";
                                                document.getElementById("spn_header_sellingprice").innerHTML = "Pack Selling Price (" + GetCurSym('', true) + ")";
                                            }
                                        }
                                        Take_Data_DB();
                                    </script>
                                </asp:Panel>
                                <script>



                                    function CreateTable() {

                                        var uniDataPrice = "";
                                        uniDataPrice += CreateHeader();
                                        uniDataPrice += "<div style='clear:both'></div>";

                                        var TempData = '';
                                        if (Mode != "edit") {
                                            for (var i = 0; i < 10; i++) {
                                                var txtValue = '';
                                                var spnValue = '';

                                                if (i == 1) {
                                                    txtValue = Number(i * 2) * 50;
                                                    spnValue = 51;
                                                }
                                                else if (i != 0) {
                                                    txtValue = Number(i * 2) * 50;
                                                    spnValue = Number(txtValue - 100) + 1;
                                                }
                                                else {
                                                    spnValue = 1;
                                                    txtValue = 50;
                                                }
                                                var clsName = "";
                                                if (i != 0) {
                                                    if (i % 2 == 0) {
                                                        clsName = "";
                                                    }
                                                    else {
                                                        clsName = "#EFEFEF";

                                                    }
                                                }
                                                var daa = ''
                                                TempData = CreateRow(i, clsName, spnValue, txtValue, daa, "");

                                                if (i == 0) {
                                                    var row_1 = document.createElement("tr");
                                                    var cell_1 = document.createElement("td");
                                                    cell_1.id = "td_header";
                                                    cell_1.innerHTML = uniDataPrice;
                                                    row_1.appendChild(cell_1);

                                                    var row_2 = document.createElement("tr");
                                                    var cell_2 = document.createElement("td");
                                                    cell_2.id = "td_" + i + "";
                                                    cell_2.innerHTML = TempData;
                                                    row_2.appendChild(cell_2);

                                                    document.getElementById("PriceTableHead").appendChild(row_1);
                                                    document.getElementById("PriceTable").appendChild(row_2);
                                                }
                                                else {
                                                    var row = document.createElement("tr");
                                                    var cell = document.createElement("td");
                                                    cell.id = "td_" + i + "";
                                                    cell.innerHTML = TempData;
                                                    row.appendChild(cell);
                                                    document.getElementById("PriceTable").appendChild(row);
                                                }
                                                lastRow = i;
                                                if (i < 150) {
                                                    document.getElementById("href_add_more").style.display = "block";
                                                }
                                                else {
                                                    document.getElementById("href_add_more").style.display = "none";
                                                }

                                            }


                                        }
                                        else {
                                            //FROM DB On EDIT CASE
                                        }
                                    }
                                    function CreateRow(i, clsName, spnValue, txtValue, uniDataPrice, MatrixType) {

                                        if (i % 2 == 0) {
                                            clsName = "";
                                        }
                                        else {
                                            clsName = "#EFEFEF";
                                        }

                                        var IsDisplay = '';
                                        var ChangeDivWidth = '50%';
                                        if (MatrixType == "simplematrix") {
                                            IsDisplay = 'display:none;';
                                            ChangeDivWidth = '90%';
                                        }

                                        uniDataPrice = "<div id='div_row_" + i + "' style='background-color:" + clsName + ";height:25px;vertical-align:middle;' >";
                                        uniDataPrice += "<div class='only5px' style='width: 100%;'>";
                                        uniDataPrice += "<table style='width:100%;' cellpadding='0px' cellspacing='0px' border='0px' >";
                                        uniDataPrice += "<tr>";

                                        uniDataPrice += "<td style='width: 24%;' align='center'>";

                                        uniDataPrice += "<div style='float: left; width: 45%;' align='center' nowrap=nowarp>";
                                        uniDataPrice += "<input type='text' id='txtQty_from_" + i + "' style='width:50px;text-align:right;" + IsDisplay + "' onkeyup='ToInteger(this,this.value);'  onblur=Check_Qty_From(" + i + ",this.value) maxlength=7 type='text'  value='" + spnValue + "'  class='textboxnew'>";
                                        uniDataPrice += "<input type='hidden' name='Rownumber' id='hdn_Matrix_Rownumber_" + i + "' value='" + i + "'>";
                                        uniDataPrice += "</div>";
                                        uniDataPrice += "<div style='float: left; padding-right:5px;'>";
                                        uniDataPrice += "<span id='spn_qty_sep_" + i + "' style='" + IsDisplay + "'>-</span>";
                                        uniDataPrice += "</div>";
                                        uniDataPrice += "<div id='div_txtQty_" + i + "' style='float: left; width: " + ChangeDivWidth + ";' >";
                                        uniDataPrice += "<input id='txtQty_" + i + "' onblur='QuantityCheck(this.value," + i + ");' onkeyup='ToInteger(this,this.value);' '  maxlength=7 type='text' style='width:80px;text-align:right;' value='" + txtValue + "'  class='textboxnew' />"; //
                                        uniDataPrice += "</div>";


                                        uniDataPrice += "</td>";
                                        uniDataPrice += "<td style='width: 20%;border:0px solid red' align='center'>";

                                        uniDataPrice += "<input id='txtCost_" + i + "' type='text' onblur=CalculateSellPrice(this," + i + ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + ThreeDecimalValue + "'/>";

                                        uniDataPrice += "</td>";
                                        uniDataPrice += "<td style='width: 20%;' align='center'>";

                                        var AssignOnBlur = "";
                                        if (i == 0) {
                                            AssignOnBlur = "onblur=CalculateSellPrice(this," + i + ",'markup');SetMarkupToAll(this,'" + i + "');";
                                        }
                                        else {
                                            AssignOnBlur = "onblur=CalculateSellPrice(this," + i + ",'markup');";
                                        }
                                        uniDataPrice += "<input id='txtMarkup_" + i + "' type='text' " + AssignOnBlur + "  maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";


                                        uniDataPrice += "</td>";
                                        uniDataPrice += "<td style='width: 24%;' align='center'>";

                                        uniDataPrice += "<input id='txtSellingPrice_" + i + "' onblur=Calculate_Markup(this," + i + "); type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='" + ThreeDecimalValue + "' />";
                                        uniDataPrice += "<span id='spn_matrixID_" + i + "' style='display:none;'>" + 0 + "</span>";


                                        uniDataPrice += "</td>";
                                        uniDataPrice += "<td align='left' style='padding-left:50px;>";


                                        uniDataPrice += "<div align='left'>";
                                        uniDataPrice += "<img style='cursor:pointer;height:10px;width:10px;' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(" + i + "); />";
                                        //uniDataPrice += "<img style='cursor:pointer;height:10px;width:10px;padding-left:10px;' src='" + strImagepath + "drag_drop.gif' border='0' title='Re-order'/>";
                                        uniDataPrice += "</div>";

                                        uniDataPrice += "</td>";


                                        uniDataPrice += "</tr>";
                                        uniDataPrice += "</table>";

                                        uniDataPrice += "</div>";
                                        uniDataPrice += "</div>";

                                        return uniDataPrice;
                                    }


                                    function ToInteger(obj, val) {

                                        if (val.substring(val.length - 1, val.length) == ".") {
                                            obj.value = val.toString().replace('.', '');
                                        }

                                    }

                                    var lastRow = 0;
                                    var TotalRow = 10;
                                    var queryString = '<%=Request.Params["edit"] %>';

                                    if (queryString == "edit") {
                                        TotalRow = document.getElementById("<%=hid_Rows_On_Edit.ClientID %>").value;
                                        TotalRow = document.getElementById("PriceTable").rows.length;
                                    }

                                    function Remove_Row(index) {
                                        TotalRow = document.getElementById("PriceTable").rows.length;
                                        var NoOfRows = 0;
                                        for (var i = 0; i < TotalRow; i++) {
                                            if (document.getElementById("div_row_" + i + "") != null) {
                                                NoOfRows++;
                                            }
                                        }
                                        if (NoOfRows < 2) {
                                            alert('<%=objlang.GetLanguageConversion("Matrix_Price_Delete_Alert") %>');
                                            return false;
                                        }
                                        NoOfRows = NoOfRows - 1;
                                        if (NoOfRows < 150) {
                                            document.getElementById("href_add_more").style.display = "block";
                                        }
                                        else {
                                            document.getElementById("href_add_more").style.display = "none";
                                        }
                                        var obj = document.getElementById("PriceTable");

                                        var Child_Obj = document.getElementById("td_" + index + "");
                                        var spn_matrixID = document.getElementById("spn_matrixID_" + index + "").innerHTML;
                                        AutoFill.Delete_OtherCost_Mtrix(Number(spn_matrixID), GetResult, onTimeout, onError);
                                        Child_Obj.innerHTML = "";
                                    }

                                    function GetResult(result) {

                                    }
                                    function onTimeout(request, context) {
                                    }
                                    function onError(objError) {

                                    }

                                    function Click_Add_More() {

                                        var Data = '';
                                        TotalRow = document.getElementById("PriceTable").rows.length;
                                        Data = CreateRow(TotalRow, "", "0", "0", Data, ddlMatrixType.value);
                                        var row = document.createElement("tr");
                                        var cell = document.createElement("td");
                                        cell.id = "td_" + TotalRow + "";
                                        cell.innerHTML = Data;
                                        row.appendChild(cell);
                                        document.getElementById("PriceTable").appendChild(row);

                                        var CheckMax = 0;
                                        for (var i = 0; i < TotalRow; i++) {
                                            if (document.getElementById("div_row_" + i + "") != null) {
                                                CheckMax++;
                                            }
                                        }
                                        if (CheckMax < Max) {
                                            document.getElementById("href_add_more").style.display = "block";
                                        }
                                        else {
                                            document.getElementById("href_add_more").style.display = "none";
                                        }
                                    }
                                    //=======================   This will creates the Price Matrix   =============================
                                    CreateTable();

                                    function CalculateSellPrice(obj, index, type) {

                                        if (type == 'cost') {
                                            var txtMarkup = document.getElementById("txtMarkup_" + index + "");
                                            var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");

                                            if (!isNaN(obj.value)) {
                                                if (!isNaN(txtMarkup.value)) {
                                                    var MarkupValue = (txtMarkup.value * obj.value) / 100;
                                                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(obj.value), 3, '', false, false, false);
                                                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 3, '', false, false, false);


                                                    obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 3, '', false, false, false);

                                                }
                                            }
                                            else {
                                                obj.value = "0.00";
                                                txtSellingPrice.value = "0.000";
                                            }
                                        }
                                        else {
                                            var txtCost = document.getElementById("txtCost_" + index + "");
                                            var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");
                                            if (!isNaN(obj.value)) {
                                                if (!isNaN(txtCost.value)) {
                                                    var MarkupValue = (obj.value * txtCost.value) / 100;
                                                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 3, '', false, false, false);
                                                    txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 3, '', false, false, false);
                                                    obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);

                                                }
                                                else {
                                                    txtSellingPrice.value = "0.000";
                                                }
                                            }
                                            else {
                                                obj.value = "0.00";
                                            }
                                        }
                                        //txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 3, '', false, false, false);
                                    }


                                    var Max = 150;
                                    var CheckAnyBug = false;
                                    function QuantityCheck(val, index) {
                                        TotalRow = document.getElementById("PriceTable").rows.length;
                                        var queryString = '<%=Request.Params["type"] %>';
                                        if (queryString == "edit") {
                                            var p = Number(index) + 1;
                                            for (var i = 0; i < index; i++) {
                                                if (document.getElementById("txtQty_" + i + "") != null) {
                                                    var preValue = document.getElementById("txtQty_" + i + "").value;
                                                }
                                            }
                                        }
                                        else {
                                            if (!isNaN(val) && val != '') {
                                                var p = Number(index) + 1;
                                                for (var i = 0; i < index; i++) {
                                                    if (document.getElementById("div_row_" + i + "") != null) {
                                                        var preValue = document.getElementById("txtQty_" + i + "").value;
                                                    }
                                                }
                                                for (var i = p; i < TotalRow; i++) {
                                                    try {
                                                        if (document.getElementById("txtQty_" + i + "") != null) {
                                                            var Pre_index = Number(i) - 1;
                                                            if (document.getElementById("txtQty_" + Pre_index + "") != null) {
                                                                var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                                                txt_Previous_value = Number(txt_Previous_value) + 100;
                                                                document.getElementById("txtQty_" + i + "").value = txt_Previous_value;
                                                                document.getElementById("txtQty_from_" + i + "").value = Number(txt_Previous_value) - 100 + 1;
                                                            }
                                                        }
                                                    }
                                                    catch (err) { }
                                                }
                                            }
                                            else {
                                                document.getElementById("txtQty_" + index + "").value = "0";
                                            }
                                        }
                                    }
                                    function Check_Qty_From(index, val) {
                                        if (!isNaN(val) && val != 0) {
                                            for (var i = 0; i < index; i++) {
                                                if (document.getElementById("txtQty_from_" + i + "") != null) {
                                                    var preValue = document.getElementById("txtQty_from_" + i + "").value;
                                                    if (Number(val) < Number(preValue)) {
                                                        alert('Please re-check the Quantity');
                                                        var OldNum = Number(Number(index) - Number(1));
                                                        if (document.getElementById("txtQty_" + OldNum + "") != null) {
                                                            var BelowValue = document.getElementById("txtQty_" + OldNum + "").value;
                                                            document.getElementById("txtQty_from_" + index + "").value = Number(Number(BelowValue) + Number(1));
                                                        }
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                        else {
                                            document.getElementById("txtQty_from_" + index + "").value = 0;
                                        }
                                    }
                                </script>
                            </div>
                        </div>
                        <div class="only10px">
                        </div>
                        <div class="only10px">
                        </div>
                        <div class="only10px">
                        </div>
                    </div>
                </fieldset>
            </div>
            <div style="width: 100%">
                <div style="width: 70%; float: left;">
                    &nbsp;
                </div>
                <div style="float: left" nowrap="nowrap">
                    <div style="float: left">
                        <div id="div_btndelete" style="display: block">
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" Visible="false"
                                OnClick="btnDelete_OnClick" />
                        </div>
                        <div id="div_deleteprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <div style="display: block">
                            <asp:Button ID="btnCancel" runat="server" Text="" CssClass="button" OnClientClick="javascript:var a=cancelClick(path+'ProductCatalogue/OtherCost_webStore_View.aspx');loadingimage(this.id,'div_btncancelprocess');return a;"></asp:Button><%--PostBackUrl="~/Settings/othercost_view.aspx"--%>
                        </div>
                        <div id="div_btncancelprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <div id="div_btnsave" style="display: block">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                OnClick="btnSave_OnClick" /><%--OnClientClick="javascript:return CallValidation();SaveFinal()"--%>
                            <asp:HiddenField ID="hidQtyPrice" Value="" runat="server" />
                            <asp:HiddenField ID="hid_MultipleChoiceValue" runat="server" Value="" />
                            <asp:HiddenField ID="hid_RemoveChoiceValue" runat="server" Value="adsfadad" />
                        </div>
                        <div id="div_btnsaveprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <div id="div_btnsaveandstay" style="display: block">
                            <asp:Button ID="btnsaveStay" runat="server" Text="Save & Stay" CssClass="button"
                                OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_btnsaveandstayprocess');return a;"
                                OnClick="btnsaveStay_OnClick" />
                        </div>
                        <div id="div_btnsaveandstayprocess" class="button" align="center" style="width: 77px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div style="clear: both; padding-bottom: 4px">
                <input type="hidden" id="hdntype" value="0" />
                <input type="hidden" id="hdnresult" value="" />
                <input type="hidden" id="hdnexp" value="(" />
                <input type="hidden" id="hdnprevious" value="0" />
                <input type="hidden" id="hdnprevfieldtype" value="0" />
                <asp:HiddenField ID="hdn_Formula" runat="server" Value="" />
                <asp:HiddenField ID="hid_FormulaTag" runat="server" Value="" />
            </div>
        </div>
        <%--  </div>--%>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
            Top="30px" Left="5px" Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" language="javascript">
        var type = '<%=Request.Params["type"] %>';
        var txtNameID = document.getElementById("<%=txtName.ClientID %>");
        var txtUserfriendlyID = document.getElementById("<%=txtUserfriendly.ClientID %>");
        var ddlCategoryID = document.getElementById("<%=ddlCategory.ClientID %>");
        var ddlMainCalculationID = document.getElementById("<%=ddlMainCalculation.ClientID %>");
        var hidQtyPrice = document.getElementById("<%=hidQtyPrice.ClientID %>");
        var hid_MultipleChoiceValue = document.getElementById("<%=hid_MultipleChoiceValue.ClientID %>");
        var txtQuestionID = document.getElementById("<%=txtQuestion.ClientID %>");
        var txtFormulaID = document.getElementById("<%=txtFormula.ClientID %>");

        var div_multiple = document.getElementById("div_multiple");
        var div_single = document.getElementById("div_single");
        var div_matrix = document.getElementById("div_Matrix");

        var txtOtherCostCategoryName = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>");

        var ddlCategory = document.getElementById("<%=ddlCategory.ClientID %>");
        var btnCategorySave = document.getElementById("<%=btnCategorySave.ClientID %>");
        var hid_RemoveChoiceValue = document.getElementById("<%=hid_RemoveChoiceValue.ClientID %>");

        if (Mode == "edit") {
            if (ddlCalculationType.options[ddlCalculationType.selectedIndex].value == "quantity") {
                document.getElementById("div_btnImportInventory").style.display = "none";
            }
        }

        var ddlMainCalculationType = document.getElementById("ctl00_ContentPlaceHolder1_ddlMainCalculation");


    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/item/othercost_webstore.js?VN='<%=VersionNumber%>'"></script>
    <asp:Panel ID="pnl_OnLoadEdit" runat="server" Visible="false">
        <script type="text/javascript">
            var chkMandatory = document.getElementById("<%=chkMandatory.ClientID %>");
            function OnLoadEdit() {
                onchange_option(ddlMainCalculationID.value);
                disableOptions(chkMandatory);
            }
            OnLoadEdit();
        </script>
    </asp:Panel>
</asp:Content>
