<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="litho_press_add.aspx.cs" Inherits="ePrint.settings.litho_press_add" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
    </script>
    <div align="left">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblTypeHeader" CssClass="navigatorpanel" runat="server">
                                <%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Sheet_Fed_Offset")%>
                                </asp:Label>
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
            <div class="mis_header_panel">
                <div align="left" style="width: 100%">
                    <div id="div_litho_stage1" align="left">
                        <div style="width: 49%; float: left;">
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Press_Name")%>
                                    </span><span style="color: Red;">&nbsp;*</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:TextBox ID="txtPressName" SkinID="textPad" runat="server" Width="195px" TabIndex="1"
                                        onblur="CheckLitho(this.value);" MaxLength="100"></asp:TextBox>
                                    <span id="spn_txtLithoPressName" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                        padding-right: 4px; width: auto;">
                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Press_Name")%>
                                    </span><span id="spn_txtPlantPressCheck" class="spanerrorMsg" style="display: none;
                                        padding-left: 4px; padding-right: 4px; width: auto;">
                                        <%=objLanguage.GetLanguageConversion("Press_Name_Already_Exists")%></span>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="height: 34px; width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Description")%>
                                    </span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:TextBox ID="txtDescription" SkinID="textPad" TextMode="MultiLine" Rows="1" Height="30px"
                                        runat="server" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"
                                        Width="195px" TabIndex="2"></asp:TextBox>
                                    <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                        padding-right: 4px; width: auto;">
                                        <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%>
                                    </span>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Set_Default_Press")%>
                                    </span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:CheckBox ID="chkDefaultPress" runat="server" TabIndex="3"></asp:CheckBox>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("This_Press_Can_Perfect")%>? </span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:RadioButton ID="rdoPerfectYes" Text="Yes" GroupName="Perfect" runat="server" />
                                    <asp:RadioButton ID="rdoPerfectNo" Text="No" runat="server" GroupName="Perfect" Checked="true" />
                                </div>
                            </div>
                            <div align="left" runat="server" id="div_AccountCode">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label></div>
                                <div class="ddlsetting" style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlAccountCode" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="height: 30px; width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Maximum_Sheet_Size")%>
                                    </span><span style="color: Red;">&nbsp;*</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <div align="left">
                                        <div style="float: left; width: 40px">
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("Height")%>
                                            </span>
                                        </div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtMaxImgHeight" Style="text-align: right" runat="server" Width="50px"
                                                SkinID="textPad" MaxLength="12" TabIndex="4" onblur="CallonBlur(this.value,'spn_MaximumImageArea');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblMaxImgHeight" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div style="float: left; width: 40px;">
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("Width")%>
                                            </span>&nbsp;</div>
                                        <div style="float: left; padding-top: 1px;">
                                            <asp:TextBox ID="txtMaxImgWidth" Style="text-align: right" runat="server" Width="50px"
                                                SkinID="textPad" MaxLength="12" TabIndex="5" onblur="CallonBlur(this.value,'spn_MaximumImageArea');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblMaxImgWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                        </div>
                                    </div>
                                    <div id="spn_MaximumImageArea" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Max_Image_Area")%>
                                        </div>
                                    </div>
                                    <div id="spn_MaximumImageArea_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Maximum_Sheet_Weight")%>
                                    </span><span style="color: Red;">&nbsp;*</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <div style="float: left; width: 40px">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtMaxSheetWeight" Style="text-align: right" runat="server" Width="50px"
                                            SkinID="textPad" MaxLength="12" TabIndex="6" onblur="CallonBlur(this.value,'spn_txtMaxSheetWeight');todecimal_function(this,this.value);"><%--AmountTo2Decimal(this,this.value);--%>
                                        </asp:TextBox>&nbsp;<asp:Label ID="lblMaxSheetWeight" runat="server" CssClass="normalText"><%=WeightMeasure %></asp:Label>
                                    </div>
                                    <div id="spn_txtMaxSheetWeight" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Max_Sheet_Weight")%>
                                        </div>
                                    </div>
                                    <div id="spn_txtMaxSheetWeight_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="header">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Press_Restrictions")%>
                                </span>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="height: 33px; width: 45%">
                                    <span class="normalText"></span>
                                    <%=objLanguage.GetLanguageConversion("Non_Print_Image_Side_Area")%>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="box" style="width: 45%" nowrap="nowrap">
                                    <div align="left">
                                        <div style="float: left; padding-top: 1px; width: 40px;">
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("Height")%>
                                            </span>&nbsp;</div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtGutterDepthHeight" Style="text-align: right" runat="server" Width="50px"
                                                SkinID="textPad" TabIndex="7" MaxLength="12" onblur="CallonBlur(this.value,'spn_GutterDepth');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblPrintHeight" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                        </div>
                                    </div>
                                    <div align="left" style="clear: left; padding-top: 1px;">
                                        <div style="float: left; width: 40px;">
                                            <span class="normalText">
                                                <%=objlang.GetValueOnLang("Width")%>
                                            </span>&nbsp;</div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtGutterDepthWidtht" Style="text-align: right;" runat="server"
                                                Width="50px" SkinID="textPad" TabIndex="8" MaxLength="12" onblur="CallonBlur(this.value,'spn_GutterDepth');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblPrintWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                        </div>
                                    </div>
                                    <div id="spn_GutterDepth" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Image_Side_Area")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div id="spn_GutterDepth_number" style="display: none; width: auto; float: left;
                                        clear: both">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="height: 33px; width: 45%">
                                    <span class="normalText"></span>
                                    <%=objLanguage.GetLanguageConversion("Default_Gutters")%>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="box" style="width: 45%" nowrap="nowrap">
                                    <div align="left">
                                        <div style="float: left; padding-top: 1px; width: 40px;">
                                            <span class="normalText">
                                                <%=objlang.GetValueOnLang("Horiz")%>
                                            </span>&nbsp;</div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtGutterHorizontal" Style="text-align: right;" runat="server" Width="50px"
                                                SkinID="textPad" MaxLength="8" TabIndex="9" onblur="CallonBlur(this.value,'spn_DefaultGutters');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblGutterHor" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>
                                        </div>
                                    </div>
                                    <div align="left" style="clear: left; padding-top: 1px;">
                                        <div style="float: left; width: 40px;">
                                            <span class="normalText">
                                                <%=objlang.GetValueOnLang("Vertic")%>
                                            </span>&nbsp;</div>
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtGutterVertical" Style="text-align: right;" runat="server" Width="50px"
                                                SkinID="textPad" MaxLength="8" TabIndex="10" onblur="CallonBlur(this.value,'spn_DefaultGutters');todecimal_function(this,this.value);">
                                            </asp:TextBox>&nbsp;<asp:Label ID="lblGutterVer" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label>&nbsp;
                                        </div>
                                    </div>
                                    <div id="spn_DefaultGutters" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Default_Gutters")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div id="spn_DefaultGuttersNumber" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("SetUp_Spoilage_Number_Of_Sheets")%>
                                    </span><span style="color: Red">*</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <div style="width: 175.5px">
                                        <asp:TextBox ID="txtSpoilageSheets" runat="server" SkinID="textPad" onblur="CallonBlur(this.value,'spn_txtSpoilageSheets');todecimal_function(this,this.value);"
                                            TabIndex="11" MaxLength="20" CssClass="textboxnew1" Width="90px"></asp:TextBox>
                                    </div>
                                    <div id="spn_txtSpoilageSheets" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Spoilage_Sheets")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div id="spn_txtSpoilageSheets_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" nowrap="nowrap" style="width: 45%">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Running_Spoilage")%>
                                        (%) </span><span style="color: Red">*</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <div style="width: 175.5px">
                                        <asp:TextBox ID="txtRunningSpoilage" runat="server" SkinID="textPad" onblur="CallonBlur(this.value,'spn_txtRunningSpoilage');todecimal_function(this,this.value);"
                                            TabIndex="12" MaxLength="20" CssClass="textboxnew1" Width="90px"></asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                    </div>
                                    <div id="spn_txtRunningSpoilage" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Running_Spoilage")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div id="spn_txtRunningSpoilage_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 49%; float: left;">
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <div style="float: left">
                                        <asp:Label ID="Label25" runat="server" Text="Default Paper" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Default_Paper")%></asp:Label>
                                        <span style="color: Red"></span>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton ID="imgbtnDefaultPaper" runat="server" ImageUrl="~/images/plus.gif"
                                            OnClientClick="javascript:return MoreStock('paper');" TabIndex="13" />
                                    </div>
                                </div>
                                <div class="box" style="width: 45%; padding-top: 4px; overflow: hidden">
                                    <asp:Label ID="lblDefaultPaper" runat="server" CssClass="graytext"></asp:Label>
                                    <div id="spn_lblDefaultPaper" style="display: none; width: auto; float: left; clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetValueOnLang("Please select Paper")%></span>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdnpaperID" runat="server" Value="0" />
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="Label7" runat="server" Text="Default Print Sheet Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Print_Sheet_Size") %></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="ddlsetting" style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlPrintSheetSize" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                                        Width="183px" TabIndex="14">
                                    </asp:DropDownList>
                                    <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left; clear: both;">
                                        <div>
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                <%--<%=objlang.GetValueOnLang("Please select Print Sheet Size")%>--%>
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="Label5" runat="server" Text="Default Job Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Job_Size")%></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="ddlsetting" style="padding-left: 5px">
                                    <asp:DropDownList ID="ddlJobSize" runat="server" CssClass="normalText" Width="183px"
                                        onchange="CallonChange(this.value,'spn_ddlJobSize')" TabIndex="15">
                                    </asp:DropDownList>
                                    <div id="spn_ddlJobSize" style="display: none; width: auto; float: left; clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Job_Size")%>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <div style="float: left">
                                        <asp:Label ID="Label1" runat="server" Text="Default Plate" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Default_Plate")%></asp:Label>
                                        <span style="color: Red">*</span>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/plus.gif" TabIndex="16"
                                            OnClientClick="javascript:return MoreStock('plates');" />
                                    </div>
                                </div>
                                <div class="box" style="width: 45%; padding-top: 4px; overflow: hidden">
                                    <asp:Label ID="lblDefaultPlates" runat="server" CssClass="graytext"></asp:Label>
                                    <div id="spn_lblDefaultPlates" style="display: none; width: auto; float: left; clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Plate") %>
                                            </span>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdnplateID" runat="server" Value="0" />
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <div style="float: left">
                                        <asp:Label ID="Label6" runat="server" Text="Default Guillotine" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Guillotine")%></asp:Label>
                                    </div>
                                    <div style="float: right;">
                                        <a href="javascript://" style="cursor: pointer;" onclick="GuillotineSelect();return false;">
                                            <img src="<%=strImagepath %>plus.gif" border="0" tabindex="16" /></a>
                                    </div>
                                </div>
                                <div class="box" style="width: 45%; padding-top: 4px; overflow: hidden">
                                    <asp:Label ID="lblGuillotine" Width="260px" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                                    <div id="spn_ddlGuillotine" style="display: none; width: auto; float: left; clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objlang.GetValueOnLang("Please select Guillotine")%>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%; background-color: White; padding-bottom: 0px">
                                    <b>
                                        <%=objLanguage.GetLanguageConversion("Plant_Charges")%></b>
                                </div>
                                <div class="box" style="width: 45%; min-width: 300px">
                                    <div style="width: 95px; float: left; padding-bottom: 0px">
                                        <b>
                                            <%=objLanguage.GetLanguageConversion("Sheet_Work")%></b>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 95px; float: left; padding-bottom: 0px">
                                        <b>
                                            <%=objLanguage.GetLanguageConversion("Work_N_Turn")%></b>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 100px; float: left;">
                                        <b>
                                            <%=objLanguage.GetLanguageConversion("Work_N_Tumble")%></b>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="Label19" runat="server" Text="Set up Charge " CssClass="normaltext"><%=objLanguage.GetLanguageConversion("SetUp_Charge")%>($)</asp:Label></div>
                                <div class="box" style="width: 45%; min-width: 300px">
                                    <div style="width: 95px; float: left">
                                        <asp:TextBox ID="txtSetupCharge" runat="server" SkinID="textPad" Style="text-align: right;"
                                            TabIndex="18" MaxLength="20" CssClass="textboxnew1" onblur="todecimal_function(this,this.value);"
                                            Width="90px">0.00</asp:TextBox>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 95px; float: left">
                                        <asp:TextBox ID="txtSetupChargeWork_n_Turn" runat="server" SkinID="textPad" Style="text-align: right;"
                                            TabIndex="18" MaxLength="20" CssClass="textboxnew1" onblur="todecimal_function(this,this.value);"
                                            Width="90px">0.00</asp:TextBox>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 100px; float: left">
                                        <asp:TextBox ID="txtSetupChargeWork_n_Tumble" runat="server" SkinID="textPad" Style="text-align: right;"
                                            TabIndex="18" MaxLength="20" CssClass="textboxnew1" onblur="todecimal_function(this,this.value);"
                                            Width="90px">0.00</asp:TextBox>
                                    </div>
                                    <div id="spn_txtSetupCharge_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <div style="float: left">
                                        <asp:Label ID="Label2" runat="server" Text="Make Ready Charge Per Plate" CssClass="normalText"></asp:Label></div>
                                    <div style="float: right;">
                                        <asp:CheckBox ID="chkMakeReady" runat="server" TabIndex="20" /></div>
                                </div>
                                <div class="box" style="width: 45%; min-width: 300px">
                                    <div style="width: 95px; float: left">
                                        <asp:TextBox ID="txtMakeReady" runat="server" SkinID="textPad" Style="text-align: right"
                                            TabIndex="20" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 95px; float: left">
                                        <asp:TextBox ID="txtMakeReadyWork_n_Turn" runat="server" SkinID="textPad" Style="text-align: right"
                                            TabIndex="20" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox>
                                    </div>
                                    <div style="width: 5px; float: left; padding-bottom: 0px">
                                        &nbsp;</div>
                                    <div style="width: 100px; float: left">
                                        <asp:TextBox ID="txtMakeReadyWork_n_Tumble" runat="server" SkinID="textPad" Style="text-align: right"
                                            TabIndex="20" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="Label20" runat="server" Text="Minimum Running Charge ($)" CssClass="normaltext"></asp:Label></div>
                                <div class="box" style="width: 45%">
                                    <div style="width: 175.5px">
                                        <asp:TextBox ID="txtMinRunningCharge" runat="server" SkinID="textPad" Style="text-align: right"
                                            TabIndex="21" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox><%--onblur="AmountTo2Decimal(this,this.value);"--%>
                                    </div>
                                    <div id="spn_txtMinRunningCharge_number" style="display: none; width: auto; float: left;
                                        clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <div style="float: left">
                                        <asp:Label ID="Label4" runat="server" Text="Wash Up Charge Per Colour ($)" CssClass="normalText"></asp:Label></div>
                                    <div style="float: right;">
                                        <asp:CheckBox ID="chkWashUp" runat="server" TabIndex="22" /></div>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:TextBox ID="txtWashUp" runat="server" SkinID="textPad" Style="text-align: right"
                                        TabIndex="23" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox><%--onblur="AmountTo2Decimal(this,this.value);"--%>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <asp:Label ID="Label22" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Mark_Up")%> (%)</asp:Label></div>
                                <div class="box" style="width: 45%">
                                    <div style="width: 175.5px">
                                        <asp:TextBox ID="txtMarkUp" runat="server" SkinID="textPad" Style="text-align: right"
                                            TabIndex="24" MaxLength="20" Width="90px" onblur="todecimal_function(this,this.value);">0.00</asp:TextBox>
                                    </div>
                                    <div id="spn_txtMarkUp_number" style="display: none; width: auto; float: left; clear: both;">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Unit Of Measure-->
                            <div id="div_UnitOfMeasure" runat="server" class="onlyEmpty" style="display: none">
                                <div class="bglabel" style="width: 45%">
                                    <%=objLanguage.GetLanguageConversion("Unit_Of_Measure")%>
                                </div>
                                <div class="box" style="width: 45%">
                                    <asp:TextBox ID="txtUnitOfMeasure" runat="server" SkinID="textPad" TabIndex="24"
                                        Width="90px" MaxLength="8" onblur="SetNumber_OfUnit(this,this.value);" onkeyup="ToInteger(this,this.value);"
                                        Style="text-align: right" Text="1000"></asp:TextBox>
                                    <span id="spn_UnitOfMeasure" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                        padding-right: 4px; width: auto;">
                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Integer_Value")%>
                                    </span>
                                </div>
                            </div>
                            <!-- Unit Of Measure-->
                            <div class="only10px">
                            </div>
                            <div align="left">
                                <div class="bglabelEmpty" style="width: 45%;">
                                </div>
                                <div class="box" style="width: 250px;">

                                    <div style="float: left">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                OnClick="btnDelete_OnClick" OnClientClick="javascript:var a=window.confirm('Are you sure, you want to delete this press?');if(a)loadingimage(this.id,'div_btndeleteprocess');return a;"
                                                TabIndex="26" />
                                        </div>
                                        <div id="div_btndeleteprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>

                                    <%--<div style="float: left">
                                        <div id="div_btncancel" style="display: block">
                                            <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" TabIndex="25"
                                                OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_btncancelprocess');" />
                                        </div>
                                        <div id="div_btncancelprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>--%>

                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>

                                    <div style="float: left">
                                        <div id="div_btncancel" style="display: block">
                                            <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" TabIndex="25"
                                                OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_btncancelprocess');" />
                                        </div>
                                        <div id="div_btncancelprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>

                                    <%--<div style="float: left">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                OnClick="btnDelete_OnClick" OnClientClick="javascript:var a=window.confirm('Are you sure, you want to delete this press?');if(a)loadingimage(this.id,'div_btndeleteprocess');return a;"
                                                TabIndex="26" />
                                        </div>
                                        <div id="div_btndeleteprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>--%>

                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <asp:Button ID="btnNext" CssClass="button" runat="server" Text="Next" TabIndex="26"
                                            OnClientClick="javascript:LithoNext();return false;" />
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                            <div class="only10px">
                            </div>
                        </div>
                    </div>
                    <div id="div_litho_stage2" align="left" style="display: none">
                        <div style="width: 49%; float: left;">
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span class="headertext">
                                        <%=objLanguage.GetLanguageConversion("Calculation_Method")%>
                                    </span>
                                </div>
                                <div class="box" style="float: left; width: 30%;">
                                    <asp:DropDownList ID="ddlMethod" runat="server" CssClass="normalText" TabIndex="27"
                                        onchange="javascript:ShowOnCalculation(this);CallonChange(ddlMethod.value,'spn_ddlMethod');">
                                        <asp:ListItem Value="speedweightlookup">SpeedWeight Lookup</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hid_ddlMethodSelected" Value="" runat="server" />
                                    <span id="spn_ddlMethod" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                        padding-right: 4px; width: auto;">
                                        <%=objlang.GetValueOnLang("Please select Calculation Method")%></span>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabel" style="width: 45%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Press_Hourly_Charge_Rate")%>
                                        (<%=objcom.GetCurrencyinRequiredFormate("",true)%>)</span><span style="color: Red">
                                            *</span>
                                </div>
                                <div class="box" style="width: 45%">
                                    <div align="left">
                                        <asp:TextBox ID="txtHourlyCharge" runat="server" Width="60px" SkinID="textPad" onblur="CheckDecimalPlus(this.value,'spn_txtHourlyCharge','spn_txtHourlyCharge_number','no');todecimal_function(this,this.value);"
                                            TabIndex="28"></asp:TextBox><%--LithoAmountTo2Decimal(this,this.value);--%>
                                    </div>
                                    <div align="left">
                                        <span id="spn_txtHourlyCharge" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                            padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Hourly_Charge_Rate")%>
                                        </span><span id="spn_txtHourlyCharge_number" class="spanerrorMsg" style="display: none;
                                            padding-left: 4px; padding-right: 4px; width: auto;">Please enter numeric value</span><span
                                                id="spn_txtHourlyCharge_range" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                padding-right: 4px; width: auto;">
                                                <%=objlang.GetValueOnLang("Enter rate b/w")%>
                                                1000-2500</span>
                                    </div>
                                </div>
                            </div>
                            <div align="left" class="only10px">
                                <div style="display: none;">
                                    <table align="left" class="ex" cellspacing="0" border="1" width="80%" cellpadding="4">
                                        <col width="30%" />
                                        <col width="30%" />
                                        <tr class="label">
                                            <td align="left">
                                                <span class="HeaderText">
                                                    <%=WeightMeasure %></span>
                                            </td>
                                            <td align="left">
                                                <span class="HeaderText">
                                                    <%=objlang.GetValueOnLang("Sheets Per Hour")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackGSM1" runat="server" SkinID="textPad" Width="75px" onblur="CallonBlur(this.value,'spn_txtBlackGSM1');IsIntegerParameter(this.value,'spn_txtBlackGSM1_number');"
                                                    MaxLength="8" TabIndex="29"></asp:TextBox>
                                                <span id="spn_txtBlackGSM1" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                    padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter GSM value")%>
                                                </span><span id="spn_txtBlackGSM1_number" class="spanerrorMsg" style="display: none;
                                                    padding-left: 4px; padding-right: 4px; width: auto;">Please enter numeric value</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackPagesPerMinute1" runat="server" SkinID="textPad" Width="75px"
                                                    onblur="CallonBlur(this.value,'spn_txtBlackPagesPerMinute1');IsIntegerParameter(this.value,'spn_txtBlackPagesPerMinute1_number');"
                                                    MaxLength="8" TabIndex="30"></asp:TextBox>
                                                <span id="spn_txtBlackPagesPerMinute1" class="spanerrorMsg" style="display: none;
                                                    padding-left: 4px; padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter Pages Per Min.")%></span><span id="spn_txtBlackPagesPerMinute1_number"
                                                        class="spanerrorMsg" style="display: none; padding-left: 4px; padding-right: 4px;
                                                        width: auto;">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackGSM2" runat="server" SkinID="textPad" Width="75px" MaxLength="8"
                                                    onblur="IsIntegerParameter(this.value,'spn_txtBlackGSM2_number');" TabIndex="31"></asp:TextBox>
                                                <span id="spn_txtBlackGSM2_number" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                    padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackPagesPerMinute2" runat="server" SkinID="textPad" Width="75px"
                                                    MaxLength="8" onblur="IsIntegerParameter(this.value,'spn_txtBlackPagesPerMinute2_number');"
                                                    TabIndex="32"></asp:TextBox>
                                                <span id="spn_txtBlackPagesPerMinute2_number" class="spanerrorMsg" style="display: none;
                                                    padding-left: 4px; padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackGSM3" runat="server" SkinID="textPad" Width="75px" MaxLength="8"
                                                    onblur="IsIntegerParameter(this.value,'spn_txtBlackGSM3_number');" TabIndex="33"></asp:TextBox>
                                                <span id="spn_txtBlackGSM3_number" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                    padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBlackPagesPerMinute3" runat="server" SkinID="textPad" Width="75px"
                                                    MaxLength="8" onblur="IsIntegerParameter(this.value,'spn_txtBlackPagesPerMinute3_number');"
                                                    TabIndex="34"></asp:TextBox>
                                                <span id="spn_txtBlackPagesPerMinute3_number" class="spanerrorMsg" style="display: none;
                                                    padding-left: 4px; padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="div_matrix" class="only5px" style="border: solid 1px silver; width: 98%;"
                                    runat="server">
                                    <table align="center" cellpadding="3" cellspacing="3" width="94%">
                                        <tr>
                                            <td align="left" width="17%">
                                                <div align="left">
                                                    <%=objLanguage.GetLanguageConversion("Run_Length")%>
                                                    -------------
                                                </div>
                                                <div align="left">
                                                    <%=WeightMeasure %>
                                                </div>
                                            </td>
                                            <td align="left" width="17%" valign="top">
                                                <input id="txt_headersh1" type="text" class="textboxnew" value="2000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="29" />
                                            </td>
                                            <td align="left" width="17%" valign="top">
                                                <input id="txt_headersh2" type="text" class="textboxnew" value="3000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="30" />
                                            </td>
                                            <td align="left" width="17%" valign="top">
                                                <input id="txt_headersh3" type="text" class="textboxnew" value="5000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="31" />
                                            </td>
                                            <td align="left" width="17%" valign="top">
                                                <input id="txt_headersh4" type="text" class="textboxnew" value="7000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="32" />
                                            </td>
                                            <td align="left" width="17%" valign="top">
                                                <input id="txt_headersh5" type="text" class="textboxnew" value="9000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="33" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <input id="txt_headergsm1" type="text" class="textboxnew" value="80" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="34" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val11" type="text" class="textboxnew" value="6000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="35" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val21" type="text" class="textboxnew" value="7000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="36" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val31" type="text" class="textboxnew" value="8000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="37" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val41" type="text" class="textboxnew" value="9000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="38" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val51" type="text" class="textboxnew" value="10000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="39" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <input id="txt_headergsm2" type="text" class="textboxnew" value="150" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="40" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val12" type="text" class="textboxnew" value="8000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="41" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val22" type="text" class="textboxnew" value="9000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="42" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val32" type="text" class="textboxnew" value="10000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="43" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val42" type="text" class="textboxnew" value="11000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="44" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val52" type="text" class="textboxnew" value="12000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="45" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <input id="txt_headergsm3" type="text" class="textboxnew" value="300" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="46" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val13" type="text" class="textboxnew" value="8500" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="47" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val23" type="text" class="textboxnew" value="9000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="48" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val33" type="text" class="textboxnew" value="10000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="49" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val43" type="text" class="textboxnew" value="11000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="50" />
                                            </td>
                                            <td align="left">
                                                <input id="txt_val53" type="text" class="textboxnew" value="12000" style="width: 47px;
                                                    text-align: right" runat="server" onblur="valuecheckisnum(this,this.value);"
                                                    maxlength="12" tabindex="51" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <a id="href_gsm" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                            <td align="left">
                                                <a id="href_col1" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                            <td align="left">
                                                <a id="href_col2" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                            <td align="left">
                                                <a id="href_col3" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                            <td align="left">
                                                <a id="href_col4" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                            <td align="left">
                                                <a id="href_col5" style="cursor: pointer" onclick="clearthis(this.id)">
                                                    <%=objlang.GetLanguageConversion("Clear")%></a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Note_Litho_Press_Add")%></span>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="only5px">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 49%; float: left;">
                            <div align="left">
                                <div class="header" style="width: 100%">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Select_The_Inks_To_Be_Assigned_To_This_Press")%></span>
                                    <div>
                                        <asp:RadioButton ID="rdn_Yield" runat="server" Checked="true" Text="Yield" OnClientClick="javascript:return YieldMatrixValue('Y');" />
                                        <asp:RadioButton ID="rdn_Matrix" runat="server" Text="Matrix" OnClientClick="javascript:return YieldMatrixValue('M');" />
                                        <asp:HiddenField ID="YieldMatrix_Value" runat="server" Value="" />
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="header" style="width: 100%">
                                    <span class="HeaderText">
                                        <%=objlang.GetValueOnLang("Select_The_Inks_To_Be_Assigned_To_This_Press")%></span>
                                </div>
                            </div>
                            <div id="div_Scroll2" style="float: left; width: 100%; height: 150px; overflow-y: scroll;
                                overflow-x: hidden; border: solid 1px silver;">
                                <div id="divOnlyContent" style="float: left; width: 100%; display: none;">
                                    <div align="left">
                                        <div class="bglabel" style="width: 45%">
                                            <div style="float: left">
                                                <asp:Label ID="lblInk" runat="server" Text="Ink 1" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Ink")%>1</asp:Label></div>
                                            <div style="float: right">
                                                <img id="imgInk" src="~/images/plus.gif" onclick="javascript:return false;" alt="More Ink"
                                                    tabindex="35" /></div>
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
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <div style="float: left;">
                                            <a href="#addINK" onclick="javascript:AddMoreInk('new');">
                                                <%=objLanguage.GetLanguageConversion("Add_More")%></a></div>
                                        <div style="float: left;">
                                            &nbsp;|&nbsp;<a href="#addINK" onclick="javascript:DeleteMoreInk();"><%=objLanguage.GetLanguageConversion("Remove")%></a></div>
                                    </div>
                                </div>
                                <asp:HiddenField runat="server" ID="hdnlitholength" Value="0" />
                                <asp:HiddenField runat="server" ID="hdnlithovalue" Value="0" />
                                <asp:HiddenField runat="server" ID="hdnlithoid" Value="0" />
                                <asp:HiddenField runat="server" ID="hdnlithoeditvalue" Value="0" />
                                <asp:HiddenField runat="server" ID="hdnlithoeditid" Value="0" />
                                <div>
                                    <a id="addINK" name="addINK"></a>
                                </div>
                            </div>
                            <div style="float: left; width: 100%;">
                                <div class="header">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Ink_Setup")%></span>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 45%">
                                        <span>
                                            <%=objLanguage.GetLanguageConversion("Number_Of")%>&nbsp;<%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%>&nbsp;<%=objLanguage.GetLanguageConversion("Units")%></span>
                                    </div>
                                    <div class="box" style="width: 45%">
                                        <asp:DropDownList ID="ddlColourunit" runat="server" CssClass="normalText" TabIndex="53">
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
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 45%">
                                        <span>
                                            <%=objLanguage.GetLanguageConversion("Default")%>&nbsp;<%=objLanguage.GetLanguageConversion("Number_Of")%>&nbsp;<%=ObjPage.GetRegionalSettings(CompanyID, "Colour") %></span>
                                    </div>
                                    <div class="box" style="width: 45%">
                                        <asp:DropDownList ID="ddlColourNo" runat="server" CssClass="normalText" TabIndex="54">
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
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 45%">
                                        <span>
                                            <%=objLanguage.GetLanguageConversion("Default_Ink_Coverage")%>
                                            (%)</span><span style="color: Red"> *</span>
                                    </div>
                                    <div class="box" style="width: 45%">
                                        <asp:TextBox ID="txtDefaultInk" runat="server" Width="60px" SkinID="textPad" onblur="CheckDecimalPlus(this.value,'spn_txtDefaultInk','spn_txtDefaultInk_number','no');todecimal_function(this,this.value);"
                                            TabIndex="55" MaxLength="20" Style="text-align: right"></asp:TextBox>
                                        <div align="left">
                                            <span id="spn_txtDefaultInk" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                padding-right: 4px; width: auto;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Ink_Coverage")%></span><span id="spn_txtDefaultInk_number"
                                                    class="spanerrorMsg" style="display: none; padding-left: 4px; padding-right: 4px;
                                                    width: auto;">
                                                    <%=objlang.GetValueOnLang("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left">
                                <div class="bglabelEmpty">
                                </div>
                                <div class="box" style="margin-left: 30px; width: 300px;">
                                    <div style="float: left;">
                                        <asp:Button ID="btnPrevious" CssClass="button" runat="server" Text="Previous" OnClientClick="javascript:LithoPrevious();return false;"
                                            TabIndex="56" />
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnCancel1" style="display: block">
                                            <asp:Button ID="btnCancel1" CssClass="button" runat="server" Text="Cancel" TabIndex="57" />
                                        </div>
                                        <div id="div_btncancel1process" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnsave" style="display: block">
                                            <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" TabIndex="58"
                                                OnClick="btnSave_OnClick" OnClientClick="javascript:var a=FinalSave();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                        </div>
                                        <div id="div_btnsaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <asp:Button ID="Button3" CssClass="button" runat="server" Text="Delete" Visible="false"
                                            OnClientClick="javascript:return window.confirm('Are you sure, you want to delete this press?');"
                                            TabIndex="41" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
            Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <asp:HiddenField runat="server" ID="hdnlength" Value="0" />
    <asp:HiddenField runat="server" ID="hdnvalue" Value="0" />
    <asp:HiddenField runat="server" ID="hdnid" Value="0" />
    <asp:HiddenField runat="server" ID="hdneditvalue" Value="0" />
    <asp:HiddenField runat="server" ID="hdneditid" Value="0" />
    <asp:HiddenField runat="server" ID="hid_GuillotineID" Value="0" />
    <script type="text/javascript" src="<%=strSitepath %>js/Item/settingsjs.js"></script>
    <script type="text/javascript" language="javascript">

        var commonpath = "<%=nmsCommon.global.sitePath()%>";


        var hdnval = document.getElementById("<%=hdneditvalue.ClientID %>");
        var hdnid = document.getElementById("<%=hdneditid.ClientID %>");
        var ddlMethod = document.getElementById("<%=ddlMethod.ClientID %>");

        

        function CheckDecimalPlus_litho(fieldValue, spanid1, spanid2, IsRequired) {

            if (spanid1 != '') {
                document.getElementById(spanid1).style.display = "none";
            }
            if (spanid2 != '') {
                document.getElementById(spanid2).style.display = "none";
            }
            if (trim12(fieldValue) == '') {
                if (IsRequired == "yes") {
                    document.getElementById(spanid1).style.display = "block";
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                if (!isNaN(fieldValue)) {
                    decallowed = 3;
                    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
                    dectext = fieldValue.substring(fieldValue.indexOf('.') + 1, fieldValue.length);
                    if (dectext.length > decallowed) {
                        document.getElementById(spanid2).style.display = "block";
                        return false;
                    }
                    else {
                        document.getElementById(spanid2).style.display = "none";
                        return true;
                    }
                }
                else {
                    document.getElementById(spanid2).style.display = "block";
                    return false;
                }
            }
        }



        var len = document.getElementById("<%=hdnlength.ClientID %>");
        var val = document.getElementById("<%=hdnvalue.ClientID %>");
        var ide = document.getElementById("<%=hdnid.ClientID %>");
        var hdnval = document.getElementById("<%=hdneditvalue.ClientID %>");
        var hdnid = document.getElementById("<%=hdneditid.ClientID %>");


        var txtLithoPressName = document.getElementById("<%=txtPressName.ClientID %>");
        var txtMaxImgHeight = document.getElementById("<%=txtMaxImgHeight.ClientID %>");
        var txtMaxImgWidth = document.getElementById("<%=txtMaxImgWidth.ClientID %>");
        var txtMaxSheetWeight = document.getElementById("<%=txtMaxSheetWeight.ClientID %>");
        var txtGutterDepthHeight = document.getElementById("<%=txtGutterDepthHeight.ClientID %>");
        var txtGutterDepthWidtht = document.getElementById("<%=txtGutterDepthWidtht.ClientID %>");
        var txtGutterHorizontal = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
        var txtGutterVertical = document.getElementById("<%=txtGutterVertical.ClientID %>");
        var txtSpoilageSheets = document.getElementById("<%=txtSpoilageSheets.ClientID %>");
        var txtRunningSpoilage = document.getElementById("<%=txtRunningSpoilage.ClientID %>");
        var ddlPrintSheetSize = document.getElementById("<%=ddlPrintSheetSize.ClientID %>");
        var ddlJobSize = document.getElementById("<%=ddlJobSize.ClientID %>");
        var txtSetupCharge = document.getElementById("<%=txtSetupCharge.ClientID %>");
        var txtMinRunningCharge = document.getElementById("<%=txtMinRunningCharge.ClientID %>");
        var txtMarkUp = document.getElementById("<%=txtMarkUp.ClientID %>");
        var ddlMethod = document.getElementById("<%=ddlMethod.ClientID %>");
        var txtHourlyCharge = document.getElementById("<%=txtHourlyCharge.ClientID %>");
        var txtDefaultInk = document.getElementById("<%=txtDefaultInk.ClientID %>");
        var lblDefaultPaper = document.getElementById("<%=lblDefaultPaper.ClientID %>");
        var lblDefaultPlates = document.getElementById("<%=lblDefaultPlates.ClientID %>");

        var hdnpaperID = document.getElementById("<%=hdnpaperID.ClientID%>");
        var hdnplateID = document.getElementById("<%=hdnplateID.ClientID%>");
        var hid_GuillotineID = document.getElementById("<%=hid_GuillotineID.ClientID %>");
        var lblGuillotine = document.getElementById("<%=lblGuillotine.ClientID %>");

        var rdn_Yield = document.getElementById("<%=rdn_Yield.ClientID %>");
        var rdn_Matrix = document.getElementById("<%=rdn_Matrix.ClientID %>");

        var txtUnitOfMeasure = document.getElementById("<%=txtUnitOfMeasure.ClientID %>");
        var spn_UnitOfMeasure = document.getElementById("spn_UnitOfMeasure");
        var UnitOfMeasure = '<%=UnitOfMeasureKey %>';



        var strSitepath = "<%=strSitepath %>";
        var CheckCount = 1;
        var action = "<%=ReqType %>";
        function showdivs() {
            for (var i = 0; i < 5; i++) {
                AddMoreInk('default');
            }
        }

        if (action == 'add') {
            showdivs();
        }
        else {
            var hdnid2 = document.getElementById("<%=hdneditid.ClientID %>");
            var ids = new Array();
            ids = hdnid2.value.split('^');
            if (ids.length <= 5) {
                showdivs();
            }
            else {
                for (var i = 0; i < ids.length - 1; i++) {
                    AddMoreInk('default');
                }
            }
        }



        function AddMoreInk(type) {
            var div_Content = document.getElementById("divContent");
            var hdnlength = document.getElementById("<%=hdnlength.ClientID %>");
            hdnlength.value = CheckCount;
            var divconetent = '';
            var Ink = '<%=objlang.GetLanguageConversion("Ink") %>';

            divconetent = "<div align='left'>";
            divconetent = divconetent + "<div class='bglabel'>";
            divconetent = divconetent + "<div style='float: left'>";
            if (CheckCount == '1') {
                divconetent = divconetent + "<span class='normaltext'> " +Ink+ CheckCount + "</span>" +
                 " <span style='color: red'>*</span> </div>";
            }
            else {
                divconetent = divconetent + "<span class='normaltext'>" +Ink+ CheckCount + "</span></div>";
            }

            divconetent = divconetent + "<div style='float: right;'>";
            divconetent = divconetent + "<img id='" + CheckCount + "' style='cursor:pointer' src='" + strImagepathjs + "plus.gif' onclick='openpopup(this.id);' TabIndex='52'/></div>";
            divconetent = divconetent + "</div>";


            divconetent = divconetent + "<div class='box' nowrap='nowrap'>";
            divconetent = divconetent + "<span class='graytext' id='spn" + CheckCount + "'></span>&nbsp;<input type='hidden' id='hdn" + CheckCount + "' />";
            divconetent = divconetent + "</div>";



            divconetent = divconetent + "</div>";

            if (CheckCount == '1') {
                divconetent = divconetent + "</div><div align='left' style='float: left'><span id='spn_ink' class='spanerrorMsg' style='display: none; position:static; padding-left: 4px; padding-right: 4px; width: auto'><%=objLanguage.GetLanguageConversion("Please_Select_Ink") %></span></div>";
            }

            if (CheckCount < 21) {
                div_Content.innerHTML = div_Content.innerHTML + divconetent;
                CheckCount = CheckCount + 1;
            }
            return false;
        }

        function selectInk() {

            var names = new Array();
            var ids = new Array();
            names = hdnval.value.split('^');

            ids = hdnid.value.split('^');
            for (var i = 0; i < ids.length - 1; i++) {
                var j = i + 1;
                var spn = "spn" + j;
                var hdn = "hdn" + j;
                document.getElementById(spn).innerHTML = SpecialDecode(names[i]) + "&nbsp;<img id='img" + j + "' style='cursor:pointer' alt='Clear this ink' src='" + strImagepathjs + "close.gif' onclick=\"javascript:clear_ink(this.id,'" + names[i] + "');\" />";
                document.getElementById(hdn).value = ids[i];
            }
        }
        var ReqType = "<%=ReqType%>";
        function deleteAllInks() {
            if (ReqType == "edit" || ReqType == "add") {
                var values = "";
                ids = "";
                var HiddenIsBlankYes = "";
                var HiddenIsBlankNo = "";
                for (var i = 1; i <= len.value; i++) {
                    hdn = "hdn" + i;
                    var quotenew = new Array();
                    quotenew = document.getElementById("spn" + i + "").innerHTML.split('&');
                    var spnval = quotenew[0];
                    if (spnval != "") {
                        HiddenIsBlankNo = "No";
                    }
                    else {
                        HiddenIsBlankYes = "Yes";
                    }
                }
                if (val.value != "") {
                    if (rdn_Yield.checked) {
                        if (HiddenIsBlankNo == "No" && HiddenIsBlankYes == "Yes" || HiddenIsBlankNo == "No" && HiddenIsBlankYes != "Yes") {
                            if (window.confirm('Please Note:  If you change the ink costing type that is assigned to this press any inks allocated to the press that are not of this type will be removed.  Only one ink costing type can be assigned to the press, either Yield type or Matrix type.') == true) {
                                for (var i = 1; i <= len.value; i++) {
                                    var quote = new Array();
                                    quote = document.getElementById("spn" + i + "").innerHTML.split('&');
                                    var spnval = quote[0];
                                    if (spnval != "") {

                                        rdn_Matrix.checked = false;
                                        document.getElementById("spn" + i + "").innerHTML = "";

                                    }

                                }

                            }
                            else {
                                rdn_Yield.checked = false;
                                rdn_Matrix.checked = true;
                                return false;
                            }
                        }
                        else if (HiddenIsBlankNo != "No" && HiddenIsBlankYes == "Yes") {
                            rdn_Yield.checked = true;
                            rdn_Matrix.checked = false;
                        }
                    }
                    if (rdn_Matrix.checked) {
                        if (HiddenIsBlankNo == "No" && HiddenIsBlankYes == "Yes" || HiddenIsBlankNo == "No" && HiddenIsBlankYes != "Yes") {
                            if (window.confirm('Please Note:  If you change the ink costing type that is assigned to this press any inks allocated to the press that are not of this type will be removed.  Only one ink costing type can be assigned to the press, either Yield type or Matrix type.') == true) {
                                for (var i = 1; i <= len.value; i++) {
                                    var quote = new Array();
                                    quote = document.getElementById("spn" + i + "").innerHTML.split('&');
                                    var spnval = quote[0];
                                    if (spnval != "") {
                                        document.getElementById("spn" + i + "").innerHTML = "";
                                        rdn_Yield.checked = false;
                                    }


                                }
                            }
                            else {

                                rdn_Yield.checked = true;
                                rdn_Matrix.checked = false;
                                return false;
                            }
                        }
                        else if (HiddenIsBlankNo != "No" && HiddenIsBlankYes == "Yes") {
                            rdn_Yield.checked = false;
                            rdn_Matrix.checked = true;
                        }
                    }
                }
            }
        }
        function DeleteMoreInk() {
            var ctrl;
            ctrl = document.getElementById('divContent');
            if (CheckCount > 6) {
                if (navigator.appName == 'Microsoft Internet Explorer') {
                    if (CheckCount != 0) {
                        ctrl.removeChild(ctrl.lastChild); //new changes by swetha
                        CheckCount = CheckCount - 1;
                    }
                }
                else {
                    if (CheckCount != 0) {
                        ctrl.removeChild(ctrl.lastChild); //new changes by swetha                       
                        CheckCount = CheckCount - 1;
                    }
                }
            }
        }
        function getvalue() {

            var values = "";
            var ids = "";
            for (var i = 1; i <= len.value; i++) {
                var quote = new Array();
                quote = document.getElementById("spn" + i + "").innerHTML.split('&');
                var spnval = quote[0];
                if (spnval != "") {
                    values += spnval + "^";
                    ids += document.getElementById("hdn" + i + "").value + "^";
                }
            }
            val.value = values;
            ide.value = ids;
        }

        function YieldMatrixValue(val) {

            var YieldMatrix_Value = document.getElementById("<%=YieldMatrix_Value.ClientID%>");
            if (val == 'Y') {
                rdn_Matrix.checked = false;
                YieldMatrix_Value.value = 'Y';
                deleteAllInks();
            }
            else {

                rdn_Yield.checked = false;
                YieldMatrix_Value.value = 'M';
                deleteAllInks();
            }
        }
        function openpopup(spnid) {
            var InkType = rdn_Yield.checked;
            if (rdn_Yield.checked) {
                InkType = "Y";
            }
            else if (rdn_Matrix.checked) {
                InkType = "M";
            }

            window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Ink&InkType=" + InkType + "&id=" + spnid + "", '950', '450');
            window.Show();
        }

        function clear_ink(val, name) {
            var spn = val.replace('img', 'spn');

            if (window.confirm("Are you sure, you want to clear '" + name + "'?")) {
                document.getElementById(spn).innerHTML = "";
            }
        }
        selectInk();



        //******* funcn to check for litho press duplicacy *********////
        var IsDuplicate = false;
        function CheckLitho(val1) {
            if (val1 != '') {
                var compID = '<%=CompanyID %>';
                var id = '<%=id %>';
                var val = compID + "±" + val1 + "±" + "litho" + "±" + id;
                PageMethods.GetLitho(val, ShowMsgLitho, ShowMsg_Failure);
            }
        }
        function ShowMsg_Failure(error) { }
        function ShowMsgLitho(result) {
            $get('spn_txtPlantPressCheck').style.display = "none";
            if (result == -1) {
                $get('spn_txtPlantPressCheck').style.display = "block";
                IsDuplicate = true;
            }
            else {
                IsDuplicate = false;
            }
        }

        var chakWhat1 = true;
        function FinalSave() {

            chakWhat1 = true;
            var flag = false;
            var txtHourlyCharge = document.getElementById("<%=txtHourlyCharge.ClientID %>");
            var txtDefaultInk = document.getElementById("<%=txtDefaultInk.ClientID %>");

            if (txtHourlyCharge.value == "") {
                document.getElementById("spn_txtHourlyCharge").style.display = "block";
                chakWhat1 = false;
            }

            if (txtDefaultInk.value == "") {
                document.getElementById("spn_txtDefaultInk").style.display = "block";
                chakWhat1 = false;
            }

            var spn1 = document.getElementById("spn1").innerHTML;

            if (trim12(spn1) == '') {

                document.getElementById('spn_ink').style.display = "block";
                chakWhat1 = false;
            }
            if (txtHourlyCharge.value.length > 10) {
                alert("Press Hourly Charge Rate is too long");
                flag = true;
                chakWhat1 = false;
            }
            if (txtDefaultInk.value.length > 20 && flag == false) {
                alert("Default Ink Coverage value is too long");
                chakWhat1 = false;
            }

            if (chakWhat1) {
                getvalue();
                return true;
            }
            else {
                return false;
            }
        }

        function SendPaperIDandName(id, values) {
            values = trim12(values);
            var lblDefaultPaper = "<%=lblDefaultPaper.ClientID %>";
            document.getElementById(lblDefaultPaper).title = values;
            document.getElementById(lblDefaultPaper).innerHTML = values;
            document.getElementById(lblDefaultPaper).style.cursor = "pointer";
            hdnpaperID.value = id;
            document.getElementById("spn_lblDefaultPaper").style.display = "none";
        }
        function SendPlatesIDandName(id, values) {
            values = trim12(values);
            var lblDefaultPlates = "<%=lblDefaultPlates.ClientID %>";
            document.getElementById(lblDefaultPlates).title = SpecialDecode(values);
            document.getElementById(lblDefaultPlates).innerHTML = SpecialDecode(values);
            document.getElementById(lblDefaultPlates).style.cursor = "pointer";
            hdnplateID.value = id;
            document.getElementById("spn_lblDefaultPlates").style.display = "none";
        }
        function clearthis(id) {
            if (id == 'href_gsm') {
                document.getElementById("<%=txt_headergsm1.ClientID %>").value = "";
                document.getElementById("<%=txt_headergsm2.ClientID %>").value = "";
                document.getElementById("<%=txt_headergsm3.ClientID %>").value = "";
            }
            if (id == 'href_col1') {
                document.getElementById("<%=txt_headersh1.ClientID %>").value = "";
                document.getElementById("<%=txt_val11.ClientID %>").value = "";
                document.getElementById("<%=txt_val12.ClientID %>").value = "";
                document.getElementById("<%=txt_val13.ClientID %>").value = "";
            }
            if (id == 'href_col2') {
                document.getElementById("<%=txt_headersh2.ClientID %>").value = "";
                document.getElementById("<%=txt_val21.ClientID %>").value = "";
                document.getElementById("<%=txt_val22.ClientID %>").value = "";
                document.getElementById("<%=txt_val23.ClientID %>").value = "";
            }
            if (id == 'href_col3') {
                document.getElementById("<%=txt_headersh3.ClientID %>").value = "";
                document.getElementById("<%=txt_val31.ClientID %>").value = "";
                document.getElementById("<%=txt_val32.ClientID %>").value = "";
                document.getElementById("<%=txt_val33.ClientID %>").value = "";
            }
            if (id == 'href_col4') {
                document.getElementById("<%=txt_headersh4.ClientID %>").value = "";
                document.getElementById("<%=txt_val41.ClientID %>").value = "";
                document.getElementById("<%=txt_val42.ClientID %>").value = "";
                document.getElementById("<%=txt_val43.ClientID %>").value = "";
            }
            if (id == 'href_col5') {
                document.getElementById("<%=txt_headersh5.ClientID %>").value = "";
                document.getElementById("<%=txt_val51.ClientID %>").value = "";
                document.getElementById("<%=txt_val52.ClientID %>").value = "";
                document.getElementById("<%=txt_val53.ClientID %>").value = "";
            }
        }


        function LithoAmountTo2Decimal(obj, val) {
            if (val != '') {
                if (val.substring(1, 0) != "-")//for NEGATIVE Values
                {
                    if (!isNaN(val)) {
                        obj.value = roundNumber(val, 2);
                        return true;
                    }
                    else {
                        obj.value = '';
                        obj.focus();
                        return false;
                    }
                }
                else {
                    obj.value = '';
                    obj.focus();
                    return false;
                }
            }
        }

        function GuillotineSelect() {
            window.radopen(strSitepath + "common/common_popup.aspx?type=moreplant&pg=estimate", '800', '400');
            window.Show();
        }
        function RadWinClose() {

            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }

        function SendGuillotineIDandName(id, values) {

            values = trim12(values);
            var lblGuillotine = "<%=lblGuillotine.ClientID %>";
            document.getElementById(lblGuillotine).title = SpecialDecode(values);
            document.getElementById(lblGuillotine).innerHTML = SpecialDecode(values);
            document.getElementById(lblGuillotine).style.cursor = "default";
            hid_GuillotineID.value = id;
            document.getElementById("spn_ddlGuillotine").style.display = "none";
        }
        function Show() {
            if (document.getElementById("divrad").style.display == "none") {
                var divrad = document.getElementById("divrad");
                if (navigator.appName != "Microsoft Internet Explorer") {       // IE, on 26.09.2011
                    setLoadingPositionOfDivMove(divrad);
                    showDivPopupCenter('divrad', '200');
                }
            }
            else {
                document.getElementById("divrad").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
            }
        }
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/item/litho.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
