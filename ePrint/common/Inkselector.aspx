<%@ page title="" language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="Inkselector.aspx.cs" Inherits="ePrint.common.Inkselector" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="InventoryAdd"
    TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js"></script>
    <asp:ScriptManagerProxy ID="SMproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js"></script>
    <div id="ds00" style="display: block;">
    </div>
    <div id="div_Load" style="display: none; position: absolute">
        <uc:loading id="ucLoading" runat="server" />
    </div>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";
        var div_Load = document.getElementById("div_Load");
        setLoadingPositionOfDivMove(div_Load);   
    </script>
    <table id="tb_Content" cellspacing="0" cellpadding="0" width="100%" align="center"
        border="0">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tableID" cellpadding="0" cellspacing="0" border="0" width="100%">
                    <%--class="borderWithoutTop"--%>
                    <tr>
                        <td style="border: solid 0px red">
                            <div align="center" style="width: 100%; padding-top: 5px">
                                <div style="width: 100%">
                                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                        <ContentTemplate>
                                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div align="left" style="padding-left: 5px" id="divbtnAddInk" runat="server">
                                <asp:Button ID="btnAddInk" runat="server" Text="Add New Ink" CssClass="button" Width="110px"
                                    OnClick="Onclick_AddNewInk" /><br />
                            </div>
                            <div>
                                <asp:PlaceHolder ID="plhink" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left; width: 200px">
                                &nbsp;</div>
                            <div style="float: left; padding-bottom: 4px">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Button" Width="65px"
                                    Style="display: none;" OnClientClick="javascript:window.close()" />
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;</div>
                            <div style="float: left; padding-bottom: 4px">
                                <div id="div_btnsave" style="display: block">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Button" Width="65px"
                                        OnClientClick="javascript:setFinalValues();loadingimg('div_btnsave','div_saveprocess');"
                                        OnClick="btnSave_onclick" />
                                    <asp:HiddenField ID="hdn_Save" Value="" runat="server" />
                                </div>
                                <div id="div_saveprocess" class="button" align="center" style="width: 49px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_InkID" runat="server" Value="0" />
    <asp:HiddenField ID="hid_InkName" runat="server" Value="0" />
    <asp:HiddenField ID="hid_InventoryCode" runat="server" Value="0" />
    <asp:HiddenField ID="hid_InkInventoryName" runat="server" Value="0" />
    <asp:HiddenField ID="hid_InkCountClicked" runat="server" Value="0" />
    <script type="text/javascript">
        var cnt = "<%=cnt %>";
        var type = "<%=type %>";

        onLoad();
        var hid_InkCountClicked = document.getElementById("<%=hid_InkCountClicked.ClientID %>");
        var hid_InkID = document.getElementById("<%=hid_InkID.ClientID %>");
        var hid_InkName = document.getElementById("<%=hid_InkName.ClientID %>");
        var hid_InventoryCode = document.getElementById("<%=hid_InventoryCode.ClientID %>");
        var hid_InkInventoryName = document.getElementById("<%=hid_InkInventoryName.ClientID %>");

        function setFinalValues() {

            var str = "";
            var inkid = '';
            var inkcoverage = '';
            var inkname = '';
            var pw = window.parent;              //*** IE, on 04.10.2011
            var Side = "<%=Side %>";

            var Section = "<%=Section %>";
            var EstimateLithoNCRItemID = "<%=EstimateLithoNCRItemID%>";
            var EstimateLithobookletItemID = "<%=EstimateLithobookletItemID%>";
            var Esttype = "<%=Esttype%>";
            var sidenumber = "<%=sidenumber%>";

            var hdn_Save = document.getElementById("<%=hdn_Save.ClientID %>");
            for (var i = 1; i <= cnt; i++) {

                var txtInkName = document.getElementById("ctl00_ContentPlaceHolder1_txtInkName_" + i);

                var lblInkID = document.getElementById("ctl00_ContentPlaceHolder1_lblInkID_" + i);
                var lblInkName = document.getElementById("ctl00_ContentPlaceHolder1_lblInkName_" + i);

                var txtbx = document.getElementById("ctl00_ContentPlaceHolder1_txtbx_" + i);

                var coveragevalue = 0;
                if (txtbx != null) {
                    coveragevalue = txtbx.value;
                }

                if (lblInkID.innerHTML != 0 && txtInkName.value != "") {
                    inkid += lblInkID.innerHTML + '±';
                    inkcoverage += coveragevalue + '±';  // '»'
                    inkname += txtInkName.value + '±';
                }
            }

            hdn_Save.value = "Parts" + Section + "~" + inkid + "~" + inkcoverage + "~" + Side + "~" + sidenumber + "~" + inkname;


            var txtInkName1 = document.getElementById("ctl00_ContentPlaceHolder1_txtInkName_1");
            var lblInkID1 = document.getElementById("ctl00_ContentPlaceHolder1_lblInkID_1");

            if (sidenumber == "side1") {
                pw.hid_SessionPressChangeSingle.value = "yes";
            }
            if (sidenumber == "side2") {

                pw.hid_SessionPressChangeDouble.value = "yes";
            }

            if (txtInkName.value == "" && lblInkID1.innerHTML == "") {
                alert("Please Enter Ink Quantity");
                return false;
            }
        }
        function onLoad() {
            for (var i = 1; i <= cnt; i++) {
                document.getElementById("ctl00_ContentPlaceHolder1_lblInkID_" + i).style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_lblInkName_" + i).style.display = "none";
            }
        }
        
        
    </script>
    <asp:Panel ID="pnlClose" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
                return oWindow;
            }


            function CloseOnReload() {
                GetRadWindow().Close();
            }
            CloseOnReload();
        </script>
    </asp:Panel>
    <asp:Panel ID="Add_NewInkID" runat="server" Visible="false">
        <div align="left" id="div_InventoryAdd" style="width: 96%; position: absolute; display: none;">
            <uc:inventoryadd id="UCInventory_Add" runat="server" />
        </div>
        <script type="text/javascript" language="javascript">
            document.getElementById("tb_Content").style.display = "none";
            function ShowInvAddDiv() {
                hdn_InkType.value = '<%=InkType %>';
                var cattype = 'inks';


                document.getElementById("div_InventoryAdd").style.display = "block";



                for (var i = 0; i < ddlInvCategoryID.length; i++) {
                    if (cattype == 'inks') {
                        if (ddlInvCategoryID.options[i].text.toLowerCase() == "inks") {
                            ddlInvCategoryID.selectedIndex = i;
                        }
                    }
                }
                ddlInvCategoryID.disabled = true;
                ShowCategoryWise(ddlInvCategoryID);
                hdn_InvCatID.value = ddlInvCategoryID.value;
                hdn_InkType.value = '<%=InkType %>';
            }
            ShowInvAddDiv();            
            
        </script>
    </asp:Panel>
    <script type="text/javascript">
        var Pgtype = "<%=Pgtype  %>";
        for (var i = 1; i < cnt; i++) {

            var hid_InkID = document.getElementById("<%=hid_InkID.ClientID %>");
            var hid_InkName = document.getElementById("<%=hid_InkName.ClientID %>");
        }
        
        
        
    </script>
    <script>
        //********** web service to autocomplete clientname *********//
        function GetInksName(InventoryID, InventoryCode, InventoryName, InkInventoryName) {

            hid_InkID.value = InventoryID;
            hid_InkName.value = InventoryCode;
            hid_InventoryCode.value = InventoryName;
            hid_InkInventoryName.value = InkInventoryName;
            var txtInkName = document.getElementById("ctl00_ContentPlaceHolder1_txtInkName_" + hid_InkCountClicked.value);
            var lblInkID = document.getElementById("ctl00_ContentPlaceHolder1_lblInkID_" + hid_InkCountClicked.value);
            lblInkID.innerHTML = InventoryID;
            txtInkName.value = InkInventoryName;
        }
        //********** End Of web service to autocomplete clientname *********//    


        //to set the count value when the text box clicked to select the ink
        function TosetCount(count) {
            hid_InkCountClicked.value = count;
        }



        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
