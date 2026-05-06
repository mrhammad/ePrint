<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Company_profile.aspx.cs" Inherits="ePrint.settings.Company_profile" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>"></script>--%>
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
                                    <%=objLanguage.GetLanguageConversion("Ssettings_Company_Profile")%></span>
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
                <div style="width: 100%;" class="mis_header_panel">
                    <div id="">
                        <div align="left" style="width: 100%; padding-bottom: 0px">
                            <div style="width: 100%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div align="left" style="width: 100%">
                            <div style="float: left; width: 49%; border: 0px solid; display: block">
                                <div align="left">
                                    <%--<div class="only5px">
                                    </div>--%>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name" CssClass="normalText"></asp:Label><span style="color: Red"> *</span>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyName" SkinID="textPad" MaxLength="50" onBlur="Validatecmpnyname();"></asp:TextBox>
                                        <span id="spn_CompanyName" class="spanerrorMsg" style="display: none; width: 178px;">
                                            <asp:Label ID="lbl1" runat="server"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyAddress1" runat="server" Text="Company Address Line 1" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyAddress1" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyAddress1" class="spanerrorMsg" style="display: none; width: 175px">
                                            <asp:Label ID="lbl2" runat="server"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyAddress2" runat="server" Text="Company Address Line 2" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyAddress2" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyAddress2" class="spanerrorMsg" style="display: none; width: 175px">
                                         <asp:Label ID="lbl3" runat="server"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyAddress3" runat="server" Text="Company Address Line 3" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyAddress3" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyAddress3" class="spanerrorMsg" style="display: none; width: 175px">
                                            <asp:Label ID="lbl4" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyAddress4" runat="server" Text="Company Address Line 4" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyPostalCode" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyAddress4" class="spanerrorMsg" style="display: none; width: 175px">
                                          <asp:Label ID="lbl5" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyCountry" runat="server" Text="Company Country" CssClass="normalText"></asp:Label><span style="color: Red"> *</span>
                                    </div>
                                    <div class="box" style="width: 25px">
                                        <asp:DropDownList ID="ddlCompanyCountry" runat="server" CssClass="normalText" Width="185px" onBlur="Validatecmpnyname();" onchange="javascript:onchange_ddlCompanyCountry();">
                                        </asp:DropDownList>
                                        <span id="spn_CompanyCountry" class="spanerrorMsg" style="display: none; width: 190px">
                                         <asp:Label ID="lbl6" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblcurrency" runat="server" Text="Currency" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box" style="width: 25px">
                                        <asp:DropDownList ID="ddl_Currency" runat="server" CssClass="normalText" Width="185px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyPhone" runat="server" Text="Company Telephone" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyPhone" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyPhone" class="spanerrorMsg" style="display: none; width: 175px">
                                          <asp:Label ID="lbl7" runat="server"></asp:Label>   ></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyFax" runat="server" Text="Company Fax" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyFax" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyFax" class="spanerrorMsg" style="display: none; width: 175px">
                                          <asp:Label ID="lbl8" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyEmail" runat="server" Text="Company Email" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyEmail" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="Spn_EmailMsg" class="spanerrorMsg" style="display: none; width: 175px">
                                         <asp:Label ID="lbl9" runat="server"></asp:Label> 
                                        </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyURL" runat="server" Text="Company URL" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyurl" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyName0" class="spanerrorMsg" style="display: none; width: 175px">
                                         <asp:Label ID="lbl10" runat="server"></asp:Label> </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblCompanyNumber" runat="server" Text="Company Number" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtCompanyNumber" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyName1" class="spanerrorMsg" style="display: none; width: 175px">
                                           <asp:Label ID="lbl11" runat="server"></asp:Label> </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblTaxNumber" runat="server" Text="Tax Number" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox runat="server" ID="txtTaxNumber" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                        <span id="spn_CompanyName2" class="spanerrorMsg" style="display: none; width: 175px">
                                            <asp:Label ID="lbl12" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div align="left" style="display: none">
                                    <div class="bglabel">
                                        <asp:Label ID="lblRoundOff" runat="server" Text="Roundoff" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:DropDownList ID="ddlroundoff" runat="server" CssClass="normalText" Width="140px">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem Selected="True">2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp; <span>Decimal</span>
                                    </div>
                                </div>
                                <div align="left" style="display: none">
                                    <div class="bglabel">
                                        <asp:Label ID="lblYear" runat="server" Text="Fiscal Year" CssClass="normalText" MaxLength="50"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div id="div_DateRange" style="float: left;">
                                                        <div style="float: left; padding: 0px" nowrap="nowrap">
                                                            <asp:TextBox ID="txtFrom" runat="server" SkinID="textPad" Width="100px" Enabled="true"></asp:TextBox><span
                                                                class="normalText">&nbsp;<%=objLanguage.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                    ID="txtTo" runat="server" SkinID="textPad" Width="100px" Enabled="true"></asp:TextBox>
                                                            <span id="spn_txtFromDate" class="spanerrorMsg" style="display: none; width: 150px">Please enter Req'd Date </span><span id="spn_txtToDate" class="spanerrorMsg" style="display: none; width: 250px;">Please enter Req'd Date </span><span id="spndateRange" class="spanerrorMsg"
                                                                style="display: none">Date Range is not in Correct Format</span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--<div align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblHighlightSellingprice" runat="server" Text="Tax Number" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:CheckBox ID="chksellingpricehighlight" runat="server" />
                                        <span id="spn_Ishighlightedsellingprice" class="spanerrorMsg" style="display: none; width: 175px">
                                            <asp:Label ID="Label2" runat="server"></asp:Label></span>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="width: 81%; border: 0px solid;">
                            <div class="bglabelEmpty" style="width: 17%">
                            </div>
                            <div class="box" style="width: 450px">
                                <div style="float: left;">
                                    <div id="div_btnCancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                        </telerik:RadButton>
                                    </div>
                                    <div id="div_btncancelprocess" class="button" align="center" style="height: 14px; width: 43px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left; margin-bottom: 10px">
                                    <div id="div_btnSave" style="display: block">
                                        <%--<telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                            runat="server" Text="save" OnClick="btnSave_OnClick" OnClientClick="return Validatecmpnyname();">
                                        </telerik:RadButton> var a= validateing();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a--%>
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" 
                                            OnClientClick="var result = Validatecmpnyname(); if(result)loadingimg('div_btnSave','div_btnsaveprocess'); return result;" Text="save"
                                             CssClass="button" />
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
    </div>
    <script type="text/javascript" language="javascript">
        var txtCompanyEmail = document.getElementById("<%=txtCompanyEmail.ClientID %>");

        var txtCompanyname = document.getElementById("<%=txtCompanyName.ClientID %>");
        //var txtCompanyurl = document.getElementById("<%=txtCompanyurl.ClientID %>");
        //var txtCompanynumber = document.getElementById("<%=txtCompanyNumber.ClientID %>");
        // var txtTaxnumber = document.getElementById("<%=txtTaxNumber.ClientID %>");
        var ddlcompanycountry = document.getElementById("<%=ddlCompanyCountry.ClientID %>");
        var CheckFinal = false;
        function Validate() {

            if (txtCompanyEmail.value != "") {
                if (!ValidateEmail(txtCompanyEmail.value, 'Spn_EmailMsg', 'no')) {
                    return false;
                }
            }
            if (CheckFinal) {
                return false;
            }
            else {

                return true;
            }
        }

        function Validatecmpnyname() {
           
            
            if (txtCompanyname.value == '') {
                document.getElementById('spn_CompanyName').style.display = "block";
                return false;
            }
            else {
                document.getElementById('spn_CompanyName').style.display = "none";
                
            }
            if (ddlcompanycountry.value == '0') {
                
                document.getElementById('spn_CompanyCountry').style.display = "block";
                return false;
            }
            else {
                document.getElementById('spn_CompanyCountry').style.display = "none";
                
            }
            if (txtCompanyname.value != '' && ddlcompanycountry.value != '0') {
                return true;
            }
            //if(txtCompanynumber=='')
            //{
            //    document.getElementById('spn_CompanyName1').style.display = "block";
            //    return false;
            //}
            //if(txtTaxnumber.value=='')
            //{
            //    document.getElementById('spn_CompanyName2').style.display = "block";
            //}

            //        document.getElementById('spn_CompanyName0').style.display = "block";
            //        document.getElementById('spn_CompanyName1').style.display = "block";
            //        document.getElementById('spn_CompanyName2').style.display = "block";
            //        return false;


        }

        function onchange_ddlCompanyCountry() {
            var ddCountry = document.getElementById("<%=ddlCompanyCountry.ClientID %>");
            var ddCurrency = document.getElementById("<%=ddl_Currency.ClientID %>");
            ddCurrency.selectedIndex = ddCountry.options[ddCountry.selectedIndex].value;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
