<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="templates_view1.ascx.cs" Inherits="ePrint.usercontrol.templates_view1" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" language="javascript" src="../js/JScript.js?VN='<%=VersionNumber%>'"></script>
<div id="ds00" style="display: block; position: fixed;">
</div>
<div id="div_Load" style="position: fixed; top: 46%; left: 46%; z-index: 800;">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<div id="Div_Attachment" style="position: absolute; vertical-align: middle;" align="center">
    <telerik:RadWindowManager EnableShadow="false" Style="z-index: 31000" ID="RadWindowManager2"
        DestroyOnClose="true" Opacity="100" runat="server" Behaviors="Close,Reload" OnClientClose="RadWinClose"
        ReloadOnShow="true">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px"; document.getElementById("ds00").style.height = window.screen.availHeight + "px";
</script>
<script type="text/javascript">
    var iframePath = '<%=iframePath %>';
    var iframePathpdf = '<%=iframePathpdf %>';
    var iframePathForEditTemplate = '<%=iframePathForEditTemplate %>';
    var iframeEmailPath = '<%=iframeEmailPath %>';
    var iframePathChooseTemp = '<%=iframePathChooseTemp %>';

    var iframePath1 = '<%=iframePath %>';
    var iframePathpdf1 = '<%=iframePathpdf %>';
    var iframePathForEditTemplate1 = '<%=iframePathForEditTemplate %>';
    var iframeEmailPath1 = '<%=iframeEmailPath %>';
    var iframePathChooseTemp1 = '<%=iframePathChooseTemp %>';
    var customtype = '<%=customType %>';

    function desableAfterLoad() {
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    }

    function TestIframe(btnid) {
        debugger;
        var TemplateIDForDLL = '<%=TemplateID%>';

        if (TemplateIDForDLL > 0) {
            if (iframePath.indexOf('&templateid=') != -1) {
                iframePath = iframePath.substring(0, iframePath.indexOf("&templateid="));
            }
            if (iframePathpdf.indexOf('&templateid=') != -1) {
                iframePathpdf = iframePathpdf.substring(0, iframePathpdf.indexOf("&templateid="));
            }
            if (iframePathForEditTemplate.indexOf('&templateid=') != -1) {
                iframePathForEditTemplate = iframePathForEditTemplate.substring(0, iframePathForEditTemplate.indexOf("&templateid="));
            }
            if (iframeEmailPath.indexOf('&templateid=') != -1) {
                iframeEmailPath = iframeEmailPath.substring(0, iframeEmailPath.indexOf("&templateid="));
            }
            if (iframePathChooseTemp.indexOf('&templateid=') != -1) {
                iframePathChooseTemp = iframePathChooseTemp.substring(0, iframePathChooseTemp.indexOf("&templateid="));
            }
        }
        document.getElementById("div_Iframe").style.display = "none";
        document.getElementById("ds00").style.display = "block";
        document.getElementById("div_Load").style.display = "block";

        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";

        if (document.getElementById(btnid).id == "item_1") {
            document.getElementById("li_Preview").style.display = "none";
            document.getElementById("li_EditTemplate").style.display = "none";
            document.getElementById("li_EmailTemplate").style.display = "none";
            if (document.getElementById("item_1").innerHTML == "Change Template") {
                document.getElementById("item_1").innerHTML = "Choose Template";
            }
            document.getElementById("Iframe_forAll").src = iframePathChooseTemp;
        }
        if (document.getElementById(btnid).id == "item_2") {
            if (TemplateIDForDLL > 0) {
                document.getElementById("Iframe_forAll").src = iframePathpdf + "&templateid=" + <%=TemplateID%>;
            }
            else {
                document.getElementById("Iframe_forAll").src = iframePathpdf;
            }
        }
        if (document.getElementById(btnid).id == "item_3") {
            if (TemplateIDForDLL > 0) {
                document.getElementById("Iframe_forAll").src = iframePathForEditTemplate + "&templateid=" + <%=TemplateID%>;
            }
            else {
                document.getElementById("Iframe_forAll").src = iframePathForEditTemplate;
            }
            document.getElementById("Iframe_forAll").scrolling = "yes";

        }
        if (document.getElementById(btnid).id == "item_4") {
            if (TemplateIDForDLL > 0) {
                document.getElementById("Iframe_forAll").src = iframeEmailPath + "&templateid=" + <%=TemplateID%>;
            }
            else {
                document.getElementById("Iframe_forAll").src = iframeEmailPath;
            }
        }

        document.getElementById(btnid).style.color = "blue";
        for (var i = 1; i <= 5; i++) {
            var dd = "item_" + i;
            if (dd != btnid) {
                if (document.getElementById("item_" + i) != null) {
                    document.getElementById("item_" + i).style.color = "black";
                    var ff = "div_" + i;
                    ff = ff + i;
                }
            }
            else {
                var ff = "div_" + i;
                ff = ff + i;
            }
        }
        document.getElementById("div_Iframe").style.display = "block";
    }


    function ClosebtnClick(btnid) {
        document.getElementById(btnid).style.color = "blue";
        document.getElementById("li_Preview").style.display = "none";
        document.getElementById("li_EditTemplate").style.display = "none";
        document.getElementById("li_EmailTemplate").style.display = "none";
        var IS_from_Webstore = '<%=IS_INVOICEorJOB_from_Webstore%>';

        if (document.getElementById(btnid).id == "item_5") {
            var maintype = '<%=maintype %>';
            if ('<%=PageType %>' == "Estimate" || '<%=PageType %>' == "PrintBroker") {
                if (maintype == 'edit') {
                    if (window.location.href.indexOf("orders/") > -1) {
                        window.location.href = '../orders/order_summary.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&ordid=' + '<%=EstimateID %>' + '&estitemid=' + '<%=EstimateItemID%>' + '&recall=y&maintype=edit' + '<%=jID %>' + '<%=InvID %>';
                    }
                    else {
                        window.location.href = '../estimates/estimate_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&estitemid=' + '<%=EstimateItemID%>' + '&recall=y&maintype=edit' + '<%=jID %>' + '<%=InvID %>';
                    }
                }
                else if (maintype == 'add') {
                    if (window.location.href.indexOf("orders/") > -1) {
                        window.location.href = '../orders/order_summary.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&ordid=' + '<%=EstimateID %>' + '&estitemid=' + '<%=EstimateItemID%>' + '&maintype=add' + '<%=jID %>' + '<%=InvID %>';
                    }
                    else {
                        window.location.href = '../estimates/estimate_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&estitemid=' + '<%=EstimateItemID%>' + '&maintype=add' + '<%=jID %>' + '<%=InvID %>';
                    }
                }
                else {
                    if (window.location.href.indexOf("orders/") > -1) {
                        window.location.href = '../orders/order_summary.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&ordid=' + '<%=EstimateID %>' + '' + '<%=jID %>' + '<%=InvID %>';
                    }
                    else {
                        window.location.href = '../estimates/estimate_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '' + '<%=jID %>' + '<%=InvID %>';
                    }
                }
        }
        else if ('<%=PageType %>' == "Job" || '<%=PageType %>' == "JobCard") {
                if (IS_from_Webstore == "yes") {
                    window.location.href = '../jobs/job_order_summary.aspx?frm=view&ordid=' + '<%=EstimateID %>' + '&estid=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
                }
                else {
                    if ('<%=EstimateItemID%>' != 0) {
                        window.location.href = '../jobs/job_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '&estitemid=' + '<%=EstimateItemID%>' + '&maintype=' + maintype + '<%=jID %>' + '<%=InvID %>';
                    }
                    else {
                        window.location.href = '../jobs/job_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
                    }
                }
            }
            else if ('<%=PageType %>' == "Invoice") {
                if (IS_from_Webstore == "yes") {
                    window.location.href = '../invoice/invoice_order_summary.aspx?frm=view&ordid=' + '<%=EstimateID %>' + '&estid=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
                }
                else {
                    window.location.href = '../invoice/invoice_summary_reeng.aspx?frm=view&estid=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
                }
            }
            else if ('<%=PageType %>' == "webstoreorder") {
                window.location.href = '../orders/order_summary.aspx?frm=view&ordid=' + '<%=EstimateID %>' + '&estid=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
            }
            else if ('<%=PageType %>' == "Purchase") {
                window.location.href = '../purchase/purchase_add.aspx?type=edit&id=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
            }
            else if ('<%=PageType %>' == "Note") {
                window.location.href = '../delivery/delivery_add.aspx?type=edit&id=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
            }
            else if ('<%=PageType %>' == "Note") {
                window.location.href = '../delivery/delivery_add.aspx?type=edit&id=' + '<%=EstimateID %>' + '<%=jID %>' + '<%=InvID %>';
            }
}
}
</script>
<div align="left">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div align="left">
        <div id="padding" class="div_prod_vwmargin">
            <div id="ynnav">
                <ul>
                    <li id="li_ChooseTemplate" style="cursor: pointer; float: left; clear: right;">
                        <div id="div2" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                            line-height: 20px; margin-right: 2px">
                            <b><span id="item_1" class="lnkTabSelected" onclick=" javascript:TestIframe(this.id);">
                                <%=objLangClass.GetLanguageConversion("Choose_Template")%></span></b>
                        </div>
                    </li>
                    <li id="li_Preview" style="cursor: pointer; float: left; clear: right; display: none">
                        <div id="div1" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                            line-height: 20px; margin-right: 2px">
                            <b><span id="item_2" class="lnkTabSelected" onclick=" javascript:TestIframe(this.id);">
                                <%=objLanguage.GetLanguageConversion("Preview")%>
                            </span></b>
                        </div>
                    </li>
                    <li id="li_EditTemplate"  style="cursor: pointer; float: left; clear: right; display: none">
                        <div id="div5" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                            line-height: 20px; margin-right: 2px">
                            <b><span id="item_3" class="lnkTabSelected" onclick=" javascript:TestIframe(this.id);">
                                <%=objLanguage.GetLanguageConversion("Edit_Template")%>
                            </span></b>
                        </div>
                    </li>
                    <li id="li_EmailTemplate" style="cursor: pointer; float: left; clear: right; display: none">
                        <div id="div3" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                            line-height: 20px; margin-right: 2px">
                            <b><span id="item_4" class="lnkTabSelected" onclick="javascript:TestIframe(this.id);">
                                <%=objLanguage.GetLanguageConversion("Email")%>
                            </span></b>
                        </div>
                    </li>
                    <li id="li_Close" style="cursor: pointer; float: left; clear: right;">
                        <div id="div4" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                            line-height: 20px; margin-right: 2px">
                            <b><span id="item_5" class="lnkTabSelected" onclick="javascript:ClosebtnClick(this.id);">
                                <%=objLanguage.GetLanguageConversion("Close")%>
                            </span></b>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="onlyEmpty">
            </div>
            <div class="divBorderItem">
                <div id="Div6" width="100%">
                    <div align="left" id="div_Iframe" style="display: block; padding: 15px 0px 15px 15px;">
                        <iframe id="Iframe_forAll" name="Iframe_forAll" style="visibility: visible;" width="100%"
                            src='<%=iframePath%>' frameborder="0" scrolling="no"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField runat="server" ID="hdnTemplateIDForPDF" Value="0" />
<asp:Panel ID="pnlOnlyOneTemp" runat="server" Visible="false">
    <script language="javascript" type="text/javascript">
        if ('<%=OnlyOneTemp %>' != "" && '<%=OnlyOneTemp %>' == "yes") {
            debugger;

            document.getElementById("li_Preview").style.display = "block";
            document.getElementById("item_2").style.color = "blue";
            document.getElementById("item_1").style.color = "black";
            if ('<%=PageType %>' == "PrintBroker") {
                document.getElementById("li_EditTemplate").style.display = "none";
            }
            else {
                document.getElementById("li_EditTemplate").style.display = "block";
            }
            document.getElementById("li_EmailTemplate").style.display = "block";
            document.getElementById("item_1").innerHTML = '<%=objLanguage.GetLanguageConversion("Change_Template")%>';
        }       
    </script>
</asp:Panel>
<script language="javascript" type="text/javascript">

    function openAttpopup(path) {
        var Radwindow_Attachment = radopen(path);
        SetRadWindow_Ver2('Div_Attachment', 'divBackGroundNew');
        Radwindow_Attachment.setSize(950, 500);
        Radwindow_Attachment.center();
    }

    function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
        var divBackGroundNew = document.getElementById(divBackgroundID);
        if (document.getElementById(divMaskID).style.display == "none") {

            if (navigator.appName != "Microsoft Internet Explorer") {
                setLoadingPositionOfDivCenter_Ver2(Div_Attachment);
            }
            showDivPopupCenter_Ver2(divMaskID);
        }
        else {
            showDivPopupCenter_Ver2(divMaskID);
        }
    }

    function RadWinClose() {
        document.getElementById("Div_Attachment").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
</script>
<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>

