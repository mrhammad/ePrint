<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="guillotine_add.ascx.cs" Inherits="ePrint.usercontrol.settings.guillotine_add" %>



<%--<script src="<%=strSitepath %>js/item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script type="text/javascript" src="<%=strSitepath %>js/commonloading.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var path = "<%=strSitepath %>";
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
</script>
<div align="left" style="width: 100%">
    <div class="navigatorpanel" id="colourPanel" runat="server" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel">
                            
                            </asp:Label>
                        </div>
                        <%--  <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow();" style="color: White;">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="" runat="server" id="Content">
        <div id="">
            <div align="left" style="width: 100%" class="mis_header_panel">
                <div align="center">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <table cellpadding="0px" cellspacing="0px" width="100%" border="0px">
                    <tr>
                        <td align="left" width="45%">
                            <asp:Panel ID="pnlText" runat="server" Visible="false">
                                <div align="left" class="graytext">
                                    <span id="spnnote" runat="server"></span>
                                </div>
                                <div class="only10px">
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <div align="left" id="tabs" style="width: 100%">
                    <div align="left" style="border: solid 0px silver; width: 100%;">
                        <div id="div_Feed_restriction" style="display: block;">
                            <div align="left" style="width: 100%; border: solid 0px blue">
                                <div style="float: left; width: 49%; border: 0px solid black">
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="Label7" runat="server" Text="Name" CssClass="normaltext"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtGuillotineName" onblur="CallonBlur(this.value,'spn_txtGuillotineName');CheckGuillotinePress(this.value);"
                                                runat="server" SkinID="textPad" MaxLength="100" CssClass="textboxnew1"></asp:TextBox>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtGuillotineName" style="display: none; width: auto; float: left">
                                                <%--<div class="RFV_Message">--%>
                                                <div>
                                                    <span id="spnGuillotineName" runat="server" style="float: left; padding-left: 4px;
                                                        padding-right: 4px; width: auto;" class="spanerrorMsg"></span>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtPlantPressCheck" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span id="spnName" runat="server" style="float: left; padding-left: 4px; padding-right: 4px;
                                                        width: auto;"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <script>
                                            //******* funcn to ckech for guillotine duplicacy *********////
                                            function CheckGuillotinePress(val1) {
                                                if (val1 != '') {
                                                    var compID = '<%=CompanyID %>';
                                                    var id = '<%=GuillotineID %>';
                                                    var val = compID + "±" + val1 + "±" + "guillotine" + "±" + id;
                                                    if ("<%= ReqType%>" != "moreplant") {
                                                        PageMethods.GetGuillotinePress(val, ShowMsgGuillotine, ShowMsg_Failure);
                                                    }
                                                }
                                            }
                                            function ShowMsg_Failure(error) { }
                                            function ShowMsgGuillotine(result) {
                                                //alert(result);
                                                $get('spn_txtPlantPressCheck').style.display = "none";
                                                if (result == -1) {
                                                    $get('spn_txtPlantPressCheck').style.display = "block";
                                                    chakWhat = false;
                                                }
                                            }
                                            function RemoveOnlur() {
                                                document.getElementById("<%=txtGuillotineName.ClientID %>").removeAttribute("onblur", 1);
                                            }
                                            //*******End of funcn to ckech for guillotine duplicacy*********////
                                        </script>
                                        <div class="bglabel" style="height: 84px">
                                            <asp:Label ID="Label10" runat="server" Text="Description" CssClass="normaltext"></asp:Label></div>
                                        <div class="box">
                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="multiLine" SkinID="textPad"
                                                Height="80px" Rows="2" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length')"
                                                onblur="CheckLength('spn_txtDescription_length');" CssClass="textboxnew1"></asp:TextBox>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtDescription_length" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                        <%=objlang.GetValueOnLang("Max.length of textbox is")%>: 3000</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- <div class="bglabel" style="height: 84px">
                                            <asp:label id="label13" runat="server" text="guillotine type" cssclass="normaltext"></asp:label></div>
                                        <div class="box">
                                            <asp:dropdownlist id="ddlguillotinetype" runat="server" width="99%" cssclass="normaltext">
                                                 <asp:listitem text="standard" value="standard"></asp:listitem>
                                                 <asp:listitem text="advanced" value="advanced"></asp:listitem>
                                            </asp:dropdownlist>
                                            <div style="clear: both">
                                            </div>
                                        </div>
                                    </div>--%>
                                    <div align="left" runat="server" >
                                            <div class="bglabel" >
                                                <asp:Label ID="label13" runat="server" Text="Guillotine Type" CssClass="normalText"></asp:Label></div>
                                            <div class="ddlsetting" style="padding-left: 5px">
                                                <asp:DropDownList ID="ddlguillotinetype" runat="server" Width="165px">
                                                <asp:listitem text="Standard" value="Standard"></asp:listitem>
                                                 <asp:listitem text="Advanced" value="Advanced"></asp:listitem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    <%-- <div align="left" runat="server" id="div_AccountCode">
                                            <div class="bglabel" >
                                                <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label></div>
                                            <div class="ddlsetting" style="padding-left: 5px">
                                                <asp:DropDownList ID="ddlAccountCode" runat="server" Width="150px">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hdnAccountCode" />--%>
                                    <div class="only10px">
                                    </div>
                                    <div align="left">
                                        <div style="float: left; width: 30%">
                                            <span class="HeaderText">
                                                <%=objlang.GetLanguageConversion("Stock_Feed_Restrictions")%>
                                            </span>
                                        </div>
                                        <div class="box" align="left">
                                            <div style="float: left; width: 22%;">
                                                <%=objlang.GetLanguageConversion("Height")%>
                                            </div>
                                            <div style="float: left; width: 30%; padding-left: 9px;" align="left">
                                                <%=objlang.GetLanguageConversion("Width")%>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-top: 5px; clear: both">
                                    </div>
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="Label8" runat="server" Text="Minimum Sheet Size for <br/> the plant"
                                                CssClass="normalText"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtMinimumSheetHeight" Style="text-align: right;" onblur="javascript:CheckDecimalPlus(this.value,'spn_MinimumHeightWidth','spn_MinimumHeightWidth_number','yes');CallonBlur(this.value,'spn_MinimumHeightWidth')"
                                                    runat="server" Width="46px" SkinID="textPad" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label
                                                        ID="lblMinSheetHeight" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label></div>
                                            <div style="float: left; margin-left: 5px;">
                                                <asp:TextBox ID="txtMinimumSheetWidth" Style="text-align: right;" onblur="javascript:CheckDecimalPlus(this.value,'spn_MinimumHeightWidth','spn_MinimumHeightWidth_number','yes');CallonBlur(this.value,'spn_MinimumHeightWidth')"
                                                    runat="server" Width="46px" SkinID="textPad" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label
                                                        ID="lblMinSheetWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label></div>
                                            <div align="left">
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MinimumHeightWidth" style="display: none; width: auto; float: left">
                                                    <%--<div class="RFV_Message">--%>
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                            <%=objlang.GetLanguageConversion("Please_Enter_Min_Sheet_Size")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MinimumHeightWidth_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="Label11" runat="server" Text="Maximum Sheet Size for <br/> the plant"
                                                CssClass="normaltext"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtMaximumSheetHeight" Style="text-align: right;" onblur="javascript:CheckDecimalPlus(this.value,'spn_MaximumHeightWidth','spn_MaximumHeightWidth_number','yes');CallonBlur(this.value,'spn_MaximumHeightWidth')"
                                                    runat="server" Width="46px" SkinID="textPad" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label
                                                        ID="lblMaxSheetHeight" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label></div>
                                            <div style="float: left; margin-left: 5px;">
                                                <asp:TextBox ID="txtMaximumSheetWidth" Style="text-align: right;" onblur="javascript:CheckDecimalPlus(this.value,'spn_MaximumHeightWidth','spn_MaximumHeightWidth_number','yes');CallonBlur(this.value,'spn_MaximumHeightWidth')"
                                                    runat="server" Width="46px" SkinID="textPad" MaxLength="8"></asp:TextBox>&nbsp;<asp:Label
                                                        ID="lblMaxSheetWidth" runat="server" CssClass="normalText"><%=PaperMeasure %></asp:Label></div>
                                            <div align="left">
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MaximumHeightWidth" style="display: none; width: auto; float: left">
                                                    <%-- <div class="RFV_Message">--%>
                                                    <div>
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                            <%=objlang.GetLanguageConversion("Please_Enter_Max_Sheet_Size")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_MaximumHeightWidth_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="Label12" runat="server" Text="Maximum Sheet Weight" CssClass="normaltext"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtMaximumSheetWeight" Style="text-align: right;" runat="server"
                                                    Width="46px" SkinID="textPad" onblur="javascript:CheckDecimalPlus(this.value,'spn_txtMaximumSheetWeight','spn_txtMaximumSheetWeight_number','yes');CallonBlur(this.value,'spn_txtMaximumSheetWeight')"
                                                    MaxLength="8"></asp:TextBox>&nbsp;<asp:Label ID="lblMaxSheetWeight" runat="server"
                                                        CssClass="normalText" Style="white-space: nowrap"><%=Weight %></asp:Label></div>
                                            <div align="left">
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtMaximumSheetWeight" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetValueOnLang("Please enter Max. Sheet Weight")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtMaximumSheetWeight_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="float: left; width: 49%; border: 0px solid">
                                    <div class="header" style="padding-top: 0px">
                                        <span class="HeaderText">
                                            <%=objlang.GetLanguageConversion("Plant_Charges")%>
                                        </span>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel">
                                            <%=objlang.GetLanguageConversion("SetUp_Charge")%>
                                            (<%=comm.GetCurrencyinRequiredFormate("", true)%>) <span style="color: Red">*</span>
                                        </div>
                                        <div class="box" unselectable="on" atomicselection="true">
                                            <asp:TextBox ID="txtSetupCharge" runat="server" SkinID="textPad" MaxLength="20" Style="text-align: right"
                                                onblur="CallonBlur(this.value,'spn_txtSetupCharge');"></asp:TextBox>
                                            <div align="left">
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtSetupCharge" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetLanguageConversion("Please_Enter_Setup_Charge")%></span>
                                                    </div>
                                                </div>
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtSetupCharge_number" style="display: none; width: auto; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objlang.GetLanguageConversion("Cost_Per_Cut")%>(<%=comm.GetCurrencyinRequiredFormate("", true)%>)
                                            </div>
                                            <div class="box" unselectable="on" atomicselection="true">
                                                <asp:TextBox ID="txtCostperCut" runat="server" SkinID="textPad" MaxLength="20" Style="text-align: right"
                                                    onblur=""></asp:TextBox>
                                                <span id="spn_txtCostperCut_number" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                    padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <asp:Panel ID="pnlTrim" Visible="true" runat="server">
                                            <div align="left">
                                                <div class="bglabel">
                                                    <%=objlang.GetLanguageConversion("Select_by_Default_On_Estimates")%>
                                                </div>
                                                <div class="box" unselectable="on" atomicselection="true">
                                                    <asp:CheckBox ID="chk_First_trim" runat="server" Text="First Trim" />
                                                    <asp:CheckBox ID="chk_Second_trim" runat="server" Text="Second Trim" />
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div align="left">
                                            <div class="bglabel">
                                                <%--  <%=objlang.GetValueOnLang("Minimum Running Charge")%> By Jagat On 01/Aug/2012  --%>
                                                <asp:Label ID="Label19" runat="server" CssClass="normaltext"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtMinRunningCharge" runat="server" SkinID="textPad" MaxLength="20"
                                                    Style="text-align: right" onblur=""></asp:TextBox>
                                                <span id="spn_txtMinRunningCharge_number" class="spanerrorMsg" style="display: none;
                                                    padding-left: 4px; padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span class="normaltext">
                                                    <%=objlang.GetLanguageConversion("Markup")%>(%)</span>
                                            </div>
                                            <div class="box" style="width: 9%">
                                                <asp:TextBox ID="txtMarkUp" runat="server" SkinID="textPad" MaxLength="20" Style="text-align: right"
                                                    onblur="AllowNumber(this,this.value);"></asp:TextBox>
                                                <span id="spn_txtMarkUp_number" class="spanerrorMsg" style="display: none; padding-left: 4px;
                                                    padding-right: 4px; width: auto;">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <div class="only10px">
                                        </div>
                                        <div style="padding-top: 0px;padding-bottom:5px;">
                                            <span class="HeaderText">
                                                <%=objlang.GetLanguageConversion("Plant_Calculation")%>
                                            </span>
                                             <%--   <asp:DropDownList ID="ddlCalculationType" runat="server" onchange="onCalculationTypeChange(this);" style="margin-left:88px" Width="165px">
                                                <asp:listitem text="Weight" value="Weight"></asp:listitem>
                                                 <asp:listitem text="Caliper" value="Caliper"></asp:listitem>
                                                </asp:DropDownList>--%>
                                        </div>
                                           <div align="left">
                                            <div class="bglabel">
                                                <span class="normaltext">
                                                    <%=objlang.GetLanguageConversion("Calculation_Type")%></span>
                                            </div>
                                            <div class="box" style="width: 9%">
                                                <asp:DropDownList ID="ddlCalculationType" runat="server" onchange="onCalculationTypeChange(this);" Width="165px">
                                                    <asp:listitem text="Weight" value="Weight"></asp:listitem>
                                                    <asp:listitem text="Caliper" value="Caliper"></asp:listitem>
                                                </asp:DropDownList>                                            </div>
                                        </div>
                                        <asp:Panel ID="pnlPlantCal" style="display:block" runat="server">
                                            
                                            <div align="left">
                                                <div align="left">
                                                    <div class="bglabel" runat="server" id="stock_weight">
                                                        <%=objlang.GetLanguageConversion("Stock_Weight")%>
                                                        (<%=Weight %>)
                                                    </div>
                                                      <div class="bglabel" runat="server" style="display:none" id="stock_caliper">
                                                        <%=objlang.GetLanguageConversion("Stock_Caliper")%>
                                                        (<%=Points %>)
                                                    </div>
                                                    <div class="box">
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtPaperWeight1" onblur="javascript:CheckDecimalPlus(this.value,'spn_PaperWeight','spn_PaperWeight_number','yes');"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtPaperWeight2" onblur="javascript:CheckDecimalPlus(this.value,'spn_PaperWeight','spn_PaperWeight_number','yes');"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtPaperWeight3" onblur="javascript:CheckDecimalPlus(this.value,'spn_PaperWeight','spn_PaperWeight_number','yes');"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div align="left">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div id="spn_PaperWeight" style="display: none; width: auto; float: left">
                                                                <div class="RFV_Message">
                                                                    <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                                        <%=objlang.GetLanguageConversion("Please_Enter_Paper_Weight")%>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div id="spn_PaperWeight_number" style="display: none; width: auto; float: left">
                                                                <div class="RFV_Message">
                                                                    <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel" runat="server" id="max_throat_weight">
                                                        <%=objlang.GetLanguageConversion("Max_No_Of_Sheets_That_Fit_In_The_Throat_For_The_Above_Stock_Weight")%>
                                                    </div>
                                                      <div class="bglabel" runat="server" style="display:none" id="max_throat_caliper">
                                                        <%=objlang.GetLanguageConversion("Max_No_Of_Sheets_That_Fit_In_The_Throat_For_The_Above_Stock_Caliper")%>
                                                    </div>
                                                    <div class="box" style="margin-top: 5px;">
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtMaxSheets1" onblur="javascript:CheckDecimalPlus(this.value,'spn_MaxSheets','spn_MaxSheets_number','yes');"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtMaxSheets2" onblur="javascript:CheckDecimalPlus(this.value,'spn_MaxSheets','spn_MaxSheets_number','yes');;"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div style="float: left; width: 21%;">
                                                            <asp:TextBox ID="txtMaxSheets3" onblur="javascript:CheckDecimalPlus(this.value,'spn_MaxSheets','spn_MaxSheets_number','yes');"
                                                                runat="server" SkinID="textPad" Width="46px" MaxLength="8" Style="text-align: right"></asp:TextBox>
                                                        </div>
                                                        <div align="left">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div id="spn_MaxSheets" style="display: none; width: auto; float: left">
                                                                <%--<div class="RFV_Message">--%>
                                                                <div>
                                                                    <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;" class="spanerrorMsg">
                                                                        <%=objlang.GetLanguageConversion("Please_Enter_Max_No_Of_Sheets")%></span>
                                                                </div>
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                            <div id="spn_MaxSheets_number" style="display: none; width: auto; float: left">
                                                                <div class="RFV_Message">
                                                                    <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                        <asp:Panel ID="pnlItemCut" Visible="false" runat="server">
                                            <div align="left">
                                                <div class="bglabel">
                                                    <span class="normaltext">
                                                        <%=objlang.GetValueOnLang("In this instance eprint will treat each printed item as an individual item involving")%></span>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddlItemCut" CssClass="normalText" runat="server" Width="50px">
                                                    </asp:DropDownList>
                                                    <span class="normaltext">
                                                        <%=objlang.GetValueOnLang("number of cuts per item")%></span>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left">
                                        <%--<div style="float: left; border: 0px solid">
                                            &nbsp;
                                        </div>--%>
                                        <div class="bglabel" style="visibility: hidden">
                                            &nbsp;
                                        </div>
                                        <div class="box">
                                            <div style="float: left;">

                                                <div style="float: left;">
                                                    <div id="div_btnguilldelete" style="display: block">
                                                        <asp:Button ID="btnGuillotineDelete" CssClass="button" runat="server" Text="Delete"
                                                            CausesValidation="false" Visible="false" OnClick="OnClick_btnGuillotineDelete"
                                                            OnClientClick="javascript:var a=window.confirm('Are you sure you want to delete ?');if(a)loadingimage(this.id,'div_btnguldeleteprocess');return a;" />
                                                    </div>
                                                    <div id="div_btnguldeleteprocess" class="button" align="center" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <%--<div style="float: left">
                                                    <div id="div_btnDigitalPressCancel" style="display: block">
                                                        <asp:Button ID="btnDigitalPressCancel" CssClass="button" runat="server" Text="Cancel"
                                                            OnClick="OnClick_btnDigitalPressCancel" CausesValidation="false" />
                                                        <%--BY VINAY OnClientClick="javascript:return cancelClick(path+'settings/guillotine_view.aspx');RemoveOnlur();return true;"--%>
                                                    <%--</div>
                                                    <div id="div_btnDigitalPressCancelprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>--%>

                                                <div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>

                                                <div style="float: left">
                                                    <div id="div_btnDigitalPressCancel" style="display: block">
                                                        <asp:Button ID="btnDigitalPressCancel" CssClass="button" runat="server" Text="Cancel"
                                                            OnClick="OnClick_btnDigitalPressCancel" CausesValidation="false" />
                                                        
                                                    </div>
                                                    <div id="div_btnDigitalPressCancelprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>

                                                <div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>

                                                <div style="float: left">
                                                    <div id="div_btnguillotine" style="display: block">
                                                        <asp:Button ID="btnGuillotineAdd" CssClass="button" runat="server" Text="Save" CausesValidation="true"
                                                            OnClick="OnClick_btnGuillotineAdd" OnClientClick="javascript:var a=checkValidation();if(a!=false)loadingimage(this.id,'div_btnguillotineprocess');return a;" />
                                                    </div>
                                                    <div id="div_btnguillotineprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                    <%--<asp:Button ID="Button5" CssClass="button" Visible="false" runat="server" Text="Next"
                                                        Width="65px" OnClientClick="javascript:changeCss('spn_2');return false;" />--%>
                                                </div>

                                                <%--<div style="float: left;">
                                                    <div id="div_btnguilldelete" style="display: block">
                                                        <asp:Button ID="btnGuillotineDelete" CssClass="button" runat="server" Text="Delete"
                                                            CausesValidation="false" Visible="false" OnClick="OnClick_btnGuillotineDelete"
                                                            OnClientClick="javascript:var a=window.confirm('Are you sure you want to delete ?');if(a)loadingimage(this.id,'div_btnguldeleteprocess');return a;" />
                                                    </div>
                                                    <div id="div_btnguldeleteprocess" class="button" align="center" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>--%>

                                            </div>
                                            <%--<div style="float: left">
                                                <asp:Button ID="Button6" CssClass="button" runat="server" Text="Save" Width="65px"
                                                    OnClientClick="javascript:return false;" /></div>--%>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                            </div>
                            <div class="only10px">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
<script>
   
function onCalculationTypeChange(dropdown) {
debugger
        var selectedValue = dropdown.value;
        var panel = document.getElementById('<%= pnlPlantCal.ClientID %>');
<%--        var panel1 = document.getElementById('<%= pnlPlantCal1.ClientID %>');--%>
<%--        var calculationType = document.getElementById('<%= CalculationType.ClientID %>');--%>
    var stock_weight = document.getElementById('<%= stock_weight.ClientID %>');
    var stock_caliper = document.getElementById('<%= stock_caliper.ClientID %>');
    var max_throat_weight = document.getElementById('<%= max_throat_weight.ClientID %>');
    var max_throat_caliper = document.getElementById('<%= max_throat_caliper.ClientID %>');

    

        if (selectedValue === "Weight") {
            //panel.style.display = "block";
            //panel1.style.display = "none";
            //calculationType.value = "Weight";
            stock_weight.style.display = "block"
            max_throat_weight.style.display = "block";

            stock_caliper.style.display = "none"
            max_throat_caliper.style.display = "none";

        } else {
            //panel.style.display = "none";
            //panel1.style.display = "block";
            //calculationType.value = "Caliper";
            stock_weight.style.display = "none"
            max_throat_weight.style.display = "none";

            stock_caliper.style.display = "block"
            max_throat_caliper.style.display = "block";
        }
    }
    function checkValidation() {
        var IsCorrect = true;
        var txtGuillotineName = document.getElementById("<%=txtGuillotineName.ClientID %>").value;
        if (CheckStringMandatory(txtGuillotineName, 'spn_txtGuillotineName')) {
            IsCorrect = false;
        }
        var txtMinimumSheetHeight = document.getElementById("<%=txtMinimumSheetHeight.ClientID %>").value;
        var txtMinimumSheetWidth = document.getElementById("<%=txtMinimumSheetWidth.ClientID %>").value;

        if (!CheckDecimalPlus(txtMinimumSheetHeight, 'spn_MinimumHeightWidth', 'spn_MinimumHeightWidth_number', 'yes')
           || !CheckDecimalPlus(txtMinimumSheetWidth, 'spn_MinimumHeightWidth', 'spn_MinimumHeightWidth_number', 'yes')) {
            IsCorrect = false;
        }

        var txtMaximumSheetHeight = document.getElementById("<%=txtMaximumSheetHeight.ClientID %>").value;
        var txtMaximumSheetWidth = document.getElementById("<%=txtMaximumSheetWidth.ClientID %>").value;
        if (!CheckDecimalPlus(txtMaximumSheetHeight, 'spn_MaximumHeightWidth', 'spn_MaximumHeightWidth_number', 'yes')
           || !CheckDecimalPlus(txtMaximumSheetWidth, 'spn_MaximumHeightWidth', 'spn_MaximumHeightWidth_number', 'yes')) {
            IsCorrect = false;
        }

        var txtMaximumSheetWeight = document.getElementById("<%=txtMaximumSheetWeight.ClientID %>").value;
        if (!CheckDecimalPlus(txtMaximumSheetWeight, 'spn_txtMaximumSheetWeight', 'spn_txtMaximumSheetWeight_number', 'Yes')) {
            IsCorrect = false;
        }
        var isLarge = '<%=IsForLarge%>'

        if (isLarge != 'yes') {
            var txtPaperWeight1 = document.getElementById("<%=txtPaperWeight1.ClientID %>").value;
            var txtPaperWeight2 = document.getElementById("<%=txtPaperWeight2.ClientID %>").value;
            var txtPaperWeight3 = document.getElementById("<%=txtPaperWeight3.ClientID %>").value;


            if (!CheckDecimalPlus(txtPaperWeight1, 'spn_PaperWeight', 'spn_PaperWeight_number', 'yes') || !CheckDecimalPlus(txtPaperWeight2, 'spn_PaperWeight', 'spn_PaperWeight_number', 'yes')
                || !CheckDecimalPlus(txtPaperWeight3, 'spn_PaperWeight', 'spn_PaperWeight_number', 'yes')) {
                IsCorrect = false;
            }

            var txtMaxSheets1 = document.getElementById("<%=txtMaxSheets1.ClientID %>").value;
            var txtMaxSheets2 = document.getElementById("<%=txtMaxSheets2.ClientID %>").value;
            var txtMaxSheets3 = document.getElementById("<%=txtMaxSheets3.ClientID %>").value;


            if (!CheckDecimalPlus(txtMaxSheets1, 'spn_MaxSheets', 'spn_MaxSheets_number', 'yes') || !CheckDecimalPlus(txtMaxSheets2, 'spn_MaxSheets', 'spn_MaxSheets_number', 'yes')
                || !CheckDecimalPlus(txtMaxSheets3, 'spn_MaxSheets', 'spn_MaxSheets_number', 'yes')) {
                IsCorrect = false;
            }
        }
        var txtSetupChargeID = document.getElementById("<%=txtSetupCharge.ClientID %>");
        var txtSetupCharge = trim12(txtSetupChargeID.value);
        if (txtSetupCharge == '') {
            document.getElementById("spn_txtSetupCharge").style.display = "block";
            IsCorrect = false;
        }

        if (IsCorrect) {
            document.getElementById('spn_MaximumHeightWidth').style.display = 'none';
            document.getElementById('spn_MinimumHeightWidth').style.display = 'none';
        }
        else {
            return false;
        }

    }

    function CheckLength(id) {
        document.getElementById(id).style.display = 'none';
    }
    
</script>
<asp:Panel ID="pnlGuillotineDisplay" runat="server" Visible="false">
    <script>
        function dispGuillotine() {
            document.getElementById("div_GuillotineAdd").style.display = "block";
            document.getElementById("div_plant_selctor").style.display = "none";
        }
        dispGuillotine()
    </script>
</asp:Panel>
<asp:Panel ID="pnlclosepopup" runat="server" Visible="false">
    <script type="text/javascript">
        var Guillotine_ID = '<%=GuillotineID %>';
        var GuillotineName = document.getElementById("<%=txtGuillotineName.ClientID %>");
        var FirstTrim = document.getElementById("<%=chk_First_trim.ClientID %>");
        var SecondTrim = document.getElementById("<%=chk_Second_trim.ClientID %>");
        function closepopup() {

            window.parent.SendGuillotineIDandName(Guillotine_ID, GuillotineName.value, FirstTrim.checked, SecondTrim.checked);
            setTimeout("TakeOut()", 700);
            return false;
        }
        function TakeOut() {
            window.close();
        }
        closepopup();
    </script>
</asp:Panel>
