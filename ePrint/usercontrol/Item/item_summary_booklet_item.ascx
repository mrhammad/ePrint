<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="item_summary_booklet_item.ascx.cs" Inherits="ePrint.usercontrol.Item.item_summary_booklet_item" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table id="tblBookletItem" width="97%" cellpadding="0" cellspacing="0" border="0">
  
    <tr id="trQuantity">
        <td>
            <asp:PlaceHolder ID="plhDigiBookletItem" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>
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