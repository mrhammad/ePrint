<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="warehouse.aspx.cs" Inherits="ePrint.warehouse.warehouse" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="InventoryStoreCustomerView" Src="~/usercontrol/warehouse/inventory_store_customer_view.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="ds00" style="display: block;">
    </div>
   
    <%--while loading page should mask done by smitha--%>
    <script>

        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "none";
    </script>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span id="lblheader" class="navigatorpanel" style="padding-left: 10px">
                                <%=strHeader %>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="content">
        <div align="left" style="width: 100%">
            <div>
                <div>
                    <div id="padding">
                        <UC:InventoryStoreCustomerView ID="InventoryStoreCustomerView2" InvenotoryInk="warehouse"
                            runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="div_raisePo" align="left" style="float: left; width: 50%; display: none;
        position: absolute; left: 35%; top: 35%; background-color: FloralWhite;">
        <div id="divMainContent">
            <div class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" nowrap="nowrap">
                                    <span class="navigatorpanel" runat="server" id="Span1">Raise Purchase Order</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Div1">
                <div class="borderWithoutTop">
                    <div id="Div2">
                        <div align="left" style="width: 100%">
                            <asp:CheckBox ID="chkAll" runat="server" Text="Check All" />
                        </div>
                        <div align="left" class="border1px" style="width: 100%; height: 150px">
                            <div align="left" class="bgcustomize" style="width: 100%; height: 15px">
                                <span class="navigatorpanel" style="padding: 2px">Supplier Name</span>
                            </div>
                            <div align="left" style="width: 100%;">
                                <asp:CheckBox ID="chkSupp1" runat="server" Text="Robert Horne Paper Supplies" />
                            </div>
                        </div>
                        <div style="clear: both">
                            &nbsp;
                        </div>
                        <div align="left" style="width: 100%;">
                            <div style="float: left; width: 55%">
                                <span class="HeaderText">1 Purchase Order(s) are available to be raised</span></div>
                            <div style="float: left;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Width="65px"
                                    OnClientClick="javascript:hideDiv();return false;" />
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div style="float: left;">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Width="65px"
                                    OnClientClick="javascript:hideDiv();return false;" />
                            </div>
                            <div style="clear: both">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnTabType" runat="server" Value="inventory" />
    <script type="text/javascript" language="javascript">
        checktype();
        function checktype() {
            var type1 = "<%=type %>"
            if (type1 == 'store') {
                document.getElementById("lblheader").innerHTML = "Warehouse: Store Supply";
                changeCssWare('ware_2');
            }
            else if (type1 == 'item') {
                document.getElementById("lblheader").innerHTML = "Warehouse: Customer Item";
                changeCssWare('ware_3');
            }
            else {
                document.getElementById("lblheader").innerHTML = ('<%=objLangClass.GetLanguageConversion("Warehouse_Inventory")%>');
                    changeCssWare('ware_1');
                }
        }
        function cleartxt() {

            document.getElementById("ContentPlaceHolder1_txtsearch").value = " ";
        }

        function changeCssWare(iss) {

            document.getElementById(iss).style.color = "orange";
            for (var i = 1; i <= 3; i++) {
                var dd = "ware_" + i;
                if (dd != iss) {
                    if (document.getElementById("ware_" + i) != null) {

                        document.getElementById("ware_" + i).style.color = "black";
                        var ff = "div_" + i;
                        ff = ff + i;
                    }
                }
                else {
                    var ff = "div_" + i;
                    ff = ff + i;
                }
            }
            if (document.getElementById(iss).id == "ware_1") {

                document.getElementById("<%=hdnTabType.ClientID %>").value = 'inventory';
                document.getElementById("divinventory").style.display = "block";
                document.getElementById("divcustomer").style.display = "none";
                document.getElementById("divstore").style.display = "none";

            }
            else if (document.getElementById(iss).id == "ware_2") {

                document.getElementById("<%=hdnTabType.ClientID %>").value = 'storesupply';
                document.getElementById("divinventory").style.display = "none";
                document.getElementById("divcustomer").style.display = "none";
                document.getElementById("divstore").style.display = "block";

            }
            else if (document.getElementById(iss).id == "ware_3") {

                document.getElementById("<%=hdnTabType.ClientID %>").value = 'customeritem';
                    document.getElementById("divinventory").style.display = "none";
                    document.getElementById("divcustomer").style.display = "block";
                    document.getElementById("divstore").style.display = "none";

                }

        return false;
    }
    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }
    function openwindow1() {
        window.open("inventory_add.aspx?type=add", "", "width=850,height=600,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }
    function ShowRaisePO() {
        if (document.getElementById("div_raisePo").style.display == "none") {
            document.getElementById("div_raisePo").style.display = "block";
        }
        else {
            document.getElementById("div_raisePo").style.display = "none";
        }
    }
    function hideDiv() {
        document.getElementById("div_raisePo").style.display = "none";
    }

    document.getElementById("ds00").style.display = "none";

    </script>
</asp:Content>

