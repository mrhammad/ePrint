<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_addnew_costcentre.ascx.cs" Inherits="ePrint.usercontrol.Item.item_addnew_costcentre" %>

<div id="div_costcentre" align="left" style="display: block; width: 100%;">
    <div style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Add New Cost Centre</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('coscentre_close');" style="color: White;">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div class="divBorderItem">
        <div id="div_costcentre_step_1" align="left" style="width: 100%; display: block;">
            <div align="left">
                <div style="float: left; width: 20%;">
                    Cost Centre Name:
                </div>
                <div style="float: left;">
                    <asp:TextBox ID="txtcostcentre" runat="server" CssClass="txtBox" Width="200px"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both;">
                &nbsp;</div>
            <div align="left">
                <div style="float: left; width: 20%;">
                    Description:
                </div>
                <div style="float: left;">
                    <asp:TextBox ID="txtcostdescription" runat="server" CssClass="txtBox" TextMode="MultiLine"
                        Width="200px" Height="60px"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both;">
                &nbsp;</div>
            <div align="left">
                <div style="float: left; width: 20%;">
                    Category:
                </div>
                <div style="float: left; width: 45%;">
                    <asp:DropDownList ID="ddlcategory_1" runat="server" CssClass="MaskDDL" Width="200px">
                        <asp:ListItem Value="admin">Administration</asp:ListItem>
                        <asp:ListItem Value="prepress">PrePess</asp:ListItem>
                        <asp:ListItem Value="press">Press</asp:ListItem>
                        <asp:ListItem Value="postpress">PostPess</asp:ListItem>
                        <asp:ListItem Value="bindery">Bindery</asp:ListItem>
                        <asp:ListItem Value="laminating">Laminating</asp:ListItem>
                        <asp:ListItem Value="delivery">Delivery</asp:ListItem>
                        <asp:ListItem Value="misc">Misc</asp:ListItem>
                        <asp:ListItem Value="general">General</asp:ListItem>
                        <asp:ListItem Value="material">Material</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="clear: both;">
                &nbsp;</div>
            <div align="left">
                <div style="float: left; width: 20%;">
                    Calculation Template:
                </div>
                <div style="float: left; width: 45%;">
                    <asp:DropDownList ID="ddlcalculation" runat="server" CssClass="MaskDDL" Width="200px">
                        <asp:ListItem Value="time">Time Based</asp:ListItem>
                        <asp:ListItem Value="quantity">Quantity Based</asp:ListItem>
                        <asp:ListItem Value="formula">Formula Based</asp:ListItem>
                        <asp:ListItem Value="formulamatrix">Formula Bases with Matrix Table</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="clear: both;">
                &nbsp;</div>
            <div align="left">
                <div align="left">
                    <div style="float: left; width: 20%;">
                        &nbsp;</div>
                </div>
                <div style="float: left;">
                    <%--<asp:Button ID="btnnext_1" runat="server" Text="Next" CssClass="button" Width="65px"
                        OnClientClick="javascript:nextcostcentrestep_1();return false;" />--%>
                    <input type="button" value="Next" class="button" onclick="javascript: nextcostcentrestep_1();"
                        style="width: 65px" />
                </div>
                <div style="float: left; width: 10px;">
                    &nbsp;
                </div>
                <div style="float: left; width: 10%;">
                    <asp:Button ID="btncostcentrecancel_1" runat="server" Text="Cancel" CssClass="button"
                        Width="65px" OnClientClick="javascript:cancelcostcentre_2('cost_centre');return false;" />
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
            </div>
        </div>
        <div id="div_costcentre_step_2" align="left" style="width: 100%; display: none;">
            <div align="left">
                <div align="left">
                    <div style="float: left;" class="HeaderText">
                        User Defined
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Name:
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="txtname" runat="server" CssClass="txtBox"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 2%">
                        &nbsp;</div>
                    <div style="float: left; width: 8%;">
                        Category:
                    </div>
                    <div style="float: left;">
                        <asp:DropDownList ID="ddlcategory_2" runat="server" CssClass="MaskDDL">
                            <asp:ListItem Value="admin">Administration</asp:ListItem>
                            <asp:ListItem Value="prepress">PrePess</asp:ListItem>
                            <asp:ListItem Value="press">Press</asp:ListItem>
                            <asp:ListItem Value="postpress">PostPess</asp:ListItem>
                            <asp:ListItem Value="bindery">Bindery</asp:ListItem>
                            <asp:ListItem Value="laminating">Laminating</asp:ListItem>
                            <asp:ListItem Value="delivery">Delivery</asp:ListItem>
                            <asp:ListItem Value="misc">Misc</asp:ListItem>
                            <asp:ListItem Value="general">General</asp:ListItem>
                            <asp:ListItem Value="material">Material</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Description:
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Priority:
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 1%">
                        &nbsp;</div>
                    <div style="float: left;">
                        The lower the value the sooner it appears on the job ticket
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Direct Cost:
                    </div>
                    <div style="float: left;">
                        <asp:CheckBoxList ID="chkdirectcost" runat="server" RepeatDirection="vertical">
                            <asp:ListItem Value="0">Check this box if the costs are external or materials</asp:ListItem>
                            <asp:ListItem Value="1">Do you wish to print this cost centre on Job Card?</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Supplier:
                    </div>
                    <div style="float: left;">
                        <asp:DropDownList ID="ddlsupplier" runat="server" CssClass="MaskDDL">
                            <asp:ListItem Value="0">Antalis Paper</asp:ListItem>
                            <asp:ListItem Value="1">Inking Ltd</asp:ListItem>
                            <asp:ListItem Value="2">My Printing Co</asp:ListItem>
                            <asp:ListItem Value="3">Robert Horne Paper Supplies</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; width: 2%">
                        &nbsp;</div>
                    <div style="float: left;">
                        Per Hour Cost:
                    </div>
                    <div style="float: left; width: 1%">
                        &nbsp;</div>
                    <div style="float: left;">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div id="div_time" align="left" style="display: none;">
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Hourly Rate '<%=commclass.GetCurrencyinRequiredFormate("",true) %>':
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Per Hour
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Make Ready Time:
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Mins
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Hourly Run Speed:
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Per Hour</div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%">
                            &nbsp;</div>
                        <div style="float: left; width: 80%;">
                            <fieldset>
                                <legend>Default values to recommond</legend>
                                <div style="float: left;">
                                    <asp:RadioButtonList ID="rdlvalue" runat="server">
                                        <asp:ListItem Value="0">Fixed Hours</asp:ListItem>
                                        <asp:ListItem Value="1">Hours calculated Based on Qty  and Run Speed</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div style="float: left; width: 2%">
                                    &nbsp;</div>
                                <div style="float: left;">
                                    <div style="float: left;">
                                        <asp:TextBox ID="TextBox7" runat="server" CssClass="txtBox"></asp:TextBox>
                                    </div>
                                    <div style="clear: both;">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:DropDownList ID="ddlhours" runat="server" CssClass="MaskDDL">
                                            <asp:ListItem Value="0">Print Sheets Qty excl Spoilage / Hourly Run Speed</asp:ListItem>
                                            <asp:ListItem Value="1">Print Sheets Qty incl Spoilage / Hourly Run Speed</asp:ListItem>
                                            <asp:ListItem Value="2">Finished Sheets Qty / Hourly Run Speed</asp:ListItem>
                                            <asp:ListItem Value="3">Finished Sheets Qty incl Spoilage / Hourly Run Speed</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                            </fieldset>
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                </div>
                <div id="div_quantity" align="left" style="display: none;">
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Hourly Rate '<%=commclass.GetCurrencyinRequiredFormate("",true) %>':
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox10" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Per Hour
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Make Ready Time:
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox11" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Mins
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Time per Unit:
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox12" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            Mins</div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Default Unit Cost:
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="TextBox13" runat="server" CssClass="txtBox"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 1%">
                            &nbsp;</div>
                        <div style="float: left;">
                            <asp:Button ID="btnmatrix" runat="server" CssClass="button" Text="Matrix for Unit Cost" /></div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%">
                            &nbsp;</div>
                        <div style="float: left; width: 80%;">
                            <fieldset>
                                <legend>Default values to recommond</legend>
                                <div style="float: left;">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem Value="0">Fixed Value</asp:ListItem>
                                        <asp:ListItem Value="1">Variable Value</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div style="float: left; width: 2%">
                                    &nbsp;</div>
                                <div style="float: left;">
                                    <div style="float: left;">
                                        <asp:TextBox ID="TextBox14" runat="server" CssClass="txtBox"></asp:TextBox>
                                    </div>
                                    <div style="clear: both;">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="MaskDDL">
                                            <asp:ListItem Value="0">Print Sheets Qty excl Spoilage</asp:ListItem>
                                            <asp:ListItem Value="1">Print Sheets Qty incl Spoilage</asp:ListItem>
                                            <asp:ListItem Value="2">Finished Sheets Qty</asp:ListItem>
                                            <asp:ListItem Value="3">Finished Sheets Qty incl Spoilage</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div style="clear: both;">
                                    &nbsp;</div>
                            </fieldset>
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                </div>
                <div id="div_formula" align="left" style="display: none;">
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            Formula:<br />
                            Cost Charges:
                        </div>
                        <div style="float: left; width: 80%;">
                            <asp:TextBox ID="txtformula" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                        </div>
                    </div>
                    <div style="clear: both;">
                        &nbsp;</div>
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button1" runat="server" Text="(" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button2" runat="server" Text=")" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button3" runat="server" Text="+" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button4" runat="server" Text="-" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button5" runat="server" Text="x" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button6" runat="server" Text="/" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button7" runat="server" Text="^" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button8" runat="server" Text="Mod" Width="90%" CssClass="button" />
                        </div>
                        <div style="float: left; width: 4%;">
                            <asp:Button ID="Button9" runat="server" Text="%" Width="90%" CssClass="button" />
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Profit %
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="txtBox"></asp:TextBox>
                    </div>
                    <div style="float: left; width: 2%">
                        &nbsp;</div>
                    <div style="float: left;">
                        After the formula is executed, the Profit % is added to the final Selling Price<br />
                        for this Cost Centre.VA contributes towards Profit.</div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
                <div align="left">
                    <div style="float: left; width: 15%;">
                        Minimum
                    </div>
                    <div style="float: left;">
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="txtBox"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both; height: 22px;">
                    &nbsp;</div>
                <div align="left">
                    <div align="left">
                        <div style="float: left; width: 15%;">
                            &nbsp;</div>
                    </div>
                    <div style="float: left;">
                        <asp:Button ID="btnapply_2" runat="server" Text="Apply" CssClass="button" Width="65px"
                            OnClientClick="javascript:cancelcostcentre_2();return false;" />
                    </div>
                    <div style="float: left; width: 10px;">
                        &nbsp;
                    </div>
                    <div style="float: left; width: 10%;">
                        <asp:Button ID="btncancel_2" runat="server" Text="Cancel" CssClass="button" Width="65px"
                            OnClientClick="javascript:cancelcostcentre_2();return false;" />
                    </div>
                </div>
                <div style="clear: both;">
                    &nbsp;</div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">

    var ddlcal = "ctl00_ContentPlaceHolder1_UCItemAdd_divusercostcentres_addnewcostcentre_ddlcalculation"
    //"ctl00_ContentPlaceHolder1_additem_divusercostcentres_addnewcostcentre_ddlcalculation" ;
    //"ctl00_ContentPlaceHolder1_addnewcostcentre_ddlcalculation";
    var costcentre_step_1 = "div_costcentre_step_1"
    var costcentre_step_2 = "div_costcentre_step_2";
    var time = "div_time";
    var quantity = "div_quantity";
    var formula = "div_formula";
    function nextcostcentrestep_1() {
        document.getElementById(costcentre_step_1).style.display = "none";
        document.getElementById(costcentre_step_2).style.display = "block";
        document.getElementById(time).style.display = "none";
        document.getElementById(quantity).style.display = "none";
        document.getElementById(formula).style.display = "none";
        var ddlcal1 = "ctl00_ContentPlaceHolder1_costcentre1_ddlcalculation"
        if (document.getElementById(ddlcal1).value == "time") {
            document.getElementById(time).style.display = "block";
        }
        else if (document.getElementById(ddlcal1).value == "quantity") {
            document.getElementById(quantity).style.display = "block";
        }
        else if (document.getElementById(ddlcal1).value == "formula") {
            document.getElementById(formula).style.display = "block";
        }
        else if (document.getElementById(ddlcal1).value == "formulamatrix") {
            document.getElementById(formula).style.display = "block";
        }
    }

    function cancelcostcentre_2(cid) {
        if (cid == 'cost_centre') {
            document.getElementById("costcentre").style.display = "block";
            document.getElementById("div_costcentre").style.display = "none";
        }
        else {
            document.getElementById(costcentre_step_1).style.display = "block";
            document.getElementById(costcentre_step_2).style.display = "none";
        }
    }

</script>


