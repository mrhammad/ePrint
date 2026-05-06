<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="digital_press_add.aspx.cs" Inherits="ePrint.settings.digital_press_add" title="Settings: Digital Press" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <style type="text/css">
            
        </style>
    </telerik:RadCodeBlock>
    <div id="ds00" style="display: block;">
    </div>
    <div id="div_Load" class="loading_new">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";

        var commonpath = "<%=nmsCommon.global.sitePath()%>";

        function MoreStock1(stocktype) {
            if (stocktype == 'paper') {
                window.radopen(commonpath + "common/common_popup.aspx?type=invselector&pg=setting&item=Paper", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
                window.Show();
            }
            else if (stocktype == 'film') {
                window.radopen(commonpath + "common/common_popup.aspx?type=morefilm&pg=setting", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
                window.Show();
            }
            else if (stocktype == 'plates') {
                window.radopen(commonpath + "common/common_popup.aspx?type=moreplate&pg=setting", '', 'width=950px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
                window.Show();

            }

            return false;
        }


    </script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
    </script>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text="Settings: Digital Press - Press,Paper & Plant Properties"><%=objLanguage.GetLanguageConversion("Digital_Press_Press_Paper_And_Plant_Properties")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnBlack" runat="server" />
        <asp:HiddenField ID="hdnColor" runat="server" />
        <asp:HiddenField ID="hdn_ClickChargeZoneLookupBlack" runat="server" />
        <asp:HiddenField ID="hdn_ClickChargeZoneLookupColour" runat="server" />
        <asp:HiddenField ID="hdnTotalrowscount" Value="0" runat="server" />
        <asp:HiddenField ID="hdnItemscount" Value="0" runat="server" />
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div class="mis_header_panel" style="padding-top: 6px;">
                <div align="left" id="DIV_TAKE" style="width: 100%;" runat="server">
                    <div id="div_Feed_restriction" style="display: block;">
                        <div style="padding: 5px 0px 0px 0px">
                            <div style="float: left; width: 100%;">
                                <div align="left" style="float: left; width: 49%;">
                                    <div align="left" style="width: 590px;">
                                        <div class="bglabel">
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("Name")%></span><span style="color: Red"> *</span>
                                        </div>
                                        <div class="box">
                                            <div style="width: 175.5px">
                                                <asp:TextBox ID="txtDigitalPressName" onblur="CheckDigitalPress(this.value);CallonBlur(this.value,'spn_txtDigitalPressName');"
                                                    runat="server" SkinID="textPad" TabIndex="1" MaxLength="100" CssClass="textboxnew1"> </asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtDigitalPressName" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Press_Name")%>
                                                    </span>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtPlantPressCheck" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                        <%=objLanguage.GetLanguageConversion("Press_Name_Already_Exists")%></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="height: 84px;">
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Description")%></span>
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
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Set_Default_Press")%></span>
                                            </div>
                                            <div class="box">
                                                <asp:CheckBox ID="chkDefaultPress" runat="server" TabIndex="3" />
                                            </div>
                                        </div>
                                        <div align="left" runat="server" id="div_AccountCode">
                                            <div class="bglabel">
                                                <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Accounting_Code")%></asp:Label>
                                            </div>
                                            <div class="ddlsetting" style="padding-left: 5px">
                                                <asp:DropDownList ID="ddlAccountCode" runat="server" Width="150px">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div style="clear: both; height: 5px">
                                            &nbsp;
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="height: 33px;">
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Maximum_Sheet_Size")%></span><span style="color: Red">
                                                        *</span>
                                            </div>
                                            <div class="box" nowrap="nowrap">
                                                <div align="left">
                                                    <div style="float: left; padding-top: 2px; width: 40px">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Height")%></span>
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtMaxImgHeight" runat="server" Width="50px" SkinID="textPad" Style="padding-left: 0px; text-align: right; margin-left: 0px"
                                                            onblur="CallonBlur(this.value,'spn_MaximumImageArea');todecimal_function(this,this.value);"
                                                            TabIndex="4" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblMaxImgHeight" runat="server"
                                                                CssClass="normalText">mm</asp:Label>
                                                    </div>
                                                </div>
                                                <div style="clear: left; padding-top: 1px;">
                                                    <div style="float: left; width: 40px">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Width")%></span>&nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtMaxImgWidth" runat="server" Width="50px" SkinID="textPad" Style="padding-left: 0px; text-align: right; margin-left: 0px"
                                                            onblur="CallonBlur(this.value,'spn_MaximumImageArea');todecimal_function(this,this.value);"
                                                            TabIndex="5" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblMaxImgWidth" runat="server"
                                                                CssClass="normalText">mm</asp:Label>&nbsp;
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MaximumImageArea" style="display: none; width: auto; float: left">
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Max_Sheet_Size")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MaximumImageArea_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="Label17" runat="server" Text="Maximum Sheet Weight" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Maximum_Sheet_Weight") %></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box">
                                                <div style="float: left; width: 40px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <asp:TextBox ID="txtMaxSheetWeight" runat="server" Width="50px" SkinID="textPad"
                                                        Style="padding-left: 0px; margin-left: 0px; text-align: right; float: left" onblur="CallonBlur(this.value,'spn_txtMaxSheetWeight');todecimal_function(this,this.value);"
                                                        TabIndex="6" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblMaxSheetWeight"
                                                            runat="server" CssClass="normalText"><%=paperWeight %></asp:Label>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtMaxSheetWeight" style="display: none; width: auto; float: left">
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                            <%-- <%=objlang.GetValueOnLang("Please enter Max. Sheet Weight")%>--%>
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Max_Sheet_Weight")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtMaxSheetWeight_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="header">
                                            <span class="HeaderText">
                                                <%=objLanguage.GetLanguageConversion("Press_Restrictions")%></span>
                                        </div>
                                        <div align="left" style="display: none">
                                            <div class="bglabel">
                                                <span class="normalText">
                                                    <%=objlang.GetValueOnLang("Grip Depth")%></span><span style="color: Red">*</span>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtGripDepth" runat="server" Width="50px" SkinID="textPad" Style="padding-left: 0px; margin-left: 0px"
                                                    onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtGripDepth');IsIntegerParameter(this.value,'spn_txtGripDepth_number');"></asp:TextBox>&nbsp;
                                                <span class="normalText">mm</span><span id="spn_txtGripDepth" class="spanerrorMsg"
                                                    style="display: none; width: 185px;">
                                                    <%=objlang.GetValueOnLang("Please enter Grip Depth")%></span><span id="spn_txtGripDepth_number"
                                                        class="spanerrorMsg" style="display: none; width: 185px;">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="height: 33px;">
                                                <span class="normalText"></span>
                                                <%=objLanguage.GetLanguageConversion("Non_Print_Image_Side_Area")%>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <%--Gutter Depth--%>
                                            <div class="box" nowrap="nowrap">
                                                <div align="left">
                                                    <div style="float: left; padding-top: 1px; width: 40px;">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Height")%></span>&nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtGutterDepthHeight" runat="server" Width="50px" SkinID="textPad"
                                                            Style="padding-left: 0px; text-align: right; margin-left: 0px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_GutterDepth');"
                                                            TabIndex="7" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblPrintHeight" runat="server"
                                                                CssClass="normalText">mm</asp:Label>
                                                    </div>
                                                </div>
                                                <div align="left" style="clear: left; padding-top: 1px;">
                                                    <div style="float: left; width: 40px;">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Width")%></span>&nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtGutterDepthWidtht" runat="server" Width="50px" SkinID="textPad"
                                                            Style="padding-left: 0px; text-align: right; margin-left: 0px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_GutterDepth');"
                                                            TabIndex="8" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblPrintWidth" runat="server"
                                                                CssClass="normalText">mm</asp:Label>&nbsp;
                                                    </div>
                                                    <%--IsIntegerParameter(this.value,'spn_GutterDepth_number');--%>
                                                </div>
                                                <div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_GutterDepth" style="display: none; width: auto; float: left">
                                                        <div>
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Image_Side_Area")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_GutterDepth_number" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="height: 33px;">
                                                <span class="normalText"></span>
                                                <%=objLanguage.GetLanguageConversion("Default_Gutters")%>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" nowrap="nowrap">
                                                <div align="left">
                                                    <div style="float: left; padding-top: 1px; width: 42px;">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Horizontal")%></span>&nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtGutterHorizontal" runat="server" Width="50px" SkinID="textPad"
                                                            Style="padding-left: 0px; text-align: right; margin-left: 0px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_DefaultGutters');"
                                                            TabIndex="9" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblGutterHor" runat="server"
                                                                CssClass="normalText">mm</asp:Label>
                                                    </div>
                                                </div>
                                                <div align="left" style="clear: left; padding-top: 1px;">
                                                    <div style="float: left; width: 42px;">
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Vertical")%></span>&nbsp;
                                                    </div>
                                                    <div style="float: left;">
                                                        <asp:TextBox ID="txtGutterVertical" runat="server" Width="50px" SkinID="textPad"
                                                            Style="padding-left: 0px; text-align: right; margin-left: 0px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_DefaultGutters');"
                                                            TabIndex="10" MaxLength="12"></asp:TextBox>&nbsp;<asp:Label ID="lblGutterVer" runat="server"
                                                                CssClass="normalText">mm</asp:Label>&nbsp;
                                                    </div>
                                                </div>
                                                <div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_DefaultGutters" style="display: none; width: auto; float: left">
                                                        <div>
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Default_Gutters")%></span>
                                                        </div>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                    <div id="spn_DefaultGuttersNumber" style="display: none; width: auto; float: left">
                                                        <div class="RFV_Message">
                                                            <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="clear: both; height: 5px">
                                            &nbsp;
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("SetUp_Spoilage_Number_Of_Sheets")%></span><span
                                                        style="color: Red"> *</span>
                                            </div>
                                            <div class="box">
                                                <div style="width: 175.5px">
                                                    <asp:TextBox ID="txtSpoilageSheets" Style="text-align: right" runat="server" SkinID="textPad"
                                                        onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtSpoilageSheets');"
                                                        TabIndex="11" MaxLength="12" CssClass="textboxnew1"></asp:TextBox>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtSpoilageSheets" style="display: none; width: auto; float: left">
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Spoilage_Sheets")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtSpoilageSheets_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" nowrap="nowrap">
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Running_Spoilage")%>
                                                    (%)<span style="color: Red"> *</span></span>
                                            </div>
                                            <div class="box">
                                                <div style="width: 175.5px">
                                                    <asp:TextBox ID="txtRunningSpoilage" Style="text-align: right" runat="server" SkinID="textPad"
                                                        onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtRunningSpoilage');"
                                                        TabIndex="12" MaxLength="12" CssClass="textboxnew1"></asp:TextBox>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtRunningSpoilage" style="display: none; width: auto; float: left">
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Running_Spoilage")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtRunningSpoilage_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                    </div>
                                </div>
                                <div style="float: left; width: 49%;">
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <div style="float: left">
                                                <asp:Label ID="Label25" runat="server" Text="Default Paper" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Default_Stock")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton ID="imgbtnDefaultPaper" runat="server" ImageUrl="~/images/plus.gif"
                                                    OnClientClick="javascript:return MoreStock1('paper');" TabIndex="13" />
                                            </div>
                                        </div>
                                        <div class="box" style="padding-top: 4px;">
                                            <asp:Label ID="lblDefaultPaper" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                                            <asp:HiddenField ID="hdnpaperID" runat="server" Value="0" />
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <asp:Label ID="Label4" runat="server" Text="Default Print Sheet Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Print_Sheet_Size")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddlsetting" style="padding-left: 3px">
                                            <asp:DropDownList ID="ddlPrintSheetSize" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                                                Width="183px" TabIndex="14">
                                            </asp:DropDownList>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <asp:Label ID="Label5" runat="server" Text="Default Job Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Job_Size")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddlsetting" style="padding-left: 3px">
                                            <asp:DropDownList ID="ddlJobSize" runat="server" CssClass="normalText" Width="183px"
                                                onchange="CallonChange(this.value,'spn_ddlJobSize')" TabIndex="15">
                                            </asp:DropDownList>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_ddlJobSize" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Job_Size")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <asp:Label ID="Label6" runat="server" Text="Default Guillotine" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Guillotine")%></asp:Label>
                                        </div>
                                        <div class="ddlsetting" style="padding-left: 3px">
                                            <asp:DropDownList ID="ddlGuillotine" runat="server" CssClass="normalText" TabIndex="16"
                                                Width="183px">
                                            </asp:DropDownList>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_ddlGuillotine" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please select Guillotine")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="header">
                                        <span class="HeaderText">
                                            <%=objLanguage.GetLanguageConversion("Plant_Charges")%></span>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <asp:Label ID="Label19" runat="server" Text="Set up Charge ($)" CssClass="normaltext"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <div style="width: 175.5px">
                                                <asp:TextBox ID="txtSetupCharge" runat="server" SkinID="textPad" onblur="todecimal_function(this,this.value);"
                                                    Style="text-align: right;" TabIndex="17" MaxLength="20" CssClass="textboxnew1"></asp:TextBox><%--onblur="AmountTo2Decimal(this,this.value);" --%>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtSetupCharge_number" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 200px;">
                                            <asp:Label ID="Label20" runat="server" Text="Minimum Running Charge ($)" CssClass="normaltext"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <div style="width: 175.5px">
                                                <asp:TextBox ID="txtMinRunningCharge" runat="server" onblur="todecimal_function(this,this.value);"
                                                    SkinID="textPad" Style="text-align: right" TabIndex="18" MaxLength="20" CssClass="textboxnew1"></asp:TextBox><%--onblur="AmountTo2Decimal(this,this.value);"--%>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtMinRunningCharge_number" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="div_UnitOfMeasure" runat="server" class="onlyEmpty" style="display: none">
                                        <div class="bglabel" style="width: 200px;">
                                            <%=objLanguage.GetLanguageConversion("Unit_Of_Measure")%>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <asp:TextBox ID="txtUnitOfMeasure" runat="server" SkinID="textPad" TabIndex="20"
                                                Width="80px" MaxLength="8" onblur="SetNumber_OfUnit(this,this.value);" onkeyup="ToInteger(this,this.value);"
                                                Style="text-align: right" Text="1000"></asp:TextBox>
                                            <span id="spn_UnitOfMeasure" class="spanerrorMsg" style="display: none; width: 150px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Integer_Value")%>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div align="left" style="width: 100%">
                                <div class="onlyEmpty">
                                </div>
                                <br />
                                <div align="left" class="box" style="width: 49%;">
                                </div>
                                <div align="left" class="box" style="width: 200px;">
                                </div>
                                <div class="box" style="width: 20%;">

                                    <div style="float: left">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                OnClick="btnDelete_OnClick" OnClientClick="javascript:var a= window.confirm('Are you sure, you want to delete this press?');if(a)loadingimage(this.id,'div_btndeleteprocess');return a;"
                                                TabIndex="21" />
                                        </div>
                                        <div id="div_btndeleteprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <%--<div style="float: left;">
                                        <div id="div_Button1" style="display: block">
                                            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Cancel" TabIndex="20"
                                                OnClick="Button1_OnClick" />
                                        </div>
                                        <div id="div_Button1process" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>--%>
                                    <div id="divDelete" style="float: left; width: 10px" runat="server">
                                        &nbsp;
                                    </div>

                                    <div style="float: left;">
                                        <div id="div_Button1" style="display: block">
                                            <asp:Button ID="Button1" CssClass="button" runat="server" Text="Cancel" TabIndex="20"
                                                OnClick="Button1_OnClick" />
                                        </div>
                                        <div id="div_Button1process" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>

                                    <%--<div style="float: left">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" Visible="false"
                                                OnClick="btnDelete_OnClick" OnClientClick="javascript:var a= window.confirm('Are you sure, you want to delete this press?');if(a)loadingimage(this.id,'div_btndeleteprocess');return a;"
                                                TabIndex="21" />
                                        </div>
                                        <div id="div_btndeleteprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>--%>
                                    <div style="float: left; padding-left: 10px;">
                                        <asp:Button ID="Button2" CssClass="button" runat="server" Text="Next" OnClientClick="javascript:DigiNext();return false;"
                                            TabIndex="22" />
                                    </div>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_Plant_Calculation" align="left" style="display: none; padding: 5px 0px 0px 0px">
                    <div align="left" style="width: 99%;">
                        <div style="float: left; width: 100%;">
                            <div class="bglabel" style="width: 30%">
                                <span class="headertext">
                                    <%=objLanguage.GetLanguageConversion("Calculation_Method")%>
                                </span>
                            </div>
                            <div class="box" style="float: left; width: 30%;">
                                <asp:DropDownList ID="ddlMethod" runat="server" CssClass="normalText" onchange="javascript:ShowOnCalculation(this);CallonChange(ddlMethod.value,'spn_ddlMethod');">
                                    <asp:ListItem>--- Select ---</asp:ListItem>
                                    <asp:ListItem Value="clickchargelookup">ClickCharge Lookup</asp:ListItem>
                                    <asp:ListItem Value="speedweightlookup">SpeedWeight Lookup</asp:ListItem>
                                    <asp:ListItem Value="clickchargezonelookup">ClickChargeZones Lookup</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hid_ddlMethodSelected" Value="" runat="server" />
                                <span id="spn_ddlMethod" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                    <%=objlang.GetValueOnLang("Please select Calculation Method")%>
                                </span>
                            </div>
                        </div>
                        <div id="div_ClickChargeLookup" style="width: 100%; display: block;">
                            <div align="left">
                                <div class="bglabel" style="width: 30%">
                                    <asp:Label ID="Label23" runat="server" Text="Rate for Black & White Chargeable Sheets ($)"
                                        CssClass="normaltext"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtBlackChargeableSheets" runat="server" Width="100px" SkinID="textPad"
                                            Style="text-align: right;" onblur="todecimal_functionForThreeDecimalplace(this,this.value);CallonBlur(this.value,'spn_txtBlackChargeableSheets');IsDecimalValue(this.value,'spn_txtBlackChargeableSheets_number');"
                                            MaxLength="20"></asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                    </div>
                                    <div style="float: left; margin-left: 2px">
                                        <span id="spn_txtBlackChargeableSheets" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Chargeable_Sheets")%>
                                        </span><span id="spn_txtBlackChargeableSheets_number" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%>
                                        </span>
                                    </div>
                                </div>
                                <div class="bglabel" style="width: 30%">
                                    <asp:Label ID="Label2" runat="server" Text="Rate for Colour Chargeable Sheets ($)"
                                        CssClass="normaltext"></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtColourChargeableSheets" runat="server" Width="100px" SkinID="textPad"
                                            Style="text-align: right;" onblur="todecimal_functionForThreeDecimalplace(this,this.value);CallonBlur(this.value,'spn_txtColourChargeableSheets');IsDecimalValue(this.value,'spn_txtColourChargeableSheets_number');"
                                            MaxLength="20"></asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                    </div>
                                    <div style="float: left; margin-left: 2px">
                                        <span id="spn_txtColourChargeableSheets" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Chargeable_Sheets")%>
                                        </span><span id="spn_txtColourChargeableSheets_number" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                    </div>
                                </div>
                                <div class="bglabel" style="width: 30%">
                                    <asp:Label ID="Label22" runat="server" Text="Mark Up (%)" CssClass="normaltext"></asp:Label>
                                </div>
                                <div class="box" style="float: left; width: 30%;">
                                    <div style="width: 175.5px">
                                        <asp:TextBox ID="txtMarkUp" onblur="todecimal_function(this,this.value);" runat="server"
                                            Width="100px" SkinID="textPad" Style="text-align: right" TabIndex="19" MaxLength="20"
                                            CssClass="textboxnew1"></asp:TextBox><%-- onblur="AmountTo2Decimal(this,this.value);"--%>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <div id="spn_txtMarkUp_number" style="display: none; width: 180px; float: left">
                                        <div class="RFV_Message">
                                            <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="bglabel" style="width: 30%">
                                    <asp:Label ID="Label3" runat="server" Text="Number of Chargeable Sheets" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Number_Of_Chargeable_Sheets")%></asp:Label>
                                    <span style="color: Red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtNoChargeableSheets" runat="server" Width="100px" SkinID="textPad"
                                            Style="text-align: right;" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtNoChargeableSheets');IsDecimalValue(this.value,'spn_txtNoChargeableSheets_number');"
                                            MaxLength="8"></asp:TextBox>
                                    </div>
                                    <div style="float: left; margin-left: 2px" nowrap="nowrap">
                                        <span id="spn_txtNoChargeableSheets" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px; white-space: nowrap">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_No_Of_Chargeable_Sheets")%></span><span
                                                id="spn_txtNoChargeableSheets_number" class="spanerrorMsg" style="display: none; padding-left: 4px; width: auto; padding-right: 4px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div id="div_SpeedWeightLookup" style="width: 100%; display: none;">
                            <div style="float: left; width: 100%;">
                                <div class="bglabel" style="width: 30%">
                                    <span>
                                        <%=objLanguage.GetLanguageConversion("Press_Hourly_Charge_Rate")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</span><span
                                            style="color: Red"> *</span>
                                </div>
                                <div class="box" style="width: 8%;">
                                    <asp:TextBox ID="txtHourlyCharge" Style="text-align: right" runat="server" Width="60px"
                                        SkinID="textPad" onblur="todecimal_function(this,this.value);CheckDecimalPlus(this.value,'spn_txtHourlyCharge','spn_txtHourlyCharge_number','no');"
                                        MaxLength="20"></asp:TextBox><%--AmountTo2Decimal(this,this.value);--%>
                                </div>
                                <div style="float: left;">
                                    <span id="spn_txtHourlyCharge" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Hourly_Charge_Rate")%>
                                    </span><span id="spn_txtHourlyCharge_number" class="spanerrorMsg" style="display: none; width: 175px;">
                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                </div>
                            </div>
                            <div class="bglabel" style="width: 30%">
                                <asp:Label ID="Label1" runat="server" Text="Mark Up (%)" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box" style="float: left; width: 30%;">
                                <div style="width: 175.5px">
                                    <asp:TextBox ID="txtspeedMarkup" onblur="todecimal_function(this,this.value);" runat="server"
                                        Width="60px" SkinID="textPad" Style="text-align: right" TabIndex="19" MaxLength="20"
                                        CssClass="textboxnew1"></asp:TextBox><%-- onblur="AmountTo2Decimal(this,this.value);"--%>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="spn_txtspeedMarkup" style="display: none; width: 180px; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both">
                                &nbsp;
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; width: 45%; border-right: 2px solid silver; margin-left: 1%;">
                                    <div style="float: left; width: 100%;">
                                        <span class="HeaderText">
                                            <%=objLanguage.GetLanguageConversion("Black_White")%></span>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 95%;">
                                        <div align="left" style="width: 100%;">
                                            <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                                                <col width="50%" />
                                                <col width="50%" />
                                                <tr class="label">
                                                    <td>
                                                        <span class="HeaderText">
                                                            <%=paperWeight %></span>
                                                    </td>
                                                    <td>
                                                        <span class="HeaderText">
                                                            <%=objLanguage.GetLanguageConversion("Pages_Per_Minute")%></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackGSM1" runat="server" SkinID="textPad" Width="75px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtBlackGSM1');"
                                                            MaxLength="12" Style="text-align: right; float: left"></asp:TextBox>
                                                        <span id="spn_txtBlackGSM1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_GSM_Value")%>
                                                        </span><span id="spn_txtBlackGSM1_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackPagesPerMinute1" runat="server" SkinID="textPad" Width="75px"
                                                            onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtBlackPagesPerMinute1');"
                                                            MaxLength="12" Style="text-align: right; float: left"></asp:TextBox>
                                                        <span id="spn_txtBlackPagesPerMinute1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Pages_Per_Min")%></span><span
                                                                id="spn_txtBlackPagesPerMinute1_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackGSM2" runat="server" SkinID="textPad" Width="75px" MaxLength="12"
                                                            Style="text-align: right; float: left" onblur="todecimal_function(this,this.value);"></asp:TextBox>
                                                        <span id="spn_txtBlackGSM2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackPagesPerMinute2" runat="server" SkinID="textPad" Width="75px"
                                                            Style="text-align: right" MaxLength="12" onblur="todecimal_function(this,this.value);IsDecimalValue(this.value,'spn_txtBlackPagesPerMinute2_number');"></asp:TextBox>
                                                        <span id="spn_txtBlackPagesPerMinute2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackGSM3" runat="server" SkinID="textPad" Style="text-align: right; float: left"
                                                            Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);"></asp:TextBox>
                                                        <span id="spn_txtBlackGSM3_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBlackPagesPerMinute3" runat="server" SkinID="textPad" Style="text-align: right"
                                                            Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);"></asp:TextBox>
                                                        <span id="spn_txtBlackPagesPerMinute3_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div style="float: left; width: 45%; border-left: 0px solid silver; margin-left: 2%">
                                    <div style="float: left; width: 100%;">
                                        <span class="HeaderText">
                                            <%=objpage.GetRegionalSettings(CompanyID, "Colour")%></span>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 95%;">
                                        <div align="left" style="width: 100%;">
                                            <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                                                <col width="50%" />
                                                <col width="50%" />
                                                <tr class="label">
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server" CssClass="HeaderText"><%=paperWeight %></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label31" runat="server" Text="Pages per Minute" CssClass="HeaderText"><%=objLanguage.GetLanguageConversion("Pages_Per_Minute")%></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtColorGSM1" runat="server" SkinID="textPad" Width="75px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtColorGSM1');"
                                                            MaxLength="12" Style="text-align: right; float: left"></asp:TextBox>
                                                        <span id="spn_txtColorGSM1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_GSM_Value")%></span><span id="spn_txtColorGSM1_number"
                                                                class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtColorPagesPerMinute1" runat="server" SkinID="textPad" Style="text-align: right; float: left"
                                                            Width="75px" onblur="todecimal_function(this,this.value);CallonBlur(this.value,'spn_txtColorPagesPerMinute1');"
                                                            MaxLength="12"></asp:TextBox>
                                                        <span id="spn_txtColorPagesPerMinute1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Pages_Per_Min")%></span><span
                                                                id="spn_txtColorPagesPerMinute1_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtColorGSM2" Style="text-align: right; float: left" runat="server"
                                                            SkinID="textPad" Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);"></asp:TextBox>
                                                        <span id="spn_txtColorGSM2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtColorPagesPerMinute2" Style="text-align: right" runat="server"
                                                            SkinID="textPad" Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);IsDecimalValue(this.value,'spn_txtColorPagesPerMinute2_number');"></asp:TextBox>
                                                        <span id="spn_txtColorPagesPerMinute2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtColorGSM3" Style="text-align: right" runat="server" SkinID="textPad"
                                                            Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);IsDecimalValue(this.value,'spn_txtColorGSM3_number');"></asp:TextBox>
                                                        <span id="spn_txtColorGSM3_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtColorPagesPerMinute3" Style="text-align: right" runat="server"
                                                            SkinID="textPad" Width="75px" MaxLength="12" onblur="todecimal_function(this,this.value);IsDecimalValue(this.value,'spn_txtColorPagesPerMinute3_number');"></asp:TextBox>
                                                        <span id="spn_txtColorPagesPerMinute3_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="only10px">
                                </div>
                                <div align="left">
                                    <div style="padding-left: 10px;">
                                        <span class="normaltext">(<%=objLanguage.GetLanguageConversion("Note_Digital_Press_Add")%>)
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="div_ClickZonesLookup" align="left" style="width: 100%; display: none;">
                            <div class="onlyEmpty">
                                <div class="bglabel" style="width: 30%">
                                    <span class="headertext">
                                        <%=objLanguage.GetLanguageConversion("Activate_The_Zone_Buildup_Calculation_Method")%></span>
                                </div>
                                <div class="box" style="float: left; width: 30%;">
                                    <asp:CheckBox ID="chkCalculationType" runat="server" />
                                </div>
                            </div>
                            <div style="float: left; width: 100%">
                                <div style="float: left; width: 49%">
                                    <span class="HeaderText">&nbsp;<%=objLanguage.GetLanguageConversion("Black_White")%></span>
                                </div>
                                <div style="float: left; width: 49%; padding-left: 15px">
                                    <span class="HeaderText">
                                        <%=objpage.GetRegionalSettings(CompanyID, "Colour")%></span>
                                </div>
                            </div>
                            <div id="div0" style="float: left; width: 100%">
                                <div id="div_tempborder" style="float: left; border-right: 2px solid Silver; width: 49%">
                                    <div align="center" style="width: 100%; vertical-align: top">
                                        <div style="float: left; width: 10%">
                                            <span>&nbsp;</span>
                                        </div>
                                        <div align="center" style="float: left; width: 27%; border: 0px solid red; padding-left: 2px">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Click_Charge_Zone")%>
                                            </span>
                                        </div>
                                        <div align="center" style="float: left; width: 13%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Chargeable_Sheets")%></span>
                                        </div>
                                        <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Cost")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</span>
                                        </div>
                                        <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Markup")%>&nbsp(%) </span>
                                        </div>
                                        <div align="center" style="width: 13%; float: left; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Chargeable_Rates")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</span>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <div id="div_left" align="left" style="float: left; width: 100%; vertical-align: top; padding-top: 4px; border: 0px solid red;">
                                        <asp:PlaceHolder ID="plhBlackZone" runat="server"></asp:PlaceHolder>
                                        <span id="spnGetID" runat="server"></span>
                                        <script language="javascript" type="text/javascript">
                                            var GetID = (document.getElementById("<%=spnGetID.ClientID %>").id).replace("spnGetID", "");
                                            var CheckZone = true;
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
                                                            //if (ROW == 7) {  
                                                            //    document.getElementById(LabelFrom + "8").innerHTML = "";
                                                            //    document.getElementById(LabelFrom + "8").innerHTML = Number(txtValue) + Number(1);
                                                            //    document.getElementById(LabelFrom + "8").innerHTML = "+" + document.getElementById(LabelFrom + "8").innerHTML;
                                                            //    document.getElementById(txtFrom + "8").value = Number(txtValue) + Number(1);
                                                            //}
                                                        }
                                                    }
                                                }
                                            }
                                            function CheckingZones() {
                                                CheckZone = false;
                                            }
                                        </script>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <div>
                                        <a id="href_add_more" name="addmore" style="display: block; float: left" href='#addmore' onclick="Click_Add_More()">Add More Rows</a>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div align="left" style="display: none;">
                                        <asp:CheckBox ID="chkBlackFlattenClick" runat="server" Text="Check this box to flatten the click charge b/w click zones" />
                                    </div>
                                    <div align="left" style="display: none;">
                                        <asp:CheckBox ID="chkBlackSumClick" runat="server" Text="Check this box to sum the click charge rate b/w click zones" />
                                    </div>
                                    <div align="left" style="border: 0px solid">
                                        <img id="Img1" src="../images/copy.gif" runat="server" onclick="javascript:ApplyToClor(this);"
                                            style="vertical-align: bottom; cursor: pointer" title="Copy" />
                                        <a onclick="javascript:ApplyToClor(this);" style="cursor: pointer">
                                            <%=objLanguage.GetLanguageConversion("Copy_Black_And_White_Settings_To") + " " + objpage.GetRegionalSettings(CompanyID, "Colour")%></a>
                                    </div>
                                </div>
                                <div id="div1" style="float: left; border-left: 0px solid Silver; width: 49%">
                                    <div align="center" style="width: 100%; vertical-align: top">
                                        <div style="float: left; width: 10%">
                                            <span>&nbsp;</span>
                                        </div>
                                        <div align="center" style="float: left; width: 27%; border: 0px solid red; padding-left: 2px">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Click_Charge_Zone")%>
                                            </span>
                                        </div>
                                        <div align="center" style="float: left; width: 13%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Chargeable_Sheets")%></span>
                                        </div>
                                        <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Cost")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</span>
                                        </div>
                                        <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Markup")%>&nbsp(%)</span>
                                        </div>
                                        <div align="center" style="width: 13%; float: left; border: 0px solid red">
                                            <span>
                                                <%=objLanguage.GetLanguageConversion("Chargeable_Rates")%>(<%=objcom.GetCurrencyinRequiredFormate("", true)%>)</span>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                    <div align="left" id="div_right" style="float: left; width: 100%; vertical-align: top; padding-top: 4px; border: 0px solid red;">
                                        <asp:PlaceHolder ID="plhColorZone" runat="server"></asp:PlaceHolder>
                                        <div style="width: 100%; height: 19px; display: none;">
                                            <div style="width: 4%; float: left;">
                                                <asp:CheckBox ID="chkColorFlattenClick" runat="server" />
                                            </div>
                                            <div style="width: 90%; float: left; height: 16px;" class="spntxtalign">
                                                <span id="spnchkbox_FlattenClick" onclick="javascript:spnchkbox_FlattenClick_OnClick()"
                                                    style="cursor: default">
                                                    <%=objlang.GetValueOnLang("Check this box to flatten the click charge b/w click zones")%></span>
                                            </div>
                                        </div>
                                        <div style="width: 100%; height: 19px; display: none;">
                                            <div style="width: 4%; float: left;">
                                                <asp:CheckBox ID="chkColorSumClick" runat="server" />
                                            </div>
                                            <div style="width: 90%; float: left; height: 17px;" class="spntxtalign">
                                                <span id="spnchkbox_SumClick" onclick="javascript:spnchkbox_SumClick_OnClick()" style="cursor: default">
                                                    <%=objlang.GetValueOnLang("Check this box to sum the click charge rate b/w click zones")%></span>
                                            </div>
                                        </div>
                                        <div class="only10px" style="padding-top: 0px">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div align="left" style="width: 100%;">
                        <div class="only10px">
                        </div>
                        <div style="float: left; width: 30%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 49%;">
                            <div class="box" style="margin-left: 33px;">
                                <div style="float: left;">
                                    <asp:Button CssClass="button" Style="padding-top: 4px;" ID="Button20" runat="server" Text="Previous" OnClientClick="DigiPrevious();return false;"></asp:Button>
                                </div>
                                <div style="float: left; width: 10px;">
                                    &nbsp;
                                </div>
                                <div style="float: left">
                                    <div id="div_btnsave" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="Button22"
                                            runat="server" Text="Save" OnClick="btnDigitalAdd_OnClick">
                                        </telerik:RadButton>
                                    </div>
                                    <div id="div_btnsaveprocess" class="button" align="center" style="width: 33px; height: 14px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only10px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
            Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <div style="clear: both; width: 775px">
        &nbsp;
    </div>
    <asp:Panel ID="pnlddlMethod" runat="server" Visible="false">
        <script>
            var MethodSelected = document.getElementById("<%=hid_ddlMethodSelected.ClientID %>").value;
            if (MethodSelected == "ClickChargeLookup") {
                document.getElementById("div_ClickChargeLookup").style.display = "block";
            }
            else if (MethodSelected == "SpeedWeightLookup") {
                document.getElementById("div_SpeedWeightLookup").style.display = "block";
                document.getElementById("div_ClickChargeLookup").style.display = "none";
            }
            else if (MethodSelected == "ClickChargeZoneLookup") {
                document.getElementById("div_ClickZonesLookup").style.display = "block";
                document.getElementById("div_SpeedWeightLookup").style.display = "none";
                document.getElementById("div_ClickChargeLookup").style.display = "none";
            }
            document.getElementById("<%=ddlMethod.ClientID %>").disabled = true;
                
        </script>
    </asp:Panel>
    <asp:HiddenField ID="hid_MethodID" Value="0" runat="server" />
    <script src="<%=strSitepath %>js/item/settingsjs.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        //This is a function for description size limit

        var txtDescription = document.getElementById("<%=txtDescription.ClientID %>");
        checkDescription();

        //This is a function call for default paper
        var lblDefaultPaper = "<%=lblDefaultPaper.ClientID %>";
        viewPaper();

        //This Function name is used in the warehouse/inventory_item_selector.ascx
        function SendPaperIDandName(id, values) {
            values = trim12(values);
            var lblDefaultPaper = "<%=lblDefaultPaper.ClientID %>";
            document.getElementById(lblDefaultPaper).title = SpecialDecode(values);
            document.getElementById(lblDefaultPaper).innerHTML = SpecialDecode(values);
            document.getElementById(lblDefaultPaper).style.cursor = "pointer";

            if (document.getElementById(lblDefaultPaper).innerHTML.length > 25) {
                document.getElementById(lblDefaultPaper).innerHTML = document.getElementById(lblDefaultPaper).innerHTML.substring(0, 25) + "...";
            }
            document.getElementById("<%=hdnpaperID.ClientID %>").value = id;
        }


        // This function call is used for next button navigation and validation
        var txtDigitalPressName = document.getElementById("<%=txtDigitalPressName.ClientID %>");
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
        var ddlGuillotine = document.getElementById("<%=ddlGuillotine.ClientID %>");
        var txtSetupCharge = document.getElementById("<%=txtSetupCharge.ClientID %>");
        var txtMinRunningCharge = document.getElementById("<%=txtMinRunningCharge.ClientID %>");
        var txtMarkUp = document.getElementById("<%=txtMarkUp.ClientID %>");
        var txtspeedMarkup = document.getElementById("<%=txtspeedMarkup.ClientID %>");
        var divFeedRestriction = document.getElementById("div_Feed_restriction");
        var divPlantCalculation = document.getElementById("div_Plant_Calculation");
        var lblheader = document.getElementById("<%=lblheader.ClientID %>");
        var ddlMethod = document.getElementById("<%=ddlMethod.ClientID %>");
        var txtBlackChargeableSheets = document.getElementById("<%=txtBlackChargeableSheets.ClientID %>");
        var txtColourChargeableSheets = document.getElementById("<%=txtColourChargeableSheets.ClientID %>");
        var txtHourlyCharge = document.getElementById("<%=txtHourlyCharge.ClientID %>");
        var txtBlackTo1 = document.getElementById("txtBlackTo1"); //ctl00_ContentPlaceHolder1_

        var txtNoChargeableSheets = document.getElementById("<%=txtNoChargeableSheets.ClientID %>");
        var hid_ddlMethodSelected = document.getElementById("<%=hid_ddlMethodSelected.ClientID %>");
        var txtBlackGSM1 = document.getElementById("<%=txtBlackGSM1.ClientID %>");
        var txtBlackGSM2 = document.getElementById("<%=txtBlackGSM2.ClientID %>");
        var txtBlackGSM3 = document.getElementById("<%=txtBlackGSM3.ClientID %>");
        var txtBlackPagesPerMinute1 = document.getElementById("<%=txtBlackPagesPerMinute1.ClientID %>");
        var txtBlackPagesPerMinute2 = document.getElementById("<%=txtBlackPagesPerMinute2.ClientID %>");
        var txtBlackPagesPerMinute3 = document.getElementById("<%=txtBlackPagesPerMinute3.ClientID %>");
        var txtColorGSM1 = document.getElementById("<%=txtColorGSM1.ClientID %>");
        var txtColorGSM2 = document.getElementById("<%=txtColorGSM2.ClientID %>");
        var txtColorGSM3 = document.getElementById("<%=txtColorGSM3.ClientID %>");
        var txtColorPagesPerMinute1 = document.getElementById("<%=txtColorPagesPerMinute1.ClientID %>");
        var txtColorPagesPerMinute2 = document.getElementById("<%=txtColorPagesPerMinute2.ClientID %>");
        var txtColorPagesPerMinute3 = document.getElementById("<%=txtColorPagesPerMinute3.ClientID %>");

        var txtUnitOfMeasure = document.getElementById("<%=txtUnitOfMeasure.ClientID %>");
        var spn_UnitOfMeasure = document.getElementById("spn_UnitOfMeasure");
        var UnitOfMeasure = '<%=UnitOfMeasureKey %>';
        var Copied_Black_N_White_2_Color_Msg = '<%=Copied_Black_N_White_2_Color_Msg %>'

        //This function call is to display ShowOnCalculation in clickchargezones
        var divClickChargeLookup = document.getElementById("div_ClickChargeLookup");
        var divSpeedWeightLookup = document.getElementById("div_SpeedWeightLookup");
        var divClickZonesLookup = document.getElementById("div_ClickZonesLookup");

        // This function call is to check the checkbox of flatten and sum checkbox in clickchargezonelookup
        var chkFlatten = document.getElementById("<%=chkColorFlattenClick.ClientID%>");
        var chkSum = document.getElementById("<%=chkColorSumClick.ClientID %>");

        //This function is to apply black and white charge values to color  
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
        var hdn_ClickChargeZoneLookupColour = document.getElementById("<%=hdn_ClickChargeZoneLookupColour.ClientID%>");
        var hdnTotalrowscount = document.getElementById("<%=hdnTotalrowscount.ClientID%>");
        var hdnItemscount = document.getElementById("<%=hdnItemscount.ClientID%>");
        var spnColorFrom = "spnColorFrom";
        var ColorFrom = "txtColorFrom";
        var ColorTo = "txtColorTo";
        var ColorChargableSheets = "txtColorChargableSheets";
        var ColorCost = "txtColorCost";
        var ColorMarkup = "txtColorMarkup";
        var ColorChargableRate = "txtColorChargableRate";
        var spn_Colour_dash = "spn_Colour_dash_";
        var Values = '';
        var ColorValues = '';
        <%--var MatrixStartRange = '<%=MatrixStartRange%>';
        var MatrixEndRange = '<%=MatrixEndRange%>';
        var CostPrefill = '<%=CostPrefill %>';--%>

        var BlackMatrixStartRange = '<%=BlackMatrixStartRange%>';
        var BlackMatrixEndRange = '<%=BlackMatrixEndRange%>';
        var BlackCostPrefill = '<%=BlackCostPrefill %>';

        var ColourMatrixStartRange = '<%=ColourMatrixStartRange%>';
        var ColourMatrixEndRange = '<%=ColourMatrixEndRange%>';
        var ColourCostPrefill = '<%=ColourCostPrefill %>';

        var ItemsCounter = '<%=ItemsCounter%>';
        var strImagepath = '<%=strImagepath%>';

        //This variable is used in default paper function 


        var spn_ddlMethod = document.getElementById("spn_ddlMethod");

        //document.getElementById("<%=txtDigitalPressName.ClientID %>").focus();

        //function for decimal 
        //ForDecimal();//To calculate Markup in Zone Press

    </script>
    <script type="text/javascript">
        //******* funcn to check for digital press duplicacy *********////
        var IsDuplicate = false;
        function CheckDigitalPress(val1) {
            if (val1 != '') {
                var compID = '<%=CompanyID %>';
                var id = '<%=DigitalPressID %>';
                var val = compID + "±" + val1 + "±" + "digital" + "±" + id;

                PageMethods.GetDigitalPress(val, ShowMsgDigital, ShowMsg_Failure);
            }
        }
        function ShowMsgDigital(result) {

            $get('spn_txtPlantPressCheck').style.display = "none";
            if (result == -1) {
                $get('spn_txtPlantPressCheck').style.display = "block";
                IsDuplicate = true;
            }
            else {
                IsDuplicate = false;
            }
        }

        // Failure callback method     
        function ShowMsg_Failure(error) {

        }
        //*******End of funcn to ckech for digital press duplicacy*********////
        function RadWinClose() {

            // document.getElementById("ds00").style.display = "none";
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }
        function RemoveTextBox(index) {
            if (document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)) != null && document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)) != undefined && (parseInt(index) - 1) != 1) {
                document.getElementById("div_imgDeleterow_" + (parseInt(hdnTotalrowscount.value) - 1)).style.display = "block";
            }
            document.getElementById("div_Black_" + index + "").remove();
            document.getElementById("div_Color_" + index + "").remove();
            ItemsCounter = parseInt(ItemsCounter) - 1;
            hdnItemscount.value = parseInt(hdnItemscount.value) - 1;
            hdnTotalrowscount.value = parseInt(hdnTotalrowscount.value) - 1;
        }

        function Click_Add_More() {
            BlackCostPrefill = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(document.getElementById(BlackCost + parseInt(hdnTotalrowscount.value)).value) - parseFloat(0.01)), 4, '', false, false, false);
            ColourCostPrefill = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (parseFloat(document.getElementById(ColorCost + parseInt(hdnTotalrowscount.value)).value) - parseFloat(0.01)), 4, '', false, false, false);
            if (parseInt(hdnTotalrowscount.value) == 1) {
                BlackMatrixStartRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                BlackMatrixEndRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 50;
                ColourMatrixStartRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                ColourMatrixEndRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 50;
            } else {
                BlackMatrixStartRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                BlackMatrixEndRange = parseInt(document.getElementById(BlackTo + parseInt(hdnTotalrowscount.value)).value) + 100;
                ColourMatrixStartRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 1;
                ColourMatrixEndRange = parseInt(document.getElementById(ColorTo + parseInt(hdnTotalrowscount.value)).value) + 100;
            }
            var Data = '';
            var Data1 = '';
            if (document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)) != null && document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)) != undefined) {
                document.getElementById("div_imgDeleterow_" + parseInt(hdnTotalrowscount.value)).style.display = "none";
            }
            Data = Create_BlackRow(parseInt(hdnTotalrowscount.value) + 1, Data);
            Data1 = Create_ColorRow(parseInt(hdnTotalrowscount.value) + 1, Data);
            var div = document.createElement("div");
            var div1 = document.createElement("div");
            div.innerHTML = Data;
            div1.innerHTML = Data1;
            document.getElementById("div_left").appendChild(div);
            document.getElementById("div_right").appendChild(div1);
            ItemsCounter = parseInt(ItemsCounter) + 1;
            hdnItemscount.value = parseInt(hdnItemscount.value) + 1;
            hdnTotalrowscount.value = parseInt(hdnTotalrowscount.value) + 1;
        }

        function Create_BlackRow(i, dataValue) {
            dataValue = "<div id='div_Black_" + i + "' style='float: left; width: 100%;'>";
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
            dataValue += "<div style='float: left; width: 15%;'>";
            dataValue += "<input type='text' ID='txtBlackChargableSheets" + i + "' value=" + 1 + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%'>";
            dataValue += "<input type='text' ID='txtBlackCost" + i + "' value=" + BlackCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "');Calculate_BlackChargeableRate(this.value," + i + ",'cost'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%'>";
            dataValue += "<input type='text' ID='txtBlackMarkup" + i + "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_BlackChargeableRate(this.value," + i + ",'markup'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 12%;'>";
            dataValue += "<input type='text' ID='txtBlackChargableRate" + i + "' value=" + BlackCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Black_" + i + "');Calculate_BlackMarkup(this.value," + i + "); />"
            dataValue += "</div>";
            //dataValue += "<div id='div_imgDeleterow_" + i + "' style='float: left;'>";
            //dataValue += "<img id='imgDeleterow_" + i + "' style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(" + i + ");'/>";
            //dataValue += "</div>";
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

        function Create_ColorRow(i, dataValue) {
            dataValue = "<div id='div_Color_" + i + "' style='float: left; width: 100%;'>";
            //dataValue += "<div style='float: left; width: 10%;'><span>&nbsp; From </span></div>";
            // dataValue += "<div style='float: left; width: 10%;'><span>&nbsp;</span></div>";
            dataValue += "<div style='float: left; width: 20%; text-align: right'>";
            dataValue += "<span id='spnColorFrom" + i + "'>" + ColourMatrixStartRange + "</span>";// + "+" 
            dataValue += "<input type='text' ID='txtColorFrom" + i + "' value=" + ColourMatrixStartRange + " Style='display: none'/>";
            dataValue += "<input type='hidden' ID='hid_ColorClickChargeZoneLookupID_" + i + "' value='0' style='display:none'/>";
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 3%; text-align: center'>";
            dataValue += "<span>&nbsp;</span>";
            dataValue += "<span id='spn_Colour_dash_" + i + "'>-</span>";
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%'>";//visibility: hidden;
            dataValue += "<input type='text' ID='txtColorTo" + i + "' value=" + ColourMatrixEndRange + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='8' onblur= AllowNumber(this,this.value);checkNextCharge(this.value," + i + ",'color');CallonBlur(this.value,'spn_Color_" + i + "'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%;'>";
            dataValue += "<input type='text' ID='txtColorChargableSheets" + i + "' value=" + 1 + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' CssClass='textboxnew' MaxLength='8' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_" + i + "'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%'>";
            dataValue += "<input type='text' ID='txtColorCost" + i + "' value=" + ColourCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px'  MaxLength='12' onblur=AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_" + i + "');Calculate_ColorChargeableRate(this.value," + i + ",'cost'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 15%'>";
            dataValue += "<input type='text' ID='txtColorMarkup" + i + "' value='0.00' Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' SkinID='textPad' MaxLength='12' onblur=AllowNumber(this,this.value);Calculate_ColorChargeableRate(this.value," + i + ",'markup'); />"
            dataValue += "</div>";
            dataValue += "<div style='float: left; width: 12%;'>";
            dataValue += "<input type='text' ID='txtColorChargableRate" + i + "' value=" + ColourCostPrefill + " Style='text-align: right;width:54px;font-family:Verdana, Arial, Helvetica, sans-serif;font-size: 11px;color: #000000;vertical-align: middle;border-top: silver 1px solid; border-right: #737373 2px solid;border-left: silver 1px solid;border-bottom: #737373 1px solid;padding-top:2px' MaxLength='12' onblur= AllowNumber(this,this.value);CallonBlur(this.value,'spn_Color_" + i + "');Calculate_ColorMarkup(this.value," + i + "); />"
            dataValue += "</div>";
            dataValue += "<div id='div_imgDeleterow_" + i + "' style='float: left;'>";
            dataValue += "<img id='imgDeleterow_" + i + "' style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick='javascript:RemoveTextBox(" + i + ");'/>";
            dataValue += "</div>";
            dataValue += "<div class='onlyEmpty'>";
            dataValue += "<div style='width: 10%; float: left;'>&nbsp;</div>";
            dataValue += "<div style='width: 10%; float: left;'>&nbsp;</div>";
            dataValue += "<div style='width: 3%; float: left;'>&nbsp;</div>";
            dataValue += "<div>";
            dataValue += "<span id='spn_Color_" + i + "' class='spanerrorMsg' style='display: none; width: auto; padding-left: 4px; padding-right: 4px;'>Please enter numeric value</span>";
            dataValue += "</div>";
            dataValue += "</div>";
            dataValue += "</div>";
            ColorValues += "StartRange±" + ColourMatrixStartRange + "~" + "EndRange±" + ColourMatrixEndRange + "~" + "CostPrefill±" + ColourCostPrefill + "&";
            hdnColor.value = ColorValues;
            return dataValue;
        }

        function Show() {
            if (document.getElementById("divrad").style.display == "none") {
                var divrad = document.getElementById("divrad");
                setLoadingPositionOfDivMove(divrad);
                showDivPopupCenter('divrad', '200');
            }
            else {
                document.getElementById("divrad").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
            }
        }

        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    </script>
    <telerik:RadWindowManager ShowContentDuringLoad="false" AutoSize="true" EnableShadow="true"
        Skin="Default" ID="RadWindowManager1" Width="900px" Height="200px" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
