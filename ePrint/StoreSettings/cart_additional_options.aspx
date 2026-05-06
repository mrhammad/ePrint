<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true"  CodeBehind="cart_additional_options.aspx.cs" Inherits="ePrint.StoreSettings.cart_additional_options" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var Category_ID = "no";
        var DecimalValue = 0;
        var Mode = '<%=action %>';
        var AccountID = '<%=AccountID %>';       
    </script>
    <script type="text/javascript">
        var strImagepath = "<%=strImagepath%>";
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);
    </script>
    <asp:ScriptManagerProxy ID="SMP" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <!--POPUP START-->
    <div>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div style="float: left;" class="estore_settingBox">
        <UC:Header ID="header" runat="server" />
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Shopping_Cart_Additional_Option")%>
                                    <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                        href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                        <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                    </a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="div_Main" class="" style="width: 100%; padding-left: 5px; height: 100%">
            <div>
                <div align="left">
                    <div style="width: 65%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div align="left" style="width: 100%; padding-left: 6px;" class="mis_header_panel">
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Name")%></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtName" runat="server" Width="100%" CssClass="textboxnew" MaxLength="200"
                                    onblur="javascript:CopyName_toUserFriendlyname();"></asp:TextBox>
                                <%--findduplicate(this.value);--Ref Bug ID:653--%>
                                <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Name")%>
                                </span><span id="spn_alreadyExist" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                    <%=objLanguage.GetLanguageConversion("Name_Already_Exists")%></span>
                            </div>
                            <div class="bglabel">
                                <asp:Label ID="Label19" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtUserfriendly" runat="server" Width="100%" CssClass="textboxnew"
                                    MaxLength="200"></asp:TextBox>
                                <span id="spn_txtUserfriendly" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_User_Friendly_Name")%></span>
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
                                            <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div style="float: right;">
                                            <a onclick="AddCategory('add')">
                                                <img src="<%=strImagepath %>plus.gif" border="0px" style="cursor: pointer" />
                                            </a>
                                        </div>
                                    </div>
                                    <div class="box" style="width: 55%;">
                                        <div id="div_OtherCost_add_item" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 35%"
                                            align="center">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td colspan="2" class="popup-top-leftcorner">&nbsp;
                                                    </td>
                                                    <td class="popup-top-middlebg">
                                                        <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                                            <b>
                                                                <%=objLanguage.GetLanguageConversion("Category_Name")%>
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
                                                        <div style="padding: 10px 5px 10px 0px; width: 98%">
                                                            <div class="" style="width: 100%">
                                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div align="left">
                                                                                <div class="bglabel">
                                                                                    <span class="normaltext">
                                                                                        <%=objLanguage.GetLanguageConversion("Category_Name")%></span>
                                                                                </div>
                                                                                <div class="box">
                                                                                    <asp:TextBox ID="txtOtherCostCategoryName" SkinID="textPad" Width="175px" runat="server"
                                                                                        MaxLength="50" onblur="findduplicatenew(this.value);"></asp:TextBox>
                                                                                    <span id="spn_txtOtherCostCategoryName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Category_Name")%></span><span
                                                                                            id="spn_alreadyExistCategory" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                                            <%=objLanguage.GetLanguageConversion("Category_Name_Already_Exists")%></span>
                                                                                </div>
                                                                            </div>
                                                                            <div align="left">
                                                                                <div class="bglabel">
                                                                                    <asp:Label ID="Label6" CssClass="normaltext" runat="server"><%=objLanguage.GetLanguageConversion("Job_Card_Category")%></asp:Label>
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
                                                                                    <span id="Span3" class="smallgraytext" style="display: block; width: 250px">(<%=objLanguage.GetLanguageConversion("Please_Specify_Where_You_Would_Like_This_Category_To_Appear_On_The_Job_Card")%>)
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
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Category")%></span>
                                        <asp:HiddenField ID="hid_CategoryID" runat="server"></asp:HiddenField>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label9" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Calculation_Type")%></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="ddlsetting" style="width: 55%;">
                                <asp:DropDownList runat="server" ID="ddlMainCalculation" CssClass="normalText" Width="100%"
                                    onchange="javascript:onchange_option(this.value);">
                                </asp:DropDownList>
                                <span id="spn_ddlMainCalculation" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Calculation_Type")%></span>
                                <asp:HiddenField ID="hid_CalculationType" runat="server" Value="0" />
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lblCost" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Cost_Mandatory")%></asp:Label>
                            </div>
                            <div class="checkboxstoresetting">
                                <div>
                                    <asp:CheckBox ID="chkCost" runat="server" OnClick="ChkCostdisable()" />
                                </div>
                                <div style="padding-left: 3px;">
                                    <asp:Label ID="lblnote" runat="server" CssClass="smallerfontgrey" Text="Note: If this cost is mandatory the first label must not have a cost allocated to it"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div align="left" runat="server" id="div_AccountCode">
                            <div class="bglabel">
                                <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label>
                            </div>
                            <div class="ddlsetting" style="width: 55%;">
                                <asp:DropDownList ID="ddlAccountCode" runat="server" CssClass="normalText" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div align="left" id="div_chkApplyToOthers" runat="server">
                            <div>
                            </div>
                            <div class="ddlsetting" style="width: 56%;">
                                <div style="float: left;">
                                    <asp:CheckBox ID="chkApplyToOthers" runat="server" Checked="true" Style="margin-left: -3px;" />
                                </div>
                                <div style="padding-top: 3px;">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Cart_Additional_Option_ApplyToOthers_Checkbox_Text")%></span>
                                    <%--Apply the change to all other accounts where the above cost is used--%>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel" style="height: 88px">
                                <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%= objLanguage.GetLanguageConversion("Help_Text")%></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtDescription" runat="server" Width="100%" CssClass="textboxnew"
                                    TextMode="MultiLine" Rows="3" MaxLength="1000" Height="84px" SkinID="textPad"
                                    onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                    <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%></span>
                            </div>
                        </div>
                        <div id="Div1" align="left" runat="server">
                            <div class="bglabel">
                                <asp:Label ID="Label4" runat="server" Text="Visible To Shopping Cart" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Visible_To_Shopping_Cart")%></asp:Label>
                            </div>
                            <div class="box">
                                <asp:CheckBox ID="chkVisibletoCart" runat="server" Checked="true" />
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div style="width: 99%; display: block;" align="left">
                    <fieldset>
                        <legend><span id="spn_option">
                            <%=objLanguage.GetLanguageConversion("Simple_Single_Question")%></span></legend>
                        <div class="only5px">
                        </div>
                        <div id="div_single" align="left" style="display: none">
                            <div align="left" style="width: 100%;">
                                <div class="normalText" style="width: 100%; padding-left: 5px;">
                                    <%=objLanguage.GetLanguageConversion("Enter_The_Question")%>
                                </div>
                                <div align="left" style="float: left; width: 100%;">
                                    <div class="box">
                                        <asp:TextBox ID="txtQuestion" runat="server" Width="80%" CssClass="textboxnew" TextMode="MultiLine"
                                            MaxLength="250"></asp:TextBox>
                                        <span id="spn_txtQuestion" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_The_Question")%></span>
                                        <div class="only10px">
                                        </div>
                                        <div class="only5px">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left" style="width: 100%;">
                                <div class="normalText" style="width: 100%; padding-left: 5px;">
                                    <%=objLanguage.GetLanguageConversion("Formula")%>
                                </div>
                                <div align="left" style="float: left; width: 100%;">
                                    <div class="box">
                                        <asp:TextBox ID="txtFormula" runat="server" Width="80%" CssClass="textboxnew" TextMode="MultiLine"
                                            MaxLength="250"></asp:TextBox>
                                        <span id="spn_txtFormula" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_The_Formula")%></span>
                                    </div>
                                </div>
                                <div class="only5px">
                                </div>
                                <div class="only5px">
                                </div>
                            </div>
                            <div>
                                <span class="graytext">
                                    <%=objLanguage.GetLanguageConversion("Formula_Tags")%>
                                    : [<%=objLanguage.GetLanguageConversion("TotalEx_GST")%>], [<%=objLanguage.GetLanguageConversion("TotalInc_GST")%>],
                                    [<%=objLanguage.GetLanguageConversion("TotalQty")%>],
                                        [<%=objLanguage.GetLanguageConversion("TotalNoOfCartItems")%>] </span>
                            </div>
                        </div>
                        <div id="div_multiple" align="left" style="display: none">
                            <div style="border: 0px solid" align="center">
                                <div style="float: left; width: 300px;">
                                    &nbsp;
                                </div>
                                <div align="center" id="diverrorMessage" style="width: 40%; padding: 3px; float: left">
                                    <span id="spn_MultipleChoice" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Value_For_Atlest_One_Row")%></span>
                                </div>
                            </div>
                            <div class="onlyEmpty" style="width: 70%">
                                <div class="bglabel">
                                    <%=objLanguage.GetLanguageConversion("Calculation_Type")%>
                                </div>
                                <div class="box" style="width: 55%;">
                                    <asp:DropDownList ID="ddlCalculationType" onchange="Onchange_calculationType(this.value);"
                                        CssClass="normalText" runat="server" Width="95%">
                                        <asp:ListItem Selected="True" Text="Fixed Value" Value="fixed"></asp:ListItem>
                                        <asp:ListItem Text="Formula" Value="quantity"></asp:ListItem>
                                    </asp:DropDownList>
                                    <script>
                                        var ddlCalculationType = document.getElementById("<%=ddlCalculationType.ClientID %>");                                          
                                    </script>
                                </div>
                                <%--    <div>
                                    <asp:CheckBox ID="chkCost" Text="The cost is mandatory" runat="server" OnClick="ChkCostdisable()" />
                                </div>--%>
                            </div>
                            <%--  <div class="only5px">
                            </div>
                            <div class="onlyEmpty" style="width: 100%">
                                <asp:Label ID="lblnote" runat="server" Style="margin-left: 59.5%" Width="35%" CssClass="smallerfontgrey"
                                    Text="Note: If this cost is mandatory the first label must not have a cost allocated to it"></asp:Label>
                            </div>--%>
                            <div class="only5px">
                            </div>
                            <div style="float: left; width: 98%">
                                <div align="left" class="borderWithoutTop" style="width: 100%;">
                                    <table cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
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
                                                    <%=objLanguage.GetLanguageConversion("Add_More_Label")%></a>
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
                                        <%=objLanguage.GetLanguageConversion("Formula_Tags")%>: [<%=objLanguage.GetLanguageConversion("TotalInc_GST")%>],
                                        [<%=objLanguage.GetLanguageConversion("TotalEx_GST")%>], [<%=objLanguage.GetLanguageConversion("TotalQty")%>],
                                        [<%=objLanguage.GetLanguageConversion("TotalNoOfCartItems")%>]
                                    <%--[$TotalInc.GST$],--%>
                                </div>
                                <script>
                                    function CreateHeaderMultiple() {
                                        var uniData = "";
                                        uniData += "<div nowarp='nowrap' style='width:100%;background-color: #DDDDDD;border:solid 0px red;' align='center'>";

                                        uniData += "<table style='width:100%;' cellpadding='3px' cellspacing='3px' border='0px' >";
                                        uniData += "<tr>";
                                        uniData += "<td style='width: 30%;' align='left'>";

                                        uniData += '<%=objLanguage.GetLanguageConversion("Label") %>';
                                        uniData += "</td>";


                                        uniData += "<td style='width: 38%;' align='left'>";
                                        uniData += '<span id="spn_FrmOrValue"><%=objLanguage.GetLanguageConversion("Cost") %></span>';
                                        uniData += "</td>";

                                        uniData += "<td style='width: 15%;' align='center'>";
                                        uniData += '<span><%=objLanguage.GetLanguageConversion("Markup") %> (%)</span>';
                                        uniData += "</td>";

                                        uniData += "<td id='td_sellingprice' style='width: 15%;' align='left'>";
                                        if (ddlCalculationType.options[ddlCalculationType.selectedIndex].value == "fixed") {
                                            uniData += "<span id='spn_sellingprice'><%=objLanguage.GetLanguageConversion("Selling_Price") %> (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)</span>";
                                        }
                                        uniData += "</td>";

                                        uniData += "<td style='width: 2%;' align='center'>";
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
                                                        document.getElementById("MultipleQuestion").appendChild(row_1);
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

                                                    document.getElementById("MultipleQuestion").appendChild(row_1);
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

                                        if (ddlCalculationType.value != "quantity") {
                                            fixed_or_qty = DecimalValue;
                                            qtyonblur = "onblur = 'CalculateMultipleSellPrice(this," + i + ")'";
                                            maxlength = "200";
                                        }
                                        else {
                                            fixed_or_qty = "";
                                            maxlength = "1000";
                                        }


                                        uniData += "<td style='width: 38%;' align='left'>";
                                        uniData += "<input id='txtfixed_or_qty_" + i + "' type='text' maxlength='" + maxlength + "' style='width:400px;text-align:left;' " + qtyonblur + " class='textboxnew' value='" + fixed_or_qty + "'/>";
                                        uniData += "<input type='hidden' name='IsMandatoryField' id='hdn_IsMandatoryField_" + i + "' value='0'>";
                                        uniData += "</td>";

                                        uniData += "<td style='width: 15%;' align='center'>";
                                        var Multiple_AssignOnBlur = "";
                                        if (i == 0) {
                                            Multiple_AssignOnBlur = "onblur=SetMarkupToAllMultiple(this,'" + i + "');Onbur_MultipleMarkup(this,'" + i + "');todecimal_function(this,this.value);";
                                        }
                                        else {
                                            Multiple_AssignOnBlur = "onblur=Onbur_MultipleMarkup(this,'" + i + "');todecimal_function(this,this.value);";
                                        }

                                        uniData += "<input id='txtMarkup_multiple_" + i + "' " + Multiple_AssignOnBlur + " type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
                                        uniData += "</td>";


                                        uniData += "<td id='td_txtsellingprice_" + i + "' style='width: 15%;' align='left'>";
                                        var MarkupVisible = '';
                                        if (ddlCalculationType.value != "quantity") {
                                            MarkupVisible = "style='width:80px;text-align:right;display:block;'";
                                        }
                                        else {
                                            MarkupVisible = "style='width:80px;text-align:right;display:none;'";
                                        }
                                        uniData += "<input id='txt_sellingprice_" + i + "' onblur=Calculate_MultipleMarkup(this,'" + i + "'); type='text' maxlength='20' " + MarkupVisible + "  class='textboxnew' value='" + DecimalValue + "'/>";
                                        uniData += "<span id='spn_choiceID_" + i + "' style='display:none;'>" + 0 + "</span>";

                                        uniData += "<span id='spn_InventoryID_" + i + "' style='display:none;'>" + 0 + "</span>";

                                        uniData += "</td>";

                                        uniData += "<td style='width: 2%;' align='center'>";
                                        if (i == 0) {
                                            uniData += "<span align='right' style='color: Red;'>*</span>";
                                        }
                                        else {
                                            uniData += "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row_New(" + i + "); />";
                                        }
                                        uniData += "</td>";



                                        uniData += "</tr>";
                                        uniData += "</table>";

                                        uniData += "</div>";
                                        uniData += "</div>";

                                        return uniData;
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
                                                        if (document.getElementById("txt_sellingprice_" + i + "") != null) {
                                                            document.getElementById("txt_sellingprice_" + i + "").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(SellingPrice), 0, '', false, false, false);
                                                        }
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
                                    Price Matrix Type
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
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                                            <tbody id="PriceTable">
                                                <asp:PlaceHolder ID="plhCatalogue" runat="server"></asp:PlaceHolder>
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
                                                    <a id="href_add_more" name="addmore" style="display: none;" href='#addmore' onclick="Click_Add_More()">Add More</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <script>
                                        function CreateHeader() {
                                            var uniDataPrice = "";
                                            uniDataPrice += "<div nowarp='nowrap' style='width:100%;border:solid 0px red;' align='center'>";

                                            uniDataPrice += "<table style='width:100%;background-color: #DDDDDD;' cellpadding='3px' cellspacing='3px' border='0px' >";
                                            uniDataPrice += "<tr>";
                                            uniDataPrice += "<td style='width: 24%;' align='center'>";

                                            uniDataPrice += "Quantity";
                                            uniDataPrice += "</td>";

                                            uniDataPrice += "<td style='width: 20%;' align='center'>";
                                            uniDataPrice += "<span id='spn_cost'>Cost For 1 (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)</span>";
                                            uniDataPrice += "</td>";



                                            uniDataPrice += "<td style='width: 20%;' align='center'>";
                                            uniDataPrice += "    Markup (%)";
                                            uniDataPrice += "</td>";

                                            uniDataPrice += "<td style='width: 24%;' align='center'>";
                                            uniDataPrice += "<span id='spn_header_sellingprice'>Selling Price For 1 (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)</span>";
                                            uniDataPrice += "</td>";
                                            uniDataPrice += "<td align='center'>";
                                            uniDataPrice += "    Action";
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
                                                            var cell_1 = document.createElement("td");
                                                            cell_1.id = "td_header";
                                                            cell_1.innerHTML = CreateHeader();
                                                            row_1.appendChild(cell_1);
                                                            document.getElementById("PriceTable").appendChild(row_1);
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

                                                if (ddlMatrixType.value == "pricebands") {
                                                    document.getElementById("spn_cost").innerHTML = "Cost For 1 (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)";
                                                    document.getElementById("spn_header_sellingprice").innerHTML = "Selling Price For 1 (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)";
                                                }
                                                else if (ddlMatrixType.value == "simplematrix") {
                                                    document.getElementById("spn_cost").innerHTML = "Cost (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)";
                                                    document.getElementById("spn_header_sellingprice").innerHTML = "Pack Selling Price (<%=objcom.GetCurrencyinRequiredFormate("",true) %>)";
                                                }
                                        }
                                        Take_Data_DB();
                                        </script>
                                    </asp:Panel>
                                    <script language="javascript" type="text/javascript">

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

                                                        document.getElementById("PriceTable").appendChild(row_1);
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
                                            uniDataPrice += "</div>";
                                            uniDataPrice += "<div style='float: left; padding-right:5px;'>";
                                            uniDataPrice += "<span id='spn_qty_sep_" + i + "' style='" + IsDisplay + "'>-</span>";
                                            uniDataPrice += "</div>";
                                            uniDataPrice += "<div id='div_txtQty_" + i + "' style='float: left; width: " + ChangeDivWidth + ";' >";
                                            uniDataPrice += "<input id='txtQty_" + i + "' onblur='QuantityCheck(this.value," + i + ");' onkeyup='ToInteger(this,this.value);' '  maxlength=7 type='text' style='width:80px;text-align:right;' value='" + txtValue + "'  class='textboxnew' />"; //
                                            uniDataPrice += "</div>";


                                            uniDataPrice += "</td>";
                                            uniDataPrice += "<td style='width: 20%;border:0px solid red' align='center'>";

                                            uniDataPrice += "<input id='txtCost_" + i + "' type='text' onblur=CalculateSellPrice(this," + i + ",'cost'); maxlength='20' style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "'/>";

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

                                            uniDataPrice += "<input id='txtSellingPrice_" + i + "' onblur=Calculate_Markup(this," + i + "); type='text' maxlength='20'  style='width:80px;text-align:right;' class='textboxnew' value='" + DecimalValue + "' />";
                                            uniDataPrice += "<span id='spn_matrixID_" + i + "' style='display:none;'>" + 0 + "</span>";


                                            uniDataPrice += "</td>";
                                            uniDataPrice += "<td align='center'>";


                                            uniDataPrice += "<div align='center'>";
                                            uniDataPrice += "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(" + i + "); />";
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
                                        }

                                        function Remove_Row(index) {

                                            var NoOfRows = 0;
                                            for (var i = 0; i < TotalRow; i++) {
                                                if (document.getElementById("div_row_" + i + "") != null) {
                                                    NoOfRows++;
                                                }
                                            }
                                            if (NoOfRows < 2) {
                                                alert('Price Matrix should have at least one row !');
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
                                                    //AutoFill.Delete_OtherCost_Choice(WebOtherCostid, Number(ChoiceID));
                                                }
                                            }
                                            var Child_Obj = document.getElementById("td_multiple_" + index + "");
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
                                            Data = CreateRow(TotalRow, "", "0", "0", Data, ddlMatrixType.value);
                                            var row = document.createElement("tr");
                                            var cell = document.createElement("td");
                                            cell.id = "td_" + TotalRow + "";
                                            cell.innerHTML = Data;
                                            row.appendChild(cell);
                                            document.getElementById("PriceTable").appendChild(row);

                                            TotalRow++;
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
                                                        txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(obj.value), 0, '', false, false, false);
                                                        txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 0, '', false, false, false);


                                                        obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);

                                                    }
                                                }
                                                else {
                                                    obj.value = "0.00";
                                                    txtSellingPrice.value = "0.00";
                                                }
                                            }
                                            else {
                                                var txtCost = document.getElementById("txtCost_" + index + "");
                                                var txtSellingPrice = document.getElementById("txtSellingPrice_" + index + "");
                                                if (!isNaN(obj.value)) {
                                                    if (!isNaN(txtCost.value)) {
                                                        var MarkupValue = (obj.value * txtCost.value) / 100;
                                                        txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(MarkupValue) + Number(txtCost.value), 0, '', false, false, false);
                                                        txtSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtSellingPrice.value, 0, '', false, false, false);
                                                        obj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, obj.value, 0, '', false, false, false);

                                                    }
                                                    else {
                                                        txtSellingPrice.value = "0.00";
                                                    }
                                                }
                                                else {
                                                    obj.value = "0.00";
                                                }
                                            }
                                        }


                                        var Max = 150;
                                        var CheckAnyBug = false;
                                        function QuantityCheck(val, index) {

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
                    <div style="width: 70.5%; float: left;">
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
                            <div id="div_btncancel" style="display: block">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClientClick="javascript:var a=cancelClick(path+'storesettings/cart_additional_options_view.aspx');loadingimage(this.id,'div_cancelprocess');return a;" /><%--PostBackUrl="~/Settings/othercost_view.aspx"--%>
                            </div>
                            <div id="div_cancelprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div id="div_btnsave" style="display: block">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                    OnClick="btnSave_OnClick" /><%--OnClientClick="javascript:return CallValidation();SaveFinal();"--%>
                            </div>
                            <div id="div_btnsaveprocess" class="button" align="center" style="width: 35px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                            <asp:HiddenField ID="hidQtyPrice" Value="" runat="server" />
                            <asp:HiddenField ID="hid_MultipleChoiceValue" runat="server" Value="" />
                            <asp:HiddenField ID="hid_RemoveChoiceValue" runat="server" Value="" />
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div id="div_savestay" style="display: block">
                                <asp:Button ID="btnsaveStay" runat="server" Text="Save & Stay" CssClass="button"
                                    OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_savestayprocess');return a;"
                                    OnClick="btnsaveStay_OnClick" />
                            </div>
                            <div id="div_savestayprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        <%--<div style="float: left; width: 10px">
                            &nbsp;
                        </div>--%>

                        <%--<div style="float: left">
                            <div id="div_btndelete" style="display: block">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" Visible="false"
                                    OnClick="btnDelete_OnClick" />
                            </div>
                            <div id="div_deleteprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>--%>
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
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
            Top="30px" Left="5px" Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" language="javascript">

        var txtNameID = document.getElementById("<%=txtName.ClientID %>");
        var txtUserfriendlyID = document.getElementById("<%=txtUserfriendly.ClientID %>");
        var ddlCategoryID = document.getElementById("<%=ddlCategory.ClientID %>");
        var ddlMainCalculationID = document.getElementById("<%=ddlMainCalculation.ClientID %>");
        var hidQtyPrice = document.getElementById("<%=hidQtyPrice.ClientID %>");
        var hid_MultipleChoiceValue = document.getElementById("<%=hid_MultipleChoiceValue.ClientID %>");
        var hid_RemoveChoiceValue = document.getElementById("<%=hid_RemoveChoiceValue.ClientID %>");
        var txtQuestionID = document.getElementById("<%=txtQuestion.ClientID %>");
        var txtFormulaID = document.getElementById("<%=txtFormula.ClientID %>");
        var div_multiple = document.getElementById("div_multiple");
        var div_single = document.getElementById("div_single");
        var div_matrix = document.getElementById("div_Matrix");
        var txtOtherCostCategoryName = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>");
        var ddlCategory = document.getElementById("<%=ddlCategory.ClientID %>");
        var btnCategorySave = document.getElementById("<%=btnCategorySave.ClientID %>");
        var chkcost = document.getElementById("<%=chkCost.ClientID %>");
        var txtname = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>").value;
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/item/cart_additional_options.js?VN='<%=VersionNumber%>'"></script>
    <asp:Panel ID="pnl_OnLoadEdit" runat="server" Visible="false">
        <script type="text/javascript">
            function OnLoadEdit() {
                onchange_option(ddlMainCalculationID.value);
            }
            OnLoadEdit();
            ChkCostdisable();
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

