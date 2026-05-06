<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalogueItem_Stock.ascx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogueItem_Stock" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script type="text/javascript" src="../js/item/autosugst.js?VN='<%=VersionNumber%>'" language="javascript"></script>--%>
<script type="text/javascript" src="../js/item/AutoFill.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../common/swazz_calendar.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script src="<%=strSitePath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<link href="<%=strSitePath %>css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Jquery-1.11.1.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/Jquery-ui-1.11.0.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../js/item/pricecatalogfeatures.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<link href="../css/jquery-ui-ePrint.css" rel="stylesheet" type="text/css" />
<script>
    var Pgtype = '<%=PageType %>';
</script>
<style type="text/css">
    .divGridstyle {
        margin: 0px 10px 0px 10px;
    }

    #div_popupAction {
        display: none;
        z-index: 999999;
        position: absolute;
        margin: 34px 0px 0px 13px;
    }
</style>
<div>
    <div id="dialog-confirm" style="display: none;">
        <p>
            <span style="float: left; margin: 0 7px 20px 0;">You have a negative stock allocation in a different location, Do you still want to add stock to this location?.</span>
        </p>
    </div>
    <div id="div_stockmanagement" style="position: absolute; margin-top: -14px; width: 99%; left: 0px;">
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="Div_StockSettings" align="left">
            <div style="float: left; margin-left: 6px; padding-top: 5px; width: 100%;">
                <div style="float: left">
                    <asp:Label ID="lbldrawstock" runat="server" CssClass="bglabel" Width="185px"><span class="normaltext"><%=objLanguage.GetLanguageConversion("Draw_Stock_From")%></span></asp:Label>
                </div>
                <div class="box" style="margin-top: 2px; width: 22%">
                    <asp:RadioButtonList ID="rdbdraw" onchange="javascript:stockonchange(this.id);" runat="server"
                        Style="display: none">
                        <asp:ListItem Value="self" Text="Self" Selected="True">Self</asp:ListItem>
                        <asp:ListItem Value="otherproducts">Other Products</asp:ListItem>
                        <asp:ListItem Value="additionaloptions">Additional Options</asp:ListItem>
                        <asp:ListItem Value="othermultiple">Other multiple existing products </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="ddldrawstockfrom" onchange="javascript:stockonchange(this.id);"
                        Width="200px" runat="server" CssClass="normaltext">
                        <asp:ListItem Value="select" Text="Select" Selected="True">Select</asp:ListItem>
                        <asp:ListItem Value="self" Text="Self">This Product</asp:ListItem>
                        <asp:ListItem Value="otherproducts">Other Products</asp:ListItem>
                        <asp:ListItem Value="additionaloptions">Additional Options</asp:ListItem>
                        <asp:ListItem Value="othermultiple">Other multiple existing products </asp:ListItem>
                        <asp:ListItem Value="simplestock">Simple Stock </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lbldrawstocktext" runat="server" Style="display: none; margin-top: 0px; margin-left: 1px"></asp:Label>
                </div>
                <span id="spndrawstockfromalert" class="RFV_Message" style="display: none; width: 274px; margin-left: -62px; float: left;">
                    <%=objLanguage.GetLanguageConversion("Please_select_option_to_draw_stock_from")%></span>
                <div id="div_currentstock" runat="server" style="display: none; float: left; margin-top: -8px; width: 50%; margin-left: -30px;">
                    <div id="div_fieldset" runat="server" style="float: left; width: 98%;" align="left">
                        <fieldset>
                            <legend>
                                <%=objLanguage.GetLanguageConversion("Current_Stock_Levels")%>
                            </legend>
                            <table width="40%" style="border-collapse: collapse; border: 1px solid #CCCCCC">
                                <tr style="background-color: #DDDDDD; height: 20px;">
                                    <td id="tdlblcurrentstockstock" runat="server">
                                        <%=objLanguage.GetLanguageConversion("Quantity_on_Hand")%>
                                        <div id="div_stockadddet" runat="server" style="display: inline">
                                            <asp:ImageButton ID="btnaddionalstocklevel" runat="server" ToolTip="View detailed stock details"
                                                OnClientClick="return View_detailed_stock_details();" Style="margin-left: 12px;"
                                                ImageUrl="~/images/plus.gif" />
                                        </div>
                                    </td>
                                    <td id="tdlblallocatedstock" runat="server">
                                        <%=objLanguage.GetLanguageConversion("Allocated_Stock")%>
                                    </td>
                                    <td id="tdlblproductionqty" runat="server">
                                        <%=objLanguage.GetLanguageConversion("Outwork_Production_Qty")%>
                                    </td>
                                    <td>
                                        <%=objLanguage.GetLanguageConversion("Available_Stock")%>
                                    </td>
                                </tr>
                                <tr style="background-color: #EFEFEF; height: 22px;">
                                    <td id="tdtxtcurrentstock" runat="server">
                                        <asp:TextBox ID="txtcurrentstock" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
                                    </td>
                                    <td id="tdtxtallocatedstock" runat="server">
                                        <asp:TextBox ID="txtallocatedstock" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
                                    </td>
                                    <td id="tdtxtproductionqty" runat="server">
                                        <asp:TextBox ID="txtproductionquantity" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtavailstock" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                </div>
                <table  style="border-collapse: collapse; border: 1px solid #CCCCCC;display:none" runat="server" id="tblSimpleStock">
                    <tr style="background-color: #DDDDDD; height: 20px;">

                        <td>
                            <%=objLanguage.GetLanguageConversion("Available_Stock")%>
                        </td>
                    </tr>
                    <tr style="background-color: #EFEFEF; height: 22px;">

                        <td>
                            <asp:TextBox ID="txtSimpleQuantity" runat="server" Width="150px" CssClass="textboxnew" onblur="javascript:checkforInteger(this.id,this.value);"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <ajaxToolkit:CollapsiblePanelExtender ID="cde" runat="server" TargetControlID="pnlpopup"
                    CollapsedSize="0" ExpandedSize="200" ScrollContents="true" ExpandControlID="div_stockadddet"
                    CollapseControlID="div_stockadddet" AutoExpand="false" AutoCollapse="false" Collapsed="true"
                    ExpandDirection="Vertical">
                </ajaxToolkit:CollapsiblePanelExtender>
                <div id="div_popupAction" style="display: none; background-color: White; width: 60%; margin-left: 468px; margin-top: 62px; z-index: 999999;">
                    <asp:Panel ID="pnlpopup" Style="box-shadow: 0px 0px 10px #7F7F7F" runat="server">
                        <asp:PlaceHolder ID="plhadditionalstockdetails" runat="server"></asp:PlaceHolder>
                    </asp:Panel>
                </div>
                <div align="right" style="float: right;">
                    <asp:LinkButton ID="lnkviewhistory" runat="server" Style="text-decoration: underline; padding-right: 10px;"
                        ForeColor="#10357F" OnClientClick="javascript:slideIt('div_stockmanagement');return false;">
                        <span class="normaltext" style="font-size:11px;"><%=objLanguage.GetLanguageConversion("View_History")%></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkView_ProductCatalougeitemStockHistory" runat="server" Style="text-decoration: underline;"
                        ForeColor="#10357F" OnClientClick="javascript:ViewStockAllocation_ProductCatalougeitemStockHistory();return false;">
                        <span class="normaltext" style="font-size:11px;"><%=objLanguage.GetLanguageConversion("View_Allocation")%></span>
                    </asp:LinkButton>
                    <%--Modification By Bilal Stage 3.5--%>
                    <br />
                    <br />
                    <asp:LinkButton ID="lnkView_ProductCatalougeitemStockPO" runat="server" Style="text-decoration: underline;"
                        ForeColor="#10357F" OnClientClick="javascript:ViewStockAllocation_ProductCatalougeitemStockPO();return false;">
                        <span class="normaltext" style="font-size:11px;margin-right: 60px; "><%=objLanguage.GetLanguageConversion("View_PO")%></span>
                    </asp:LinkButton>
                </div>
            </div>
            <div style="width: 100%; height: 10px">
            </div>
            <div align="left" id="div_selfpnl" runat="server" style="width: 100%; float: left; display: block;">
                <div style="width: 100%; padding-top: 5px; padding-top: 5px" runat="server" id="divStockAdjustment">
                    <div style="float: right; width: 100%;" align="left">
                        <fieldset>
                            <legend>
                                <%=objLanguage.GetLanguageConversion("Stock_Activity")%></legend>
                            <div id="div_stockactivity" runat="server" style="float: left; padding-top: 5px; width: 100%; display: none;">
                                <div style="float: left">
                                    <asp:Label ID="Label1" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Stock_Activity")%></asp:Label>
                                </div>
                                <div class="box" style="width: 20%;">
                                    <asp:DropDownList ID="ddlstkactivity" CssClass="normaltext" runat="server" onchange="javascript:displayactivity();"
                                        Width="200px">
                                        <asp:ListItem Text="Add" Value="add" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Release" Value="release"></asp:ListItem>
                                        <asp:ListItem Text="Adjustments" Value="adjustments"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="Note1" class="box" align="left" style="color: Gray; font-size: 10px; display: none;">
                                    <asp:Label ID="Notetext1" runat="server"><%=objLanguage.GetLanguageConversion("Explanation_text1_For_Releasestock")%></asp:Label>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_Addstock" style="float: left; width: 100%; padding-top: 5px" align="left">
                                <div align="left" class="borderWithoutTop" style="width: 99%; margin-left: 4px;">
                                    <asp:PlaceHolder ID="plhstock" runat="server"></asp:PlaceHolder>
                                </div>
                                <asp:HiddenField ID="hdnfld" runat="server" />
                                <div align="right" style="width: 100%; margin-left: -10px">
                                    <asp:HiddenField ID="hdnloc" runat="server" />
                                    <asp:LinkButton ID="lnkaddrow" runat="server" Text="Add More" OnClientClick="javascript:return addingrowself('tblstock','ctl00_ContentPlaceHolder1_ctl00_hdnfld');"><%=objLanguage.GetLanguageConversion("Add_More")%></asp:LinkButton>
                                </div>
                            </div>
                            <div id="div_Release" style="float: left; padding-top: 5px; width: 100%; display: none">
                                <div style="float: left">
                                    <asp:Label ID="lbljobref" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Job_Reference")%><span style="color:Red;"> *</span></asp:Label>
                                </div>
                                <div class="box" style="width: 20%;">
                                    <asp:TextBox ID="txtjobref" runat="server" Width="100px" CssClass="textboxnew"></asp:TextBox>
                                </div>
                                <div id="Note2" class="box" align="left" style="color: Gray; font-size: 10px; display: none;">
                                    <asp:Label ID="Notetext2" runat="server"><%=objLanguage.GetLanguageConversion("Explanation_text2_For_Releasestock")%></asp:Label>
                                </div>
                                <div style="width: 100%; float: left">
                                    <div style="float: left">
                                        <asp:Label ID="lblrefqty" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Quantity") %></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="txtrefqty" Width="100px" Style="text-align: right" runat="server"
                                            onblur="javascript:validaterefqty(this.value,'spnreferror',this.id);" Text="0"
                                            CssClass="textboxnew"></asp:TextBox><br />
                                        <div id="spnreferror" style="display: none; width: 150px; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="div_Adjustments" style="float: left; padding-top: 5px; width: 100%; display: none">
                                <div style="float: left">
                                    <asp:Label ID="Label4" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Adjustment_Type")%></asp:Label>
                                </div>
                                <div class="box">
                                    <asp:DropDownList ID="ddladjustment" CssClass="normaltext" runat="server" Width="200px">
                                        <asp:ListItem Text="Damaged" Value="Damaged" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Returned" Value="Returned"></asp:ListItem>
                                        <asp:ListItem Text="Loss In Transit" Value="LossinTransit"></asp:ListItem>
                                        <asp:ListItem Text="Stock Recalculation" Value="StockRecalculation"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="borderWithoutTop" style="width: 99%; margin-top: 6px; float: left;">
                                    <asp:PlaceHolder ID="plhAdjustments" runat="server"></asp:PlaceHolder>
                                </div>
                                <div style="width: 100%; float: left">
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <%--collapsible--%>
                <div style="clear: both; height: 6px">
                </div>
                <%--     <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="1275px" Height="100%"
                        ExpandMode="MultipleExpandedItems" Skin="Default" Style="margin-left: 5px"  CssClass="New">
                        <Items>
                            <telerik:RadPanelItem Text="Reorder Level & Alert Settings" Expanded="false" Font-Bold="true"
                                CssClass="rounded-ReportTopcorners" Selected="true">
                                <ContentTemplate>
                                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="New">
                                                <telerik:RadPageView runat="server"  ID="RadPageView2">
                                    <%--    <div style="width: 100%; padding-top: 5px; padding-top: 5px">--%>
                <div id="accordion" style="width: 100%">
                    <div class="divGridstyle">
                        <div>
                            <h3 class='HeaderText' onclick="javascript:setsavepos();" style="font-weight: bold; height: 23px">
                                <a href="#" style="color: Black">
                                    <%=objLanguage.GetLanguageConversion("Reorder_Level_Alert_Settings")%></a></h3>
                            <div style="border-top: 1px solid #AAAAAA;">
                                <div style="float: left; width: 40%; margin-left: -10px" align="left">
                                    <fieldset>
                                        <legend>
                                            <%=objLanguage.GetLanguageConversion("Re_Order_Level")%></legend>
                                        <div align="left">
                                            <div class="bglabel" style="width: 185px;">
                                                <asp:Label ID="Label46" CssClass="normaltext" Text="Re-Order Alert Level" runat="server"><%=objLanguage.GetLanguageConversion("ReOrder_Alert_Level")%></asp:Label>
                                            </div>
                                             
                                            <div class="box">
                                                <div style="width: 150px;">
                                                    <asp:TextBox ID="txtReorderLevel" SkinID="textpad" onblur="javascript:checkforInteger(this.id,this.value);"
                                                        runat="server" Text="0" MaxLength="8" CssClass="textboxnew1" Width="100px" Style="text-align: right"></asp:TextBox>
                                                </div>
                                                 
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtReorderLevel_number" style="float: left">
                                                    <div>
                                                        <span id="spnReorderLevel_int" class="RFV_Message" style="display: none; width: 150px; float: left; padding-left: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                        <span id="spnReorderLevel_req" class="RFV_Message" style="display: none; width: 174px; float: left; padding-left: 4px">Please enter Re-Order Level</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="width: 185px;">
                                                          <br />
                                                <asp:Label ID="lblMsgreorder" CssClass="normaltext" Text="Alerts will be sent at or below this number" runat="server"></asp:Label>
                                              </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 185px;">
                                                <asp:Label ID="Label47" CssClass="normaltext" Text="Re-Order Quantity" Width="160px"
                                                    runat="server"><%=objLanguage.GetLanguageConversion("ReOrder_Quantity")%></asp:Label>
                                            </div>
                                            
                                            <div class="box">
                                                <div style="width: 150px;">
                                                    <asp:TextBox ID="txtReorderQty" onblur="javascript:checkforInteger(this.id,this.value);"
                                                        SkinID="textpad" runat="server" Text="0" MaxLength="8" Width="100px" CssClass="textboxnew1"
                                                        Style="text-align: right"></asp:TextBox>
                                                </div>
                                                
                                                <div style="clear: both">
                                                </div>
                                                <div id="spn_txtReorderQty_number" style="display: none; width: 150px; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                    </div>
                                                </div>
                                                <div id="div_reorderqtyerror" style="display: none; width: 150px; float: left">
                                                    <div class="RFV_Message">
                                                        <span style="float: left; padding-left: 4px">Please enter reorder qty</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="width: 185px;">
                                                    <br />
                                                <asp:Label ID="lblMsgReorderQuantity" CssClass="normaltext" Text="Re-Order email will suggest ordering to this number" runat="server"></asp:Label>
                                              </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div style="float: right; width: 60%;" align="left">
                                    <fieldset>
                                        <legend>
                                            <%=objLanguage.GetLanguageConversion("Alerts")%></legend>
                                        <div align="left">
                                            <div class="bglabel" style="height: 70px">
                                                <asp:Label ID="Label11" CssClass="normaltext" Text="Alert the users " runat="server"><%=objLanguage.GetLanguageConversion("Alert_The_Users")%></asp:Label>
                                            </div>
                                            <div class="box" > <%--style="margin-left: -1.5px"--%>
                                                <asp:RadioButton ID="chkReorderLevelEveryTime" GroupName="alertgroup" Text="Once Only"
                                                    runat="server" />
                                            </div>
                                            <div class="box">
                                                <asp:RadioButton ID="chkReorderLevelDaily" GroupName="alertgroup" Text="Once per day until the stock is replenished"
                                                    runat="server" />
                                            </div>
                                            <div class="box">
                                                <asp:RadioButton ID="chkReorderLevelWeekly" GroupName="alertgroup" Text=" Once every 7 days until the stock is replenished"
                                                    runat="server" />
                                            </div>
                                            <div class="box">
                                                <asp:RadioButton ID="rdoNone" Text="Don't alert users" GroupName="alertgroup" onclick="javascript:rdoNone_checked(this.id);"
                                                    runat="server" Checked="true" />
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="height: 42px">
                                                <asp:Label ID="Label10" CssClass="normaltext" Text="Email address for alerts" runat="server"><%=objLanguage.GetLanguageConversion("Email_Address_For_Alerts")%></asp:Label>
                                            </div>
                                            <div class="box">
                                                <div style="width: 250px; margin-left: 2px">
                                                    <asp:TextBox ID="txtemail" TextMode="MultiLine" SkinID="textpad" Width="250px" Height="45px"
                                                        runat="server" Text="info@infomazeapps.com" MaxLength="500" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_To')">
                                                    </asp:TextBox>
                                                </div>
                                                <div class="smallgraytext" style="width: 300px; padding-top: 5px; padding-left: 2px">
                                                    <asp:Label ID="Label9" runat="server"><%=objLanguage.GetLanguageConversion("Multiple_Emali_Address_Note")%></asp:Label>
                                                </div>
                                                <span id="spn_To" class="spanerrorMsg" style="width: 200px; display: none">Please enter
                                                    valid email </span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" Visible="false"
                                                    ErrorMessage="Please Enter Email Id" ControlToValidate="txtemail" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div id="div_additionaloptnpnl" align="left" runat="server" style="width: 100%; float: left; display: none">
                <fieldset>
                    <legend>Stock Activity</legend>
                    <div id="additionalactivity" runat="server" style="float: left; padding-top: 5px; width: 100%; display: block;">
                        <div style="float: left">
                            <asp:Label ID="Label3" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Stock_Activity")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:DropDownList ID="ddl_additionalactivity" CssClass="normaltext" runat="server"
                                onchange="javascript:AdditionalStockOnChange();" Width="200px">
                                <asp:ListItem Text="Add" Value="add" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Release" Value="release"></asp:ListItem>
                                <asp:ListItem Text="Adjustments" Value="adjustments"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%--add case--%>
                    <div id="div_additionaladd" style="float: left; width: 100%; padding-top: 5px;" align="left">
                        <div id="divadditionalborder" align="left" style="width: 99%; margin-left: 4px; border-bottom: 1px solid #CCCCCC">
                            <asp:PlaceHolder ID="plhadditionaloptions" runat="server"></asp:PlaceHolder>
                        </div>
                        <div id="div_addlnk" runat="server" align="right" style="width: 100%; display: none; margin-left: -10px">
                            <asp:LinkButton ID="lnkaddmorelabel" runat="server" OnClientClick="javascript:return addmoreadditionaloption();"
                                Text="Add More"><%=objLanguage.GetLanguageConversion("Add_More")%></asp:LinkButton>
                        </div>
                        <div class="graytext" style="font-size: 9px; margin-top: 3px">
                            <asp:Label ID="lbladdoptnote" runat="server"><%=objLanguage.GetLanguageConversion("AdditionalOptions_Stock_Note")%> </asp:Label>
                        </div>
                    </div>
                    <%--release case--%>
                    <div id="div_additionalrelease" style="float: left; padding-top: 5px; width: 100%; display: none">
                        <div style="float: left">
                            <asp:Label ID="Label5" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Job_Reference")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:TextBox ID="txtadditionalrelease" runat="server" Width="100px" CssClass="textboxnew"></asp:TextBox>
                        </div>
                        <div style="width: 100%; float: left">
                            <div style="float: left">
                                <asp:Label ID="Label6" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Quantity") %></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtadditionalrefrenceqty" Width="100px" onblur="javascript:validaterefqty(this.value,'spnreferror',this.id);"
                                    Style="text-align: right" runat="server" CssClass="textboxnew"></asp:TextBox><br />
                                <div id="Div5" style="display: none; width: 150px; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--adjustments--%>
                    <div id="div_additionaladjustments" style="float: left; padding-top: 5px; width: 100%; display: none">
                        <div style="float: left">
                            <asp:Label ID="Label7" runat="server" CssClass="bglabel" Width="185px"><%=objLanguage.GetLanguageConversion("Adjustment_Type")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:DropDownList ID="ddladditionaladjtype" CssClass="normaltext" runat="server"
                                Width="200px">
                                <asp:ListItem Text="Damaged" Value="Damaged" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Returned" Value="Returned"></asp:ListItem>
                                <asp:ListItem Text="Loss In Transet" Value="LossInTranset"></asp:ListItem>
                                <asp:ListItem Text="Stock Recalculation" Value="StockRecalculation"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="borderWithoutTop" style="width: 100%; float: left; margin-top: 5px">
                            <asp:PlaceHolder ID="plhadditionaladjustments" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div id="div_otherproducts" align="left" style="width: 100%; float: left; margin-left: 5px; display: none;">
                <div id="div3" style="float: left; width: 70%; padding-top: 5px" align="left">
                    <div class="borderWithoutTop">
                        <asp:PlaceHolder ID="plhdrawotherproducts" runat="server"></asp:PlaceHolder>
                    </div>
                    <div align="right" style="width: 100%; margin-left: -10px">
                        <asp:LinkButton ID="lnkbtnadd" runat="server" Text="Add More" OnClientClick="javascript:return addOtherproductrow('tblother');"><%=objLanguage.GetLanguageConversion("Add_More")%></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div id="div_othermultiple" align="left" style="width: 100%; float: left; margin-left: 5px; display: none;">
                <div id="divchkMulti">
                    <asp:CheckBox ID="chkMultiDetail" runat="server" Checked="false" Text="In the eStore display sub products as a matrix table, rather than a drop down." />
                    <p>Please note sub products that use the large format price matrix will not work in the matrix table, they will only work using the drop down function.</p>
                </div>
                <div id="div2" style="float: left; width: 60%; padding-top: 5px" align="left">
                    <div class="borderWithoutTop">
                        <asp:PlaceHolder ID="plhothermultiple" runat="server"></asp:PlaceHolder>
                    </div>
                    <div align="right" style="width: 100%; margin-left: -10px">
                        <asp:LinkButton ID="lnkothadd" runat="server" Text="Add More" OnClientClick="javascript:return addOthermultiplerow('tblmultiple');"><%=objLanguage.GetLanguageConversion("Add_More")%></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 10px;" class="onlyEmpty">
        </div>
        <div id="div_savebtn" align="right" style="width: 100%; float: right; margin-right: 647px">
            <div style="float: right; margin-left: 6px; display: inline">
                <div style="float: right">
                    <asp:Button CssClass="button" ID="btnStockSave" OnClick="btnStockSave_Click" OnClientClick="validateval()" runat="server" Text="Save" />
                </div>
                <div id="div_saveprocess" style="display: none; float: right">
                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                </div>
            </div>
            <div style="float: right; display: inline">
                <div style="float: right">
                    <asp:Button CssClass="button" runat="server" ID="btnStockStay" Text="Save & Stay" OnClientClick="validateval()" OnClick="btnStockStay_Click" />
                </div>
                <div id="div_stayprocess" style="display: none; float: right">
                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                </div>
            </div>
        </div>
        <div style="width: 100%; height: 35px">
        </div>
        <%--   </div>--%>
    </div>
    <div id="div_StockHistory" align="left" style="width: 100%; height: auto; margin-top: -14px; right: 0px; position: absolute; display: none">
        <asp:Button ID="imgback" runat="server" CssClass="button" Style="margin-left: 7px"
            Text="Back" ToolTip="Back to Stock Management" OnClientClick="javascript:slidehistory('div_StockHistory');return false;" />
        <div id="padding">
            <asp:UpdatePanel ID="pnlgridAccountingCodes" runat="server">
                <ContentTemplate>
                    <telerik:RadGrid ID="grdInventoryHistory" runat="server" AutoGenerateColumns="false"
                        AllowSorting="false" PagerStyle-AlwaysVisible="true" AllowPaging="true" AllowCustomPaging="true"
                        OnNeedDataSource="grdInventoryHistory_NeedDataSource" OnItemDataBound="grdInventoryHistory_ItemDataBound" OnPageIndexChanged="grdInventoryHistory_PageIndexChanged"
                        GridLines="None" HeaderStyle-Font-Bold="true" AllowFilteringByColumn="true" ClientSettings-EnableRowHoverStyle="true" PageSize="20"
                        Width="100%">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <div id="DivExport" style="height: 30px">
                                    <a id="a1export" href="#" onclick="getrecord();" style="margin-left: 8px;">
                                        <asp:Label ID="Label12" ToolTip="Export" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/export-icon1.jpg"  />
                                        </asp:Label></a>
                                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; float: right; cursor: pointer; margin: 6px 4px 0px 0px"
                                        runat="server" OnClick="clrFilters_Click"
                                        Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                </div>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Date" ItemStyle-Width="15%" HeaderStyle-Width="15%"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataField="CreatedDate"
                                    SortExpression="CreatedDate" ItemStyle-Height="28px" FilterControlWidth="38%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="User Name" CurrentFilterFunction="Contains"
                                    AutoPostBackOnFilter="true" DataField="UserName" SortExpression="UserName" ItemStyle-Width="10%"
                                    HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnUser" runat="server" Value='<%#Eval("UserName")%>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Description" SortExpression="Description"
                                    AutoPostBackOnFilter="true" DataField="Description" CurrentFilterFunction="Contains"
                                    ItemStyle-Width="20%" HeaderStyle-Width="20%" FilterControlWidth="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label></br>
                                        <asp:Label ID="lblCustomDescription" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdn_Customdescription1" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField1", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_Customdescription2" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField2", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_Customdescription3" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField3", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_Customdescription4" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField4", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_Customdescription5" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField5", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_Customdescription6" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CustomField6", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_jobnumber" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.JobNumber", "{0}") %>' />
                                        <asp:HiddenField ID="hdn_estimateid" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.EstimateID","{0}") %>' />
                                        <asp:HiddenField ID="hdn_orderid" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.OrderID","{0}") %>' />
                                        <asp:HiddenField ID="hdn_deliveryid" runat="server" Value='<%# DataBinder.Eval(Container,"DataItem.DeliveryID","{0}") %>' />
                                        <asp:HiddenField ID="hdn_actiontype" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.ActionType","{0}") %>' />
                                        <asp:HiddenField ID="hdn_jobid" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.JobID","{0}") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Reference No" DataField="JobNumber" HeaderStyle-HorizontalAlign="Left"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ItemStyle-HorizontalAlign="Left"
                                    SortExpression="JobNumber" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreferenceno" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Transaction Quantity" DataField="Quantity"
                                    CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                    ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" SortExpression="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinalQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn DataField="StockInHand" HeaderStyle-HorizontalAlign="Right"
                                    AllowFiltering="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                    ItemStyle-Width="7%" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right"
                                    SortExpression="StockInHand" HeaderText="Quantity on Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstockQty" runat="server" Text='<%#Eval("StockInHand")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Allocated Stock" DataField="AllocatedStock"
                                    CurrentFilterFunction="Contains" AllowFiltering="false" AutoPostBackOnFilter="true"
                                    ItemStyle-Width="7%" HeaderStyle-Width="7%" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" SortExpression="AllocatedStock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAllocatedQuantity" runat="server" Text='<%#Eval("AllocatedStock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Available Stock" DataField="AvailableStock"
                                    HeaderStyle-HorizontalAlign="Right" AllowFiltering="false" CurrentFilterFunction="Contains"
                                    AutoPostBackOnFilter="true" ItemStyle-Width="7%" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Right"
                                    SortExpression="AvailableStock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("AvailableStock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </ContentTemplate>
                <%--   <Triggers>
                   <asp:AsyncPostBackTrigger ControlID="a1export" EventName="click" />
                </Triggers>--%>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="upProgress" AssociatedUpdatePanelID="pnlgridAccountingCodes"
                runat="server">
                <ProgressTemplate>
                    <div id="div_Load" class="loading_new" style="display: block">
                        <table cellpadding="0" cellspacing="10">
                            <tr>
                                <td>
                                    <div style="float: left">
                                        <img src="<%=strImagepath%>loading_new.gif" border="0" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>
</div>
<asp:Button ID="btninvenntory" Style="display: none" runat="server" OnClick="btninventory_onclick" />
<asp:HiddenField ID="hdnDefaultStockLocation" runat="server" Value=" " />
<asp:HiddenField ID="hdnDefaultLocationValue" runat="server" Value="0" />
<asp:HiddenField ID="hdnstockselfdetails" runat="server" Value="0" />
<asp:HiddenField ID="hdnOtherProductDetails" runat="server" Value="0" />
<asp:HiddenField ID="hdnAdditionalOptionDetails" runat="server" Value="0" />
<asp:HiddenField ID="hdnOtherMutipleDetails" runat="server" Value="0" />
<asp:HiddenField ID="hdntotalstockqty" runat="server" Value="0" />
<asp:HiddenField ID="hdnwebother" runat="server" Value="0" />
<asp:HiddenField ID="hdnEstimateID" runat="server" Value="0" />
<asp:HiddenField ID="hdnproductqty" runat="server" Value="0" />
<asp:HiddenField ID="hdnselfrowcount" runat="server" Value="0" />
<asp:HiddenField ID="hdnotherproductsrowcount" runat="server" Value="0" />
<asp:HiddenField ID="hdnothermultiplerowcount" runat="server" Value="0" />
<asp:HiddenField ID="hdnstockadjustment" runat="server" Value="" />
<asp:HiddenField ID="hdnAdditionalStockAdjustment" runat="server" Value="" />
<asp:HiddenField ID="hdnmainwebothercostid" runat="server" Value="0" />
<asp:HiddenField ID="hdnbackorder" runat="server" Value="" />
</div>
<asp:Button ID="lnkdownload" runat="server" Style="display: none" OnClick="lnkDownload_OnClick"></asp:Button>
<div id="div_radlocation" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="610" Modal="false" OnClientClose="OnClientClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<script language="javascript" type="text/javascript">
    var selfpnl = document.getElementById("<%=div_selfpnl.ClientID%>");
    var otherproducts = document.getElementById("div_otherproducts");
    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var strSitePath = "<%=strSitePath %>";
    var strImagepath = '<%=strImagepath %>';
    var additionaloptions = document.getElementById("<%=div_additionaloptnpnl.ClientID%>");
    var othermultiple = document.getElementById("div_othermultiple")
    var indexvalue = 0;
    var type = '';

    function displayactivity() {
        var divaddstock = document.getElementById("div_Addstock");
        var divrelease = document.getElementById("div_Release");
        var divadjustments = document.getElementById("div_Adjustments");
        var e = document.getElementById("<%=ddlstkactivity.ClientID %>");
        var selectedval = e.options[e.selectedIndex].value
        var Note1 = document.getElementById("Note1");
        var Note2 = document.getElementById("Note2");

        if (selectedval == 'add') {

            divaddstock.style.display = "block";
            divrelease.style.display = "none";
            divadjustments.style.display = "none";
            Note1.style.display = "none";
            Note2.style.display = "none";
        }
        else if (selectedval == 'release') {

            divaddstock.style.display = "none";
            divrelease.style.display = "block";
            divadjustments.style.display = "none";
            Note1.style.display = "block";
            Note2.style.display = "block";

        }
        else if (selectedval == 'adjustments') {

            divaddstock.style.display = "none";
            divrelease.style.display = "none";
            divadjustments.style.display = "block";
            Note1.style.display = "none";
            Note2.style.display = "none";
        }
    }

    function stockonchange(rdbid) {
        var ddldrawstockfrom = document.getElementById("<%=ddldrawstockfrom.ClientID %>");
        var selectedval = ddldrawstockfrom.options[ddldrawstockfrom.selectedIndex].value;
        if (selectedval == 'self') {
            selfpnl.style.display = "block";
            otherproducts.style.display = "none";
            additionaloptions.style.display = "none";
            othermultiple.style.display = "none";
            document.getElementById("<%=ddlstkactivity.ClientID %>").selectedIndex = 0;
            document.getElementById("spndrawstockfromalert").style.display = "none";
        }
        else if (selectedval == 'otherproducts') {
            otherproducts.style.display = "block";
            selfpnl.style.display = "none";
            additionaloptions.style.display = "none";
            othermultiple.style.display = "none";
            document.getElementById("spndrawstockfromalert").style.display = "none";
        }
        else if (selectedval == 'additionaloptions') {
            additionaloptions.style.display = "block";
            selfpnl.style.display = "none";
            otherproducts.style.display = "none";
            othermultiple.style.display = "none";
            document.getElementById("<%=ddl_additionalactivity.ClientID %>").selectedIndex = 0;
            document.getElementById("spndrawstockfromalert").style.display = "none";

            var ttlrows = '<%=totalrows %>';
            for (i = 0; i < ttlrows; i++) {
                var txtoptionname = document.getElementById("txtoptionname" + i);
                txtoptionname.value = SpecialDecode(txtoptionname.value);

                var txtoptionvalue = document.getElementById("txtoptionvalue" + i);
                txtoptionvalue.value = SpecialDecode(txtoptionvalue.value);

                var txtWhLocation = document.getElementById("txtWhLocation" + i);
                txtWhLocation.value = SpecialDecode(txtWhLocation.value);
            }
        }
        else if (selectedval == 'othermultiple') {
            othermultiple.style.display = "block";
            additionaloptions.style.display = "none";
            selfpnl.style.display = "none";
            otherproducts.style.display = "none";
            document.getElementById("spndrawstockfromalert").style.display = "none";
        }
        else if (selectedval == 'select') {
            selfpnl.style.display = "block";
            otherproducts.style.display = "none";
            additionaloptions.style.display = "none";
            othermultiple.style.display = "none";
            document.getElementById("<%=ddlstkactivity.ClientID %>").selectedIndex = 0;
        }

        var PB = '<%=PB%>';
        if (PB == 'false') {
            loadtextbox(2);
        }
    }
    function ClearTextbox(txtcode, txttitle) {
        var txttitle = document.getElementById(txttitle);
        if (txtcode.value == '') {
            txttitle.value = '';
        }

    }

    function getSelfStockDetails() {
        debugger
        var hdnstockselfdetails = document.getElementById("<%=hdnstockselfdetails.ClientID %>")
        var hdntotalstockqty = document.getElementById("<%=hdntotalstockqty.ClientID %>")
        var totalstockqty = 0;
        var stockdata = '';
        var tblid = document.getElementById("tblstock");
        var rowid = document.getElementById('tblstock').getElementsByTagName('tr');
        for (j = 1; j < (rowid.length); j++) {
            var inputs = rowid[j].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                //if (Number(inputs[0].value) != '' && Number(inputs[0].value) != Number(0)) {
                if ((inputs[n].id).indexOf('txtopnstock') > -1) {                                          //(inputs[n].id == 'txtopnstock') {
                    stockdata += 'openstock»' + inputs[n].value + '±';
                    totalstockqty = parseInt(totalstockqty) + parseInt(inputs[n].value);
                }
                if ((inputs[n].id).indexOf('hdnlocationid') > -1) {                                     //inputs[n].id =='hdnlocationid') {
                    stockdata += 'customfield1»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtcustomfield2') {
                    stockdata += 'customfield2»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtcustomfield3') {
                    stockdata += 'customfield3»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtcustomfield4') {
                    stockdata += 'customfield4»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtcustomfield5') {
                    stockdata += 'customfield5»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtcustomfield6') {
                    stockdata += 'customfield6»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtprice') {
                    stockdata += 'price»' + inputs[n].value + '±';
                }
                if (inputs[n].id == 'txtNotes') {
                    stockdata += 'Notes»' + inputs[n].value + '±';
                }
                if ((inputs[n].id).indexOf('txtstkdate') > -1) {
                    stockdata += 'date»' + inputs[n].value + '±';
                }
                //}
                //added if
            }
            stockdata += 'µ';
        }

        hdntotalstockqty.value = totalstockqty;
        hdnstockselfdetails.value = stockdata;
        return true;
    }

    function getOtherProductDetails() {
        var hdnOtherProductDetails = document.getElementById("<%=hdnOtherProductDetails.ClientID %>");
        var otherproduct = '';
        var tblid = document.getElementById("tblother");
        var rowid = document.getElementById('tblother').getElementsByTagName('tr');
        for (p = 1; p < (rowid.length); p++) {

            var inputs = rowid[p].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                if (Number(inputs[0].value) != 0) {
                    if ((inputs[n].id).indexOf('hdnOtherKitItemID') > -1) {
                        otherproduct += 'kititemid»' + inputs[n].value + "±";
                    }
                    if ((inputs[n].id).indexOf('txtunit') > -1) {
                        otherproduct += 'unit»' + inputs[n].value + "µ";
                    }
                }
            }
        }
        hdnOtherProductDetails.value = otherproduct;
        return true;
    }


    function getAdditinalOptionDetails() {
        var hdnAdditionalOptionDetails = document.getElementById("<%=hdnAdditionalOptionDetails.ClientID %>");
        var hdntotalstockqty = document.getElementById("<%=hdntotalstockqty.ClientID %>")
        var addtionaloptiondata = '';
        var totalstockqty = 0;
        var tblid = document.getElementById("tbladditional");
        var rowadd = document.getElementById('tbladditional').getElementsByTagName('tr');
        for (t = 1; t < (rowadd.length); t++) {
            var rowinputs = rowadd[t].getElementsByTagName('input');
            for (n = 0; n < rowinputs.length; n++) {
                if ((rowinputs[0].id).indexOf('txtoptionname') > -1) {
                    if (rowinputs[2].value != '') {               //to check open stock null
                        if ((rowinputs[n].id).indexOf('txtoptionname') > -1) {                                                                      //rowinputs[n].id == 'txtoptionname' + parseInt(t - 1)
                            addtionaloptiondata += 'optionname»' + rowinputs[n].value + '±';
                        }
                        if ((rowinputs[n].id).indexOf('txtoptionvalue') > -1) {                                                                    // rowinputs[n].id == 'txtoptionvalue' + parseInt(t - 1)
                            addtionaloptiondata += 'optionvalue»' + rowinputs[n].value + '±';
                        }
                        if ((rowinputs[n].id).indexOf('txtopnstockadditional') > -1) {        //txtopnstock                                                                //rowinputs[n].id == 'txtopnstock' + parseInt(t - 1)
                            addtionaloptiondata += 'openstock»' + rowinputs[n].value + '±';
                            totalstockqty = parseInt(totalstockqty) + parseInt(rowinputs[n].value);
                        }
                        if ((rowinputs[n].id).indexOf('txtadditionalprice') > -1) {                                                                 //rowinputs[n].id == 'txtadditionalprice' + parseInt(t - 1)
                            addtionaloptiondata += 'price»' + rowinputs[n].value + '±';
                        }
                        if ((rowinputs[n].id).indexOf('txtstkdate') > -1) {                                                                         //rowinputs[n].id == 'txtstkdate' + parseInt(t - 1)
                            addtionaloptiondata += 'date»' + rowinputs[n].value + '±';
                        }
                        if ((rowinputs[n].id).indexOf('hdnWhlocationid') > -1) {    //'hdnWhlocationid' txtWhLocation                                  rowinputs[n].id == 'txtWhLocation' + parseInt(t - 1)
                            addtionaloptiondata += 'customfield1»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'txtcustomfield0') {
                            addtionaloptiondata += 'customfield2»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'txtcustomfield1') {
                            addtionaloptiondata += 'customfield3»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'txtcustomfield2') {
                            addtionaloptiondata += 'customfield4»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'txtcustomfield3') {
                            addtionaloptiondata += 'customfield5»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'txtcustomfield4') {
                            addtionaloptiondata += 'customfield6»' + rowinputs[n].value + '±';
                        }
                        if (rowinputs[n].id == 'hdnwebother') {
                            addtionaloptiondata += 'webother»' + rowinputs[n].value + '±';
                        }
                        if ((rowinputs[n].id).indexOf('hdnchoiceid') > -1) {
                            addtionaloptiondata += 'choiceid»' + rowinputs[n].value;
                        }
                    }
                }
            }
            addtionaloptiondata += 'µ';

        }
        hdnAdditionalOptionDetails.value = addtionaloptiondata;
        hdntotalstockqty.value = totalstockqty;
        return true;
    }


    function addingrowself(tableID, hdnfldid) {
        var PriceValue = "<%=Price %>"
        var hdndefaultStockLocation = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnDefaultStockLocation").value;
        var hdndefaultlocationid = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnDefaultLocationValue").value;
        var hdnlocID = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnloc").value;
        var clsName = "";
        var count = document.getElementById(hdnfldid).value;

        var table = document.getElementById(tableID);
        rowCount = table.rows.length;
        var id;
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnselfrowcount").value == 0) {
            id = rowCount;
        }
        else {
            id = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnselfrowcount").value;
        }

        var row = table.insertRow(rowCount);

        // var id = rowCount;
        if (rowCount % 2 == 0) {
            clsName = "#EFEFEF";
        }
        else {
            clsName = "";

        }
        //New design changes.
        var txtlocationwidth = 0;
        var marginleftcaluculate = 4 + 'px';
        if (count == 6) {
            marginleftcaluculate = 5 + 'px';
            txtlocationwidth = 130 + 'px';
        }
        if (count == 5) {
            marginleftcaluculate = 40 + 'px';
            txtlocationwidth = 160 + 'px';
        }
        if (count == 4) {
            marginleftcaluculate = 80 + 'px';
            txtlocationwidth = 185 + 'px';
        }
        if (count == 3) {
            marginleftcaluculate = 100 + 'px';
            txtlocationwidth = 225 + 'px';
        }
        if (count == 2) {
            marginleftcaluculate = 120 + 'px';
            txtlocationwidth = 300 + 'px';
        }
        if (count == 1) {
            marginleftcaluculate = 135 + 'px';
            txtlocationwidth = 320 + 'px';
        }

        row.id = id;
        row.style.backgroundColor = clsName;
        row.style.height = "25px";
        var cell1 = row.insertCell(0);
        cell1.align = "left";
        cell1.innerHTML = "<input type='text' style='width:100px;text-align:right' onblur='javascript:checkforInteger(this.id,this.value);'  class='textboxnew' id='txtopnstock" + id + "' value='0'/>";

        var cell2 = row.insertCell(1);
        cell2.align = "left";
        cell2.innerHTML = "<input type='text' style='width:100px; text-align:right' value='" + PriceValue + "'  onblur='javascript:pricetodecimal(this," + id + ")'   class='textboxnew' id='txtprice'/>";

        var cell3 = row.insertCell(2);
        cell3.align = "left";
        cell3.innerHTML = "<input id='txtstkdate" + id + "'type='text' style='width:100px;text-align:left' value='<%=comm.Eprint_return_Date_Before_View(DateTime.Now.ToString(), CompanyID, UserID, false) %>' onclick=javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormat + "');  class='textboxnew'  />";

        var inc = 3;
        // if (Number(hdndefaultStockLocation) != 0) {
        if (hdnlocID == "yes") {
            var cell4 = row.insertCell(3);
            cell4.width = "5%"
            cell4.align = "left";
            cell4.innerHTML = "<span style='margin-right:5px'><img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='" + strImagepath + "plus.gif' onclick=javascript:addstocklocation(" + id + ",'s'); /></span><input type='text' style='width:" + txtlocationwidth + ";text-align:left;' autocomplete='off' onkeyup=javascript:GetLocationDetails(this,'hdnlocationid" + id + "','Warehouse','" + CompanyID + "','1',event);  onclick=javascript:GetLocationDetails(this,'hdnlocationid" + id + "','Warehouse','" + CompanyID + "','1',event);  value='" + hdndefaultStockLocation + "' onblur='javascript:chkloc(this.value,hdnlocationid" + id + ");'  class='textboxnew' id='txtLocation" + id + "'/><input type='hidden' id='hdnlocationid" + id + "' value='" + hdndefaultlocationid + "' />";  // <span style='margin-right:5px'><img style='cursor:pointer;height:12px;width:12px' title='Add Location' src='" + strImagepath + "plus.gif' onclick=javascript:GetRadWindow().BrowserWindow.location.href='" + strSitePath + "settings/settings_warehouselocation_add.aspx' /></span>
            inc = 4;
            count = count - 1;
        }
        //var inc = 2;
        var p = 1;
        for (var i = 0; i < count; i++) {
            p = p + 1;
            var cell5 = row.insertCell(inc);
            cell5.align = "left";
            cell5.innerHTML = "<input type='text' style='width:" + txtlocationwidth + ";text-align:left'  class='textboxnew' id='txtcustomfield" + p + "'/>";
            inc = inc + 1;
        }
        var cell6 = row.insertCell(inc);
        cell6.align = "right";
        cell6.style.paddingRight = "15px"
        cell6.innerHTML = "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0'   title='Remove' onclick=javascript:Remove_Row(" + id + ",'tblstock'); />";

        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnselfrowcount").value = parseInt(id) + 1;
        loadtextbox(id);
        return false;


    }

    function CallSelectedOption(rdbid, SaveType) {
        var ddldrawfrom = document.getElementById("<%=ddldrawstockfrom.ClientID %>");
        var ddlselectedval = ddldrawfrom.options[ddldrawfrom.selectedIndex].value;

        var e = document.getElementById("<%=ddlstkactivity.ClientID %>");
        var selectedval = e.options[e.selectedIndex].value;

        var ddladditional = document.getElementById("<%=ddl_additionalactivity.ClientID %>");
        var additionalselectedval = ddladditional.options[ddladditional.selectedIndex].value;

        var rdblen = document.getElementById(rdbid).getElementsByTagName("input");
        //        for (var x = 0; x < rdblen.length; x++) {
        //            if (rdblen[x].checked) {
        if (ddlselectedval.toLowerCase() == 'self') {
            if (selectedval == 'add') {
                return getSelfStockDetails();
            }
            else if (selectedval == 'adjustments') {
                return GetStockSelfAdjustmentDetails(SaveType);
            }
        }
        if (ddlselectedval.toLowerCase() == 'otherproducts') {
            return getOtherProductDetails();
        }
        if (ddlselectedval.toLowerCase() == 'additionaloptions') {

            if (additionalselectedval == 'add' && document.getElementById("tbladditional") != null) {
                return getAdditinalOptionDetails();
            }
            else if (additionalselectedval == 'adjustments') {
                return GetAdditionalEditDetails();
            }

        }
        if (ddlselectedval.toLowerCase() == 'othermultiple') {
            return getOtherMultipleDetails();
        }
    }

    var BackOrderCheck = false;
    function PlusMinusCheck() {
        var IsPlusMinus = true;
        var selfbackorder = document.getElementById("<%=hdnbackorder.ClientID %>").value;
        var ddldrawfrom = document.getElementById("<%=ddldrawstockfrom.ClientID %>");
        var ddlselectedval = ddldrawfrom.options[ddldrawfrom.selectedIndex].value;

        var e = document.getElementById("<%=ddlstkactivity.ClientID %>");
        var selectedval = e.options[e.selectedIndex].value;

        var ddladditional = document.getElementById("<%=ddl_additionalactivity.ClientID %>");
        var additionalselectedval = ddladditional.options[ddladditional.selectedIndex].value;

        if (ddlselectedval.toLowerCase() == 'self') {
            if (selectedval == 'adjustments') {
                var tblselfedit = document.getElementById("tblselfedit");
                var tbrow = document.getElementById('tblselfedit').rows.length;
                for (i = 0; i < (tbrow - 1); i++) {
                    var ddl = document.getElementById("ddlplusminus" + i + "");
                    var availQty = document.getElementById("hdn_availQty" + i + "").value;
                    var txtQty = document.getElementById("txtadjustqty" + i + "").value;
                    if (ddl.value == '-' && parseInt(availQty) < parseInt(txtQty)) {
                        BackOrderCheck = true;
                    } else if (ddl.value == 'Move' && parseInt(availQty) < parseInt(txtQty)) {
                        BackOrderCheck = true;
                    }
                    if (ddl.selectedIndex == 0 && parseInt(txtQty) > 0) {
                        IsPlusMinus = false;
                    }
                }
            }
        }
        if (ddlselectedval.toLowerCase() == 'additionaloptions') {
            if (additionalselectedval == 'adjustments') {

                var tbladditionaladjustment = document.getElementById("tbladditionaladjustment");
                var tbrow = document.getElementById('tbladditionaladjustment').rows.length;
                for (i = 0; i < (tbrow - 1); i++) {
                    var ddl = document.getElementById("ddlplusminus" + i + "");
                    var availQty = document.getElementById("hdn_availQty" + i + "").value;
                    var txtQty = document.getElementById("txtadjustqty" + i + "").value;
                    if (ddl.value == '-' && parseInt(availQty) < parseInt(txtQty)) {
                        BackOrderCheck = true;
                    } else if (ddl.value == 'Move' && parseInt(availQty) < parseInt(txtQty)) {
                        BackOrderCheck = true;
                    }
                    if (ddl.selectedIndex == 0 && parseInt(txtQty) > 0) {
                        IsPlusMinus = false;
                    }
                }
            }
        }
        return IsPlusMinus;
    }




    function addOthermultiplerow(tableID) {
        var clsName = "";
        var table = document.getElementById(tableID);

        var rowCount = table.rows.length;

        var id;
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnothermultiplerowcount").value == 0) {
            id = rowCount + 1;
        }
        else {
            id = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnothermultiplerowcount").value;
        }

        var row = table.insertRow(rowCount);

        //var id = rowCount;
        if (rowCount % 2 == 0) {
            clsName = "#EFEFEF";
        }
        else {
            clsName = "";

        }
        row.id = id;
        row.style.backgroundColor = clsName;
        row.style.height = "25px";
        row.id = id;
        var cell1 = row.insertCell(0);
        cell1.align = "left";
        cell1.innerHTML = "<input type='text' style='width:165px;text-align:left' autocomplete='off' onkeyup=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID" + id + "','txtitemtitlemultiple" + id + "','Products','" + CompanyID + "','1',event);  onclick=javascript:displayProductTitle(this,'hdnOtherMultipleKitItemID" + id + "','txtitemtitlemultiple" + id + "','Products','" + CompanyID + "','1',event); onblur=javascript:ClearTextbox(this,'txtitemtitlemultiple" + id + "');  class='textboxnew' id='txtitemcodemultiple" + id + "'/><input type='hidden' id='hdnOtherMultipleKitItemID" + id + "' value='0' />";
        var cell2 = row.insertCell(1);
        cell2.align = "left";
        cell2.innerHTML = "<input type='text' style='width:365px;text-align:left' disabled='true'   class='textboxnew' id='txtitemtitlemultiple" + id + "'/>";
        var cell3 = row.insertCell(2);
        cell3.align = "center";
        cell3.innerHTML = "<input type='checkbox' id='chkdefault" + id + "' onclick=javascript:chkothermultipledefault(this.id); />";
        var cell4 = row.insertCell(3);
        cell4.align = "center";
        cell4.innerHTML = "<img style='cursor:pointer;height:10px;width:10px' src='" + strImagepath + "delete.gif' border='0' title='Remove' onclick=javascript:Remove_Row(" + id + ",'tblmultiple'); />";

        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnothermultiplerowcount").value = parseInt(id) + 1;
        return false;
    }

    function getOtherMultipleDetails() {
        var hdnOtherMultipleDetails = document.getElementById("<%=hdnOtherMutipleDetails.ClientID %>");
        var multipleproduct = '';
        var tblid = document.getElementById("tblmultiple");
        var rowid = document.getElementById('tblmultiple').getElementsByTagName('tr');
        for (p = 1; p < (rowid.length); p++) {
            var inputs = rowid[p].getElementsByTagName('input');
            for (n = 0; n < inputs.length; n++) {
                if (inputs[0].value != '') {
                    if ((inputs[n].id).indexOf('hdnOtherMultipleKitItemID') > -1) {
                        multipleproduct += 'kititemid»' + inputs[n].value + "±";
                    }
                    if ((inputs[n].id).indexOf('chkdefault') > -1) {
                        var chkdefault = document.getElementById(inputs[n].id);
                        var isdefault;
                        if (chkdefault.checked) {
                            isdefault = 1;
                        }
                        else {
                            isdefault = 0;
                        }

                        multipleproduct += 'default»' + isdefault + "µ";
                    }
                }
            }
        }
        hdnOtherMultipleDetails.value = multipleproduct;
        return true;
    }


</script>
<script language="javascript" type="text/javascript">

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function finalvalidatemail() {
        debugger
        var ddldrawstockfrom = document.getElementById("<%=ddldrawstockfrom.ClientID %>");
        var selectedval = ddldrawstockfrom.options[ddldrawstockfrom.selectedIndex].value;

        BackOrderCheck = false;

        if (selectedval == "self") {
            var tblid = document.getElementById("tblstock");
            var rowid = document.getElementById('tblstock').getElementsByTagName('tr');

            for (j = 1; j < (rowid.length); j++) {
                var inputs = rowid[j].getElementsByTagName('input');
                for (n = 0; n < inputs.length; n++) {
                    if ((inputs[n].id).indexOf('hdnlocationid') > -1) {
                        if (inputs[n].value == "") {
                            alert("Please select location");
                            inputs[n].focus();
                            return false;
                        }
                    }
                }
            }
        }
        else if (selectedval == "additionaloptions" && document.getElementById('tbladditional') != null) {
            var rowadd = document.getElementById('tbladditional').getElementsByTagName('tr');
            for (t = 0; t < (rowadd.length); t++) {
                var rowinputs = rowadd[t].getElementsByTagName('input');
                for (n = 0; n < rowinputs.length; n++) {
                    if ((rowinputs[n].id).indexOf('hdnWhlocationid') > -1) {
                        if (rowinputs[n].value == "") {
                            alert("Please select location");
                            rowinputs[n].focus();
                            return false;
                        }
                    }
                }
            }
        }

        var IsPlusMinus = PlusMinusCheck();

        if (IsPlusMinus) {

            if (BackOrderCheck) {
                alert("Stock Adjustment is not possible due to insufficient stock availability.");
                return false;
            }


            if (selectedval == 'select') {
                document.getElementById("spndrawstockfromalert").style.display = "block";
                return false;
            }
            else {
                document.getElementById("spndrawstockfromalert").style.display = "none";
                if (selectedval == 'additionaloptions' && ('<%=AdditionalHeaderType %>').toLowerCase() == 'opening') {
                    if (document.getElementById("<%=hdnmainwebothercostid.ClientID %>").value == 0) {
                        alert("Please select one additional option");
                        return false;
                    }
                    else {
                        return true;
                    }
                }
                if (selectedval == 'othermultiple') {
                    var table = document.getElementById('tblmultiple');
                    var rowCount = table.rows.length;
                    var id = $('#tblmultiple tr:last').attr('id'); // to get last row id

                    for (var i = 1; i <= id; i++) {
                        if (document.getElementById('txtitemcodemultiple' + i) != null || document.getElementById('txtitemcodemultiple' + i) != undefined) {
                            var txtval = document.getElementById('txtitemcodemultiple' + i).value;
                            if (txtval == "") {
                                alert('Please select product for the other multiple stock');
                                return false;
                            }
                        }
                        else if (document.getElementById('txtitemcodemultiple' + j + 'e') != null || document.getElementById('txtitemcodemultiple' + j + 'e')) {
                            var j = i - 1;
                            var txtval = document.getElementById('txtitemcodemultiple' + j + 'e').value;
                            if (txtval == "") {
                                alert('Please select product for the other multiple stock');
                                return false;
                            }
                        }
                    }
                }

                var refqty = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_txtrefqty").value;
                var chkrdb1 = document.getElementById("<%=chkReorderLevelEveryTime.ClientID %>");
                var chkrdb2 = document.getElementById("<%=chkReorderLevelDaily.ClientID %>");
                var chkrdb3 = document.getElementById("<%=chkReorderLevelWeekly.ClientID %>");
                var email = document.getElementById("<%=txtemail.ClientID %>");
                if (chkrdb1.checked || chkrdb2.checked || chkrdb3.checked) {
                    return validateMultipleEmailsCommaSeparated(email.value, 'spn_To');
                }
                else {
                    return true;
                }
            }
        }
        else {
            var message = "<%=validationmsg%>";
            alert(message);
            return false;
        }
    }

    function validateval() {
        debugger;
        try {
            var x = document.getElementById("txtopnstock1").value;
            var e = document.getElementById("<%=ddlstkactivity.ClientID %>");
            var selectedval = e.options[e.selectedIndex].value;
            if (x == "" || x <= 0 && selectedval == "add") {
                alert("Qty must be greater than 0");
                return false;
            }
        }
        catch (err) {

        }
    }
    // to save adjustments
    var IsNegativeQtyExistSave = false;
    function GetStockSelfAdjustmentDetails(SaveType) {
        var hdnstockadjustment = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_hdnstockadjustment");
        var SelfAdjustmentStockDetails = '';
        var QtyAdjustment;
        var notes;
        var tblid = document.getElementById("tblselfedit");
        var rowid = document.getElementById('tblselfedit').rows.length;
        var IsNegativeQtyExist = false;
        var IsNegativeAlert = false;
        var IsAddingOnlyNegativeQty = false;

        var IFQTYADD = false;
        for (var n = 0; n < (rowid - 1); n++) {
            var e = document.getElementById("ddlplusminus" + n + "");
            if (e.options[e.selectedIndex].value == '+') {
                IFQTYADD = true;
            }
        }

        if (IFQTYADD) {
            for (var n = 0; n < (rowid - 1); n++) {
                var e = document.getElementById("ddlplusminus" + n + "");
                if (Number(document.getElementById("hdn_availQty" + n + "").value) < 0) {
                    IsNegativeQtyExist = true;
                    if (e.options[e.selectedIndex].value == '+') {
                        IsAddingOnlyNegativeQty = true;
                    }
                } else if (e.options[e.selectedIndex].value == '+' && !IsAddingOnlyNegativeQty) {
                    IFQTYADD = true;
                    IsAddingOnlyNegativeQty = false;
                }
            }
        }

        for (p = 0; p < (rowid - 1); p++) {

            var availQty = document.getElementById("hdn_availQty" + p + "").value;
            QtyAdjustment = document.getElementById("txtadjustqty" + p + "").value;
            notes = document.getElementById("txtNotes" + p + "").value;
            var e = document.getElementById("ddlplusminus" + p + "");
            var action = e.options[e.selectedIndex].value; //plus or minus
            var hdnPriceCatalogueStockID = document.getElementById("hdn_stockselfID" + p + "");

            if (action == 'Move') {
                var rows = document.getElementById('tblselfedit').getElementsByTagName('tr');
                var inputs = rows[(p + 1)].getElementsByTagName('input');
                SelfAdjustmentStockDetails += 'stockselfid»' + hdnPriceCatalogueStockID.value + '±';
                SelfAdjustmentStockDetails += 'Notes»' + notes + '±';
                SelfAdjustmentStockDetails += 'adjustqty»M~' + QtyAdjustment + '±';
                for (n = 0; n < inputs.length; n++) {
                    if ((inputs[n].id).indexOf('hdn_Adjustment_locationid_' + (p + 1)) > -1) {
                        SelfAdjustmentStockDetails += 'customfield1»' + inputs[n].value + '±';
                    }
                    if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_2') {
                        SelfAdjustmentStockDetails += 'customfield2»' + inputs[n].value + '±';
                    }
                    if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_3') {
                        SelfAdjustmentStockDetails += 'customfield3»' + inputs[n].value + '±';
                    }
                    if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_4') {
                        SelfAdjustmentStockDetails += 'customfield4»' + inputs[n].value + '±';
                    }
                    if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_5') {
                        SelfAdjustmentStockDetails += 'customfield5»' + inputs[n].value + '±';
                    }
                    if (inputs[n].id == 'txt_Adjustment_customfield_' + (p + 1) + '_6') {
                        SelfAdjustmentStockDetails += 'customfield6»' + inputs[n].value + '±';
                    }
                }
                SelfAdjustmentStockDetails += 'µ';
            }
            else if (QtyAdjustment != Number(0)) {
                SelfAdjustmentStockDetails += 'stockselfid»' + hdnPriceCatalogueStockID.value + '±';
                SelfAdjustmentStockDetails += 'Notes»' + notes + '±';
                SelfAdjustmentStockDetails += 'adjustqty»' + action + "~" + QtyAdjustment + 'µ';
                if (IsNegativeQtyExist && Number(availQty) < 0 && Number(QtyAdjustment) >= Math.abs(Number(availQty))) {
                    IsNegativeAlert = false;
                } else if (IsNegativeQtyExist && Number(availQty) < Number(0)) {
                    IsNegativeAlert = true;
                }
            } else if (IsNegativeQtyExist && Number(availQty) < Number(0)) {
                IsNegativeAlert = true;
            }
        }

        if (IsNegativeAlert && !IsNegativeQtyExistSave && !IsAddingOnlyNegativeQty) {
            $("#dialog-confirm").dialog({
                resizable: false,
                width: '440px',
                modal: true,
                buttons: {
                    Cancel: function () {
                        $(this).dialog("close");
                    },
                    "Save": function () {
                        $(this).dialog("close");
                        IsNegativeQtyExistSave = true;
                        finalvalidatemail();
                        if (SaveType == 'saveandstay') {
                            document.getElementById("<%=btnStockStay.ClientID %>").click();
                        } else if (SaveType == 'save') {
                            document.getElementById("<%=btnStockSave.ClientID %>").click();
                        }
                    }
                }
            });
            $("#dialog-confirm").dialog('open');
            return false;
        } else {
            hdnstockadjustment.value = SelfAdjustmentStockDetails;
            return true;
        }
    }

    if (window.screen.Width < 1500) {
        document.getElementById("div_Outer").style.width = "1490";
    }

    function GetJobDetails(estimateid, Quantity) {
        document.getElementById("<%=txtrefqty.ClientID %>").value = Quantity;
        document.getElementById("<%=txtadditionalrefrenceqty.ClientID %>").value = Quantity;
        document.getElementById("<%=hdnproductqty.ClientID %>").value = Quantity;
        document.getElementById("<%=hdnEstimateID.ClientID %>").value = estimateid;
    }

    function validaterefqty(s, spanid, txtrefqty) {
        if (checkforInteger(txtrefqty, s) == false) {

            document.getElementById("<%=txtrefqty.ClientID %>").value = 0;
            document.getElementById("<%=txtadditionalrefrenceqty.ClientID %>").value = 0;
            //document.getElementById("<%=hdnproductqty.ClientID %>").value = 0;
        }
        else if (parseInt(s) > parseInt(document.getElementById("<%=hdnproductqty.ClientID %>").value)) {
            alert("The release quantity can't be greater than the allocated quantity");
            document.getElementById("<%=txtrefqty.ClientID %>").value = document.getElementById("<%=hdnproductqty.ClientID %>").value;
            document.getElementById("<%=txtadditionalrefrenceqty.ClientID %>").value = document.getElementById("<%=hdnproductqty.ClientID %>").value;
            return false;
        }
        else {
            var i;
            s = s.toString();
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (isNaN(c)) {
                    if (spanid != '') {
                        document.getElementById(spanid).style.display = "block";
                    }
                    return false;
                }
            }
            if (spanid != '') {
                document.getElementById(spanid).style.display = "none";
            }
            return true;
        }

    }

    //additional options
    function AdditionalStockOnChange() {
        var divadditionaladd = document.getElementById("div_additionaladd");
        var divadditionalrelease = document.getElementById("div_additionalrelease");
        var divadditionaladjustments = document.getElementById("div_additionaladjustments");
        var e = document.getElementById("<%=ddl_additionalactivity.ClientID %>");
        var selectedval = e.options[e.selectedIndex].value

        if (selectedval == 'add') {

            divadditionaladd.style.display = "block";
            divadditionalrelease.style.display = "none";
            divadditionaladjustments.style.display = "none";

        }
        else if (selectedval == 'release') {

            divadditionaladd.style.display = "none";
            divadditionalrelease.style.display = "block";
            divadditionaladjustments.style.display = "none";

        }
        else if (selectedval == 'adjustments') {

            divadditionaladd.style.display = "none";
            divadditionalrelease.style.display = "none";
            divadditionaladjustments.style.display = "block";

        }
    }

    // validation for self and additional options adjustment qty



    function checkforIntegerSelf(txtadjust, s, totqty, ddlval, backorder, Avail_qty) {
        debugger;
        document.getElementById("<%=hdnbackorder.ClientID %>").value = backorder;
        var sv = ddlval.options[ddlval.selectedIndex].value;
        var i;
        s = s.toString();
        if (s == '') {
            document.getElementById(txtadjust).value = 0;
        }
        else if (sv == '-' && (Number(s) > Number(totqty.value) || Number(Avail_qty.value) < Number(0))) {
            document.getElementById(txtadjust).value = 0;
        }
        else if (sv == 'Move' && Number(s) > Number(totqty.value)) {
            document.getElementById(txtadjust).value = 0;
        }
        for (i = 0; i < s.length; i++) {
            var c = s.charAt(i);
            if (isNaN(c)) {
                document.getElementById(txtadjust).value = 0;
                return false;
            }
        }
    }

    function duplicatecodevalidate(textboxid, titletextboxid, otherkititemid, itemcode) {
        var ddldrawstockfrom = document.getElementById("<%=ddldrawstockfrom.ClientID %>");
        var selectedval = ddldrawstockfrom.options[ddldrawstockfrom.selectedIndex].value;

        if (selectedval == 'otherproducts') {
            var rowid = document.getElementById('tblother').getElementsByTagName('tr');
            for (p = 1; p < (rowid.length); p++) {
                var inputs = rowid[p].getElementsByTagName('input');
                for (n = 0; n < inputs.length; n++) {
                    if (Number(inputs[0].value) != 0) {
                        if ((inputs[n].id).indexOf('txtitemcode') > -1) {
                            if (inputs[n].id != textboxid.id) {
                                if (inputs[n].value == itemcode) {
                                    textboxid.value = '';
                                    titletextboxid.value = '';
                                    otherkititemid = '';
                                    alert("Product already used!!");
                                    return false;
                                }
                            }
                        }

                    }


                }
            }
        }
        if (selectedval == 'othermultiple') {
            var rowid = document.getElementById('tblmultiple').getElementsByTagName('tr');
            for (p = 1; p < (rowid.length); p++) {
                var inputs = rowid[p].getElementsByTagName('input');
                for (n = 0; n < inputs.length; n++) {
                    if (Number(inputs[0].value) != 0) {
                        if ((inputs[n].id).indexOf('txtitemcode') > -1) {
                            if (inputs[n].id != textboxid.id) {
                                if (inputs[n].value == itemcode) {
                                    textboxid.value = '';
                                    titletextboxid.value = '';
                                    otherkititemid = '';
                                    alert("Product already used!!");
                                    return false;
                                }
                            }
                        }

                    }


                }
            }
        }
    }


    function accordinwithoutindex() {
        $(document).ready(function () {
            $("#accordion").accordion({ header: "h3", collapsible: true, autoHeight: false, animated: 'easeslide', active: false });
        });
    }
    accordinwithoutindex();

    function setsavepos() {
        var btn = document.getElementById("div_savebtn");
        if (btn.style.marginRight == "647px") {
            btn.style.marginRight = "382px";
        }
        else {

            btn.style.marginRight = "647px";
        }
    }


    function validateMultipleEmailsCommaSeparated(value, spnid) {
        document.getElementById(spnid).style.display = "none";
        if (document.getElementById("<%=rdoNone.ClientID %>").checked == false) {

            if (value == '') {
                if (spnid == 'spn_To') {
                    document.getElementById(spnid).innerHTML = "Please enter email address";
                    document.getElementById(spnid).style.display = "block";
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                var result = value.split(",");
                var chkvalidate = 'false';
                for (var i = 0; i < result.length; i++) {

                    if (!validateEmail(result[i])) {
                        document.getElementById(spnid).innerHTML = "Please enter valid email address";
                        document.getElementById(spnid).style.display = "block";
                        chkvalidate = 'false';
                        return false;
                    }
                    else {
                        chkvalidate = 'true';
                    }
                }
                if (chkvalidate == 'false') {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    }

    function validateEmail(field) {
        //var regex = /\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b/i;
        // var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        return (regex.test(field)) ? true : false;
    }

    //check only one chek box
    function validateadditionaloptioncheck(chkid) {
        var hdnmainwebothercostid = document.getElementById("<%=hdnmainwebothercostid.ClientID %>");
        var chkcount = 0;
        var rowadd = document.getElementById('tbladditional').getElementsByTagName('tr');
        for (t = 0; t < (rowadd.length); t++) {
            var rowinputs = rowadd[t].getElementsByTagName('input');
            for (n = 0; n < rowinputs.length; n++) {
                if (rowinputs[n].type == 'checkbox') {               // && rowid[j].id.indexOf('chkselect') != -1
                    if (rowinputs[n].checked) {
                        hdnmainwebothercostid.value = rowinputs[n].value;
                        chkcount = chkcount + 1;
                    }
                }
            }
        }
        if (chkcount > 1) {
            //alert("Please check one Additional option");
            //hdnmainwebothercostid.value = 0;
            for (t = 0; t < (rowadd.length); t++) {
                var rowinputs = rowadd[t].getElementsByTagName('input');
                for (n = 0; n < rowinputs.length; n++) {
                    if (rowinputs[n].type == 'checkbox') {
                        if (rowinputs[n].id != chkid) {
                            rowinputs[n].checked = false;
                        }
                    }
                }

            }
            hdnmainwebothercostid.value = document.getElementById(chkid).value;
        }
        if (chkcount == 0) {
            hdnmainwebothercostid.value = 0;
            //alert("Please select one additional option");
        }

    }
    function addmoreadditionaloption() {
        document.getElementById("adddiv").style.display = "block";
        document.getElementById("<%=div_addlnk.ClientID %>").style.display = "none";
        return false;
    }


    function chkothermultipledefault(chkid) {

        var rowadd = document.getElementById('tblmultiple').getElementsByTagName('tr');
        var rowcount = 0;
        for (t = 0; t < (rowadd.length); t++) {
            var rowinputs = rowadd[t].getElementsByTagName('input');
            for (n = 0; n < rowinputs.length; n++) {
                if (rowinputs[n].checked || rowinputs[n].checked == false) {               // && rowid[j].id.indexOf('chkselect') != -1
                    if (rowinputs[n].checked) {
                        rowcount = 1;
                        if (rowinputs[n].id != chkid) {
                            rowinputs[n].checked = false;
                        }
                    }
                }
            }
        }
        //if (rowcount == 1 && document.getElementById(chkid).checked == true) {
        document.getElementById("<%=btnStockStay.ClientID %>").click();
        //}
    }

    function ViewStockAllocation_ProductCatalougeitemStockHistory() {
        var ProductCatalogueID = "<%=ProductCatalogueID %>";
        document.location.href = "<%=strSitepath %>" + "common/common_popup.aspx?type=productcatalogueitemstockhistory&action=edit&PriceCatalogueID=" + ProductCatalogueID, '1000', '500';
        //var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=productcatalogueitemstockhistory&action=edit&id=" + id, '1000', '500');
        //SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        //Rad1Customer.setSize(1330, 520);
        //Rad1Customer.center();
        //Rad1Customer.id = "Radwindowstock";
    }
    <%--Modification By Bilal Stage 3.5--%>
    function ViewStockAllocation_ProductCatalougeitemStockPO() {
        debugger
        var ProductCatalogueID = "<%=ProductCatalogueID %>";
        document.location.href = "<%=strSitepath %>" + "common/common_popup.aspx?type=productcatalogueitemstockpo&action=edit&PriceCatalogueID=" + ProductCatalogueID, '1000', '500';
        //var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=productcatalogueitemstockhistory&action=edit&id=" + id, '1000', '500');
        //SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        //Rad1Customer.setSize(1330, 520);
        //Rad1Customer.center();
        //Rad1Customer.id = "Radwindowstock";
    }

    function edit_other(id, kitItemID, itemCode, itemTitle, qty, companyID) {
        debugger
        var path = "<%=strSitepath %>" + "common/common_popup.aspx?type=otherstockedit&action=edit&id=" + id + "&kitItemID=" + kitItemID + "&itemCode=" + itemCode + "&itemTitle=" + itemTitle + "&qty=" + qty + "&companyID=" + companyID;
        var oWnd = radopen(path, 'RadWindow1');
        oWnd.setSize(900, 350);
        oWnd.center();
        oWnd.set_visibleStatusbar(false);
        oWnd.set_modal(true);
    }

    function delete_other(id) {
        __doPostBack('DeleteItem', id);

    }
</script>

