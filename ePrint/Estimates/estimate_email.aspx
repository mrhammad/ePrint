<%@ page language="C#" autoeventwireup="true" CodeBehind="estimate_email.aspx.cs" Inherits="ePrint.Estimates.estimate_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/email_template.ascx" TagName="Email" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/email_printbroker.ascx" TagName="EmailPrintBroker"
    TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/email_printbroker.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        //ShowOnEmailType();      

    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/press_select.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="Pagediv" style="padding-left: 15px; padding-top: 0px;">
        <div id="div_btnSendEmail" runat="server" style="display: none; padding-top: 0px;">
            <asp:Button ID="Btncancel1" runat="server" CssClass="button" Width="65px" Text="Cancel"
                OnClick="btncancel_Click" CausesValidation="False"></asp:Button>
            <asp:Button runat="server" ID="btnSendAllEmail" Text="Send Selected" Width="100px"
                CssClass="button" OnClick="btnSendAllEmail_OnClick" OnClientClick="javascript:return checkvalidaetion11();" />
        </div>
        <div style="height: 15px">
            &nbsp;</div>
        <div id="phdiv" style="overflow-y: scroll; height: 740px;">
            <asp:PlaceHolder ID="plhEmail" runat="server"></asp:PlaceHolder>
        </div>
        <div style="height: 15px">
            &nbsp;</div>
        <div id="div_btnSendEmail1" runat="server" style="display: none;">
            <asp:Button ID="BtnCancel2" runat="server" CssClass="button" Width="65px" Text="Cancel"
                OnClick="btncancel_Click" CausesValidation="False"></asp:Button>
            <asp:Button runat="server" ID="btnSendAllEmail1" Text="Send Selected" Width="100px"
                CssClass="button" OnClick="btnSendAllEmail_OnClick" OnClientClick="javascript:return checkvalidaetion11();" />
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    //Fun for Attach on Send Mail.
    function Checked_SuplierAttach() {
        var formattach = document.getElementById("form1");
        //now findout total usercontrols
        var allDivAttachArra = document.getElementsByTagName("div");
        var ucCounter = 1;
        for (a = 0; a < allDivAttachArra.length; a++) {
            var divObj = allDivAttachArra[a];
            if (divObj.id.indexOf('_Div_Attach') != -1) {
                var hdnEmailAttachment_ActualName = document.getElementById("uc" + ucCounter + "_hdnEmailAttachment_ActualName");
                var hdnEmailAttachment_OriginalName = document.getElementById("uc" + ucCounter + "_hdnEmailAttachment_OriginalName");
                var inputArray = divObj.getElementsByTagName("input");
                for (b = 0; b < inputArray.length; b++) {

                    var inputObj = inputArray[b];

                    if (inputObj.id.indexOf('Chk_Attach') != -1 && inputObj.type == 'checkbox') {
                        if (inputObj.checked) {
                            hdnEmailAttachment_ActualName.value += inputObj.value + "~";
                            hdnEmailAttachment_OriginalName.value += inputObj.title + "~";
                        }
                    }
                }
                ucCounter++;
            }
        }
    }


    function fnSelect(objId) {
        fnDeSelect();
        if (document.selection) {
            var range = document.body.createTextRange();
            range.moveToElementText(document.getElementById(objId));
            range.select();
        }
        else if (window.getSelection) {
            var range = document.createRange();
            range.selectNode(document.getElementById(objId));
            window.getSelection().addRange(range);
        }
    }
    function fnDeSelect() {
        if (document.selection)
            document.selection.empty();
        else if (window.getSelection)
            window.getSelection().removeAllRanges();
    }

    function OpenOutlook(to, cc, bcc, subject, obj, pdfpath) {
        var lnkMail = '';
        subject = subject.replace("&", "and");
        if (cc != "" && bcc != "") {
            lnkMail = "mailto:" + to + "?cc=" + cc + "&bcc=" + bcc + "&subject=" + subject + "";
        }
        else if (cc == "" && bcc != "") {
            lnkMail = "mailto:" + to + "?bcc=" + bcc + "&subject=" + subject + "";
        }
        else if (bcc == "" && cc != "") {
            lnkMail = "mailto:" + to + "?cc=" + cc + "&subject=" + subject + "";
        }
        else {
            lnkMail = "mailto:" + to + "?subject=" + subject + "";
        }

        var body = document.getElementById(obj).innerHTML;
        var FinalOccyStr = body.replace(/<br>/g, '%0D%0A');
        FinalOccyStr = strip(FinalOccyStr).replace(/[\n\r]/g, '%0D%0A');

        //var FinalOccyStr = strip(body);
        //for (var k = 0; k < 10; k++) {
        //    FinalOccyStr = FinalOccyStr.replace("<br>", "%0A"); 
        //    FinalOccyStr = FinalOccyStr.replace("<br />", "%0A");
        //    FinalOccyStr = FinalOccyStr.replace("<p>", "");
        //    FinalOccyStr = FinalOccyStr.replace("</p>", "%0A%0A");
        //    FinalOccyStr = FinalOccyStr.replace("&", "and");
        //}

        var SysName = '<%=SysName %>';
        if (SysName.toLowerCase() == "occy" || SysName.toLowerCase() == "creativeapproach") {
            location.href = lnkMail + "&body=" + FinalOccyStr + "";
        }
        else {
            location.href = lnkMail + "&body=" + escape(pdfpath) + "";
        }
    }

    function strip(html) {
        var tmp = document.createElement("DIV");
        tmp.innerHTML = html;
        return tmp.textContent || tmp.innerText;
    }

    <%=FinalOutlookData %>


    function desableAfterLoad() {
        window.parent.document.getElementById("ds00").style.display = "none";
        window.parent.document.getElementById("div_Load").style.display = "none";
    }


    setTimeout("desableAfterLoad()", 1000);
    window.parent.document.getElementById("Iframe_forAll").style.height = window.parent.document.getElementById("Iframe_forAll").contentWindow.document.body.scrollHeight + "px";


</script>

