<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="system_markup.aspx.cs" Inherits="ePrint.settings.system_markup" title="Settings: System Markup" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objlang.GetLanguageConversion("Settings_System_Markup")%></asp:Label>
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
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div>
            <div style="width: 100%;" class="mis_header_panel">
                <div id="">
                    <asp:UpdatePanel ID="UpdatePanelSysMarkup" runat="server">
                        <ContentTemplate>
                            <div align="left" style="width: 100%;">
                                <div style="width: 80%">
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <div align="left">
                                <div align="left" id="divPaper" runat="server">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Paper")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtPaper" runat="server" SkinID="textPad" Width="100px" Text="0.00"
                                            Style="text-align: right" onblur="todecimal_function(this,this.value);" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%----%><%--onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left">
                                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" ErrorMessage="Please enter Paper Markup"
                                            ControlToValidate="txtPaper" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            ValidationGroup="markup" Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Paper_markup")%></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVPaper" runat="server" ControlToValidate="txtPaper"
                                            ValidationGroup="markup" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            ErrorMessage="Please enter numeric value" ValidationExpression="^\d{0,5}(\.\d{1,10})?$"
                                            Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left" id="divInks" runat="server">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Inks")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtInks" runat="server" onblur="todecimal_function(this,this.value);"
                                            SkinID="textPad" Width="100px" Text="0.00" Style="text-align: right" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%-- onblur="MakePrice2Decimal(this);" onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Inks Markup"
                                            ControlToValidate="txtInks" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            ValidationGroup="markup" Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Inks_markup")%></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVInks" runat="server" ControlToValidate="txtInks"
                                            CssClass="errorMsg box" Display="Dynamic" ForeColor="" ErrorMessage="Please enter numeric value"
                                            ValidationGroup="markup" ValidationExpression="^\d{0,5}(\.\d{1,10})?$" Style="width: auto;
                                            padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%> </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Outwork")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtPrintBroker" runat="server" SkinID="textPad" Width="100px" Text="0.00"
                                            Style="text-align: right" onblur="todecimal_function(this,this.value);" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%-- --%><%--onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left; white-space: nowrap">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter Outwork Markup"
                                            ControlToValidate="txtPrintBroker" CssClass="errorMsg box" Display="Dynamic"
                                            ValidationGroup="markup" ForeColor="" Style="width: auto; padding-left: 4px;
                                            padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Outwork_markup")%>
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVPrintBroker" runat="server" ControlToValidate="txtPrintBroker"
                                            ValidationGroup="markup" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            ErrorMessage="Please enter numeric value" ValidationExpression="^\d{0,5}(\.\d{1,10})?$"
                                            Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%>
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Inventory_Items")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtInventoryItems" runat="server" onblur="todecimal_function(this,this.value);"
                                            SkinID="textPad" Width="100px" Text="0.00" Style="text-align: right" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%--  onblur="MakePrice2Decimal(this);"onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left; white-space: nowrap">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter Inv. Items Markup"
                                            ControlToValidate="txtInventoryItems" CssClass="errorMsg box" Display="Dynamic"
                                            ValidationGroup="markup" ForeColor="" Style="width: auto; padding-left: 4px;
                                            padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_enter_Inv_Items_Markup")%></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVInventoryItems" runat="server" ControlToValidate="txtInventoryItems"
                                            ValidationGroup="markup" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            ErrorMessage="Please enter numeric value" ValidationExpression="^\d{0,5}(\.\d{1,10})?$"
                                            Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Other_Costs")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtOtherCosts" runat="server" onblur="todecimal_function(this,this.value);"
                                            SkinID="textPad" Width="100px" Text="0.00" Style="text-align: right" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%--  onblur="MakePrice2Decimal(this);"onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left; white-space: nowrap">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOtherCosts"
                                            ValidationGroup="markup" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_enter_Other_Costs_markup")%></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVOtherCosts" runat="server" ControlToValidate="txtOtherCosts"
                                            CssClass="errorMsg box" Display="Dynamic" ForeColor="" ErrorMessage="Please enter numeric value"
                                            ValidationGroup="markup" ValidationExpression="^\d{0,5}(\.\d{1,10})?$" Style="width: auto;
                                            padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <%=objlang.GetLanguageConversion("Delivery_Cost")%>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <div class="box" style="width: 140px">
                                        <asp:TextBox ID="txtDeliveryCost" runat="server" onblur="todecimal_function(this,this.value);"
                                            SkinID="textPad" Width="100px" Text="0.00" Style="text-align: right" MaxLength="20"></asp:TextBox>&nbsp;&nbsp;%&nbsp;<%--  onblur="MakePrice2Decimal(this);"onblur="MakePrice2Decimal(this);"--%>
                                    </div>
                                    <div style="float: left; white-space: nowrap">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDeliveryCost"
                                            ValidationGroup="markup" CssClass="errorMsg box" Display="Dynamic" ForeColor=""
                                            Style="width: auto; padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_enter_Delivery_Cost_markup")%></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REVDeliveryCost" runat="server" ControlToValidate="txtDeliveryCost"
                                            CssClass="errorMsg box" Display="Dynamic" ForeColor="" ErrorMessage="Please enter numeric value"
                                            ValidationGroup="markup" ValidationExpression="^\d{0,5}(\.\d{1,10})?$" Style="width: auto;
                                            padding-left: 4px; padding-right: 4px;"><%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <div style="float: left">
                                            <span class="normalText">
                                                Default Markup</span> <span style="color: red;">
                                                    *</span>
                                        </div>
                                        <div style="float: right;">
                                            <asp:ImageButton ID="imgShowMarkup" runat="server" ImageUrl="~/images/plus.gif" OnClientClick="javascript:ShowPopup();"
                                                CausesValidation="false" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 60%; position: static;" nowrap="nowrap">
                                        <div style="float: left; padding: 3px 0px 0px 3px;" nowrap="nowrap">
                                            <asp:DropDownList ID="ddlMarkup" CssClass="normalText" OnSelectedIndexChanged="ddlMarkup_OnSelectedIndexChanged"
                                                AutoPostBack="true" runat="server" Width="110px" CausesValidation="false">
                                            </asp:DropDownList>
                                        </div>
                                        <div style="float: left; padding: 3px 0px 0px 0px;">
                                            &nbsp;<asp:Label ID="lblmarkup" runat="server" Text="0%"></asp:Label>
                                        </div>
                                        <div style="float: left; padding: 3px 0px 0px 11px;">
                                            <asp:RequiredFieldValidator ID="RFVMarkup" runat="server" ErrorMessage="Please select Markup"
                                                ControlToValidate="ddlMarkup" InitialValue="0" CssClass="errorMsg box" Display="Dynamic"
                                                ValidationGroup="markup" ForeColor="" Style="width: auto; padding-left: 4px;
                                                padding-right: 4px;"> <%=objlang.GetLanguageConversion("Please_Select_Markup")%></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:HiddenField ID="hid_MarkRate" runat="server" Value="0"></asp:HiddenField>
                                        <asp:HiddenField ID="hid_MarkType" runat="server" Value="add"></asp:HiddenField>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="float: left; width: 16%; min-width: 250px;">
                                        <div style="float: left">
                                            <span class="normalText">
                                                <%=objlang.GetLanguageConversion("Default_Tax_Code")%></span> <span style="color: red;">
                                                    *</span>
                                        </div>
                                    </div>
                                    <div style="float: left; padding: 3px 0px 0px 3px;">
                                        <asp:DropDownList ID="ddlTax" runat="server" CssClass="normalText" Width="110px"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlTax_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div style="float: left; padding: 3px 0px 0px 0px;">
                                        &nbsp;<asp:Label ID="lbltaxcode" runat="server" Text="0%"></asp:Label>
                                    </div>
                                    <div style="float: left; padding: 3px 0px 0px 11px;">
                                        <asp:RequiredFieldValidator ID="RFVTax" runat="server" ErrorMessage="Please select Tax Code"
                                            ControlToValidate="ddlTax" InitialValue="0" CssClass="errorMsg box" Display="Dynamic"
                                            ValidationGroup="markup" ForeColor="" Style="width: auto; padding-left: 4px;
                                            padding-right: 4px;"> <%=objlang.GetLanguageConversion("Please_Select_Tax_code")%></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="hid_TaxRate" runat="server" Value="0"></asp:HiddenField>
                                    </div>
                                </div>
                                <div align="left" style="display: none">
                                    <div class="bglabel" style="float: left; width: 16%;">
                                        <span class="normalText">
                                            <%=objlang.GetLanguageConversion("RoundUp_Total")%></span>
                                    </div>
                                    <div class="box">
                                        <asp:CheckBox ID="chkrounduptotals" runat="server" />
                                    </div>
                                </div>
                                <div style="float: left; width: 100%">
                                    <div class="bglabelEmpty" style="width: 16%; min-width: 250px;">
                                    </div>
                                    <div class="box">
                                        <div style="float: left; padding-top: 3px">
                                            <div id="div_btnCancel" style="display: block">
                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                    ValidationGroup="markup" runat="server" Text="Cancel" CommandName="Cancel" OnClick="btnCancel_OnClick"
                                                    CausesValidation="false">
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
                                        <div style="float: left; padding-top: 3px">
                                            <div id="div_btnsave" style="display: block">
                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnsave"
                                                    ValidationGroup="markup" runat="server" Text="save" OnClientClick="if(Page_ClientValidate()) loadingimg('div_btnsave','div_btnsaveprocess');"
                                                    OnClick="btnSave_OnClick ">
                                                </telerik:RadButton>
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
                                <asp:HiddenField ID="hid_SysMarkupID" runat="server" Value="0" />
                                <asp:HiddenField ID="hid_SysMarkupType" runat="server" Value="Add" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div id="div_mask">
    </div>
    <script language="javascript" type="text/javascript" src="../js/Item/float_popup.js?VN='<%=VersionNumber%>"></script>
    <div id="div_markup" class="topbar" style="width: 400px;">
        <div align="center" class="bgcustomize" style="width: 100%; padding: 3px">
            <div style="float: left; width: 95%; border: 0px solid">
                <span class="navigatorpanel" style="vertical-align: middle">
                    <%=objlang.GetLanguageConversion("Markup_Rates")%></span></div>
            <div style="float: right; border: 0px solid">
                <a href="" onclick="javascript:closebar('div_markup');return false;">
                    <img src="<%=strImagepath%>close1.jpg" border="0" /></a></div>
            <div style="clear: both">
            </div>
        </div>
        <div align="left" class="border1px" style="width: 100%; padding: 2px">
            <div class="bglabel">
                <asp:Label ID="lblMarkupName" runat="server" CssClass="HeaderText"><%=objlang.GetLanguageConversion("Markup_Name")%></asp:Label></div>
            <div class="box">
                <asp:TextBox ID="txtMarkupName1" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
            </div>
            <div class="bglabel">
                <asp:Label ID="lblMarkupRate" runat="server" CssClass="HeaderText"><%=objlang.GetLanguageConversion("Rate")%></asp:Label></div>
            <div class="box">
                <asp:TextBox ID="txtMarkupRate1" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
            </div>
            <div align="left" class="header" style="width: 90%">
                <div style="float: left; width: 47%">
                    &nbsp;</div>
                <div style="float: left">
                    <telerik:RadButton EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                        CssClass="Button" ID="btnMarkupRatesSave" runat="server" Text="Save">
                    </telerik:RadButton>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left">
                    <telerik:RadButton EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                        CssClass="Button" ID="btnMarkupRatesCancel" runat="server" Text="Cancel" CommandName="Cancel"
                        CausesValidation="false">
                    </telerik:RadButton>
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="System Markup"
        Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="systemMarkup" runat="server" DestroyOnClose="true" Width="430"
                Height="200">
                <ContentTemplate>
                    <div id="divMarkup" class="SystemMarkup_Main" align="center">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <div style="padding: 10px 5px 10px 10px; width: 98%">
                                        <div class="" style="width: 100%">
                                            <div id="Div1">
                                                <div align="left" style="width: 100%;">
                                                    <div align="left">
                                                        <div>
                                                            <div class="UploadFont_bglabel">
                                                                <asp:Label ID="Label2" runat="server" CssClass="normalText"></asp:Label>
                                                                <span style="color: red">*</span>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtMarkupName" runat="server" SkinID="textPad"></asp:TextBox>
                                                            </div>
                                                            <div>
                                                                <asp:RequiredFieldValidator ID="RFVMarkupName" runat="server" ErrorMessage="Please enter Markup Name"
                                                                    ControlToValidate="txtMarkupName" CssClass="errorMsg box" ForeColor=" " Style="margin-top: 2px;
                                                                    margin-left: 4px; width: auto; padding-left: 4px; padding-right: 4px;" Display="dynamic"
                                                                    ValidationGroup="VGmarkupadd"> <%=objlang.GetLanguageConversion("Please_Enter_Paper_markup")%></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <div class="UploadFont_bglabel">
                                                                <asp:Label ID="Label3" runat="server" CssClass="normalText"></asp:Label>
                                                                <span style="color: red">*</span>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtMarkupRate" runat="server" onblur="todecimal_function(this,this.value);"
                                                                    SkinID="textPad"></asp:TextBox>
                                                            </div>
                                                            <div>
                                                                <asp:RequiredFieldValidator ID="RFVMarkupRate" runat="server" ErrorMessage="Please enter Markup Rate"
                                                                    ControlToValidate="txtMarkupRate" CssClass="errorMsg box" ForeColor=" " Style="margin-top: 2px;
                                                                    margin-left: 4px; width: auto; padding-left: 4px; padding-right: 4px;" Display="Dynamic"
                                                                    ValidationGroup="VGmarkupadd"> <%=objlang.GetLanguageConversion("Please_Enter_Paper_markup_rate")%></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="REVMarkupRate" runat="server" ControlToValidate="txtMarkupRate"
                                                                    Style="margin-top: 2px; width: auto; padding-left: 4px; padding-right: 4px;"
                                                                    Display="Dynamic" CssClass="errorMsg box" ForeColor=" " ValidationGroup="VGmarkupadd"
                                                                    ErrorMessage="Please enter numeric value" ValidationExpression="^([-+]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$"
                                                                    Visible="false"> <%=objlang.GetLanguageConversion("Please_Enter_Numeric_Value")%></asp:RegularExpressionValidator></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="only10px">
                                                </div>
                                                <div align="left" style="width: 500px">
                                                    <div class="SystemMarkup_bglabelEmpty" style="width: 100px">
                                                        &nbsp;</div>
                                                    <%--<div style="float: left">
                                                        <telerik:RadButton EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                                                            CssClass="Button" ID="Button2" runat="server" Style="display: none" Text="Cancel"
                                                            CommandName="Cancel" CausesValidation="false">
                                                        </telerik:RadButton>
                                                    </div>--%>
                                                    <div style="float: left; width: 5px">
                                                        &nbsp;</div>
                                                    <div id="div_btnDelete" style="float: left; display: block">
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnDelete"
                                                            runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" OnClick="btnDelete_OnClick">
                                                        </telerik:RadButton>
                                                    </div>
                                                    <div style="float: left; width: 5px">
                                                        &nbsp;</div>
                                                    <div style="float: left">
                                                        <asp:Button ID="btnSaveMarkup" runat="server" Text="Update" CssClass="button" OnClick="btnSaveMarkup_OnClick"
                                                            ValidationGroup="VGmarkupadd" OnClientClick="javascript:setHdn('edit');" />
                                                        <%-- <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSaveMarkup"
                                                            runat="server" Text="Update" OnClick="btnSaveMarkup_OnClick" ValidationGroup="VGmarkupadd">
                                                        </telerik:RadButton>--%>
                                                    </div>
                                                    <div style="float: left; width: 5px;">
                                                    </div>
                                                    <div style="float: left; padding-left: 5px">
                                                        <%-- <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnAdd" runat="server"
                                                            Text="Save as new" ValidationGroup="VGmarkupadd" OnClick="btnSaveMarkup_OnClick">
                                                        </telerik:RadButton>--%>
                                                        <asp:Button ID="btnAdd" runat="server" Text="Save as new" CssClass="button" OnClick="btnSaveMarkup_OnClick"
                                                            ValidationGroup="VGmarkupadd" OnClientClick="javascript:setHdn('add');" />
                                                    </div>
                                                </div>
                                                <div class="only5px">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=UserID %>';
        var path = "<%=strSitepath %>";
    </script>
    <script type="text/javascript">
        function popup_markup(section) {
            var ddl_Markup = document.getElementById('<%=ddlMarkup.ClientID %>');
            if (ddl_Markup.selectedIndex != 0) {
                window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=markup&pg=" + section + "&page=edit", '', 'width=550px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
            }
            else {
                window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=markup&pg=" + section + "&page=add", '', 'width=550px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
            }
        }
    </script>
    <script type="text/javascript">
        var ddl_Markup = "<%=ddlMarkup.ClientID %>";
        var ddl_Tax = "<%=ddlTax.ClientID %>";
        var txt_MarkupName = "<%=txtMarkupName.ClientID %>";
        var txt_MarkupRate = "<%=txtMarkupRate.ClientID %>";
        var hid_MarkRate = '<%=hid_MarkRate.ClientID %>';

        function ShowMarkup() {
            document.getElementById("<%=btnDelete.ClientID %>").style.display = "none";
            document.getElementById("<%=btnAdd.ClientID %>").style.display = "none";
            if (document.getElementById("divMarkup").style.display == "none") {

                //IEB,on  21.09.2011...
                var divMarkup = document.getElementById("divMarkup")
                if (navigator.appName != "Microsoft Internet Explorer") {
                    setLoadingPositionOfDivMove(divMarkup);
                }
                showDivPopupCenter('divMarkup', '200');
                document.getElementById(ddl_Markup).style.display = "none";
                document.getElementById(ddl_Tax).style.display = "none";
                document.getElementById("<%=txtMarkupName.ClientID %>").focus();
            }
            else {
                document.getElementById("divMarkup").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
                document.getElementById(ddl_Markup).style.display = "block";
                document.getElementById(ddl_Tax).style.display = "block";
            }

            //=== to load the markup values on edit case ===///
            if (document.getElementById(ddl_Markup).selectedIndex != 0) {
                var ddl_Markup_IndexValue = $get(ddl_Markup).selectedIndex;
                var ddl_Markup_Text = $get(ddl_Markup).options[ddl_Markup_IndexValue].text;
                var ddl_Markup_Value = $get(ddl_Markup).options[ddl_Markup_IndexValue].value;
                document.getElementById(txt_MarkupName).value = ddl_Markup_Text;
                document.getElementById(txt_MarkupRate).value = document.getElementById(hid_MarkRate).value;
                document.getElementById("<%=btnDelete.ClientID %>").style.display = "block";
                document.getElementById("<%=btnAdd.ClientID %>").style.display = "block";


            }
            else {
                clearMarkup();
            }

        }
        function clearMarkup() {
            document.getElementById(txt_MarkupName).value = "";
            document.getElementById(txt_MarkupRate).value = "";

            document.getElementById(ddl_Markup).style.display = "none";
            document.getElementById(ddl_Tax).style.display = "none";
        }
        function hideDiv() {
            var txtMarkupName = document.getElementById("<%=txtMarkupName.ClientID %>").value;
            var txtMarkupRate = document.getElementById("<%=txtMarkupRate.ClientID %>").value;
            if (txtMarkupName != '' && txtMarkupRate != '') {
                document.getElementById("divMarkup").style.display = "none";
                document.getElementById("divBackGroundNew").style.display = "none";
                document.getElementById(ddl_Markup).style.display = "block";
                document.getElementById(ddl_Tax).style.display = "block";


            }
        }
        function CloseMarkup() {
            document.getElementById("divMarkup").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            document.getElementById(ddl_Markup).style.display = "block";
            document.getElementById(ddl_Tax).style.display = "block";


        }

        function ClearTextBox() {
            document.getElementById("<%=txtMarkupName.ClientID %>").value = "";
            document.getElementById("<%=txtMarkupRate.ClientID %>").value = "";
            document.getElementById("<%=btnDelete.ClientID %>").style.display = "none";
            document.getElementById("<%=btnAdd.ClientID %>").style.display = "none";
        }

        function ShowPopup() {
            var oWnd = $find("<%=systemMarkup.ClientID%>");
            oWnd.show();
            if (document.getElementById(ddl_Markup).selectedIndex != 0) {
                var ddl_Markup_IndexValue = $get(ddl_Markup).selectedIndex;
                var ddl_Markup_Text = $get(ddl_Markup).options[ddl_Markup_IndexValue].text;
                var ddl_Markup_Value = $get(ddl_Markup).options[ddl_Markup_IndexValue].value;
                document.getElementById(txt_MarkupName).value = ddl_Markup_Text;
                document.getElementById(txt_MarkupRate).value = document.getElementById(hid_MarkRate).value;
                document.getElementById("<%=btnDelete.ClientID %>").style.display = "block";
                document.getElementById("<%=btnAdd.ClientID %>").style.display = "block";
                document.getElementById("<%=RFVMarkupName.ClientID %>").style.display = "none";
                document.getElementById("<%=RFVMarkupRate.ClientID %>").style.display = "none";

            }
            else {
                clearMarkup();
            }
            document.getElementById(txt_MarkupName).focus();
        }
        function setHdn(val) {
            var hid_MarkType = document.getElementById("<%=hid_MarkType.ClientID %>");
            if (val == "add") {
                hid_MarkType.value = "add";
            }
            else {
                var ddl_Markup = document.getElementById('<%=ddlMarkup.ClientID %>');
                if (ddl_Markup.selectedIndex == 0) {
                    hid_MarkType.value = "add";
                }
                else {
                    hid_MarkType.value = "edit";
                }
            }
        }
        function validatemarkup() {
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
