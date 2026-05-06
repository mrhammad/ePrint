<%@ control language="C#" autoeventwireup="true" CodeBehind="inventory_add.ascx.cs" Inherits="ePrint.usercontrol.warehouse.inventory_add" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div id="ds00" style="display: none; width: 100%; height: 100%">
</div>
<!-- content start -->
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdInventoryHistory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdInventoryHistory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7" />
<script type="text/javascript">
    var div_Load = document.getElementById("div_Load");
    if (div_Load != null) {  // IE, on 23.09.2011...
        setLoadingPositionOfDivMove(div_Load);
    }
    var action = '<%=type %>';
    var PaperMeasure = "<%=PaperMeasure %>";
    var LargeFormatCalculation = "<%=LargeFormatCalculation %>";
    var SquareMeater = '<%=objLangClass.GetLanguageConversion("Sqaure_Meter")%>'

</script>
<div id="divBackGroundNew" style="display: none;">
</div>
<div align="left">
    <div class="navigatorpanel" id="colourPanel" runat="server">
    </div>
    <div id="Content" runat="server">
        <div id="padding" class="div_purchase_vwmargin">
            <div align="center" style="width: 70%; padding-top: 5px">
                <div style="width: 100%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="width: 100%; display: block; margin-top: 5px;" id="divtabs">
                <div id="ynnav">
                    <ul>
                        <li id="li_General" style="cursor: pointer; float: left; clear: right;">
                            <div id="divGeneral" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; display: block">
                                <b><span id="item_1" class="TabSelected" style="color: Red" onclick="javascript:gettabs('g');">
                                    <%=objLangClass.GetLanguageConversion("General")%>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_Stock" style="cursor: pointer; float: left; clear: right; display: block">
                            <div id="divStock" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; filter: opaci">
                                <b><span id="item_2" onclick="javascript:gettabs('s');">
                                    <%=objLangClass.GetLanguageConversion("Stock")%>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_History" style="cursor: pointer; float: left; clear: right; display: block">
                            <div id="divHistoryforedit" runat="server" visible="false">
                                <div id="divHistory" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                    <b><span id="SpnHistory" onclick="javascript:gettabs('h');">
                                        <%=objLangClass.GetLanguageConversion("History")%></span></b>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div class="divBorderItem">
                <div id="padding">
                    <div id="divGeneralItem" style="display: block">
                        <div style="float: left; border: 0px solid; width: 100%; padding-top: 5px; padding-bottom: 5px">
                            <div id="divArchivelnk" runat="server" visible="false" style="width: 50%; float: left; padding-left: 10px; padding-bottom: 5px; padding-top: 5px">
                                <span style="width: 100%" class="error_yello_new"><b>
                                    <%=objlang.GetValueOnLang("This Item is Archived")%>,
                                    <asp:LinkButton ID="UnArchiveID" runat="server" OnClick="UnArchive_onclicklnk"><u><%=objlang.GetValueOnLang("Un-Archive this Item")%></u>?</asp:LinkButton></b>
                                </span>
                            </div>
                        </div>
                        <div align="left" style="width: 100%; padding: 2px;">
                            <div style="float: left; width: 49%;">
                                <div align="left">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label39" CssClass="normaltext" runat="server"><%=objLangClass.GetLanguageConversion("Inventory_Name")%></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box" style="padding-left: 5px">
                                        <div style="width: 200px;">
                                            <asp:TextBox ID="txtInvName" SkinID="textPad" CssClass="textboxnew1" runat="server"
                                                Width="200px" MaxLength="100"></asp:TextBox>
                                            <%----%>
                                        </div>

                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_txtInvName" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Inventory_Name")%></span>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_InvNameCheck" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objLangClass.GetLanguageConversion("Inventory_Name_Already_Exists")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 30%">
                                        <asp:Label ID="lbl_UserFriendlyName" CssClass="normaltext" Text="Friendly name" runat="server"></asp:Label>
                                    </div>
                                    <div class="box" style="padding-left: 5px">
                                        <asp:TextBox ID="txt_UserFriendlyName" SkinID="textPad" runat="server" MaxLength="100"
                                            Width="200px" onfocus="copyText();"></asp:TextBox>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="height: 70px; vertical-align: middle; width: 30%;">
                                        <span class="normaltext" style="vertical-align: middle">
                                            <%=objLangClass.GetLanguageConversion("Description")%></span>
                                    </div>
                                    <div class="box" style="padding-left: 5px">
                                        <asp:TextBox ID="txtdescription" Rows="2" Height="70px" Width="200px" runat="server"
                                            TextMode="MultiLine" SkinID="textPad" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                                        <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 200px; white-space: nowrap">
                                            <%=objlang.GetValueOnLang("Max. length of textbox is")%>: 3000</span>
                                    </div>
                                </div>
                                 <div id="div_basisweight" align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label5" CssClass="normaltext" Text="Basis Weight" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div style="float: left; padding: 3px; padding-left: 3px;">
                                        <div align="left" style="padding-left: 2px">
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtBasisWeight" SkinID="textpad" runat="server" MaxLength="20" Width="200px" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);CallonBlur(this.value,'spn_basisweightreq');">1.00</asp:TextBox>
                                            </div>
                                            <div style="float: left;">
                                                <div style="float: left; padding-left: 5px">
                                                    <asp:Label ID="lblBasisweightType" runat="server" CssClass="normalText">GSM</asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="spn_basisweightreq" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter Basis Weight")%></span>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_basisweight" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_basisweight_2" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objLangClass.GetLanguageConversion("Weight_Cannot_Be_Zero")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Caliper" align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="lblCaliper" CssClass="normaltext" Text="Caliper" runat="server"></asp:Label>
                                    </div>
                                    <div style="float: left; padding: 3px; padding-left: 3px;">
                                        <div align="left" style="padding-left: 2px">
                                            <div style="float: left;">
                                                <asp:TextBox ID="txtCaliper" SkinID="textpad" runat="server" MaxLength="20" Width="200px" Style="text-align: right;" onblur="todecimal_functionwithfourdecimal(this,this.value);AllowNumber(this,this.value);">1.0000</asp:TextBox>
                                            </div>
                                            <div style="float: left;">
                                                <div style="float: left; padding-left: 5px">
                                                    <asp:Label ID="lblCaliperType" runat="server" CssClass="normalText">Points</asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_Caliper" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                            </div>
                                        </div>
                                        <%--<div style="clear: both">
                                        </div>
                                        <div id="spn_Caliper_2" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objLangClass.GetLanguageConversion("Weight_Cannot_Be_Zero")%></span>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                                <div id="div_coated" align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%">
                                        <asp:Label ID="Label57" CssClass="normaltext" Text="Coated" runat="server"></asp:Label>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlCoated" CssClass="normaltext" runat="server" Width="200px">
                                            <asp:ListItem Value="None">None</asp:ListItem>
                                            <asp:ListItem Value="Gloss">Gloss</asp:ListItem>
                                            <asp:ListItem Value="Matt">Matt</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="div_colour" align="left" style="display: none;">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="lblColour" CssClass="normaltext" Text="Colour" runat="server"></asp:Label>
                                    </div>
                                    <div class="box" style="padding-left: 5px;">
                                        <asp:TextBox ID="txtColour" SkinID="textpad" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label40" CssClass="normaltext" runat="server"><%=objLangClass.GetLanguageConversion("Inventory_Code")%></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box" style="padding-left: 5px">
                                        <asp:TextBox ID="txtInvCode" onblur="CallonBlur(this.value,'spn_txtInvCode');TakeALookNew();"
                                            SkinID="textpad" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                        <span id="spn_txtInvCode" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px;">
                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Part_Name_Code")%>
                                        </span><span id="spn_txtInvNameCode" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; white-space: nowrap;">
                                            <%=objLangClass.GetLanguageConversion("Part_Code_Already_Exists")%></span>
                                    </div>
                                </div>
                                <div align="left">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label41" CssClass="normaltext" Text="Part Category" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlInvCategory" CssClass="normaltext" runat="server" Width="200px" 
                                            onchange="javascript:ShowCategoryWise(this);CallonChange(this.value,'spn_ddlInvCategory');ddlInvCategorySelectedIndexChanged();return false;">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hid_CategoryID" runat="server" Value="0" />
                                        <asp:HiddenField ID="hid_SubCategoryID" runat="server" Value="0" />
                                        <asp:HiddenField ID="hid_Properties" runat="server" Value="" />
                                        <asp:HiddenField ID="hid_SubCategoryName" runat="server" Value="" />
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_ddlInvCategory" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please select Part Category")%></span>
                                            </div>
                                        </div>
                                        <script type="text/javascript">

                                            var CompanyID = '<%=CompanyID %>';
                                            var UserID = '<%=UserID %>'
                                            var div_Paper_Type = "div_paperType";
                                            var divLargeFormatMaterial = "divLargeFormatMaterial";
                                            var LargeFormat = "<%=LargeFormat %>";

                                            var div_Ink_Type = "div_InkType";
                                            var div_minimum_ink_cost = "divMinimumCost";
                                            var div_CostID = "div_cost";
                                            var div_PackedInPrice = "divPackedInPackPrice";

                                            var div_SizeWeightCoated = "div_size_wgt_coated";
                                            var div_CostPerMtr = "div_CostPerMtr";


                                            var div_Ink_Absorption = "div_InkAbsorption";
                                            var div_Max_Impressions = "div_maxImpressions";
                                            var div_ProcSellExpo = "div_proc_sell_expo";
                                            var divColour = "div_colour";
                                            var div_Weight = "div_basisweight";
                                            var div_Coated = "div_coated";
                                            var div_Ink_Properties = "div_inkproperties";
                                            var hid_CategoryID = "<%=hid_CategoryID.ClientID %>";
                                            var hid_SubCategoryName = "<%=hid_SubCategoryName.ClientID %>";
                                            var hid_Properties = "<%=hid_Properties.ClientID %>";
                                            var hid_SubCategoryID = "<%=hid_SubCategoryID.ClientID %>";
                                            var str_prop3 = "";
                                            var ddlText;
                                            var ddlValue;
                                            var txtPacked = "<%=txtPackedIn.ClientID %>";
                                            var ddlPacked = "<%=ddlPackedIn.ClientID %>";
                                            var ServerName_Inventory = "<%=ServerName_Inventory %>";
                                            var div_Caliper = "div_Caliper";

                                            
                                        </script>
                                    </div>
                                </div>

                                <div align="left">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label43" CssClass="normaltext" Text="Location" runat="server"></asp:Label>
                                    </div>
                                    <div class="box" style="padding-left: 5px">
                                        <div style="width: 200px;">
                                            <asp:TextBox ID="txtInvLocation" SkinID="textpad" runat="server" CssClass="textboxnew1"
                                                MaxLength="50" Width="200px"></asp:TextBox>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_txtInvLocation" style="display: none; width: auto; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter Location")%>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label44" CssClass="normaltext" Text="Status" runat="server"></asp:Label>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlInvStatus" CssClass="normaltext" runat="server" Width="200px">
                                            <asp:ListItem>Available</asp:ListItem>
                                            <asp:ListItem>Discontinued</asp:ListItem>
                                        </asp:DropDownList>
                                        <span id="spn_ddlInvStatus" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px;">
                                            <%=objlang.GetValueOnLang("Please select Status")%>
                                        </span>
                                    </div>
                                </div>
                                <div align="left">
                                    <%--ppppppppp--%>
                                    <div class="bglabel" style="width: 30%;">
                                        <div style="float: left">
                                            <asp:Label ID="Label4" runat="server" Text="Supplier" CssClass="normaltext"></asp:Label>
                                        </div>
                                        <div id="DivImageButton8" runat="server" style="float: right">
                                            <asp:ImageButton Style="vertical-align: top" ID="ImageButton8" Visible="true" runat="server"
                                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                               OnClientClick="javascript:open_popupforsupplier();return false;" ></asp:ImageButton> <%--OnClick="ImageButton8_Click" --%>
                                        </div>
                                        <div style="float: right">
                                            <asp:ImageButton Style="vertical-align: top" ID="ImageButtonPlus" Visible="false"
                                                runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                                OnClientClick="javascript:ImageButtonPlus_Click();return false"></asp:ImageButton>
                                        </div>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlSupplier" CssClass="normaltext" runat="server" Width="200px"
                                            onchange="javascript:GetSupplier();return false;">
                                        </asp:DropDownList>
                                        <span id="spn_ddlSupplier" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px;">
                                            <%=objlang.GetValueOnLang("Please select Supplier")%>
                                        </span>
                                    </div>
                                </div>
                                <div align="left" runat="server" id="div_AccountCode">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:DropDownList ID="ddlAccountCode" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="float: right; width: 50%">
                                <div id="divLargeFormatMaterial" style="display: none;">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="lblLargeFroamtMaterial" CssClass="normaltext" Text="Large Format Material"
                                            runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="chk_LargeFormatMaterial" runat="server" />
                                    </div>
                                </div>
                                <div id="div_paperType" style="display: none;">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label58" CssClass="normaltext" Text="Paper Type" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlPaperType" onchange="ShowddlPaperType();" CssClass="normaltext"
                                            runat="server" Width="175px">
                                            <asp:ListItem Text="Sheet" Value="sheet">Sheet</asp:ListItem>
                                            <asp:ListItem Text="Web Printing" Value="web printing">Roll</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <script type="text/javascript" language="javascript">
                                            //// Paper Type
                                            var ddlPaperTypeID = document.getElementById("<%=ddlPaperType.ClientID %>");
                                    </script>
                                </div>
                                <%--for ink dropdown done by smitha on 21/10/10--%>
                                <div id="div_InkType" style="display: none;">
                                    <div class="bglabel" style="height: 30px; width: 30%;">
                                        <asp:Label ID="lblInkType" CssClass="normaltext" Text="Ink Costing Type" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="ddlsetting">
                                        <asp:DropDownList ID="ddlInkType" CssClass="normaltext" onchange="javascript:ShowddlInkType(); return false;"
                                            runat="server" Width="175px">
                                            <asp:ListItem Selected="True" Text="Yield" Value="Y"></asp:ListItem>
                                            <asp:ListItem Text="Matrix" Value="M">Matrix</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <div>
                                        &nbsp;
                                    </div>
                                    <div class="smallgraytext" style="padding-left: 5px;">
                                        <span style="padding-left: 5px">
                                            <%=objLangClass.GetLanguageConversion("For_Large_Format_Inks_Please_Use_The_Yield_Cost_Type")%></span>
                                    </div>
                                </div>
                                <div id="divMinimumCost" align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label7" CssClass="normaltext" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box">
                                        <div style="float: left; padding-left: 3px;">
                                            <asp:TextBox ID="txtminimum" Width="80px" CssClass="textboxnew" MaxLength="15" runat="server"
                                                Text="0.00" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);IsDecimalValue(this.value,'Spn_MinimumCost');"></asp:TextBox>
                                        </div>
                                        <span id="Spn_MinimumCostID"></span><span id="Spn_MinimumCost" class="spanerrorMsg"
                                            style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span><span id="Span3"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter Integer Value")%></span><span id="Spn_MinimumCostreq"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter Set up cost")%>
                                                </span>
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                                    </div>
                                </div>
                                <%--for ink dropdown done by smitha on 21/10/10--%>
                                <div id="div_cost" align="left">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label49" CssClass="normaltext" Text="Cost($)" runat="server"></asp:Label><span
                                            style="color: red;"> *</span>
                                    </div>
                                    <div class="box" style="border: 0px solid red; padding-left: 3px;" nowrap="nowrap">
                                        <div style="border: 0px solid; float: left; padding-left: 3px;" nowrap="nowrap">
                                            <asp:TextBox ID="txtCost" SkinID="textpad" Width="73px" runat="server" Text="0.00"
                                                MaxLength="12" onblur="todecimal_function(this,this.value);CalculatePackPrice();CalSellingPrice();"></asp:TextBox><%----%>
                                            &nbsp;<%=objLangClass.GetLanguageConversion("Per")%>
                                            <asp:TextBox ID="txtPer" SkinID="textpad" Width="71px" runat="server" Text="0" MaxLength="8"
                                                onblur="CalculatePackPrice();CalSellingPrice();"></asp:TextBox><%--onKeyup="isInteger('spn_per',this.value)"--%>
                                            <span id="spn_permtr"></span><span id="spn_cost" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span><span id="spn_per"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter Integer Value")%>Please enter Integer Value</span>
                                            <span id="spn_CostPer" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter Cost & Quantity")%></span><span id="spn_CostPerZero"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Cost Can't be Zero")%></span>
                                            <asp:HiddenField ID="hid_perqty" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>

                                <div id="divPackedInPackPrice" align="left">
                                    <div id="divPackedIn" align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label50" CssClass="normaltext" Text="Packed In" runat="server"></asp:Label>
                                            <span style="color: red;">*</span>
                                        </div>
                                        <div class="ddlsetting" style="width: auto;">
                                            <div>
                                                <div style="width: 103px; padding-left: 1px;">
                                                    <asp:TextBox ID="txtPackedIn" SkinID="textpad" runat="server" Text="1" MaxLength="20"
                                                        onblur="CalculatePackPrice();CallonBlur(this.value,'spn_packedinreq');                                            
                                            IsDecimalValue(this.value,'spn_packedin');"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div style="float: left; padding-left: 1px;">
                                                <asp:DropDownList ID="ddlPackedIn" CssClass="normaltext" Width="65px" runat="server"
                                                    Style="display: none" onchange="populatePackedIn(this.value);">
                                                    <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                    <asp:ListItem Value="ml" Text="ml"></asp:ListItem>
                                                    <asp:ListItem Value="Lbs" Text="Lbs"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="spn_packedinreq" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter Packed in Qty")%></span>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_packedin" style="display: none; width: auto; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                        </div>
                                       
                                    </div>
                                    <div id="divPackPrice" align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label51" CssClass="normaltext" Text="Pack Price ($)" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="padding-left: 6px;">
                                            <asp:TextBox ID="txtPackedPrice" SkinID="textpad" runat="server" Text="0.00" MaxLength="20"
                                                Enabled="false"></asp:TextBox><%--onKeyup="checkDecimals('spn_packedprice',this.id, this.value)"--%>
                                            <span id="spn_packedprice" class="spanerrorMsg" style="display: none; width: 175px">
                                                <%=objlang.GetValueOnLang("Please enter decimal value")%>
                                            </span>
                                            <asp:HiddenField ID="hid_packprice" runat="server" Value="0" />
                                        </div>
                                    </div>
                                  
                                </div>
                                <div id="divMarkup" align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="LabelMarkup" CssClass="normaltext" Text="Markup %" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="padding-left: 6px;">
                                            <asp:TextBox ID="txtMarkup" SkinID="textpad" runat="server" Text="0.00" MaxLength="20"
                                                Enabled="true"></asp:TextBox>
                                            <span id="spn_markup" class="spanerrorMsg" style="display: none; width: 175px">
                                                <%=objlang.GetValueOnLang("Please enter decimal value")%>
                                            </span>
                                            <asp:HiddenField ID="hid_markup" runat="server" Value="0" />
                                        </div>
                                    </div>
                                <div id="div_proc_sell_expo" style="display: none;">
                                    <div align="left" style="display: none">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label52" CssClass="normaltext" Text="Process Charge ($)" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtProcessCharge" SkinID="textpad" runat="server" Text="0.00" MaxLength="12"
                                                onblur="CalSellingPrice();CallonBlur(this.value,'spn_processchargereq');"></asp:TextBox>
                                            <span id="spn_processchargereq" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter Process Charge")%>
                                            </span><span id="spn_processcharge" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter decimal value upto 4 decimals")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label53" CssClass="normaltext" Text="Selling Price ($)" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtSellingPrice" SkinID="textpad" runat="server" Text="0.00" MaxLength="12"
                                                Enabled="false"></asp:TextBox><%--onblur="CallonBlur(this.value,'spn_sellingpricereq');CheckDecimalPlus(this.value,'spn_sellingpricereq','spn_sellingprice','yes')"--%>
                                            <span id="spn_sellingpricereq" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter Selling Price")%></span><span id="spn_sellingprice"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter decimal value upto 4 decimals")%></span>
                                            <asp:HiddenField ID="hid_sellingprice" runat="server" Value="0" />
                                        </div>
                                        <script>
                                            var hid_sellingprice = document.getElementById("<%=hid_sellingprice.ClientID %>");
                                        </script>
                                    </div>
                                </div>
                                <div id="div_maxImpressions" style="display: none">
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label60" CssClass="normaltext" Text="Max. No. of Impressions " runat="server"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtImpressions" SkinID="textpad" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_size_wgt_coated" style="display: none">
                                    <div align="left" id="div_size">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label54" CssClass="normaltext" Text="Size Ordered" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div id="div_Inventory_ddl_Size" class="ddlsetting" style="width: auto;">
                                            <asp:DropDownList ID="ddlPaperSize" CssClass="normaltext" runat="server" Width="175.5px"
                                                onchange="CallonChange(this.value,'spn_papersize');
                                                LoadToSheetCustom(this.value);CalculatePackPrice();">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hid_ddlPrintSheetSize" runat="server" Value="0" />
                                            
                                            <div id="spn_papersize" style="display: none; width: auto;">
                                                <div class="RFV_Message">
                                                    <span style="width: auto; padding-left: 4px; padding-right: 4px">
                                                        <%=objLangClass.GetLanguageConversion("Please_Select_Paper_Size")%></span>
                                                </div>
                                            </div>
                                            <script>
                                                function LoadToSheetCustom(ddlValue) {
                                                    var hid_ddlPrintSheetSize = document.getElementById("<%=hid_ddlPrintSheetSize.ClientID %>").value;
                                                    var chkCustom = document.getElementById("<%=chkCustom.ClientID %>");
                                                    if (ddlValue == "0") {
                                                        document.getElementById("<%=txtPaperHeight.ClientID %>").value = '';
                                                        document.getElementById("<%=txtPaperWidth.ClientID %>").value = '';
                                                        chkCustom.checked = false;
                                                        PrintSheetCustom(chkCustom.id);
                                                    }
                                                    else {
                                                        var arr1 = hid_ddlPrintSheetSize.split('µ');
                                                        for (var i = 0; i < arr1.length; i++) {
                                                            var arr2 = arr1[i].split('±');
                                                            if (ddlValue == arr2[0]) {
                                                                document.getElementById("<%=txtPaperHeight.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[2], 0, '', false, false, false);
                                                                document.getElementById("<%=txtPaperWidth.ClientID %>").value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, arr2[3], 0, '', false, false, false);
                                                            }
                                                        }
                                                    }
                                                }

                                            </script>
                                        </div>
                                        <div id="div_Inventory_Custom_Size" class="box" style="display: none; width: 220px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="float: left; padding-left: 3px;">
                                                            <%=objlang.GetValueOnLang("Height")%>
                                                            &nbsp;<span class="SpanFontSize"></span><asp:TextBox ID="txtPaperHeight" SkinID="textPad"
                                                                Width="50px" runat="server" MaxLength="8" onblur="inventory_todecimal_function(this,this.value);CalculatePackPrice();">0</asp:TextBox>&nbsp;<%=PaperMeasure %>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="float: left; margin-left: -4%; padding-top: 5px;">
                                                            &nbsp;
                                                            <%=objlang.GetValueOnLang("Width")%>
                                                            &nbsp;&nbsp;<span class="SpanFontSize"></span><asp:TextBox ID="txtPaperWidth" SkinID="textPad"
                                                                Width="50px" runat="server" MaxLength="8" onblur="inventory_todecimal_function(this,this.value);CalculatePackPrice();">0</asp:TextBox>&nbsp;<%=PaperMeasure %>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <span id="spn_height" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objlang.GetValueOnLang("Please enter numeric value")%></span><span id="spn_width"
                                                    class="spanerrorMsg" style="display: none">
                                                    <%=objlang.GetValueOnLang("Please enter Integer Value")%></span><span id="spn_heightwidthcheck"
                                                        class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter Height & Width")%></span><span id="spn_heightwidthcheck_2"
                                                            class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                            <%=objlang.GetValueOnLang("Height & Width cannot be 0")%>
                                                        </span>
                                            <asp:HiddenField ID="hid_PaperWidthType" runat="server" Value="mm" />
                                        </div>
                                        <script type="text/javascript">
                                                function PrintSheetCustom(chID) {
                                                    document.getElementById("div_Inventory_ddl_Size").style.display = "none";
                                                    document.getElementById("div_Inventory_Custom_Size").style.display = "none";
                                                    document.getElementById("spn_height").style.display = "none";
                                                    var chCheck = document.getElementById(chID).checked;
                                                    if (chCheck) {
                                                        document.getElementById("div_Inventory_Custom_Size").style.display = "block";
                                                    }
                                                    else {
                                                        document.getElementById("div_Inventory_ddl_Size").style.display = "block";
                                                    }
                                                }

                                        </script>
                                        <div id="div_chkCustom" style="float: left;">
                                            <div style="padding-top: 1px; float: left; margin-top: 2px">
                                                <asp:CheckBox ID="chkCustom" runat="server" onclick="javascript:PrintSheetCustom(this.id);" />
                                            </div>
                                            <div style="float: left; margin-top: 7px">
                                                <span id="SpnCustom" onclick="javascript:spnchkbox_CustomClick();" style="cursor: pointer">
                                                    <%=objLangClass.GetLanguageConversion("Custom")%></span>
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <script type="text/javascript">
                                            var ddlPaperSize = document.getElementById('<%=ddlPaperSize.ClientID %>');
                                            var chidd = document.getElementById('<%=chkCustom.ClientID %>');
                                            var customclick = document.getElementById("<%=chkCustom.ClientID%>");
                                        </script>
                                    </div>
                                    <div align="left" id="div_WebPrinting" style="display: none;">
                                        <div align="left">
                                            <div class="bglabel" style="width: 30%;">
                                                <asp:Label ID="Label1" CssClass="normaltext" Text="Width" runat="server"></asp:Label>
                                                <span style="color: Red;">*</span>
                                            </div>
                                            <div class="box">
                                                <div style="float: left">
                                                    <asp:TextBox ID="txtWebWidth" SkinID="textpad" runat="server" Text="0" MaxLength="20"
                                                        Width="175px" onblur="todecimal_function(this,this.value);CalculatePackPrice();"></asp:TextBox>
                                                    <asp:Label ID="lblWidthType" runat="server" CssClass="normalText">mm</asp:Label>
                                                </div>
                                                <div style="float: left; padding-left: 5px;">
                                                    
                                                </div>
                                                <span id="spn_webwidth" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                </span>
                                            </div>
                                            <div class="bglabel" style="width: 30%;">
                                                <asp:Label ID="Label2" CssClass="normaltext" Text="Length" runat="server"></asp:Label>
                                                <span style="color: Red;">*</span>
                                            </div>
                                            <div class="box" nowrap="nowrap" style="width: 230px; float: left; nowrap: nowrap;">
                                                <asp:TextBox ID="txtWebLength" SkinID="textpad" runat="server" Text="0" MaxLength="20"
                                                    onblur="todecimal_function(this,this.value);CalculatePackPrice();MakePrice2Decimal(this);"
                                                    onkeyup="checkDecimals('spn_length',this.id,this.value);"></asp:TextBox>
                                                <asp:Label ID="lblLengthType" runat="server" CssClass="normalText"></asp:Label>
                                                <span id="spn_length" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-right: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_CostPerMtr" align="left" style="display: none">
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%">
                                            <asp:Label ID="lblCostpermtr" CssClass="normaltext" Text="Cost per Meter ($)" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box" style="padding-left: 2px">
                                            <%=comm.GetCurrencyinRequiredFormate("",true)%><asp:Label ID="lblCostperMtrvalue"
                                                CssClass="normaltext" runat="server">0.00</asp:Label>&nbsp;<asp:Label ID="lblpreLnFtMtr"
                                                    CssClass="normaltext" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hid_costperMtr" runat="server" Value="0" />
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%">
                                            <asp:Label ID="lblCostperSQmtr" CssClass="normaltext" Text="Cost per Meter ($)" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <%=comm.GetCurrencyinRequiredFormate("",true)%><asp:Label ID="lblCostPerReel" CssClass="normaltext"
                                                runat="server">0.00</asp:Label>&nbsp;<asp:Label ID="lblpreSqFtMtr" CssClass="normaltext"
                                                    runat="server"></asp:Label>
                                            <asp:HiddenField ID="hid_costperreel" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>
                               
                                <div id="div_InkAbsorption" style="display: none;">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label56" CssClass="normaltext" Text="Ink Absorption" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="txtInkAbsorption" SkinID="textpad" runat="server" Text="0" MaxLength="12"
                                            onblur="CallonBlur(this.value,'spn_inkabsorptionreq');checkDecimals('spn_inkabsorption',this.id, this.value)"></asp:TextBox>
                                        &nbsp; % <span id="spn_inkabsorptionreq" class="spanerrorMsg" style="display: none; width: 175px">
                                            <%=objlang.GetValueOnLang("Please enter Ink Absorption")%></span><span id="spn_inkabsorption"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px"><%=objlang.GetValueOnLang("Please enter decimal value")%></span>
                                    </div>
                                </div>
                                
                                <div id="divSetUpCost" align="left" style="display: none">
                                    <div class="bglabel" style="width: 30%;">
                                        <asp:Label ID="Label6" CssClass="normaltext" Text="Set up Cost ($)" runat="server"></asp:Label>
                                        <span style="color: Red;">*</span>
                                    </div>
                                    <div class="box">
                                        <div style="float: left;">
                                            <asp:TextBox ID="txtSetupCost" Width="80px" CssClass="textboxnew" MaxLength="15"
                                                runat="server" Text="0.00" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);IsDecimalValue(this.value,'Spn_Setupcost');"></asp:TextBox>
                                        </div>
                                        <span id="Spn_SetCostID"></span><span id="Spn_Setupcost" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                            <%=objlang.GetValueOnLang("Please enter numeric value")%></span><span id="Spn_Setupcostreq"
                                                class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px"><%=objlang.GetValueOnLang("Please enter Set up cost")%></span>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                    </div>
                                </div>
                                <div id="div_inkproperties" style="display: none;">
                                    <div align="left" style="display: none">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label62" CssClass="normaltext" Text="Washup Counter" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtWashup" SkinID="textpad" runat="server" Text="0" MaxLength="8"
                                                onblur="CalculatePackPrice();CallonBlur(this.value,'spn_washupreq');IsIntegerParameter(this.value,'spn_washup')"></asp:TextBox>
                                            <span id="spn_washupreq" class="spanerrorMsg" style="display: none; width: 175px">
                                                <%=objlang.GetValueOnLang("Please enter Washup Counter")%></span><span id="spn_washup"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objlang.GetValueOnLang("Please enter Integer Value")%></span>
                                        </div>
                                    </div>
                                    <div align="left" id="div_Yield">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label63" CssClass="normaltext" Text="Yield" runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="float: left; padding-left: 3px;">
                                                <asp:TextBox ID="txtYield" SkinID="textpad" Width="100px" runat="server" Text="0.00"
                                                    MaxLength="20" onblur="CallonBlur(this.value,'spn_yieldreq');CheckDecimalPlus(this.value,'spn_yieldreq','spn_yield','yes');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; padding: 5px; border: 0px solid red;">
                                                <asp:Label ID="lblPackedIn" CssClass="normaltext" runat="server"></asp:Label>
                                                <asp:HiddenField runat="server" ID="hdnPackedIn" Value="Sq.CM/KG" />
                                            </div>
                                            <span id="spn_yieldreq" class="spanerrorMsg" style="display: none; width: 175px">
                                                <%=objLangClass.GetLanguageConversion("Please_Enter_Yield")%>
                                            </span><span id="spn_yield" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objLangClass.GetLanguageConversion("Please_Enter_Decimal_Value_Upto_4_Decimals")%></span>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                        <div align="left" class="smallgraytext">
                                            <span id="notetext">
                                                <%=objLangClass.GetLanguageConversion("Warehouse_Note")%></span>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="DIV_TAKE_MATRIX" runat="server" style="width: 100%;" align="left">
                                    <div id="divMatrix" align="center" style="display: none; border: 0px solid blue; width: 100%; margin-top: 15px">
                                        <div align="left" style="width: 100%; vertical-align: top; border: 0px solid red; padding-left: 10px">
                                            <b>
                                                <%=objLangClass.GetLanguageConversion("Matrix_Method")%></b>
                                        </div>
                                        <div align="left" style="width: 100%; vertical-align: top; border: 0px solid red; padding-left: 50px; padding-top: 5px">
                                            <div style="clear: both">
                                            </div>
                                            <div style="float: left; width: 11%">
                                                <span>&nbsp;</span>
                                            </div>
                                            <div align="right" style="float: left; width: 24%; border: 0px solid red; padding-left: 1px">
                                                <span>
                                                    <%=objLangClass.GetLanguageConversion("Quantity")%></span>
                                            </div>
                                            <div align="center" style="float: left; width: 24%; border: 0px solid red">
                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Cost")%></span>
                                            </div>
                                            <div align="center" style="float: left; width: 17%; border: 0px solid red">
                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Per")%></span>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                        </div>
                                        <div>
                                            <div align="left" style="float: left; width: 90%; vertical-align: top; padding-top: 10px; padding-left: 60px; border: 0px solid red;">
                                                <div style="float: left; width: 100%;">
                                                    <div style="float: left; width: 10%;">
                                                        <span>&nbsp;</span>
                                                    </div>
                                                    <div style="float: left; width: 10%; text-align: right">
                                                        <span id="spnSheetsFrom1" runat="server">1</span>
                                                        <asp:TextBox ID="txtSheetsFrom1" runat="server" Style="display: none">1</asp:TextBox>
                                                        <asp:HiddenField ID="hid_InkmatrixSheetsfromID_1" Value="0" runat="server" />
                                                    </div>
                                                    <div style="float: left; width: 3%; text-align: center">
                                                        <span>-</span>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtSheetsTo1" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="8" onblur="checkNextCharge(this.value,1);AllowNumber(this,this.value);">1000</asp:TextBox>
                                                        <span id="spnGetID" runat="server"></span>
                                                        <script>
                                                            var GetID = (document.getElementById("<%=spnGetID.ClientID %>").id).replace("spnGetID", "");
                                                            var CheckZone = true;
                                                            function checkNextCharge(txtValue, ROW) {
                                                                var TextBoxTo = "txtSheetsTo";
                                                                var LabelFrom = "spnSheetsFrom";
                                                                var txtFrom = "txtSheetsFrom";

                                                                var ConcatID = GetID + TextBoxTo; //Ct00_ccc
                                                                LabelFrom = GetID + LabelFrom; //Ct00_ccc
                                                                txtFrom = GetID + txtFrom; //Ct00_ccc
                                                                var start = Number(ROW + 1);

                                                                if (!isNaN(txtValue)) {
                                                                    var IsCorrect = true;
                                                                    if (Number(ROW) > 1) {
                                                                        var First = document.getElementById(ConcatID + Number(ROW - 1)).value;
                                                                        var Second = document.getElementById(ConcatID + Number(ROW)).value;
                                                                        IsCorrect = (Number(Second) > Number(First));
                                                                    }
                                                                    if (IsCorrect) {
                                                                        document.getElementById(LabelFrom + "" + start).innerHTML = Number(txtValue) + Number(1);
                                                                        document.getElementById(txtFrom + "" + start).value = Number(txtValue) + Number(1);
                                                                        if (ROW == 4) {
                                                                            document.getElementById(LabelFrom + "5").innerHTML = "";
                                                                            document.getElementById(LabelFrom + "5").innerHTML = Number(txtValue) + Number(1);
                                                                            document.getElementById(LabelFrom + "5").innerHTML = "+" + document.getElementById(LabelFrom + "5").innerHTML;
                                                                            document.getElementById(txtFrom + "5").value = Number(txtValue) + Number(1);
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        </script>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkChargableCost1" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="15" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);">1.50</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 15%;">
                                                        <asp:TextBox ID="txtInkCostPer1" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12" onblur="AllowNumber(this,this.value);">1000</asp:TextBox>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 3%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div>
                                                            <span id="spn_InkValue_1" class="spanerrorMsg" style="display: none; width: 185px;">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 100%;">
                                                    <div style="float: left; width: 10%">
                                                        <span>&nbsp;</span>
                                                    </div>
                                                    <div style="float: left; width: 10%; text-align: right">
                                                        <span id="spnSheetsFrom2" runat="server">1001</span>
                                                        <asp:TextBox ID="txtSheetsFrom2" runat="server" Style="display: none">1001</asp:TextBox>
                                                        <asp:HiddenField ID="hid_InkmatrixSheetsfromID_2" Value="0" runat="server" />
                                                    </div>
                                                    <div style="float: left; width: 3%; text-align: center">
                                                        <span>-</span>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtSheetsTo2" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="8" onblur="checkNextCharge(this.value,2);AllowNumber(this,this.value);">2000</asp:TextBox>
                                                        <%--onblur="checkNextCharge(this.value,2,'color');"--%>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkChargableCost2" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="15" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);">1.25</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkCostPer2" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12" onblur="AllowNumber(this,this.value);">1000</asp:TextBox>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 3%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div>
                                                            <span id="spn_InkValue_2" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px;">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 100%">
                                                    <div style="float: left; width: 10%">
                                                        <span>&nbsp;</span>
                                                    </div>
                                                    <div style="float: left; width: 10%; text-align: right">
                                                        <span id="spnSheetsFrom3" runat="server">2001</span>
                                                        <asp:TextBox ID="txtSheetsFrom3" runat="server" Style="display: none">2001</asp:TextBox>
                                                        <asp:HiddenField ID="hid_InkmatrixSheetsfromID_3" Value="0" runat="server" />
                                                    </div>
                                                    <div style="float: left; width: 3%; text-align: center">
                                                        <span>-</span>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtSheetsTo3" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="8" onblur="checkNextCharge(this.value,3);AllowNumber(this,this.value);">3000</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkChargableCost3" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="15" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);">1.00</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkCostPer3" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12" onblur="AllowNumber(this,this.value);">1000</asp:TextBox>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 3%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div>
                                                            <span id="spn_InkValue_3" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px;">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 100%;">
                                                    <div style="float: left; width: 10%">
                                                        <span>&nbsp;</span>
                                                    </div>
                                                    <div style="float: left; width: 10%; text-align: right">
                                                        <span id="spnSheetsFrom4" runat="server">3001</span>
                                                        <asp:TextBox ID="txtSheetsFrom4" runat="server" Style="display: none">3001</asp:TextBox>
                                                        <asp:HiddenField ID="hid_InkmatrixSheetsfromID_4" Value="0" runat="server" />
                                                    </div>
                                                    <div style="float: left; width: 3%; text-align: center">
                                                        <span>-</span>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtSheetsTo4" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="8" onblur="checkNextCharge(this.value,4);AllowNumber(this,this.value);">10000</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkChargableCost4" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="15" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);">0.75</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkCostPer4" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12" onblur="AllowNumber(this,this.value);">1000</asp:TextBox>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 3%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div>
                                                            <span id="spn_InkValue_4" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px;">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 100%; border: 0px solid blue">
                                                    <div style="float: left; width: 10%; border: 0px solid red">
                                                        <span>&nbsp;</span>
                                                    </div>
                                                    <div style="float: left; width: 12%; text-align: left; border: 0px solid red">
                                                        <span id="spnSheetsFrom5" runat="server">&nbsp;&nbsp;&nbsp;+10001</span>
                                                        <asp:TextBox ID="txtSheetsFrom5" runat="server" Style="display: none">10001</asp:TextBox>
                                                        <asp:HiddenField ID="hid_InkmatrixSheetsfromID_5" Value="0" runat="server" />
                                                    </div>
                                                    
                                                    <div style="float: left; width: 24%">
                                                        <asp:TextBox ID="txtSheetsTo5" runat="server" Style="display: none">0</asp:TextBox>&nbsp;
                                                    </div>
                                                    <div style="float: left; width: 23%;">
                                                        <asp:TextBox ID="txtInkChargableCost5" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="15" onblur="todecimal_function(this,this.value);AllowNumber(this,this.value);">0.50</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 23%">
                                                        <asp:TextBox ID="txtInkCostPer5" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12" onblur="AllowNumber(this,this.value);">1000</asp:TextBox>
                                                    </div>
                                                    <div style="float: left; width: 15%; display: none">
                                                        <asp:TextBox ID="txtColorChargableRate8" runat="server" Width="80px" CssClass="textboxnew"
                                                            MaxLength="12">0.15</asp:TextBox>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 10%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div style="width: 3%; float: left;">
                                                            &nbsp;
                                                        </div>
                                                        <div>
                                                            <span id="spn_InkValue_5" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                                <%=objlang.GetValueOnLang("Please enter numeric value")%>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                                <div class="only10px">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div class="only5px">
                        </div>
                        <div align="left" style="width: 100%">
                            <div style="float: left; width: 49%">
                                &nbsp;
                            </div>
                            <div style="float: left; width: 50%">
                                <div style="float: left; width: 5%">
                                    &nbsp;
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <%--By Jagat On 21/July/2012--%>
                                <div style="float: left;">
                                    <div id="div_btncancel" style="display: block">
                                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" CausesValidation="false"
                                            OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
                                    </div>
                                    <div id="div_cancelprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <%--End--%>
                                <div runat="server" id="divbtnNext">
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <div id="div_btnnext" style="display: block">
                                            <asp:Button ID="btnNext" CssClass="button" runat="server" Text="Next" OnClientClick="javascript:var a=CallNewValidation('s');if(a)loadingimage(this.id,'div_nextprocess');return a;" />
                                        </div>
                                        <div id="div_nextprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="Divdiv_btnsave" runat="server" style="float: left;">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save1" OnClick="btnSave_OnClick"
                                            OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_saveprocess');return a;"
                                            CausesValidation="true" /><%--hideDiv('divinventoryadd');--%>
                                    </div>
                                    <div id="div_saveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="Divdiv_btnstay" runat="server" style="float: left;">
                                    <div id="div_btnstay" style="display: block">
                                        <asp:Button ID="btnStay" CssClass="button" runat="server" Text="Save & Stay" OnClick="btnStay_OnClick"
                                            CausesValidation="true" OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_stayprocess');return a;"
                                            Visible="false" />
                                    </div>
                                    <div id="div_stayprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="Divdiv_btndelete" runat="server" style="float: left;">
                                    <div id="div_btndelete" style="display: block">
                                        <asp:Button ID="btnDelete" CssClass="button" runat="server" Text="Delete" OnClick="btnDelete_OnClick"
                                            OnClientClick="javascript:var a=window.confirm('Are you sure you want to delete this record?');if(a)loadingimage(this.id,'div_deleteprocess');return a;"
                                            Visible="false" />
                                    </div>
                                    <div id="div_deleteprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <div id="div_btnarchieve" style="display: block">
                                        <asp:Button ID="btnArchive" CssClass="button" runat="server" Text="Archive this Item"
                                            OnClick="btnArchive_OnClick" OnClientClick="javascript:var a=window.confirm('Are you sure you want to archive this record?');if(a)loadingimage(this.id,'div_archieveprocess');return a;"
                                            Visible="false" />
                                    </div>
                                    <div id="div_archieveprocess" style="width: 104px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div>
                            <asp:LinkButton ID="lnkCopyInventory" runat="server" Text="" OnClick="lnkCopyInventory_OnClick"
                                CausesValidation="false" Visible="false"></asp:LinkButton>
                        </div>
                    </div>
                    <div id="divStockItem" style="display: none">
                        <div style="width: 100%; padding-top: 5px; padding-bottom: 5px">
                            <div style="float: left; width: 40%;" align="left">
                                <fieldset>
                                    <legend>
                                        <%=objLangClass.GetLanguageConversion("Stock")%>
                                    </legend>
                                    <div class="header" style="margin-bottom: 8px; width: 40%;">
                                        <span class="HeaderText">
                                            <%=objLangClass.GetLanguageConversion("Current_Stock_Level")%></span>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" id="divRollStockQty" style="width: 30%; display: none;" runat="server">
                                            <asp:Label ID="Label3" CssClass="normaltext" Text="Roll Length" runat="server"></asp:Label>
                                        </div>
                                         <div class="box">
                                            <div style="width: 150px;display: none;" runat="server" id="divRollStockQtyContainer">
                                                <asp:TextBox ID="txtRollStockQty" SkinID="textpad" runat="server" Text="0" CssClass="textboxnew1"
                                                    MaxLength="8" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label45" CssClass="normaltext" Text="Opening Stock" runat="server"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtInStock" SkinID="textpad" runat="server" Text="0" onkeyup="CallonBlur(this.value,'spn_txtInStock');"
                                                    onblur="CallonBlur(this.value,'spn_txtInStock');" CssClass="textboxnew1" MaxLength="8"
                                                    onkeydown="txtInStock_keyDown();"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtInStock" style="display: none; width: 175px;">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 2px; padding-right: 2px;">
                                                        <%=objLangClass.GetLanguageConversion("Please_enter_Opening_Stock")%>
                                                    </span>
                                                </div>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtInStock_number" style="display: none; width: auto;">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left" runat="server" id="divAllocatedQty" style="display: none">
                                        <div class="bglabel" style="width: 30%">
                                            <asp:Label ID="Label8" CssClass="normaltext" Text="Allocated Qty" runat="server"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAllocatedQty" SkinID="textpad" runat="server" Text="0" CssClass="textboxnew1"
                                                    MaxLength="8" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left" runat="server" id="divAvailableQty" style="display: none;">
                                        <div class="bglabel" style="width: 30%">
                                            <asp:Label ID="lblAvailableQty" CssClass="normaltext" Text="Available Qty" runat="server"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAvailableQty" SkinID="textpad" runat="server" Text="0" CssClass="textboxnew1"
                                                    MaxLength="8" onkeyup="javascript:invAdjustment();" onkeydown="javascript:txtKeyDown();"></asp:TextBox>
                                                <asp:HiddenField ID="hdnAvailableQty" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="header" style="margin-bottom: 8px; width: 40%;">
                                        <span class="HeaderText">
                                            <%=objLangClass.GetLanguageConversion("ReOrder")%></span>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%">
                                            <asp:Label ID="Label46" CssClass="normaltext" Text="Re-Order Alert Level" runat="server"></asp:Label>
                                            <span style="color: red;">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtReorderLevel" SkinID="textpad" runat="server" Text="0" MaxLength="8"
                                                    CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtReorderLevel_number" style="float: left">
                                                <div>
                                                    <span id="spnReorderLevel_int" class="RFV_Message" style="display: none; width: 150px; float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span> <span id="spnReorderLevel_req"
                                                            class="RFV_Message" style="display: none; width: 174px; float: left; padding-left: 4px">
                                                            <%=objlang.GetValueOnLang("Please enter Re-Order Level")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabel" style="width: 30%;">
                                            <asp:Label ID="Label47" CssClass="normaltext" Text="Re-Order Quantity" runat="server"></asp:Label>
                                            <span style="color: red;">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtReorderQty" onblur="IsIntegerParameter(this.value,'spn_txtReorderQty_number')"
                                                    SkinID="textpad" runat="server" Text="0" MaxLength="8" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtReorderQty_number" style="display: none; width: 175px;">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px;">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                            <div id="spn_txtReorderQty_value" style="display: none; width: 200px;">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px; padding-right: 4px;">
                                                        <%=objLangClass.GetLanguageConversion("Please_enter_ReOrder_Quantity")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="header" id="divQtyAdjustment" style="display: none; width: 40%;" runat="server">
                                        <span class="HeaderText">
                                            <%=objLangClass.GetLanguageConversion("Qty_Adjustment")%></span>
                                    </div>
                                    <div style="margin-bottom: 8px; clear: both">
                                    </div>
                                    <div align="left" id="divQtyToAdjusted" runat="server" style="display: none;">
                                        <div class="bglabel" style="float: left; width: 30%">
                                            <asp:Label ID="lblQtyToBeAdjusted" runat="server" />
                                            
                                        </div>
                                        <div class="box" style="float: left">
                                            <div style="width: 200px; float: left">
                                                <div style="float: left;">
                                                    
                                                    <asp:DropDownList ID="ddlMinusPlus" runat="server" Style="height: 19px" onchange="Toggle()">
                                                        <asp:ListItem Text="+" Value="plus" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="-" Value="minus"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnQtyType" runat="server" Value="p" />
                                                </div>
                                                <div style="float: left; padding-left: 3px">
                                                    <asp:TextBox ID="txtQtyToAdjusted" runat="server" Text="0" MaxLength="8" CssClass="textboxnew"
                                                        Style="text-align: right" Width="135px" onkeyup="QtyAdjustment();" onblur="IsIntegerParameter(this.value,'spn_txtQtyToAdjusted_number')"
                                                        onkeydown="javascript:txtKeyDown();"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="spn_txtQtyToAdjusted_number" style="display: none; padding-left: 40px; width: 132px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <%=objlang.GetValueOnLang("Please enter numeric value")%></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left" id="divReasonadjustment" runat="server" style="display: none">
                                        <div class="bglabel" style="height: 47px; width: 30%;">
                                            <asp:Label ID="lblReasonadjustment" CssClass="normaltext" Text="Reason for adjustment"
                                                runat="server"></asp:Label>
                                            <span style="color: Red;">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtReasonadjustment" Text="Stock Replenished" onblur="javascript:CallBlur()"
                                                    SkinID="textpad" runat="server" Height="47px" TextMode="MultiLine" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="divReason" style="display: none; width: 170px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">Please enter reason text</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div style="float: right; width: 59%;" align="right">
                                <fieldset>
                                    <legend>
                                        <%=objLangClass.GetLanguageConversion("Alerts")%></legend>
                                    <div align="left">
                                        <div class="bglabel" style="height: 90px; width: 31%;">
                                            <asp:Label ID="Label11" CssClass="normaltext" Text="Alert the users " runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: auto">
                                            <asp:RadioButton ID="chkReorderLevelEveryTime" Text="Once only when the stock falls below the <br /> &nbsp;&nbsp;&nbsp;&nbsp; re-order level."
                                                runat="server" onclick="javascript:chkEveryTime_checked();validateMultipleEmailsCommaSeparated('','spn_To');" />
                                            <span class="smallgraytext">
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=objLangClass.GetLanguageConversion("This_May_Results_In_Multiple_Emails")%></span>
                                        </div>
                                        <div class="box">
                                            <asp:RadioButton ID="chkReorderLevelDaily" Text="Once per day until the stock is replenished"
                                                onclick="javascript:chkDaily_checked();validateMultipleEmailsCommaSeparated('','spn_To');" runat="server" />
                                        </div>
                                        <div class="box">
                                            <asp:RadioButton ID="rdoNone" Text="Don't alert users" onclick="javascript:rdoNone_checked();validateMultipleEmailsCommaSeparated('','spn_To');"
                                                runat="server" Checked="true" />
                                        </div>
                                    </div>
                                    
                                    <div align="left">
                                        <div class="bglabel" style="height: 42px; width: 31%;">
                                            <asp:Label ID="Label9" CssClass="normaltext" Text="Email address for alerts to be sent to"
                                                runat="server"></asp:Label><%--<span style="color: Red;"> *</span>--%>
                                        </div>
                                        <div class="box">
                                            <div style="width: 250px;">
                                                <asp:TextBox ID="txtemail" TextMode="MultiLine" SkinID="textpad" Width="250px" Height="45px"
                                                    runat="server" Text="info@infomazeapps.com" MaxLength="500" onblur="javascript:return validateMultipleEmailsCommaSeparated(this.value,'spn_To')">
                                                </asp:TextBox>
                                            </div>
                                            <div class="smallgraytext" style="width: 300px; padding-top: 5px">
                                                <%=objLangClass.GetLanguageConversion("Multiple_Emali_Address_Note")%>
                                            </div>
                                            <span id="spn_To" class="spanerrorMsg" style="width: 200px; display: none">
                                                <%=objlang.GetValueOnLang("Please enter valid email")%>
                                            </span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" Visible="false"
                                                ErrorMessage='<%#objlang.GetValueOnLang("Please Enter Email Id")%>' ControlToValidate="txtemail"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                   
                                </fieldset>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <br />
                            <div style="float: right; width: 49%;">
                                <div class="onlyEmpty">
                                </div>
                                <div style="float: left; width: 30%">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button ID="BtnPrevious" CssClass="button" runat="server" Text="Previous" CausesValidation="false"
                                        OnClientClick="javascript:return CallNewValidation('g');" />
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <div id="div_btncancelnew" style="display: block">
                                        <asp:Button ID="btnCancel_new" CssClass="button" runat="server" Text="Cancel" CausesValidation="false"
                                            OnClientClick="javascript:loadingimage(this.id,'div_cancelnewprocess');" OnClick="btnCancel_OnClick" />
                                    </div>
                                    <div id="div_cancelnewprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="Divdiv_btnsavenew" runat="server" style="float: left;">
                                    <div id="div_btnsavenew" style="display: block">
                                        <asp:Button ID="btnSave_new" CssClass="button" runat="server" Text="AFDS" OnClick="btnSave_OnClick"
                                            CausesValidation="true" OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_savenewprocess');return a;" />
                                    </div>
                                    <div id="div_savenewprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="Divdiv_btnstaynew" runat="server" style="float: left;">
                                    <div id="div_btnstaynew" style="display: block">
                                        <asp:Button ID="btnStay_new" CssClass="button" runat="server" Text="Save & Stay"
                                            Visible="false" OnClick="btnStay_OnClick" CausesValidation="true" OnClientClick="javascript:var a=CallValidation();if(a)loadingimage(this.id,'div_staynewprocess');return a;" />
                                    </div>
                                    <div id="div_staynewprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div id="divHistoryItem" style="display: none">
                        <div style="width: 100%; padding-top: 5px; padding-bottom: 5px">
                            <div style="float: left; width: 75%;">
                                <asp:UpdatePanel ID="pnlGridHistory" ChildrenAsTriggers="false" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="grdInventoryHistory" runat="server" AutoGenerateColumns="false"
                                            AllowSorting="true" OnPageIndexChanged="grdInventoryHistoryPageIndexChanged"
                                            PagerStyle-AlwaysVisible="true" AllowPaging="true" PageSize="50" GridLines="None"
                                            OnPageSizeChanged="grdInventoryHistoryPageSizeChanged" HeaderStyle-Font-Bold="true"
                                            DataSourceID="objDatagrdInventoryHistory" ClientSettings-EnableRowHoverStyle="true"
                                            OnItemDataBound="grdInventoryHistory_OnItemDataBound">
                                            <MasterTableView CommandItemDisplay="Top">
                                                <CommandItemTemplate>
                                                    <div id="DivExport" runat="server">
                                                        <a href="#" onclick="DownloadFile();" style="float: right; margin-right: 5px; margin-top: 5px">
                                                            <asp:Label ID="Label12" ToolTip="Export" runat="server">
                                                                    <input type="image" src="../images/export-icon1.jpg"  />
                                                            </asp:Label></a>
                                                    </div>
                                                </CommandItemTemplate>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Date" DataField="CreatedDate" SortExpression="CreatedDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnActionType" runat="server" Value='<%#Eval("actiontype") %>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Description" SortExpression="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="User" SortExpression="UserName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Adjusted Qty" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" SortExpression="quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("quantity")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <Columns>
                                                    <telerik:GridTemplateColumn DataField="instockQty" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" SortExpression="instockQty" HeaderText="InStock Qty">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInstockQty" runat="server" Text='<%#Eval("instockQty")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="Available Qty" DataField="FinalQuantity"
                                                        HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" SortExpression="FinalQuantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFinalQuantity" runat="server" Text='<%#Eval("FinalQuantity")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings ReorderColumnsOnClient="true" AllowDragToGroup="false">
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                        <asp:ObjectDataSource runat="server" ID="objDatagrdInventoryHistory" SelectMethod="Select_Activity_History_For_Inventory"
                                            TypeName="Printcenter.UI.Inventories.InventoryBasePage">
                                            <SelectParameters>
                                                <asp:QueryStringParameter Name="InventoryID" DefaultValue="0" Type="Int64" QueryStringField="id" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div id="divUnAuthorized" style="display: none">
                        <div style="width: 100%; padding-top: 5px; padding-bottom: 5px">
                            <div style="float: left; width: 49%;" class="smallgraytext">
                                <%=objlang.GetValueOnLang("This option is available only for users who have opted for Inventory Management")%>.
                                <br />
                                <%=objlang.GetValueOnLang("Please contact eprint support team for more details")%>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="div_trueStock" style="display: none; position: absolute; vertical-align: middle; z-index: 100; width: 35%"
        align="center">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                        <b>
                            <%=objLangClass.GetLanguageConversion("True_Stock_Quantity")%></b>
                    </div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="ImageButtonNew2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('c');"
                                UseSubmitBehavior="false" />
                        </div>
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
                    <div style="padding: 10px 5px 10px 0px; width: 98%">
                        <div class="" style="width: 100%">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblCopyStockQuantity" runat="server" Text="Enter the True stock quantity"
                                            CssClass="normaltext"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCopyStockQuantity" runat="server" CssClass="textboxnew" MaxLength="8"
                                            Text="0" onkeyup="javascript:validateQtyAmount();" onfocus="this.select();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:UpdatePanel ID="UPSAVE" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btnOk" Text="Save" CssClass="button" runat="server" OnClientClick="javascript:hideDiv('s');"
                                                    UseSubmitBehavior="false" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
                </td>
                <td class="popup-bottom-middlebg">&nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" Top="120px" Left="210px" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Resize">        
    </telerik:RadWindowManager>
</div>

<asp:Button ID="lnkFileDownload" runat="server" OnClick="lnkDownload_OnClick" Style="display: none"></asp:Button>

<asp:HiddenField ID="hdn_InvCatID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_InkType" runat="server" Value="0" />
<asp:HiddenField ID="hdn_amount" runat="server" Value="0" />
<asp:HiddenField ID="hdn_available" runat="server" Value="0" />
<asp:HiddenField ID="hid_3DecimalPaperSize" runat="server" Value="" />
<div style="float: left; width: 950px">
    &nbsp;
</div>
<script type="text/javascript" src="<%=strSitepath %>js/HelpText/Mask.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/commonloading.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">


                                                            //left side
                                                            var txtInvNameID = document.getElementById("<%=txtInvName.ClientID %>");

                                                            var txtInvCodeID = document.getElementById("<%=txtInvCode.ClientID %>");
    var ddlInvCategoryID = document.getElementById("<%=ddlInvCategory.ClientID %>");
    var txtInvLocationID = document.getElementById("<%=txtInvLocation.ClientID %>");
    var txtInStockID = document.getElementById("<%=txtInStock.ClientID %>");
    var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID %>");
    var txtReorderLevelID = document.getElementById("<%=txtReorderLevel.ClientID %>");
    var txtReorderQtyID = document.getElementById("<%=txtReorderQty.ClientID %>");
    //right side
    var txtCostID = document.getElementById("<%=txtCost.ClientID %>");
    var txtPerID = document.getElementById("<%=txtPer.ClientID %>");
    var txtPackedInID = document.getElementById("<%=txtPackedIn.ClientID %>");
    var txtPackedPriceID = document.getElementById("<%=txtPackedPrice.ClientID %>");
    var txtProcessChargeID = document.getElementById("<%=txtProcessCharge.ClientID %>");
    var txtSellingPriceID = document.getElementById("<%=txtSellingPrice.ClientID %>");
    var ddlPaperSizeID = document.getElementById("<%=ddlPaperSize.ClientID %>");
    var txtPaperHeightID = document.getElementById("<%=txtPaperHeight.ClientID %>");
    var txtPaperWidthID = document.getElementById("<%=txtPaperWidth.ClientID %>");
    var txtWebWidthID = document.getElementById("<%=txtWebWidth.ClientID %>");
    var txtWebLengthID = document.getElementById("<%=txtWebLength.ClientID %>");
    var txtBasisWeightID = document.getElementById("<%=txtBasisWeight.ClientID %>");
    var txtInkAbsorptionID = document.getElementById("<%=txtInkAbsorption.ClientID %>");
    var txtWashupID = document.getElementById("<%=txtWashup.ClientID %>");
    var txtYieldID = document.getElementById("<%=txtYield.ClientID %>");
    var txtminimumID = document.getElementById("<%=txtminimum.ClientID %>")
    var txtSetupCostID = document.getElementById("<%=txtSetupCost.ClientID %>");

    var hdn_InvCatID = document.getElementById("<%=hdn_InvCatID.ClientID %>");
    var hdn_InkType = document.getElementById("<%=hdn_InkType.ClientID %>");

    ////***************** Start of Validation on btnSave Onclick *************///
    var CheckFinal = false;
    var ddlPaperTypeID = document.getElementById("<%=ddlPaperType.ClientID %>");
    var ddlInkTypeID = document.getElementById("<%=ddlInkType.ClientID %>");
    var chkCustomID = document.getElementById("<%=chkCustom.ClientID %>");
    var div_Archivelnk = document.getElementById("divArchivelnk");

    var txtSheetsTo1ID = document.getElementById("<%=txtSheetsTo1.ClientID %>");
    var txtSheetsTo2ID = document.getElementById("<%=txtSheetsTo2.ClientID %>");
    var txtSheetsTo3ID = document.getElementById("<%=txtSheetsTo3.ClientID %>");
    var txtSheetsTo4ID = document.getElementById("<%=txtSheetsTo4.ClientID %>");

    var txtInkCostPer1ID = document.getElementById("<%=txtInkCostPer1.ClientID %>");
    var txtInkCostPer2ID = document.getElementById("<%=txtInkCostPer2.ClientID %>");
    var txtInkCostPer3ID = document.getElementById("<%=txtInkCostPer3.ClientID %>");
    var txtInkCostPer4ID = document.getElementById("<%=txtInkCostPer4.ClientID %>");
    var txtInkCostPer5ID = document.getElementById("<%=txtInkCostPer5.ClientID %>");

    var txtInkChargableCost1ID = document.getElementById("<%=txtInkChargableCost1.ClientID %>");
    var txtInkChargableCost2ID = document.getElementById("<%=txtInkChargableCost2.ClientID %>");
    var txtInkChargableCost3ID = document.getElementById("<%=txtInkChargableCost3.ClientID %>");
    var txtInkChargableCost4ID = document.getElementById("<%=txtInkChargableCost4.ClientID %>");
    var txtInkChargableCost5ID = document.getElementById("<%=txtInkChargableCost5.ClientID %>");

</script>
<script type="text/javascript" language="javascript">
    var hid_3DecimalPaperSize = document.getElementById("<%=hid_3DecimalPaperSize.ClientID %>");

    function inventory_todecimal_function(txtobj) {
        debugger;
        const hdn_3DecimalPaperSize = hid_3DecimalPaperSize.value.toLowerCase() === "true";
        const decimalPlaces = hdn_3DecimalPaperSize ? 3 : 0;
        var value = RemoveDollorAndComma(txtobj.value); // Changed by Pradeep -- called RemoveDollorAndComma()
        if (!isNaN(value) && Number(value)) {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, value, decimalPlaces, '', false, false, false);
        }
        else {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, decimalPlaces, '', false, false, false);
        }
        //  alert('value = ' + txtobj.value);
    }

    function ImageButtonPlus_Click() {
        window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg %>" + "1&mode=" + "edit" + "&item=" + "<%=item %>&sender=popup", '', 1000, 500);
        SetRadWindow('divrad', 'divBackGroundNew', '200');

    }
    var tabSelection = '<%=TabSelection %>';
    if (tabSelection != "True") {
        document.getElementById("divStock").style.opacity = "0.4";
        document.getElementById("divStock").style.filter = "alpha(opacity=60)";
        if (document.getElementById("divHistory") != null) {
            document.getElementById("divHistory").style.opacity = "0.4";
            document.getElementById("divHistory").style.filter = "alpha(opacity=60)";
        }
    }
    function RadWinClose() {

        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";

    }

    function gettabs(value) {
        tabSelection = '<%=TabSelection %>';
        if (tabSelection != "True") {
            if (value == 'g') {
                document.getElementById("divGeneralItem").style.display = "block";
                document.getElementById("divStockItem").style.display = "none";
                if (document.getElementById("divHistoryItem") != null)
                    document.getElementById("divHistoryItem").style.display = "none";
                document.getElementById("item_1").style.color = "red";
                document.getElementById("item_2").style.color = "black";
                if (document.getElementById("SpnHistory") != null)
                    document.getElementById("SpnHistory").style.color = "black";
                document.getElementById("divUnAuthorized").style.display = "none";
            }
            else if (value != 'g') {
                document.getElementById("divUnAuthorized").style.display = "block";
                document.getElementById("divGeneralItem").style.display = "none";
                document.getElementById("divStockItem").style.display = "none";
                if (document.getElementById("divHistoryItem") != null)
                    document.getElementById("divHistoryItem").style.display = "none";
            }
        }
        if (tabSelection == "True") {

            if (value == 'g') {
                document.getElementById("divGeneralItem").style.display = "block";
                document.getElementById("divStockItem").style.display = "none";
                if (document.getElementById("divHistoryItem") != null)
                    document.getElementById("divHistoryItem").style.display = "none";
                document.getElementById("item_1").style.color = "red";
                document.getElementById("item_2").style.color = "black";

                txtInvNameID.focus();
                if (document.getElementById("SpnHistory") != null)
                    document.getElementById("SpnHistory").style.color = "black";
                document.getElementById("divUnAuthorized").style.display = "none";
            }
            else if (value == 's') {
                document.getElementById("divGeneralItem").style.display = "none";
                document.getElementById("divStockItem").style.display = "block";
                if (document.getElementById("divHistoryItem") != null)
                    document.getElementById("divHistoryItem").style.display = "none";
                document.getElementById("item_2").style.color = "red";
                document.getElementById("item_1").style.color = "black";
                if (document.getElementById("<%=txtInStock.ClientID %>").disabled != true)
                    document.getElementById("<%=txtInStock.ClientID %>").focus();
                if (document.getElementById("SpnHistory") != null)
                    document.getElementById("SpnHistory").style.color = "black";
                document.getElementById("divUnAuthorized").style.display = "none";
            }
            else if (value == 'h') {
                if (CallValidation()) {
                    document.getElementById("divGeneralItem").style.display = "none";
                    document.getElementById("divStockItem").style.display = "none";
                    if (document.getElementById("divHistoryItem") != null)
                        document.getElementById("divHistoryItem").style.display = "block";
                    if (document.getElementById("divHistoryItem") != null)
                        document.getElementById("SpnHistory").style.color = "red";
                    document.getElementById("item_1").style.color = "black";
                    document.getElementById("item_2").style.color = "black";
                    document.getElementById("divUnAuthorized").style.display = "none";
                }
            }
        }

    }
    //******* funcn to ckech for inv Item duplicacy *********////
    function TakeALookNew() {
        var compID = '<%=CompanyID %>';
    var id = '<%=InventoryID %>';
    var val1 = document.getElementById("<%=txtInvName.ClientID %>").value;
    var val2 = document.getElementById("<%=txtInvCode.ClientID %>").value;

    var val = compID + "±" + val1 + "±" + val2 + "±" + id;

    PageMethods.FindOutNew(val, FindSuccNew, ShowMsg_Failure);

    }
    function ShowMsg_Failure(error) { }
    var CheckDuplicate = false;
    function FindSuccNew(result) {

        $get('spn_InvNameCheck').style.display = "none";
        $get('spn_txtInvNameCode').style.display = "none";
        if (result == -1) {
            $get('spn_InvNameCheck').style.display = "block";
            CheckDuplicate = true;
        }

        else if (result == -2) {
            $get('spn_txtInvNameCode').style.display = "block";
            $get('spn_txtInvNameCode').innerHTML = '<%=objLangClass.GetLanguageConversion("Inv_Code_Already_Exists")%>'; //result;  //
        CheckDuplicate = true;
    }
    else if (result == -3) {
        $get('spn_txtInvNameCode').style.display = "block";
        $get('spn_txtInvNameCode').innerHTML = '<%=objLangClass.GetLanguageConversion("Inv_Code_Already_Exists")%>'; //result;  //
            CheckDuplicate = true;
    }

    else {
        CheckDuplicate = false;
    }
    }
//*******End of funcn to ckech for inv Item duplicacy *********////
</script>
<script type="text/javascript" language="javascript">
    //******* funcn to bind Paper Height and width *********////
    
    function BindHeightWidth(paperid) {
        var compID = '<%=CompanyID %>';
        var val = compID + "&" + paperid;
        PageMethods.GetPaperHeightWidth(val, FindSuccHeightWidth, ShowMsg_Failure_2);
    }
    function ShowMsg_Failure_2(error) { }
    function FindSuccHeightWidth(result) {
        var sss = result.split('µ');
        var txtheight = "<%=txtPaperHeight.ClientID %>";
        var txtwidth = "<%=txtPaperWidth.ClientID %>";

        document.getElementById(txtheight).value = sss[0];
        document.getElementById(txtwidth).value = sss[1];

    }
    function ddlInvCategorySelectedIndexChanged() {
        debugger;
        //var ddlInvCategory = $('#ctl00_ContentPlaceHolder1_inventoryadd_ddlInvCategory')[0].options.selectedIndex;
        var ddlInvCategory = $('#ctl00_ContentPlaceHolder1_inventoryadd_ddlInvCategory option:selected').text();
        //var Markup = PageMethods.ddlInvCategory_SelectedIndexChanged(ddlInvCategory);
        $.ajax({
            type: "POST",
            url: "inventory_add.aspx/ddlInvCategory_SelectedIndexChanged",
            data: JSON.stringify({ 'ddlInvCategory': ddlInvCategory }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response != '')
                    $('#<%= txtMarkup.ClientID%>').val(response.d);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    //*******End of funcn to bind Paper Height and width *********////
</script>
<script type="text/javascript" language="javascript">
    var ddlPaperType = document.getElementById("<%=ddlPaperType.ClientID %>");
    var ddlInkType = document.getElementById("<%=ddlInkType.ClientID %>");
    var lblCostPerReel = document.getElementById("<%=lblCostPerReel.ClientID %>");
    var lblCostperMtrvalue = document.getElementById("<%=lblCostperMtrvalue.ClientID %>");

    var hid_packprice = document.getElementById("<%=hid_packprice.ClientID %>");
    var hid_costperreel = document.getElementById("<%=hid_costperreel.ClientID %>");
    var hid_costperMtr = document.getElementById("<%=hid_costperMtr.ClientID %>");

</script>
<script src="<%=strSitepath %>js/Item/warehouse_inventory.js?VN='<%=VersionNumber%>'"
    type="text/javascript"></script>
<script type="text/javascript">
    var txtemail = document.getElementById("<%=txtemail.ClientID %>");
    function CallNewValidation(val) {
        TakeALookNew();
        if (CallValidation()) {
            if (val == 's') {
                gettabs('s');
            }
            if (val == 'g') {
                gettabs('g');
            }
            return false;
        }
        else {
            return false;
        }
    }
</script>
<asp:Panel ID="pnlChkCustomShow" runat="server" Visible="false">
    <script type="text/javascript">
        InventoryShowCustom();
    </script>
</asp:Panel>
<asp:Panel ID="pnlLoadSubCat" runat="server" Visible="false">
    <script>

        function loadSubCat() {

            var ddlsd = "<%=CatValue %>";
            var subddlsd = "<%=SubCatValue %>";

            var cat34 = document.getElementById("<%=ddlInvCategory.ClientID %>");
            ShowCategoryWise(cat34);
        }
        //to display papertype properties//
        // var subddlsd = "<%=SubCatValue %>";


        ShowddlInkType();

        ShowddlPaperType_edit();


        loadSubCat();
    </script>
</asp:Panel>
<script type="text/javascript">
    function ShowCategoryWise1() {
        debugger;
            //paper type
            var ddlID = document.getElementById('ctl00_ContentPlaceHolder1_inventoryadd_ddlInvCategory');
            document.getElementById(div_Paper_Type).style.display = "none";
            //Ink type
            document.getElementById(div_Ink_Type).style.display = "none";
            //ink minimum cost
            document.getElementById(div_minimum_ink_cost).style.display = "none";
            //Size Weight Coated
            document.getElementById(div_SizeWeightCoated).style.display = "none";
            //Ink Absorption
            document.getElementById(div_Ink_Absorption).style.display = "none";
            //IMpressions
            document.getElementById(div_Max_Impressions).style.display = "none";
            //div_ProcSellExpo
            document.getElementById(div_ProcSellExpo).style.display = "none";
            //Colour
            document.getElementById(divColour).style.display = "none";
            //Ink Properties
            document.getElementById(div_Ink_Properties).style.display = "none";
            //Basis Weight
            document.getElementById(div_Weight).style.display = "none";
            document.getElementById(div_Caliper).style.display = "none";

            //Coated
            document.getElementById(div_Coated).style.display = "none";

            ddlText = ddlID.options[ddlID.selectedIndex].text.toLowerCase();
            ddlValue = ddlID.options[ddlID.selectedIndex].value.toLowerCase();
            document.getElementById(hid_CategoryID).value = ddlValue;
            //document.getElementById("ddlPaperType").selectedIndex=0;
            document.getElementById(txtPacked).style.display = "block";
            document.getElementById(ddlPacked).style.display = "none";

            if (ddlValue != 0) {
                /*bind_subcategory(ddlValue); //to bind Subcategory to the ddl*/

                //to get the property names
                var str_property = document.getElementById(hid_Properties).value;
                var str_prop1 = str_property.split('µ');
                //1$Weight^Color^^^^^µ2$^^^^Coated^^µ3$^^^^^Exposure^ProcessingChargeµ4$Weight^Color^^^^Exposure^µ44$Weight^Color^^PaperSize^Coated^^ProcessingChargeµ     

                var store_property = '';
                for (var i = 0; i < str_prop1.length; i++) {
                    var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^   
                    if (ddlValue == str_prop2[0]) {
                        store_property = str_prop2[1];
                    }
                }
                //to get individual propertyname
                str_prop3 = store_property.split('^'); //Weight^Color^^^^^
                document.getElementById(txtPacked).style.width = "175px";
                if (ddlText == 'paper') {
                    document.getElementById(div_Paper_Type).style.display = "block";
                    document.getElementById(div_SizeWeightCoated).style.display = "block";
                    document.getElementById(div_Weight).style.display = "block";
                    document.getElementById(div_Caliper).style.display = "block";
                    document.getElementById(div_CostPerMtr).style.display = "block";
                    document.getElementById(div_Ink_Absorption).style.display = "none";

                }
                else if (ddlText == 'inks' || ddlText == 'ink') {
                    document.getElementById(div_Ink_Type).style.display = "block";
                    document.getElementById(div_Ink_Properties).style.display = "block";
                    document.getElementById(div_minimum_ink_cost).style.display = "block";
                    document.getElementById(txtPacked).style.width = "100px";
                    document.getElementById(ddlPacked).style.display = "block";
                    document.getElementById("spn_packedinreq").style.display = "none"
                }
                for (var k = 0; k < str_prop3.length; k++) {
                    if (str_prop3[k] != '') {
                        if (str_prop3[k] == "Weight") {
                            document.getElementById(div_Weight).style.display = "block";
                            document.getElementById(div_Caliper).style.display = "block";
                        }
                        if (str_prop3[k] == "Coated") {
                            document.getElementById(div_Coated).style.display = "block";
                        }
                        if (str_prop3[k] == "Color") {
                            document.getElementById(divColour).style.display = "block";
                        }
                        if (str_prop3[k] == "ProcessingCharge") {
                            document.getElementById(div_ProcSellExpo).style.display = "block";
                        }
                        if (str_prop3[k] == "ItemCustomPaperSize") {
                            document.getElementById(div_SizeWeightCoated).style.display = "block";
                            document.getElementById(div_Weight).style.display = "block";
                            document.getElementById(div_Caliper).style.display = "block";
                            document.getElementById(div_Coated).style.display = "block";
                            document.getElementById("div_chkCustom").style.display = "block";
                            InventoryShowCustom();
                        }
                        else if (str_prop3[k] == "PaperSize") {
                            document.getElementById(div_SizeWeightCoated).style.display = "block";
                            document.getElementById(div_Weight).style.display = "block";
                            document.getElementById(div_Caliper).style.display = "block";
                            document.getElementById(div_Coated).style.display = "block";
                            document.getElementById("div_Inventory_Custom_Size").style.display = "none";
                            document.getElementById("div_chkCustom").style.display = "none";
                        }
                        else if (str_prop3[k] == "ItemCustomSize") {
                            document.getElementById(div_SizeWeightCoated).style.display = "block";
                            document.getElementById(div_Weight).style.display = "block";
                            document.getElementById(div_Caliper).style.display = "block";
                            document.getElementById(div_Coated).style.display = "block";
                            document.getElementById("div_Inventory_ddl_Size").style.display = "none";
                            document.getElementById("div_Inventory_Custom_Size").style.display = "block";
                            document.getElementById("div_chkCustom").style.display = "none";
                        }
                    }
                }
            }
        }
        var lblPackedIn = document.getElementById("<%=lblPackedIn.ClientID %>");
    var hdnPackedIn = document.getElementById("<%=hdnPackedIn.ClientID %>");


    // By Jagat On 16/July/2012

    if ('<%=IsLargeMaterial %>' != '1') {
        if ("<%=paperType %>" == "sheet") {
            ddlPaperType.selectedIndex = 0;
            ShowddlPaperType();
            ddlPaperType.disabled = true;
        }
        //End

        if ("<%=paperType %>" == "roll") {
            ddlPaperType.selectedIndex = 1;
            ShowddlPaperType();
            ddlPaperType.disabled = true;
        }
    }

    if ("<%=InkType %>" == "M") {
        ddlInkType.selectedIndex = 1;
        document.getElementById("div_coated").style.display = "none";
        document.getElementById("div_inkproperties").style.display = "none";
        ShowddlInkType();
        ddlInkType.disabled = true;
    }
    if ("<%=InkType %>" == "Y") {
        ddlInkType.selectedIndex = 0;
        ShowddlInkType();
        ddlInkType.disabled = true;
    }

    if (hdn_InkType.value == "Y") {

        ddlInkType.selectedIndex = 0;
        ShowddlInkType();
        ddlInkType.disabled = true;
    }

    if (hdn_InkType.value == "M") {

        ddlInkType.selectedIndex = 1;
        document.getElementById("div_coated").style.display = "none";
        document.getElementById("div_inkproperties").style.display = "none";
        ShowddlInkType();
        ddlInkType.disabled = true;
    }
</script>
<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    if (document.getElementById("div_Load") != null) { // IE on 23.09.2011
        document.getElementById("div_Load").style.display = "none";
    }
    var inventoryManagement = '<%=InventoryManagement%>';

    function Copy_Inventory() {
        if (inventoryManagement == "IM") {
            showDivPopupCenter('div_trueStock', '250');
            return false;
        }
        else {
            __doPostBack('ctl00$ContentPlaceHolder1$inventoryadd$lnkCopyInventory', '');
            return false;
        }
    }

    function hideDiv(val) {

        window.parent.close();


        if (val == 'c') {

            document.getElementById("div_trueStock").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
            return false;
        }
        if (val == 's') {
            __doPostBack('ctl00$ContentPlaceHolder1$inventoryadd$lnkCopyInventory', '');
        }


    }
    var txtCopyStockQuantity = document.getElementById("<%=txtCopyStockQuantity.ClientID %>");
    function validateQtyAmount() {


        if (!Number(txtCopyStockQuantity.value)) {
            txtCopyStockQuantity.value = 0;
        }
    }
</script>
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script type="text/javascript">
        function CallNow() {

            var ProductType = "<%=ProductType %>";
            window.parent.Reloadgrid(ProductType);
            setTimeout("TakeOut()", 1000);
        }
        function TakeOut() {
            window.close();
        }
        CallNow();
    </script>
</asp:Panel>
<asp:HiddenField ID="hdn_supplierID" runat="server" Value="" />
<script type="text/javascript">
        function GetSupplier() {
            var hdn_supplierID = document.getElementById("<%=hdn_supplierID.ClientID %>");
        var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID %>");
        hdn_supplierID.value = ddlSupplierID.value;

        }


        function Supplier_ReBind(SupplierID, SuppName) {
            var hdn_supplierID = document.getElementById("<%=hdn_supplierID.ClientID %>");
        ddlSupplierID.options.add(new Option(SuppName, SupplierID, ddlSupplierID.length))
        hdn_supplierID.value = SupplierID;

        for (var i = 0; i < ddlSupplierID.length; i++) {
            if (ddlSupplierID.options[i].value == SupplierID) {
                ddlSupplierID.selectedIndex = i;
            }
        }
    }


    function chkEveryTime_checked() {

        if ((document.getElementById("<%=chkReorderLevelEveryTime.ClientID %>")).checked) {
            document.getElementById("<%=rdoNone.ClientID %>").checked = false;
            document.getElementById("<%=chkReorderLevelDaily.ClientID %>").checked = false;
        }
    }
    function chkDaily_checked() {
        if ((document.getElementById("<%=chkReorderLevelDaily.ClientID %>")).checked) {
            document.getElementById("<%=chkReorderLevelEveryTime.ClientID %>").checked = false;
            document.getElementById("<%=rdoNone.ClientID %>").checked = false;
        }
    }
    function rdoNone_checked() {
        if ((document.getElementById("<%=rdoNone.ClientID %>")).checked) {
            document.getElementById("<%=chkReorderLevelDaily.ClientID %>").checked = false;
            document.getElementById("<%=chkReorderLevelEveryTime.ClientID %>").checked = false;
        }
    }

    function SelectNone() {
        document.getElementById("<%=chkReorderLevelDaily.ClientID %>").checked = false;
        document.getElementById("<%=chkReorderLevelEveryTime.ClientID %>").checked = false;
    }



    function validateEmail(field) {

        var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return (regex.test(field)) ? true : false;
    }

    function validateMultipleEmailsCommaSeparated(value, spnid) {
        var isnonchecked = document.getElementById("ctl00_ContentPlaceHolder1_inventoryadd_rdoNone").checked;
        var emailValue = document.getElementById("ctl00_ContentPlaceHolder1_inventoryadd_txtemail").value;
        if (emailValue != "") {
            value = emailValue;
        }
        document.getElementById(spnid).style.display = "none";
        if (value == '') {
            if (spnid == 'spn_To' && isnonchecked == false) {
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

    var saveClicked;
    var txtInvName = document.getElementById("<%=txtInvName.ClientID  %>");
    var txt_UserFriendlyName = document.getElementById("<%=txt_UserFriendlyName.ClientID  %>");
    var txtReasonadjustment = document.getElementById("<%=txtReasonadjustment.ClientID  %>");
    var ddlMinusPlus = document.getElementById("<%=ddlMinusPlus.ClientID %>");

    function SetTextbox() {
    }
    function CallBlur() {
        if (txtReasonadjustment.value == "" || txtReasonadjustment.value == null) {
            document.getElementById("divReason").style.display = "block";
        }
        else {
            document.getElementById("divReason").style.display = "none";
        }
    }
    var hdnAvailableQty = document.getElementById("<%=hdnAvailableQty.ClientID %>");
    var txtAvailableQty = document.getElementById("<%=txtAvailableQty.ClientID %>");
    var txtQtyToAdjusted = document.getElementById("<%=txtQtyToAdjusted.ClientID %>");
    function invAdjustment() {
        if (txtAvailableQty.value != "") {
            txtAvailableQty.value = txtAvailableQty.value - 0;
            if (!Number(txtQtyToAdjusted.value)) {
                txtQtyToAdjusted.value = 0;
            }
            if (!Number(txtAvailableQty.value)) {
                txtAvailableQty.value = 0;
            }
            if (parseInt(txtAvailableQty.value) < parseInt(hdnAvailableQty.value)) {
                txtQtyToAdjusted.value = hdnAvailableQty.value - txtAvailableQty.value;
                ddlMinusPlus.selectedIndex = 1;
                document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Reduced")%>';
            }
            else {
                txtQtyToAdjusted.value = txtAvailableQty.value - hdnAvailableQty.value;
                ddlMinusPlus.selectedIndex = 0;
                document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Replenished")%>';
            }
        }
    }
    var txtQtyToAdjustedNew;
    var txtAvailableQtyNew;
    var hdnAvailableQtyNew;
    function QtyAdjustment() {
        if (txtQtyToAdjusted.value != "") {

            if (!Number(txtQtyToAdjusted.value)) {
                txtQtyToAdjusted.value = 0;
            }
            if (!Number(txtAvailableQty.value)) {
                txtAvailableQty.value = 0;
            }
            txtQtyToAdjusted.value = txtQtyToAdjusted.value - 0;
            txtQtyToAdjustedNew = txtQtyToAdjusted.value;

            hdnAvailableQty.value = RemoveDollorAndComma(hdnAvailableQty.value);
            txtAvailableQty.value = RemoveDollorAndComma(txtAvailableQty.value);
            hdnAvailableQtyNew = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, hdnAvailableQty.value, 0, '', false, false, false);
            txtAvailableQtyNew = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtAvailableQty.value, 0, '', false, false, false);

            if (ddlMinusPlus.selectedIndex == 1) {
                txtAvailableQty.value = hdnAvailableQtyNew - txtQtyToAdjusted.value;
                ddlMinusPlus.selectedIndex = 1;
                document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Reduced")%>';
            }
            else {
                txtAvailableQty.value = hdnAvailableQtyNew - (-(txtQtyToAdjusted.value));
                ddlMinusPlus.selectedIndex = 0;
                document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Replenished")%>';
            }
        }
    }
    function Toggle() {
        txtQtyToAdjusted.value = txtQtyToAdjusted.value - 0;
        txtAvailableQty.value = txtAvailableQty.value - 0;
        txtQtyToAdjustedNew = parseInt(txtQtyToAdjusted.value);

        //hdnAvailableQtyNew = parseInt(hdnAvailableQty.value);

        var availQty = hdnAvailableQty.value.replace(",","");
        hdnAvailableQtyNew = parseInt(availQty);
        txtAvailableQtyNew = parseInt(txtAvailableQty.value);
        if (ddlMinusPlus.selectedIndex == 1) {

            txtAvailableQty.value = hdnAvailableQtyNew - txtQtyToAdjusted.value;
            ddlMinusPlus.selectedIndex = 1;
            document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Reduced")%>';


        }
        if (ddlMinusPlus.selectedIndex == 0) {
            txtAvailableQty.value = hdnAvailableQtyNew - (-(txtQtyToAdjusted.value));
            ddlMinusPlus.selectedIndex = 0;
            document.getElementById("<%=txtReasonadjustment.ClientID %>").value = '<%=objLangClass.GetLanguageConversion("Stock_Replenished")%>';
        }
    }

    function txtKeyDown() {
        if (!Number(txtQtyToAdjusted.value)) {
            txtQtyToAdjusted.value = 0;
        }
        if (!Number(txtAvailableQty.value)) {
            txtAvailableQty.value = 0;
        }
    }
    function txtInStock_keyDown() {
        document.getElementById("spn_txtInStock_number").style.display = "none";
    }

    function copyText() {
        if (txt_UserFriendlyName.value == '') {
            txt_UserFriendlyName.value = txtInvName.value;
        }
    }

    var Inventory_ID = '<%=Inventory_ID %>';
    var Inventory_Name = '<%=Inventory_Name %>';

    var type = '<%=type %>';
    if (type == "") {
        document.getElementById("tdLeftpanel").style.display = "none";
        document.getElementById("ctl00_DivLeftpanel1").style.display = "none";
        document.getElementById("ctl00_RightPanel").style.paddingLeft = "3px";
    }


</script>
<asp:Panel ID="pnl_InventoryName" runat="server" Visible="false">
    <script type="text/javascript">
        function setvalue(id, val) {
            if ('<%=IsColororwhiteink %>'.toLowerCase() == 'white') {
                var lbl = "spnwhiteInk" + '<%=inkid %>';
                var hdn = "hdnwhiteInk" + '<%=inkid %>';
                var img = "imgwhiteInk" + '<%=inkid %>';

                var val1 = trim12(val);
                val1 = val1.length > 25 ? val1 = val1.substring(0, 25) + '...' : val1;
                pw.document.getElementById(lbl).title = SpecialDecode(val);
                pw.document.getElementById(lbl).innerHTML = SpecialDecode(val1) + "&nbsp;<img style='cursor:pointer'  id='imgwhiteInk" + '<%=inkid %>' + "' alt='Clear this ink' src='<%=strImagepath%>close.gif' onclick=\"clear_ink(this.id,'" + val + "');\"  />";
                pw.document.getElementById(hdn).value = id;
                pw.document.getElementById("spn_whiteInk").style.display = 'none';
                setTimeout("TakeOut()", 500);
                return false;
            }
            else {
                var lbl = "spn" + '<%=inkid %>';
                var hdn = "hdn" + '<%=inkid %>';
                var img = "img" + '<%=inkid %>';
                var val1 = trim12(val);

                val1 = val1.length > 25 ? val1 = val1.substring(0, 25) + '...' : val1;
                pw.document.getElementById(lbl).title = val;
                pw.document.getElementById(lbl).innerHTML = val1 + "&nbsp;<img style='cursor:pointer'  id='img" + '<%=inkid %>' + "' alt='Clear this ink' src='<%=strImagepath%>close.gif' onclick=\"clear_ink(this.id,'" + val + "');\"  />";
                pw.document.getElementById(hdn).value = id;
                pw.document.getElementById("spn_ink").style.display = 'none';
                setTimeout("TakeOut()", 500);
                return false;
            }
        }

        function TakeOut() {
            window.close();
        }

        setvalue(Inventory_ID, Inventory_Name);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_SendPaperID_Name" runat="server" Visible="false">
    <script type="text/javascript">
        var Inventory_ID = '<%=Inventory_ID %>';
        var MaterialNo = '<%=MaterialNo %>';
        var txtInvName = document.getElementById("<%=txtInvName.ClientID %>");
        var PaperTypeNew = '<%=PaperTypeNew %>';
        var txtBasisWeight = trim12(txtBasisWeightID.value);

        txtBasisWeight = txtBasisWeight + " " + '<%=PaprMeasure %>';

        function SendPaperID_Name() {
            window.parent.SendPaperIDandName(Inventory_ID, txtInvName.value, PaperTypeNew, MaterialNo, txtBasisWeight);

            setTimeout("TakeOut()", 700);
            return false;
        }

        function TakeOut() {
            window.close();
        }

        SendPaperID_Name();

    </script>
</asp:Panel>

 <%--OPTIMIZATION--%>
<script type="text/javascript">
        function open_popupforsupplier() {
            var inventoryid = "<%=id %>"; debugger;
        var type = "<%=type %>";
        document.getElementById('divBackGroundNew').style.display = 'block';
        if (type == 'edit') {

            window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=inv&mode=edit&id=" + inventoryid, 1000, 500);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        else {
            window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=inv", "inventory", 1000, 500);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        }

        function Bind_Supplier_inventory(supplierid, txtsuppliername) {
            document.getElementById('<%=hdn_supplierid_frompopup.ClientID %>').value = supplierid;
        var ddl = document.getElementById('<%=ddlSupplier.ClientID %>');
        ddl.options.add(new Option(txtsuppliername, supplierid, ddl.options.length));
        ddl.selectedIndex = ddl.options.length - 1;
    }

    </script>

<asp:HiddenField ID="hdn_supplierid_frompopup" runat="server" />
<script type="text/javascript">
    if (window.screen.Width < 1500) {
        document.getElementById("div_Outer").style.width = "1490";
    }
    function DownloadFile() {
        __doPostBack('ctl00$ContentPlaceHolder1$inventoryadd$lnkFileDownload', '');
    }




</script>
<%-- By Jagat On 24/July/2012--%>
<asp:Panel ID="pnl_CloseParent" runat="server" Visible="false">
    <script>

        var Inventory_ID = '<%=Inventory_ID %>';
        var txtInvName = document.getElementById("<%=txtInvName.ClientID %>");

        function SendPlateID_Name() {

            window.parent.SendPlatesIDandName(Inventory_ID, txtInvName.value);

            setTimeout("TakeOut()", 700);
            return false;
        }


        function TakeOut() {

            window.close();

        }

        SendPlateID_Name();
    </script>
</asp:Panel>
<%--End--%>
