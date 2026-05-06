<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="othercost_add.aspx.cs" Inherits="ePrint.settings.othercost_add" title="Setting: User Defined Cost Centres" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var Category_ID = "no";
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div align="left">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Other_Cost")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="div_Main" style="width: 100%; height: 100%" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div class="mis_header_panel">
                <div align="left">
                    <div style="width: 65%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div align="left" style="width: 100%;">
                    <div style="width: 49%; float: left;">
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Name")%></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtName" runat="server" Width="100%" CssClass="textboxnew" onblur="findduplicate(this.value);"
                                    MaxLength="100"></asp:TextBox><%--CallonBlur(this.value,'spn_txtName');--%>
                                <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                    padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Other_Cost_Name")%>
                                </span><span id="spn_alreadyExist" class="spanerrorMsg" style="display: none; width: auto;
                                    padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                    <%=objlang.GetValueOnLang("Other Cost Name already exists")%></span>
                            </div>
                            <script>
                                function findduplicate(name) {
                                    var compID = '<%=CompanyID %>';
                                    var OtherCostid = '<%=OtherCostID %>';
                                    var val = compID + "±" + name + "±" + OtherCostid;
                                    PageMethods.FindDuplicate(val, FindSuccNew, ShowMsg_Failure);
                                }
                                function ShowMsg_Failure(error) { }
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
                            <div class="bglabel" style="height: 84px">
                                <asp:Label ID="Label3" runat="server" CssClass="normaltext"></asp:Label><%=objLanguage.GetLanguageConversion("Description")%></div>
                            <div class="box">
                                <asp:TextBox ID="txtDescription" runat="server" Width="99.2%" CssClass="textboxnew"
                                    TextMode="MultiLine" Rows="2" Height="80px" SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: auto;
                                    padding-left: 4px; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Max. length of textbox is")%>: 3000</span>
                            </div>
                        </div>
                        <div align="left">
                            <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Category")%></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div style="float: right; vertical-align: top">
                                            <a onclick="AddCategory('add')">
                                                <img src="<%=strImagepath %>plus.gif" border="0px" style="cursor: pointer" />
                                            </a>
                                        </div>
                                    </div>
                                    <div id="div_mask">
                                    </div>
                                    <div class="box" style="width: 55%;">
                                        <div id="div_OtherCost_add_item" style="display: none; position: absolute; vertical-align: middle;
                                            z-index: 100; width: 45%" align="center">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td colspan="2" class="popup-top-leftcorner">
                                                        &nbsp;
                                                    </td>
                                                    <td class="popup-top-middlebg">
                                                        <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                                                            padding-left: 1px">
                                                            <b>
                                                                <%=objLanguage.GetLanguageConversion("Category_Name")%></b>
                                                            <asp:Label ID="Label6" runat="server"></asp:Label></div>
                                                        <div style="float: right; padding-top: 6px; padding-right: 10px">
                                                            <div class="CancelButtonDiv">
                                                                <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                                    runat="server" CausesValidation="false" OnClientClick="AddCategory('close');return false;" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td colspan="2" class="popup-top-rightcorner">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="popup-middle-leftcorner">
                                                        &nbsp;
                                                    </td>
                                                    <td style="width: 15px; background-color: #ffffff">
                                                        &nbsp;
                                                    </td>
                                                    <td class="popup-middlebg" align="center">
                                                        <div style="padding: 10px 5px 10px 0px; width: 98%">
                                                            <div class="" style="width: 100%">
                                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <div align="left" style="background-color: white; padding: 2px;">
                                                                                <div class="only5px">
                                                                                </div>
                                                                                <div align="left">
                                                                                    <div class="bglabel">
                                                                                        <span class="normaltext">
                                                                                            <%=objLanguage.GetLanguageConversion("Category_Name")%></span>
                                                                                    </div>
                                                                                    <div class="box">
                                                                                        <asp:TextBox ID="txtOtherCostCategoryName" SkinID="textPad" Width="175px" runat="server"
                                                                                            MaxLength="50" onblur="findduplicatenew(this.value);"></asp:TextBox>
                                                                                        <span id="spn_txtOtherCostCategoryName" class="spanerrorMsg" style="display: none;
                                                                                            width: auto; padding-left: 4px; padding-right: 4px;">
                                                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Category_Name")%></span><span
                                                                                                id="spn_alreadyExistCategory" class="spanerrorMsg" style="display: none; width: auto;
                                                                                                padding-left: 4px; padding-right: 4px;">
                                                                                                <%=objlang.GetValueOnLang("Category Name already exists")%></span>
                                                                                    </div>
                                                                                </div>
                                                                                <div align="left">
                                                                                    <div class="bglabel">
                                                                                        <asp:Label ID="Label19" CssClass="normaltext" runat="server"><%=objLanguage.GetLanguageConversion("Job_Card_Catagory")%></asp:Label>
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
                                                                                        <span id="Span3" class="smallgraytext" style="display: block; width: auto; padding-left: 4px;
                                                                                            padding-right: 4px;">(<%=objLanguage.GetLanguageConversion("Please_Specify_Where_You_Would_Like_This_Category_To_Appear_On_The_Job_Card")%>)
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div align="left">
                                                                                    <div class="bglabelEmpty">
                                                                                    </div>
                                                                                    <div class="box">
                                                                                        <asp:Button ID="btnCategorySave" OnClick="btnCategorySave_OnClick" Text="Save" CssClass="button"
                                                                                            OnClientClick="javascript:return checkduplicateName();" Width="65px" runat="server" />
                                                                                        <asp:HiddenField ID="hdn_CategortID" runat="server" Value="0" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="width: 10px; background-color: #ffffff">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" class="popup-middle-rightcorner">
                                                        &nbsp;
                                                    </td>
                                                    <tr>
                                                        <td colspan="2" class="popup-bottom-leftcorner">
                                                            &nbsp;
                                                        </td>
                                                        <td class="popup-bottom-middlebg">
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="2" class="popup-bottom-rightcorner">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </table>
                                        </div>
                                        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="normalText textboxnew "
                                            Width="100%" onchange="javascript:CallonChange(this.value,'spn_ddlCategory');return false;">
                                        </asp:DropDownList>
                                        <span id="spn_ddlCategory" class="spanerrorMsg" style="display: none; width: auto;
                                            padding-left: 4px; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Category")%></span>
                                        <asp:HiddenField ID="hid_CategoryID" runat="server"></asp:HiddenField>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label9" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Calculation_Used")%></asp:Label>
                                <span style="color: Red;">*</span>
                            </div>
                            <div class="box" style="width: 55%;">
                                <asp:DropDownList runat="server" ID="ddlCalculation" CssClass="normalText textboxnew"
                                    Width="100%" onchange="javascript:LoadMethods(this.value);CallonChange(this.value,'spn_ddlCalculation');return false;">
                                    <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>
                                    <asp:ListItem Value="f" Text="Formula Based"></asp:ListItem>
                                    <asp:ListItem Value="m" Text="Formula Based with Matrix Table"></asp:ListItem>
                                    <asp:ListItem Value="q" Text="Quantity Based"></asp:ListItem>
                                    <asp:ListItem Value="t" Text="Time Based"></asp:ListItem>
                                </asp:DropDownList>
                                <span id="spn_ddlCalculation" class="spanerrorMsg" style="display: none; width: auto;
                                    padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Calculation")%></span>
                                <asp:HiddenField ID="hid_CalculationType" runat="server" Value="0" />
                            </div>
                            <script>
                                function LoadMethods(ddlval) {
                                    var div_TimeBased = document.getElementById("div_TimeBased");
                                    var div_QuantityBased = document.getElementById("div_QuantityBased");
                                    var div_Matrixbtn = document.getElementById("div_Matrixbtn");
                                    var div_FormulaBased = document.getElementById("div_FormulaBased");
                                    document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = "";
                                    document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixValue").value = "";
                                    var div_matrix_button = document.getElementById("div_matrix_button");
                                    var hid_IsMatrix = document.getElementById("<%=hid_IsMatrix.ClientID %>");
                                    var hid_CalculationType = document.getElementById("<%=hid_CalculationType.ClientID %>");
                                    var hdnprevfieldtype = document.getElementById("hdnprevfieldtype");
                                    var hdnquestion = document.getElementById("hdnquestion");

                                    var divPerHourCost = document.getElementById("divPerHourCost");

                                    div_TimeBased.style.display = "none";
                                    div_QuantityBased.style.display = "none";
                                    div_Matrixbtn.style.display = "none";
                                    div_FormulaBased.style.display = "none";
                                    div_matrix_button.style.display = "none";

                                    var type = '<%=Type %>';

                                    if (ddlval != 0) {
                                        if (ddlval == "t") {
                                            div_TimeBased.style.display = "block";
                                            hid_CalculationType.value = "t";
                                            divPerHourCost.style.display = "block";

                                        }
                                        else if (ddlval == "q") {
                                            hid_CalculationType.value = "q";
                                            divPerHourCost.style.display = "block";
                                            if (type == 'edit') {
                                                div_QuantityBased.style.display = "block";

                                            }
                                            else {
                                                div_QuantityBased.style.display = "block";

                                            }
                                        }
                                        else if (ddlval == "f") {
                                            hid_CalculationType.value = "f";
                                            div_FormulaBased.style.display = "block";
                                            divPerHourCost.style.display = "none";
                                            if ('<%=Action %>' != "") {
                                                document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = SpecialDecode('<%=Formula %>');
                                                hdnprevfieldtype.value = "ex";
                                                hdnquestion.value = "0";
                                            }
                                        }
                                        else if (ddlval == "m") {
                                            hid_CalculationType.value = "m";
                                            div_FormulaBased.style.display = "block";
                                            div_matrix_button.style.display = "block";
                                            divPerHourCost.style.display = "none";
                                            var div_MatrixTable = document.getElementById("div_MatrixTable");

                                            if ('<%=Action %>' != "") {
                                                document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value = SpecialDecode('<%=Formula %>');
                                                hdnprevfieldtype.value = "ex";
                                                hdnquestion.value = "0";
                                            }
                                            ShowHideMatrixTable("show");

                                        }
                        }
                    }
                            </script>
                        </div>
                        <div class="bglabel">
                            <div style="float: left">
                                <asp:Label ID="Label4" runat="server"><%=objLanguage.GetLanguageConversion("Supplier")%></asp:Label>
                            </div>
                            <div style="float: right">
                                <asp:ImageButton Style="vertical-align: top" ID="ImageButton8" Visible="true" runat="server"
                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                    OnClick="ImageButton8_Click"></asp:ImageButton></div>
                            <div style="float: right">
                                <asp:ImageButton Style="vertical-align: top" ID="ImageButtonPlus" Visible="false"
                                    runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                    OnClientClick="javascript:ImageButtonPlus_Click();return false"></asp:ImageButton></div>
                        </div>
                        <div class="box" style="width: 55%;">
                            <asp:DropDownList ID="ddlSupplier" CssClass="textboxnew" runat="server" Width="100%"
                                onchange="javascript:GetSupplier();return false;">
                            </asp:DropDownList>
                            <span id="Span4" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                padding-right: 4px;">
                                <%=objlang.GetValueOnLang("Please select Supplier")%>
                            </span>
                        </div>
                        <div align="left" runat="server" id="div_AccountCode">
                            <div class="bglabel">
                                <asp:Label ID="lblAccountCode" runat="server" CssClass="normalText"><%=objlang.GetValueOnLang("Accounting Code")%></asp:Label></div>
                            <div class="ddlsetting" style="width: 55%;">
                                <asp:DropDownList ID="ddlAccountCode" runat="server" Width="100%" CssClass="normalText">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div align="left" id="divPerHourCost">
                            <div class="bglabel">
                                <asp:Label ID="Label5" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Per_Hour_Cost")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</asp:Label></div>
                            <div class="box" style="width: 54%;">
                                <asp:TextBox ID="txtPerHourCost" runat="server" Width="100%" CssClass="textboxnew"
                                    onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtPerHourCost');CheckDecimalPlus(this.value,'spn_txtPerHourCost','spn_txtPerHourCost_number','no');CalculateHourlyCost();"
                                    MaxLength="20">0.000</asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                <span id="spn_txtPerHourCost" class="spanerrorMsg" style="display: none; width: auto;
                                    padding-left: 4px; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Please enter Per Hour Cost")%>
                                </span><span id="spn_txtPerHourCost_number" class="spanerrorMsg" style="display: none;
                                    width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label7" runat="server" CssClass="normaltext"></asp:Label><%=objLanguage.GetLanguageConversion("Markup")%>
                                (%)</div>
                            <div class="box" style="width: 54%;">
                                <asp:TextBox ID="txtProfit" runat="server" Width="100%" CssClass="textboxnew" onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtProfit');CheckDecimalPlus(this.value,'spn_txtProfit','spn_txtProfit_number','no');CalculateHourlyCost();"
                                    MaxLength="20">0.000</asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                <span id="spn_txtProfit" class="spanerrorMsg" style="display: none; width: auto;
                                    padding-left: 4px; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Please enter Profit")%>
                                </span><span id="spn_txtProfit_number" class="spanerrorMsg" style="display: none;
                                    width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                            </div>
                        </div>
                        <script>
                            function CalculateHourlyCost() {
                                var PerCost = Number(trim12(txtPerHourCostID.value));
                                var Profit = Number(trim12(txtProfitID.value));
                                var CalProfit = (PerCost * Profit) / 100;
                                var HourlyCost = PerCost + CalProfit;
                                txtHourlyRateID.value = HourlyCost.toFixed(3);
                                txtQtyHourlyRateID.value = HourlyCost.toFixed(3);
                            }
                        </script>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label8" runat="server" CssClass="normaltext"></asp:Label><%=objLanguage.GetLanguageConversion("Minimum_Charge")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</div>
                            <div class="box" style="width: 54%;">
                                <asp:TextBox ID="txtMinimum" runat="server" Width="100%" CssClass="textboxnew" onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtMinimum');CheckDecimalPlus(this.value,'spn_txtMinimum','spn_txtMinimum_number','yes');"
                                    MaxLength="20">0.000</asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                <span id="spn_txtMinimum" class="spanerrorMsg" style="display: none; width: 175px;">
                                    <%=objlang.GetValueOnLang("Please enter Minimum")%></span><span id="spn_txtMinimum_number"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div style="width: 49%; float: left;">
                        <div id="div_TimeBased" align="left" style="display: none; width: 100%">
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label10" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Hourly Rate")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</asp:Label>
                                    <span style="color: Red;">*</span>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtHourlyRate" runat="server" Width="70%" CssClass="textboxnew"
                                        onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtHourlyRate');CheckDecimalPlus(this.value,'spn_txtHourlyRate','spn_txtHourlyRate_number','yes')"
                                        MaxLength="20">0.000</asp:TextBox><span class="normalText">&nbsp;<%=objlang.GetValueOnLang("Per Hour")%></span>
                                    <span id="spn_txtHourlyRate" class="spanerrorMsg" style="display: none; width: auto;
                                        padding-left: 4px; padding-right: 4px;">
                                        <%=objlang.GetValueOnLang("Please enter Hourly Rate")%>
                                    </span><span id="spn_txtHourlyRate_number" class="spanerrorMsg" style="display: none;
                                        width: auto; padding-left: 4px; padding-right: 4px;">
                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%;">
                                <div class="bglabel">
                                    <asp:Label ID="Label11" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Make Ready Time")%></asp:Label>
                                    <span style="color: Red;">*</span>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtMakeReadyTime" runat="server" Width="70%" CssClass="textboxnew"
                                        onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtMakeReadyTime');CheckDecimalPlus(this.value,'spn_txtMakeReadyTime','spn_txtMakeReadyTime_number','yes')"
                                        MaxLength="20">0</asp:TextBox><span class="normalText">&nbsp;<%=objlang.GetValueOnLang("Mins")%></span><span
                                            id="spn_txtMakeReadyTime" class="spanerrorMsg" style="display: none; width: auto;
                                            padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter Make Ready Time")%>
                                        </span><span id="spn_txtMakeReadyTime_number" class="spanerrorMsg" style="display: none;
                                            width: auto; padding-left: 4px; padding-right: 4px;">
                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label12" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Hourly Run Speed")%></asp:Label>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtRunSpeed" runat="server" Width="70%" CssClass="textboxnew" onblur="todecimal_functionNew(this,this.value,'3');OnblurValidate(this.value,'spn_txtRunSpeed_defaultval');CallonBlur(this.value,'spn_txtRunSpeed'); CheckDecimalPlus(this.value,'spn_txtRunSpeed','spn_txtRunSpeed_number','yes')"
                                        MaxLength="20">1</asp:TextBox>
                                    <span class="normalText">&nbsp;<%=objlang.GetValueOnLang("Per Hour")%></span><span
                                        id="spn_txtRunSpeed" class="spanerrorMsg" style="display: none; width: auto;
                                        padding-left: 4px; padding-right: 4px;">
                                        <%=objlang.GetValueOnLang("Please enter Run Speed")%></span><span id="spn_txtRunSpeed_number"
                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span><span id="spn_txtRunSpeed_defaultval"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">Run
                                                Speed value cannot be less than 1</span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="bglabel" style="height: 40px">
                                    <asp:Label ID="Label18" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Time Based Type")%></asp:Label>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:RadioButtonList ID="rdlTimeCostType" runat="server" RepeatDirection="vertical"
                                        onclick="BindOnTimeCostType();">
                                        <asp:ListItem Text="Machine & Labour" Value="m" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="Labour Only" Value="l"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:HiddenField ID="hdnRunSpeed" runat="server" Value="1" />
                                    <script>


                                        //   By Jagat on 25/July

                                        function CheckRdn() {
                                            var rdlTimeCostType = document.getElementById("<%=rdlTimeCostType.ClientID %>");
                                            var options = rdlTimeCostType.getElementsByTagName('input');
                                            var rdlvalue = '';

                                            var rdldefaultQty = document.getElementById("<%=rdldefaultQty.ClientID %>");
                                            var optionshr = rdldefaultQty.getElementsByTagName('input');
                                            var rdlvaluehr = '';

                                            hdnRunSpeed = document.getElementById("<%=hdnRunSpeed.ClientID %>");

                                            for (var i = 0; i < options.length; i++) {
                                                if (options[i].checked) {
                                                    rdlvalue = options[i].value;
                                                }
                                            }
                                            if (rdlvalue == 'l') {
                                                txtRunSpeedID.value = "0";
                                                txtRunSpeedID.disabled = true;
                                                ddlVariableQtyID.disabled = true;
                                                for (var i = 0; i < optionshr.length; i++) {
                                                    if (optionshr[i].value == "txt") {
                                                        optionshr[i].checked = true;
                                                    }
                                                    if (optionshr[i].value == "ddl") {
                                                        optionshr[i].disabled = true;
                                                    }
                                                }
                                            }


                                            else if (rdlvalue == 'm') {
                                                if (hdnRunSpeed.value != "1") {
                                                    txtRunSpeedID.value = hdnRunSpeed.value;
                                                }
                                                else {
                                                    txtRunSpeedID.value = "1";
                                                }
                                                txtRunSpeedID.disabled = false;

                                            }

                                            SwitchHours();
                                        }


                                        //End

                                        function BindOnTimeCostType() {
                                            var rdlTimeCostType = document.getElementById("<%=rdlTimeCostType.ClientID %>");
                                            var options = rdlTimeCostType.getElementsByTagName('input');
                                            var rdlvalue = '';

                                            var rdldefaultQty = document.getElementById("<%=rdldefaultQty.ClientID %>");
                                            var optionshr = rdldefaultQty.getElementsByTagName('input');
                                            var rdlvaluehr = '';

                                            for (var i = 0; i < options.length; i++) {
                                                if (options[i].checked) {
                                                    rdlvalue = options[i].value;
                                                }
                                            }
                                            if (rdlvalue == 'l') {
                                                txtRunSpeedID.value = "0";
                                                txtRunSpeedID.disabled = true;
                                                ddlVariableQtyID.disabled = true;
                                                for (var i = 0; i < optionshr.length; i++) {
                                                    if (optionshr[i].value == "txt") {
                                                        optionshr[i].checked = true;
                                                    }
                                                    if (optionshr[i].value == "ddl") {
                                                        optionshr[i].disabled = true;
                                                    }
                                                }
                                            }
                                            else if (rdlvalue == 'm') {
                                                txtRunSpeedID.value = "1";
                                                txtRunSpeedID.disabled = false;
                                                ddlVariableQtyID.disabled = false;
                                                for (var i = 0; i < optionshr.length; i++) {
                                                    if (optionshr[i].value == "txt") {
                                                        optionshr[i].checked = true;
                                                    }
                                                    if (optionshr[i].value == "ddl") {
                                                        optionshr[i].disabled = false;
                                                    }
                                                }
                                            }
                                            SwitchHours();
                                        }
                                    </script>
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="onlyEmpty">
                                </div>
                                <fieldset style="width: 96%; height: 125px">
                                    <legend>
                                        <%=objlang.GetValueOnLang("Default Values to recommend")%></legend>
                                    <div style="float: left; width: 179px; border: 0px solid">
                                        <asp:RadioButtonList ID="rdldefaultQty" runat="server" onclick="javascript:SwitchHours();">
                                            <asp:ListItem Value="txt" Selected="true">Fixed Hours</asp:ListItem>
                                            <asp:ListItem Value="ddl">Hrs Calculated based on &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Qty and run Speed</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:HiddenField ID="hid_DefaultHourType" runat="server" Value="0" />
                                        <script>
                                            function SwitchHours() {
                                                var txtFixedQty = document.getElementById("<%=txtFixedQty.ClientID %>");
                                                var hid_DefaultHourType = document.getElementById("<%=hid_DefaultHourType.ClientID %>");
                                                var ddlVariableQty = document.getElementById("<%=ddlVariableQty.ClientID %>");
                                                var rdldefaultQty = document.getElementById("<%=rdldefaultQty.ClientID %>");
                                                var options = rdldefaultQty.getElementsByTagName('input');
                                                var rdlvalue = '';

                                                for (var i = 0; i < options.length; i++) {
                                                    if (options[i].checked) {
                                                        rdlvalue = options[i].value;
                                                    }
                                                }
                                                if (rdlvalue == 'txt') {
                                                    ddlVariableQty.disabled = true;
                                                    txtFixedQty.disabled = false;
                                                    ddlVariableQty.selectedIndex = 0;
                                                    hid_DefaultHourType.value = "f";
                                                    document.getElementById("spn_ddlVariableQty").style.display = "none";
                                                }
                                                else if (rdlvalue == 'ddl') {
                                                    txtFixedQty.disabled = true;
                                                    ddlVariableQty.disabled = false;
                                                    txtFixedQty.value = "0";
                                                    hid_DefaultHourType.value = "v";
                                                    document.getElementById("spn_txtFixedQty").style.display = "none";
                                                    document.getElementById("spn_txtFixedQty_number").style.display = "none";
                                                }
                                            }
                                        </script>
                                    </div>
                                    <div style="float: left; width: 2px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; white-space: nowrap" nowrap="nowrap">
                                        <div align="left" style="padding-top: 5px">
                                            <asp:TextBox ID="txtFixedQty" runat="server" Width="50px" SkinID="textPad" MaxLength="20"
                                                onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtFixedQty')">0</asp:TextBox>
                                            <span id="spn_txtFixedQty" class="spanerrorMsg" style="display: none; width: 160px;">
                                                <%=objlang.GetValueOnLang("Please enter Fixed Hours ")%></span><span id="spn_txtFixedQty_number"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span></div>
                                        <div align="left">
                                            &nbsp;
                                        </div>
                                        <div align="left" nowrap="nowrap">
                                            <asp:DropDownList runat="server" ID="ddlVariableQty" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlVariableQty');">
                                                <asp:ListItem Value="0">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="1">Print Sheet Qty excl Spoilage / Hourly Run Speed</asp:ListItem>
                                                <asp:ListItem Value="2">Print Sheet Qty incl Spoilage / Hourly Run Speed</asp:ListItem>
                                                <asp:ListItem Value="3">Finished Item Qty / Hourly Run Speed</asp:ListItem>
                                                <asp:ListItem Value="4">Width of Unfolded Finished Item Size/Hourly Run Speed</asp:ListItem>
                                                <asp:ListItem Value="5">Height of Unfolded Finished Item Size/Hourly Run Speed</asp:ListItem>

                                            </asp:DropDownList>
                                            <div align="left">
                                                <span id="spn_ddlVariableQty" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px;">
                                                    <%=objlang.GetValueOnLang("Please select Variable Hours")%></span>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hid_CostTimeBasedID" runat="server" Value="0" />
                                </fieldset>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                        </div>
                        <div id="div_QuantityBased" align="left" style="display: none; width: 100%">
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label13" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Hourly Rate")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</asp:Label>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtQtyHourlyRate" runat="server" Width="70%" CssClass="textboxnew"
                                        onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtQtyHourlyRate');CheckDecimalPlus(this.value,'spn_txtQtyHourlyRate','spn_txtQtyHourlyRate_number','yes')"
                                        MaxLength="20">0.000</asp:TextBox><span class="normalText">&nbsp;<%=objlang.GetValueOnLang("Per Hour")%></span><span
                                            id="spn_txtQtyHourlyRate" class="spanerrorMsg" style="display: none; width: auto;
                                            padding-left: 4px; padding-right: 4px;">
                                            <%=objlang.GetValueOnLang(" Please enter Hourly Rate")%></span><span id="spn_txtQtyHourlyRate_number"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label14" runat="server" Text="Make Ready Time" CssClass="normaltext"><%=objlang.GetValueOnLang("Make Ready Time")%></asp:Label>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtQtyMakeReadyTime" runat="server" Width="70%" CssClass="textboxnew"
                                        MaxLength="20" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtQtyMakeReadyTime');CheckDecimalPlus(this.value,'spn_txtQtyMakeReadyTime','spn_txtQtyMakeReadyTime_number','yes')">0</asp:TextBox><span
                                            class="normalText">&nbsp;<%=objlang.GetValueOnLang("Mins")%></span><span id="spn_txtQtyMakeReadyTime"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                <%=objlang.GetValueOnLang("Please enter Make Ready Time")%></span><span id="spn_txtQtyMakeReadyTime_number"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label15" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Time Per Unit (Mins)")%></asp:Label>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <asp:TextBox ID="txtQtyTimePerUnit" runat="server" Width="70%" CssClass="textboxnew"
                                        MaxLength="20" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtQtyTimePerUnit');CheckDecimalPlus(this.value,'spn_txtQtyTimePerUnit','spn_txtQtyTimePerUnit_number','yes')">0</asp:TextBox><span
                                            class="normalText"></span> <span class="normalText"><span id="spn_txtQtyTimePerUnit"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                <%=objlang.GetValueOnLang("Please enter Time")%></span><span id="spn_txtQtyTimePerUnit_number"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="bglabel">
                                    <asp:Label ID="Label16" runat="server" CssClass="normaltext"><%=objlang.GetValueOnLang("Unit Cost")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</asp:Label>
                                    <span style="color: Red;">*</span>
                                </div>
                                <div class="box" style="width: 56%;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtQtyUnitCost" runat="server" Width="70%" CssClass="textboxnew"
                                            onblur="todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtQtyUnitCost');CheckDecimalPlus(this.value,'spn_txtQtyUnitCost','spn_txtQtyUnitCost_number','yes')"
                                            MaxLength="20">0.000</asp:TextBox></span>
                                    </div>
                                    <div style="float: left; width: 2px;">
                                        &nbsp;</div>
                                    <div id="div_Matrixbtn" style="float: left; display: none;">
                                        <asp:Button ID="btnMatrix" runat="server" Text="Matrix" CssClass="button" Width="45px"
                                            OnClientClick="javascript:ShowHideMatrixTable('show');return false;" /></div>
                                    <span id="spn_txtQtyUnitCost" class="spanerrorMsg" style="display: none; width: auto;
                                        padding-left: 4px; padding-right: 4px;">
                                        <%=objlang.GetValueOnLang(" Please enter Unit Cost")%></span><span id="spn_txtQtyUnitCost_number"
                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                            </div>
                            <div align="left" style="width: 100%;">
                                <div class="onlyEmpty">
                                </div>
                                <fieldset style="width: 96%;">
                                    <legend>
                                        <%=objlang.GetValueOnLang("Default Quantity to recommend")%></legend>
                                    <div style="float: left; width: 120px">
                                        <asp:RadioButtonList ID="rdlQtyDefaultValue" runat="server" onclick="javascript:SwitchQtyValue();">
                                            <asp:ListItem Value="txt" Selected="true" Text="Fixed Value"></asp:ListItem>
                                            <asp:ListItem Value="ddl" Text="Variable Value"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:HiddenField ID="hid_QtyDefaultValueType" runat="server" Value="0" />
                                        <script>
                                            function SwitchQtyValue() {
                                                var txtQtyFixedValue = document.getElementById("<%=txtQtyFixedValue.ClientID %>");
                                                var hid_QtyDefaultValueType = document.getElementById("<%=hid_QtyDefaultValueType.ClientID %>");
                                                var ddlQtyVariableValue = document.getElementById("<%=ddlQtyVariableValue.ClientID %>");
                                                var rdlQtyDefaultValue = document.getElementById("<%=rdlQtyDefaultValue.ClientID %>");
                                                var options = rdlQtyDefaultValue.getElementsByTagName('input');
                                                var rdlvalue = '';

                                                for (var i = 0; i < options.length; i++) {
                                                    if (options[i].checked) {
                                                        rdlvalue = options[i].value;
                                                    }
                                                }
                                                if (rdlvalue == 'txt') {
                                                    ddlQtyVariableValue.disabled = true;
                                                    txtQtyFixedValue.disabled = false;
                                                    ddlQtyVariableValue.selectedIndex = 0;
                                                    hid_QtyDefaultValueType.value = "f";
                                                    document.getElementById("spn_ddlQtyVariableValue").style.display = "none";
                                                }
                                                else if (rdlvalue == 'ddl') {
                                                    txtQtyFixedValue.disabled = true;
                                                    ddlQtyVariableValue.disabled = false;
                                                    txtQtyFixedValue.value = "0";
                                                    hid_QtyDefaultValueType.value = "v";
                                                    document.getElementById("spn_txtQtyFixedValue").style.display = "none";
                                                    document.getElementById("spn_txtQtyFixedValue_number").style.display = "none";
                                                }
                                            }
                                        </script>
                                    </div>
                                    <div style="float: left; width: 2px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div align="left" style="padding-top: 5px;">
                                            <asp:TextBox ID="txtQtyFixedValue" runat="server" Width="50px" CssClass="textboxnew"
                                                onblur="CallonBlur(this.value,'spn_txtQtyFixedValue');IsIntegerParameter(this.value,'spn_txtQtyFixedValue_number');"
                                                MaxLength="10">0</asp:TextBox>
                                            <span id="spn_txtQtyFixedValue" class="spanerrorMsg" style="display: none; width: 175px;">
                                                <%=objlang.GetValueOnLang("Please enter Fixed Qty")%></span><span id="spn_txtQtyFixedValue_number"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetValueOnLang("Please enter integer value")%></span></div>
                                        <div align="left">
                                            &nbsp;</div>
                                        <div align="left">
                                            <asp:DropDownList runat="server" ID="ddlQtyVariableValue" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlQtyVariableValue');">
                                                <asp:ListItem Value="0">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Print Sheet Qty excl Spoilage"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Print Sheet Qty incl Spoilage"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Finished Item Qty"></asp:ListItem>
                                            </asp:DropDownList>
                                            <div align="left">
                                                <span id="spn_ddlQtyVariableValue" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px;">
                                                    <%=objlang.GetValueOnLang("Please select Variable Qty")%></span>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hid_IsMatrix" runat="server" Value="false" />
                                </fieldset>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                        </div>
                        <div align="left" id="div_FormulaBased" style="display: none; width: 100%;">
                            <div align="left" style="width: 100%">
                                <div class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Formula_String")%></div>
                                <div align="left" style="height: 50px; width: 100%;">
                                    <asp:TextBox ID="TextBox2" runat="server" Width="98%" CssClass="textboxnew" TextMode="MultiLine"
                                        Columns="2" Height="50px" onblur="javascript:ValidateText(this.value);"></asp:TextBox>
                                </div>
                                <div class="only5px">
                                </div>
                                <div style="float: left; padding-top: 5px; display: none" id="div_matrix_button">
                                    <input type="button" value="Matrix" class="button" onclick="javascript: ShowHideMatrixTable('show')" />
                                </div>
                            </div>
                            <div class="only10px">
                            </div>
                            <div align="left" style="width: 100%">
                                <div align="left" style="width: 100%" nowrap="nowrap">
                                    <input type="button" value="(" class="button" onclick="javascript: generate_formula('(', 'op', '', '');" />&nbsp;
                                    <input type="button" value=")" class="button" onclick="javascript: generate_formula(')', 'op', '', '');" />&nbsp;
                                    <input type="button" value="+" class="button" onclick="javascript: generate_formula('+', 'op', '', '');" />&nbsp;
                                    <input type="button" value="-" class="button" onclick="javascript: generate_formula('-', 'op', '', '');" />&nbsp;
                                    <input type="button" value="*" class="button" onclick="javascript: generate_formula('*', 'op', '', '');" />&nbsp;
                                    <input type="button" value="/" class="button" onclick="javascript: generate_formula('/', 'op', '', '');" />&nbsp;
                                    <input type="button" value="%" class="button" onclick="javascript: generate_formula('%', 'op', '', '');" />&nbsp;
                                    <input type="button" value="^" class="button" onclick="javascript: generate_formula('^', 'op', '', '');" />&nbsp;<%--<br />--%>
                                    <input type="button" value="#" class="button" onclick="javascript: generate_formula('#', 'op', '', '');" />&nbsp;
                                    <input type="button" value="Reset" class="button" onclick="javascript: clear_formula();" />
                                    <input type="button" value="Add Question" style="display: none" class="button" onclick="javascript: ShowHideQuestionTable('show');" />
                                    <input type="button" value="Num" class="button" style="display: none" onclick="javascript: ShowNumberTable();" />
                                    <input type="hidden" value="0" id="formalcount" />
                                    <input type="hidden" value="0" id="hdnquestion" />
                                    <script>
                                        function ShowNumberTable() {
                                            if (document.getElementById("div_Number").style.display == "none") {
                                                document.getElementById("div_Number").style.display = "block";
                                            }
                                            else {
                                                document.getElementById("div_Number").style.display = "none";
                                            }
                                        }
                                    </script>
                                    <script>
                                        //=== To place text at the cursor position ====///
                                        function insertAtCaret(text) {
                                            var obj = document.getElementById("<%=TextBox2.ClientID %>");

                                            if (document.selection) {
                                                obj.focus();
                                                var orig = obj.value.replace(/\r\n/g, "\n");
                                                var range = document.selection.createRange();

                                                if (range.parentElement() != obj) {
                                                    return false;
                                                }

                                                range.text = text;

                                                var actual = tmp = obj.value.replace(/\r\n/g, "\n");

                                                for (var diff = 0; diff < orig.length; diff++) {
                                                    if (orig.charAt(diff) != actual.charAt(diff)) break;
                                                }

                                                for (var index = 0, start = 0;
				                                    tmp.match(text)
					                                    && (tmp = tmp.replace(text, ""))
					                                    && index <= diff;
				                                    index = start + text.length
			                                    ) {
                                                    start = actual.indexOf(text, index);
                                                }
                                            } else if (obj.selectionStart) {
                                                var start = obj.selectionStart;
                                                var end = obj.selectionEnd;

                                                obj.value = obj.value.substr(0, start)
				                                + text
				                                + obj.value.substr(end, obj.value.length);
                                            }


                                            if (start != null) {
                                                setCaretTo(obj, start + text.length);
                                            } else {
                                                obj.value = text;
                                            }
                                        }

                                        function setCaretTo(obj, pos) {
                                            if (obj.createTextRange) {
                                                var range = obj.createTextRange();
                                                range.move('character', pos);
                                                range.select();
                                            } else if (obj.selectionStart) {
                                                obj.focus();
                                                obj.setSelectionRange(pos, pos);
                                            }
                                        }
                                    </script>
                                </div>
                                <div align="left" class="graytext" style="display: none">
                                    (Note: % -- Percentage, ^ -- PowerOf, # -- MOD)</div>
                            </div>
                            <div class="only10px">
                            </div>
                            <div align="left" style="width: 100%;">
                                <div align="left" id="div_Number" style="float: left; display: none; width: 220px">
                                    <div style="border: 1px solid silver; padding: 2px;">
                                        jdrgtjr</div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div align="left" style="width: 100%">
                                    <div style="border: solid 1px silver; width: 100%; height: 250px; visibility: visible;
                                        overflow-y: scroll; overflow-x: hidden">
                                        <asp:PlaceHolder ID="plhFormulaTags" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_MatrixTable" style="display: none; position: absolute; vertical-align: middle;
                    z-index: 100; width: 80%; top: 4%; left: 10%;" align="center">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" class="popup-top-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-top-middlebg">
                                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                                    padding-left: 1px">
                                    <b>
                                        <%=objLanguage.GetLanguageConversion("Cost_Matrix")%></b>
                                    <asp:Label ID="Label17" runat="server"></asp:Label></div>
                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                    <div class="CancelButtonDiv">
                                        <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                            runat="server" CausesValidation="false" OnClientClick="javascript:ShowHideMatrixTable('close');return false;" />
                                    </div>
                                </div>
                            </td>
                            <td colspan="2" class="popup-top-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="popup-middle-leftcorner">
                                &nbsp;
                            </td>
                            <td style="width: 15px; background-color: #ffffff">
                                &nbsp;
                            </td>
                            <td class="popup-middlebg" align="center">
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td valign="top">
                                            <div align="left" id="tbl_matrix">
                                                <div align="left">
                                                    <div class="bglabel" style="width: 12%">
                                                        <asp:Label ID="Label20" runat="server" Text="Prompt" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Prompt")%></asp:Label>
                                                        <span style="color: red;">*</span>
                                                    </div>
                                                    <div class="box">
                                                        <div align="left">
                                                            <asp:TextBox ID="txtprompt" runat="server" SkinID="textPad" Width="525px" Wrap="false"
                                                                onblur="CallonBlur(this.value,'spn_txtpromptv');" onfocus="javascript:ChangePromptBgcolor();return false;"
                                                                MaxLength="200"></asp:TextBox></div>
                                                        <div align="left">
                                                            <span id="spn_txtpromptv" class="spanerrorMsg" style="float: left; display: none;
                                                                width: auto; padding-left: 4px; padding-right: 4px;">
                                                                <%=objlang.GetValueOnLang("Please enter Prompt")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="only5px">
                                                </div>
                                                <div id="div_table" runat="server" align="center" style="width: 100%; height: 350px;
                                                    overflow-y: scroll;">
                                                    <table align="left" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4"
                                                        style="table-layout: fixed">
                                                        <col width="20%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <col width="13%" />
                                                        <tr class="label">
                                                            <td align="center">
                                                                <asp:Label ID="Label21" runat="server" Text="Matrix" CssClass="HeaderText"><%=objLanguage.GetLanguageConversion("Matrix")%></asp:Label>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol1" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol1v');"
                                                                    MaxLength="100">Selection A</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol1v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol2" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol2v');"
                                                                    MaxLength="100">Selection B</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol2v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol3" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol3v');"
                                                                    MaxLength="100">Selection C</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol3v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol4" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol4v');"
                                                                    MaxLength="100">Selection D</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol4v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol5" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol5v');"
                                                                    MaxLength="100">Selection E</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol5v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                    clear: both">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol6" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol6v');"
                                                                    MaxLength="100">Selection F</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol6v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol7" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol6v');"
                                                                    MaxLength="100">Selection G</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol7v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol8" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol6v');"
                                                                    MaxLength="100">Selection H</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol8v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol9" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol6v');"
                                                                    MaxLength="100">Selection I</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol9v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <asp:TextBox ID="txtCol10" runat="server" SkinID="textPad" Width="91%" onblur="CallonBlur(this.value,'spn_txtCol6v');"
                                                                    MaxLength="100">Selection J</asp:TextBox>
                                                                <br />
                                                                <span>(<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span><span id="spn_txtCol10v"
                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                    <%=objLanguage.GetLanguageConversion("Enter_Value")%></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="center">
                                                                    <%=objLanguage.GetLanguageConversion("Quantity")%><br />
                                                                </div>
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm1" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm1n');IsIntegerParameter(this.value,'spn_txtFrm1n');"
                                                                        MaxLength="6" Style="text-align: right">1</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo1" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm1n');IsIntegerParameter(this.value,'spn_txtFrm1n');"
                                                                        MaxLength="6" Style="text-align: right">1000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm1n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtTo1v" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA51" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA51v');CheckDecimalPlus(this.value,'spn_txtA51v','spn_txtA51n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA51v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA51n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA41" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA41v');CheckDecimalPlus(this.value,'spn_txtA41v','spn_txtA41n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA41v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA41n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA31" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA31v');CheckDecimalPlus(this.value,'spn_txtA31v','spn_txtA31n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA31v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA31n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA21" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA21v');CheckDecimalPlus(this.value,'spn_txtA21v','spn_txtA21n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA21v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA21n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA61" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA61v');CheckDecimalPlus(this.value,'spn_txtA61v','spn_txtA61n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA61v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA61n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA71" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA71v');CheckDecimalPlus(this.value,'spn_txtA71v','spn_txtA71n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA71v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA71n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA81" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA81v');CheckDecimalPlus(this.value,'spn_txtA81v','spn_txtA81n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA81v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA81n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA91" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA91v');CheckDecimalPlus(this.value,'spn_txtA91v','spn_txtA91n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA91v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA91n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA101" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA101v');CheckDecimalPlus(this.value,'spn_txtA101v','spn_txtA101n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA101v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA101n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left" style="margin-top: 11px;">
                                                                    <asp:TextBox ID="txtA111" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA111v');CheckDecimalPlus(this.value,'spn_txtA111v','spn_txtA111n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA111v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA111n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm2" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm2n');IsIntegerParameter(this.value,'spn_txtFrm2n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo2" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm2n');IsIntegerParameter(this.value,'spn_txtFrm2n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm2n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="Span1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA52" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA52v');CheckDecimalPlus(this.value,'spn_txtA52v','spn_txtA52n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA52v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA52n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA42" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA42v');CheckDecimalPlus(this.value,'spn_txtA42v','spn_txtA42n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA42v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA42n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA32" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA32v');CheckDecimalPlus(this.value,'spn_txtA32v','spn_txtA32n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA32v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA32n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA22" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA22v');CheckDecimalPlus(this.value,'spn_txtA22v','spn_txtA22n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA22v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA22n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA62" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA62v');CheckDecimalPlus(this.value,'spn_txtA62v','spn_txtA62n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA62v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA62n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA72" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA72v');CheckDecimalPlus(this.value,'spn_txtA72v','spn_txtA72n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA72v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA72n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objlang.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA82" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA81v');CheckDecimalPlus(this.value,'spn_txtA82v','spn_txtA82n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA82v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA82n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA92" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA92v');CheckDecimalPlus(this.value,'spn_txtA92v','spn_txtA92n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA92v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA92n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA102" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA102v');CheckDecimalPlus(this.value,'spn_txtA102v','spn_txtA102n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA102v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA102n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objlang.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td nowrap="nowrap" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA112" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA112v');CheckDecimalPlus(this.value,'spn_txtA112v','spn_txtA112n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA112v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtA112n" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm3" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm3n');IsIntegerParameter(this.value,'spn_txtFrm3n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo3" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm3n');IsIntegerParameter(this.value,'spn_txtFrm3n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm3n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtFrm3v" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtTo3v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtTo3n"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA53" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA53v');CheckDecimalPlus(this.value,'spn_txtA53v','spn_txtA53n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA53v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion("Enter_Numeric_Value")%></span><span id="spn_txtA53n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA43" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA43v');CheckDecimalPlus(this.value,'spn_txtA43v','spn_txtA43n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA43v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA43n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA33" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA33v');CheckDecimalPlus(this.value,'spn_txtA33v','spn_txtA33n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA33v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA33n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA23" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA23v');CheckDecimalPlus(this.value,'spn_txtA23v','spn_txtA23n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA23v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA23n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA63" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA63v');CheckDecimalPlus(this.value,'spn_txtA63v','spn_txtA63n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA63v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA63n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA73" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA73v');CheckDecimalPlus(this.value,'spn_txtA73v','spn_txtA73n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA73v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA73n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA83" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA83v');CheckDecimalPlus(this.value,'spn_txtA83v','spn_txtA83n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA83v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA83n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA93" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA93v');CheckDecimalPlus(this.value,'spn_txtA93v','spn_txtA93n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA93v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA93n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA103" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA103v');CheckDecimalPlus(this.value,'spn_txtA103v','spn_txtA103n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA103v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA103n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA113" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA113v');CheckDecimalPlus(this.value,'spn_txtA113v','spn_txtA113n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA113v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA113n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm4" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm4n');IsIntegerParameter(this.value,'spn_txtFrm4n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo4" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm4n');IsIntegerParameter(this.value,'spn_txtFrm4n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm4n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%>
                                                                    </span><span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo4v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo4n"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA54" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA54v');CheckDecimalPlus(this.value,'spn_txtA54v','spn_txtA54n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA54v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA54n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA44" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA44v');CheckDecimalPlus(this.value,'spn_txtA44v','spn_txtA44n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA44v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA44n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA34" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA34v');CheckDecimalPlus(this.value,'spn_txtA34v','spn_txtA34n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA34v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA34n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA24" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA24v');CheckDecimalPlus(this.value,'spn_txtA24v','spn_txtA24n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA24v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA24n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA64" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA64v');CheckDecimalPlus(this.value,'spn_txtA64v','spn_txtA64n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA64v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA64n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA74" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA74v');CheckDecimalPlus(this.value,'spn_txtA74v','spn_txtA74n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA74v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA74n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA84" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA84v');CheckDecimalPlus(this.value,'spn_txtA84v','spn_txtA84n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA84v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                        padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA84n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                            white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA94" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA94v');CheckDecimalPlus(this.value,'spn_txtA94v','spn_txtA94n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA94v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA94n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA104" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA104v');CheckDecimalPlus(this.value,'spn_txtA104v','spn_txtA104n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA104v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA104n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA114" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA114v');CheckDecimalPlus(this.value,'spn_txtA114v','spn_txtA114n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA114v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA114n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm5" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm5n');IsIntegerParameter(this.value,'spn_txtFrm5n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo5" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm5n');IsIntegerParameter(this.value,'spn_txtFrm5n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm5n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtFrm5v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo5v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo5n"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA55" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA55v');CheckDecimalPlus(this.value,'spn_txtA55v','spn_txtA55n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA55v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA55n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA45" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA45v');CheckDecimalPlus(this.value,'spn_txtA45v','spn_txtA45n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA45v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA45n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA35" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA35v');CheckDecimalPlus(this.value,'spn_txtA35v','spn_txtA35n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA35v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA35n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA25" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA25v');CheckDecimalPlus(this.value,'spn_txtA25v','spn_txtA25n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA25v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA25n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA65" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA65v');CheckDecimalPlus(this.value,'spn_txtA65v','spn_txtA65n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA65v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA65n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA75" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA75v');CheckDecimalPlus(this.value,'spn_txtA75v','spn_txtA75n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA75v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA75n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA85" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA85v');CheckDecimalPlus(this.value,'spn_txtA85v','spn_txtA85n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA85v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA85n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA95" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA95v');CheckDecimalPlus(this.value,'spn_txtA95v','spn_txtA95n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA95v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA95n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA105" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA105v');CheckDecimalPlus(this.value,'spn_txtA105v','spn_txtA105n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA105v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA105n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA115" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA115v');CheckDecimalPlus(this.value,'spn_txtA115v','spn_txtA115n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA115v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA115n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm6" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm6n');IsIntegerParameter(this.value,'spn_txtFrm6n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo6" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm6n');IsIntegerParameter(this.value,'spn_txtFrm6n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm6n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtFrm6v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo6v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo6n"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA56" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA56v');CheckDecimalPlus(this.value,'spn_txtA56v','spn_txtA56n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA56v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA56n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA46" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA46v');CheckDecimalPlus(this.value,'spn_txtA46v','spn_txtA46n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA46v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA46n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA36" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA36v');CheckDecimalPlus(this.value,'spn_txtA36v','spn_txtA36n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA36v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA36n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA26" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA26v');CheckDecimalPlus(this.value,'spn_txtA26v','spn_txtA26n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA26v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA26n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA66" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA66v');CheckDecimalPlus(this.value,'spn_txtA66v','spn_txtA66n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA66v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA66n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA76" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA76v');CheckDecimalPlus(this.value,'spn_txtA76v','spn_txtA76n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA76v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA76n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA86" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA86v');CheckDecimalPlus(this.value,'spn_txtA86v','spn_txtA86n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA86v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA86n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA96" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA96v');CheckDecimalPlus(this.value,'spn_txtA96v','spn_txtA96n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA96v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA96n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA106" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA106v');CheckDecimalPlus(this.value,'spn_txtA106v','spn_txtA106n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA106v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA106n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA116" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA116v');CheckDecimalPlus(this.value,'spn_txtA116v','spn_txtA116n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA116v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA116n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%--Pradeep --%>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm7" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm7n');IsIntegerParameter(this.value,'spn_txtFrm7n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo7" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm7n');IsIntegerParameter(this.value,'spn_txtFrm7n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm7n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%>
                                                                    </span><span id="spn_txtFrm7v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo7v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo7n"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA57" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA57v');CheckDecimalPlus(this.value,'spn_txtA57v','spn_txtA57n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA57v" class="spanerrorMsg" style="display: none;width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA57n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA47" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA47v');CheckDecimalPlus(this.value,'spn_txtA47v','spn_txtA47n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA47v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA47n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA37" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA37v');CheckDecimalPlus(this.value,'spn_txtA37v','spn_txtA37n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA37v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA37n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA27" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA27v');CheckDecimalPlus(this.value,'spn_txtA27v','spn_txtA27n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA27v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA27n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA67" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA67v');CheckDecimalPlus(this.value,'spn_txtA67v','spn_txtA67n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA67v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA67n"
                                                                            class="spanerrorMsg" style="display: none;width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA77" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA77v');CheckDecimalPlus(this.value,'spn_txtA77v','spn_txtA77n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA77v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA77n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA87" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA87v');CheckDecimalPlus(this.value,'spn_txtA87v','spn_txtA87n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA87v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA87n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA97" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA97v');CheckDecimalPlus(this.value,'spn_txtA97v','spn_txtA97n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA97v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA97n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA107" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA107v');CheckDecimalPlus(this.value,'spn_txtA107v','spn_txtA107n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA107v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA107n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA117" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA117v');CheckDecimalPlus(this.value,'spn_txtA117v','spn_txtA117n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA117v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA117n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm8" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm8n');IsIntegerParameter(this.value,'spn_txtFrm8n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo8" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm8n');IsIntegerParameter(this.value,'spn_txtFrm8n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm8n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm8v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo8v"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo8n"
                                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                    <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA58" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA58v');CheckDecimalPlus(this.value,'spn_txtA58v','spn_txtA58v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA58v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA58n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA48" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA48v');CheckDecimalPlus(this.value,'spn_txtA48v','spn_txtA48v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA48v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA48n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA38" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA38v');CheckDecimalPlus(this.value,'spn_txtA38v','spn_txtA38v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA38v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA38n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA28" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA28v');CheckDecimalPlus(this.value,'spn_txtA28v','spn_txtA28v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA28v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA28n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA68" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA68v');CheckDecimalPlus(this.value,'spn_txtA68v','spn_txtA68v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA68v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA68n"
                                                                            class="spanerrorMsg" style="display: none;width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA78" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA78v');CheckDecimalPlus(this.value,'spn_txtA78v','spn_txtA78v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA78v" class="spanerrorMsg" style="display: none;width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA78n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA88" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA88v');CheckDecimalPlus(this.value,'spn_txtA88v','spn_txtA88n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA88v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA88n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA98" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA98v');CheckDecimalPlus(this.value,'spn_txtA98v','spn_txtA98n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA98v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA98n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA108" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA108v');CheckDecimalPlus(this.value,'spn_txtA108v','spn_txtA108n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA108v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA108n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA118" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA118v');CheckDecimalPlus(this.value,'spn_txtA118v','spn_txtA118n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA118v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA118n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm9" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm9n');IsIntegerParameter(this.value,'spn_txtFrm9n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo9" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm9n');IsIntegerParameter(this.value,'spn_txtFrm9n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm9n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm9v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo9v"
                                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo9n"
                                                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px;">
                                                                                    <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA59" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA59v');CheckDecimalPlus(this.value,'spn_txtA59v','spn_txtA59v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA59v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA59n"
                                                                            class="spanerrorMsg" style="display: none;width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA49" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA49v');CheckDecimalPlus(this.value,'spn_txtA49v','spn_txtA49v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA49v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA49n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA39" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA39v');CheckDecimalPlus(this.value,'spn_txtA39v','spn_txtA39v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA39v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA39n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA29" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA29v');CheckDecimalPlus(this.value,'spn_txtA29v','spn_txtA29v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA29v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA29n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA69" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA69v');CheckDecimalPlus(this.value,'spn_txtA69v','spn_txtA69v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA69v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA69n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA79" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA79v');CheckDecimalPlus(this.value,'spn_txtA79v','spn_txtA79v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA79v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA79n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA89" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA89v');CheckDecimalPlus(this.value,'spn_txtA89v','spn_txtA89n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA89v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA89n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA99" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA99v');CheckDecimalPlus(this.value,'spn_txtA99v','spn_txtA99n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA99v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA99n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA109" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA109v');CheckDecimalPlus(this.value,'spn_txtA109v','spn_txtA109n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA109v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA109n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA119" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA119v');CheckDecimalPlus(this.value,'spn_txtA119v','spn_txtA119n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA119v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA119n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm10" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm10n');IsIntegerParameter(this.value,'spn_txtFrm10n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo10" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm10n');IsIntegerParameter(this.value,'spn_txtFrm10n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm10n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm10v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">Enter numeric value</span>
                                                                    <span id="spn_txtTo10v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo10n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA510" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA510v');CheckDecimalPlus(this.value,'spn_txtA510v','spn_txtA510v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA510v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA510n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA410" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA410v');CheckDecimalPlus(this.value,'spn_txtA410v','spn_txtA410v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA410v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA410n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA310" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA310v');CheckDecimalPlus(this.value,'spn_txtA310v','spn_txtA310v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA310v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA310n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA210" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA210v');CheckDecimalPlus(this.value,'spn_txtA210v','spn_txtA210v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA210v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA210n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA610" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA610v');CheckDecimalPlus(this.value,'spn_txtA610v','spn_txtA610v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA610v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA610n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA710" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA710v');CheckDecimalPlus(this.value,'spn_txtA710v','spn_txtA710v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA710v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA710n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA810" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA810v');CheckDecimalPlus(this.value,'spn_txtA810v','spn_txtA810n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA810v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA810n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA910" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA910v');CheckDecimalPlus(this.value,'spn_txtA910v','spn_txtA910n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA910v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA910n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1010" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1010v');CheckDecimalPlus(this.value,'spn_txtA1010v','spn_txtA1010n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1010v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1010n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1110" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1110v');CheckDecimalPlus(this.value,'spn_txtA1110v','spn_txtA1110n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1110v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1110n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm11" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm11n');IsIntegerParameter(this.value,'spn_txtFrm11n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo11" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm11n');IsIntegerParameter(this.value,'spn_txtFrm11n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm11n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm11v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">Enter numeric value</span>
                                                                    <span id="spn_txtTo11v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtTo11n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA511" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA511v');CheckDecimalPlus(this.value,'spn_txtA511v','spn_txtA511v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA511v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA511n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA411" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA411v');CheckDecimalPlus(this.value,'spn_txtA411v','spn_txtA411v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA411v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA411n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA311" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA311v');CheckDecimalPlus(this.value,'spn_txtA311v','spn_txtA311v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA311v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA311n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA211" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA211v');CheckDecimalPlus(this.value,'spn_txtA211v','spn_txtA211v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA211v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA211n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA611" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA611v');CheckDecimalPlus(this.value,'spn_txtA611v','spn_txtA611v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA611v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA611n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA711" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA711v');CheckDecimalPlus(this.value,'spn_txtA711v','spn_txtA711v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA711v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA711n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA811" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA811v');CheckDecimalPlus(this.value,'spn_txtA811v','spn_txtA811n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA811v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA811n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA911" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA911v');CheckDecimalPlus(this.value,'spn_txtA911v','spn_txtA911n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA911v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA911n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1011" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1011v');CheckDecimalPlus(this.value,'spn_txtA1011v','spn_txtA1011n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1011v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1011n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1111" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1111v');CheckDecimalPlus(this.value,'spn_txtA1111v','spn_txtA1111n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1111v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1111n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm12" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm12n');IsIntegerParameter(this.value,'spn_txtFrm12n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo12" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm12n');IsIntegerParameter(this.value,'spn_txtFrm12n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm12n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm12v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA512" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA512v');CheckDecimalPlus(this.value,'spn_txtA512v','spn_txtA512v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA512v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA512n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA412" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA412v');CheckDecimalPlus(this.value,'spn_txtA412v','spn_txtA412v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA412v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA412n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA312" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA312v');CheckDecimalPlus(this.value,'spn_txtA312v','spn_txtA312v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA312v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA312n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA212" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA212v');CheckDecimalPlus(this.value,'spn_txtA212v','spn_txtA212v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA212v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA212n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA612" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA612v');CheckDecimalPlus(this.value,'spn_txtA612v','spn_txtA612v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA612v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA612n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA712" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA712v');CheckDecimalPlus(this.value,'spn_txtA712v','spn_txtA712v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA712v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA712n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA812" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA812v');CheckDecimalPlus(this.value,'spn_txtA812v','spn_txtA812n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA812v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA812n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA912" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA912v');CheckDecimalPlus(this.value,'spn_txtA912v','spn_txtA912n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA912v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA912n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1012" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1012v');CheckDecimalPlus(this.value,'spn_txtA1012v','spn_txtA1012n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1012v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1012n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1112" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1112v');CheckDecimalPlus(this.value,'spn_txtA1112v','spn_txtA1112n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1112v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1112n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <%--Rows --%>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm13" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm13n');IsIntegerParameter(this.value,'spn_txtFrm13n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo13" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm13n');IsIntegerParameter(this.value,'spn_txtFrm13n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm13n" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm13v"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA513" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA513v');CheckDecimalPlus(this.value,'spn_txtA513v','spn_txtA513v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA513v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA513n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA413" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA413v');CheckDecimalPlus(this.value,'spn_txtA413v','spn_txtA413v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA413v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA413n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA313" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA313v');CheckDecimalPlus(this.value,'spn_txtA313v','spn_txtA313v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA313v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA313n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA213" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA213v');CheckDecimalPlus(this.value,'spn_txtA213v','spn_txtA213v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA213v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA213n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA613" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA613v');CheckDecimalPlus(this.value,'spn_txtA613v','spn_txtA613v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA613v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA613n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA713" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA713v');CheckDecimalPlus(this.value,'spn_txtA713v','spn_txtA713v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA713v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA713n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA813" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA813v');CheckDecimalPlus(this.value,'spn_txtA813v','spn_txtA813n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA813v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA813n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA913" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA913v');CheckDecimalPlus(this.value,'spn_txtA913v','spn_txtA913n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA913v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA913n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1013" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1013v');CheckDecimalPlus(this.value,'spn_txtA1013v','spn_txtA1013n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1013v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1013n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1113" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1113v');CheckDecimalPlus(this.value,'spn_txtA1113v','spn_txtA1113n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1113v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1113n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm14" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm14n');IsIntegerParameter(this.value,'spn_txtFrm14n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo14" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm14n');IsIntegerParameter(this.value,'spn_txtFrm14n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm14v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm14n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA514" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA514v');CheckDecimalPlus(this.value,'spn_txtA514v','spn_txtA514v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA514v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA514n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA414" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA414v');CheckDecimalPlus(this.value,'spn_txtA414v','spn_txtA414v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA414v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA414n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA314" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA314v');CheckDecimalPlus(this.value,'spn_txtA314v','spn_txtA314v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA314v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA314n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA214" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA214v');CheckDecimalPlus(this.value,'spn_txtA214v','spn_txtA214v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA214v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA214n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA614" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA614v');CheckDecimalPlus(this.value,'spn_txtA614v','spn_txtA614v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA614v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA614n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA714" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA714v');CheckDecimalPlus(this.value,'spn_txtA714v','spn_txtA714v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA714v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA714n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA814" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA814v');CheckDecimalPlus(this.value,'spn_txtA814v','spn_txtA814n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA814v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA814n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA914" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA914v');CheckDecimalPlus(this.value,'spn_txtA914v','spn_txtA914n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA914v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA914n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1014" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1014v');CheckDecimalPlus(this.value,'spn_txtA1014v','spn_txtA1014n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1014v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1014n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1114" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1114v');CheckDecimalPlus(this.value,'spn_txtA1114v','spn_txtA1114n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1114v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1114n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm15" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm15n');IsIntegerParameter(this.value,'spn_txtFrm15n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo15" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm15n');IsIntegerParameter(this.value,'spn_txtFrm15n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm15v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm15n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA515" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA515v');CheckDecimalPlus(this.value,'spn_txtA515v','spn_txtA515v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA515v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA515n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA415" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA415v');CheckDecimalPlus(this.value,'spn_txtA415v','spn_txtA415v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA415v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA415n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA315" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA315v');CheckDecimalPlus(this.value,'spn_txtA315v','spn_txtA315v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA315v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA315n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA215" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA215v');CheckDecimalPlus(this.value,'spn_txtA215v','spn_txtA215v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA215v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA215n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA615" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA615v');CheckDecimalPlus(this.value,'spn_txtA615v','spn_txtA615v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA615v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA615n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA715" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA715v');CheckDecimalPlus(this.value,'spn_txtA715v','spn_txtA715v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA715v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA715n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA815" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA815v');CheckDecimalPlus(this.value,'spn_txtA815v','spn_txtA815n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA815v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA815n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA915" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA915v');CheckDecimalPlus(this.value,'spn_txtA915v','spn_txtA915n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA915v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA915n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1015" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1015v');CheckDecimalPlus(this.value,'spn_txtA1015v','spn_txtA1015n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1015v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1015n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1115" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1115v');CheckDecimalPlus(this.value,'spn_txtA1115v','spn_txtA1115n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1115v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1115n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm16" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm16n');IsIntegerParameter(this.value,'spn_txtFrm16n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo16" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm16n');IsIntegerParameter(this.value,'spn_txtFrm16n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm16v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm16n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA516" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA516v');CheckDecimalPlus(this.value,'spn_txtA516v','spn_txtA516v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA516v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA516n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA416" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA416v');CheckDecimalPlus(this.value,'spn_txtA416v','spn_txtA416v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA416v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA416n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA316" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA316v');CheckDecimalPlus(this.value,'spn_txtA316v','spn_txtA316v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA316v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA316n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA216" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA216v');CheckDecimalPlus(this.value,'spn_txtA216v','spn_txtA216v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA216v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA216n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA616" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA616v');CheckDecimalPlus(this.value,'spn_txtA616v','spn_txtA616v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA616v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA616n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA716" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA716v');CheckDecimalPlus(this.value,'spn_txtA716v','spn_txtA716v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA716v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA716n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA816" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA816v');CheckDecimalPlus(this.value,'spn_txtA816v','spn_txtA816n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA816v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA816n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA916" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA916v');CheckDecimalPlus(this.value,'spn_txtA916v','spn_txtA916n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA916v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA916n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1016" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1013v');CheckDecimalPlus(this.value,'spn_txtA1013v','spn_txtA1013n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1016v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1016n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1116" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1116v');CheckDecimalPlus(this.value,'spn_txtA1116v','spn_txtA1116n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1116v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1116n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm17" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm17n');IsIntegerParameter(this.value,'spn_txtFrm17n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo17" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm17n');IsIntegerParameter(this.value,'spn_txtFrm17n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm17v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm17n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA517" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA517v');CheckDecimalPlus(this.value,'spn_txtA517v','spn_txtA517v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA517v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA517n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA417" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA417v');CheckDecimalPlus(this.value,'spn_txtA417v','spn_txtA417v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA417v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA417n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA317" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA317v');CheckDecimalPlus(this.value,'spn_txtA317v','spn_txtA317v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA317v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA317n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA217" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA217v');CheckDecimalPlus(this.value,'spn_txtA217v','spn_txtA217v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA217v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA217n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA617" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA617v');CheckDecimalPlus(this.value,'spn_txtA617v','spn_txtA617v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA617v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA617n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA717" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA717v');CheckDecimalPlus(this.value,'spn_txtA717v','spn_txtA717v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA717v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA717n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA817" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA817v');CheckDecimalPlus(this.value,'spn_txtA817v','spn_txtA817n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA817v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA817n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA917" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA917v');CheckDecimalPlus(this.value,'spn_txtA917v','spn_txtA917n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA917v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA917n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1017" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1017v');CheckDecimalPlus(this.value,'spn_txtA1017v','spn_txtA1017n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1017v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1017n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1117" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1117v');CheckDecimalPlus(this.value,'spn_txtA1117v','spn_txtA1117n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1117v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1117n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm18" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm18n');IsIntegerParameter(this.value,'spn_txtFrm18n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo18" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm18n');IsIntegerParameter(this.value,'spn_txtFrm18n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm18v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm18n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA518" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA518v');CheckDecimalPlus(this.value,'spn_txtA518v','spn_txtA518v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA518v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA518n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA418" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA418v');CheckDecimalPlus(this.value,'spn_txtA418v','spn_txtA418v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA418v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA418n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA318" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA318v');CheckDecimalPlus(this.value,'spn_txtA318v','spn_txtA318v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA318v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA318n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA218" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA218v');CheckDecimalPlus(this.value,'spn_txtA218v','spn_txtA218v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA218v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA218n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA618" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA618v');CheckDecimalPlus(this.value,'spn_txtA618v','spn_txtA618v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA618v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA618n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA718" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA718v');CheckDecimalPlus(this.value,'spn_txtA718v','spn_txtA718v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA718v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA718n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA818" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA818v');CheckDecimalPlus(this.value,'spn_txtA818v','spn_txtA818n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA818v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA818n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA918" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA918v');CheckDecimalPlus(this.value,'spn_txtA918v','spn_txtA918n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA918v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA918n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1018" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1018v');CheckDecimalPlus(this.value,'spn_txtA1018v','spn_txtA1018n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1018v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1018n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1118" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1118v');CheckDecimalPlus(this.value,'spn_txtA1118v','spn_txtA1118n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1118v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1118n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm19" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm19n');IsIntegerParameter(this.value,'spn_txtFrm19n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    -
                                                                    <asp:TextBox runat="server" ID="txtTo19" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm19n');IsIntegerParameter(this.value,'spn_txtFrm19n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm19v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm19n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA519" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA519v');CheckDecimalPlus(this.value,'spn_txtA519v','spn_txtA519v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA519v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA519n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA419" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA419v');CheckDecimalPlus(this.value,'spn_txtA419v','spn_txtA419v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA419v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA419n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA319" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA319v');CheckDecimalPlus(this.value,'spn_txtA319v','spn_txtA319v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA319v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA319n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA219" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA219v');CheckDecimalPlus(this.value,'spn_txtA219v','spn_txtA219v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA219v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA219n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA619" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA619v');CheckDecimalPlus(this.value,'spn_txtA619v','spn_txtA619v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA619v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA619n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA719" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA719v');CheckDecimalPlus(this.value,'spn_txtA719v','spn_txtA719v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA719v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA719n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA819" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA819v');CheckDecimalPlus(this.value,'spn_txtA819v','spn_txtA819n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA819v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA819n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA919" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA919v');CheckDecimalPlus(this.value,'spn_txtA919v','spn_txtA919n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA919v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA919n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1019" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1019v');CheckDecimalPlus(this.value,'spn_txtA1019v','spn_txtA1019n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1019v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1019n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1119" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1119v');CheckDecimalPlus(this.value,'spn_txtA1119v','spn_txtA1119n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1119v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1119n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="HeaderText label" nowrap="nowrap">
                                                                <div align="left">
                                                                    <asp:TextBox runat="server" ID="txtFrm20" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm20n');IsIntegerParameter(this.value,'spn_txtFrm20n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>
                                                                    +
                                                                    <%--<asp:TextBox runat="server" ID="txtTo20" SkinID="textPad" Width="40%" onblur="CallonBlur(this.value,'spn_txtFrm13n');IsIntegerParameter(this.value,'spn_txtFrm13n');"
                                                                        MaxLength="6" Style="text-align: right">0</asp:TextBox>--%>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtFrm20v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtFrm20n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA520" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA520v');CheckDecimalPlus(this.value,'spn_txtA520v','spn_txtA520v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA520v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA520n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA420" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA420v');CheckDecimalPlus(this.value,'spn_txtA420v','spn_txtA420v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA420v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA420n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA320" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA320v');CheckDecimalPlus(this.value,'spn_txtA320v','spn_txtA320v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA320v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA320n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA220" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA220v');CheckDecimalPlus(this.value,'spn_txtA220v','spn_txtA220v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA220v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA220n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA620" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA620v');CheckDecimalPlus(this.value,'spn_txtA620v','spn_txtA620n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA620v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA620n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA720" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA720v');CheckDecimalPlus(this.value,'spn_txtA720v','spn_txtA720n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA720v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA720n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA820" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA820v');CheckDecimalPlus(this.value,'spn_txtA820v','spn_txtA820v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox></div>
                                                                <div align="left">
                                                                    <span id="spn_txtA820v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA820n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA920" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA920v');CheckDecimalPlus(this.value,'spn_txtA920v','spn_txtA920n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA920v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA920n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1020" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1020v');CheckDecimalPlus(this.value,'spn_txtA1020v','spn_txtA1020n','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1020v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1020n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                            <td class="HeaderText" align="left">
                                                                <div align="left">
                                                                    <asp:TextBox ID="txtA1120" runat="server" SkinID="textPad" Width="91%" onClick="select_all(this.id)"
                                                                        onfocus="javascript:ChangetxtBgcolor(this);return false;" onblur="javascript:todecimal_functionNew(this,this.value,'3');CallonBlur(this.value,'spn_txtA1120v');CheckDecimalPlus(this.value,'spn_txtA1120v','spn_txtA1120v','yes');AmountTo2Decimal(this,this.value);RemoveBgcolor(this,this.value);return false;"
                                                                        MaxLength="12" Style="text-align: right">0.000</asp:TextBox>
                                                                </div>
                                                                <div align="left">
                                                                    <span id="spn_txtA1120v" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                        <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span><span id="spn_txtA1120n"
                                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;padding-right: 4px; white-space: nowrap">
                                                                            <%=objLanguage.GetLanguageConversion ("Enter_Numeric_Value")%></span>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <asp:HiddenField runat="server" ID="hdnMatrixValue" Value="" />
                                                        <asp:HiddenField runat="server" ID="hdnMatrixHeadingID" Value="" />
                                                        <asp:HiddenField runat="server" ID="hdnMatrixValueID" Value="" />
                                                    </table>
                                                    <script>
                                                        function errorDisplay() {
                                                            var checkWhat = true;

                                                            var generalIdFrom = document.getElementById("<%=txtFrm1.ClientID %>").id;
                                                            var generalIdTo = document.getElementById("<%=txtTo1.ClientID %>").id;

                                                            generalIdFrom = generalIdFrom.replace('txtFrm1', 'txtFrm');
                                                            generalIdTo = generalIdTo.replace('txtTo1', 'txtTo');

                                                            for (var i = 1; i <= 11; i++) {
                                                                var newGeneralIdFrom = generalIdFrom.replace('txtFrm', 'txtFrm' + i);
                                                                var newGeneralIdTo = generalIdTo.replace('txtTo', 'txtTo' + i);

                                                                newGeneralIdFrom = document.getElementById(newGeneralIdFrom).value;
                                                                newGeneralIdTo = document.getElementById(newGeneralIdTo).value;

                                                                if (CheckReqCompare(newGeneralIdFrom, 'spn_txtFrm' + i + 'n', 'spn_txtFrm' + i + 'n')
                                                        || CheckReqCompare(newGeneralIdTo, 'spn_txtFrm' + i + 'n', 'spn_txtFrm' + i + 'n')) {
                                                                    checkWhat = false;
                                                                }
                                                            }

                                                            if (checkWhat) {
                                                                checkvalidation();
                                                                var txtFormula = document.getElementById("<%=TextBox2.ClientID %>");
                                                                if (txtFormula.value.indexOf('<<Matrix>>') == -1) {
                                                                    if (trim12(txtFormula.value) == "") {
                                                                        txtFormula.value = "<<Matrix>>";
                                                                    }
                                                                    else {
                                                                        txtFormula.value = txtFormula.value + "<<Matrix>>";
                                                                    }

                                                                }

                                                                if (navigator.appName != "Microsoft Internet Explorer") {
                                                                    txtFormula.setSelectionRange(txtFormula.value.length, txtFormula.value.length); //applied condn for IE check by swetha on 21/9/2011 -- since page getting blank in IE
                                                                }
                                                            }
                                                            return false;
                                                        }

                                                        function ChangetxtBgcolor(obj) {
                                                            var text_val = document.getElementById(obj);
                                                            text_val.style.backgroundColor = "#fbfea0"; //#FFF9BB
                                                            text_val.select();

                                                        }

                                                        function select_all(Id) {
                                                            var text_val = document.getElementById(Id);
                                                            text_val.focus();
                                                            text_val.select();
                                                            ChangetxtBgcolor(Id);
                                                        }

                                                        function ChangePromptBgcolor() {
                                                            var text_val = document.getElementById("ctl00_ContentPlaceHolder1_txtprompt");
                                                            text_val.style.backgroundColor = "#FFFFFF"; //#FFF9BB
                                                            text_val.select();

                                                        }

                                                        function SelectPrompt() {
                                                            var txt = document.getElementById("ctl00_ContentPlaceHolder1_txtprompt");
                                                            txt.select();
                                                        }

                                                        function RemoveBgcolor(obj, val) {

                                                            obj.style.backgroundColor = "";
                                                            var matrixvalue = document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixValue");
                                                            matrixvalue.value = val;

                                                        }

                                                    </script>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="float: left; width: 84%;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left;">
                                                <div style="float: left;">
                                                    <asp:Button ID="btnCancelMatrix" runat="server" Text="Cancel" Style="display: none;"
                                                        CssClass="button" OnClientClick="javascript:ShowHideMatrixTable('close');return false;" />
                                                </div>
                                                <div style="float: left; width: 10px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <asp:Button ID="btnSaveMatrix" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:errorDisplay();return false;" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <script>
                                        function checkvalidation() {
                                            var flag = false;
                                            tblmatrix = document.getElementById("tbl_matrix");
                                            var inpuEle = tblmatrix.getElementsByTagName('input');
                                            for (var i = 0; i < inpuEle.length; i++) {
                                                if (inpuEle[i].type == 'text') {
                                                    if (inpuEle[i].value == "") {
                                                        var elId = inpuEle[i].id;
                                                        elId = elId.replace("ctl00_ContentPlaceHolder1", "spn");
                                                        var spnId = elId + "v";
                                                        document.getElementById(spnId).style.display = "block";
                                                        flag = true;
                                                    }
                                                }
                                            }
                                            if (flag) {
                                                ShowHideMatrixTable('show');
                                            }
                                            else {
                                                ShowHideMatrixTable('hide');
                                            }
                                        }
                                    </script>
                                </table>
                            </td>
                            <td style="width: 10px; background-color: #ffffff">
                                &nbsp;
                            </td>
                            <td align="right" class="popup-middle-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="popup-bottom-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-bottom-middlebg">
                                &nbsp;
                            </td>
                            <td colspan="2" class="popup-bottom-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_QuestionTable" style="display: none; position: absolute; vertical-align: middle;
                    z-index: 100; width: 50%" align="center">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" class="popup-top-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-top-middlebg">
                                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                                    padding-left: 1px">
                                    <b>
                                        <%=objlang.GetValueOnLang("Please enter a Question")%>
                                    </b>
                                    <asp:Label ID="Label22" runat="server"></asp:Label></div>
                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                    <div class="CancelButtonDiv">
                                        <asp:ImageButton ID="ImageButton3" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                            runat="server" CausesValidation="false" OnClientClick="javascript:ShowHideQuestionTable('hide');return false;" />
                                    </div>
                                </div>
                            </td>
                            <td colspan="2" class="popup-top-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="popup-middle-leftcorner">
                                &nbsp;
                            </td>
                            <td style="width: 15px; background-color: #ffffff">
                                &nbsp;
                            </td>
                            <td class="popup-middlebg" align="center">
                                <div style="padding: 10px 5px 10px 0px; width: 98%">
                                    <div class="" style="width: 100%">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td valign="top">
                                                    <div>
                                                        <asp:TextBox runat="server" ID="txtquestion" SkinID="textPad" TextMode="MultiLine"
                                                            Rows="2" Width="488px">
                                                        </asp:TextBox>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="position: relative; display: none; width: 285px" id="diverror" nowrap="nowrap">
                                                        <span class="spanerrorMsg" style="white-space: nowrap">
                                                            <%=objlang.GetValueOnLang("Please enter a Question")%></span>
                                                    </div>
                                                    <div align="right" style="padding-right: 10px;">
                                                        <input type="button" value="OK" class="button" onclick="javascript: addquestion('hide');" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                            <td style="width: 10px; background-color: #ffffff">
                                &nbsp;
                            </td>
                            <td align="right" class="popup-middle-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="popup-bottom-leftcorner">
                                &nbsp;
                            </td>
                            <td class="popup-bottom-middlebg">
                                &nbsp;
                            </td>
                            <td colspan="2" class="popup-bottom-rightcorner">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="only10px">
                </div>
                <div style="width: 100%">
                    <div style="width: 14.3%; float: left;">
                        &nbsp;
                    </div>
                    <div class="box" style="Margin-left:-7px;" id="Divboxedit" runat="server">
                        <div style="float: left">
                            <div id="div_btndelete" style="display: block">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" Visible="false"
                                    OnClick="btnDelete_OnClick" OnClientClick="javascript:var a=window.confirm('Are you sure, you want to delete this press?');if(a)loadingimage(this.id,'div_btnDeleteprocess');return a;" />
                            </div>
                            <div id="div_btnDeleteprocess" style="width: 35px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                            <div id="div_btnCancel" style="display: block">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick" />
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
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_OnClick"
                                    OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                            </div>
                            <div id="div_btnsaveprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
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
                    <asp:HiddenField ID="hdn_supplierID" runat="server" Value="" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        //left side
        var txtNameID = document.getElementById("<%=txtName.ClientID %>");
        var ddlCategoryID = document.getElementById("<%=ddlCategory.ClientID %>");
        var ddlCalculationID = document.getElementById("<%=ddlCalculation.ClientID %>");
        var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID %>");
        var txtPerHourCostID = document.getElementById("<%=txtPerHourCost.ClientID %>");
        var txtProfitID = document.getElementById("<%=txtProfit.ClientID %>");
        var txtMinimumID = document.getElementById("<%=txtMinimum.ClientID %>");

        //right side
        //** Time Based **//
        var txtHourlyRateID = document.getElementById("<%=txtHourlyRate.ClientID %>");
        var txtMakeReadyTimeID = document.getElementById("<%=txtMakeReadyTime.ClientID %>");
        var txtRunSpeedID = document.getElementById("<%=txtRunSpeed.ClientID %>");
        var rdldefaultQty = document.getElementById("<%=rdldefaultQty.ClientID %>");
        var txtFixedQtyID = document.getElementById("<%=txtFixedQty.ClientID %>");
        var ddlVariableQtyID = document.getElementById("<%=ddlVariableQty.ClientID %>");
        var rdlTimeCostType = document.getElementById("<%=rdlTimeCostType.ClientID %>");

        //** Quantity Based **//
        var txtQtyHourlyRateID = document.getElementById("<%=txtQtyHourlyRate.ClientID %>");
        var txtQtyMakeReadyTimeID = document.getElementById("<%=txtQtyMakeReadyTime.ClientID %>");
        var txtQtyTimePerUnitID = document.getElementById("<%=txtQtyTimePerUnit.ClientID %>");
        var txtQtyUnitCostID = document.getElementById("<%=txtQtyUnitCost.ClientID %>");
        var rdlQtyDefaultValue = document.getElementById("<%=rdlQtyDefaultValue.ClientID %>");
        var txtQtyFixedValueID = document.getElementById("<%=txtQtyFixedValue.ClientID %>");
        var ddlQtyVariableValueID = document.getElementById("<%=ddlQtyVariableValue.ClientID %>");

        //Formula Based//
        var txtFormulaID = document.getElementById("<%=TextBox2.ClientID %>");
        var hid_FormulaTag = document.getElementById("<%=hid_FormulaTag.ClientID %>");

        var CheckFinal = false;
        function CallValidation() {
            CheckFinal = false;
            //left side
            var txtName = trim12(txtNameID.value);
            if (txtName == '') {
                document.getElementById("spn_txtName").style.display = "block";
                CheckFinal = true;
            }
            var ddlCategory = ddlCategoryID.value;
            var ddlCategory = ddlCategoryID.options[ddlCategoryID.selectedIndex].value;


            if (Category_ID == "no") {
                if (ddlCategory == '0') {
                    document.getElementById("spn_ddlCategory").style.display = "block";
                    CheckFinal = true;
                }
            }

            if (CallonChange(document.getElementById("<%=ddlCategory.ClientID %>").value, 'spn_ddlCategory')) {
                CheckFinal = true;
            }

            var ddlCalculation = ddlCalculationID.value;
            if (ddlCalculation == '0') {
                document.getElementById("spn_ddlCalculation").style.display = "block";
                CheckFinal = true;
            }
            var ddlSupplier = ddlSupplierID.value;
            if (ddlSupplier == '0') {
            }
            var txtPerHourCost = trim12(txtPerHourCostID.value);
            if (txtPerHourCost == '') {
            }
            else {
                if (checkDecimals('spn_txtPerHourCost_number', txtPerHourCostID, txtPerHourCost) == false) {
                    CheckFinal = true;
                }
            }
            var txtProfit = trim12(txtProfitID.value);
            if (txtProfit == '') {
            }
            else {
                if (checkDecimals('spn_txtProfit_number', txtProfitID, txtProfit) == false) {
                    CheckFinal = true;
                }
            }
            var txtMinimum = trim12(txtMinimumID.value);
            if (txtMinimum == '') {
                document.getElementById("spn_txtMinimum").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtMinimum_number', txtMinimumID, txtMinimum) == false) {
                    CheckFinal = true;
                }
            }

            //right side
            //** Time Based **//
            var txtHourlyRate = trim12(txtHourlyRateID.value);
            if (txtHourlyRate == '') {
                document.getElementById("spn_txtHourlyRate").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtHourlyRate_number', txtHourlyRateID, txtHourlyRate) == false) {
                    CheckFinal = true;
                }
            }
            var txtMakeReadyTime = trim12(txtMakeReadyTimeID.value);
            if (txtMakeReadyTime == '') {
                document.getElementById("spn_txtMakeReadyTime").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtMakeReadyTime_number', txtMakeReadyTimeID, txtMakeReadyTime) == false) {
                    CheckFinal = true;
                }
            }
            var txtRunSpeed = trim12(txtRunSpeedID.value);
            if (txtRunSpeed == '') {
                document.getElementById("spn_txtRunSpeed").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtRunSpeed_number', txtRunSpeedID, txtRunSpeed) == false) {
                    CheckFinal = true;
                }
            }

            //timehour//
            var optionstime = rdldefaultQty.getElementsByTagName('input');
            var rdlvaluetime = '';
            for (var i = 0; i < optionstime.length; i++) {
                if (optionstime[i].checked) {
                    rdlvaluetime = optionstime[i].value;
                }
            }
            if (rdlvaluetime == 'txt') {
                document.getElementById("spn_ddlVariableQty").style.display = "none";
                var txtFixedQty = trim12(txtFixedQtyID.value);
                if (txtFixedQty == '') {
                    document.getElementById("spn_txtFixedQty").style.display = "block";
                    CheckFinal = true;
                }
                else {
                    if (!CheckDecimalPlus(txtFixedQty, 'spn_txtFixedQty_number', 'spn_txtFixedQty_number', 'yes')) {
                        document.getElementById("spn_txtFixedQty").style.display = "none";
                        CheckFinal = false;
                    }
                }
            }
            else if (rdlvaluetime == 'ddl') {
                document.getElementById("spn_txtFixedQty").style.display = "none";
                var ddlVariableQty = trim12(ddlVariableQtyID.value);
                if (ddlVariableQty == '0') {
                    document.getElementById("spn_ddlVariableQty").style.display = "block";
                    CheckFinal = true;
                }
            }
            //Time Cost type-- l or m
            if (ddlCalculationID.value == "t") {
                var optionshr = rdlTimeCostType.getElementsByTagName('input');
                var rdlvaluehr = '';
                for (var i = 0; i < optionshr.length; i++) {
                    if (optionshr[i].checked) {
                        rdlvaluehr = optionshr[i].value;
                    }
                }
                if (rdlvaluehr == 'm') {

                    document.getElementById("spn_txtRunSpeed_defaultval").style.display = "none";
                    if (txtRunSpeed == '0.000' || txtRunSpeed == '0') {
                        document.getElementById("spn_txtRunSpeed_defaultval").style.display = "block";
                        CheckFinal = true;
                    }
                    else {
                        if (checkDecimals('spn_txtRunSpeed_number', txtRunSpeedID, txtRunSpeed) == false) {
                            CheckFinal = true;
                        }
                    }
                }
            }

            //** Quantity Based **//
            var txtQtyHourlyRate = trim12(txtQtyHourlyRateID.value);
            if (txtQtyHourlyRate == '') {
                document.getElementById("spn_txtQtyHourlyRate").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtQtyHourlyRate_number', txtQtyHourlyRateID, txtQtyHourlyRate) == false) {
                    CheckFinal = true;
                }
            }
            var txtQtyMakeReadyTime = trim12(txtQtyMakeReadyTimeID.value);
            if (txtQtyMakeReadyTime == '') {
                document.getElementById("spn_txtQtyMakeReadyTime").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtQtyMakeReadyTime_number', txtQtyMakeReadyTimeID, txtQtyMakeReadyTime) == false) {
                    CheckFinal = true;
                }
            }
            var txtQtyTimePerUnit = trim12(txtQtyTimePerUnitID.value);
            if (txtQtyTimePerUnit == '') {
                document.getElementById("spn_txtQtyTimePerUnit").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtQtyTimePerUnit_number', txtQtyTimePerUnitID, txtQtyTimePerUnit) == false) {
                    CheckFinal = true;
                }
            }
            var txtQtyUnitCost = trim12(txtQtyUnitCostID.value);
            if (txtQtyUnitCost == '') {
                //alert("hi");
                document.getElementById("spn_txtQtyUnitCost").style.display = "block";
                CheckFinal = true;
            }
            else {
                if (checkDecimals('spn_txtQtyUnitCost_number', txtQtyUnitCostID, txtQtyUnitCost) == false) {
                    CheckFinal = true;
                }
            }

            //rdlqty//
            var options = rdlQtyDefaultValue.getElementsByTagName('input');
            var rdlvalue = '';
            for (var i = 0; i < options.length; i++) {
                if (options[i].checked) {
                    rdlvalue = options[i].value;
                }
            }
            if (rdlvalue == 'txt') {
                var txtQtyFixedValue = trim12(txtQtyFixedValueID.value);
                if (txtQtyFixedValue == '') {
                    document.getElementById("spn_txtQtyFixedValue").style.display = "block";
                    CheckFinal = true;
                }
                else {

                    if (IsIntegerParameter(txtQtyFixedValue, 'spn_txtQtyFixedValue_number') == false) {
                        CheckFinal = true;
                    }
                }
            }
            else if (rdlvalue == 'ddl') {
                var ddlQtyVariableValue = trim12(ddlQtyVariableValueID.value);
                if (ddlQtyVariableValue == '0') {
                    document.getElementById("spn_ddlQtyVariableValue").style.display = "block";
                    CheckFinal = true;
                }
            }

            if (CheckFinal) {
                return false;
            }
            else {
                if (CheckDuplicate) {
                    //yes Its duplicate
                    return false;
                }
                //no duplicate
                return true;
            }
        }
        function booklet(val, divid, i, rowcount) {
            if (val == 'none') {
                document.getElementById("divopen_" + i).style.display = 'none';
                document.getElementById("divclose_" + i).style.display = 'block';
                for (var j = 1; j <= rowcount; j++) {
                    document.getElementById("divbooklet_" + i + "_" + j).style.display = 'none';
                }
            }
            else if (val == 'block') {
                document.getElementById("divopen_" + i).style.display = 'block';
                document.getElementById("divclose_" + i).style.display = 'none';
                for (var j = 1; j <= rowcount; j++) {
                    document.getElementById("divbooklet_" + i + "_" + j).style.display = 'block';
                }
            }
        }

        function addfield() {
            var txtfield = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
            generate_formula('', txtfield.value);
        }


        function ImageButtonPlus_Click() {
            PopupCenter("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg %>" + "1&mode=" + "edit" + "&item=" + "<%=item %>&sender=popup", 1000, 500);
            window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg %>" + "1&mode=" + "edit" + "&item=" + "<%=item %>&sender=popup", 1000, 500);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        function GetSupplier() {
            var hdn_supplierID = document.getElementById("<%=hdn_supplierID.ClientID %>");
            var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID %>");
            hdn_supplierID.value = ddlSupplierID.value;
        }
        function Formula_OnEdit() {
            if ('<%=Action %>' == "edit") {

                var strKey = '<%=FormulaKey %>'.split('±');
                var strVal = '<%=FormulaValue %>'.split('±');
                for (var i = 0; i < strVal.length - 1; i++) {
                    var RE = new RegExp(strVal[i], "m");
                    var match = txtFormulaID.value.toString().match(strVal[i]);
                }

            }
        }
        //Formula_OnEdit();


        function ShowHideMatrixTable(distype) {
            var div_MatrixTable = document.getElementById("div_MatrixTable");
            var ddlCalculation = document.getElementById("<%=ddlCalculation.ClientID %>");
            var ddlSupplier = document.getElementById("<%=ddlSupplier.ClientID %>");
            var ddlCategory = document.getElementById("<%=ddlCategory.ClientID %>");
            var ddlQtyVariableValue = document.getElementById("<%=ddlQtyVariableValue.ClientID %>");

            if (distype == "show") {
                div_MatrixTable.style.display = "block";
                document.getElementById("divBackGroundNew").style.display = "block";
                document.getElementById("divBackGroundNew").style.left = "0px"
                document.getElementById("divBackGroundNew").style.width = "100%";
                document.getElementById("divBackGroundNew").style.height = "650px";
                document.getElementById("divBackGroundNew").style.top = "0px";

                ddlCalculation.style.display = "none";
                ddlSupplier.style.display = "none";
                ddlCategory.style.display = "none";
                ddlQtyVariableValue.style.display = "none";
                document.getElementById("tbl_matrix").style.display = "block";
                document.getElementById("<%=txtprompt.ClientID %>").focus();

            }
            else if (distype == "hide") {
                var matrixval = document.getElementById("ctl00_ContentPlaceHolder1_hdnMatrixValue").value;
                var formulabox = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
                var hdnprevious = document.getElementById("hdnprevious");
                var hdnprevfieldtype = document.getElementById("hdnprevfieldtype");
                var hdnquestion = document.getElementById("hdnquestion");
                document.getElementById("div_MatrixTable").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
                ddlCalculation.style.display = "block";
                ddlSupplier.style.display = "block";
                ddlCategory.style.display = "block";
                ddlQtyVariableValue.style.display = "block";
                if ('<%=Action %>' == "") {
                    if (txtFormulaID.value != "") {
                        if ((hdnprevious.value == '(') || (hdnprevious.value == '+') || (hdnprevious.value == '-') || (hdnprevious.value == '/') || (hdnprevious.value == '*') || (hdnprevious.value == '^') || (hdnprevious.value == '%') || (hdnprevious.value == 'mod')) {
                            if (formulabox.value.indexOf('<<Matrix>>') == -1) {
                                if (trim12(formulabox.value) == "") {
                                    formulabox.value = "<<Matrix>>";
                                }
                                else {
                                    formulabox.value = formulabox.value + "<<Matrix>>";
                                }
                            }
                            hdnprevious.value = "<<matrix>>";
                            hdnprevfieldtype.value = "ex";
                            hdnquestion.value = "0";
                            hid_FormulaTag.value += "Matrix";
                        }
                        else {
                            alert("Please select an operator before assigning an expression (e.g, + - / *) ");
                        }
                    }
                    else {
                        if (formulabox.value.indexOf('<<Matrix>>') == -1) {
                            if (trim12(formulabox.value) == "") {
                                formulabox.value = "<<Matrix>>";
                            }
                            else {
                                formulabox.value = formulabox.value + "<<Matrix>>";
                            }
                        }
                        hdnprevious.value = "<<matrix>>";
                        hdnprevfieldtype.value = "ex";
                        hdnquestion.value = "0";
                        hid_FormulaTag.value += "Matrix";
                    }
                }
                //        }

            }
            else if (distype == "close") {
                document.getElementById("div_MatrixTable").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
                ddlCalculation.style.display = "block";
                ddlSupplier.style.display = "block";
                ddlCategory.style.display = "block";
                ddlQtyVariableValue.style.display = "block";

                var formulabox = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
                if (navigator.appName != "Microsoft Internet Explorer") {
                    formulabox.setSelectionRange(formulabox.value.length, formulabox.value.length);
                }
            }
    }

    function ValidateText(val) {
        var hdnprevious = document.getElementById("hdnprevious");
        var hdnprevfieldtype = document.getElementById("hdnprevfieldtype");
        var txt = val.toString().substring(val.length - 1, val.length);

        if (txt == "(" || txt == ")" || txt == "+" || txt == "-" || txt == "*" || txt == "/" || txt == "%" || txt == "mod") {
            hdnprevious.value = txt;
            hdnprevfieldtype.value = "op";
        }
        else {
            hdnprevious.value = "0";
            hdnprevfieldtype.value = "ex";
        }
    }


    var quesB = '';
    function generate_formula(field, fieldtype, formulatype, formulatag) {

        var hdnprevious = document.getElementById("hdnprevious");
        var txtformula = document.getElementById("<%=TextBox2.ClientID %>");
            var hdnquestion = document.getElementById("hdnquestion");
            var hdnprevfieldtype = document.getElementById("hdnprevfieldtype");
            var hdn_Formula = document.getElementById("<%=hdn_Formula.ClientID %>");

            //swetha
            if (txtformula.value == "") {

                if (field == "+" || field == "-" || field == "*" || field == "/" || field == "%" || field == "^" || field == "mod") {
                    alert("Please select an operator before assigning an expression (e.g, + - / *) ");
                }
                else {
                    insertAtCaret(field);
                    hdnprevious.value = field;
                    hdnprevfieldtype.value = fieldtype;
                    hdnquestion.value = "0";
                    if (formulatype != "Q") {
                        quesB += "B" + "»" + field + "»" + formulatag + "±";
                    }
                    else if (formulatype == "Q") {
                        quesB += "Q" + "»" + field + "»" + formulatag + "±";
                    }
                    hid_FormulaTag.value += formulatag;
                }
            }
            else {
                if (hdnprevfieldtype.value == fieldtype) {
                    if (fieldtype == "op") {
                        if (field == "(") {
                            if ((hdnprevious.value == '(') || (hdnprevious.value == ')') || (hdnprevious.value == '+') || (hdnprevious.value == '-') || (hdnprevious.value == '/') || (hdnprevious.value == '*') || (hdnprevious.value == '^') || (hdnprevious.value == '%') || (hdnprevious.value == 'mod')) {
                                insertAtCaret(field);
                                hdnprevious.value = field;
                                hdnprevfieldtype.value = fieldtype;
                                hdnquestion.value = "0";
                                if (formulatype != "Q") {
                                    quesB += "B" + "»" + field + "»" + formulatag + "±";
                                }
                                else if (formulatype == "Q") {
                                    quesB += "Q" + "»" + field + "»" + formulatag + "±";
                                }
                                hid_FormulaTag.value += field + formulatag;
                            }
                            else {
                                if (hdnprevious.value != "(" || hdnprevious.value != ")") {
                                    alert("Please select an operator before assigning an expression (e.g, + - / *) ");
                                }
                            }
                        }
                        else if (field == ")") {
                            if ((hdnprevious.value == '(') || (hdnprevious.value == ')') || (hdnprevious.value == '+') || (hdnprevious.value == '-') || (hdnprevious.value == '/') || (hdnprevious.value == '*') || (hdnprevious.value == '^') || (hdnprevious.value == '%') || (hdnprevious.value == 'mod')) {
                                insertAtCaret(field);
                                hdnprevious.value = field;
                                hdnprevfieldtype.value = fieldtype;
                                hdnquestion.value = "0";
                                if (formulatype != "Q") {
                                    quesB += "B" + "»" + field + "»" + formulatag + "±";
                                }
                                else if (formulatype == "Q") {
                                    quesB += "Q" + "»" + field + "»" + formulatag + "±";
                                }
                                hid_FormulaTag.value += field + formulatag;
                            }
                            else {
                                if (hdnprevious.value != "(" || hdnprevious.value != ")") {
                                    alert("Please select an operator before assigning an expression (e.g, + - / *)");
                                }
                            }
                        }
                        else if (hdnprevious.value == "(") {
                            insertAtCaret(field);
                            hdnprevious.value = field;
                            hdnprevfieldtype.value = fieldtype;
                            hdnquestion.value = "0";
                            if (formulatype != "Q") {
                                quesB += "B" + "»" + field + "»" + formulatag + "±";
                            }
                            else if (formulatype == "Q") {
                                quesB += "Q" + "»" + field + "»" + formulatag + "±";
                            }
                            hid_FormulaTag.value += field + formulatag;
                        }
                        else if (hdnprevious.value == ")") {
                            if ((field == ')') || (field == '(') || (field == '+') || (field == '-') || (field == '/') || (field == '*') || (field == '^') || (field == '%') || (field == 'mod')) {
                                insertAtCaret(field);
                                hdnprevious.value = field;
                                hdnprevfieldtype.value = fieldtype;
                                hdnquestion.value = "0";
                                if (formulatype != "Q") {
                                    quesB += "B" + "»" + field + "»" + formulatag + "±";
                                }
                                else if (formulatype == "Q") {
                                    quesB += "Q" + "»" + field + "»" + formulatag + "±";
                                }
                                hid_FormulaTag.value += field + formulatag;
                            }
                            else {
                                if (field != ")" || field != "(") {
                                    alert("Please select an operator before assigning an expression (e.g, + - / *) ");
                                }
                            }
                        }
                        else if (hdnprevious.value == "0") {
                            insertAtCaret(field);
                            hdnprevious.value = field;
                            hdnprevfieldtype.value = fieldtype;
                            hdnquestion.value = "0";
                            if (formulatype != "Q") {
                                quesB += "B" + "»" + field + "»" + formulatag + "±";
                            }
                            else if (formulatype == "Q") {
                                quesB += "Q" + "»" + field + "»" + formulatag + "±";
                            }
                            hid_FormulaTag.value += field + formulatag;
                        }
                        else {
                            if (field != ")" || field != "(") {
                                alert("Please assign an expression before adding an operator (e.g, + - / *) ");
                            }
                        }
                    }
                    else {
                        insertAtCaret(field);
                        hdnprevious.value = field;
                        hdnprevfieldtype.value = fieldtype;
                        hdnquestion.value = "0";
                        if (formulatype != "Q") {
                            quesB += "B" + "»" + field + "»" + formulatag + "±";
                        }
                        else if (formulatype == "Q") {
                            quesB += "Q" + "»" + field + "»" + formulatag + "±";
                        }
                        hid_FormulaTag.value += field + formulatag;
                    }
                }
                else {
                    if (field == "(") {
                        if ((hdnprevious.value == '0') || (hdnprevious.value == '(') || (hdnprevious.value == ')') || (hdnprevious.value == '+') || (hdnprevious.value == '-') || (hdnprevious.value == '/') || (hdnprevious.value == '*') || (hdnprevious.value == '^') || (hdnprevious.value == '%') || (hdnprevious.value == 'mod')) {
                            insertAtCaret(field);
                            hdnprevious.value = field;
                            hdnprevfieldtype.value = fieldtype;
                            hdnquestion.value = "0";
                            if (formulatype != "Q") {
                                quesB += "B" + "»" + field + "»" + formulatag + "±";
                            }
                            else if (formulatype == "Q") {
                                quesB += "Q" + "»" + field + "»" + formulatag + "±";
                            }
                            if (fieldtype == "op") {
                                hid_FormulaTag.value += field + formulatag;
                            }
                            else {
                                hid_FormulaTag.value += formulatag;
                            }
                        }
                        else {
                            if (hdnprevious.value != "(" || hdnprevious.value != ")" || hdnprevious.value != "0") {
                                alert("Please select an operator before assigning an expression (e.g, + - / *) ");
                            }
                        }
                    }
                    else if (hdnprevious.value == ")") {
                        insertAtCaret(field);
                        hdnprevious.value = field;
                        hdnprevfieldtype.value = fieldtype;
                        hdnquestion.value = "0";
                        if (formulatype != "Q") {
                            quesB += "B" + "»" + field + "»" + formulatag + "±";
                        }
                        else if (formulatype == "Q") {
                            quesB += "Q" + "»" + field + "»" + formulatag + "±";
                        }
                        if (fieldtype == "op") {
                            hid_FormulaTag.value += field + formulatag;
                        }
                        else {
                            hid_FormulaTag.value += formulatag;
                        }
                    }
                    else {
                        insertAtCaret(field);
                        hdnprevious.value = field;
                        hdnprevfieldtype.value = fieldtype;
                        hdnquestion.value = "0";
                        if (formulatype != "Q") {
                            quesB += "B" + "»" + field + "»" + formulatag + "±";
                        }
                        else if (formulatype == "Q") {
                            quesB += "Q" + "»" + field + "»" + formulatag + "±";
                        }
                        if (fieldtype == "op") {
                            hid_FormulaTag.value += field + formulatag;
                        }
                        else {
                            hid_FormulaTag.value += formulatag;
                        }
                    }
                }
            }
            hdn_Formula.value = quesB;
        }

        function clear_formula() {
            quesB = '';
            document.getElementById("hdnresult").value = "";
            document.getElementById("<%=TextBox2.ClientID %>").value = "";
            document.getElementById("formalcount").value = "0";
            document.getElementById("hdnprevious").value = "";
            //    }
        }
    </script>
    <script>

        function addquestion(type) {
            var formalcount = document.getElementById("formalcount").value;
            var previous = document.getElementById("hdnprevious").value;
            var txtresult = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
            var txtquestion = document.getElementById("ctl00_ContentPlaceHolder1_txtquestion");
            var hdnprevfieldtype = document.getElementById("hdnprevfieldtype");
            var hdnquestion = document.getElementById("hdnquestion");
            var result = txtresult.value;

            if (txtquestion.value == '') {
                document.getElementById("diverror").style.display = "block";
            }
            else {
                document.getElementById("diverror").style.display = "none";
                document.getElementById("formalcount").value = "1";
                var StrTemp = txtquestion.value;

                StrTemp = StringToRepalce(StrTemp);
                hdnquestion.value = "0";
                var nVer = navigator.appVersion;
                var nAgt = navigator.userAgent;
                // In Chrome, the true version is after "Chrome" 
                if ((verOffset = nAgt.indexOf("Chrome")) != -1) {
                    browserName = "Chrome";
                }
                    // In Safari, the true version is after "Safari" or after "Version" 
                else if ((verOffset = nAgt.indexOf("Safari")) != -1) {
                    browserName = "Safari";
                }
                    // In Firefox, the true version is after "Firefox" 
                else if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
                    browserName = "Firefox";
                }
                else {
                    browserName = "IE";
                }

                if (browserName == "IE")
                { txtresult.value += "<<Q:: " + StrTemp + ">>"; }
                else
                { generate_formula("<<Q:: " + StrTemp + ">>", "ex", "Q", "ques"); }

                //generate_formula("<<Q:: " + StrTemp + ">>", "ex", "Q", "ques");
                showhide('hide');
            }
        }
        function StringToRepalce(strData) {
            strData = strData.replace(/Q::/gi, "Q:");
            strData = strData.replace(/\+/gi, "Plus");
            strData = strData.replace(/\-/gi, "Minus");
            strData = strData.replace(/\//gi, 'Divide');
            strData = strData.replace(/\*/gi, 'Multiply');
            strData = strData.replace(/\%/gi, 'Percentage');
            strData = strData.replace(/\^/gi, 'Cap');

            return strData;
        }



        function ShowHideQuestionTable(distype) {

            showhide(distype); //swetha
        }

        function showhide(distype) {
            var div_QuestionTable = document.getElementById("div_QuestionTable");
            document.getElementById("div_QuestionTable").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            if (distype == "show") {
                showDivPopupCenter('div_QuestionTable', '350');
                document.getElementById("<%=ddlCategory.ClientID %>").style.display = "none";
                document.getElementById("<%=ddlCalculation.ClientID %>").style.display = "none";
                document.getElementById("<%=ddlSupplier.ClientID %>").style.display = "none";

            }
            else if (distype == "hide") {
                document.getElementById("div_QuestionTable").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
                document.getElementById("<%=ddlCategory.ClientID %>").style.display = "block";
                document.getElementById("<%=ddlCalculation.ClientID %>").style.display = "block";
                document.getElementById("<%=ddlSupplier.ClientID %>").style.display = "block";
            }
    }
    </script>
    <asp:Panel ID="pnlShowOnCalType" Visible="false" runat="server">
        <script>
            function calmethodonedit() {
                var CalMethod = '<%=CalMethod %>';
                var sub = document.getElementById("<%=ddlCalculation.ClientID %>");
                for (var k = 0; k < sub.length; k++) {
                    if (sub.options[k].value == CalMethod) {
                        sub.selectedIndex = k;
                    }
                }
                LoadMethods(CalMethod);

            }
            calmethodonedit();
        </script>
    </asp:Panel>
    <script>
        function AddQuestion() {
            showDivPopupCenter('div_QuestionTable', '200');
            document.getElementById("<%=txtquestion.ClientID %>").focus();
        }
    </script>
    <script type="text/javascript">
        var txtOtherCostCategoryName = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>");
        function CategoryValidate() {
            if (CheckStringMandatory(txtOtherCostCategoryName.value, 'spn_txtOtherCostCategoryName')) {
            }
            else {
            }
        }

        function AddCategory(type) {
            var div_Obj = document.getElementById("div_OtherCost_add_item");
            var btnCategorySave = document.getElementById("<%=btnCategorySave.ClientID %>");
            var txtOtherCostCategoryName = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>");
            if (type == "add") {
                //IEB,on  22.09.2011...
                if (navigator.appName != "Microsoft Internet Explorer") {
                    setLoadingPositionOfDivMove(div_Obj);
                }
                showDivPopupCenter('div_OtherCost_add_item', '200');
                txtOtherCostCategoryName.focus();
            }
            else if (type == "edit") {
                txtOtherCostCategoryName.focus();
            }
            else {
                document.getElementById("div_OtherCost_add_item").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
            }

        }




    </script>
    <script>
        function findduplicatenew(name) {
            if (name != '') {
                var compID = '<%=CompanyID %>';
                var OtherCostCategoryid = 0;
                var val = compID + "&" + name + "&" + OtherCostCategoryid;
                PageMethods.FindDuplicateCategory(val, FindSuccNew1, ShowMsg_Failure1);
            }
        }
        function ShowMsg_Failure1(error) { }
        var CheckDuplicateCategory = false;
        function FindSuccNew1(result) {
            if (result == -1) {
                document.getElementById("spn_alreadyExistCategory").style.display = "block";
                CheckDuplicateCategory = true;
            }
            else {
                document.getElementById("spn_alreadyExistCategory").style.display = "none";
                CheckDuplicateCategory = false;
            }
        }

        function checkduplicateName() {
            var CheckValidationCategory = false;
            document.getElementById('spn_txtOtherCostCategoryName').style.display = "none";
            //Added on 15.09.2011
            if (txtOtherCostCategoryName.value == '') {
                document.getElementById('spn_txtOtherCostCategoryName').style.display = "block";
            }
            else {
                document.getElementById("div_OtherCost_add_item").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
            }

            var txtname = document.getElementById("<%=txtOtherCostCategoryName.ClientID %>").value;
            if (trim12(txtname) == '') {
                document.getElementById('spn_txtOtherCostCategoryName').style.display = "block";
                CheckValidationCategory = true;
            }
            if (CheckValidationCategory) {
                return false;
            }
            else {
                if (CheckDuplicateCategory) {
                    return false;
                }
                else {
                    Category_ID = "Yes";
                    return true;
                }
            }
        }
        // For Bug ID: 836
        function OnblurValidate(val, spanid) {

            if (trim12(val) > 1) {

                document.getElementById(spanid).style.display = "none";
                document.getElementById("spn_txtRunSpeed_defaultval").style.display = "none";
            }
            else {
                document.getElementById(spanid).style.display = "block";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

