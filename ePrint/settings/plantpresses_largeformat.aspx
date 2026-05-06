<%@ Page Language="C#" MasterPageFile="~/Templates/settingpage.master" AutoEventWireup="true" CodeBehind="plantpresses_largeformat.aspx.cs" Inherits="ePrint.settings.plantpresses_largeformat" Title="Settings: Large Format" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var path = "<%=sitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = "<%=UserID%>";
        var InkToPress_Validation = "<%=InkToPress_Validation%>";
        var White_Ink = "<%=White_Ink%>";
        var WhiteInkToPress_Validation = "<%=WhiteInkToPress_Validation%>";
    </script>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings")%>:<%=objLanguage.GetLanguageConversion("Large_Format_Press_Paper_Plant_Properties")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div style="width: 100%;" class="mis_header_panel">
                <div id="">
                    <div style="float: left; border: 0px solid; width: 100%">
                        <div align="left" id="tabs" style="width: 100%">
                            <div align="left" style="width: 100%; display: none">
                                <div style="clear: both;">
                                    &nbsp;
                                </div>
                                <div id="ynnav">
                                    <ul>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_11" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_1" class="lnkTabSelected" style="color: Orange;" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Feed Restrictions")%>
                                                </span></b>
                                            </div>
                                        </li>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_22" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_2" class="lnkTabSelected" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Paper Settings")%>
                                                </span></b>
                                            </div>
                                        </li>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_33" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_3" class="lnkTabSelected" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Plant Properties")%>
                                                </span></b>
                                            </div>
                                        </li>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_44" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_4" class="lnkTabSelected" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Plant Calculation")%>
                                                </span></b>
                                            </div>
                                        </li>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_55" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_5" class="lnkTabSelected" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Plant Charges")%>
                                                </span></b>
                                            </div>
                                        </li>
                                        <li style="cursor: pointer; margin-right: 3px; float: left; clear: right;">
                                            <div id="div_66" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px;">
                                                <b><span id="spn_6" class="lnkTabSelected" onclick="javascript:changeCss(this.id);">
                                                    <%=objlang.GetValueOnLang("Ink Order")%>
                                                </span></b>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div style="clear: both;">
                                </div>
                            </div>
                            <div style="width: 100%;">
                                <div id="div_Feed_restriction" style="display: block;">
                                    <div class="onlyEmpty">
                                    </div>
                                    <div align="center">
                                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                            <ContentTemplate>
                                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <%--LEFT--%>
                                    <div style="float: left; width: 49%;">
                                        <div style="float: left; width: 100%;">
                                            <div align="left">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label18" runat="server" Text="Name" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="box">
                                                    <div style="width: 175.5px">
                                                        <asp:TextBox ID="txtLargeFormatName" runat="server" SkinID="textPad" onblur="CheckLargeFormat(this.value);CallonBlur(this.value,'spn_txtLargeFormatName');"
                                                            TabIndex="1" MaxLength="50" CssClass="textboxnew1"></asp:TextBox>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtLargeFormatName" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_Enter_Name") %>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtPlantPressCheck" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Press_Name_already_exists")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="height: 84px;">
                                                    <asp:Label ID="Label10" runat="server" Text="Description"></asp:Label>
                                                </div>
                                                <div class="box">
                                                    <div style="width: 175.5px">
                                                        <asp:TextBox ID="txtDescription" Rows="2" Height="80px" runat="server" TextMode="MultiLine"
                                                            SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"
                                                            onblur="CheckLength('spn_txtDescription_length');" TabIndex="2" CssClass="textboxnew1"></asp:TextBox>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtDescription_length" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                <%=objlang.GetLanguageConversion("Max_length_of_textbox_is")%>: 3000</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left" runat="server" id="div_AccountCode">
                                                <div class="bglabel">
                                                    <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="ddlsetting" style="padding-left: 5px">
                                                    <asp:DropDownList ID="ddlAccountCode" runat="server" Width="150px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <asp:HiddenField ID="hdnAccountCode" runat="server" />
                                            <div class="onlyEmpty">
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="white-space: nowrap">
                                                    <span style="word-wrap: normal;">
                                                        <%=objLanguage.GetLanguageConversion("Min_Sheet_Height_Length")%></span><span style="color: red; padding-left: 2px;">*</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtMinimumWebWidth" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtMinimumWebWidth');
                                                        IsDecimalValue(this.value,'spn_txtMinWebWidth_number')"
                                                        TabIndex="3" MaxLength="20"
                                                        CssClass="textboxnew1" Width="140px" Style="text-align: right"></asp:TextBox>
                                                    <asp:Label ID="lblMinWebWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMinimumWebWidth" style="display: none; width: auto; float: left">
                                                        <div>
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px" class="spanerrorMsg">
                                                                <%=objlang.GetLanguageConversion("Please_Enter_Min_Web_Width") %></span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMinWebWidth_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label5" runat="server" Text="Maximum Sheet Width" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtMaximumWebWidth" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtMaximumWebWidth');"
                                                        TabIndex="4" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right"></asp:TextBox>&nbsp;<asp:Label
                                                            ID="lblMaxWebWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMaximumWebWidth" style="display: none; width: auto; float: left">
                                                        <div>
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;" class="spanerrorMsg">
                                                                <%=objlang.GetLanguageConversion("Please_Enter_Max_Web_Width") %>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMaxWidth_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left" style="white-space: nowrap">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label6" runat="server" Text="Maximum Sheet Weight" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtMaximumSheetWeight" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtMaximumSheetWeight');"
                                                        TabIndex="5" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right"></asp:TextBox>&nbsp;<asp:Label
                                                            ID="lblSheetWeight" runat="server" CssClass="normalText"><%=Weight %></asp:Label>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMaximumSheetWeight" style="display: none; width: auto; float: left">
                                                        <div>
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;" class="spanerrorMsg">
                                                                <%=objlang.GetLanguageConversion("Please_Enter_Max_Sheet_Weight")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtMaxSheetWeight_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="header">
                                                <span class="HeaderText">
                                                    <%=objLanguage.GetLanguageConversion("Press_Restrictions")%></span>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label20" runat="server" Text="Grip Side Orientation" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="ddlsetting">
                                                    <asp:DropDownList ID="ddlGripSideOrientation" runat="server" CssClass="normalText"
                                                        Width="145px" TabIndex="6">
                                                        <asp:ListItem Value="-1" Text="None"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="Long Side"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Short Side"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label21" runat="server" Text="Grip Depth" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtGripDepth" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtGripDepth');"
                                                        TabIndex="7" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right">0</asp:TextBox>&nbsp;<asp:Label
                                                            ID="lblGripDepth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtGripDepth" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_Grip_Depth")%></span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtGripDepth_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <asp:Label ID="Label23" runat="server" Text="Side Gutter Depth" CssClass="normaltext"></asp:Label>
                                                    <span style="color: red">*</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtSideGutterDepth" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtSideGutterDepth');"
                                                        TabIndex="8" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right">0</asp:TextBox>&nbsp;<asp:Label
                                                            ID="lblSideGutterDepth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtSideGutterDepth" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_Side_Gutter_Depth")%></span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_txtSideGutterDepth_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div align="left" style="display:none;">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label1" runat="server" Text="Paper Type" CssClass="normaltext"></asp:Label>
                                                        <span style="color: red">*</span></div>
                                                    <div class="ddlsetting">
                                                        <asp:DropDownList ID="ddlPaperType" runat="server" CssClass="normalText" Width="145px"
                                                            onchange="javascript:showSpoilageType(this.value);return false;" TabIndex="9">
                                                            <asp:ListItem Value="roll" Text="Roll"></asp:ListItem>
                                                            <asp:ListItem Value="sheet" Text="Sheet"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                            <div id="div_nonprintimage" align="left">
                                                <div class="bglabel" style="height: 33px;">
                                                    <span class="normalText"></span>
                                                    <%=objlang.GetLanguageConversion("Non_Print_Image_Side_Area")%>
                                                </div>
                                                <div class="box" nowrap="nowrap">
                                                    <div align="left">
                                                        <div style="float: left; padding-top: 1px; width: 40px;">
                                                            <span class="normalText">
                                                                <%=objlang.GetLanguageConversion("Height")%></span>&nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:TextBox ID="txtPrintImageHeight" runat="server" Width="100px" SkinID="textPad"
                                                                Style="padding-left: 0px; margin-left: 0px; text-align: right" onblur="todecimal_function(this,this.value);"
                                                                TabIndex="10" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label ID="lblPrintHeight" runat="server"
                                                                    CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div align="left" style="clear: left; padding-top: 1px;">
                                                        <div style="float: left; width: 40px;">
                                                            <span class="normalText">
                                                                <%=objlang.GetLanguageConversion("Width")%></span>&nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:TextBox ID="txtPrintImageWidth" runat="server" Width="100px" SkinID="textPad"
                                                                Style="padding-left: 0px; margin-left: 0px; text-align: right" onblur="todecimal_function(this,this.value);"
                                                                TabIndex="11" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label ID="lblPrintWidth" runat="server"
                                                                    CssClass="normalText"><%=PaperMeasure %></asp:Label>&nbsp;
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_GutterDepth" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Image_Side_Area")%></span>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_GutterDepth_number" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="height: 33px;">
                                                    <span class="normalText"></span>
                                                    <%=objlang.GetLanguageConversion("Default_Gutters")%>
                                                    <span style="color: Red">*</span>
                                                </div>
                                                <div class="box" nowrap="nowrap">
                                                    <div align="left">
                                                        <div style="float: left; padding-top: 1px; width: 42px;">
                                                            <span class="normalText">
                                                                <%=objlang.GetLanguageConversion("Horizo")%></span>&nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:TextBox ID="txtGutterHorizontal" runat="server" Width="100px" SkinID="textPad"
                                                                Style="padding-left: 0px; margin-left: 0px; text-align: right" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_DefaultGutters');"
                                                                TabIndex="12" MaxLength="20"></asp:TextBox>&nbsp;<asp:Label ID="lblGutterHor" runat="server"
                                                                    CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div align="left" style="clear: left; padding-top: 1px;">
                                                        <div style="float: left; width: 42px;">
                                                            <span class="normalText">
                                                                <%=objlang.GetLanguageConversion("Vertic")%></span>&nbsp;
                                                        </div>
                                                        <div style="float: left;">
                                                            <asp:TextBox ID="txtGutterVertical" runat="server" Width="100px" SkinID="textPad"
                                                                Style="padding-left: 0px; margin-left: 0px; text-align: right" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_DefaultGutters');"
                                                                TabIndex="13" MaxLength="20"></asp:TextBox>&nbsp;<asp:Label ID="lblGutterVer" runat="server"
                                                                    CssClass="normalText"><%=PaperMeasure %></asp:Label>&nbsp;
                                                        </div>
                                                    </div>
                                                    <div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_DefaultGutters" style="display: none; width: auto; float: left">
                                                            <%--<div class="RFV_Message">--%>
                                                            <div>
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;" class="spanerrorMsg">
                                                                    <%=objlang.GetLanguageConversion("Please_Enter_Default_Gutters")%></span>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_DefaultGuttersNumber" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_cylindersize" class="topbar" style="width: 400px;">
                                            <div align="center" class="bgcustomize" style="width: 100%; padding: 3px">
                                                <div style="float: left; width: 95%; border: 0px solid">
                                                    <span class="navigatorpanel" style="vertical-align: middle">
                                                        <%=objlang.GetValueOnLang("Roll Sizes")%></span>
                                                </div>
                                                <div style="float: right; border: 0px solid">
                                                    <a href="" onclick="javascript:closebar('div_cylindersize');showhideDDL('show');return false;">
                                                        <img src="<%=strImagepath%>close1.jpg" border="0" /></a>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div align="left" class="border1px" style="width: 100%; padding: 2px">
                                                <div class="bglabel">
                                                    <asp:Label ID="lblRollName" runat="server" CssClass="HeaderText"><%=objlang.GetLanguageConversion("Roll_Name")%></asp:Label>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtRollName" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
                                                </div>
                                                <div class="bglabel">
                                                    <asp:Label ID="lblRollWidth" runat="server" CssClass="HeaderText"><%=objlang.GetLanguageConversion("Width")%> </asp:Label>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtRollWidth" runat="server" Width="60px" CssClass="textboxnew"></asp:TextBox>&nbsp;mm
                                                </div>
                                                <div align="left" class="header" style="width: 90%">
                                                    <div style="float: left; width: 47%">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:Button ID="btnMarkupRatesCancel" runat="server" Text="Cancel" CssClass="button"
                                                            OnClientClick="javascript:closebar('div_cylindersize');showhideDDL('show');return false;" />
                                                    </div>
                                                    <div style="float: left; width: 10px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:Button ID="btnMarkupRatesSave" runat="server" Text="Save" CssClass="button"
                                                            OnClientClick="javascript:return false;" CausesValidation="false" />
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <%--RIGHT--%>
                                    <div style="float: left; width: 49%;">
                                        <div style="float: left; width: 100%;">
                                            <div align="left">
                                                <div class="bglabel" style="border: solid 0px red">
                                                    <asp:Label ID="Label13" runat="server" Text="Set up Spoilage" CssClass="normaltext"></asp:Label>
                                                    (<span id="spnSpoilageType" runat="server"></span>) <span style="color: red; padding-left: 2px">*</span>
                                                </div>
                                                <div class="box">
                                                    <div style="float: left">
                                                        <asp:TextBox ID="txtSpoilage" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtSpoilage');IsDecimalValue(this.value,'spn_txtSpoilage_number');"
                                                            TabIndex="14" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right">0</asp:TextBox>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_txtSpoilage" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Setup_Spoilage")%>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_txtSpoilage_number" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </div>
                                                        <div id="spn_txtSpoilage_decimal" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_only_10_Decimal_points")%>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="bglabel" style="border: solid 0px red">
                                                    <asp:Label ID="Label1" runat="server" Text="Set Up Spoilage" CssClass="normaltext"></asp:Label>
                                                    (<span id="spnSpoilageType1" runat="server"></span>) <span style="color: red; padding-left: 2px">*</span>
                                                </div>
                                                <div class="box">
                                                    <div style="float: left">
                                                        <asp:TextBox ID="txtSpoilage1" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtSpoilage1');IsDecimalValue(this.value,'spn_txtSpoilage_number1');"
                                                            TabIndex="14" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right">0</asp:TextBox>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_txtSpoilage1" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Setup_Spoilage")%>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_txtSpoilage_number1" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </div>
                                                        <div id="spn_txtSpoilage_decimal1" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_only_10_Decimal_points")%>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div align="left">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label16" runat="server" Text="Running Spoilage (%)" CssClass="normaltext"></asp:Label>
                                                        <span style="color: red">*</span>
                                                    </div>
                                                    <div class="box">
                                                        <asp:TextBox ID="txtRunningSpoilage" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_RunningSpoilage');"
                                                            TabIndex="15" MaxLength="20" CssClass="textboxnew1" Width="140px" Style="text-align: right">0</asp:TextBox>&nbsp;<span></span>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_RunningSpoilage" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Running_Spoilage")%></span>
                                                            </div>
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_RunningSpoilage_number" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="Label25" runat="server" Text="Default Paper" CssClass="normalText"></asp:Label>
                                                            <%-- <span style="color: red">*</span>--%>
                                                        </div>
                                                        <div style="float: right">
                                                            <asp:ImageButton ID="ImgbtnMorePaper" runat="server" ImageUrl="~/images/plus.gif"
                                                                TabIndex="16" OnClientClick="javascript:return OpenPaperRollsPopUp('paper','1')" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="padding-top: 4px;">
                                                        <span id="spnpaper1" class="graytext" runat="server" style="cursor: pointer"></span>
                                                        <asp:HiddenField runat="server" ID="hdnpaper1" Value="0" />
                                                        <br />
                                                        <span id="spn_defaultpaper1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_select_Default_Paper")%></span>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="Label4" runat="server" Text="Default Paper" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/plus.gif" TabIndex="16"
                                                                OnClientClick="javascript:return OpenPaperRollsPopUp('paper','2')" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="padding-top: 4px;">
                                                        <span id="spnpaper2" class="graytext" style="cursor: pointer" runat="server"></span>
                                                        <asp:HiddenField runat="server" ID="hdnpaper2" Value="0" />
                                                        <br />
                                                        <span id="spn_defaultpaper2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_select_Default_Paper")%></span>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="Label8" runat="server" Text="Default Paper" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/plus.gif" TabIndex="16"
                                                                OnClientClick="javascript:return OpenPaperRollsPopUp('paper','3')" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="padding-top: 4px;">
                                                        <span id="spnpaper3" class="graytext" runat="server" style="cursor: pointer"></span>
                                                        <asp:HiddenField runat="server" ID="hdnpaper3" Value="0" />
                                                        <br />
                                                        <span id="spn_defaultpaper3" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_select_Default_Paper")%></span>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="Label11" runat="server" Text="Default Paper" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/plus.gif" TabIndex="16"
                                                                OnClientClick="javascript:return OpenPaperRollsPopUp('paper','4')" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="padding-top: 4px;">
                                                        <span id="spnpaper4" class="graytext" runat="server" style="cursor: pointer"></span>
                                                        <asp:HiddenField runat="server" ID="hdnpaper4" Value="0" />
                                                        <br />
                                                        <span id="spn_defaultpaper4" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_select_Default_Paper")%></span>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="Label14" runat="server" Text="Default Paper" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/plus.gif" TabIndex="16"
                                                                OnClientClick="javascript:return OpenPaperRollsPopUp('paper','5')" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="padding-top: 4px;">
                                                        <span id="spnpaper5" class="graytext" runat="server" style="cursor: pointer"></span>
                                                        <asp:HiddenField runat="server" ID="hdnpaper5" Value="0" />
                                                        <br />
                                                        <span id="spn_defaultpaper5" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_select_Default_Paper")%></span>
                                                    </div>
                                                </div>
                                                <div align="left" id="div_DefaultPrintSheet">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label46" runat="server" Text="Default Print Sheet Size" CssClass="normaltext"></asp:Label>
                                                    </div>
                                                    <div class="ddlsetting">
                                                        <asp:DropDownList ID="ddlPrintSheetSize" runat="server" CssClass="normalText" Width="183px"
                                                            onchange="javascript:CallonChange(this.value,'spn_PrintSheetSize');return false;"
                                                            TabIndex="17">
                                                        </asp:DropDownList>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_PrintSheetSize" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_select_Print_Sheet_Size")%></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label9" runat="server" Text="Default Job Size" CssClass="normaltext"></asp:Label>
                                                        <%--<span style="color: red">*</span>--%>
                                                    </div>
                                                    <div class="ddlsetting">
                                                        <asp:DropDownList ID="ddlJobSize" runat="server" CssClass="normalText" Width="183px"
                                                            TabIndex="18">
                                                        </asp:DropDownList>
                                                        <div style="clear: both">
                                                        </div>
                                                        <%--<div id="spn_JobSize" style="display: none; width: 180px; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; padding-left: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_select_Job_Size")%></span>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label2" runat="server" Text="Default Cutting Table" CssClass="normaltext"></asp:Label>
                                                    </div>
                                                    <div class="ddlsetting" style="padding-left: 5px">
                                                        <asp:DropDownList ID="ddlGuillotine" runat="server" CssClass="normalText" Width="183px"
                                                            TabIndex="19">
                                                            <%--onchange="javascript:CallonChange(this.value,'spn_Guillotine');return false;"--%>
                                                        </asp:DropDownList>
                                                        <div style="clear: both">
                                                        </div>
                                                        <div id="spn_Guillotine" style="display: none; width: auto; float: left">
                                                            <div class="RFV_Message">
                                                                <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_select_Guillotine")%></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                                <div align="left" style="display: none">
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label12" runat="server" Text="Can press do Perfecting?" CssClass="normaltext"></asp:Label>
                                                    </div>
                                                    <div class="box">
                                                        <asp:CheckBox ID="chkIsPerfecting" runat="server" TabIndex="20" />
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Set_Default_Press")%></span>
                                                    </div>
                                                    <div class="box">
                                                        <asp:CheckBox ID="chkDefaultPress" runat="server" TabIndex="20" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="div_UnitOfMeasure" runat="server" class="onlyEmpty" style="display: none">
                                                <div class="bglabel">
                                                    <%=objLanguage.GetLanguageConversion("Unit_Of_Measure")%>
                                                </div>
                                                <div class="box" style="width: 55%;">
                                                    <asp:TextBox ID="txtUnitOfMeasure" runat="server" SkinID="textPad" TabIndex="21"
                                                        Width="80px" MaxLength="8" onblur="SetNumber_OfUnit(this,this.value);" onkeyup="ToInteger(this,this.value);"
                                                        Style="text-align: right" Text="1000"></asp:TextBox>
                                                    <span id="spn_UnitOfMeasure" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                        <%=objlang.GetLanguageConversion("Please_Enter_Interger_Value") %></span>
                                                </div>
                                            </div>

                                            <div align="left" >
                                                    <div class="bglabel" >
                                                        <span class="normalText">
                                                            Calculate the total area of material including wastage</span></div>
                                                    <div class="box">
                                                        <asp:CheckBox ID="chkTotalSheets" runat="server" TabIndex="20" /></div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <div class="only5px">
                                        </div>
                                        <div align="left" style="width: 100%;">
                                            <div style="float: left; width: 29%; border: 0px solid">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 48%">
                                                <div class="box" style="float: left">
                                                    <div style="float: left">
                                                        <div id="div_Button4" style="display: block">
                                                            <asp:Button ID="Button4" CssClass="button" runat="server" Text="Cancel" TabIndex="22"
                                                                OnClick="Button4_OnClick" /><%--PostBackUrl="~/Settings/large_format_view.aspx"--%>
                                                        </div>
                                                        <div id="div_Button4process" style="display: none">
                                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                        </div>
                                                    </div>
                                                    <div style="float: left; width: 10px;">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:Button ID="Button5" CssClass="button" runat="server" Text="Next" OnClientClick="javascript:CheckNext();return false;"
                                                            TabIndex="23" />
                                                    </div>
                                                    <div style="clear: both">
                                                        &nbsp;
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Paper_Settings" align="left" style="display: none; padding: 15px 5px 5px 5px">
                                    <div style="float: left; width: 700px; border: 0px solid red">
                                        <div style="float: left; width: 350px;">
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div align="left">
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div align="left">
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Plant_Properties" style="display: none;">
                                    <div style="float: left; width: 100%;">
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div id="div_Plant_Calculation" style="display: none;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 49%">
                                            <div align="left">
                                                <div class="header" style="padding-top: 0px">
                                                    <span class="HeaderText">
                                                        <%=objlang.GetLanguageConversion("Press_Calculation")%></span>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <span class="normaltext">
                                                            <%=objlang.GetLanguageConversion("Setup_Charge")%>
                                                            (<%=comm.GetCurrencyinRequiredFormate("", true)%>)</span> <span style="color: red">*</span>
                                                    </div>
                                                    <div class="box">
                                                        <asp:TextBox ID="txtSetupCharge" runat="server" Width="100px" SkinID="textPad" onblur="todecimal_function(this,this.value);CheckDecimalPlus(this.value,'spn_SetupCharge','spn_SetupCharge_number','yes');"
                                                            MaxLength="20" TabIndex="24" Style="text-align: right">0</asp:TextBox>
                                                        <span id="spn_SetupCharge" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_enter_Setup_Charge")%>
                                                        </span><span id="spn_SetupCharge_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <span style="word-wrap: normal; white-space: nowrap">
                                                            <%=objlang.GetLanguageConversion("Min_Running_Charge")%>(<%=comm.GetCurrencyinRequiredFormate("", true)%>)
                                                            <span style="color: red;">*</span></span>
                                                    </div>
                                                    <div class="box" nowrap="nowrap">
                                                        <asp:TextBox ID="txtMinimumRunningCharge" runat="server" Width="100px" SkinID="textPad"
                                                            onblur="todecimal_function(this,this.value);CheckDecimalPlus(this.value,'spn_MinRunningCharge','spn_MinRunningCharge_number','yes');"
                                                            MaxLength="20" TabIndex="24" Style="text-align: right">0</asp:TextBox>
                                                        <span id="spn_MinRunningCharge" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_enter_Min_Running_Charge")%></span><span
                                                                id="spn_MinRunningCharge_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"><%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                    </div>
                                                </div>


                                                <%-- start --%>

                                                <div style="float: left; width: 100%;">
                                                    <div class="bglabel" style="width: 28%">
                                                        <span class="headertext">
                                                            <%=objLanguage.GetLanguageConversion("Calculation_Method")%>
                                                        </span>
                                                    </div>
                                                    <div class="box" style="float: left; width: 30%;">
                                                        <asp:DropDownList ID="ddlMethod" runat="server" CssClass="normalText" onchange="javascript:ShowOnCalculation(this);">
                                                            <%--<asp:ListItem>--- Select ---</asp:ListItem>--%>
                                                            <asp:ListItem Value="simplecosting">Simple Time Costing</asp:ListItem>
                                                            <asp:ListItem Value="timecosting">Time Based Matrix Costing</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hid_ddlMethodSelected" Value="" runat="server" />
                                                        <span id="spn_ddlMethod" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please select Calculation Method")%>
                                                        </span>
                                                    </div>
                                                </div>


                                                <%-- end --%>

                                                <div align="left" id="div_Markup" runat="server">
                                                    <div class="bglabel">
                                                        <span class="normaltext">
                                                            <%=objlang.GetLanguageConversion("Mark_Up")%>(%)</span> <span style="color: red">*</span>
                                                    </div>
                                                    <div class="box">
                                                        <asp:TextBox ID="txtMarkup" runat="server" Width="100px" SkinID="textPad" onblur="todecimal_function(this,this.value);CheckDecimalPlus(this.value,'spn_Markup','spn_Markup_number','yes')"
                                                            MaxLength="20" TabIndex="24" Style="text-align: right">0</asp:TextBox>
                                                        <span id="spn_Markup" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetLanguageConversion("Please_enter_Markup")%>
                                                        </span><span id="spn_Markup_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                    </div>
                                                </div>
                                                <div class="only5px">
                                                </div>
                                                <div class="bglabel">
                                                    <asp:Label ID="Label3" runat="server" Text="Print Quality" CssClass="normaltext"></asp:Label>
                                                </div>
                                                <div class="box">
                                                    <div style="float: left">
                                                        <%=objlang.GetLanguageConversion("Low")%>
                                                    </div>
                                                    <div style="float: left; width: 50px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <%=objlang.GetLanguageConversion("Medium")%>
                                                    </div>
                                                    <div style="float: left; width: 30px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <%=objlang.GetLanguageConversion("High")%>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <span style="word-wrap: normal" id="spnPrinting" runat="server"></span><span style="color: red">*</span>
                                                </div>
                                                <div class="box" style="width: 220px;">
                                                    <div style="float: left">
                                                        <asp:TextBox ID="txtPrintPerHourLow" runat="server" Width="55px" SkinID="textPad"
                                                            onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_PrintPerHour');"
                                                            MaxLength="8" TabIndex="24" Style="text-align: right">100</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 10px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:TextBox ID="txtPrintPerHourMedium" runat="server" Width="55px" SkinID="textPad"
                                                            onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_PrintPerHour');"
                                                            MaxLength="8" TabIndex="24" Style="text-align: right">60</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 10px">
                                                        &nbsp;
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:TextBox ID="txtPrintPerHourHigh" runat="server" Width="55px" SkinID="textPad"
                                                            onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_PrintPerHour');"
                                                            MaxLength="8" TabIndex="24" Style="text-align: right">30</asp:TextBox>
                                                    </div>
                                                    <span id="spn_PrintPerHour" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                        <%=objlang.GetLanguageConversion("Please_enter_Print_per_Hour")%></span><span id="spn_PrintPerHour_number"
                                                            class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"><%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div align="left" id="divHourlyChargeRate" runat="server">
                                                <div class="bglabel" nowrap="nowrap">
                                                    <span style="word-wrap: normal">
                                                        <%=objlang.GetLanguageConversion("Press_Hourly_Charge_Rate")%>(<%=comm.GetCurrencyinRequiredFormate("", true)%>)<span
                                                            style="color: red; padding-left: 4px">*</span></span>
                                                </div>
                                                <div class="box" nowrap="nowrap">
                                                    <asp:TextBox ID="txtPressHourlyCharge" runat="server" Width="60px" SkinID="textPad"
                                                        onblur="todecimal_function(this,this.value);CheckDecimalPlus(this.value,'spn_txtPressHourlyCharge','spn_txtPressHourlyCharge_number','yes');"
                                                        MaxLength="20" TabIndex="24" Style="text-align: right">0</asp:TextBox>
                                                    <span id="spn_txtPressHourlyCharge" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                        <%=objlang.GetLanguageConversion("Please_enter_Press_Hourly_Charge")%></span>
                                                    <span id="spn_txtPressHourlyCharge_number" class="spanerrorMsg" style="display: none; wiwidth: auto; padding-left: 4px; padding-right: 4px;">
                                                        <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="header">
                                                    <span class="HeaderText">
                                                        <%=objlang.GetLanguageConversion("Ink_Coverage")%></span>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div align="left">
                                                <table>
                                                    <tr>
                                                        <td width="120px">
                                                            <div class="bglabel" nowrap="nowrap" style="width: 200px">
                                                                <span style="word-wrap: normal">
                                                                    <%=objlang.GetLanguageConversion("Default_Ink") %>
                                                                    <br />
                                                                    <%=objlang.GetLanguageConversion("Coverage_Side")%>
                                                                    1(%) <span style="color: red;">*</span></span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtInkCoverageSide1" runat="server" Width="100px" SkinID="textPad"
                                                                    onblur="todecimal_function(this,this.value);" MaxLength="8" TabIndex="24" Style="text-align: right"></asp:TextBox>
                                                                <span id="spn_InkCoverageSide1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Ink_Coverage_Side_1")%></span>
                                                                <span id="spn_InkCoverageSide1_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" nowrap="nowrap" style="width: 200px">
                                                                <span style="word-wrap: normal">
                                                                    <%=objlang.GetLanguageConversion("Default_Ink")%>
                                                                    <br />
                                                                    <%=objlang.GetLanguageConversion("Coverage_Side")%>
                                                                    2(%) <span style="color: red;">*</span></span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtInkCoverageSide2" runat="server" Width="100px" CssClass="textboxnew"
                                                                    onblur="todecimal_function(this,this.value);" MaxLength="8" TabIndex="24" Style="text-align: right"></asp:TextBox>
                                                                <span id="spn_InkCoverageSide2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_Ink_Coverage_Side_2")%>
                                                                </span><span id="spn_InkCoverageSide2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" nowrap="nowrap" style="width: 200px">
                                                                <span style="word-wrap: normal">Special Ink
                                                                    <br />
                                                                    Coverage Side1(%) <span style="color: red;">*</span> </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtWhiteInkCoverageSide1" runat="server" Width="100px" CssClass="textboxnew"
                                                                    onblur="todecimal_function(this,this.value);" MaxLength="8" TabIndex="24" Style="text-align: right"></asp:TextBox>
                                                                <span id="span_whiteinkcoverageside1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_whiteink_coverageside1")%></span><span
                                                                        id="span_WhiteInkcoverageside1number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                        <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" nowrap="nowrap" style="width: 200px">
                                                                <span style="word-wrap: normal">Special Ink
                                                                    <br />
                                                                    Coverage Side2(%) <span style="color: red;">*</span> </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtWhiteInkCoverageSide2" runat="server" Width="100px" CssClass="textboxnew"
                                                                    onblur="todecimal_function(this,this.value);" MaxLength="8" TabIndex="24" Style="text-align: right"></asp:TextBox>
                                                                <span id="spn_whiteinkcoverageside2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; white-space: nowrap">
                                                                    <%=objlang.GetLanguageConversion("Please_enter_whiteink_coverageside2")%></span><span
                                                                        id="spn_whiteinkcoverageside2number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                        <%=objlang.GetLanguageConversion("Please_enter_numeric_value")%></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div style="clear: both;">
                                            </div>
                                        </div>
                                        <div style="float: left; width: 49%">
                                            <asp:HiddenField ID="YieldMatrix_Value" runat="server" Value="Y" />
                                        </div>
                                        <div id="div_Scroll2" style="float: left; width: 49%; height: 200px; overflow-y: scroll; overflow-x: hidden">
                                            <div align="left">
                                                <div class="header" style="width: 100%">
                                                    <span class="HeaderText">
                                                        <%=objlang.GetLanguageConversion("Select_the_Inks_to_be_assigned_to_this_press")%></span>
                                                </div>
                                            </div>
                                            <div id="divOnlyContent" style="float: left; width: 100%; display: none;">
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="lblInk" runat="server" Text="Ink 1" CssClass="normaltext"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <img id="imgInk" src="~/images/plus.gif" onclick="javascript:return false;" alt="More Ink" />
                                                        </div>
                                                        <%--<%=strImagepath%>lookup.gif--%>
                                                    </div>
                                                    <div class="box" style="border: 1px solid">
                                                        <asp:TextBox ID="txtInk" runat="server" Width="100px" CssClass="textboxnew"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                            </div>
                                            <div id="divContent" style="float: left; width: 100%;">
                                            </div>
                                            <div class="onlyEmpty">
                                            </div>
                                            <script>
                                                var strImagepathjs = "<%=strImagepath%>";
                                            </script>
                                            <div align="left" style="width: 99%;">
                                                <div class="bglabelEmpty">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <div style="float: left;">
                                                        <a href="#addINK" onclick="javascript:AddMoreInk('new');">
                                                            <%=objlang.GetLanguageConversion("Add_More")%></a>
                                                    </div>
                                                    <div style="float: left;">
                                                        &nbsp;|&nbsp;<a href="#addINK" onclick="javascript:DeleteMoreInk();"><%=objlang.GetLanguageConversion("Remove")%></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <a id="addINK" name="addINK"></a>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                        <div id="div_scrollforwhiteink" style="float: left; width: 49%; height: 70px; overflow-y: hidden; overflow-x: hidden">
                                            <div align="left">
                                                <div class="header" style="width: 100%">
                                                    <span class="HeaderText">
                                                        <%=objlang.GetLanguageConversion("Select_The_WhiteInks_To_Be_Assigned_To_This_Press")%></span>
                                                </div>
                                            </div>
                                            <div id="div2" style="float: left; width: 100%; display: none;">
                                                <div align="left">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="lblwhiteInk" runat="server" Text="Ink 1" CssClass="normaltext"></asp:Label>
                                                        </div>
                                                        <div style="float: right">
                                                            <img id="img1" src="~/images/plus.gif" onclick="javascript:return false;" alt="More Ink" />
                                                        </div>
                                                    </div>
                                                    <div class="box" style="border: 1px solid">
                                                        <asp:TextBox ID="txtwhiteInk" runat="server" Width="100px" CssClass="textboxnew"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                            </div>
                                            <div id="divContentforwhiteink" style="float: left; width: 100%;">
                                            </div>
                                            <div class="onlyEmpty">
                                            </div>
                                            <%-- <script>
                                                var strImagepathjs = "<%=strImagepath%>";
                                            </script>--%>
                                            <div align="left" style="width: 99%;">
                                                <div class="bglabelEmpty">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left; display: none;">
                                                    <div style="float: left;">
                                                        <a href="#addWhiteInk" onclick="javascript:AddMoreWhiteInk('new');">
                                                            <%=objlang.GetLanguageConversion("Add_More")%></a>
                                                    </div>
                                                    <div style="float: left;">
                                                        &nbsp;|&nbsp;<a href="#addWhiteInk" onclick="javascript:DeleteMoreWhiteInk();"><%=objlang.GetLanguageConversion("Remove")%></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <a id="addWhiteInk" name="addWhiteInk"></a>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="only5px">
                                    </div>

                                    <%-- start --%>

                                    <div runat="server" id="divNewMatrixCalculation" style="display:none">
                                        <div align="center" style="width: 100%; vertical-align: top">
                                            <div style="float: left; width: 12%">
                                                <span>&nbsp;</span>
                                            </div>

                                             <div align="center" style="float: left; width: 13%; border: 0px solid red">
                                        <span>Minutes
                                        </span>
                                    </div>
                                            <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                                <span>Hourly Cost
                                                </span>
                                            </div>
                                            <div align="center" style="float: left; width: 6%; border: 0px solid red">
                                                <span>Markup
                                                </span>
                                            </div>
                                            <div align="center" style="width: 17%; float: left; border: 0px solid red">
                                                <span>Hourly Chargable Rate
                                                </span>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </div>

                                        <div id="div_left" align="left" style="float: left; width: 100%; vertical-align: top; padding-top: 4px; border: 0px solid red;">
                                            <asp:PlaceHolder ID="plhBlackZone" runat="server"></asp:PlaceHolder>
                                            <span id="spnGetID" runat="server"></span>
                                            <div style="clear: both">
                                            </div>
                                        </div>



                                        <div>
                                            <a id="href_add_more" name="addmore" style="display: block; float: left" href='#addmore' onclick="Click_Add_More()">Add More Rows</a>
                                        </div>

                                    </div>

                                    <%-- end --%>

                                    <div align="left" style="width: 100%;">
                                        <div style="float: left; width: 40%; border: 0px solid">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 53%">
                                            <div class="bglabelEmpty" style="width: 282px;">
                                                &nbsp;
                                            </div>
                                            <div class="box">
                                                <div style="float: left">
                                                    <asp:Button ID="Button1" CssClass="button" runat="server" Text="Previous" OnClientClick="javascript:changeCss('spn_1');return false;"
                                                        TabIndex="24" />
                                                </div>

                                                <div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left">
                                                    <div id="div_btndelete" style="display: block">
                                                        <asp:Button ID="btndelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                            OnClick="btndelete_OnClick" TabIndex="24" />
                                                    </div>
                                                    <div id="div_btndelprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left">
                                                    <div id="div_btnsave" style="display: block">
                                                        <asp:Button ID="btn_save" CssClass="button" runat="server" Text="Save" OnClick="btnSave_OnClick"
                                                            TabIndex="22" />
                                                        <asp:HiddenField runat="server" ID="hdnlength" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdnvalue" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdnid" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdneditvalue" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdneditid" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdneditidforwhiteink" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdneditvalueforwhiteink" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdnidforwhiteink" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdnwhiteinkvalue" Value="0" />
                                                        <asp:HiddenField runat="server" ID="hdnlengthforwhiteink" Value="0" />
                                                    </div>
                                                    <div id="div_btnsaveprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <%--<div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>--%>
                                                <%--<div style="float: left">
                                                    <div id="div_btndelete" style="display: block">
                                                        <asp:Button ID="btndelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                            OnClick="btndelete_OnClick" TabIndex="24" />
                                                    </div>
                                                    <div id="div_btndelprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>--%>
                                                <div style="clear: both">
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>



                                </div>
                                <div id="div_Plant_Charges" style="display: none;">
                                    <div style="float: left; width: 900px; padding: 5px">
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objlang.GetLanguageConversion("Setup_Charge")%>(<%=comm.GetCurrencyinRequiredFormate("", true)%>)
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="TextBox45" runat="server" CssClass="textboxnew" Width="70px" Style="text-align: right"></asp:TextBox>
                                            </div>
                                            <div class="bglabel">
                                                <%=objlang.GetLanguageConversion("Minimum_Running_Charge")%>
                                                (<%=comm.GetCurrencyinRequiredFormate("", true)%>)
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="TextBox48" runat="server" CssClass="txtbox" Width="70px" Style="text-align: right"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Ink_Order" style="display: none;">
                                    <div id="Div4">
                                        <div style="float: left; width: 100%;">
                                            <div style="float: left; width: 60%; border: 0px solid;">
                                                <div style="float: left; width: 100%; border: 0px solid red">
                                                    <div class="bglabel" nowrap="nowrap">
                                                        <asp:Label ID="Label27" runat="server" Text="Default Ink Coverage Side 1" CssClass="normaltext"></asp:Label>
                                                    </div>
                                                    <div class="box">
                                                        <asp:TextBox ID="TextBox43" runat="server" Width="100px" CssClass="textboxnew" onblur="todecimal_function(this,this.value);"
                                                            TabIndex="24"></asp:TextBox>&nbsp;<span>%</span>
                                                    </div>
                                                    <div class="bglabel">
                                                        <asp:Label ID="Label7" runat="server" Text="Default Ink Coverage Side 2" CssClass="normaltext"></asp:Label>
                                                    </div>
                                                    <div class="box">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="100px" CssClass="textboxnew" onblur="todecimal_function(this,this.value);"
                                                            TabIndex="24"></asp:TextBox>&nbsp;<span>%</span>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 800px; padding-top: 10px">
                                                    <div class="box" style="width: 250px; border: 0px solid blue">
                                                        <asp:ListBox ID="lstInk" runat="server" CssClass="normaltext" Width="250px" Height="200px">
                                                            <asp:ListItem>307 C - Blue</asp:ListItem>
                                                            <asp:ListItem>308 C - Blue</asp:ListItem>
                                                            <asp:ListItem>309 C - Blue</asp:ListItem>
                                                            <asp:ListItem>310 C - Blue</asp:ListItem>
                                                            <asp:ListItem>BLACK 2 C</asp:ListItem>
                                                            <asp:ListItem>BLACK 3 C</asp:ListItem>
                                                            <asp:ListItem>BLACK 4 C</asp:ListItem>
                                                            <asp:ListItem>BLACK C</asp:ListItem>
                                                            <asp:ListItem>BLACK C Hexachrome</asp:ListItem>
                                                        </asp:ListBox>
                                                    </div>
                                                    <div style="float: left; width: 40px; border: 0px solid blue">
                                                        <div style="float: left;">
                                                            <img src="<%=strImagepath %>select_right.jpg" />
                                                        </div>
                                                        <div style="float: left;">
                                                            <img src="<%=strImagepath %>select_left.jpg" />
                                                        </div>
                                                        <div style="clear: both">
                                                        </div>
                                                    </div>
                                                    <div style="float: left; width: 250px; border: 0px solid blue">
                                                        <div style="float: left; width: 250px">
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                1st
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox125" runat="server" Width="200px" CssClass="textboxnew">Black Toner 1 KG</asp:TextBox>
                                                            </div>
                                                            <div style="clear: left">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                2nd
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox33" runat="server" Width="200px" CssClass="textboxnew">Cyan Toner 1 KG</asp:TextBox>
                                                            </div>
                                                            <div style="clear: left">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                3rd
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox135" runat="server" Width="200px" CssClass="textboxnew">Magenta Toner 1 KG</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                4th
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox126" runat="server" Width="200px" CssClass="textboxnew">Yellow Toner 1 KG</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                5th
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox127" runat="server" Width="200px" CssClass="textboxnew">YELLOW C Hexachrome</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                6th
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox128" runat="server" Width="200px" CssClass="textboxnew">ORANGE C Hexachrome</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                7th
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox129" runat="server" Width="200px" CssClass="textboxnew">MAGENTA C Hexachrome</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div style="float: left; padding: 5px; width: 20px;">
                                                                8th
                                                            </div>
                                                            <div class="box" style="width: 200px">
                                                                <asp:TextBox ID="TextBox130" runat="server" Width="200px" CssClass="textboxnew">YGREEN C Hexachrome</asp:TextBox>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <div align="left" style="width: 100%;">
                                        <div style="float: left; width: 59%; border: 0px solid">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 40%">
                                            <div style="float: left">
                                                <asp:Button ID="Button10" CssClass="button" runat="server" Text="Previous" OnClientClick="javascript:changeCss('spn_4');return false;"
                                                    TabIndex="24" />
                                            </div>
                                            <div style="float: left; width: 10px;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnSave_OnClick"
                                                    TabIndex="24" />
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                        &nbsp;
                                    </div>
                                </div>



                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div id="divrad" style="display: none;">
                <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
                    Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
                    Behaviors="Close, Move,Reload,Resize">
                </telerik:RadWindowManager>
            </div>
            <div style="clear: both; width: 775px">
                &nbsp;
            </div>
            <asp:HiddenField ID="hdnBlack" runat="server" />
            <asp:HiddenField ID="hdnColor" runat="server" />
            <asp:HiddenField ID="hdn_ClickChargeZoneLookupBlack" runat="server" />
            <asp:HiddenField ID="hdn_ClickChargeZoneLookupColour" runat="server" />
            <asp:HiddenField ID="hdnTotalrowscount" Value="0" runat="server" />
            <asp:HiddenField ID="hdnItemscount" Value="0" runat="server" />
            <script language="javascript" type="text/javascript" src="../js/Item/float_popup.js?VN='<%=VersionNumber%>'"></script>
            <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
            <script type="text/javascript" src="<%=strSitepath %>js/item/Largeformat.js?VN='<%=VersionNumber%>'"></script>
            <script type="text/javascript">

                var ItemsCounter = '<%=ItemsCounter%>';
                var strImagepath = '<%=strImagepath%>';
                var hdnItemscount = document.getElementById("<%=hdnItemscount.ClientID%>");
                var hdnTotalrowscount = document.getElementById("<%=hdnTotalrowscount.ClientID%>");
                var BlackMatrixStartRange = '<%=BlackMatrixStartRange%>';
                var BlackMatrixEndRange = '<%=BlackMatrixEndRange%>';
                var BlackCostPrefill = '<%=BlackCostPrefill %>';
                var spnBlackFrom = "spnBlackFrom";
                var BlackFrom = "txtBlackFrom";
                var BlackTo = "txtBlackTo";
                var BlackChargableSheets = "txtBlackChargableSheets";
                var BlackCost = "txtBlackCost";
                var BlackMarkup = "txtBlackMarkup";
                var BlackChargableRate = "txtBlackChargableRate";
                var spn_Black_dash = "spn_Black_dash_";
                var hdnBlack = document.getElementById("<%=hdnBlack.ClientID%>");
                var hdnColor = document.getElementById("<%=hdnColor.ClientID%>");
                var hdn_ClickChargeZoneLookupBlack = document.getElementById("<%=hdn_ClickChargeZoneLookupBlack.ClientID%>");
                var Values = '';
                function RemoveTextBox(index) {
                    if (document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)) != null && document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)) != undefined && (parseInt(index) - 1) != 1) {

                        document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)).style.display = "block";

                        document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value))).style.display = "none";
                    } else {
                        document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value))).style.display = "none";
                    }
                    document.getElementById("div_Black_" + index + "").remove();
                    //document.getElementById("div_Color_" + index + "").remove();
                    ItemsCounter = parseInt(ItemsCounter) - 1;
                    hdnItemscount.value = parseInt(hdnItemscount.value) - 1;
                    hdnTotalrowscount.value = parseInt(hdnTotalrowscount.value) - 1;
                }


                function Click_Add_More() {
                    BlackCostPrefill = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(document.getElementById(BlackCost + parseInt(hdnTotalrowscount.value)).value)), 4, '', false, false, false);
                    //ColourCostPrefill = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(document.getElementById(ColorCost + parseInt(hdnTotalrowscount.value)).value) - parseFloat(0.01)), 4, '', false, false, false);
                    if (parseInt(hdnTotalrowscount.value) == 1) {
                        BlackMatrixStartRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                        BlackMatrixEndRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 50;
                        //ColourMatrixStartRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                        //ColourMatrixEndRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 50;
                    } else {
                        BlackMatrixStartRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                        BlackMatrixEndRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 100;
                        //ColourMatrixStartRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                        //ColourMatrixEndRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 100;
                    }
                    var Data = '';
                    var Data1 = '';
                    if (document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)) != null && document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)) != undefined) {
                        document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)).style.display = "none";
                    }
                    Data = Create_BlackRow(parseInt(hdnTotalrowscount.value) + 1, Data);
                    //Data1 = Create_ColorRow(parseInt(hdnTotalrowscount.value) + 1, Data);
                    var div = document.createElement("div");
                    //var div1 = document.createElement("div");
                    div.innerHTML = Data;
                    //div1.innerHTML = Data1;
                    document.getElementById("div_left").appendChild(div);
                    //document.getElementById("div_right").appendChild(div1);
                    ItemsCounter = parseInt(ItemsCounter) + 1;
                    hdnItemscount.value = parseInt(hdnItemscount.value) + 1;
                    hdnTotalrowscount.value = parseInt(hdnTotalrowscount.value) + 1;
                }

                function Create_BlackRow(i, dataValue) {
                    dataValue = "<div id='div_Black_" + i + "' style='float: left; width: 80%;'>";
                    //dataValue += "<div style='float: left; width: 10%;'><span>&nbsp; From </span></div>";
                    // dataValue += "<div style='float: left; width: 10%;'><span>&nbsp;</span></div>";
                    dataValue += "<div style='float: left; width: 20%; text-align: right'>";
                    dataValue += "<span id='spnBlackFrom" + i + "'>" + BlackMatrixStartRange + "</span>";// + "+" 
                    dataValue += "<input type='text' ID='txtBlackFrom" + i + "' value=" + BlackMatrixStartRange + " Style='display: none'/>";
                    dataValue += "<input type='hidden' ID='hid_BlackClickChargeZoneLookupID_" + i + "' value='0' style='display:none'/>";
                    dataValue += "</div>";
                    dataValue += "<div style='float: left; width: 3%; text-align: center'>";
                    dataValue += "<span>&nbsp;</span>";
                    dataValue += "<span id='spn_Black_dash_" + i + "'>-</span>";
                    dataValue += "</div>";
                    dataValue += "<div style='float: left; width: 15%'>";//visibility: hidden;
                    dataValue += "<input type='text' ID='txtBlackTo" + i + "' value=" + BlackMatrixEndRange + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur= AllowNumber(this,this.value);checkNextCharge(this.value," + i + ",'black');CallonBlur(this.value,'spn_Black_" + i + "'); />"
                    dataValue += "</div>";
                    //dataValue += "<div style='float: left; width: 15%;'>";
                    //dataValue += "<input type='text' ID='txtBlackChargableSheets" + i + "' value=" + 1 + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "'); />"
                    //dataValue += "</div>";
                    dataValue += "<div style='float: left; width: 15%'>";
                    dataValue += "<input type='text' ID='txtBlackCost" + i + "' value=" + BlackCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "');Calculate_BlackChargeableRate(this.value," + i + ",'cost'); />"
                    dataValue += "</div>";
                    dataValue += "<div style='float: left; width: 15%'>";
                    dataValue += "<input type='text' ID='txtBlackMarkup" + i + "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_BlackChargeableRate(this.value," + i + ",'markup'); />"
                    dataValue += "</div>";
                    dataValue += "<div style='float: left; width: 12%;'>";
                    dataValue += "<input type='text' ID='txtBlackChargableRate" + i + "' value=" + BlackCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "');Calculate_BlackMarkup(this.value," + i + "); />"
                    dataValue += "</div>";
                    dataValue += "<div id='div_imgDeleterow_" + i + "' style='float: left;'>";
                    dataValue += "<img id='imgDeleterow_" + i + "' style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(" + i + ");'/>";
                    dataValue += "</div>";
                    dataValue += "<div class='onlyEmpty'>";
                    dataValue += "<div style='width: 10%; float: left;'>&nbsp;</div>";
                    dataValue += "<div style='width: 10%; float: left;'>&nbsp;</div>";
                    dataValue += "<div style='width: 3%; float: left;'>&nbsp;</div>";
                    dataValue += "<div>";
                    dataValue += "<span id='spn_Black_" + i + "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>Please enter numeric value</span>";
                    dataValue += "</div>";
                    dataValue += "</div>";
                    dataValue += "</div>";
                    Values += "StartRange±" + BlackMatrixStartRange + "~" + "EndRange±" + BlackMatrixEndRange + "~" + "CostPrefill±" + BlackCostPrefill + "&";
                    hdnBlack.value = Values;
                    return dataValue;
                }

                function Calculate_BlackChargeableRate(objval, index, type) {
                    if (type == 'cost') {
                        var txtBlckMarkup = document.getElementById(BlackMarkup + index);
                        var txtBlckCost = document.getElementById(BlackCost + index);
                        var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);
                        if (Number(objval) != 0) {
                            var MarkupValue = (objval * txtBlckMarkup.value) / 100;
                            var BlckChargableRate = Number(MarkupValue) + Number(objval);
                            txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, BlckChargableRate, 4, '', false, false, false);
                        }
                        else {
                            objval = "0.00";
                            txtBlckChargableRate.value = "0.00";
                        }
                        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
                        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckMarkup.value, 0, '', false, false, false);
                        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
                    }
                    else {
                        var txtBlckCost = document.getElementById(BlackCost + index);
                        var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);
                        var txtBlckMarkup = document.getElementById(BlackMarkup + index);

                        if (!isNaN(objval)) {
                            if (Number(objval) != 0) {
                                var MarkupValue = (objval * txtBlckCost.value) / 100;
                                var BlckChargableRate = Number(MarkupValue) + Number(txtBlckCost.value);
                                txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, BlckChargableRate, 4, '', false, false, false);
                                //txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
                            }
                        }
                        else {
                            txtBlckChargableRate.value = txtBlckCost.value;
                        }
                        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
                        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 0, '', false, false, false);
                        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckChargableRate.value, 4, '', false, false, false);
                    }
                }

                function Calculate_BlackMarkup(objval, index) {
                    var txtBlckMarkup = document.getElementById(BlackMarkup + index);
                    var txtBlckCost = document.getElementById(BlackCost + index);
                    var txtBlckChargableRate = document.getElementById(BlackChargableRate + index);

                    if (Number(objval) != 0 && Number(txtBlckCost.value) != 0) {
                        var MarkupValue = (Number(objval) - Number(txtBlckCost.value)) / Number(txtBlckCost.value);
                        MarkupValue = Number(MarkupValue) * 100;
                        txtBlckMarkup.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, MarkupValue, 0, '', false, false, false);
                        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtBlckCost.value, 4, '', false, false, false);
                        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
                    }
                    else if (Number(objval) != 0 || Number(txtBlckCost.value) != 0) {
                        txtBlckCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
                        txtBlckChargableRate.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, objval, 4, '', false, false, false);
                    }
                }

                function checkNextCharge(txtValue, ROW, type) {
                    var TextBoxTo;
                    var LabelFrom;
                    var txtFrom;
                    if (type == 'black') {
                        TextBoxTo = "txtBlackTo";
                        LabelFrom = "spnBlackFrom";
                        txtFrom = "txtBlackFrom";
                    }
                    else if (type == 'color') {
                        TextBoxTo = "txtColorTo";
                        LabelFrom = "spnColorFrom";
                        txtFrom = "txtColorFrom";
                    }
                    var ConcatID = TextBoxTo; //GetID + Ct00_ccc
                    LabelFrom = LabelFrom; //GetID + Ct00_ccc
                    txtFrom = txtFrom; //GetID + Ct00_ccc
                    var start = Number(ROW + 1);

                    if (!isNaN(txtValue)) {
                        var IsCorrect = true;
                        if (Number(ROW) > 1) {
                            var First = document.getElementById(ConcatID + Number(ROW - 1)).value;
                            var Second = document.getElementById(ConcatID + Number(ROW)).value;
                            IsCorrect = (Number(Second) > Number(First));
                        }
                        if (IsCorrect) {
                            if (document.getElementById(LabelFrom + "" + start) != null && document.getElementById(LabelFrom + "" + start) != undefined) {
                                document.getElementById(LabelFrom + "" + start).innerHTML = Number(txtValue) + Number(1);
                                document.getElementById(txtFrom + "" + start).value = Number(txtValue) + Number(1);

                            }
                        }
                    }
                }
                function CheckingZones() {
                    CheckZone = false;
                }




                function ShowOnCalculation(ddlID) {
                    //divClickChargeLookup.style.display = "none";
                    //divSpeedWeightLookup.style.display = "none";
                    //divClickZonesLookup.style.display = "none";
                    debugger;
                    var divNewMatrixCalculation_div = document.getElementById("ctl00_ContentPlaceHolder1_divNewMatrixCalculation");
                    var divHourlyChargeRate_div = document.getElementById("ctl00_ContentPlaceHolder1_divHourlyChargeRate");
                    var Markup_div = document.getElementById("ctl00_ContentPlaceHolder1_div_Markup");
                    var ddlText = ddlID.options[ddlID.selectedIndex].text.toLowerCase();
                    var ddlValue = ddlID.options[ddlID.selectedIndex].value.toLowerCase();

                    if (ddlValue != '') {
                        if (ddlValue == 'timecosting') {
                            divNewMatrixCalculation_div.style.display = "block";
                            divHourlyChargeRate_div.style.display = "none";
                            Markup_div.style.display = "none";
                        }
                        else if (ddlValue == 'simplecosting') {
                            divNewMatrixCalculation_div.style.display = "none";
                            divHourlyChargeRate_div.style.display = "block";
                            Markup_div.style.display = "block";
                        }
                        //else if (ddlValue == 'clickchargezonelookup') {
                        //    divClickZonesLookup.style.display = "block";
                        //}
                        //else {
                        //    divClickChargeLookup.style.display = "none";
                        //    divSpeedWeightLookup.style.display = "none";
                        //    divClickZonesLookup.style.display = "none";
                        //}
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                function SendPaperIDandName(Invid, val, papertype, MaterialNo) {
                    var val1 = trim12(val);
                    val1 = val1.length > 25 ? val1 = val1.substring(0, 25) + '...' : val1;

                    var spn = "spnpaper" + MaterialNo;
                    var hdn = "hdnpaper" + MaterialNo;
                    var spn_defaultpaper = "spn_defaultpaper" + MaterialNo
                    var spn1 = "<%=spnpaper1.ClientID %>";
                    if (MaterialNo == '1') {
                        document.getElementById("<%=spnpaper1.ClientID %>").title = val1;
                        document.getElementById("<%=hdnpaper1.ClientID %>").value = Invid;
                        document.getElementById("spn_defaultpaper1").style.cursor = "pointer"
                        document.getElementById("<%=spnpaper1.ClientID %>").innerHTML = SpecialDecode(val1);
                    }
                    else if (MaterialNo == '2') {
                        document.getElementById("<%=spnpaper2.ClientID %>").title = val1;
                        document.getElementById("<%=hdnpaper2.ClientID %>").value = Invid;
                        document.getElementById("spn_defaultpaper2").style.cursor = "pointer"
                        document.getElementById("<%=spnpaper2.ClientID %>").innerHTML = SpecialDecode(val1) + "&nbsp;<img  id='img" + MaterialNo + "' style='cursor:pointer' alt='Clear this paper' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_paper(this.id,'" + val1 + "','2');\" />";
                    }
                    else if (MaterialNo == '3') {
                        document.getElementById("<%=spnpaper3.ClientID %>").title = val1;
                        document.getElementById("<%=hdnpaper3.ClientID %>").value = Invid;
                        document.getElementById("spn_defaultpaper3").style.cursor = "pointer"
                        document.getElementById("<%=spnpaper3.ClientID %>").innerHTML = SpecialDecode(val1) + "&nbsp;<img  id='img" + MaterialNo + "' style='cursor:pointer' alt='Clear this paper' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_paper(this.id,'" + val1 + "','3');\" />";
                    }
                    else if (MaterialNo == '4') {
                        document.getElementById("<%=spnpaper4.ClientID %>").title = val1;
                        document.getElementById("<%=hdnpaper4.ClientID %>").value = Invid;
                        document.getElementById("spn_defaultpaper4").style.cursor = "pointer"
                        document.getElementById("<%=spnpaper4.ClientID %>").innerHTML = SpecialDecode(val1) + "&nbsp;<img  id='img" + MaterialNo + "' style='cursor:pointer' alt='Clear this paper' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_paper(this.id,'" + val1 + "','4');\" />";
                    }
                    else if (MaterialNo == '5') {
                        document.getElementById("<%=spnpaper5.ClientID %>").title = val1;
                        document.getElementById("<%=hdnpaper5.ClientID %>").value = Invid;
                        document.getElementById("spn_defaultpaper5").style.cursor = "pointer"
                        document.getElementById("<%=spnpaper5.ClientID %>").innerHTML = SpecialDecode(val1) + "&nbsp;<img  id='img" + MaterialNo + "' style='cursor:pointer' alt='Clear this paper' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_paper(this.id,'" + val1 + "','5');\" />";
                    }
                    //                document.getElementById(spn).title = val1;
                    //                document.getElementById(hdn).value = Invid;
                    //                document.getElementById(spn_defaultpaper).style.cursor = "pointer";
                }

                var hdnpaper2 = document.getElementById("<%=hdnpaper2.ClientID %>");
                var hdnpaper3 = document.getElementById("<%=hdnpaper3.ClientID %>");
                var hdnpaper4 = document.getElementById("<%=hdnpaper4.ClientID %>");
                var hdnpaper5 = document.getElementById("<%=hdnpaper5.ClientID %>");

                var spnpaper2 = document.getElementById("<%=spnpaper2.ClientID %>");
                var spnpaper3 = document.getElementById("<%=spnpaper3.ClientID %>");
                var spnpaper4 = document.getElementById("<%=spnpaper4.ClientID %>");
                var spnpaper5 = document.getElementById("<%=spnpaper5.ClientID %>");

                var len = document.getElementById("ctl00_ContentPlaceHolder1_hdnlength");

                var whitelen = document.getElementById("ctl00_ContentPlaceHolder1_hdnlengthforwhiteink");
                var val = document.getElementById("ctl00_ContentPlaceHolder1_hdnvalue");
                var ide = document.getElementById("ctl00_ContentPlaceHolder1_hdnid");
                var idsforwhiteink = document.getElementById("ctl00_ContentPlaceHolder1_hdnidforwhiteink");
                var whiteinkval = document.getElementById("ctl00_ContentPlaceHolder1_hdnwhiteinkvalue");

                //These variable declaration is used in checkNext function
                var txtGutterVertical = document.getElementById("<%=txtGutterVertical.ClientID %>");
                var txtGutterHorizontal = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
                var txtLargeFormatName = document.getElementById("<%=txtLargeFormatName.ClientID %>");
                var spntxtLargeFormatName = document.getElementById('spn_txtLargeFormatName');
                var txtMinimumWebWidth = document.getElementById("<%=txtMinimumWebWidth.ClientID %>");
                var txtMaximumWebWidth = document.getElementById("<%=txtMaximumWebWidth.ClientID %>");
                var txtMaximumSheetWeight = document.getElementById("<%=txtMaximumSheetWeight.ClientID %>");
                var txtGripDepth = document.getElementById("<%=txtGripDepth.ClientID %>");
                var txtSideGutterDepth = document.getElementById("<%=txtSideGutterDepth.ClientID %>");
                var ddlPrintSheetSize = document.getElementById("<%=ddlPrintSheetSize.ClientID %>");
                var spnPrintSheetSize = document.getElementById("spn_PrintSheetSize");
                var ddlJobSize = document.getElementById("<%=ddlJobSize.ClientID %>");
                //            var spnJobSize = document.getElementById("spn_JobSize");
                var ddlGuillotine = document.getElementById("<%=ddlGuillotine.ClientID %>");
                var spnGuillotine = document.getElementById("spn_Guillotine");
                var spnpaper1 = document.getElementById("ctl00_ContentPlaceHolder1_spnpaper1");
                var spndefaultpaper = document.getElementById('spn_defaultpaper1');
                var txtSpoilage = document.getElementById("<%=txtSpoilage.ClientID%>");
                var txtRunningSpoilage = document.getElementById("<%=txtRunningSpoilage.ClientID %>");
                var divPlantProperties = document.getElementById("div_Plant_Properties");
                var txtSetupCharge = document.getElementById("<%=txtSetupCharge.ClientID %>");


                //This variable declaration is used for checksave function
                var txtMinimumRunningCharge = document.getElementById("<%=txtMinimumRunningCharge.ClientID %>");
                var txtMarkup = document.getElementById("<%=txtMarkup.ClientID %>");
                var txtPrintPerHourLow = document.getElementById("<%=txtPrintPerHourLow.ClientID%>");
                var txtPrintPerHourMedium = document.getElementById("<%=txtPrintPerHourMedium.ClientID %>");
                var txtPrintPerHourHigh = document.getElementById("<%=txtPrintPerHourHigh.ClientID %>");
                var txtPressHourlyCharge = document.getElementById("<%=txtPressHourlyCharge.ClientID%>");
                var txtInkCoverageSide1 = document.getElementById("<%=txtInkCoverageSide1.ClientID %>");
                var txtInkCoverageSide2 = document.getElementById("<%=txtInkCoverageSide2.ClientID %>");
                var txtInk = document.getElementById("<%=txtInk.ClientID%>");

                var hdnval = document.getElementById("<%=hdneditvalue.ClientID %>");
                var hdnid = document.getElementById("<%=hdneditid.ClientID %>");

                var hdneditidforwhiteink = document.getElementById("<%=hdneditidforwhiteink.ClientID %>");
                var hdneditvalueforwhiteink = document.getElementById("<%=hdneditvalueforwhiteink.ClientID %>");


                var YieldMatrix_Value = document.getElementById("<%=YieldMatrix_Value.ClientID%>");
                var div_nonprintimage = document.getElementById("div_nonprintimage");
                var div_DefaultPrintSheet = document.getElementById("div_DefaultPrintSheet");
                var hdnAccountCode = document.getElementById("<%=hdnAccountCode.ClientID %>");
                var ddlAccountCode = document.getElementById("<%=ddlAccountCode.ClientID %>");
                var txtUnitOfMeasure = document.getElementById("<%=txtUnitOfMeasure.ClientID %>");
                var spn_UnitOfMeasure = document.getElementById("spn_UnitOfMeasure");
                var UnitOfMeasure = '<%=UnitOfMeasureKey %>';

                selectInk();
                selectWhiteInk();

                //******* funcn to check for digital press duplicacy *********////
                var IsDuplicate = false;
                function CheckLargeFormat(val1) {
                    if (val1 != '') {
                        var compID = '<%=CompanyID %>';
                        var id = '<%=PressID %>';
                        var val = compID + "±" + val1 + "±" + "largeformat" + "±" + id;
                        PageMethods.GetLargeFormat(val, ShowMsgLargeFormat, ShowMsg_Failure);
                    }
                }
                function ShowMsg_Failure(error) { }
                function ShowMsgLargeFormat(result) {
                    $get('spn_txtPlantPressCheck').style.display = "none";
                    if (result == -1) {
                        $get('spn_txtPlantPressCheck').style.display = "block";
                        IsDuplicate = true;
                    }
                    else {
                        IsDuplicate = false;
                    }
                }
                function RadWinClose() {

                    document.getElementById("divrad").style.display = "none";
                    document.getElementById("divBackGroundNew").style.display = "none";

                }
                function Show() {
                    if (document.getElementById("divrad").style.display == "none") {
                        if (navigator.appName != "Microsoft Internet Explorer") {
                            setLoadingPositionOfDivMove(document.getElementById("divrad"));
                            showDivPopupCenter('divrad', '200');
                        }
                    }
                    else {
                        document.getElementById("divrad").style.display = "none";
                        document.getElementById("divBackGroundNew").style.display = "none";
                    }
                }


                //*******End of funcn to ckech for digital press duplicacy*********////

                var commonpath = "<%=nmsCommon.global.sitePath()%>";


                var div_Feed_restriction = document.getElementById("div_Feed_restriction");
                var div_Paper_Settings = document.getElementById("div_Paper_Settings");
                var div_Plant_Properties = document.getElementById("div_Plant_Properties");
                var div_Plant_Calculation = document.getElementById("div_Plant_Calculation");
                var div_Plant_Charges = document.getElementById("div_Plant_Charges");
                var div_Ink_Order = document.getElementById("div_Ink_Order");
                var lblheader = document.getElementById("<%=lblheader.ClientID %>");
                var spnSpoilage = document.getElementById("spnSpoilageType");


            </script>
            <%-- <asp:Panel ID="pnl_ShowOnEdit" runat="server" Visible="false">
            <script type="text/javascript">
//                showonedit();
//                function showonedit() {
//                    var ddlvalue = document.getElementById('<%=ddlPaperType.ClientID %>');
//                    showSpoilageType(ddlvalue.value);
//                }
            </script>
        </asp:Panel>--%>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


