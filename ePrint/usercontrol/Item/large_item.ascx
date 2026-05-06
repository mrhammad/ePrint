<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="large_item.ascx.cs" Inherits="ePrint.usercontrol.Item.large_item" %>


<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>' " lang="javascript"></script>
<script type="text/javascript" src="../js/item/calculations.js?VN='<%=VersionNumber%>'"
    lang="javascript"></script>
<script>
    var PrintLayout_MSG_Sheet = '<%=PrintLayout_MSG_Sheet%>';
    var PaperMeasure = "<%=PaperMeasure %>";
    var Metre = "<%=Metre %>";
    var QtyNo = "<%=QtyNo %>";

    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var tabtype = "<%=tabtype %>";
    var modulename = "<%=modulename %>";
    var QueryType = "<%=QueryType %>";

    var Sheets = '<%=objLanguage.GetLanguageConversion("Sheets") %>';
    var mm = '<%=objLanguage.GetLanguageConversion("mm") %>';
    var LargeFormatCalculation = "<%=LargeFormatCalculation %>";
    var SquareFeet = '<%=objLanguage.GetLanguageConversion("SquareFeet") %>';
    var SquareMeter = '<%=objLanguage.GetLanguageConversion("SquareMeter") %>';

    var LargeItemPrintLayout ="<%=LargeItemPrintLayout %>";
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
    setLoadingPositionOfDivMove(div_Load);
</script>
<style>
    .bglabel {
        float: left;
        width: 26%;
        padding: 5px;
        clear: left;
        vertical-align: middle;
        margin: 0px 0px 2px 0px;
    }
</style>
<div>
    <div id="divMainContent">
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="div_AlertPopup" style="display: none; position: absolute; width: 1100px; left: 480px; z-index: 10;">
        </div>
        <div id="content">
            <%-- LEFT SIDE --%>
            <div style="float: left; width: 49%; border: solid 0px red;">
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label10" runat="server" Text="Item Title" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="boxlargeitem" style="float: left; padding-left: 5px;">
                        <asp:TextBox ID="txtItemTitle" SkinID="textPad" runat="server" Width="260px" MaxLength="75"
                            onblur="CallonBlur(this.value,'spn_txtItemTitle');"></asp:TextBox>
                    </div>
                    <div id="spn_txtItemTitle" style="float: left; display: none; width: 65%; margin-left: 28.4%; margin-top: -6px; margin-bottom: 5px;">
                        <span class="spanErrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: -3px">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Item_Title") %></span>
                    </div>
                </div>
                <div align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label3" runat="server" Text="Estimate Type" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting">
                        <asp:DropDownList ID="ddlEstimateType" onchange="javascript:ShowEstimate(this.value);"
                            CssClass="normaltext" Width="175px" runat="server">
                            <asp:ListItem Text="--- Select ---" Selected="True" Value=""></asp:ListItem>
                            <asp:ListItem Text="Sheet Fed Digital" Value="digital"></asp:ListItem>
                            <asp:ListItem Text="Large Format" Value="largeformat"></asp:ListItem>
                            <asp:ListItem Text="Print Broker" Value="printbroker"></asp:ListItem>
                            <asp:ListItem Text="Warehouse" Value="warehouse"></asp:ListItem>
                            <asp:ListItem Text="Other Costs" Value="othercost"></asp:ListItem>
                            <asp:ListItem Text="Price Catalogue" Value="pricecatalogue"></asp:ListItem>
                        </asp:DropDownList>
                        <span id="spn_Label3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                            class="spanErrorMsg">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Estimate_Type") %></span>
                    </div>
                </div>
                <div id="div_ProductType" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label4" runat="server" Text="Product Type" CssClass="normaltext"></asp:Label>
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
                            <%=objLanguage.GetLanguageConversion("Please_Select_Product_type") %>
                        </span>
                    </div>
                </div>
                  <div class="only5px">
            </div>
                <div id="div_only_digitals_left" align="left">
                    <div align="left">
                        <div class="bglabel" style="height: 37px; border: 0px solid blue">
                            <div id="div_FinishedQty" style="float: left; border: 0px solid;">
                                <asp:Label ID="Label6" runat="server" Text="Finished Qty" CssClass="normaltext"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div id="div_BookletQty" style="display: none; float: left;">
                                <asp:Label ID="Label7" runat="server" Text="Booklet Qty" CssClass="normaltext"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div id="div_PadsQty" style="display: none; float: left;">
                                <asp:Label ID="Label8" runat="server" Text="Enter Pad Qty" CssClass="normaltext"></asp:Label>
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
                        <div style="white-space: nowrap; float: left; margin-bottom: -2.5%;">
                            <table style="margin-left: -1%; margin-top: -1%;">
                                <tr>
                                    <td>
                                        <div style="float: left; width: 260px; margin-left: 2px;" id="div_qty12">
                                            <div id="div_qty1" class="box" style="float: left; width: 120px; border: 0px solid red; white-space: nowrap;">
                                                <%=objLanguage.GetLanguageConversion("Qty1")%>
                                                <asp:TextBox ID="txtQuantity" Width="75px" SkinID="textPad" runat="server" onkeyup="javascript:ToInteger(this,this.value);"
                                                    MaxLength="8"></asp:TextBox>
                                                <span id="spn_txtQuantity_number" class="spanerrorMsg" style="display: none; width: 165px;">Please enter numeric value</span>
                                            </div>
                                            <div id="div_chkRunOnQty" style="float: left; padding-top: 15px; vertical-align: bottom">
                                                <asp:CheckBox ID="chkRunOnQty" onclick="javascript:moreQty('runonqty');" Text="Run On Qty"
                                                    runat="server" Style="display: none" />
                                            </div>
                                            <div class="box" id="div_Addmore" style="float: right; display: none; width: 120px; border: 0px solid red; white-space: nowrap; margin-right: -5.5%;"
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
                                                    <div class="bglabelnewLargeEmpty" style="float: left;">
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
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="div_Qty_2to4" style="display: none; border: 0px solid; margin-top: -4px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div id="div_qty3" class="box" style="float: left; width: 141px; border: 0px solid; white-space: nowrap;">
                                                            <%=objLanguage.GetLanguageConversion("Qty3")%>
                                                            <asp:TextBox ID="txtQuantity_3" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                                                onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>

                                                        <div id="div_qty4" class="box" style="float: right; width: 155px; border: 0px solid; white-space: nowrap;">
                                                            <%=objLanguage.GetLanguageConversion("Qty4")%>
                                                            <asp:TextBox ID="txtQuantity_4" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);"
                                                                onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="div_qty_3to4" style="float: left; border: 0px solid">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                     <div class="onlyEmpty">
                </div>

                    <div style="border: 0px solid">
                    <div class="bglabelEmpty" style="float: left;">
                    </div>
                    <div style="float: left; border: 0px solid blue; margin-top: -25px; margin-left: -103px;">
                        <%--raghavendra added margin-top:-15px; margin-left:-81px for proper alignment of validator fields 18th july 2012 line no-203--%>
                        <span id="spn_txtQuantity" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;margin-top: 14px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity") %></span>
                        <%--raghavendra chnaged width to 205 px for proper alignment of validator line no-205 18th july 2012--%>
                    </div>
                </div>
                    <div class="onlyEmpty">
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
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Section_Reference") %></span>
                        </div>
                    </div>
                    <div align="left" style="white-space: nowrap; margin-bottom: -10px;">
                        <div class="bglabel" style="float: left; height: 18px;">
                            <asp:Label ID="Label9" runat="server" Text="Assigned Press" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="ddlsetting" style="float: left; margin-top: -2.5px">
                            <asp:DropDownList ID="ddlPress" CssClass="normaltext" Width="260px" onchange="PressOnChange(this);LoadCalculations(this.id);"
                                runat="server">
                            </asp:DropDownList>
                            <span id="spn_ddlPress" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Press") %></span>
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
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabelMaterial">
                    </div>
                    <div id="paperheading" class="box" style="width: 400px; float: left;">
                        <div style="float: left; width: 165px;">
                            &nbsp;
                        </div>
                        <div id="div_WholePack" style="float: left; width: 70px;">
                            <asp:Label ID="Label21" runat="server" Style="cursor: pointer;" Text="Price for Whole Pack"></asp:Label>
                        </div>
                        <div id="div_Supplied" style="float: left; width: 200px; margin-top: -10px;">
                            <asp:Label ID="Label28" runat="server" Style="cursor: pointer;" Text="Paper Supplied"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div id="div_Stock" class="bglabel" style="margin-top: -15px; height: 20px;">
                        <div style="float: left;">
                            <asp:Label ID="lbl_m1" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div id="Divplus1" runat="server" style="float: right;">
                            <a href="javascript://" onclick="OpenPaperPopUp('paper','1');">
                                <img src="<%=strImagepath%>plus.gif" id="Img_plus1" border="0" /></a>
                            <asp:HiddenField ID="hdn_PaperProperties" Value="" runat="server" />
                        </div>
                    </div>
                    <div id="div_defaultpaper" class="box" style="width: 360px; margin-top: -10px;">
                        <div style="float: left; width: 220px; padding-left: 2px;">
                            <asp:Label ID="lblDefaultPaper" runat="server" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
                            <asp:Label ID="lblPaperWeight" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                            <asp:HiddenField ID="hdnpaperID" runat="server" Value="" />
                            <span id="spn_lblDefaultPaper" class="spanerrorMsg" style="display: none; width: 222px; padding-left: 4px; padding-right: 4px; margin-top: 3px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Default_Paper") %></span>
                        </div>
                        <div id="div_PriceForWholePack1" style="float: left; width: 70px;">
                            <asp:CheckBox ID="Chk_PriceForWholePack1" Text="" onclick="javascript:checkchanged(1);"
                                runat="server" />
                        </div>
                        <div id="div_PaperSupplied1" style="float: left; width: 50px; margin-left: -2px;">
                            <asp:CheckBox ID="Chk_PaperSupplied1" Text="" runat="server" onclick="javascript:checkchanged1(1);" />
                        </div>
                         <div style="float: left; width: 20px; padding-top: 2px;">
                                <a href="javascript://" onclick="delete_Papers('1');">
                                    <img src="<%=strImagepath%>delete.gif" id="Img_delete" border="0" style="cursor: pointer; " /></a>
                            </div>
                    </div>
                </div>
                <div id="div_materials" runat="server">
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" id="divpaperstock2" runat="server" style="display: none;">
                        <div class="bglabel">
                            <div style="float: left;">
                                <asp:Label ID="lbl_m2" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="Divplus2" runat="server" style="float: right;">
                                <a href="javascript://" onclick="OpenPaperPopUp('paper','2');">
                                    <img src="<%=strImagepath%>plus.gif" id="Img_plus2" border="0" /></a>
                                <asp:HiddenField ID="hdn_PaperProperties2" Value="" runat="server" />
                            </div>
                        </div>
                        <div class="box" style="width: 360px;">
                            <div style="float: left; width: 220px;">
                                <asp:Label ID="lbl_paper2" runat="server" CssClass="graytext" Style="cursor: pointer; display: none;"
                                    Text="Paper 2"></asp:Label>
                                <asp:Label ID="lblPaperWt2" runat="server" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
                                <asp:HiddenField ID="hdnpaperID2" runat="server" Value="0" />
                            </div>
                            <div id="div_PriceForWholePack2" style="float: left; width: 70px;">
                                <asp:CheckBox ID="Chk_PriceForWholePack2" Text="" onclick="javascript:checkchanged(2);"
                                    runat="server" />
                            </div>
                            <div id="div_PaperSupplied2" style="float: left; width: 50px;">
                                <asp:CheckBox ID="Chk_PaperSupplied2" Text="" runat="server" onclick="javascript:checkchanged1(2);" />
                            </div>
                            <div style="float: left; width: 20px; padding-top: 2px;">
                                <a href="javascript://" onclick="delete_Papers('2');">
                                    <img src="<%=strImagepath%>delete.gif" id="Img_delete2" border="0" style="cursor: pointer; display: none;" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" id="divpaperstock3" runat="server" style="display: none;">
                        <div class="bglabel">
                            <div style="float: left;">
                                <asp:Label ID="lbl_m3" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="Divplus3" runat="server" style="float: right;">
                                <a href="javascript://" onclick="OpenPaperPopUp('paper','3');">
                                    <img src="<%=strImagepath%>plus.gif" id="Img_plus3" border="0" /></a>
                                <asp:HiddenField ID="hdn_PaperProperties3" Value="" runat="server" />
                            </div>
                        </div>
                        <div class="box" style="width: 360px;">
                            <div style="float: left; width: 220px;">
                                <asp:Label ID="lbl_paper3" runat="server" CssClass="graytext" Style="cursor: pointer; display: none;"
                                    Text="Paper 3"></asp:Label>
                                <asp:Label ID="lblPaperWt3" runat="server" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
                                <asp:HiddenField ID="hdnpaperID3" runat="server" Value="0" />
                            </div>
                            <div id="div_PriceForWholePack3" style="float: left; width: 70px;">
                                <asp:CheckBox ID="Chk_PriceForWholePack3" Text="" onclick="javascript:checkchanged(3);"
                                    runat="server" />
                            </div>
                            <div id="div_PaperSupplied3" style="float: left; width: 50px;">
                                <asp:CheckBox ID="Chk_PaperSupplied3" Text="" runat="server" onclick="javascript:checkchanged1(3);" />
                            </div>
                            <div style="float: left; width: 20px; padding-top: 2px;">
                                <a href="javascript://" onclick="delete_Papers('3');">
                                    <img src="<%=strImagepath%>delete.gif" id="Img_delete3" border="0" style="cursor: pointer; display: none;" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" id="divpaperstock4" runat="server" style="display: none;">
                        <div class="bglabel">
                            <div style="float: left;">
                                <asp:Label ID="lbl_m4" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="Divplus4" runat="server" style="float: right;">
                                <a href="javascript://" onclick="OpenPaperPopUp('paper','4');">
                                    <img src="<%=strImagepath%>plus.gif" id="Img_plus4" border="0" /></a>
                                <asp:HiddenField ID="hdn_PaperProperties4" Value="" runat="server" />
                            </div>
                        </div>
                        <div class="box" style="width: 360px;">
                            <div style="float: left; width: 220px;">
                                <asp:Label ID="lbl_paper4" runat="server" CssClass="graytext" Style="cursor: pointer; display: none;"
                                    Text="Paper 4"></asp:Label>
                                <asp:Label ID="lblPaperWt4" runat="server" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
                                <asp:HiddenField ID="hdnpaperID4" runat="server" Value="0" />
                            </div>
                            <div id="div_PriceForWholePack4" style="float: left; width: 70px;">
                                <asp:CheckBox ID="Chk_PriceForWholePack4" Text="" onclick="javascript:checkchanged(4);"
                                    runat="server" />
                            </div>
                            <div id="div_PaperSupplied4" style="float: left; width: 50px;">
                                <asp:CheckBox ID="Chk_PaperSupplied4" Text="" runat="server" onclick="javascript:checkchanged1(4);" />
                            </div>
                            <div style="float: left; width: 20px; padding-top: 2px;">
                                <a href="javascript://" onclick="delete_Papers('4');">
                                    <img src="<%=strImagepath%>delete.gif" id="Img_delete4" border="0" style="cursor: pointer; display: none;" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" id="divpaperstock5" runat="server" style="display: none;">
                        <div class="bglabel">
                            <div style="float: left;">
                                <asp:Label ID="lbl_m5" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="Divplus5" runat="server" style="float: right;">
                                <a href="javascript://" onclick="OpenPaperPopUp('paper','5');">
                                    <img src="<%=strImagepath%>plus.gif" id="Img_plus4" border="0" /></a>
                                <asp:HiddenField ID="hdn_PaperProperties5" Value="" runat="server" />
                            </div>
                        </div>
                        <div class="box" style="width: 360px;">
                            <div style="float: left; width: 220px;">
                                <asp:Label ID="lbl_paper5" runat="server" CssClass="graytext" Style="cursor: pointer; display: none;"
                                    Text="Paper 5"></asp:Label>
                                <asp:Label ID="lblPaperWt5" runat="server" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
                                <asp:HiddenField ID="hdnpaperID5" runat="server" Value="0" />
                            </div>
                            <div id="div_PriceForWholePack5" style="float: left; width: 70px;">
                                <asp:CheckBox ID="Chk_PriceForWholePack5" Text="" onclick="javascript:checkchanged(5);"
                                    runat="server" />
                            </div>
                            <div id="div_PaperSupplied5" style="float: left; width: 50px;">
                                <asp:CheckBox ID="Chk_PaperSupplied5" Text="" runat="server" onclick="javascript:checkchanged1(5);" />
                            </div>
                            <div style="float: left; width: 20px; padding-top: 2px;">
                                <a href="javascript://" onclick="delete_Papers('5');">
                                    <img src="<%=strImagepath%>delete.gif" id="Img_delete5" border="0" style="cursor: pointer; display: none;" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div style="float: left; padding-bottom: 3px;" id="divaddmorepaper" runat="server">
                    <div style="float: left;">
                        <a href="javascript://" id="lnkaddpaper" onclick="Addpaperstock();">
                            <%=objLanguage.GetLanguageConversion("Add_more_stock")%></a>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label13" runat="server" Text="Set up Spoilage" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="boxlargeitem" style="float: left; white-space: nowrap; padding-left: 5px;">
                        <asp:TextBox ID="txtSetupSpoilage" SkinID="textPad" Width="75px" runat="server" MaxLength="20"></asp:TextBox>&nbsp;
                        <span id="spnPaperType" style="font-size: 9px; display: none"></span><span id="spn_setupSpoilage"
                            class="SpanFontSize"></span>
                        <div>
                            <span id="spn_txtSetupSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_SetUp_spoilage") %></span>
                            <span id="spn_txtSetupSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numberic_Value") %></span>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label14" runat="server" Text="Running Spoilage" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="boxlargeitem" style="float: left; white-space: nowrap; padding-left: 5px;">
                        <asp:TextBox ID="txtRunningSpoilage" SkinID="textPad" Width="75px" runat="server"
                            MaxLength="20"></asp:TextBox>
                        <span id="Span1" style="font-size: 9px;">&nbsp;%</span>
                        <div>
                            <span id="spn_txtRunningSpoilage" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Runn_Spoilage") %></span>
                            <span id="spn_txtRunningSpoilage_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
                        </div>
                    </div>
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
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_No_of_Pages") %></span><span id="spn_txtNoOfPagesRequired_number"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
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
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Pages_Per_Section") %></span><span
                                        id="spn_txtPagesPerSection_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_Pads_1" align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label36" runat="server" Text="No. of Leaves per Pad" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="box">
                        <div align="left">
                            <asp:TextBox ID="txtNoOfLeavesPerPad" SkinID="textPad" runat="server" Width="75px"
                                MaxLength="8"></asp:TextBox>
                        </div>
                        <div align="left">
                            <span id="spn_txtNoOfLeavesPerPad" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Leavs_PerPad") %></span><span
                                    id="spn_txtNoOfLeavesPerPad_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
                        </div>
                    </div>
                </div>
                <div align="left" style="display: none;">
                    <div class="bglabel">
                        <%=objLanguage.GetLanguageConversion("No_Of_Sides_Printed") %>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlNoOfSide" runat="server" Width="75px" SkinID="onlyDDL">
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Double</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lbldoubleside" runat="server" CssClass="normaltext"></asp:Label>
                    </div>
                    <div style="float: left; padding-top: 3px; margin-left: -3px">
                        &nbsp;<asp:CheckBox ID="chkDoubleSided" onclick="showSides(this.checked);" runat="server" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label11" runat="server" Text="Colours" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="width: 345px; border: 0px solid red">
                        <div align="left">

                            <div style="float: left;">
                                <asp:DropDownList ID="ddlColors" runat="server" Width="195px" SkinID="onlyDDL" onchange="ShowHideInkCoverage1(this.value);">

                                    <asp:ListItem Text="Full Colour" Value="color"></asp:ListItem>
                                    <asp:ListItem Text="Single Special" Value="swhite"></asp:ListItem>
                                    <asp:ListItem Text="Double Special" Value="dwhite"></asp:ListItem>
                                    <asp:ListItem Text="Full Colour Plus Special" Value="colourwithswhite"></asp:ListItem>
                                    <asp:ListItem Text="Full Colour Plus Double Special" Value="colourwithdwhite"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div id="div_lblinkcovside1" class="bglabel" style="height: 18px;">
                        <asp:Label ID="lblinkcovside1" runat="server" CssClass="normaltext"></asp:Label>
                    </div>
                    <div style="float: left; padding-left: 5px; vertical-align: middle; width: 345px">
                        <div>
                            <asp:TextBox ID="txtInkCoverageSide1" SkinID="textPad" runat="server" MaxLength="3"
                                Width="78px"></asp:TextBox>
                            <asp:TextBox ID="txtWhiteInkCoverageSide1" SkinID="textPad" runat="server" MaxLength="3"
                                Width="95px" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <span id="spnink" class="normaltext" style="font-size: 9px;">Coverage %
                                <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%>
                            </span><span id="spnwhiteink" class="normaltext" style="font-size: 9px; padding-left: 17px; padding-top: 1px;">Coverage % Special Ink </span>
                            <div>
                                <span id="spn_txtInkCoverageSide1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 5px; padding-right: 4px; padding-top: 1px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Ink_Coverage") %>
                                </span><span id="spn_txtInkCoverageSide1_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span>
                            </div>
                        </div>
                    </div>

                </div>
                <div align="left" id="divside2color" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lblside2color" runat="server" Text="Colours" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="width: 345px; border: 0px solid red">
                        <div align="left" id="div_side2">
                            <div style="float: left;">
                                <asp:DropDownList ID="ddlColors_2" runat="server" Width="195px" SkinID="onlyDDL"
                                    onchange="ShowHideInkCoverage(this.value);">
                                    <asp:ListItem Text="Full Colour" Value="color"></asp:ListItem>
                                    <asp:ListItem Text="Single Special" Value="swhite"></asp:ListItem>
                                    <asp:ListItem Text="Double Special" Value="dwhite"></asp:ListItem>
                                    <asp:ListItem Text="Full Colour Plus Special" Value="colourwithswhite"></asp:ListItem>
                                    <asp:ListItem Text="Full Colour Plus Double Special" Value="colourwithdwhite"></asp:ListItem>
                                </asp:DropDownList>
                                <span id="spnddlcolor2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_select_Side2_Color")%></span>

                            </div>
                        </div>
                        <span id="spn_ddlColors" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Select_Colours") %></span>
                    </div>
                </div>
                <div align="left" id="divside2coverage" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lblinkcovside2" runat="server" CssClass="normaltext"></asp:Label>
                    </div>
                    <div style="float: left; padding-left: 5px; vertical-align: middle; width: 345px;">
                        <div>
                            <asp:TextBox ID="txtInkCoverageSide2" SkinID="textPad" runat="server" MaxLength="3"
                                Width="78px"></asp:TextBox>
                            <asp:TextBox ID="txtWhiteInkCoverageSide2" SkinID="textPad" runat="server" MaxLength="3"
                                Width="95px" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                        <div style="float: left">
                            <span id="spninkside2" class="normaltext" style="font-size: 9px; padding-top: 1px;">Coverage %
                                <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%>
                            </span><span id="spnwhiteinkside2" class="normaltext" style="font-size: 9px; padding-left: 17px; padding-top: 1px;">Coverage % Special Ink </span>
                            <div>
                                <span id="spn_txtInkCoverageSide2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Ink_Coverage") %>
                                </span><span id="spn_txtInkCoverageSide2_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="divPrintQualityDPI" align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lblPrintQualityDPI" runat="server" Text="Print Quality - DPI" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="width: 195px;">
                        <asp:DropDownList ID="ddlPrintQualityDPI" CssClass="normaltext" Width="195px" runat="server">
                            <asp:ListItem Value="600">600</asp:ListItem>
                            <asp:ListItem Value="1000">1000</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="div_PrintQualitySector" align="left" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label158" runat="server" Text="Print Speed" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="ddlsetting" style="width: 195px;">
                        <asp:DropDownList ID="ddlQualitySector" CssClass="normaltext" Width="195px" runat="server">
                            <asp:ListItem Value="Low">Low</asp:ListItem>
                            <asp:ListItem Value="Medium">Medium</asp:ListItem>
                            <asp:ListItem Value="High">High</asp:ListItem>
                        </asp:DropDownList>
                        <span id="spn_ddlQualitySector" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_select_Print_Speed")%></span>
                    </div>
                </div>
            </div>
            <%-- RIGHT SIDE--%>
            <div id="div_only_digitals_right" style="float: left; width: 50%; border: solid 0px green;">
                <div id="div_booklet_NoOfPagesInSection" align="left" style="display: none">
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label18" runat="server" Text="No. of pages in this section" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="box">
                            <div align="left">
                                <asp:TextBox ID="txtNoOfPagesInSection" SkinID="textPad" runat="server" MaxLength="8"
                                    Width="75px" onblur="javascript:CalculateBookletSection();"></asp:TextBox><%--onblur="javascript:return CalculateBookletSection();"--%>
                            </div>
                            <div align="left">
                                <span id="spn_txtNoOfPagesInSection" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_No_Of_Pages") %></span><span id="spn_txtNoOfPagesInSection_number"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span><span
                                            id="spn_txtNoOfPagesInSection_divide" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left" style="width: 100%;">
                    <%--SHEET SIZE--%>
                    <div align="left" nowrap="nowrap">
                        <div class="bglabel">
                            <asp:Label ID="Label22" runat="server" Text="Print Sheet Size" CssClass="normaltext"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div style="float: left; width: 235px; border: 0px solid" nowrap="nowrap">
                            <div id="div_ddlPrintSheetSize" class="ddlsetting" style="width: 235px;">
                                <asp:DropDownList ID="ddlPrintSheetSize" CssClass="normaltext" Width="175px" onchange="LoadToSheetCustom(this.value);Calculations();"
                                    runat="server">
                                </asp:DropDownList>
                                <span id="spn_ddlPrintSheetSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size") %></span>
                                <asp:HiddenField ID="hid_ddlPrintSheetSize" runat="server" Value="" />
                            </div>
                            <div style="float: left; width: 235px;" nowrap="nowrap">
                                <div id="div_PrintSheetCustomSize" class="box" style="display: none; width: 100%;">

                                    <table cellpadding="0" width="100%">
                                        <tr>
                                            <td style="width: 35px;">
                                                <span class="normaltext" style="font-size: 9px;">
                                                    <%=objLanguage.GetLanguageConversion("Width") %></span>
                                            </td>
                                            <td style="width: 35px;">
                                                <asp:TextBox ID="txtsectionwidth" Width="55px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                                            </td>
                                            <td>
                                                <font class="SpanFontSize">
                                                    <%=PaperMeasure %></font>
                                            </td>
                                            <td style="width: 35px;">
                                                <span id="spn_sheet_height" style="font-size: 9px;" class="normaltext">
                                                    <%=objLanguage.GetLanguageConversion("Height") %></span>
                                            </td>
                                            <td style="width: 35px;">
                                                <asp:TextBox ID="txtsectionheight" Width="55px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                                            </td>
                                            <td>
                                                <font class="SpanFontSize">
                                                    <%=PaperMeasure %></font>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div align="left" style="padding-left: 5px">
                                <span id="spn_PrintSheetCustomSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Print_Sheet_Size") %></span>
                                <span id="spn_PrintSheetCustomSize_numeric" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
                            </div>
                        </div>
                        <div style="float: left;">
                            <div id="div_chkPrintSheet" style="float: left; padding-top: 2px;">
                                <asp:CheckBox ID="chkPrintSheet" onclick="javascript:PrintSheetCustom(this.id);"
                                    Text="Custom" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label23" runat="server" Text="Finished Job size" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div style="float: left; width: 235px;" nowrap="nowrap">
                        <div id="div_ddlJobItemSize" class="ddlsetting" style="float: left; width: 235px;">
                            <asp:DropDownList ID="ddlJobItemSize" CssClass="normaltext" Width="175px" onchange="LoadToItemCustom(this.value);Calculations();"
                                runat="server">
                            </asp:DropDownList>
                            <span id="spn_ddlJobItemSize" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Job_Flat_Size") %></span>
                        </div>
                        <div style="float: left; width: 235px;" nowrap="nowrap">
                            <div id="div_JobItemCustomSize" class="box" style="width: 100%; display: none;">

                                <table cellpadding="0" width="100%">
                                    <tr>
                                        <td style="width: 35px;">
                                            <span class="normaltext" style="font-size: 9px;">
                                                <%=objLanguage.GetLanguageConversion("Width") %></span>
                                        </td>
                                        <td style="width: 35px;">
                                            <asp:TextBox ID="txtitemwidth" Width="55px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td>
                                            <font class="SpanFontSize">
                                                <%=PaperMeasure %></font>
                                        </td>
                                        <td style="width: 35px;">
                                            <span class="normaltext" style="font-size: 9px;">
                                                <%=objLanguage.GetLanguageConversion("Height") %></span>
                                        </td>
                                        <td style="width: 35px;">
                                            <asp:TextBox ID="txtitemheight" Width="55px" SkinID="textPad" runat="server" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td>
                                            <font class="SpanFontSize">
                                                <%=PaperMeasure %></font>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div align="left" style="padding-left: 5px;">
                            <span id="spn_JobItemCustomSize" class="spanerrorMsg" style="display: none; width: 175px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Job_Flat_Size") %></span><span
                                    id="spn_JobItemCustomSize_numeric" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_Numeric_Value") %></span>
                        </div>
                    </div>
                    <div style="float: left; padding-top: 2px;">
                        <asp:CheckBox ID="ChkJobFlatCustom" onclick="javascript:JobItemCustom(this.id);Calculations();"
                            Text="Custom" runat="server" />
                    </div>
                </div>
                <div id="div_Booklet_Format" align="left" style="display: none">
                    <div class="bglabel">
                        <span class="normalText">
                            <%=objLanguage.GetLanguageConversion("Booklet_Format") %></span>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlBookletFormat" SkinID="onlyDDL" runat="server" onchange="javascript:Calculations();">
                            <asp:ListItem>Portrait</asp:ListItem>
                            <asp:ListItem>Landscape</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="onlyEmpty" align="left" style="border: 0px solid red">
                    <div class="bglabel" id="div_GutterLabel">
                        <asp:Label ID="Label24" runat="server" Text="Include Gutters" CssClass="normaltext"></asp:Label>
                    </div>
                    <div id="div_GuttersCustomSize" class="box" style="display: none; width: 235px;"
                        nowrap="nowrap">
                        <div style="width: 235px;" nowrap="nowrap">
                            <table cellpadding="0" width="100%">
                                <tr>
                                    <td style="width: 34px;">
                                        <span class="normaltext" style="font-size: 9px;">
                                            <%=objLanguage.GetLanguageConversion("Horiz") %></span>
                                    </td>
                                    <td style="width: 35px;">
                                        <asp:TextBox ID="txtGutterHorizontal" Width="55px" SkinID="textPad" runat="server"
                                            Style="margin-left: 1px;" MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                                    </td>
                                    <td>
                                        <font class="SpanFontSize">
                                            <%=PaperMeasure %></font>
                                    </td>
                                    <td style="width: 34px;">
                                        <span class="normaltext" style="font-size: 9px;">
                                            <%=objLanguage.GetLanguageConversion("Vert") %></span>
                                    </td>
                                    <td style="width: 35px;">
                                        <asp:TextBox ID="txtGutterVertical" Width="55px" SkinID="textPad" runat="server"
                                            Style="margin-left: 1px;" MaxLength="20" onclick="javascript:Calculations();"></asp:TextBox>
                                    </td>
                                    <td>
                                        <font class="SpanFontSize">
                                            <%=PaperMeasure %></font>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="div_GutterCheckBox" style="float: left; padding: 2px 0px 2px 0px; clear: right; margin-left: 1px;">
                        <asp:CheckBox ID="chkGutters" onclick="javascript:GuttersCustom(this.id);Calculations();setwidth();"
                            runat="server" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabelnewLargeEmpty">
                    </div>
                    <div align="center">
                        <span id="spn_txtGutterHorizontal_number" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span><span
                                id="spn_txtGutterHorizontal" class="spanerrorMsg" style="display: none; width: 185px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Include_Gutters") %></span>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label25" runat="server" Text="Apply Press Restrictions" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box" style="padding: 2px 0px 0px 1px;">
                        <asp:CheckBox ID="ChkPressRestrictions" runat="server" onclick="javascript:Calculations();"
                            Checked="true" />
                    </div>
                </div>
                <div class="onlyEmpty" style="height: 1px;">
                </div>
                <div id="div_booklet_NoOfSignatures" align="left" style="display: none; white-space: nowrap;">
                    <div align="left">
                        <div class="bglabel">
                            <asp:Label ID="Label19" runat="server" Text="Booklet Pages Per Print Sheet" CssClass="normaltext"></asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtPagesPerSignature" SkinID="textPad" runat="server" MaxLength="8"
                                Width="75px" ReadOnly="false"></asp:TextBox>
                            <span id="spn_txtPagesPerSignatureNumber" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value") %></span>
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
                <div id="div_PrintLayout" align="left" style="margin-top: -0.6px;">
                    <div id="div_PrintLayoutWithoutButtons">
                        <div class="bglabel" style="height: 35px;">
                            <div align="left" style="height: 15px;">
                                <div style="float: left;">
                                    <asp:Label ID="Label20" runat="server" Text="Print Layout" CssClass="normaltext"></asp:Label>
                                </div>
                                <div style="float: right;">
                                    <a href="javascript://" style="cursor: pointer;" onclick="popup_layout();">
                                        <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                                </div>
                            </div>
                            <div class="classEmpty">
                                <span class="smalldarkgraytext">(<%=objLanguage.GetLanguageConversion("Showing_Calculation_For_Qty1")%>)</span>
                            </div>
                        </div>
                        <div style="float: left; width: auto; white-space: nowrap;">
                            <div style="width: auto;">
                                <div style="float: left; width: 85px">
                                    <asp:CheckBox ID="chkPortrait" Checked="true" onclick="javascript:PrintLayout('portrait',this.id);If_Port_Ticked(this.checked);"
                                        Text="Portrait" runat="server" />
                                </div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtportrait" Width="75px" SkinID="textPad" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:HiddenField ID="hdn_PortraitValue" runat="server" Value="0" />
                                </div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtPortLength" Width="75px" Style="display: none;" SkinID="textPad"
                                        runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div style="float: left;">
                                    <asp:Label ID="lblPortraitLength" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                                </div>
                            </div>
                            <div class="onlyEmpty" style="height: 2px;">
                            </div>
                            <div style="width: auto;">
                                <div style="float: left; width: 85px">
                                    <asp:CheckBox ID="chkLandscape" onclick="javascript:PrintLayout('landscape',this.id);If_Land_Ticked();"
                                        Text="Landscape " runat="server" />
                                </div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtlandscape" Width="75px" SkinID="textPad" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:HiddenField ID="hdn_LandscapeValue" runat="server" Value="0" />
                                    <input type="hidden" value="0" id="hdnrow_land" />
                                    <input type="hidden" value="0" id="hdncol_land" />
                                    <input type="hidden" value="0" id="hdnrow_port" />
                                    <input type="hidden" value="0" id="hdncol_port" />
                                    <input type="hidden" value="0" id="hdntype" />
                                    <input type="hidden" value="0" id="hdnselected" />
                                    <input type="hidden" value="0" id="hdnvertical" />
                                    <input type="hidden" value="0" id="hdnhorizontal" />
                                    <asp:HiddenField runat="server" ID="hdnProtrait" Value="0" />
                                    <asp:HiddenField runat="server" ID="hdnLandscale" Value="0" />
                                </div>
                                <div style="float: left;">
                                    <asp:TextBox ID="txtLandLength" Width="75px" Style="display: none;" SkinID="textPad"
                                        runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div style="float: left;">
                                    <asp:Label ID="lblLandscapeLength" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div class="EmptybglabelnewLarge">
                            <div class="box">
                                <asp:Label ID="lblLengthRequired" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                            </div>
                        </div>
                        <div id="div_itemSize" align="left" style="display: none;">
                            <div class="bglabel" style="height: 35px;">
                                <div align="left">
                                    <asp:Label ID="lblItemSize" runat="server" CssClass="normaltext"></asp:Label>
                                </div>
                                <div class="classEmpty">
                                    <span class="smalldarkgraytext">(<%=objLanguage.GetLanguageConversion("Showing_Calculation_For_Qty1")%>)</span>
                                </div>
                            </div>
                            <div class="box">
                                <div style="float: left;">
                                    <asp:TextBox ID="txt_ItemSize" Width="75px" SkinID="textPad" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div style="float: left; padding-left: 3px;">
                                    <asp:Label ID="lblSqItemSIze" runat="server" Style="font-size: 9px;" CssClass="normaltext"></asp:Label>
                                </div>
                            </div>


                            <div class="box">
                                <asp:CheckBox ID="chkUSeFullSheets" Checked="false" onclick="javascript:Calculations();"
                                    Text="use full sheets" runat="server" />
                            </div>



                        </div>
                        <div class="onlyEmpty">
                        </div>

                        <div align="left">
                            <div class="bglabel" style="height: 30px;">
                                <div style="float: left;">
                                    <asp:Label ID="Label26" runat="server" Text="Guillotine" CssClass="normaltext"></asp:Label>
                                </div>
                                <div style="float: right;">
                                    <a href="javascript://" style="cursor: pointer;" onclick="GuillotineSelect();return false;">
                                        <img src="<%=strImagepath %>plus.gif" border="0" />
                                    </a>
                                </div>
                            </div>
                            <div class="box" style="float: left;">
                                <div align="left" style="overflow: hidden; white-space: nowrap; width: 260px;">
                                    <asp:Label ID="lblGuillotine" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                                </div>
                                <div align="left" id="div_guillotine_trim" style="display: none">
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
                                <asp:Label ID="Label2" runat="server" Text="Update Item Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_Description") %></asp:Label>
                                <a id="img_UpdateDescription" runat="server" href="javascript:void(0);" cssclass="tooltip"
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
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>

                    <div align="left">
                        <div class="only10px">
                        </div>
                        <div class="only10px">
                        </div>
                        <div class="bglabelnewLargeEmpty">
                        </div>
                        <div style="float: left; white-space: nowrap; width: 100%" nowrap="nowrap">
                            <div class="bglabel" style="visibility: hidden">
                            </div>
                            <div class="box" style="width: 160px; float: left; padding-left: 170px;">
                                <div style="float: left;">
                                    <table>
                                        <tr>
                                            <td>
                                                <div style="float: left;">
                                                    <div id="div_btnprev" style="display: block">
                                                        <asp:Button ID="btnPrevious" CssClass="button" OnClick="btnPrevious_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_prevprocess');"
                                                            Text="Previous" runat="server" />
                                                    </div>
                                                    <div id="div_prevprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div style="float: left; width: 2px">
                                                    &nbsp;
                                                </div>
                                            </td>
                                            <td>
                                                <div style="float: left;">
                                                    <div id="div_btnsave" style="display: block">
                                                        <asp:Button ID="btnSave" CssClass="button" Text="Finish" runat="server" OnClick="btnSave_OnClick"
                                                            OnClientClick="javascript:var a=Large_Validation();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
                                                    </div>
                                                    <div id="div_saveprocess" class="button" style="display: none; width: 32px; height: 14px;">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</div>--%>
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
<asp:HiddenField ID="hid_Row" Value="" runat="server" />
<asp:HiddenField ID="hid_Col" Value="" runat="server" />
<asp:HiddenField ID="hid_width" Value="" runat="server" />
<asp:HiddenField ID="hid_height" Value="" runat="server" />
<asp:HiddenField ID="hid_IsJobCustom" Value="" runat="server" />
<asp:HiddenField ID="hid_IsSheetCustom" Value="" runat="server" />
<asp:HiddenField ID="hdnedit_Default" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPressID" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID2" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID3" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID4" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldPaperID5" Value="0" runat="server" />
<asp:HiddenField ID="hdnOldGuillotineID" Value="0" runat="server" />
<asp:HiddenField ID="hdn_InvpaperID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_InvpaperID2" runat="server" Value="0" />
<asp:HiddenField ID="hdn_InvpaperID3" runat="server" Value="0" />
<asp:HiddenField ID="hdn_InvpaperID4" runat="server" Value="0" />
<asp:HiddenField ID="hdn_InvpaperID5" runat="server" Value="0" />
<asp:HiddenField ID="hdn_invStockBack" runat="server" Value="" />
<asp:HiddenField ID="hdn_invStockReduce" runat="server" Value="" />
<script>

    if (document.getElementById("divhrefQtyMore").style.display == "none") {
        if (modulename == "estimates") {
            document.getElementById("divhrefQtyMore").style.display = "block";
            //alert("hello");
        }
        else {
            //alert("hi");
            document.getElementById("divhrefQtyMore").style.display = "none";
        }
    }
    var estimateType = '';
    var productType = '';
    var QtyForCalculate = 0;

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
    var divPrintQualityDPI = 'divPrintQualityDPI';
    // var div_Ink_Coverage = 'div_InkCoverage';

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
    var PaperTypeNew = '<%=PaperType %>';

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
    var lblLengthRequired = document.getElementById("<%=lblLengthRequired.ClientID %>");
    var lblSqItemSIze = document.getElementById("<%=lblSqItemSIze.ClientID %>");
    var RequestType = '<%=Request.QueryString["type"]%>';


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

        if (LargeFormatCalculation.toLowerCase() != 'tilling') {
            if (G_CalculateInventorySheet('l', Number(Height), Number(Width)) == 0 && (Height != undefined && Height != null)) {
                alert('<%=objLanguage.GetLanguageConversion("Select_Smaller_Print_Sheet_Size_Or_Larger_Paper_Line_From_Inventory") %>');
                return false;
            }
        }
        var papertype = document.getElementById("spnPaperType").innerHTML;
        if (LargeFormatCalculation.toLowerCase() != 'tilling') {
            if (trim12(PaperTypeNew).toLowerCase() != 'sheet') {
                if (Check_Width_Height_For_Roll() == false) {
                    alert('<%=objLanguage.GetLanguageConversion("Select_Smaller_Print_Sheet_Size_Or_Larger_Paper_Line_From_Inventory") %>');
                    return false;
                }
            }
            if (chkGutters.checked == true || ChkPressRestrictions.checked == true) {
                if (Number(txtsectionheight.value) == Number(txtitemheight.value) || Number(txtsectionwidth.value) == Number(txtitemwidth.value)) {
                    alert('<%=objLanguage.GetLanguageConversion("Print_SheetSize_Selection_Note") %>');
                    return false;
                }
            }
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
    var hid_LargeFormatPress = document.getElementById("<%=hid_LargeFormatPress.ClientID %>");
    var hid_DefaultLargePress = document.getElementById("<%=hid_DefaultLargePress.ClientID %>");

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

    var hdnpaperID = document.getElementById("<%=hdnpaperID.ClientID %>");
    var hdnpaperID2 = document.getElementById("<%=hdnpaperID2.ClientID %>");
    var hdnpaperID3 = document.getElementById("<%=hdnpaperID3.ClientID %>");
    var hdnpaperID4 = document.getElementById("<%=hdnpaperID4.ClientID %>");
    var hdnpaperID5 = document.getElementById("<%=hdnpaperID5.ClientID %>");

    var lbl_paper2 = document.getElementById("<%=lbl_paper2.ClientID %>");
    var lbl_paper3 = document.getElementById("<%=lbl_paper3.ClientID %>");
    var lbl_paper4 = document.getElementById("<%=lbl_paper4.ClientID %>");
    var lbl_paper5 = document.getElementById("<%=lbl_paper5.ClientID %>");

    var lblPaperWt2 = document.getElementById("<%=lblPaperWt2.ClientID %>");
    var lblPaperWt3 = document.getElementById("<%=lblPaperWt3.ClientID %>");
    var lblPaperWt4 = document.getElementById("<%=lblPaperWt4.ClientID %>");
    var lblPaperWt5 = document.getElementById("<%=lblPaperWt5.ClientID %>");

    var hdn_PaperProperties2 = document.getElementById("<%=hdn_PaperProperties2.ClientID %>");
    var hdn_PaperProperties3 = document.getElementById("<%=hdn_PaperProperties3.ClientID %>");
    var hdn_PaperProperties4 = document.getElementById("<%=hdn_PaperProperties4.ClientID %>");
    var hdn_PaperProperties5 = document.getElementById("<%=hdn_PaperProperties5.ClientID %>");
    var Chk_PriceForWholePack1 = document.getElementById("<%=Chk_PriceForWholePack1.ClientID %>");
    var Chk_PriceForWholePack2 = document.getElementById("<%=Chk_PriceForWholePack2.ClientID %>");
    var Chk_PriceForWholePack3 = document.getElementById("<%=Chk_PriceForWholePack3.ClientID %>");
    var Chk_PriceForWholePack4 = document.getElementById("<%=Chk_PriceForWholePack4.ClientID %>");
    var Chk_PriceForWholePack5 = document.getElementById("<%=Chk_PriceForWholePack5.ClientID %>");
    var Chk_PaperSupplied1 = document.getElementById("<%=Chk_PaperSupplied1.ClientID %>");
    var Chk_PaperSupplied2 = document.getElementById("<%=Chk_PaperSupplied2.ClientID %>");
    var Chk_PaperSupplied3 = document.getElementById("<%=Chk_PaperSupplied3.ClientID %>");
    var Chk_PaperSupplied4 = document.getElementById("<%=Chk_PaperSupplied4.ClientID %>");
    var Chk_PaperSupplied5 = document.getElementById("<%=Chk_PaperSupplied5.ClientID %>");
    var Img_delete = document.getElementById("Img_delete");
    var Img_delete2 = document.getElementById("Img_delete2");
    var Img_delete3 = document.getElementById("Img_delete3");
    var Img_delete4 = document.getElementById("Img_delete4");
    var Img_delete5 = document.getElementById("Img_delete5");
    var Img_delete5 = document.getElementById("Img_delete5");
    var paperheading = document.getElementById("paperheading");
    var div_WholePack = document.getElementById("div_WholePack");
    var div_Supplied = document.getElementById("div_Supplied");


    var div_PriceForWholePack1 = document.getElementById("div_PriceForWholePack1");
    var div_PriceForWholePack2 = document.getElementById("div_PriceForWholePack2");
    var div_PriceForWholePack3 = document.getElementById("div_PriceForWholePack3");
    var div_PriceForWholePack4 = document.getElementById("div_PriceForWholePack4");
    var div_PriceForWholePack5 = document.getElementById("div_PriceForWholePack5");
    var div_PaperSupplied1 = document.getElementById("div_PaperSupplied1");
    var div_PaperSupplied2 = document.getElementById("div_PaperSupplied2");
    var div_PaperSupplied3 = document.getElementById("div_PaperSupplied3");
    var div_PaperSupplied4 = document.getElementById("div_PaperSupplied4");
    var div_PaperSupplied5 = document.getElementById("div_PaperSupplied5");
    var spn_setupSpoilage = document.getElementById("spn_setupSpoilage");

    var hdn_PaperProperties = document.getElementById("<%=hdn_PaperProperties.ClientID %>");

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
    //FOR ROLL
    var txtPortLength = document.getElementById("<%=txtPortLength.ClientID %>");
    var txtLandLength = document.getElementById("<%=txtLandLength.ClientID %>");
    var txt_ItemSize = document.getElementById("<%=txt_ItemSize.ClientID %>");



    //Large Format
    var ddlQualitySector = document.getElementById("<%=ddlQualitySector.ClientID %>");
    var txtInkCoverageSide1 = document.getElementById("<%=txtInkCoverageSide1.ClientID %>");
    var txtInkCoverageSide2 = document.getElementById("<%=txtInkCoverageSide2.ClientID %>");

    var txtWhiteInkCoverageSide1 = document.getElementById("<%=txtWhiteInkCoverageSide1.ClientID %>");
    var txtWhiteInkCoverageSide2 = document.getElementById("<%=txtWhiteInkCoverageSide2.ClientID %>");


    var hid_Row = document.getElementById("<%=hid_Row.ClientID %>");
    var hid_Col = document.getElementById("<%=hid_Col.ClientID %>");


    var hid_IsSheetCustom = document.getElementById("<%=hid_IsSheetCustom.ClientID %>");
    var hid_IsJobCustom = document.getElementById("<%=hid_IsJobCustom.ClientID %>");
    var hdnedit_Default = document.getElementById("<%=hdnedit_Default.ClientID %>");

    //Paper/Stock add

    var divpaperstock2 = document.getElementById("<%=divpaperstock2.ClientID %>");
    var divpaperstock3 = document.getElementById("<%=divpaperstock3.ClientID %>");
    var divpaperstock4 = document.getElementById("<%=divpaperstock4.ClientID %>");
    var divpaperstock5 = document.getElementById("<%=divpaperstock5.ClientID %>");
    var divaddmorepaper = document.getElementById("<%=divaddmorepaper.ClientID %>");

</script>
<%-- CODING PART END--%>
<script>
    function calc(val) {

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
                //alert("gutter");
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
                //alert(C);
                col = C;
                D = Number(ASH) + Number(VtGutter.value);
                E = Number(D) / (Number(IW.value) + Number(VtGutter.value));
                F = parseInt(E);
                //alert(F);
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
                //alert(ASH);
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

    var RS = document.getElementById("<%=txtRunningSpoilage.ClientID %>");
    var SS = document.getElementById("<%=txtSetupSpoilage.ClientID %>");

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

    var Row_Print = 0;
    var Col_Print = 0;
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
        else {
            hdntype.value = "portrait";
            row = row_port.value;
            col = col_port.value;

        }

        if ((SH.value != "") && (SW.value != "") && (IH.value != "") && (IW.value != "")) {
            if (row == 0 || col == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Print_Layout_Should_Not_Be_Zero")%>');

            }
            else {
                if (PaperTypeNew == 'roll' || PaperTypeNew == 'web printing') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>print_layout_large_roll.aspx?SH=" + SH.value + "&SW=" + SW.value + "&IH=" + IH.value + "&IW=" + IW.value + "&type=" + hdntype.value + "&selected=" + hdnselected.value + "&row=" + row + "&col=" + col + "&vg=" + hdnvertical.value + "&hg=" + hdnhorizontal.value + "&nonHeight=" + NonHeight + "&nonWidth=" + NonWeight + "&esttype=L&qty=" + txtQuantity.value + "&Row_Print=" + Row_Print + "&Col_Print=" + Col_Print + "", '', '1000', '500');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else {
                    window.radopen("<%=nmsCommon.global.sitePath()%>print_layout_large.aspx?SH=" + SH.value + "&SW=" + SW.value + "&IH=" + IH.value + "&IW=" + IW.value + "&type=" + hdntype.value + "&selected=" + hdnselected.value + "&row=" + row + "&col=" + col + "&vg=" + hdnvertical.value + "&hg=" + hdnhorizontal.value + "&nonHeight=" + NonHeight + "&nonWidth=" + NonWeight + "&esttype=L&qty=" + txtQuantity.value + "&Row_Print=" + Row_Print + "&Col_Print=" + Col_Print + "", '', '1000', '500');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
            }
        }
        else {
            alert('<%=objLanguage.GetLanguageConversion("Print_Layout_Should_Not_Be_Zero") %>');
        }
    }

    var hid_singleData = document.getElementById("<%=hid_singleData.ClientID %>");
    var hid_booklet_save = document.getElementById("<%=hid_booklet_save.ClientID %>");
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/large_item.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">

    estimateType = "largeformat";
    ShowEstimate('largeformat');
    //moreQty('single');
    if (modulename != "invoice" && modulename != "jobs" && modulename != "orders") {
        moreQty('more');
    }
    else {
        moreQty('single');
    }

    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    var modulename = "<%=modulename %>"
    if (modulename == "jobs") {
        hrefQtyMore.style.display = "none";
        hrefQtySingle.style.display = "none";
    }

</script>
<asp:Panel ID="pnlPadEdit" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        TakeValuesFromDB();

    </script>
</asp:Panel>

<script type="text/javascript" language="javascript">
    //this is done on 11/03/11 in job & invoice (it shows multiple qty text boxes which was created in Estimates).

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
            document.getElementById("div_qty12").style.display = "none";
            document.getElementById("div_Qty_2to4").style.display = "block";
            document.getElementById("div_qty3").style.display = "block";
        }
        else if (QtyNo == "4") {
            document.getElementById("div_qty1").style.display = "none";
            document.getElementById("div_Addmore").style.display = "none";
            document.getElementById("div_qty3").style.display = "none";
            document.getElementById("div_qty12").style.display = "none";
            document.getElementById("div_Qty_2to4").style.display = "block";
            document.getElementById("div_qty4").style.display = "block";
        }
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";

    }

    if (!ChkJobFlatCustom.checked) {
        hdnedit_Default.value = "1";
    }
    if (!chkPrintSheet.checked) {
        hdnedit_Default.value = "1";
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
        var hdn_InvpaperID2 = document.getElementById("<%=hdn_InvpaperID2.ClientID %>");
        var hdn_InvpaperID3 = document.getElementById("<%=hdn_InvpaperID3.ClientID %>");
        var hdn_InvpaperID4 = document.getElementById("<%=hdn_InvpaperID4.ClientID %>");
        var hdn_InvpaperID5 = document.getElementById("<%=hdn_InvpaperID5.ClientID %>");


        var InventoryManagement = '<%=InventoryManagement %>';
        var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
        var hdn_invStockBack = document.getElementById("<%=hdn_invStockBack.ClientID %>");
        var ReduceStockType = '<%=ReduceStockType %>';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        var reqtype = funreqtype();
        if (reqtype == 'edit') {
            var isMaterialChanged = false;

            if (hdn_InvpaperID.value != 0 && hdn_InvpaperID.value != hdnpaperID.value) {
                isMaterialChanged = true;
            }
            else if (hdn_InvpaperID2.value != 0 && hdn_InvpaperID2.value != hdnpaperID2.value) {
                isMaterialChanged = true;
            }
            else if (hdn_InvpaperID3.value != 0 && hdn_InvpaperID3.value != hdnpaperID3.value) {
                isMaterialChanged = true;
            }
            else if (hdn_InvpaperID4.value != 0 && hdn_InvpaperID4.value != hdnpaperID4.value) {
                isMaterialChanged = true;
            }
            else if (hdn_InvpaperID5.value != 0 && hdn_InvpaperID5.value != hdnpaperID5.value) {
                isMaterialChanged = true;
            }
            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (modulename.toLowerCase() == "jobs" || modulename.toLowerCase() == "invoice") {
                    if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p" && (isMaterialChanged)) {
                        if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                            hdn_invStockBack.value = "yes";
                        }
                        else { hdn_invStockBack.value = "no"; }
                    }
                }
            }
        }
        if (reqtype == 'add') {
            if (InventoryManagement.toString().toLowerCase() == "im") {
                if (modulename.toLowerCase() == "invoice") {
                    if (ReduceStockType.toString().toLowerCase() != "e" && ReduceStockType.toString().toLowerCase() != "i") {
                        //                        if (window.confirm('Do you want to reduce the inventory stock?')) {
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
    if (hdnpaperID.value == '' || hdnpaperID.value == '0') {
        Chk_PriceForWholePack1.style.display = "none";
        Chk_PaperSupplied1.style.display = "none";
        Chk_PriceForWholePack1.style.display = "none";
        Chk_PaperSupplied1.style.display = "none";

        Chk_PriceForWholePack2.style.display = "none";
        Chk_PaperSupplied2.style.display = "none";

        Chk_PriceForWholePack3.style.display = "none";
        Chk_PaperSupplied3.style.display = "none";

        Chk_PriceForWholePack4.style.display = "none";
        Chk_PaperSupplied4.style.display = "none";

        Chk_PriceForWholePack5.style.display = "none";
        Chk_PaperSupplied5.style.display = "none";
        paperheading.style.display = "none";
    }
    else {
        paperheading.style.display = "block";
        Chk_PriceForWholePack1.style.display = "block";
        Chk_PaperSupplied1.style.display = "block";
    }

    if (LargeFormatCalculation.toLowerCase() == 'square') {
        document.getElementById("div_itemSize").style.display = "block";
    }

    if (LargeFormatCalculation.toLowerCase() == 'tilling') {
        document.getElementById("div_PrintLayoutWithoutButtons").style.display = "none";
        document.getElementById("div_GutterLabel").style.display = "none";
        document.getElementById("div_GutterCheckBox").style.display = "none";
        document.getElementById("div_GuttersCustomSize").style.display = "none";
        
        var HrzGutter = document.getElementById("<%=txtGutterHorizontal.ClientID %>");
        //alert(HrzGutter.value);
        var VtGutter = document.getElementById("<%=txtGutterVertical.ClientID %>");
        HrzGutter.value = 0.00;
        VtGutter.value = 0.00;
        chkGutters.checked = false;

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
        document.getElementById('div_saveprocess').style.display = 'block';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        hdn_invStockReduce.value = val;
        document.getElementById('div_AlertPopup').style.display = "none"
        document.getElementById('divBackGroundNew').style.display = "none";
        __doPostBack('ctl00$ContentPlaceHolder1$UcLargeItem$btnSave', '');
    }
</script>
<script type="text/javascript" language="JavaScript">
    $(document).ready(function () {
        Calculations();//By Khaleel Ur Rehman Ticket 71229
        // In Firefox, the true version is after "Firefox" 
        var browsername = (function () {
            var N = navigator.appName, ua = navigator.userAgent, tem;
            var M = ua.match(/(opera|chrome|safari|firefox|msie)\/?\s*(\.?\d+(\.\d+)*)/i);
            if (M && (tem = ua.match(/version\/([\.\d]+)/i)) != null) M[2] = tem[1];
            M = M ? [M[1]] : [N, navigator.appVersion, '-?'];
            return M;
        })();
        if ((browsername.indexOf("Firefox", [0]) != -1)) {
            var div_qty3 = document.getElementById("div_qty3").style.width = "142px";
            document.getElementById("div_lblinkcovside1").style.height = "21px";
            document.getElementById("div_Stock").style.marginTop = "-16px";
            document.getElementById("div_defaultpaper").style.marginTop = "-12px";
            document.getElementById("div_Supplied").style.marginTop = "-10px";
        }
    });
</script>
