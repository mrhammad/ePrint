<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="prof_attachment_selection.ascx.cs" Inherits="ePrint.usercontrol.Item.prof_attachment_selection" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="../js/item/general.js?VN='<%=VersionNumber%>'"></script>
<div id="div_attachments" align="left" style="width: 100%; height: 100%; border: 0px solid red;">
    <telerik:RadAjaxManager ID="ajaxMngr_Attch" runat="server">
        <AjaxSettings>
            <%--            <telerik:AjaxSetting AjaxControlID="btnUpload">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Specific" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadStrp_Attch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStrp_Attch" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage_Attach" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage_Attach">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStrp_Attch" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage_Attach" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <%--<div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <span class="navigatorpanel">
                            <%#objLanguage.GetLanguageConversion("Attachments")%></span>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div align="left" style="width: 100%">
        <div style="width: 100%; margin-left: 10px;">
            <asp:UpdatePanel ID="UPMessage" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div>
        <%--class="borderWithoutTop"--%>
        <div style="padding-left: 5px; width: 99%; padding-top: 8px;">

            <div id="Div_Attach" runat="server">
                <div id="Div1">
                    <%-- <asp:ImageButton Style="vertical-align: middle" ID="attachment_btn" OnClientClick="javascript:popup_attachments();return false;"   runat="server" CausesValidation="False" ImageUrl="../../images/plus.gif">
                                                        </asp:ImageButton>--%>

                    <%----%>
                    <div id="Div2" style="width: 100%;">
                        <div style="text-align: left;margin-bottom:10px" runat="server">
                            <asp:Label runat="server" Text="Status" Visible="false" Style="padding-right: 10px; font-weight: bold"></asp:Label>
                            <asp:DropDownList ID="proof_status" DataTextField="TextFieldValue" Visible="false" DataValueField="ValueFieldValue" runat="server" Style="width: 20%;">
                            </asp:DropDownList>
                        </div>
                        <div id="div_MainExp" runat="server" style="border: none;">

                            <telerik:RadGrid ID="RadGrid_Specific" runat="server" AllowCustomPaging="false" AllowPaging="false"
                                AllowSorting="false" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true"
                                OnItemDataBound="RadGridGenereal_OnItemDataBound" OnNeedDataSource="RadGrid_Specific_OnNeedDataSource"
                                PagerStyle-AlwaysVisible="true" PageSize="50" ShowStatusBar="true" Visible="true"
                                Width="100%" Style="background: no-repeat;">
                                <MasterTableView CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <div id="DivAddNewRecords" runat="server">
                                            <table border="0" class="rgCommandTable" runat="server" style="width: 100%;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Image ID="attachment_btn" runat="server" ImageUrl="~/images/plus.gif" onclick="javascript:popup_attachments();"
                                                            Style="cursor: pointer" ToolTip="Add new file" Visible="true" /><a href="#" onclick="javascript:popup_attachments();"
                                                                style="padding-left: 5px;">Add new record</a>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                            <HeaderTemplate>
                                                <input id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input id="Id1" runat="server" name="Id" checked="checked" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.AttachmentID", "{0}") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="FileName" HeaderStyle-Width="35%" HeaderText="File Name"
                                            ItemStyle-Width="35%" SortExpression="FileName" UniqueName="FileName">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; min-height: 18px;">
                                                    <asp:LinkButton ID="lbl_FileName" runat="server" Style="display: none;" Text='<%#Eval("OriginalFileName")%>'></asp:LinkButton>
                                                    <a id="ancFileName" href="#" name='<%#Eval("OriginalFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("FileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                        title='<%#Eval("OriginalFileName")%>'>
                                                        <%#Eval("OriginalFileName")%></a><br />
                                                    <a id="ancReportFileName" href="#" name='<%#Eval("ReportFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("ReportFileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                        title='<%#Eval("ReportFileName")%>'>
                                                        <%# (String.IsNullOrEmpty(Eval("ReportFileName").ToString()) ? "" : "Report File.pdf") %></a>
                                                    <asp:HiddenField ID="hdn_ActualFileName" runat="server" Value='<%#Eval("FileName")%>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Title" HeaderStyle-Width="20%" ItemStyle-Width="20%"
                                            SortExpression="Title" UniqueName="Title" Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_Title1" runat="server" Visible="true"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.ModuleNumber", "{0}"))%></asp:Label><%----%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="EstimateTitle" HeaderStyle-Width="20%" HeaderText="Item Title"
                                            ItemStyle-Width="20%" SortExpression="EstimateTitle" UniqueName="EstimateTitle"
                                            Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_ItemTitle" runat="server" Visible="true"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateTitle", "{0}"))%></asp:Label><%----%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="UserName" HeaderStyle-Width="15%" HeaderText="Uploaded By"
                                            ItemStyle-Width="15%" SortExpression="UserName" UniqueName="UserName">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_UplBy" runat="server"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.UserName", "{0}"))%></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="CreatedDate" HeaderStyle-Width="17%" HeaderText="Uploaded On"
                                            ItemStyle-Width="17%" SortExpression="CreatedDate" UniqueName="CreatedDate">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_UpldOn" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedDate", "{0}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="7%" HeaderText="Action" ItemStyle-Width="7%">
                                            <HeaderTemplate>
                                                <div style="margin-left: 5%;">
                                                    <asp:Label ID="Label" runat="server" Text="Action"></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="margin-left: 15%;">
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("AttachmentID")%>'
                                                        ImageUrl="~/Images/erase.png" OnClientClick="javascript:return imgdelete();"
                                                        OnCommand="imgbtnDelete_OnClick_Specific" ToolTip="Delete" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings EditFormType="Template">
                                        <FormTemplate>
                                        </FormTemplate>
                                    </EditFormSettings>
                                </MasterTableView><ClientSettings Scrolling-AllowScroll="true">
                                    <Scrolling AllowScroll="true" ScrollHeight="250" UseStaticHeaders="true" />
                                </ClientSettings>
                            </telerik:RadGrid>
                            <div id="div9" style="padding: 5px 0px 2px 2px;">
                                <div id="div_delspecific" style="display: block">
                                    <div id="div3" runat="server" style="float: left; margin: 0px 10px 0px 0px;">
                                        <div id="div_btncancel_Genrl" style="display: block">
                                            <asp:Button ID="btncancel_Genrl" runat="server" CommandName="Cancel" CssClass="button"
                                                OnClientClick="javascript:loadingimg('div_btncancel_Genrl','div_btncancel_Genrl_process');Close_wind();"
                                                Text="Cancel" />
                                        </div>
                                        <div id="div_btncancel_Genrl_process" align="center" class="button" style="width: 42px; display: none">
                                            <img alt="loading" border="0" class="trans" src="<%=strImagepath %>radimg1.gif" />
                                        </div>
                                    </div>
                                    <div style="float: left; margin: 0px 10px 0px 0px;">
                                        <asp:Button ID="btn_delSpecific" runat="server" CssClass="button" OnClick="DeleteSelected_ItemSpcfc_OnClick"
                                            Text="Create Proof" />


                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div class=" only5px">
            </div>
        </div>
    </div>
</div>
<div style="clear: both;">
</div>
</div>
<div id="Div_Attachment" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="300" Height="250" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdn_ddlEstitemID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ddlEstType" runat="server" Value="" />
<asp:HiddenField ID="hdn_AttachFileSupRFQ_Gen" runat="server" Value="" />
<asp:HiddenField ID="hdn_IsPreFlightEnabled" runat="server" Value="0" />
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
            return oWindow;
        }

        setTimeout("CloseOnReload()", 000);

        function CloseOnReload() {
            GetRadWindow().Close();
        }
    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">

    function TakeOut() {
        window.close();
    }



    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>
<asp:Panel ID="pnlLoadonEdit" runat="server" Visible="false">
    <script type="text/javascript">
        function ShowDivOnEdit() {
            var mode = '<%=Mode %>';
            if (mode == 'edit') {
                document.getElementById("div_FileName1").style.display = "block";
                document.getElementById("div_FileName2").style.display = "block";
                document.getElementById("div_FileName3").style.display = "block";
            }
        }
        ShowDivOnEdit();
    </script>
</asp:Panel>
<asp:Label ID="lblGetID" runat="server"></asp:Label>
<script type="text/javascript" src="<%#strSitepath%>js/HelpText/Mask.js?VN='<%#VersionNumber%>'"></script>
<script>
    var hdn_ddlEstitemID = document.getElementById("<%=hdn_ddlEstitemID.ClientID %>");
    var hdn_ddlEstType = document.getElementById("<%=hdn_ddlEstType.ClientID %>");

    <%--var chkPreflightGeneral = document.getElementById("<%=chkPreflightGeneral.ClientID %>");
    var ddlPreflightGeneral = document.getElementById("<%=ddlPreflightGeneral.ClientID %>");--%>
    var hdn_IsPreFlightEnabled = document.getElementById("<%= hdn_IsPreFlightEnabled.ClientID %>");
    var ArrEstType = new Array();
    var EstimateType = '<%=EstimateType %>';

    function onchange_ddlSpecific(objddl, ddlval) {

        hdn_ddlEstitemID.value = ddlval;
        var str = EstimateType.split('‡');
        for (var i = 0; i < str.length - 1; i++) {
            ArrEstType.push(str[i]);
            hdn_ddlEstType.value = ArrEstType[objddl.selectedIndex];
        }
    }

    function lnk_AddNew_Click() {
       <%-- var Div_IS = document.getElementById("<%=Div_IS.ClientID %>");
        var lnk_AddNew = document.getElementById("<%=lnk_AddNew.ClientID %>");
        lnk_AddNew.style.display = "none";
        Div_IS.style.display = "block";--%>
    }


    <%--function lnk_AddNewGen_Click() {
        var Div_GeneralAdd = document.getElementById("Div_GeneralAdd");
        var linkAdd_Gen = document.getElementById("<%=linkAdd_Gen.ClientID %>");
        Div_GeneralAdd.style.display = "block";
        linkAdd_Gen.style.display = "none";
    }--%>

</script>
<script type="text/javascript">
    function imgdelete() {
        return confirm("Are you sure you want to create proof record?");
    }

   <%-- var lblGetID = document.getElementById("<%=lblGetID.ClientID %>").id;--%>
    function MakeMaskShow() {

        var w = 900; var h = 400;
        displayCommon_first('div_attachments', w, h);
    }

    var CheckFinal = false;
  <%--  function uploadCheck_Specific() {

        CheckFinal = true;
        //Controls which are inside the RadGrid...
        // var FileUpload1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload1");
        // var FileUpload2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload2");
        // var FileUpload3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload3");
        var FileUpload1 = document.getElementById("<%=FileUpload1.ClientID %>");
        var FileUpload2 = document.getElementById("<%=FileUpload2.ClientID %>");
        var FileUpload3 = document.getElementById("<%=FileUpload3.ClientID %>");

        document.getElementById("Spn_errorr1").style.display = "none";
        document.getElementById("spn_ErrIsvalidIS").style.display = "none";
        if (FileUpload1.value == '' && FileUpload2.value == '' && FileUpload3.value == '') {
            document.getElementById("Spn_errorr1").style.display = "block";
            CheckFinal = false;
        }
        if (FileUpload1.value != '') {
            var fileupload = FileUpload1.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                // var SplitedFile = "." + ArrFile[1];
            }
            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload2.value != '') {
            var fileupload = FileUpload2.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload3.value != '') {
            var fileupload = FileUpload3.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                // var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }

        if (CheckFinal) {
            if (hdn_IsPreFlightEnabled.value == "1") {
                if (chkPreflightItem.checked && ddlPreflightItem.options.selectedIndex == 0) {
                    alert('Please select profile');
                    ddlPreflightItem.focus();
                    return false;
                }
            }
            document.getElementById("Spn_errorr1").style.display = "success";
        }
        else {
            return false;
        }
    }--%>


    //File Validation for General tab...
    var CheckFinal = false;
   <%-- function uploadCheck_General() {

        CheckFinal = true;
        var FileUpload4 = document.getElementById("<%=FileUpload4.ClientID %>");
        var FileUpload5 = document.getElementById("<%=FileUpload5.ClientID %>");
        var FileUpload6 = document.getElementById("<%=FileUpload6.ClientID %>");

        document.getElementById("Spn_errorr").style.display = "none";
        document.getElementById("spn_ErrIsvalidGen").style.display = "none";
        if (FileUpload4.value == '' && FileUpload5.value == '' && FileUpload6.value == '') {
            document.getElementById("Spn_errorr").style.display = "block";
            CheckFinal = false;
        }
        if (FileUpload4.value != '') {
            var fileupload = FileUpload4.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }
            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";

                CheckFinal = false;
            }
        }
        if (FileUpload5.value != '') {
            var fileupload = FileUpload5.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload6.value != '') {
            var fileupload = FileUpload6.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";
                CheckFinal = false;
            }
        }
        if (CheckFinal) {
            if (hdn_IsPreFlightEnabled.value == "1") {
                if (chkPreflightGeneral.checked && ddlPreflightGeneral.options.selectedIndex == 0) {
                    alert('Please select profile');
                    ddlPreflightGeneral.focus();
                    return false;
                }
            }
            document.getElementById("Spn_errorr").style.display = "success";
        }
        else {
            return false;
        }
    }--%>

    function CheckAll(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                e.checked = ChkState;
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1)
                e.checked = ChkState;
        }
    }
    function checkAll_new(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
        }
    }

</script>
<script>
    //function CallDelete() {
    //    var ret = CheckOne_new();
    //    if (ret) {
    //        return true;
    //    }
    //    else {
    //        return false;
    //    }
    //}
   <%-- function CheckOne_new() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;

                }
            }
        }
        if (Number(Counter) == 0) {
            //alert("Please check at least one 'row' to Delete");
            alert('<%=objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert")%>');
            return false;
        }
        else {
            //return window.confirm('Are you sure you want to delete this record(s)?');
            return window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert")%>');
        }
    }--%>

</script>
<script>
    function popup_attachments() {
        debugger;
        var currentLocation = window.location.href;
        var _redUrl = currentLocation.replace("type=proof", "type=attachments");
        window.location.href = _redUrl;
    }
    function Email_Attachment() {
        var ret = CheckOne_newAttach();
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckOne_newAttach() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
        }

        if (Number(Counter) > 0) {
            return true;
        }
        else {
            alert("Please check at least one file to Attach");
            return false;
        }

        var count = Counter;
    }


</script>
<script>
    // Function to view the file...
    function OpenAttach(Obj, Type) {
        var OpenNewInmage = "";
        if (Type == "True") {
            // OpenNewInmage = '<%=StreStorAttach%>' + Obj;
            var ext = Obj.substr(Obj.lastIndexOf('.') + 1);
            if (ext.toLowerCase() == 'png') {
                OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=previewimage&actid=" + '<%=AccountID %>' + "&filename=" + Obj;
            }
            else {
                OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=attachments&filename=" + Obj;
            }
        }
        else {
            // OpenNewInmage = '<%=StrDownload%>' + Obj;
            OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=attachments&filename=" + Obj;
        }
        window.open(OpenNewInmage);
    }

<%--    function AddnewFile_General() {
        var Div_GeneralAdd = document.getElementById("Div_GeneralAdd");
        var linkAdd_Gen = document.getElementById("<%=linkAdd_Gen.ClientID %>");
        Div_GeneralAdd.style.display = "block";
        linkAdd_Gen.style.display = "none";
    }--%>
    function AddnewFile_Specific() {
       <%-- var Div_IS = document.getElementById("<%=Div_IS.ClientID %>");
        var lnk_AddNew = document.getElementById("<%=lnk_AddNew.ClientID %>");
        lnk_AddNew.style.display = "none";
        Div_IS.style.display = "block";--%>

    }

</script>
<script>
    function GetAttachments(Attached, ActualFiles) {
        var MainContainerID = "<%=AttachImageID%>";
        MainContainerID = MainContainerID.replace("Image_Attachment", "Div_Attach");
        var Div_Attach = window.parent.frames[0].document.getElementById(MainContainerID); //parent.window.document.getElementById(MainContainerID);
        var StrChckbox = '';
        var StrAttach = Attached.split('‡');
        var StrActual = ActualFiles.split('‡');
        for (var i = 0; i < StrAttach.length - 1; i++) {
            var Attach = StrAttach[i];
            var ActualFile = StrActual[i];
            StrChckbox += "<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>";
            StrChckbox += "<input type='checkbox'  id='Chk_Attach_" + i + "' value='" + ActualFile + "' title='" + Attach + "' checked='checked' style='float:left; display:block;'/>" + Attach + "";
            StrChckbox += "</div>";
        }
        Div_Attach.innerHTML += StrChckbox;
    }

    function EnablePreFlightDdl(chkPreFlight, ddlPreFlight) {
        if (chkPreFlight.checked) {
            ddlPreFlight.disabled = false;
        }
        else {
            ddlPreFlight.disabled = true;
        }
    }
</script>
<asp:Panel ID="Pnl_AttachLinkForSupplier" runat="server" Visible="false">
    <script>

        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        var MainContainerID = "<%=AttachImageID%>";
        var Str_AttachPath = '<%=StrDownload%>';
        window.parent.frames[0].GetAttachLink_Supplier(AttachedSupRFQ, ActualSupRFQ, MainContainerID, Str_AttachPath);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttacClose" runat="server" Visible="false">
    <script>
        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        GetAttachments(AttachedSupRFQ, ActualSupRFQ);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttachCustomer" runat="server" Visible="false">
    <script>
        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        window.parent.frames[0].BindAttachmentsForActual(AttachedSupRFQ, ActualSupRFQ);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttachLinkCustomer" runat="server" Visible="false">
    <script>
        var CheckedAttachLink = '<%=AttachSupRFQ%>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        window.parent.frames[0].BindAttachment_Link(CheckedAttachLink, ActualSupRFQ);
    </script>
</asp:Panel>
<asp:Panel ID="pnl_WindowClose" runat="server" Visible="false">
    <script>
        setTimeout("TakeOut()", 700);
        function TakeOut() {
            window.close();
        }
    </script>
</asp:Panel>
<asp:Panel ID="pnl_CloseWebstore" runat="server" Visible="false">
    <script>
        //        RefreshParentPage();
        //        function RefreshParentPage() {
        //            var win = window.radWindow.radWindow;
        //        alert(win);
        //        win.radWindow.Reload();
        //           
        //        }

        //        function GetRadWindow() {
        //            var oWindow = null;
        //            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        //            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
        //            return oWindow;
        //        }  




        //        parent.location.reload(true);
        //        self.close();       
    </script>
</asp:Panel>
