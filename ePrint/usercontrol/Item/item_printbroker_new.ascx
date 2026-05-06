<%@ control language="C#" autoeventwireup="true" enableviewstate="false" CodeBehind="item_printbroker_new.ascx.cs" Inherits="ePrint.usercontrol.Item.item_printbroker_new" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="../js/item/AutoFill.js?VN='<%=VersionNumber%>'"
    language="javascript"></script>
<div id="ds00" style="display: block;">
</div>
<style type="text/css">
    html body .radinput_default .riread, html body .radinput_read_default {
        border-top: silver 1px solid;
        border-right: #737373 2px solid;
        border-left: silver 1px solid;
        border-bottom: #737373 1px solid;
    }
    
    html body .radinput_default .ritextbox, html body .radinputmgr_default {
        border-top: silver 1px solid;
        border-right: #737373 2px solid;
        border-left: silver 1px solid;
        border-bottom: #737373 1px solid;
        padding-left: 4px;
        padding-top: 2px;
        padding-bottom: 2px;
        margin: 0px 0px 0px 0px;
        font-family: "Verdana", Verdana, Arial, Helvetica, sans-serif;
        
        font-size: 11px;
        color: #000000;
        width: 175px;
        vertical-align: middle;
    }
    TEXTAREA, INPUT[type="text"]
    {
      font-family: Arial,Helvetica;
      font-size: 13px;
    }

</style>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/item_firstprintbroker.js?VN='<%=VersionNumber%>'"></script>
<script>
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var QtyNumber = '<%=QtyNumber %>';
    var strImagepath = '<%=strImagepath %>';
    var modulename = '<%=modulename %>';
    var QueryType = '<%=QueryType %>';
    var subedit = '<%=subedit %>';


    var EstimateID = '<%=EstimateID %>';
    var EstimateItemID = '<%=EstimateItemID %>';
    var EstType = '<%=EstType %>';
    var MainType = '<%=MainType %>';

    var ParentEstimateItemID = '<%=ParentEstimateItemID %>';
    var ParentEstimateType = '<%=ParentEstimateType %>';
    var EstimateBookletItemID = '<%=EstimateBookletItemID %>';
    var ISFromAddAnItem = '<%=ISFromAddAnItem %>';
    var SysName = '<%=SysName %>';

    var Supplier = "<%=Supplier%>";
    var Name = "<%=Name%>";
    var Contact = "<%=Contact%>";
    var Pgtype = "estimate";

    var JobID = "<%=jobID%>";
    var InvoiceID = "<%=InvoiceID%>";

    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<script type="text/javascript">
    setLoadingPositionOfDivMove(div_Load);

    function DateSelected(sender, eventArgs) {
        document.getElementById("ctl00_ContentPlaceHolder1_divprintbroker_txtRFQReturnDate").value = eventArgs.get_newValue();
    }
</script>
<asp:HiddenField ID="hid_Suppliers" Value="" runat="server" />
<script>
    var DateFormat = "<%=DateFormat %>";
    var currentdate = '<%=newdate %>';
</script>
<div id="divBackGroundNew" style="display: none;">
</div>
<div class="only5px">
</div>
<div id="div_blank_OW" style="display: none; height: 500px; width: 700px;">
</div>
<div id="div_print_broker" style="float: left; width: 100%;">
    <div id="divPrintclass" style="float: left; width: 100%" class="div_spacing2">
        <div style="border: 0px solid green" align="center">
            <div style="float: left; width: 300px;">
                &nbsp;
            </div>
            <div align="center" id="diverrorMessage" style="width: auto; padding: 5px; display: none; float: left">
                <span id="span_none" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;"></span>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <div style="float: left; width: 100%">
            <div align="left">
                <div id="div_print_broker_step_1" align="left" style="width: 100%; display: none">
                    <div class="est_printbroker">
                        <div align="left">
                            <div style="float: left; display: none;">
                                <asp:Label ID="lblwork" runat="server" Text="Populate the work instructions as you would like them to appeare on the job card<br/> and purchase order or copy to RFQ description to this area, click the import icon below"></asp:Label>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div id="div_title" runat="server" style="display: block;">
                            <div class="bglabel" style="width: 193px; margin-left: 30px;">
                                <asp:Label ID="lbltitle" CssClass="normalText" runat="server"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtjobtitle" SkinID="textPad" runat="server" TabIndex="1" Width="300px"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div style="width: 99%; padding-left: 4px; border: 0px solid green" align="left">
                            <div class="bglabel" style="float: left; width: 193px; margin-left: 26px;">
                                <asp:Label ID="lblqty" CssClass="normalText" Text="Quantity" runat="server"></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div style="float: left;">
                                <div align="left" style="display: none;">
                                    <asp:RadioButtonList ID="RdlQtyType" runat="server" RepeatDirection="horizontal">
                                        <asp:ListItem Value="single" style="display: none;">Single Qty</asp:ListItem>
                                        <asp:ListItem Value="multiple" Selected="True">Multiple Qty</asp:ListItem>
                                        <%--<asp:ListItem Value="runon">RunOn  Qty</asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="div_singleQty" style="float: left; border: solid 0px red; display: none">
                                    <div align="left" style="float: left; width: 99%; border: solid 0px red;">
                                        <asp:TextBox ID="txtSingleQty" runat="server" SkinID="textPad" MaxLength="7" onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('1',this.value);"
                                            Width="70px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="div_runQty" style="float: left; border: solid 0px red; display: none; width: 99%">
                                    <div align="left" style="float: left; width: 99%; border: solid 0px white;">
                                        <asp:TextBox ID="txtRunQty1" runat="server" SkinID="textPad" MaxLength="7" onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('1',this.value);"
                                            Width="70px"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="txtRunQty2" runat="server" SkinID="textPad" MaxLength="7" onblur="Allow_Insteger_Only(this,false,'div_qty');ChangeOfQty('2',this.value);"
                                            Width="70px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="div_MultyQty" class="box" style="float: left; border: solid 0px red; display: block; width: 400px;">
                                    <div align="left" style="width: 400px;">
                                        <asp:TextBox ID="txtMultiQty1" runat="server" SkinID="textPad" TabIndex="2" MaxLength="7"
                                            onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('1',this.value);"
                                            Width="69px"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="txtMultiQty2" runat="server" SkinID="textPad" TabIndex="3" MaxLength="7"
                                            onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('2',this.value);"
                                            Width="69px"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="txtMultiQty3" runat="server" SkinID="textPad" TabIndex="4" MaxLength="7"
                                            onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('3',this.value);"
                                            Width="69px"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="txtMultiQty4" runat="server" SkinID="textPad" TabIndex="5" MaxLength="7"
                                            onblur="Allow_Integer_Only(this,false,'div_qty');ChangeOfQty('4',this.value);"
                                            Width="69px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="div_qty" style="display: none; width: 99%; border: solid 0px red; margin-left: 5px;">
                                    <span id="span_qty" class="spanerrorMsg" style="float: left; width: auto; padding-left: 4px; padding-right: 4px;"></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                        </div>
                        <div id="div_searchproduct" runat="server" style="display: none;">
                            <div class="bglabel" style="width: 193px; margin-left: 30px;">
                                <asp:Label ID="Label1" CssClass="normalText" runat="server">Search Product to fill description</asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtprodsearch" AutoCompleteType="Disabled" SkinID="textPad" runat="server"
                                    TabIndex="1" Width="300px" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div style="float: left;">
                            <div id="padding">
                                <div style="float: left; width: 650px;">
                                    <asp:HiddenField ID="hdn_OutworkDesc" runat="server" Value="" />
                                    <div id="div_scrollDescription" align="left">
                                        <fieldset style="width: 99%;">
                                            <legend>
                                                <%=objLanguage.GetLanguageConversion("Supplier_Items_Description")%>
                                            </legend>

                                            <div style="border: 0px solid green; height: 690px; width: 98%; overflow-y: scroll;">
                                                <asp:PlaceHolder ID="divContainer" runat="server">
                                                    <div id="div_OutItemTitle" align="left" style="width: 100%; display: block;" runat="server">
                                                    <div style="float: left; width: 100%;">
                                                        <div style="float: left; width: 100%;">
                                                            <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                                <div style="height: 15px;">
                                                                    &nbsp;
                                                                </div>
                                                                <div style="clear: both">
                                                                </div>
                                                                <asp:CheckBox ID="chkOutItemTitle" runat="server" Checked="true" />
                                                            </div>
                                                            <div style="float: left; margin-left: 1px">
                                                                <div style="height: 15px; width: 30px">
                                                                    &nbsp;
                                                                </div>
                                                                <div style="clear: both">
                                                                </div>
                                                                <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                    <div style="clear: both">
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:TextBox ID="txtTitle" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                    </div>
                                                                    <div style="float: right;">
                                                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton36" runat="server" CausesValidation="False"
                                                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Title');return false;" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 0px; border: 0px solid red">
                                                                    <div style="height: 17px; width: 50px;">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="clear: both">
                                                                    </div>
                                                                    <asp:TextBox ID="txtTitleDescription" SkinID="textPad" runat="server" Width="300px"
                                                                        MaxLength="300" TextMode="MultiLine" Rows="2" Columns="38" TabIndex="6" Height="46px"></asp:TextBox>
                                                                </div>
                                                                <div style="float: left; border: 0px solid">
                                                                    <div style="float: left; padding-top: 2px; padding-left: 5px;" class="only10px">
                                                                        <%=objLanguage.GetLanguageConversion("Save")%>
                                                                    </div>
                                                                    <div style="clear: both">
                                                                    </div>
                                                                    <div style="float: left; padding-left: 6px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <asp:CheckBox ID="chk_broker_Phrase_Title" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div style="clear: both; padding-top: 2px">
                                                </div>
                                                <div id="div_OutDescription" runat="server" align="left" style="width: 100%; display: none; border: solid 0px red">
                                                    <div style="float: left; width: 100%;">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <div style="float: left">
                                                                <asp:CheckBox ID="chkOutDescription" runat="server" Checked="true" />
                                                            </div>
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtOrigination" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton1" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Description');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtOriginationDescription" SkinID="textPad" runat="server" Rows="2"
                                                                    Columns="38" Width="300px" Height="46px" TextMode="MultiLine" TabIndex="7" MaxLength="300"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Design" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutArtwork" runat="server" align="left" style="width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutArtwork" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtArtwork" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton2" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Artwork');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtArtworkDescription" SkinID="textPad" runat="server" Width="300px"
                                                                    MaxLength="300" Rows="2" Columns="38" Height="46px" TabIndex="8" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Artwork" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutColour" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutColour" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtColor" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton3" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Colours');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtColorDescription" SkinID="textPad" runat="server" Width="300px"
                                                                    MaxLength="300" Rows="2" Columns="38" Height="46px" TabIndex="9" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Color" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutSize" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutSize" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtSize" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton4" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Size');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtSizeDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="10" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Size" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutMaterial" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutMaterial" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtMaterial" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton5" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Material');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtMaterialDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="11" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Material" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutDelivery" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutDelivery" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtDelivery" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton6" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Delivery');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtDeliveryDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="12" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Delivery" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutFinishing" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutFinishing" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtFinishing" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton7" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Finishing');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtFinishingDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="13" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Finishing" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutProofs" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutProofs" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtProofs" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton10" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Proofs');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtProofsDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="14" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Proofs" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutPacking" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutPacking" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtPacking" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton11" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Packing');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtPackingDescription" SkinID="textPad" runat="server" MaxLength="300"
                                                                    Rows="2" Columns="38" TextMode="MultiLine" Width="300px" TabIndex="15" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Packing" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutNotes" runat="server" align="left" style="width: 100%; display: none">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutNotes" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtNotes" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton8" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Notes');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtNotesDescription" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="16" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Notes" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_OutInstructions" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="chkOutInstructions" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txtTerms" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton9" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Terms');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txtTermsDescription" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="chk_broker_Phrase_Terms" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <%--New Supplier Description Fields--%>
                                                <div id="div_SupplierDescrn1" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn1" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel1" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton12" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription1');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue1" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase1" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn2" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn2" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel2" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton13" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription2');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue2" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase2" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn3" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn3" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel3" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton14" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription3');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue3" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase3" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn4" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn4" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel4" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton15" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription4');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue4" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase4" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn5" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn5" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel5" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton16" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription5');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue5" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase5" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn6" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn6" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel6" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton17" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription6');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue6" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase6" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn7" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn7" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel7" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton18" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription7');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue7" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase7" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn8" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn8" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel8" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton19" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription8');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue8" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase8" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn9" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn9" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel9" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton20" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription9');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue9" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase9" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn10" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn10" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel10" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton21" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription10');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue10" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase10" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn11" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn11" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel11" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton22" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription11');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue11" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase11" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn12" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn12" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel12" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton23" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription12');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue12" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase12" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn13" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn13" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel13" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton24" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription13');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue13" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase13" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn14" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn14" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel14" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton25" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription14');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue14" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase14" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn15" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn15" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel15" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton26" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription15');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue15" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase15" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn16" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn16" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel16" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton27" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription16');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue16" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase16" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn17" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn17" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel17" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton28" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription17');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue17" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase17" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn18" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn18" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel18" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton29" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription18');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue18" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase18" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn19" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn19" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel19" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton30" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription19');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue19" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase19" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn20" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn20" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel20" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton31" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription20');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue20" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase20" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn21" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn21" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel21" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton32" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription21');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue21" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase21" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn22" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn22" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel22" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton33" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription22');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue22" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase22" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn23" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn23" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel23" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton34" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription23');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue23" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase23" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn24" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn24" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel24" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton35" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription24');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue24" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase24" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div id="div_SupplierDescrn25" runat="server" align="left" style="border: 0px solid red; width: 100%; display: none;">
                                                    <div style="float: left; width: 100%">
                                                        <div style="float: left; margin-right: 2px; padding: 3 0 3 0px; width: 3%;">
                                                            <asp:CheckBox ID="Chk_SuplierDescn25" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; margin-left: 1px">
                                                            <div style="clear: both">
                                                            </div>
                                                            <div class="bglabel" style="width: 190px; height: 39px; float: left; margin-bottom: 2px; margin-left: 1px">
                                                                <div style="float: left">
                                                                    <asp:TextBox ID="txt_SuplierLabel25" SkinID="textPad" runat="server" Width="140px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton37" runat="server" CausesValidation="False"
                                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker CustomDescription25');return false;" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="">
                                                            <div style="float: left;">
                                                                <asp:TextBox ID="txt_SuplierValue25" SkinID="textPad" runat="server" Rows="2" Columns="38"
                                                                    Width="300px" TextMode="MultiLine" TabIndex="17" Height="46px"></asp:TextBox>
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left; padding-left: 6px">
                                                                    &nbsp;
                                                                </div>
                                                                <asp:CheckBox ID="Chk_DescnsToPhrase25" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                </asp:PlaceHolder>
                                                
                                            </div>
                                            <%--end --%>
                                            <div style="margin-top: 10px; border: 0px solid red;">
                                                <div id="Div_Text" runat="server" visible="true" style="padding-left: 25px;">
                                                    <span>Copy the item description fields above to:</span>
                                                </div>
                                                <div style="margin: 2px 0px 0px 0px">
                                                    <asp:CheckBox ID="Chk_CopytoCustomr" Checked="false" runat="server" Visible="false" />
                                                    <asp:Label ID="chklabel" runat="server"></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:CheckBox ID="Chk_POItmDescn" runat="server" Checked="true" Visible="false" Text="  Purchase order item description fields" />
                                                </div>
                                                <div>
                                                    <asp:CheckBox ID="Chk_DNCopy" Visible="false" Checked="true" runat="server" Text="  Delivery note item description fields" />
                                                </div>
                                                <div>
                                                    &nbsp;
                                                </div>
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div align="left" id="Div_Productcatalogue" runat="server" visible="false">
                                                <div class="bglabel" style="float: left; width: 193px; margin-left: 20px;">
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
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="float: left; vertical-align: top; width: 44%; border: 0px solid red">
                        <div align="left" style="margin-left: 17px;">
                            <div class="bglabel" style="float: left; width: 186px;">
                                <asp:Label ID="lblcustomer" runat="server" Text="Costing Type" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box" style="">
                                <asp:DropDownList runat="server" ID="ddlCostingType" CssClass="normaltext" TabIndex="18"
                                    Width="200px">
                                    <asp:ListItem Value="unit">Unit Based Costing&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="simple" Selected="True">Simple Costing</asp:ListItem>
                                    <%--<asp:ListItem Value="per1000">Per 1000 Costing&nbsp;&nbsp;</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="margin-left: 17px;">
                            <div class="bglabel" style="float: left; width: 186px;">
                                <asp:Label ID="lblrfq" runat="server" Text="RFQ Return Date" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box" style="margin-top: -2px">
                                <asp:TextBox ID="txtRFQReturnDate" runat="server" TabIndex="19" Width="90px" SkinID="textPad"
                                    ReadOnly="true" Style="margin-top: -1px"></asp:TextBox>

                                <telerik:RadTimePicker ID="RadTimePicker1" runat="server" SkinID="textPad" ShowPopupOnFocus="true"
                                    TimePopupButton-Visible="true" DateInput-ReadOnly="false" TimeView-Width="350px"
                                    ZIndex="30001" InputMode="TimePicker">
                                </telerik:RadTimePicker>
                                <div style="clear: both">
                                </div>

                            </div>
                        </div>
                        <div style="margin-left: 17px;">
                            <div class="bglabel" style="width: 186px;">
                                <asp:Label ID="lbljob" runat="server" Text="Job Completion Date" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtJobCompletionDate" runat="server" TabIndex="20" Width="200px"
                                    SkinID="textPad" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                        <div style="margin-left: 17px;">
                            <div class="bglabel" style="width: 186px;">
                                <div style="float: left;">
                                    <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Header")%></span>
                                </div>
                                <div style="float: right;">
                                    <a href="javascript://" tabindex="21" onclick="GetPBPhraseBook('header','PrintBroker Header');return false">
                                        <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                                </div>
                            </div>
                            <div class="box" style="width: 200px; overflow: hidden; white-space: nowrap;">
                                <span id="spn_PrintBroker_Header" runat="server" class="graytext"></span>
                            </div>
                        </div>
                        <div style="margin-left: 17px;">
                            <div class="bglabel" style="width: 186px;">
                                <div style="float: left;">
                                    <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Footer")%></span>
                                </div>
                                <div style="float: right;">
                                    <a href="javascript://" tabindex="22" onclick="GetPBPhraseBook('footer','PrintBroker Footer');return false">
                                        <img src="<%=strImagepath %>plus.gif" border="0" /></a>
                                </div>
                            </div>
                            <div class="box" style="width: 200px; overflow: hidden; white-space: nowrap;">
                                <span id="spn_PrintBroker_Footer" runat="server" class="graytext"></span>
                            </div>
                        </div>
                        <div align="left" id="div_ArtWork_Content" style="margin-left: 17px;">
                            <div class="bglabel" style="width: 186px;">
                                <asp:Label ID="lblartwork" runat="server" Text=" ArtWork" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <a href="javascript://" tabindex="23" onclick="OpenUpload();">
                                    <%=objLanguage.GetLanguageConversion("Upload")%></a>
                            </div>
                        </div>
                        <div id="div_ArtWork_More">
                        </div>
                        <div align="left" style="display: none; padding-left: 0px;">
                            <div class="bglabelEmpty">
                                &nbsp;
                            </div>
                            <div class="box">
                                <a href="javascript://" onclick="ArtWorkMore();return false;">Add More</a>&nbsp;|&nbsp;
                                <a href="javascript://" onclick="ArtWorkMoreRemove('ok');return false;">Remove</a>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <%--This is fo testing--%>
                        <div id="div_print_broker_step_2" style="display: block; width: 100%; margin-top: 10px">
                            <fieldset>
                                <legend>
                                    <%=objLanguage.GetLanguageConversion("Supplier_Selection")%></legend>
                                <%--Supplier Request for Quote Description--%>
                                <div id="div_scroll" style="float: left; width: 100%; height: 260px;">
                                    <%--overflow-y: scroll;--%>
                                    <div id="div_addmorecontents">
                                        <div id="div_supplier0">
                                            <div align="left" style="display: none;">
                                                <div style="width: 100%; float: left; padding: 3px 0px  6px 0px; border-bottom: 1px solid silver">
                                                    <span class="HeaderText">
                                                        <%=objLanguage.GetLanguageConversion("Supplier_1")%></span>
                                                </div>
                                                <asp:DropDownList ID="ddlSupplier1" Width="200px" runat="server" TabIndex="24" Style="padding: 0px"
                                                    SkinID="onlyDDL">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlSupplierContact1" Width="200px" TabIndex="25" runat="server"
                                                    SkinID="onlyDDL">
                                                </asp:DropDownList>
                                                <div style="width: 90%; float: left; padding: 2px;">
                                                    <div class="onlyEmpty">
                                                    </div>
                                                    <div align="left">
                                                        <div class="bglabel" style="width: 20%">
                                                            <asp:Label ID="Label3" runat="server" Text="Name" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div class="box">
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                    <div align="left">
                                                        <div class="bglabel" style="width: 20%">
                                                            <asp:Label ID="Label5" runat="server" Text="Contact" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div class="box">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divtest">
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <table align="left" cellspacing="2" width="100%" cellpadding="4" border="0">
                                            <tbody id="tableSup">
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="div_added" align="left">
                                    </div>
                                    <div style="clear: both; height: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; border: solid 0px red; width: 100%">
                                        <div style="width: 82%; float: left">
                                            &nbsp;
                                        </div>
                                        <div style="float: left">
                                            <div style="float: left;">
                                                <a id="link_more" name="link_more" href="#link_more" onclick="javascript:add_more();return false;">
                                                    <%=objLanguage.GetLanguageConversion("Add_More")%></a>
                                            </div>
                                            <input type="hidden" value="1" id="hdn_count" />
                                        </div>
                                        <div id="divS">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                        </div>
                        <%--This is for testing--%>
                        <div style="clear: both; height: 15px;">
                            &nbsp;
                        </div>
                        <div align="left">
                            <div class="onlyEmpty">
                            </div>
                            <div align="left">
                                <div style="float: left;">
                                    &nbsp;
                                </div>
                                <div style="float: left; padding-top: 30px; padding-left: 170px;">

                                    <div style="width: 10px; float: left;">
                                        &nbsp;
                                    </div>
                                    <div id="div_printbroker_previous" style="float: left;">
                                        <div id="div_btnprev" style="display: block">
                                            <asp:Button ID="Button1" runat="server" Text="Previous" TabIndex="27" CssClass="button"
                                                OnClick="btnprevious_onclick" OnClientClick="javascript:loadingimage(this.id,'div_prevprocess')" />
                                        </div>
                                        <div id="div_prevprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="width: 10px; float: left;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnsave">
                                            <asp:Button ID="btnSave" runat="server" Text="Next" TabIndex="28" CssClass="button"
                                                OnClientClick="javascript:PbNextBtn('3','1');return false;" />
                                        </div>
                                        <div id="div_nextprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="width: 10px; float: left">
                                        &nbsp;
                                    </div>
                                    <div id="DivPrint" runat="server" style="float: left;">
                                        <asp:Button ID="btn_Outwork_PrintEmail" runat="server" Text="Print/Email" TabIndex="29"
                                            CssClass="button" OnClientClick="javascript:CallPrintEmail();return false;" Style="display: block;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty" style="height: 35px;">
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
</div>
<div class="onlyEmpty">
</div>
<div class="onlyEmpty">
</div>
<div align="left" id="div_print_broker_step_3" style="display: none; width: 99%; padding: 5px; border: 0px solid green;">
    <div id="div_simplecosting" style="float: left; width: 100%; border: 0px solid blue; margin-top: -38px">
        <div style="float: left; width: 99.5%; background-color: #ccc; height: 30px; padding-top: 2px; padding-left: 5px; border: 0px solid red">
            <div style="float: left; width: 100%; border: 0px solid red;">
                <div style="float: left; width: 9%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Supp_Quote")%></b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Supplier_Name")%></b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Quantity")%></b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Cost")%></b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Delivery_Included")%></b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Delivery_Date")%></b></span>

                </div>
                <div style="float: left; width: 9%;">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Delivery_Cost")%></b></span>

                </div>
                <div style="float: left; width: 9%; padding-left: 3px;">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("MarkUp_Type")%></b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 3px;">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("MarkUp_Value")%></b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 5px;">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Total_Price")%></b></span>
                </div>
                <div style="float: left; width: 9%; padding-left: 5px;">
                    <span><b>
                        <%=objLanguage.GetLanguageConversion("Select_Supplier_Quantities")%></b></span>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <div id="div_unitcosting" style="float: left; width: 100%; border: 0px solid red">
        <div style="float: left; width: 100%; background-color: #ccc; height: 25px;">
            <div style="float: left; width: 100%;">
                <div style="float: left; width: 9%">
                    <span><b>Supp. Quote#</b></span>
                </div>
                <div style="float: left; width: 14%">
                    <span><b>Supplier Name</b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>Quantity</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Unit Cost</b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>Delivery Included</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Delivery Date</b></span>

                </div>
                <div style="float: left; width: 9%;">
                    <span><b>Delivery Cost</b></span>

                </div>
                <div style="float: left; width: 9%; padding-left: 3px;">
                    <span><b>Markup Type</b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 3px;">
                    <span><b>Markup Value</b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 5px;">
                    <span><b>Total Price</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Select Supplier</b></span>
                    <br />
                    <span><b>& Quantities</b></span>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <div id="div_per1000costing" style="float: left;display:none; width: 100%; border: 0px solid red">
        <div style="float: left; width: 100%; background-color: #ccc; height: 25px;">
            <div style="float: left; width: 100%;">
                <div style="float: left; width: 9%">
                    <span><b>Supp. Quote#</b></span>
                </div>
                <div style="float: left; width: 6%">
                    <span><b>Supplier Name</b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>Quantity</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Cost Per 1000</b></span>
                </div>
                <div style="float: left; width: 7%">
                    <span><b>Delivery Included</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Delivery Date</b></span>

                </div>
                <div style="float: left; width: 9%;">
                    <span><b>Delivery Cost</b></span>

                </div>
                <div style="float: left; width: 9%; padding-left: 3px;">
                    <span><b>Markup Type</b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 3px;">
                    <span><b>Markup Value</b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 5px;">
                    <span><b>Total Price</b></span>
                </div>
                <div style="float: left; width: 8%; padding-left: 5px;">
                    <span><b>Total Price per 1000</b></span>
                </div>
                <div style="float: left; width: 9%">
                    <span><b>Select Supplier</b></span>
                    <br />
                    <span><b>& Quantities</b></span>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <div style="float: left; width: 100%;">
        <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #ccc; padding: 2px">
            <tbody id="PriceTable">
            </tbody>
        </table>
        <div align="left" id="div_load">
        </div>
    </div>
    <div class="only10px">
    </div>
    <div align="left">
        <div style="float: left; width: 69%;">
            &nbsp;
        </div>
        <div style="float: right; width: 30%;">
            <div style="float: left;">
                <asp:Button ID="Button11" runat="server" Text="Previous" CssClass="button" OnClientClick="javascript:PbNextBtn('1','3');return false;" />
            </div>
            <div style="width: 10px; float: left">
                &nbsp;
            </div>
            <div style="float: left;">
                <asp:Button ID="Button12" runat="server" Text="Finish" OnClick="btnOutWork_OnClick"
                    OnClientClick="javascript:return SavePrintBroker();" CssClass="button" />
            </div>
            <script>
                var getcheck = false;
                var getqtycheck = false;
                function SavePrintBroker() {
                    SaveOutWork();
                    SaveData();

                    return true;

                }

            </script>
        </div>
    </div>
    <div class="only5px" style="height: 35px;">
    </div>
</div>
<div class="onlyEmpty">
</div>
</div> </div>
<div class="onlyEmpty">
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload, Resize">
    </telerik:RadWindowManager>
</div>
<div id="div_FileUpload" style="display: none; position: absolute; vertical-align: middle; border: 0px solid; z-index: 100;"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_FileUpload" DestroyOnClose="true"
        Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
        Behaviors="Close" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hid_outwork_save" runat="server" />
<asp:HiddenField ID="hid_Pub_ClientID" runat="server" />
<asp:HiddenField ID="hid_outwork_phrase_data" runat="server" />
<asp:LinkButton ID="lnkPrintEmail" runat="server" OnClick="lnkPrintEmail_OnClick"></asp:LinkButton>
<asp:HiddenField ID="hdn_Sleep" runat="server" Value="" />
<asp:HiddenField ID="hdn_IsAddEdit" runat="server" Value="0" />
<div style="display: none;">
    <asp:Label ID="lblTest" runat="server"></asp:Label>
</div>
<asp:Panel ID="pnlOfInvoice" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        Only_Single_Qty();
    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">
    var OptionData = '';
    var CompanyID = "<%=CompanyID %>";
    var UserID = "<%=UserID %>";
    var estimateType = "printbroker";
    var pb_markup = '<%=printbroker_markup%>';
    var ProfitTaxKey = '<%=ProfitTaxKey%>';
    var DateFormatNEW = "<%=DateFormat %>";

    pb_markup = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, pb_markup, 0, '', false, false, false);
    var hdn_OutworkDesc = document.getElementById("<%=hdn_OutworkDesc.ClientID %>");
    var hid_outwork_phrase_data = document.getElementById("<%=hid_outwork_phrase_data.ClientID %>");
    var hdn_IsAddEdit = document.getElementById("<%=hdn_IsAddEdit.ClientID %>");
    //Labels//
    var txtTitle = document.getElementById("<%=txtTitle.ClientID %>");
    var txtOrigination = document.getElementById("<%=txtOrigination.ClientID %>");
    var txtArtwork = document.getElementById("<%=txtArtwork.ClientID %>");
    var txtColor = document.getElementById("<%=txtColor.ClientID %>");
    var txtSize = document.getElementById("<%=txtSize.ClientID %>");
    var txtMaterial = document.getElementById("<%=txtMaterial.ClientID %>");
    var txtDelivery = document.getElementById("<%=txtDelivery.ClientID %>");
    var txtFinishing = document.getElementById("<%=txtFinishing.ClientID %>");
    var txtProofs = document.getElementById("<%=txtProofs.ClientID %>");
    var txtPacking = document.getElementById("<%=txtPacking.ClientID %>");
    var txtNotes = document.getElementById("<%=txtNotes.ClientID %>");
    var txtTerms = document.getElementById("<%=txtTerms.ClientID %>");

    var txtprodsearch = document.getElementById("<%=txtprodsearch.ClientID %>");
    var txt_SuplierLabel1 = document.getElementById("<%=txt_SuplierLabel1.ClientID %>");
    var txt_SuplierLabel2 = document.getElementById("<%=txt_SuplierLabel2.ClientID %>");
    var txt_SuplierLabel3 = document.getElementById("<%=txt_SuplierLabel3.ClientID %>");
    var txt_SuplierLabel4 = document.getElementById("<%=txt_SuplierLabel4.ClientID %>");
    var txt_SuplierLabel5 = document.getElementById("<%=txt_SuplierLabel5.ClientID %>");
    var txt_SuplierLabel6 = document.getElementById("<%=txt_SuplierLabel6.ClientID %>");
    var txt_SuplierLabel7 = document.getElementById("<%=txt_SuplierLabel7.ClientID %>");
    var txt_SuplierLabel8 = document.getElementById("<%=txt_SuplierLabel8.ClientID %>");
    var txt_SuplierLabel9 = document.getElementById("<%=txt_SuplierLabel9.ClientID %>");
    var txt_SuplierLabel10 = document.getElementById("<%=txt_SuplierLabel10.ClientID %>");
    var txt_SuplierLabel11 = document.getElementById("<%=txt_SuplierLabel11.ClientID %>");
    var txt_SuplierLabel12 = document.getElementById("<%=txt_SuplierLabel12.ClientID %>");
    var txt_SuplierLabel13 = document.getElementById("<%=txt_SuplierLabel13.ClientID %>");
    var txt_SuplierLabel14 = document.getElementById("<%=txt_SuplierLabel14.ClientID %>");
    var txt_SuplierLabel15 = document.getElementById("<%=txt_SuplierLabel15.ClientID %>");
    var txt_SuplierLabel16 = document.getElementById("<%=txt_SuplierLabel16.ClientID %>");
    var txt_SuplierLabel17 = document.getElementById("<%=txt_SuplierLabel17.ClientID %>");
    var txt_SuplierLabel18 = document.getElementById("<%=txt_SuplierLabel18.ClientID %>");
    var txt_SuplierLabel19 = document.getElementById("<%=txt_SuplierLabel19.ClientID %>");
    var txt_SuplierLabel20 = document.getElementById("<%=txt_SuplierLabel20.ClientID %>");
    var txt_SuplierLabel21 = document.getElementById("<%=txt_SuplierLabel21.ClientID %>");
    var txt_SuplierLabel22 = document.getElementById("<%=txt_SuplierLabel22.ClientID %>");
    var txt_SuplierLabel23 = document.getElementById("<%=txt_SuplierLabel23.ClientID %>");
    var txt_SuplierLabel24 = document.getElementById("<%=txt_SuplierLabel24.ClientID %>");
    var txt_SuplierLabel25 = document.getElementById("<%=txt_SuplierLabel25.ClientID %>");


    //Values//
    var txtTitleDescription = document.getElementById("<%=txtTitleDescription.ClientID %>");
    var txtOriginationDescription = document.getElementById("<%=txtOriginationDescription.ClientID %>");
    var txtArtworkDescription = document.getElementById("<%=txtArtworkDescription.ClientID %>");
    var txtColorDescription = document.getElementById("<%=txtColorDescription.ClientID %>");
    var txtSizeDescription = document.getElementById("<%=txtSizeDescription.ClientID %>");
    var txtMaterialDescription = document.getElementById("<%=txtMaterialDescription.ClientID %>");
    var txtDeliveryDescription = document.getElementById("<%=txtDeliveryDescription.ClientID %>");
    var txtFinishingDescription = document.getElementById("<%=txtFinishingDescription.ClientID %>");
    var txtProofsDescription = document.getElementById("<%=txtProofsDescription.ClientID %>");
    var txtPackingDescription = document.getElementById("<%=txtPackingDescription.ClientID %>");
    var txtNotesDescription = document.getElementById("<%=txtNotesDescription.ClientID %>");
    var txtTermsDescription = document.getElementById("<%=txtTermsDescription.ClientID %>");

    var txt_SuplierValue1 = document.getElementById("<%=txt_SuplierValue1.ClientID %>");
    var txt_SuplierValue2 = document.getElementById("<%=txt_SuplierValue2.ClientID %>");
    var txt_SuplierValue3 = document.getElementById("<%=txt_SuplierValue3.ClientID %>");
    var txt_SuplierValue4 = document.getElementById("<%=txt_SuplierValue4.ClientID %>");
    var txt_SuplierValue5 = document.getElementById("<%=txt_SuplierValue5.ClientID %>");
    var txt_SuplierValue6 = document.getElementById("<%=txt_SuplierValue6.ClientID %>");
    var txt_SuplierValue7 = document.getElementById("<%=txt_SuplierValue7.ClientID %>");
    var txt_SuplierValue8 = document.getElementById("<%=txt_SuplierValue8.ClientID %>");
    var txt_SuplierValue9 = document.getElementById("<%=txt_SuplierValue9.ClientID %>");
    var txt_SuplierValue10 = document.getElementById("<%=txt_SuplierValue10.ClientID %>");
    var txt_SuplierValue11 = document.getElementById("<%=txt_SuplierValue11.ClientID %>");
    var txt_SuplierValue12 = document.getElementById("<%=txt_SuplierValue12.ClientID %>");
    var txt_SuplierValue13 = document.getElementById("<%=txt_SuplierValue13.ClientID %>");
    var txt_SuplierValue14 = document.getElementById("<%=txt_SuplierValue14.ClientID %>");
    var txt_SuplierValue15 = document.getElementById("<%=txt_SuplierValue15.ClientID %>");
    var txt_SuplierValue16 = document.getElementById("<%=txt_SuplierValue16.ClientID %>");
    var txt_SuplierValue17 = document.getElementById("<%=txt_SuplierValue17.ClientID %>");
    var txt_SuplierValue18 = document.getElementById("<%=txt_SuplierValue18.ClientID %>");
    var txt_SuplierValue19 = document.getElementById("<%=txt_SuplierValue19.ClientID %>");
    var txt_SuplierValue20 = document.getElementById("<%=txt_SuplierValue20.ClientID %>");
    var txt_SuplierValue21 = document.getElementById("<%=txt_SuplierValue21.ClientID %>");
    var txt_SuplierValue22 = document.getElementById("<%=txt_SuplierValue22.ClientID %>");
    var txt_SuplierValue23 = document.getElementById("<%=txt_SuplierValue23.ClientID %>");
    var txt_SuplierValue24 = document.getElementById("<%=txt_SuplierValue24.ClientID %>");
    var txt_SuplierValue25 = document.getElementById("<%=txt_SuplierValue25.ClientID %>");

    //var div_OutItemTitle = document.getElementById("div_OutItemTitle");
    //var div_OutDescription = document.getElementById("div_OutDescription");
    //var div_OutArtwork = document.getElementById("div_OutArtwork");
    //var div_OutColour = document.getElementById("div_OutColour");
    //var div_OutSize = document.getElementById("div_OutSize");
    //var div_OutMaterial = document.getElementById("div_OutMaterial");
    //var div_OutDelivery = document.getElementById("div_OutDelivery");
    //var div_OutFinishing = document.getElementById("div_OutFinishing");
    //var div_OutProofs = document.getElementById("div_OutProofs");
    //var div_OutPacking = document.getElementById("div_OutPacking");
    //var div_OutNotes = document.getElementById("div_OutNotes");
    //var div_OutInstructions = document.getElementById("div_OutInstructions");

    //var div_SupplierDescrn1 = document.getElementById("div_SupplierDescrn1");
    //var div_SupplierDescrn2 = document.getElementById("div_SupplierDescrn2");
    //var div_SupplierDescrn3 = document.getElementById("div_SupplierDescrn3");
    //var div_SupplierDescrn4 = document.getElementById("div_SupplierDescrn4");
    //var div_SupplierDescrn5 = document.getElementById("div_SupplierDescrn5");
    //var div_SupplierDescrn6 = document.getElementById("div_SupplierDescrn6");
    //var div_SupplierDescrn7 = document.getElementById("div_SupplierDescrn7");
    //var div_SupplierDescrn8 = document.getElementById("div_SupplierDescrn8");
    //var div_SupplierDescrn9 = document.getElementById("div_SupplierDescrn9");
    //var div_SupplierDescrn10 = document.getElementById("div_SupplierDescrn10");
    //var div_SupplierDescrn11 = document.getElementById("div_SupplierDescrn11");
    //var div_SupplierDescrn12 = document.getElementById("div_SupplierDescrn12");
    //var div_SupplierDescrn13 = document.getElementById("div_SupplierDescrn13");
    //var div_SupplierDescrn14 = document.getElementById("div_SupplierDescrn14");
    //var div_SupplierDescrn15 = document.getElementById("div_SupplierDescrn15");
    //var div_SupplierDescrn16 = document.getElementById("div_SupplierDescrn16");
    //var div_SupplierDescrn17 = document.getElementById("div_SupplierDescrn17");
    //var div_SupplierDescrn18 = document.getElementById("div_SupplierDescrn18");
    //var div_SupplierDescrn19 = document.getElementById("div_SupplierDescrn19");
    //var div_SupplierDescrn20 = document.getElementById("div_SupplierDescrn20");
    //var div_SupplierDescrn21 = document.getElementById("div_SupplierDescrn21");
    //var div_SupplierDescrn22 = document.getElementById("div_SupplierDescrn22");
    //var div_SupplierDescrn23 = document.getElementById("div_SupplierDescrn23");
    //var div_SupplierDescrn24 = document.getElementById("div_SupplierDescrn24");
    //var div_SupplierDescrn25 = document.getElementById("div_SupplierDescrn25");

    var div_OutItemTitle = document.getElementById('<%= div_OutItemTitle.ClientID %>');
    var div_OutDescription = document.getElementById('<%= div_OutDescription.ClientID %>');
    var div_OutArtwork = document.getElementById('<%= div_OutArtwork.ClientID %>');
    var div_OutColour = document.getElementById('<%= div_OutColour.ClientID %>');
    var div_OutSize = document.getElementById('<%= div_OutSize.ClientID %>');
    var div_OutMaterial = document.getElementById('<%= div_OutMaterial.ClientID %>');
    var div_OutDelivery = document.getElementById('<%= div_OutDelivery.ClientID %>');
    var div_OutFinishing = document.getElementById('<%= div_OutFinishing.ClientID %>');
    var div_OutProofs = document.getElementById('<%= div_OutProofs.ClientID %>');
    var div_OutPacking = document.getElementById('<%= div_OutPacking.ClientID %>');
    var div_OutNotes = document.getElementById('<%= div_OutNotes.ClientID %>');
    var div_OutInstructions = document.getElementById('<%= div_OutInstructions.ClientID %>');

    var div_SupplierDescrn1 = document.getElementById('<%= div_SupplierDescrn1.ClientID %>');
    var div_SupplierDescrn2 = document.getElementById('<%= div_SupplierDescrn2.ClientID %>');
    var div_SupplierDescrn3 = document.getElementById('<%= div_SupplierDescrn3.ClientID %>');
    var div_SupplierDescrn4 = document.getElementById('<%= div_SupplierDescrn4.ClientID %>');
    var div_SupplierDescrn5 = document.getElementById('<%= div_SupplierDescrn5.ClientID %>');
    var div_SupplierDescrn6 = document.getElementById('<%= div_SupplierDescrn6.ClientID %>');
    var div_SupplierDescrn7 = document.getElementById('<%= div_SupplierDescrn7.ClientID %>');
    var div_SupplierDescrn8 = document.getElementById('<%= div_SupplierDescrn8.ClientID %>');
    var div_SupplierDescrn9 = document.getElementById('<%= div_SupplierDescrn9.ClientID %>');
    var div_SupplierDescrn10 = document.getElementById('<%= div_SupplierDescrn10.ClientID %>');
    var div_SupplierDescrn11 = document.getElementById('<%= div_SupplierDescrn11.ClientID %>');
    var div_SupplierDescrn12 = document.getElementById('<%= div_SupplierDescrn12.ClientID %>');
    var div_SupplierDescrn13 = document.getElementById('<%= div_SupplierDescrn13.ClientID %>');
    var div_SupplierDescrn14 = document.getElementById('<%= div_SupplierDescrn14.ClientID %>');
    var div_SupplierDescrn15 = document.getElementById('<%= div_SupplierDescrn15.ClientID %>');
    var div_SupplierDescrn16 = document.getElementById('<%= div_SupplierDescrn16.ClientID %>');
    var div_SupplierDescrn17 = document.getElementById('<%= div_SupplierDescrn17.ClientID %>');
    var div_SupplierDescrn18 = document.getElementById('<%= div_SupplierDescrn18.ClientID %>');
    var div_SupplierDescrn19 = document.getElementById('<%= div_SupplierDescrn19.ClientID %>');
    var div_SupplierDescrn20 = document.getElementById('<%= div_SupplierDescrn20.ClientID %>');
    var div_SupplierDescrn21 = document.getElementById('<%= div_SupplierDescrn21.ClientID %>');
    var div_SupplierDescrn22 = document.getElementById('<%= div_SupplierDescrn22.ClientID %>');
    var div_SupplierDescrn23 = document.getElementById('<%= div_SupplierDescrn23.ClientID %>');
    var div_SupplierDescrn24 = document.getElementById('<%= div_SupplierDescrn24.ClientID %>');
    var div_SupplierDescrn25 = document.getElementById('<%= div_SupplierDescrn25.ClientID %>');


    var IsMain = "<%=IsMain %>";
    var UcPage = "<%=UcPage %>";

    var txtSingleQty = document.getElementById("<%=txtSingleQty.ClientID %>");
    var txtMultiQty1 = document.getElementById("<%=txtMultiQty1.ClientID %>");
    var txtMultiQty2 = document.getElementById("<%=txtMultiQty2.ClientID %>");
    var txtMultiQty3 = document.getElementById("<%=txtMultiQty3.ClientID %>");
    var txtMultiQty4 = document.getElementById("<%=txtMultiQty4.ClientID %>");
    var txtRunQty1 = document.getElementById("<%=txtRunQty1.ClientID %>");
    var txtRunQty2 = document.getElementById("<%=txtRunQty2.ClientID %>");

    var txtRFQReturnDate = document.getElementById("<%=txtRFQReturnDate.ClientID %>");
    var txtJobCompletionDate = document.getElementById("<%=txtJobCompletionDate.ClientID %>");
    var txtTitle = document.getElementById("<%=txtTitle.ClientID %>");
    var txtTitleDescription = document.getElementById("<%=txtTitleDescription.ClientID %>");

    var spn_PrintBroker_Header = document.getElementById("<%=spn_PrintBroker_Header.ClientID %>");
    var spn_PrintBroker_Footer = document.getElementById("<%=spn_PrintBroker_Footer.ClientID %>");

    //Initializs        
    var btn_Outwork_PrintEmail = document.getElementById("<%=btn_Outwork_PrintEmail.ClientID %>");

    var ddlCostingType = document.getElementById("<%=ddlCostingType.ClientID %>");
    var RadTimePicker1 = document.getElementById("<%=RadTimePicker1.ClientID %>");
    var txtJobCompletionDate = document.getElementById("<%=txtJobCompletionDate.ClientID %>");

    var RdlQtyType = document.getElementById("<%=RdlQtyType.ClientID %>");

    var txtSingleQty1 = document.getElementById("<%=txtSingleQty.ClientID %>");

    var txtRunQty11 = document.getElementById("<%=txtRunQty1.ClientID %>");
    var txtRunQty22 = document.getElementById("<%=txtRunQty2.ClientID %>");

    var txtMultiQty11 = document.getElementById("<%=txtMultiQty1.ClientID %>");
    var txtMultiQty22 = document.getElementById("<%=txtMultiQty2.ClientID %>");
    var txtMultiQty33 = document.getElementById("<%=txtMultiQty3.ClientID %>");
    var txtMultiQty44 = document.getElementById("<%=txtMultiQty4.ClientID %>");

    var UploadedFiles = '';

    //Check Box For Inserting into Phrase Book
    var chk_broker_Phrase_Title = document.getElementById("<%=chk_broker_Phrase_Title.ClientID %>");
    var chk_broker_Phrase_Design = document.getElementById("<%=chk_broker_Phrase_Design.ClientID %>");
    var chk_broker_Phrase_Artwork = document.getElementById("<%=chk_broker_Phrase_Artwork.ClientID %>");
    var chk_broker_Phrase_Color = document.getElementById("<%=chk_broker_Phrase_Color.ClientID %>");
    var chk_broker_Phrase_Size = document.getElementById("<%=chk_broker_Phrase_Size.ClientID %>");
    var chk_broker_Phrase_Material = document.getElementById("<%=chk_broker_Phrase_Material.ClientID %>");
    var chk_broker_Phrase_Finishing = document.getElementById("<%=chk_broker_Phrase_Finishing.ClientID %>");
    var chk_broker_Phrase_Proofs = document.getElementById("<%=chk_broker_Phrase_Proofs.ClientID %>");
    var chk_broker_Phrase_Packing = document.getElementById("<%=chk_broker_Phrase_Packing.ClientID %>");
    var chk_broker_Phrase_Delivery = document.getElementById("<%=chk_broker_Phrase_Delivery.ClientID %>");
    var chk_broker_Phrase_Notes = document.getElementById("<%=chk_broker_Phrase_Notes.ClientID %>");
    var chk_broker_Phrase_Terms = document.getElementById("<%=chk_broker_Phrase_Terms.ClientID %>");

    var Chk_DescnsToPhrase1 = document.getElementById("<%=Chk_DescnsToPhrase1.ClientID %>");
    var Chk_DescnsToPhrase2 = document.getElementById("<%=Chk_DescnsToPhrase2.ClientID %>");
    var Chk_DescnsToPhrase3 = document.getElementById("<%=Chk_DescnsToPhrase3.ClientID %>");
    var Chk_DescnsToPhrase4 = document.getElementById("<%=Chk_DescnsToPhrase4.ClientID %>");
    var Chk_DescnsToPhrase5 = document.getElementById("<%=Chk_DescnsToPhrase5.ClientID %>");
    var Chk_DescnsToPhrase6 = document.getElementById("<%=Chk_DescnsToPhrase6.ClientID %>");
    var Chk_DescnsToPhrase7 = document.getElementById("<%=Chk_DescnsToPhrase7.ClientID %>");
    var Chk_DescnsToPhrase8 = document.getElementById("<%=Chk_DescnsToPhrase8.ClientID %>");
    var Chk_DescnsToPhrase9 = document.getElementById("<%=Chk_DescnsToPhrase9.ClientID %>");
    var Chk_DescnsToPhrase10 = document.getElementById("<%=Chk_DescnsToPhrase10.ClientID %>");
    var Chk_DescnsToPhrase11 = document.getElementById("<%=Chk_DescnsToPhrase11.ClientID %>");
    var Chk_DescnsToPhrase12 = document.getElementById("<%=Chk_DescnsToPhrase12.ClientID %>");
    var Chk_DescnsToPhrase13 = document.getElementById("<%=Chk_DescnsToPhrase13.ClientID %>");
    var Chk_DescnsToPhrase14 = document.getElementById("<%=Chk_DescnsToPhrase14.ClientID %>");
    var Chk_DescnsToPhrase15 = document.getElementById("<%=Chk_DescnsToPhrase15.ClientID %>");
    var Chk_DescnsToPhrase16 = document.getElementById("<%=Chk_DescnsToPhrase16.ClientID %>");
    var Chk_DescnsToPhrase17 = document.getElementById("<%=Chk_DescnsToPhrase17.ClientID %>");
    var Chk_DescnsToPhrase18 = document.getElementById("<%=Chk_DescnsToPhrase18.ClientID %>");
    var Chk_DescnsToPhrase19 = document.getElementById("<%=Chk_DescnsToPhrase19.ClientID %>");
    var Chk_DescnsToPhrase20 = document.getElementById("<%=Chk_DescnsToPhrase20.ClientID %>");
    var Chk_DescnsToPhrase21 = document.getElementById("<%=Chk_DescnsToPhrase21.ClientID %>");
    var Chk_DescnsToPhrase22 = document.getElementById("<%=Chk_DescnsToPhrase22.ClientID %>");
    var Chk_DescnsToPhrase23 = document.getElementById("<%=Chk_DescnsToPhrase23.ClientID %>");
    var Chk_DescnsToPhrase24 = document.getElementById("<%=Chk_DescnsToPhrase24.ClientID %>");
    var Chk_DescnsToPhrase25 = document.getElementById("<%=Chk_DescnsToPhrase25.ClientID %>");



    //For  Main Check Condition.
    var chkOutDescription = document.getElementById("<%=chkOutDescription.ClientID %>");
    var chkOutItemTitle = document.getElementById("<%=chkOutItemTitle.ClientID %>");
    var chkOutArtwork = document.getElementById("<%=chkOutArtwork.ClientID %>");
    var chkOutColour = document.getElementById("<%=chkOutColour.ClientID %>");
    var chkOutSize = document.getElementById("<%=chkOutSize.ClientID %>");
    var chkOutMaterial = document.getElementById("<%=chkOutMaterial.ClientID %>");
    var chkOutDelivery = document.getElementById("<%=chkOutDelivery.ClientID %>");
    var chkOutFinishing = document.getElementById("<%=chkOutFinishing.ClientID %>");
    var chkOutProofs = document.getElementById("<%=chkOutProofs.ClientID %>");
    var chkOutPacking = document.getElementById("<%=chkOutPacking.ClientID %>");
    var chkOutNotes = document.getElementById("<%=chkOutNotes.ClientID %>");
    var chkOutInstructions = document.getElementById("<%=chkOutInstructions.ClientID %>");

    var Chk_SuplierDescn1 = document.getElementById("<%=Chk_SuplierDescn1.ClientID %>");
    var Chk_SuplierDescn2 = document.getElementById("<%=Chk_SuplierDescn2.ClientID %>");
    var Chk_SuplierDescn3 = document.getElementById("<%=Chk_SuplierDescn3.ClientID %>");
    var Chk_SuplierDescn4 = document.getElementById("<%=Chk_SuplierDescn4.ClientID %>");
    var Chk_SuplierDescn5 = document.getElementById("<%=Chk_SuplierDescn5.ClientID %>");
    var Chk_SuplierDescn6 = document.getElementById("<%=Chk_SuplierDescn6.ClientID %>");
    var Chk_SuplierDescn7 = document.getElementById("<%=Chk_SuplierDescn7.ClientID %>");
    var Chk_SuplierDescn8 = document.getElementById("<%=Chk_SuplierDescn8.ClientID %>");
    var Chk_SuplierDescn9 = document.getElementById("<%=Chk_SuplierDescn9.ClientID %>");
    var Chk_SuplierDescn10 = document.getElementById("<%=Chk_SuplierDescn10.ClientID %>");
    var Chk_SuplierDescn11 = document.getElementById("<%=Chk_SuplierDescn11.ClientID %>");
    var Chk_SuplierDescn12 = document.getElementById("<%=Chk_SuplierDescn12.ClientID %>");
    var Chk_SuplierDescn13 = document.getElementById("<%=Chk_SuplierDescn13.ClientID %>");
    var Chk_SuplierDescn14 = document.getElementById("<%=Chk_SuplierDescn14.ClientID %>");
    var Chk_SuplierDescn15 = document.getElementById("<%=Chk_SuplierDescn15.ClientID %>");
    var Chk_SuplierDescn16 = document.getElementById("<%=Chk_SuplierDescn16.ClientID %>");
    var Chk_SuplierDescn17 = document.getElementById("<%=Chk_SuplierDescn17.ClientID %>");
    var Chk_SuplierDescn18 = document.getElementById("<%=Chk_SuplierDescn18.ClientID %>");
    var Chk_SuplierDescn19 = document.getElementById("<%=Chk_SuplierDescn19.ClientID %>");
    var Chk_SuplierDescn20 = document.getElementById("<%=Chk_SuplierDescn20.ClientID %>");
    var Chk_SuplierDescn21 = document.getElementById("<%=Chk_SuplierDescn21.ClientID %>");
    var Chk_SuplierDescn22 = document.getElementById("<%=Chk_SuplierDescn22.ClientID %>");
    var Chk_SuplierDescn23 = document.getElementById("<%=Chk_SuplierDescn23.ClientID %>");
    var Chk_SuplierDescn24 = document.getElementById("<%=Chk_SuplierDescn24.ClientID %>");
    var Chk_SuplierDescn25 = document.getElementById("<%=Chk_SuplierDescn25.ClientID %>");


    var IsEdit = false;
    var EditNo = '';
    //-----------
    var rowno = 1;
    var supCount = 1;
    var labelCount = 1;

    var tableSup = document.getElementById("tableSup");
    var ReqType = '<%=ReqType %>';
    var strSupList = document.getElementById("<%=hid_Suppliers.ClientID %>");
    var ddl1 = document.getElementById("<%=ddlSupplier1.ClientID %>");
    var ddl2 = document.getElementById("<%=ddlSupplierContact1.ClientID %>");
    var SupplierContacts = document.getElementById("<%=ddlSupplierContact1.ClientID%>");

    function CallWebService(ids) {
        var OutID = ArrayPrint[ids].EstOutworkID;
        var firstConfirm = window.confirm('Are you sure, you want to remove ? ');
        if (firstConfirm) {
            PageMethods.RemovePrintBroker(CompanyID, OutID, "subitem");
            ArrayPrint.splice(ids, 1);
            ShowOutworkList();
        }
    }
    var IsPrintBrokerDirect;
    IsPrintBrokerDirect = '<%=IsPrintBrokerDirect%>';
    var hid_Pub_ClientID = document.getElementById("<%=hid_Pub_ClientID.ClientID %>");
    var hid_outwork_save = document.getElementById("<%=hid_outwork_save.ClientID %>");

    var hdn_Sleep = document.getElementById("<%=hdn_Sleep.ClientID %>");
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/item_printbroker_new.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">

    var qtyarray = getName('<%=RdlQtyType.ClientID %>');
    var costarray = getName("<%=ddlCostingType.ClientID %>");
    var QtyTypeArray = getName('<%=RdlQtyType.ClientID %>');
    var CostTypeArray = getName("<%=ddlCostingType.ClientID %>");
    if (QueryType == "add") {
        BindOutworkDesc();
    }
    function dateformatnew() {
        var DateFormatNEW = "<%=DateFormat %>";
        return DateFormatNEW;
    }

    document.onkeydown = keyProcess;
    function keyProcess(e) {
        var isIE = /MSIE/.test(navigator.userAgent);
        var kcode = 0;
        kcode = isIE ? event.keyCode : e.which;

        if (kcode == 9) {
            CloseSwazzCalender();
        }
    }

</script>
<asp:HiddenField ID="hid_single_outworkData" runat="server" Value="" />
<asp:HiddenField ID="hid_outwork_title" runat="server" Value="" />
<asp:HiddenField ID="hid_from_printemail" runat="server" />
<asp:HiddenField ID="hid_DefaultMarkupType" runat="server" Value="" />
<asp:HiddenField ID="hdn_SupCount" runat="server" Value="0" />
<asp:HiddenField ID="hdn_supplierproductcatalogueid" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ArtworkFileSave" runat="server" Value="" />
<script>
    var hid_single_outworkData = document.getElementById("<%=hid_single_outworkData.ClientID %>");
    var hid_outwork_title = document.getElementById("<%=hid_outwork_title.ClientID %>");
    var hid_DefaultMarkupType = document.getElementById("<%=hid_DefaultMarkupType.ClientID %>");
    var hdn_SupCount = document.getElementById("<%=hdn_SupCount.ClientID %>");
    var hdn_supplierproductcatalogueid = document.getElementById("<%=hdn_supplierproductcatalogueid.ClientID %>");
    if (!IsEdit) {
        document.getElementById("div_print_broker_step_1").style.display = "block";
    }
</script>

<asp:Panel ID="pnlMainOutwork" runat="server" Visible="false">
    <script>
        function funreqtype() {
            var reqtype = '<%=ReqType %>';
            return reqtype;
        }
        var print_broker = "div_print_broker";
        var RequestType = '<%=Request.QueryString["type"]%>';

        ShowEstimate('printbroker');

        EditOutwork();

        var firstQtyValue = '';
        var firstSay = false;
        for (var i = 0; i < QtyTypeArray.length; i++) {
            QtyTypeArray[i].disabled = false;
            if (QtyTypeArray[i].checked) {
                firstQtyValue = QtyTypeArray[i].value;
            }
            QtyTypeArray[i].onclick = handler;
        }
        function RadWinClose() {
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }

        //Only for Occy .. in Re-Run case to show directtly Price Comparision screen -- 6 -1-2012
        document.getElementById("div_print_broker_step_1").style.display = "none";
        document.getElementById("div_print_broker_step_3").style.display = "none";
        if ('<%=SysName %>'.toLowerCase() == "occy") {
            document.getElementById("div_print_broker_step_1").style.display = "none";
            document.getElementById("div_print_broker_step_3").style.display = "block";
            document.getElementById("lblheader").innerHTML = '<%=objLanguage.GetLanguageConversion("Price_Comparison")%>';

            if (ddlCostingType.selectedIndex == 0) {
                document.getElementById("div_simplecosting").style.display = "none";
                document.getElementById("div_unitcosting").style.display = "block";
                document.getElementById("div_per1000costing").style.display = "none";
            }
            if (ddlCostingType.selectedIndex == 1) {
                document.getElementById("div_simplecosting").style.display = "block";
                document.getElementById("div_unitcosting").style.display = "none";
                document.getElementById("div_per1000costing").style.display = "none";
            }
            if (ddlCostingType.selectedIndex == 2) {
                document.getElementById("div_simplecosting").style.display = "none";
                document.getElementById("div_unitcosting").style.display = "none";
                document.getElementById("div_per1000costing").style.display = "none";
            }
        }
        else {
            document.getElementById("div_print_broker_step_1").style.display = "block";
        }
        //Only for Occy .. in Re-Run case to show directtly Price Comparision screen -- 6 -1-2012

    </script>
</asp:Panel>
<script type="text/javascript">
    var ClientID = '<%=ClientId_PB%>';


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
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>
<asp:Panel ID="pnlmultipleqtyonadditionalitem" Visible="false" runat="server">
    <script type="text/javascript">
        qtyarray[1].checked = true;
        div_MultyQty.style.display = 'block';
    </script>
</asp:Panel>
<asp:Panel ID="pnlsingleqtyonadditionalitem" Visible="false" runat="server">
    <script type="text/javascript">
        qtyarray[0].checked = true;
        div_MultyQty.style.display = 'none';
        div_singleQty.style.display = 'block';
    </script>
</asp:Panel>
