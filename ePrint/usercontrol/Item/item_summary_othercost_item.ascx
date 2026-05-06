<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_othercost_item.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_othercost_item" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table id="tblOtherCostItem" width="97%" cellpadding="0" cellspacing="0" border="0">
    <%--<tr style="border: 0px solid red" align="right">
        <td valign="top" align="right">
            <asp:PlaceHolder ID="plhSummaryBtns" runat="server"></asp:PlaceHolder>
        </td>
    </tr>--%>
    <tr id="trQuantity">
        <td>
            <asp:PlaceHolder ID="plhOtherCostItem" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>
<%--<div id="Div_RadSplit" runat="server">
    <telerik:RadButton ID="SplitButton" runat="server" AutoPostBack="false" EnableSplitButton="true"
        Text="Add Sub Item" Skin="Vista" OnClientClicked="OnClientClicked" Visible="false">
    </telerik:RadButton>
    <telerik:RadContextMenu ID="RadContextMenu1" runat="server">
        <Items>
            <telerik:RadMenuItem Text="Sheed Fed Digital">
                <Items>
                    <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="Sheed Fed Offset">
                <Items>
                    <telerik:RadMenuItem Text="Single Item" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Pads" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                <Items>
                    <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="" Style="cursor: pointer;">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenuItem>
            <telerik:RadMenuItem Text="Price Catalogue" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Outwork " Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Other Cost" Style="cursor: pointer;" />
        </Items>
    </telerik:RadContextMenu>
</div>
<div id="Div_AdvancedOptions" runat="server">
    <telerik:RadButton ID="Radbtn_Options" runat="server" AutoPostBack="false" EnableSplitButton="true"
        Text="Action" Skin="Vista" OnClientClicked="OnClientClicked_Option" Visible="false">
    </telerik:RadButton>
    <telerik:RadContextMenu ID="RCM_Options" runat="server">
        <Items>
            <telerik:RadMenuItem Text="Re-Run Item" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Copy Item" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Delete Item " Visible="true" Style="cursor: pointer;" />
            <telerik:RadMenuItem Text="Edit Job Card" Style="cursor: pointer;" Visible="false" />
        </Items>
    </telerik:RadContextMenu>
</div>--%>
<asp:HiddenField runat="server" ID="hdnOtherCostDetails" />
<asp:HiddenField runat="server" ID="hdnestothercostid" />
<asp:HiddenField runat="server" ID="hdnParentItemID" />
<asp:HiddenField runat="server" ID="hdnEstimateItemID" />
<asp:HiddenField runat="server" ID="hdnModule" />
<asp:HiddenField runat="server" ID="hdnParentItemType" />
<asp:HiddenField ID="hid_PressID" runat="server" Value="0" />
<asp:HiddenField ID="hid_PaperID" runat="server" Value="0" />
<asp:HiddenField ID="hid_GuillotineID" runat="server" Value="0" />
<asp:HiddenField ID="hdnOtherCostValues" runat="server" Value="" />
<asp:HiddenField ID="hdn_IsOthercostsavedFromPopUp" runat="server" Value="yes" />
<asp:HiddenField ID="hdnEditOtherCostValues" runat="server" Value="yes" />
<asp:LinkButton runat="server" ID="lnkOtherCostFromSummary" OnClick="lnkOtherCostFromSummary_Click"></asp:LinkButton>
<telerik:RadScriptBlock ID="test" runat="server">
    <script language="javascript" type="text/javascript">


        function EditOthercost(URL, refID) {



            var othercosts = document.getElementById(refID).value;
            var strothercosts = othercosts.split('µ');
            var strstrothercosts2 = strothercosts[1].split('»');
            var CostCatID = strstrothercosts2[0];
            var CostID = strstrothercosts2[1];
            var CostName = strstrothercosts2[2];
            var CostDesc = strstrothercosts2[3];
            var CostTimeBasedID = strstrothercosts2[4];
            var CostCalType = strstrothercosts2[5];

            var GuillotineID = 0;
            var PaperID = 0;
            var PressID = 0;

            GuillotineID = document.getElementById(refID.replace('hdnOtherCostDetails', 'hid_GuillotineID')).value;
            PaperID = document.getElementById(refID.replace('hdnOtherCostDetails', 'hid_PaperID')).value;
            PressID = document.getElementById(refID.replace('hdnOtherCostDetails', 'hid_PressID')).value;

            var estothercostid = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnestothercostid')).value;



            var parentestitemid = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnParentItemID')).value;
            var parentesttype = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnParentItemType')).value;
            var Module = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnModule')).value;
            var EstimateItemID = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnEstimateItemID')).value;
            var totalItemCount = LoadOtherCostOnEdit(refID);
            var otherinx = 0;
            for (var g = 0; g < totalItemCount; g++) {

                if (ArrayOtherCost[g].EstOtherCostID == estothercostid) {
                    otherinx = g;
                }
            }
            //these hidden fields are on main user control
            hid_EstimateItemID.value = parentestitemid;
            hid_EstimateType.value = parentesttype;
            hid_BookletSectionID.value = 1;
            var pgtype = Module;
            var CurrerntControlID = 'openfromsummary' + '~' + refID.replace('hdnOtherCostDetails', 'lnkOtherCostFromSummary') + '~' + EstimateItemID;



            OpenPopup(CostID, CostTimeBasedID, CostCalType, 's', CurrerntControlID, otherinx.toString(), GuillotineID, PaperID, PressID, estothercostid);

        }

        function LoadOtherCostOnEdit(refID) {
            ArrayOtherCost.length = 0;
            OtherIndex = '';
            var estitemtype = '';
            var IsOtherMainEdit = '';
            estitemtype = 's';

            var hdnOtherCostValues = document.getElementById(refID.replace('hdnOtherCostDetails', 'hdnOtherCostValues'));
            var editdata = hdnOtherCostValues.value;
            var str = editdata.split('µ');
            var str2 = '';
            var EstOtherCostID = '';
            var CalculationType = '';
            var OtherCostVal = '';
            var OtherCostTypeVal = '';
            var CheckHourQtyVal = '';
            var Mode = 'editonload';
            var totalItemCount = str.length;
            for (var i = 0; i < str.length; i++) {
                str2 = str[i].split('§');
                EstOtherCostID = str2[0];
                CalculationType = str2[1];
                OtherCostVal = str2[2];
                OtherCostTypeVal = str2[3];
                CheckHourQtyVal = str2[4];
                BindOtherCostItems(OtherCostVal, CalculationType, OtherCostTypeVal, estitemtype, Mode, CheckHourQtyVal);
            }
            return totalItemCount;
        }



    </script>
</telerik:RadScriptBlock>

<script type="text/javascript" language="javascript">

    var strSecuresitepath = '<%=strSecuresitepath %>';
    var ServerName = '<%=serverName %>';
    var AccountID = '<%=AccountID %>';
    function ShowAttachments_Order() {
        debugger;
        var Pgtype = "<%=PageType %>";
        var pagetype = 'general';
       <%--var EstimateID = "<%=EstimateID %>";--%>
        var EstimateID;
        if (Pgtype == 'job') {
            EstimateID = "<%=jobID %>";
        }
        else if (Pgtype == 'invoice') {
            EstimateID = "<%=InvoiceID %>";
        }
        else {
            EstimateID = "<%=EstimateID %>";
        }
        var PDFToURLPath = '<%=PDFToURLPath %>';
        //var Rad_Attachment = window.radopen("<%=strSitepath %>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&ordID=" + EstimateID + "&estid=" + EstimateID + "&pg=" + Pgtype + "");
        var Rad_Attachment = window.radopen(strSitepath + "common/common_popup.aspx?pagetype=general&type=attachments&estid=" + EstimateID + "&pg=" + Pgtype + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');

        if (window.window.screen.width > 1100) {
            if (window.window.screen.height > 450) {
                Rad_Attachment.setSize(1100, 555);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
                else {
                    Rad_Attachment.Center();
                }
            }
        }
        else {
            var screenwidth = window.window.screen.width;
            var screenheight = window.window.screen.height;
            if (window.window.screen.width > 1100 && screenheight > 450) {
                Rad_Attachment.setSize(screenwidth - 200, 550);
                Rad_Attachment.center();
            }
            else if (window.window.screen.width > 800) {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                var c = Rad_Attachment._getCentralBounds();
                if (navigator.appName != "Microsoft Internet Explorer") {
                    var x = c.x;
                    var y = c.y;
                    if (y < 50) {
                        var window_size1 = $(window).height();
                        var window_size2 = $(window).width();
                        var check = Number(window_size1) - 555;
                        if (check < 0) {
                            check = window_size1 / 2;
                        }
                        if (x < 0) { x = window_size2 / 4; }
                        check = Number(check) / 2;
                        Rad_Attachment.moveTo(x, check);
                    }
                }
            }
            else {
                Rad_Attachment.setSize(screenwidth - 200, screenheight - 200);
                Rad_Attachment.center();
            }
        }
    }

    function OpenAttach(FileName, ServerName, CompanyID, DocPath) {
        window.open(DocPath + ServerName + "/" + CompanyID + "/attachments/" + FileName, '_blank');
    }
    //Ticket Id : 13476
    function Pdf_ImagPopup(Images, AccountID, strSitepath, Mode) {
        var window = GetImgRadWindow();
        $(".div_imagePreview").html('');
        var image = Images.toString().split(',');
        var display = '', selected = 'selected';
        var childImages = "";
        for (var i = 0; i < image.length - 1; i++) {
            if (i > 0) {
                display = "none";
                selected = "";
            }
            src = strSitepath + ServerName + "/store/" + AccountID + "/pdf/" + image[i];
            childImages += "<li class='" + selected + "' style='display:" + display + ";padding-top:15px;text-align:center'><img class='img' style='width:50%;background:white;' onload='imgLoaded(this);' src='" + src + "'/><input type='hidden' value='" + image[i] + "'/></li>";

        }
        $(".rwWindowContent").css("background", '#323639');
        $(".div_imagePreview").append(childImages);
        window.show();

    }
    function GetImgRadWindow() {
        var oWindow = null;
        oWindow = $find("<%=ImagePopWindow.ClientID %>");
        return oWindow;
    }
</script>
<%--Ticket Id : 13476 --%>
<telerik:RadWindow RenderMode="Lightweight" ID="ImagePopWindow" Title="Image Preview"
    Height="420px" Width="835px" ResizeMode="NoResize" BackColor="Gray" runat="server"
    Modal="True" ReloadOnShow="true" CssClass="ImagePopWindow">
    <ContentTemplate>
        <div class="divTitle">
            <img id="Imgpreview" runat="server" style="float: right; cursor: pointer" title="Download" />
        </div>
        <ul runat="server" class="slider div_imagePreview" id="div_imagePreview" style="overflow: hidden;
            background: #323639;">
        </ul>
        <div style="margin-top: 15px;">
            <input type="button" id="btn_previous" value="Previous" style="float: left" onclick="btnPrevoius_clicked();" />
            <%-- <span class="pageNo">1</span>  <span class="totalpage" id="totalPages"></span>--%>
            <input type="button" id="btn_next" value="Next" style="float: right" onclick="btnNext_clciked();" />
        </div>
    </ContentTemplate>
</telerik:RadWindow>
