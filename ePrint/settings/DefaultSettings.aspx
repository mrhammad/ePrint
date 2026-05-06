<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="DefaultSettings.aspx.cs" Inherits="ePrint.settings.DefaultSettings" title="Default Settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .simpledropdown {
            width: 89px;
            border: solid 1px #ABADB3;
            font-size: 11px;
            color: #000000;
            font-family: "segoe ui",arial,sans-serif;
            padding: 1px 1px 1px 1px;
            outline: none;
        }
    </style>
    <div align="left">
        <div align="left">
            <div id="content" style="padding-bottom: 10px;" class="estore_settingBox">
                <UC:Header_MIS ID="header_mis" runat="server" />
                <div class="mis_header_panel">
                    <div align="left" style="width: 100%">
                        <div style="width: 34%">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 99%;">
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Estimate_Type")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <asp:DropDownList ID="ddlEstimateType" CssClass="normalText" runat="server">
                                    <asp:ListItem Text="--- Select ---" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%-- <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Estimate_Valid_For")%></span>
                                <span style="color: red">*</span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left">
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtValidFor" runat="server" Width="50px" SkinID="textPad" MaxLength="6"
                                            onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);">30</asp:TextBox><span
                                                class="normaltext" style="padding-left: 4px;"><%=objlang.GetLanguageConversion("Days_from_todays_date")%></span>
                                    </div>
                                    <div class="ValidationMessage">
                                        <asp:RequiredFieldValidator ID="rfv_txtValidFor" runat="server" ControlToValidate="txtValidFor"
                                            ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                            CssClass="spanerrorMsg"><%=objLanguage.GetLanguageConversion("Default_days_Validation")%>
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext"><b>
                                    <%=objLanguage.GetLanguageConversion("Default_Number_of_Days_from_Todays_Date")%></b></span>
                            </div>
                        </div>
                        <div align="left" id="div_Default_Arkwork" runat="server">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_ArtWork") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateArtwork" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtDefaultEstimated" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDefaultEstimated"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" CssClass="spanerrorMsg"
                                        ValidationGroup="AddEstimate"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left" id="div_DefaultProof" runat="server">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Proof") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateProof" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateProof');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimateProof" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEstimateProof"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Approval") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateApproval" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_TxtEstimateApproval');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="TxtEstimateApproval" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtEstimateApproval"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Production") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateProduction" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateProduction');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimateProduction" runat="server" Width="50px" MaxLength="3"
                                        SkinID="textPad" onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEstimateProduction"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Completion")%></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateCompletion" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimatedCompletion');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimatedCompletion" runat="server" Width="50px" MaxLength="3"
                                        SkinID="textPad" onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEstimatedCompletion"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Delivery")%></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateDelivery" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateDelivery');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtEstimateDelivery" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                            <div class="ValidationMessage">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEstimateDelivery"
                                    ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                    CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Working_Days") %></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:DropDownList ID="ddlWorkingFrom" CssClass="simpledropdown" runat="server">
                                        <asp:ListItem Text="Sunday" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Monday" Value="2" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Tuesday" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Wednesday" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Thursday" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Friday" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Saturday" Value="7"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                    <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("To") %></span>
                                </div>
                                <div align="left" style="float: left; padding-left: 10px;">
                                    <asp:DropDownList ID="ddlWorkingTo" CssClass="simpledropdown" runat="server">
                                        <asp:ListItem Text="Sunday" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Monday" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Tuesday" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Wednesday" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Thursday" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Friday" Value="6" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Saturday" Value="7"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="divpriceforwholepack" runat="server" style="display: none;" align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Price_For_Whole_Pack")%>
                                </span>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkDefaultPackPrice" runat="server" />
                            </div>
                            <div style="float: left; padding-top: 3px;">
                                <span class="smallgraytext">(<%=objlang.GetLanguageConversion("Price_For_Whole_Pack_Note")%></span>
                            </div>
                        </div>
                        <div align="left" style="display: none">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetValueOnLang("Round off Numbers to")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left">
                                    <asp:DropDownList ID="ddlroundoff" CssClass="normalText" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList>
                                    <span class="normaltext">
                                        <%=objlang.GetValueOnLang("Decimals")%></span>
                                </div>
                            </div>
                        </div>
                        
                        <div align="left">
                            <div id="divDefaultPaperSize" runat="server" class="bglabel" style="width: 210px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Paper_Size")%></span>
                            </div>
                            <div id="divddlPaperSize" runat="server" class="DefaultSettingsbox">
                                <div align="left" style="padding-top: 2px;">
                                    <asp:DropDownList ID="ddlPaperSize" runat="server">
                                        <asp:ListItem Value="0" Text="Dropdown"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Custom"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Update_Item_Description") %></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkUpdateItemDescription" runat="server" />
                                    <span class="smallgraytext" style="margin-left: -4px; vertical-align: 3px;">
                                        <%=objlang.GetLanguageConversion("Update_Item_Description_By_Default")%></span>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext"><b>
                                    <%=objlang.GetLanguageConversion("Item_Description_Prefill_from_Settings_Phrase_Book")%></b></span>
                            </div>
                        </div>
                        <%-- Added by Naveen for 7559--%>
                        <div align="left">
                            <div id="div_Digitalsingle" runat="server" class="bglabel" style="width: 200px;">
                                <span class="normaltext Estimatespn1">
                                    <%=objlang.GetLanguageConversion("Sheet_Fed_Digital")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkdigitalsingle" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Single")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkDigitalBooklet" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Booklet")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkDigitalPad" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Pad")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div id="div_Digital_Booklet" runat="server" class="bglabel" style="width: 200px;">
                                <span class="normaltext Estimatespn1">
                                    <%=objlang.GetLanguageConversion("Sheet_Fed_Offset")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkOffsetSingle" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Single")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkOffsetBooklet" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Booklet")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkOffsetPad" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Pad")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkOffsetNCR" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("NCR")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div id="div_Large_Format" runat="server" class="bglabel" style="width: 200px;">
                                <span class="normaltext Estimatespn1">
                                    <%=objlang.GetLanguageConversion("Large_Format")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chkLinear" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Linear")%></span>
                                    </div>
                                </div>
                                <div class="sheetfedCheckbox">
                                    <asp:CheckBox ID="chksqrmeter" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="SheetFedprefil">
                                        <span>
                                            <%=objlang.GetLanguageConversion("Square_Meter")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox sheetfedNote">
                            <span class="smallgraytext" style="padding-left: 2px;">
                                <%=objlang.GetLanguageConversion("Please_Note_This_setting_only_applicable_for_Item")%> <%=objPage.GetRegionalSettings(CompanyID, "Colour")%><%=objlang.GetLanguageConversion("Item_Size_Item_Material_description_fields")%>
                            </span>
                        </div>

                        <div align="left">
                            <div id="div1" runat="server" class="bglabel" style="width: 200px;">
                                <span class="normaltext Estimatespn1">
                                    Outwork</span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div class="outworkCheckbox" style="float:left;">
                                    <asp:CheckBox ID="chkCopyDescFieldsToSupplier" runat="server" />
                                </div>
                                <div style="float: left; padding-top: 3px;">
                                    <div class="Outworkprefil">
                                        <span>
                                          Copy the item description fields to supplier request for quote item description fields
                                        </span>
                                    </div>
                                </div>
                                <br /><br />
                                <div class="outworkCheckbox" style="float:left;padding-right: 3px;"">
                                    <asp:CheckBox ID="chkOutworkDescBoxesEnable" runat="server" />
                                </div>
                                <div style="float: left; padding-top: 3px;">
                                    <div class="Outworkprefil">
                                        <span>
                                          Don't tick outwork update description boxes by default
                                        </span>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_Outwork_Markup_Type")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left">
                                    <asp:DropDownList ID="ddlMarkuptype" CssClass="normalText" runat="server" Width="45px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Default_outwork_costing_Type")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <asp:DropDownList ID="ddlCostingType" CssClass="normalText" runat="server">
                                    <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Simple Costing" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Unit Based Costing" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="" Value="3"></asp:ListItem>
                                    <%--<asp:ListItem Text="Per 1000 Costing " Value="3"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <%--END--%>
                        <div class="only10px">
                        </div>
                        <div align="left">
                            <div id="divRoundoffnearest" class="bglabel" style="width: 200px; height: 15px" runat="server">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Round_Off_Subtotal")%></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left">
                                    <asp:DropDownList ID="ddlRoundoffnearest" runat="server" onchange="javascript:ddlSelection();">
                                        <asp:ListItem Value="0" Text="None"></asp:ListItem>
                                        <asp:ListItem Value=".00" Text="2 Decimal"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Nearest 1"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Nearest 5"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Nearest 10"></asp:ListItem>
                                        <asp:ListItem Value="50" Text="Nearest 50"></asp:ListItem>
                                        <asp:ListItem Value="100" Text="Nearest 100"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Highlight_selling_price_in_red") %></span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="margin-left: -3px;">
                                    <asp:CheckBox ID="chk_Highlight_selling_price" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="DefaultSettingsbox show_hide">
                                <div style="float: left; margin-left: -3px; margin-bottom: -3px;">
                                    <table>
                                        <tr>
                                            <td>
                                                <div id="divRoundLock" runat="server">
                                                    <asp:CheckBox ID="chkRoundLock" runat="server" />
                                                </div>
                                            </td>
                                            <td>
                                                <div id="divtdmargin" runat="server">
                                                    <span class="normaltext">
                                                        <%=objlang.GetLanguageConversion("Round_Lock")%></span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objLanguage.GetLanguageConversion("While_progressing_an_Estimate_to_become_a_Job_tick_the_following_by_default")%>
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="float: left; margin-left: -3px;">
                                    <asp:CheckBox ID="chk_isPORaise" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div style="width: 100px; padding-top: 3px;">
                                        <span>
                                            <%=objLanguage.GetLanguageConversion("Raise_Purchase_Order")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="float: left; margin-left: -3px;">
                                    <asp:CheckBox ID="chk_isDeliveryRaise" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div style="width: 100px; padding-top: 3px;">
                                        <span>
                                            <%=objLanguage.GetLanguageConversion("Raise_Delivery_Note")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px; height: 38px;">
                                <span class="normaltext">
                                    <%=objLanguage.GetLanguageConversion("Combine_items_for_the_same_supplier_on_one_Outwork_PO")%>
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkCombineSupplier" Checked="true" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <div class="DefaultSettingsbox sheetfedNote">
                                        <span class="smallgraytext">
                                            <%=objLanguage.GetLanguageConversion("If_selected_the_system_will_detect_if_a_job_has_more_then_1_item_for_the_same_supplier_and_if_so_will_put_all_items_for_the_supplier_onto_1_PO")%></span>
                                    </div>
                                </div>
                            </div>

                          
                        </div>

                           <div align="left">
                            <div class="bglabel" style="width: 200px; height: 38px;">
                                <span class="normaltext">
                                     In delivery note descriptions don't include description headings
                                </span>
                            </div>
                                <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkAddDescHeadings" Checked="false" runat="server" />
                                </div>
                              <%--  <div style="float: left;">
                                    <div class="DefaultSettingsbox">
                                        <span class="smallgraytext">
                                           In delivery note descriptions don't include description headings</span>
                                    </div>
                                </div>--%>
                            </div>
                           

                          
                        </div>







                         





                        <div align="left">
                            <div id="divDefaultProductCatalogue" runat="server" class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                     <%=objLanguage.GetLanguageConversion("Product_catalogue_default_item")%></span>
                            </div>
                            <div id="divddlProductCatalogue" runat="server" class="DefaultSettingsbox">
                                <div align="left" style="padding-top: 2px;">
                                    <asp:DropDownList ID="ddlProductCatalogue" runat="server">
                                        <asp:ListItem Value="S" Text="Specific Customer"></asp:ListItem>
                                        <asp:ListItem Value="A" Text="All Items"></asp:ListItem>
                                        <asp:ListItem Value="U" Text="Unallocated Items"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext"> 
                                      <%=objLanguage.GetLanguageConversion("Display_catalogue_print_ready_file")%>
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkProductAttachment" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       <%=objLanguage.GetLanguageConversion("Display_approved_orders")%>
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkOrderApproval" runat="server" />
                                </div>
                            </div>
                        </div>

                        <%-- start --%>

                        <div align="left">
                            <div class="bglabel" style="width:200px;">
                                <span class="normalText">
                                    Allow sorting of items
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px">
                                    <asp:CheckBox  ID="chkSortingItems" visible="false" runat="server"/>
                                    <asp:RadioButton ID="rdFromPopup" runat="server" Text="From popup" GroupName="reorder" />  
                                    <br />
                                    <asp:RadioButton ID="rdFromSummary" runat="server" Text="Item Drag and Drop" GroupName="reorder" />  
                                    <br />
                                    <asp:RadioButton ID="rdNone" runat="server" Text="None" GroupName="reorder" />  
                                </div>

                            </div>

                        </div>

                        <%-- end --%>
                        <%-- start --%>

                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       Open on summary panel for condensed view
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkSumCondensedView" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       Show Priority on Creation
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkEnblePriority" runat="server" />
                                </div>
                            </div>
                        </div>


                           <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       <%=objLanguage.GetLanguageConversion("Default_invoice_payment_method")%>
                                </span>
                            </div>
                              <div class="DefaultSettingsbox">
                                <div align="left" style="padding-top: 2px;">
                                    <asp:DropDownList ID="ddlPaymentMethod" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                         <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       <%=objLanguage.GetLanguageConversion("3_Decimals_for_Paper_Sizes")%>
                                </span>
                            </div>
                              <div class="DefaultSettingsbox">
                                <div align="left" style="padding-top: 2px;">
                                    <asp:CheckBox ID="chk3DecimalPlaces" runat="server" />
                                </div>
                            </div>
                        </div>

                         <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       <%=objLanguage.GetLanguageConversion("Mandatory_Replenishments")%>
                                </span>
                            </div>
                              <div class="DefaultSettingsbox">
                                <div align="left" style="padding-top: 2px;">
                                    <asp:CheckBox ID="ChkMandatoryReplenishments" runat="server" />
                                </div>
                            </div>
                        </div>
                        <%-- <div align="left" style="display:none">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                       Update Unit Price
                                </span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div style="margin-left: -3px;">
                                    <asp:CheckBox ID="chkUnitPrice" runat="server" />
                                </div>
                            </div>
                        </div>--%>

                        <%-- end --%>
                    </div>
                    <div class="only5px">
                    </div>
                    <div align="left">
                        <div class="bglabelEmpty" style="width: 200px;">
                        </div>
                        <div class="DefaultSettingsbox">
                            <div style="float: left;">
                                <div id="div_btnCancel" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                        runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_onClick">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_btnCancelprocess" class="button" align="center" style="height: 14px; width: 43px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div style="float: left;">
                                <div id="div_btnsave" style="display: block; margin-top: -1px;">
                                    <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                                        OnClick="btnSave_OnClick" OnClientClick="if(Page_ClientValidate()){javascript:loadingimage(this.id,'div_btnsaveprocess');}else{return false;}" />
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    <%--    var txtDefaultEstimated = document.getElementById("<%=txtDefaultEstimated.ClientID %>");
        var txtEstimateProof = document.getElementById("<%=txtEstimateProof.ClientID %>");
        var TxtEstimateApproval = document.getElementById("<%=TxtEstimateApproval.ClientID %>");
        var txtEstimateProduction = document.getElementById("<%=txtEstimateProduction.ClientID %>");
        var txtEstimatedCompletion = document.getElementById("<%=txtEstimatedCompletion.ClientID %>");
        var txtEstimateDelivery = document.getElementById("<%=txtEstimateDelivery.ClientID %>");

        var chkEstimateArtwork = document.getElementById("<%=chkEstimateArtwork.ClientID %>");
        var chkEstimateProof = document.getElementById("<%=chkEstimateProof.ClientID %>");
        var chkEstimateApproval = document.getElementById("<%=chkEstimateApproval.ClientID %>");
        var chkEstimateProduction = document.getElementById("<%=chkEstimateProduction.ClientID %>");
        var chkEstimateCompletion = document.getElementById("<%=chkEstimateCompletion.ClientID %>");
        var chkEstimateDelivery = document.getElementById("<%=chkEstimateDelivery.ClientID %>");--%>

    </script>
    <script src="../js/settings.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
