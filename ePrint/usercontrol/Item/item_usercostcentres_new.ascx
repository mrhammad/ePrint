<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_usercostcentres_new.ascx.cs" Inherits="ePrint.usercontrol.Item.item_usercostcentres_new" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="navigatorpanel">
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content" style="overflow: hidden;">
    <div id="padding" class="div_othercostmargin">
        <div class="onlyEmpty">
        </div>
        <div id="costcentre" style="width: 100%; display: block;">
            <div id="div_costcenterheader" style="width: 100%; display: none" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">Select Cost Centre</span>
                                </div>
                                <div style="width: 50px; float: right;">
                                    <a href="javascript:closewindow('div_cost_centre');" style="color: White;">Close X</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="div_costcenterborder">
                <div align="left" style="width: 100%">
                    <div style="clear: both; height: 10px;">
                        &nbsp;
                    </div>
                    <div id="div_othercostTitle" align="left" style="display: none;">
                        <div class="bglabel" style="width: 150px;">
                            <asp:Label ID="lbl_ItemTitle" runat="server" CssClass="normaltext"> <%=objLanguage.GetLanguageConversion("Item_Title") %></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="box" style="float: left;">
                            <asp:TextBox ID="txt_ItemTitle" SkinID="textPad" Width="260px" runat="server" MaxLength="70"></asp:TextBox><%--onblur="CallonBlur(this.value,'spn_txtItemTitle');"--%>
                        </div>
                        <div class="box" style="float: left;">
                            <span id="spn_txtItemTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Item_Title") %></span>
                        </div>
                    </div>
                    <div id="div_othercostMain" align="left" style="display: none;">
                        <div class="bglabel" style="width: 150px; border: 0px solid blue">
                            <%=objLanguage.GetLanguageConversion("Finished_Quantity")%>
                            <span style="color: Red; padding-right: 1px">*</span>
                        </div>
                        <div style="float: left;">
                            <div id="div_qty1" class="box" style="float: left; width: 120px; border: 0px solid red; vertical-align: top;">
                                <%=objLanguage.GetLanguageConversion("Qty1") %>
                                <asp:TextBox ID="txtQuantity1" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);onblur_estQtyLists();"
                                    onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            </div>
                            <div id="div_qty2" class="box" style="float: left; width: 120px; border: 0px solid red; vertical-align: top;">
                                <%=objLanguage.GetLanguageConversion("Qty2") %>
                                <asp:TextBox ID="txtQuantity2" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);onblur_estQtyLists();"
                                    onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            </div>
                            <div id="div_qty3" class="box" style="float: left; width: 120px; border: 0px solid red; vertical-align: top;">
                                <%=objLanguage.GetLanguageConversion("Qty3") %>
                                <asp:TextBox ID="txtQuantity3" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);onblur_estQtyLists();"
                                    onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            </div>
                            <div id="div_qty4" class="box" style="float: left; width: 120px; border: 0px solid red; vertical-align: top;">
                                <%=objLanguage.GetLanguageConversion("Qty4") %>
                                <asp:TextBox ID="txtQuantity4" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);onblur_estQtyLists();"
                                    onkeyup="javascript:ToInteger(this,this.value);" runat="server" MaxLength="8"></asp:TextBox>
                            </div>
                            <div align="left" style="clear: both; margin-left: 3px; padding-top: 2px">
                                <span id="spn_txtQuantity" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-bottom: 5px">
                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity") %></span> &nbsp;
                            </div>
                        </div>
                    </div>
                    <div id="div_none" align="left" style="width: 50%; display: none">
                        <div style="border: 0px solid green" align="center">
                            <div style="float: left; width: 162px;">
                                &nbsp;
                            </div>
                            <div align="center" id="diverrorMessage" style="width: auto; float: left; padding-top: 3px; padding-bottom: 3px">
                                <span id="span_none" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px; margin-top: 7px;"></span>
                            </div>
                        </div>
                    </div>
                    <div align="left" style="display: block; width: 100%; border: solid 0px blue;">
                        <div id="ynnav" style="width: 90%; white-space: normal; float: left; border: solid 0px blue; border-top: solid 0px gainsboro;">
                            <ul>
                                <asp:PlaceHolder ID="plhTab" runat="server"></asp:PlaceHolder>
                                <div id="div_other_tab">
                                </div>
                                <asp:HiddenField ID="hid_OtherCostValues" runat="server" Value="" />
                            </ul>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div class="divBorderItem">
                            <div class="only5px">
                            </div>
                            <div align="left" style="width: 80%;">
                                <div id="divHeader" align="left" style="width: 100%; border: 1px solid silver;">
                                    <div align="left" style="width: 100%; height: 23px; display: block;" class="bgCustomize"
                                        id="divsubheader">
                                        <div style="float: left; width: 48%; padding: 2px" class="navigatorpanel">
                                            <b>
                                                <%=objLanguage.GetLanguageConversion("Name")%></b>
                                        </div>
                                        <div style="float: left; width: 49%; padding: 2 2 2 0px;" class="navigatorpanel">
                                            <b>
                                                <%=objLanguage.GetLanguageConversion("Description")%></b>
                                        </div>
                                    </div>
                                    <div id="divContent" align="left" style="width: 100%; height: 300px; overflow-y: scroll; overflow-x: hidden">
                                    </div>
                                </div>
                                <asp:HiddenField ID="hid_OtherCostValues_Load" runat="server" Value="" />
                            </div>
                            <div class="only10px">
                            </div>
                        </div>
                        <div style="float: left; width: 49%">
                            <div class="box">
                                <div id="div_OtherCostItems" style="position: absolute; display: none; z-index: 5000; width: 300px; height: 75px;">
                                    <div align="left" class="bgcustomize" style="padding: 2px; padding-right: 0px;">
                                        <div style="float: left; width: 175px">
                                            <span class="navigatorpanel" style="vertical-align: middle; text-align: left;">
                                                <%=objLanguage.GetLanguageConversion("Item_Name") %></span>
                                        </div>
                                        <div style="float: left; width: 50px;">
                                            <span class="navigatorpanel" style="text-align: left;"></span>
                                        </div>
                                        <div align="right" style="float: right;">
                                            <a href="javascript://" onclick="CloseOtherCostItems('m');return false;">
                                                <img src="<%=strImagepath%>close1.jpg" title="Close" border="0" width="10px" height="10px" /></a>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="div_OtherCostItems_Add" align="left" class="divborderItem" style="overflow-y: scroll; clear: both; padding: 2px; height: 100px; background-color: white;">
                                        </div>
                                    </div>
                                </div>
                                <a id="href_ShowOtherCost" href="javascript://" onclick="ShowOtherCostItems('m');return false;"
                                    style="display: none"><b>
                                        <%=objLanguage.GetLanguageConversion("Show_Other_Cost_Items")%></b></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div align="left" id="div_OtherCost_Qty" class="CenterDiv" style="float: left; position: absolute; display: none; height: 100px; width: 400px; padding: 0px; left: 30%; top: 50%;">
                <div class="onlyEmpty">
                </div>
                <div class="removeTrancy">
                    <div align="center" class="bgcustomize" style="width: 100%; padding: 3px 0px 3px 0px;">
                        <div style="float: left; width: 95%; border: 0px solid">
                            <span class="navigatorpanel" style="vertical-align: middle">Quantity</span>
                        </div>
                        <div style="float: right; border: 0px solid">
                            <a href="javascript://" onclick="ShowOtherCostQtyDiv('close');return false;">
                                <img src="<%=strImagepath%>close1.jpg" border="0" width="11px" height="11px" title="Close" /></a>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div align="left" class="CenterDivTopBorder">
                        <div class="onlyEmpty" style="height: 3px;">
                        </div>
                        <div align="left" style="width: 99%; padding-left: 3px">
                            <div class="bglabel">
                                <asp:Label ID="Label135" runat="server" Text="Required Stock Qty"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtOtherCostQty" SkinID="textPad" runat="server" MaxLength="8" onblur="CallonBlur(this.value,'spn_txtOtherCostQty');IsIntegerParameter(this.value,'spn_txtOtherCostQty_number');"></asp:TextBox>
                                <span id="spn_txtOtherCostQty" class="spanerrorMsg" style="display: none; width: 175px;">Please enter Stock Qty </span><span id="spn_txtOtherCostQty_number" class="spanerrorMsg"
                                    style="display: none; width: 175px;">Please enter numeric value </span>
                            </div>
                        </div>
                        <div class="onlyEmpty" style="height: 5px;">
                            <span></span>
                        </div>
                        <div align="left">
                            <div style="float: left; width: 40%;">
                                &nbsp;
                            </div>
                            <div style="float: left;">
                                <div style="float: left;">
                                    <asp:Button ID="Button6" CssClass="button" Text="Add" Width="65px" runat="server"
                                        OnClientClick="javascript:AddThisOtherCostItem(); return false;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
</div>
<%--added by rk--%>
<style type="text/css">
    .RadWindow table.rwTable {
        width: 1200px;
        padding: 0px auto;
    }
</style>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Height="400" OnClientClose="RadWinClose" Behaviors="Close, Move,Reload,Resize"
        Style="z-index: 31000" ReloadOnShow="false" KeepInScreenBounds="true">
    </telerik:RadWindowManager>
</div>
<script>
    var pgtype = '<%=pg %>';
</script>
<asp:HiddenField ID="hid_EstimateItemID" runat="server" Value="0" />
<asp:HiddenField ID="hid_EstimateType" runat="server" Value="" />
<asp:HiddenField ID="hid_PressID" runat="server" Value="0" />
<asp:HiddenField ID="hid_PaperID" runat="server" Value="0" />
<asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
<asp:HiddenField ID="hid_OtherCostValuesFromTB" runat="server" Value="" />
<asp:HiddenField ID="hdnOtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hdnEditOtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hid_BookletSectionID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_IsOthercostsavedFromPopUp" runat="server" Value="no" />
<asp:HiddenField ID="hdnOtherCostSequenceIDs" runat="server" />

<asp:HiddenField ID="hdn_EstQtyList" runat="server" Value="" />
<asp:HiddenField ID="hdn_ItemTitle" runat="server" Value="" />
<asp:HiddenField ID="hdn_CostEditPath" runat="server" Value="" />

<script src="<%=strSitepath %>js/item/othercost_item.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript">
    var strSitepath = "<%=strSitepath %>";
    var hid_OtherCostValues_Load = document.getElementById("<%=hid_OtherCostValues_Load.ClientID %>");
    var txtOtherCostQty = document.getElementById("<%=txtOtherCostQty.ClientID %>");
    var href_ShowOtherCostID = document.getElementById("href_ShowOtherCost");

    var hid_PressID = document.getElementById("<%=hid_PressID.ClientID %>");
    var hid_PaperID = document.getElementById("<%=hid_PaperID.ClientID %>");
    var hid_GuillotineID = document.getElementById("<%=hid_GuillotineID.ClientID %>");
    var hid_EstimateItemID = document.getElementById("<%=hid_EstimateItemID.ClientID %>");
    var hid_EstimateType = document.getElementById("<%=hid_EstimateType.ClientID %>");
    var hid_BookletSectionID = document.getElementById("<%=hid_BookletSectionID.ClientID %>");

    var hdnOtherCostValues = document.getElementById("<%=hdnOtherCostValues.ClientID %>");
    var hdnEditOtherCostValues = document.getElementById("<%=hdnEditOtherCostValues.ClientID %>");
    var hid_OtherCostValuesFromTB = document.getElementById("<%=hid_OtherCostValuesFromTB.ClientID %>");
    var hdn_IsOthercostsavedFromPopUp = document.getElementById("<%=hdn_IsOthercostsavedFromPopUp.ClientID %>");
    var hdnOtherCostSequenceIDs = document.getElementById("<%=hdnOtherCostSequenceIDs.ClientID %>");
    var EsttxtQuantity1 = document.getElementById("<%=txtQuantity1.ClientID %>");
    var EsttxtQuantity2 = document.getElementById("<%=txtQuantity2.ClientID %>");
    var EsttxtQuantity3 = document.getElementById("<%=txtQuantity3.ClientID %>");
    var EsttxtQuantity4 = document.getElementById("<%=txtQuantity4.ClientID %>");
    var jobQtyCheck = 0;
    var txt_ItemTitle = document.getElementById("<%=txt_ItemTitle.ClientID %>");
    var ArrayOtherCost = new Array();

    var hdn_ItemTitle = document.getElementById("<%=hdn_ItemTitle.ClientID %>");
    var hdn_EstQtyList = document.getElementById("<%=hdn_EstQtyList.ClientID %>");
    var hdn_CostEditPath = document.getElementById("<%=hdn_EstQtyList.ClientID %>");

    hid_EstimateItemID.value = '<%=EstimateItemID %>';
    hid_EstimateType.value = '<%=EstimateType %>';

    var rowcount = '<%=rowcount %>';
    var CompanyID = "<%=CompanyID %>";
    var estimateType = "";
    estimateType = '<%=MainOrSubtype %>';
    var QtyNo = "<%=QtyNo %>";
    var pg = '<%=pg %>';
    var isfrom_eStore = '<%=isfrom_eStore %>';

    var ParentEstType = '';
    if (estimateType.toLowerCase() == 's') {
    }
    var OthMode = '<%=Type %>';

    Create_Other_Cost_Tab(estimateType); //BY VINAY

    if (estimateType == 'm') {
        document.getElementById("div_othercostMain").style.display = "block";
        document.getElementById("div_othercostTitle").style.display = "block";
        if (pg == 'job' || pg == 'invoice' || pg == 'order') {
            if (QtyNo == "1") {
                document.getElementById("div_qty1").style.display = "block";
                document.getElementById("div_qty2").style.display = "none";
                document.getElementById("div_qty3").style.display = "none";
                document.getElementById("div_qty4").style.display = "none";
                jobQtyCheck = EsttxtQuantity1.value;
            }
            else if (QtyNo == "2") {
                document.getElementById("div_qty1").style.display = "none";
                document.getElementById("div_qty2").style.display = "block";
                document.getElementById("div_qty3").style.display = "none";
                document.getElementById("div_qty4").style.display = "none";
                jobQtyCheck = EsttxtQuantity2.value;
            }
            else if (QtyNo == "3") {
                document.getElementById("div_qty1").style.display = "none";
                document.getElementById("div_qty2").style.display = "none";
                document.getElementById("div_qty3").style.display = "block";
                document.getElementById("div_qty4").style.display = "none";
                jobQtyCheck = EsttxtQuantity3.value;
            }
            else if (QtyNo == "4") {
                document.getElementById("div_qty1").style.display = "none";
                document.getElementById("div_qty2").style.display = "none";
                document.getElementById("div_qty3").style.display = "none";
                document.getElementById("div_qty4").style.display = "block";
                jobQtyCheck = EsttxtQuantity4.value;
            }
        }
        else {
            document.getElementById("div_qty1").style.display = "block";
            document.getElementById("div_qty2").style.display = "block";
            document.getElementById("div_qty3").style.display = "block";
            document.getElementById("div_qty4").style.display = "block";
            jobQtyCheck = EsttxtQuantity1.value;
        }

    }


    //function qtyValues() {       
    //    if (EsttxtQuantity2.value == "" && EsttxtQuantity3.value == "" && EsttxtQuantity4.value == "" ) {
    //        EsttxtQuantity2.value = EsttxtQuantity1.value;
    //        EsttxtQuantity3.value = EsttxtQuantity1.value;
    //        EsttxtQuantity4.value = EsttxtQuantity1.value;
    //    }
    //}
</script>
<asp:Panel ID="pnlOtherCostonEdit" runat="server" Visible="false">
    <script language="javascript" type="text/javascript">

        function LoadOtherCostOnEdit() {
            debugger;
            ArrayOtherCost.length = 0;
            OtherIndex = '';
            var EstType = '<%=EstimateType %>'.toLowerCase();
            var estitemtype = '';
            var IsOtherMainEdit = '';
            estitemtype = 'm';
            var hdnOtherCostValues = document.getElementById("<%=hdnOtherCostValues.ClientID %>");
            var editdata = hdnOtherCostValues.value;
            var str = editdata.split('µ');
            var str2 = '';
            var EstOtherCostID = '';
            var CalculationType = '';
            var OtherCostVal = '';
            var OtherCostTypeVal = '';
            var CheckHourQtyVal = '';
            var Mode = 'editonload';

            for (var i = 0; i < str.length; i++) {
                str2 = str[i].split('§');
                EstOtherCostID = str2[0];
                CalculationType = str2[1];
                OtherCostVal = str2[2];
                OtherCostTypeVal = str2[3];
                CheckHourQtyVal = str2[4];
                BindOtherCostItems(OtherCostVal, CalculationType, OtherCostTypeVal, estitemtype, Mode, CheckHourQtyVal);
            }
            Sys.Application.add_load(function () {
                opencostwindow(hdn_CostEditPath.value)
            });

        }
        LoadOtherCostOnEdit();

        function opencostwindow(Path) {
            debugger;
            var RadWindow_open = window.radopen(Path, '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_open.setSize(1225, 550);
            RadWindow_open.center();
        }

        function RadWinClose() {
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
    </script>
</asp:Panel>
