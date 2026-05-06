<%@ page language="C#" autoeventwireup="true"  CodeBehind="Common_ReplenishItemAllocation.aspx.cs" Inherits="ePrint.common.Common_ReplenishItemAllocation" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../../js/item/pricecatalogfeatures.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../js/item/AutoFill.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../common/swazz_calendar.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/item/general.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/Jquery-1.11.1.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/Jquery-ui-1.11.0.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../../js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../js/jquery-ui-1.8.21.custom.min.js"></script>
<link href="../css/jquery-ui-ePrint.css" rel="stylesheet" type="text/css" />
<link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ScriptManagerProxy ID="SMproxy" runat="server">
            <Services>
                <asp:ServiceReference Path="~/AutoFill.asmx" />
                <asp:ServiceReference Path="~/item_summary.asmx" />
            </Services>
        </asp:ScriptManagerProxy>
        <div>
            <div id="dialog-confirm" style="display: none;">
                <p>
                    <span style="float: left; margin: 0 7px 20px 0;">You have a negative stock allocation in a different location, Do you still want to add stock to this location?.</span>
                </p>
            </div>
            <asp:LinkButton ID="lnkbtn_Replenish_SaveandStay" OnClick="lnkbtn_Replenish_SaveandStay_Click" runat="server"></asp:LinkButton>
            <asp:LinkButton ID="lnkbtn_Replenish_Save" OnClick="lnkbtn_Replenish_Save_Click" runat="server"></asp:LinkButton>
            <div id="divBackGroundNew" style="left: 0px; background-color: #505050; width: 100%; height: 100%; top: 0px; opacity: 0.5; z-index: 20; position: fixed; display: none;">
            </div>
            <div id="div_AllocationProductCatalogueItemStockHistory">
                <div align="left" id="div_selfpnl_Addstock_BackOrder_Allocation" runat="server" style="width: 100%; float: left;">
                    <div style="width: 100%; padding-top: 5px; padding-top: 5px">
                        <div style="float: right; width: 100%;" align="left">
                            <div id="div_Addstock_BackOrder_Allocation" runat="server" style="float: left; width: 100%; padding-top: 5px;" align="left">
                                <div align="left" style="width: 99%; margin-left: 4px;">
                                    <asp:PlaceHolder ID="plhstock" runat="server"></asp:PlaceHolder>
                                </div>
                                <asp:HiddenField ID="hdnfld_BackOrder_Allocation" runat="server" />
                                <div align="right" style="width: 100%; margin-left: -10px;">
                                    <asp:HiddenField ID="hdnloc_BackOrder_Allocation" runat="server" />
                                </div>
                            </div>

                            <div id="div_AdditionalAdjustments_BackOrder_Allocation" style="float: left; padding-top: 5px; width: 100%; display: none">
                                <div class="borderWithoutTop" style="width: 100%; float: left; margin-top: 5px">
                                    <asp:PlaceHolder ID="plhAdditionalAdjustments_BackOrder_Allocation" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>

                            <div id="div_Addotherproducts_BackOrder_Allocation" align="left" style="width: 100%; float: left; margin-left: 5px; display: none;">
                                <div id="div3" style="float: left; width: 70%; padding-top: 5px" align="left">
                                    <div class="borderWithoutTop">
                                        <asp:PlaceHolder ID="plhdrawotherproducts" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div align="right" style="width: 100%; margin-left: -10px">
                                        <asp:LinkButton ID="lnkbtnadd" runat="server" Text="Add More" OnClientClick="javascript:return addOtherproductrow('tblother');"><%=objLanguage.GetLanguageConversion("Add_More")%></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div id="div_Addothermultiple_BackOrder_Allocation" align="left" style="width: 100%; float: left; margin-left: 5px; display: none;">
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
                    </div>
                </div>
                <div style="height: 10px;" class="onlyEmpty">
                </div>
            </div>
            <div id="div_Radlocation_Replenish" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
                align="center">
                <telerik:RadWindowManager EnableShadow="false" ID="rwm_CreateNewLocation_Replenish_Allocation"
                    DestroyOnClose="true" Opacity="100" runat="server" Width="620" Height="350" Modal="false"
                    Behaviors="Close,Move,Reload,Resize,Move" OnClientClose="ClosePopup_location">
                    <Windows>
                        <telerik:RadWindow ID="RadWindow1" runat="server">
                        </telerik:RadWindow>
                    </Windows>
                </telerik:RadWindowManager>
            </div>
        </div>
        <asp:HiddenField ID="hdnselfrowcount" runat="server" Value="0" />
        <asp:HiddenField ID="hdnDefaultStockLocation" runat="server" Value="" />
        <asp:HiddenField ID="hdnDefaultLocationValue" runat="server" Value="0" />
        <asp:HiddenField ID="hdnstockselfdetails" runat="server" Value="0" />
        <asp:HiddenField ID="hdn_accordion_index" runat="server" Value="0" />
        <asp:HiddenField ID="hdnDateFormat" runat="server" Value="" />
        <asp:HiddenField ID="hdnTodate" runat="server" Value="" />


        <script language="javascript" type="text/javascript">
            var accordionindex = 0;
            var tblid_ProductCatalogueID = '';
            var hdnaccordionIndex = document.getElementById("<%=hdn_accordion_index.ClientID %>");
            var Job_Item_Status_Updated_Successfully = '<%=objLanguage.GetLanguageConversion("Job_Item_Status_Updated_Successfully")%>';
            var hdnstockselfdetails = document.getElementById("<%=hdnstockselfdetails.ClientID %>");
            var CustomerDiv = false;
            var Pgtype = 'job';
            var CompanyID = '<%=CompanyID%>';
            var UserID = '<%=UserID%>';
            var ReplenishStatusID = '<%=ReplenishStatusID%>';
            var indexvalue = 0;
            var type = '';
            var IsFrom = '<%=IsFrom%>';
            var SaveType = '<%=SaveType%>';
            var roundoff = '<%=roundoff%>';

            var strImagepath = '<%=strImagepath%>';
            var strSitepath = '<%=strSitepath%>';
            var Total_Qty_should_always_be_equal_to_the_Original_Qty = '<%=objLanguage.GetLanguageConversion("Total_Qty_should_always_be_equal_to_the_Original_Qty")%>';
            var ReplenishStatusTitle = '<%=ReplenishStatusTitle%>';

            $(function () {
                $("#accordion").accordion({
                    collapsible: true,
                    autoHeight: false,
                    navigation: true,
                });

                accordionindex = Number($(hdnaccordionIndex).val());
                if (accordionindex == 0) {
                    if (typeof document.getElementById('tblSelfStock_Replenish' + tblid_ProductCatalogueID + '_0') != 'undefined' &&
                        document.getElementById('tblSelfStock_Replenish' + tblid_ProductCatalogueID + '_0') != undefined &&
                        document.getElementById('tblSelfStock_Replenish' + tblid_ProductCatalogueID + '_0') != null) {
                        document.getElementById('tblSelfStock_Replenish' + tblid_ProductCatalogueID + '_0').style.display = 'block';
                    }
                }
                else {
                    $("#accordion").accordion('activate', accordionindex);
                }

            });

            function addstocklocation(index, DrawType) {

                RadLocation = window.radopen(strSitepath + "common/common_addstocklocation.aspx", '0', '0');
                document.getElementById("divBackGroundNew").style.display = "block";
                SetRadWindow('div_Radlocation_Replenish', 'divBackGroundNew');
                RadLocation.setSize(620, 350);
                RadLocation.center();
                indexvalue = index;
                type = DrawType;

            }
            //CalculateDivHieght();
            //function CalculateDivHieght() {                                                                             
            //    var ht2 = document.getElementById('div_selfpnl_Addstock_BackOrder_Allocation').clientHeight / 3.8;                                    
            //    document.getElementById('fieldset').style.height = ht2 + 'px';
            //}
            function AllocationPopUp1(id) {
                debugger
                var path = '<%=strSitepath%>'
                //var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1330', '520');
                var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1350', '490');
                //SetRadWindow_Ver2('divrad', 'divBackGroundNew');
                //SetRadWindow('divrad', 'divBackGroundNew', '300');
                //Rad1Customer.setSize(1200, 480);
                //Rad1Customer.setSize(1260, 450);//Ticket 61470
                Rad1Customer.setSize(1260, 400);//Ticket 61470
                Rad1Customer.center();
                Rad1Customer.id = "Radwindowstock";
                return false;
            }
            function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
                var Div_Customer = document.getElementById(divMaskID);
                var divBackGroundNew = document.getElementById(divBackgroundID);

                if (document.getElementById(divMaskID).style.display == "none") {

                    if (navigator.appName != "Microsoft Internet Explorer") {
                        setLoadingPositionOfDivCenter_Ver2(Div_Customer);
                    }
                    showDivPopupCenter_Ver2(divMaskID);
                }
                else {
                    showDivPopupCenter_Ver2(divMaskID);
                }
            }


        </script>
    </form>
</body>
</html>
