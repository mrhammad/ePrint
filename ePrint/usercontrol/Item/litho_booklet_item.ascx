<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="litho_booklet_item.ascx.cs" Inherits="ePrint.usercontrol.Item.litho_booklet_item" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/item/calculations.js?VN='<%=VersionNumber%>'"
    language="javascript"></script>
<script type="text/javascript">
    Sys.Browser.WebKit = {};
    if (navigator.userAgent.indexOf('WebKit/') > -1) {
        Sys.Browser.agent = Sys.Browser.WebKit;
        Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
        Sys.Browser.name = 'WebKit';
    }

    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<script type="text/javascript">

    setLoadingPositionOfDivMove(div_Load);
</script>
<script type="text/javascript" language="javascript">
    var Delete_Confirmation = '<%=objLanguage.GetLanguageConversion("Are_You_Sure_You_Want_To_Delete") %>';
    var Booklet_PrintLayout_Format_Validation = '<%=objLanguage.GetLanguageConversion("Booklet_PrintLayout_Format_Validation") %>';
</script>

<script type="text/javascript">
    $(document).ready(function () {
        single_side_selection();
    });
</script>
<div id="divMainContent">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_AlertPopup" style="display: none; position: absolute; width: 1100px; left: 500px; z-index: 10;">
    </div>
    <div id="content">
        <%--   <div class="borderWithoutTop" style="padding: 5px;">--%>
        <%-- LEFT SIDE --%>
        <div style="float: left; width: 50%; border: solid 0px red;">
            <div align="left" style="display: block;">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label10" runat="server" Text="Item Title" CssClass="normaltext"></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div class="box" style="float: left;">
                    <asp:TextBox ID="txtItemTitle" SkinID="textPad" Width="260px" runat="server" MaxLength="70"
                        onblur="CallonBlur(this.value,'spn_txtItemTitle');"></asp:TextBox>
                </div>
                <div>
                    <span id="spn_txtItemTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 3px;">
                        <%=objLanguage.GetLanguageConversion("Please_Enter_Item_Title")%></span>
                </div>
            </div>
            <div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div id="div_only_digitals_left" align="left">
                <div align="left">
                    <div class="bglabelnewLarge" style="height: 38px; border: 0px solid blue">
                        <div id="div_FinishedQty" style="float: left; border: 0px solid;">
                        </div>
                        <div id="div_BookletQty" style="float: left">
                            <%=objLanguage.GetLanguageConversion("Booklet_Quantity")%>
                        </div>
                        <div id="div_PadsQty" style="display: none; float: left;">
                            <asp:Label ID="Label8" runat="server" Text="Enter Pad Quantity" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div id="divhrefQtyMore" style="display: none; float: right; border: 0px solid red; vertical-align: top">
                            <asp:HiddenField ID="hid_QtyType" Value="S" runat="server" />
                            <asp:HiddenField ID="hid_Q1" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q2" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q3" Value="0" runat="server" />
                            <asp:HiddenField ID="hid_Q4" Value="0" runat="server" />
                        </div>
                    </div>
                    <div style="float: left; width: 1px; border: 0px solid">
                        &nbsp;
                    </div>
                    <div style="float: left; width: 50%; border: 0px solid" id="div_qty12">
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
                                        runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>

                    <div style="float: left; width: 50%; padding-top: 2px;">
                        <div id="div_Qty_2to4" style="display: none; border: 0px solid; float: left; width: 260px;">
                            <div align="left">
                                <div id="div_qty3" class="box" style="float: left; width: 120px; border: 0px solid">
                                    <%=objLanguage.GetLanguageConversion("Qty3")%>
                                    <asp:TextBox ID="txtQuantity_3" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                        onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
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
                </div>
                <div class="onlyEmpty">
                </div>
                <div style="border: 0px solid">
                    <div style="float: left; border: 0px solid blue; margin-left: 28%; margin-top: -3px">
                        <span id="spn_txtQuantity" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: -2px">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span>
                    </div>
                </div>

                <div class="onlyEmpty">
                </div>
                <div id="div_SectionRef" style="display: block;">
                    <div class="onlyEmpty">
                    </div>
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label5" runat="server" Text="Section Reference" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSectionRef" SkinID="textPad" runat="server" MaxLength="100" onblur="CallonBlur(this.value,'spn_txtSectionRef');">Section 1</asp:TextBox>
                    </div>
                    <div>
                        <span id="spn_txtSectionRef" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Section_Reference")%></span>

                    </div>
                </div>
                <div align="left">
                    <div class="onlyEmpty">
                    </div>
                    <div class="bglabelnewLarge" style="float: left">
                        <asp:Label ID="Label9" runat="server" Text="Assigned Press" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box" style="f<loat: left;">
                        <asp:UpdatePanel ID="updatepresschangeid" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlPress" CssClass="normaltext" Width="260px" onchange="javascript:onchange_press(this.value);"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:LinkButton ID="lnk_ddlPress_OnChange" runat="server" OnClick="ddlPress_OnChange"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:HiddenField ID="hid_PressID" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_PressChange" runat="server" Value="no" />
                        <asp:HiddenField ID="hid_SessionPressChange" runat="server" Value="no" />
                        <asp:HiddenField ID="hid_SectionCount" runat="server" Value="1" />
                        <asp:HiddenField ID="hid_PresntSection" runat="server" Value="1" />

                        <asp:HiddenField ID="hid_DigitalPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_LithoPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_LithoPress_all" runat="server" Value="" />
                        <asp:HiddenField ID="hid_LargeFormatPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_DefaultDigitalPress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_DefaultLargePress" runat="server" Value="" />
                        <asp:HiddenField ID="hid_IsJobCustom" Value="" runat="server" />
                        <asp:HiddenField ID="hid_IsSheetCustom" Value="" runat="server" />
                        <asp:HiddenField ID="hdnedit_Default" Value="0" runat="server" />
                        <asp:HiddenField ID="hid_isPressPerfect" Value="0" runat="server" />
                        <script>
                            var CompanyID = "<%=CompanyID%>";
                            var strSitepath = "<%=strSitepath %>";
                        </script>
                    </div>
                </div>
                <div style="margin-top: 19px">
                    <span id="spn_ddlPress" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 3px">
                        <%=objLanguage.GetLanguageConversion("Please_Select_Press")%></span>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <div style="float: left;">
                            <asp:Label ID="Label12" runat="server" Text="Paper (Stock)" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div style="float: right;">
                            <a href="#" onclick="javascript:return OpenPaperPopUp('paper');">
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
                                <%=objLanguage.GetLanguageConversion("Please_select_Default_Paper")%></span>
                        </div>
                        <div class="onlyEmpty">
                            <asp:CheckBox ID="ChkPriceForWholePack" Text="Price for Whole Pack" onclick="javascript:checkchanged();"
                                runat="server" />
                        </div>
                        <div>
                            <asp:CheckBox ID="ChkPaperSupplied" Text="Paper Supplied" runat="server" onclick="javascript:checkchanged1();" />
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label13" runat="server" Text="Set up Spoilage" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSetupSpoilage" SkinID="textPad" Width="75px" runat="server" MaxLength="20"></asp:TextBox>&nbsp;
                        <span id="spnPaperType" style="font-size: 9px;">
                            <%=objLanguage.GetLanguageConversion("Sheets")%></span>
                        <div>
                            <span id="spn_txtSetupSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Setup_Spoilage")%></span>
                            <span id="spn_txtSetupSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label14" runat="server" Text="Running Spoilage" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtRunningSpoilage" SkinID="textPad" Width="75px" runat="server"
                            MaxLength="20"></asp:TextBox>
                        <span id="Span1" style="font-size: 9px;">&nbsp;%</span>
                        <div>
                            <span id="spn_txtRunningSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Runn_Spoilage")%></span>
                            <span id="spn_txtRunningSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <%--    THE BELOW 2 TEXT BOX ARE NOT USING  --%>
                <div style="display: none;">
                    <div id="div_Booklet_1" align="left">
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label15" runat="server" Text="No. of Pages Required" CssClass="normaltext"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtNoOfPagesRequired" SkinID="textPad" runat="server" MaxLength="8"></asp:TextBox>
                                <span id="spn_txtNoOfPagesRequired" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_No_of_Pages")%></span><span id="spn_txtNoOfPagesRequired_number"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value")%></span>
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
                                        id="spn_txtPagesPerSection_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value")%></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left" style="display: none">
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
                <div align="left">
                    <div class="bglabelnewLarge">
                        <%=objLanguage.GetLanguageConversion("No_Of_Sides_Printed")%>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlNoOfSide" onchange="show_work(this.value); single_side_selection();" runat="server"
                            Width="75px" SkinID="onlyDDL">
                            <asp:ListItem Selected="False">Single</asp:ListItem>
                            <asp:ListItem Selected="True">Double</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <div style="float: left">
                            <asp:Label ID="Label1" runat="server" Text="Side1 Colour" CssClass="normaltext"></asp:Label>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/plus.gif" OnClientClick="javascript:popup_ink('side1');return false;" />
                        </div>
                    </div>
                    <div class="box" style="width: 169px; border: 0px solid">
                        <div align="left">
                            <div style="float: left; padding-right: 5px;">
                                <span id="Span2" class="normalText" style="display: none;">
                                    <%=objLanguage.GetLanguageConversion("Side1")%></span>
                            </div>
                            <div style="float: left;">
                                <asp:DropDownList ID="ddlSide1Color" onchange="side1_on_chnage(this.value)" runat="server"
                                    Width="75px" SkinID="onlyDDL">
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
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="75px" SkinID="onlyDDL"
                                    Style="display: none;">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div align="left" id="div1" style="display: none;">
                            <div style="float: left;">
                                <span id="Span3" class="normalText" style="display: block;">
                                    <%=objLanguage.GetLanguageConversion("Side2")%></span>
                            </div>
                            <div style="float: left; padding-left: 5px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="120px" SkinID="onlyDDL">
                                    <asp:ListItem Text="Colour" Value="color"></asp:ListItem>
                                    <asp:ListItem Text="Black & White" Value="black"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <span id="Span4" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Colours")%></span>
                    </div>
                    <div style="float: left; padding-top: 3px; display: none;">
                        &nbsp;<asp:CheckBox ID="CheckBox1" onclick="show_work(this.checked);" Text="Double Sided"
                            runat="server" />
                    </div>
                </div>
                <div align="left" id="div_side2_colour" style="display: block">
                    <div class="bglabelnewLarge">
                        <div style="float: left">
                            <asp:Label ID="Label2" runat="server" Text="Side2 Colour" CssClass="normaltext"></asp:Label>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/plus.gif" OnClientClick="javascript:popup_ink('side2');return false;" />
                        </div>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlSide2Color" onchange="side2_on_chnage(this.value)" runat="server"
                            Width="75px" SkinID="onlyDDL">
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
                <div class="onlyEmpty">
                </div>
                <div align="left" id="div_work" style="display: none;">
                    <div class="bglabelnewLarge" style="background-color: White;">
                    </div>
                    <div align="left">
                        <div style="float: left">
                            <asp:CheckBox ID="chkSheetWork" onclick="javascript:WorkTick('sheetwork',this.id);Calculations();"
                                Text="Sheet Work" runat="server" />
                        </div>
                        <div id="Div_PerfectChk" style="float: left; display: none;">
                            <asp:CheckBox ID="chkPerfecting" onclick="javascript:WorkTick('perfect',this.id);Calculations();"
                                Text="Perfecting" runat="server" />
                        </div>
                        <div style="float: left">
                            <asp:CheckBox ID="chkTurn" onclick="javascript:WorkTick('turn',this.id);Calculations(); "
                                Text="Work 'n' Turn" runat="server" />
                        </div>
                        <div style="float: left">
                            <asp:CheckBox ID="chkTumble" onclick="javascript:WorkTick('tumble',this.id);Calculations();"
                                Text="Work 'n' Tumble" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <div style="float: left;">
                            <%=objLanguage.GetLanguageConversion("Plate")%>
                            <span style="color: red">*</span>
                        </div>
                        <div style="float: right;">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/plus.gif" OnClientClick="javascript:return MoreStock('plates');" />
                        </div>
                    </div>
                    <div class="box" style="overflow: hidden; white-space: nowrap; width: 175px;">
                        <asp:Label ID="lblDefaultPlates" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                        <span id="spn_lblDefaultPlates" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Plate")%></span>
                        <asp:HiddenField ID="hdnplateID" runat="server" Value="" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <%=objLanguage.GetLanguageConversion("No_Of_Plates")%>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlPlates" runat="server" SkinID="onlyDDL" Style="display: none">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtNoOfPlates" runat="server" SkinID="textPad" Width="75px" MaxLength="8"
                            onkeyup="javascript:ToInteger(this,this.value);">0</asp:TextBox>
                    </div>
                </div>
                <div align="left" id="divMakeReady" style="display: none">
                    <div class="bglabelnewLarge">
                        <%=objLanguage.GetLanguageConversion("No_of_Make_Ready")%>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlMakeReady" runat="server" SkinID="onlyDDL" Style="display: none">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtNoOfMakeReady" runat="server" SkinID="textPad" Width="75px" MaxLength="8"
                            onkeyup="javascript:ToInteger(this,this.value);">0</asp:TextBox>
                    </div>
                </div>
                <div align="left" id="divWashUp" style="display: none">
                    <div class="bglabelnewLarge">
                        <%=objLanguage.GetLanguageConversion("No_Of_Washup")%>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlWashUp" runat="server" SkinID="onlyDDL">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <%-- RIGHT SIDE--%>
        <div id="div_only_digitals_right" style="float: left; width: 49%; border: solid 0px green;">
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="lblBookletType" runat="server" Text="Booklet Type" CssClass="normaltext"></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div class="box">
                    <div align="left">
                        <asp:DropDownList ID="ddlBookletType" SkinID="onlyDDL" runat="server" onchange="javascript:SetPerfectbound_vs_Saddlestiched();Calculations();CalculateBookletSection();changetext(); single_side_selection();">
                            <asp:ListItem Value="saddlestiched">Saddle Stiched</asp:ListItem>
                            <asp:ListItem Value="perfectbound">Perfect Bound</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="div_booklet_NoOfPagesInSection" align="left">
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label18" runat="server" Text="No. of pages in this section" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <div align="left">
                            <asp:TextBox ID="txtNoOfPagesInSection" SkinID="textPad" runat="server" MaxLength="8"
                                Width="75px" onblur="javascript:Calculations();CalculateBookletSection();">4</asp:TextBox><%--onblur="javascript:return CalculateBookletSection();"--%>
                        </div>
                        <div align="left">
                            <span id="spn_txtNoOfPagesInSection" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Number_Of_Pages")%></span><span
                                    id="spn_txtNoOfPagesInSection_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span><span
                                        id="spn_txtNoOfPagesInSection_divide" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left">
                <%--SHEET SIZE--%>
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label22" runat="server" Text="Print Sheet Size" CssClass="normaltext"></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div style="float: left; width: 216px;" nowrap="nowrap">
                    <div id="div_ddlPrintSheetSize" class="box" style="width: 206px;">
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
                                    Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font><span id="spn_sheet_width" class="normaltext" style="font-size: 9px;">
                                    <%=objLanguage.GetLanguageConversion("Width")%></span>&nbsp;<asp:TextBox ID="txtsectionwidth"
                                        Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font>
                        </div>
                    </div>
                </div>
                <div style="float: left;">
                    <div id="div_chkPrintSheet" style="float: left; padding-top: 2px; margin-left: 20px;">
                        <asp:CheckBox ID="chkPrintSheet" onclick="javascript:PrintSheetCustom(this.id);Calculations();ItemSize_AssignToSummary();"
                            Text="Custom" runat="server" />
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label23" runat="server" Text="Finished Booklet Size" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Finished_Booklet_Size")%></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div style="float: left; width: 216px;" nowrap="nowrap">
                    <div id="div_ddlJobItemSize" class="box" style="float: left; width: 206px">
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
                                    Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font><span class="normaltext" style="font-size: 9px;">
                                    <%=objLanguage.GetLanguageConversion("Width")%></span>&nbsp;<asp:TextBox ID="txtitemwidth"
                                        Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'></asp:TextBox>
                            <font style="font-size: 9px;">
                                <%=PaperMeasure %></font>
                        </div>
                    </div>
                </div>
                <div style="float: left; padding-top: 2px; margin-left: 20px;">
                    <asp:CheckBox ID="ChkJobFlatCustom" onclick="javascript:JobItemCustom(this.id);Calculations();ItemSize_AssignToSummary();"
                        Text="Custom" runat="server" />
                </div>
            </div>
            <div id="div_Booklet_Format" align="left">
                <div class="bglabelnewLarge">
                    <span class="normalText">
                        <asp:Label ID="lblbookletformat" runat="server"><%=objLanguage.GetLanguageConversion("Finished_Booklet_Format")%></asp:Label></span>
                </div>
                <div class="box" style="float: left; width: auto">
                    <asp:DropDownList ID="ddlBookletFormat" SkinID="onlyDDL" runat="server" onchange="javascript:Calculations();">
                        <asp:ListItem Value="P">Portrait</asp:ListItem>
                        <asp:ListItem Value="L">Landscape</asp:ListItem>
                    </asp:DropDownList>
                    <div>
                        <span id="spn_Printlayout" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Print_Layout_Should_Not_Be_Zero")%></span>
                    </div>
                </div>
            </div>
            <div id="div_Booklet_itemSize" align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Flat_Booklet_Item_Size")%></asp:Label>
                </div>
                <div id="div_Flatbookletitemsize" style="display: block; float: left; width: 235px"
                    class="box">
                    <span class="normaltext" style="font-size: 9px;">
                        <%=objLanguage.GetLanguageConversion("Height")%></span> &nbsp;<asp:TextBox ID="txtFlatbookletitemsizeHeight"
                            Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'
                            onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font><span class="normaltext" style="font-size: 9px;">
                            <%=objLanguage.GetLanguageConversion("Width")%></span>&nbsp;<asp:TextBox ID="txtFlatbookletitemsizeWidth"
                                Width="52px" SkinID="textPad" runat="server" MaxLength="20" onfocus='this.select();'
                                onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font>
                </div>

                <div class="box">
                    <span id="spnFlatbookletitemsize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                        <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span><span
                            id="Span6" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Include_Gutters")%></span>
                </div>
            </div>
            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label24" runat="server" Text="Include Gutters" CssClass="normaltext"></asp:Label>
                </div>
                <div id="div_GuttersCustomSize" style="display: none; float: left; width: 100%;"
                    class="box">
                    <span class="normaltext" style="font-size: 9px; padding-right: 4px">
                        <%=objLanguage.GetLanguageConversion("Horiz")%></span> &nbsp;<asp:TextBox ID="txtGutterHorizontal"
                            Width="52px" SkinID="textPad" runat="server" MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font><span class="normaltext" style="font-size: 9px; padding-right: 3px">
                            <%=objLanguage.GetLanguageConversion("Vert")%></span>&nbsp;<asp:TextBox ID="txtGutterVertical"
                                Width="52px" SkinID="textPad" runat="server" MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                    <font style="font-size: 9px;">
                        <%=PaperMeasure %></font>
                </div>
                <div style="float: left; padding: 2px 0px 0px 0px; border: 0px solid red; clear: right">
                    <asp:CheckBox ID="chkGutters" onclick="javascript:GuttersCustom(this.id);Calculations();setbooklet_format();setwidth();"
                        runat="server" />
                </div>
                <div class="box">
                    <span id="spn_txtGutterHorizontal_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                        <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span><span
                            id="spn_txtGutterHorizontal" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Include_Gutters")%></span>
                </div>
            </div>

            <div align="left">
                <div class="bglabelnewLarge">
                    <asp:Label ID="Label25" runat="server" Text="Apply Press Restrictions" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box" style="padding: 2px 0px 0px 1px;">
                    <asp:CheckBox ID="ChkPressRestrictions" runat="server" onclick="javascript:Calculations();setbooklet_format();"
                        Checked="true" />
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div id="div_PrintLayout" align="left" style="display: block;">

                <div class="bglabelnewLarge" style="height: 30px;">
                    <table width="100%" style="vertical-align: top;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <asp:Label ID="Label20" runat="server" Text="Print Layout Item Booklet Flat Size"
                                        CssClass="normaltext"></asp:Label>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="div_plusimg" style="float: right; padding-left: 1px">

                                    <a href="#" style="cursor: pointer;" onclick="javascript:popup_layout();">
                                        <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left;">
                    <div>
                        <div style="float: left; width: 85px; margin-bottom: 3px; margin-left: -1px;">
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
                        <div style="float: left; width: 85px; margin-left: -1px;">
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
                            <asp:HiddenField ID="hid_FinalInkSave1" Value="" runat="server" />
                            <asp:HiddenField ID="hid_FinalInkSave2" Value="" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>

                    <%-- start --%>

                    <div>
                        <div style="float: left; width: 85px; margin-bottom: 3px;">
                            <asp:CheckBox ID="chkManual" onclick="javascript:PrintLayout('manual',this.id);"
                                Text="Manual" runat="server" />
                        </div>
                        <div style="float: left;">
                            <asp:TextBox ID="txtManual" Width="75px" SkinID="textPad" runat="server" onblur="CalculateManual();"></asp:TextBox>
                            <asp:Label ID="lblManual" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                            <asp:HiddenField ID="hdnManual" runat="server" Value="0" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>


                    <%-- end --%>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div id="div_booklet_NoOfSignatures" align="left">
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label19" runat="server" Text="Booklet Pages Per Print Sheet" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtPagesPerSignature" onblur="javascript:CalculateBookletSection();"
                            SkinID="textPad" runat="server" MaxLength="8" Width="75px" ReadOnly="false"></asp:TextBox>
                        <span id="spn_txtPagesPerSignatureNumber" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLarge">
                        <asp:Label ID="Label27" runat="server" Text="Print Sheets Per Section" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box" style="width: 80px">
                        <asp:TextBox ID="txtNoOfSignatures" SkinID="textPad" runat="server" Text="0" MaxLength="8"
                            Width="75px" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div style="float: left;">
                        <div style="float: left; padding-top: 2px;">
                            <asp:CheckBox ID="chkIsSilling" onclick="javascript:Calculations();" Text="Round up to use whole sheets"
                                runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left">
                <div class="bglabelnewLarge" style="height: 30px;">
                    <div style="float: left;">
                        <asp:Label ID="Label26" runat="server" Text="Guillotine" CssClass="normaltext"></asp:Label>
                    </div>
                    <div style="float: right;">
                        <a href="#" style="cursor: pointer;" onclick="javascript:GuillotineSelect();return false;">
                            <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                    </div>
                </div>
                <div class="box" style="float: left;">
                    <div align="left" style="overflow: hidden; white-space: nowrap; width: 260px;">
                        <asp:Label ID="lblGuillotine" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                    </div>
                    <div id="div_Trim" align="left" style="display: none">
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
                    <asp:Label ID="Label3" runat="server" Text="Update Item Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_Description")%></asp:Label>
                    <a id="img_Update_Descriptipn" runat="server" href="javascript:void(0);" cssclass="tooltip"
                        title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                        <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                            cssclass="tooltip" title="Untick this box if you want the item description fields not to be overwritten during the rerun process." /></a>
                </div>
                <div class="box" style="float: left;">
                    <div id="div2" align="left">
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
            <div class="onlyEmpty">
            </div>
            <div align="left" style="border: 0px solid">
                <div class="only10px">
                </div>
                <div class="only10px">
                </div>
                <div class="onlyEmpty">
                </div>
                <div class="bglabelEmpty" style="width: 26%;">
                </div>
                <div class="box" style="float: left; width: 70%">
                    <div style="white-space: nowrap; float: left" nowrap="nowrap">
                        <div align="left" style="white-space: nowrap; clear: both" nowrap="nowrap">
                            <div style="float: left;">
                                <div style="float: left;" runat="server" id="divprevious">
                                    <div style="float: left;">
                                        <div id="div_btnstageprev">
                                            <asp:Button ID="btnStage2_Previous" CssClass="button" OnClick="btnPrevious_OnClick"
                                                OnClientClick="javascript:loadingimage(this.id,'div_btnstageprevprocess');" Text="Previous"
                                                runat="server" />
                                        </div>
                                        <div id="div_btnstageprevprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                </div>
                                <div id="div_BookletDelete" style="float: left;">
                                    <div style="float: left;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Button14" CssClass="button" Text="New Section" OnClientClick="javascript:var a=MoveNextSection();if(a)NewSection();return false;"
                                                    Width="100px" runat="server" />
                                                <asp:LinkButton ID="lnkNewSection" runat="server" OnClick="onclick_lnkNewSection"></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <asp:UpdatePanel ID="UpBookletDelete" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Button16" CssClass="button" Text="Delete" OnClientClick="javascript:return SectionDelete();"
                                                    OnClick="btn_Delete" Width="55px" runat="server" />
                                                <asp:HiddenField ID="hid_DeletedID" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                </div>
                                <div style="float: left;">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btnSave" CssClass="button" Text="Finish" OnClick="btnSave_OnClick"
                                            OnClientClick="javascript:var a=Booklet_Click_Next();if(a)loadingimage(this.id,'div_tbnsaveprocess');return a;"
                                            runat="server" />
                                    </div>
                                    <div id="div_tbnsaveprocess" class="button" style="display: none; width: 32px; height: 14px;">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">

                            <div style="float: left;" nowrap="nowrap">
                                <div id="div_btn_booklet_sections" style="white-space: nowrap;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
<%-- Coding Ends --%>
<asp:HiddenField ID="hid_singleData" Value="" runat="server" />
<asp:HiddenField ID="hid_booklet_save" Value="" runat="server" />
<asp:HiddenField ID="hid_makeready" Value="" runat="server" />
<%--this value is used in editcase if makeready check then only that dropdown should visible--%>
<asp:HiddenField ID="hid_washup" Value="" runat="server" />
<%--this value is used in editcase if washup check then only that dropdown should visible--%>
<asp:HiddenField ID="hid_value" Value="1" runat="server" />
<asp:HiddenField ID="hdn_InkType" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPressID" Value="" runat="server" />
<asp:HiddenField ID="hdnOldPaperID" Value="" runat="server" />
<asp:HiddenField ID="hdnOldGuillotineID" Value="" runat="server" />
<asp:HiddenField ID="hdn_invStockReduce" runat="server" Value="" />
<asp:HiddenField ID="hdn_IsPaperUnitPriceLocked" Value="" runat="server" />
<asp:HiddenField ID="hid_3DecimalPaperSize" runat="server" Value="" />

<script>
    var chkSheetSize = document.getElementById("<%=chkPrintSheet.ClientID%>");
    var chkJobSize = document.getElementById("<%=ChkJobFlatCustom.ClientID%>");
    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var QtyNo = "<%=QtyNo %>";
    var dpaperhw = "<%=dpaperhw %>";

    var QueryType = "<%=QueryType%>";
    var tabtype = "<%=tabtype %>";
    var modulename = "<%=modulename %>";

    var div_Trim = document.getElementById("div_Trim");
    var hid_SectionCount = document.getElementById("<%=hid_SectionCount.ClientID %>");
    var hid_PresntSection = document.getElementById("<%=hid_PresntSection.ClientID %>");


    var hdn_InkType = document.getElementById("<%=hdn_InkType.ClientID%>");
    if (document.getElementById("divhrefQtyMore").style.display == "none") {
        if (modulename == "estimates") {
            document.getElementById("divhrefQtyMore").style.display = "block";
        }
        else {
            document.getElementById("divhrefQtyMore").style.display = "none";
        }
    }
    var estimateType = '';
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
    var div_Pads_Qty = "div_PadsQty";
    var div_Qty2to4 = "div_Qty_2to4";

    var div_Booklet_One = "div_Booklet_1";
    var div_Pads_One = "div_Pads_1";
    var div_Print_Layout = "div_PrintLayout";
    var hid_DefaultDigitalPress = document.getElementById("<%=hid_DefaultDigitalPress.ClientID %>");

    //booklet
    var div_BookletFormat = "div_Booklet_Format";
    var div_BookletNoOfPagesInSection = "div_booklet_NoOfPagesInSection";

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

    var ArrayPressID = new Array();

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

        if (G_CalculateInventorySheet('k', Number(Height), Number(Width)) == 0 && (Height != undefined && Height != null)) {
            alert('<%=objLanguage.GetLanguageConversion("Select_Smaller_Print_Sheet_Size_Or_Larger_Paper_Line_From_Inventory") %>');
            return false;
        }
        return true;

    }

    var txtItemTitle = document.getElementById("<%=txtItemTitle.ClientID %>");


    var QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");

    //THIS FUNCTION IS USED FOR UPDATIG THE SUMARY DATA
    ///Load_Data_From_Stage1_To_Stage4(Etype)

    ///CreateItemPrevious(check)
    //************************ CREATE ITEM ENDS ********************************

    var hid_DigitalPress = document.getElementById("<%=hid_DigitalPress.ClientID %>");
    var hid_LithoPress = document.getElementById("<%=hid_LithoPress.ClientID %>");
    var hid_LithoPress_all = document.getElementById("<%=hid_LithoPress_all.ClientID %>");
    function funreqtype() {
        var reqtype = '<%=QueryType %>';
        return reqtype;
    }

    var chkRunOnQty = document.getElementById("<%=chkRunOnQty.ClientID %>");
    var hid_QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");
    var txtQuantity = document.getElementById("<%=txtQuantity.ClientID %>");

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

    var txtNoOfPlates = document.getElementById("<%=txtNoOfPlates.ClientID %>");
    var txtNoOfMakeReady = document.getElementById("<%=txtNoOfMakeReady.ClientID %>");

    var ddlColors = document.getElementById("<%=ddlColors.ClientID %>");
    var chkDoubleSided = document.getElementById("<%=chkDoubleSided.ClientID %>");
    var ddlColors_2 = document.getElementById("<%=ddlColors_2.ClientID %>");

    //Booklet new changes       
    var ddlBookletType = document.getElementById("<%=ddlBookletType.ClientID %>");
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
    var lblDefaultPlates = document.getElementById("<%=lblDefaultPlates.ClientID %>");
    var hdnplateID = document.getElementById("<%=hdnplateID.ClientID %>");
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

    var hid_DeletedID_id = document.getElementById("<%=hid_DeletedID.ClientID %>").id;

    var hid_makeready = document.getElementById("<%=hid_makeready.ClientID %>");
    var hid_washup = document.getElementById("<%=hid_washup.ClientID %>");

    var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
    var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
    var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID%>");
    var ddlNoOfSide = document.getElementById("<%=ddlNoOfSide.ClientID %>");
    var ddlSide1Color = document.getElementById("<%=ddlSide1Color.ClientID %>");
    var ddlSide2Color = document.getElementById("<%=ddlSide2Color.ClientID %>");
    var chkTurn = document.getElementById("<%=chkTurn.ClientID %>");
    var chkTumble = document.getElementById("<%=chkTumble.ClientID %>");
    var chkSheetWork = document.getElementById("<%=chkSheetWork.ClientID %>");
    var chkPerfecting = document.getElementById("<%=chkPerfecting.ClientID %>");


    var hid_FinalInkSave1 = document.getElementById("<%=hid_FinalInkSave1.ClientID %>");
    var hid_FinalInkSave2 = document.getElementById("<%=hid_FinalInkSave2.ClientID %>");
    var EditID = 0;
    var BookletPrintLayout = '';
    var hid_value = document.getElementById("<%=hid_value.ClientID %>");
    var hid_IsSheetCustom = document.getElementById("<%=hid_IsSheetCustom.ClientID %>");
    var hid_IsJobCustom = document.getElementById("<%=hid_IsJobCustom.ClientID %>");
    var hdnedit_Default = document.getElementById("<%=hdnedit_Default.ClientID %>");
    var hid_isPressPerfect = document.getElementById("<%=hid_isPressPerfect.ClientID %>");
    var spn_Printlayout = document.getElementById("spn_Printlayout");


    var txtFlatbookletitemsizeHeight = document.getElementById("<%=txtFlatbookletitemsizeHeight.ClientID %>");
    var txtFlatbookletitemsizeWidth = document.getElementById("<%=txtFlatbookletitemsizeWidth.ClientID %>");

</script>
<%-- CODING PART END--%>
<script>
    function calc(val) {

        var SH = document.getElementById("<%=txtsectionheight.ClientID %>");
        var SW = document.getElementById("<%=txtsectionwidth.ClientID %>");
        var IH = document.getElementById("<%=txtitemheight.ClientID %>");
        var IW = document.getElementById("<%=txtitemwidth.ClientID %>");
        var result_port = document.getElementById("<%=txtportrait.ClientID %>");
        var result_port = document.getElementById("<%=txtportrait.ClientID %>");
        var result_manual = document.getElementById("<%=txtManual.ClientID %>");
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
    var SH = document.getElementById("<%=txtsectionheight.ClientID %>");
    var SW = document.getElementById("<%=txtsectionwidth.ClientID %>");
    var IH = document.getElementById("<%=txtitemheight.ClientID %>");
    var IW = document.getElementById("<%=txtitemwidth.ClientID %>");
    var result_port = document.getElementById("<%=txtportrait.ClientID %>");
    var result_land = document.getElementById("<%=txtlandscape.ClientID %>");
    var result_manual = document.getElementById("<%=txtManual.ClientID %>");
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
    var hdn_Protrait = document.getElementById("<%=hdnProtrait.ClientID %>");
    var hdn_Landscale = document.getElementById("<%=hdnLandscale.ClientID %>");

    var chkIsSilling = document.getElementById("<%=chkIsSilling.ClientID %>");

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
    var ddlBookletType = document.getElementById("<%=ddlBookletType.ClientID %>");
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
        var chkTurn = document.getElementById("<%=chkTurn.ClientID %>");
        var chkTumble = document.getElementById("<%=chkTumble.ClientID %>");
        var chkSheetWork = document.getElementById("<%=chkSheetWork.ClientID %>");
        var chkPerfecting = document.getElementById("<%=chkPerfecting.ClientID %>");

        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
            IH = txtFlatbookletitemsizeHeight;
            IW = txtFlatbookletitemsizeWidth;
        }

        var dblsidelitho = 0;
        var IsChkTumble = 0;
        if (chkTumble.checked == true) {
            IsChkTumble = 1;
        }
        if (chkTurn.checked == true || chkTumble.checked == true) {
            dblsidelitho = 1;
        }

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

        } else {
            hdntype.value = "manual";
            row = row_port.value;
            col = col_port.value;
        }

        if ((SH.value != "") && (SW.value != "") && (IH.value != "") && (IW.value != "")) {
            if (row == 0 || col == 0) {
                alert('Print Layout should not be zero');
            }
            else {
                window.radopen("<%=nmsCommon.global.sitePath()%>print_layout.aspx?SH=" + SH.value + "&SW=" + SW.value + "&IH=" + IH.value + "&IW=" + IW.value + "&type=" + hdntype.value + "&selected=" + hdnselected.value + "&row=" + row + "&col=" + col + "&vg=" + hdnvertical.value + "&hg=" + hdnhorizontal.value + "&nonHeight=" + NonHeight + "&nonWidth=" + NonWeight + "&dblside=" + dblsidelitho + "&IsChkTumble=" + IsChkTumble, '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        else {
            alert('Print Layout should not be zero');
        }
    }

    var hid_singleData = document.getElementById("<%=hid_singleData.ClientID %>");
    var hid_booklet_save = document.getElementById("<%=hid_booklet_save.ClientID %>");
    var commonpath = "<%=nmsCommon.global.sitePath()%>";
</script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/settingsjs.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/item_lithobooklet.js?VN='<%=VersionNumber%>'"></script>
<asp:HiddenField ID="hid_bookletData" runat="server" />
<asp:Panel ID="pnlBookletEdit" runat="server" Visible="false">
    <script type="text/javascript">
        var hid_bookletData = document.getElementById("<%=hid_bookletData.ClientID %>");
        OnlyForBooklet();
    </script>
</asp:Panel>
<script>
    var FromItemDescription = '';
    FromItemDescription = '<%=FromItemDescription%>';
    if (FromItemDescription == 'Y') {
        MoveNextSection();
    }

    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    var modulename = "<%=modulename %>"
    if (modulename == "jobs") {
        if (typeof hrefQtyMore !== 'undefined') {
            hrefQtyMore.style.display = "none";
        }
        if (typeof hrefQtySingle !== 'undefined') {
            hrefQtySingle.style.display = "none";
        }
        // hrefQtyMore.style.display = "none";
        // hrefQtySingle.style.display = "none";
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>
<script type="text/javascript">
    function bindplatesmakereadywashupdropdownvalue(val) {
        var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
        var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
        var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID %>");

        for (var i = 0; i < ddlMakeReady.length; i++) {
            if (ddlMakeReady.options[i].value == val) {
                ddlMakeReady.selectedIndex = i;
            }
        }
        for (var j = 0; j < ddlWashUp.length; j++) {
            if (ddlWashUp.options[j].value == val) {
                ddlWashUp.selectedIndex = j;
            }
        }
        for (var k = 0; k < ddlPlates.length; k++) {
            if (ddlPlates.options[k].value == val) {
                ddlPlates.selectedIndex = k;
            }
        }
    }
</script>
<script>
    var hid_SessionPressChange = document.getElementById("<%=hid_SessionPressChange.ClientID %>");
    var hid_PressChange = document.getElementById("<%=hid_PressChange.ClientID %>");
    var hid_PressID = document.getElementById("<%=hid_PressID.ClientID %>");
    function GuillotineSelect() {
        window.radopen(strSitepath + "common/common_popup.aspx?type=moreplant&pg=estimate", '', '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

    function SendGuillotineIDandName(id, values, FirstTrim, SecondTrim) {
        lblGuillotine.title = SpecialDecode(values);
        lblGuillotine.innerHTML = SpecialDecode(trim12(values));
        chkFirstTrim.checked = FirstTrim;
        chkSecondTrim.checked = SecondTrim;
        lblGuillotine.style.cursor = "default";
        hid_GuillotineID.value = id;
        div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";
    }


    function onchange_press(val) {
        hid_PressID.value = val;
        if (ddlPress.selectedIndex != 0) {
            var compID = '<%=CompanyID %>';
            val = compID + '±' + val;

            ePrint.press_select.Litho_press_select(val, success)
        }
        document.getElementById("<%=hid_PressChange.ClientID %>").value = "yes";
    }

    function success(result) {
        var ddlValue = '';
        ddlValue = hid_PressID.value;
        document.getElementById("div_GuttersCustomSize").style.display = "none";
        chkGutters.checked = false;
        ChkPressRestrictions.checked = false;    // by natraj, Ref Bug: 612
        txtGutterHorizontal.value = "0.00";
        txtGutterVertical.value = "0.00";

        var Litho = result;
        var arr2 = Litho.split('±');
        if (arr2[0] == ddlValue) {

            lblDefaultPaper.innerHTML = SpecialDecode(arr2[3].split('»')[1]);
            lblDefaultPlates.innerHTML = SpecialDecode(arr2[16].split('»')[1]);
            lblGuillotine.innerHTML = SpecialDecode(arr2[18].split('»')[1]);

            lblDefaultPaper.title = SpecialDecode(arr2[3].split('»')[1]);
            lblDefaultPlates.title = SpecialDecode(arr2[16].split('»')[1]);
            lblGuillotine.title = SpecialDecode(arr2[18].split('»')[1]);
            lblPaperWeight.innerHTML = SpecialDecode(arr2[26]);

            hdnpaperID.value = arr2[2].split('»')[1];
            hdnplateID.value = arr2[15].split('»')[1];
            hid_GuillotineID.value = arr2[17].split('»')[1];
            div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";

            hdn_InkType.value = arr2[24].split('»')[1];

            txtSetupSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[11].split('»')[1], 0, '', true, false, false);
            txtRunningSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[12].split('»')[1], 0, '', false, false, false);

            var gutterhoriz = arr2[13].split('»')[1]
            var gutterverti = arr2[13].split('»')[2]

            if (gutterhoriz >= 1 && gutterverti >= 1) {
                txtGutterHorizontal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, gutterhoriz, 0, '', false, false, false);
                txtGutterVertical.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, gutterverti, 0, '', false, false, false);
                chkGutters.checked = true;
                document.getElementById("div_GuttersCustomSize").style.display = "block";
            }

            var printimageheight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[14].split('»')[1], 0, '', false, false, false);
            NonHeight = printimageheight;

            var printimagewidth = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[14].split('»')[2], 0, '', false, false, false);
            NonWeight = printimagewidth;

            if (printimageheight >= 1 || printimagewidth >= 1) {
                ChkPressRestrictions.checked = true;
            }

            for (j = 0; j < ddlPrintSheetSize.length; j++) {
                if (ddlPrintSheetSize.options[j].value == arr2[4].split('»')[1]) {
                    ddlPrintSheetSize.selectedIndex = j;

                    LoadToSheetCustom();
                }
            }

            for (j = 0; j < ddlJobItemSize.length; j++) {
                if (ddlJobItemSize.options[j].value == arr2[5].split('»')[1]) {
                    ddlJobItemSize.selectedIndex = j;
                    LoadToJobCustom();
                }
            }
            for (k = 0; k < ddlSide1Color.length; k++) {
                if (ddlSide1Color.options[k].value == arr2[21].split('»')[1]) {
                    ddlSide1Color.selectedIndex = k;
                }
            }
            for (m = 0; m < ddlSide2Color.length; m++) {
                if (ddlSide2Color.options[m].value == arr2[21].split('»')[1]) {
                    ddlSide2Color.selectedIndex = m;
                }
            }
            var MakeReadyPerPlateCheck = arr2[19].split('»')[1]
            var WashupChargePerColourCheck = arr2[20].split('»')[1]

            if (MakeReadyPerPlateCheck == "1") {
                document.getElementById("divMakeReady").style.display = "block";
            }
            else {
                document.getElementById("divMakeReady").style.display = "none";
            }
            if (WashupChargePerColourCheck == "1") {
                document.getElementById("divWashUp").style.display = "block";
            }
            else {
                document.getElementById("divWashUp").style.display = "none";
            }

            var ddlval = '';
            if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
                ddlval = Number(arr2[21].split('»')[1]) + Number(arr2[21].split('»')[1]);
            }
            else {
                ddlval = arr2[21].split('»')[1];
            }
            hid_isPressPerfect.value = arr2[25].split('»')[1];
            bindplatesmakereadywashupdropdownvalue(ddlval);
        }
        else {
            txtGutterHorizontal.value = "0.00"
            txtGutterVertical.value = "0.00"

            ddlJobItemSize.selectedIndex = 0;
            ddlPrintSheetSize.selectedIndex = 0;
            if (ddlJobItemSize.selectedIndex == 0) {

                txtsectionheight.value = "0.00";
                txtsectionwidth.value = "0.00";
            }
            if (ddlPrintSheetSize.selectedIndex == 0) {

                txtitemheight.value = "0.00";
                txtitemwidth.value = "0.00";
            }
        }
        LoadCalculations("ctl00_ContentPlaceHolder1_UcBooklet_ddlPress");

        try {
            PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
        }
        catch (err) { }
        __doPostBack('ctl00$ContentPlaceHolder1$UcBooklet$lnk_ddlPress_OnChange', '');
    }


    function GetPaperValue(result) {
        hdn_PaperProperties.value = result;
    }

    if (modulename != "invoice" && modulename != "jobs" && modulename != "orders") {
        moreQty('more');
    }

    function moreQty(para1) {
        try {
            txtQuantity.focus();
            if (navigator.appName == "Microsoft Internet Explorer") {
                if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                    var ieversion = new Number(RegExp.$1)
                    if (ieversion >= 6) {
                        document.getElementById("div_RunOnQty").className = "absolutepos";
                    }
                    if (ieversion >= 7) {
                        document.getElementById("div_RunOnQty").className = "absolutepos7";
                    }
                }
            }
            else {
                if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)) {
                    var ffversion = new Number(RegExp.$1);

                    if (ffversion == 3) {
                        document.getElementById("div_RunOnQty").className = "absolutepos1ff";
                    }
                    if (ffversion >= 3.5) {
                        document.getElementById("div_RunOnQty").className = "absolutepos1";
                    }
                }
            }

            if (para1 == "single") {
                document.getElementById(div_Qty2to4).style.display = "none";
                document.getElementById("div_Addmore").style.display = "none";
                hid_QtyType.value = "S";

                document.getElementById("hrefQtyMore").style.display = "block";
                document.getElementById("hrefQtySingle").style.display = "none";
            }
            else if (para1 == "more") {
                document.getElementById(div_Qty2to4).style.display = "block";
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("div_qty_3to4").className = "bglabelnewLargeEmpty";
                }
                else {
                    document.getElementById("div_qty_3to4").className = "bglabelnewLargeEmpty1";
                }
                document.getElementById("div_Addmore").style.display = "block"

                hid_QtyType.value = "M";
                document.getElementById("hrefQtyMore").style.display = "none";
                document.getElementById("hrefQtySingle").style.display = "block";

                document.getElementById("div_RunOnQty").style.display = "none";
                chkRunOnQty.checked = false;
            }
            else if (para1 == "runonqty") {
                document.getElementById(div_Qty2to4).style.display = "none"
                document.getElementById("div_Addmore").style.display = "none";
                if (chkRunOnQty.checked) {
                    document.getElementById("div_RunOnQty").style.display = "block";
                    hid_QtyType.value = "R";
                }
                else {
                    document.getElementById("div_RunOnQty").style.display = "none";
                    hid_QtyType.value = "S";
                }
            }

        }
        catch (err) {
        }
    }

    function SendPaperIDandName(id, values, papertype, Materialno, PaperWeight) {
        values = trim12(values);
        var lblDefaultPaper = "<%=lblDefaultPaper.ClientID %>";
        document.getElementById(lblDefaultPaper).title = SpecialDecode(values);
        document.getElementById(lblDefaultPaper).innerHTML = SpecialDecode(values);
        document.getElementById(lblDefaultPaper).style.cursor = "pointer";
        document.getElementById("<%=hdnpaperID.ClientID %>").value = id;
        lblPaperWeight.innerHTML = PaperWeight;

        try {
            PageMethods.GetPaperHeightWidth(CompanyID, id, GetPaperValue);
        }
        catch (err) { }
    }

    function SendPlatesIDandName(id, values) {
        values = trim12(values);
        var lblDefaultPlates = "<%=lblDefaultPlates.ClientID %>";
        document.getElementById(lblDefaultPlates).title = SpecialDecode(values);
        document.getElementById(lblDefaultPlates).innerHTML = SpecialDecode(values);
        document.getElementById(lblDefaultPlates).style.cursor = "pointer";
        document.getElementById("<%=hdnplateID.ClientID %>").value = id;
    }

    function GuttersCustom(chID) {
        document.getElementById("div_GuttersCustomSize").style.display = "none";
        var chCheck = document.getElementById(chID).checked;
        if (chCheck) {
            document.getElementById("div_GuttersCustomSize").style.display = "block";

            txtGutterHorizontal.focus();
        }
        else {
            document.getElementById("div_GuttersCustomSize").style.display = "none";
        }
    }

    function PrintLayout(val, chkLayoutID) {
        debugger
        var Sides = 1;
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }

        if (val == "landscape") {
            chkPortrait.checked = false;
            chkManual.checked = false;

            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_land.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_land.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_land.value) * 2;
                } else {
                    //txtPagesPerSignature.value = Number(result_land.value) * 1;
                    txtPagesPerSignature.value = Number(result_land.value) * 2;
                }
            }

            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
        }
        else if (val == "portrait") {
            chkLandscape.checked = false;
            chkManual.checked = false;

            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 2;
                } else {
                    //txtPagesPerSignature.value = Number(result_port.value) * 1;
                    txtPagesPerSignature.value = Number(result_port.value) * 2;
                }
            }
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
        } else {
            chkLandscape.checked = false;
            chkPortrait.checked = false;

            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_manual.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_manual.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_manual.value) * 2;
                } else {
                    //txtPagesPerSignature.value = Number(result_port.value) * 1;
                    txtPagesPerSignature.value = Number(result_manual.value) * 2;
                }
            }
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

        }

        var chCheck = document.getElementById(chkLayoutID).checked;
        if (!chCheck) {
            document.getElementById(chkLayoutID).checked = true;
        }
        var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
        if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
            txtNoOfSignatures.value = GetNoOfSignatures("0");
        }
        else {

            txtNoOfSignatures.value = NoOfSignature;
            txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
        }
    }

    function CalculateManual() {
        var Sides = 1;
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }
        if (chkManual.checked) {
            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_manual.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_manual.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_manual.value) * 2;
                } else {
                    //txtPagesPerSignature.value = Number(result_port.value) * 1;
                    txtPagesPerSignature.value = Number(result_manual.value) * 2;
                }
            }
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {

                txtNoOfSignatures.value = NoOfSignature;
                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
            }
        }

    }

    function WorkTick(chktick) {
        var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
        var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
        var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID %>");
        var ddlSide1Color = document.getElementById("<%=ddlSide1Color.ClientID %>");
        var ddlSide2Color = document.getElementById("<%=ddlSide2Color.ClientID %>");

        var ddltemp;

        if (chktick == "turn") {
            chkTumble.checked = false;
            chkSheetWork.checked = false;
            chkPerfecting.checked = false;
        }
        else if (chktick == "tumble") {
            chkTurn.checked = false;
            chkSheetWork.checked = false;
            chkPerfecting.checked = false;
        }
        else if (chktick == "perfect") {
            chkTurn.checked = false;
            chkSheetWork.checked = false;
            chkTumble.checked = false;
        }
        else {
            chkTumble.checked = false;
            chkTurn.checked = false;
            chkPerfecting.checked = false;
        }

        if (chkTurn.checked == false && chkTumble.checked == false && chkPerfecting.checked == false) {
            chkSheetWork.checked = true;
            side1_on_chnage(ddlSide1Color.options[ddlSide1Color.selectedIndex].value);
        }
        else {
            ddltemp = ddlSide1Color.options[ddlSide1Color.selectedIndex].value;
            for (var i = 0; i < ddlPlates.length; i++) {
                if (ddlPlates.options[i].value == ddltemp) {
                    ddlPlates.selectedIndex = i;
                }
            }
            for (var i = 0; i < ddlMakeReady.length; i++) {
                if (ddlMakeReady.options[i].value == ddltemp) {
                    ddlMakeReady.selectedIndex = i;
                }
            }
            for (var i = 0; i < ddlWashUp.length; i++) {
                if (ddlWashUp.options[i].value == ddltemp) {
                    ddlWashUp.selectedIndex = i;
                }
            }

            BindPlatesMakeready(); //by Swetha M.S on 12/4/2011 -- Ref BUGID:121
        }
    }

    function LoadCalculations(ddlid) {
        const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
        const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
        var Sides = 1;

        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }

        if (txtsectionheight.value != "") {
            var DDl = document.getElementById(ddlid);
            if (DDl.selectedIndex != 0) {

                if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                    var NewJobSheetHight = 0;
                    var NewJobSheetWidth = 0;

                    var FormatIndex = ddlBookletFormat.selectedIndex;
                    if (FormatIndex == 0) {
                        if (Number(IH.value) > Number(IW.value)) {
                            NewJobSheetWidth = Number(IW.value) * 2;
                            NewJobSheetHight = Number(IH.value);
                        }
                        else {
                            NewJobSheetHight = Number(IH.value) * 2;
                            NewJobSheetWidth = Number(IW.value);
                        }
                    }
                    else {

                        if (Number(IH.value) > Number(IW.value)) {
                            NewJobSheetHight = Number(IH.value) * 2;
                            NewJobSheetWidth = Number(IW.value);
                        }
                        else {
                            NewJobSheetWidth = Number(IW.value) * 2;
                            NewJobSheetHight = Number(IH.value);
                        }
                    }
                    var tempNewJobSheetHight = 0;
                    var tempNewJobSheetWidth = 0;

                    if (FormatIndex == 0) {
                        if (NewJobSheetHight > NewJobSheetWidth) {
                            tempNewJobSheetWidth = NewJobSheetWidth;
                            tempNewJobSheetHight = NewJobSheetHight;
                        }
                        else {
                            tempNewJobSheetWidth = NewJobSheetHight;
                            tempNewJobSheetHight = NewJobSheetWidth;
                        }
                    }
                    else {
                        if (NewJobSheetHight > NewJobSheetWidth) {
                            tempNewJobSheetWidth = NewJobSheetHight;
                            tempNewJobSheetHight = NewJobSheetWidth;
                        }
                        else {
                            tempNewJobSheetWidth = NewJobSheetWidth;
                            tempNewJobSheetHight = NewJobSheetHight;
                        }
                    }

                    txtFlatbookletitemsizeHeight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, tempNewJobSheetHight, decimalPlaces, '', false, false, false);
                    txtFlatbookletitemsizeWidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, tempNewJobSheetWidth, decimalPlaces, '', false, false, false);

                    G_CalculateLandscape_saddlestiched('K', tempNewJobSheetHight, tempNewJobSheetWidth);
                    G_CalculatePortrait_saddlestiched('K', tempNewJobSheetHight, tempNewJobSheetWidth);

                    lblPortraitLength.innerHTML = "";
                    lblLandscapeLength.innerHTML = "";

                    if (Number(result_port.value) > Number(result_land.value)) {
                        if (Sides == 2) {
                            txtPagesPerSignature.value = Number(result_port.value) * 4;
                        } else {
                            txtPagesPerSignature.value = Number(result_port.value) * 4;
                        }
                        txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                        chkPortrait.checked = true;
                        chkLandscape.checked = false;
                        chkManual.checked = false;
                    }
                    else {
                        if (Sides == 2) {
                            txtPagesPerSignature.value = Number(result_land.value) * 4;
                        } else {
                            txtPagesPerSignature.value = Number(result_land.value) * 4;
                        }
                        txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                        chkPortrait.checked = false;
                        chkLandscape.checked = true;
                        chkManual.checked = false;
                    }
                    var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
                    if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                        txtNoOfSignatures.value = GetNoOfSignatures("0");
                    }
                    else {

                        txtNoOfSignatures.value = NoOfSignature;
                        txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
                    }
                }
                else {
                    G_CalculateLandscape('K');
                    G_CalculatePortrait('K');

                    lblPortraitLength.innerHTML = "";
                    lblLandscapeLength.innerHTML = "";

                    if (Number(result_port.value) > Number(result_land.value)) {
                        if (Sides == 2) {
                            txtPagesPerSignature.value = Number(result_port.value) * 2;
                        } else {
                            txtPagesPerSignature.value = Number(result_port.value) * 1;
                        }
                        txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                        document.getElementById("<%=ddlBookletFormat.ClientID%>").selectedIndex = "0";
                    }
                    else {
                        if (Sides == 2) {
                            txtPagesPerSignature.value = Number(result_land.value) * 2;
                        } else {
                            txtPagesPerSignature.value = Number(result_land.value) * 1;
                        }
                        txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                        document.getElementById("<%=ddlBookletFormat.ClientID%>").selectedIndex = "1";
                    }
                    var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
                    if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                        txtNoOfSignatures.value = GetNoOfSignatures("0");
                    }
                    else {

                        txtNoOfSignatures.value = NoOfSignature;
                        txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
                    }
                }
                BindPlatesMakeready();
            }
        }
        if (hid_isPressPerfect.value == 1 || hid_isPressPerfect.value == 'True') {
            document.getElementById("Div_PerfectChk").style.display = "block";
        }
        else {
            document.getElementById("Div_PerfectChk").style.display = "none";
        }
    }

    function CalculateLandscape(FinishedBookletHeight, FinishedBookletWidth, isSaddleStiched) {

        var Sides = 1;
        if (!isSaddleStiched) {

            if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
                Sides = 2;
            }
            else {
                Sides = 1;
            }
        }

        if ((chkGutters.checked) && (chkRestrictions.checked)) {

            hdnselected.value = "both";
            ASH = Number(SH.value) - (Number(NonHeight) * Sides);
            ASW = Number(SW.value) - Number(NonWeight) * Sides;
            A = Number(ASH) - Number(HrzGutter.value);
            B = Number(A) / Number(Number(FinishedBookletHeight) + Number(HrzGutter.value));
            C = parseInt(B);

            row = C;

            D = Number(ASW) - Number(VtGutter.value);
            E = Number(D) / Number(Number(FinishedBookletWidth) + Number(VtGutter.value));

            F = parseInt(E);
            col = F;
            Result = C * F;
            Result = (C * F) * Sides;

            hdnvertical.value = VtGutter.value;
            hdnhorizontal.value = HrzGutter.value;
        }
        else if (chkGutters.checked) {
            hdnselected.value = "gutters";
            A = Number(SH.value) - Number(VtGutter.value);
            B = Number(A) / Number(Number(FinishedBookletHeight) + Number(VtGutter.value));
            C = parseInt(B);
            row = C;
            var Z;

            D = Number(SW.value) - Number(HrzGutter.value);
            E = Number(D) / Number(Number(FinishedBookletWidth) + Number(HrzGutter.value));
            F = parseInt(E);
            col = F;
            Result = C * F;
            Result = (C * F) * Sides;
            hdnvertical.value = VtGutter.value;
            hdnhorizontal.value = HrzGutter.value;

        }
        else if (chkRestrictions.checked) {
            hdnselected.value = "restriction";

            ASH = Number(SH.value) - Number(NonHeight);
            ASW = Number(SW.value) - Number(NonWeight);
            A = Number(ASH) / Number(FinishedBookletHeight);
            B = Number(ASW) / Number(FinishedBookletWidth);
            row = parseInt(A);
            col = parseInt(B);
            Result = col * row;
            Result = (col * row) * Sides;
            hdnhorizontal.value = "0";
            hdnvertical.value = "0";
        }
        else {
            hdnselected.value = "none";

            A = Number(SH.value) / Number(FinishedBookletHeight);
            B = Number(SW.value) / Number(FinishedBookletWidth);

            C = parseInt(A); //Math.round(col_land)
            D = parseInt(B); //Math.round(row_land)

            row = C;
            col = D;

            Result = col * row;
            Result = (col * row) * Sides;
            hdnhorizontal.value = "0";
            hdnvertical.value = "0";
        }

        row_land.value = row;

        col_land.value = col;

        if (ddlBookletFormat.value == "L") {
            if (isNaN(Result)) {
                txtPagesPerSignature.value = "0";
                result_land.value = "0";
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {
                txtPagesPerSignature.value = Result;
                txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                result_land.value = Result;
                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(Result);
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                    txtNoOfSignatures.value = GetNoOfSignatures("0");
                }
                else {
                    txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
                }
            }
        }
        else if (isNaN(Result)) {
            result_land.value = "0";
        }
        else {
            result_land.value = Result;
            hdn_Landscale.value = Result;
        }
    }

    function CalculatePortrait(FinishedBookletHeight, FinishedBookletWidth, isSaddleStiched) {

        var Sides = 1;
        if (!isSaddleStiched) {

            if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
                Sides = 2;
            }
            else {
                Sides = 1;
            }
        }

        var FormatIndex = ddlFormat.selectedIndex;
        if ((chkGutters.checked) && (chkRestrictions.checked)) {
            hdnselected.value = "both";

            // ROW Calculation
            var Row_A1 = Number(SH.value) - Number(NonHeight);
            Row_A1 = Number(Row_A1) - Number(HrzGutter.value);
            var Row_A2 = Number(FinishedBookletWidth) + Number(HrzGutter.value);
            var Row_A = Number(Row_A1) / Number(Row_A2);
            Row_A = parseInt(Row_A);

            //COLUMN Calculation
            var Col_B1 = Number(SW.value) - Number(NonWeight);
            Col_B1 = Number(Col_B1) - Number(VtGutter.value);
            var Col_B2 = Number(FinishedBookletHeight) + Number(VtGutter.value);
            var Col_B = Number(Col_B1) / Number(Col_B2);
            Col_B = parseInt(Col_B);

            Result = Row_A * Col_B;
            Result = (Row_A * Col_B) * Sides;
            row = Row_A;
            col = Col_B;
        }
        else if (chkGutters.checked) {
            hdnselected.value = "gutters";

            // ROW Calculation
            var Row_A1 = Number(SH.value) - Number(HrzGutter.value);
            var Row_A2 = Number(FinishedBookletWidth) + Number(HrzGutter.value);
            var Row_A = Number(Row_A1) / Number(Row_A2);
            Row_A = parseInt(Row_A);

            //COLUMN Calculation
            var Col_B1 = Number(SW.value) - Number(VtGutter.value);
            var Col_B2 = Number(FinishedBookletHeight) + Number(VtGutter.value);
            var Col_B = Number(Col_B1) / Number(Col_B2);
            Col_B = parseInt(Col_B);

            Result = Row_A * Col_B;
            Result = (Row_A * Col_B) * Sides;
            row = Row_A;
            col = Col_B;

            hdnvertical.value = VtGutter.value;
            hdnhorizontal.value = HrzGutter.value;
        }
        else if (chkRestrictions.checked) {
            hdnselected.value = "restriction";
            // ROW Calculation
            var Row_A1 = Number(SH.value) - Number(NonHeight);
            var Row_A2 = Number(FinishedBookletWidth);
            var Row_A = Number(Row_A1) / Number(Row_A2);
            Row_A = parseInt(Row_A);

            //COLUMN Calculation
            var Col_B1 = Number(SW.value) - Number(NonWeight);
            var Col_B2 = Number(FinishedBookletHeight);
            var Col_B = Number(Col_B1) / Number(Col_B2);
            Col_B = parseInt(Col_B);

            Result = Row_A * Col_B;

            Result = (Row_A * Col_B) * Sides;
            row = Row_A;
            col = Col_B;

            hdnhorizontal.value = "0";
            hdnvertical.value = "0";

        }
        else {
            hdnselected.value = "none";
            A = Number(SH.value) / Number(FinishedBookletWidth);
            B = Number(SW.value) / Number(FinishedBookletHeight);


            C = parseInt(A); //Math.round(col_port)
            D = parseInt(B); //Math.round(row_port)


            row = C;
            col = D;

            Result = row * col;
            Result = (row * col) * Sides;
            hdnhorizontal.value = "0";
            hdnvertical.value = "0";
        }
        row_port.value = row;
        col_port.value = col;

        if (ddlBookletFormat.value == "P") {
            if (isNaN(Result)) {
                txtPagesPerSignature.value = "0";
                result_port.value = "0";
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {
                txtPagesPerSignature.value = Result;
                txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
                result_port.value = Result;

                var NoOfSignature = Number(txtNoOfPagesInSection.value) / Result;
                if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                    txtNoOfSignatures.value = GetNoOfSignatures("0");
                }
                else {
                    txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
                }
            }
        }
        else if (isNaN(Result)) {
            result_port.value = "0";
        }
        else {
            result_port.value = Result;
            hdn_Protrait.value = Result;
        }
    }

    function PrintSheetCustom(chID) {
        document.getElementById("div_ddlPrintSheetSize").style.display = "none";
        document.getElementById("div_PrintSheetCustomSize").style.display = "none";
        var chCheck = document.getElementById(chID).checked;
        if (chCheck) {
            document.getElementById("div_PrintSheetCustomSize").style.display = "block";
            txtsectionheight.focus();
        }
        else {
            document.getElementById("div_ddlPrintSheetSize").style.display = "block";
        }
    }

    function JobItemCustom(chID) {
        document.getElementById("div_ddlJobItemSize").style.display = "none";
        document.getElementById("div_JobItemCustomSize").style.display = "none";
        var chCheck = document.getElementById(chID).checked;
        if (chCheck) {
            document.getElementById("div_JobItemCustomSize").style.display = "block";
            txtitemheight.focus();
        }
        else {
            document.getElementById("div_ddlJobItemSize").style.display = "block";
        }
    }

    function LoadToSheetCustom() {
        const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
        const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
        var ddlPrintSheetSizeid = ddlPrintSheetSize.options[ddlPrintSheetSize.selectedIndex].value;
        var dpaperhw = "<%=dpaperhw%>";
        if (dpaperhw != "") {
            var arr1 = dpaperhw.split('»');
            for (var i = 0; i < arr1.length; i++) {
                var arr2 = arr1[i].split('±');
                if (arr2[0] == ddlPrintSheetSizeid) {
                    txtsectionheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[1], decimalPlaces, '', false, false, false);
                    txtsectionwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[2], decimalPlaces, '', false, false, false);
                }
            }
        }
    }

    function LoadToJobCustom() {
        const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
        const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
        var ddlJobItemSizeid = ddlJobItemSize.options[ddlJobItemSize.selectedIndex].value;
        var dpaperhw = "<%=dpaperhw%>";
        if (dpaperhw != "") {
            var arr1 = dpaperhw.split('»');
            for (var i = 0; i < arr1.length; i++) {
                var arr2 = arr1[i].split('±');
                if (arr2[0] == ddlJobItemSizeid) {
                    txtitemheight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[1], decimalPlaces, '', false, false, false);
                    txtitemwidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[2], decimalPlaces, '', false, false, false);
                }
            }
        }
    }

    if ("<%=QueryType%>" == "edit") {
        var ddlNoOfSide = document.getElementById("<%=ddlNoOfSide.ClientID %>");

        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            document.getElementById("div_side2_colour").style.display = "block";
            document.getElementById("div_work").style.display = "block";
        }
    }

    if ("<%=QueryType%>" == "add") {
        chkSheetWork.checked = true;
    }

    function setwidth() {
        var is_ie = (/msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent));
        if (is_ie) {
            document.getElementById("div_GuttersCustomSize").style.width = "230px";
        }
        else {
            document.getElementById("div_GuttersCustomSize").style.width = "230px";
        }
    }
    setwidth();

    function Calculations() {
        const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
        const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
        var Sides = 1;
        if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
            Sides = 2;
        }
        else {
            Sides = 1;
        }

        if (!chkPrintSheet.checked) {
            LoadToSheetCustom();
        }

        if (!ChkJobFlatCustom.checked) {
            LoadToJobCustom();
        }

        if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
            var NewJobSheetHight = 0;
            var NewJobSheetWidth = 0;

            var FormatIndex = ddlBookletFormat.selectedIndex;
            if (FormatIndex == 0) {
                if (Number(IH.value) > Number(IW.value)) {
                    NewJobSheetWidth = Number(IW.value) * 2;
                    NewJobSheetHight = Number(IH.value);
                }
                else {
                    NewJobSheetHight = Number(IH.value) * 2;
                    NewJobSheetWidth = Number(IW.value);
                }
            }
            else {

                if (Number(IH.value) > Number(IW.value)) {
                    NewJobSheetHight = Number(IH.value) * 2;
                    NewJobSheetWidth = Number(IW.value);
                }
                else {
                    NewJobSheetWidth = Number(IW.value) * 2;
                    NewJobSheetHight = Number(IH.value);
                }
            }

            var tempNewJobSheetHight = 0;
            var tempNewJobSheetWidth = 0;

            if (FormatIndex == 0) {
                if (NewJobSheetHight > NewJobSheetWidth) {
                    tempNewJobSheetWidth = NewJobSheetWidth;
                    tempNewJobSheetHight = NewJobSheetHight;
                }
                else {
                    tempNewJobSheetWidth = NewJobSheetHight;
                    tempNewJobSheetHight = NewJobSheetWidth;
                }
            }
            else {
                if (NewJobSheetHight > NewJobSheetWidth) {
                    tempNewJobSheetWidth = NewJobSheetHight;
                    tempNewJobSheetHight = NewJobSheetWidth;
                }
                else {
                    tempNewJobSheetWidth = NewJobSheetWidth;
                    tempNewJobSheetHight = NewJobSheetHight;
                }
            }

            txtFlatbookletitemsizeHeight.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, tempNewJobSheetHight, decimalPlaces, '', false, false, false);
            txtFlatbookletitemsizeWidth.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, tempNewJobSheetWidth, decimalPlaces, '', false, false, false);

            G_CalculateLandscape_saddlestiched('K', tempNewJobSheetHight, tempNewJobSheetWidth);
            G_CalculatePortrait_saddlestiched('K', tempNewJobSheetHight, tempNewJobSheetWidth);

            if (txtManual.value == "") {
                txtManual.value = 0;
            }

            lblPortraitLength.innerHTML = "";
            lblLandscapeLength.innerHTML = "";

            if (Number(result_port.value) > Number(result_land.value)) {
                if (BookletPrintLayout == 'P') {
                    chkPortrait.checked = true;
                    chkLandscape.checked = false;
                    chkManual.checked = false;

                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (PortraitLength != "Infinity") {
                            lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblPortraitLength.innerHTML = "";
                    }
                }
                else if (BookletPrintLayout == 'L') {
                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    chkPortrait.checked = false;
                    chkLandscape.checked = true;
                    chkManual.checked = false;
                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (LandscapeLength != "Infinity") {
                            lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblLandscapeLength.innerHTML = "";
                    }
                } else if (BookletPrintLayout == "M") {
                    chkPortrait.checked = false;
                    chkLandscape.checked = false;
                    chkManual.checked = true;

                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_manual.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_manual.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (LandscapeLength != "Infinity") {
                            lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblLandscapeLength.innerHTML = "";
                    }
                }
                else {
                    chkPortrait.checked = true;
                    chkLandscape.checked = false;
                    chkManual.checked = false;
                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);


                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (PortraitLength != "Infinity") {
                            lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblPortraitLength.innerHTML = "";
                    }
                }
            }
            else if (Number(result_land.value) > Number(result_port.value)) {
                if (BookletPrintLayout == 'L') {
                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    chkPortrait.checked = false;
                    chkLandscape.checked = true;
                    chkManual.checked = false;
                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (LandscapeLength != "Infinity") {
                            lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblLandscapeLength.innerHTML = "";
                    }
                }
                else if (BookletPrintLayout == 'P') {
                    chkPortrait.checked = true;
                    chkLandscape.checked = false;
                    chkManual.checked = false;

                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_port.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (PortraitLength != "Infinity") {
                            lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblPortraitLength.innerHTML = "";
                    }
                } else if (BookletPrintLayout == "M") {
                    chkPortrait.checked = false;
                    chkLandscape.checked = false;
                    chkManual.checked = true;
                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_manual.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_manual.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (PortraitLength != "Infinity") {
                            lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblPortraitLength.innerHTML = "";
                    }
                }
                else {
                    if (Sides == 2) {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    } else {
                        txtPagesPerSignature.value = Number(result_land.value) * 4;
                    }
                    txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                    chkPortrait.checked = false;
                    chkLandscape.checked = true;
                    chkManual.checked = false;
                    if (spnPaperType.innerHTML == "meter(s)") {
                        if (LandscapeLength != "Infinity") {
                            lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " <%=PaperMeasure %>";
                        }
                    }
                    else {
                        lblLandscapeLength.innerHTML = "";
                    }
                }
            } else {
                // If both are equaled

                //chkPortrait.checked = true;
                //chkLandscape.checked = false;
                //chkManual.checked = false;

                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                }
                txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);


                if (spnPaperType.innerHTML == "meter(s)") {
                    if (PortraitLength != "Infinity") {
                        lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                    }
                }
                else {
                    lblPortraitLength.innerHTML = "";
                }
            }

            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {
                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
            }
        }
        else {

            G_CalculateLandscape('K');
            G_CalculatePortrait('K');

            lblPortraitLength.innerHTML = "";
            lblLandscapeLength.innerHTML = "";

            if (Number(result_port.value) > Number(result_land.value)) {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 2;
                } else {
                    txtPagesPerSignature.value = Number(result_port.value) * 1;
                }
                txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                chkPortrait.checked = true;
                chkLandscape.checked = false;
                chkManual.checked = false;
                if (spnPaperType.innerHTML == "meter(s)") {
                    if (PortraitLength != "Infinity") {
                        lblPortraitLength.innerHTML = "Paper Length Required: " + PortraitLength + " <%=PaperMeasure %>";
                    }
                }
                else {
                    lblPortraitLength.innerHTML = "";
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_land.value) * 2;
                } else {
                    txtPagesPerSignature.value = Number(result_land.value) * 1;
                }
                txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);

                chkPortrait.checked = false;
                chkLandscape.checked = true;
                chkManual.checked = false;
                if (spnPaperType.innerHTML == "meter(s)") {
                    if (LandscapeLength != "Infinity") {
                        lblLandscapeLength.innerHTML = "Paper Length Required: " + LandscapeLength + " <%=PaperMeasure %>";
                    }
                }
                else {
                    lblLandscapeLength.innerHTML = "";
                }
            }
            // by gaj
            var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
            if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
                txtNoOfSignatures.value = GetNoOfSignatures("0");
            }
            else {

                txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
            }
            // by gaj
        }
        BindPlatesMakeready();
    }

    function setbooklet_format() {

        if (Number(result_port.value) > Number(result_land.value)) {
            ddlBookletFormat.selectedIndex = 0;
        }
        else {
            ddlBookletFormat.selectedIndex = 1;
        }
    }

</script>
<script>
    //by Swetha M.S on 12/4/2011 --- Ref BUG ID: 121
    function BindPlatesMakeready() {
        var txtNoOfPlates = document.getElementById("<%=txtNoOfPlates.ClientID %>");
        var txtNoOfMakeReady = document.getElementById("<%=txtNoOfMakeReady.ClientID %>");

        //by Swetha M.S on 12/4/2011 -- Ref BugID: 121
        var txtNoOfSignatures = document.getElementById("<%=txtNoOfSignatures.ClientID %>");
        var SideSelected = ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value;
        var Side1ColorVal = ddlSide1Color.options[ddlSide1Color.selectedIndex].value;
        var Side2ColorVal = ddlSide2Color.options[ddlSide2Color.selectedIndex].value;

        var NoOfSignatures = Number(txtNoOfSignatures.value);
        var NoOfPlatesorMakeready = 0;

        if (NoOfSignatures > 0) {
            if (SideSelected.toString().toLocaleLowerCase() == "double") {
                if (chkTurn.checked == true || chkTumble.checked == true) {
                    NoOfPlatesorMakeready = (Math.ceil(Number(NoOfSignatures)) * Number(Side1ColorVal));
                }
                else {
                    NoOfPlatesorMakeready = (Math.ceil(Number(NoOfSignatures)) * Number(Side1ColorVal)) + (Math.ceil(Number(NoOfSignatures)) * Number(Side2ColorVal));
                }
            }
            else {
                NoOfPlatesorMakeready = (Math.ceil(Number(NoOfSignatures)) * Number(Side1ColorVal));
            }
        }
        else {
            if (SideSelected.toString().toLocaleLowerCase() == "double") {
                if (chkTurn.checked == true || chkTumble.checked == true) {
                    NoOfPlatesorMakeready = Number(Side1ColorVal);
                }
                else {
                    NoOfPlatesorMakeready = Number(Side1ColorVal) + Number(Side2ColorVal);
                }
            }
            else {
                NoOfPlatesorMakeready = Number(Side1ColorVal);
            }
        }

        txtNoOfPlates.value = Math.ceil(NoOfPlatesorMakeready);
        txtNoOfMakeReady.value = Math.ceil(NoOfPlatesorMakeready);
    }
</script>
<script>
    function OpenPaperPopUp(Type) {
        var papertype = "sheet";
        var wnd = window.radopen(strSitepath + "common/common_popup.aspx?type=invselector&pg=estimate&item=paper&papertype=" + papertype + "");
        wnd.setSize(1275, 500);
        wnd.center();
        var x = wnd.getWindowBounds().x;
        var y = wnd.getWindowBounds().y;
        if (y < 0) {
            wnd.moveTo(x, 57);
        }
        SetRadWindow('divrad', 'divBackGroundNew', '200');

        return false;
    }


    function popup_ink(val) {
        debugger;
        var ddl = 1;
        var id = 0;
        var Type = "<%=QueryType %>";
        var EstItemID = "<%=EstimateItemID %>";
        var Side = "Single";
        var ddlval = "";
        var ddlNoOfSide = document.getElementById("<%=ddlNoOfSide.ClientID %>");
        var hid_FinalInkSave1 = document.getElementById("<%=hid_FinalInkSave1.ClientID%>");
        var hid_FinalInkSave2 = document.getElementById("<%=hid_FinalInkSave2.ClientID%>");
        var ddlPress = document.getElementById("<%=ddlPress.ClientID %>");

        if (val == 'side1') {
            ddl = document.getElementById("<%=ddlSide1Color.ClientID %>");
        }
        else {
            ddl = document.getElementById("<%=ddlSide2Color.ClientID %>");
        }
        if (val == 'side1') {
            Side = "Single";
            ddlval = hid_FinalInkSave1.value;
        }
        else {
            Side = "Double";
            ddlval = hid_FinalInkSave2.value;
        }

        var arraynew = new Array();
        arraynew = ddlval;
        ddlval = '';
        var str = new Array();

        for (var k = 0; k < arraynew.length; k++) {
            ddlval += arraynew[k].replace('~', '±');
        }
        str = ddlval;
        var arraynew1 = new Array();
        arraynew1 = str;
        str = '';
        for (var l = 0; l < arraynew1.length; l++) {
            str += arraynew1[l].replace('ž', '»');
        }

        ddl = ddl.options[ddl.selectedIndex].value;
        id = ddlPress.options[ddlPress.selectedIndex].value;
        window.radopen("<%=nmsCommon.global.sitePath()%>common/inkselector.aspx?cnt=" + ddl + "&id=" + id + "&type=" + Type + "&EstItemID=" + EstItemID + "&side=" + Side + "&ddlval=" + str + "&EstimateLithoNCRItemID=0&EstimateLithobookletItemID=" + EditID + "&Section=" + hid_value.value + "&Esttype=K&sidenumber=" + val + "&InkType=" + hdn_InkType.value + "&PressChangeVal=" + hid_PressChange.value + '', '1000', '600');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

</script>
<script>
    function show_work(para) {
        debugger;

        var ddlSide2Color = document.getElementById("<%=ddlSide2Color.ClientID %>");
        var ddlSide1Color = document.getElementById("<%=ddlSide1Color.ClientID %>");
        if (chkLandscape.checked) {
            chkPortrait.checked = false;

            var Sides = 1;
            if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
                Sides = 2;
            }
            else {
                Sides = 1;
            }

            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_land.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_land.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_land.value) * 2;
                } else {
                    txtPagesPerSignature.value = Number(result_land.value) * 1;
                }
            }

            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
        }
        else {
            chkLandscape.checked = false;

            if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                } else {
                    txtPagesPerSignature.value = Number(result_port.value) * 4;
                }
            }
            else {
                if (Sides == 2) {
                    txtPagesPerSignature.value = Number(result_port.value) * 2;
                } else {
                    //txtPagesPerSignature.value = Number(result_port.value) * 1;
                    txtPagesPerSignature.value = Number(result_port.value) * 2;
                }
            }
            txtPagesPerSignature.value = GetPagesPerSignature(txtPagesPerSignature.value);
        }

        var NoOfSignature = Number(txtNoOfPagesInSection.value) / Number(txtPagesPerSignature.value);
        if (isNaN(Number(NoOfSignature)) || NoOfSignature == "Infinity") {
            txtNoOfSignatures.value = GetNoOfSignatures("0");
        }
        else {
            txtNoOfSignatures.value = NoOfSignature;
            txtNoOfSignatures.value = GetNoOfSignatures(NoOfSignature);
        }

        if (para == "Double") {
            document.getElementById("div_work").style.display = "block";
            document.getElementById("div_side2_colour").style.display = "block";
            side2_on_chnage(ddlSide2Color.options[ddlSide2Color.selectedIndex].value);
            CalculateBookletSection();
        }
        else {
            document.getElementById("div_work").style.display = "none";
            document.getElementById("div_side2_colour").style.display = "none";

            single_side_selection();
            CalculateBookletSection();


        }
    }

    // single sided print formula
    function single_side_selection() {
        debugger
        if (chkPortrait.checked) {
            PrintLayout('portrait', chkPortrait.id);
        }
        else if (chkLandscape.checked) {
            PrintLayout('landscape', chkLandscape.id);
        } else if (chkManual.checked) {
            PrintLayout('manual', chkManual.id);
        }
    }

    function side1_on_chnage(val) {
        var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
        var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
        var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID %>");

        ddlMakeReady.selectedIndex = val;
        ddlWashUp.selectedIndex = val;
        ddlPlates.selectedIndex = Number(val) - 1;

        if (document.getElementById("div_side2_colour").style.display == "block") {
            val1 = document.getElementById("<%=ddlSide2Color.ClientID %>").value;

            ddlMakeReady.selectedIndex = Number(val) + Number(val1);
            ddlWashUp.selectedIndex = Number(val) + Number(val1);
            ddlPlates.selectedIndex = Number(val) + Number(val1) - 1;
        }

        chkSheetWork.checked = true;
        chkTurn.checked = false;
        chkTumble.checked = false;

        if (chkPerfecting.checked == true) {
            chkSheetWork.checked = false;
        }
        BindPlatesMakeready(); //By Swetha M.S on 12/4/2011 -- Ref BUGID -121
    }

    function side2_on_chnage(val) {
        var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
        var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
        var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID %>");

        val1 = document.getElementById("<%=ddlSide1Color.ClientID %>").value;

        ddlMakeReady.selectedIndex = Number(val) + Number(val1);
        ddlWashUp.selectedIndex = Number(val) + Number(val1);
        ddlPlates.selectedIndex = Number(val) + Number(val1) - 1;

        BindPlatesMakeready(); //By Swetha M.S on 12/4/2011 -- Ref BUGID -121
        if (chkTurn.checked == true) {
            WorkTick('turn', this.id);
        }
        else if (chkTumble.checked == true) {
            WorkTick('tumble', this.id);
        }

    }

    function WorkTick(chktick, chkid) {
        var ddlPlates = document.getElementById("<%=ddlPlates.ClientID %>");
        var ddlMakeReady = document.getElementById("<%=ddlMakeReady.ClientID %>");
        var ddlWashUp = document.getElementById("<%=ddlWashUp.ClientID %>");
        var ddlSide1Color = document.getElementById("<%=ddlSide1Color.ClientID %>");
        var ddlSide2Color = document.getElementById("<%=ddlSide2Color.ClientID %>");

        var ddltemp;

        if (chktick == "turn") {
            chkTumble.checked = false;
            chkSheetWork.checked = false;
            chkPerfecting.checked = false;
        }
        else if (chktick == "tumble") {
            chkTurn.checked = false;
            chkSheetWork.checked = false;
            chkPerfecting.checked = false;
        }
        else if (chktick == "perfect") {
            chkTurn.checked = false;
            chkSheetWork.checked = false;
            chkTumble.checked = false;
        }
        else {
            chkTumble.checked = false;
            chkTurn.checked = false;
            chkPerfecting.checked = false;
        }

        if (chkTurn.checked == false && chkTumble.checked == false && chkPerfecting.checked == false) {
            chkSheetWork.checked = true;
            side1_on_chnage(ddlSide1Color.options[ddlSide1Color.selectedIndex].value);
        }
        else {
            if (chkPerfecting.checked == true) {
                side1_on_chnage(ddlSide1Color.options[ddlSide1Color.selectedIndex].value);
            }
            else {
                ddltemp = ddlSide1Color.options[ddlSide1Color.selectedIndex].value;
                for (var i = 0; i < ddlPlates.length; i++) {
                    if (ddlPlates.options[i].value == ddltemp) {
                        ddlPlates.selectedIndex = i;
                    }
                }
                for (var i = 0; i < ddlMakeReady.length; i++) {
                    if (ddlMakeReady.options[i].value == ddltemp) {
                        ddlMakeReady.selectedIndex = i;
                    }
                }
                for (var i = 0; i < ddlWashUp.length; i++) {
                    if (ddlWashUp.options[i].value == ddltemp) {
                        ddlWashUp.selectedIndex = i;
                    }
                }

                BindPlatesMakeready(); //By Swetha M.S on 12/4/2011 -- Ref BUGID -121
            }
        }
    }
</script>

<asp:Panel ID="pnlPress" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function PressOnChange() {
            var ddlPress = document.getElementById("<%=ddlPress.ClientID %>");
            var ddlValue = ddlPress.options[ddlPress.selectedIndex].value;

            chkGutters.checked = false;
            ChkPressRestrictions.checked = false;

            var Litho = hid_LithoPress.value;
            var arr1;
            arr1 = Litho.split('µ');
            for (var i = 0; i < arr1.length; i++) {
                var arr2 = arr1[i].split('±');
                if (arr2[0] == ddlValue) {
                    lblDefaultPaper.innerHTML = SpecialDecode(arr2[3].split('»')[1]);
                    lblDefaultPlates.innerHTML = SpecialDecode(arr2[16].split('»')[1]);
                    lblGuillotine.innerHTML = SpecialDecode(arr2[18].split('»')[1]);

                    lblDefaultPaper.title = SpecialDecode(arr2[3].split('»')[1]);
                    lblDefaultPlates.title = SpecialDecode(arr2[16].split('»')[1]);
                    lblGuillotine.title = SpecialDecode(arr2[18].split('»')[1]);
                    lblPaperWeight.innerHTML = SpecialDecode(arr2[26]);

                    hdnpaperID.value = arr2[2].split('»')[1];
                    hdnplateID.value = arr2[15].split('»')[1];
                    hid_GuillotineID.value = arr2[17].split('»')[1];
                    div_Trim.style.display = hid_GuillotineID.value != "0" ? "block" : "none";

                    hdn_InkType.value = arr2[24].split('»')[1];

                    txtSetupSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[11].split('»')[1], 0, '', true, false, false);
                    txtRunningSpoilage.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[12].split('»')[1], 0, '', false, false, false);

                    var gutterhoriz = arr2[13].split('»')[1]
                    var gutterverti = arr2[13].split('»')[2]

                    if (gutterhoriz >= 1 && gutterverti >= 1) {      // Ref Bug:568
                        txtGutterHorizontal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, gutterhoriz, 0, '', false, false, false);
                        txtGutterVertical.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, gutterverti, 0, '', false, false, false);
                        chkGutters.checked = true;
                        document.getElementById("div_GuttersCustomSize").style.display = "block";
                    }

                    var printimageheight = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[14].split('»')[1], 0, '', false, false, false);
                    NonHeight = printimageheight;

                    var printimagewidth = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[14].split('»')[1], 0, '', false, false, false);
                    NonWeight = printimagewidth;

                    if (printimageheight >= 1 || printimagewidth >= 1) { // Ref Bug: 612
                        ChkPressRestrictions.checked = true;
                    }


                    if (RequestType == "add" || hdnedit_Default.value == "1") {
                        for (j = 0; j < ddlPrintSheetSize.length; j++) {
                            if (ddlPrintSheetSize.options[j].value == arr2[4].split('»')[1]) {
                                ddlPrintSheetSize.selectedIndex = j;
                                LoadToSheetCustom();
                            }
                        }

                        for (j = 0; j < ddlJobItemSize.length; j++) {
                            if (ddlJobItemSize.options[j].value == arr2[5].split('»')[1]) {
                                ddlJobItemSize.selectedIndex = j;
                                LoadToJobCustom();
                            }
                        }
                    }

                    var MakeReadyPerPlateCheck = arr2[19].split('»')[1]
                    var WashupChargePerColourCheck = arr2[20].split('»')[1]

                    if (MakeReadyPerPlateCheck == "1") {
                        document.getElementById("divMakeReady").style.display = "block";
                    }
                    else {
                        document.getElementById("divMakeReady").style.display = "none";
                    }
                    if (WashupChargePerColourCheck == "1") {
                        document.getElementById("divWashUp").style.display = "block";
                    }
                    else {
                        document.getElementById("divWashUp").style.display = "none";
                    }
                    for (k = 0; k < ddlSide1Color.length; k++) {
                        if (ddlSide1Color.options[k].value == arr2[21].split('»')[1]) {
                            ddlSide1Color.selectedIndex = k;
                        }
                    }
                    for (m = 0; m < ddlSide2Color.length; m++) {
                        if (ddlSide2Color.options[m].value == arr2[21].split('»')[1]) {
                            ddlSide2Color.selectedIndex = m;
                        }
                    }
                    var ddlval = '';
                    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
                        ddlval = Number(arr2[21].split('»')[1]) + Number(arr2[21].split('»')[1]);
                    }
                    else {
                        ddlval = arr2[21].split('»')[1];
                    }

                    hid_isPressPerfect.value = arr2[25].split('»')[1];

                    show_work(ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value);

                    bindplatesmakereadywashupdropdownvalue(ddlval);

                    txtNoOfPlates.value = ddlval;
                    txtNoOfMakeReady.value = ddlval;
                    //BindPlatesMakeready();  //by Swetha M.S on 12/4/2011 -- Ref BugID: 121
                }
            }

            if (Litho != '') {
                //To get Paper Height and Width on PaperID //
                PageMethods.GetPaperHeightWidth(CompanyID, hdnpaperID.value, GetPaperValue);
            }
        }
        PressOnChange();
        LoadCalculations("ctl00_ContentPlaceHolder1_UcBooklet_ddlPress");
    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">
    //this is done on 11/03/11 in job & invoice (it shows multiple qty text boxes which was created in Estimates).
    if (modulename == "invoice" || modulename == "jobs" || modulename == "orders") {
        if (QtyNo == "1") {
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
        }
        else if (QtyNo == "2") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
        }
        else if (QtyNo == "3") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty4").style.display = "none";
            document.getElementById("div_qty12").style.display = "none";
        }
        else if (QtyNo == "4") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty12").style.display = "none";
        }
    }

    if (!ChkJobFlatCustom.checked) {
        hdnedit_Default.value = "1";
    }
    if (!chkPrintSheet.checked) {
        hdnedit_Default.value = "1";
    }

    //if (QueryType.toLowerCase() != "add") {
    //    if (ddlJobItemSize.value == 0 || hid_IsJobCustom.value == "True") {
    //        document.getElementById("div_JobItemCustomSize").style.display = "block";
    //        document.getElementById("div_ddlJobItemSize").style.display = "none";
    //        document.getElementById("ChkJobFlatCustom")
    //        ChkJobFlatCustom.checked = true;
    //    }
    //    else {
    //        document.getElementById("div_ddlJobItemSize").style.display = "block";
    //        document.getElementById("div_JobItemCustomSize").style.display = "none";
    //    }
    //    if (ddlPrintSheetSize.value == 0 || hid_IsSheetCustom.value == "True") {
    //        document.getElementById("div_ddlPrintSheetSize").style.display = "none";
    //        document.getElementById("div_PrintSheetCustomSize").style.display = "block";
    //        document.getElementById("chkPrintSheet")
    //        chkPrintSheet.checked = true;
    //    }
    //    else {
    //        document.getElementById("div_ddlPrintSheetSize").style.display = "block";
    //        document.getElementById("div_PrintSheetCustomSize").style.display = "none";
    //    }
    //}

    if (ddlNoOfSide.options[ddlNoOfSide.selectedIndex].value == "Double") {
        document.getElementById("div_work").style.display = "block";
    }
    else {
        document.getElementById("div_work").style.display = "none";
    }

    if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'saddlestiched') {
        document.getElementById("div_Booklet_itemSize").style.display = "block";
    }
    else if (ddlBookletType.options[ddlBookletType.selectedIndex].value == 'perfectbound') {
        document.getElementById("div_PrintLayout").style.display = "block";
        document.getElementById("div_Booklet_itemSize").style.display = "none";
        document.getElementById("div_Booklet_Format").style.display = "none";
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
        var InventoryManagement = '<%=InventoryManagement %>';
        var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
        var ReduceStockType = '<%=ReduceStockType %>';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        var reqtype = funreqtype();
        if (reqtype == 'add') {
            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (modulename.toLowerCase() == "invoice") {
                    if (ReduceStockType.toString().toLowerCase() != "e" && ReduceStockType.toString().toLowerCase() != "i") {
                        //                        if (window.confirm('Do you want to Reduce the inventory stock?')) {
                        //                            hdn_invStockReduce.value = "yes";
                        //                        }
                        //                        else { hdn_invStockReduce.value = "no"; }
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

        document.getElementById('div_tbnsaveprocess').style.display = 'block';
        document.getElementById('div_btnsave').style.display = 'none';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        hdn_invStockReduce.value = val;
        document.getElementById('div_AlertPopup').style.display = "none"
        document.getElementById('divBackGroundNew').style.display = "none";
        __doPostBack('ctl00$ContentPlaceHolder1$UcBooklet$btnSave', '');
    }

    function changetext() {
        selectedval = ddlBookletType.options[ddlBookletType.selectedIndex].value;
        if (selectedval == 'saddlestiched') {
            document.getElementById("<%= Label20.ClientID %>").innerHTML = '<%=objLanguage.GetLanguageConversion("Print_Layout_of_the_flat_booklet_item") %>';;
            document.getElementById("<%=lblbookletformat.ClientID %>").innerHTML = '<%=objLanguage.GetLanguageConversion("Finished_Booklet_Format") %>';
            document.getElementById("div_Booklet_itemSize").style.display = "block";
            document.getElementById("div_PrintLayout").style.display = "block";
            document.getElementById("div_Booklet_Format").style.display = "block";
        }
        else if (selectedval == 'perfectbound') {
            document.getElementById("<%=Label20.ClientID %>").innerHTML = '<%=objLanguage.GetLanguageConversion("Print_Layout") %>';
            document.getElementById("<%=lblbookletformat.ClientID %>").innerHTML = '<%=objLanguage.GetLanguageConversion("Print_Layout") %>';
            document.getElementById("div_Booklet_itemSize").style.display = "none";
            document.getElementById("div_PrintLayout").style.display = "block";
            document.getElementById("div_Booklet_Format").style.display = "none";
        }
    }

    changetext();
</script>
