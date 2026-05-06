<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Store_Selector.ascx.cs" Inherits="ePrint.usercontrol.Item.Store_Selector" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%--<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" style="display: block; width: 200px; height: 50px; position: absolute; top: 45%; left: 45%">
    <UC:Loading ID="ucLoading" runat="server" />
</div>--%>
<%--<script type="text/javascript">
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>--%>
<asp:ScriptManagerProxy ID="SMproxy" runat="server">
    <services>
        <asp:ServiceReference Path="~/press_select.asmx" />

    </services>
</asp:ScriptManagerProxy>

<%--<div id="divBackGroundNew" style="display: none;">
</div>--%>

<div id="content" style="width: 100%">
    <div align="left" style="height: auto;">
        <%--class="borderWithoutTop"--%>
        <div id="padding">
            <div align="left" style="width: 100%">
                <div id="div_add" runat="server" style="float: left; width: 100%;">
                    <div style="float: left; width: 1000px;">

                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label42" runat="server" CssClass="normaltext">Select The Store:</asp:Label>
                            </div>
                            <div class="ddlsetting">
                                <asp:DropDownList ID="ddlCategory2" runat="server" Width="200px" CssClass="normaltext"
                                    TabIndex="7">
                                </asp:DropDownList>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>

                    </div>

                </div>
                <div style="clear: both">
                </div>

                <div style="clear: both">
                </div>

                <div style="clear: both">
                </div>

                <div class="onlyEmpty">
                </div>




                <div align="left" runat="server" id="theDiv">
                   
                    <div class="ddlsetting">
                        <div style="float: right; margin: 0px 0px 0px 10px;">
                            <%--<asp:Button ID="btnSave" Style="" runat="server"
                        Text="Add" CssClass="button" OnClientClick="javascript:return loadingimage(this.id,'div_btncanceladdressSelector')" />--%>
                            <button class="button" id="btnMISSave" type="button" value="Save">Import From MIS</button>
                        </div>
                        <div style="float: right; margin: 0px 0px 0px 10px;">
                            <%--<asp:Button ID="btnSave" Style="" runat="server"
                        Text="Add" CssClass="button" OnClientClick="javascript:return loadingimage(this.id,'div_btncanceladdressSelector')" />--%>
                            <button class="button" id="btnSave" type="button" value="Save">Import</button>
                        </div>
                        <div style="float: right; margin: 0px 0px 0px 10px;">
                            <asp:Button ID="btnCancel" Style="" runat="server"
                                Text="Cancel" CssClass="button" OnClientClick="javascript:return loadingimage(this.id,'div_btncanceladdressSelector')" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>

                <asp:HiddenField runat="server" ID="hdnPriceCatalogueID" Value="0" />
                <asp:HiddenField runat="server" ID="hdnCompanyID" Value="0" />
                <asp:HiddenField runat="server" ID="hdnURL" Value="" />



                <div style="clear: both">
                </div>
            </div>
        </div>
    </div>
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
<script type="text/javascript">


    $(document).ready(function () {


        ///*
        $("#btnSave").click(function () {

            debugger;

            var ddlCategory2 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory2").val();
            //var ddlCategory3 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory3").val();
            //var ddlCategory4 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory4").val();
            //var ddlCategory5 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory5").val();
            //var ddlCategory6 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory6").val();

            var hdnPriceCatalogueID = $("#ctl00_ContentPlaceHolder1_ctl00_hdnPriceCatalogueID").val();

            //if (ddlCategory2 == 0) {
            //    ddlCategory2 = ddlCategory3;
            //}

            //document.getElementById("div_Load").style.display = "block";
            var bar = new Promise((resolve, reject) => {
                

                ePrint.press_select.Import_otherstore_deliveryCost(hdnPriceCatalogueID, ddlCategory2);
                resolve();
                // window.onunload = window.location.reload(true);
                //window.close();
                setTimeout(function () {
                    parent.location.reload(true);
                }, 1000);
            });

            bar.then(() => {
                console.log('All done!');
                //window.location.reload(true);
            });
        });

        $("#btnMISSave").click(function () {

            debugger;

            var ddlCategory2 = $("#ctl00_ContentPlaceHolder1_ctl00_ddlCategory2").val();
            var hdnPriceCatalogueID = $("#ctl00_ContentPlaceHolder1_ctl00_hdnPriceCatalogueID").val();
            var hdnCompanyID = $("#ctl00_ContentPlaceHolder1_ctl00_hdnCompanyID").val();

            var bar = new Promise((resolve, reject) => {


                ePrint.press_select.Import_MIS_deliveryCost(hdnPriceCatalogueID, hdnCompanyID);
                resolve();
                // window.onunload = window.location.reload(true);
                //window.close();
                setTimeout(function () {
                    parent.location.reload(true);
                }, 1000);
            });

            bar.then(() => {
                console.log('All done!');
                //window.location.reload(true);
            });
        });


       
    });

    function validateClose() {   
        debugger;

        //window.close();

        var hdnPriceCatalogueID = $("#ctl00_ContentPlaceHolder1_ctl00_hdnPriceCatalogueID").val();
        var strSitepath = $("#ctl00_ContentPlaceHolder1_ctl00_hdnURL").val();
        var url = "ProductCatalogue/ProductCatalogueCategory.aspx?type=product&post=settings&postmode=edit&id="+ hdnPriceCatalogueID +"&clientID=0&from=&mode=add";

        window.parent.location.href = strSitepath + url;

        return true;
    }

        function TakeOut() {
            window.close();
    }

</script>
