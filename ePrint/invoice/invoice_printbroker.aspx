<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="invoice_printbroker.aspx.cs" Inherits="ePrint.invoice.invoice_printbroker" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="printbroker" Src="~/usercontrol/Item/item_printbroker_new.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/item/item_firstprintbroker.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>'"></script>
    <asp:Label ID="lblheader" runat="server"></asp:Label>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" class="bor" nowrap="nowrap">
                            <span class="navigatorpanel" id="Span1">Supplier Request For Quote Item Description</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="content">
       <%-- <div class="borderWithoutTop">--%>
            <div class="onlyEmpty">
            </div>
            <div id="div_print_broker" align="left" style="width: 99%; min-width: 1200px; display: block;">
                <UC:printbroker ID="divprintbroker" runat="server" />
            </div>
            <div id="div_printbroker_summary" style="display: none; min-width: 1200px;">
                <div style="float: left; width: 99%;">
                    <div style="width: 60%;">
                        <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                            <div style="height: 15px;">
                                &nbsp;
                            </div>
                            <div style="clear: both">
                            </div>
                            <asp:CheckBox ID="chkPBItemTitle" onclick="chkPBItemTitleChecked(this);" runat="server"
                                Checked="true" />
                        </div>
                        <div style="float: left; width: 96%;">
                            <div style="float: left; width: 100%;">
                                <div style="float: left;">
                                    <div style="height: 15px; width: 30px">
                                        &nbsp;
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <div class="bglabel_new" style="width: 229px; float: left">
                                        <div style="float: left">
                                            <asp:TextBox ID="txt_lblPBItemTitle" onblur="lblPBItemTitleData(this.value);" SkinID="textPad"
                                                runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div style="float: right">
                                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton36" runat="server" CausesValidation="False"
                                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Title');return false;" /></div>
                                        <asp:HiddenField ID="hdn_lblPBItemTitle" runat="server" Value="" />
                                    </div>
                                </div>
                                <div style="float: left;">
                                    <div style="float: left; padding-left: 5px">
                                        <div style="height: 17px; width: 50px">
                                            &nbsp;
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <asp:TextBox ID="txtPBItemTitle" onblur="PBItemTitleData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <div style="float: left; padding-bottom: 4px">
                                            &nbsp;Save to Phrase Book
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div style="float: left;">
                                            <asp:CheckBox ID="chk_Outwork_Phrase_ItemTitle" runat="server" /></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both; padding-top: 2px">
                        </div>
                        <div id="div_PBDescription" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBDescription" onclick="chkPBDescriptionChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px; height: 41px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBDescription" onblur="lblPBDescriptionData(this.value);"
                                            SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton37" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Description');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBDescription" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBDesign" onblur="PBDesignData(this.value);" SkinID="textPad"
                                            TextMode="MultiLine" runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Design" runat="server" />
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
                        <div id="div_PBArtwork" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBArtwork" onclick="chkPBArtworkChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBArtwork" onblur="lblPBArtworkData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton38" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Artwork');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBArtwork" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBArtwork" onblur="PBArtworkData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Artwork" runat="server" />
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
                        <div id="div_PBColour" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBColour" onclick="chkPBColourChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBColour" onblur="lblPBColourData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton39" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Colours');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBColour" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBColour" onblur="PBColourData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Colour" runat="server" />
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
                        <div id="div_PBSize" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBSize" onclick="chkPBSizeChecked(this);" runat="server" Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBSize" onblur="lblPBSizeData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton40" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Size');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBSize" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBSize" onblur="PBSizeData(this.value);" SkinID="textPad" runat="server"
                                            Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Size" runat="server" />
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
                        <div id="div_PBMaterial" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBMaterials" onclick="chkPBMaterialsChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBMaterials" onblur="lblPBMaterialsData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton41" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Material');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBMaterials" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBMaterials" onblur="PBMaterialsData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Material" runat="server" />
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
                        <div id="div_PBDelivery" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBDelivery" onclick="chkPBDeliveryChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBDelivery" onblur="lblPBDeliveryData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton42" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Delivery');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBDelivery" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBDelivery" onblur="PBDeliveryData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Delivery" runat="server" />
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
                        <div id="div_PBFinishing" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBFinishing" onclick="chkPBFinishingChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBFinishing" onblur="lblPBFinishingData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton43" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Finishing');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBFinishing" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBFinishing" onblur="PBFinishingData(this.value);" SkinID="textPad"
                                            runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Finishing" runat="server" />
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
                        <div id="div_PBNotes" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBNotes" onclick="chkPBNotesChecked(this);" runat="server" Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px; height: 41px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBNotes" onblur="lblPBNotesData(this.value);" SkinID="textPad"
                                            runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton44" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Notes');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBNotes" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBNotes" onblur="PBNotesData(this.value);" TextMode="MultiLine"
                                            SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Notes" runat="server" />
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
                        <div id="div_PBInstructions" align="left" style="display: block">
                            <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                                <asp:CheckBox ID="chkPBInstructions" onclick="chkPBInstructionsChecked(this);" runat="server"
                                    Checked="true" /></div>
                            <div style="float: left; width: 90%">
                                <div class="bglabel_new" style="width: 229px; height: 41px;">
                                    <div style="float: left">
                                        <asp:TextBox ID="txt_lblPBInstructions" onblur="lblPBInstructionsData(this.value);"
                                            SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div style="float: right;">
                                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton68" runat="server" CausesValidation="False"
                                            ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('PrintBroker Terms');return false;" /></div>
                                    <asp:HiddenField ID="hdn_lblPBInstructions" runat="server" Value="" />
                                </div>
                                <div class="box">
                                    <div style="float: left">
                                        <asp:TextBox ID="txtPBInstructions" onblur="PBInstructionsData(this.value);" TextMode="MultiLine"
                                            SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_Outwork_Phrase_Instructions" runat="server" />
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <span id="span_none" class="spanerrorMsg" style="width: 100%"></span>
                            <asp:HiddenField ID="hdn_OutworkDesc" runat="server" Value="" />
                        </div>
                    </div>
                </div>
                <script type="text/javascript" language="javascript">
                    var strSitepath = "<%=strSitepath %>";
                    var div_PrintBrokerSummary = "div_printbroker_summary";
                    //To bind othetcost desc//
                    var hdn_OutworkDesc = document.getElementById("<%=hdn_OutworkDesc.ClientID %>");
                    var txt_lblPBItemTitle = document.getElementById("<%=txt_lblPBItemTitle.ClientID %>");
                    var txt_lblPBDescription = document.getElementById("<%=txt_lblPBDescription.ClientID %>");
                    var txt_lblPBArtwork = document.getElementById("<%=txt_lblPBArtwork.ClientID %>");
                    var txt_lblPBColour = document.getElementById("<%=txt_lblPBColour.ClientID %>");
                    var txt_lblPBSize = document.getElementById("<%=txt_lblPBSize.ClientID %>");
                    var txt_lblPBMaterials = document.getElementById("<%=txt_lblPBMaterials.ClientID %>");
                    var txt_lblPBDelivery = document.getElementById("<%=txt_lblPBDelivery.ClientID %>");
                    var txt_lblPBFinishing = document.getElementById("<%=txt_lblPBFinishing.ClientID %>");
                    var txt_lblPBNotes = document.getElementById("<%=txt_lblPBNotes.ClientID %>");
                    var txt_lblPBInstructions = document.getElementById("<%=txt_lblPBInstructions.ClientID %>");

                    var chkPBItemTitle = document.getElementById("<%=chkPBItemTitle.ClientID %>");
                    var chkPBDescription = document.getElementById("<%=chkPBDescription.ClientID %>");
                    var chkPBArtwork = document.getElementById("<%=chkPBArtwork.ClientID %>");
                    var chkPBColour = document.getElementById("<%=chkPBColour.ClientID %>");
                    var chkPBSize = document.getElementById("<%=chkPBSize.ClientID %>");
                    var chkPBMaterials = document.getElementById("<%=chkPBMaterials.ClientID %>");
                    var chkPBDelivery = document.getElementById("<%=chkPBDelivery.ClientID %>");
                    var chkPBFinishing = document.getElementById("<%=chkPBFinishing.ClientID %>");
                    var chkPBNotes = document.getElementById("<%=chkPBNotes.ClientID %>");
                    var chkPBInstructions = document.getElementById("<%=chkPBInstructions.ClientID %>");

                    var hdn_lblPBItemTitle = document.getElementById("<%=hdn_lblPBItemTitle.ClientID %>");
                    var hdn_lblPBDescription = document.getElementById("<%=hdn_lblPBDescription.ClientID %>");
                    var hdn_lblPBArtwork = document.getElementById("<%=hdn_lblPBArtwork.ClientID %>");
                    var hdn_lblPBColour = document.getElementById("<%=hdn_lblPBColour.ClientID %>");
                    var hdn_lblPBSize = document.getElementById("<%=hdn_lblPBSize.ClientID %>");
                    var hdn_lblPBMaterials = document.getElementById("<%=hdn_lblPBMaterials.ClientID %>");
                    var hdn_lblPBDelivery = document.getElementById("<%=hdn_lblPBDelivery.ClientID %>");
                    var hdn_lblPBFinishing = document.getElementById("<%=hdn_lblPBFinishing.ClientID %>");
                    var hdn_lblPBNotes = document.getElementById("<%=hdn_lblPBNotes.ClientID %>");
                    var hdn_lblPBInstructions = document.getElementById("<%=hdn_lblPBInstructions.ClientID %>");

                    var txtPBItemTitle = document.getElementById("<%=txtPBItemTitle.ClientID %>"); //var txtPBItemTitleID by vinay
                    var txtPBDesign = document.getElementById("<%=txtPBDesign.ClientID %>");
                    var txtPBArtwork = document.getElementById("<%=txtPBArtwork.ClientID %>");
                    var txtPBColour = document.getElementById("<%=txtPBColour.ClientID %>");
                    var txtPBSize = document.getElementById("<%=txtPBSize.ClientID %>");
                    var txtPBMaterials = document.getElementById("<%=txtPBMaterials.ClientID %>");
                    var txtPBDelivery = document.getElementById("<%=txtPBDelivery.ClientID %>");
                    var txtPBFinishing = document.getElementById("<%=txtPBFinishing.ClientID %>");
                    var txtPBNotes = document.getElementById("<%=txtPBNotes.ClientID %>");
                    var txtPBInstructions = document.getElementById("<%=txtPBInstructions.ClientID %>");

                    ///BindOutworkDesc()
                </script>
                <asp:TextBox ID="txtItemTitle" SkinID="textPad" onblur="ItemTitleLoad(this.value);validateName(this.value)"
                    runat="server" MaxLength="50"></asp:TextBox>
                <asp:HiddenField ID="hid_Estimate_Type" runat="server" />
                <%--When Print Broker used in Edit case of Sub Item --%>
                <asp:HiddenField ID="hid_single_outworkData" Value="" runat="server" />
                <script>
                    var estimateType = '';
                    var productType = '';
                    var IsPrintBrokerDirect = false;
                    function funreqtype() {
                        var reqtype = '<%=QueryType %>';
                        return reqtype;
                    }
                    var hid_Estimate_Type = document.getElementById("<%=hid_Estimate_Type.ClientID %>");
                    var txtItemTitle = document.getElementById("<%=txtItemTitle.ClientID %>");


                    var hid_single_outworkData = document.getElementById("<%=hid_single_outworkData.ClientID %>");
                  
                </script>
            </div>
            <div class="onlyEmpty">
            </div>
        <%--</div>--%>
    </div>
    <script type="text/javascript">
        if (window.screen.Width < 1400) {
            document.getElementById("content").style.width = "1390";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

