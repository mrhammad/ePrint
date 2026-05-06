<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" CodeBehind="order_Othercost.aspx.cs" Inherits="ePrint.orders.order_Othercost" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="OtherCosts" Src="~/usercontrol/Item/item_usercostcentres_new.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="ds00" style="display: block;">
    </div>
    <div id="div_Load" style="display: block; width: 200px; height: 35px; position: absolute;
        top: 45%; left: 45%">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script>
        var IsOtherCostSequence = '<%=IsOtherCostSequence %>';
        document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";
    </script>
    <script type="text/javascript">
        setLoadingPositionOfDivMove(div_Load);
    </script>
    <div id="div_Other_Cost" align="left" style="width: 100%;">
        <div align="left" style="border: 0px solid red;">
            <UC:OtherCosts ID="UCOtherCosts" runat="server" />
        </div>
        <div align="left">
            <div align="left" id="Div_ItemDescn" runat="server" visible="false">
                <div class="bglabelnewLarge" style="float: left; width: 15%">
                    <asp:Label ID="Label7" runat="server" Text="Update Item Descriptions" CssClass="normaltext"></asp:Label>
                    <a href="javascript:void(0);" class="tooltip" title="Untick this box if you want the item description fields to be overwritten during the rerun process.">
                        <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                            class="tooltip" /></a>
                </div>
                <div class="box" style="float: left;">
                    <div id="div2" align="left">
                        <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="true" />
                    </div>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div align="left" id="Div_Productcatalogue" runat="server" visible="false">
                <div class="bglabelnewLarge" style="float: left; width: 15%;">
                    <asp:Label ID="Label17" runat="server" Text="Product Catalogue" CssClass="normaltext"></asp:Label>
                    <a href="javascript:void(0);" class="tooltip" title="Quantity may be Updated/added">
                        <img alt="" id="Img1" src="~/images/Help-icon.png" runat="server" style="cursor: pointer;
                            width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
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
            <div class="only10px">
            </div>
            <div id="Div_Options" runat="server" style="float: right; width: 35%;">
                <div style="float: left;">
                    <div id="div_btnprevious" style="display: block">
                        <asp:Button ID="btncostcentrePrevious" CssClass="button" runat="server" Text="Save"
                            OnClick="btnprevious_onclick" OnClientClick="javascript:loadingimage(this.id,'div_prevprocess');" />
                    </div>
                    <div id="div_prevprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div id="div_OtherCost_btn_Next" style="float: left; display: none;">
                    <div id="div_btnskip" style="display: block">
                        <asp:Button ID="btncostSkip" CssClass="button" OnClick="btncostSkip_OnClick" OnClientClick="var a=ValidateMandatoryOtherCost();if(a)loadingimage(this.id,'div_skipprocess');return a;"
                            runat="server" Text="Skip" Visible="false" />
                    </div>
                    <div id="div_skipprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left;">
                    <div id="div_btnfinish" style="display: block">
                        <asp:Button ID="btncostcentre" CssClass="button" OnClientClick="javascript:var a=OtherCostNext();if(a)loadingimage(this.id,'div_finishprocess');return a;"
                            OnClick="btnCostFinish_OnClick" runat="server" Text="Finish" />
                    </div>
                    <div id="div_finishprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty" style="height: 20px;">
        </div>
        <asp:HiddenField ID="hid_booklet_save" runat="server" Value="" />
        <asp:HiddenField ID="hdnEditOtherCostValues" runat="server" Value="" />
        <asp:HiddenField ID="hdn_EditOtherCostSelected" runat="server" Value="" />
        <asp:HiddenField ID="hdn_EditOtherCostNewItemSelected" runat="server" Value="" />
        <asp:HiddenField ID="hid_OtherCost_Question" runat="server" Value="" />
        <asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
        <asp:HiddenField ID="hdnpaperID" runat="server" Value="" />
        <asp:HiddenField ID="hdn_IsOthChangedInAdd" runat="server" Value="" />
        <asp:HiddenField ID="hdn_EstQtyList" runat="server" Value="" />
        <asp:HiddenField ID="hdn_ItemTitle" runat="server" Value="" />
        <asp:LinkButton ID="lnkSaveSubOthercost" runat="server" OnClick="btnCostFinish_OnClick"></asp:LinkButton>
    </div>
    <script language="javascript" type="text/javascript">

        var divOtherCost = "div_Other_Cost";
        divOtherCostbtnNext = "div_OtherCost_btn_Next";
        document.getElementById(divOtherCost).style.display = "block";
        document.getElementById(divOtherCostbtnNext).style.display = "block";

        var btncostcentrePrevious = document.getElementById("<%=btncostcentrePrevious.ClientID %>");
        btncostcentrePrevious.value = '<%=objLanguage.GetLanguageConversion("Previous")%>';

        var hdnEditOtherCostValues = document.getElementById("<%=hdnEditOtherCostValues.ClientID %>");
        var hdn_EditOtherCostSelected = document.getElementById("<%=hdn_EditOtherCostSelected.ClientID %>");
        var hdn_EditOtherCostNewItemSelected = document.getElementById("<%=hdn_EditOtherCostNewItemSelected.ClientID%>");
        var hid_OtherCost_Question = document.getElementById("<%=hid_OtherCost_Question.ClientID %>");
        var hdn_IsOthChangedInAdd = document.getElementById("<%=hdn_IsOthChangedInAdd.ClientID %>");
        var hdn_EstQtyList = document.getElementById("<%=hdn_EstQtyList.ClientID %>");
        ///OTHER COST        
        var RequestType = '<%=Request.QueryString["type"]%>';
        var IsWareDirect = false;
        var IsPrintBrokerDirect = false;
        var IsOtherCost = false;
        var hdn_ItemTitle = document.getElementById("<%=hdn_ItemTitle.ClientID %>");

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
</asp:Content>



