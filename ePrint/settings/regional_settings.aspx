<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="regional_settings.aspx.cs" Inherits="ePrint.settings.regional_settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../common/swazz_calendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <div align="left" id="pnldetails">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objlang.GetLanguageConversion("Settings_Regional_Settings")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div style="width: 100%; padding-left: 10px; margin-top: -3px;">
                    <div id="">
                        <div align="left" style="width: 100%; padding-top: 10px; margin-bottom: -10px;">
                            <div style="width: 100%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <div align="left" style="width: 100%">
                            <div style="float: left; width: 49%; border: solid 0px">
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblcustomer" runat="server" Text="Language" CssClass="normalText"></asp:Label><span
                                            style="color: Red; padding-left: 2px">*</span></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlLanguage" CssClass="normalText" Width="185px"
                                                onchange="javascript:showDefaultValues(this.value);CallonChange(this.value,'spn_ddlLanguage');return false;">
                                            </asp:DropDownList>
                                            <span id="spn_ddlLanguage" class="spanerrorMsg" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px">
                                                <%=objlang.GetLanguageConversion("Please_Select_Language")%>
                                            </span>
                                        </div>
                                        <asp:HiddenField ID="hid_LanguageID" runat="server" Value="0"></asp:HiddenField>
                                        <asp:HiddenField ID="hid_RegionalID" runat="server" Value="0"></asp:HiddenField>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblDateFormate" runat="server" Text="Date Format" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlDateFormat" CssClass="normalText" Width="185px">
                                                <asp:ListItem Value="dd/mm/yyyy">dd/mm/yyyy</asp:ListItem>
                                                <asp:ListItem Value="mm/dd/yyyy">mm/dd/yyyy</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <asp:HiddenField ID="hid_Dateformat" runat="server" Value=""></asp:HiddenField>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblColour" runat="server" Text="Colour" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtColour" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtColour" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Colour")%></span>
                                    </div>
                                    <asp:HiddenField ID="hid_Colour" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblOrganisation" runat="server" Text="Organisation" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtOrganisation" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtOrganisation" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Organisation")%></span>
                                    </div>
                                    <asp:HiddenField ID="hid_Organisation" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblState" runat="server" Text="State" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtState" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtState" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_State")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_State" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCentre" runat="server" Text="Centre" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCentre" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtCentre" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Centre")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_Centre" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtPostcode" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtPostcode" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_ZipCode")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_ZipCode" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblMetre" runat="server" Text="Metre" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtMetre" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtMetre" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Metre")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_Metre" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblWeight" runat="server" Text="Weight" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtWeight" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtWeight" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_PaperWeight")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_Weight" runat="server" Value=""></asp:HiddenField>
                                </div>

                                  <div align="left" id="div1" runat="server">
                                    <div class="bglabel">
                                        <asp:Label ID="lblpapermaterial" runat="server" Text="Paper/Material Caliper" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
<%--                                        <asp:TextBox runat="server" ID="TextBox1" SkinID="textPad" MaxLength="50" Style="display: none"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlPaperMaterial" runat="server" CssClass="normalText" Width="185px">
                                            <asp:ListItem Value="Micron">Micron</asp:ListItem>
                                            <asp:ListItem Value="Points">Points</asp:ListItem>
                                            <asp:ListItem Value="Mils">Mils</asp:ListItem>
                                        </asp:DropDownList>
                                   <%--     <span id="spn_txtPaper" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Paper_Measure")%>
                                        </span>--%>
                                    </div>
                                    <asp:HiddenField ID="hid_PaperMaterial" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblGeneralWeight" runat="server" Text="General Weight" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtGeneralWeight" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtGeneralWeight" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_General_Weight")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hdngeneralweight" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left" id="div_PaperMeasure" runat="server">
                                    <div class="bglabel">
                                        <asp:Label ID="lblPaperMeasure" runat="server" Text="Paper Measure" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtPaper" SkinID="textPad" MaxLength="50" Style="display: none"></asp:TextBox>
                                        <asp:DropDownList ID="ddlPaperMeasure" runat="server" CssClass="normalText" Width="185px">
                                            <asp:ListItem Value="mm">mm</asp:ListItem>
                                            <asp:ListItem Value="In.">In.</asp:ListItem>
                                        </asp:DropDownList>
                                        <span id="spn_txtPaper" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Paper_Measure")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_PaperMeasure" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblOrganisation5" runat="server" Text="Page Title" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtPageTitle" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_txtPageTitle" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Page_Title")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_txtPageTitle" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblColour0" runat="server" Text="Company Title" CssClass="normalText"
                                            MaxLength="50"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompany" SkinID="textPad"></asp:TextBox>
                                        <span id="spn_txtCompany" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetLanguageConversion("Please_Enter_Company_Title")%>
                                        </span>
                                    </div>
                                    <asp:HiddenField ID="hid_CompanyTitle" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblColour2" runat="server" Text="Time Zone" CssClass="normalText"
                                            MaxLength="50"></asp:Label></div>
                                    <div class="box">
                                        <asp:DropDownList ID="ddlTimeZone" runat="server" CssClass="normalText" Width="185px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                                                
                                <%--- added by rakshith  --%>
                                <div align="left" style="margin-top: -100px">
                                    <div class="bglabel">
                                        <asp:Label ID="lblcostcentre" runat="server" Text="Cost Centre Enabled" CssClass="normalText"
                                            MaxLength="50"><%=objlang.GetLanguageConversion("Cost_Centre_Enabled")%></asp:Label></div>
                                    <div class="box">
                                        <asp:CheckBox ID="chkCostCentreDisplay" runat="server" />
                                    </div>
                                </div>
                                <div align="left">
                                    <asp:HiddenField ID="hdnFrom" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnTo" runat="server" Value="0" />
                                    <div class="bglabel">
                                        <asp:Label ID="lblYear" runat="server" Text="" CssClass="normalText" MaxLength="50"><%=objLanguage.GetLanguageConversion("Fiscal_Year") %></asp:Label></div>
                                    <div class="box">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div id="div_DateRange" style="float: left;">
                                                        <div style="float: left; padding: 0px" nowrap="nowrap">
                                                            <asp:DropDownList ID="ddlFromMonth" runat="server">
                                                            </asp:DropDownList>
                                                            <span class="normalText">&nbsp;<%=objLanguage.GetLanguageConversion("To")%>&nbsp;</span>
                                                            <asp:DropDownList ID="ddlToMonth" runat="server">
                                                            </asp:DropDownList>
                                                            <span id="spn_txtFromDate" class="spanerrorMsg" style="display: none; width: 150px">
                                                                Please enter Req'd Date </span><span id="spn_txtToDate" class="spanerrorMsg" style="display: none;
                                                                    width: 250px;">Please enter Req'd Date </span><span id="spndateRange" class="spanerrorMsg"
                                                                        style="display: none">Date Range is not in Correct Format</span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="width: 81%; border: 0px solid">
                            <div class="bglabelEmpty" style="width: 17%">
                            </div>
                            <div class="box">
                                <div style="float: left; padding-left: 0%">
                                    <div id="div_btnCancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                        </telerik:RadButton>
                                    </div>
                                    <div id="div_btncancelprocess" class="button" align="center" style="height: 14px;
                                        width: 43px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left; margin-bottom: 10px">
                                    <div id="div_btnSave" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                            runat="server" Text="save" OnClick="btnSave_OnClick" OnClientClick="javascript:var a=Validate();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;">
                                        </asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var ddlLanguageID = document.getElementById("<%=ddlLanguage.ClientID %>");
        var ddlDateFormat = document.getElementById("<%=ddlDateFormat.ClientID %>");
        var txtColour = document.getElementById("<%=txtColour.ClientID %>");
        var txtOrganisation = document.getElementById("<%=txtOrganisation.ClientID%>");
        var txtState = document.getElementById("<%=txtState.ClientID %>");
        var txtCentre = document.getElementById("<%=txtCentre.ClientID %>");
        var txtPostcode = document.getElementById("<%=txtPostcode.ClientID %>");
        var txtMetre = document.getElementById("<%=txtMetre.ClientID%>");
        var txtWeight = document.getElementById("<%=txtWeight.ClientID %>");
        var txtGeneralWeight = document.getElementById("<%=txtGeneralWeight.ClientID %>");
        var txtPaper = document.getElementById("<%=txtPaper.ClientID %>");
        var ddlPaperMeasure = document.getElementById("<%=ddlPaperMeasure.ClientID %>");
        var ddlTimeZone = document.getElementById("<%=ddlTimeZone.ClientID %>");
        var txtCompany = document.getElementById("<%=txtCompany.ClientID %>");
        var hid_LanguageID = document.getElementById("<%=hid_LanguageID.ClientID %>");
        var hid_Dateformat = document.getElementById("<%=hid_Dateformat.ClientID %>");
        var hid_Colour = document.getElementById("<%=hid_Colour.ClientID %>");
        var hid_Organisation = document.getElementById("<%=hid_Organisation.ClientID %>");
        var hid_State = document.getElementById("<%=hid_State.ClientID %>");
        var hid_Centre = document.getElementById("<%=hid_Centre.ClientID %>");
        var hid_ZipCode = document.getElementById("<%=hid_ZipCode.ClientID %>");
        var hid_Metre = document.getElementById("<%=hid_Metre.ClientID %>");
        var hid_Weight = document.getElementById("<%=hid_Weight.ClientID %>");
        var hdngeneralweight = document.getElementById("<%=hdngeneralweight.ClientID %>");
        var hid_PaperMeasure = document.getElementById("<%=hid_PaperMeasure.ClientID %>");
        var hid_CompanyTitle = document.getElementById("<%=hid_CompanyTitle.ClientID %>");
        var ddlPaperMaterial = document.getElementById("<%=ddlPaperMaterial.ClientID %>");
        var hid_PaperMaterial = document.getElementById("<%=hid_PaperMaterial.ClientID %>");


        function Validate() {
            var CheckFinal = false;
            var ddlLanguage = ddlLanguageID.value;

            if (ddlLanguage == '0') {
                document.getElementById("spn_ddlLanguage").style.display = "block";
                CheckFinal = true;
            }

            var txtColourVal = trim12(txtColour.value);
            if (txtColourVal == '') {
                document.getElementById("spn_txtColour").style.display = "block";
                CheckFinal = true;
            }

            var txtOrganisationVal = trim12(txtOrganisation.value);
            if (txtOrganisationVal == '') {
                document.getElementById("spn_txtOrganisation").style.display = "block";
                CheckFinal = true;
            }

            var txtStateVal = trim12(txtState.value);
            if (txtStateVal == '') {
                document.getElementById("spn_txtState").style.display = "block";
                CheckFinal = true;
            }

            var txtCentreVal = trim12(txtCentre.value);
            if (txtCentreVal == '') {
                document.getElementById("spn_txtCentre").style.display = "block";
                CheckFinal = true;
            }

            var txtPostcodeVal = trim12(txtPostcode.value);
            if (txtPostcodeVal == '') {
                document.getElementById("spn_txtPostcode").style.display = "block";
                CheckFinal = true;
            }

            var txtMetreVal = trim12(txtMetre.value);
            if (txtMetreVal == '') {
                document.getElementById("spn_txtMetre").style.display = "block";
                CheckFinal = true;
            }

            var txtWeightVal = trim12(txtWeight.value);
            if (txtWeightVal == '') {
                document.getElementById("spn_txtWeight").style.display = "block";
                CheckFinal = true;
            }

            var txtGeneralWeightVal = trim12(txtGeneralWeight.value);
            if (txtGeneralWeightVal == '') {
                document.getElementById("spn_txtGeneralWeight").style.display = "block";
                CheckFinal = true;
            }


            var txtCompanyVal = trim12(txtCompany.value);
            if (txtCompanyVal == '') {
                document.getElementById("spn_txtCompany").style.display = "block";
                CheckFinal = true;
            }
            if (CheckFinal) {
                return false;
            }
            else {
                return true;
            }
        }    
    </script>
    <script>
        function showDefaultValues(ddlval) {
            if (ddlval == hid_LanguageID.value) {

                ddlDateFormat.options[ddlDateFormat.selectedIndex].value = hid_Dateformat.value;
                txtColour.value = hid_Colour.value;
                txtOrganisation.value = hid_Organisation.value;
                txtState.value = hid_State.value;
                txtCentre.value = hid_Centre.value;
                txtPostcode.value = hid_ZipCode.value;
                txtMetre.value = hid_Metre.value;
                txtWeight.value = hid_Weight.value;
                txtGeneralWeight.value = hdngeneralweight.value;
                ddlPaperMeasure.options[ddlPaperMeasure.selectedIndex].value = hid_PaperMeasure.value;
                txtCompany.value = hid_CompanyTitle.value;
                ddlPaperMaterial.options[ddlPaperMaterial.selectedIndex].value = hid_PaperMaterial.value;

            }
            else {
                ddlDateFormat.options[ddlDateFormat.selectedIndex].value = "mm/dd/yyyy";
                txtColour.value = "Color";
                txtOrganisation.value = "Organisation";
                txtState.value = "State";
                txtCentre.value = "Centre";
                txtPostcode.value = "Zip Code";
                txtMetre.value = "Metre";
                txtWeight.value = "Paper Weight";
                txtGeneralWeight.value = "General Weight";
                ddlPaperMeasure.SelectedIndex = 0;
                ddlPaperMeasure.options[ddlPaperMeasure.selectedIndex].value = hid_PaperMeasure.value;
                ddlPaperMaterial.SelectedIndex = 0;
                ddlPaperMaterial.options[ddlPaperMaterial.selectedIndex].value = hid_PaperMaterial.value;
                txtCompany.value = "CompanyTitle";
            }
            if (ddlLanguageID.selectedIndex == '1') {
                ddlDateFormat.selectedIndex = 1;
                ddlPaperMeasure.selectedIndex = 1;
                ddlTimeZone.selectedIndex = 5;
                txtPostcode.value = "Zip Code";
                txtOrganisation.value = "Organization";
                txtCentre.value = "Center";
                txtMetre.value = "Meter";
                txtGeneralWeight.value = "lbs";
                txtWeight.value = "gsm";
                txtState.value = "State";
            }
            else if (ddlLanguageID.selectedIndex == '2') {

                ddlDateFormat.selectedIndex = 0;
                ddlPaperMeasure.selectedIndex = 0;
                ddlTimeZone.selectedIndex = 32;
                txtPostcode.value = "Post Code";
                txtOrganisation.value = "Organisation";
                txtCentre.value = "Centre";
                txtMetre.value = "Metre";
                txtWeight.value = "gsm";
                txtGeneralWeight.value = "kgs";
                txtState.value = "State";

            }
        }

        function SetDate() {
            var txtFrom = document.getElementById("<%=ddlFromMonth.ClientID%>");
            var txtTo = document.getElementById("<%=ddlToMonth.ClientID%>");

            var hdnFrom = document.getElementById("<%=hdnFrom.ClientID%>");
            var hdnTo = document.getElementById("<%=hdnTo.ClientID%>");

            var dtFrom = new Date(hdnFrom.value);
            var dtTo = new Date(hdnTo.value);

            var ddFrom, ddTo, mmFrom, mmTo, yyFrom, yyTo;

            //Date From Code
            if (dtFrom.getDate() < 10) {
                ddFrom = '0' + dtFrom.getDate()
            }
            else {
                ddFrom = dtFrom.getDate()
            }

            if ((dtFrom.getMonth() + 1) < 10) {
                mmFrom = '0' + (dtFrom.getMonth() + 1);
            }
            else {
                mmFrom = (dtFrom.getMonth() + 1);
            }
            yyFrom = dtFrom.getFullYear();

            //Date To Code
            if (dtTo.getDate() < 10) {
                ddTo = '0' + dtTo.getDate()
            }
            else {
                ddTo = dtTo.getDate()
            }

            if ((dtTo.getMonth() + 1) < 10) {
                mmTo = '0' + (dtTo.getMonth() + 1);
            }
            else {
                mmTo = (dtTo.getMonth() + 1);
            }
            yyTo = dtTo.getFullYear();

            if (ddlDateFormat.options[ddlDateFormat.selectedIndex].text == "mm/dd/yyyy") {
                txtFrom.value = mmFrom + '/' + ddFrom + '/' + yyFrom;
                txtTo.value = mmTo + '/' + ddTo + '/' + yyTo;
                return;
            }
            else {
                txtFrom.value = ddFrom + '/' + mmFrom + '/' + yyFrom;
                txtTo.value = ddTo + '/' + mmTo + '/' + yyTo;
                return;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
