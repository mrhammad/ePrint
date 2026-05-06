<%@ control language="C#" autoeventwireup="true" CodeBehind="pad_item.ascx.cs" Inherits="ePrint.usercontrol.Item.pad_item" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>' " language="javascript"></script>
<script type="text/javascript" src="../js/item/calculations.js?VN='<%=VersionNumber%>'"
    language="javascript"></script>
<script>
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<script type="text/javascript">
    setLoadingPositionOfDivMove(div_Load);
</script>
<div id="divMainContent">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_AlertPopup" style="display: none; position: absolute; width: 1100px; left: 125px; z-index: 10;">
    </div>
    <div id="content">
        <%--  <div class="borderWithoutTop" style="padding: 5px;">--%>
        <%-- LEFT SIDE --%>
        <div style="float: left; width: 50%; border: solid 0px red;">
            <div align="left" style="display: block;">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label10" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Item_Title")%></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div class="box" style="float: left; padding-left: 5px">
                    <asp:TextBox ID="txtItemTitle" SkinID="textPad" runat="server" Width="260px" MaxLength="75"
                        onblur="CallonBlur(this.value,'spn_txtItemTitle');"></asp:TextBox>
                </div>
                <div>
                    <span id="spn_txtItemTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;margin-left:5px">
                        <%=objLanguage.GetLanguageConversion("Please_Enter_Item_Title")%></span>
                </div>
            </div>
            <div align="left" style="display: none;">
                <div class="bglabel">
                    <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Estimate_Type")%></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div class="ddlsetting">
                    <asp:DropDownList ID="ddlEstimateType" onchange="javascript:ShowEstimate(this.value);"
                        CssClass="normaltext" Width="175px" runat="server">
                        <asp:ListItem Text="--- Select ---" Selected="True" Value=""></asp:ListItem>
                        <asp:ListItem Text="Sheet Fed Digital" Value="digital"></asp:ListItem>
                        <asp:ListItem Text="Print Broker" Value="printbroker"></asp:ListItem>
                        <asp:ListItem Text="Warehouse" Value="warehouse"></asp:ListItem>
                        <asp:ListItem Text="Other Costs" Value="othercost"></asp:ListItem>
                        <asp:ListItem Text="Price Catalogue" Value="pricecatalogue"></asp:ListItem>
                    </asp:DropDownList>
                    <span id="spn_Label3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                        class="spanErrorMsg">
                        <%=objLanguage.GetLanguageConversion("Please_Select_Estimate_Type")%></span>
                </div>
            </div>
            <div align="left" style="display: none;">
                <div id="div_ProductType" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label4" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Product_Type")%></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting">
                        <asp:DropDownList ID="ddlProductType" onchange="javascript:ProductTypeShow(this.value);MakeArrayNull();"
                            CssClass="normaltext" Width="175px" runat="server">
                            <asp:ListItem Value="singleitem">Single Item</asp:ListItem>
                            <asp:ListItem Value="booklet"> Booklet</asp:ListItem>
                            <asp:ListItem Value="pads"> Pads</asp:ListItem>
                        </asp:DropDownList>
                        <span id="spn_Label4" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanErrorMsg">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Product_Type")%></span>
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div id="div_only_digitals_left" align="left">
                <div align="left">
                    <div class="bglabelnewLarge" style="height: 38px; border: 0px solid blue">
                        <div id="div_FinishedQty" style="float: left; border: 0px solid;">
                        </div>
                        <div id="div_BookletQty" style="display: none; float: left;">
                        </div>
                        <div id="div_PadsQty" style="display: block; float: left;">
                            <asp:Label ID="Label8" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Pad_Quantity")%></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div id="divhrefQtyMore" style="float: right; vertical-align: bottom; border: 0px solid red; display: none">
                            <asp:HiddenField ID="hid_QtyType" Value="S" runat="server" />
                            <asp:HiddenField ID="hid_Q1" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q2" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q3" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q4" Value="0" runat="server" />
                        </div>
                    </div>
                    <div style="float: left; width: 1px; border: 0px solid">
                    </div>
                    <div style="float: left; width: 50%" id="div_qty12">
                        <div id="div_qty1" class="box" style="float: left; width: 120px; border: 0px solid red;">
                            <%=objLanguage.GetLanguageConversion("Qty1")%>
                            <asp:TextBox ID="txtQuantity" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            <span id="spn_txtQuantity_number" class="spanerrorMsg" style="display: none; width: 165px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                        <div id="div_chkRunOnQty" style="float: left; padding-top: 15px; vertical-align: bottom">
                            <asp:CheckBox ID="chkRunOnQty" onclick="javascript:moreQty('runonqty');" Text="Run On Qty"
                                runat="server" Style="display: none" />
                        </div>
                        <div class="box" id="div_Addmore" style="float: left; display: none; width: 120px; border: 0px solid red; white-space: nowrap;"
                            nowrap="nowrap">
                            <%=objLanguage.GetLanguageConversion("Qty2")%>
                            <asp:TextBox ID="txtQuantity_2" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                        </div>
                        <div id="div_RunOnQty" style="clear: left; display: none; width: 80px; border: 0px solid red; white-space: nowrap"
                            nowrap="nowrap">
                            <div class="onlyEmpty">
                            </div>
                            <div align="left">
                                <div class="bglabelEmpty" style="float: left;">
                                </div>
                                <div style="float: left;">
                                    <%=objLanguage.GetLanguageConversion("Qty2")%><br />
                                    <asp:TextBox ID="txtRunOnQty" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                        onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                    
                    <div style="float: left; width: 50%; padding-top:2px;">
                        <div id="div_Qty_2to4" style="display: none; border: 0px solid;">
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_qty3" align="left" style="float: left;">
                                <div class="box" style="float: left; width: 120px; border: 0px solid">
                                    <%=objLanguage.GetLanguageConversion("Qty3")%>
                                    <asp:TextBox ID="txtQuantity_3" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                        onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>
                            <div id="div_qty4" class="box" style="float: left; width: 120px; border: 0px solid">
                                <%=objLanguage.GetLanguageConversion("Qty4")%>
                                <asp:TextBox ID="txtQuantity_4" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                    onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            </div>
                            <div id="div_qty_3to4" style="float: left; border: 0px solid">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="onlyEmpty">
                </div>
                <div style="border: 0px solid">
                    <div class="bglabelEmpty" style="float: left;">
                    </div>
                    <div style="float: left; border: 0px solid blue; margin-left: -102px; margin-top: -11px;">
                        <span id="spn_txtQuantity" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div id="div_SectionRef" style="display: none;">
                    <div class="onlyEmpty">
                    </div>
                    <div class="bglabel">
                        <asp:Label ID="Label5" runat="server" Text="Section Reference" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSectionRef" SkinID="textPad" runat="server" MaxLength="100">Section 1</asp:TextBox>
                        <span id="spn_txtSectionRef" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Section_Reference")%></span>
                    </div>
                </div>
                <div align="left">
                    <div class="onlyEmpty">
                    </div>
                    <div class="bglabelnewLarge" style="float: left">
                        <asp:Label ID="Label9" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Assigned_Press")%></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="float: left;">
                        <asp:DropDownList ID="ddlPress" CssClass="normaltext" Width="260px" onchange="PressOnChange(this);LoadCalculations(this.id);ItemSize_AssignToSummary('ddlitemsize');Paper_AssignToSummary();"
                            runat="server">
                        </asp:DropDownList>
                        <span id="spn_ddlPress" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Press")%></span>
                        <asp:HiddenField ID="hid_DigitalPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_LargeFormatPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_DefaultDigitalPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_DefaultLargePress" runat="server" Value="" />
                        <script>
                            var CompanyID = "<%=CompanyID%>";
                            var strSitepath = "<%=strSitepath %>";
                        </script>
                    </div>
                </div>
                <div class="only10px">
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <div style="float: left;">
                            <asp:Label ID="Label12" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Paper_Stock")%></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div style="float: right;">
                            <a href="javascript://" onclick="OpenPaperPopUp('paper');">
                                <img src="<%=strImagepath%>plus.gif" border="0" /></a>
                            <asp:HiddenField ID="hdn_PaperProperties" runat="server" Value="" />
                        </div>
                        <div>
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                    <div class="box" style="float: left;">
                        <div class="graytext" style="overflow: hidden; white-space: nowrap; width: 260px; padding-left: 2px;">
                            <asp:Label ID="lblDefaultPaper" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                            <br />
                            <asp:Label ID="lblPaperWeight" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                            <asp:HiddenField ID="hdnpaperID" runat="server" Value="" />
                            <span id="spn_lblDefaultPaper" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Default_Paper")%></span>
                        </div>
                        <div class="onlyEmpty" style="margin-left:-2px">
                            <asp:CheckBox ID="ChkPriceForWholePack" Text="Price for Whole Pack" onclick="javascript:checkchanged();"
                                runat="server" />
                        </div>
                        <div style="margin-left:-2px">
                            <asp:CheckBox ID="ChkPaperSupplied" Text="Paper Supplied" runat="server" onclick="javascript:checkchanged1();" />
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label13" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Setup_Spoilage")%></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box" style="margin-left:2px">
                        <asp:TextBox ID="txtSetupSpoilage" SkinID="textPad" Width="75px" runat="server" MaxLength="20"></asp:TextBox>&nbsp;
                        <span id="spnPaperType" style="font-size: 9px;margin-left:2px">
                            <%=objLanguage.GetLanguageConversion("Sheets")%></span>
                        <div>
                            <span id="spn_txtSetupSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_SetUp_Spoilage")%></span>
                            <span id="spn_txtSetupSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label14" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Running_Spoilage")%></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box" style="margin-left:2px">
                        <asp:TextBox ID="txtRunningSpoilage" SkinID="textPad" Width="75px" runat="server" 
                            MaxLength="20"></asp:TextBox>
                        <span id="Span1" style="font-size: 9px;">&nbsp;%</span>
                        <div>
                            <span id="spn_txtRunningSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Running_Spoilage")%></span>
                            <span id="spn_txtRunningSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
                <div class="only10px">
                </div>
                <%--    THE BELOW 2 TEXT BOX ARE NOT USING  --%>
                <div style="display: none;">
                    <div id="div_Booklet_1" align="left" style="display: none;">
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label15" runat="server" Text="No. of Pages Required" CssClass="normaltext"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtNoOfPagesRequired" SkinID="textPad" runat="server" MaxLength="8"></asp:TextBox>
                                <span id="spn_txtNoOfPagesRequired" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_No_Of_Pages")%></span><span id="spn_txtNoOfPagesRequired_number"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label16" runat="server" Text="Pages per Section" CssClass="normaltext"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtPagesPerSection" SkinID="textPad" runat="server" MaxLength="8"></asp:TextBox>
                                <span id="spn_txtPagesPerSection" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Pages_Per_Section")%></span><span
                                        id="spn_txtPagesPerSection_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_Pads_1" align="left" style="display: none;">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label36" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("No_Of_Leaves_Per_Pad")%></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box" style="margin-left:2px">
                        <div align="left">
                            <asp:TextBox ID="txtNoOfLeavesPerPad" SkinID="textPad" runat="server" Width="75px"
                                MaxLength="20" onkeyup="javascript:ToInteger(this,this.value);" onblur="AllowNumber(this,this.value);"></asp:TextBox>
                        </div>
                        <div align="left">
                            <span id="spn_txtNoOfLeavesPerPad" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Leaves_Per_Pad")%></span><span
                                    id="spn_txtNoOfLeavesPerPad_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label11" runat="server" Text="Colours" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="width: 169px; border: 0px solid">
                        <div align="left">
                            <div style="float: left; padding-right: 5px;">
                                <span id="spnSide1" class="normalText" style="display: none;">
                                    <%=objLanguage.GetLanguageConversion("Side1")%></span>
                            </div>
                            <div style="float: left;">
                                <asp:DropDownList ID="ddlColors" runat="server" Width="170px" SkinID="onlyDDL">
                                    <asp:ListItem Text="Colour" Value="color"></asp:ListItem>
                                    <asp:ListItem Text="Black & White" Value="black"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div align="left" id="div_side2" style="display: none;">
                            <div style="float: left;">
                                <span id="spnSide2" class="normalText" style="display: block;">
                                    <%=objLanguage.GetLanguageConversion("Side2")%></span>
                            </div>
                            <div style="float: left; padding-left: 5px;">
                                <asp:DropDownList ID="ddlColors_2" runat="server" Width="120px" SkinID="onlyDDL">
                                    <asp:ListItem Text="Colour" Value="color"></asp:ListItem>
                                    <asp:ListItem Text="Black & White" Value="black"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <span id="spn_ddlColors" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Colour")%></span>
                    </div>
                    <div style="float: left; padding-top: 3px;">
                        &nbsp;<asp:CheckBox ID="chkDoubleSided" onclick="showSides(this.checked);" Text="Double Sided"
                            runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <%-- RIGHT SIDE--%>
        <div id="div_only_digitals_right" style="float: left; width: 49%; border: solid 0px green;">
            <div id="div_booklet_NoOfPagesInSection" align="left" style="display: none">
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label18" runat="server" Text="No. of pages in this section" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <div align="left">
                            <asp:TextBox ID="txtNoOfPagesInSection" SkinID="textPad" runat="server" MaxLength="8"
                                Width="75px" onblur="javascript:Calculations();CalculateBookletSection();"></asp:TextBox><%--onblur="javascript:return CalculateBookletSection();"--%>
                        </div>
                        <div align="left">
                            <span id="spn_txtNoOfPagesInSection" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_No_Of_Pages")%></span><span id="spn_txtNoOfPagesInSection_number"
                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span><span
                                        id="spn_txtNoOfPagesInSection_divide" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left">
                <%--SHEET SIZE--%>
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label22" runat="server" Text="Print Sheet Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Print_Sheet_Size")%></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div style="float: left; width: 206px;" nowrap="nowrap">
                    <div id="div_ddlPrintSheetSize" class="ddlsetting" style="width: 206px;margin-left:-1px">
                        <asp:DropDownList ID="ddlPrintSheetSize" CssClass="normaltext" Width="175px" onchange="LoadToSheetCustom(this.value);LoadCalculations(this.id);"
                            runat="server">
                        </asp:DropDownList>
                        <span id="spn_ddlPrintSheetSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%></span>
                        <asp:HiddenField ID="hid_ddlPrintSheetSize" runat="server" Value="" />
                    </div>
                    <div style="float: left; width: 266px;" nowrap="nowrap">
                        <div id="div_PrintSheetCustomSize" class="box" style="display: none; width: 100%;">
                            <span id="spn_sheet_height" style="font-size: 9px;" class="normaltext">
                                <%=objLanguage.GetLanguageConversion("Height")%></span> &nbsp;<asp:TextBox ID="txtsectionheight"
                                    Width="52px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font><span id="spn_sheet_width" class="normaltext" style="font-size: 9px;">Width</span> &nbsp;<asp:TextBox ID="txtsectionwidth" Width="52px" SkinID="textPad"
                                    runat="server" MaxLength="20"></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font>
                        </div>
                    </div>
                    <div align="left">
                        <span id="spn_PrintSheetCustomSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Print_Sheet_Size")%></span><span
                                id="spn_PrintSheetCustomSize_numeric" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                    </div>
                </div>
                <div style="float: left; margin-left: 24px">
                    <div id="div_chkPrintSheet" style="float: left; padding-top: 2px;">
                        <asp:CheckBox ID="chkPrintSheet" onclick="javascript:PrintSheetCustom(this.id);"
                            Text="Custom" runat="server" />
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label23" runat="server" Text="Finished Job Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Finished_Job_Size")%></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div style="float: left; width: 206px;margin-left:-1px" nowrap="nowrap">
                    <div id="div_ddlJobItemSize" class="ddlsetting" style="float: left; width: 206px">
                        <asp:DropDownList ID="ddlJobItemSize" CssClass="normaltext" Width="175px" onchange="LoadToItemCustom(this.value);LoadCalculations(this.id);ItemSize_AssignToSummary('ddlitemsize');"
                            runat="server">
                        </asp:DropDownList>
                        <span id="spn_ddlJobItemSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Job_Flat_Size")%></span>
                    </div>
                    <div style="float: left; width: 266px;" nowrap="nowrap">
                        <div id="div_JobItemCustomSize" class="box" style="display: none; width: 100%;">
                            <span class="normaltext" style="font-size: 9px;">
                                <%=objLanguage.GetLanguageConversion("Height")%></span> &nbsp;<asp:TextBox ID="txtitemheight"
                                    Width="52px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font><span class="normaltext" style="font-size: 9px;">
                                    <%=objLanguage.GetLanguageConversion("Width")%></span> &nbsp;<asp:TextBox ID="txtitemwidth"
                                        Width="52px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font>
                        </div>
                    </div>
                    <div align="left">
                        <span id="spn_JobItemCustomSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Job_Flat_Size")%></span><span
                                id="spn_JobItemCustomSize_numeric" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                    </div>
                </div>
                <div style="float: left; padding-top: 2px; margin-left: 24px">
                    <asp:CheckBox ID="ChkJobFlatCustom" onclick="javascript:JobItemCustom(this.id);Calculations();ItemSize_AssignToSummary();"
                        Text="Custom" runat="server" />
                </div>
            </div>
            <div id="div_Booklet_Format" align="left" style="display: none">
                <div class="bglabel">
                    <span class="normalText">
                        <%=objLanguage.GetLanguageConversion("Booklet_Format")%></span>
                </div>
                <div class="box">
                    <asp:DropDownList ID="ddlBookletFormat" SkinID="onlyDDL" runat="server" onchange="javascript:Calculations();">
                        <asp:ListItem>Portrait</asp:ListItem>
                        <asp:ListItem>Landscape</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label24" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Include_Gutters")%></asp:Label>
                </div>
                <div id="div_GuttersCustomSize" style="display: none; float: left; width: 226px"
                    class="box">
                    <span class="normaltext" style="font-size: 9px; padding-right: 4px">Horiz.</span>
                    &nbsp;<asp:TextBox ID="txtGutterHorizontal" Width="52px" SkinID="textPad" runat="server"
                        MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font><span class="normaltext" style="font-size: 9px; padding-right: 3px">Vert.</span> &nbsp;<asp:TextBox ID="txtGutterVertical" Width="52px" SkinID="textPad"
                            runat="server" MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font>
                </div>
                <div style="float: left; padding: 2px 0px 0px 0px; border: 0px solid red; clear: right">
                    <asp:CheckBox ID="chkGutters" onclick="javascript:GuttersCustom(this.id);Calculations();setwidth();"
                        runat="server" />
                </div>
            </div>
            <div class="onlyEmpty">
                <div class="bglabelEmpty">
                </div>
                <div class="box">
                    <span id="spn_txtGutterHorizontal" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                        <%=objLanguage.GetLanguageConversion("Please_ENter_Include_Gutters")%></span>
                    <span id="spn_txtGutterHorizontal_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                        <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                </div>
            </div>
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label25" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Apply_Press_Restrictions")%></asp:Label>
                </div>
                <div class="box" style="padding: 2px 0px 0px 1px;margin-left:-1px">
                    <asp:CheckBox ID="ChkPressRestrictions" runat="server" onclick="javascript:Calculations();"
                        Checked="true" />
                </div>
            </div>
            <div class="only10px">
            </div>
            <div id="div_booklet_NoOfSignatures" align="left" style="display: none">
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label19" runat="server" Text="Booklet Pages Per Print Sheet" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtPagesPerSignature" SkinID="textPad" runat="server" MaxLength="8"
                            Width="75px" ReadOnly="false"></asp:TextBox>
                        <span id="spn_txtPagesPerSignatureNumber" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label27" runat="server" Text="Print Sheets Per Section" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtNoOfSignatures" SkinID="textPad" runat="server" Text="0" MaxLength="8"
                            Width="75px" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div id="div_PrintLayout" align="left">
                <div class="bglabelnewLarge" style="height: 28px;">
                    <div style="float: left;">
                        <asp:Label ID="Label20" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Print_Layout")%></asp:Label>
                    </div>
                    <div style="float: right;">
                        <a href="javascript://" style="cursor: pointer;" onclick="popup_layout();">
                            <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                    </div>
                </div>
                <div style="float: left;">
                    <div>
                        <div style="float: left; width: 85px;margin-bottom:3px">
                            <asp:CheckBox ID="chkPortrait" Checked="true" onclick="javascript:PrintLayout('portrait',this.id);"
                                Text="Portrait" runat="server" />
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="txtportrait" Width="75px" SkinID="textPad" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblPortraitLength" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                            <asp:HiddenField ID="hdn_PortraitValue" runat="server" Value="0" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div>
                        <div style="float: left; width: 85px">
                            <asp:CheckBox ID="chkLandscape" onclick="javascript:PrintLayout('landscape',this.id);"
                                Text="Landscape " runat="server" />
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="txtlandscape" Width="75px" SkinID="textPad" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblLandscapeLength" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                            <asp:HiddenField ID="hdn_LandscapeValue" runat="server" Value="0" />
                            <input type="hidden" value="0" id="hdnrow_land" name="hdnrow_land" />
                            <input type="hidden" value="0" id="hdncol_land" name="hdncol_land" />
                            <input type="hidden" value="0" id="hdnrow_port" name="hdnrow_port" />
                            <input type="hidden" value="0" id="hdncol_port" name="hdncol_port" />
                            <input type="hidden" value="0" id="hdntype" />
                            <input type="hidden" value="0" id="hdnselected" />
                            <input type="hidden" value="0" id="hdnvertical" />
                            <input type="hidden" value="0" id="hdnhorizontal" />
                            <asp:HiddenField runat="server" ID="hdnProtrait" Value="0" />
                            <asp:HiddenField runat="server" ID="hdnLandscale" Value="0" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>


                    <%-- start --%>

                    <div>
                        <div style="float: left; width: 85px;margin-bottom:3px;">
                            <asp:CheckBox ID="chkManual" onclick="javascript:PrintLayout('manual',this.id);"
                                Text="Manual" runat="server" />
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="txtManual" Width="75px" SkinID="textPad" runat="server"></asp:TextBox>
                            <asp:Label ID="lblManual" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                            <asp:HiddenField ID="hdnManual" runat="server" Value="0" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>


                    <%-- end --%>


                    <div style="float: left;">
                        <span id="spn_Printlayout" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Print_Layout_Should_Not_Be_Zero")%></span>
                    </div>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div align="left">
                <div class="bglabelnewLarge" style="height: 30px;">
                    <div style="float: left;">
                        <asp:Label ID="Label26" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Guillotine")%></asp:Label>
                    </div>
                    <div style="float: right;">
                        <a href="javascript://" style="cursor: pointer;" onclick="GuillotineSelect();return false;">
                            <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                    </div>
                </div>
                <div class="box" style="float: left;">
                    <div align="left" style="overflow: hidden; white-space: nowrap; width: 260px;">
                        <asp:Label ID="lblGuillotine" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                    </div>
                    <div id="div_Trim" align="left" style="margin-left:-2px">
                        <asp:CheckBox ID="chkFirstTrim" runat="server" Checked="true" Text="First Trim" />
                        <asp:CheckBox ID="chkSecondTrim" runat="server" Checked="true" Text="Second Trim" />
                    </div>
                    <asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
                </div>
            </div>
            <div class="only10px">
            </div>
            <div align="left" id="Div_ItemDescn" runat="server" visible="false">
                <div class="bglabelnewLarge" style="float: left;">
                    <asp:Label ID="Label1" runat="server" Text="Update Item Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_Description") %></asp:Label>
                    <a id="img_UpdateDescription" runat="server" href="javascript:void(0);" cssclass="tooltip"
                        title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                        <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                            cssclass="tooltip" title="Untick this box if you want the item description fields not to be overwritten during the rerun process." /></a>
                </div>
                <div class="box" style="float: left;">
                    <div id="div1" align="left">
                        <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="false" />
                    </div>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div align="left" id="Div_Productcatalogue" runat="server" visible="false">
                <div class="bglabelnewLarge" style="float: left;">
                    <asp:Label ID="Label17" runat="server" Text="Product Catalogue" CssClass="normaltext"></asp:Label>
                    <a href="javascript:void(0);" class="tooltip" title="Quantity may be Updated/added">
                        <img alt="" id="Img1" src="../../images/Help-icon.png" runat="server" style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                            class="tooltip" /></a>
                </div>
                <div class="box" style="float: left;">
                    <div id="div3" align="left">
                        <asp:CheckBox ID="chkPoduct1" runat="server" Checked="true" Text="Update Product Info/Price"
                            onclick="javascript:OnChkchanged1();" />
                        <asp:CheckBox ID="chkPoduct2" runat="server" Text="Delete and Recreate" onclick="javascript:OnChkchanged2();" />
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="only10px">
                </div>
                <div class="only10px">
                </div>
                <div class="bglabelEmpty" style="width: 26%">
                </div>
                <div class="box" style="float: left">
                    <div style="float: left; white-space: nowrap;" nowrap="nowrap">
                        <div style="float: left;">
                            <div style="float: left;">
                                <div id="div_btnprev" style="display: block">
                                    <asp:Button ID="btnPrevious" CssClass="button" OnClick="btnPrevious_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_btnprevprocess');"
                                        Text="Previous" runat="server" />
                                </div>
                                <div id="div_btnprevprocess" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div style="float: left;">
                                <div id="div_btnsave" style="display: block">
                                    <asp:Button ID="btnSave" CssClass="button" Text="Finish" runat="server" OnClick="btnSave_OnClick"
                                        OnClientClick="javascript:var a=Pad_Validation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                </div>
                                <div id="div_btnsaveprocess" class="button" style="display: none; height: 12px; width: 32px;">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>
    </div>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move, Resize">
    </telerik:RadWindowManager>
</div>
<%-- Coding Ends --%>
<asp:HiddenField ID="hid_singleData" Value="" runat="server" />
<asp:HiddenField ID="hid_booklet_save" Value="" runat="server" />
<asp:HiddenField ID="hid_width" Value="" runat="server" />
<asp:HiddenField ID="hid_height" Value="" runat="server" />
<asp:HiddenField ID="hid_IsJobCustom" Value="" runat="server" />
<asp:HiddenField ID="hid_IsSheetCustom" Value="" runat="server" />
<asp:HiddenField ID="hdnedit_Default" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPressID" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldGuillotineID" Value="0" runat="server" />
<asp:HiddenField ID="hdn_InvpaperID" runat="server" Value="" />
<asp:HiddenField ID="hdn_invStockBack" runat="server" Value="" />
<asp:HiddenField ID="hdn_invStockReduce" runat="server" Value="" />
<asp:HiddenField ID="hid_3DecimalPaperSize" runat="server" Value="" />

<script>
    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var tabtype = "<%=tabtype %>";
    var modulename = "<%=modulename %>";
    var div_Trim = document.getElementById("div_Trim");
    var PadPrintLayout = "<%=PadPrintLayout %>";
    if (document.getElementById("divhrefQtyMore").style.display == "none") {
        if (modulename == "estimates") {
            document.getElementById("divhrefQtyMore").style.display = "block";
        }
        else {
            document.getElementById("divhrefQtyMore").style.display = "none";
        }
    }
    var estimateType = 'digital';
    var productType = '';

    var print_broker = "div_print_broker";
    var stock_only = "div_stock_only";
    var divOtherCost = "div_Other_Cost";
    var div_price_catalogue = document.getElementById("div_price_catalogue");


    var div_only_digitalsleft = "div_only_digitals_left";
    var div_only_digitalsright = "div_only_digitals_right";
    var div_Product_Type = "div_ProductType";
    var div_Section_Ref = "div_SectionRef";

    var div_Finished_Qty = "div_FinishedQty";
    var div_Booklet_Qty = "div_BookletQty";
    var div_Pads_Qty = "div_PadsQty";
    var div_Qty2to4 = "div_Qty_2to4";

    var div_Booklet_One = "div_Booklet_1";
    var div_Pads_One = "div_Pads_1";
    var div_Print_Layout = "div_PrintLayout";
    var hid_DefaultDigitalPress = document.getElementById("<%=hid_DefaultDigitalPress.ClientID %>");

    //booklet
    var div_BookletFormat = "div_Booklet_Format";
    var div_BookletNoOfPagesInSection = "div_booklet_NoOfPagesInSection";
    var div_BookletNoOfSignatures = "div_booklet_NoOfSignatures";

    //Large Format
    var div_chk_Run_OnQty = 'div_chkRunOnQty';
    var div_Print_Quality_Sector = 'div_PrintQualitySector';
    var div_Ink_Coverage = 'div_InkCoverage';

    //stage 4
    var div_BtnNextSection = "div_btn_nextSection";
    var div_Booklet_Delete = "div_BookletDelete";

    ///summary
    var div_BookletSummary = "div_booklet_summary";
    var div_SingleItemSummary = "div_singleItem_summary";
    var div_PadSummary = "div_pad_summary";
    var div_PrintBrokerSummary = "div_printbroker_summary";
    var div_OtherCostSummary = "div_other_cost_summary";
    var div_WarehouseSummary = "div_warehouse_summary";
    var div_LargeFormatSummary = 'div_largeFormat_summary';
    var div_PriceCatalogueSummary = "div_pricecatalogue_summary";
    var div_pricecatalogue_summary = document.getElementById("div_pricecatalogue_summary");

    ///stock only(warehouse supply)
    var div_StockOnly = "div_stock_only";
    var div_Ware_Next_Button = "div_WarehouseNextButton";

    ///OTHER COST
    divOtherCostbtnNext = "div_OtherCost_btn_Next";
    var ArrayOtherCost = new Array();

    var divSingleBookPadLargeFinalbtn = "div_SingleBookPadLarge_Finalbtn";
    var divOtherTypeFinishButton = "div_OtherType_FinishButton";

    var lblPortraitLength = document.getElementById("<%=lblPortraitLength.ClientID %>");
    var lblLandscapeLength = document.getElementById("<%=lblLandscapeLength.ClientID %>");

    var RequestType = '<%=Request.QueryString["type"]%>';
    var hid_3DecimalPaperSize = document.getElementById("<%=hid_3DecimalPaperSize.ClientID %>");


    var IsWareDirect = false;
    var IsPrintBrokerDirect = false;
    var IsOtherCost = false;

    //*************** WAREHOUSE ************************************
    var WareID1, WareName1, WareType1, UnitPrice1, WareItemID1 = 0, PackedInQty1 = 0;

    //************************ CREATE ITEM ********************************

    ///SiBoPaLaPrevious()

    function ValidatePaper_HeightWidth() {
        var txtsectionheight = document.getElementById("<%=txtsectionheight.ClientID %>");
        var txtsectionwidth = document.getElementById("<%=txtsectionwidth.ClientID %>");
        var txtitemheight = document.getElementById("<%=txtitemheight.ClientID %>");
        var txtitemwidth = document.getElementById("<%=txtitemwidth.ClientID %>");
        var str = document.getElementById("<%=hdn_PaperProperties.ClientID %>");
        var chkGutters = document.getElementById("<%=chkGutters.ClientID %>");
        var ChkPressRestrictions = document.getElementById("<%=ChkPressRestrictions.ClientID %>");
        var str2 = str.value.split('µ');
        var PaperSizeID = str2[0];
        var Height = str2[1];
        var Width = str2[2];

        if (G_CalculateInventorySheet('p', Number(Height), Number(Width)) == 0 && (Height != undefined && Height != null)) {
            alert("Select smaller Print Sheet Size or a larger paper line from Inventory")
            return false;
        }

        return true;
    }

    var txtItemTitle = document.getElementById("<%=txtItemTitle.ClientID %>");
    var ddlEstimateType = document.getElementById("<%=ddlEstimateType.ClientID %>");


    var QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");

    //THIS FUNCTION IS USED FOR UPDATIG THE SUMARY DATA
    ///Load_Data_From_Stage1_To_Stage4(Etype)

    ///CreateItemPrevious(check)
    //************************ CREATE ITEM ENDS ********************************
    var ddlEstimateType = document.getElementById("<%=ddlEstimateType.ClientID %>");
    var ddlProd = document.getElementById("<%=ddlProductType.ClientID %>");
    var hid_DigitalPress = document.getElementById("<%=hid_DigitalPress.ClientID %>");

    function funreqtype() {
        var reqtype = '<%=QueryType %>';
        return reqtype;
    }

    var chkRunOnQty = document.getElementById("<%=chkRunOnQty.ClientID %>");
    var hid_QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");
    var txtQuantity = document.getElementById("<%=txtQuantity.ClientID %>");


    var ddlEsti = document.getElementById("<%=ddlEstimateType.ClientID %>");
    var ddlProd = document.getElementById("<%=ddlProductType.ClientID %>");
    //Please check this before editing 
    ddlEsti.selectedIndex = "0";
    ddlProd.selectedIndex = "0";

    //MAIN OBJECTS      
    var txtItemTitle = document.getElementById("<%=txtItemTitle.ClientID %>");
    var txtQuantity = document.getElementById("<%=txtQuantity.ClientID %>");
    var txtRunOnQty = document.getElementById("<%=txtRunOnQty.ClientID %>");
    var txtQuantity_2 = document.getElementById("<%=txtQuantity_2.ClientID %>");
    var txtQuantity_3 = document.getElementById("<%=txtQuantity_3.ClientID %>");
    var txtQuantity_4 = document.getElementById("<%=txtQuantity_4.ClientID %>");
    var chkRunOnQty = document.getElementById("<%=chkRunOnQty.ClientID %>");
    var hid_QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");

    var txtSectionRef = document.getElementById("<%=txtSectionRef.ClientID %>");
    var ddlPress = document.getElementById("<%=ddlPress.ClientID %>");
    var hdnpaperID = document.getElementById("<%=hdnpaperID.ClientID %>");
    var lblDefaultPaper = document.getElementById("<%=lblDefaultPaper.ClientID %>");
    var lblPaperWeight = document.getElementById("<%=lblPaperWeight.ClientID %>");
    var hdn_PaperProperties = document.getElementById("<%=hdn_PaperProperties.ClientID %>");
    var ChkPriceForWholePack = document.getElementById("<%=ChkPriceForWholePack.ClientID %>");
    var ChkPaperSupplied = document.getElementById("<%=ChkPaperSupplied.ClientID %>");
    var txtSetupSpoilage = document.getElementById("<%=txtSetupSpoilage.ClientID %>");
    var txtRunningSpoilage = document.getElementById("<%=txtRunningSpoilage.ClientID %>");
    var txtNoOfPagesRequired = document.getElementById("<%=txtNoOfPagesRequired.ClientID %>");
    var txtPagesPerSection = document.getElementById("<%=txtPagesPerSection.ClientID %>");
    //Pads
    var txtNoOfLeavesPerPad = document.getElementById("<%=txtNoOfLeavesPerPad.ClientID %>");

    var ddlColors = document.getElementById("<%=ddlColors.ClientID %>");
    var chkDoubleSided = document.getElementById("<%=chkDoubleSided.ClientID %>");
    var ddlColors_2 = document.getElementById("<%=ddlColors_2.ClientID %>");

    //Booklet new changes       
    var txtNoOfPagesInSection = document.getElementById("<%=txtNoOfPagesInSection.ClientID %>");
    var txtPagesPerSignature = document.getElementById("<%=txtPagesPerSignature.ClientID %>");
    var txtNoOfSignatures = document.getElementById("<%=txtNoOfSignatures.ClientID %>");
    var ddlBookletFormat = document.getElementById("<%=ddlBookletFormat.ClientID %>");

    //SIZE
    var hid_ddlPrintSheetSize = document.getElementById("<%=hid_ddlPrintSheetSize.ClientID %>");
    var ddlPrintSheetSize = document.getElementById("<%=ddlPrintSheetSize.ClientID %>");
    var chkPrintSheet = document.getElementById("<%=chkPrintSheet.ClientID %>");
    var txtsectionheight = document.getElementById("<%=txtsectionheight.ClientID %>");
    var txtsectionwidth = document.getElementById("<%=txtsectionwidth.ClientID %>");

    //SIZE
    var ddlJobItemSize = document.getElementById("<%=ddlJobItemSize.ClientID %>");
    var ChkJobFlatCustom = document.getElementById("<%=ChkJobFlatCustom.ClientID %>");
    var txtitemheight = document.getElementById("<%=txtitemheight.ClientID %>");
    var txtitemwidth = document.getElementById("<%=txtitemwidth.ClientID %>");

    var chkGutters = document.getElementById("<%=chkGutters.ClientID %>");
    var txtGutterHorizontal = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
    var txtGutterVertical = document.getElementById("<%=txtGutterVertical.ClientID %>");
    var ChkPressRestrictions = document.getElementById("<%=ChkPressRestrictions.ClientID %>");
    var hid_GuillotineID = document.getElementById("<%=hid_GuillotineID.ClientID %>");
    var lblGuillotine = document.getElementById("<%=lblGuillotine.ClientID %>");
    var chkFirstTrim = document.getElementById("<%=chkFirstTrim.ClientID %>");
    var chkSecondTrim = document.getElementById("<%=chkSecondTrim.ClientID %>");

    //Print Layout  
    var chkPortrait = document.getElementById("<%=chkPortrait.ClientID %>");
    var chkLandscape = document.getElementById("<%=chkLandscape.ClientID %>");
    var txtportrait = document.getElementById("<%=txtportrait.ClientID %>");
    var txtlandscape = document.getElementById("<%=txtlandscape.ClientID %>");
    var hdn_PortraitValue = document.getElementById("<%=hdn_PortraitValue.ClientID %>");
    var hdn_LandscapeValue = document.getElementById("<%=hdn_LandscapeValue.ClientID %>");

    var chkManual = document.getElementById("<%=chkManual.ClientID %>");
    var txtManual = document.getElementById("<%=txtManual.ClientID %>");
    var hdnManual = document.getElementById("<%=hdnManual.ClientID %>");


    var hid_IsSheetCustom = document.getElementById("<%=hid_IsSheetCustom.ClientID %>");
    var hid_IsJobCustom = document.getElementById("<%=hid_IsJobCustom.ClientID %>");

    var hid_IsSheetCustom = document.getElementById("<%=hid_IsSheetCustom.ClientID %>");
    var hid_IsJobCustom = document.getElementById("<%=hid_IsJobCustom.ClientID %>");
    var hdnedit_Default = document.getElementById("<%=hdnedit_Default.ClientID %>");
    
</script>
<%-- CODING PART END--%>
<script>
    function calc(val) {

        var SH = document.getElementById("<%=txtsectionheight.ClientID %>");
        var SW = document.getElementById("<%=txtsectionwidth.ClientID %>");
        var IH = document.getElementById("<%=txtitemheight.ClientID %>");
        var IW = document.getElementById("<%=txtitemwidth.ClientID %>");
        var result_port = document.getElementById("<%=txtportrait.ClientID %>");
        var result_land = document.getElementById("<%=txtlandscape.ClientID %>");
        var HrzGutter = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
        var VtGutter = document.getElementById("<%=txtGutterVertical.ClientID %>");

        var chkGutters = document.getElementById("<%=chkGutters.ClientID %>");
        var chkRestrictions = document.getElementById("<%=ChkPressRestrictions.ClientID %>");
        var chkPortrait = document.getElementById("<%=chkPortrait.ClientID %>");
        var chkLandscape = document.getElementById("<%=chkLandscape.ClientID %>");

        var row_land = document.getElementById("hdnrow_land");
        var col_land = document.getElementById("hdncol_land");
        var row_port = document.getElementById("hdnrow_port");
        var col_port = document.getElementById("hdncol_port");
        var hdntype = document.getElementById("hdntype");
        var hdnselected = document.getElementById("hdnselected");
        var hdnvertical = document.getElementById("hdnvertical");
        var hdnhorizontal = document.getElementById("hdnhorizontal");

        var col;
        var row;
        var A;
        var B;
        var C;
        var D;
        var E;
        var F;
        var ASH;
        var ASW;
        var Result;
        if (val == "land")//if(chkLandscape.checked)
        {

            if ((chkGutters.checked) && (chkRestrictions.checked)) {
                hdnselected.value = "both";
                ASH = Number(SH.value) - (Number(NonHeight) * 2);
                ASW = Number(SW.value) - Number(NonWeight) * 2;
                A = Number(ASH) + Number(VtGutter.value);
                B = Number(A) / (Number(IH.value) + Number(VtGutter.value));
                C = parseInt(B);
                row = C;

                D = Number(ASW) + Number(HrzGutter.value);
                E = Number(D) / (Number(IW.value) + Number(HrzGutter.value));
                F = parseInt(E);
                col = F;

                Result = C * F;
                hdnvertical.value = VtGutter.value;
                hdnhorizontal.value = HrzGutter.value;
            }
            else if (chkGutters.checked) {
                hdnselected.value = "gutters";
                A = Number(SH.value) - Number(VtGutter.value);
                B = A / (Number(IH.value) + Number(VtGutter.value));
                C = parseInt(B)
                row = C;
                D = Number(SW.value) - Number(HrzGutter.value);
                E = D / (Number(IW.value) + Number(HrzGutter.value));
                F = parseInt(E)
                col = F;
                Result = C * F;
                hdnvertical.value = VtGutter.value;
                hdnhorizontal.value = HrzGutter.value;
            }
            else if (chkRestrictions.checked) {
                hdnselected.value = "restriction";
                ASH = Number(SH.value) - (Number(NonHeight) * 2);
                ASW = Number(SW.value) - Number(NonWeight) * 2;
                A = Number(ASH) / Number(IH.value);
                B = Number(ASW) / Number(IW.value);
                row = parseInt(A);
                col = parseInt(B);
                Result = col * row;
                hdnhorizontal.value = "0";
                hdnvertical.value = "0";
            }
            else {

                hdnselected.value = "none";
                A = Number(SH.value) / Number(IH.value);
                B = Number(SW.value) / Number(IW.value);

                C = parseInt(A); //Math.round(col_land)
                D = parseInt(B); //Math.round(row_land)
                row = C;
                col = D;

                Result = col * row;
                hdnhorizontal.value = "0";
                hdnvertical.value = "0";
            }
            row_land.value = row;

            col_land.value = col;

            result_land.value = Result;

        }
        else {

            if ((chkGutters.checked) && (chkRestrictions.checked)) {
                hdnselected.value = "both";
                ASH = Number(SH.value) - (Number(NonHeight) * 2);
                ASW = Number(SW.value) - Number(NonWeight) * 2;
                A = Number(ASW) + Number(HrzGutter.value);
                B = A / (Number(IH.value) + Number(HrzGutter.value));
                C = parseInt(B);
                col = C;
                D = Number(ASH) + Number(VtGutter.value);
                E = Number(D) / (Number(IW.value) + Number(VtGutter.value));
                F = parseInt(E);
                row = F;
                Result = C * F;
                hdnvertical.value = VtGutter.value;
                hdnhorizontal.value = HrzGutter.value;
            }
            else if (chkGutters.checked) {

                hdnselected.value = "gutters";
                A = Number(SW.value) - Number(HrzGutter.value);

                B = A / (Number(IH.value) + Number(HrzGutter.value));
                C = parseInt(B)

                row = C;

                D = Number(SH.value) - Number(VtGutter.value);
                E = D / (Number(IW.value) + Number(VtGutter.value));
                F = parseInt(E)
                col = F;

                Result = C * F;
                hdnvertical.value = VtGutter.value;
                hdnhorizontal.value = HrzGutter.value;


            }
            else if (chkRestrictions.checked) {
                hdnselected.value = "restriction";
                ASH = Number(SH.value) - (Number(NonHeight) * 2);
                ASW = Number(SW.value) - Number(NonWeight) * 2;
                A = Number(ASH) / Number(IW.value);
                B = Number(ASW) / Number(IH.value);
                row = parseInt(A);
                col = parseInt(B);
                Result = row * col;
                hdnhorizontal.value = "0";
                hdnvertical.value = "0";
            }
            else {
                hdnselected.value = "none";
                A = Number(SH.value) / Number(IW.value);
                B = Number(SW.value) / Number(IH.value);
                C = parseInt(A); //Math.round(col_port)
                D = parseInt(B); //Math.round(row_port)
                row = C;
                col = D;
                Result = row * col;
                hdnhorizontal.value = "0";
                hdnvertical.value = "0";
            }
            row_port.value = row;
            col_port.value = col;
            result_port.value = Result;

        }
    }
    // By M.S.Vinay
    var LandscapeLength = 0;
    var PortraitLength = 0;

    var DdlProductType = document.getElementById("<%=ddlProductType.ClientID %>");

    var SH = document.getElementById("<%=txtsectionheight.ClientID %>");
    //alert(SH.value);
    var SW = document.getElementById("<%=txtsectionwidth.ClientID %>");
    //alert(SW.value);
    var IH = document.getElementById("<%=txtitemheight.ClientID %>");
    //alert(IH.value);
    var IW = document.getElementById("<%=txtitemwidth.ClientID %>");
    // alert(IW.value);
    var result_port = document.getElementById("<%=txtportrait.ClientID %>");
    //alert(result_port.value);
    var result_land = document.getElementById("<%=txtlandscape.ClientID %>");
    //alert(result_land.value);
    var HrzGutter = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
    //alert(HrzGutter.value);
    var VtGutter = document.getElementById("<%=txtGutterVertical.ClientID %>");
    //alert(VtGutter.value);

    var chkGutters = document.getElementById("<%=chkGutters.ClientID %>");
    var chkRestrictions = document.getElementById("<%=ChkPressRestrictions.ClientID %>");
    var chkPortrait = document.getElementById("<%=chkPortrait.ClientID %>");
    var chkLandscape = document.getElementById("<%=chkLandscape.ClientID %>");

    var row_land = document.getElementById("hdnrow_land");
    var col_land = document.getElementById("hdncol_land");
    var row_port = document.getElementById("hdnrow_port");
    var col_port = document.getElementById("hdncol_port");
    var hdntype = document.getElementById("hdntype");
    var hdnselected = document.getElementById("hdnselected");
    var hdnvertical = document.getElementById("hdnvertical");
    var hdnhorizontal = document.getElementById("hdnhorizontal");
    var hdn_Protrait = document.getElementById("<%=hdnProtrait.ClientID %>");
    var hdn_Landscale = document.getElementById("<%=hdnLandscale.ClientID %>");


    var col;
    var row;
    var A;
    var B;
    var C;
    var D;
    var E;
    var F;
    var ASH;
    var ASW;
    var NonHeight = 0;
    var NonWeight = 0;
    var Result;

    var txtPagesPerSignature = document.getElementById("<%=txtPagesPerSignature.ClientID %>");
    var txtNoOfPagesInSection = document.getElementById("<%=txtNoOfPagesInSection.ClientID %>");

    var ddlFormat = document.getElementById("<%=ddlBookletFormat.ClientID %>");


    function popup_layout() {

        var SH = document.getElementById("<%=txtsectionheight.ClientID %>");
        var SW = document.getElementById("<%=txtsectionwidth.ClientID %>");
        var IH = document.getElementById("<%=txtitemheight.ClientID %>");
        var IW = document.getElementById("<%=txtitemwidth.ClientID %>");
        var row_land = document.getElementById("hdnrow_land");
        var col_land = document.getElementById("hdncol_land");
        var row_port = document.getElementById("hdnrow_port");
        var col_port = document.getElementById("hdncol_port");
        var hdntype = document.getElementById("hdntype");
        var hdnselected = document.getElementById("hdnselected");
        var hdnvertical = document.getElementById("hdnvertical");
        var hdnhorizontal = document.getElementById("hdnhorizontal");
        var chkLandscape = document.getElementById("<%=chkLandscape.ClientID %>");
        var row;
        var col;
        if (chkLandscape.checked) {
            hdntype.value = "landscape";
            row = row_land.value;
            col = col_land.value;
        }
        else if (chkPortrait.checked) {
            hdntype.value = "portrait";
            row = row_port.value;
            col = col_port.value;

        }else {
            hdntype.value = "manual";
            row = row_port.value;
            col = col_port.value;
        }

        if ((SH.value != "") && (SW.value != "") && (IH.value != "") && (IW.value != "")) {
            if (row == 0 || col == 0) {
                alert('Print Layout should not be zero');
            }
            else {
                window.radopen("<%=nmsCommon.global.sitePath()%>print_layout.aspx?SH=" + SH.value + "&SW=" + SW.value + "&IH=" + IH.value + "&IW=" + IW.value + "&type=" + hdntype.value + "&selected=" + hdnselected.value + "&row=" + row + "&col=" + col + "&vg=" + hdnvertical.value + "&hg=" + hdnhorizontal.value + "&nonHeight=" + NonHeight + "&nonWidth=" + NonWeight, '', '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        else {
            alert('Print Layout should not be zero');
        }
    }

    var hid_singleData = document.getElementById("<%=hid_singleData.ClientID %>");
    var hid_booklet_save = document.getElementById("<%=hid_booklet_save.ClientID %>");
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/pad_item.js"></script>
<script>
    ShowEstimate('digital');
    ProductTypeShow("pads");
    if (modulename != "invoice" && modulename != "jobs" && modulename != "orders") {
        moreQty('more');
    }
    else {
        moreQty('single');
    }

    estimatetype = "digital";
    producttype = "pad";

    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    var modulename = "<%=modulename %>"
    if (modulename == "jobs") {
        hrefQtyMore.style.display = "none";
        hrefQtySingle.style.display = "none";
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";

    }
</script>
<asp:Panel ID="pnlPadEdit" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        TakeValuesFromDB();
    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">
    //this is done on 11/03/11 in job & invoice (it shows multiple qty text boxes which was created in Estimates).

    var QtyNo = "<%=QtyNo %>";
    if (modulename == "invoice" || modulename == "jobs" || modulename == "orders") {

        if (QtyNo == "1") {
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
            document.getElementById("div_qty1").style.display = "block";
        }
        else if (QtyNo == "2") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";

            document.getElementById("div_Addmore").style.display = "block";

        }
        else if (QtyNo == "3") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
            document.getElementById("div_Qty_2to4").style.display = "block";
            document.getElementById("div_qty3").style.display = "block";
            document.getElementById("div_qty12").style.display = "none";
        }
        else if (QtyNo == "4") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_Qty_2to4").style.display = "block";
            document.getElementById("div_qty4").style.display = "block";
            document.getElementById("div_qty12").style.display = "none";
        }
    }

    if (!ChkJobFlatCustom.checked) {
        hdnedit_Default.value = "1";
    }
    if (!chkPrintSheet.checked) {
        hdnedit_Default.value = "1";
    }


    var QueryType = '<%=QueryType %>';
    if (QueryType.toLowerCase() == "edit") {
        if (ddlJobItemSize.value == 0 || hid_IsJobCustom.value == "True") {

            document.getElementById("div_JobItemCustomSize").style.display = "block";
            document.getElementById("div_ddlJobItemSize").style.display = "none";
            ChkJobFlatCustom.checked = true;
        }
        else {
            document.getElementById("div_ddlJobItemSize").style.display = "block";
            document.getElementById("div_JobItemCustomSize").style.display = "none";
            ChkJobFlatCustom.checked = false;
        }
        if (ddlPrintSheetSize.value == 0 || hid_IsSheetCustom.value == "True") {
            document.getElementById("div_ddlPrintSheetSize").style.display = "none";
            document.getElementById("div_PrintSheetCustomSize").style.display = "block";
            chkPrintSheet.checked = true;
        }
        else {
            document.getElementById("div_ddlPrintSheetSize").style.display = "block";
            document.getElementById("div_PrintSheetCustomSize").style.display = "none";
            chkPrintSheet.checked = false;
        }
    }


    function OnChkchanged1() {

        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct1.checked) {
            chkPoduct2.checked = false;
        }
        else {
            chkPoduct1.checked = false;
        }
    }

    function OnChkchanged2() {
        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct2.checked) {
            chkPoduct1.checked = false;
        }
        else {
            chkPoduct2.checked = false;
        }
    }

    function InnventoryPrompt() {
        var hdn_InvpaperID = document.getElementById("<%=hdn_InvpaperID.ClientID %>");
        var InventoryManagement = '<%=InventoryManagement %>';
        var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
        var hdn_invStockBack = document.getElementById("<%=hdn_invStockBack.ClientID %>");
        var ReduceStockType = '<%=ReduceStockType %>';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        var reqtype = funreqtype();
        if (reqtype == 'edit') {
            if (InventoryManagement.toString().toLowerCase() == "im") {                     // Still to work on this case.
                if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
                    if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p" && (hdn_InvpaperID.value != hdnpaperID.value)) {
                        if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                            hdn_invStockBack.value = "yes";
                        }
                        else { hdn_invStockBack.value = "no"; }
                    }
                }
            }
        }
        if (reqtype == 'add') {
            if (InventoryManagement.toString().toLowerCase() == "im") {                     // Still to work on this case.
                if (modulename.toLowerCase() == "invoice") {
                    if (ReduceStockType.toString().toLowerCase() != "e" && ReduceStockType.toString().toLowerCase() != "i") {
                        //                        if (window.confirm('Do you want to Reduce the inventory stock?')) {
                        //                            hdn_invStockReduce.value = "yes";
                        //                        }
                        //                        else { hdn_invStockBack.value = "no"; }
                        ShowConfirmationMessage();
                        SetRadWindow('divrad', 'divBackGroundNew', '200');
                        document.getElementById('divBackGroundNew').style.display = 'block';
                        document.getElementById('divBackGroundNew').style.zIndex = 1;
                        return false;
                    }
                }
            }
        }
        if (InventoryManagement.toString().toLowerCase() != "im" || (InventoryManagement.toString().toLowerCase() == "im" && modulename.toLowerCase() != "invoice")
        || (reqtype == 'edit' && modulename.toLowerCase() == "invoice")) {
            return true;
        }
    }
    function ShowConfirmationMessage() {
        var id = document.getElementById('div_AlertPopup');
        var strImagepath = '<%= strImagepath %>';
        var str = "<table id='tbl_Popup'  cellpadding='0' cellspacing='0' width='35%' height='82%'>";
        str += "<tr>";
        str += "<td colspan='2' class='popup-top-leftcorner'></td><td class='popup-top-middlebg'><div  align='left' id='div_invoice_Popup' class=Label-PopupHeading style='float: right; padding-top: 6px; padding-right: 7px;'><div class='CancelButtonDiv2'><img src='" + strImagepath + "IMAGES/deleteicon3.png' title='Cancel' OnClick='javascript:CloseDiv_Popup_InventoryAlert();return false;'/></div></div></td><td colspan='2' class='popup-top-rightcorner'></td></tr>";
        str += "<tr>";
        str += "<td class='popup-middle-leftcorner'></td><td style='width: 15px; background-color: #ffffff'></td>";

        str += "<td class='popup-middlebg' align='center' valign='top'><table cellpadding='2' cellspacing='2' border='0' width='100%'><tr><td valign='top'><div id='div_Popup_Invoice'><div id='div_rdb_Popup_Invoice' style='float: left; padding-bottom: 7px;'><span style='font-weight: bold;'><label id='lbltxt_Popup' style='width:310px;margin-left:10px;margin-top:10px' Text=''> Do you want to reduce inventory stock ? </label></span></div><div style='clear: both'></div><div style='padding-top: 5px; float: left; padding-left: 3.2%; margin-left:80px;'><input type='button' id='btn_Yes' onclick=javascript:called_reducestock('yes'); return false; class='button' style='width:50px;' value='Yes'/></div><div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='button' id='btn_No' style='width:50px;' onclick=javascript:called_reducestock('no'); return false; class='button' value='No'/></div></div></td></tr></table></td>";
        str += "<td style='width: 10px; background-color: #ffffff'></td><td align='right' class='popup-middle-rightcorner'></td>";
        str += "</tr>";
        str += "<tr><td colspan='2' class='popup-bottom-leftcorner'></td><td class='popup-bottom-middlebg'></td><td colspan='2' class='popup-bottom-rightcorner'></td>";
        str += "</tr>";
        str += "</table>";
        id.innerHTML = str;
        id.style.display = 'block';
    }
    function CloseDiv_Popup_InventoryAlert() {
        document.getElementById('div_AlertPopup').style.display = "none"
        document.getElementById('divBackGroundNew').style.display = "none";
    }
    function called_reducestock(val) {

        document.getElementById('div_btnsave').style.display = 'none';
        document.getElementById('div_btnsaveprocess').style.display = 'block';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        hdn_invStockReduce.value = val;
        document.getElementById('div_AlertPopup').style.display = "none"
        document.getElementById('divBackGroundNew').style.display = "none";
        __doPostBack('ctl00$ContentPlaceHolder1$UCPadItem$btnSave', '');
    }
</script>
