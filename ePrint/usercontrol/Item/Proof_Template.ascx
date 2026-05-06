<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Proof_Template.ascx.cs" Inherits="ePrint.usercontrol.Item.Proof_Template" %>
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
<%--<script type="text/javascript">
     function ClosebtnClick(btnid) {
        document.getElementById(btnid).style.color = "blue";
        window.location.href = '../Proofs/Proof_summary.aspx?estid=' + '<%=EstimateID %>' + '&EstItemID=' + '<%=EstimateItemID%>' + '&ProofID=' +'<%=ProofID%>'';

    }
</script>--%>
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

    function desableAfterLoad() {
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    }


    function ClosebtnClick(btnid) {
        debugger;
        document.getElementById(btnid).style.color = "blue";
        window.location.href = '../Proofs/Proof_summary.aspx?estid=' + '<%=EstimateID %>' + '&EstItemID=' + '<%=EstimateItemID%>' + '&ProofID=' + '<%=ProofID%>';
    }

</script>
<div align="left">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div align="left">
        <div id="padding" class="div_prod_vwmargin">
            <div id="ynnav">
                <ul>
                    <%--  <li id="li_ChooseTemplate" runat="server" style="cursor: pointer; float: left; clear: right;">
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
                    </li>--%>
                    <li id="li_EmailTemplate" runat="server" style="cursor: pointer; color: blue; float: left; clear: right">
                        <div id="div3" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                            <b><span id="item_4" class="lnkTabSelected" style="color:blue">
                                <%=objLanguage.GetLanguageConversion("Email")%>
                            </span></b>
                        </div>
                    </li>
                    <li id="li_Close" style="cursor: pointer; float: left; clear: right;">
                        <div id="div4" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
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
    //document.getElementById("ds00").style.display = "none";
    //document.getElementById("div_Load").style.display = "none";
</script>

