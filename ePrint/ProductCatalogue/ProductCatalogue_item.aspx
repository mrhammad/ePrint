<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.Master" AutoEventWireup="true" CodeBehind="ProductCatalogue_item.aspx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogue_item" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="uc" TagName="EditableProduct" Src="~/usercontrol/settings/editableproduct_create.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="SMproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>

    <style type="text/css">
        div#ctl00_ContentPlaceHolder1_GridWebOtherCostShippedOrders_GridHeader {
            padding-right: 0px;
            overflow: hidden;
        }

        #ctl00_ContentPlaceHolder1_lblType {
            font-weight: normal;
        }



        .ftp-panel {
            background-color: #f9f9f9;
            border: 1px solid #ccc;
            padding: 10px;
            border-radius: 10px;
            width: 80%;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }

        /* Headings */
        .ftp-heading {
            color: royalblue;
            font-size: 14px;
        }

        .ftp-subheading {
            color: royalblue;
            font-size: 14px;
            margin-bottom: 10px;
        }

        /* Form Fields */
        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 6px;
            color: #333;
        }

        .form-control {
            width: 50%;
            padding: 8px 10px;
            font-size: 12px;
            border: 1px solid #aaa;
            border-radius: 5px;
        }

        .form-control1 {
            width: 644px;
            padding: 8px 10px;
            font-size: 12px;
            border: 1px solid #aaa;
            border-radius: 5px;
        }

        /* Separator */
        .separator {
            margin: 25px 0;
            border: 0;
            border-top: 1px solid #ddd;
        }

        /* GridView/Table Styling */
        .tag-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
            font-size: 14px;
        }

            .tag-table th,
            .tag-table td {
                border: 1px solid #ccc;
                padding: 10px;
                text-align: left;
            }

            .tag-table th {
                background-color: #f0f0f0;
                font-weight: bold;
            }

            .tag-table tr:nth-child(even) {
                background-color: #fafafa;
            }
    </style>
    <script type="text/javascript" src="../js/jquery-1.3.2.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript" src="../js/Jquery-1.11.1.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript" src="../js/Jquery-ui-1.11.0.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <link href="../css/jquery-ui-ePrint.css" rel="stylesheet" type="text/css" />
    <script>
        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }

        var Pgtype = '<%=PageType %>';
        var eStoreHide = '<%=objlang.GetLanguageConversion("eStoreHide")%>';
        var Qty_Display = '<%=objlang.GetLanguageConversion("Quantity")%>';
        var Cost_For1 = '<%=objlang.GetLanguageConversion("Cost_For1")%>';
        var Markup_display = '<%=objlang.GetLanguageConversion("Markup")%>';
        var sell_Price_For1 = '<%=objlang.GetLanguageConversion("Selling_Price_For1")%>';
        var Action_Display = '<%=objlang.GetLanguageConversion("Action")%>';
        var Cost_Display = '<%=objlang.GetLanguageConversion("Cost")%>';
        var Selling_Price_Display = '<%=objlang.GetLanguageConversion("Selling_Price")%>';
        var From = '<%=objlang.GetLanguageConversion("From")%>';
        var To = '<%=objlang.GetLanguageConversion("To")%>';
        var Cost_Price = '<%=objlang.GetLanguageConversion("Cost_Price")%>';
        var Measurementvalue = '<%=Measurementvalue %>';
        var Measurementvalue2 = '<%=Measurementvalue2 %>';
        var PaperMeasure = '<%=PaperMeasure%>';

        function Fileuploadtextclear() {
            var Fileuploadtext = document.getElementById('<%=upPrintReadyFile.ClientID%>');
            Fileuploadtext.value = "";
            document.getElementById('ctl00_ContentPlaceHolder1_Filetextclear').style.display = "None";
        }
        function checksize() {
            var Fileuploadtext = document.getElementById('<%=upPrintReadyFile.ClientID%>');
            if (Fileuploadtext.files[0].size > 0) {
                document.getElementById('ctl00_ContentPlaceHolder1_Filetextclear').style.display = "block";
                return false;
            }
        }
    </script>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="dialog-confirm" style="display: none;">
        <p>
            <span id="spn_dialog-confirm-msg" style="float: left; margin: 0 7px 20px 0;">You are saving this product without creating an opening stock quantity. An opening stock of zero will be added for this product.</span>
        </p>
    </div>
    <asp:HiddenField ID="hdn_AddZeroOpeningStock" Value="false" runat="server" />
    <asp:HiddenField ID="hdn_isMatrixCalculation" Value="false" runat="server" />
    <%--<%=strSitepath %>/js/popup.js--%>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Product Image"
                    OnClientClose="bindUploadimgname" KeepInScreenBounds="true" VisibleTitlebar="true"
                    VisibleStatusbar="true" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript">
        var PageType = '<%=PageType %>';
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridWebOtherCostPendingOrders">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostPendingOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridWebOtherCostShippedOrders">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostPendingOrders" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostPendingOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnReMove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostPendingOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnMove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkSaveGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkRemove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkprice_managestock">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostShippedOrders" />
                    <telerik:AjaxUpdatedControl ControlID="GridWebOtherCostPendingOrders" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridAvaialbleCoupncodes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridAvaialbleCoupncodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedCouponCodes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridSelectedCouponCodes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedCouponCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridAvaialbleCoupncodes" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCouponCodeMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridAvaialbleCoupncodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedCouponCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnCouponCodeMove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCouponCodeRemove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridSelectedCouponCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="GridAvaialbleCoupncodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnCouponCodeRemove" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">
        <script type="text/javascript">

            function onRowDropping(sender, args) {
                if (sender.get_id() == "<%=GridWebOtherCostPendingOrders.ClientID %>") {

                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=GridWebOtherCostShippedOrders.ClientID %>', node) && !isChildOf('<%=GridWebOtherCostPendingOrders.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }

            }

            function isChildOf(parentId, element) {
                while (element) {
                    if (element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }

            function CheckMainStockCheckbox(Id) {
                var chkId = document.getElementById(Id);
                var mainChkId = document.getElementById("ctl00_ContentPlaceHolder1_chkstockitem");
                if (chkId.checked == true) {
                    mainChkId.checked = true;
                }
            }

            function SetDigit_ShowInPacks(obj, val) {
                if (trim12(val) != '') {
                    if (val.substring(1, 0) != "-")//for NEGATIVE Values
                    {
                        if (!isNaN(val)) {
                            if (val > 0) {
                                val = val;
                            }
                            else {
                                obj.value = '1';
                            }
                            setQtyForSoldInPacks();
                            return true;
                        }
                        else {
                            obj.value = '1';
                            setQtyForSoldInPacks();
                            return false;
                        }
                    }
                    else {
                        obj.value = '1';
                        setQtyForSoldInPacks();
                        return false;
                    }
                }
                else {
                    obj.value = '1';
                    setQtyForSoldInPacks();
                    return false;
                }
            }


            function ToIntegerSolpacks(obj, val) {
                if (val.substring(val.length - 1, val.length) == ".") {
                    obj.value = val.toString().replace('.', '');
                }
                else {
                    obj.value = val;
                }
            }


            function setQtyForSoldInPacks() {
                if ("<%=action%>" != "edit") {
                    for (var i = 0; i < TotalRow; i++) {
                        try {
                            if (document.getElementById("txtQty_" + i + "") != null) {
                                var Pre_index = Number(i) - 1;
                                if (document.getElementById("txtQty_" + Pre_index + "") != null) {
                                    var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                    if (txt_SoldinPack.value != 0) {
                                        txt_Previous_value = (Number(txt_Previous_value) + Number(txt_SoldinPack.value));
                                    }
                                    else {
                                        txt_Previous_value = Number(txt_Previous_value) + 100;
                                    }
                                    document.getElementById("txtQty_" + i + "").value = txt_Previous_value;

                                    if (txt_SoldinPack.value == 0) {
                                        var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                        txt_Previous_value = Number(txt_Previous_value) + 100;
                                        document.getElementById("txtQty_from_" + i + "").value = Number(txt_Previous_value) - 100 + 1;
                                    }
                                    else {
                                        var txt_Previous_value = document.getElementById("txtQty_" + Pre_index + "").value;
                                        document.getElementById("txtQty_from_" + i + "").value = Number(txt_Previous_value) + 1;
                                    }
                                }
                            }
                        }
                        catch (err) { }
                    }
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Default" Skin="Default"
        runat="server" />
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript">
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var strImagepath = '<%=strImagepath %>';
        var strSitePath = '<%=strSitePath %>';
        var DecimalValue = 0;
        var commonpath = "<%=nmsCommon.global.sitePath()%>";
        var queryString = '<%=action%>';
        var Counter = '<%=count %>';
        var ProductCatalogueID = '<%=ProductCatalogueID %>';
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 6, '', false, false, false);
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/settingsjs.js?VN='<%#VersionNumber%>'"></script>
    <div align="left" style="width: 100%;">
        <div class="navigatorpanel show_hide" style="width: 100%;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div id="lblPriceCatalogueView" align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel">
                               <%=objlang.GetLanguageConversion("Products") %>&nbsp:&nbsp; <%=objlang.GetLanguageConversion("Product_Catalogue")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="div_popup_supplier_save" style="display: none;">
            <telerik:RadWindowManager ID="radwin_manager_supplier" runat="server">
                <Windows>
                    <telerik:RadWindow ID="radwin_supplier" runat="server" DestroyOnClose="true">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
        <%-- header --%>
        <%-- <div class="borderWithoutTop" style="width: 100%;">--%>
        <div id="padding" class="div_prodaddmargin">
            <div align="left" style="padding-top: 5px;">
                <div style="width: 65%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="height: 20px;">
                <div id="ynnav">
                    <ul style="width: 100%;">
                        <li id="li_General" style="cursor: pointer; float: left; clear: right;">
                            <div id="div_General" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="item_1" class="TabSelected" style="color: Red" onclick="javascript:gettabs('g');">
                                    <asp:Label ID="lblGeneral" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_Price" style="cursor: pointer; float: left; clear: right;">
                            <div id="div_Price" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="item_3" onclick="javascript:gettabs('p');">
                                    <asp:Label ID="lblPriceing" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_decoration" style="cursor: pointer; float: left; clear: right;">
                            <div id="div_decoration" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="item_decoration" onclick="javascript:gettabs('d');">
                                    <asp:Label ID="Labeldecoration" Text="Decoration" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_artworkCanvas" style="cursor: pointer; float: left; clear: right; display: none;">
                            <div id="div_artworkCanvas" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; cursor: pointer;">
                                <b><span id="item_2" onclick="javascript:gettabs('ac');">
                                    <asp:Label ID="lbleStoreSettingsPanel" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>

                        <li id="li_EditProduct" style="cursor: pointer; float: left; clear: right; display: none;">
                            <div id="Div_EditProduct" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; cursor: pointer;">
                                <b><span id="item_5" onclick="javascript:gettabs('ep');">
                                    <asp:Label ID="lblEditPRoduct" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_additionalOption" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_additionalOption" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; cursor: pointer;">
                                <b><span id="item_4" onclick="javascript:gettabs('ao');">
                                    <asp:Label ID="lblAdditionalOptions" runat="server"></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_CouponCodeOption" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_CouponCodeOption" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; cursor: pointer;">
                                <b><span id="item_6" onclick="javascript:gettabs('cc');">
                                    <asp:Label ID="lblCouponCodeOptions" runat="server"><%=objlang.GetLanguageConversion("Coupon_code_options")%></asp:Label>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_FTPOption" runat="server" style="cursor: pointer; float: left; clear: right;">
                            <div id="div_FTPOption" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; cursor: pointer;">
                                <b><span id="item_7" onclick="javascript:gettabs('ft');">
                                    <asp:Label ID="lblFTP" runat="server"><%=objlang.GetLanguageConversion("FTP")%></asp:Label>
                                </span></b>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div class="divBorderItem" style="width: 98%; overflow: hidden;">
                <div class="onlyEmpty">
                </div>
                <div id="tdaddnew" align="left" style="width: 100%; display: block;">
                    <div align="left">
                        <div style="display: none">
                            <div class="box">
                                <asp:CheckBox ID="chkNonEditable" runat="server" CssClass="graytext" Text="Non-editable"
                                    Checked="false" onclick="javascript:gettabStockItem('s');" />
                            </div>
                        </div>
                        <div style="width: 100%; float: left;">
                            <fieldset style="border: 0px solid #000000;">
                                <div style="width: 49%; float: left;">
                                    <div class="bglabel">
                                        <div style="float: left;">
                                            <asp:Label ID="lblCategory_Name" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div style="float: right">
                                            <a href='#' runat="server" id="btnaddcat" onclick="AddCategory('add')">
                                                <img alt="" src="<%=strImagepath %>plus.gif" border="0px" />
                                            </a>
                                        </div>
                                        <div style="float: right">
                                            <asp:ImageButton Style="vertical-align: top" ID="imgbtnaddcategory" Visible="true"
                                                runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new Category"></asp:ImageButton>
                                            <%--<asp:ImageButton Style="vertical-align: top" ID="imgbtnaddcategory" Visible="true"
                                                runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new Category"
                                                OnClick="imgbtnaddcategory_Click"></asp:ImageButton>--%>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <div>
                                            <asp:TextBox runat="server" ID="txtCategoryName" SkinID="textPad" MaxLength="50"
                                                onblur="CallonBlur(this.value,'spn_txtCategoryName');" Style="display: none;"
                                                CssClass="textboxnew1"></asp:TextBox>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="spn_txtCategoryName" style="display: none; width: 180px; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px" id="spn_CategoryName_Validation" runat="server"></span>
                                            </div>
                                        </div>
                                        <div id="div_PriceCata_Category_add_item" class="CenterDiv" align="left" style="display: none; position: absolute; height: 110px; width: 400px;">
                                            <div>
                                                <div align="center" class="bgcustomize" style="width: 100%; padding: 3px 0px 3px 0px;">
                                                    <div style="float: left; width: 95%; border: 0px solid">
                                                        <span class="navigatorpanel" style="vertical-align: middle" id="spn_Category_Name"
                                                            runat="server"></span>
                                                    </div>
                                                    <div style="float: right; border: 0px solid">
                                                        <a href="javascript://" onclick="AddCategory('close');return false;">
                                                            <img alt="" src="<%=strImagepath%>close1.jpg" border="0" width="11px" height="11px"
                                                                title="Close" /></a>
                                                    </div>
                                                    <div style="clear: both">
                                                    </div>
                                                </div>
                                                <div align="left" style="background-color: white; padding: 2px;">
                                                    <div class="only5px">
                                                    </div>
                                                    <div align="left">
                                                        <div class="bglabel">
                                                            <span class="normaltext">
                                                                <%=objlang.GetValueOnLang("Category Name")%></span>
                                                        </div>
                                                        <div class="box">
                                                            <asp:TextBox ID="txtPriceCatalogueCategoryName" SkinID="textPad" Width="180px" runat="server"
                                                                MaxLength="50"></asp:TextBox>
                                                            <span id="spn_txtPriceCatalogueCategoryName" class="spanerrorMsg" style="display: none; width: 175px;">
                                                                <%=objlang.GetValueOnLang("Please enter Category Name")%></span>
                                                        </div>
                                                    </div>
                                                    <div align="left">
                                                        <div class="bglabelEmpty">
                                                        </div>
                                                        <div class="box">
                                                            <asp:Button CssClass="NewButton" ID="btnCategorySave" OnClick="btnCategorySave_OnClick"
                                                                runat="server" Text="Save" />
                                                        </div>
                                                    </div>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:DropDownList ID="ddlPriceCatalogueCategory" runat="server" CssClass="textboxnew"
                                            onchange="OnChange_ddlPriceCatalogueCategory(this.value);" Width="405px">
                                        </asp:DropDownList>
                                        <div style="clear: both">
                                        </div>
                                        <span id="spn_ddlPriceCatalogueCategory" class="spanerrorMsg" style="display: none; width: 175px;">
                                            <%=objlang.GetValueOnLang("Please select Category Name")%></span>
                                        <asp:HiddenField ID="hid_CategoryID" runat="server"></asp:HiddenField>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 30px;">
                                            <asp:Label ID="txt_lblItemtitle1" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox runat="server" ID="txtCatalogueName" SkinID="textPad" Style="display: block;"
                                                    onblur="CallonBlur(this.value,'spn_txtCatalogueName');" Width="95%" TextMode="MultiLine"
                                                    Height="30px"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtCatalogueName" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" id="spn_Item_Name_Validation" runat="server"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--changes for editable and noneditable added by rakshith on 10-jan-2013 --%>
                                    <div class="onlyEmpty" id="diveditableproduct" runat="server">
                                        <div id="divproductType" runat="server" class="bglabel" style="height: 55px">
                                            <asp:Label ID="lblProductType" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 60%;">
                                            <div id="divNonEditable" runat="server" style="float: left">
                                                <asp:RadioButton ID="rdbnoneditable" ForeColor="Black" Text="Non Editable" onclick="javascript:StockEnable();"
                                                    GroupName="editcheck" Checked="true" runat="server" />
                                            </div>
                                            <div>
                                                <asp:RadioButton ID="ChkEditableProduct" runat="server" ForeColor="Black" GroupName="editcheck"
                                                    Text="Editable" onclick="javascript:StockEnable();" />
                                            </div>
                                            <div id="div_stockcontentdiv" runat="server" style="float: left; margin-top: 3px; display: none"
                                                class="onlyEmpty">
                                                <div style="float: left">
                                                    <div style="float: left">
                                                        <asp:CheckBox ID="chkstockitem" ForeColor="Black" Text="This is a Stock Item" onclick="javascript:showstockbtn();"
                                                            runat="server" />
                                                        <%---  onclick="javascript:showstocklnk();"--%>
                                                    </div>
                                                    <div class="box" style="float: left; margin-left: 4px; width: 126px">
                                                        <asp:CheckBox ID="chkbackorders" ForeColor="Black" Text="Allow Back Orders" runat="server"
                                                            onclick="javascript:CheckMainStockCheckbox(this.id);showstockbtn();" />
                                                    </div>
                                                    <div id="div_managestock" runat="server" style="float: left; padding-left: 8px; padding-top: 5px; display: none;">
                                                        <a href="javascript:void(0);" onclick="javascript:addstock(<%=ProductCatalogueID %>);return false;">
                                                            <%=objlang.GetLanguageConversion("Manage_Stock")%></a>
                                                    </div>
                                                    <div id="div_stocklinkcontactmsg" runat="server" class="smallerfontgrey" style="float: left; margin-left: 4px; margin-top: -12px; display: none">
                                                        <br />
                                                        <asp:Label ID="lblManageStockPleaseNote" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <br />
                                            </div>
                                            <div id="div_ManageStockMsg" runat="server" style="float: left; width: 94%; margin-left: 1%; margin-top: 6px; display: none"
                                                class="smallerfontgrey">
                                                <asp:Label ID="lblEdiatableTemplatePleaseNote" runat="server" Style="width: 100%;"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--added by rakshith --%>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div class="onlyEmpty" id="div_ProductType" runat="server" style="display: none">
                                        <div class="bglabel">
                                            <asp:Label ID="lblPRoductType1" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div style="float: left; width: 30%;">
                                                <div style="float: left; width: 25%;">
                                                    <asp:RadioButton ID="rbn_Editable" runat="server" GroupName="ProductType" onclick="StockItem('e');"
                                                        Checked="true" />
                                                </div>
                                                <div style="float: left; width: auto; margin: 3px 0px 0px 0px">
                                                    <asp:Label ID="lbl_Editable" runat="server" Text="Editable"></asp:Label>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 65%;">
                                                <div style="float: left; width: 12%;">
                                                    <asp:RadioButton ID="rbn_Noneditable" runat="server" GroupName="ProductType" onclick="StockItem('n');" />
                                                </div>
                                                <div style="float: left; width: 85%; margin: 3px 0px 0px 0px">
                                                    <div>
                                                        <asp:Label ID="lbl_Noneditable" runat="server" Text="Non editable"></asp:Label>
                                                    </div>
                                                    <div id="div_StockItem" style="display: none;">
                                                        <div style="float: left; width: 15%; margin: 0px 0px 0px -4px">
                                                            <asp:CheckBox ID="chk_Noneditable" runat="server" Checked="true" />
                                                        </div>
                                                        <div style="float: left; width: auto; margin: 3px 0px 0px 0px">
                                                            <asp:Label ID="lbl_NoneditableStockItem" runat="server" Text="This is stock item"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div class="onlyEmpty" style="display: none;">
                                        <div class="bglabel">
                                            <asp:Label ID="txt_lblItemtitle" runat="server"></asp:Label>
                                        </div>
                                        <div class="box">
                                            <asp:TextBox ID="txtItemTitle" runat="server" SkinID="textPad" Width="250px" MaxLength="50"></asp:TextBox>
                                            <span id="spn_txtItemTitle" class="spanerrorMsg" style="display: none; width: 250px"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                    <div id="divDrawStockFrom" runat="server" class="onlyEmpty" style="display: none;">
                                        <div class="bglabel">
                                            <asp:Label ID="lblDrawstockFrom" runat="server"><%=objlang.GetLanguageConversion("Draw_Stock_From")%></asp:Label>
                                            <span style="color: red;" id="spnDSFMandatory">*</span>
                                        </div>
                                        <div class="box">
                                            <asp:DropDownList ID="ddldrawstockfrom" Width="405px" runat="server" CssClass="textboxnew" Enabled="false">
                                                <asp:ListItem Value="select" Text="--- Select ---" Selected="True">--- Select ---</asp:ListItem>
                                                <asp:ListItem Value="self" Text="Self">This Product</asp:ListItem>
                                                <asp:ListItem Value="otherproducts">Other Products</asp:ListItem>
                                                <asp:ListItem Value="additionaloptions">Additional Options</asp:ListItem>
                                                <asp:ListItem Value="othermultiple">Other multiple existing products </asp:ListItem>
                                                <asp:ListItem Value="simplestock">Simple Stock </asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <span id="spn_DrawStockFromError" class="spanerrorMsg" style="display: none; width: 188px;">Please select draw stock from
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 50.5%; float: left;">
                                    <div class="onlyEmpty" id="divitemcode" runat="server">
                                        <div class="bglabel">
                                            <asp:Label ID="lblItem_Code" runat="server"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox runat="server" ID="txtitemcode" SkinID="textPad" Style="display: block;"
                                                    MaxLength="50" onkeyup="CheckPricecatalogue(this.value);" onblur="CheckPricecatalogue(this.value);CallonBlur(this.value,'spn_txtitemcode');"
                                                    Width="95%"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtitemcode" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" id="spn_Item_Code_Entry_Validation"
                                                        runat="server"></span>
                                                </div>
                                            </div>
                                            <div id="spn_txtitemcodeCheck" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" id="spn_Item_code_Exists_Validation"
                                                        runat="server"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <div style="float: left; padding-left: 4px; display: none" nowrap="nowrap;">
                                                    <div style="float: left; display: none;" id="div_DeleteCategory">
                                                        <asp:LinkButton ID="lnkCategoryDelete" OnClick="OnClick_lnkCategoryDelete" runat="server"
                                                            OnClientClick="DeleteCategory()"><b><%=objlang.GetValueOnLang("Delete")%></b></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="bglabel">
                                                    <div style="float: left">
                                                        <asp:Label ID="lblcustcode" runat="server"><%=objLanguage.GetLanguageConversion("p_Customer_code")%></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtcustomercode" Width="97%" CssClass="textboxnew" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="bglabel">
                                                    <div style="float: left">
                                                        <asp:Label ID="Label2" runat="server"><%=objlang.GetLanguageConversion("Supplier")%></asp:Label>
                                                    </div>
                                                    <div style="float: right">
                                                        <asp:ImageButton Style="vertical-align: top" ID="ImageButton8" Visible="true" runat="server"
                                                            CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                                            OnClientClick="javascript:openpopup_Supplier();"></asp:ImageButton><%--OnClick="ImageButton8_Click"  --%>
                                                    </div>
                                                    <div style="float: right">
                                                        <asp:ImageButton Style="vertical-align: top" ID="ImageButtonPlus" Visible="false"
                                                            runat="server" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add a new supplier"
                                                            OnClientClick="javascript:ImageButtonPlus_Click();return false"></asp:ImageButton>
                                                    </div>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddlSupplier" CssClass="textboxnew" runat="server" Width="415px"
                                                        onchange="javascript:GetSupplier();return false;">
                                                    </asp:DropDownList>
                                                    <span id="Span2" class="spanerrorMsg" style="display: none; width: 175px;" runat="server"></span>
                                                </div>

                                                <div class="bglabel">
                                                    <asp:Label ID="lblSalestaxrate" runat="server"><%=objlang.GetLanguageConversion("Sales_Tax_Rate")%></asp:Label>
                                                    <%--<span style="color: red;" id="spnSalestax">*</span>--%>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddl_SaleTaxRate" Width="415px" runat="server" CssClass="textboxnew">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <span id="spn_Salestaxrate" class="spanerrorMsg" style="display: none; width: 175px;">
                                                        <%=objlang.GetLanguageConversion("Please_Select_Sales_Tax_Rate")%></span>
                                                    <asp:HiddenField ID="hdn_SalesTaxRate" runat="server" Value="" />
                                                    <asp:HiddenField ID="hdn_CountryName" runat="server" Value="" />
                                                </div>


                                                <%-- Start --%>

                                                <div class="bglabel">
                                                    <asp:Label ID="lblAccountingCode" runat="server">Sales Accounting Code</asp:Label>
                                                    <span style="color: red;" id="spnAccountingCode"></span>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddl_AccountingCode" Width="415px" runat="server" CssClass="textboxnew">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:HiddenField ID="hdn_AccountingCode" runat="server" Value="" />
                                                </div>
                                                <%-- End --%>

                                                <%-- Start --%>

                                                <div class="bglabel">
                                                    <asp:Label ID="lblPurchaseAccountingCode" runat="server">Purchase Accounting Code</asp:Label>
                                                    <span style="color: red;" id="spnPurchaseAccountingCode"></span>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddl_PurchaseAccountingCode" Width="415px" runat="server" CssClass="textboxnew">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:HiddenField ID="hdn_PurchaseAccountingCode" runat="server" Value="" />
                                                </div>
                                                <%-- End --%>

                                                <div class="bglabel">
                                                    <asp:Label runat="server" ID="lblPressName"><%=objlang.GetLanguageConversion("Press_Name")%></asp:Label>
                                                </div>


                                                <div class="box">
                                                    <asp:DropDownList ID="ddlPressName" Width="415px" runat="server" CssClass="textboxnew">
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                                <div class="bglabel" style="text-align: left; float: left; width: 28%">
                                                    <asp:Label ID="lblproductthumbnail" runat="server" Text="Product Thumbnail"><%=objlang.GetLanguageConversion("Product_ThumbNail") %></asp:Label>
                                                    <a href="javascript:void(0);" id="img_thumbNail" runat="server" title="1.The standard Thumbnail size in the catagory screen is 200 x 150 pixels<br>2.If you upload an image which is smaller than this it won't be upsized<br>3.If you upload an image which is larger it will be resized to 200 x 150 pixels<br>4.When the user has selected the product the Thumbnail in the product screen will display as 300 x 300 pixels and your Thumbnail image will be resized to 300 x 300px">
                                                        <img alt="" id="img_help_productthumbnail" runat="server" src="../images/Help-icon.png"
                                                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green; float: right;"
                                                            class="tooltip" /></a>
                                                </div>
                                                <div class="box" style="text-align: left; float: left; width: auto;">
                                                    <div align="left" style="padding-top: 8px">
                                                        <a runat="server" id="ancUploadimage" href="javascript:void(0);" onclick="javascript:openPopupCrop();">
                                                            <%=objlang.GetLanguageConversion("Upload_Image") %></a>
                                                        <asp:HiddenField ID="hidmode" runat="server" />
                                                        <div id="div_uploadedimagename" style="display: none">
                                                            <a href="javascript:void(0);" id="lnkUpimagepath" runat="server"></a>
                                                        </div>
                                                        <asp:Label ID="lblProductImage" runat="server" Style="display: none" CssClass="Normaltext"></asp:Label>
                                                        <asp:HiddenField ID="hid_ProductImage" runat="server" Value="" />
                                                    </div>
                                                    <span id="spn_uplImage" class="spanerrorMsg" style="display: none; width: auto;">
                                                        <%=objlang.GetLanguageConversion("Please_upload_only_image_file")%>
                                                    </span>
                                                    <div class="onlyEmpty">
                                                    </div>
                                                </div>
                                                <div class="onlyEmpty" id="divDefaultPreflightProfile" runat="server" style="display: none">
                                                    <div class="bglabel">
                                                        <div style="float: left">
                                                            <asp:Label ID="lblDefaultPreflightProfile" runat="server"><%=objlang.GetLanguageConversion("Default_Preflight_Profile")%></asp:Label>
                                                        </div>
                                                        <a href="javascript:void(0);" id="A2" runat="server" title="Select which Pitstop profile to use when the end user uploads artwork PDF files into the job at the time of ordering">
                                                            <img alt="" id="img1" runat="server" src="../images/Help-icon.png"
                                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green; float: right;"
                                                                class="tooltip" /></a>

                                                    </div>
                                                    <div class="box">
                                                        <asp:DropDownList ID="ddlDefaultPreFlightProfile" CssClass="textboxnew" runat="server" Width="415px">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div style="width: 49%; float: left; padding-top: 1px;">
                            <div runat="server" id="div_AccountCode" visible="false">
                                <div class="onlyEmpty">
                                    <div class="bglabel">
                                        <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code"></asp:Label>
                                    </div>
                                    <div class="ddlsetting" style="width: 55%;">
                                        <asp:DropDownList ID="ddlAccountCode" runat="server" Width="95%" CssClass="normalText">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--===== Added Description FieldSet by Shivappa ====--%>
                        <div align="left" style="width: 100%; float: left;">
                            <fieldset>
                                <legend>
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </legend>
                                <div style="width: 49%; float: left; border: 0px solid;">
                                    <%-- Left Pannel--%>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 112px">
                                            <asp:Label ID="txt_lblDescription" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtDescription" Width="95%" Height="113px" SkinID="textPad" runat="server"
                                                    TextMode="MultiLine" MaxLength="100" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');copytoTextArea(this,this.value);"
                                                    onblur="copytoTextArea(this,this.value);" CssClass="textboxnew1"> </asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtDescription_length" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px">
                                                        <asp:Label ID="lblMaxLenghtText2" runat="server"></asp:Label></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblArtwork" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtArtwork" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    CssClass="textboxnew1" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtArtwork" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" runat="server" id="spn_Arkwork_Validation"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblColour" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtColour" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtColour" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" id="spn_colour_Validation" runat="server">
                                                        <%--<%=colorformat%>--%>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblSize" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtSize" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <div style="clear: both">
                                            </div>
                                            <div id="spn_txtSize" style="display: none; width: 180px; float: left">
                                                <div class="RFV_Message">
                                                    <span style="float: left; padding-left: 4px" id="spn_Size_Validation" runat="server"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblMaterial" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtMaterial" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 51%; float: right; border: 0px solid;">
                                    <%-- Right Pannel--%>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblDelivery" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtDelivery" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <span id="spn_txtDelivery" class="spanerrorMsg" style="display: none; width: 250px"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblFinishing" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtFinishing" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                            <span id="spn_txtFinishing" class="spanerrorMsg" style="display: none; width: 250px"
                                                runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblProofs" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtProofs" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblPacking" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtPacking" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblNotes" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtNotes" Width="95%" Height="50px" SkinID="textPad" runat="server"
                                                    CssClass="textboxnew1" TextMode="MultiLine" MaxLength="2000" onkeyup="javascript:sizelimit(this,'spn_txtNotes_length');">
                                                </asp:TextBox>
                                            </div>
                                            <span id="spn_txtNotes_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                                <%=objlang.GetValueOnLang("Max. length of textbox is")%>: 3000</span>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="txt_lblInstructions" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtInstructions" Width="95%" Height="50px" SkinID="textPad" runat="server"
                                                    CssClass="textboxnew1" TextMode="MultiLine" MaxLength="2000" onkeyup="javascript:sizelimit(this,'spn_txtInstructions_length');">
                                                </asp:TextBox>
                                            </div>
                                            <span id="spn_txtInstructions_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                                <%=objlang.GetValueOnLang("Max. length of textbox is")%>: 3000</span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_1" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom1" Text="Custom Description 1" runat="server"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom1" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom2" runat="server" Text="Custom Description 2"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom2" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_2" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom3" runat="server" Text="Custom Description 3"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom3" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom4" runat="server" Text="Custom Description 4"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom4" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_3" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom5" runat="server" Text="Custom Description 5"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom5" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom6" runat="server" Text="Custom Description 6"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom6" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_4" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="display: inline; float: left; width: 49%">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom7" runat="server" Text="Custom Description 7"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom7" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: inline; float: left; width: 51%">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom8" runat="server" Text="Custom Description 8"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom8" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_5" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="display: inline; float: left; width: 49%">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom9" runat="server" Text="Custom Description 9"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom9" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: inline; float: left; width: 51%">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom10" runat="server" Text="Custom Description 10"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom10" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_6" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom11" runat="server" Text="Custom Description 11"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom11" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom12" runat="server" Text="Custom Description 12"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom12" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_7" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom13" runat="server" Text="Custom Description 13"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom13" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom14" runat="server" Text="Custom Description 14"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom14" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_8" runat="server" class="onlyEmpty" style="display: none; width: 100%">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom15" runat="server" Text="Custom Description 15"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom15" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom16" runat="server" Text="Custom Description 16"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom16" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_9" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom17" runat="server" Text="Custom Description 17"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom17" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom18" runat="server" Text="Custom Description 18"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom18" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_10" runat="server" class="onlyEmpty" style="width: 100%; display: none;">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom19" runat="server" Text="Custom Description 19"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom19" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom20" runat="server" Text="Custom Description 20"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom20" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_11" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom21" runat="server" Text="Custom Description 21"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom21" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom22" runat="server" Text="Custom Description 22"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom22" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_12" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom23" runat="server" Text="Custom Description 23"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom23" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="float: left; width: 51%; display: inline">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom24" runat="server" Text="Custom Description 24"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom24" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divcd_13" runat="server" class="onlyEmpty" style="width: 100%; display: none">
                                    <div style="float: left; width: 49%;">
                                        <div class="bglabel" style="height: 50px">
                                            <asp:Label ID="lblCustom25" runat="server" Text="Custom Description 25"></asp:Label>
                                        </div>
                                        <div class="box" style="width: 55%;">
                                            <div>
                                                <asp:TextBox ID="txtCustom25" runat="server" SkinID="textPad" Width="95%" Height="50px"
                                                    TextMode="MultiLine" MaxLength="5000" CssClass="textboxnew1"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="onlyEmpty" style="width: 100%" align="right">
                                    <div class="bglabel" style="width: 63.4%; visibility: hidden">
                                    </div>
                                    <div class="box" style="width: 145px; text-align: left">
                                        <a id="A1" name="addmore" style="cursor: pointer; color: #10357F" onclick="javascript:AddCustomDescriptionrow();"
                                            runat="server">
                                            <%=objlang.GetLanguageConversion("Add_More_Descriptions") %></a>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <%--=====End of Description FieldSet by Shivappa ====--%>



                        <%-- Start CBM Fieldset --%>

                        <div id="divCBMActive" visible="false" runat="server" align="left" style="width: 100%; float: left;">
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label4" runat="server">Dimensions</asp:Label>

                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </legend>
                                <div style="width: 49%; float: left;">

                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label5" runat="server">Length</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxLength" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersCBM(this);"></asp:TextBox>
                                    </div>
                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label7" runat="server">Height</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxHeight" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersCBM(this);"></asp:TextBox>
                                    </div>
                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label12" runat="server">Per Quantity</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxPerQuantity" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersCBM(this);"></asp:TextBox>
                                    </div>
                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label9" runat="server">Cubic Measurement</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box" id="divCBM">
                                        <asp:TextBox ID="TextBoxCBM" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateIsNumber(this);"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="width: 50.5%; float: left;">
                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label6" runat="server">Width</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxWidth" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersCBM(this);"></asp:TextBox>
                                    </div>



                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label8" runat="server" />

                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxWeight" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersCBM(this);"></asp:TextBox>
                                    </div>

                                    <div class="bglabel">
                                        <div style="float: left">
                                            <asp:Label ID="Label11" runat="server">Volumetric Weight</asp:Label>
                                        </div>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBoxVolumetricWeight" Width="97%" CssClass="textboxnew" runat="server" onblur="ValidateNumbersVW(this);"></asp:TextBox>
                                    </div>

                                    <div class="bglabel" style="width: 28%;">
                                        <span id="spn">Override Cubic Measurement</span>
                                    </div>

                                    <div class="box" style="float: left; width: auto;">
                                        <input runat="server" id="chkCRMOverride" type="checkbox" checked="checked" name="CRMOverride" onclick="enableDisableCBM(this)" />

                                    </div>
                                </div>
                            </fieldset>
                        </div>

                        <%-- End CBM Fieldset --%>

                        <%--===== Added Allocation FieldSet by Shivappa ====--%>
                        <div align="left" style="width: 100%; float: left;">
                            <fieldset>
                                <legend>
                                    <asp:Label ID="lblAllocation" runat="server"></asp:Label>
                                </legend>
                                <div style="width: 49%; float: left; border: 0px solid;">
                                    <%-- Left Pannel--%>
                                    <%--added by rakshith --%>
                                    <div id="divOwnership" runat="server" class="onlyEmpty" style="display: none">
                                        <div class="bglabel">
                                            <div style="float: left; width: 5%; height: 75px;">
                                                <span>
                                                    <asp:Label ID="lblOwnerShip" runat="server"></asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                        <div id="div4" class="box" style="display: block;">
                                            <asp:ListBox ID="lstownership" runat="server" onclick="javascript:ownership_onchange();"
                                                CssClass="textboxnew1" SelectionMode="Single" Width="97%" Height="83px"></asp:ListBox>
                                            <div style="color: Gray" font-size="10px">
                                                <%=objlang.GetLanguageConversion("For_use_with_stock_items_owned_by_your_customers") %>.
                                            </div>
                                        </div>
                                    </div>
                                    <%--added by rakshith --%>
                                    <div class="onlyEmpty" id="div_catagoryType" runat="server">
                                        <div class="bglabel">
                                            <div style="float: left; width: 5%; height: 50px;">
                                                <span>
                                                    <asp:Label ID="lblCustomers" runat="server"></asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                        <div align="left" style="float: left; width: 50%;">
                                            <div id="div_None" align="left" style="height: 20px;">
                                                <div style="float: left; width: 5%; cursor: pointer;">
                                                    <asp:RadioButton ID="rdCustomerNone" GroupName="Customer" Checked="true" runat="server"
                                                        Onclick="ShowHideDiv('N')" />
                                                </div>
                                                <div style="float: left; white-space: normal; padding-top: 3px;">
                                                    <span>&nbsp;&nbsp;<asp:Label ID="lblCustomerNone" runat="server"></asp:Label></span>
                                                </div>
                                            </div>
                                            <div id="div_SpecificToCustomers" align="left" class="onlyEmpty" style="height: 20px;">
                                                <div style="float: left; cursor: pointer;">
                                                    <asp:RadioButton ID="rdSelectedCustomer" GroupName="Customer" Text="" runat="server"
                                                        Onclick="ShowHideDiv('S')" />
                                                </div>
                                                <div style="float: left; width: 140px; white-space: normal; padding-top: 3px;">
                                                    <span>&nbsp;<asp:Label ID="lblSpecificToCustomer" runat="server"></asp:Label></span>
                                                </div>
                                                <div style="float: left; padding-top: 4px;">
                                                    <span style="float: left;" id="spnSelectedCustomer" class="smallgraytext">&nbsp;</span>
                                                </div>
                                                <div id="div_selectLnk" style="float: left; padding-left: 5px; padding-top: 3px; display: none;">
                                                    <a id="Select" runat="server" href="javascript:void(0);">
                                                        <%=objlang.GetLanguageConversion("Select") %></a>
                                                    <%--onclick="javascript:openPopUp('I','<%=ProductCatalogueID %>','<%=hdn_itemtitle.Value %>','<%=action %>');"--%>
                                                </div>
                                            </div>
                                            <div id="div_All" align="left" class="onlyEmpty" style="height: 20px;">
                                                <div style="float: left; cursor: pointer;">
                                                    <asp:RadioButton ID="rdSelectedAll" GroupName="Customer" Text="" runat="server" Onclick="ShowHideDiv('A')" />
                                                </div>
                                                <div style="float: left; width: 140px; white-space: normal; padding-top: 3px;">
                                                    <span>&nbsp;<asp:Label ID="lblCustomerSelectedAll" runat="server"></asp:Label></span>
                                                </div>
                                                <div id="div_ExcludeLnk" style="float: left; padding-left: 5px; padding-top: 3px; display: none;">
                                                    <a id="Exclude" runat="server" href="javascript:void(0);">
                                                        <%=objlang.GetLanguageConversion("Exclude") %></a>
                                                    <%--onclick="javascript:openPopUp('E','<%=ProductCatalogueID %>','<%=hdn_itemtitle.Value %>','<%=action %>');"--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_PublicAccounts" style="width: 51%; float: right; margin-top: 2px; border: 0px solid;">
                                    <%-- Right Pannel--%>
                                    <div class="onlyEmpty">
                                        <div class="bglabel" style="height: 90px">
                                            <%=objlang.GetLanguageConversion("Public_Accounts")%>
                                        </div>
                                        <div id="div_NoPublicAccount" runat="server" class="box smallgraytext" style="width: 55%; display: none;">
                                            <asp:Label ID="lblPublicAccount" runat="server" Text="Not applicable to your system. Contact support for more information"></asp:Label>
                                        </div>
                                        <div id="publicAccount_label" runat="server" class="box" style="width: 55%; display: none;">
                                            <div id="div_listbox" style="display: block;">
                                                <telerik:RadListBox ID="lstStatus" runat="server" SelectionMode="Multiple" CheckBoxes="true"
                                                    Width="100%" Height="98px" Style="overflow: auto">
                                                    <Items>
                                                    </Items>
                                                </telerik:RadListBox>
                                                <%-- <asp:ListBox ID="lstAccountPublic" runat="server" CssClass="textboxnew1" SelectionMode="Multiple"
                                                        Width="97%" Height="83px" onclick="CheckForNone('accounts');"></asp:ListBox>--%>
                                            </div>
                                            <div style="clear: both;">
                                            </div>
                                            <%-- <div style="float: left; margin: 0px 10px 0px 0px">
                                                    <a href="javascript:void(0);" id="href_selectAll_Public" onclick="selectAll_onclick('public','yes')"
                                                        runat="server" style="display: block;">
                                                        <%=objlang.GetLanguageConversion("Select_All") %>
                                                    </a><a href="javascript:void(0);" id="href_selectNone_Public" onclick="selectAll_onclick('public','no')"
                                                        runat="server" style="display: none;">
                                                        <%=objlang.GetLanguageConversion("None") %>
                                                    </a>
                                                </div>
                                                <div style="float: left; color: Gray; font-size: 10px">
                                                    (<%=objlang.GetLanguageConversion("Use_Ctrl_For_Multiple_Seletion")%>)
                                                </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <%--===== End of Allocation FieldSet by Shivappa ====--%>
                        <div class="only5px">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                    <div class="only5px">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div align="left" style="width: 100%; float: left">
                        <div style="float: left; width: 49%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 49%;">
                            <div class="box" style="width: 80%;">
                                <div align="left">
                                    <div style="float: left">
                                        <div id="div_btncancel" style="display: block">
                                            <asp:Button CssClass="NewButton" ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel"
                                                CausesValidation="false" OnClick="btnCancel_OnClick" OnClientClick="loadingimage(this.id,'div_btncancelmain')" />
                                        </div>
                                        <div id="div_btncancelmain" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <asp:Button CssClass="NewButton" ID="btnNext1" runat="server" Text="Next" OnClientClick="javascript:btnNext_Page('1','2');return false;" />
                                    </div>
                                    <div id="div_btngeneral" runat="server" style="float: left; display: none">
                                        <div style="float: left; margin-left: 10px;">
                                            <div style="display: block">
                                                <asp:Button CssClass="NewButton" ID="btngenstay" Text="Save & Stay" runat="server" />
                                                <asp:LinkButton ID="lnkgensavestay" OnClick="lnkgensavestay_Onclick" runat="server"></asp:LinkButton>
                                            </div>
                                            <div id="div_gensavestayprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; margin-left: 10px;">
                                            <div style="display: block">
                                                <asp:Button CssClass="NewButton" ID="btngensave" Text="Save" runat="server" />
                                                <asp:LinkButton ID="lnkgensave" OnClick="lnkgensave_Onclick" runat="server"></asp:LinkButton>
                                            </div>
                                            <div id="div_btngensaveprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div id="div_genmanagestock" style="float: left; margin-left: 10px; display: none">
                                            <div>
                                                <asp:Button CssClass="NewButton" ID="btngenmanagestock" Text="Save & Manage Stock"
                                                    runat="server" />
                                            </div>
                                            <div id="div_gensavestockprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="only5px">
                    </div>
                    <%--====================decoration=======================--%>
                </div>
                <div style="clear: both;">
                </div>
                <div style="clear: both;">
                </div>
                <div id="div_PricDecoration" style="display: none">
                    <div style="float: left; width: 49%; padding-top: 1px;">

                        <div id="div8" runat="server" style="display: none;">
                            <div class="bglabel" style="float: left; text-align: left">
                                <%=objlang.GetValueOnLang("Show Sides")%>
                            </div>
                            <div align="left" class="box">
                                <asp:CheckBox ID="CheckBox2" runat="server" Checked="true" />
                            </div>
                        </div>
                    </div>
                    <div class="only5px">
                        &nbsp;&nbsp;
                    </div>
                    <table>

                        <tr>
                            <td></td>
                            <td style="white-space: normal; width: 150px;">
                                <asp:TextBox runat="server" Text="Decoration1" ID="txtdecoration1_title" /></td>
                            <td>
                                <asp:TextBox runat="server" Text="Decoration2" ID="txtdecoration2_title" /></td>
                            <td>
                                <asp:TextBox runat="server" Text="Decoration3" ID="txtdecoration3_title" /></td>
                            <td>
                                <asp:TextBox runat="server" Text="Decoration4" ID="txtdecoration4_title" /></td>
                            <td>
                                <asp:TextBox runat="server" Text="Decoration5" ID="txtdecoration5_title" /></td>
                            <td>
                                <asp:TextBox runat="server" Text="Decoration6" ID="txtdecoration6_title" /></td>
                        </tr>

                        <tr>
                            <td>Name</td>
                            <td style="white-space: normal; width: 150px;">
                                <asp:TextBox runat="server" ID="Decoration1_Name" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration2_Name" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration3_Name" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration4_Name" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration5_Name" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration6_Name" /></td>
                        </tr>
                        <tr>
                            <td style="white-space: normal; width: 150px;">Description</td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration1_Description" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration2_Description" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration3_Description" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration4_Description" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration5_Description" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration6_Description" /></td>

                        </tr>
                        <tr>
                            <td style="white-space: normal; width: 150px;">Setup Cost $</td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration1_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration2_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration3_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration4_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration5_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration6_SetupCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                        </tr>
                        <tr>
                            <td style="white-space: normal; width: 150px;">Per Item Cost $</td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration1_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration2_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration3_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration4_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration5_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration6_PerItemCost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                        </tr>
                        <tr>
                            <td style="white-space: normal; width: 150px;">Minimum cost $</td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration1_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration2_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration3_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration4_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration5_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                            <td>
                                <asp:TextBox runat="server" ID="Decoration6_Minimumcost" onblur="ValidateNumbersCBM(this);" Text="0" /></td>
                        </tr>
                        <tr>
                            <td style="white-space: normal; width: 150px;">Mandatory</td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration1_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration2_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration3_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration4_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration5_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDecoration6_Mandatory" runat="server" CssClass="textboxnew">
                                </asp:DropDownList>

                            </td>
                        </tr>

                    </table>
                    <div class="only5px">
                    </div>

                    <div class="only5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="width: 100%">
                        <div style="width: 54%; float: left">
                            &nbsp;
                        </div>
                        <div style="width: 40%; float: left;">
                            <div style="float: left">
                                <asp:Button ID="btnDecorationPre" runat="server" CssClass="NewButton" Text="Previous"
                                    OnClientClick="javascript:btnNext_Page('3','2');return false;" CausesValidation="false" />
                            </div>
                            <div style="float: left; padding-left: 10px">
                                <asp:Button ID="Button2" runat="server" CssClass="NewButton" Text="Next" OnClientClick="javascript:gettabs('ac');return false;" />
                            </div>
                            <div style="float: left; padding-left: 10px" runat="server">
                                <div id="div_btndecorationsavestay" style="display: block" runat="server">
                                    <asp:Button ID="BtnDecorationSaveAndStay" runat="server" CssClass="NewButton" Text="Save & Stay" OnClick="lnkDecorationSaveAndStay_Click" />
                                    <asp:LinkButton ID="lnkDecorationSaveAndStay" runat="server"></asp:LinkButton>
                                </div>
                                <div id="div_btndecorationsavestayprocess" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="float: left; padding-left: 10px" runat="server">
                                <div id="div_btndecorationsave" style="display: block" runat="server">
                                    <asp:Button ID="BtnDecorationSave" runat="server" CssClass="NewButton" Text="Save" OnClick="lnkDecorationSave_Click" />
                                    <asp:LinkButton ID="lnkDecorationSave" runat="server"></asp:LinkButton>
                                </div>
                                <div id="div_btndecorationsaveprocess" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                </div>

                <div class="only5px">
                </div>
                <%--====================price=======================--%>
                <%---------------------------------FTP---------------------------------------%>
                <div id="div_FTP" style="display: none" class="ftp-tab">


                    <asp:Panel ID="pnlFtpTab" runat="server" CssClass="ftp-panel">
                        <table>
                            <tr>
                                <td style="width: 100px;"><strong>File Type:</strong></td>
                                <td>
                                    <asp:RadioButton ID="rdoEditable" runat="server" GroupName="FileType" onclick="toggleFileUI();" Text="Editable Product" />
                                    &nbsp;&nbsp;
                                    <asp:RadioButton ID="rdoPrintReady" runat="server" GroupName="FileType" onclick="toggleFileUI();" Text="Print Ready File" />
                                    &nbsp;&nbsp;
                <asp:RadioButton ID="rdoFTPFile" runat="server" GroupName="FileType" onclick="toggleFileUI();" Text="FTP File" />
                                </td>
                            </tr>
                            <tr style="height: 10px;"></tr>
                                    <tr id="fileControlsRow">

                                        <td><strong>Upload File:</strong></td>
                                        <td>
                                            <asp:FileUpload ID="fileUploader" style="margin-left:5px;" runat="server" />
                                            <asp:HyperLink ID="lnkUploadedFile" runat="server" style="margin-left:5px;" Visible="false" Target="_blank"></asp:HyperLink>
                                            <asp:ImageButton ID="btnRemoveFTP" runat="server" ImageUrl="~/images/erase.png" Visible="false" OnClick="btnRemoveFTP_Click" ToolTip="Remove" style="cursor:pointer; margin-left: 10px; vertical-align:middle;" />
<%--                                            <img id="imgRemoveFTP" src="../images/erase.png" title="Remove" onclick="RemoveFTPImage();" style="cursor:pointer; margin-left: 10px; vertical-align:middle; width: 18px; height: 18px;" />--%>
                                        </td>
                                    </tr>
                        </table>

                        <h3 class="ftp-heading">FTP Folder Configuration</h3>

                        <!-- FTP Folder Dropdown -->
                        <div class="form-group">
                            <label for="<%= ddlFtpFolders.ClientID %>" class="form-label">Select FTP Folder:</label>
                            <%--                        <asp:DropDownList ID="ddlFtpFolders" runat="server" CssClass="form-control" onchange="validateFtpSettings();"/>--%>
                            <asp:DropDownList ID="ddlFtpFolders" runat="server" CssClass="form-control" />
                            <label id="spn_FTP" style="display: none; color: red;">
                                Please select an FTP folder.
                            </label>
                        </div>

                        <!-- Optional Prefix TextBox -->
                        <div class="form-group">
                            <label for="<%= txtPrefix.ClientID %>" class="form-label">Prefix for selected folder (optional):</label>
                            <asp:TextBox ID="txtPrefix" runat="server" CssClass="form-control1" Placeholder="Enter prefix..." />
                        </div>
                        <label>This prefix will be used if "Prefix" mode is selected under Filename Handling below.</label>
                        <hr class="separator" />

                        <!-- Tags Grid -->
                        <h4 class="ftp-subheading">Available FTP Filename Tags</h4>
                        <label>Use these tags in the "Prefix for selected folder" field.</label>
                        <asp:GridView ID="gvTags" runat="server" AutoGenerateColumns="false" CssClass="tag-table">
                            <Columns>
                                <asp:BoundField DataField="Tag" HeaderText="Tag" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                            </Columns>
                        </asp:GridView>


                    </asp:Panel>
                    <div class="only5px"></div>
                    <!-- Optional spacing divs (can be removed or replaced with CSS margin/padding) -->
                    <div class="only5px"></div>
                    <div class="only5px"></div>
                    <div style="width: 33%; float: right;">
                        <div style="float: left">
                            <asp:Button ID="btnFTPPrevious" runat="server" CssClass="NewButton" Text="Previous"
                                OnClientClick="javascript:gettabs('cc');return false;" CausesValidation="false" />
                        </div>
                        <div style="float: left; padding-left: 10px" runat="server">
                            <div id="div5" style="display: block" runat="server">
                                <%--  <asp:Button ID="btnFTPSaveStay" runat="server" CssClass="NewButton" Text="Save & Stay" OnClientClick="if(validateFtpSettings()){javascript:loadingimage(this.id,'div_btnFTPsavestayprocess');}else{return false;}"
                                        OnClick="lnkFTPSaveAndStay_Click" />--%>
                                <asp:Button ID="btnFTPSaveStay" runat="server" CssClass="NewButton" Text="Save & Stay"
                                    OnClick="lnkFTPSaveAndStay_Click" />
                                <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                            </div>
                            <div id="div_btnFTPsavestayprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="float: left; padding-left: 10px" runat="server">
                            <div id="div6" style="display: block" runat="server">
                                <%--                                    <asp:Button ID="btnFTPSave" runat="server" CssClass="NewButton" Text="Save" OnClientClick="if(validateFtpSettings()){javascript:loadingimage(this.id,'div_btnftpsaveprocess');}else{return false;}"  OnClick="lnkFTPSave_Click" />--%>
                                <asp:Button ID="btnFTPSave" runat="server" CssClass="NewButton" Text="Save" OnClick="lnkFTPSave_Click" />
                                <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                            </div>
                            <div id="div_btnftpsaveprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>

                    </div>
                    <div class="only5px"></div>
                    <div class="only5px"></div>

                </div>
                <%----------------------------End of FTP-------------------------------------%>
            </div>
            <div style="clear: both;">
            </div>
            <div style="clear: both;">
            </div>
            <div id="div_Pricemain" style="display: none">
                <div style="float: left; width: 49%; padding-top: 1px;">
                    <div class="bglabel" style="text-align: left">
                        <%=objlang.GetLanguageConversion("Price_Matrix_Type")%>
                    </div>
                    <div align="left" class="ddlsetting" style="width: 55%; margin-left: -2px;">
                        <asp:DropDownList ID="ddlMatrixType" onchange="MatrixTypeChange(this.value);ShowSoldInPacks();"
                            CssClass="normalText" runat="server" Width="65%">
                        </asp:DropDownList>
                    </div>
                    <div id="div_UnitOfMeasure" runat="server" style="display: none;">
                        <div class="bglabel" style="float: left; text-align: left">
                            <%=objlang.GetLanguageConversion("Unit_of_Measure")%>
                        </div>
                        <div align="left" class="box">
                            <asp:TextBox ID="txtUnitOfMeasure" runat="server" SkinID="textPad" Width="80px" MaxLength="8"
                                onblur="SetNumber_OfUnit(this,this.value);" onkeyup="ToInteger(this,this.value);"
                                Style="text-align: right" Text="1000"></asp:TextBox>
                            <span id="spn_UnitOfMeasure" class="spanerrorMsg" style="display: none; width: 150px;">
                                <%=objlang.GetLanguageConversion("Please_enter_integer_value")%>
                            </span>
                        </div>
                    </div>
                    <%--added by sharan--%>
                    <%--   style="display: none"--%>
                    <div id="div_SoldinPack" runat="server">
                        <div class="bglabel" style="float: left; text-align: left">
                            <%=objlang.GetLanguageConversion("Sold_in_Packs_of")%>
                        </div>
                        <div align="left" class="box">
                            <asp:TextBox ID="txt_SoldinPack" runat="server" SkinID="textPad" Width="80px" MaxLength="8"
                                onblur="SetDigit_ShowInPacks(this,this.value);" onkeyup="ToIntegerSolpacks(this,this.value);"
                                Style="text-align: right" Text="1"></asp:TextBox>
                            <span id="Span4" class="spanerrorMsg" style="display: none; width: 150px;">
                                <%=objlang.GetLanguageConversion("Please_enter_integer_value")%>
                            </span>
                        </div>
                    </div>
                    <div id="div_EnableCumulativePriceing" runat="server" style="display: none;">
                        <div class="bglabel" style="float: left; text-align: left">
                            <%=objlang.GetLanguageConversion("Enable_Cumulative_Pricing")%>
                        </div>
                        <div align="left" class="box" style="margin-left: -3px;">
                            <asp:CheckBox ID="chk_EnableCumulative_Priceing" Checked="false" runat="server" />
                        </div>
                    </div>
                    <%--End by sharan--%>
                    <div id="div_Sides" runat="server" style="display: none;">
                        <div class="bglabel" style="float: left; text-align: left">
                            <%=objlang.GetValueOnLang("Show Sides")%>
                        </div>
                        <div align="left" class="box">
                            <asp:CheckBox ID="chk_ShowSides" runat="server" Checked="true" />
                        </div>
                    </div>
                </div>
                <div class="only5px">
                    &nbsp;&nbsp;
                </div>
                <div style="width: 100%; float: left;">
                    <div class="onlyEmpty">
                        <div style="float: left; width: 98%">
                            <div align="left" class="borderWithoutTop" style="width: 100%;">
                                <table cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                                    <tbody id="PriceTable">
                                        <asp:PlaceHolder ID="plhCatalogue" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                            <asp:HiddenField ID="hid_Rows_On_Edit" runat="server" />
                            <asp:HiddenField ID="hid_data" runat="server" Value="" />
                            <div align="right" style="width: 100%;">
                                <table cellpadding="0" cellspacing="0" border="0px" align="right">
                                    <tr>
                                        <td style='width: 24%;' align='center'></td>
                                        <td style='width: 20%;' align='center'></td>
                                        <td style='width: 20%;' align='center'></td>
                                        <td style='width: 24%;' align='center'></td>
                                        <td style='float: right;' align='center' runat="server" id="ADD">
                                            <a id="href_add_more" name="addmore" style="display: none;" href='javascript:void(0);'
                                                onclick="Click_Add_More()">
                                                <%=objlang.GetLanguageConversion("Add_More") %></a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="only10px">
                    </div>
                    <div class="onlyEmpty" style="display: none;">
                        <div class="bglabel">
                            <%=objlang.GetValueOnLang("Price Matrix")%>
                        </div>
                        <div class="box">
                            <div align="left">
                                <asp:PlaceHolder ID="plhDisplay" runat="server"></asp:PlaceHolder>
                            </div>
                            <table id="tblHeader" align="left" cellspacing="1" border="0" width="75%" cellpadding="4">
                                <col width="15%" />
                                <col width="15%" />
                                <col width="3%" />
                                <tr class="label" height="23px">
                                    <td>
                                        <asp:Label ID="lblQuantity" runat="server" CssClass="HeaderText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="HeaderText"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div align="left" class="normaltext">
                                <div style="float: left; width: 25%;">
                                    &nbsp;
                                </div>
                                <div style="float: right;">
                                    <a href="javascript://" id="AddMore" name="AddMore" onclick="AddMoreItem('','');return false;">Add More </a>
                                </div>
                            </div>
                            <div class="onlyEmpty">
                                <span id="spn_txtQuantity_Number" class="spanerrorMsg" style="display: none; width: 175px;">
                                    <%=objlang.GetValueOnLang("Please enter Numeric Value")%>
                                </span><span id="spn_txtPrice_Number" class="spanerrorMsg" style="display: none; width: 175px;">
                                    <%=objlang.GetValueOnLang("Please enter Numeric Value")%></span>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; float: left">
                        <div>
                            <span class="graytext" id="spn_help_simplematrix" style="display: none;">
                                <%=objlang.GetValueOnLang("Matrix_Use_Note")%></span><span class="graytext" id="spn_help_pricebands"
                                    style="display: block;">
                                    <%-- <%=objlang.GetLanguageConversion("Price_Band_Use_Note")%>--%>
                                    <%=objlang.GetLanguageConversion("Product_Use_Note")%>
                                </span>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                        <div style="float: left; width: 49%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 49%" align="right">
                            <div class="bglabelEmpty">
                                &nbsp;
                            </div>
                            <div class="box" style="width: 90%; float: right" align="right">
                                <div align="left">
                                    <div style="float: left;">
                                        <asp:Button CssClass="NewButton" ID="btnPrevious1" runat="server" Text="Previous"
                                            OnClientClick="javascript:btnNext_Page('2','1');return false;" />
                                        <asp:HiddenField ID="hidPriceCatalogueID" Value="0" runat="server" />
                                        <asp:HiddenField ID="hidQtyPrice" Value="" runat="server" />
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <asp:Button CssClass="NewButton" ID="btnNext2" runat="server" Text="Next" Visible="false"
                                            OnClientClick="javascript:getactivetabDecoration('next');return false;" />
                                        <%-- <asp:Button ID="btnsave1" CssClass="button" runat="server" Text="Save" OnClick="OnClick_btnSave" />commented because 2 save buttons appearing--%>
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_pricebtnsavestay" style="display: block">
                                            <asp:Button ID="btnPriceSaveandStay" CssClass="NewButton" runat="server" Text="Save & Stay"
                                                Visible="false" />
                                            <asp:LinkButton ID="lnkPriceSaveandStay" runat="server" OnClick="OnClick_btnPriceSaveandStay"></asp:LinkButton>
                                        </div>
                                        <div id="div_pricesavestayprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_btnpricesave" style="display: block">
                                            <asp:Button ID="btnPriceSave" CssClass="NewButton" runat="server" Text="Save" Visible="false" />
                                            <asp:LinkButton ID="lnkPriceSave" runat="server" OnClick="OnClick_btnPriceSave"></asp:LinkButton>
                                        </div>
                                        <div id="div_btnpricesaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div id="divprice_savestock" style="float: left; padding-left: 10px; display: none">
                                        <div id="div_pricesavestock" style="display: block">
                                            <asp:Button ID="btnprice_managestock" CssClass="NewButton" runat="server" Text="Save & Manage Stock"
                                                Visible="true" />
                                            <asp:LinkButton ID="lnkprice_managestock" runat="server" OnClick="OnClick_btnprice_managestock"></asp:LinkButton>
                                        </div>
                                        <div id="div_pricemanagestock" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                                <div id="div_test_1" style="width: 100%; overflow: scroll; border: solid 1px blue; display: none">
                                    <div id="div_test_2" style="width: 100%; border: solid 1px red;">
                                        Loading...
                                    </div>
                                </div>
                                <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
            </div>
            <%--====================eStore Settings Changes on 31-01-12 by Shivappa=======================--%>
            <div id="div_ArtworkcanvasMain" style="display: none;">
                <div style="width: 100%; float: left; min-width: 1300px;">
                    <div style="width: 840px; float: left; vertical-align: top;">
                        <fieldset style="z-index: 100000;">
                            <legend>
                                <%=objlang.GetLanguageConversion("eStore_Description") %></legend>
                            <div style="width: 99%; float: left; border: solid 0px green;">
                                <div class="bglabel" style="text-align: left; float: left; width: 16%">
                                    <%=objlang.GetLanguageConversion("Short_description")%>
                                    <a id="img_Help_ShortDescritpion_Link" runat="server" href="javascript:void(0);"
                                        title="This appears in the Product Category Screen">
                                        <img alt="" id="img_help_ShortDescription" runat="server" src="../images/Help-icon.png"
                                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" /></a>
                                    <%-- </div>--%>
                                </div>
                                <div class="box" style="width: auto; float: left;">
                                    <div>
                                        <asp:TextBox ID="txtShortdescriprion" runat="server" Width="250px" Height="50px"
                                            SkinID="textPad" CssClass="textboxnew1" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </div>
                                <div class="bglabel" style="text-align: left; float: left; width: 16%">
                                    <%=objlang.GetLanguageConversion("Item_description")%>
                                    <a id="img_help_Item_Description_Link" runat="server" href="javascript:void(0);"
                                        title="This appears in the Product Details Screen">
                                        <img alt="" id="img_help_ItemDescription" runat="server" src="../images/Help-icon.png"
                                            style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" /></a>
                                </div>
                                <div style="float: left; width: auto;">
                                    <div id="div1" style="float: left; width: auto;">
                                        <div style="z-index: 1000;">
                                            <telerik:RadEditor ID="RadEdit_txtItemdescriprion" runat="server" EditModes="Design,Html"
                                                ImageManager-ViewMode="Grid" OnClientLoad="RareditorIframe" Style="z-inex: 300000"
                                                OnClientCommandExecuting="OnClientCommandExecuting" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute" ContentAreaMode="Iframe">
                                                <Content>
                                                                          
                                                </Content>
                                                <CssFiles>
                                                    <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                </CssFiles>
                                            </telerik:RadEditor>
                                        </div>
                                        <div class="only5px">
                                        </div>
                                        <span id="Span3" class="spanerrorMsg" style="display: none; width: 187px;">Max. length
                                                of textbox is: 4000</span>
                                    </div>
                                    <%--</div>--%>
                                </div>
                                <div class="bglabel" style="text-align: left; float: left; width: 16%">
                                    <asp:Label ID="lblprintready" runat="server" Text="Print Ready File"><%=objlang.GetLanguageConversion("Print_Ready_File")%></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="javascript:void(0);" id="img_PrintReady_File" runat="server" title="Only PDF files allowed. This file will be shown to the user and will also be downloadable">
                                            <img alt="" id="img_help_printreadyfile" runat="server" src="../images/Help-icon.png"
                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" /></a>
                                </div>
                                <div class="box" style="width: auto; margin-right: -4%;">
                                    <table>
                                        <tr>
                                            <td>
                                                <div align="left">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="upPrintReadyFile" runat="server" CssClass="textboxnew" onchange="checksize();" />
                                                            </td>
                                                            <td>
                                                                <a id="Filetextclear" runat="server" href="#" style="display: none; text-decoration: underline; cursor: pointer; padding-left: 5px;"
                                                                    onclick="javascript:Fileuploadtextclear();return false;">
                                                                    <%=objLanguage.GetLanguageConversion("Clear")%></a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div align="left" class="div_lblprintready">
                                                        <asp:Label ID="lblPrintReadyFile" runat="server" Style="display: none;" CssClass="Normaltext"></asp:Label>
                                                    </div>
                                                    <asp:HiddenField ID="hid_PrintReadyFile" runat="server" Value="" />
                                                    <asp:HiddenField ID="hid_ReportFile" runat="server" Value="" />
                                                </div>
                                            </td>
                                            <td>
                                                <div id="divSetPrintreadyfileasproductimg" style="margin-left: -22px;">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox runat="server" ID="chksetPrAsProductimg" />
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkForceUser" runat="server" Text="Force user to view and approve PDF before ordering" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <span id="Spn_upPrintReadyFile" class="spanerrorMsg" style="display: none;">
                                        <%--                                        <%=objlang.GetLanguageConversion("Please_upload_only_Pdf_file")%>--%>
                                        <%=objlang.GetLanguageConversion("print_ready_file_formats_validation")%>
                                    </span>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="float: left; width: 100%;">
                                    <div class="bglabel" style="text-align: left; width: 16%">
                                        <asp:Label ID="lblPDFwatermarks" runat="server" Text="PDF watermarks">PDF watermarks</asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:CheckBox ID="chkAllowWaterMarksPrintReady" runat="server" Text="Allow watermarks to Print Ready File" />
                                        <br />
                                        &nbsp;<asp:TextBox ID="txtWaterMarkPrintReady" runat="server" Text="Watermark" Width="150px"
                                            onclick="clearText(this);" CssClass="fontgrey" MaxLength="25" Style="margin-left: 30px;"></asp:TextBox><%--onmouseout="defaultText(this);" --%>
                                        <asp:Label ID="lbl" runat="server" Text="" CssClass="smallfontgrey" ForeColor="black"><%=objLanguage.GetLanguageConversion("Max_25_Char")%></asp:Label>
                                    </div>

                                </div>
                                <div style="height: 5px" class="onlyEmpty">
                                </div>

                                <div id="divPreFlight" runat="server">
                                    <div class="bglabel" style="width: 16%; background-color: #FFFFFF">
                                    </div>
                                    <div class="box" style="width: auto;">
                                        <div align="left">
                                            <asp:CheckBox ID="chkPreflightFiles" runat="server" Text="Preflight Files"></asp:CheckBox>
                                            <asp:DropDownList ID="ddlPreflightFiles" runat="server" Style="margin-top: -5px; width: 185px;">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdn_IsPreFlight" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </div>
                                <div class="bglabel" style="width: 16%; background-color: #FFFFFF">
                                </div>
                                <div class="box" style="width: auto;">
                                    <div align="left">
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div id="div_produvtdetailsZindexProb" style="width: 450px; min-width: 200px; float: left;">
                        <fieldset style="z-index: -10;">
                            <legend><b>
                                <%=objlang.GetLanguageConversion("Product_Detail_Settings")%></b></legend>
                            <div>
                                <div id="divproductVisible" runat="server" style="display: none;">
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblproductVisible" runat="server" Text="Product visible to customer / public accounts"></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkProductVisible" runat="server" />
                                        <span id="Span1" class="spanerrorMsg" style="display: none; width: 185px;" runat="server">
                                            <asp:Label ID="lblMaxLenghtText1" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div class="bglabel" style="width: 55%;">
                                    <asp:Label ID="Label1" runat="server"><%=objlang.GetLanguageConversion("Product_Details")%></asp:Label>
                                </div>
                                <div class="box" style="float: left; width: auto;">
                                    <asp:CheckBox ID="ChkShortDescription" runat="server" /><br />
                                    <asp:CheckBox ID="ChkItemDescription" runat="server" Checked="true" /><br />
                                    <asp:CheckBox ID="ChkPriceStart" runat="server" /><br />
                                    <asp:CheckBox ID="ChkPriceList" runat="server" /><br />
                                    <asp:CheckBox ID="ChkUnitPrice" runat="server" /><br />
                                    <asp:CheckBox ID="ChkPackPrice" runat="server" /><br />
                                    <asp:CheckBox ID="chkpricesubtotaltax" runat="server" Checked="true" />


                                </div>
                                <div class="bglabel" style="width: 55%;">
                                    <asp:Label ID="lblPrintreadtfile" runat="server" Text="Print Ready File"><%=objlang.GetLanguageConversion("Print_Ready_File") %></asp:Label>
                                </div>
                                <div class="box" style="float: left; width: auto;">
                                    <asp:CheckBox ID="ChkPrintReadyFile" runat="server" Checked="true" />
                                </div>
                                <div id="div_userArtwork" runat="server" style="display: none">
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblArtworkfile" runat="server"><%=objlang.GetLanguageConversion("Allow_user_to_upload_artwork_file")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="ChkArtworkFile" runat="server" Text="" onclick="ChkArtworkFile_onclick('Y');" />
                                    </div>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblUploadbox" runat="server" Text="How Many Upload boxes"><%=objlang.GetLanguageConversion("How_Many_Upload_Boxes") %></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:DropDownList ID="ddlArtCount" runat="server" Enabled="false" CssClass="textboxnew"
                                            Width="45px">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lbluploadmandatory" runat="server" Text="Make the first file upload mandatory"><%=objlang.GetLanguageConversion("Make_the_first_file_upload_mandatory")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="ChkMandatoryArtworkFile" runat="server" Enabled="false" Text=""
                                            onclick="ChkArtworkFile_onclick('M');" />
                                        <asp:HiddenField ID="hid_ArtworkFileValue" runat="server" Value="N" />
                                    </div>
                                    <%-- addded on 23-01-2013--%>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblshowstock" runat="server" Text="Show Stock"><%=objlang.GetLanguageConversion("Show_Stock")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="Chkshowstock" runat="server" Text="" />
                                    </div>
                                    <%-- added by sharan on 4/3/2013--%>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblShowSoldPack" runat="server" Text="Show Sold in Packs of"><%=objlang.GetLanguageConversion("Show_Sold_in_Packs_of")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkShowSoldPack" runat="server" Text="" />
                                    </div>
                                    <%--   end by sharan--%>
                                    <%-- added by kruti on 21/3/2013--%>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblAllowGroupRun" runat="server" Text="Allow Group Run"><%=objlang.GetLanguageConversion("Allow_Group_Run")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkAllowGroupRun" runat="server" Text="" />
                                    </div>
                                    <%-- end--%>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblCustomerCode" runat="server"> <%=objLanguage.GetLanguageConversion("p_Customer_code")%> </asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkCustomerCode" runat="server" Text="" />
                                    </div>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblItemCode" runat="server"><%=objLanguage.GetLanguageConversion("p_Item_code")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkItemCode" runat="server" />
                                    </div>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="lblSubAdditionOption" runat="server"><%=objLanguage.GetLanguageConversion("Hide_additional_options")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkSubAdditionOption" runat="server" />
                                    </div>
                                    <%-- <div class="bglabel" style="width: 55%;">
                                                <asp:Label ID="lblpricesubtax" runat="server"><%=objLanguage.GetLanguageConversion("price_tax_subtotal")%></asp:Label>
                                            </div>
                                            <div class="box" style="float: left; width: auto;">
                                                <asp:CheckBox ID="chkpricesubtotaltax" runat="server" Checked="true" />
                                            </div>--%>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Quick_Item_Add")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkQuickItemAdd" runat="server" />
                                    </div>
                                    <div class="bglabel" style="width: 55%;">
                                        <asp:Label ID="Label10" runat="server"><%=objLanguage.GetLanguageConversion("Add_To_Cart_And_Stay")%></asp:Label>
                                    </div>
                                    <div class="box" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkAddToCartStay" runat="server" />
                                    </div>
                                    <div class="bglabel" id="divlblJobName" visible="false" runat="server" style="width: 55%;">
                                        <asp:Label ID="lblJobName" runat="server"></asp:Label>
                                    </div>
                                    <div class="box" id="divchkJobName" runat="server" visible="false" style="float: left; width: auto;">
                                        <asp:CheckBox ID="chkJobName" runat="server" />
                                    </div>
                                    <div style="float: left;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <span class="quickaddfunNote">
                                                        <%=objLanguage.GetLanguageConversion("Please_Note") %>: </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="quickaddfunNoteContent">
                                                        <%=objLanguage.GetLanguageConversion("Quick_add_function_note") %>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div class="only5px">
                </div>
                <div style="width: 100%">
                    <div style="width: 54%; float: left">
                        &nbsp;
                    </div>
                    <div style="width: 40%; float: left;">
                        <div style="float: left">
                            <asp:Button ID="btnPrevious2" runat="server" CssClass="NewButton" Text="Previous"
                                OnClientClick="javascript:getactivetabDecoration('previous');return false;" CausesValidation="false" />
                        </div>
                        <div style="float: left; padding-left: 10px">
                            <asp:Button ID="btnNext3" runat="server" CssClass="NewButton" Text="Next" OnClientClick="javascript:getactivetab('next');return false;" />
                        </div>
                        <div style="float: left; padding-left: 10px">
                            <div id="div_btnartsavestay" style="display: block">
                                <asp:Button ID="btnArtworkSaveandStay" runat="server" CssClass="NewButton" Text="Save & Stay" />
                                <asp:LinkButton ID="lnkArtworkSaveandStay" runat="server" OnClick="OnClick_btnArtworkSaveandStay"></asp:LinkButton>
                            </div>
                            <div id="div_btnartsavestayprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="float: left; padding-left: 10px">
                            <div id="div_btnartsave" style="display: block">
                                <asp:Button ID="btnArtworkSave" runat="server" CssClass="NewButton" Text="Save" />
                                <asp:LinkButton ID="lnkArtworkSave" runat="server" OnClick="OnClick_btnArtworkSave"></asp:LinkButton>
                            </div>
                            <div id="div_btnartworksaveprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="divestore_savestock" style="float: left; padding-left: 10px; display: none;">
                            <div id="div_savestockbtn" style="display: block">
                                <asp:Button ID="btnestoresavestock" runat="server" CssClass="NewButton" Text="Save & Manage Stock" />
                                <asp:LinkButton ID="lnkestoresavestock" runat="server" OnClick="OnClick_btnArtworkSave"></asp:LinkButton>
                            </div>
                            <div id="div_estorestocksaveprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
            </div>
            <%--====================End of eStore Settings =======================--%>
            <%--====================Additional Options =======================--%>
            <div id="div_additional" style="display: none">
                <div>
                    <div id="div_Additional_padding">
                        <div id="div_Main" runat="server" align="left" style="width: 100%">
                            <div id="a">
                            </div>
                            <div id="div_Grid" style="width: 100%; float: left">
                                <div style="width: 47%; float: left">
                                    <div id="div_PendingGrid" style="float: left; width: 100%">
                                        <strong><span>
                                            <asp:Label ID="lblAvailableOptions" runat="server"></asp:Label></span></strong>
                                        <div class="only5px">
                                        </div>
                                        <telerik:RadGrid runat="server" ID="GridWebOtherCostPendingOrders" OnNeedDataSource="grdPendingOrders_NeedDataSource"
                                            AllowPaging="True" Width="95%" OnRowDrop="grdPendingOrders_RowDrop" AllowMultiRowSelection="true"
                                            CssClass="RadGrid_Eprint_Skin" PageSize="50" EnableHeaderContextMenu="true" AutoGenerateColumns="false"
                                            AllowFilteringByColumn="true">
                                            <GroupingSettings CaseSensitive="false" />
                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <HeaderStyle Width="120px" />
                                            <MasterTableView DataKeyNames="WebOtherCostID" Width="103%" TableLayout="Fixed">
                                                <Columns>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                        <HeaderTemplate>
                                                            <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <input type="checkbox" runat="server" id="Id_1" onclick="CheckChanged('move');" name="Id"
                                                                value='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>' />
                                                            <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridDragDropColumn HeaderStyle-Width="5%" Visible="false" />
                                                    <telerik:GridBoundColumn Visible="false" HeaderText="OtherCost ID" DataField="WebOtherCostID">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderText="Category"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="28%" DataField="OtherCostCategoryName"
                                                        ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                        AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblpendingCategory" runat="server"><%=objlang.GetLanguageConversion("Category")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("OtherCostCategoryName")%>'>
                                                                    <asp:Label ID="lblpendingOtherCostCategoryName" CssClass="normalText" runat="server"
                                                                        Text='<%#Eval("OtherCostCategoryName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="WebOtherCostName" HeaderText="Name" CurrentFilterFunction="Contains"
                                                        HeaderStyle-Width="28%" DataField="WebOtherCostName" ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left"
                                                        AllowFiltering="true" AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblpendingName" runat="server"><%=objlang.GetLanguageConversion("Name")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("WebOtherCostName")%>'>
                                                                    <asp:Label ID="lblpendingWebOtherCostName" CssClass="normalText" runat="server" Text='<%#Eval("WebOtherCostName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="UserFriendlyName" HeaderText="User Friendly Name"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="29%" DataField="UserFriendlyName"
                                                        ItemStyle-Width="29%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                        AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblpendingUserFriendlyName" runat="server"><%=objlang.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("UserFriendlyName")%>'>
                                                                    <asp:Label ID="lblpendingUserFriendlyName1" CssClass="normalText" runat="server"
                                                                        Text='<%#Eval("UserFriendlyName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn HeaderText="AdditionalGroupID" Visible="false" DataField="AdditionalGroupID"
                                                        SortExpression="AdditionalGroupID" UniqueName="AdditionalGroupID">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn HeaderText="Group Name" Visible="false" DataField="GroupName"
                                                        SortExpression="GroupName" UniqueName="GroupName">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="True">
                                                <Resizing AllowColumnResize="true" />
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                <ClientEvents OnRowDropping="onRowDropping" />
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="400px" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                                <div style="width: 3%; vertical-align: middle; float: left">
                                    <div style="width: 20%">
                                        &nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <asp:Button ID="btnMove" runat="server" Text=">>" ToolTip="Move" CssClass="NewButton"
                                        OnClientClick="javascript:return CallSelect('move');" OnClick="BtnMove_Onclick" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnReMove" runat="server" Text="<<" ToolTip="Remove" CssClass="NewButton"
                                            OnClientClick="javascript:return CallSelect('remove');" OnClick="BtnReMove_Onclick" />
                                </div>
                                <%--Arrows--%>
                                <div style="width: 47%; float: left; padding: 0% 0% 0% 2%;" align="left">
                                    <div>
                                        <div id="div_popupAction" style="display: none; z-index: 999999; position: absolute; margin: 54px 0px 0px 10px"
                                            onmouseover="show();" onmouseout="hide();">
                                            <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel3">
                                                <telerik:RadListBox runat="server" ID="RadListBox3" SelectionMode="Single" Width="100px">
                                                    <Items>
                                                        <telerik:RadListBoxItem Text="Add Group" onclick="CheckOne_new('add');" />
                                                        <telerik:RadListBoxItem Text="Remove Group" onclick="CheckOne_new('remove');Onclick_Remove();" />
                                                    </Items>
                                                </telerik:RadListBox>
                                            </telerik:RadAjaxPanel>
                                            <asp:LinkButton ID="lnkRemove" runat="server" OnClick="btnRemoveGroup_OnClick"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div id="div_ShippingGrid" style="width: 100%">
                                        <strong><span style="float: left; padding-left: 0%;">
                                            <asp:Label ID="lblSelectedOptions" runat="server"></asp:Label>
                                        </span></strong>&nbsp; <a id="text1" runat="server" title="1. To reorder the rows from ↑ (Top) to ↓(Bottom) place on below of the required row.<br>2. To reorder the rows from  ↓(Bottom)  to ↑ (Top) place on above of the required row.">
                                            <img alt="" id="Option_help" runat="server" src="../images/Help-icon.png" style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" />
                                        </a>
                                        <div class="only5px">
                                        </div>
                                        <telerik:RadGrid runat="server" Width="98%" AllowPaging="true" ID="GridWebOtherCostShippedOrders"
                                            OnNeedDataSource="grdShippedOrders_NeedDataSource" OnRowDrop="grdShippedOrders_RowDrop"
                                            AllowMultiRowSelection="true" PageSize="50" CssClass="RadGrid_Eprint_Skin" AutoGenerateColumns="false">
                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                            <MasterTableView DataKeyNames="WebOtherCostID" Width="103%">
                                                <Columns>
                                                    <telerik:GridDragDropColumn Visible="false" />
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="12%" ItemStyle-Width="12%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                        <HeaderTemplate>
                                                            <div id="div_chk" style="float: left; padding: 2px 4px 2px 4px; border: outset 1px; width: inherit; height: inherit; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px;">
                                                                <div style="float: left">
                                                                    <input type="checkbox" id="checkAll_2" onclick="CheckAll_New(this);" runat="server"
                                                                        name="checkAll" />
                                                                </div>
                                                                <div style="float: left; padding: 5px 3px 0px 3px">
                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                        onclick="show();" alt='' />
                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                        onclick="hide();" alt='' />
                                                                </div>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; margin-left: 6px;">
                                                                <input type="checkbox" runat="server" id="Id_2" onclick="CheckChanged('remove');"
                                                                    checked="checked" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>' />
                                                                <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.WebOtherCostID", "{0}") %>'></asp:Label>
                                                            </div>
                                                            <a title="Reorder">
                                                                <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px; float: right; background-repeat: no-repeat; padding: 0px 0px 0px 10px;"
                                                                    align="right">
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="OtherCostCategoryName" HeaderText="Category"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="20%" DataField="OtherCostCategoryName"
                                                        ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblShippedCategory" runat="server"><%=objlang.GetLanguageConversion("Category")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("OtherCostCategoryName")%>'>
                                                                    <asp:Label ID="lblShippedOtherCostCategoryName1" CssClass="normalText" runat="server"
                                                                        Text='<%#Eval("OtherCostCategoryName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="WebOtherCostName" HeaderText="Name" CurrentFilterFunction="Contains"
                                                        HeaderStyle-Width="20%" DataField="WebOtherCostName" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblShippedName" runat="server"><%=objlang.GetLanguageConversion("Name")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("WebOtherCostName")%>'>
                                                                    <asp:Label ID="lblShippedWebOtherCostName" CssClass="normalText" runat="server" Text='<%#Eval("WebOtherCostName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="UserFriendlyName" HeaderText="User Friendly Name"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="24%" DataField="UserFriendlyName"
                                                        ItemStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblShippedUserFriendlyName" runat="server"><%=objlang.GetLanguageConversion("User_Friendly_Name")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("UserFriendlyName")%>'>
                                                                    <asp:Label ID="lblShippedUserFriendlyName" CssClass="normalText" runat="server" Text='<%#Eval("UserFriendlyName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn HeaderText="AdditionalGroupID" Visible="false" DataField="AdditionalGroupID"
                                                        SortExpression="AdditionalGroupID" UniqueName="AdditionalGroupID">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn HeaderText="Group Name" DataField="GroupName" SortExpression="GroupName"
                                                        HeaderStyle-Width="24%" ItemStyle-Width="24%" UniqueName="GroupName">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <div style="height: 30px; cursor: pointer;">
                                                        <%=objlang.GetLanguageConversion("No_records_to_display")%>
                                                    </div>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="True">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                <ClientEvents OnRowDropping="onRowDropping" />
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="425px" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <%--Selected Form--%>
                            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                            <asp:HiddenField ID="hidweightunit" runat="server" Value="" />
                        </div>
                        <div class="only5px">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                </div>
                <div class="only5px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div style="width: 100%; float: left">
                    <div class="onlyEmpty">
                        <div style="float: left; width: 51.8%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 39%;">
                            <div class="bglabelEmpty" style="width: 115px">
                            </div>
                            <div class="box" style="width: 100%">
                                <div align="left">
                                    <div style="float: left">
                                        <asp:Button CssClass="NewButton" ID="btnPrevious3" runat="server" Text="Previous"
                                            OnClientClick="javascript:gettabs('acp');return false;" />
                                    </div>
                                    <div style="float: left; padding-left: 10px">
                                        <asp:Button ID="btn_Additional_next" runat="server" CssClass="NewButton" Text="Next"
                                            OnClientClick="javascript:gettabs('cc');return false;" />
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_btnaddsavestay" style="display: block">
                                            <asp:Button ID="btnAdditionalSaveandStay" CssClass="NewButton" runat="server" Text="Save & Stay" />
                                            <asp:LinkButton ID="lnkAdditionalSaveandStay" runat="server" OnClick="OnClick_btnAdditionalSaveandStay"></asp:LinkButton>
                                        </div>
                                        <div id="div_btnaddsavestayprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_finalsave" style="display: block">
                                            <asp:Button ID="btnFinalSave" CssClass="NewButton" runat="server" Text="Save" />
                                            <asp:LinkButton ID="lnkFinalSave" runat="server" OnClick="OnClick_btnSave"></asp:LinkButton>
                                            <asp:HiddenField ID="hid_AdditionalSave" runat="server" Value="" />
                                        </div>
                                        <div id="div_finalsaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div id="divadditional_stocksave" style="float: left; padding-left: 10px; display: none">
                                        <div id="div_additionalsve" style="display: block">
                                            <asp:Button ID="btnadditionalstocksave" CssClass="NewButton" runat="server" Text="Save & Manage Stock" />
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="OnClick_btnSave"></asp:LinkButton>
                                        </div>
                                        <div id="div_additionalstockprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
            </div>
            <%--====================End of Additional Options =======================--%>
            <%--====================CouponCode Options =======================--%>
            <div id="div_CouponCode" style="display: none">
                <div>
                    <div id="div-CouponCode_padding">
                        <div id="div_CouponCode_Main" runat="server" align="left" style="width: 100%">
                            <div id="div_CouponCode_a">
                            </div>
                            <div id="div_CouponCode_Grid" style="width: 100%; float: left">
                                <div style="width: 47%; float: left">
                                    <div id="div_AvailableCouponCodeGrid" style="float: left; width: 100%">
                                        <strong><span>
                                            <asp:Label ID="lblAvailableCouponCodeOptions" runat="server"><%=objlang.GetLanguageConversion("Available_Coupon_code")%></asp:Label></span></strong>
                                        <div class="only5px">
                                        </div>
                                        <telerik:RadGrid runat="server" ID="GridAvaialbleCoupncodes" OnNeedDataSource="GridAvaialbleCoupncodes_NeedDataSource"
                                            AllowPaging="True" Width="95%" OnRowDrop="GridAvaialbleCoupncodes_RowDrop" AllowMultiRowSelection="true"
                                            CssClass="RadGrid_Eprint_Skin" PageSize="50" EnableHeaderContextMenu="true" AutoGenerateColumns="false"
                                            AllowFilteringByColumn="true">
                                            <GroupingSettings CaseSensitive="false" />
                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <HeaderStyle Width="120px" />
                                            <MasterTableView DataKeyNames="CouponCodeID" Width="103%" TableLayout="Fixed">
                                                <Columns>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                        <HeaderTemplate>
                                                            <input type="checkbox" id="chkAll_ACC_1" onclick="CheckAll_ACC(this);" runat="server"
                                                                name="checkAll" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <input type="checkbox" runat="server" id="chkACC_1" onclick="CheckChanged_CouponCode('move');"
                                                                name="Id" value='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>' />
                                                            <asp:Label ID="lbl_AvailableCouponCodeID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridDragDropColumn HeaderStyle-Width="5%" Visible="false" />
                                                    <telerik:GridBoundColumn Visible="false" HeaderText="Available CouponCodeID" DataField="CouponCodeID">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn SortExpression="CouponCode" HeaderText="Available CouponCode"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="28%" DataField="CouponCode"
                                                        ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                        AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblAvailableCouponCodes" runat="server"><%=objlang.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("CouponCode")%>'>
                                                                    <asp:Label ID="lbllnkAvailableCouponCodes" CssClass="normalText" runat="server" Text='<%#Eval("CouponCode")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="CouponCodeUserFriendlyName" HeaderText="User Friendly Name"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="29%" DataField="CouponCodeUserFriendlyName"
                                                        ItemStyle-Width="29%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                        AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblAvailableCouponCodeUserFriendlyName" runat="server"><%=objlang.GetLanguageConversion("Description")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("CouponCodeUserFriendlyName")%>'>
                                                                    <asp:Label ID="lbllnkAvailableCouponCodeUserFriendlyName" CssClass="normalText" runat="server"
                                                                        Text='<%#Eval("CouponCodeUserFriendlyName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="True">
                                                <Resizing AllowColumnResize="true" />
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                <ClientEvents OnRowDropping="onRowDropping" />
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="400px" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                                <div style="width: 3%; vertical-align: middle; float: left">
                                    <div style="width: 20%">
                                        &nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <asp:Button ID="btnCouponCodeMove" runat="server" Text=">>" ToolTip="Move" CssClass="NewButton"
                                        OnClientClick="javascript:return CallSelectCouponCode('move');" OnClick="btnCouponCodeMove_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCouponCodeRemove" runat="server" Text="<<" ToolTip="Remove" CssClass="NewButton"
                                            OnClientClick="javascript:return CallSelectCouponCode('remove');" OnClick="btnCouponCodeRemove_Click" />
                                </div>
                                <%--Arrows--%>
                                <div style="width: 47%; float: left; padding: 0% 0% 0% 2%;" align="left">
                                    <div id="div_SelectedCouponCodeGrid" style="width: 100%">
                                        <strong><span style="float: left; padding-left: 0%;">
                                            <asp:Label ID="lblSelectedCouponCodeOptions" runat="server"><%=objlang.GetLanguageConversion("Selected_Coupon_Code")%></asp:Label>
                                        </span></strong>&nbsp; <a id="anc_txtHelp" runat="server" title="1. To reorder the rows from ↑ (Top) to ↓(Bottom) place on below of the required row.<br>2. To reorder the rows from  ↓(Bottom)  to ↑ (Top) place on above of the required row.">
                                            <img alt="" id="img_Options_Help" runat="server" src="../images/Help-icon.png" style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" />
                                        </a>
                                        <div class="only5px">
                                        </div>
                                        <telerik:RadGrid runat="server" Width="98%" AllowPaging="true" ID="GridSelectedCouponCodes"
                                            OnNeedDataSource="GridSelectedCouponCodes_NeedDataSource" OnRowDrop="GridSelectedCouponCodes_RowDrop"
                                            AllowMultiRowSelection="true" PageSize="50" CssClass="RadGrid_Eprint_Skin" AutoGenerateColumns="false">
                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                            <MasterTableView DataKeyNames="CouponCodeID" Width="103%">
                                                <Columns>
                                                    <telerik:GridDragDropColumn Visible="false" />
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="12%" ItemStyle-Width="12%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                        <HeaderTemplate>
                                                            <div id="div_chk" style="float: left; padding: 2px 4px 2px 4px; border: outset 1px; width: inherit; height: inherit; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px;">
                                                                <div style="float: left">
                                                                    <input type="checkbox" id="chkAll_SCC_2" onclick="CheckAll_SCC(this);" runat="server"
                                                                        name="checkAll" />
                                                                </div>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; margin-left: 6px;">
                                                                <input type="checkbox" runat="server" id="chkSCC_2" onclick="CheckChanged_CouponCode('remove');"
                                                                    checked="checked" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>' />
                                                                <asp:Label ID="lblSelectedCouponCodeID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.CouponCodeID", "{0}") %>'></asp:Label>
                                                            </div>
                                                            <a title="Reorder">
                                                                <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px; float: right; background-repeat: no-repeat; padding: 0px 0px 0px 10px;"
                                                                    align="right">
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="CouponCode" HeaderText="Category" CurrentFilterFunction="Contains"
                                                        HeaderStyle-Width="20%" DataField="CouponCode" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblSelectedCouponCodes" runat="server"><%=objlang.GetLanguageConversion("Coupon_Code")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("CouponCode")%>'>
                                                                    <asp:Label ID="lbllnkSelectedCouponCodes" CssClass="normalText" runat="server" Text='<%#Eval("CouponCode")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn SortExpression="CouponCodeUserFriendlyName" HeaderText="User Friendly Name"
                                                        CurrentFilterFunction="Contains" HeaderStyle-Width="24%" DataField="CouponCodeUserFriendlyName"
                                                        ItemStyle-Width="24%" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <asp:Label ID="lblSelectedCouponCodeUserFriendlyName" runat="server"><%=objlang.GetLanguageConversion("Description")%></asp:Label>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <a title='<%#Eval("CouponCodeUserFriendlyName")%>'>
                                                                    <asp:Label ID="lbllnkSelectedCouponCodeUserFriendlyName" CssClass="normalText" runat="server"
                                                                        Text='<%#Eval("CouponCodeUserFriendlyName")%>'></asp:Label></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <div style="height: 30px; cursor: pointer;">
                                                        <%=objlang.GetLanguageConversion("No_records_to_display")%>
                                                    </div>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <ClientSettings AllowRowsDragDrop="True">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                <ClientEvents OnRowDropping="onRowDropping" />
                                                <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="425px" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <%--Selected Form--%>
                            <asp:HiddenField ID="hidCouponCodeGridCount" runat="server" Value="" />
                            <asp:HiddenField ID="hidCouponCodeweightunit" runat="server" Value="" />
                        </div>
                        <div class="only5px">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                </div>
                <div class="only5px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div style="width: 100%; float: left">
                    <div class="onlyEmpty">
                        <div style="float: left; width: 51.8%;">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 39%;">
                            <div class="bglabelEmpty" style="width: 115px">
                            </div>
                            <div class="box" style="width: 100%">
                                <div align="left">
                                    <div style="float: left">
                                        <asp:Button CssClass="NewButton" ID="btn_CouponCode_Previous" runat="server" Text="Previous"
                                            OnClientClick="javascript:gettabs('ao');return false;" />
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_CouponCode_btnaddsavestay" style="display: block">
                                            <asp:Button ID="btn_CouponCode_SaveStay" CssClass="NewButton" runat="server" Text="Save & Stay" />
                                            <asp:LinkButton ID="lnk_CouponCode_SaveStay" runat="server" OnClick="lnk_CouponCode_SaveStay_Click"></asp:LinkButton>
                                        </div>
                                        <div id="div_CouponCode_btnaddsavestayprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; padding-left: 10px;">
                                        <div id="div_CouponCode_finalsave" style="display: block">
                                            <asp:Button ID="btn_CouponCode_Save" CssClass="NewButton" runat="server" Text="Save" />
                                            <asp:LinkButton ID="lnk_CouponCode_Save" runat="server" OnClick="lnk_CouponCode_Save_Click"></asp:LinkButton>
                                            <asp:HiddenField ID="hdn_CouponCode_Save" runat="server" Value="" />
                                        </div>
                                        <div id="div_CouponCode_finalsaveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div id="div_CouponCode_Savestocksave" style="float: left; padding-left: 10px; display: none">
                                        <div id="div_CouponCode_Save" style="display: block">
                                            <asp:Button ID="btn_CouponCode_SaveMangeStock" CssClass="NewButton" runat="server"
                                                Text="Save & Manage Stock" />
                                            <asp:LinkButton ID="lnk_CouponCode_SaveMangeStock" runat="server" OnClick="lnk_CouponCode_SaveMangeStock_Click"></asp:LinkButton>
                                        </div>
                                        <div id="div_CouponCode_Stockprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
            </div>
            <%--====================End of CouponCode Options =======================--%>

            <%--====================Setup Template =======================--%>
            <%--=========== Editable Product ================================--%>
            <uc:EditableProduct runat="server" ID="ucEditableProduct" />
            <%--=========== Editable Product ================================--%>
        </div>
    </div>
    <%-- Padding--%>
    <%-- </div>--%>
    <div id="div2" style="display: none;">
    </div>
    <div id="div_Group" style="display: none; position: absolute; z-index: 1000; width: 30%;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">&nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                        <b>Add Group</b>
                    </div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="imgCloseHGroup" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="javascript:ShowHideGroup('hide');return false;" />
                        </div>
                    </div>
                </td>
                <td colspan="2" class="popup-top-rightcorner">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="popup-middle-leftcorner">&nbsp;
                </td>
                <td style="width: 15px; background-color: #ffffff">&nbsp;
                </td>
                <td class="popup-middlebg" align="center">
                    <div id="Div3">
                        <div align="left" style="width: 100%">
                            <div align="left" style="width: 100%">
                                <div style="float: left; width: 25%">
                                    <asp:Label ID="lblHGroupName" runat="server" Text="Group Name" CssClass="normalText"></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div class="box">
                                    <div id="div_grpEdit" runat="server" style="display: none;">
                                        <asp:UpdatePanel ID="updpnlGroup" runat="server" RenderMode="Inline" UpdateMode="Always">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlGroup" runat="server" onchange="javascript:onchange_ddlGroup(this.value);">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:HiddenField ID="hid_GroupList" runat="server" />
                                        <div id="div_DeleteGroup" style="float: right;">
                                            <a href='#' onclick="javascript:Delete_Group();">
                                                <img alt="" src="<%=strImagepath %>delete.gif" border="0px" style="padding-top: 4px;"
                                                    title="Delete Group" />
                                            </a>
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="lnkDeleteGroup" runat="server" OnClick="DeleteGroup_OnClick"></asp:LinkButton>
                                    <div id="div_grpAdd" runat="server" style="display: none;">
                                        <asp:TextBox ID="txtGroupName" runat="server" Width="200px" SkinID="textPad"></asp:TextBox>
                                    </div>
                                    <span id="spnerrGroupName" class="spanerrorMsg" style="display: none; width: 200px;">
                                        <%=objlang.GetValueOnLang("Please enter Group Name")%></span>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; width: 26%">
                                    &nbsp;
                                </div>
                                <div style="float: left">
                                    <div id="div_grpCancel" runat="server" style="display: none; float: left; padding-right: 5px;">
                                        <asp:Button ID="btnCancelGroup" Text="Cancel" CssClass="NewButton" runat="server"
                                            OnClientClick="javascript:btnGroup_Cancel();return false;" />
                                        <div class="onlyEmpty">
                                            &nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div style="float: left;">
                                        <asp:Button ID="btnSaveGroup" Text="Save" CssClass="NewButton" runat="server" OnClientClick="javascript:return ValidateGroup();" />
                                        <asp:LinkButton ID="lnkSaveGroup" runat="server" OnClick="btnSaveGroup_OnClick"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkSaveGroupandFinal" runat="server" OnClick="OnClick_lnkSaveGroupandFinal"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                    </div>
                </td>
                <td style="width: 10px; background-color: #ffffff">&nbsp;
                </td>
                <td align="right" class="popup-middle-rightcorner">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
                </td>
                <td class="popup-bottom-middlebg">&nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </div>
    <asp:HiddenField ID="hid_PO_values" runat="server" Value="" />
    <asp:HiddenField ID="hid_OtherCostMoveOrders" runat="server" Value="" />
    <asp:HiddenField ID="hid_OtherCostRemoveOrders" runat="server" Value="" />
    <asp:HiddenField ID="hid_ddlMatrixType" runat="server" Value="P" />
    <asp:HiddenField ID="hid_TempProductID" runat="server" Value="0" />
    <asp:HiddenField ID="hid_AddValues_onDelete" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_supplierID" runat="server" Value="" />
    <asp:HiddenField ID="SalesTaxRate" runat="server" Value="" />
    <asp:HiddenField ID="hdn_itemtitle" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
    <asp:HiddenField ID="hdntemp" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_Matrixtypetext" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CouponCodeMove" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CouponCodeRemove" runat="server" Value="" />
    <div id="div_rad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <div id="div_stockpopupnew" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager4" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" Modal="false" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/price_catalogue.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/drag.js?VN='<%#VersionNumber%>'"
        language="javascript"></script>
    <script type="text/javascript">        var RedirectTo = '<%=RedirectTo %>';
        var hid_ArtworkFileValue = document.getElementById("<%=hid_ArtworkFileValue.ClientID %>");
        var ChkArtworkFile = document.getElementById("<%=ChkArtworkFile.ClientID %>");
        var ChkMandatoryArtworkFile = document.getElementById("<%=ChkMandatoryArtworkFile.ClientID %>");
        var ddlArtCount = document.getElementById("<%=ddlArtCount.ClientID %>");
        var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID%>");
        var hid_CategoryID = document.getElementById("<%=hid_CategoryID.ClientID %>");
        var hdn_SalesTaxRate = document.getElementById("<%=hdn_SalesTaxRate.ClientID%>");
        var div_Obj = document.getElementById("div_PriceCata_Category_add_item");
        var txtPriceCatalogueCategoryName = document.getElementById("<%=txtPriceCatalogueCategoryName.ClientID %>");
        var btnCategorySave = document.getElementById("<%=btnCategorySave.ClientID %>");
        var ddlMatrixType = document.getElementById("<%=ddlMatrixType.ClientID %>");
        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hdn_Matrixtypetext = document.getElementById("<%=hdn_Matrixtypetext.ClientID %>");
        var txtCategoryName = document.getElementById("<%=txtCategoryName.ClientID%>");
        var txtCatalogueName = document.getElementById("<%=txtCatalogueName.ClientID%>");
        var txtDescription = document.getElementById("<%=txtDescription.ClientID %>");
        var hidQtyPrice = document.getElementById("<%=hidQtyPrice.ClientID %>");
        var spn_txtQuantity_Number = document.getElementById("spn_txtQuantity_Number");
        var ddlPriceCatalogueCategory = document.getElementById("<%=ddlPriceCatalogueCategory.ClientID %>");
        var hid_ddlMatrixType = document.getElementById("<%=hid_ddlMatrixType.ClientID %>");
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var hid_AdditionalSave = document.getElementById("<%=hid_AdditionalSave.ClientID %>");
        var GridWebOtherCostPendingOrders = document.getElementById("<%=GridWebOtherCostPendingOrders.ClientID %>");
        var GridWebOtherCostShippedOrders = document.getElementById("<%=GridWebOtherCostShippedOrders.ClientID %>");
        var hid_OtherCostMoveOrders = document.getElementById("<%=hid_OtherCostMoveOrders.ClientID %>");
        var hid_OtherCostRemoveOrders = document.getElementById("<%=hid_OtherCostRemoveOrders.ClientID %>");
        var lblProductImage = document.getElementById("<%=lblProductImage.ClientID %>");

        var hid_ProductImage = document.getElementById("<%=hid_ProductImage.ClientID%>");
        var hid_PrintReadyFile = document.getElementById("<%=hid_PrintReadyFile.ClientID%>");
        var hid_ReportFile = document.getElementById("<%=hid_ReportFile.ClientID %>");
        var lblPrintReadyFile = document.getElementById("<%=lblPrintReadyFile.ClientID%>");
        var upPrintReadyFile = document.getElementById("<%=upPrintReadyFile.ClientID%>");

        var divPreFlight = document.getElementById("<%=divPreFlight.ClientID%>");
        var lastRow = 0; var TotalRow = 10;
        var txtShortdescriprion = document.getElementById("<%=txtShortdescriprion.ClientID%>");

        var txtItemdescriprion = document.getElementById("<%=RadEdit_txtItemdescriprion.ClientID%>");

        var lstAccountPublic = this.document.getElementById("<%=lstStatus.ClientID%>");
        var div_Group = document.getElementById("div_Group");
        var txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");
        var ddlGroup = document.getElementById("<%=ddlGroup.ClientID %>");
        var div_grpAdd = document.getElementById("<%=div_grpAdd.ClientID %>");
        var div_grpEdit = document.getElementById("<%=div_grpEdit.ClientID%>");
        var div_grpCancel = document.getElementById("<%=div_grpCancel.ClientID %>");
        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        var hid_AddValues_onDelete = document.getElementById("<%=hid_AddValues_onDelete.ClientID %>");
        var hdn_itemtitle = document.getElementById("<%=hdn_itemtitle.ClientID %>");
        var hdn_Customers = document.getElementById("<%=hdn_Customers.ClientID %>");
        var txt_SoldinPack = document.getElementById("<%=txt_SoldinPack.ClientID%>");
        var ddlPreflightFiles = document.getElementById("<%=ddlPreflightFiles.ClientID%>");
        var chkPreFlightFiles = document.getElementById("<%=chkPreflightFiles.ClientID %>");
        var hdn_IsPreFlight = document.getElementById("<%=hdn_IsPreFlight.ClientID %>");
        var ddldrawstockfrom = document.getElementById("<%= ddldrawstockfrom.ClientID%>");
        var ddl_SaleTaxRate = document.getElementById("<%=ddl_SaleTaxRate.ClientID%>");
<%--        var folder = document.getElementById('<%= ddlFtpFolders.ClientID %>').value;--%>
        var ftpFolderDropdownId = '<%= ddlFtpFolders.ClientID %>';

        var action = '<%=action%>';

        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_imgbtnaddcategory').click(function () {
                // ...
                return false;
            });
        });
       <%-- function validateFtpSettings() {
            debugger;
            var folder = document.getElementById('<%= ddlFtpFolders.ClientID %>').value;
            var errorSpan = document.getElementById("spn_FTP");

            if (folder === "0" || folder === "") {
                errorSpan.style.display = "inline";
                return false;
            } else {
                errorSpan.style.display = "none";
                return true;
            }
        }--%>
        function toggleFileUI() {
            debugger;
            var rdoEditable = document.getElementById('<%= rdoEditable.ClientID %>');
            var rdoPrintReady = document.getElementById('<%= rdoPrintReady.ClientID %>');
            var fileSection = document.getElementById('fileControlsRow');

                if (rdoEditable.checked) {
                    fileSection.style.display = 'none';
                }
                else if (rdoPrintReady.checked)
                {
                    fileSection.style.display = 'none';
                }
                else {
                    fileSection.style.display = '';
                }
        }
        window.onload = toggleFileUI();
        function AddMultipleCategories(ProductCatalogueID, CompanyID, JobID, InvoiceID, page) {
            debugger;
            var Rad_Attachment = window.radopen("<%=strSitepath %>common/common_popup.aspx?pagetype=general&type=multiple_categories&productcatalogueid=" + ProductCatalogueID + "&companyid=" + CompanyID + "&jobid=" + JobID + "&invoiceid=" + InvoiceID + "&page=" + page + "&pg=" + page + "");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad_Attachment.setSize(800, 300);
            Rad_Attachment.center();
        }
        function CheckForNone(value) {
            if (value == 'accounts') {
                if (lstAccountPublic.selectedIndex == '0') {
                    for (i = 0; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].selected = false;
                    }
                    lstAccountPublic.options[0].selected = true;
                }
            }

        }
        function RareditorIframe(editor, args) {
            var RareditorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            RareditorIframe.style.height = "100%";
            var RadeditorIframeHeight = document.getElementById("ctl00_ContentPlaceHolder1_RadEdit_txtItemdescriprion_contentIframe")
            RadeditorIframeHeight.style.height = "100%";
        }

        function copytoTextArea(ID, text) {
            if (text != "" && queryString != "edit") {
                txtShortdescriprion.value = text; txtItemdescriprion.value = text;
            }
        }

        function CallSelect(value) {
            var hid_OtherCostMoveOrders = document.getElementById("<%=hid_OtherCostMoveOrders.ClientID%>");
            var ret = CheckOne(value);
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = '';
                if (value == 'move') {
                    frm = document.getElementById("<%=GridWebOtherCostPendingOrders.ClientID%>").getElementsByTagName("input");
                }
                else if (value == 'remove') {
                    frm = document.getElementById("<%=GridWebOtherCostShippedOrders.ClientID%>").getElementsByTagName("input");
                }
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('Id') != -1) {
                        if (frm[l].type == "checkbox") {
                            if (frm[l].checked) {
                                IDs = IDs + frm[l].value + ",";
                            }
                        }
                    }
                }

                if (value == 'move') {
                    hid_OtherCostMoveOrders.value = IDs;
                    document.cookie = "OtherCostMoveOrders=" + IDs;
                    //optimization : grid will not if we wont select any checkboxes
                    __doPostBack('ctl00$ContentPlaceHolder1$btnMove', '');
                    return ret;
                }
                else {
                    hid_OtherCostRemoveOrders.value = IDs;
                    document.cookie = "OtherCostRemoveOrders=" + IDs;
                    //optimization : grid will not if we wont select any checkboxes
                    __doPostBack('ctl00$ContentPlaceHolder1$btnReMove', '');
                    return ret;
                }
                return true;

            }
            else {
                if (value == 'move') {
                    document.cookie = "OtherCostMoveOrders=";
                }
                else {
                    document.cookie = "OtherCostRemoveOrders=";
                }
                return false;
            }
        }


        function CallSelectCouponCode(value) {
            var hdn_CouponCodeMove = document.getElementById("<%=hdn_CouponCodeMove.ClientID%>");
            var hdn_CouponCodeRemove = document.getElementById("<%=hdn_CouponCodeRemove .ClientID%>");
            var ret = CheckOne_CouponCode(value);
            if (ret) {
                CheckGrid();
                var IDs = '';
                var frm = '';
                if (value == 'move') {
                    frm = document.getElementById("<%=GridAvaialbleCoupncodes.ClientID%>").getElementsByTagName("input");
                }
                else if (value == 'remove') {
                    frm = document.getElementById("<%=GridSelectedCouponCodes.ClientID%>").getElementsByTagName("input");
                }
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('chkACC_1') != -1 || frm[l].id.indexOf('chkSCC_2') != -1) {
                        if (frm[l].type == "checkbox") {
                            if (frm[l].checked) {
                                IDs = IDs + frm[l].value + ",";
                            }
                        }
                    }
                }

                if (value == 'move') {
                    hdn_CouponCodeMove.value = IDs;
                    document.cookie = "CouponCodeMove=" + IDs;
                    //optimization : grid will not if we wont select any checkboxes
                    __doPostBack('ctl00$ContentPlaceHolder1$btnCouponCodeMove', '');
                    return ret;
                }
                else {
                    hdn_CouponCodeRemove.value = IDs;
                    document.cookie = "CouponCodeReMove=" + IDs;
                    //optimization : grid will not if we wont select any checkboxes
                    __doPostBack('ctl00$ContentPlaceHolder1$btnCouponCodeRemove', '');
                    return ret;
                }
                return true;

            }
            else {
                if (value == 'move') {
                    document.cookie = "CouponCodeMove=";
                }
                else {
                    document.cookie = "CouponCodeReMove=";
                }
                return false;
            }
        }



        function EnableCustomeListBox() {

        }
        EnableCustomeListBox();
        if (queryString == "edit") {
            TotalRow = document.getElementById("<%=hid_Rows_On_Edit.ClientID%>").value;
        }
        if ('<%=totalrec %>' != 0) { // window.onload = CallScroll 
        }
        if (queryString == 'edit') {
            var txtitemcode = document.getElementById("<%=txtitemcode.ClientID%>");
        }

        function DeleteCategory() {
            var LetsMove = window.confirm("Are you sure,you want to delete this Category ?");
            if (LetsMove) {
                document.getElementById("<%=hid_CategoryID.ClientID%>").value = document.getElementById("<%=ddlPriceCatalogueCategory.ClientID %>").value;
            }
            else {
                document.getElementById("<%=hid_CategoryID.ClientID %>").value = 0;
            }
        }

        function getAdditionalValues() {
            hid_AdditionalSave.value = ''; var IDs = ''; var
                frm = '';
            frm = document.getElementById("<%=GridWebOtherCostShippedOrders.ClientID%>").getElementsByTagName("input");
            var i = 1;
            var counter = 0;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id_2') != -1) {
                    if (frm[l].type == "checkbox") {
                        IDs = IDs + frm[l].value + ",";
                        counter++;
                    }
                }
            }
            hid_AdditionalSave.value = IDs;
            document.cookie = "AdditionalIDs=" + IDs;
        }


        function GetAdditionalValuesForGroup() {
            var IDs = '';
            var frm = ''; var Len = false;
            frm = document.getElementById("<%=GridWebOtherCostShippedOrders.ClientID%>").getElementsByTagName("input");
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id_2') != -1) {
                    if (frm[l].type == "checkbox") {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                            Len = true;
                        }
                    }
                }
            }
            document.cookie = "AdditionalGroupIDs=" + IDs;
            hid_AddValues_onDelete.value = IDs;
            return Len;
        }

        function SetAddlValForGroup_onDelete(IdVal) {
            var frm = '';
            frm = document.getElementById("<%=GridWebOtherCostShippedOrders.ClientID%>").getElementsByTagName("input");
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id_2') != -1) {
                    if (frm[l].type == "checkbox" && frm[l].value == IdVal) {
                        frm[l].checked = true;
                    }
                }
            }
        }

        function getCustimerlist() {
        }

        var rdSelectedCustomer = document.getElementById("<%=rdSelectedCustomer.ClientID%>");
        function selectAll_onclick(type, selectAll) {
            if (type == 'private') {

            }
            else {
                if (selectAll == 'yes') {
                    for (i = 1; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].selected = true;
                    }
                    href_selectAll_Public.style.display = "none";
                    href_selectNone_Public.style.display = "block";
                }

                if (selectAll == 'no') {
                    for (i = 0; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].selected = false;
                    }
                    href_selectAll_Public.style.display = "block";
                    href_selectNone_Public.style.display = "none";
                }
            }
        }

        function ImageButtonPlus_Click() {
            PopupCenter("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg %>" + "1&mode=" + "edit" + "&item=" + "<%=item %>&sender=popup", 1000, 500);
            window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg %>" + "1&mode=" + "edit" + "&item=" + "<%=item %>&sender=popup", 1000, 500);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        function GetSupplier() {
            var hdn_supplierID = document.getElementById("<%=hdn_supplierID.ClientID %>");
            var ddlSupplierID = document.getElementById("<%=ddlSupplier.ClientID %>");
            hdn_supplierID.value = ddlSupplierID.value;
        }

        function clearText(val) {
            val.value = "";
        }

        function defaultText(val) {
            if (val.value == '')
                val.value = "Sample";
        }
        var rbn_Noneditable = document.getElementById("<%=rbn_Noneditable.ClientID%>");
        var div_StockItem = document.getElementById("div_StockItem");
        var li_EditProduct = document.getElementById("li_EditProduct");

        function StockItem(val) {
            if (val == 'e') {
                div_StockItem.style.display = "none";
                li_EditProduct.style.display = "block";

            }
            else {
                div_StockItem.style.display = "block";
                li_EditProduct.style.display = "none";

            }
        }
    </script>
    <script type="text/javascript" src="../js/item/ProductCatalogue.js?VN='<%=VersionNumber%>'"></script>
    <asp:Panel ID="pnlCheckRow" runat="server" Visible="false">
        <script>
            var hid_Rows_On_Edit = document.getElementById("<%=hid_Rows_On_Edit.ClientID %>");
            var hid_data = document.getElementById("<%=hid_data.ClientID%>");
            if (hid_Rows_On_Edit.value < 150) {
                document.getElementById("href_add_more").style.display = "block";
            }
            Take_Data_DB();
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlLoadOnEdit" runat="server" Visible="false">
        <script>
            var str = document.getElementById("<%=hid_PO_values.ClientID%>");
            load();
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlShowMsg" runat="server" Visible="false">
        <script type="text/javascript">
            DisplayRightMsg();
        </script>
    </asp:Panel>
    <script type="text/javascript">
        function openPopUp(type, ProductCatalogueID, action) {
            window.radopen(path + "settings/productCatelogue_Allocation.aspx?from=product&type=" + type + "&id=" + ProductCatalogueID + "&action=" + action); SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        function ShowHideDiv(type) {
            if (type == 'S') {
                document.getElementById("div_selectLnk").style.display = "block";
                document.getElementById("div_ExcludeLnk").style.display = "none";
            }
            else if (type == 'A') {
                document.getElementById("div_selectLnk").style.display = "none";
                document.getElementById("div_ExcludeLnk").style.display = "block";
            }
            else if (type == 'N') {
                document.getElementById("div_selectLnk").style.display = "none";
                document.getElementById("div_ExcludeLnk").style.display = "none";
            }
        }
        var CustType = '<%=CustomerType %>'.toString();
        ShowHideDiv(CustType);

    </script>
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
        <script type="text/javascript">
            function openPopupCrop() {
                var mode = document.getElementById("<%=hidmode.ClientID %>").value;
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                if (mode == "add") {

                    oWnd.setUrl(path + "UploadAndCrop.aspx?from=ProductCatalogue_item&ProductCatalogueID=" + "add");
                    //oWnd.setSize(700, 490);
                    oWnd.setSize(1100, 490);
                    oWnd.center();
                    oWnd.show();
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else {
                    oWnd.setUrl(path + "UploadAndCrop.aspx?from=ProductCatalogue_item&ProductCatalogueID=" + ProductCatalogueID);
                    //oWnd.setSize(700, 490);
                    oWnd.setSize(1100, 490);
                    oWnd.center();
                    oWnd.show();
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
            }

            //added by rk
            function bindUploadimgname() {
                RadWinClose();
                var imagenameCookie = readCookie("UploadedImageName");
                // Get all the cookies pairs in an array
                cookiearray = imagenameCookie.split('&');
                ckiename = cookiearray[1].split('=')[0];
                upimagename = cookiearray[1].split('=')[1];
                displyUpimageName(upimagename);
                //to delete the cookie
                clearCookie(imagenameCookie);
            }

            function clearCookie(name) {
                var date = new Date();
                date.setDate(date.getDate() - 1);
                document.cookie = name + "=''; expires=" + date + "; path=/";
            }

            function readCookie(name) {
                return (name = new RegExp('(?:^|;\\s*)' + ('' + name).replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&') + '=([^;]*)').exec(document.cookie)) && name[1];
            }
            function displyUpimageName(upimagename) {
                document.getElementById("div_uploadedimagename").style.display = "block";
                lblProductImage.style.display = "block";
                document.getElementById('<%= ancUploadimage.ClientID %>').style.display = "none";
                document.getElementById('<%= lnkUpimagepath.ClientID %>').innerHTML = upimagename;

                document.getElementById('<%= lnkUpimagepath.ClientID %>').target = "_blank";

                document.getElementById('<%= lnkUpimagepath.ClientID %>').href = '<%=strSitePath %>' + "DocManager.ashx?doctype=prodnew&filename=" + upimagename;
            }
            function OnClientPageLoad(sender, args) {
                if (contentCell && loadingSign) {
                    contentCell.removeChild(loadingSign);
                    contentCell.style.verticalAlign = "";
                    loadingSign.style.display = "none";
                }
            }
            function OnClientCommandExecuting(editor, args) {
                var commandName = args.get_commandName();
                if (commandName == "ToggleScreenMode") {
                    if (!editor.isFullScreen()) //if the editor is placed in fullscreen mode  
                    {

                        fullscreen = true;

                        document.getElementById("div_produvtdetailsZindexProb").style.display = 'none';
                    }
                    else {
                        document.getElementById("div_produvtdetailsZindexProb").style.display = 'block';
                    }
                }
            }

        </script>
    </telerik:RadScriptBlock>
    <%---by rakshith ---%>
    <asp:HiddenField ID="hdnincrement" runat="server" Value="0" />
    <script>
        var incrval = document.getElementById("<%=hdnincrement.ClientID %>");
        var div1 = document.getElementById("<%=divcd_1.ClientID%>");
        var div2 = document.getElementById("<%=divcd_2.ClientID%>");
        var div3 = document.getElementById("<%=divcd_3.ClientID %>");
        var div4 = document.getElementById("<%=divcd_4.ClientID %>");
        var div5 = document.getElementById("<%=divcd_5.ClientID %>");
        var div6 = document.getElementById("<%=divcd_6.ClientID %>");
        var div7 = document.getElementById("<%=divcd_7.ClientID %>");
        var div8 = document.getElementById("<%=divcd_8.ClientID %>");
        var div9 = document.getElementById("<%=divcd_9.ClientID %>");
        var div10 = document.getElementById("<%=divcd_10.ClientID %>");
        var div11 = document.getElementById("<%=divcd_11.ClientID %>");
        var div12 = document.getElementById("<%=divcd_12.ClientID %>");
        var div13 = document.getElementById("<%=divcd_13.ClientID %>");
        var textaddcustom = document.getElementById("<%=A1.ClientID %>");

    </script>
    <script>

        var divpublicaccounts = document.getElementById("div_PublicAccounts");
        var divnone = document.getElementById("div_None");
        var divall = document.getElementById("div_All");
        var rdbspecifictocustomer = document.getElementById("<%=rdSelectedCustomer.ClientID %>");
        var rdbnone = document.getElementById("<%=rdCustomerNone.ClientID %>");
        var rdall = document.getElementById("<%=rdSelectedAll.ClientID %>");
        var ddl_SaleTaxRate = document.getElementById("<%=ddl_SaleTaxRate.ClientID%>");
        function ownership_onchange() {

            var companyname = '<%=CompanyName%>';
            var lstownership = document.getElementById("<%=lstownership.ClientID%>")
            var selectedval = lstownership.options[lstownership.selectedIndex].value;
            if (selectedval == 'space') {
                lstownership.selectedIndex = 0;
                divpublicaccounts.style.display = "block";
                divnone.style.display = "block";
                divall.style.display = "block";
                divcustomer.display = "block";
                rdbnone.checked = true;
            }
            else if (selectedval == "1") {
                divpublicaccounts.style.display = "block";
                divnone.style.display = "block";
                divall.style.display = "block";
                if (rdbnone.checked) {
                    document.getElementById("div_selectLnk").style.display = "none";
                    document.getElementById("div_ExcludeLnk").style.display = "none";
                }
                else if (rdbspecifictocustomer.checked) {
                    document.getElementById("div_selectLnk").style.display = "block";
                    document.getElementById("div_ExcludeLnk").style.display = "none";
                }
                else if (rdall.checked) {
                    document.getElementById("div_selectLnk").style.display = "none";
                    document.getElementById("div_ExcludeLnk").style.display = "block";
                }
                rdbspecifictocustomer.disabled = false;
                document.getElementById("spnSelectedCustomer").innerHTML = "";
            }
            else {
                divpublicaccounts.style.display = "none";
                divnone.style.display = "none";
                divall.style.display = "none";
                rdbspecifictocustomer.checked = true;
                hdn_Customers.value = lstownership.options[lstownership.selectedIndex].value + ",";

                //                document.getElementById("div_selectLnk").style.display = "none";
                //                document.getElementById("spnSelectedCustomer").innerHTML = "(" + lstownership.options[lstownership.selectedIndex].text + ")";
                if (<%=ManageStockPermission %>== 1) {
                    rdbspecifictocustomer.disabled = true;
                    document.getElementById("div_selectLnk").style.display = "none";
                    document.getElementById("spnSelectedCustomer").innerHTML = "(" + lstownership.options[lstownership.selectedIndex].text + ")";
                }
                else {
                    if (rdbspecifictocustomer.checked) {
                        divpublicaccounts.style.display = "block";
                        divnone.style.display = "block";
                        divall.style.display = "block";
                        document.getElementById("div_selectLnk").style.display = "block";
                        rdbspecifictocustomer.disabled = false;
                    }
                    else {
                        rdbspecifictocustomer.disabled = true;
                        document.getElementById("div_selectLnk").style.display = "none";
                        document.getElementById("spnSelectedCustomer").innerHTML = "(" + lstownership.options[lstownership.selectedIndex].text + ")";
                    }
                }
            }

        }

        var stockcontent = document.getElementById("ctl00_ContentPlaceHolder1_div_stockcontentdiv");

        function StockEnable() {
            var noneditableitem = document.getElementById("<%=rdbnoneditable.ClientID %>");
            var editableitem = document.getElementById("<%=ChkEditableProduct.ClientID %>");
            var chkstockitem = document.getElementById("<%=chkstockitem.ClientID %>");
            var chkbackorders = document.getElementById("<%=chkbackorders.ClientID %>");
            var Chkshowstock = document.getElementById("<%=Chkshowstock.ClientID %>");

            //Commenting the Below to Enable Stock option for Editable products - START
            //            if (editableitem.checked) {
            //                //divstocktab.style.display = "none";
            //                
            //                chkstockitem.disabled = true;
            //                chkbackorders.disabled = true;
            //                if (Chkshowstock.checked) {// enhancement id : 2319.
            //                    Chkshowstock.checked = false;
            //                }
            //                Chkshowstock.disabled = true;
            //            }
            //            else {
            //                //stockcontent.style.display = "block";
            //                chkstockitem.disabled = false;
            //                chkbackorders.disabled = false;
            //                Chkshowstock.disabled = false;
            //            }
            //Commenting the Below to Enable Stock option for Editable products - END
        }

        function ShowSoldInPacks() {
            var ddlmatrix = document.getElementById("ctl00_ContentPlaceHolder1_ddlMatrixType");
            var divsoldin = document.getElementById("ctl00_ContentPlaceHolder1_div_SoldinPack");
            var EnableCumulativePriceing = document.getElementById("ctl00_ContentPlaceHolder1_div_EnableCumulativePriceing");
            var ddlvalue = ddlmatrix.options[ddlmatrix.selectedIndex].value;
            var spn_help_pricebands = document.getElementById("spn_help_pricebands");

            if (ddlvalue == "pricebands") {
                spn_help_pricebands.innerHTML ='<%=objlang.GetLanguageConversion("Price_Band_Use_Note")%>';
            }
            else {
                spn_help_pricebands.innerHTML ='<%=objlang.GetLanguageConversion("Product_Use_Note")%>';
            }

            if (ddlvalue == "signagematrix") {
                divsoldin.style.display = "none";
            }
            else {
                divsoldin.style.display = "block";
            }

            if (ddlvalue == "simplematrix") {
                EnableCumulativePriceing.style.display = "block";
            }
            else {
                EnableCumulativePriceing.style.display = "none";
            }
        }


    </script>
    <script>
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
        function addstock(id) {
            var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1000', '500');
            SetRadWindow_Ver2('div_rad', 'divBackGroundNew');
            Rad1Customer.setSize(1330, 520);
            Rad1Customer.center();

        }

        function getactivetab(type) {
            debugger;
            if (type == 'next') {
                if (document.getElementById("li_EditProduct").style.display == "block") {
                    gettabs('ep');
                    return false;
                }
                else {
                    btnNext_Page('3', '4');
                    return false;
                }
            }
            else if (type == 'previous') {
                if (document.getElementById("li_EditProduct").style.display == "block") {
                    gettabs('ep');
                    return false;
                }
                else {
                    btnNext_Page('4', '3');
                    return false;
                }
            }
        }

        function getactivetabDecoration(type) {

            if (type == 'next') {
                if (document.getElementById("li_decoration").style.display == "block") {
                    document.getElementById("tdaddnew").style.display = "none";
                    document.getElementById("div_Pricemain").style.display = "none";
                    document.getElementById("div_additional").style.display = "none";
                    document.getElementById("div_CouponCode").style.display = "none";
                    document.getElementById("Div_EditableProduct").style.display = "none";
                    document.getElementById("div_PricDecoration").style.display = "none";
                    gettabs('d');
                    return false;
                }
                else {
                    gettabs('ac');
                    return false;
                }
            }
            else if (type == 'previous') {
                if (document.getElementById("li_decoration").style.display == "block") {
                    document.getElementById("tdaddnew").style.display = "none";
                    document.getElementById("div_Pricemain").style.display = "none";
                    document.getElementById("div_additional").style.display = "none";
                    document.getElementById("div_CouponCode").style.display = "none";
                    document.getElementById("Div_EditableProduct").style.display = "none";
                    document.getElementById("div_PricDecoration").style.display = "none";

                    document.getElementById("tdaddnew").style.display = "none";
                    document.getElementById("div_ArtworkcanvasMain").style.display = "none";

                    document.getElementById("div_additional").style.display = "none";

                    gettabs('d');
                    return false;
                }
                else {
                    btnNext_Page('3', '2');

                    return false;
                }
            }
        }


        if ('<%=Request.Params["ToConvert"]%>' == "Yes") {
            MatrixTypeChange('simplematrix');
        }

        function showstockbtn() {
            var action = '<%=action%>';
            var mainChkId = document.getElementById("ctl00_ContentPlaceHolder1_chkstockitem");
            var ddldrawstockfrom = document.getElementById("<%=ddldrawstockfrom.ClientID%>");
            if (mainChkId.checked == true) {
                if (<%=ManageStockPermission %>== 1) {
                    document.getElementById("divprice_savestock").style.display = "block";
                    document.getElementById("divadditional_stocksave").style.display = "block";
                    document.getElementById("divestore_savestock").style.display = "block";
                    document.getElementById("div_genmanagestock").style.display = "block";
                    document.getElementById("div_CouponCode_Savestocksave").style.display = "block";
                    document.getElementById("spnDSFMandatory").style.display = "inline";
                    if (ddldrawstockfrom.selectedIndex == 0) {
                        ddldrawstockfrom.disabled = false;
                    }
                }
            }
            else {
                document.getElementById("divprice_savestock").style.display = "none";
                document.getElementById("divadditional_stocksave").style.display = "none";
                document.getElementById("divestore_savestock").style.display = "none";
                document.getElementById("div_genmanagestock").style.display = "none";
                document.getElementById("div_CouponCode_Savestocksave").style.display = "none";
                ddldrawstockfrom.disabled = true;
                ddldrawstockfrom.selectedIndex = 0;
                document.getElementById("ctl00_ContentPlaceHolder1_chkbackorders").checked = false;
                document.getElementById("spnDSFMandatory").style.display = "none";
            }

            if (action == 'add') {
                MatrixTypeChange('simplematrix');
            }

        }

        showstockbtn();

        function redirectpage(sender) {
            {
                window.location.href ='<%=strSitepath %>ProductCatalogue/ProductCatalogue_item.aspx?action=edit&id=' + ret + '&page=g';
            }
        }
        if ('<%=WebStore.ToLower()%>' == 'yes') {
            document.getElementById("li_artworkCanvas").style.display = "block";
            //document.getElementById("li_additionalOption").style.display="block";
        }


        if ('<%=ChkIsEditable.ToLower() %>' == 'true') {
            Editable = "true"
            document.getElementById("li_EditProduct").style.display = "block";
        }
        else {
            Editable = "false";
            document.getElementById("li_EditProduct").style.display = "none";
        }

        if ('<%=IsDecoration.ToLower() %>' == 'true') {

            document.getElementById("li_decoration").style.display = "block";
        }
        else {

            document.getElementById("li_decoration").style.display = "none";
        }

        function EnablePreFlightDdl(chkPreFlight, ddlPreFlight) {
            if (chkPreFlight.checked) {
                ddlPreFlight.disabled = false;
            }
            else {
                ddlPreFlight.disabled = true;
            }
        }

        //optimization 07-10-16
        function openpopup_Supplier(spnid) {
            var strSitePath = "<%=strSitepath %>";
            var redirect_url = window.location.href;
            var action = '';
            var id = "<%=productCatalogID %>";
            var ClientID = "<%=ClientID %>";
            var RedirectTo = "<%=RedirectTo %>";
            var jID = "<%=jID %>";
            var InvID = "<%=InvID %>";

            if (redirect_url.indexOf('action=edit') > -1) {
                window.radopen(strSitePath + "common/Client_add_new.aspx?type=Supplier&post=settings&mode=edit&id=" + id + "&clientID=" + ClientID + "&from=" + RedirectTo + jID + InvID, 'Supplier', '950', '600');
                SetRadWindow('div_popup_supplier_save', 'divBackGroundNew', '200');
            }
            else {
                window.radopen(strSitePath + "common/Client_add_new.aspx?type=Supplier&post=settings" + "&clientID=" + ClientID + "&from=" + RedirectTo + jID + InvID, 'Supplier', '950', '600');
                SetRadWindow('div_popup_supplier_save', 'divBackGroundNew', '200');
            }
            document.getElementById('divBackGroundNew').style.display = 'block';
        }
        function Bind_supplier(supplierid, txtsuppliername) {
            document.getElementById('<%=hdnsupplierid_onpopup.ClientID %>').value = supplierid;
            var ddl = document.getElementById('<%=ddlSupplier.ClientID %>');
            ddl.options.add(new Option(txtsuppliername, supplierid, ddl.options.length));
            ddl.selectedIndex = ddl.options.length - 1;
        }

        function ValidateNumbersCBM(obj) {
            if (isNaN(obj.value)) {
                obj.value = "0.00";
            }
            if (obj.value < 0) {
                obj.value = "0.00";
            }

            var length = $("#ctl00_ContentPlaceHolder1_TextBoxLength").val();
            var height = $("#ctl00_ContentPlaceHolder1_TextBoxHeight").val();
            var width = $("#ctl00_ContentPlaceHolder1_TextBoxWidth").val();
            var weight = $("#ctl00_ContentPlaceHolder1_TextBoxWeight").val();
            var CBM = $("#ctl00_ContentPlaceHolder1_TextBoxCBM").val();
            var result = "";
            if (('<%=Measurementvalue2.ToString() %>') == "In.") {
                result = (length * width * height) / 1728;
            } else {
                result = (length * width * height) / 1000000;
            }

            if ($('#ctl00_ContentPlaceHolder1_chkCRMOverride').prop('checked') == false) {
                $("#ctl00_ContentPlaceHolder1_TextBoxCBM").val(result.toFixed(3));
            }
            ValidateNumbersVW(obj);

        }

        function ValidateNumbersVW(obj) {
            if (isNaN(obj.value)) {
                obj.value = "0.00";
            }
            if (obj.value < 0) {
                obj.value = "0.00";
            }

            var length = $("#ctl00_ContentPlaceHolder1_TextBoxLength").val();
            var height = $("#ctl00_ContentPlaceHolder1_TextBoxHeight").val();
            var width = $("#ctl00_ContentPlaceHolder1_TextBoxWidth").val();
            var weight = $("#ctl00_ContentPlaceHolder1_TextBoxWeight").val();
            var CBM = $("#ctl00_ContentPlaceHolder1_TextBoxCBM").val();
            var result = "";
            if (('<%=Measurementvalue2.ToString() %>') == "In.") {
                result = (length * width * height) / 166;
            } else {
                result = (length * width * height) / 5000;
            }
            if ($('#ctl00_ContentPlaceHolder1_chkCRMOverride').prop('checked') == false) {
                $("#ctl00_ContentPlaceHolder1_TextBoxVolumetricWeight").val(result.toFixed(5));
            }


        }

        function ValidateIsNumber(obj) {
            if (isNaN(obj.value)) {
                obj.value = "0.00";
            }
            if (obj.value < 0) {
                obj.value = "0.00";
            }

        }

        function enableDisableCBM(obj) {
            if (obj.checked == true) {
                $("#ctl00_ContentPlaceHolder1_TextBoxCBM").attr('readonly', false);
            } else if (obj.checked == false) {
                calculateCBM();
                $("#ctl00_ContentPlaceHolder1_TextBoxCBM").attr("readonly", true);
            }
        }

        function calculateCBM() {

            var length = $("#ctl00_ContentPlaceHolder1_TextBoxLength").val();
            var height = $("#ctl00_ContentPlaceHolder1_TextBoxHeight").val();
            var width = $("#ctl00_ContentPlaceHolder1_TextBoxWidth").val();
            var weight = $("#ctl00_ContentPlaceHolder1_TextBoxWeight").val();
            var CBM = $("#ctl00_ContentPlaceHolder1_TextBoxCBM").val();
            var result = "";
            if (('<%=Measurementvalue2.ToString() %>') == "In.") {
                result = (length * width * height) / 1728;
            } else {
                result = (length * width * height) / 1000000;
            }
            $("#ctl00_ContentPlaceHolder1_TextBoxCBM").val(result.toFixed(3));
        }




    </script>
    <asp:HiddenField ID="hdnsupplierid_onpopup" runat="server" />
</asp:Content>

