<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="othercost_selector_new.ascx.cs" Inherits="ePrint.usercontrol.Item.othercost_selector_new" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'"></script>
<div>
    <div id="ds00" style="display: none;">
    </div>
    <div id="ds01" style="display: block;">
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_Load" class="loading_new">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script>
        document.getElementById("ds01").style.display = "block";
        var CompanyID = '<%=CompanyID%>';
        var UserID = '<%=UserID%>';
        var pgtype = '<%=pg %>';
        var QtyNo = '<%=QtyNo %>';
    </script>
    <script type="text/javascript">
        setLoadingPositionOfDivMove(div_Load);
    </script>
    <div>
        <div id="padding">
            <div align="left" style="width: 100%">
                <div align="left" style="width: 100%">
                    <div style="float: left; width: 65%">
                        <asp:Label ID="lblCostName" runat="server" CssClass="HeaderText"></asp:Label>
                    </div>
                    <div style="float: left">
                        <span class="HeaderText"><%=objLanguage.GetLanguageConversion("Minimum_Charge")%>&nbsp;=&nbsp;</span>
                        <asp:Label ID="lblMinimumCharge" runat="server" CssClass="HeaderText">0</asp:Label>
                    </div>
                </div>
                <div class="only5px">
                    <hr width="100%" size="0" color="silver" />
                </div>
                <div align="left" style="width: 100%;">
                    <div align="left">
                        <div style="float: left; width: 15%; padding: 5px;">
                            <span class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Description") %></span>
                        </div>
                        <div id="div_Description" runat="server" style="float: left; width: 80%">
                            <asp:TextBox ID="txtDescription" runat="server" SkinID="textPad" Width="100%" Height="70px"
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div style="float: left; width: 49%">
                        <div align="left">
                            <asp:Button ID="btnAdvanced" runat="server" CssClass="button" Text="Advanced «" Width="82px"
                                OnClientClick="javascript:ShowHideAdvanceDiv();return false;extractButton();" />
                        </div>
                        <div id="div_Advance_TimeBased" align="left" style="width: 100%; display: none">
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Runs_Required") %></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtRunsRequired" runat="server" SkinID="textPad" Width="100px" MaxLength="10"
                                        onblur="SetNumber(this,this.value);CalSetUpCost();MakePrice2Decimal(this);">0</asp:TextBox>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 100%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Speed") %>
                                        @
                                        <asp:Label ID="lblSpeed" runat="server" CssClass="normalText">0</asp:Label>
                                        <%=objLanguage.GetLanguageConversion("Per_Hour") %></span>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 27%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Total_Time") %></span>
                                </div>
                                <div class="box">
                                    &nbsp;&nbsp;<asp:Label ID="lblTotalTime" runat="server" CssClass="normalText">0</asp:Label>&nbsp;<%=objLanguage.GetLanguageConversion("mins") %>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 27%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Cost") %></span>
                                </div>
                                <div class="box">
                                    <%=OBjJava.GetCurrencyinRequiredFormate("",true) %>&nbsp;<asp:Label ID="lblCost"
                                        runat="server" CssClass="normalText">0.00</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div id="div_Advance_QuantityBased" align="left" style="width: 100%; display: none">
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Set_up_Time")%></span>
                                </div>
                                <div class="box" style="width: 200px">
                                    <asp:TextBox ID="txtQtySetUpTime" runat="server" SkinID="textPad" Width="100px" MaxLength="10"
                                        onblur="todecimal_function(this,this.value);SetNumber(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;mins&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %><asp:Label
                                            ID="lblQtySetUpCost" runat="server" CssClass="normalText">20.00</asp:Label>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Hourly_Rate")%></span>
                                    <%--Hourly Rate--%>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtQtyHourlyRate" runat="server" SkinID="textPad" Width="100px"
                                        MaxLength="10" onblur="todecimal_function(this,this.value);SetNumber(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Total_time")%></span>
                                </div>
                                <div class="box">
                                    <asp:Label ID="lblQtyTotalTime" runat="server" CssClass="normalText">0</asp:Label>&nbsp;mins
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_FormulaBased" style="float: left; width: 100%; display: none">
                        <div align="left">
                            <div style="float: left; width: 15%; padding: 5px; clear: left">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Cost_Formula")%></span>
                            </div>
                            <div class="box">
                                <div>
                                    <asp:TextBox ID="txtFormula" runat="server" SkinID="textPad" Width="450px" Height="70px"
                                        TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div id="AvtualQtyValue" style="display: none; vertical-align: middle; z-index: 100; width: 100%; float: left" align="center">
                            </div>
                        </div>




                        <div align="left">
                            <div style="float: left; width: 15%; padding: 5px; clear: left">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Quantity_With_Actuals")%></span>
                            </div>
                            <div id="WithActuals0" class="box" style="width: 237px; border: 0px solid red; float: left">
                                <asp:TextBox ID="txtWithActuals" runat="server" SkinID="textPad" Width="210px" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="javascript:CalculateSellingPrice();"></asp:TextBox>
                                <div id="div_Matrixbtn1" style="margin-top: -2px; float: right; cursor: hand; cursor: pointer; display: none">
                                    <img src="<%=strImagepath%>matrix.jpg" alt="Click here to open Matrix" title="Click here to open Matrix"
                                        onclick="javascript:ShowHideMatrixTable('show',0);" style="margin-top: 2px" />
                                </div>
                            </div>
                            <div id="WithActuals1" class="box" style="width: 237px; display: none; float: left">
                                <asp:TextBox ID="txtWithActuals1" runat="server" SkinID="textPad" Width="210px" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="javascript:CalculateSellingPrice();"></asp:TextBox>
                                <div id="div_Matrixbtn2" style="margin-top: -2px; float: right; cursor: hand; cursor: pointer; display: none">
                                    <img src="<%=strImagepath%>matrix.jpg" alt="Click here to open Matrix" title="Click here to open Matrix"
                                        onclick="javascript:ShowHideMatrixTable('show',1);" style="margin-top: 2px" />
                                </div>
                            </div>
                            <div id="WithActuals2" class="box" style="width: 237px; display: none; float: left">
                                <asp:TextBox ID="txtWithActuals2" runat="server" SkinID="textPad" Width="210px" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="javascript:CalculateSellingPrice();"></asp:TextBox>
                                <div id="div_Matrixbtn3" style="margin-top: -2px; float: right; cursor: hand; cursor: pointer; display: none">
                                    <img src="<%=strImagepath%>matrix.jpg" alt="Click here to open Matrix" title="Click here to open Matrix"
                                        onclick="javascript:ShowHideMatrixTable('show',2);" style="margin-top: 2px" />
                                </div>
                            </div>
                            <div id="WithActuals3" class="box" style="width: 237px; display: none; float: left">
                                <asp:TextBox ID="txtWithActuals3" runat="server" SkinID="textPad" Width="210px" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="javascript:CalculateSellingPrice();"></asp:TextBox>
                                <div id="div_Matrixbtn4" style="margin-top: -2px; float: right; cursor: hand; cursor: pointer; display: none">
                                    <img src="<%=strImagepath%>matrix.jpg" alt="Click here to open Matrix" title="Click here to open Matrix"
                                        onclick="javascript:ShowHideMatrixTable('show',3);" style="margin-top: 2px" />
                                </div>
                            </div>
                            <div id="div_Matrixbtn" style="float: left; padding-top: 3px; display: none">
                                <asp:Button ID="btnMatrix" runat="server" Text="Matrix" CssClass="button" Width="65px"
                                    OnClientClick="javascript:ShowHideMatrixTable('show');return false" />
                            </div>
                        </div>
                        <div align="left">
                            <div style="float: left; width: 15%; padding: 5px; clear: left">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Cost")%></span>
                            </div>
                            <div id="FormulaCost0" class="box" style="float: left; border: solid 0px red; width: 200px">
                                <asp:TextBox ID="txtFormulaCost" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    ReadOnly="true">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %><%--onkeyup="SetNumber(this,this.value);CalculateSellingPrice();"--%>
                            </div>
                            <div id="FormulaCost1" class="box" style="padding-left: 40px; float: left; width: 200px; display: none;">
                                <asp:TextBox ID="txtFormulaCost1" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                            <div id="FormulaCost2" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaCost2" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                            <div id="FormulaCost3" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaCost3" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                        </div>
                        <div align="left">
                            <div style="float: left; width: 15%; padding: 5px; clear: left">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Markup")%></span>
                            </div>
                            <div id="FormulaProfit0" class="box" style="border: 0px solid; width: 200px;">
                                <asp:TextBox ID="txtFormulaProfit" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" onkeyup="javascript:CalculateSellingPrice();" onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;%
                            </div>
                            <div id="FormulaProfit1" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaProfit1" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;%
                            </div>
                            <div id="FormulaProfit2" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaProfit2" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;%
                            </div>
                            <div id="FormulaProfit3" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaProfit3" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" onkeyup="javascript:CalculateSellingPrice();"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;%
                            </div>
                        </div>
                        <div align="left">
                            <div style="float: left; width: 15%; padding: 5px; clear: left">
                                <span class="HeaderText">
                                    <%=objLanguage.GetLanguageConversion("Selling_Price")%></span>
                            </div>
                            <div id="FormulaSellingPrice0" class="box" style="float: left; width: 200px">
                                <asp:TextBox ID="txtFormulaSellingPrice" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" ReadOnly="true">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %><%--onblur="SetNumber(this,this.value);"--%>
                            </div>
                            <div id="FormulaSellingPrice1" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaSellingPrice1" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" ReadOnly="true">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                            <div id="FormulaSellingPrice2" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaSellingPrice2" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" ReadOnly="true">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                            <div id="FormulaSellingPrice3" class="box" style="padding-left: 40px; float: left; width: 200px; display: none">
                                <asp:TextBox ID="txtFormulaSellingPrice3" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="10" Style="text-align: right" ReadOnly="true">0.00</asp:TextBox>&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 49%">
                        <div id="div_TimeBased" align="left" style="width: 100%; display: none">
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Per_Hour_Cost")%></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtHourlyRate" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                        onblur="AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);MakePrice2Decimal(this);"
                                        onkeyup="CalculateSellingPrice();">0.00</asp:TextBox>
                                    <%--SetNumber(this,this.value);--%>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Make_Ready_Time")%></span>
                                </div>
                                <div class="box" style="width: 200px">
                                    <asp:TextBox ID="txtSetUpTime" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                        onblur="todecimal_function(this,this.value);SetNumber(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;mins&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %><asp:Label
                                            ID="lblSetUpCost" runat="server" CssClass="normalText">0.00</asp:Label>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Hours")%></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtHours" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                        onkeyup="SetNumber(this,this.value);CalculateSellingPrice();" onblur="MakePrice2Decimal(this);todecimal_function(this);">0</asp:TextBox>
                                </div>
                            </div>
                            <div align="left" id="div_Passes" style="display: none">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Passes")%></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtPasses" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                        onblur="CalculateSellingPrice();">1.00</asp:TextBox>
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Markup")%></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtProfit" runat="server" SkinID="textPad" Width="100px" MaxLength="6"
                                        onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>&nbsp;%
                                </div>
                            </div>
                            <div align="left">
                                <div style="float: left; width: 30%; padding: 5px; clear: left">
                                    <span class="HeaderText">
                                        <%=objLanguage.GetLanguageConversion("Selling_Price")%>
                                        &nbsp;
                                        <%=OBjJava.GetCurrencyinRequiredFormate("",true) %></span>
                                </div>
                                <div class="box">
                                    <asp:TextBox ID="txtSellingPrice" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                        ReadOnly="true">0.00</asp:TextBox>
                                </div>
                            </div>
                            <asp:HiddenField ID="hid_HourlySpeed" runat="server" Value="0" />
                        </div>
                    </div>
                </div>
                <div id="div_QuantityBased" align="left" style="width: 100%; display: none">
                    <div align="left" style="border: 0px solid;">
                        <div style="float: left; width: 10%; padding: 5px; clear: left">
                            <span class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Unit_Rate")%></span>
                        </div>
                        <div class="box">
                            <div style="float: left; padding-right: 5px" id="div_unitrate0">
                                <asp:TextBox ID="txtQtyUnitRate" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);MakePrice2Decimal(this);"
                                    onkeyup="CalculateSellingPrice();">0.00</asp:TextBox>
                                <%-- SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_unitrate1">
                                <asp:TextBox ID="txtQtyUnitRate1" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);MakePrice2Decimal(this);"
                                    onkeyup="CalculateSellingPrice();">0.00</asp:TextBox>
                                <%-- SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_unitrate2">
                                <asp:TextBox ID="txtQtyUnitRate2" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);MakePrice2Decimal(this);"
                                    onkeyup="CalculateSellingPrice();">0.00</asp:TextBox>
                                <%-- SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; display: none" id="div_unitrate3">
                                <asp:TextBox ID="txtQtyUnitRate3" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="AllowNumber_WithNegative(this,this.value);todecimal_function(this,this.value);MakePrice2Decimal(this);"
                                    onkeyup="CalculateSellingPrice();">0.00</asp:TextBox>
                                <%-- SetNumber(this,this.value);--%>
                            </div>
                        </div>
                    </div>
                    <div align="left">
                        <div style="float: left; width: 10%; padding: 5px; clear: left">
                            <span class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Quantity")%></span>
                        </div>
                        <div class="box">
                            <div style="float: left; padding-right: 5px" id="div_qtytext0">
                                <asp:TextBox ID="txtQtyQuantity" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onkeyup="SetNumber(this,this.value);CalculateSellingPrice();ToInteger(this,this.value);">0</asp:TextBox>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtytext1">
                                <asp:TextBox ID="txtQtyQuantity1" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onkeyup="SetNumber(this,this.value);CalculateSellingPrice();ToInteger(this,this.value);">0</asp:TextBox>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtytext2">
                                <asp:TextBox ID="txtQtyQuantity2" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onkeyup="SetNumber(this,this.value);CalculateSellingPrice();ToInteger(this,this.value);">0</asp:TextBox>
                            </div>
                            <div style="float: left; display: none" id="div_qtytext3">
                                <asp:TextBox ID="txtQtyQuantity3" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onkeyup="SetNumber(this,this.value);CalculateSellingPrice();ToInteger(this,this.value);">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div align="left">
                        <div style="float: left; width: 10%; padding: 5px; clear: left">
                            <span class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Markup")%></span>
                        </div>
                        <div class="box">
                            <div style="float: left; padding-right: 5px" id="div_qtymarkup0">
                                <asp:TextBox ID="txtQtyProfit" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtymarkup1">
                                <asp:TextBox ID="txtQtyProfit1" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtymarkup2">
                                <asp:TextBox ID="txtQtyProfit2" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>
                            </div>
                            <div style="float: left; display: none" id="div_qtymarkup3">
                                <asp:TextBox ID="txtQtyProfit3" runat="server" SkinID="textPad" Width="100px" MaxLength="8"
                                    onblur="todecimal_function(this,this.value);SetNumberWithMinus(this,this.value);CalculateSellingPrice();MakePrice2Decimal(this);">0</asp:TextBox>
                                <%--&nbsp;%--%>
                            </div>
                        </div>
                    </div>
                    <div align="left">
                        <div style="float: left; width: 10%; padding: 5px; clear: left">
                            <span class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Selling_Price")%></span>
                        </div>
                        <div class="box">
                            <div style="float: left; padding-right: 5px" id="div_qtysellingprice0">
                                <asp:TextBox ID="txtQtySellingPrice" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="8" onblur="AllowNumber_WithNegative(this,this.value);" ReadOnly="true">0.00</asp:TextBox>
                                <%--SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtysellingprice1">
                                <asp:TextBox ID="txtQtySellingPrice1" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="8" onblur="AllowNumber_WithNegative(this,this.value);" ReadOnly="true">0.00</asp:TextBox>
                                <%--SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; padding-right: 5px; display: none" id="div_qtysellingprice2">
                                <asp:TextBox ID="txtQtySellingPrice2" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="8" onblur="AllowNumber_WithNegative(this,this.value);" ReadOnly="true">0.00</asp:TextBox>
                                <%--SetNumber(this,this.value);--%>
                            </div>
                            <div style="float: left; display: none" id="div_qtysellingprice3">
                                <asp:TextBox ID="txtQtySellingPrice3" runat="server" SkinID="textPad" Width="100px"
                                    MaxLength="8" onblur="AllowNumber_WithNegative(this,this.value);" ReadOnly="true">0.00</asp:TextBox>
                                <%--SetNumber(this,this.value);--%>  <%--&nbsp;<%=OBjJava.GetCurrencyinRequiredFormate("",true) %>--%>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hid_TimePerUnit" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_QtyCost" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_QtyCost1" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_QtyCost2" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_QtyCost3" runat="server" Value="0" />
                </div>
                <div align="right" class="onlyEmpty">
                    <div style="width: 100%; border: 0px solid;" align="right">
                        <div style="float: left; width: 70%">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: none;" CssClass="button"
                                Width="65px" OnClientClick="javascript:window.close();return false" />
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left; padding-left: 17%; padding-top: 1%;">
                            <asp:Button ID="btnSave" runat="server" Text="OK" CssClass="button" Width="65px"
                                OnClientClick="javascript:Loading_onSaveOtherCost();return false;" />
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div id="div_btnRecalculate" runat="server" style="float: left; display: none">
                            <asp:Button ID="btnRecalculate" runat="server" Text="Re-Calculate" CssClass="button"
                                OnClientClick="javascript:Recalculate();return false;" />
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
    <%--   QUESTION TAG   --%>
    <div id="div_question" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 50%; top: 20%; left: 30%;"
        align="center">
    </div>
    <div id="div_MatrixTable" style="display: none; margin: 20px 0px 20px 0px; padding: 10px 10px 10px 10px; position: absolute; z-index: 10000; width: 100%; top: 15%;"
        align="center">
        <table cellpadding="0" cellspacing="0" width="85%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                </td>
                <td id="drag_header" class="popup-top-middlebg" style="width: auto;">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                        <b>
                            <%=objLanguage.GetLanguageConversion("Cost_Matrix")%></b>
                        <asp:Label ID="Label10" runat="server"></asp:Label>
                    </div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px; z-index: +100000;">
                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/close_btn.PNG"
                            runat="server" CausesValidation="false" OnClientClick="javascript:ShowHideMatrixTable('hide');return false;" />
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
                    <div>
                        <div class="" style="width: 1060px; overflow: scroll; padding: 10px 10px 10px 10px; height: 200px;">
                            <table cellpadding="2" cellspacing="2" border="0" width="auto">
                                <tr>
                                    <td valign="top" style="width: auto; padding: 10px 10px 10px 10px;">
                                        <div align="left" id="tbl_matrix">
                                            <div align="left">
                                                <div class="bglabel" style="width: 20%">
                                                    <asp:Label ID="Label17" runat="server" Text="Prompt" CssClass="normaltext"></asp:Label>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtprompt" runat="server" SkinID="textPad" Width="520px" MaxLength="100"
                                                        ReadOnly="true"></asp:TextBox>
                                                    <span class="smallgraytext">
                                                        <br />
                                                        <%=objLanguage.GetLanguageConversion("Click_the_Unit_Price_box_to_select")%>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                            <div id="div_table" runat="server" align="center" style="white-space: nowrap;">
                                                <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                                                    <col width="20%" />
                                                    <col width="13%" />
                                                    <col width="13%" />
                                                    <col width="13%" />
                                                    <col width="13%" />
                                                    <col width="13%" />
                                                    <col width="13%" />
                                                    <tr class="label">
                                                        <td align="center">
                                                            <asp:Label ID="Label21" runat="server" Text="Matrix" CssClass="HeaderText"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol1" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol2" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol3" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol4" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol5" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol6" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol7" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol8" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol9" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCol10" runat="server" SkinID="textPad" Width="75px" MaxLength="100"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <span>
                                                                <br />
                                                                (<%=objLanguage.GetLanguageConversion("Unit_Price")%>)</span>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" runat="server">
                                                        <td align="left" class="HeaderText label" nowrap="nowrap">
                                                            <div align="center">
                                                                <%=objLanguage.GetLanguageConversion("Quantity")%><br />
                                                            </div>
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm1" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">1</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo1" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA51" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">45</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA41" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">13</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA31" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">13</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA21" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">15</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA61" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA71" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA81" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA91" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA101" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td nowrap="nowrap" align="left" valign="bottom">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA111" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr2" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm2" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">6</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo2" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA52" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">9</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA42" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">12</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA32" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">12</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA22" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">14</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA62" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox><%--CallonBlur(this.value,'spn_txtA62v');CheckDecimalPlus(this.value,'spn_txtA62v','spn_txtA62n','yes');AmountTo2Decimal(this,this.value);--%>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA72" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA82" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA92" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA102" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA112" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr3" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm3" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">11</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo3" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">20</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA53" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA43" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">11</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA33" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">11</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA23" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">13</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA63" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA73" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA83" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA93" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA103" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA113" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr4" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm4" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">21</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo4" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">50</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA54" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">7</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA44" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA34" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA24" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">12</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA64" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA74" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA84" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA94" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA104" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA114" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr5" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm5" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">51</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo5" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">100</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA55" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">6</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA45" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">9</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA35" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">9</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA25" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">11</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA65" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA75" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA85" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA95" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA105" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA115" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr6" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm6" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo6" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA56" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA46" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA36" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA26" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA66" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA76" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA86" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA96" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA106" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA116" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr7" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm7" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">201</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo7" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA57" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">4.5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA47" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">7</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA37" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">7</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA27" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">9</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA67" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA77" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA87" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA97" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA107" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA117" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr8" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm8" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo8" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA58" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA48" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA38" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA28" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA68" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA78" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA88" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA98" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA108" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA118" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr9" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm9" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo9" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA59" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA49" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA39" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA29" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA69" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA79" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA89" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA99" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA109" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA119" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr10" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm10" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo10" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA510" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA410" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA310" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA210" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA610" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA710" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA810" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA910" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1010" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1110" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr11" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm11" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo11" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA511" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA411" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA311" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA211" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA611" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA711" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA811" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA911" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1011" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1111" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr12" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm12" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo12" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA512" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA412" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA312" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA212" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA612" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA712" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA812" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA912" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1012" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1112" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <asp:HiddenField runat="server" ID="hdnMatrixValue" Value="" />
                                                    <asp:HiddenField runat="server" ID="hdnMatrixHeadingID" Value="" />
                                                    <asp:HiddenField runat="server" ID="hdnMatrixValueID" Value="" />
                                                    <tr id="tr13" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm13" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo13" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA513" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA413" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA313" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA213" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA613" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA713" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA813" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA913" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1013" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1113" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr14" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm14" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo14" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA514" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA414" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA314" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA214" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA614" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA714" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA814" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA914" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1014" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1114" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr15" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm15" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo15" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA515" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA415" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA315" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA215" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA615" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA715" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA815" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA915" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1015" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1115" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr16" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm16" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo16" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA516" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA416" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA316" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA216" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA616" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA716" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA816" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA916" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1016" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1116" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr17" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm17" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo17" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA517" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA417" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA317" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA217" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA617" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA717" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA817" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA917" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1017" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1117" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr18" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm18" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo18" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA518" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA418" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA318" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA218" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA618" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA718" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA818" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA918" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1018" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1118" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr19" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm19" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                                -
                                                                <asp:TextBox runat="server" ID="txtTo19" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">200</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA519" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA419" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA319" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA219" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA619" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA719" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA819" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA919" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1019" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1119" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr20" runat="server">
                                                        <td align="center" class="HeaderText label" nowrap="nowrap">
                                                            <div align="left">
                                                                <asp:TextBox runat="server" ID="txtFrm20" SkinID="textPad" Width="60px" MaxLength="8"
                                                                    ReadOnly="true" Style="text-align: right">101</asp:TextBox>
                                                            +
                                                        </td>
                                                        <td align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA520" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">5</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA420" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA320" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">8</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA220" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">10</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA620" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA720" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA820" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA920" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1020" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td class="HeaderText" align="left">
                                                            <div align="left">
                                                                <asp:TextBox ID="txtA1120" runat="server" SkinID="textPad" Width="75px" onfocus="javascript:ChangetxtBgcolor(this);return false;"
                                                                    onblur="javascript:RemoveBgcolor(this,this.value);return false;" onclick="javascript:GetMatrixValue(this.value);return false;"
                                                                    MaxLength="12" ReadOnly="true" Style="text-align: right">0.00</asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <script>
                                                    function ChangetxtBgcolor(obj) {
                                                        obj.style.backgroundColor = "#fbfea0"; //#FFF9BB
                                                    }
                                                    function RemoveBgcolor(obj, val) {
                                                        obj.style.backgroundColor = "";
                                                        var matrixvalue = document.getElementById("<%=hdnMatrixValue.ClientID %>");
                                                        matrixvalue.value = val;

                                                    }
                                                </script>
                                            </div>
                                            <div id="div_btnMatrixOk" align="right" style="display: none">
                                                <asp:Button ID="btnSaveMatrix" runat="server" Text="Cancel" CssClass="button" Width="65px"
                                                    OnClientClick="javascript:ShowHideMatrixTable('hide');return false;" />
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
                <td colspan="2" class="popup-bottom-leftcorner" style="padding-left: 25px;">&nbsp;
                </td>
                <td class="popup-bottom-middlebg">&nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner" style="padding-right: 34px;">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divrad" style="display: none;" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
            OnClientClose="RadWinClose" Behaviors="Close,reload, Move, Resize" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
</div>
<asp:HiddenField ID="hdnEditOtherValues" runat="server" Value="" />
<asp:HiddenField ID="hid_TotalSheets" runat="server" Value="" />
<asp:HiddenField ID="hid_IsColorOrBlack" runat="server" Value="" />
<asp:HiddenField ID="hid_IsDuobleSided" runat="server" Value="" />
<%--//******* OTHERCOST SECTION *********//--%>
<asp:HiddenField ID="hdn_OtherVariableQtyValues" runat="server" Value="" />
<asp:HiddenField ID="hdn_VariableQtyWithCost" runat="server" Value="" />
<asp:HiddenField ID="hid_OtherCostValuesFromTB" runat="server" Value="" />
<asp:HiddenField ID="hid_OtherCost_Question" runat="server" Value="" />
<asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
<asp:HiddenField ID="hdnpaperID" runat="server" Value="" />
<asp:HiddenField ID="hdn_ZoneMarkupPrice" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ZoneCostPrice" runat="server" Value="0" />
<asp:HiddenField ID="hdn_compare_sellingprice" runat="server" Value="" />
<script type="text/javascript" src="<%=strSitepath %>js/Item/othercost_item.js?VN='<%=VersionNumber%>'"></script>
<asp:HiddenField ID="hdn_estquantityformainItem" runat="server" Value="" />
<asp:HiddenField ID="hdn_MinimumCharge" runat="server" Value="0" />
<asp:HiddenField ID="hdn_QuestionValue" runat="server" Value="" />

<script type="text/javascript" language="javascript">
    var asyncState = true;
    XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
    XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
        async = asyncState;
        var eventArgs = Array.prototype.slice.call(arguments);
        return this.original_open.apply(this, eventArgs);
    }
</script>

<script type="text/javascript">
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var othercostid = '<%=OtherCostID %>';
    var ForOtherCostFormula = '<%=ForOtherCostFormula.ToString().ToLower()%>';

    var ActualQuantiryArry = '<%=qty %>'.split(',');
    var ActualQuantiry1 = ActualQuantiryArry[0];
    var ActualQuantiry2 = ActualQuantiryArry[1];
    var ActualQuantiry3 = ActualQuantiryArry[2];
    var ActualQuantiry4 = ActualQuantiryArry[3];

    var caltype = '<%=CalType %>';
    var costtimebasedid = '<%=CostTimeBasedID %>';
    var otherinx = '<%=otherinx %>';
    var pw = window.parent;
    var lblCostNameID = document.getElementById("<%=lblCostName.ClientID %>");
    var lblMinimumChargeID = document.getElementById("<%=lblMinimumCharge.ClientID %>");
    var hdn_MinimumChargID = document.getElementById("<%=hdn_MinimumCharge.ClientID%>");
    var btnAdvancedID = document.getElementById("<%=btnAdvanced.ClientID %>");
    var hdnEditOtherValues = document.getElementById("<%=hdnEditOtherValues.ClientID %>");
    var txtDescription = document.getElementById("<%=txtDescription.ClientID %>");
    var hdn_QuestionValue = document.getElementById("<%=hdn_QuestionValue.ClientID%>");

    //Time Based//
    var div_TimeBased = document.getElementById("div_TimeBased");
    var div_Advance_TimeBased = document.getElementById("div_Advance_TimeBased");
    var txtHourlyRateID = document.getElementById("<%=txtHourlyRate.ClientID %>");
    var txtSetUpTimeID = document.getElementById("<%=txtSetUpTime.ClientID %>");
    var lblSetUpCostID = document.getElementById("<%=lblSetUpCost.ClientID %>");
    var txtHoursID = document.getElementById("<%=txtHours.ClientID %>");
    var txtPassesID = document.getElementById("<%=txtPasses.ClientID %>");
    var txtProfitID = document.getElementById("<%=txtProfit.ClientID %>");
    var txtSellingPriceID = document.getElementById("<%=txtSellingPrice.ClientID %>");
    var hid_HourlySpeedID = document.getElementById("<%=hid_HourlySpeed.ClientID %>");

    //Time Advance//
    var txtRunsRequiredID = document.getElementById("<%=txtRunsRequired.ClientID %>");
    var lblSpeedID = document.getElementById("<%=lblSpeed.ClientID %>");
    var lblTotalTimeID = document.getElementById("<%=lblTotalTime.ClientID %>");
    var lblCostID = document.getElementById("<%=lblCost.ClientID %>");

    //Qty Based//
    var div_QuantityBased = document.getElementById("div_QuantityBased");
    var div_Advance_TimeBased = document.getElementById("div_Advance_TimeBased");
    var txtQtyUnitRateID = document.getElementById("<%=txtQtyUnitRate.ClientID %>");
    var txtQtyUnitRateID1 = document.getElementById("<%=txtQtyUnitRate1.ClientID %>");
    var txtQtyUnitRateID2 = document.getElementById("<%=txtQtyUnitRate2.ClientID %>");
    var txtQtyUnitRateID3 = document.getElementById("<%=txtQtyUnitRate3.ClientID %>");

    var txtQtyQuantityID = document.getElementById("<%=txtQtyQuantity.ClientID %>");
    var txtQtyQuantityID1 = document.getElementById("<%=txtQtyQuantity1.ClientID %>");
    var txtQtyQuantityID2 = document.getElementById("<%=txtQtyQuantity2.ClientID %>");
    var txtQtyQuantityID3 = document.getElementById("<%=txtQtyQuantity3.ClientID %>");

    var txtQtyProfitID = document.getElementById("<%=txtQtyProfit.ClientID %>");
    var txtQtyProfitID1 = document.getElementById("<%=txtQtyProfit1.ClientID %>");
    var txtQtyProfitID2 = document.getElementById("<%=txtQtyProfit2.ClientID %>");
    var txtQtyProfitID3 = document.getElementById("<%=txtQtyProfit3.ClientID %>");

    var txtQtySellingPriceID = document.getElementById("<%=txtQtySellingPrice.ClientID %>");
    var txtQtySellingPriceID1 = document.getElementById("<%=txtQtySellingPrice1.ClientID %>");
    var txtQtySellingPriceID2 = document.getElementById("<%=txtQtySellingPrice2.ClientID %>");
    var txtQtySellingPriceID3 = document.getElementById("<%=txtQtySellingPrice3.ClientID %>");

    //Qty Advance//
    var txtQtySetUpTimeID = document.getElementById("<%=txtQtySetUpTime.ClientID %>");
    var txtQtyHourlyRateID = document.getElementById("<%=txtQtyHourlyRate.ClientID %>");
    var lblQtyTotalTimeID = document.getElementById("<%=lblQtyTotalTime.ClientID %>");
    var lblQtySetUpCostID = document.getElementById("<%=lblQtySetUpCost.ClientID %>");
    var hid_QtyCost = document.getElementById("<%=hid_QtyCost.ClientID %>");
    var hid_QtyCost1 = document.getElementById("<%=hid_QtyCost1.ClientID %>");
    var hid_QtyCost2 = document.getElementById("<%=hid_QtyCost2.ClientID %>");
    var hid_QtyCost3 = document.getElementById("<%=hid_QtyCost3.ClientID %>");

    //Formula Based//
    var div_FormulaBased = document.getElementById("div_FormulaBased");
    var txtFormulaID = document.getElementById("<%=txtFormula.ClientID %>");
    var txtWithActualsID = document.getElementById("<%=txtWithActuals.ClientID %>");
    var txtWithActualsID1 = document.getElementById("<%=txtWithActuals1.ClientID %>");
    var txtWithActualsID2 = document.getElementById("<%=txtWithActuals2.ClientID %>");
    var txtWithActualsID3 = document.getElementById("<%=txtWithActuals3.ClientID %>");


    var txtFormulaCost = document.getElementById("<%=txtFormulaCost.ClientID %>");
    var txtFormulaCost1 = document.getElementById("<%=txtFormulaCost1.ClientID %>");
    var txtFormulaCost2 = document.getElementById("<%=txtFormulaCost2.ClientID %>");
    var txtFormulaCost3 = document.getElementById("<%=txtFormulaCost3.ClientID %>");

    var txtFormulaProfit = document.getElementById("<%=txtFormulaProfit.ClientID %>");
    var txtFormulaProfit1 = document.getElementById("<%=txtFormulaProfit1.ClientID %>");
    var txtFormulaProfit2 = document.getElementById("<%=txtFormulaProfit2.ClientID %>");
    var txtFormulaProfit3 = document.getElementById("<%=txtFormulaProfit3.ClientID %>");

    var txtFormulaSellingPrice = document.getElementById("<%=txtFormulaSellingPrice.ClientID %>");
    var txtFormulaSellingPrice1 = document.getElementById("<%=txtFormulaSellingPrice1.ClientID %>");
    var txtFormulaSellingPrice2 = document.getElementById("<%=txtFormulaSellingPrice2.ClientID %>");
    var txtFormulaSellingPrice3 = document.getElementById("<%=txtFormulaSellingPrice3.ClientID %>");

    var div_MatrixTable = document.getElementById("div_MatrixTable");
    var div_Matrixbtn = document.getElementById("div_Matrixbtn");
    var div_Matrixbtn = document.getElementById("div_Matrixbtn1");
    var div_Matrixbtn = document.getElementById("div_Matrixbtn2");
    var div_Matrixbtn = document.getElementById("div_Matrixbtn3");
    var div_Matrixbtn = document.getElementById("div_Matrixbtn4");
    var div_btnMatrixOk = document.getElementById("div_btnMatrixOk");

    var hid_TotalSheets = document.getElementById("<%=hid_TotalSheets.ClientID %>");
    var hid_IsColorOrBlack = document.getElementById("<%=hid_IsColorOrBlack.ClientID %>");
    var hid_IsDuobleSided = document.getElementById("<%=hid_IsDuobleSided.ClientID %>");

    //quantity based
    var div_unitrate0 = document.getElementById("div_unitrate0");
    var div_unitrate1 = document.getElementById("div_unitrate1");
    var div_unitrate2 = document.getElementById("div_unitrate2");
    var div_unitrate3 = document.getElementById("div_unitrate3");

    var div_qtytext0 = document.getElementById("div_qtytext0");
    var div_qtytext1 = document.getElementById("div_qtytext1");
    var div_qtytext2 = document.getElementById("div_qtytext2");
    var div_qtytext3 = document.getElementById("div_qtytext3");

    var div_qtymarkup0 = document.getElementById("div_qtymarkup0");
    var div_qtymarkup1 = document.getElementById("div_qtymarkup1");
    var div_qtymarkup2 = document.getElementById("div_qtymarkup2");
    var div_qtymarkup3 = document.getElementById("div_qtymarkup3");

    var div_qtysellingprice0 = document.getElementById("div_qtysellingprice0");
    var div_qtysellingprice1 = document.getElementById("div_qtysellingprice1");
    var div_qtysellingprice2 = document.getElementById("div_qtysellingprice2");
    var div_qtysellingprice3 = document.getElementById("div_qtysellingprice3");

    var hdn_ZoneMarkupPrice = document.getElementById("<%=hdn_ZoneMarkupPrice.ClientID %>");
    var hdn_ZoneCostPrice = document.getElementById("<%=hdn_ZoneCostPrice.ClientID %>");
    var div_btnRecalculate = document.getElementById("<%=div_btnRecalculate.ClientID %>");
    var hdn_compare_sellingprice = document.getElementById("<%=hdn_compare_sellingprice.ClientID %>");
    var hdn_estquantityformainItem = document.getElementById("<%=hdn_estquantityformainItem.ClientID %>");

    var TotalSheetsVal = "";
    var IsColourOrBlack = "";
    var IsDoubleSided = "";
    var SideColor = "";

    function qtyTable() {
        var str1 = '';
        var Qty1 = "<%=Qty1 %>";
        var Qty2 = "<%=Qty2 %>";
        var Qty3 = "<%=Qty3 %>";
        var Qty4 = "<%=Qty4 %>";

        str1 += "<table cellpadding='0px' cellspacing='0px' width='100%' align='center' border='0px'>";

        str1 += "<tr> <td align='left' class='only10px'> </td> </tr>";

        str1 += "<tr align='left'><td align='center' width='100%' style='border:solid 0px red'>";

        if ((QtyNo == 0 || QtyNo == 1)) {

            str1 += "<div align='center' style='23%;float:left;padding-left:16%'><div align='left' style='width:110px;float:left'><span class='headerText' width='22%'>Quantity1: " + Qty1 + "</span></div></div>";
        }

        if (Qty2 != '' && Qty2 != 0 && (QtyNo == 0 || QtyNo == 2)) {

            str1 += "<div style='22%;float:left;padding-left:132px'><div align='left' style='width:110px;float:left'><span class='headerText' width='22%'>Quantity2: " + Qty2 + "</span></div></div>";
        }
        if (Qty3 != '' && Qty3 != 0 && (QtyNo == 0 || QtyNo == 3)) {

            str1 += "<div style='22%;float:left;padding-left:132px;border:solid 0px red'><div align='left' style='width:110px;float:left;border:solid 0px red'><span class='headerText' width='22%'>Quantity3: " + Qty3 + "</span></div></div>";
        }
        if ((Qty4 != '' && Qty4 != 0) && (QtyNo == 0 || QtyNo == 4)) {



            str1 += "<div style='25%;float:left;padding-right:0px;border:solid 0px red;padding-left: 132px;'><div align='left' style='width:110px;float:left;border:solid 0px red'><span class='headerText' width='22%'>Quantity4: " + Qty4 + "</span></div></div>";
        }
        str1 += "</td></tr>";

        str1 += "<tr> <td align='center' width='100%'>";



        str1 += "</td > </tr></table>";
        document.getElementById("AvtualQtyValue").innerHTML = str1;
        document.getElementById("AvtualQtyValue").style.display = "block";
    }

    function MakeMatrixdivCenter() {

        w = div_MatrixTable.style.width;
        h = div_MatrixTable.style.height;
        var left = (screen.width / 2) - (w / 2);
        var top = (h / 2); //(screen.height / 2) - ;
        div_MatrixTable.style.left = left;
        div_MatrixTable.style.top = top;
    }

    var CurrentNo = -1;
    function ShowHideMatrixTable(distype, MatrixNo) {
        if (distype == "show") {

            if (MatrixNo == undefined) {
                MatrixNo = -1;
            }
            CurrentNo = MatrixNo;
            div_MatrixTable.style.display = "block";
            div_btnMatrixOk.style.display = "none";
            if (otherinx != "") {
                div_btnMatrixOk.style.display = "block";
                ShowQuestionTable('hide');
            }
        }
        else if (distype == "hide") {
            div_MatrixTable.style.display = "none";
            CurrentNo = -1;
        }
        if ('<%=FormulaTag %>'.indexOf('Q::') != -1) {
            ShowQuestionTable();
        }
    }

    var Actual = '<%=FormulaTag %>';
    var ActualArray = new Array(5);

    for (g = 0; g < 5; g++) {
        ActualArray[g] = Actual;
    }

    var ActualFormulaFromDB = Actual;
    var MatrixVal = '<%=MatrixValue%>'.split(',');

    //BY GAJ FOR MATRIX Start
    function AssignMatrixValues(val) {
        var PriceForMatrix = val.split(',');
        var key = '<%=Key %>';
        //new on 25th feb
        var qtynew = '<%= qty%>'.split(',');
        //qtynew = qtynew.split(',')
        //By Gaj on 17-7-2012 
        debugger;
        if (CurrentNo == -1) {
            for (k = 0; k < qtynew.length - 1; k++) {
                MatrixVal = PriceForMatrix[k];
                if (qtynew[k] != null) {
                    CalculateVariableQty(ActualArray[k], PriceForMatrix[k], qtynew[k], k, 'formulabased');
                }
            }
        }
        else {
            MatrixVal = PriceForMatrix[CurrentNo];
            CalculateVariableQty(ActualArray[CurrentNo], PriceForMatrix[CurrentNo], qtynew[CurrentNo], CurrentNo, 'formulabased');
        }
        //By Gaj on 17-7-2012
        CalculateSellingPrice();
        ShowHideMatrixTable('hide');

    }
    //BY GAJ FOR MATRIX End

    function GetMatrixValue(txtval) {
        var key = '<%=Key %>';
        MatrixVal = txtval;

        //new on 25th feb
        var qtynew = '<%= qty%>'.split(',');
        //qtynew = qtynew.split(',')
        //By Gaj on 17-7-2012 
        debugger;
        if (CurrentNo == -1) {
            for (k = 0; k < qtynew.length - 1; k++) {
                if (qtynew[k] != null) {
                    CalculateVariableQty(ActualArray[k], txtval, qtynew[k], k, 'formulabased');
                }
            }
        }
        else {
            CalculateVariableQty(ActualArray[CurrentNo], txtval, qtynew[CurrentNo], CurrentNo, 'formulabased');
        }
        //By Gaj on 17-7-2012
        CalculateSellingPrice();
        ShowHideMatrixTable('hide');
    }

    function AllowMarkup(obj, val) {
    }

    function ShowQuestionTable() {
        var Actuals_Main = Actual; //'<%=FormulaTag %>';
        //var qtycount='<%=Qtycount%>';
        if (otherinx == '') {
            var StrArray = Actual.split('Q::');
            hdn_QuestionValue.Value = StrArray;
            if (StrArray.length > 1) {

                var round = 0;
                for (var i = 1; i < StrArray.length; i++) {
                    var data_0 = replace_char(SpecialDecode(StrArray[i]));
                    //var data_0 = (StrArray[i]);
                    var old_data = document.getElementById("div_question").innerHTML;
                    document.getElementById("div_question").innerHTML = old_data + '' + CreateHTML(SpecialEncode(data_0), round, Actual);
                    round++;
                }
                document.getElementById("div_question").style.display = "block";
                document.getElementById("div_ques_0").style.display = "block";
                //showDivPopupCenter('div_question','300');
                document.getElementById("txt_qty_10").focus();
                document.getElementById("txt_qty_10").select();
                document.getElementById("ds00").style.width = "100%"; //window.screen.availWidth+"px";
                document.getElementById("ds00").style.height = window.screen.availHeight + "px";
                document.getElementById("ds00").style.display = "block";

            }
            else {
                //new on 25th feb
                // var qtyVariable = ;
                var qtynew = '<%=qty%>'.split(',');
                debugger;
                for (k = 0; k < qtynew.length; k++) {

                    if (qtynew[k] != null) {
                        CalculateVariableQty(ActualArray[k], MatrixVal[k], qtynew[k], k, 'formulabased');
                    }
                }
            }
        }
    }
    function RadWinClose() {

        // document.getElementById("ds00").style.display = "none";
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";

    }
    function ShowOnLoad() {
        debugger;
        if (caltype == 't') {
            div_TimeBased.style.display = "block";
        }
        else if (caltype == 'q') {
            div_QuantityBased.style.display = "block";
        }
        else if (caltype == 'f' || caltype == 'm') {
            div_FormulaBased.style.display = "block";
            if (caltype == 'm') {



                if (otherinx == '') {
                    ShowHideMatrixTable('show');
                    div_btnMatrixOk.style.display = "none";
                }
            }
            ShowQuestionTable();
        }

        ShowQuestionTable(); //by kumar on december 14 2010,bec this method prevoisly called only for formula and matrix types,now its applying for all the types

        if (otherinx != '') {

            BindCostValuesOnEdit();
        }
        else {
            BindMainItemOnEdit();
        }
    }
    ShowOnLoad();


    function ReplaceAll(strFormula, ValueToReplace, FinalValue) {
        while (strFormula.indexOf(ValueToReplace) != -1) {
            strFormula = strFormula.replace(ValueToReplace, FinalValue);

        }
    }


    function CalculateVariableQty(para_formula, txtMatrixval, txtQty, index, formulatype) {

        debugger;

        if (formulatype == 'formulabased') {
            Actual = ActualFormulaFromDB;
        }
        else {
            Actual = para_formula;
        }


        if ('<%=ItemType %>' == "s" || '<%=ItemType %>' == "m") {
            //Finished Qty //
            //var txtQty = '<%=Quantity %>'; //pw.txtQuantity.value;
            if (caltype == 't') {
                var txtQty = '<%=Quantity %>'; //pw.txtQuantity.value;

            }
            var txtNoOfPagesInSection = '<%=NoOfPagesInSection %>'; //pw.txtNoOfPagesInSection.value;
            var SetupSpoilage = '<%=SetupSpoilage %>'; //pw.txtSetupSpoilage.value;
            var RunningSpoilage = '<%=RunningSpoilage %>'; //pw.txtRunningSpoilage.value;
            var Partsperset = '<%=Partsperset %>';
            var Setsperpad = '<%=Setsperpad %>';

            //Print Sheet Qty //
            var txtPortrait = '<%=PortraitValue %>'; //pw.txtportrait.value;
            var txtLandscape = '<%=LandscapeValue %>'; //pw.txtlandscape.value;
            var txtManual = '<%=ManualValue %>'; //pw.txtlandscape.value;
            var chkPortrait = '<%=chkPortrait %>'; //pw.chkPortrait;
            var chkLandscape = '<%=chkLandscape %>'; //pw.chkLandscape;
            debugger
            var NoOfSections = '<%=NoOfSections %>';
            try {
                var hid_GuillotineID = pw.hid_GuillotineID;
            } catch (err) { }
            var chkGutters = '<%=chkGutters %>'; //pw.chkGutters;
            var txtNoOfLeavesPerPad = '<%=NoOfLeavesPerPad %>'; //pw.txtNoOfLeavesPerPad;
            var ddlColors = '<%=ddlColors %>'; //pw.ddlColors;
            var chkDoubleSided = '<%=chkDoubleSided %>'; //pw.chkDoubleSided;
            var ddlColors_2 = '<%=SideColor %>'; //pw.ddlColors_2;

            var chkFirstTrim = '<%=chkFirstTrim %>'; //pw.chkFirstTrim;

            var sheetHeight = '<%=SheetHeight %>'; //pw.txtsectionheight.value;
            var sheetWidth = '<%=SheetWidth %>'; //pw.txtsectionwidth.value;

            var strTotalLengthRequired = '<%=strTotalLengthRequired %>';
            var strTotalAreaRequired = '<%=strTotalAreaRequired %>';

            var strjobheight = '<%=strjobheight %>';
            var strjobwidth = '<%=strjobwidth %>';

            var FinishedQty_Excl_Spoilage = Number(txtQty);
            var FinishedQty_Incl_Spoilage = 0;

            var PrintLayoutQty;
            var PrintLayout = '';
            //if (pw.productType != "booklet") { OLD  

            if (('<%=ProductType %>' == "singleitem")) {
                if (chkPortrait == "True") {
                    PrintLayoutQty = Number(txtPortrait);
                    PrintLayout = "P";
                }
                else if (chkLandscape == "True") {
                    PrintLayoutQty = Number(txtLandscape);
                    PrintLayout = "L";
                }
                else {
                    PrintLayoutQty = Number(txtManual);
                    PrintLayout = "M";
                }
                if (Number(PrintLayoutQty) >= 1) {
                    var Pri_sheets = 0;
                    if (PrintLayoutQty > 0) {
                        Pri_sheets = Number(txtQty) / Number(PrintLayoutQty);
                    }
                    var RunSpoilSheets = Number(Number(Pri_sheets) * Number(RunningSpoilage)) / 100;
                    FinishedQty_Incl_Spoilage = Number(txtQty) + Number(SetupSpoilage) + Number(RunSpoilSheets);
                }
            }
            else if ('<%=ProductType %>' == "large") {
                if(chkPortrait == "True") {
                PrintLayoutQty = Number(txtPortrait);
                PrintLayout = "P";
            }
            else {
                PrintLayoutQty = Number(txtLandscape);
                PrintLayout = "L";
            }
            if (Number(PrintLayoutQty) >= 1) {
                var Pri_sheets = 0;
                if (PrintLayoutQty > 0) {
                    Pri_sheets = Number(txtQty) / Number(PrintLayoutQty);
                }
                var RunSpoilSheets = Number(Number(Pri_sheets) * Number(RunningSpoilage)) / 100;
                FinishedQty_Incl_Spoilage = Number(txtQty) + Number(SetupSpoilage) + Number(RunSpoilSheets);
            }
            }
            else if (('<%=ProductType %>' == "booklet")) {
                //var ddlBookletFormat = pw.document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_ddlBookletFormat");
                var NoOfSignatures = '<%=NoOfSignatures %>';
                PrintLayoutQty = '<%=NoOfSignatures %>'; //pw.txtNoOfSignatures.value; ///txtPagesPerSignature  OLD


                // This PrintLayoutQty Will be used as No Of Signature in case of Booklet
                NoOfSections = '<%=NoOfSections %>'; //pw.bookArr.length; OLD

                var ddlBookletFormat = '<%=ddlBookletFormat %>'; //pw.ddlBookletFormat.value; ///txtPagesPerSignature  OLD
                if (ddlBookletFormat.toLowerCase() == 'portrait') {
                    PrintLayout = "P";
                }
                else {
                    PrintLayout = "L";
                }
                if (Number(PrintLayoutQty) >= 1) {
                    var Pri_sheets = Number(txtQty) * Number(PrintLayoutQty);
                    var RunSpoilSheets = Number(Number(Pri_sheets) * Number(RunningSpoilage)) / 100;
                    FinishedQty_Incl_Spoilage = Number(txtQty) + Number(SetupSpoilage) + Number(RunSpoilSheets);
                }
            }
            else if ('<%=ProductType %>' == "pads") {
                if (chkPortrait == "True") {
                    PrintLayoutQty = Number(txtPortrait);
                    PrintLayout = "P";
                }
                else if (chkLandscape == "True") {
                    PrintLayoutQty = Number(txtLandscape);
                    PrintLayout = "L";
                }
                else {
                    PrintLayoutQty = Number(txtManual);
                    PrintLayout = "M";
                }
                if (Number(PrintLayoutQty) >= 1) {
                    var Pri_sheets = (Number(txtQty) * Number(txtNoOfLeavesPerPad)) / Number(PrintLayoutQty);
                    var RunSpoilSheets = Number(Number(Pri_sheets) * Number(RunningSpoilage)) / 100;
                    FinishedQty_Incl_Spoilage = Number(txtQty) + Number(SetupSpoilage) + Number(RunSpoilSheets);
                }
            }
            else if ('<%=ProductType %>' == "ncr") {
                if (chkPortrait == "True") {
                    PrintLayoutQty = Number(txtPortrait);
                    PrintLayout = "P";
                }
                else if (chkLandscape == "True") {
                    PrintLayoutQty = Number(txtLandscape);
                    PrintLayout = "L";
                }
                else {
                    PrintLayoutQty = Number(txtManual);
                    PrintLayout = "M";
                }
                if (Number(PrintLayoutQty) >= 1) {
                    var Pri_sheets = Number(txtQty) * Number(Setsperpad);
                    var RunSpoilSheets = Number(Number(Pri_sheets) * Number(RunningSpoilage)) / 100;
                    FinishedQty_Incl_Spoilage = Number(txtQty) + Number(SetupSpoilage) + Number(RunSpoilSheets);
                }
            }

            var TotalPagesAllSections = '<%=TotalPagesAllSections %>';
            debugger
            var PrintSheets = 0;
            var PrintSheetQty_Excl_Spoilage = 0;
            var PrintRunSpoilSheets = 0;
            var PrintSheetQty_Incl_Spoilage = 0;
            var Quantity_Inc_Spoilage = 0;

            ////Paper Detials
            var Paper_Markup = 0;
            var Paper_Basis_Weight = 0;
            var Pack_Price = 0;
            var Pack_Quantity = 0;
            var Paper_Unit_Price = 0;
            var Paper_Cost_Inc_Markup = 0;
            var Paper_Cost_Exc_Markup = 0;
            var Spoilage_Percentage_Used = 0;
            var Spoilage_Sheets_Used = 0;

            //if (pw.productType != "booklet") { OLD

            if (('<%=ProductType %>' == "singleitem") || ('<%=ProductType %>' == "large")) {
                if (PrintLayoutQty > 0) {
                    PrintSheets = Number(txtQty) / Number(PrintLayoutQty);
                }
                else { PrintSheets = 0; }
                PrintSheets = Math.ceil(PrintSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
                PrintRunSpoilSheets = (Number(PrintSheets) * Number(RunningSpoilage)) / 100;
                PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(SetupSpoilage) + Number(PrintRunSpoilSheets);

                //Paper Details
                Spoilage_Percentage_Used = RunningSpoilage;
                Spoilage_Sheets_Used = Number(SetupSpoilage) + Number(PrintRunSpoilSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheetQty_Incl_Spoilage) - Spoilage_Sheets_Used;



            }
            else if ('<%=ProductType %>' == "booklet") {

                PrintSheets = Number(txtQty) * Number(PrintLayoutQty);
                PrintRunSpoilSheets = Number(Number(PrintSheets) * Number(RunningSpoilage)) / 100;
                PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(SetupSpoilage) + Number(PrintRunSpoilSheets);
                //Paper Details
                Spoilage_Percentage_Used = RunningSpoilage;
                Spoilage_Sheets_Used = Number(SetupSpoilage) + Number(PrintRunSpoilSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheetQty_Incl_Spoilage) - Spoilage_Sheets_Used;
            }
            else if ('<%=ProductType %>' == "pads") {
                PrintSheets = (Number(txtQty) * Number(txtNoOfLeavesPerPad)) / Number(PrintLayoutQty);
                PrintSheets = Math.ceil(PrintSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
                PrintRunSpoilSheets = (Number(PrintSheets) * Number(RunningSpoilage)) / 100;
                PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(SetupSpoilage) + Number(PrintRunSpoilSheets);

                //Paper Details
                Spoilage_Percentage_Used = RunningSpoilage;
                Spoilage_Sheets_Used = Number(SetupSpoilage) + Number(PrintRunSpoilSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheetQty_Incl_Spoilage) - Spoilage_Sheets_Used;
            }

            else if ('<%=ProductType %>' == "ncr") {
                PrintSheets = (Number(txtQty) * Number(Setsperpad)) / PrintLayoutQty;
                PrintSheets = Math.ceil(PrintSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheets);
                PrintRunSpoilSheets = (Number(PrintSheets) * Number(RunningSpoilage)) / 100;
                PrintSheetQty_Incl_Spoilage = Number(PrintSheets) + Number(SetupSpoilage) + Number(PrintRunSpoilSheets);

                //Paper Details
                Spoilage_Percentage_Used = RunningSpoilage;
                Spoilage_Sheets_Used = Number(SetupSpoilage) + Number(PrintRunSpoilSheets);
                PrintSheetQty_Excl_Spoilage = Number(PrintSheetQty_Incl_Spoilage) - Spoilage_Sheets_Used;
            }
            else if ('<%=ProductType %>' == "large") {
                PrintSheetQty_Excl_Spoilage = 0;
                PrintSheetQty_Incl_Spoilage = 0;
            }


            PrintSheetQty_Incl_Spoilage = Math.ceil(PrintSheetQty_Incl_Spoilage);
            Quantity_Inc_Spoilage = Number(txtQty) + Number(Number(PrintSheetQty_Incl_Spoilage) - Number(PrintSheetQty_Excl_Spoilage));
            Quantity_Inc_Spoilage = Math.ceil(Quantity_Inc_Spoilage);
            Spoilage_Sheets_Used = Math.ceil(Spoilage_Sheets_Used);

            TotalSheetsVal = PrintSheetQty_Incl_Spoilage;
            IsColourOrBlack = ddlColors; //ddlColors.value; OLD
            IsDoubleSided = chkDoubleSided; //chkDoubleSided.checked; OLD
            SideColor = ddlColors_2; //ddlColors_2.value;

            var DefaultHourOrQtyType = '<%=DefaultHourOrQtyType %>';
            var FixedHourOrQty = '<%=FixedHourOrQty %>';
            var VariableHourOrQty = '<%=VariableHourOrQty %>';


            var hdn_OtherVariableQtyValues = document.getElementById("<%=hdn_OtherVariableQtyValues.ClientID %>").value; //pw.hdn_OtherVariableQtyValues; 
            if (caltype == "q") {
                if (DefaultHourOrQtyType == "f") {
                    //                        if(FixedHourOrQty=='0.0000000000')
                    //                        {
                    //                            FixedHourOrQty=txtQty;
                    //                        }                        
                    if (index == 0) {
                        txtQtyQuantityID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, FixedHourOrQty, 0, '', true, false, false);
                    }
                    else if (index == 1) {
                        txtQtyQuantityID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, FixedHourOrQty, 0, '', true, false, false);
                    }
                    else if (index == 2) {
                        txtQtyQuantityID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, FixedHourOrQty, 0, '', true, false, false);
                    }
                    else if (index == 3) {
                        txtQtyQuantityID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, FixedHourOrQty, 0, '', true, false, false);
                    }

                }
                else {
                    if (VariableHourOrQty == "1")//Print Sheet Qty Excl Spoilage
                    {
                        if (index == 0) {
                            txtQtyQuantityID.value = Math.round(PrintSheetQty_Excl_Spoilage);
                        }
                        else if (index == 1) {
                            txtQtyQuantityID1.value = Math.round(PrintSheetQty_Excl_Spoilage);
                        }
                        else if (index == 2) {
                            txtQtyQuantityID2.value = Math.round(PrintSheetQty_Excl_Spoilage);
                        }
                        else if (index == 3) {
                            txtQtyQuantityID3.value = Math.round(PrintSheetQty_Excl_Spoilage); //FinishedQty_Excl_Spoilage
                        }
                    }
                    else if (VariableHourOrQty == "2")//Print Sheet Qty Incl Spoilage
                    {
                        if (index == 0) {
                            txtQtyQuantityID.value = Math.round(PrintSheetQty_Incl_Spoilage);
                        }
                        else if (index == 1) {
                            txtQtyQuantityID1.value = Math.round(PrintSheetQty_Incl_Spoilage);
                        }
                        else if (index == 2) {
                            txtQtyQuantityID2.value = Math.round(PrintSheetQty_Incl_Spoilage);
                        }
                        else if (index == 3) {
                            txtQtyQuantityID3.value = Math.round(PrintSheetQty_Incl_Spoilage); //FinishedQty_Excl_Spoilage
                        }
                    }
                    else if (VariableHourOrQty == "3")//Finished Item Qty
                    {
                        if (index == 0) {
                            txtQtyQuantityID.value = Math.round(FinishedQty_Excl_Spoilage);
                        }
                        else if (index == 1) {
                            txtQtyQuantityID1.value = Math.round(FinishedQty_Excl_Spoilage);
                        }
                        else if (index == 2) {
                            txtQtyQuantityID2.value = Math.round(FinishedQty_Excl_Spoilage);
                        }
                        else if (index == 3) {
                            txtQtyQuantityID3.value = Math.round(FinishedQty_Excl_Spoilage);
                        }
                    }
                    else if (VariableHourOrQty == "4")//Finished Item Qty Incl Spoilage
                    {
                        txtQtyQuantityID.value = Math.round(FinishedQty_Incl_Spoilage);
                    }
                    txtQtyQuantityID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtQtyQuantityID.value, 0, '', true, false, false);
                }
                hdn_OtherVariableQtyValues.value = "DefaultQtyType»" + DefaultHourOrQtyType + "±FixedQty»" +
                    FixedHourOrQty + "±VariableQty»" + VariableHourOrQty + "±HoursOrQty»" + txtQtyQuantityID.value;
            }
            else if (caltype == "t") {
                if (DefaultHourOrQtyType == "f") {
                    txtHoursID.value = FixedHourOrQty;
                    txtHoursID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, FixedHourOrQty, 0, '', false, false, false);
                }
                else {
                    if (VariableHourOrQty == "1")//Print Sheet Qty Excl Spoilage
                    {
                        txtHoursID.value = Number(PrintSheetQty_Excl_Spoilage / hid_HourlySpeedID.value);
                    }
                    else if (VariableHourOrQty == "2")//Print Sheet Qty Incl Spoilage
                    {
                        txtHoursID.value = Number(PrintSheetQty_Incl_Spoilage / hid_HourlySpeedID.value);
                    }
                    else if (VariableHourOrQty == "3")//Finished Item Qty
                    {
                        txtHoursID.value = Number(FinishedQty_Excl_Spoilage / hid_HourlySpeedID.value);
                    }
                    //else if (VariableHourOrQty == "4")//Finished Item Qty Incl Spoilage
                    //{
                    //    txtHoursID.value = Number(FinishedQty_Incl_Spoilage / hid_HourlySpeedID.value);
                    //}
                    txtHoursID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtHoursID.value, 0, '', false, false, false);
                }

                hdn_OtherVariableQtyValues.value = "DefaultQtyType»" + DefaultHourOrQtyType + "±FixedQty»" + FixedHourOrQty + "±VariableQty»"
                    + VariableHourOrQty + "±HoursOrQty»" + txtHoursID.value;
            }
            else if (caltype == "f" || caltype == 'm') {
                ////==== Guillotine Cal ======///
                var TotalSheets = PrintSheetQty_Incl_Spoilage;////==== Guillotine Cal ======///
                var Bundles = 0;
                var GuillotineMaximumThroat = '<%=GuillotineMaximumThroat %>';
                var InvPaperHeight = "<%=InvPaperHeight %>";
                var InvPaperWidth = "<%=InvPaperWidth %>";
                Paper_Markup = '<%=PaperMarkup %>';
                Paper_Unit_Price = '<%=PaperUnitPrice %>';
                Pack_Price = '<%=PackedPrice %>';
                Pack_Quantity = '<%=PackedIn %>';
                var paper_markup_price = 0;
                var TotalLengthRequired = 0;
                var TotalAreaRequired = 0;
                if (index < 4) {
                    var PaperCostExMarkup = '<%=PaperCostExMarkup%>'.split('~');
                    Paper_Cost_Exc_Markup = roundNumber(Number(PaperCostExMarkup[index]), 2);
                    Paper_Cost_Exc_Markup = roundNumber(Number(Paper_Cost_Exc_Markup), 2);



                    var PaperMarkupPrice = '<%=PaperMarkupPrice%>'.split('~');
                    paper_markup_price = PaperMarkupPrice[index];
                }

                // by pradeep
                if ('<%=ProductType %>' == "large") {
                    if (index < 4) {
                        var arrTotalLength = strTotalLengthRequired.split('±');
                        var arrTotalArea = strTotalAreaRequired.split('±');
                        TotalLengthRequired = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arrTotalLength[index], 0, '', false, false, false);
                        TotalAreaRequired = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arrTotalArea[index], 0, '', false, false, false);
                    }
                }
                // end by pradeep



                //Paper Calculation
                //                Paper_Cost_Exc_Markup = Number(Paper_Unit_Price) * Number(PrintSheetQty_Incl_Spoilage);
                //                Paper_Cost_Exc_Markup = roundNumber(Number(Paper_Cost_Exc_Markup), 2);


                Paper_Cost_Inc_Markup = Number(Paper_Cost_Exc_Markup) + Number(paper_markup_price);
                Paper_Cost_Inc_Markup = roundNumber(Number(Paper_Cost_Inc_Markup), 2);







                var AnsA = 0;
                var AnsB = 0;
                var NoOfPrintSheets = 0;
                var BundlesOfFirstTrim = 0;

                if (PrintLayout == "P") {
                    if (sheetWidth > 0) {
                        AnsA = parseInt(InvPaperHeight / sheetWidth);
                    }
                    if (sheetHeight > 0) {
                        AnsB = parseInt(InvPaperWidth / sheetHeight);
                    }
                }
                else if (PrintLayout == "L") {
                    if (sheetHeight > 0) {
                        AnsA = parseInt(InvPaperHeight / sheetHeight);
                    }
                    if (sheetWidth > 0) {
                        AnsB = parseInt(InvPaperWidth / sheetWidth);
                    }
                }
                else {
                    if (sheetHeight > 0) {
                        AnsA = parseInt(InvPaperHeight / sheetHeight);
                    }
                    if (sheetWidth > 0) {
                        AnsB = parseInt(InvPaperWidth / sheetWidth);
                    }
                }

                NoOfPrintSheets = Number(AnsA) * Number(AnsB);

                var Cuts = 0;
                var StrObtianSheets = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50");
                var StrObtianCuts = new Array("0", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53");

                for (var s = 0; s < StrObtianSheets.length; s++) {
                    if (NoOfPrintSheets == StrObtianSheets[s]) {
                        Cuts = StrObtianCuts[s];
                    }
                }

                var TotalFirstTrimCuts = 0;
                var NoOfInvPaperRequired = 0;

                if (NoOfPrintSheets > 0) {
                    NoOfInvPaperRequired = Math.ceil(PrintSheetQty_Incl_Spoilage / NoOfPrintSheets);
                    if (GuillotineMaximumThroat > 0) {
                        BundlesOfFirstTrim = Math.ceil(NoOfInvPaperRequired / GuillotineMaximumThroat);
                    }
                    TotalFirstTrimCuts = Cuts * BundlesOfFirstTrim;
                    if (TotalFirstTrimCuts == 0) {
                        BundlesOfFirstTrim = 0;
                    }
                }
                if (chkFirstTrim.checked == false) {
                    BundlesOfFirstTrim = 0;
                    TotalFirstTrimCuts = 0;
                }
                if (GuillotineMaximumThroat != 0) {
                    Bundles = Number(Math.ceil(TotalSheets / GuillotineMaximumThroat));
                }
                if (Bundles == 0) {
                    Bundles = 1;
                }

                var IsYesOrNo = chkGutters.toLowerCase() == "true" ? "yes" : "no";
                var GuillotineSheets = '<%=GuillotineSheets %>'.split('±');
                var SheetWithNoGutters = '<%=SheetWithNoGutters %>'.split('±');
                var SheetWithGutters = '<%=SheetWithGutters %>'.split('±');
                var StandardValue = 0;

                for (var j = 0; j < GuillotineSheets.length - 1; j++) {
                    if (GuillotineSheets[j] == PrintLayoutQty) {
                        if (IsYesOrNo == "yes") {
                            StandardValue = SheetWithGutters[j];
                        }
                        else {
                            StandardValue = SheetWithNoGutters[j];
                        }
                    }
                }

                var SecondTrimCuts = StandardValue * Bundles;

                //==== Guillotine Cal Ends ======///

                //===== Press CAl ====///
                var DigiMethodType = '<%=DigiMethodType %>';
                var PressHourlyCharge = '<%=PressHourlyCharge %>';
                var ColorChargeableRate = '<%=ColorChargeableRate %>';
                var BlackChargeableRate = '<%=BlackChargeableRate %>';
                var NoOfChargeableSheets = '<%=NoOfChargeableSheets %>';
                var PressSetupCharge = '<%=PressSetupCharge %>';
                var PressMinimumRunningCharge = '<%=PressMinimumRunningCharge %>';
                var PressMarkUp = '<%=PressMarkUp %>';
                var PaperWeight = '<%=PaperWeight %>';
                var PaperCaliper = '<%=PaperCaliper %>';
                var HourlyCharge = '<%=HourlyCharge %>';
                var CostPerCut = '<%=CostPerCut %>';

                var Press_Cost = 0;
                var Press_SellPrice = 0;

                if (DigiMethodType == "clickchargelookup") {
                    var ChargeableRate = IsColourOrBlack == "color" ? ColorChargeableRate : BlackChargeableRate;
                    Press_Cost = PressCostPerClick(TotalSheetsVal, ChargeableRate, NoOfChargeableSheets);
                    Press_Cost = roundNumber(Number(Press_Cost), 2);

                    if (IsDoubleSided == true) {
                        ChargeableRate = SideColor == "color" ? ColorChargeableRate : BlackChargeableRate;
                        var SideColor_Cost = PressCostPerClick(TotalSheetsVal, ChargeableRate, NoOfChargeableSheets);
                        SideColor_Cost = roundNumber(Number(SideColor_Cost), 2);

                        Press_Cost = Number(Press_Cost) + Number(SideColor_Cost);
                    }

                }
                else if (DigiMethodType == "speedweightlookup") {
                    var BlackGSM1 = '<%=BlackGSM1 %>';
                    var BlackPagesPerMinute1 = '<%=BlackPagesPerMinute1 %>';
                    var BlackGSM2 = '<%=BlackGSM2 %>';
                    var BlackPagesPerMinute2 = '<%=BlackPagesPerMinute2 %>';
                    var BlackGSM3 = '<%=BlackGSM3 %>';
                    var BlackPagesPerMinute3 = '<%=BlackPagesPerMinute3 %>';
                    var ColorGSM1 = '<%=ColorGSM1 %>';
                    var ColorPagesPerMinute1 = '<%=ColorPagesPerMinute1 %>';
                    var ColorGSM2 = '<%=ColorGSM2 %>';
                    var ColorPagesPerMinute2 = '<%=ColorPagesPerMinute2 %>';
                    var ColorGSM3 = '<%=ColorGSM3 %>';
                    var ColorPagesPerMinute3 = '<%=ColorPagesPerMinute3 %>';

                    var go_1 = true;
                    var go_2 = false;
                    if (IsDoubleSided == true) {
                        go_2 = true;
                    }
                    if (go_1) {
                        if (IsColourOrBlack == "color") {
                            var ColorGSM = 0;
                            var ColorPagesPerMinute = 0;

                            if (PaperWeight <= ColorGSM1) {
                                ColorGSM = ColorGSM1;
                                ColorPagesPerMinute = ColorPagesPerMinute1;
                            }
                            else if (PaperWeight > ColorGSM1 && PaperWeight <= ColorGSM2) {
                                ColorGSM = (ColorGSM1 + ColorGSM2) / 2;
                                var colorValue = Number(ColorPagesPerMinute1) + Number(ColorPagesPerMinute2);
                                ColorPagesPerMinute = Number(Number(colorValue) / 2);
                            }
                            else if (PaperWeight > ColorGSM2 && PaperWeight <= ColorGSM3) {
                                ColorGSM = (ColorGSM2 + ColorGSM3) / 2;
                                var colorValue = Number(ColorPagesPerMinute2) + Number(ColorPagesPerMinute3);
                                ColorPagesPerMinute = Number(Number(colorValue) / 2);
                            }
                            else if (PaperWeight > ColorGSM3) {
                                ColorGSM = ColorGSM3;
                                ColorPagesPerMinute = ColorPagesPerMinute3;
                            }
                            // BY Vinay
                            ColorPagesPerMinute = parseInt(ColorPagesPerMinute);

                            var JobTime = 0;
                            if (ColorPagesPerMinute != 0) {
                                JobTime = Number(TotalSheetsVal) / Number(ColorPagesPerMinute); // MINUTES
                            }

                            JobTime = roundNumber(Number(JobTime), 2);
                            var totalTime = JobTime;

                            Press_Cost = Number(Number(JobTime * HourlyCharge) / 60);
                            Press_Cost = roundNumber(Number(Press_Cost), 2);
                        }
                        else {
                            var BlackGSM = 0;
                            var BlackPagesPerMinute = 0;
                            if (PaperWeight <= BlackGSM1) {
                                BlackGSM = BlackGSM1;
                                BlackPagesPerMinute = BlackPagesPerMinute1;
                            }
                            else if (PaperWeight > BlackGSM1 && PaperWeight <= BlackGSM2) {
                                BlackGSM = Number(Number(BlackGSM1) + Number(BlackGSM2) / 2);
                                var blackValue = Number(BlackPagesPerMinute1) + Number(BlackPagesPerMinute2);
                                BlackPagesPerMinute = Number(Number(blackValue) / 2);

                            }
                            else if (PaperWeight > BlackGSM2 && PaperWeight <= BlackGSM3) {
                                BlackGSM = Number(Number(BlackGSM2) + Number(BlackGSM3) / 2);
                                var blackValue = Number(BlackPagesPerMinute2) + Number(BlackPagesPerMinute3);
                                BlackPagesPerMinute = Number(Number(blackValue) / 2);
                            }
                            else if (PaperWeight > BlackGSM3) {
                                BlackGSM = BlackGSM3;
                                BlackPagesPerMinute = BlackPagesPerMinute3;
                            }
                            // BY Vinay
                            BlackPagesPerMinute = parseInt(BlackPagesPerMinute);

                            var JobTime = 0;
                            if (BlackPagesPerMinute != 0) {
                                JobTime = Number(TotalSheetsVal) / Number(BlackPagesPerMinute); // MINUTES
                            }
                            JobTime = roundNumber(Number(JobTime), 2);
                            totalTime = JobTime;

                            Press_Cost = Number(Number(JobTime) * Number(HourlyCharge) / 60);
                            Press_Cost = roundNumber(Number(Press_Cost), 2);
                        }
                    }

                    if (go_2) {

                        var SideColor_Cost = 0;
                        if (SideColor == "color") {
                            var ColorGSM = 0;
                            var ColorPagesPerMinute = 0;

                            if (PaperWeight <= ColorGSM1) {
                                ColorGSM = ColorGSM1;
                                ColorPagesPerMinute = ColorPagesPerMinute1;
                            }
                            else if (PaperWeight > ColorGSM1 && PaperWeight <= ColorGSM2) {
                                ColorGSM = (ColorGSM1 + ColorGSM2) / 2;
                                var colorValue = Number(ColorPagesPerMinute1) + Number(ColorPagesPerMinute2);
                                ColorPagesPerMinute = Number(Number(colorValue) / 2);
                            }
                            else if (PaperWeight > ColorGSM2 && PaperWeight <= ColorGSM3) {
                                ColorGSM = (ColorGSM2 + ColorGSM3) / 2;
                                var colorValue = Number(ColorPagesPerMinute2) + Number(ColorPagesPerMinute3);
                                ColorPagesPerMinute = Number(Number(colorValue) / 2);
                            }
                            else if (PaperWeight > ColorGSM3) {
                                ColorGSM = ColorGSM3;
                                ColorPagesPerMinute = ColorPagesPerMinute3;
                            }
                            // BY Vinay
                            ColorPagesPerMinute = parseInt(ColorPagesPerMinute);

                            var JobTime = 0;
                            if (ColorPagesPerMinute != 0) {
                                JobTime = Number(TotalSheetsVal) / Number(ColorPagesPerMinute); // MINUTES
                            }
                            JobTime = roundNumber(Number(JobTime), 2);
                            var totalTime = JobTime;

                            SideColor_Cost = Number(Number(JobTime * HourlyCharge) / 60);
                            SideColor_Cost = roundNumber(Number(SideColor_Cost), 2);
                        }
                        else {
                            var BlackGSM = 0;
                            var BlackPagesPerMinute = 0;
                            if (PaperWeight <= BlackGSM1) {
                                BlackGSM = BlackGSM1;
                                BlackPagesPerMinute = BlackPagesPerMinute1;
                            }
                            else if (PaperWeight > BlackGSM1 && PaperWeight <= BlackGSM2) {
                                BlackGSM = Number(Number(BlackGSM1) + Number(BlackGSM2) / 2);
                                var blackValue = Number(BlackPagesPerMinute1) + Number(BlackPagesPerMinute2);
                                BlackPagesPerMinute = Number(Number(blackValue) / 2);

                            }
                            else if (PaperWeight > BlackGSM2 && PaperWeight <= BlackGSM3) {
                                BlackGSM = Number(Number(BlackGSM2) + Number(BlackGSM3) / 2);
                                var blackValue = Number(BlackPagesPerMinute2) + Number(BlackPagesPerMinute3);
                                BlackPagesPerMinute = Number(Number(blackValue) / 2);
                            }
                            else if (PaperWeight > BlackGSM3) {
                                BlackGSM = BlackGSM3;
                                BlackPagesPerMinute = BlackPagesPerMinute3;
                            }
                            // BY Vinay
                            BlackPagesPerMinute = parseInt(BlackPagesPerMinute);

                            var JobTime = 0;
                            if (BlackPagesPerMinute != 0) {
                                JobTime = Number(TotalSheetsVal) / Number(BlackPagesPerMinute); // MINUTES
                            }
                            JobTime = roundNumber(Number(JobTime), 2);
                            totalTime = JobTime;


                            SideColor_Cost = Number(Number(JobTime) * Number(HourlyCharge) / 60);
                            SideColor_Cost = roundNumber(Number(SideColor_Cost), 2);
                        }
                        Press_Cost = Number(Press_Cost) + Number(SideColor_Cost);
                        Press_Cost = roundNumber(Number(Press_Cost), 2);
                    }
                }
                else if (DigiMethodType == "clickchargezonelookup") {
                    var go_1 = true;
                    var go_2 = false;

                    if (IsDoubleSided == true) {
                        go_2 = true;
                    }

                    if (go_1) {
                        Press_Cost = Zone_Calculation(TotalSheetsVal, IsColourOrBlack);
                        Press_Cost = roundNumber(Number(Press_Cost), 2);

                    } //end of Color

                    if (go_2) {
                        var SideColor_Cost = Zone_Calculation(TotalSheetsVal, SideColor);
                        SideColor_Cost = roundNumber(Number(SideColor_Cost), 2);

                        Press_Cost = Number(Press_Cost) + Number(SideColor_Cost);
                        Press_Cost = roundNumber(Number(Press_Cost), 2);

                    } //End of Side Color
                }

                Press_Cost = Number(Press_Cost) + Number(PressSetupCharge);
                Press_Cost = roundNumber(Number(Press_Cost), 2);

                if (Number(PressMinimumRunningCharge) > Number(Press_Cost)) {
                    Press_Cost = Number(PressMinimumRunningCharge);
                }



                //From New _reeng starts by gaj

                //From New _reeng starts by gaj



                if (isNaN(Press_Cost)) {
                    Press_Cost = 0;
                }


                var PressMarkupPrice = ((Press_Cost * PressMarkUp) / 100);
                Press_SellPrice = Number(Press_Cost) + Number(PressMarkupPrice);
                Press_SellPrice = roundNumber(Number(Press_SellPrice), 2);

                //===== Press CAl Ends ====///

                /////////////////////GAJ

                //  if ('<%=EstimateType%>'.toLowerCase() == 'f' || '<%=EstimateType%>'.toLowerCase() == 'k' || '<%=EstimateType%>'.toLowerCase() == 'n' || '<%=EstimateType%>'.toLowerCase() == 'd') {


                if (index < 4) {
                    var PressArray = '<%=OtherCostPressValues%>'.split('~');
                    Press_SellPrice = roundNumber(Number(PressArray[index]), 2);


                    var PressArrayExMarkup = '<%=OtherCostPressCostExMarkup%>'.split('~');
                    Press_Cost = roundNumber(Number(PressArrayExMarkup[index]), 2);

                    var PressArrayHourlyCharge = '<%=OtherCostPressValuesHourlyCharge%>'.split('~');
                    PressHourlyCharge = roundNumber(Number(PressArrayHourlyCharge[index]), 2);






                }


                //  }





                //////////////////////////




                var key = '<%=Key %>';
                //var Actual = para_formula; /////'<%=FormulaTag %>';
                var str = key.split('±');
                var repstr = "";
                for (var i = 0; i < str.length - 1; i++) {
                    var formula = str[i].toString();
                    //Booklet//
                  
                    if ('<%=ProductType %>' == "booklet" || '<%=ProductType %>' == "ncr") {
                        if (formula.toLowerCase() == "booklet quantity required(section 1)") {
                            txtQty = txtQty == "" ? "0" : txtQty;
                            txtQty = isNaN(txtQty) == true ? 0 : txtQty;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtQty, 0, '', true, false, false));

                        }
                        else if (formula.toLowerCase() == "pages in this section only")///pages per section
                        {
                            txtNoOfPagesInSection = txtNoOfPagesInSection == "" ? "0" : txtNoOfPagesInSection;
                            txtNoOfPagesInSection = isNaN(txtNoOfPagesInSection) == true ? 0 : txtNoOfPagesInSection;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfPagesInSection, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "number of sections") {
                            //if (Number(pw.bookArr.length) != 0) {
                            if (Number(NoOfSections) != 0) {
                                NoOfSections = NoOfSections == "" ? "0" : NoOfSections;
                                NoOfSections = isNaN(NoOfSections) == true ? 0 : NoOfSections;
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, NoOfSections, 0, '', true, false, false));
                            }
                            else {
                                Actual = ReplaceAll(Actual.toString(), formula, "1");
                            }
                        }
                        else if (formula.toLowerCase() == "total number of pages (all sections)") {
                            //if (Number(pw.bookArr.length) != 0) {
                            //                            if (Number(NoOfSections) != 0) {
                            //                                var Temp_BookArr = NoOfSections; //pw.bookArr; OLD
                            //                                var PPSCount = 0;
                            //                                for (var t = 0; t < NoOfSections; t++) {
                            //                                    PPSCount = Number(PPSCount) + Number(txtNoOfPagesInSection);
                            //                                }
                            //                                PPSCount = isNaN(PPSCount) == true ? 0 : PPSCount;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalPagesAllSections, 0, '', true, false, false));

                            //                            }
                            //                            else {
                            //                                txtNoOfPagesInSection = isNaN(txtNoOfPagesInSection) == true ? 0 : txtNoOfPagesInSection;
                            //                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfPagesInSection, 0, '', true, false, false));
                            //                            }
                        }
                        else if (formula.toLowerCase() == "print sheet quantity this section (excluding spoilage)") {
                            PrintSheetQty_Excl_Spoilage = isNaN(PrintSheetQty_Excl_Spoilage) == true ? 0 : PrintSheetQty_Excl_Spoilage;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Excl_Spoilage, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "print sheet quantity this section (including spoilage)") {
                            PrintSheetQty_Incl_Spoilage = isNaN(PrintSheetQty_Incl_Spoilage) == true ? 0 : PrintSheetQty_Incl_Spoilage;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Incl_Spoilage, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "print sheet quantity all sections (excluding spoilage)") {
                            //if (Number(pw.bookArr.length) != 0) {

                            //                            if (Number(NoOfSections) != 0) {
                            //                                var Temp_BookArr = NoOfSections; //pw.bookArr; OLD
                            //                                var SheetCount = 0;
                            //                                for (var t = 0; t < NoOfSections; t++) {
                            //                                    SheetCount = SheetCount + Number(txtQty) * Number(NoOfSignatures);
                            //                                }
                            //                                if (pw.PresentSectionID == null) {
                            //                                    SheetCount = Number(SheetCount) + Number(PrintSheetQty_Excl_Spoilage);
                            //                                }
                            //                                SheetCount = isNaN(SheetCount) == true ? 0 : SheetCount;
                            //                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SheetCount, 0, '', true, false, false));
                            //                            }
                            //                            else {
                            //                                PrintSheetQty_Excl_Spoilage = isNaN(PrintSheetQty_Excl_Spoilage) == true ? 0 : PrintSheetQty_Excl_Spoilage;
                            //                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Excl_Spoilage, 0, '', true, false, false));
                            //                            }


                            if (index < 4) {
                                debugger;
                                var PrintSheetsAllSections_ExcludeSpoilage = '<%=PrintSheetsAllSections_ExcludeSpoilage%>'.split('~');
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetsAllSections_ExcludeSpoilage[index], 0, '', false, false, false));
                            }
                        }
                        else if (formula.toLowerCase() == "print sheet quantity all sections (including spoilage)") {
                            //if (Number(pw.bookArr.length) != 0) {
                            //                            if (Number(NoOfSections) != 0) 
                            //                            {
                            //                                var Temp_BookArr = NoOfSections; //pw.bookArr; OLD
                            //                                var SheetCountInc = 0;
                            //                                for (var t = 0; t < NoOfSections; t++)
                            //                                 {
                            //                                    var SheetCount_t = Number(txtQty) * Number(NoOfSignatures);
                            //                                    var SheetCount_runn = (Number(SheetCount_t) * Number(RunningSpoilage)) / 100;
                            //                                    var SheetCount_inc_spoil = Number(SheetCount_t) + Number(SheetCount_runn) + Number(SetupSpoilage);
                            //                                    SheetCountInc = Number(SheetCountInc) + Number(SheetCount_inc_spoil);
                            //                                }
                            //                                if (pw.PresentSectionID == null)
                            //                                 {
                            //                                    SheetCountInc = Number(SheetCountInc) + Number(PrintSheetQty_Incl_Spoilage);
                            //                                }
                            //                                SheetCountInc = isNaN(SheetCountInc) == true ? 0 : SheetCountInc;
                            //                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SheetCountInc, 0, '', false, false, false));
                            //                            }
                            //                            else 
                            //                            {
                            //                                PrintSheetQty_Incl_Spoilage = isNaN(PrintSheetQty_Incl_Spoilage) == true ? 0 : PrintSheetQty_Incl_Spoilage;
                            //                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Incl_Spoilage, 0, '', false, false, false));
                            //                            }


                            if (index < 4) {
                                var PrintSheetsAllSections = '<%=PrintSheetsAllSections%>'.split('~');
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetsAllSections[index], 0, '', false, false, false));
                            }
                        }
                        else if (formula.toLowerCase() == "parts per set" && '<%=ProductType %>' == "ncr") {
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Partsperset, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "sets per pad" && '<%=ProductType %>' == "ncr") {
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Setsperpad, 0, '', true, false, false));
                        }
                    }
                    //Pads//
                    else if ('<%=ProductType %>' == "pads") {
                        if (formula.toLowerCase() == "number of leaves per pad") {
                            txtNoOfLeavesPerPad = txtNoOfLeavesPerPad == "" ? "0" : txtNoOfLeavesPerPad;
                            txtNoOfLeavesPerPad = isNaN(txtNoOfLeavesPerPad) == true ? 0 : txtNoOfLeavesPerPad;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtNoOfLeavesPerPad, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "number of pads") {
                            txtQty = txtQty == "" ? "0" : txtQty;
                            txtQty = isNaN(txtQty) == true ? 0 : txtQty;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtQty, 0, '', true, false, false));
                        }
                    }
                    else if ('<%=ProductType %>' == "ncr") {
                        if (formula.toLowerCase() == "parts per set") {
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Partsperset, 0, '', true, false, false));
                        }
                        else if (formula.toLowerCase() == "sets per pad") {
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Setsperpad, 0, '', true, false, false));
                        }
                    }

                    else if ('<%=ProductType %>' == "large") { // by pradeep
                        if (formula.toLowerCase() == 'large format item area (sq. meter)' || formula.toLowerCase() == 'large format item area (sq. feet)') {
                            if ('<%=strcalctype %>' == "linear") {
                                TotalLengthRequired = TotalLengthRequired == "" ? "0" : TotalLengthRequired;
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalLengthRequired, 0, '', false, false, false));
                            }
                            else if ('<%=strcalctype %>' == "square") {
                                TotalAreaRequired = TotalAreaRequired == "" ? "0" : TotalAreaRequired;
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalAreaRequired, 0, '', false, false, false));
                            }
                        }

                        if (formula.toLowerCase() == 'large format item width (meter)' || formula.toLowerCase() == 'large format item width (feet)') {
                            var JobWidth = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, strjobwidth, 0, '', false, false, false);

                            if ('<%=PaperMeasure %>' == "In.") {
                                JobWidth = JobWidth / 12;
                            }
                            else {
                                JobWidth = JobWidth / 1000;
                            }

                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, JobWidth, 0, '', false, false, false));
                        }

                        if (formula.toLowerCase() == 'large format item height (meter)' || formula.toLowerCase() == 'large format item height (feet)') {
                            var JobHeight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, strjobheight, 0, '', false, false, false);

                            if ('<%=PaperMeasure %>' == "In.") {
                                JobHeight = JobHeight / 12;
                            }
                            else {
                                JobHeight = JobHeight / 1000;
                            }
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, JobHeight, 0, '', false, false, false));
                        }

                        if (formula.toLowerCase() == 'total length required (meter)') {
                            TotalLengthRequired = TotalLengthRequired == "" ? "0" : TotalLengthRequired;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalLengthRequired, 0, '', false, false, false));
                        }
                        else if (formula.toLowerCase() == 'total area required (sq.meter)') {
                            TotalAreaRequired = TotalAreaRequired == "" ? "0" : TotalAreaRequired;
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalAreaRequired, 0, '', false, false, false));
                        }
                    }
                    //end by pradeep 

                    //Guillotine//
                    if (formula.toLowerCase() == "guillotine bundles") {
                        Bundles = isNaN(Bundles) == true ? 0 : Bundles;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Bundles, 0, '', true, false, false));
                    }
                    else if (formula.toLowerCase() == "guillotine cost per cut") {
                        CostPerCut = isNaN(CostPerCut) == true ? 0 : CostPerCut;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, CostPerCut, 0, '', false, false, false)); //'<%=CostPerCut %>'
                    }
                    else if (formula.toLowerCase() == "number of cuts in first trim") {
                        TotalFirstTrimCuts = TotalFirstTrimCuts == "" ? "0" : TotalFirstTrimCuts;
                        TotalFirstTrimCuts = isNaN(TotalFirstTrimCuts) == true ? 0 : TotalFirstTrimCuts;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, TotalFirstTrimCuts, 0, '', true, false, false));
                    }
                    else if (formula.toLowerCase() == "number of cuts in second trim") {
                        SecondTrimCuts = SecondTrimCuts == "" ? "0" : SecondTrimCuts;
                        SecondTrimCuts = isNaN(SecondTrimCuts) == true ? 0 : SecondTrimCuts;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, SecondTrimCuts, 0, '', true, false, false));
                    }

                    //Press
                    else if (formula.toLowerCase() == "press hourly charge") {
                        PressHourlyCharge = PressHourlyCharge == "" ? "0" : PressHourlyCharge;
                        PressHourlyCharge = isNaN(PressHourlyCharge) == true ? 0 : PressHourlyCharge;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PressHourlyCharge, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "total press cost price") {
                        Press_Cost = Press_Cost == "" ? "0" : Press_Cost;
                        Press_Cost = isNaN(Press_Cost) == true ? 0 : Press_Cost;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Press_Cost, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "total press selling price") {
                        Press_SellPrice = Press_SellPrice == "" ? "0" : Press_SellPrice;
                        Press_SellPrice = isNaN(Press_SellPrice) == true ? 0 : Press_SellPrice;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Press_SellPrice, 0, '', false, false, false));
                    }
                    //General
                    else if (formula.toLowerCase() == "print sheet quantity (excluding spoilage)") {
                        PrintSheetQty_Excl_Spoilage = PrintSheetQty_Excl_Spoilage == "" ? "0" : PrintSheetQty_Excl_Spoilage;
                        PrintSheetQty_Excl_Spoilage = isNaN(PrintSheetQty_Excl_Spoilage) == true ? 0 : PrintSheetQty_Excl_Spoilage;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Excl_Spoilage, 0, '', true, false, false));
                    }

                    else if (formula.toLowerCase() == "print sheet quantity section 1") {

                        var PrintSheetsSections1_ExcludeSpoilage = '<%=PrintSheetsSections1_ExcludeSpoilage%>'.split('~');
                        PrintSheetsSections1_ExcludeSpoilage = PrintSheetsSections1_ExcludeSpoilage[index];

                        PrintSheetsSections1_ExcludeSpoilage = PrintSheetsSections1_ExcludeSpoilage == "" ? "0" : PrintSheetsSections1_ExcludeSpoilage;
                        PrintSheetsSections1_ExcludeSpoilage = isNaN(PrintSheetsSections1_ExcludeSpoilage) == true ? 0 : PrintSheetsSections1_ExcludeSpoilage;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetsSections1_ExcludeSpoilage, 0, '', true, false, false));
                    }

                    else if (formula.toLowerCase() == "print sheet quantity (including spoilage)") {
                        PrintSheetQty_Incl_Spoilage = PrintSheetQty_Incl_Spoilage == "" ? "0" : PrintSheetQty_Incl_Spoilage;
                        PrintSheetQty_Incl_Spoilage = isNaN(PrintSheetQty_Incl_Spoilage) == true ? 0 : PrintSheetQty_Incl_Spoilage;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PrintSheetQty_Incl_Spoilage, 0, '', true, false, false));
                    }
                    else if (formula.toLowerCase() == "finished job quantity")///finished job quantity (excluding spoilage)
                    {
                        txtQty = txtQty == "" ? "0" : txtQty;
                        txtQty = isNaN(txtQty) == true ? 0 : txtQty;
                        Actual = ReplaceAll(Actual.toString(), formula, txtQty);
                    }
                    else if (formula.toLowerCase() == "paper basis weight (gsm)") {
                        debugger;
                        PaperWeight = PaperWeight == "" ? "0" : PaperWeight;
                        PaperWeight = isNaN(PaperWeight) == true ? 0 : PaperWeight;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PaperWeight, 0, '', false, false, false));
                    }

                    else if (formula.toLowerCase() == "paper caliper (micron)" || formula.toLowerCase() == "paper caliper (point)" || formula.toLowerCase() == "paper caliper (mils)") {
                        debugger;
                        PaperCaliper = PaperCaliper == "" ? "0" : PaperCaliper;
                        PaperCaliper = isNaN(PaperCaliper) == true ? 0 : PaperCaliper;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, PaperCaliper, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "paper cost (excluding markup)") {
                        Paper_Cost_Exc_Markup = Paper_Cost_Exc_Markup == "" ? "0" : Paper_Cost_Exc_Markup;
                        Paper_Cost_Exc_Markup = isNaN(Paper_Cost_Exc_Markup) == true ? 0 : Paper_Cost_Exc_Markup;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Paper_Cost_Exc_Markup, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "paper cost (including markup)") {
                        Paper_Cost_Inc_Markup = Paper_Cost_Inc_Markup == "" ? "0" : Paper_Cost_Inc_Markup;
                        Paper_Cost_Inc_Markup = isNaN(Paper_Cost_Inc_Markup) == true ? 0 : Paper_Cost_Inc_Markup;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Paper_Cost_Inc_Markup, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "spoilage percentage used") {
                        Spoilage_Percentage_Used = Spoilage_Percentage_Used == "" ? "0" : Spoilage_Percentage_Used;
                        Spoilage_Percentage_Used = isNaN(Spoilage_Percentage_Used) == true ? 0 : Spoilage_Percentage_Used;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Spoilage_Percentage_Used, 0, '', true, false, false));
                    }
                    else if (formula.toLowerCase() == "spoilage sheets used") {
                        Spoilage_Sheets_Used = Spoilage_Sheets_Used == "" ? "0" : Spoilage_Sheets_Used;
                        Spoilage_Sheets_Used = isNaN(Spoilage_Sheets_Used) == true ? 0 : Spoilage_Sheets_Used;
                        Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Spoilage_Sheets_Used, 0, '', false, false, false));
                    }
                    else if (formula.toLowerCase() == "matrix") {
                        if (txtMatrixval != '') {
                            txtMatrixval = txtMatrixval == "" ? "0" : txtMatrixval;
                            txtMatrixval = isNaN(txtMatrixval) == true ? 0 : txtMatrixval;
                            Actual = ReplaceAll(Actual.toString(), formula, txtMatrixval);
                        }
                    }
                    else if (pgtype == "estimate" || pgtype == "job" || pgtype == "invoice")
                    {
                        if (('<%=ProductType %>' == "singleitem") || ('<%=ProductType %>' == "booklet") || ('<%=ProductType %>' == "pads") || ('<%=ProductType %>' == "ncr"))
                        {
                            if (formula.toLowerCase() == 'small format item height') {
                                var JobHeight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, strjobheight, 0, '', false, false, false);

                                if ('<%=PaperMeasure %>' == "In.") {
                                //JobHeight = JobHeight / 12;
                                formula = formula + " " + "(inches)";
                            }
                            else {
                                //JobHeight = JobHeight / 1000;
                                formula = formula + " " + "(mm)";

                            }
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, JobHeight, 0, '', false, false, false));
                            }
                            else if (formula.toLowerCase() == 'small format item width') {
                            var JobWidth = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, strjobwidth, 0, '', false, false, false);

                                    if ('<%=PaperMeasure %>' == "In.") {
                                        //JobWidth = JobWidth / 12;
                                        formula = formula + " " + "(inches)";
                                    }
                                    else {
                                        //JobWidth = JobWidth / 1000;
                                        formula = formula + " " + "(mm)";

                                    }

                                    Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, JobWidth, 0, '', false, false, false));
                                }
                        }

                    }
                   

                    if ('<%=MatrixType %>' == "G") {
                        if (formula.toLowerCase() == "large format item height (feet)" || formula.toLowerCase() == "large format item height (meter)") {
                            var HeightList = '<%=HeightList %>';
                            if (HeightList.length > 0) {
                                var HeightList_Array = HeightList.split('§');
                                var finalheight = 0;

                                if ('<%=PaperMeasure %>' == "In.") {
                    finalheight = HeightList_Array[index] / 12;
                }
                else {
                    finalheight = HeightList_Array[index] / 1000;
                }

            }
            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalheight, 0, '', false, false, false));
        }

        if (formula.toLowerCase() == "large format item width (feet)" || formula.toLowerCase() == "large format item width (meter)") {
            var WidthList = '<%=WidthList %>';
                            if (WidthList.length > 0) {
                                var WidthList_Array = WidthList.split('§');
                                var finalwidth;

                                if ('<%=PaperMeasure %>' == "In.") {
                    finalwidth = WidthList_Array[index] / 12;
                }
                else {
                    finalwidth = WidthList_Array[index] / 1000;
                }

                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalwidth, 0, '', false, false, false));
            }
        }

        if (formula.toLowerCase() == 'large format item area (sq. meter)' || formula.toLowerCase() == 'large format item area (sq. feet)') {

            var HeightList = '<%=HeightList %>';
                            var WidthList = '<%=WidthList %>';

                            if (HeightList.length > 0 && WidthList.length > 0) {

                                var HeightList_Array = HeightList_Array[index];
                                var WidthList_Array = WidthList_Array[index];

                                var finalresult = 0;
                                var finalAwidth = 0;
                                var finalAheight = 0;
                                if ('<%=PaperMeasure %>' == "In.") {
                                    finalAwidth = WidthList_Array / 12;
                                    finalAheight = HeightList_Array / 12;
                                }
                                else {
                                    finalAwidth = WidthList_Array / 1000;
                                    finalAheight = HeightList_Array / 1000;
                                }

                                finalresult = finalAwidth * finalAheight;
                                Actual = ReplaceAll(Actual.toString(), formula, finalresult, 0, '', false, false, false);
                            }
                            else {
                                Actual = ReplaceAll(Actual.toString(), formula, 0, 0, '', false, false, false);
                            }
                        }
                    }

                    if (formula.toLowerCase() == "product height") {
                        var HeightList = '<%=HeightList %>';
                        if (HeightList.length > 0) {
                            var HeightList_Array = HeightList.split('§');
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, HeightList_Array[index], 0, '', false, false, false));
                        }
                    }
                    if (formula.toLowerCase() == "product width") {
                        var WidthList = '<%=WidthList %>';
                        if (WidthList.length > 0) {
                            var WidthList_Array = WidthList.split('§');
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, WidthList_Array[index], 0, '', false, false, false));
                        }
                    }
                    if (formula.toLowerCase() == "product weight") {
                        var WeightList = '<%=WeightList %>';
                        if (WeightList.length > 0) {
                            var WeightList_Array = WeightList.split('§');
                            Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, WeightList_Array[index], 0, '', false, false, false));
                        }
                    }
                    if (formula.toLowerCase() == "product length") {
                        var LengthList = '<%=LengthList %>';
                        var MatrixType = '<%=MatrixType %>';
                        if (MatrixType.toLowerCase() != 'g') {
                            if (LengthList.length > 0) {
                                var LengthList_Array = LengthList.split('§');
                                Actual = ReplaceAll(Actual.toString(), formula, Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, LengthList_Array[index], 0, '', false, false, false));
                            }
                        }
                    }

                    Actual = Actual.toString().trim();
                    repstr = Actual.toString().trim();

                    if (index == 0) {
                        txtWithActualsID.value = repstr;
                    }
                    else if (index == 1) {
                        txtWithActualsID1.value = repstr;
                    }
                    else if (index == 2) {
                        txtWithActualsID2.value = repstr;
                    }
                    else if (index == 3) {
                        txtWithActualsID3.value = repstr;
                    }
                }
            }
        }
        ActualArray[index] = Actual;
    }

    function ReplaceAll(CompleteString, ReplaceThis, RepolaceWith) {
        return CompleteString = CompleteString.split(ReplaceThis).join(RepolaceWith);
    }


    function Zone_Calculation(TotalSheetsVal_1, Color) {
        var ZoneFromDATA = Color == "black" ? '<%=ZoneFrom %>' : '<%=ColoredZoneFrom %>';
    var ZoneToDATA = Color == "black" ? '<%=ZoneTo %>' : '<%=ColoredZoneTo %>';
    var ChargeableRateDATA = Color == "black" ? '<%=ChargeableRate %>' : '<%=ColoredChargeableRate %>';
    var ChargeableSheetsDATA = Color == "black" ? '<%=ChargeableSheets %>' : '<%=ColoredChargeableSheets %>';

    var ZoneFrom = ZoneFromDATA.split('±');
    var ZoneTo = ZoneToDATA.split('±');
    var ChargeableRate = ChargeableRateDATA.split('±');
    var ChargeableSheets = ChargeableSheetsDATA.split('±');
    var ZoneMarkup = '<%=ZoneMarkup %>'.split('±');

    var CostOfTotalClick = 0;
    var ZoneTotalMarkupPrice = 0;
    var ZoneTotalCostPrice = 0;
    var DigiCalculationType = "<%=DigiCalculationType %>";

        if (DigiCalculationType == "False" || DigiCalculationType == "false") {
            var MaxSheet = 0;
            for (var i = 0; i < ZoneFrom.length; i++) {
                if (ZoneFrom[i] != '') {
                    MaxSheet = ZoneFrom[i];
                }
            }
            for (var i = 0; i < ZoneFrom.length; i++) {
                if (ZoneFrom[i] != '') {
                    if (Number(TotalSheetsVal_1) > Number(MaxSheet)) {
                        if (MaxSheet == ZoneFrom[i]) {
                            CostOfOneClick = PressCostPerClick(TotalSheetsVal_1, ChargeableRate[i], ChargeableSheets[i]);
                            CostOfTotalClick = Number(CostOfTotalClick) + Number(CostOfOneClick);

                            //                            CostPriceOfOne = Number((ChargeableRate[i]/ZoneMarkup[i]) * 100);  
                            //                            ZoneTotalCostPrice = ZoneTotalCostPrice + CostPriceOfOne;                
                            //                            
                            //                            MarkupPriceOfOneClick = Number((CostPriceOfOne * ZoneMarkup[i]) / 100);
                            //                            ZoneTotalMarkupPrice = ZoneTotalMarkupPrice + MarkupPriceOfOneClick;     
                        }
                    }
                    else {
                        if (ZoneFrom[i] <= TotalSheetsVal_1 && TotalSheetsVal_1 <= ZoneTo[i]) {
                            CostOfOneClick = PressCostPerClick(TotalSheetsVal_1, ChargeableRate[i], ChargeableSheets[i]);
                            CostOfTotalClick = Number(CostOfTotalClick) + Number(CostOfOneClick);

                            //                            CostPriceOfOne = Number((ChargeableRate[i]/ZoneMarkup[i]) * 100);  
                            //                            ZoneTotalCostPrice = ZoneTotalCostPrice + CostPriceOfOne;                
                            //                            
                            //                            MarkupPriceOfOneClick = Number((CostPriceOfOne * ZoneMarkup[i]) / 100);
                            //                            ZoneTotalMarkupPrice = ZoneTotalMarkupPrice + MarkupPriceOfOneClick;     
                        }
                    }
                }
            }
        }
        else {
            for (var i = 0; i < ZoneFrom.length; i++) {
                var Paper1 = ZoneTo[i] - ZoneFrom[i];
                var CostOfOneClick = 0;

                if (Paper1 > 0) {
                    var RemainingPaper = TotalSheetsVal_1;
                    TotalSheetsVal_1 = TotalSheetsVal_1 - Paper1;

                    if (TotalSheetsVal_1 > 0) {
                        CostOfOneClick = PressCostPerClick(Paper1, ChargeableRate[i], ChargeableSheets[i]);
                        CostOfTotalClick = Number(CostOfTotalClick) + Number(CostOfOneClick);

                        //                        CostPriceOfOne = Number((ChargeableRate[i]/ZoneMarkup[i]) * 100);  
                        //                        ZoneTotalCostPrice = ZoneTotalCostPrice + CostPriceOfOne;                
                        //                        
                        //                        MarkupPriceOfOneClick = Number((CostPriceOfOne * ZoneMarkup[i]) / 100);
                        //                        ZoneTotalMarkupPrice = ZoneTotalMarkupPrice + MarkupPriceOfOneClick;     

                    }
                    else {
                        CostOfOneClick = PressCostPerClick(RemainingPaper, ChargeableRate[i], ChargeableSheets[i]);
                        CostOfTotalClick = Number(CostOfTotalClick) + Number(CostOfOneClick);

                        //                        CostPriceOfOne = Number((ChargeableRate[i]/ZoneMarkup[i]) * 100);  
                        //                        ZoneTotalCostPrice = ZoneTotalCostPrice + CostPriceOfOne;                
                        //                        
                        //                        MarkupPriceOfOneClick = Number((CostPriceOfOne * ZoneMarkup[i]) / 100);
                        //                        ZoneTotalMarkupPrice = ZoneTotalMarkupPrice + MarkupPriceOfOneClick;     
                        break;
                    }
                }
                else {
                    if (TotalSheetsVal_1 > 0) {
                        CostOfOneClick = PressCostPerClick(TotalSheetsVal_1, ChargeableRate[i], ChargeableSheets[i]);
                        CostOfTotalClick = Number(CostOfTotalClick) + Number(CostOfOneClick);

                        //                        CostPriceOfOne = Number((ChargeableRate[i]/ZoneMarkup[i]) * 100);  
                        //                        ZoneTotalCostPrice = ZoneTotalCostPrice + CostPriceOfOne;                
                        //                        
                        //                        MarkupPriceOfOneClick = Number((CostPriceOfOne * ZoneMarkup[i]) / 100);
                        //                        ZoneTotalMarkupPrice = ZoneTotalMarkupPrice + MarkupPriceOfOneClick;     
                        break;
                    }
                }
            }
        }
        //hdn_ZoneMarkupPrice.value = Number(ZoneTotalMarkupPrice);  
        //hdn_ZoneCostPrice.value = Number(ZoneTotalCostPrice);   
        return CostOfTotalClick;
    }

    function CreateHTML(ques, index, ActualData) {

        var str = '';
        var Qty1 = "<%=Qty1 %>";
    var Qty2 = "<%=Qty2 %>";
    var Qty3 = "<%=Qty3 %>";
    var Qty4 = "<%=Qty4 %>";

    var QtyNo = "<%=QtyNo %>";

        str += "<div id='div_ques_" + index + "' style='display:none;'>";
        str += "<table cellpadding='0' cellspacing='0' width='100%'>";
        str += "<tr>";
        str += "<td colspan='2' class='popup-top-leftcorner'>&nbsp;</td>";
        str += "<td class='popup-top-middlebg'>";
        str += "<div align='left' class='Label-PopupHeading' style='float: left; padding-top: 6px; padding-left: 1px'><b>Question </b></div>";
        str += "</td>";
        str += "<td colspan='2' class='popup-top-rightcorner'> &nbsp;</td>";
        str += "</tr>";
        str += "<tr>";
        str += "<td class='popup-middle-leftcorner'>&nbsp;</td>";
        str += "<td style='width: 15px; background-color: #ffffff'>&nbsp;</td>";
        str += "<td class='popup-middlebg' align='center'>";

        str += "<div class='only5px'></div>";
        str += "<div align='left' style='padding:5px;' >";
        str += "<span class='headerText'>" + SpecialDecode(ques) + "</span>";
        str += "</div>";
        str += "<div style='float:left;width:4%'>&nbsp;</div><div width='96%' align='center' style='float:left;border:solid 0px red' >";
        str += "<div style='float:left;width:500px;border:solid 0px red' >";
        str += "<table cellpadding='0px' cellspacing='0px' width='100%' align='center' border='0px'>";
        //str += "<tr> <td align='left'>"+ ques +"</td> </tr>";
        str += "<tr> <td align='left' class='only10px'> </td> </tr>";

        str += "<tr align='left'><td align='center' width='100%' style='border:solid 0px red'>";

        if ((QtyNo == 0 || QtyNo == 1)) {

            str += "<div align='center' style='23%;float:left;padding-right:10px;padding-left:4px'><div align='left' style='width:110px;float:left'><span class='headerText' width='22%'>Qty1: " + Qty1 + "</span></div></div>";
        }

        if (Qty2 != '' && Qty2 != 0 && (QtyNo == 0 || QtyNo == 2)) {
            document.getElementById("WithActuals1").style.display = "block";
            document.getElementById("FormulaCost1").style.display = "block";
            document.getElementById("FormulaProfit1").style.display = "block";
            document.getElementById("FormulaSellingPrice1").style.display = "block";
            str += "<div style='22%;float:left;padding-right:10px'><div align='left' style='width:110px;float:left'><span class='headerText' width='22%'>Qty2: " + Qty2 + "</span></div></div>";
        }
        if (Qty3 != '' && Qty3 != 0 && (QtyNo == 0 || QtyNo == 3)) {
            document.getElementById("WithActuals2").style.display = "block";
            document.getElementById("FormulaCost2").style.display = "block";
            document.getElementById("FormulaProfit2").style.display = "block";
            document.getElementById("FormulaSellingPrice2").style.display = "block";
            str += "<div style='22%;float:left;padding-right:0px;border:solid 0px red'><div align='left' style='width:110px;float:left;border:solid 0px red'><span class='headerText' width='22%'>Qty3: " + Qty3 + "</span></div></div>";
        }
        if ((Qty4 != '' && Qty4 != 0) && (QtyNo == 0 || QtyNo == 4)) {


            document.getElementById("WithActuals3").style.display = "block";
            document.getElementById("FormulaCost3").style.display = "block";
            document.getElementById("FormulaProfit3").style.display = "block";
            document.getElementById("FormulaSellingPrice3").style.display = "block";
            str += "<div style='25%;float:left;padding-right:0px;border:solid 0px red;padding-left: 4px;'><div align='left' style='width:110px;float:left;border:solid 0px red'><span class='headerText' width='22%'>Qty4: " + Qty4 + "</span></div></div>";
        }
        str += "</td></tr>";

        str += "<tr> <td align='center' width='100%'>";


        if ((QtyNo == 0 || QtyNo == 1)) {
            str += "<div style='22%;float:left;padding-right:10px;padding-top: 5px;'><div style='width:110px'> <input type='text' id='txt_qty_1" + index + "' class='textboxnew' style='width:98px;text-align:right'onblur='qtyValues();'> </div></div>";
        }
        else {
            str += "<div style='22%;float:left;padding-right:10px;display:none;padding-top: 5px;'><div style='width:110px'> <input type='text' id='txt_qty_1" + index + "' value='0' class='textboxnew' style='width:98px;text-align:right'> </div></div>";

        }


        if (Qty2 != '' && Qty2 != 0 && (QtyNo == 0 || QtyNo == 2)) {
            str += "<div style='22%;float:left;padding-right:10px;padding-top: 5px;'><div style='width:110px'> <input type='text' id='txt_qty_2" + index + "' class='textboxnew' style='width:98px;text-align:right'></div> </div>";
        }
        else {
            str += "<div style='22%;float:left;padding-right:10px;display:none;padding-top: 5px;'><div style='width:110px'> <input type='text' id='txt_qty_2" + index + "'  value='0' class='textboxnew' style='width:98px;text-align:right'></div> </div>";

        }


        if (Qty3 != '' && Qty3 != 0 && (QtyNo == 0 || QtyNo == 3)) {
            str += "<div style='22%;float:left;padding-right:10px;padding-top: 5px;'><div style='width:110px'><input type='text' id='txt_qty_3" + index + "' class='textboxnew' style='width:98px;text-align:right'></div> </div>";
        }
        else {
            str += "<div style='22%;float:left;padding-right:10px;display:none;padding-top: 5px;'><div style='width:110px'><input type='text' id='txt_qty_3" + index + "'  value='0' class='textboxnew' style='width:98px;text-align:right'></div> </div>";
        }

        if (Qty4 != '' && Qty4 != 0 && (QtyNo == 0 || QtyNo == 4)) {
            str += "<div style='22%;float:left;padding-top: 5px;'><div style='float:left'> <input type='text' id='txt_qty_4" + index + "' class='textboxnew' style='width:98px;text-align:right'></div></div>";
        }
        else {
            str += "<div style='22%;float:left;display:none;padding-top: 5px;'><div style='float:left'> <input type='text' id='txt_qty_4" + index + "' value='0'  class='textboxnew' style='width:98px;text-align:right'></div></div>";
        }


        str += "</td > </tr>";

        str += "<tr> <td align='center' style='padding-left: 7px;padding-top:5px;'>";
        str += "<span id='spn_txt_qty_" + index + "' class='spanerrorMsg' style='display:none;width:200px;text-align: center;'>Text box cannot be empty</span>";
        str += "<span id='spn_txt_qty_numeric_" + index + "' class='spanerrorMsg' style='display:none;width:160px;text-align: center'>Please enter numeric value</span>";
        str += "</td> </tr>";
        str += "<tr> <td align='left' class='only10px'><div class='only5px'></div></td> </tr>";
        str += "<tr> <td width='100%' style='border:solid 0px red;padding-left: 7px;' align='left'> <input type='button' value='OK' class='button' style='width:60px;' onclick='NextQuestion(" + index + ",\"" + ques + "\",\"" + ActualData + "\");CalculateSellingPrice();return false;'> </td> </tr> ";
        str += "<tr> <td align='left' class='only10px'> </td> </tr>";
        str += "</table>";
        str += "</div>";
        str += "</div>";
        str += "<div class='only10px'></div>";

        str += "</td>";
        str += "<td style='width: 10px; background-color: #ffffff'>&nbsp;</td>";
        str += "<td align='right' class='popup-middle-rightcorner'&nbsp; </td>";
        str += "</tr>";
        str += "<tr>";
        str += "<td colspan='2' class='popup-bottom-leftcorner'>&nbsp;</td>";
        str += "<td class='popup-bottom-middlebg'> &nbsp;</td>";
        str += "<td colspan='2' class='popup-bottom-rightcorner'>&nbsp; </td>";
        str += "</tr>";
        str += "</table>";
        str += "</div>";
        return str;
    }
    function qtyValues() {

        var StrQuestionArray = hdn_QuestionValue.Value;
        var round = 0;
        var QtyValue = 0;
        var Qty2 = "<%=Qty2 %>";
        var Qty3 = "<%=Qty3 %>";
        var Qty4 = "<%=Qty4 %>";
        if (Qty2 != "") {
            QtyValue = "2";
        }
        if (Qty3 != "") {
            QtyValue = "3";
        }
        if (Qty4 != "") {
            QtyValue = "4";
        }

        if (StrQuestionArray.length > 1) {
            for (var i = 1; i < StrQuestionArray.length; i++) {
                if (StrQuestionArray.length - 1 != round) {
                    var txt_qty_10 = document.getElementById("txt_qty_1" + round + "");
                    var txt_qty_20 = document.getElementById("txt_qty_2" + round + "");
                    var txt_qty_30 = document.getElementById("txt_qty_3" + round + "");
                    var txt_qty_40 = document.getElementById("txt_qty_4" + round + "");
                    if (QtyValue.trim() == "2") {
                        if ((txt_qty_20.value == "") || (txt_qty_20.value == null) || (txt_qty_20.value == undefined)) {
                            txt_qty_20.value = txt_qty_10.value;
                        }
                    }
                    if (QtyValue.trim() == "3") {
                        if ((txt_qty_20.value == "" && txt_qty_30.value == "") || (txt_qty_20.value == null && txt_qty_30.value == null) || (txt_qty_20.value == undefined && txt_qty_30.value == undefined)) {
                            txt_qty_20.value = txt_qty_10.value;
                            txt_qty_30.value = txt_qty_10.value;
                        }
                    }
                    if (QtyValue.trim() == "4") {
                        if ((txt_qty_20.value == "" && txt_qty_30.value == "" && txt_qty_40.value == "") || (txt_qty_20.value == null && txt_qty_30.value == null && txt_qty_40.value == null) || (txt_qty_20.value == undefined && txt_qty_30.value == undefined && txt_qty_40.value == undefined)) {
                            txt_qty_20.value = txt_qty_10.value;
                            txt_qty_30.value = txt_qty_10.value;
                            txt_qty_40.value = txt_qty_10.value;
                        }
                    }
                    round++;
                }
            }
        }

    }
    function NextQuestion(OldIndex, strData, ActualData) {

        document.getElementById("div_Load").style.display = "block";
        var txtValue = 0;

        var txtValue1 = 0;
        var txtValue2 = 0;
        var txtValue3 = 0;
        var strActual = '';
        var strActual1 = '';
        var strActual2 = '';
        var strActual3 = '';
        try {
            txtValue = document.getElementById("txt_qty_1" + OldIndex + "").value;
            strActual = ActualArray[0];

        } catch (err) { }
        try {
            txtValue1 = document.getElementById("txt_qty_2" + OldIndex + "").value;
            strActual1 = ActualArray[1];
        } catch (err) { }
        try {
            txtValue2 = document.getElementById("txt_qty_3" + OldIndex + "").value;
            strActual2 = ActualArray[2];
        } catch (err) { }
        try {
            txtValue3 = document.getElementById("txt_qty_4" + OldIndex + "").value;
            strActual3 = ActualArray[3];
        } catch (err) { }
        var ActualTest = ''; //new

        if (!isNaN(txtValue) && txtValue != '') {
            strData = "Q::" + strData + "";
            strData = trim12(strData);


            //Actual = Actual.replace(strData, txtValue);
            ActualTest = strActual.replace(strData, txtValue) + "±" + strActual1.replace(strData, txtValue1) + "±" + strActual2.replace(strData, txtValue2) + "±" + strActual3.replace(strData, txtValue3) + "±";             //new

            try {
                pw.SaveQuestionInfo(strData + "»" + txtValue + "±");
            } catch (err) { }
        }
        else {
            if (txtValue == '') {
                document.getElementById("spn_txt_qty_" + OldIndex + "").style.display = "block";
                document.getElementById("spn_txt_qty_numeric_" + OldIndex + "").style.display = "none";
            }
            else {
                document.getElementById("spn_txt_qty_" + OldIndex + "").style.display = "none";
                document.getElementById("spn_txt_qty_numeric_" + OldIndex + "").style.display = "block";
            }
            return false;
        }
        if (isNaN(txtValue1) && txtValue1 != '') {

            try {
                document.getElementById("spn_txt_qty_" + OldIndex + "").style.display = "none";
                document.getElementById("spn_txt_qty_numeric_" + OldIndex + "").style.display = "block";
            } catch (err) { }
            return false;
        }
        if (isNaN(txtValue2) && txtValue2 != '') {

            try {
                document.getElementById("spn_txt_qty_" + OldIndex + "").style.display = "none";
                document.getElementById("spn_txt_qty_numeric_" + OldIndex + "").style.display = "block";
            } catch (err) { }
            return false;
        }
        if (isNaN(txtValue3) && txtValue3 != '') {

            try {
                document.getElementById("spn_txt_qty_" + OldIndex + "").style.display = "none";
                document.getElementById("spn_txt_qty_numeric_" + OldIndex + "").style.display = "block";
            } catch (err) { }
            return false;
        }
        var NewIndex = Number(OldIndex) + 1;
        if (document.getElementById("div_ques_" + NewIndex + "") != null) {
            document.getElementById("div_ques_" + OldIndex + "").style.display = "none";

            document.getElementById("div_ques_" + NewIndex + "").style.display = "block";

            document.getElementById("txt_qty_1" + NewIndex + "").focus();

            var qtynew = '<%= qty%>'.split(',');
            var Actualdata = ActualTest.split('±'); //new
            debugger;
            for (k = 0; k < qtynew.length; k++) {
                if (qtynew[k] != null) {
                    CalculateVariableQty(Actualdata[k], MatrixVal[k], qtynew[k], k, 'formulabasedquestion');
                    CalculateSellingPrice();
                }
            }
        }
        else {

            //            if (ItemType == "m") {
            //                Actual = MakeZeroForFormula(Actual);  
            //                txtWithActualsID.value = Actual;
            //            }
            //            else
            //             { Commented by gajendra and kumar omn 23-3-2011
            //new on 25th feb
            var qtynew = '<%= qty%>'.split(',');
            var Actualdata = ActualTest.split('±'); //new
            for (k = 0; k < qtynew.length; k++) {
                if (qtynew[k] != null) {
                    CalculateVariableQty(Actualdata[k], MatrixVal[k], qtynew[k], k, 'formulabasedquestion');
                }
            }
            CalculateSellingPrice();
            document.getElementById("div_ques_" + OldIndex + "").style.display = "none";
            document.getElementById("div_question").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        }
        document.getElementById("div_Load").style.display = "none";
    }

    function MakeZeroForFormula(FormulaWithValues) {
        var key = '<%=Key %>';
        var str = key.split('±');
        for (var i = 0; i < str.length - 1; i++) {
            var formula = str[i].toString();

            if (formula.toLowerCase() == "booklet quantity required(section 1)" || formula.toLowerCase() == "pages in this section only" ||
                formula.toLowerCase() == "number of sections" || formula.toLowerCase() == "total number of pages (all sections)" ||
                formula.toLowerCase() == "print sheet quantity this section (excluding spoilage)" ||
                formula.toLowerCase() == "print sheet quantity this section (including spoilage)" ||
                formula.toLowerCase() == "print sheet quantity all sections (excluding spoilage)" ||
                formula.toLowerCase() == "print sheet quantity all sections (including spoilage)" ||
                formula.toLowerCase() == "guillotine bundles" || formula.toLowerCase() == "guillotine cost per cut" ||
                formula.toLowerCase() == "number of cuts in first trim" || formula.toLowerCase() == "number of cuts in second trim" ||
                formula.toLowerCase() == "number of leaves per pad" || formula.toLowerCase() == "number of pads" ||
                formula.toLowerCase() == "press hourly charge" || formula.toLowerCase() == "total press cost price" ||
                formula.toLowerCase() == "total press selling price" || formula.toLowerCase() == "print sheet quantity (excluding spoilage)" ||
                formula.toLowerCase() == "print sheet quantity (including spoilage)" ||
                formula.toLowerCase() == "finished job quantity (excluding spoilage)" || formula.toLowerCase() == "finished job quantity (including spoilage)" ||
                formula.toLowerCase() == "paper basis weight (gsm)" || formula.toLowerCase() == "paper cost (excluding markup)" ||
                formula.toLowerCase() == "paper cost (including markup)" || formula.toLowerCase() == "spoilage percentage used" ||
                formula.toLowerCase() == "spoilage sheets used") {
                FormulaWithValues = FormulaWithValues.toString().replace(new RegExp(formula, 'g'), "0");
            }
        }
        return FormulaWithValues;
    }

    function replace_char(data) {
        data = data.replace('(', 'µ').replace(')', 'µ');
        data = data.replace('+', 'µ').replace('-', 'µ');
        data = data.replace('*', 'µ').replace('-', 'µ');
        data = data.replace('/', 'µ').replace('%', 'µ');
        data = data.replace('^', 'µ');

        var array_0 = data.split('µ');

        return array_0[0];
    }


    var CheckFinal = false;
    function CalFormulaCost() {
        debugger;
        qtyTable();
        if (pgtype == "estimate") {
            if (txtWithActualsID.value != "") {
                try {
                    var dd = eval(txtWithActualsID.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID.value, GetResult); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID.value, GetResult);
                        }
                    }
                    else {
                        txtWithActualsID.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
            }

            if (ActualQuantiry2 != null && ActualQuantiry2 != 0 && ActualQuantiry2 != '') {

                //if (txtWithActualsID1.value != "") {
                document.getElementById("WithActuals1").style.display = "block";
                document.getElementById("FormulaCost1").style.display = "block";
                document.getElementById("FormulaProfit1").style.display = "block";
                document.getElementById("FormulaSellingPrice1").style.display = "block";

                try {
                    var dd = eval(txtWithActualsID1.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID1.value, GetResult1); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID1.value, GetResult1);
                        }
                    }
                    else {
                        txtWithActualsID1.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
                // }
            }
            if (ActualQuantiry3 != null && ActualQuantiry3 != 0 && ActualQuantiry3 != '') {
                // if (txtWithActualsID2.value != "") {
                document.getElementById("WithActuals2").style.display = "block";
                document.getElementById("FormulaCost2").style.display = "block";
                document.getElementById("FormulaProfit2").style.display = "block";
                document.getElementById("FormulaSellingPrice2").style.display = "block";
                try {
                    var dd = eval(txtWithActualsID2.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID2.value, GetResult2); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID2.value, GetResult2);
                        }
                    }
                    else {
                        txtWithActualsID2.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
                // }
            }
            if (ActualQuantiry4 != null && ActualQuantiry4 != 0 && ActualQuantiry4 != '') {
                // if (txtWithActualsID3.value != "") {
                document.getElementById("WithActuals3").style.display = "block";
                document.getElementById("FormulaCost3").style.display = "block";
                document.getElementById("FormulaProfit3").style.display = "block";
                document.getElementById("FormulaSellingPrice3").style.display = "block";
                try {
                    var dd = eval(txtWithActualsID3.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID3.value, GetResult3); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID3.value, GetResult3);
                        }
                    }
                    else {
                        txtWithActualsID3.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
        }
        else {
            if (txtWithActualsID.value != "") {
                try {
                    var dd = eval(txtWithActualsID.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID.value.trim(), GetResult); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID.value, GetResult);
                        }
                    }
                    else {
                        txtWithActualsID.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
            if (QtyNo == 2) {
                document.getElementById("WithActuals1").style.display = "block";
                document.getElementById("FormulaCost1").style.display = "block";
                document.getElementById("FormulaProfit1").style.display = "block";
                document.getElementById("FormulaSellingPrice1").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID1.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID1.value, GetResult1); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID1.value, GetResult1);
                        }
                    }
                    else {
                        txtWithActualsID1.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }

            }
            else if (QtyNo == 3) {
                document.getElementById("WithActuals2").style.display = "block";
                document.getElementById("FormulaCost2").style.display = "block";
                document.getElementById("FormulaProfit2").style.display = "block";
                document.getElementById("FormulaSellingPrice2").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID2.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID2.value, GetResult2); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID2.value, GetResult2);
                        }
                    }
                    else {
                        txtWithActualsID2.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }

            }
            else if (QtyNo == 4) {

                document.getElementById("WithActuals3").style.display = "block";
                document.getElementById("FormulaCost3").style.display = "block";
                document.getElementById("FormulaProfit3").style.display = "block";
                document.getElementById("FormulaSellingPrice3").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals2").style.display = "none";
                document.getElementById("FormulaCost2").style.display = "none";
                document.getElementById("FormulaProfit2").style.display = "none";
                document.getElementById("FormulaSellingPrice2").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID3.value);
                    if (!isNaN(dd)) {
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID3.value, GetResult3); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID3.value, GetResult3);
                        }
                    }
                    else {
                        txtWithActualsID3.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
        }
    }

    function CalFormulaCost_ForSave() {
        if (pgtype == "estimate") {
            if (txtWithActualsID.value != "") {
                try {
                    var dd = eval(txtWithActualsID.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID.value, GetResult); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID.value, GetResult);
                        }
                    }
                    else {
                        txtWithActualsID.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
            }

            if (ActualQuantiry2 != null && ActualQuantiry2 != 0 && ActualQuantiry2 != '') {

                //if (txtWithActualsID1.value != "") {
                document.getElementById("WithActuals1").style.display = "block";
                document.getElementById("FormulaCost1").style.display = "block";
                document.getElementById("FormulaProfit1").style.display = "block";
                document.getElementById("FormulaSellingPrice1").style.display = "block";

                try {
                    var dd = eval(txtWithActualsID1.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID1.value, GetResult1); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID1.value, GetResult1);
                        }
                    }
                    else {
                        txtWithActualsID1.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
                // }
            }
            if (ActualQuantiry3 != null && ActualQuantiry3 != 0 && ActualQuantiry3 != '') {
                // if (txtWithActualsID2.value != "") {
                document.getElementById("WithActuals2").style.display = "block";
                document.getElementById("FormulaCost2").style.display = "block";
                document.getElementById("FormulaProfit2").style.display = "block";
                document.getElementById("FormulaSellingPrice2").style.display = "block";
                try {
                    var dd = eval(txtWithActualsID2.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID2.value, GetResult2); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID2.value, GetResult2);
                        }
                    }
                    else {
                        txtWithActualsID2.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }
                // }
            }
            if (ActualQuantiry4 != null && ActualQuantiry4 != 0 && ActualQuantiry4 != '') {
                // if (txtWithActualsID3.value != "") {
                document.getElementById("WithActuals3").style.display = "block";
                document.getElementById("FormulaCost3").style.display = "block";
                document.getElementById("FormulaProfit3").style.display = "block";
                document.getElementById("FormulaSellingPrice3").style.display = "block";
                try {
                    var dd = eval(txtWithActualsID3.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID3.value, GetResult3); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID3.value, GetResult3);
                        }
                    }
                    else {
                        txtWithActualsID3.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
        }
        else {
            if (txtWithActualsID.value != "") {
                try {
                    var dd = eval(txtWithActualsID.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID.value, GetResult); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID.value, GetResult);
                        }
                    }
                    else {
                        txtWithActualsID.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
            if (QtyNo == 2) {
                document.getElementById("WithActuals1").style.display = "block";
                document.getElementById("FormulaCost1").style.display = "block";
                document.getElementById("FormulaProfit1").style.display = "block";
                document.getElementById("FormulaSellingPrice1").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID1.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID1.value, GetResult1); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID1.value, GetResult1);
                        }
                    }
                    else {
                        txtWithActualsID1.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }

            }
            else if (QtyNo == 3) {
                document.getElementById("WithActuals2").style.display = "block";
                document.getElementById("FormulaCost2").style.display = "block";
                document.getElementById("FormulaProfit2").style.display = "block";
                document.getElementById("FormulaSellingPrice2").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID2.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID2.value, GetResult2); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID2.value, GetResult2);
                        }
                    }
                    else {
                        txtWithActualsID2.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    //alert("Please enter valid value");
                    CheckFinal = true;
                }

            }
            else if (QtyNo == 4) {

                document.getElementById("WithActuals3").style.display = "block";
                document.getElementById("FormulaCost3").style.display = "block";
                document.getElementById("FormulaProfit3").style.display = "block";
                document.getElementById("FormulaSellingPrice3").style.display = "block";

                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                try {
                    var dd = eval(txtWithActualsID3.value);
                    if (!isNaN(dd)) {
                        asyncState = false;
                        if (ForOtherCostFormula == 'true') {
                            PageMethods.CalculateFormulaCost_ForOtherCost(txtWithActualsID3.value, GetResult3); //For OtherCost Calculation allowing Negative value
                        } else {
                            PageMethods.CalculateFormulaCost(txtWithActualsID3.value, GetResult3);
                        }
                    }
                    else {
                        txtWithActualsID3.value = "0.00";
                    }
                    CheckFinal = false;
                }
                catch (e) {
                    CheckFinal = true;
                }
            }
        }
    }

    function GetResult(result) {
        if (!isNaN(result)) {
            txtFormulaCost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, result, 0, '', false, false, false);

            var cost = Number(txtFormulaCost.value);

            var profitpercent = Number(txtFormulaProfit.value);
            profitpercent = roundNumber(Number(profitpercent), 2);

            var profitval = Number(cost * profitpercent) / 100;
            profitval = roundNumber(Number(profitval), 2);

            txtFormulaSellingPrice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Number(cost) + Number(profitval)), 0, '', false, false, false);
        }
    }

    function GetResult1(result) {

        if (!isNaN(result)) {

            txtFormulaCost1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, result, 0, '', false, false, false);

            var cost = Number(txtFormulaCost1.value);

            var profitpercent = Number(txtFormulaProfit1.value);
            profitpercent = roundNumber(Number(profitpercent), 2);

            var profitval = Number(cost * profitpercent) / 100;
            profitval = roundNumber(Number(profitval), 2);

            txtFormulaSellingPrice1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Number(cost) + Number(profitval)), 0, '', false, false, false);
        }
    }

    function GetResult2(result) {

        if (!isNaN(result)) {

            txtFormulaCost2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, result, 0, '', false, false, false);

            var cost = Number(txtFormulaCost2.value);

            var profitpercent = Number(txtFormulaProfit2.value);
            profitpercent = roundNumber(Number(profitpercent), 2);

            var profitval = Number(cost * profitpercent) / 100;
            profitval = roundNumber(Number(profitval), 2);

            txtFormulaSellingPrice2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Number(cost) + Number(profitval)), 0, '', false, false, false);
        }
    }

    function GetResult3(result) {

        if (!isNaN(result)) {

            txtFormulaCost3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, result, 0, '', false, false, false);

            var cost = Number(txtFormulaCost3.value);

            var profitpercent = Number(txtFormulaProfit3.value);
            profitpercent = roundNumber(Number(profitpercent), 2);

            var profitval = Number(cost * profitpercent) / 100;
            profitval = roundNumber(Number(profitval), 2);

            txtFormulaSellingPrice3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(Number(cost) + Number(profitval)), 0, '', false, false, false);
        }
    }

    function PressCostPerClick(TotalSheets, ChargeableRate, NoOfChargeableSheets) {
        var CostPerClick = 0;
        CostPerClick = Number(ChargeableRate) / Number(NoOfChargeableSheets);
        CostPerClick = Number(CostPerClick) * Number(TotalSheets);
        return CostPerClick;
    }

    function BindCostValuesOnEdit() {
        if (otherinx != '') {
            hdnEditOtherValues.value = '';
            try {
                hdnEditOtherValues.value = pw.EditOtherPopupValues; //In usercoscenters
            } catch (err) { }

            var OtherCostTypeVal = hdnEditOtherValues.value;
            if (caltype == 't') {
                var timeval = OtherCostTypeVal.split('±');
                var timeval2 = '';
                var proptime = '';
                var valuetime = '';
                for (var x = 0; x < timeval.length; x++) {
                    timeval2 = timeval[x].split('»');
                    proptime = timeval2[0];
                    valuetime = timeval2[1];
                    //alert(trim12(proptime)+" = "+valuetime);
                    if (trim12(proptime) == "HourlyRate") {
                        txtHourlyRateID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);
                    }
                    if (trim12(proptime) == "SetUpTime") {
                        txtSetUpTimeID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);
                    }
                    if (trim12(proptime) == "Hours") {
                        txtHoursID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);
                    }
                    if (trim12(proptime) == "Passes") {
                        txtPassesID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);
                    }
                    if (trim12(proptime) == "Markup") {
                        txtProfitID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);;
                    }
                    if (trim12(proptime) == "Cost") {
                        lblCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valuetime, 0, '', false, false, false);;
                    }
                    if (trim12(proptime) == "HourlyRunSpeed") {
                        hid_HourlySpeedID.value = valuetime;
                    }
                }
            }
            else if (caltype == 'q') {
                var qtyval = OtherCostTypeVal.split('±');
                var qtyval2 = '';
                var propqty = '';
                var valueqty = '';
                for (var y = 0; y < qtyval.length; y++) {
                    qtyval2 = qtyval[y].split('»');
                    propqty = qtyval2[0];
                    valueqty = qtyval2[1];
                    valueqty = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', false, false, false);
                    if (trim12(propqty) == "UnitRate") {
                        txtQtyUnitRateID.value = valueqty;
                    }
                    if (trim12(propqty) == "UnitRate1") {
                        if (ActualQuantiry2 != null && ActualQuantiry2 != '') {
                            txtQtyUnitRateID1.value = valueqty;
                            div_unitrate1.style.display = "block";
                            div_qtytext1.style.display = "block";
                            div_qtymarkup1.style.display = "block";
                            div_qtysellingprice1.style.display = "block";
                        }
                    }
                    if (trim12(propqty) == "UnitRate2") {
                        if (ActualQuantiry3 != null && ActualQuantiry3 != '') {
                            txtQtyUnitRateID2.value = valueqty;
                            div_unitrate2.style.display = "block";
                            div_qtytext2.style.display = "block";
                            div_qtymarkup2.style.display = "block";
                            div_qtysellingprice2.style.display = "block";
                        }
                    }
                    if (trim12(propqty) == "UnitRate3") {
                        if (ActualQuantiry4 != null && ActualQuantiry4 != '') {
                            txtQtyUnitRateID3.value = valueqty;
                            div_unitrate3.style.display = "block";
                            div_qtytext3.style.display = "block";
                            div_qtymarkup3.style.display = "block";
                            div_qtysellingprice3.style.display = "block";
                        }
                    }

                    if (trim12(propqty) == "Quantity") {
                        txtQtyQuantityID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }
                    if (trim12(propqty) == "Quantity1") {
                        txtQtyQuantityID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }
                    if (trim12(propqty) == "Quantity2") {
                        txtQtyQuantityID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }
                    if (trim12(propqty) == "Quantity3") {
                        txtQtyQuantityID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }


                    if (trim12(propqty) == "Markup") {
                        txtQtyProfitID.value = valueqty;
                    }
                    if (trim12(propqty) == "Markup1") {
                        txtQtyProfitID1.value = valueqty;
                    }
                    if (trim12(propqty) == "Markup2") {
                        txtQtyProfitID2.value = valueqty;
                    }
                    if (trim12(propqty) == "Markup3") {
                        txtQtyProfitID3.value = valueqty;
                    }


                    if (trim12(propqty) == "SetUpTime") {
                        txtQtySetUpTimeID.value = valueqty;
                    }
                    if (trim12(propqty) == "HourlyRate") {
                        txtQtyHourlyRateID.value = valueqty;
                    }
                }
            }
        }
    }

    function ShowHideAdvanceDiv() {
        var Advanced = '<%=objLanguage.GetLanguageConversion("Advanced") %>';
        if (caltype == 't') {
            if (div_Advance_TimeBased.style.display == "block") {
                //btnAdvancedID.value = "Advanced «";
                btnAdvancedID.value = Advanced + " «";
                div_Advance_TimeBased.style.display = "none";
            }
            else if (div_Advance_TimeBased.style.display == "none") {
                //btnAdvancedID.value = "Advanced »";
                btnAdvancedID.value = Advanced + " »";
                div_Advance_TimeBased.style.display = "block";
            }
        }
        else if (caltype == 'q') {
            if (div_Advance_QuantityBased.style.display == "block") {
                //btnAdvancedID.value = "Advanced «";
                btnAdvancedID.value = Advanced + " «";
                div_Advance_QuantityBased.style.display = "none";
            }
            else if (div_Advance_QuantityBased.style.display == "none") {
                //btnAdvancedID.value = "Advanced »";
                btnAdvancedID.value = Advanced + " »";
                div_Advance_QuantityBased.style.display = "block";
            }
        }
    }

    function CalSetUpCost() {
        var hours = 0;
        if (hid_HourlySpeedID.value > 0) {
            hours = Number(txtRunsRequiredID.value / hid_HourlySpeedID.value);
        }
        txtHoursID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hours, 0, '', false, false, false);

        lblSpeedID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtRunsRequiredID.value, 0, '', false, false, false);

        CalculateSellingPrice();
    }
    try {
        var PreArry = window.parent.ArrayOtherCost;

        var ItemType = '<%=ItemType %>';
        var Mode = '<%=Mode %>';
        var ModeinOrgionalCase = '<%=ModeinOrgionalCase %>';
        var estothercostid = pw.EstOtherCostID;
    } catch (err) { }


    function BindMainItemOnEdit() {
        hdnEditOtherValues.value = '';
        try {
            hdnEditOtherValues.value = pw.EditOtherPopupValues;
        } catch (err) { }
        var OtherCostTypeVal = hdnEditOtherValues.value.split('µ');
        var str2 = '';
        for (var i = 0; i < OtherCostTypeVal.length - 1; i++) {
            var str = OtherCostTypeVal[i].split('¶');
            if (pw.EstOtherCostID == str[0]) {
                str2 = str[1];
            }
        }
        var str3 = str2.split('±');
        for (var k = 0; k < str3.length; k++) {
            var str4 = str3[k].split('»');
            propcost = str4[0];
            valuecost = str4[1];

            if (caltype == 't') {
                //alert(trim12(proptime)+" = "+valuetime);
                if (trim12(propcost) == "HourlyRate") {
                    txtHourlyRateID.value = valuecost;
                }
                if (trim12(propcost) == "SetUpTime") {
                    txtSetUpTimeID.value = valuecost;
                }
                if (trim12(propcost) == "Hours") {
                    txtHoursID.value = valuecost;
                }
                if (trim12(propcost) == "Passes") {
                    txtPassesID.value = valuecost;
                }
                if (trim12(propcost) == "Markup") {
                    txtProfitID.value = valuecost;
                }
                if (trim12(propcost) == "Cost") {
                    lblCostID.innerHTML = valuecost;
                }
                if (trim12(propcost) == "HourlyRunSpeed") {
                    hid_HourlySpeedID.value = valuecost;
                }
            }
            else if (caltype == 'q') {
                if (trim12(propcost) == "UnitRate") {
                    txtQtyUnitRateID.value = valuecost;
                }
                if (trim12(propcost) == "Quantity") {
                    txtQtyQuantityID.value = valuecost;
                }
                if (trim12(propcost) == "Markup") {
                    txtQtyProfitID.value = valuecost;
                }
                if (trim12(propcost) == "SetUpTime") {
                    txtQtySetUpTimeID.value = valuecost;
                }
                if (trim12(propcost) == "HourlyRate") {
                    txtQtyHourlyRateID.value = valuecost;
                }
            }
        }
    }


    function CallSaveCost() {
        debugger;
        if (ItemType == 'u') {
            var OtherCostVal = "EstOtherCostID" + '»' + pw.EstOtherCostID + '±' + "OtherCostID" + '»' + othercostid + '±' + "OtherCostName" + '»' + lblCostNameID.innerHTML + '±' +
                "CalculationType" + '»' + caltype + '±' + "CostTimeBasedID" + '»' + costtimebasedid + '±' +
                "Minimum" + '»' + hdn_MinimumChargID.value + '±' + "Description" + '»' + txtDescription.value;
            var OtherCostTime = "HourlyRate" + '»' + txtHourlyRateID.value + '±' + "SetUpTime" + '»' + txtSetUpTimeID.value + '±' +
                "SetUpCost" + '»' + lblSetUpCostID.innerHTML + '±' + "Hours" + '»' + txtHoursID.value + '±' +
                "Passes" + '»' + txtPassesID.value + '±' + "Markup" + '»' + txtProfitID.value + '±' +
                "SellingPrice" + '»' + txtSellingPriceID.value + '±' + "RunsRequired" + '»' + txtRunsRequiredID.value + '±' +
                "Speed" + '»' + lblSpeedID.innerHTML + '±' + "TotalTime" + '»' + lblTotalTimeID.innerHTML + '±' +
                "Cost" + '»' + lblCostID.innerHTML + '±' + "HourlyRunSpeed" + '»' + hid_HourlySpeedID.value + '±' + "SectionNo»0";

            var OtherCostQuantity = "UnitRate" + '»' + txtQtyUnitRateID.value + '±' + "Quantity" + '»' + txtQtyQuantityID.value + '±' +
                "Markup" + '»' + txtQtyProfitID.value + '±' + "SellingPrice" + '»' + txtQtySellingPriceID.value + '±' +
                "SetUpTime" + '»' + txtQtySetUpTimeID.value + '±' + "SetUpCost" + '»' + lblQtySetUpCostID.innerHTML + '±' +
                "HourlyRate" + '»' + txtQtyHourlyRateID.value + '±' + "TotalTime" + '»' + lblQtyTotalTimeID.innerHTML + '±' +
                "Cost" + '»' + hid_QtyCost.value + '±' + "Cost1" + '»' + hid_QtyCost1.value + '±' + "Cost2" + '»' + hid_QtyCost2.value + '±' +
                "Cost3" + '»' + hid_QtyCost3.value + '±' + "UnitRate1" + '»' + txtQtyUnitRateID1.value + '±' + "UnitRate2" + '»' + txtQtyUnitRateID2.value + '±' +
                "UnitRate3" + '»' + txtQtyUnitRateID3.value + '±' + "Quantity1" + '»' + txtQtyQuantityID1.value + '±' + "Quantity2" + '»' + txtQtyQuantityID2.value + '±' +
                "Quantity3" + '»' + txtQtyQuantityID3.value + '±' + "Markup1" + '»' + txtQtyProfitID1.value + '±' + "Markup2" + '»' + txtQtyProfitID2.value + '±' +
                "Markup3" + '»' + txtQtyProfitID3.value + '±' + "SellingPrice1" + '»' + txtQtySellingPriceID1.value + '±' + "SellingPrice2" + '»' + txtQtySellingPriceID2.value + '±' +
                "SellingPrice3" + '»' + txtQtySellingPriceID3.value + '±' + "SectionNo»0";


            var OtherCostFormula = "Formula" + '»' + txtFormulaID.value + '±' + "FormulaTag" + '»' + txtWithActualsID.value + '¶' + '<%=FormulaTag %>' + '±' +
                "FormulaTag1" + '»' + txtWithActualsID1.value + '¶' + '<%=FormulaTag %>' + '±' + "FormulaTag2" + '»' + txtWithActualsID2.value + '¶' + '<%=FormulaTag %>' + '±' +
                "FormulaTag3" + '»' + txtWithActualsID3.value + '¶' + '<%=FormulaTag %>' + '±' + "Cost" + '»' + txtFormulaCost.value + '±' +
                "Cost1" + '»' + txtFormulaCost1.value + '±' + "Cost2" + '»' + txtFormulaCost2.value + '±' + "Cost3" + '»' + txtFormulaCost3.value + '±' +
                "Markup" + '»' + txtFormulaProfit.value + '±' + "Markup1" + '»' + txtFormulaProfit1.value + '±' + "Markup2" + '»' + txtFormulaProfit2.value + '±' +
                "Markup3" + '»' + txtFormulaProfit3.value + '±' + "SellingPrice" + '»' + txtFormulaSellingPrice.value + '±' + "SellingPrice1" + '»' + txtFormulaSellingPrice1.value + '±' +
                "SellingPrice2" + '»' + txtFormulaSellingPrice2.value + '±' + "SellingPrice3" + '»' + txtFormulaSellingPrice3.value + '±' + "SectionNo»0";


            var OtherCostTypeVal = '';
            if (caltype == 't') {
                OtherCostTypeVal = OtherCostTime;
            }
            else if (caltype == 'q') {
                OtherCostTypeVal = OtherCostQuantity;
            }
            else if (caltype == 'f' || caltype == 'm') {
                OtherCostTypeVal = OtherCostFormula;
            }




            window.close();
            //funcn is in summary page//
            if (pw.hdn_EditOtherCostSelected != null && pw.hdn_EditOtherCostSelected != undefined) {
                pw.hdn_EditOtherCostSelected.value = 'true';
            }
            if ('<%=Mode %>' == 'editonload') {
                if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                    pw.hdn_EditOtherCostNewItemSelected.value = 'false';
                }
            } else if ('<%=Mode %>' == 'add') {
                if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                    pw.hdn_EditOtherCostNewItemSelected.value = 'true';
                }
            }
            pw.SaveMainCostItem(OtherCostVal, caltype, OtherCostTypeVal, ItemType, Mode); //to add main cost item from est summary screen
        }
        else {
            if (caltype == 'f' || caltype == 'm') {
                if (CheckFinal == false) {
                    if (pw.hdn_EditOtherCostSelected != null && pw.hdn_EditOtherCostSelected != undefined) {
                        pw.hdn_EditOtherCostSelected.value = 'true';
                    }
                    if ('<%=Mode %>' == 'editonload') {
                        if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                            pw.hdn_EditOtherCostNewItemSelected.value = 'false';
                        }
                    } else if ('<%=Mode %>' == 'add') {
                        if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                            pw.hdn_EditOtherCostNewItemSelected.value = 'true';
                        }
                    }
                    SaveOtherCost(); //to add formula based othercost item as main and sub item from estimate add page
                }
                else {
                    alert("Please enter valid actual value");
                    document.getElementById("div_question").style.display = "none";
                    document.getElementById("divBackGroundNew").style.display = "none";
                    document.getElementById("ds00").style.display = "none";
                    document.getElementById("div_Load").style.display = "none";
                    asyncState = true;
                }
            }
            else {
                if (pw.hdn_EditOtherCostSelected != null && pw.hdn_EditOtherCostSelected != undefined) {
                    pw.hdn_EditOtherCostSelected.value = 'true';
                }
                if ('<%=Mode %>' == 'editonload') {
                    if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                        pw.hdn_EditOtherCostNewItemSelected.value = 'false';
                    }
                } else if ('<%=Mode %>' == 'add') {
                    if (pw.hdn_EditOtherCostNewItemSelected != null && pw.hdn_EditOtherCostNewItemSelected != undefined) {
                        pw.hdn_EditOtherCostNewItemSelected.value = 'true';
                    }
                }
                SaveOtherCost(); //to add qty and time based othercost item as main and sub item from estimate add page
            }
        }
    }

    function CalculateSellingPrice() {
        debugger
        if (caltype == 'q') {
            lblQtyTotalTimeID.innerHTML = txtQtySetUpTimeID.value;

            var setupcost = (txtQtyHourlyRateID.value * txtQtySetUpTimeID.value) / 60;
            lblQtySetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, setupcost, 0, '', false, false, false);

            var sellingprice = (txtQtyUnitRateID.value * txtQtyQuantityID.value);
            var profit = Number((sellingprice * txtQtyProfitID.value) / 100);

            hid_QtyCost.value = sellingprice + setupcost; //Cost excl Markup//

            txtQtySellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice + profit + setupcost), 0, '', false, false, false);

            var sellingprice1 = (txtQtyUnitRateID1.value * txtQtyQuantityID1.value);
            hid_QtyCost1.value = sellingprice1 + setupcost;
            var profit1 = Number((sellingprice1 * txtQtyProfitID1.value) / 100);
            txtQtySellingPriceID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice1 + profit1 + setupcost), 0, '', false, false, false);

            var sellingprice2 = (txtQtyUnitRateID2.value * txtQtyQuantityID2.value);
            hid_QtyCost2.value = sellingprice2 + setupcost;
            var profit2 = Number((sellingprice2 * txtQtyProfitID2.value) / 100);
            txtQtySellingPriceID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice2 + profit2 + setupcost), 0, '', false, false, false);

            var sellingprice3 = (txtQtyUnitRateID3.value * txtQtyQuantityID3.value);
            hid_QtyCost3.value = sellingprice3 + setupcost;
            var profit3 = Number((sellingprice3 * txtQtyProfitID3.value) / 100);
            txtQtySellingPriceID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice3 + profit3 + setupcost), 0, '', false, false, false);

            gettextboxdisplayedinqtybased();
        }
        else if (caltype == 't') {
            if (hid_HourlySpeedID.value == "0" || hid_HourlySpeedID.value == "0.0000000000") {
                document.getElementById("div_Passes").style.display = "none";
                btnAdvancedID.style.display = "none";
                var setupcost = (txtHourlyRateID.value * txtSetUpTimeID.value) / 60;
                lblSetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(setupcost), "", 0, false, false, true);

                var sellingprice = (txtHourlyRateID.value * txtHoursID.value);
                lblCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice + setupcost), "", 0, false, false, true);

                var profit = Number((sellingprice * txtProfitID.value) / 100);
                var finalsellingprice = Number(sellingprice + profit + setupcost);

                txtSellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(finalsellingprice), 0, '', false, false, false);
            }
            else {
                document.getElementById("div_Passes").style.display = "block";
                btnAdvancedID.style.display = "block";

                var runsrequired = txtHoursID.value * hid_HourlySpeedID.value;
                txtRunsRequiredID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(runsrequired), 0, '', false, false, false);
                lblSpeedID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(runsrequired), 0, '', false, false, false);

                var totaltime = (txtHoursID.value * 60) + Number(txtSetUpTimeID.value);
                lblTotalTimeID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totaltime, "", 0, false, false, true);

                var setupcost = (txtHourlyRateID.value * txtSetUpTimeID.value) / 60;
                lblSetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, setupcost, "", 0, false, false, true);

                var sellingprice = (txtHourlyRateID.value * txtHoursID.value);
                //lblCostID.innerHTML =  Number(sellingprice * txtPassesID.value);
                lblCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number((sellingprice * txtPassesID.value) + setupcost), "", 0, false, false, false);

                var profit = Number(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number((sellingprice * txtProfitID.value) / 100)), "", 0, false, false, false);
                var finalsellingprice = Number((sellingprice + profit + setupcost) * txtPassesID.value);

                txtSellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(finalsellingprice), 0, '', false, false, false);
            }
        }
        else if (caltype == 'f' || caltype == 'm') {
            div_Matrixbtn.style.display = "none";
            div_Matrixbtn1.style.display = "none";
            div_Matrixbtn2.style.display = "none";
            div_Matrixbtn3.style.display = "none";
            div_Matrixbtn4.style.display = "none";
            btnAdvancedID.style.display = "none";

            if (caltype == 'm') {
                //div_Matrixbtn.style.display = "block";

                // By gaj on 17-7-2012
                div_Matrixbtn.style.display = "none";

                div_Matrixbtn1.style.display = "block";
                div_Matrixbtn2.style.display = "block";
                div_Matrixbtn3.style.display = "block";
                div_Matrixbtn4.style.display = "block";
            }

            CalFormulaCost();
        }

        if (pgtype != "estimate") {
            CallWhenJObOrInvoice();
        }
    }

    function CalculateSellingPrice_ForSave() {
        debugger;
        if (caltype == 'q') {
            lblQtyTotalTimeID.innerHTML = txtQtySetUpTimeID.value;

            var setupcost = (txtQtyHourlyRateID.value * txtQtySetUpTimeID.value) / 60;
            lblQtySetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, setupcost, 0, '', false, false, false);

            var sellingprice = (txtQtyUnitRateID.value * txtQtyQuantityID.value);
            var profit = Number((sellingprice * txtQtyProfitID.value) / 100);

            hid_QtyCost.value = sellingprice + setupcost; //Cost excl Markup//

            txtQtySellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice + profit + setupcost), 0, '', false, false, false);

            var sellingprice1 = (txtQtyUnitRateID1.value * txtQtyQuantityID1.value);
            hid_QtyCost1.value = sellingprice1 + setupcost;
            var profit1 = Number((sellingprice1 * txtQtyProfitID1.value) / 100);
            txtQtySellingPriceID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice1 + profit1 + setupcost), 0, '', false, false, false);

            var sellingprice2 = (txtQtyUnitRateID2.value * txtQtyQuantityID2.value);
            hid_QtyCost2.value = sellingprice2 + setupcost;
            var profit2 = Number((sellingprice2 * txtQtyProfitID2.value) / 100);
            txtQtySellingPriceID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice2 + profit2 + setupcost), 0, '', false, false, false);

            var sellingprice3 = (txtQtyUnitRateID3.value * txtQtyQuantityID3.value);
            hid_QtyCost3.value = sellingprice3 + setupcost;
            var profit3 = Number((sellingprice3 * txtQtyProfitID3.value) / 100);
            txtQtySellingPriceID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice3 + profit3 + setupcost), 0, '', false, false, false);

            gettextboxdisplayedinqtybased();
        }
        else if (caltype == 't') {
            if (hid_HourlySpeedID.value == "0" || hid_HourlySpeedID.value == "0.0000000000") {
                document.getElementById("div_Passes").style.display = "none";
                btnAdvancedID.style.display = "none";
                var setupcost = (txtHourlyRateID.value * txtSetUpTimeID.value) / 60;
                lblSetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(setupcost), "", 0, false, false, true);

                var sellingprice = (txtHourlyRateID.value * txtHoursID.value);
                lblCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice + setupcost), "", 0, false, false, true);

                var profit = Number((sellingprice * txtProfitID.value) / 100);
                var finalsellingprice = Number(sellingprice + profit + setupcost);

                txtSellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(finalsellingprice), 0, '', false, false, false);
            }
            else {
                document.getElementById("div_Passes").style.display = "block";
                btnAdvancedID.style.display = "block";

                var runsrequired = txtHoursID.value * hid_HourlySpeedID.value;
                txtRunsRequiredID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(runsrequired), 0, '', false, false, false);
                lblSpeedID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(runsrequired), 0, '', false, false, false);

                var totaltime = (txtHoursID.value * 60) + Number(txtSetUpTimeID.value);
                lblTotalTimeID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, totaltime, "", 0, false, false, true);

                var setupcost = (txtHourlyRateID.value * txtSetUpTimeID.value) / 60;
                lblSetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, setupcost, "", 0, false, false, true);

                var sellingprice = (txtHourlyRateID.value * txtHoursID.value);
                //lblCostID.innerHTML =  Number(sellingprice * txtPassesID.value);
                lblCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number((sellingprice * txtPassesID.value) + setupcost), "", 0, false, false, false);

                var profit = Number(Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number((sellingprice * txtProfitID.value) / 100)), "", 0, false, false, false);
                var finalsellingprice = Number((sellingprice + profit + setupcost) * txtPassesID.value);

                txtSellingPriceID.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(finalsellingprice), 0, '', false, false, false);
            }
        }
        else if (caltype == 'f' || caltype == 'm') {
            div_Matrixbtn.style.display = "none";
            div_Matrixbtn1.style.display = "none";
            div_Matrixbtn2.style.display = "none";
            div_Matrixbtn3.style.display = "none";
            div_Matrixbtn4.style.display = "none";
            btnAdvancedID.style.display = "none";

            if (caltype == 'm') {
                //div_Matrixbtn.style.display = "block";

                // By gaj on 17-7-2012
                div_Matrixbtn.style.display = "none";

                div_Matrixbtn1.style.display = "block";
                div_Matrixbtn2.style.display = "block";
                div_Matrixbtn3.style.display = "block";
                div_Matrixbtn4.style.display = "block";
            }

            CalFormulaCost_ForSave();
        }

        if (pgtype != "estimate") {
            CallWhenJObOrInvoice();
        }
    }

    document.getElementById("ds01").style.display = "block";
    document.getElementById("div_Load").style.display = "block";
    CalculateSellingPrice();
    GetSelPrice_OnLoad();
    document.getElementById("ds01").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    function GetSelPrice_OnLoad() {
        if (caltype == 'q') {
            hdn_compare_sellingprice.value = txtQtySellingPriceID.value + "µ" + txtQtySellingPriceID1.value + "µ" + txtQtySellingPriceID2.value + "µ" + txtQtySellingPriceID3.value;
        }
        else if (caltype == 't') {
            hdn_compare_sellingprice.value = txtSellingPriceID.value + "µ" + 0 + "µ" + 0 + "µ" + 0; //pls donot alter -- by swetha
        }
        else {
            hdn_compare_sellingprice.value = txtFormulaSellingPrice.value + "µ" + txtFormulaSellingPrice1.value + "µ" + txtFormulaSellingPrice2.value + "µ" + txtFormulaSellingPrice3.value;
        }
    }

    function SaveOtherCost() {
        debugger
        var item = window.parent.OtherCost;


        var OtherCostVal = "OtherCostID" + '»' + othercostid + '±' + "OtherCostName" + '»' + lblCostNameID.innerHTML + '±' +
            "CalculationType" + '»' + caltype + '±' + "CostTimeBasedID" + '»' + costtimebasedid + '±' +
            "Minimum" + '»' + hdn_MinimumChargID.value + '±' + "Description" + '»' + txtDescription.value;

        var OtherCostTime = "HourlyRate" + '»' + txtHourlyRateID.value + '±' + "SetUpTime" + '»' + txtSetUpTimeID.value + '±' +
            "SetUpCost" + '»' + lblSetUpCostID.innerHTML + '±' + "Hours" + '»' + txtHoursID.value + '±' +
            "Passes" + '»' + txtPassesID.value + '±' + "Markup" + '»' + txtProfitID.value + '±' +
            "SellingPrice" + '»' + txtSellingPriceID.value + '±' + "RunsRequired" + '»' + txtRunsRequiredID.value + '±' +
            "Speed" + '»' + lblSpeedID.innerHTML + '±' + "TotalTime" + '»' + lblTotalTimeID.innerHTML + '±' +
            "Cost" + '»' + lblCostID.innerHTML + '±' + "HourlyRunSpeed" + '»' + hid_HourlySpeedID.value;

        var OtherCostQuantity = "UnitRate" + '»' + txtQtyUnitRateID.value + '±' + "Quantity" + '»' + txtQtyQuantityID.value + '±' +
            "Markup" + '»' + txtQtyProfitID.value + '±' + "SellingPrice" + '»' + txtQtySellingPriceID.value + '±' +
            "SetUpTime" + '»' + txtQtySetUpTimeID.value + '±' + "SetUpCost" + '»' + lblQtySetUpCostID.innerHTML + '±' +
            "HourlyRate" + '»' + txtQtyHourlyRateID.value + '±' + "TotalTime" + '»' + lblQtyTotalTimeID.innerHTML + '±' +
            "Cost" + '»' + hid_QtyCost.value + '±' + "Cost1" + '»' + hid_QtyCost1.value + '±' + "Cost2" + '»' + hid_QtyCost2.value + '±' +
            "Cost3" + '»' + hid_QtyCost3.value + '±' + "UnitRate1" + '»' + txtQtyUnitRateID1.value + '±' + "UnitRate2" + '»' + txtQtyUnitRateID2.value + '±' +
            "UnitRate3" + '»' + txtQtyUnitRateID3.value + '±' + "Quantity1" + '»' + txtQtyQuantityID1.value + '±' + "Quantity2" + '»' + txtQtyQuantityID2.value + '±' +
            "Quantity3" + '»' + txtQtyQuantityID3.value + '±' + "Markup1" + '»' + txtQtyProfitID1.value + '±' + "Markup2" + '»' + txtQtyProfitID2.value + '±' +
            "Markup3" + '»' + txtQtyProfitID3.value + '±' + "SellingPrice1" + '»' + txtQtySellingPriceID1.value + '±' + "SellingPrice2" + '»' + txtQtySellingPriceID2.value + '±' +
            "SellingPrice3" + '»' + txtQtySellingPriceID3.value;

        var SectionNo = 0;
        
        var FormulaTag0 = txtWithActualsID.value != "" ? txtWithActualsID.value + '¶' + '<%=FormulaTag %>' : 0 + '¶' + '<%=FormulaTag %>';
        var FormulaTag1 = txtWithActualsID1.value != 0 ? txtWithActualsID1.value + '¶' + '<%=FormulaTag %>' : 0 + '¶' + '<%=FormulaTag %>';
        var FormulaTag2 = txtWithActualsID2.value != "" ? txtWithActualsID2.value + '¶' + '<%=FormulaTag %>' : 0 + '¶' + '<%=FormulaTag %>';
        var FormulaTag3 = txtWithActualsID3.value != "" ? txtWithActualsID3.value + '¶' + '<%=FormulaTag %>' : 0 + '¶' + '<%=FormulaTag %>';

        var OtherCostFormula = "Formula" + '»' + txtFormulaID.value + '±' + "FormulaTag" + '»' + FormulaTag0 + '±' + "Cost" + '»' + txtFormulaCost.value + '±' +
            "Markup" + '»' + txtFormulaProfit.value + '±' + "SellingPrice" + '»' + txtFormulaSellingPrice.value + '±' +
            "Cost1" + '»' + txtFormulaCost1.value + '±' + "Markup1" + '»' + txtFormulaProfit1.value + '±' + "SellingPrice1" + '»' + txtFormulaSellingPrice1.value + '±' +
            "FormulaTag1" + '»' + FormulaTag1 + '±' + "Cost2" + '»' + txtFormulaCost2.value + '±' +
            "Markup2" + '»' + txtFormulaProfit2.value + '±' + "SellingPrice2" + '»' + txtFormulaSellingPrice2.value + '±' +
            "FormulaTag2" + '»' + FormulaTag2 + '±' + "Cost3" + '»' + txtFormulaCost3.value + '±' + "Markup3" + '»' + txtFormulaProfit3.value + '±' +
            "SellingPrice3" + '»' + txtFormulaSellingPrice3.value + '±' + "FormulaTag3" + '»' + FormulaTag3 + '±' + "SectionNo" + '»' + SectionNo;



        var OtherCostTypeVal = '';
        var CheckHourQtyVal = '';
        if (caltype == 't') {
            OtherCostTypeVal = OtherCostTime + '±' + "SectionNo" + '»' + SectionNo;
            CheckHourQtyVal = "DefaultQtyType»" + '<%=DefaultHourOrQtyType %>' + "±FixedQty»" + '<%=FixedHourOrQty %>' + "±VariableQty»"
                + '<%=VariableHourOrQty %>' + "±HoursOrQty»" + txtHoursID.value;
        }
        else if (caltype == 'q') {
            OtherCostTypeVal = OtherCostQuantity + '±' + "SectionNo" + '»' + SectionNo;
            CheckHourQtyVal = "DefaultQtyType»" + '<%=DefaultHourOrQtyType %>' + "±FixedQty»" + '<%=FixedHourOrQty %>' + "±VariableQty»"
                + '<%=VariableHourOrQty %>' + "±HoursOrQty»" + txtQtyQuantityID.value;
        }
        else if (caltype == 'f' || caltype == 'm') {
            OtherCostTypeVal = OtherCostFormula;
        }

        //== To Compare for changes in add case ==//
        var othIsChanged = 'no';
        if (hdn_compare_sellingprice.value != "") {
            var strComp = hdn_compare_sellingprice.value.split('µ');
            var compcnt = 0;
            if (strComp != null && strComp.length > 0) {
                var selprice1 = 0;
                var selprice2 = 0;
                var selprice3 = 0;
                var selprice4 = 0;

                if (caltype == 'q') {
                    selprice1 = txtQtySellingPriceID.value;
                    selprice2 = txtQtySellingPriceID1.value;
                    selprice3 = txtQtySellingPriceID2.value;
                    selprice4 = txtQtySellingPriceID3.value;
                }
                else if (caltype == 't') {
                    selprice1 = txtSellingPriceID.value;
                }
                else {
                    selprice1 = txtFormulaSellingPrice.value;
                    selprice2 = txtFormulaSellingPrice1.value;
                    selprice3 = txtFormulaSellingPrice2.value;
                    selprice4 = txtFormulaSellingPrice3.value;
                }
                if (strComp[0] != selprice1 || strComp[1] != selprice2 || strComp[2] != selprice3 || strComp[3] != selprice4) {
                    compcnt++;
                }
            }

            othIsChanged = compcnt > 0 ? "yes" : "no";
        }
        //== END To Compare for changes in add case ==//


        if (Mode.split('~')[0] == 'openfromsummary') {
            pw.hdn_IsOthercostsavedFromPopUp.value = "yes"; // pw.hdn_IsOthercostsavedFromPopUp != null ? "yes" : "no";
            pw.BindOtherCostOnEdit(OtherCostVal, caltype, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal);
            pw.getOtherCostval();

            var SummaryControlsID = ModeinOrgionalCase.split('~')[1];
            var currenthdnEditOtherCostValues = window.parent.document.getElementById(SummaryControlsID.replace('lnkOtherCostFromSummary', 'hdnEditOtherCostValues'));
            currenthdnEditOtherCostValues.value = pw.hdnEditOtherCostValues.value;
            window.parent.__doPostBack('ctl00$ContentPlaceHolder1$UCItemSummaryMain$UcOtherCostItem_' + ModeinOrgionalCase.split('~')[2] + '$lnkOtherCostFromSummary', '');
        }
        else {

            if (pw.OtherIndex != '') {

                pw.hdn_IsOthercostsavedFromPopUp.value = "no"; //pw.hdn_IsOthercostsavedFromPopUp != null ? "yes" : "no";
                pw.BindOtherCostOnEdit(OtherCostVal, caltype, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal);
            }
            else {
                pw.hdn_IsOthChangedInAdd.value += pw.hdn_IsOthChangedInAdd != null ? othIsChanged + "»" : "no";
                if (Mode == "add" && ItemType == "s") {
                    window.close();
                }
                pw.BindOtherCostItems(OtherCostVal, caltype, OtherCostTypeVal, ItemType, Mode, CheckHourQtyVal);
            }
            window.close();
        }

    }



    function gettextboxdisplayedinqtybased() {
        if (ActualQuantiry2 != null && ActualQuantiry2 != '') {
            div_unitrate1.style.display = "block";
            div_qtytext1.style.display = "block";
            div_qtymarkup1.style.display = "block";
            div_qtysellingprice1.style.display = "block";
        }
        if (ActualQuantiry3 != null && ActualQuantiry3 != '') {
            div_unitrate2.style.display = "block";
            div_qtytext2.style.display = "block";
            div_qtymarkup2.style.display = "block";
            div_qtysellingprice2.style.display = "block";
        }

        if (ActualQuantiry4 != null && ActualQuantiry4 != '') {
            div_unitrate3.style.display = "block";
            div_qtytext3.style.display = "block";
            div_qtymarkup3.style.display = "block";
            div_qtysellingprice3.style.display = "block";
        }
    }

    function Recalculate() {
        document.getElementById("div_Load").style.display = "block";
        //document.getElementById("ds01").style.display = "block";

        Actual = '<%=FormulaTag %>';
    ActualArray.length = 0;

    for (g = 0; g < 5; g++) {
        ActualArray[g] = Actual;
    }

    var Actuals_Main = Actual; //'<%=FormulaTag %>';


    if (otherinx != '') {
        if (caltype == 'm') {
            ShowHideMatrixTable('show');
            div_btnMatrixOk.style.display = "none";
        }

        var StrArray = Actual.split('Q::');
        hdn_QuestionValue.Value = StrArray;
        if (StrArray.length > 1) {

            var round = 0;
            for (var i = 1; i < StrArray.length; i++) {
                var data_0 = replace_char(SpecialDecode(StrArray[i]));
                //var data_0 = (StrArray[i]);
                var old_data = document.getElementById("div_question").innerHTML;

                document.getElementById("div_question").innerHTML = old_data + '' + CreateHTML(SpecialEncode(data_0), round, Actual);
                round++;
            }

            //document.getElementById("div_question").style.display = "block";
            showDivPopupCenter_ForOthercost('div_question', '200');

            document.getElementById("div_ques_0").style.display = "block";

            document.getElementById("ds00").style.width = "100%"; //window.screen.availWidth+"px";
            //document.getElementById("ds00").style.height = window.screen.availHeight + "px";
            document.getElementById("ds00").style.height = "400px";
            document.getElementById("ds00").style.display = "block";

        }
        else {
            var qtynew = '<%=qty%>'.split(',');
                for (k = 0; k < qtynew.length; k++) {
                    debugger;
                    if (qtynew[k] != null) {
                        CalculateVariableQty(ActualArray[k], MatrixVal[k], qtynew[k], k, 'formulabased');
                    }
                }
                CalculateSellingPrice();
            }
        }

        if (pgtype != "estimate" && ItemType == "s") {
            CallWhenJObOrInvoice();
        }

        //document.getElementById("ds01").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
        // div_btnRecalculate.style.display = "none";
    }

    function isPostBack() {
        if (!document.getElementById('clientSideIsPostBack')) {
            if (caltype == 'q') {
                var OtherCostTypeVal = hdnEditOtherValues.value;
                var qtyval = OtherCostTypeVal.split('±');
                var qtyval2 = '';
                var propqty = '';
                var valueqty = '';
                for (var y = 0; y < qtyval.length; y++) {
                    qtyval2 = qtyval[y].split('»');
                    propqty = qtyval2[0];
                    valueqty = qtyval2[1];
                    valueqty = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', false, false, false);

                    if (trim12(propqty) == "UnitRate1") {
                        txtQtyUnitRateID1.value = valueqty;
                    }
                    if (trim12(propqty) == "UnitRate2") {
                        txtQtyUnitRateID2.value = valueqty;
                    }
                    if (trim12(propqty) == "UnitRate3") {
                        txtQtyUnitRateID3.value = valueqty;
                    }

                    if (trim12(propqty) == "Quantity1") {
                        txtQtyQuantityID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }
                    if (trim12(propqty) == "Quantity2") {
                        txtQtyQuantityID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }
                    if (trim12(propqty) == "Quantity3") {
                        txtQtyQuantityID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, valueqty, 0, '', true, false, false);
                    }

                    if (trim12(propqty) == "Markup1") {
                        txtQtyProfitID1.value = valueqty;
                    }
                    if (trim12(propqty) == "Markup2") {
                        txtQtyProfitID2.value = valueqty;
                    }
                    if (trim12(propqty) == "Markup3") {
                        txtQtyProfitID3.value = valueqty;
                    }

                    if (trim12(propqty) == "SetUpTime") {
                        txtQtySetUpTimeID.value = valueqty;
                    }
                    if (trim12(propqty) == "HourlyRate") {
                        txtQtyHourlyRateID.value = valueqty;
                    }
                }

                lblQtyTotalTimeID.innerHTML = txtQtySetUpTimeID.value;
                var setupcost = (txtQtyHourlyRateID.value * txtQtySetUpTimeID.value) / 60;
                lblQtySetUpCostID.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, setupcost, 0, '', false, false, false);

                var sellingprice = (txtQtyUnitRateID.value * txtQtyQuantityID.value);
                var profit = Number((sellingprice * txtQtyProfitID.value) / 100);

                if (QtyNo == 2) {

                    var sellingprice1 = (txtQtyUnitRateID1.value * txtQtyQuantityID1.value);
                    hid_QtyCost1.value = sellingprice1 + setupcost;
                    var profit1 = Number((sellingprice1 * txtQtyProfitID1.value) / 100);
                    txtQtySellingPriceID1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice1 + profit1 + setupcost), 0, '', false, false, false);

                    div_unitrate1.style.display = "block";
                    div_qtytext1.style.display = "block";
                    div_qtymarkup1.style.display = "block";
                    div_qtysellingprice1.style.display = "block";

                    div_unitrate0.style.display = "none";
                    div_qtytext0.style.display = "none";
                    div_qtymarkup0.style.display = "none";
                    div_qtysellingprice0.style.display = "none";
                }
                if (QtyNo == 3) {

                    var sellingprice2 = (txtQtyUnitRateID2.value * txtQtyQuantityID2.value);
                    hid_QtyCost2.value = sellingprice2 + setupcost;
                    var profit2 = Number((sellingprice2 * txtQtyProfitID2.value) / 100);
                    txtQtySellingPriceID2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice2 + profit2 + setupcost), 0, '', false, false, false);

                    div_unitrate2.style.display = "block";
                    div_qtytext2.style.display = "block";
                    div_qtymarkup2.style.display = "block";
                    div_qtysellingprice2.style.display = "block";

                    div_unitrate0.style.display = "none";
                    div_qtytext0.style.display = "none";
                    div_qtymarkup0.style.display = "none";
                    div_qtysellingprice0.style.display = "none";
                }

                if (QtyNo == 4) {

                    var sellingprice3 = (txtQtyUnitRateID3.value * txtQtyQuantityID3.value);
                    hid_QtyCost3.value = sellingprice3 + setupcost;
                    var profit3 = Number((sellingprice3 * txtQtyProfitID3.value) / 100);
                    txtQtySellingPriceID3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(sellingprice3 + profit3 + setupcost), 0, '', false, false, false);

                    div_unitrate3.style.display = "block";
                    div_qtytext3.style.display = "block";
                    div_qtymarkup3.style.display = "block";
                    div_qtysellingprice3.style.display = "block";

                    div_unitrate0.style.display = "none";
                    div_qtytext0.style.display = "none";
                    div_qtymarkup0.style.display = "none";
                    div_qtysellingprice0.style.display = "none";
                }
            }
        }

        //if (document.getElementById('clientSideIsPostBack').value == 'Y') {
        //    return true;
        //}
        //else {
        //    return false;
        //}
    }

    function CallWhenJObOrInvoice() {
        debugger;
        if (pgtype != "estimate") {
            if (ItemType == "s") {
                document.getElementById("WithActuals0").style.display = "none";
                document.getElementById("FormulaCost0").style.display = "none";
                document.getElementById("FormulaProfit0").style.display = "none";
                document.getElementById("FormulaSellingPrice0").style.display = "none";

                document.getElementById("WithActuals1").style.display = "none";
                document.getElementById("FormulaCost1").style.display = "none";
                document.getElementById("FormulaProfit1").style.display = "none";
                document.getElementById("FormulaSellingPrice1").style.display = "none";

                document.getElementById("WithActuals2").style.display = "none";
                document.getElementById("FormulaCost2").style.display = "none";
                document.getElementById("FormulaProfit2").style.display = "none";
                document.getElementById("FormulaSellingPrice2").style.display = "none";

                document.getElementById("WithActuals3").style.display = "none";
                document.getElementById("FormulaCost3").style.display = "none";
                document.getElementById("FormulaProfit3").style.display = "none";
                document.getElementById("FormulaSellingPrice3").style.display = "none";

                div_unitrate0.style.display = "none";
                div_qtytext0.style.display = "none";
                div_qtymarkup0.style.display = "none";
                div_qtysellingprice0.style.display = "none";

                div_unitrate1.style.display = "none";
                div_qtytext1.style.display = "none";
                div_qtymarkup1.style.display = "none";
                div_qtysellingprice1.style.display = "none";

                div_unitrate2.style.display = "none";
                div_qtytext2.style.display = "none";
                div_qtymarkup2.style.display = "none";
                div_qtysellingprice2.style.display = "none";

                div_unitrate3.style.display = "none";
                div_qtytext3.style.display = "none";
                div_qtymarkup3.style.display = "none";
                div_qtysellingprice3.style.display = "none";

                if (QtyNo == 1) {
                    if (caltype == 'f' || caltype == 'm') {
                        document.getElementById("WithActuals0").style.display = "block";
                        document.getElementById("FormulaCost0").style.display = "block";
                        document.getElementById("FormulaProfit0").style.display = "block";
                        document.getElementById("FormulaSellingPrice0").style.display = "block";
                    }
                    else {
                        div_unitrate0.style.display = "block";
                        div_qtytext0.style.display = "block";
                        div_qtymarkup0.style.display = "block";
                        div_qtysellingprice0.style.display = "block";
                    }
                }
                if (QtyNo == 2) {
                    if (caltype == 'f' || caltype == 'm') {
                        document.getElementById("WithActuals1").style.display = "block";
                        document.getElementById("FormulaCost1").style.display = "block";
                        document.getElementById("FormulaProfit1").style.display = "block";
                        document.getElementById("FormulaSellingPrice1").style.display = "block";
                    }
                    else {
                        div_unitrate1.style.display = "block";
                        div_qtytext1.style.display = "block";
                        div_qtymarkup1.style.display = "block";
                        div_qtysellingprice1.style.display = "block";
                    }
                }
                if (QtyNo == 3) {
                    if (caltype == 'f' || caltype == 'm') {
                        document.getElementById("WithActuals2").style.display = "block";
                        document.getElementById("FormulaCost2").style.display = "block";
                        document.getElementById("FormulaProfit2").style.display = "block";
                        document.getElementById("FormulaSellingPrice2").style.display = "block";
                    }
                    else {
                        div_unitrate2.style.display = "block";
                        div_qtytext2.style.display = "block";
                        div_qtymarkup2.style.display = "block";
                        div_qtysellingprice2.style.display = "block";
                    }
                }
                if (QtyNo == 4) {
                    if (caltype == 'f' || caltype == 'm') {
                        document.getElementById("WithActuals3").style.display = "block";
                        document.getElementById("FormulaCost3").style.display = "block";
                        document.getElementById("FormulaProfit3").style.display = "block";
                        document.getElementById("FormulaSellingPrice3").style.display = "block";
                    }
                    else {
                        div_unitrate3.style.display = "block";
                        div_qtytext3.style.display = "block";
                        div_qtymarkup3.style.display = "block";
                        div_qtysellingprice3.style.display = "block";
                    }
                }
            } else {

                window.onload = isPostBack;
            }
        }
    }

    if (pgtype != "estimate") {
        CallWhenJObOrInvoice();
    }

    function Loading_onSaveOtherCost() {
        debugger;
        showDivPopupCenter_ForOthercost('div_question', '200');
        document.getElementById("div_Load").style.display = "block";
        document.getElementById("divBackGroundNew").style.backgroundColor = "white";
        CalculateSellingPrice_ForSave();
        CallSaveCost();
        //document.getElementById("div_question").style.display = "none";
        //document.getElementById("divBackGroundNew").style.display = "none";
        //document.getElementById("ds00").style.display = "none";
        //document.getElementById("div_Load").style.display = "none";
    }
</script>
<script type="text/javascript">
    document.getElementById("ds01").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    //txtFormulaProfit.value="0"; 
</script>

