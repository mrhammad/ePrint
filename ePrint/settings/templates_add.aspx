<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="templates_add.aspx.cs" Inherits="ePrint.settings.templates_add" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN=<%=VersionNumber %>"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/rgbcolor.js?VN=<%=VersionNumber %>"></script>
    <div id="ds00" style="display: none; z-index: 2;">
    </div>
    <div id="div_Load" style="position: absolute; display: none; z-index: 3; padding-left: 400px; padding-top: 200px;">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";

    </script>
    <style>
        
    </style>
    <script language="javascript" type="text/javascript">


        var isBlank1 = false;
        function ValidateName(saveType) {
            isBlank1 = false;
            var txtName = document.getElementById("<%=txtName.ClientID %>");
            var txtFooterSpace = document.getElementById("<%=txtFooterSpace.ClientID %>");
            var txtHeaderSpace = document.getElementById("<%=txtHeaderSpace.ClientID %>");
            var chkDefaultTemp = document.getElementById("<%=chkDefaultTemp.ClientID %>");

            if (trim12(txtName.value) == "") {
                document.getElementById("spn_txtName").style.display = "block";
                isBlank1 = true;
            }
            if (txtFooterSpace.value != "") {
                if (CheckDecimalPlus(txtFooterSpace.value, 'spn_txtFooterSpace', 'spn_txtFooterSpace', 'no') == false) {
                    isBlank1 = true;
                }
            }
            if (txtHeaderSpace.value != "") {
                if (CheckDecimalPlus(txtHeaderSpace.value, 'spn_txtHeaderSpace', 'spn_txtHeaderSpace', 'no') == false) {
                    isBlank1 = true;
                }
            }
            if (isBlank1) {
                return false;
            }
            else {
                unSelAll();
                var hid_SaveType = document.getElementById("<%=hid_SaveType.ClientID %>");
                hid_SaveType.value = saveType;

                var hid_EditorHTML = document.getElementById("<%=hid_EditorHTML.ClientID %>");
                hid_EditorHTML.value = trim12(document.getElementById("ctl00_ContentPlaceHolder1_Div1").innerHTML);

                while (hid_EditorHTML.value.indexOf('rgb') != -1) {
                    var rgbIndex = hid_EditorHTML.value.indexOf('rgb');
                    var str = hid_EditorHTML.value.substring(rgbIndex, hid_EditorHTML.value.length - 1);

                    var semicolonIndex = str.indexOf(';');

                    var rgbcolor = str.substring(0, semicolonIndex);

                    var color = new RGBColor(rgbcolor);
                    if (color.ok) {
                        hid_EditorHTML.value = hid_EditorHTML.value.replace(rgbcolor, color.toHex());
                    }
                    else {
                        hid_EditorHTML.value = hid_EditorHTML.value.replace(rgbcolor, '#000000');
                    }
                }
                var div_CtrlList = document.getElementById('div_CtrlList');
                var counter = div_CtrlList.getElementsByTagName('input');
                var countertxtarea = div_CtrlList.getElementsByTagName('textarea');
                var totaltxtcount = counter.length + countertxtarea.length;
                for (var i = 0; i < counter.length; i++) {
                    if (counter[i].type == 'text') {
                        var newtextbox = document.getElementById(counter[i].id);
                        newtextbox.setAttribute('value', newtextbox.value);
                    }
                }
                //For TEXTAREA -- NEED TO contunue//
                for (var j = 0; j < countertxtarea.length; j++) {
                    if (countertxtarea[j].type == 'textarea') {
                        var newtextbox = document.getElementById(countertxtarea[j].id);
                        newtextbox.value = newtextbox.value;
                    }
                }

                var hid_ctrlListHTML = document.getElementById("<%=hid_ctrlListHTML.ClientID %>");
                hid_ctrlListHTML.value = trim12(div_CtrlList.innerHTML);


                var fieldprop = "";
                var card_Div = document.getElementById('ctl00_ContentPlaceHolder1_CardDiv');
                var counterdiv = card_Div.getElementsByTagName('div');

                var objID = "";
                var objType = "", objName = "", type = "";
                var objValue = "", imgsrc = "", title = "";
                var align = "left", position = "";
                var objtop = 0, objleft = 0, objwidth = 0, objheight = 0;
                var zindex = "", padding = "", display = "", overflow = "";
                var fontfamily = "", fontsize = "", fontweight = "", fontstyle = "", fontcolor = "";
                var textdecoration = "", textalign = "", border = "", backgroundcolor = "";
                var visibility = "", maxlength = "0";
                var offsetwidth = "", offsetheight = "", offsettop = "", offsetleft = "";
                var pixelwidth = "", pixelheight = "", pixeltop = "";
                var lock = "", repeat = "";
                var canmove = "1", canchangefontcolor = "1", canchangefontsize = "1", canchangefont = "1";
                var objclass = "", onmouseoverclass = "this.className='putpointer'", objTag = '', GroupID = '0', HGroupID = '0', AssociatedLabel = '';
                var IsHGroupMain = '0';
                debugger;
                for (var j = 0; j < counterdiv.length; j++) {
                    objID = counterdiv[j].id;
                    objType = counterdiv[j].getAttribute("objtype");
                    objName = counterdiv[j].getAttribute("objname");
                    type = counterdiv[j].getAttribute("type");
                    objValue = counterdiv[j].innerHTML;

                    if (objType == 13 || objType == 14) {
                        //alert(objName);
                        imgsrc = objName;
                        objValue = imgsrc;
                    }
                    else if (objType == 3 || objType == 8 || objType == 9 || objType == 10 || objType == 11 || objType == 12 || objType == 15 || objType == 16) {
                        //imgsrc = objName;
                        imgsrc = document.getElementById(counterdiv[j].id).firstChild.getAttribute("src");
                        objValue = imgsrc;
                    }
                    else {
                        imgsrc = "";
                        objValue = counterdiv[j].innerHTML;
                    }

                    title = counterdiv[j].getAttribute("title");
                    align = counterdiv[j].getAttribute("align");
                    position = counterdiv[j].style.position;
                    objtop = counterdiv[j].style.top.replace("px", "");
                    objleft = counterdiv[j].style.left.replace("px", "");
                    objwidth = counterdiv[j].style.width.replace("px", "");
                    objheight = counterdiv[j].style.height.replace("px", "");
                    zindex = counterdiv[j].style.zIndex;
                    padding = counterdiv[j].style.padding;
                    display = counterdiv[j].style.display;
                    overflow = counterdiv[j].style.overflow;
                    fontfamily = counterdiv[j].style.fontFamily;

                    fontsize = counterdiv[j].style.fontSize;
                    fontweight = counterdiv[j].style.fontWeight;
                    fontstyle = counterdiv[j].style.fontStyle;


                    fontcolor = counterdiv[j].style.color;
                    textdecoration = counterdiv[j].style.textDecoration;
                    textalign = counterdiv[j].style.textAlign;
                    border = counterdiv[j].style.border;
                    backgroundcolor = counterdiv[j].style.backgroundColor;
                    visibility = counterdiv[j].style.visibility;
                    maxlength = counterdiv[j].getAttribute("maxlength");
                    offsetwidth = counterdiv[j].offsetWidth;
                    offsetheight = counterdiv[j].offsetHeight;
                    offsettop = counterdiv[j].offsetTop;
                    offsetleft = counterdiv[j].offsetLeft;
                    pixelwidth = counterdiv[j].style.pixelWidth;
                    pixelheight = counterdiv[j].style.pixelHeight;
                    pixeltop = counterdiv[j].style.pixelTop;
                    lock = counterdiv[j].getAttribute("lock");
                    repeat = counterdiv[j].getAttribute("repeat");
                    canmove = counterdiv[j].getAttribute("canmove");
                    canchangefontcolor = counterdiv[j].getAttribute("canchangefontcolor");
                    canchangefontsize = counterdiv[j].getAttribute("canchangefontsize");
                    canchangefont = counterdiv[j].getAttribute("canchangefont");
                    objclass = counterdiv[j].getAttribute("class");
                    onmouseoverclass = counterdiv[j].getAttribute("onmouseover");
                    objTag = counterdiv[j].getAttribute("objtag");
                    GroupID = counterdiv[j].getAttribute("GroupID");
                    HGroupID = counterdiv[j].getAttribute("HGroupID");
                    AssociatedLabel = counterdiv[j].getAttribute("AssociatedLabel");
                    IsHGroupMain = counterdiv[j].getAttribute("IsHGroupMain");

                    if ('<%=CheckTagsExists %>' == "no") {
                        if (objType == "1" && objTag == null) {
                            var strTxt = objName.toString().toLowerCase();
                            if (strTxt == "estimate" || strTxt == "enter your text" || strTxt == "kind regards" || strTxt == "best regards"
                                || strTxt == "job card" || strTxt == "invoice" || strTxt == "purchase order" || strTxt == "delivery note"
                                || strTxt == "your's sincerely" || strTxt == "description of goods" || strTxt == "production information"
                                || strTxt == "estimated" || strTxt == "actual job performance" || strTxt == "GroupID") {
                                objTag = "";
                            }
                            else {
                                var str = objName.split(' ');
                                var FinalTagName = '';
                                for (var i = 0; i < str.length; i++) {
                                    FinalTagName = trim12(FinalTagName + str[i]);
                                }
                                objTag = "[" + FinalTagName + "]";
                            }
                        }
                    }



                    fieldprop += "objID»" + objID + "±" + "objType»" + objType + "±" + "objName»" + objName + "±";
                    fieldprop += "type»" + type + "±" + "objValue»" + objValue + "±" + "imgsrc»" + imgsrc + "±";
                    fieldprop += "title»" + title + "±" + "align»" + align + "±" + "position»" + position + "±";
                    fieldprop += "objtop»" + objtop + "±" + "objleft»" + objleft + "±" + "objwidth»" + objwidth + "±";
                    fieldprop += "objheight»" + objheight + "±" + "zindex»" + zindex + "±" + "padding»" + padding + "±";
                    fieldprop += "display»" + display + "±" + "overflow»" + overflow + "±" + "fontfamily»" + fontfamily + "±";
                    fieldprop += "fontsize»" + fontsize + "±" + "fontweight»" + fontweight + "±" + "fontstyle»" + fontstyle + "±";
                    fieldprop += "fontcolor»" + fontcolor + "±" + "textdecoration»" + textdecoration + "±" + "textalign»" + textalign + "±";
                    fieldprop += "border»" + border + "±" + "backgroundcolor»" + backgroundcolor + "±" + "visibility»" + visibility + "±";
                    fieldprop += "maxlength»" + maxlength + "±" + "offsetwidth»" + offsetwidth + "±" + "offsetheight»" + offsetheight + "±";
                    fieldprop += "offsettop»" + offsettop + "±" + "offsetleft»" + offsetleft + "±" + "pixelwidth»" + pixelwidth + "±";
                    fieldprop += "pixelheight»" + pixelheight + "±" + "pixeltop»" + pixeltop + "±" + "lock»" + lock + "±";
                    fieldprop += "canmove»" + canmove + "±" + "canchangefontcolor»" + canchangefontcolor + "±" + "canchangefontsize»" + canchangefontsize + "±";
                    fieldprop += "canchangefont»" + canchangefont + "±" + "objclass»" + objclass + "±" + "onmouseoverclass»" + onmouseoverclass + "±";
                    fieldprop += "objTag»" + objTag + "±" + "GroupID»" + GroupID + "±" + "HGroupID»" + HGroupID + "±" + "AssociatedLabel»" + AssociatedLabel + "±" + "IsHGroupMain»" + IsHGroupMain + "±" + "repeat»" + repeat + "µ";
                }
                document.getElementById("<%=hid_FieldProperties.ClientID %>").value = fieldprop;
                return true;
            }
        }
    </script>
    <asp:HiddenField ID="hid_FieldProperties" runat="server" />
    <asp:HiddenField ID="hidEditorValues_Edit" runat="server" Value="" />
    <asp:HiddenField ID="hid_IsImgDel" runat="server" Value="no" />
    <asp:HiddenField ID="hid_SaveType" runat="server" Value="" />
    <asp:HiddenField ID="hid_PDFImageName" runat="server" Value="" />
    <asp:HiddenField ID="hid_HasGridlines" runat="server" Value="no" />
    <script type="text/javascript" src="<%=sitepath%>js/rgbcolor.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/Item/rightcontext.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-ui-1.8.21.custom.min.js"></script>
    <div id="div_TempAddMain" align="left" style="width: 100%;">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div style="padding: 3px">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel" runat="server" id="spnheader"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div class="estore_settingBox" style="min-width: 1195px;">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div class="mis_header_panel">
                <div align="left">
                    <div id="">
                        <div align="left" style="width: 100%;">
                            <div style="width: 60%">
                                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                                <asp:UpdatePanel ID="UPMessage" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div align="left" style="display: none">
                            <a href="#" onclick="showhideGridline();">
                                <%=objLanguage.GetLanguageConversion("Click_Here")%></a>
                            <div class="only5px">
                            </div>
                        </div>
                        <div align="left" style="width: 100%">
                            <div align="left" id="ODS_Editor" style="width: 950px">
                                <%--width changed by gajendra--%>
                                <style>
                                    .textalign {
                                        align: right;
                                    }
                                </style>
                                <style>
                                    .putpointer {
                                        cursor: move;
                                    }

                                    .fillthetextbox {
                                        background-color: #BED3FA;
                                        border-left: 1px;
                                        border-left-color: #000000;
                                        border-left-style: solid;
                                        border-bottom: 1px;
                                        border-bottom-color: #000000;
                                        border-bottom-style: solid;
                                        border-top: 1px;
                                        border-top-color: #000000;
                                        border-top-style: solid;
                                        border-right: 1px;
                                        border-right-color: #000000;
                                        border-right-style: solid;
                                    }

                                    .emptythetextbox {
                                        background-color: #FFFFFF;
                                        border-left: 1px;
                                        border-left-color: #000000;
                                        border-left-style: solid;
                                        border-bottom: 1px;
                                        border-bottom-color: #000000;
                                        border-bottom-style: solid;
                                        border-top: 1px;
                                        border-top-color: #000000;
                                        border-top-style: solid;
                                        border-right: 1px;
                                        border-right-color: #000000;
                                        border-right-style: solid;
                                    }
                                </style>
                                <style>
                                    .black_overlay {
                                        display: none;
                                        position: absolute;
                                        top: 0%;
                                        left: 0%;
                                        width: 100%;
                                        height: 100%;
                                        background-color: black;
                                        z-index: 1001;
                                        -moz-opacity: 0.8;
                                        opacity: .80;
                                        filter: alpha(opacity=80);
                                    }

                                    .white_content {
                                        display: none;
                                        position: absolute;
                                        top: 25%;
                                        left: 25%;
                                        width: 50%;
                                        height: 50%;
                                        padding: 16px;
                                        border: 16px solid orange;
                                        background-color: white;
                                        z-index: 1002;
                                        overflow: auto;
                                    }
                                </style>
                                <style type="text/css">
                                    .Buttonnew {
                                        font-size: 11px;
                                        width: auto;
                                        height: 22px;
                                        font-weight: bold;
                                        text-align: center;
                                        background-color: #EEEEEE;
                                        background: url( 'glass-24.gif' );
                                        border-left: 1px solid #5D5D5D;
                                        border-right: 1px solid #5D5D5D;
                                        border-top: 1px solid #5D5D5D;
                                        border-bottom: 1px solid #5D5D5D;
                                    }
                                </style>
                                <style type="text/css">
                                    UNKNOWN {
                                        background-image: none;
                                        margin: 0px;
                                    }

                                    .style3 {
                                        font-weight: bold;
                                        font-size: 14px;
                                    }
                                </style>
                                <style type="text/css">
                                    UNKNOWN {
                                        color: #ffffff;
                                    }

                                    .style2 {
                                        font-weight: bold;
                                    }
                                </style>
                                <link rel="stylesheet" href="../ODSprinting/css/default.css" media="screen,projection"
                                    type="text/css" />
                                <link rel="stylesheet" href="../ODSprinting/css/lightbox.css" media="screen,projection"
                                    type="text/css" />
                                <link media="all" href="../ODSprinting/Managment Print_files/EFlowColorPicker.css"
                                    type="text/css" rel="stylesheet">
                                <%-- <link href="../ODSprinting/Managment Print_files/pixaroo.css" type="text/css" rel="stylesheet">--%>
                                <link href="../ODSprinting/Managment Print_files/tool.css" type="text/css" rel="stylesheet">
                                <%--  <link href="../ODSprinting/Managment Print_files/main.css" type="text/css" rel="stylesheet">--%>
                                <link rel="stylesheet" href="../ODSprinting/js_color_picker_v2.css" media="screen">
                                <script src="../ODSprinting/Managment Print_files/WebResource.axd?VN='<%=VersionNumber%>'"
                                    type="text/javascript"></script>
                                <script src="../ODSprinting/Managment Print_files/js_color_picker_v2.js?VN='<%=VersionNumber%>'"
                                    type="text/javascript">
                                </script>
                                <input id="tmpImgPath" type="hidden">
                                <input id="ctl00_ContentPlaceHolder1_DMode" type="hidden" value="1" name="ctl00$ContentPlaceHolder1$DMode">
                                <input id="ctl00_ContentPlaceHolder1_sXDPI" type="hidden" value="90" name="ctl00$ContentPlaceHolder1$sXDPI">
                                <input id="ctl00_ContentPlaceHolder1_sYDPI" type="hidden" value="90" name="ctl00$ContentPlaceHolder1$sYDPI">
                                <input id="ctl00_ContentPlaceHolder1_CDivHPoint" type="hidden" value="250" name="ctl00$ContentPlaceHolder1$CDivHPoint">
                                <input id="ctl00_ContentPlaceHolder1_CDivWPoint" type="hidden" value="400" name="ctl00$ContentPlaceHolder1$CDivWPoint">
                                <input type="hidden" id="lockallobjects" name="lockallobjects" value="0">
                                <form id="odsform">
                                    <table width="950px">
                                        <tr valign="top">
                                            <td>
                                                <div style="float: left; width: 270px">
                                                    <asp:UpdateProgress ID="UpPro" runat="server" AssociatedUpdatePanelID="UpdatePanelCat1">
                                                        <ProgressTemplate>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:UpdatePanel ID="UpdatePanelCat1" runat="server" RenderMode="Inline">
                                                        <ContentTemplate>
                                                            <div style="float: left; width: 270px; overflow-y: <%=divFields_overflowy %>; overflow-x: hidden; height: <%=divFields_Height %>">
                                                                <div id="Rad_CollapsiblePanel">
                                                                    <style type="text/css">
                                                                        /* RadPanelBar needs to know the height of the images to calculate
                                                               its height accordingly when the images are not loaded yet. */ .RadPanelBar .rpImage {
                                                                            height: 19px;
                                                                        }

                                                                        .RadPanelBar .rpLevel1 .rpImage {
                                                                            height: 16px;
                                                                        }
                                                                    </style>
                                                                    <telerik:RadPanelBar runat="server" ID="RadPanelBar_btn" Height="600px" ExpandMode="MultipleExpandedItems">
                                                                        <Items>
                                                                            <telerik:RadPanelItem Value="1" Text="Company Fields" ImageUrl="Img/mail.gif" Expanded="True"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="2" Text="Customer Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="4" Text="Customer Contact Fields" ImageUrl="Img/mail.gif"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="3" Text="Supplier Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="13" Text="Supplier Contact Fields" ImageUrl="Img/mail.gif"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="5" Text="General Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="6" Text="Item Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="7" Text="Estimate Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="14" Text="Supplier RFQ Fields" ImageUrl="Img/mail.gif"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="15" Text="eStore Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="8" Text="Job Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="9" Text="Job Card Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="10" Text="Invoice Fields" ImageUrl="Img/mail.gif" Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="11" Text="Purchase Order Fields" ImageUrl="Img/mail.gif"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                            <telerik:RadPanelItem Value="12" Text="Delivery Note Fields" ImageUrl="Img/mail.gif"
                                                                                Visible="false">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadPanelItem>
                                                                        </Items>
                                                                    </telerik:RadPanelBar>
                                                                </div>
                                                                <asp:PlaceHolder runat="server" ID="phButtons"></asp:PlaceHolder>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div style="float: left; width: 5px">
                                                    &nbsp;
                                                </div>
                                            </td>
                                            <td>
                                                <div id="div_MainEditor" style="float: right; width: 930px">
                                                    <div align="left" style="width: 100%">
                                                        <table align="left" width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td valign="top" style="width: 100%">
                                                                    <table class="Panel-B" width="100%" border="0" cellspacing="0" cellpadding="2" align="left">
                                                                        <tr valign="top">
                                                                            <td id="td_MainEditor" class="Panel-B" width="100%" style="border-color: #D1DC03; border-width: thin; border-style: solid; height: 933px"
                                                                                valign="top">
                                                                                <div id="div">
                                                                                    <table width="100%" cellspacing="0" cellpadding="0" align="center">
                                                                                        <tr>
                                                                                            <td valign="top">
                                                                                                <table class="Panel-C" width="100%" border="0" cellspacing="0" cellpadding="8">
                                                                                                    <tr valign="top">
                                                                                                        <td width="100%" valign="top">
                                                                                                            <table align="left" width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                                                <tr valign="top">
                                                                                                                    <td>
                                                                                                                        <div id="ctl00_ContentPlaceHolder1_pnlToolBar" style="float: left; width: 100%; background-color: #FAFAFA; white-space: nowrap">
                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                <tr>
                                                                                                                                    <td class="menu_left">&nbsp;
                                                                                                                                    </td>
                                                                                                                                    <td valign="top" class="menu_bg" style="height: 100%; padding-top: 5px; white-space: nowrap">
                                                                                                                                        <div style="float: left; width: 35%">
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 20px; border-right: solid 1px #ffffff; width: 100%">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" valign="top" style="color: #000000; font-family: Arial; font-weight: bold; font-size: 11px; padding-left: 8px">
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Textual")%>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 24px; border-right: solid 1px #ffffff; width: 100%; vertical-align: middle">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" valign="middle" style="padding-left: 8px; width: 160px">
                                                                                                                                                        <asp:DropDownList ID="ddlfonts" CssClass="normalText" Width="180px" runat="server"
                                                                                                                                                            onchange="chngFont(this.options[this.selectedIndex].value)">
                                                                                                                                                        </asp:DropDownList>
                                                                                                                                                        </select>
                                                                                                                                                    </td>
                                                                                                                                                    <td align="left" valign="middle" style="width: 60px">
                                                                                                                                                        <select id="ctl00_ContentPlaceHolder1_lstSize" onmouseover="window.status='Font Size'"
                                                                                                                                                            style="font-size: 8pt; width: 50px; font-family: Calibri; cursor: pointer;" onmouseout="window.status=''"
                                                                                                                                                            onchange="chngSize(this.options[this.selectedIndex].value);" name="ctl00$ContentPlaceHolder1$lstSize">
                                                                                                                                                            <option value="6pt">6pt</option>
                                                                                                                                                            <option value="7pt">7pt</option>
                                                                                                                                                            <option value="8pt">8pt</option>
                                                                                                                                                            <option value="9pt">9pt</option>
                                                                                                                                                            <option value="10pt">10pt</option>
                                                                                                                                                            <option value="11pt">11pt</option>
                                                                                                                                                            <option value="12pt" selected>12pt</option>
                                                                                                                                                            <option value="13pt">13pt</option>
                                                                                                                                                            <option value="14pt">14pt</option>
                                                                                                                                                            <option value="15pt">15pt</option>
                                                                                                                                                            <option value="16pt">16pt</option>
                                                                                                                                                            <option value="17pt">17pt</option>
                                                                                                                                                            <option value="18pt">18pt</option>
                                                                                                                                                            <option value="19pt">19pt</option>
                                                                                                                                                            <option value="20pt">20pt</option>
                                                                                                                                                            <option value="21pt">21pt</option>
                                                                                                                                                            <option value="22pt">22pt</option>
                                                                                                                                                            <option value="23pt">23pt</option>
                                                                                                                                                            <option value="24pt">24pt</option>
                                                                                                                                                            <option value="25pt">25pt</option>
                                                                                                                                                            <option value="26pt">26pt</option>
                                                                                                                                                            <option value="27pt">27pt</option>
                                                                                                                                                            <option value="28pt">28pt</option>
                                                                                                                                                            <option value="29pt">29pt</option>
                                                                                                                                                            <option value="30pt">30pt</option>
                                                                                                                                                            <option value="31pt">31pt</option>
                                                                                                                                                            <option value="32pt">32pt</option>
                                                                                                                                                            <option value="33pt">33pt</option>
                                                                                                                                                            <option value="34pt">34pt</option>
                                                                                                                                                            <option value="35pt">35pt</option>
                                                                                                                                                            <option value="36pt">36pt</option>
                                                                                                                                                            <option value="37pt">37pt</option>
                                                                                                                                                            <option value="38pt">38pt</option>
                                                                                                                                                            <option value="39pt">39pt</option>
                                                                                                                                                            <option value="40pt">40pt</option>
                                                                                                                                                            <option value="41pt">41pt</option>
                                                                                                                                                            <option value="42pt">42pt</option>
                                                                                                                                                            <option value="43pt">43pt</option>
                                                                                                                                                            <option value="44pt">44pt</option>
                                                                                                                                                            <option value="45pt">45pt</option>
                                                                                                                                                            <option value="46pt">46pt</option>
                                                                                                                                                            <option value="47pt">47pt</option>
                                                                                                                                                            <option value="48pt">48pt</option>
                                                                                                                                                            <option value="49pt">49pt</option>
                                                                                                                                                            <option value="50pt">50pt</option>
                                                                                                                                                        </select>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="width: 50px">
                                                                                                                                                        <input id="txtColorNo" type="hidden">
                                                                                                                                                        <img id="imgtextcolor" onmouseover="mbtnOver(this);window.status='Font Color'" style="cursor: hand"
                                                                                                                                                            onclick="showColorPicker(this,document.getElementById('txtColorNo'),'../images/')"
                                                                                                                                                            onmouseout="mbtnOut(this);window.status=''" title="Font Color" alt="Font Color"
                                                                                                                                                            src="../ODSprinting/Managment Print_files/textcolor.gif">
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="2" cellspacing="1" style="height: 25px; border-right: solid 1px #ffffff; width: 100%; vertical-align: middle;">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgBld" onmouseover="mbtnOver(this);window.status='Bold'" style="cursor: hand"
                                                                                                                                                            onclick="chngBld()" onmouseout="mbtnOut(this);window.status=''" title="Bold"
                                                                                                                                                            alt="Bold" src="../ODSprinting/Managment Print_files/bold.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgIt" onmouseover="mbtnOver(this);window.status='Italic'" style="cursor: hand"
                                                                                                                                                            onclick="chngIt()" onmouseout="mbtnOut(this);window.status=''" title="Italic"
                                                                                                                                                            alt="Italic" src="../ODSprinting/Managment Print_files/italic.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgUnd" onmouseover="mbtnOver(this);window.status='Underline'" style="cursor: hand"
                                                                                                                                                            onclick="chngUnd()" onmouseout="mbtnOut(this);window.status=''" title="Underline"
                                                                                                                                                            alt="Underline" src="../ODSprinting/Managment Print_files/underline.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgLAlign" onmouseover="mbtnOver(this);window.status='Left align'" style="cursor: hand"
                                                                                                                                                            onclick="chngAlign('1')" onmouseout="mbtnOut(this);window.status=''" title="Left align"
                                                                                                                                                            alt="Left align" src="../ODSprinting/Managment Print_files/alignleft.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgCAlign" onmouseover="mbtnOver(this);window.status='Center align'" style="cursor: hand"
                                                                                                                                                            onclick="chngAlign('2')" onmouseout="mbtnOut(this);window.status=''" title="Center align"
                                                                                                                                                            alt="Center align" src="../ODSprinting/Managment Print_files/aligncenter.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgRAlign" onmouseover="mbtnOver(this);window.status='Right align'" style="cursor: hand"
                                                                                                                                                            onclick="chngAlign('3')" onmouseout="mbtnOut(this);window.status=''" title="Right align"
                                                                                                                                                            alt="Right align" src="../ODSprinting/Managment Print_files/alignright.gif">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgHorizontalRule" onmouseover="mbtnOver(this);window.status='Horizontal Rule'"
                                                                                                                                                            style="cursor: hand" onclick="showhideHrRule()" onmouseout="mbtnOut(this);window.status=''"
                                                                                                                                                            title="Horizontal Rule" alt="Horizontal Rule" src="../ODSprinting/Managment Print_files/hrline.jpg">
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <img id="imgGrid" onmouseover="mbtnOver(this);window.status='Gridlines'" style="cursor: hand"
                                                                                                                                                            onclick="showhideGridline()" onmouseout="mbtnOut(this);window.status=''" title="Grid lines"
                                                                                                                                                            alt="Grid lines" src="../ODSprinting/Managment Print_files/grid2.gif">
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </div>
                                                                                                                                        <div style="float: left; width: 12%">
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 20px; border-right: solid 1px #ffffff; border-left: solid 1px #B2B2B2; width: 100%;">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" valign="top" style="color: #000000; font-family: Arial; font-weight: bold; font-size: 11px; padding-left: 8px">
                                                                                                                                                        <%--Basic--%>
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Zoom")%>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="2" cellspacing="1" style="height: 25px; border-right: solid 1px #ffffff; border-left: solid 1px #B2B2B2; width: 100%; vertical-align: middle">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <a href="#" title="Zoom Out">
                                                                                                                                                            <img src="../ODSprinting/zoom_in.gif" style="cursor: pointer; padding: 2px 0px 0px 2px"
                                                                                                                                                                onclick="javascript:zoomit('i')"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <a href="#" title="Zoom In">
                                                                                                                                                            <img src="../ODSprinting/zoom_out.gif" style="cursor: pointer; padding: 2px 0px 0px 2px"
                                                                                                                                                                onclick="javascript:zoomit('o')"></a>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="2" cellspacing="1" style="height: 24px; border-right: solid 1px #ffffff; border-left: solid 1px #B2B2B2; width: 100%; vertical-align: middle;">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="display: none">
                                                                                                                                                        <a href="#" title="Save">
                                                                                                                                                            <img alt="Save" src="../ODSprinting/Managment Print_files/Save.PNG" style="padding: 2px 0px 0px 2px"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="display: none">
                                                                                                                                                        <a href="#" title="Save As">
                                                                                                                                                            <img alt="SaveAs" src="../ODSprinting/Managment Print_files/SaveAs.gif"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="display: none">
                                                                                                                                                        <a href="#" title="Copy">
                                                                                                                                                            <img alt="Copy" src="../ODSprinting/Managment Print_files/Copy.png"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="display: none">
                                                                                                                                                        <a href="#" title="Paste">
                                                                                                                                                            <img alt="Paste" src="../ODSprinting/Managment Print_files/Paste.png"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <a href="#" title="Redo">
                                                                                                                                                            <img id="redoimg" src="../ODSprinting/Managment Print_files/Redo.png" onclick="javascript:return Redo();"
                                                                                                                                                                style="cursor: pointer; padding: 0px 3px 0px 3px"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle">
                                                                                                                                                        <a href="#" title="Undo">
                                                                                                                                                            <img id="undoimg" src="../ODSprinting/Managment Print_files/Undo.gif" onclick="javascript:return Undo();"
                                                                                                                                                                style="cursor: pointer; padding: 0px 3px 0px 3px">
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </div>
                                                                                                                                        <div style="float: left; width: 13%">
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 20px; border-left: solid 1px #B2B2B2; border-right: solid 1px #ffffff; width: 100%;">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" valign="top" style="color: #000000; font-family: Arial; font-weight: bold; font-size: 11px; padding-left: 8px">
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Insert") %>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="2" cellspacing="1" style="height: 25px; border-left: solid 1px #B2B2B2; border-right: solid 1px #ffffff; width: 100%; vertical-align: middle">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="Menu" align="left" valign="middle">
                                                                                                                                                        <img style="cursor: hand" onclick="addtextbox(2)" alt="Add Textbox" src="../ODSprinting/Managment Print_files/add_text.gif">
                                                                                                                                                        <div id="crtlDiv" style="border-right: black 1px solid; border-top: black 1px solid; z-index: 5; left: 450px; visibility: hidden; border-left: black 1px solid; width: 407px; border-bottom: black 1px solid; position: absolute; top: 300px; height: 79px; background-color: #c0c0c0">
                                                                                                                                                            <table style="width: 401px" cellspacing="0" cellpadding="0" border="0">
                                                                                                                                                                <tr>
                                                                                                                                                                    <td class="header2" style="width: 204px; height: 38px">
                                                                                                                                                                        <span>&nbsp;<span style="font-size: 10pt; color: #000033; font-family: Calibri"> <strong>Object Name :</strong></span></span>
                                                                                                                                                                    </td>
                                                                                                                                                                    <td>
                                                                                                                                                                        <input class="input2" id="objName" name="objName">
                                                                                                                                                                    </td>
                                                                                                                                                                    <td>
                                                                                                                                                                        <input id="BtnAddCrl" style="width: 75px; font-family: Calibri" onclick="addCtrl(1);"
                                                                                                                                                                            type="button" value="Add" name="BtnAddCrl">
                                                                                                                                                                    </td>
                                                                                                                                                                    <td>
                                                                                                                                                                        <input id="Button1" style="width: 75px; font-family: Calibri" onclick="showHidDiv();"
                                                                                                                                                                            type="button" value="Cancel" name="Button1">
                                                                                                                                                                    </td>
                                                                                                                                                                </tr>
                                                                                                                                                                <tr>
                                                                                                                                                                    <td class="header2" style="width: 195px; height: 40px">
                                                                                                                                                                        <input id="chkBx" type="checkbox"><span style="font-family: Calibri"><span style="font-size: 10pt">
                                                                                                                                                                            <span style="color: #000033"><strong>
                                                                                                                                                                                <%=objLanguage.GetLanguageConversion("Multi_Line")%></strong></span></span></span>
                                                                                                                                                                    </td>
                                                                                                                                                                </tr>
                                                                                                                                                            </table>
                                                                                                                                                        </div>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="2" cellspacing="1" style="height: 24px; border-left: solid 1px #B2B2B2; border-right: solid 1px #ffffff; width: 100%; vertical-align: middle">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="Menu" align="left" valign="middle">
                                                                                                                                                        <telerik:DialogOpener runat="server" ID="DialogOpener1"></telerik:DialogOpener>
                                                                                                                                                        <img style="cursor: hand" onclick="$find('<%= DialogOpener1.ClientID %>').open('ImageManager', {CssClasses: []});return false;"
                                                                                                                                                            alt="Add Image" src="../ODSprinting/Managment Print_files/add_image.gif" />
                                                                                                                                                        <script type="text/javascript">

                                                                                                                                                            function ImageManagerFunction(sender, args) {
                                                                                                                                                                if (!args) {
                                                                                                                                                                    alert('<%=objLanguage.GetLanguageConversion("No_Image_File_Was_Selected")%>');
                                                                                                                                                                    return false;
                                                                                                                                                                }
                                                                                                                                                                var selectedItem = args.get_value();
                                                                                                                                                                if ($telerik.isIE) {

                                                                                                                                                                }
                                                                                                                                                                else {
                                                                                                                                                                    var displayName = '';
                                                                                                                                                                    var src = args.value.getAttribute("src", 2);


                                                                                                                                                                    if (src.indexOf("~securepath~") !== -1) {
                                                                                                                                                                        var Imagename = src.split('~securepath~');

                                                                                                                                                                        displayName = Imagename[1];

                                                                                                                                                                    }
                                                                                                                                                                    else {
                                                                                                                                                                        displayName = (src.length > 0 && src.indexOf("/") != -1) ? src.substr(src.lastIndexOf("/") + 1, src.length - 1) : src;

                                                                                                                                                                    }

                                                                                                                                                                    var mode = 'add';
                                                                                                                                                                    var imgWidth = '300';
                                                                                                                                                                    var imgHeight = '100';

                                                                                                                                                                    BindImg(displayName, imgWidth, imgHeight, mode, src);
                                                                                                                                                                    CloseOnReload();
                                                                                                                                                                }
                                                                                                                                                            }




                                                                                                                                                        </script>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </div>
                                                                                                                                        <div style="float: left; width: 12%">
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 20px; border-left: solid 1px #B2B2B2; width: 100%;">
                                                                                                                                                <tr>
                                                                                                                                                    <td align="left" valign="top" style="color: #000000; font-family: Arial; font-weight: bold; font-size: 11px; padding-left: 8px">
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Advanced") %>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="0" cellspacing="0" style="height: 25px; border-left: solid 1px #B2B2B2; width: 100%; vertical-align: middle;">
                                                                                                                                                <tr>
                                                                                                                                                    <td style="width: 3px">&nbsp;
                                                                                                                                                    </td>
                                                                                                                                                    <td align="left" valign="middle" style="padding-left: 2px">
                                                                                                                                                        <select style="font-size: 10px; width: 100px" name="alignment" onchange="alignthis(this.value)">
                                                                                                                                                            <option style="font-size: 10px;" value="left">
                                                                                                                                                                <%=objLanguage.GetLanguageConversion("Align_Left")%></option>
                                                                                                                                                            <option style="font-size: 10px;" value="center">
                                                                                                                                                                <%=objLanguage.GetLanguageConversion("Align_Center")%></option>
                                                                                                                                                            <option style="font-size: 10px;" value="right">
                                                                                                                                                                <%=objLanguage.GetLanguageConversion("Align_Right")%></option>
                                                                                                                                                        </select>
                                                                                                                                                    </td>
                                                                                                                                                    <td style="padding-left: 5px">&nbsp;
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="center" valign="middle" style="width: 22px; padding: 0px 5px 0px 5px">
                                                                                                                                                        <a href="javascript:deleteselected()" title="Delete Selectecd items">
                                                                                                                                                            <img alt="Delete" src="../ODSprinting/delete_icon.gif" style="cursor: pointer;"></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 4px 0px 4px; width: 22px">
                                                                                                                                                        <a href="javascript:LockObj()" title="Lock Objects"><span id="lockobjects">
                                                                                                                                                            <%=objLanguage.GetLanguageConversion("Lock")%></span></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 4px 0px 4px; width: 22px"
                                                                                                                                                        id="AdjustTooltd" runat="server">
                                                                                                                                                        <a href="javascript:CallAdjustProperties()" title="Edit Properties">
                                                                                                                                                            <%=objLanguage.GetLanguageConversion("Adjust")%></a>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 4px 0px 4px; width: 22px">
                                                                                                                                                        <a href="javascript:RepeatObj()" title="Repeat Objects in each pages"><span id="repeatobjects">
                                                                                                                                                            <%=objLanguage.GetLanguageConversion("Repeat")%></span></a>
                                                                                                                                                    </td>

                                                                                                                                                    <td align="center" style="width: 120px; height: 19px; display: none" valign="middle">
                                                                                                                                                        <select id="ctl00_ContentPlaceHolder1_imgBk" style="font-size: 8pt; width: 100px; font-family: Calibri"
                                                                                                                                                            onchange="change_image_background_here(this.value)" name="ctl00_ContentPlaceHolder1_imgBk">
                                                                                                                                                            <option value="" selected>Backgrounds</option>
                                                                                                                                                            <option value="transparentpixel.gif" selected>None</option>
                                                                                                                                                            <option value="bg1.jpg" selected>Default</option>
                                                                                                                                                        </select>
                                                                                                                                                    </td>
                                                                                                                                                    <td align="center" valign="middle" style="width: 22px; display: none">
                                                                                                                                                        <a href="../ODSprinting/form.html" class="lbOn"></a>
                                                                                                                                                        <img style="cursor: hand" onclick="addBKImg()" alt="Change Background" src="../ODSprinting/Managment Print_files/bkimages.jpg">
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                            <table cellpadding="0" cellspacing="1" style="height: 24px; border-left: solid 1px #B2B2B2; width: 100%; vertical-align: middle;">
                                                                                                                                                <tr>
                                                                                                                                                    <td style="width: 3px">&nbsp;
                                                                                                                                                    </td>
                                                                                                                                                    <td align="left">
                                                                                                                                                        <asp:UpdatePanel ID="updpnlGroup" runat="server" RenderMode="Inline" UpdateMode="Always">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:DropDownList ID="ddlGroup" onchange="ShowHideGroup('show');SetGroup(this.value)"
                                                                                                                                                                    Style="font-size: 10px; width: 115px" runat="server">
                                                                                                                                                                </asp:DropDownList>
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 4px 0px 4px; width: 22px"
                                                                                                                                                        id="editgroupTooltd" runat="server">
                                                                                                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/Edit.gif" OnClientClick="javascript:Loadingimg();"
                                                                                                                                                                    OnClick="img_Groupeditbtnclick" />
                                                                                                                                                                <script type="text/javascript">
                                                                                                                                                                    function Loadingimg() {
                                                                                                                                                                        var ddlGroup = document.getElementById("<%=ddlGroup.ClientID%>");
                                                                                                                                                                        var txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");
                                                                                                                                                                        if (ddlGroup.options[ddlGroup.selectedIndex].value != "0" && ddlGroup.options[ddlGroup.selectedIndex].value != "-2" && ddlGroup.options[ddlGroup.selectedIndex].value != "-1") {

                                                                                                                                                                            document.getElementById("ds00").style.display = "block";
                                                                                                                                                                            document.getElementById("div_Load").style.display = "block";
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                    function EditGroup() {

                                                                                                                                                                        var ddlGroup = document.getElementById("<%=ddlGroup.ClientID%>");
                                                                                                                                                                        var txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");



                                                                                                                                                                        if (ddlGroup.options[ddlGroup.selectedIndex].value != "0" && ddlGroup.options[ddlGroup.selectedIndex].value != "-2" && ddlGroup.options[ddlGroup.selectedIndex].value != "-1") {



                                                                                                                                                                            showDivPopupCenter('div_Group', '200');


                                                                                                                                                                        }
                                                                                                                                                                        else {
                                                                                                                                                                            alert('<%=objLanguage.GetLanguageConversion("Please_Select_Atleast_One_Group_Name")%>');

                                                                                                                                                                        }
                                                                                                                                                                        document.getElementById("ds00").style.display = "none";
                                                                                                                                                                        document.getElementById("div_Load").style.display = "none";
                                                                                                                                                                    }


                                                                                                                                                                </script>
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 4px 4px 0px 4px; width: 22px"
                                                                                                                                                        id="deletegroupTooltd" runat="server">
                                                                                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:ImageButton ID="imgbtnDeleteGroup" runat="server" ImageUrl="../ODSprinting/delete_icon.gif"
                                                                                                                                                                    AlternateText="Remove Group" ToolTip="Remove Group" OnClick="imgbtnDeleteGroup_OnClick"
                                                                                                                                                                    OnClientClick="return window.confirm('Are You Sure You Want To Remove The Group?');" />
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td align="left">
                                                                                                                                                        <asp:UpdatePanel ID="updpnlHGroup" runat="server">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:DropDownList ID="ddlHGroup" onchange="ShowHideHGroup('show');SetHGroup(this.value);"
                                                                                                                                                                    Style="font-size: 10px; width: 127px" runat="server">
                                                                                                                                                                </asp:DropDownList>
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 4px 0px 4px; width: 22px"
                                                                                                                                                        id="editHgroupTooltd" runat="server">
                                                                                                                                                        <asp:UpdatePanel ID="Updatepnl" runat="server">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:ImageButton ID="btn_image" runat="server" ImageUrl="../Images/Edit.gif" OnClientClick="javascript:Loadingimg1();"
                                                                                                                                                                    OnClick="img_heditbtnclick" />
                                                                                                                                                                <script type="text/javascript">
                                                                                                                                                                    function Loadingimg1() {

                                                                                                                                                                        var ddlHGroup = document.getElementById("<%=ddlHGroup.ClientID%>");
                                                                                                                                                                        var txtHGroupName = document.getElementById("<%=txtHGroupName.ClientID%>");
                                                                                                                                                                        if (ddlHGroup.options[ddlHGroup.selectedIndex].value != "0" && ddlHGroup.options[ddlHGroup.selectedIndex].value != "-2" && ddlHGroup.options[ddlHGroup.selectedIndex].value != "-1") {
                                                                                                                                                                            document.getElementById("ds00").style.display = "block";
                                                                                                                                                                            document.getElementById("div_Load").style.display = "block";
                                                                                                                                                                        }
                                                                                                                                                                    }


                                                                                                                                                                    function EditHGroup() {
                                                                                                                                                                        var ddlHGroup = document.getElementById("<%=ddlHGroup.ClientID%>");
                                                                                                                                                                        var txtHGroupName = document.getElementById("<%=txtHGroupName.ClientID%>");

                                                                                                                                                                        if (ddlHGroup.options[ddlHGroup.selectedIndex].value != "0" && ddlHGroup.options[ddlHGroup.selectedIndex].value != "-2" && ddlHGroup.options[ddlHGroup.selectedIndex].value != "-1") {
                                                                                                                                                                            showDivPopupCenter('div_HGroup', '200');

                                                                                                                                                                        }
                                                                                                                                                                        else {
                                                                                                                                                                            alert('<%=objLanguage.GetLanguageConversion("Please_Select_Atleast_One_Horizontal_Group_Name") %>');

                                                                                                                                                                        }
                                                                                                                                                                        document.getElementById("ds00").style.display = "none";
                                                                                                                                                                        document.getElementById("div_Load").style.display = "none";
                                                                                                                                                                    }
                                                                                                                                                                </script>
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 4px 4px 0px 4px; width: 22px"
                                                                                                                                                        id="deleteHgroupTooltd" runat="server">
                                                                                                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                                                                                                                            <ContentTemplate>
                                                                                                                                                                <asp:ImageButton ID="imgbtnDeleteHGroup" runat="server" ImageUrl="../ODSprinting/delete_icon.gif"
                                                                                                                                                                    AlternateText="Remove Horizontal Group" ToolTip="Remove Horizontal Group" OnClick="imgbtnDeleteHGroup_OnClick"
                                                                                                                                                                    OnClientClick="return window.confirm('Are you sure you want to remove the Group?');" />
                                                                                                                                                            </ContentTemplate>
                                                                                                                                                        </asp:UpdatePanel>
                                                                                                                                                    </td>
                                                                                                                                                    <td class="Menu" align="left" valign="middle" style="padding: 0px 5px 1px 5px; width: 22px; display: none">
                                                                                                                                                        <img src="../images/plus.gif" onclick="javascript:ShowHideHGroup('show');" title="Add Group"
                                                                                                                                                            alt="Add Group" />
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </div>
                                                                                                                                    </td>
                                                                                                                                    <td class="menu_right">&nbsp;
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </div>
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                                                                                                                            <ContentTemplate>
                                                                                                                                <div id="div_Group" style="display: none; position: absolute; z-index: 1000; width: 30%;">
                                                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                        <tr>
                                                                                                                                            <td colspan="2" class="popup-top-leftcorner">&nbsp;
                                                                                                                                            </td>
                                                                                                                                            <td class="popup-top-middlebg">
                                                                                                                                                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                                                                                                                                    <b>
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Add_Group")%></b>
                                                                                                                                                </div>
                                                                                                                                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                                                                                                                                    <div class="CancelButtonDiv">
                                                                                                                                                        <asp:ImageButton ID="imgCloseGroup" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
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
                                                                                                                                                <div id="padding">
                                                                                                                                                    <div align="left" style="width: 100%">
                                                                                                                                                        <div align="left" style="width: 100%">
                                                                                                                                                            <div style="float: left; width: 25%">
                                                                                                                                                                <asp:Label ID="lblGroupName" runat="server" Text="Group Name" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Group_Name")%></asp:Label>
                                                                                                                                                            </div>
                                                                                                                                                            <div class="box">
                                                                                                                                                                <asp:TextBox ID="txtGroupName" runat="server" Width="200px" SkinID="textPad"></asp:TextBox>
                                                                                                                                                                <span id="spnerrGroupName" class="spanerrorMsg" style="display: none; width: 200px;">
                                                                                                                                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Group_Name")%></span>
                                                                                                                                                            </div>
                                                                                                                                                            <div class="onlyEmpty">
                                                                                                                                                            </div>
                                                                                                                                                        </div>
                                                                                                                                                        <div align="left" style="width: 100%; clear: both">
                                                                                                                                                            <div style="float: left; width: 25%">
                                                                                                                                                                <asp:Label ID="lblAutoExpand" runat="server" Text="Auto Expand" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Auto_Expand")%></asp:Label>
                                                                                                                                                            </div>
                                                                                                                                                            <div class="box">
                                                                                                                                                                <asp:CheckBox ID="chkAutoExpand" runat="server" />
                                                                                                                                                            </div>
                                                                                                                                                        </div>
                                                                                                                                                        <div align="left" style="width: 100%;">
                                                                                                                                                            <div style="float: left; width: 26%">
                                                                                                                                                                &nbsp;
                                                                                                                                                            </div>
                                                                                                                                                            <div style="float: left; padding-left: 80px;">
                                                                                                                                                                <asp:UpdatePanel ID="UPSAVEGroup" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                                                                                                                                    <ContentTemplate>
                                                                                                                                                                        <asp:Button ID="btnCancelGroup" Text="Cancel" CssClass="button" Visible="false" runat="server"
                                                                                                                                                                            OnClientClick="javascript:ShowHideGroup('hide');return false;" />
                                                                                                                                                                        <asp:Button ID="btnSaveGroup" Text="Save" CssClass="button" runat="server" OnClick="btnSaveGroup_OnClick"
                                                                                                                                                                            OnClientClick="javascript:return ValidateGroup();" />
                                                                                                                                                                    </ContentTemplate>
                                                                                                                                                                </asp:UpdatePanel>
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
                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>
                                                                                                                        <div class="onlyEmpty">
                                                                                                                        </div>
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="Inline">
                                                                                                                            <ContentTemplate>
                                                                                                                                <div id="div_HGroup" style="display: none; position: absolute; z-index: 1000; width: 30%;">
                                                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                        <tr>
                                                                                                                                            <td colspan="2" class="popup-top-leftcorner">&nbsp;
                                                                                                                                            </td>
                                                                                                                                            <td class="popup-top-middlebg">
                                                                                                                                                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                                                                                                                                    <b>
                                                                                                                                                        <%=objLanguage.GetLanguageConversion("Add_HGroup")%></b>
                                                                                                                                                </div>
                                                                                                                                                <div style="float: right; padding-top: 6px; padding-right: 10px">
                                                                                                                                                    <div class="CancelButtonDiv">
                                                                                                                                                        <asp:ImageButton ID="imgCloseHGroup" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                                                                                                                            runat="server" CausesValidation="false" OnClientClick="javascript:ShowHideHGroup('hide');return false;" />
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
                                                                                                                                                <div id="Div1">
                                                                                                                                                    <div align="left" style="width: 100%">
                                                                                                                                                        <div align="left" style="width: 100%">
                                                                                                                                                            <div style="float: left; width: 26%">
                                                                                                                                                                <asp:Label ID="lblHGroupName" runat="server" Text="HGroup Name" CssClass="normalText"><%=objLanguage.GetLanguageConversion("HgroupName")%></asp:Label>
                                                                                                                                                            </div>
                                                                                                                                                            <div class="box">
                                                                                                                                                                <asp:TextBox ID="txtHGroupName" runat="server" Width="200px" SkinID="textPad"></asp:TextBox>
                                                                                                                                                                <span id="spnerrHGroupName" class="spanerrorMsg" style="display: none; width: 200px;">
                                                                                                                                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_HGroup_Name")%></span>
                                                                                                                                                            </div>
                                                                                                                                                        </div>
                                                                                                                                                        <div align="left" style="width: 100%; clear: both">
                                                                                                                                                            <div style="float: left; width: 26%">
                                                                                                                                                                <asp:Label ID="Label6" runat="server" Text="Remove Label" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Remove_Label")%></asp:Label>
                                                                                                                                                            </div>
                                                                                                                                                            <div class="box">
                                                                                                                                                                <asp:CheckBox ID="chkIsDeleteAllIfBlank" runat="server" />
                                                                                                                                                            </div>
                                                                                                                                                        </div>
                                                                                                                                                        <div align="left" style="width: 100%;">
                                                                                                                                                            <div style="float: left; width: 26%">
                                                                                                                                                                &nbsp;
                                                                                                                                                            </div>
                                                                                                                                                            <div style="float: left; padding-left: 80px;">
                                                                                                                                                                <asp:UpdatePanel ID="UPSAVEHGroup" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                                                                                                                                    <ContentTemplate>
                                                                                                                                                                        <asp:Button ID="btnCancelHGroup" Text="Cancel" CssClass="button" Visible="false"
                                                                                                                                                                            runat="server" OnClientClick="javascript:ShowHideHGroup('hide');return false;" />
                                                                                                                                                                        <asp:Button ID="btnSaveHGroup" Text="Save" CssClass="button" runat="server" OnClick="btnSaveHGroup_OnClick"
                                                                                                                                                                            OnClientClick="javascript:return ValidateHGroup();" />
                                                                                                                                                                    </ContentTemplate>
                                                                                                                                                                </asp:UpdatePanel>
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
                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>
                                                                                                                        <div class="onlyEmpty">
                                                                                                                        </div>
                                                                                                                        <div align="left" id="update_artwork">
                                                                                                                            <span class="subheader"><b></b></span>
                                                                                                                            <table id="tbl_Editor" style="height: 1290px; width: <%=EditorWidth%>;">
                                                                                                                                <tr>
                                                                                                                                    <td id="tdDesign" style="display: block; position: absolute" valign="top">
                                                                                                                                        <input type="hidden" value="100" id="zoomvalue" name="zoomvalue">
                                                                                                                                        <input type="hidden" value="" name="ctl00_ContentPlaceHolder1_CtrlList_values">
                                                                                                                                        <input type="hidden" value="" name="ctl00_ContentPlaceHolder1_Div1_values">
                                                                                                                                        <input id="ctl00_ContentPlaceHolder1_chkBrows" type="hidden" value="0" name="ctl00_ContentPlaceHolder1_chkBrows">
                                                                                                                                        <input name="bgimg" value="" type="hidden">
                                                                                                                                        <input id="ctl00_ContentPlaceHolder1_imgPath" type="hidden" value="1210/1210_Background.jpg"
                                                                                                                                            name="ctl00_ContentPlaceHolder1_imgPath">
                                                                                                                                        <div align="center" id="ctl00_ContentPlaceHolder1_Div1" style="background: white; left: 0px; overflow: visible; width: <%=EditorWidth%>; height: <%=EditorHeight%>; position: relative; top: 0px; z-index: 1; overflow-y: scroll; overflow-x: hidden; border: 0px dotted #ADADAD;">
                                                                                                                                            <div id="ctl00_ContentPlaceHolder1_CardDiv" class="grid" style="left: 0px; overflow: visible; position: absolute; top: 0px; background-color: transparent">
                                                                                                                                                <%-- <div class="ghost-select111"><span></span></div>--%>
                                                                                                                                            </div>
                                                                                                                                        </div>
                                                                                                                                        <input id="ctl00_ContentPlaceHolder1_txtHtml" type="hidden" name="ctl00_ContentPlaceHolder1_txtHtml">
                                                                                                                                    </td>
                                                                                                                                    <td>
                                                                                                                                        <div id="div_EditFields" style="display: none; position: absolute; z-index: 100000; left: 471px; top: 481px;">
                                                                                                                                            <img style="position: absolute; top: -26px; left: 10px; z-index: 100000;" src="../images/thought_pointer.gif">
                                                                                                                                            <table style="border-width: 0pt; width: 314px;" cellpadding="0" cellspacing="0">
                                                                                                                                                <tbody>
                                                                                                                                                    <tr>
                                                                                                                                                        <td>
                                                                                                                                                            <img src="../images/thought_top_lt.gif" />
                                                                                                                                                        </td>
                                                                                                                                                        <td style="background-image: url(../images/thought_top_tl.gif);"></td>
                                                                                                                                                        <td>
                                                                                                                                                            <img src="../images/thought_top_rt.gif" />
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                    <tr>
                                                                                                                                                        <td style="background-image: url(../images/thought_tl_lt.gif);"></td>
                                                                                                                                                        <td id="td_Edit" style="background-image: url(../images/thought_bot_center.gif); width: 314px; height: 85px;">
                                                                                                                                                            <table style="background-image: url(../images/thought_bot_center.gif); position: absolute; left: 4px; top: 4px;">
                                                                                                                                                                <tbody>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td align="left">
                                                                                                                                                                            <span id="spn_EditFieldName" style="font-weight: bold;"></span>
                                                                                                                                                                        </td>
                                                                                                                                                                        <td style="text-align: right;" onclick="javascript:CloseEditWindow();">
                                                                                                                                                                            <a title="Close" style="text-decoration: none;" href="javascript://" onclick="CloseEditWindow();"
                                                                                                                                                                                id="btnCloseTextEdit">Close<img style="margin-left: 2px;" src="../images/close_window.gif"
                                                                                                                                                                                    align="absmiddle" border="0"></a>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            <div class="studioToolbarContainer" style="height: 16px; width: 100%;">
                                                                                                                                                                                <div style="width: 100%;" class="studioMiniToolbar">
                                                                                                                                                                                    <div style="margin: 2px 0px 3px;" class="studioToolbarItem" onmouseover="javascript:EditOptionOver(this);window.status='Bold'"
                                                                                                                                                                                        onmouseout="javascript:EditOptionOut(this);window.status=''">
                                                                                                                                                                                        <img style="" src="../images/bold1.gif" title="Bold" id="toolbarButton_bold_button_mini_toolbar_vpls_text_5"
                                                                                                                                                                                            class="studioToolbarImage" width="21" height="20" border="0" onclick="javascript:CallEditOptions('bold');" />
                                                                                                                                                                                    </div>
                                                                                                                                                                                    <div style="margin: 2px 0px 3px;" class="studioToolbarItem" onmouseover="javascript:EditOptionOver(this);window.status='Bold'"
                                                                                                                                                                                        onmouseout="javascript:EditOptionOut(this);window.status=''">
                                                                                                                                                                                        <img style="" src="../images/italic1.gif" title="Italic" id="toolbarButton_italic_button_mini_toolbar_vpls_text_5"
                                                                                                                                                                                            class="studioToolbarImage" width="21" height="20" border="0" onclick="javascript:CallEditOptions('italic');" />
                                                                                                                                                                                    </div>
                                                                                                                                                                                    <div style="margin: 2px 0px 3px; display: none" class="studioToolbarItem">
                                                                                                                                                                                        <img style="" src="../images/underline.gif" title="Underline" id="Img1" class="studioToolbarImage"
                                                                                                                                                                                            width="21" height="20" border="0" />
                                                                                                                                                                                    </div>
                                                                                                                                                                                    <div style="margin: 2px 0px 3px; display: none" class="studioToolbarItem">
                                                                                                                                                                                        <img style="" src="../images/special_chars1.gif" title="Lookup special characters"
                                                                                                                                                                                            id="toolbarButton_special_chars_button_mini_toolbar_vpls_text_5" class="studioToolbarImage"
                                                                                                                                                                                            width="21" height="20" border="0" />
                                                                                                                                                                                    </div>
                                                                                                                                                                                    <br style="clear: left;">
                                                                                                                                                                                </div>
                                                                                                                                                                            </div>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                    <tr>
                                                                                                                                                                        <td colspan="2">
                                                                                                                                                                            <div style="overflow-x: hidden; width: 300px;" id="vpls_text_5_innerContainer">
                                                                                                                                                                                <div id="vpls_text_5_inlineText" style="border: 1px solid black; width: 298px; height: 20px;">
                                                                                                                                                                                    <span id="spn_txtTopLeft"></span>
                                                                                                                                                                                    <asp:TextBox ID="txtEditField" runat="server" Style="display: none; border: 0px; width: 296px; height: 18px; margin: 0px; clear: both; background-image: url(../images/thought_bot_center.gif);"></asp:TextBox>
                                                                                                                                                                                </div>
                                                                                                                                                                            </div>
                                                                                                                                                                            <div style="margin-top: 5px;">
                                                                                                                                                                                <%=objlang.GetValueOnLang("Use the toolbar at the top of the page for more editing options")%>.
                                                                                                                                                                            </div>
                                                                                                                                                                        </td>
                                                                                                                                                                    </tr>
                                                                                                                                                                </tbody>
                                                                                                                                                            </table>
                                                                                                                                                        </td>
                                                                                                                                                        <td style="background-image: url(../images/thought_tl_rt.gif);"></td>
                                                                                                                                                    </tr>
                                                                                                                                                    <tr>
                                                                                                                                                        <td>
                                                                                                                                                            <img src="../images/thought_bot_lt.gif" />
                                                                                                                                                        </td>
                                                                                                                                                        <td style="background-image: url(../images/thought_bot_tl.gif);"></td>
                                                                                                                                                        <td>
                                                                                                                                                            <img src="../images/thought_bot_rt.gif" />
                                                                                                                                                        </td>
                                                                                                                                                    </tr>
                                                                                                                                                </tbody>
                                                                                                                                            </table>
                                                                                                                                        </div>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </div>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="only10px">
                                                    </div>
                                                    <div align="left" style="width: 100%">
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%">
                                                                <asp:Label ID="Label5" runat="server" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Select_PDF")%></asp:Label>
                                                            </div>
                                                            <div class="box">
                                                                <asp:DropDownList ID="ddlTemplatePDF" runat="server" CssClass="normalText" Width="250px"
                                                                    onchange="javascript:InsertPDF(this.value);">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="lblTaxName" runat="server" Text="Layout Name" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Layout_Name")%></asp:Label>
                                                                <span style="color: Red; padding-left: 3px">*</span>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtName" runat="server" Width="400px" SkinID="textPad" onfocus="javascript:setfocus(this);"
                                                                    onblur="CallonBlur(this.value,'spn_txtName');CheckExist(this.value);" MaxLength="100"></asp:TextBox>
                                                                <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Layout_Name")%></span><span id="spn_txtProductNameCheck"
                                                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"><%=objLanguage.GetLanguageConversion("Product_Name_Already_Exists")%></span>
                                                            </div>
                                                            <script>
                                                                function setfocus(obj) {
                                                                    unSelAll();
                                                                    obj.focus();

                                                                }
                                                                function chkSplit_checked() {

                                                                    if ((document.getElementById("<%=chkSplit.ClientID %>")).checked) {

                                                                        document.getElementById("<%=chkadjusted.ClientID %>").checked = false;
                                                                    }

                                                                }
                                                                function chkadjusted_checked() {


                                                                    if ((document.getElementById("<%=chkadjusted.ClientID %>")).checked) {

                                                                        document.getElementById("<%=chkSplit.ClientID %>").checked = false;
                                                                    }

                                                                }
                                                            </script>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%; height: 65px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="multiLine" Rows="4" Width="400px"
                                                                    SkinID="textPad" MaxLength="200" onfocus="javascript:setfocus(this);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Footer_Space")%></asp:Label>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtFooterSpace" runat="server" Width="150px" SkinID="textPad" MaxLength="10"
                                                                    Style="text-align: right; float: left" onfocus="javascript:setfocus(this);" onblur="CallonBlur(this.value,'spn_txtFooterSpace');CheckDecimalPlus(this.value,'spn_txtFooterSpace','spn_txtFooterSpace','no');">10.00</asp:TextBox>
                                                                <span class="normalText " style="float: left">&nbsp;<%=objLanguage.GetLanguageConversion("mm")%></span>
                                                                <span id="spn_txtFooterSpace" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 3px">
                                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%;">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"><%=objlang.GetLanguageConversion("Follow_Up_Header_Space")%></asp:Label>
                                                            </div>
                                                            <div class="box">
                                                                <asp:TextBox ID="txtHeaderSpace" runat="server" Width="150px" SkinID="textPad" MaxLength="10"
                                                                    Style="text-align: right; float: left" onfocus="javascript:setfocus(this);" onblur="CallonBlur(this.value,'spn_txtHeaderSpace');CheckDecimalPlus(this.value,'spn_txtHeaderSpace','spn_txtHeaderSpace','no');">10.00</asp:TextBox>
                                                                <span class="normalText " style="float: left">&nbsp;<%=objLanguage.GetLanguageConversion("mm")%></span><span
                                                                    id="spn_txtHeaderSpace" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 3px"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="display: block">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Set_As_Default_Template")%></asp:Label>
                                                            </div>
                                                            <div style="float: left; padding: 5px">
                                                                <asp:CheckBox ID="chkDefaultTemp" runat="server" onfocus="javascript:setfocus(this);" />
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%; clear: both">
                                                            <div class="box">
                                                                <asp:CheckBox ID="chkisKeepWithPrevious" Text="&nbsp;&nbsp;Where fields in a group are blank move the fields below up to close the gap"
                                                                    runat="server" />
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%">
                                                            <div class="box">
                                                                <div align="left" style="width: 100%">
                                                                    <asp:CheckBox ID="chkSplit" Text="&nbsp;&nbsp;In multi item templates only allow 1 item per page"
                                                                        runat="server" onclick="javascript:chkSplit_checked();" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%; display: block">
                                                            <div class="box">
                                                                <div align="left" style="width: 100%">
                                                                    <asp:CheckBox ID="chkadjusted" Text="&nbsp;&nbsp;In multi item templates allow multiple items on a page, but don't allow an items details to be split accross two pages"
                                                                        onclick="javascript:chkadjusted_checked();" runat="server" />
                                                                </div>
                                                                <div align="left" style="width: 100%; padding-left: 21px">
                                                                    <span class="smallerfontgrey"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%; display: block">
                                                            <div class="box">
                                                                <div id="dvSplitSubitem" align="left" style="width: 100%" runat="server">
                                                                    <asp:CheckBox ID="chkSplitSubitem" Text="&nbsp;&nbsp;Split sub items which are from the Product Catalogue onto a new page"
                                                                        runat="server" />
                                                                </div>
                                                                <div align="left" style="width: 100%; padding-left: 21px">
                                                                    <span class="smallerfontgrey"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%; display: block" >
                                                            <div class="box">
                                                                <div id="dvLocationBasedSorting" align="left" style="width: 100%" runat="server">
                                                                    <asp:CheckBox ID="chkLocationBasedSorting" Text="&nbsp;&nbsp;Enable sorting based on stock location"
                                                                        runat="server" />
                                                                </div>
                                                                <div align="left" style="width: 100%; padding-left: 21px">
                                                                    <span class="smallerfontgrey"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div align="left" style="width: 100%; display: block">
                                                            <div class="box">
                                                                <div id="dvGroupingBasedOnStock" align="left" style="width: 100%" runat="server">
                                                                    <asp:CheckBox ID="chkGroupingBasedOnStock" Text="&nbsp;&nbsp;Group Products within stock location"
                                                                        runat="server" />
                                                                </div>
                                                                <div align="left" style="width: 100%; padding-left: 21px">
                                                                    <span class="smallerfontgrey"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div id="div_chkCopy" runat="server" align="left" style="width: 100%; clear: both; display: none">
                                                            <div class="bglabel" style="width: 20%; border: 0px solid red">
                                                                <span class="normalText">
                                                                    <%=objLanguage.GetLanguageConversion("Copy_Template_To")%></span>
                                                            </div>
                                                            <div class="ddlsetting" style="width: 75%; border: 0px solid red">
                                                                <div id="div_chkEstimate" style="padding-top: 3px">
                                                                    <asp:CheckBoxList ID="chklstCopy" runat="server" RepeatDirection="Horizontal" Width="100%"
                                                                        Style="vertical-align: bottom;">
                                                                        <asp:ListItem Text="Estimate" Value="Estimate">&nbsp;Estimates</asp:ListItem>
                                                                        <asp:ListItem Text="PrintBroker" Value="PrintBroker">&nbsp;Supplier RFQs</asp:ListItem>
                                                                        <asp:ListItem Text="WebStoreOrder" Value="WebStoreOrder">&nbsp;Web Order</asp:ListItem>
                                                                        <asp:ListItem Text="Job" Value="Job">&nbsp;Jobs</asp:ListItem>
                                                                        <asp:ListItem Text="Invoice" Value="Invoice">&nbsp;Invoice</asp:ListItem>
                                                                        <asp:ListItem Text="Purchase" Value="Purchase">&nbsp;Purchase</asp:ListItem>
                                                                        <asp:ListItem Text="Note" Value="Note">&nbsp;Delivery Notes</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="only10px">
                                                        </div>
                                                        <div align="left" style="clear: both">
                                                            <div style="float: left;">
                                                                &nbsp;
                                                            </div>
                                                            <div style="float: left;">
                                                                <div style="float: left">
                                                                    <div id="div_btnCancel" style="display: block">
                                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_OnClick">
                                                                        </telerik:RadButton>
                                                                    </div>
                                                                    <div id="div_btnCancelprocess" class="button" align="center" style="height: 14px; width: 43px; display: none">
                                                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                                <div style="float: left; width: 10px">
                                                                    &nbsp;
                                                                </div>
                                                                <div style="float: left">
                                                                    <div id="div_btnupdate" style="display: block">
                                                                        <asp:Button Skin="EprintbtnSkin" CssClass="button" EnableEmbeddedSkins="false" ID="btnUpdate"
                                                                            runat="server" Text="Save" OnClick="btnUpdate_Submit"></asp:Button>
                                                                    </div>
                                                                    <div id="div_btnupdateprocess" class="button" align="center" style="width: 31px; height: 14px; display: none">
                                                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                                <div style="float: left; width: 10px">
                                                                    &nbsp;
                                                                </div>
                                                                <div style="float: left">
                                                                    <div id="div_btnsavestay" style="display: block">
                                                                        <asp:Button Skin="EprintbtnSkin" CssClass="button" EnableEmbeddedSkins="false" ID="btnSaveStay"
                                                                            runat="server" Text="Save  & Continue" OnClick="btnUpdate_Submit"></asp:Button>
                                                                    </div>
                                                                    <div id="div_btnsavestayprocess" class="button" align="center" style="width: 72px; height: 14px; display: none">
                                                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <asp:HiddenField ID="hid_EditorHTML" runat="server" Value="" />
                                                            <asp:HiddenField ID="hid_ctrlListHTML" runat="server" Value="" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div style="float: left; border: 0px solid red;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="left">
                                                        <tr>
                                                            <td class="normalText" style="background-color: #DFFEB1; border-color: #93AB07; border-width: thin; border-style: solid; padding-left: 2px; display: none"
                                                                nowrap>
                                                                <%=objlang.GetValueOnLang("Edit Fields")%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td onclick="unSelAll();" valign="top">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div align="left" id="div_CtrlList" style="display: none">
                                                                                <table id="ctl00_ContentPlaceHolder1_CtrlList" cellspacing="0" cellpadding="0" width="180"
                                                                                    border="0">
                                                                                </table>
                                                                            </div>
                                                                            <div id="div_EditTxtBox">
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="context-menu" id="global-menu" nowrap="nowrap">
                    <div align="left" style="padding: 4px 4px 4px 5px;" class="HeaderText">
                        <%=objLanguage.GetLanguageConversion("Field_Options")%>
                    </div>
                    <table width="100%" style="float: left" onmouseover="javascript:RightMenuHover(this);"
                        onmouseout="javascript:RightMenuOut(this);" onclick="javascript:EditField();">
                        <tbody>
                            <tr>
                                <td style="width: 24px;" align="center">
                                    <img src="../images/edit_text.gif">
                                </td>
                                <td align="left" class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Edit") %>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table width="100%" style="float: left;" onmouseover="javascript:RightMenuHover(this);"
                        onmouseout="javascript:RightMenuOut(this);" onclick="javascript:deleteselected();">
                        <tbody>
                            <tr>
                                <td style="width: 24px;" align="center">
                                    <img src="../images/delete.gif">
                                </td>
                                <td align="left" class="normalText">
                                    <%=objLanguage.GetLanguageConversion("Delete") %>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <ul class="context-menu" id="global-menu111">
                    <span class="HeaderText" style="text-align: center; padding: 4px;">
                        <%=objlang.GetValueOnLang("Text Field Options")%>
                    </span>
                    <li>
                        <img src="../images/edit_text.gif"><a href="#" onclick="javascript:addImg('edit');">Edit
                            Field</a></li>
                    <li>
                        <img src="../images/delete.gif"><a href="#" onclick="javascript:deleteselected();">Delete
                            Field</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1300" Height="550" RestrictionZoneID="Zoneid"
            OnClientClose="RadWinClose" Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <asp:HiddenField ID="hdn_Group" runat="server" Value="" />
    <asp:HiddenField ID="hdn_HGroup" runat="server" Value="" />
    <script>
        ddlfonts = document.getElementById("<%=ddlfonts.ClientID %>");
        function RightMenuHover(obj) {
            obj.style.border = "1px solid black";
            obj.style.backgroundColor = "lightslategray";
            obj.style.width = "100%";
            obj.style.cursor = "default";
            obj.style.fontSize = "11px";
            obj.style.clear = "both";
            obj.style.padding = "0px";
        }
        function RightMenuOut(obj) {
            obj.style.border = "none";
            obj.style.backgroundColor = "white";
            obj.style.width = "100%";
            obj.style.cursor = "default";
            obj.style.fontSize = "11px";
            obj.style.clear = "both";
            obj.style.padding = "1px";
        }

        function EditOptionOver(obj) {
            obj.style.border = "solid 1px #316AC5";
            obj.style.backgroundColor = "#C1D2EE";
            obj.style.padding = "0px";
        }

        function EditOptionOut(obj) {
            obj.style.border = "none";
            obj.style.backgroundColor = "";
            obj.style.padding = "1px";
        }

        function SetRightMenuTopLeft(obj) {
            var divtop = document.getElementById(obj).style.top;
            var divleft = document.getElementById(obj).style.left;

            var tdDesignTop = document.getElementById("tdDesign").offsetTop;
            var tdDesignLeft = document.getElementById("tdDesign").offsetLeft;

            divtop = tdDesignTop + Number(divtop.replace("px", ""));
            divleft = tdDesignLeft + Number(divleft.replace("px", ""));

            document.getElementById("global-menu").style.top = divtop + "px";
            document.getElementById("global-menu").style.left = divleft + "px";
        }

        function CloseEditWindow() {
            document.getElementById("div_EditFields").style.display = "none";
            var inputs = document.getElementById("div_CtrlList");
            inputs.style.display = "none";
        }

        var dividsave = '';
        function EditField() {
            document.getElementById("div_EditFields").style.display = "none";
            for (var i = selObjs.length - 1; i >= 0; i--) {
                if (selObjs[i] != null) {
                    var tdDesignTop = document.getElementById("tdDesign").offsetTop;
                    var tdDesignLeft = document.getElementById("tdDesign").offsetLeft;

                    var objtype = document.getElementById(selObjs[i]).getAttribute("objtype");
                    var objname = document.getElementById(selObjs[i]).getAttribute("objname");
                    var objvalue = document.getElementById(selObjs[i]).innerHTML.replace('<DIV', '<div');
                    var divtop = document.getElementById(selObjs[i]).style.top;
                    var divleft = document.getElementById(selObjs[i]).style.left;
                    var selObj = document.getElementById(selObjs[i]);
                    dividsave = selObj;

                    divtop = tdDesignTop + Number(divtop.replace("px", "")) + 35;
                    divleft = tdDesignLeft + Number(divleft.replace("px", ""));

                    if (objtype == "3") {
                        addImg('edit');
                    }
                    else if (objtype == "8" || objtype == "9" || objtype == "10" || objtype == "15" || objtype == "16") {
                        document.getElementById("div_EditFields").style.display = "none";
                    }
                    else {
                        document.getElementById("div_EditFields").style.display = "block";
                        document.getElementById("div_EditFields").style.top = divtop + "px";
                        document.getElementById("div_EditFields").style.left = divleft + "px";


                        var inputs = document.getElementById("div_CtrlList");
                        var var_remove = selObj.id.replace("'div'", "");
                        var ctrltxtbx = inputs.getElementsByTagName("input");
                        var txtbx = document.getElementById("txtbx" + var_remove);
                        var row1 = document.getElementById("row1" + var_remove);
                        if (txtbx != null) {
                            for (var n = 0; n < idnm + 500; n++) {
                                var txtbx1 = document.getElementById("txtbx_" + n);
                                var row11 = document.getElementById("row1_" + n);
                                if (txtbx1 != null) {
                                    inputs.style.display = "block";
                                    if (txtbx1.id != txtbx.id) {
                                        txtbx1.style.display = "none";
                                        row11.style.display = "none";
                                    }
                                    else {
                                        inputs.style.display = "block";
                                        txtbx1.style.display = "block";
                                        row11.style.display = "none";
                                    }
                                }
                            }

                            txtbx.style.position = "absolute";
                            txtbx.style.backgroundImage = "url(../images/thought_bot_center.gif)";
                            txtbx.style.zIndex = "100000";
                            txtbx.style.width = "296px";
                            txtbx.style.border = "0px solid";
                            txtbx.className = "";

                            if (txtbx.nodeName == "TEXTAREA") {
                                var textareaval = objvalue.substring(0, objvalue.indexOf('<div'));
                                txtbx.value = textareaval;
                                for (var k = 0; k < txtbx.value.length; k++) {
                                    txtbx.value = txtbx.value.replace('<BR>', '<br>').replace('<br>', '\n');
                                }
                                txtbx.style.height = "50px";
                                document.getElementById("vpls_text_5_inlineText").style.height = "50px";
                                document.getElementById("td_Edit").style.height = "110px";
                            }
                            else {
                                txtbx.style.height = "20px";
                                document.getElementById("vpls_text_5_inlineText").style.height = "20px";
                                document.getElementById("td_Edit").style.height = "85px";
                            }


                            var ReqNumericValue = 0;
                            if (txtbx.attachEvent) //IE
                            {
                                if (ReqNumericValue == "1")
                                    txtbx.attachEvent("onkeydown", CheckKeyCodeInteger);
                                txtbx.attachEvent("onkeyup", chgTxt);
                                txtbx.attachEvent("onblur", savecntrlList);
                            }
                            else if (txtbx.addEventListener) {
                                if (ReqNumericValue == "1")
                                    txtbx.addEventListener("onkeydown", CheckKeyCodeInteger, true);
                                txtbx.addEventListener("keyup", chgTxt, true);
                                txtbx.addEventListener("blur", savecntrlList, true);
                            }
                            else {
                                if (ReqNumericValue == "1")
                                    txtbx["onkeyup"] = chgTxt;
                                txtbx["onkeydown"] = CheckKeyCodeInteger;
                                txtbx["onblur"] = savecntrlList;
                            }

                            var txtTop = document.getElementById("div_EditFields").style.top;
                            var txtLeft = document.getElementById("div_EditFields").style.left;

                            var xx = document.getElementById("vpls_text_5_inlineText").style.top;
                            var yy = document.getElementById("vpls_text_5_inlineText").style.left;


                            if (is_ie) {
                                if (window.navigatorVersion == "8" || window.navigatorVersion == "7") {
                                    txtTop = Number(txtTop.replace("px", "")) + 57;
                                    txtLeft = Number(txtLeft.replace("px", "")) + 7;
                                }
                                else {
                                    txtTop = Number(txtTop.replace("px", "")) + 68;
                                    txtLeft = Number(txtLeft.replace("px", "")) + 7;
                                }
                            }
                            else {
                                txtTop = Number(txtTop.replace("px", "")) + 57;
                                txtLeft = Number(txtLeft.replace("px", "")) + 7;
                            }

                            txtbx.style.top = txtTop + "px";
                            txtbx.style.left = txtLeft + "px";
                        }
                        document.getElementById("spn_EditFieldName").innerHTML = objname;
                    }
                }
            }
        }

        function CallEditOptions(optType) {
            document.getElementById("div_EditFields").style.display = "block";
            var obj = dividsave;
            var objType = obj.getAttribute("objtype");
            selObjs[0] = obj.id;

            var var_remove = obj.id.replace("'div'", "");
            var inputs = document.getElementById("div_CtrlList");
            inputs.style.display = "block";
            var txtbx = document.getElementById("txtbx" + var_remove);
            txtbx.style.display = "block";

            if (optType == "bold") {
                if (objType == "1") {
                    if (txtbx.style.fontWeight == "bold") {
                        txtbx.style.fontWeight = "normal";
                    }
                    else {
                        txtbx.style.fontWeight = "bold";
                    }
                    chngBld();
                }
                else if (objType == "2") {
                    Make_SelectedText_Bold_Italic(txtbx, obj, 'bold');
                }
            }
            else if (optType == "italic") {
                if (objType == "1") {
                    if (txtbx.style.fontStyle == "italic") {
                        txtbx.style.fontStyle = "normal";
                    }
                    else {
                        txtbx.style.fontStyle = "italic";
                    }
                    chngIt();
                }
                else if (objType == "2") {
                    Make_SelectedText_Bold_Italic(txtbx, obj, 'italic');
                }
            }
        }

        function Make_SelectedText_Bold_Italic(txtbx, divobj, type) {
            var textComponent = txtbx;  //document.getElementById(txtbx);
            var oldtxtval = textComponent.value;
            var newtxtval = "";

            var selectedText;
            if (document.selection != undefined) {
                textComponent.focus();
                var sel = document.selection.createRange();
                selectedText = sel.text;
            }
                // Mozilla version
            else if (textComponent.selectionStart != undefined) {
                var startPos = textComponent.selectionStart;
                var endPos = textComponent.selectionEnd;
                selectedText = textComponent.value.substring(startPos, endPos);
            }


            if (selectedText != "") {

            }
            else {
                if (type == "bold") {
                    if (textComponent.style.fontWeight == "bold") {
                        textComponent.style.fontWeight = "normal";
                    }
                    else {
                        textComponent.style.fontWeight = "bold";
                    }
                    chngBld();
                }
                else {
                    if (textComponent.style.fontStyle == "italic") {
                        textComponent.style.fontStyle = "normal";
                    }
                    else {
                        textComponent.style.fontStyle = "italic";
                    }
                    chngIt();
                }
            }
            OnChangeInsertIntoArray();
        }
    </script>
    <script>

        function CheckExist(val) {
            var ModuleName = '<%=report_page%>'
            var CompID = '<%=CompanyID %>'
            var Para = val + "&" + ModuleName + "&" + CompID;

            document.getElementById('div_CtrlList').style.display = "none";
        }
        function current_value(val) {

            alert(val);
            PageMethods.GetFunalValue(val, FinalResultVAlue)
            return false;
        }
        function FinalResultVAlue(result) {
            alert(result);
        }
        function Confirmation1(Result) {
            alert('successsssssssssssssss');
            alert(Result);

        }
    </script>
    <script>
        ///== To create controls ===//
        function CreateCtrl(CtrlType, CtrlID, CtrlTag, CtrlValue, CtrlName, CtrlMaxLen, CtrlSize, CtrlFont, CtrlFontSize, CtrlFontWeight, CtrlStyle, CtrlLeft, CtrlTop, CtrlWidth, CtrlHeight, CtrlColor, CtrlIsUnderline, CtrlLSpace, CtrlAlign, ConReq, CanEditText, CanMoveObject, ReqNumericValue, MaxChar, RotatAngle, CanChangeFont, CanChangeFontSize, CanChageFontColor, isitem, GroupID, HGroupID, AssociatedLabel, IsHGroupMain, repeat) {

            document.getElementById("div_CtrlList").style.display = "none";
            document.getElementById("div_EditFields").style.display = "none";
            divids = idnm;

            if (CtrlName == "")
                CtrlName = "object name";
            if (CtrlFont == "")
                CtrlFont = "Arial";
            if (CtrlFontSize == "")
                CtrlFontSize = "10pt";
            if ('<%=action %>' == "add" && CtrlFontSize == "9pt")
                CtrlFontSize = "10pt";
            if (CtrlFontWeight == "")
                CtrlFontWeight = "normal";
            if (CtrlStyle == "")
                CtrlStyle = "normal";
            if (CtrlLeft == "")
                CtrlLeft = "0";
            if (CtrlTop == "")
                CtrlTop = "0";
            if (CtrlWidth == "")
                CtrlWidth = "50";
            if (CtrlHeight == "")
                CtrlHeight = "20";
            if (CtrlLSpace == "")
                CtrlLSpace = "0pt";
            strAlign = "left";
            if (CtrlAlign == "2")
                strAlign = "center";
            else if (CtrlAlign == "3")
                strAlign = "right";
            else if (CtrlAlign == "4")
                strAlign = "justify";
            UnderlineStr = "none";
            if (CtrlColor == "")
                CtrlColor = "000000";
            if (CtrlIsUnderline == "1") {
                UnderlineStr = "underline";
            }
            if (CanEditText == "")
                CanEditText = "0";

            if (CanMoveObject != "true")
                CanMoveObject = "false";
            if (ReqNumericValue == "")
                ReqNumericValue = "0";
            if (MaxChar == "")
                MaxChar = "0";
            if (RotatAngle == "")
                RotatAngle = "0";
            if (CanChangeFont == "")
                CanChangeFont = "0";
            if (CanChangeFontSize == "")
                CanChangeFontSize = "0";
            if (CanChageFontColor == "")
                CanChageFontColor = "0";

            var zindx = 10000;

            if (ConReq == "1") {
                CtrlLeft = PointToPixel(CtrlLeft, document.getElementById(contPlNm + "sXDPI").value);
                CtrlWidth = PointToPixel(CtrlWidth, document.getElementById(contPlNm + "sXDPI").value);

                CtrlTop = PointToPixel(CtrlTop, document.getElementById(contPlNm + "sYDPI").value);
                CtrlHeight = PointToPixel(CtrlHeight, document.getElementById(contPlNm + "sYDPI").value);
            }

            //By Swetha changes for CtrlType=7
            if (CtrlType == 1 || CtrlType == 2 || CtrlType == 4 || CtrlType == 5 || CtrlType == 7)//by swetha 7
            {
                if (is_ie) {
                    if (/MSIE (\d+\.\d+);/.test(navigator.userAgent)) {
                        var ieversion = new Number(RegExp.$1)
                        if (ieversion <= 7) {
                            var ctrList = document.getElementById(contPlNm + "CtrlList").getElementsByTagName("tbody")[0];
                        }
                        if (ieversion > 7) {
                            var ctrList = document.getElementById(contPlNm + "CtrlList");
                        }
                    }
                }
                else {
                    var ctrList = document.getElementById(contPlNm + "CtrlList");
                }
                var CardDiv = document.getElementById(contPlNm + "CardDiv");

                var row1 = document.createElement("tr");
                row1.setAttribute("id", "row1_" + idnm);
                var td1 = document.createElement("td");
                td1.style.pixelHeight = 18;
                td1.style.verticalAlign = "bottom";
                td1.appendChild(document.createTextNode(CtrlName));
                td1.className = "formlabel";
                row1.appendChild(td1);
                var row2 = document.createElement("tr");
                row2.setAttribute("id", "row2_" + idnm);
                var td2 = document.createElement("td");
                td2.style.pixelWidth = 200;
                td2.style.textAlign = "left";

                if (CtrlType == 2) {
                    var txtbx = document.createElement("textarea");
                    txtbx.setAttribute("cols", "23");
                    txtbx.style.height = "60px";
                }
                else if (CtrlType == 7)//by swetha
                {
                    var txtbx = document.createElement("div");
                }
                else {
                    var txtbx = document.createElement("input");
                    txtbx.setAttribute("type", "text");
                    txtbx.setAttribute("size", "25");
                    txtbx.style.height = "18px";
                }

                if (CanEditText == "0")
                    txtbx.setAttribute("readOnly", "true")
                txtbx.style.pixelWidth = 200;
                txtbx.setAttribute("id", "txtbx_" + idnm);
                txtbx.setAttribute("name", "txtbx_" + idnm);
                txtbx.setAttribute("class", "emptythetextbox");
                txtbx.setAttribute("runat", "server");

                if (CtrlType == 2) {
                    txtbx.value = SpecialDecode(CtrlValue.replace(/<BR \/>/g, "\n").replace(/<br \/>/g, "\n").replace(/'/g, "&acute;"));
                }
                else {
                    if (MaxChar != "0")
                        txtbx.setAttribute("maxLength", MaxChar);
                    txtbx.setAttribute("value", CtrlValue.replace(/<BR \/>/g, "\n").replace(/<br \/>/g, "\n").replace(/'/g, "&acute;"));
                }

                if (txtbx.attachEvent) //IE
                {
                    if (ReqNumericValue == "1")
                        txtbx.attachEvent("onkeydown", CheckKeyCodeInteger);
                    txtbx.attachEvent("onkeyup", chgTxt);
                    txtbx.attachEvent("onblur", savecntrlList);
                }
                else if (txtbx.addEventListener) {
                    if (ReqNumericValue == "1")
                        txtbx.addEventListener("onkeydown", CheckKeyCodeInteger, true);
                    txtbx.addEventListener("keyup", chgTxt, true);
                    txtbx.addEventListener("blur", savecntrlList, true);
                }
                else {
                    if (ReqNumericValue == "1")
                        txtbx["onkeyup"] = chgTxt;
                    txtbx["onkeydown"] = CheckKeyCodeInteger;
                    txtbx["onblur"] = savecntrlList;
                }

                td2.appendChild(txtbx);
                row2.appendChild(td2);
                if (document.getElementById(contPlNm + "DMode").value == "1") {
                    var td3_gap = document.createElement("td");
                    td3_gap.className = "normaltxt";
                    td3_gap.appendChild(document.createTextNode("\u00a0"));
                    td3_gap.style.textAlign = "center";
                    td3_gap.style.pixelWidth = 10;
                    row2.appendChild(td3_gap);

                    var td3 = document.createElement("td");
                    td3.className = "normaltxt";
                    td3.appendChild(document.createTextNode("Show"));
                    td3.style.textAlign = "center";
                    td3.style.pixelWidth = 35;

                    var td3_gap = document.createElement("td");
                    td3_gap.className = "normaltxt";
                    td3_gap.appendChild(document.createTextNode("\u00a0"));
                    td3_gap.style.textAlign = "center";
                    td3_gap.style.pixelWidth = 5;

                    var td4 = document.createElement("td");
                    td4.style.pixelWidth = 27;
                    var chkbxS = document.createElement("input");
                    chkbxS.setAttribute("type", "checkbox");
                    chkbxS.setAttribute("id", "chkbxS_" + idnm);
                    chkbxS.setAttribute("name", "chkbxS_" + idnm);
                    chkbxS.setAttribute("runat", "server");
                    if (chkbxS.attachEvent) { // IE
                        chkbxS.attachEvent("onclick", showhidObj);
                    }
                    else if (chkbxS.addEventListener) { // Gecko / W3C
                        chkbxS.addEventListener("click", showhidObj, true);
                    }
                    else {
                        chkbxS["onclick"] = showhidObj;
                    }

                    var row_gap = document.createElement("tr");
                    row_gap.setAttribute("id", "row_gap_2_" + idnm);
                    var td_gap = document.createElement("td");
                    td_gap.style.pixelHeight = 10;
                    td_gap.setAttribute("height", "10");
                    td_gap.style.textAlign = "left";
                    row_gap.appendChild(td_gap);

                    var td5 = document.createElement("td");
                    td5.className = "normaltxt";
                    td5.appendChild(document.createTextNode("|"));
                    td5.style.pixelWidth = 5;

                    var td6 = document.createElement("td");
                    td6.className = "normaltxt";
                    td6.appendChild(document.createTextNode("Lock"));
                    td6.style.textAlign = "center";
                    td6.style.pixelWidth = 35;

                    var td7 = document.createElement("td");
                    td7.style.pixelWidth = 27;
                    var chkbxL = document.createElement("input");
                    chkbxL.setAttribute("type", "checkbox");
                    chkbxL.setAttribute("id", "chkbxL_" + idnm);
                    chkbxL.setAttribute("name", "chkbxL_" + idnm);
                    chkbxL.setAttribute("runat", "server");
                    if (chkbxL.attachEvent) { // IE
                        chkbxL.attachEvent("onclick", LockObj);
                    }
                    else if (chkbxL.addEventListener) { // Gecko / W3C
                        chkbxL.addEventListener("click", LockObj, true);
                    }
                    else {
                        chkbxL["onclick"] = LockObj;
                    }
                }

                ctrList.appendChild(row1);
                ctrList.appendChild(row2);
                ctrList.appendChild(row_gap);

                var txtdiv = document.createElement("DIV");
                txtdiv.setAttribute("id", "'div'_" + idnm);
                txtdiv.setAttribute("type", "divobj");
                txtdiv.setAttribute("title", CtrlName);
                txtdiv.setAttribute("objtype", CtrlType);
                txtdiv.setAttribute("objtag", CtrlTag);
                txtdiv.setAttribute("objname", CtrlName);
                txtdiv.setAttribute("align", "left");
                txtdiv.setAttribute("onMouseOver", "this.className='putpointer'");
                txtdiv.setAttribute("CanChangeFont", CanChangeFont);
                txtdiv.setAttribute("CanChangeFontSize", CanChangeFontSize);
                txtdiv.setAttribute("CanChageFontColor", CanChageFontColor);

                txtdiv.setAttribute("isitem", isitem);
                txtdiv.setAttribute("GroupID", GroupID);
                txtdiv.setAttribute("HGroupID", HGroupID);
                txtdiv.setAttribute("AssociatedLabel", AssociatedLabel);
                txtdiv.setAttribute("IsHGroupMain", IsHGroupMain);

                if (CanMoveObject == "false") {
                    txtdiv.setAttribute("canmove", "1");
                    txtdiv.setAttribute("lock", "false");
                }
                else {
                    txtdiv.setAttribute("canmove", "0");
                    txtdiv.setAttribute("lock", "true");
                }

                if (repeat != null && repeat != '' && repeat == "true") {
                    txtdiv.setAttribute("repeat", "true");
                } else {
                    txtdiv.setAttribute("repeat", "false");
                }

                txtdiv.setAttribute("runat", "server");
                txtdiv.innerHTML = SpecialDecode(CtrlValue);
                txtdiv.style.position = "absolute";
                txtdiv.style.backgroundColor = "transparent";
                txtdiv.style.display = "inline";
                txtdiv.style.zIndex = zindx + idnm;
                txtdiv.style.fontFamily = CtrlFont;
                txtdiv.style.fontSize = CtrlFontSize;
                txtdiv.style.fontWeight = CtrlFontWeight;
                txtdiv.style.fontStyle = CtrlStyle;

                if (CtrlColor.indexOf("rgb") != -1) {
                    var color = new RGBColor(CtrlColor);
                    if (color.ok) {
                        CtrlColor = color.toHex().replace("#", "");
                    }
                    else {
                        CtrlColor = '000000';
                    }
                }
                else {
                    CtrlColor = CtrlColor.replace("#", "");
                }

                txtdiv.style.color = "#" + CtrlColor;
                txtdiv.style.textDecoration = UnderlineStr;
                txtdiv.style.textAlign = strAlign;
                txtdiv.style.overflow = "hidden";

                txtdiv.style.visibility = "visible";
                txtdiv.style.border = "1px dotted #ADADAD"; //#D2D2D2

                txtdiv.style.pixelLeft = CtrlLeft; //.style.pixelLeft;
                txtdiv.style.pixelTop = CtrlTop; //.pixelTop;
                txtdiv.style.pixelWidth = CtrlWidth;
                txtdiv.style.pixelHeight = CtrlHeight;

                txtdiv.style.left = CtrlLeft + "px"; //.style.pixelLeft;
                txtdiv.style.top = CtrlTop + "px"; //.pixelTop;
                txtdiv.style.width = CtrlWidth + "px";
                txtdiv.style.height = CtrlHeight + "px";


                if (document.getElementById(contPlNm + "DMode").value == "1") {
                }


                CardDiv.appendChild(txtdiv);

                if (document.getElementById(contPlNm + "DMode").value == "1") {
                }
                idnm = idnm + 1;
            }
            else if (CtrlType == 3) {
                var CardDiv = document.getElementById(contPlNm + "CardDiv");
                var txtdiv = document.createElement("div");
                txtdiv.setAttribute("id", "'div'_" + idnm);
                txtdiv.setAttribute("type", "imgDiv");
                txtdiv.setAttribute("objtype", CtrlType);
                txtdiv.setAttribute("objtag", CtrlTag);
                txtdiv.setAttribute("objname", CtrlName);

                txtdiv.setAttribute("isitem", isitem);
                txtdiv.setAttribute("GroupID", GroupID);
                txtdiv.setAttribute("HGroupID", HGroupID);
                txtdiv.setAttribute("AssociatedLabel", AssociatedLabel);
                txtdiv.setAttribute("IsHGroupMain", IsHGroupMain);

                if (CanMoveObject == "false") {
                    txtdiv.setAttribute("canmove", "1");
                    txtdiv.setAttribute("lock", "false");
                }
                else {
                    txtdiv.setAttribute("canmove", "0");
                    txtdiv.setAttribute("lock", "true");
                }

                txtdiv.style.border = "1px dotted #ADADAD"; //#D2D2D2
                txtdiv.setAttribute("runat", "server");
                txtdiv.style.position = "absolute";
                txtdiv.style.backgroundColor = "transparent";
                txtdiv.style.display = "inline";
                txtdiv.style.overflow = "visible";
                txtdiv.style.zIndex = zindx + idnm;
                txtdiv.style.left = CtrlLeft + "px"; //.style.pixelLeft;
                txtdiv.style.top = CtrlTop + "px"; //.pixelTop;
                txtdiv.style.width = CtrlWidth + "px";
                txtdiv.style.height = CtrlHeight + "px";

                if (document.getElementById(contPlNm + "DMode").value == "1") {

                }

                var img = document.createElement("img");
                img.setAttribute("src", CtrlValue);

                img.setAttribute("id", "'img'_" + idnm);
                img.setAttribute("type", "imgObj");
                img.style.position = "absolute";
                img.style.display = "inline";
                img.style.left = "0px"; //.style.pixelLeft;
                img.style.top = "0px"; //.pixelTop;
                img.style.width = "100%"; //CtrlWidth;
                img.style.height = "100%"; //CtrlHeight;
                img.setAttribute("width", CtrlWidth);
                img.setAttribute("height", CtrlHeight);

                txtdiv.appendChild(img);

                CardDiv.appendChild(txtdiv);
                var div_inter_img = imgsarray.splice(imgsarray.length, 0, divids);
                idnm = idnm + 1;

            }
            else if (CtrlType == 13) {

                var CardDiv = document.getElementById(contPlNm + "CardDiv");
                var txtdiv = document.createElement("div");
                txtdiv.setAttribute("id", "div_bgImage");
                txtdiv.setAttribute("type", "imgDiv");
                txtdiv.setAttribute("objtype", CtrlType);
                txtdiv.setAttribute("objtag", CtrlTag);
                txtdiv.setAttribute("objname", CtrlName);

                txtdiv.setAttribute("isitem", isitem);
                txtdiv.setAttribute("GroupID", GroupID);
                txtdiv.setAttribute("HGroupID", HGroupID);
                txtdiv.setAttribute("AssociatedLabel", AssociatedLabel);
                txtdiv.setAttribute("IsHGroupMain", IsHGroupMain);

                if (CanMoveObject == "false") {
                    txtdiv.setAttribute("canmove", "1");
                    txtdiv.setAttribute("lock", "false");
                }
                else {
                    txtdiv.setAttribute("canmove", "0");
                    txtdiv.setAttribute("lock", "true");
                }

                txtdiv.style.border = "1px dotted #ADADAD"; //#D2D2D2
                txtdiv.setAttribute("runat", "server");
                txtdiv.style.position = "absolute";
                txtdiv.style.backgroundColor = "transparent";
                txtdiv.style.display = "inline";
                txtdiv.style.overflow = "visible";
                txtdiv.style.zIndex = -1;
                txtdiv.style.left = CtrlLeft + "px"; //.style.pixelLeft;
                txtdiv.style.top = CtrlTop + "px"; //.pixelTop;
                txtdiv.style.width = CtrlWidth + "px"; //"<%=EditorWidth%>";
                txtdiv.style.height = CtrlHeight + "px"; //"<%=EditorHeight%>";

                if (document.getElementById(contPlNm + "DMode").value == "1") {

                }

                if (CtrlValue != "") {
                    txtdiv.style.backgroundImage = 'url(' + CtrlValue + ')';
                    txtdiv.style.backgroundRepeat = "no-repeat";
                    if (document.getElementById("div_Gridlines") != null) {
                        txtdiv.style.zIndex = -1;
                        document.getElementById("div_Gridlines").style.zIndex = 1;
                        document.getElementById("div_Gridlines").style.filter = "alpha(opacity=80)";
                        document.getElementById("div_Gridlines").style.opacity = 0.8;
                    }
                }
                else {
                    txtdiv.style.backgroundImage = "";
                }

                CardDiv.appendChild(txtdiv);
                var div_inter_img = imgsarray.splice(imgsarray.length, 0, divids);
                idnm = idnm + 1;

            }
            else if (CtrlType == 14) {
                var hid_HasGridlines = document.getElementById("<%=hid_HasGridlines.ClientID %>");

                if (hid_HasGridlines.value == "no") {
                    var CardDiv = document.getElementById(contPlNm + "CardDiv");
                    var txtdiv = document.createElement("div");
                    txtdiv.setAttribute("id", "div_Gridlines");
                    txtdiv.setAttribute("type", "imgDiv");
                    txtdiv.setAttribute("objtype", CtrlType);
                    txtdiv.setAttribute("objtag", CtrlTag);
                    txtdiv.setAttribute("objname", CtrlName);

                    txtdiv.setAttribute("isitem", isitem);
                    txtdiv.setAttribute("GroupID", GroupID);
                    txtdiv.setAttribute("HGroupID", HGroupID);
                    txtdiv.setAttribute("AssociatedLabel", AssociatedLabel);
                    txtdiv.setAttribute("IsHGroupMain", IsHGroupMain);

                    if (CanMoveObject == "false") {
                        txtdiv.setAttribute("canmove", "1");
                        txtdiv.setAttribute("lock", "false");
                    }
                    else {
                        txtdiv.setAttribute("canmove", "0");
                        txtdiv.setAttribute("lock", "true");
                    }

                    txtdiv.style.border = "1px dotted #ADADAD"; //#D2D2D2
                    txtdiv.setAttribute("runat", "server");
                    txtdiv.style.position = "absolute";
                    txtdiv.style.backgroundColor = "transparent";
                    txtdiv.style.display = "inline";
                    txtdiv.style.overflow = "visible";
                    txtdiv.style.zIndex = -1;
                    txtdiv.style.left = CtrlLeft + "px"; //.style.pixelLeft;
                    txtdiv.style.top = CtrlTop + "px"; //.pixelTop;
                    txtdiv.style.width = CtrlWidth + "px"; //"<%=EditorWidth%>";
                    txtdiv.style.height = CtrlHeight + "px"; //"<%=EditorHeight%>";

                    if (document.getElementById(contPlNm + "DMode").value == "1") {

                    }

                    if (CtrlValue != "") {
                        txtdiv.style.backgroundImage = 'url(' + CtrlValue + ')';
                        txtdiv.style.backgroundRepeat = "no-repeat";
                        if (document.getElementById("div_bgImage") != null) {
                            txtdiv.style.width = document.getElementById("div_bgImage").style.width;
                            txtdiv.style.height = document.getElementById("div_bgImage").style.height;
                            txtdiv.style.zIndex = 1;
                            document.getElementById("div_bgImage").style.zIndex = -1;
                            txtdiv.style.filter = "alpha(opacity=80)";
                            txtdiv.style.opacity = 0.8;
                        }
                    }
                    else {
                        txtdiv.style.backgroundImage = "";
                    }

                    CardDiv.appendChild(txtdiv);
                    var div_inter_img = imgsarray.splice(imgsarray.length, 0, divids);
                    idnm = idnm + 1;

                    hid_HasGridlines.value = "yes";
                }
                else {
                    if (document.getElementById("div_Gridlines") != null) {
                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").removeChild(document.getElementById("div_Gridlines"));
                        hid_HasGridlines.value = "no";
                    }
                }
            }
            else if (CtrlType == 8 || CtrlType == 9 || CtrlType == 10 || CtrlType == 11 || CtrlType == 12 || CtrlType == 15 || CtrlType == 16)//by swetha --- HorizontalRule
            {
                //8 & 9-- Default start and end hr lines ,cant be deleted
                //10 -- user defined hr rule, can be deleted
                //11 & 12 -- header and footer seperation hr lines.
                var CardDiv = document.getElementById(contPlNm + "CardDiv");
                var txtstart = '';
                if (CtrlType == 8)//<strat1> tag
                {
                    txtstart = document.createElement("start1");
                }
                else if (CtrlType == 9)//<strat2> tag
                {
                    txtstart = document.createElement("start2");
                }

                var txtdiv = document.createElement("div");
                txtdiv.setAttribute("id", "'div'_" + idnm);
                txtdiv.setAttribute("type", "hrDiv");
                txtdiv.setAttribute("objtype", CtrlType);
                txtdiv.setAttribute("objtag", CtrlTag);
                txtdiv.setAttribute("objname", CtrlName);

                txtdiv.setAttribute("onMouseOver", "this.className='putpointer'");
                txtdiv.setAttribute("isitem", isitem);
                txtdiv.setAttribute("GroupID", GroupID);
                txtdiv.setAttribute("HGroupID", HGroupID);
                txtdiv.setAttribute("AssociatedLabel", AssociatedLabel);
                txtdiv.setAttribute("IsHGroupMain", IsHGroupMain);

                if (CanMoveObject == "false") {
                    txtdiv.setAttribute("canmove", "1");
                    txtdiv.setAttribute("lock", "false");
                }
                else {
                    txtdiv.setAttribute("canmove", "0");
                    txtdiv.setAttribute("lock", "true");
                }

                txtdiv.setAttribute("runat", "server");
                txtdiv.setAttribute("align", "left");
                txtdiv.style.position = "absolute";
                txtdiv.style.backgroundColor = "transparent";
                txtdiv.style.display = "inline";
                txtdiv.style.overflow = "hidden";
                txtdiv.style.zIndex = zindx + idnm;
                txtdiv.style.left = CtrlLeft + "px"; //.style.pixelLeft;
                txtdiv.style.top = CtrlTop + "px"; //.pixelTop;
                txtdiv.style.width = CtrlWidth + "px";
                txtdiv.style.height = CtrlHeight + "px";


                if (document.getElementById(contPlNm + "DMode").value == "1") {
                }

                var img = document.createElement("img");
                CtrlValue = '<%=imgHRPath %>';
                if (CtrlType == 12) {
                    CtrlValue = '<%=imgHeaderPath %>';
                }
                else if (CtrlType == 11) {
                    CtrlValue = '<%=imgFooterPath %>';
                }
                else if (CtrlType == 8 || CtrlType == 9) {
                    CtrlValue = '<%=imgItemPath %>';
                }
                else if (CtrlType == 15 || CtrlType == 16) {
                    CtrlValue = '<%=imgSubItemPath %>';
                }

    img.setAttribute("src", CtrlValue);
    img.setAttribute("id", "'img'_" + idnm);
    img.setAttribute("type", "imgObj");
    img.style.position = "absolute";
    img.style.display = "inline";
    img.style.left = "0px"; //.style.pixelLeft;
    img.style.top = "0px"; //.pixelTop;
    img.style.width = "100%"; //CtrlWidth;
    img.setAttribute("width", CtrlWidth);
    if (CtrlType == 10) {
        img.style.height = "1"; //CtrlHeight;
        img.setAttribute("height", 1);
    }
    else {
        img.style.height = "8"; //CtrlHeight;
        img.setAttribute("height", 8);
    }


    txtdiv.appendChild(img);
    if (CtrlType == 8 || CtrlType == 9) {
        txtstart.appendChild(txtdiv);
        CardDiv.appendChild(txtstart);
    }
    else {
        CardDiv.appendChild(txtdiv);
    }

    idnm = idnm + 1;
}
    var div_inter = divsarray.splice(divsarray.length, 0, divids);
}

    </script>
    <script>
        ////=== To load default fields on add case ===//
        function loadObjects() {
            //by swetha
            var CompanyID = '<%=CompanyID %>';
            var CompanyLogo = '<%=CompanyLogo %>';
            var LogoPath = '<%=SecureSitePath %>' + '<%=ServerName %>' + "/" + CompanyID + '/' + CompanyLogo;
            var LogoWidth = "246";
            var LogoHeight = "100"; //old value was 60 ----changed by gajendra
            var LogoLeft = "30";
            var LogoTop = "20";
            // changed conreq value 0 from 1 by gajendra for image control

            if (report_page == 'Estimate') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(9, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '35', '280', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(8, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '35', '500', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '35', '205', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '35', '585', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[MyCompanyName]', '[MyCompanyName]', 'My Company Name', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress1]', '[MyCompanyAddress1]', 'My Company Address1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress2]', '[MyCompanyAddress2]', 'My Company Address2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress3]', '[MyCompanyAddress3]', 'My Company Address3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyEmail]', '[MyCompanyEmail]', 'My Company Email', '', '', 'Arial', '9pt', '', 'normal', '400', '95', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyPhone]', '[MyCompanyPhone]', 'My Company Phone', '', '', 'Arial', '9pt', '', 'normal', '400', '110', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Estimate', 'Estimate', '', '', 'Arial', '18pt', 'bolder', 'normal', '400', '140', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimateNumber]', 'Est. No: [EstimateNumber]', 'Estimate Number', '', '', 'Arial', '9pt', '', 'normal', '400', '160', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimateTitle]', 'Est. Title: [EstimateTitle]', 'Estimate Title', '', '', 'Arial', '9pt', '', 'normal', '400', '175', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedDate]', 'Estimated On: [EstimatedDate]', 'Estimated Date', '', '', 'Arial', '9pt', '', 'normal', '400', '190', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ContactName]', '[ContactName]', 'Contact Name', '', '', 'Arial', '9pt', '', 'normal', '35', '100', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CompanyName]', '[CompanyName]', 'Company Name', '', '', 'Arial', '9pt', '', 'normal', '35', '115', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress1]', '[CustomerAddress1]', 'Customer Address 1', '', '', 'Arial', '9pt', '', 'normal', '35', '130', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress2]', '[CustomerAddress2]', 'Customer Address 2', '', '', 'Arial', '9pt', '', 'normal', '35', '145', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress3]', '[CustomerAddress3]', 'Customer Address 3', '', '', 'Arial', '9pt', '', 'normal', '35', '160', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress4]', '[CustomerAddress4]', 'Customer Address 4', '', '', 'Arial', '9pt', '', 'normal', '35', '175', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Greeting]', '[Greeting]', 'Greeting', '', '', 'Arial', '9pt', '', 'normal', '35', '210', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Header]', '[Header]', 'Header', '', '', 'Arial', '9pt', '', 'normal', '35', '230', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ItemTitle]', '[ItemTitle]', 'Item Title', '', '', 'Arial', '9pt', '', 'normal', '35', '290', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '35', '305', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Size]', 'Size: [Size]', 'Size', '', '', 'Arial', '9pt', '', 'normal', '35', '320', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Artwork]', 'Artwork: [Artwork]', 'Artwork', '', '', 'Arial', '9pt', '', 'normal', '35', '335', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Material]', 'Material: [Material]', 'Material', '', '', 'Arial', '9pt', '', 'normal', '35', '350', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Colour]', 'Colour: [Colour]', 'Colour', '', '', 'Arial', '9pt', '', 'normal', '35', '365', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Finishing]', 'Finishing: [Finishing]', 'Finishing', '', '', 'Arial', '9pt', '', 'normal', '35', '380', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Delivery]', 'Delivery: [Delivery]', 'Delivery', '', '', 'Arial', '9pt', '', 'normal', '35', '395', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Notes]', 'Notes: [Notes]', 'Notes', '', '', 'Arial', '9pt', '', 'normal', '35', '410', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Quantity1]', 'Qty1: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '35', '450', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity2]', 'Qty2: [Quantity2]', 'Quantity2', '', '', 'Arial', '9pt', '', 'normal', '140', '450', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity3]', 'Qty3: [Quantity3]', 'Quantity3', '', '', 'Arial', '9pt', '', 'normal', '250', '450', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity4]', 'Qty4: [Quantity4]', 'Quantity4', '', '', 'Arial', '9pt', '', 'normal', '360', '450', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(inTax)]', 'Tax incl: [Price1(inTax)]', 'Price1(in Tax)', '', '', 'Arial', '9pt', '', 'normal', '35', '465', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price2(inTax)]', 'Tax incl: [Price2(inTax)]', 'Price2(in Tax)', '', '', 'Arial', '9pt', '', 'normal', '140', '465', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price3(inTax)]', 'Tax incl: [Price3(inTax)]', 'Price3(in Tax)', '', '', 'Arial', '9pt', '', 'normal', '250', '465', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price4(inTax)]', 'Tax incl: [Price4(inTax)]', 'Price4(in Tax)', '', '', 'Arial', '9pt', '', 'normal', '360', '465', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Footer]', '[Footer]', 'Footer', '', '', 'Arial', '9pt', '', 'normal', '35', '510', '300', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Kind Regards', 'Kind Regards', '', '', 'Arial', '9pt', '', 'normal', '35', '550', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SalesPerson]', '[SalesPerson]', 'Sales Person', '', '', 'Arial', '9pt', '', 'normal', '35', '565', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
            }

            else if (report_page == 'PrintBroker') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(10, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '35', '290', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(10, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '35', '470', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '35', '220', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '35', '570', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[MyCompanyName]', '[MyCompanyName]', 'My Company Name', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress1]', '[MyCompanyAddress1]', 'My Company Address1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress2]', '[MyCompanyAddress2]', 'My Company Address2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress3]', '[MyCompanyAddress3]', 'My Company Address3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress4]', '[MyCompanyAddress4]', 'My Company Address4', '', '', 'Arial', '9pt', '', 'normal', '400', '80', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyCountry]', '[MyCompanyCountry]', 'My Company Country', '', '', 'Arial', '9pt', '', 'normal', '400', '95', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyPhone]', '[MyCompanyPhone]', 'My Company Phone', '', '', 'Arial', '9pt', '', 'normal', '400', '110', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyEmail]', '[MyCompanyEmail]', 'My Company Email', '', '', 'Arial', '9pt', '', 'normal', '400', '125', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[SupplierName]', '[SupplierName]', 'Supplier Name', '', '', 'Arial', '9pt', '', 'normal', '35', '125', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SupplierAddress1]', '[SupplierAddress1]', 'Supplier Address1', '', '', 'Arial', '9pt', '', 'normal', '35', '140', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SupplierAddress2]', '[SupplierAddress2]', 'Supplier Address2', '', '', 'Arial', '9pt', '', 'normal', '35', '155', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SupplierAddress3]', '[SupplierAddress3]', 'Supplier Address3', '', '', 'Arial', '9pt', '', 'normal', '35', '170', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SupplierAddress4]', '[SupplierAddress4]', 'Supplier Address4', '', '', 'Arial', '9pt', '', 'normal', '35', '185', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SupplierCountry]', '[SupplierCountry]', 'Supplier Country', '', '', 'Arial', '9pt', '', 'normal', '35', '200', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Greeting]', '[Greeting]', 'Greeting', '', '', 'Arial', '9pt', '', 'normal', '35', '230', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Header]', '[Header]', 'Header', '', '', 'Arial', '9pt', '', 'normal', '35', '245', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ItemTitle]', '[ItemTitle]', 'Item Title', '', '', 'Arial', '9pt', '', 'normal', '35', '295', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Colour]', 'Colour: [Colour]', 'Colour', '', '', 'Arial', '9pt', '', 'normal', '35', '310', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Size]', 'Size: [Size]', 'Size', '', '', 'Arial', '9pt', '', 'normal', '35', '325', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '35', '340', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Material]', 'Material: [Material]', 'Material', '', '', 'Arial', '9pt', '', 'normal', '35', '355', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Finishing]', 'Finishing: [Finishing]', 'Finishing', '', '', 'Arial', '9pt', '', 'normal', '35', '370', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Delivery]', 'Delivery: [Delivery]', 'Delivery', '', '', 'Arial', '9pt', '', 'normal', '35', '385', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Artwork]', 'Artwork: [Artwork]', 'Artwork', '', '', 'Arial', '9pt', '', 'normal', '35', '400', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Notes]', 'Notes: [Notes]', 'Notes', '', '', 'Arial', '9pt', '', 'normal', '35', '415', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Quantity1]', 'Qty1: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '35', '440', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity2]', 'Qty2: [Quantity2]', 'Quantity2', '', '', 'Arial', '9pt', '', 'normal', '140', '440', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity3]', 'Qty3: [Quantity3]', 'Quantity3', '', '', 'Arial', '9pt', '', 'normal', '245', '440', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity4]', 'Qty4: [Quantity4]', 'Quantity4', '', '', 'Arial', '9pt', '', 'normal', '350', '440', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Footer]', '[Footer]', 'Footer', '', '', 'Arial', '9pt', '', 'normal', '35', '475', '300', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Best Regards', 'Best Regards', '', '', 'Arial', '9pt', '', 'normal', '35', '520', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[SalesPerson]', '[SalesPerson]', 'Sales Person', '', '', 'Arial', '9pt', '', 'normal', '35', '535', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
            }
            else if (report_page == 'Job') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(9, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '280', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(8, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '460', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '30', '220', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '30', '570', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[CompanyName]', '[CompanyName]', 'Company Name', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress1]', '[CustomerAddress1]', 'Customer Address 1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress2]', '[CustomerAddress2]', 'Customer Address 2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress3]', '[CustomerAddress3]', 'Customer Address 3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress4]', '[CustomerAddress4]', 'Customer Address 4', '', '', 'Arial', '9pt', '', 'normal', '400', '80', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerCountry]', '[CustomerCountry]', 'Customer Country', '', '', 'Arial', '9pt', '', 'normal', '400', '95', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerPhone]', '[CustomerPhone]', 'Customer Phone', '', '', 'Arial', '9pt', '', 'normal', '400', '110', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerEmail]', '[CustomerEmail]', 'Customer Email', '', '', 'Arial', '9pt', '', 'normal', '400', '125', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[DeliveryDate]', '[DeliveryDate]', 'Delivery Date', '', '', 'Arial', '9pt', '', 'normal', '400', '150', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryAddress1]', '[DeliveryAddress1]', 'Delivery Address1', '', '', 'Arial', '9pt', '', 'normal', '400', '165', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[JobTitle]', 'Job Title: [JobTitle]', 'JobTitle', '', '', 'Arial', '9pt', '', 'normal', '30', '125', '170', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[JobNumber]', 'Job Number: [JobNumber]', 'Job Number', '', '', 'Arial', '9pt', '', 'normal', '30', '140', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimateNumber]', 'Estimate Number: [EstimateNumber]', 'Estimate Number', '', '', 'Arial', '9pt', '', 'normal', '30', '155', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ProductionDate]', 'Production Date: [ProductionDate]', 'Production Date', '', '', 'Arial', '9pt', '', 'normal', '30', '170', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ProofDate]', 'Proof Date: [ProofDate]', 'Proof Date', '', '', 'Arial', '9pt', '', 'normal', '30', '185', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ArtworkDate]', 'Artwork Date: [ArtworkDate]', 'Artwork Date', '', '', 'Arial', '9pt', '', 'normal', '30', '200', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Greeting]', '[Greeting]', 'Greeting', '', '', 'Arial', '9pt', '', 'normal', '30', '230', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Header]', '[Header]', 'Header', '', '', 'Arial', '9pt', '', 'normal', '30', '245', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ItemTitle]', '[ItemTitle]', 'Item Title', '', '', 'Arial', '9pt', 'bolder', 'normal', '30', '300', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Colour]', 'Colour: [Colour]', 'Colour', '', '', 'Arial', '9pt', '', 'normal', '30', '315', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Size]', 'Size: [Size]', 'Size', '', '', 'Arial', '9pt', '', 'normal', '400', '315', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '30', '330', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Material]', 'Material: [Material]', 'Material', '', '', 'Arial', '9pt', '', 'normal', '400', '330', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Finishing]', 'Finishing: [Finishing]', 'Finishing', '', '', 'Arial', '9pt', '', 'normal', '30', '345', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Delivery]', 'Delivery: [Delivery]', 'Delivery', '', '', 'Arial', '9pt', '', 'normal', '400', '345', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Artwork]', 'Artwork: [Artwork]', 'Artwork', '', '', 'Arial', '9pt', '', 'normal', '30', '360', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Notes]', 'Notes: [Notes]', 'Notes', '', '', 'Arial', '9pt', '', 'normal', '400', '360', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Quantity1]', 'Quantity1: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '30', '400', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(exTax)]', 'Price1(ex Tax): [Price1(exTax)]', 'Price1(ex Tax)', '', '', 'Arial', '9pt', '', 'normal', '30', '415', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(inTax)]', 'Price1(in Tax): [Price1(inTax)]', 'Price1(in Tax)', '', '', 'Arial', '9pt', '', 'normal', '30', '430', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[SalesPerson]', 'Sales Person: [SalesPerson]', 'Sales Person', '', '', 'Arial', '9pt', '', 'normal', '30', '480', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Footer]', '[Footer]', 'Footer', '', '', 'Arial', '9pt', '', 'normal', '30', '495', '300', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedBy]', 'Estimated By: [EstimatedBy]', 'Estimated By', '', '', 'Arial', '9pt', '', 'normal', '30', '535', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
            }
            else if (report_page == 'JobCard') {

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '30', '140', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '30', '690', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', 'Job Card', 'Job Card', '', '', 'Arial', '10pt', 'bolder', 'normal', '200', '10', '50', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[JobNumber]', 'Job Number: [JobNumber]', 'Job Number', '', '', 'Arial', '7pt', 'bolder', 'normal', '30', '25', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[JobTitle]', 'Job Title: [JobTitle]', 'Job Title', '', '', 'Arial', '7pt', 'bolder', 'normal', '30', '40', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedDeliveryDate]', 'Estimated Delivery Date: [EstimatedDeliveryDate]', 'Estimated Delivery Date', '', '', 'Arial', '7pt', 'bolder', 'normal', '30', '55', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[EstimatedProofDate]', 'Proof Date: [EstimatedProofDate]', 'Estimated Proof Date', '', '', 'Arial', '7pt', '', 'normal', '300', '25', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedArtworkDate]', 'Artwork Date: [EstimatedArtworkDate]', 'Estimated Artwork Date', '', '', 'Arial', '7pt', '', 'normal', '300', '40', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedProductionDate]', 'Production Date: [EstimatedProductionDate]', 'Estimated Production Date', '', '', 'Arial', '7pt', '', 'normal', '300', '55', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ContactName]', 'Contact Name: [ContactName]', 'Contact Name', '', '', 'Arial', '7pt', '', 'normal', '30', '85', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerName]', 'Customer Name: [CustomerName]', 'Customer Name', '', '', 'Arial', '7pt', '', 'normal', '30', '100', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryAddress1]', 'DeliveryAddress1: [DeliveryAddress1]', 'Delivery Address1', '', '', 'Arial', '7pt', '', 'normal', '30', '115', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[OrderNumber]', 'Order Number: [OrderNumber]', 'Order Number', '', '', 'Arial', '7pt', '', 'normal', '300', '85', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimateNumber]', 'Estimate Number: [EstimateNumber]', 'Estimate Number', '', '', 'Arial', '7pt', '', 'normal', '300', '100', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedBy]', 'Estimated By: [EstimatedBy]', 'Estimated By', '', '', 'Arial', '7pt', '', 'normal', '300', '115', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ItemTitle]', '[ItemTitle]', 'Item Title', '', '', 'Arial', '8pt', 'bolder', 'normal', '30', '175', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity1]', 'Quantity1: [Quantity1]', 'Quantity1', '', '', 'Arial', '7pt', 'bolder', 'normal', '30', '190', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '7pt', '', 'normal', '30', '205', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Material]', 'Material: [Material]', 'Material', '', '', 'Arial', '7pt', '', 'normal', '30', '220', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Artwork]', 'Artwork: [Artwork]', 'Artwork', '', '', 'Arial', '7pt', '', 'normal', '300', '175', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Colour]', 'Colour: [Colour]', 'Colour', '', '', 'Arial', '7pt', '', 'normal', '300', '190', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Size]', 'Size: [Size]', 'Size', '', '', 'Arial', '7pt', '', 'normal', '300', '205', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(10, '', '', '', '', '', '', 'Arial', '7pt', '', 'normal', '30', '250', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', 'Production Information', 'Production Information', '', '', 'Arial', '10pt', 'bolder', 'normal', '30', '250', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Estimated', 'Estimated', '', '', 'Arial', '8pt', 'bolder', 'normal', '30', '265', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Actual Job Performance', 'Actual Job Performance', '', '', 'Arial', '8pt', 'bolder', 'normal', '300', '265', '200', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[EstimatedPrePress]', 'Pre Press: [EstimatedPrePress]', 'Estimated Pre Press', '', '', 'Arial', '7pt', '', 'normal', '30', '280', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedPress]', 'Press: [EstimatedPress]', 'Estimated Press', '', '', 'Arial', '7pt', '', 'normal', '30', '380', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedPostPress]', 'Post Press: [EstimatedPostPress]', 'Estimated Post Press', '', '', 'Arial', '7pt', '', 'normal', '30', '480', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedWarehouse]', 'Warehouse: [EstimatedWarehouse]', 'Estimated Warehouse', '', '', 'Arial', '7pt', '', 'normal', '30', '580', '250', '40', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedPriceCatalogue]', 'Price Catalogue: [EstimatedPriceCatalogue]', 'Estimated Price Catalogue', '', '', 'Arial', '7pt', '', 'normal', '30', '620', '250', '30', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedOutwork]', 'Outwork: [EstimatedOutwork]', 'Estimated Outwork', '', '', 'Arial', '7pt', '', 'normal', '30', '650', '250', '30', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ActualPrePress]', 'Pre Press: [ActualPrePress]', 'Actual Pre Press', '', '', 'Arial', '7pt', '', 'normal', '300', '280', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ActualPress]', 'Press: [ActualPress]', 'Actual Press', '', '', 'Arial', '7pt', '', 'normal', '300', '380', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ActualPostPress]', 'Post Press: [ActualPostPress]', 'Actual Post Press', '', '', 'Arial', '7pt', '', 'normal', '300', '480', '250', '100', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ActualWarehouse]', 'Warehouse: [ActualWarehouse]', 'Actual Warehouse', '', '', 'Arial', '7pt', '', 'normal', '300', '580', '250', '40', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ActualPriceCatalogue]', 'Price Catalogue: [ActualPriceCatalogue]', 'Actual Price Catalogue', '', '', 'Arial', '7pt', '', 'normal', '300', '620', '250', '30', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[ActualOutwork]', 'Outwork: [ActualOutwork]', 'Actual Outwork', '', '', 'Arial', '7pt', '', 'normal', '300', '650', '250', '30', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(10, '', '', '', '', '', '', 'Arial', '7pt', '', 'normal', '30', '685', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
            }

            else if (report_page == 'Invoice') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(9, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '270', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(8, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '430', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '30', '110', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '30', '530', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[MyCompanyName]', '[MyCompanyName]', 'My Company Name', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress1]', '[MyCompanyAddress1]', 'My Company Address1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress2]', '[MyCompanyAddress2]', 'My Company Address2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress3]', '[MyCompanyAddress3]', 'My Company Address3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress4]', '[MyCompanyAddress4]', 'My Company Address4', '', '', 'Arial', '9pt', '', 'normal', '400', '80', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyPhone]', '[MyCompanyPhone]', 'My Company Phone', '', '', 'Arial', '9pt', '', 'normal', '400', '120', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyEmail]', '[MyCompanyEmail]', 'My Company Email', '', '', 'Arial', '9pt', '', 'normal', '400', '135', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[CompanyName]', '[CompanyName]', 'Company Name', '', '', 'Arial', '9pt', '', 'normal', '30', '120', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress1]', '[CustomerAddress1]', 'Customer Address 1', '', '', 'Arial', '9pt', '', 'normal', '30', '135', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress2]', '[CustomerAddress2]', 'Customer Address 2', '', '', 'Arial', '9pt', '', 'normal', '30', '150', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress3]', '[CustomerAddress3]', 'Customer Address 3', '', '', 'Arial', '9pt', '', 'normal', '30', '165', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress4]', '[CustomerAddress4]', 'Customer Address 4', '', '', 'Arial', '9pt', '', 'normal', '30', '180', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', "INVOICE", "INVOICE", '', '', 'Arial', '11pt', 'bolder', 'normal', '400', '155', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[InvoiceNumber]', 'Invoice Number: [InvoiceNumber]', 'Invoice Number', '', '', 'Arial', '9pt', '', 'normal', '400', '170', '170', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimateNumber]', '[EstimateNumber]', 'Estimate Number', '', '', 'Arial', '9pt', '', 'normal', '400', '185', '170', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[JobNumber]', '[JobNumber]', 'Job Number', '', '', 'Arial', '9pt', '', 'normal', '400', '200', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Greeting]', '[Greeting]', 'Greeting', '', '', 'Arial', '9pt', '', 'normal', '30', '215', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Header]', '[Header]', 'Header', '', '', 'Arial', '9pt', '', 'normal', '30', '230', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ItemTitle]', '[ItemTitle]', 'Item Title', '', '', 'Arial', '9pt', 'bolder', 'normal', '30', '280', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity1]', 'Quantity: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '30', '295', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Colour]', 'Colour: [Colour]', 'Colour', '', '', 'Arial', '9pt', '', 'normal', '30', '310', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '30', '325', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Delivery]', 'Delivery: [Delivery]', 'Delivery', '', '', 'Arial', '9pt', '', 'normal', '30', '340', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Finishing]', 'Finishing: [Finishing]', 'Finishing', '', '', 'Arial', '9pt', '', 'normal', '30', '355', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Price1(exTax)]', 'Price1(excl GST): [Price1(exTax)]', 'Price1(ex GST)', '', '', 'Arial', '9pt', '', 'normal', '30', '370', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Tax1]', 'GST: [Tax1]', 'GST', '', '', 'Arial', '9pt', '', 'normal', '30', '385', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(inTax)]', 'Price1(incl GST): [Price1(inTax)]', 'Price1(incl GST)', '', '', 'Arial', '9pt', '', 'normal', '30', '400', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Footer]', '[Footer]', 'Footer', '', '', 'Arial', '9pt', '', 'normal', '30', '440', '300', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', "Your's sincerely", "Your's sincerely", '', '', 'Arial', '9pt', '', 'normal', '30', '490', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[EstimatedBy]', '[EstimatedBy]', 'Estimated By', '', '', 'Arial', '9pt', '', 'normal', '30', '505', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

            }
            else if (report_page == 'Purchase') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(9, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '240', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(8, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '350', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '30', '110', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '30', '450', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[MyCompanyName]', '[MyCompanyName]', 'My Company Name', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress1]', '[MyCompanyAddress1]', 'My Company Address1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress2]', '[MyCompanyAddress2]', 'My Company Address2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress3]', '[MyCompanyAddress3]', 'My Company Address3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyAddress4]', '[MyCompanyAddress4]', 'My Company Address4', '', '', 'Arial', '9pt', '', 'normal', '400', '80', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyPhone]', '[MyCompanyPhone]', 'My Company Phone', '', '', 'Arial', '9pt', '', 'normal', '400', '120', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[MyCompanyEmail]', '[MyCompanyEmail]', 'My Company Email', '', '', 'Arial', '9pt', '', 'normal', '400', '135', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[SupplierName]', '[SupplierName]', 'Supplier Name', '', '', 'Arial', '9pt', '', 'normal', '30', '120', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CompanyAddress1]', '[CompanyAddress1]', 'Company Address 1', '', '', 'Arial', '9pt', '', 'normal', '30', '135', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CompanyAddress2]', '[CompanyAddress2]', 'Company Address 2', '', '', 'Arial', '9pt', '', 'normal', '30', '150', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CompanyAddress3]', '[CompanyAddress3]', 'Company Address 3', '', '', 'Arial', '9pt', '', 'normal', '30', '165', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CompanyAddress4]', '[CompanyAddress4]', 'Company Address 4', '', '', 'Arial', '9pt', '', 'normal', '30', '180', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', "Purchase Order", "Purchase Order", '', '', 'Arial', '11pt', 'bolder', 'normal', '400', '160', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[PurchaseNumber]', 'Purchase Order No.: [PurchaseNumber]', 'Purchase Order Number', '', '', 'Arial', '9pt', '', 'normal', '400', '175', '190', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[RequiredDate]', 'Ordered Date: [RequiredDate]', 'Ordered Date', '', '', 'Arial', '9pt', '', 'normal', '400', '190', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Quantity1]', 'Quantity: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '30', '250', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '30', '265', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(exTax)]', 'Price1(excl GST): [Price1(exTax)]', 'Price1(ex GST)', '', '', 'Arial', '9pt', '', 'normal', '30', '280', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Tax1]', 'GST: [Tax1]', 'GST', '', '', 'Arial', '9pt', '', 'normal', '30', '295', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Price1(inTax)]', 'Price1(incl GST): [Price1(inTax)]', 'Price1(incl GST)', '', '', 'Arial', '9pt', '', 'normal', '30', '310', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[Footer]', '[Footer]', 'Footer', '', '', 'Arial', '9pt', '', 'normal', '30', '360', '300', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', "Kind Regards", "Kind Regards", '', '', 'Arial', '9pt', '', 'normal', '30', '400', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[RaisedBy]', '[RaisedBy]', 'Raised By', '', '', 'Arial', '9pt', '', 'normal', '30', '415', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
            }
            else if (report_page == 'Note') {

                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', LogoLeft, LogoTop, LogoWidth, LogoHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                CreateCtrl(9, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '240', '500', '15', '000000', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(8, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '30', '500', '500', '15', '000000', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(12, '', '', '', 'header', '', '', 'Arial', '9pt', '', 'normal', '30', '110', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(11, '', '', '', 'footer', '', '', 'Arial', '9pt', '', 'normal', '30', '590', '500', '15', '2630A1', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[CompanyName]', '[CompanyName]', 'CompanyName', '', '', 'Arial', '9pt', '', 'normal', '400', '20', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress1]', '[CustomerAddress1]', 'Customer Address 1', '', '', 'Arial', '9pt', '', 'normal', '400', '35', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress2]', '[CustomerAddress2]', 'Customer Address 2', '', '', 'Arial', '9pt', '', 'normal', '400', '50', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress3]', '[CustomerAddress3]', 'Customer Address 3', '', '', 'Arial', '9pt', '', 'normal', '400', '65', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[CustomerAddress4]', '[CustomerAddress4]', 'Customer Address 4', '', '', 'Arial', '9pt', '', 'normal', '400', '80', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[DeliveryAddress1]', '[DeliveryAddress1]', 'Delivery Address 1', '', '', 'Arial', '9pt', '', 'normal', '30', '120', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryAddress2]', '[DeliveryAddress2]', 'Delivery Address 2', '', '', 'Arial', '9pt', '', 'normal', '30', '135', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryAddress3]', '[DeliveryAddress3]', 'Delivery Address 3', '', '', 'Arial', '9pt', '', 'normal', '30', '150', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryAddress4]', '[DeliveryAddress4]', 'Delivery Address 4', '', '', 'Arial', '9pt', '', 'normal', '30', '165', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', 'DeliveryNote', 'Delivery Note', '', '', 'Arial', '12pt', 'bolder', 'normal', '400', '150', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryNumber]', 'Delivery Note No.: [DeliveryNumber]', 'Delivery No', '', '', 'Arial', '9pt', '', 'normal', '400', '165', '170', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[DeliveryDate]', 'Delivery Date: [DeliveryDate]', 'Delivery Date', '', '', 'Arial', '9pt', '', 'normal', '400', '180', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[OrderNumber]', 'Order Number: [OrderNumber]', 'Order Number', '', '', 'Arial', '9pt', '', 'normal', '400', '195', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '[ContactName]', 'For the attention of: [ContactName]', 'Contact Name', '', '', 'Arial', '9pt', '', 'normal', '30', '195', '170', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Carrier]', 'Carrier: [Carrier]', 'Carrier', '', '', 'Arial', '9pt', '', 'normal', '30', '210', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', 'Description Of Goods', 'Description Of Goods', '', '', 'Arial', '9pt', 'bolder', 'normal', '30', '250', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Quantity1]', 'Quantity: [Quantity1]', 'Quantity1', '', '', 'Arial', '9pt', '', 'normal', '30', '265', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '[Description]', 'Description: [Description]', 'Description', '', '', 'Arial', '9pt', '', 'normal', '30', '280', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

                CreateCtrl(1, '', '', 'Goods received in satisfactory condition', 'Goods received in satisfactory condition', '', '', 'Arial', '9pt', '', 'normal', '400', '515', '190', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Signature', 'Signature', '', '', 'Arial', '9pt', '', 'normal', '400', '535', '50', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', '_________________', 'Signature', '', '', 'Arial', '9pt', '', 'normal', '450', '535', '100', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', 'Date', 'Date', '', '', 'Arial', '9pt', '', 'normal', '400', '555', '30', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');
                CreateCtrl(1, '', '', '____/____/____', 'Date', '', '', 'Arial', '9pt', '', 'normal', '430', '555', '90', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1');

            }
        }
    </script>
    <script>
        //=== Editor button functions ===//

        function AddField(objText, objVal, isitem) {
            var str = objText.split(' ');
            var ctrlName = '';
            for (var i = 0; i < str.length; i++) {
                ctrlName = trim12(ctrlName + str[i]);
            }
            if (ctrlName == "CustomText") {
                addtextbox(2);
            }
            else {
                CreateCtrl(1, '', '' + objVal + '', '' + objVal + '', '' + objText + '', '', '', 'Arial', '10pt', '', 'normal', '150', '100', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1', isitem);
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
            }
        }

        function addImg(mode) {
            window.radopen('../Settings/image_upload.aspx?mode=' + mode + '', "imgwin", "scrollbars,resizable, height = 500px, width = 600px");
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            window.endHeight = "400px";



        }

        function chngObjLAlign() {
            var lft = 0;
            if (selObjs.length > 0) {
                //Before changes
                lft = parseInt(document.getElementById(contPlNm + "CardDiv").style.left); //By Swetha
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {
                            if (parseInt(document.getElementById(selObjs[i]).style.left) < lft)
                                lft = parseInt(document.getElementById(selObjs[i]).style.left);
                        }
                    }
                }
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {
                            document.getElementById(selObjs[i]).style.left = lft + "px";
                        }
                    }
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
            }
        }
        function chngObjRAlign() {
            var lft = 0;
            if (selObjs.length > 0) {
                //Before changes
                lft = parseInt(document.getElementById(contPlNm + "CardDiv").style.width); //By Swetha
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {
                            if (parseInt(document.getElementById(selObjs[i]).style.left) + parseInt(document.getElementById(selObjs[i]).style.width) > lft)
                                lft = parseInt(document.getElementById(selObjs[i]).style.left) + parseInt(document.getElementById(selObjs[i]).style.width);
                        }
                    }
                }

                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {

                        }
                    }
                }
                OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S 
            }
        }
        function chngObjCAlign() {
            var md = parseInt(parseInt(document.getElementById(contPlNm + "CardDiv").style.width) / 2);
            if (selObjs.length > 0) {
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {
                            document.getElementById(selObjs[i]).style.left = parseInt(md - parseInt(document.getElementById(selObjs[i]).style.width) / 2) + "px"

                        }
                    }
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
            }
        }

        function chngUnd() {
            if (selObjs.length > 0) {
                uchk = 0;
                if (document.getElementById(selObjs[0]).style.textDecoration == "none") uchk = 0; else uchk = 1;
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (uchk == 0)
                            document.getElementById(selObjs[i]).style.textDecoration = "underline";
                        else
                            document.getElementById(selObjs[i]).style.textDecoration = "none";
                    }
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S        
            }
        }
        function chngAlign(txtalign) {
            if (txtalign != "") {
                alignstr = "";
                if (txtalign == "1")
                    alignstr = "left";
                else if (txtalign == "2")
                    alignstr = "center";
                else if (txtalign == "3")
                    alignstr = "right";
                else if (txtalign == "4")
                    alignstr = "justify";
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        if (document.getElementById("lockallobjects").value == 0) {
                            document.getElementById(selObjs[i]).style.textAlign = alignstr;
                        }
                    }
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
            }
        }

        function ctrlSet() {
            if (selObj != "" && typeObj == "divobj") {
                if (document.getElementById(selObj).style.fontWeight == "normal")
                    document.getElementById("imgBld").src = "../ODSPrinting/bold.gif";
                else
                    document.getElementById("imgBld").src = "../ODSPrinting/bold_gray.gif";

                if (document.getElementById(selObj).style.fontStyle == "normal")
                    document.getElementById("imgIt").src = "../ODSPrinting/italic.gif";
                else
                    document.getElementById("imgIt").src = "../ODSPrinting/italic_gray.gif";

                list = ddlfonts;
                idx = 0;
                var strfontfamilyga = document.getElementById(selObj).style.fontFamily;

                for (i = list.options.length - 1; i >= 0; i--) {

                    while (strfontfamilyga.indexOf("'") != -1) {
                        strfontfamilyga = strfontfamilyga.replace("'", "");
                    }

                    if (list.options[i].value.toUpperCase() == strfontfamilyga.toUpperCase()) {
                        idx = i;

                        break;
                    }
                }

                if (document.getElementById(selObj).getAttribute("lock") == "false")
                    document.getElementById("lockobjects").innerHTML = "Lock";
                else
                    document.getElementById("lockobjects").innerHTML = "Unlock";


                if (document.getElementById(selObj).getAttribute("repeat") == "false" || document.getElementById(selObj).getAttribute("repeat") == null)
                    document.getElementById("repeatobjects").innerHTML = "Repeat";
                else
                    document.getElementById("repeatobjects").innerHTML = "Undo Repeat";

                list.selectedIndex = idx;
                list = document.getElementById(contPlNm + "lstSize");
                idx = 0;
                for (i = list.options.length - 1; i >= 0; i--) {
                    if (list.options[i].value == document.getElementById(selObj).style.fontSize) {
                        idx = i;
                    }
                }
                list.selectedIndex = idx;

                //Commented By shahbaz - 26-09-2016
                //if (document.getElementById(contPlNm + "ddlGroup") != null) {
                //    list = document.getElementById(contPlNm + "ddlGroup");
                //    idx = 0;
                //    for (i = list.options.length - 1; i >= 0; i--) {
                //        if (list.options[i].value == document.getElementById(selObj).getAttribute("GroupID")) {
                //            idx = i;
                //        }
                //    }
                //    list.selectedIndex = idx;
                //}


                //if (document.getElementById(contPlNm + "ddlGroup") != null) {
                //    list = document.getElementById(contPlNm + "ddlHGroup");
                //    idx = 0;
                //    for (i = list.options.length - 1; i >= 0; i--) {
                //        if (list.options[i].value == document.getElementById(selObj).getAttribute("HGroupID")) {
                //            idx = i;
                //        }
                //    }
                //    list.selectedIndex = idx;
                //}


                if (document.getElementById(selObj).getAttribute("CanChangeFont") == "1")
                    ddlfonts.disabled = "";
                else
                    ddlfonts.disabled = "disabled";

                if (document.getElementById(selObj).getAttribute("CanChangeFontSize") == "1")
                    document.getElementById(contPlNm + "lstSize").disabled = "";
                else
                    document.getElementById(contPlNm + "lstSize").disabled = "disabled";

                if (document.getElementById(selObj).getAttribute("CanChageFontColor") == "1")
                    document.getElementById("imgtextcolor").disabled = "";
                else
                    document.getElementById("imgtextcolor").disabled = "disabled";
            }
            else {
                document.getElementById(contPlNm + "lstSize").disabled = "disabled";
                ddlfonts.disabled = "disabled";
            }


            //Added by shahbaz to select group for All Items.26-09-2016
            if (selObj != 'undefined' && selObj != "") {
                if (document.getElementById(selObj).getAttribute("GroupID") != null) {
                    if (document.getElementById(contPlNm + "ddlGroup") != null) {
                        list = document.getElementById(contPlNm + "ddlGroup");
                        idx = 0;
                        for (i = list.options.length - 1; i >= 0; i--) {
                            if (list.options[i].value == document.getElementById(selObj).getAttribute("GroupID")) {
                                idx = i;
                            }
                        }
                        list.selectedIndex = idx;
                    }
                }

                if (document.getElementById(selObj).getAttribute("HGroupID") != null) {
                    if (document.getElementById(contPlNm + "ddlHGroup") != null) {
                        list = document.getElementById(contPlNm + "ddlHGroup");
                        idx = 0;
                        for (i = list.options.length - 1; i >= 0; i--) {
                            if (list.options[i].value == document.getElementById(selObj).getAttribute("HGroupID")) {
                                idx = i;
                            }
                        }
                        list.selectedIndex = idx;
                    }
                }
            }
        }
        function chngFont(fontNm) {
            for (var i = selObjs.length - 1; i >= 0; i--) {
                if (selObjs[i] != "") {

                    document.getElementById(selObjs[i]).style.fontFamily = fontNm;
                }
            }
            OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
        }

        function chngBld() {
            if (selObjs.length > 0) {
                bchk = 0;
                if (document.getElementById(selObjs[0]).style.fontWeight == "normal") bchk = 0; else bchk = 1;
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        selObj = selObjs[i];
                        var var_remove = selObj.replace("'div'", "");
                        var txtbx = document.getElementById("txtbx" + var_remove);

                        if (bchk == 0) {
                            document.getElementById(selObjs[i]).style.fontWeight = "bolder"; //Before changes 18/1/2010 
                            txtbx.style.fontWeight = "bolder";
                        }
                        else {
                            document.getElementById(selObjs[i]).style.fontWeight = "normal"; //Before changes 18/1/2010  
                            txtbx.style.fontWeight = "normal";
                        }
                    }
                }
                OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S        
            }
        }

        function chngIt() {
            if (selObjs.length > 0) {
                ichk = 0;
                if (document.getElementById(selObjs[0]).style.fontStyle == "normal") ichk = 0; else ichk = 1;
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        selObj = selObjs[i];
                        var var_remove = selObj.replace("'div'", "");
                        var txtbx = document.getElementById("txtbx" + var_remove);

                        if (ichk == 0) {
                            document.getElementById(selObjs[i]).style.fontStyle = "italic";
                            txtbx.style.fontStyle = "italic";
                        }
                        else {
                            document.getElementById(selObjs[i]).style.fontStyle = "normal";
                            if (txtbx != null) {
                                txtbx.style.fontStyle = "normal";
                            }
                        }
                    }
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S
            }
        }
        function appColor(clr) {
            if (clr != "") {
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "")
                        document.getElementById(selObjs[i]).style.color = clr;
                }
                OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
            }
        }


        function chngSize(fsize) {
            for (var i = selObjs.length - 1; i >= 0; i--) {
                if (selObjs[i] != "") {
                    document.getElementById(selObjs[i]).style.fontSize = fsize;
                    if (document.getElementById(selObjs[i]).getAttribute("objtype") == 1) {
                        var txtht = document.getElementById(selObjs[i]).style.height.replace("px", "");
                        var fontsz = document.getElementById(selObjs[i]).style.fontSize.replace("pt", "");
                    }
                }
            }
            OnChangeInsertIntoArray(); //Undo func by Swetha M.S
        }

        function alignthis(val) {
            if (val == 'left') chngObjLAlign();
            if (val == 'center') chngObjCAlign();
            if (val == 'right') chngObjRAlign();
        }

        function showHidDiv() {
            unSelAll();
            if (document.getElementById("crtlDiv").style.visibility == "hidden")
                document.getElementById("crtlDiv").style.visibility = "visible";
            else
                document.getElementById("crtlDiv").style.visibility = "hidden";
            document.getElementById("objName").value = "";
        }

        function showhideHrRule() {
            CreateCtrl(10, '', '', '', '', '', '', 'Arial', '9pt', '', 'normal', '150', '100', '200', '20', '000000', '', '0pt', '1', '1', '0', '1', '0', '0', '0', '1', '1', '1');
            OnChangeInsertIntoArray(); //Undo func by Swetha M.S    
        }

        function addtextbox(CtrlType) {
            if (CtrlType == 1) {
                var objName = "Enter your text";
                CreateCtrl(1, '', '', objName, objName, '', '', 'Arial', '10pt', '', 'normal', '', '', '150', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1', '');

            }
            else if (CtrlType == 2) {
                var objName = "Enter your text";
                CreateCtrl(2, '', '', objName, objName, '', '', 'Arial', '10pt', '', 'normal', '200', '100', '250', '15', '000000', '', '0pt', '1', '1', '1', '1', '0', '0', '0', '1', '1', '1', '');

            }
            OnChangeInsertIntoArray(); //Undo func by Swetha M.S
        }

        var ttlGrid = 0;
        function showhideGridline() {



            var GridImgName = 'GridLines.gif'; //'test.png';
            var GridImageWidth = '<%=EditorWidth %>'.replace("px", "");
            var GridImageHeight = '<%=EditorHeight %>'.replace("px", "");

            CreateCtrl(14, '', '', GridImgName, GridImgName, '', '', '', '', '', '', '0', '0', GridImageWidth, GridImageHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0', '');

        }
        function zoomit(a) {                                    //IE,Changes made on 28.09.2011

            zvalue = document.getElementById("zoomvalue").value;
            var zvalue_f = 0;
            if (a == 'i') {
                zvalue_f = eval(eval(zvalue) + 10);
            }
            if (a == 'o') {
                if (zvalue != 100) {
                    zvalue_f = eval(eval(zvalue) - 10);
                }
            }
            document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.zoom = zvalue_f + "%";
            document.getElementById("zoomvalue").value = zvalue_f;
        }

        function lockobjects() {

            unSelAll();
            if (document.getElementById("lockallobjects").value == 1) {
                document.getElementById("lockobjects").innerHTML = "Lock";
                document.getElementById("lockallobjects").value = 0;
            }
            else {
                document.getElementById("lockobjects").innerHTML = "Unlock";
                document.getElementById("lockallobjects").value = 1;
            }
        }
        function showhidObj(e) {
            var src = DefaultButton_GetSrcElement(e);
            arr = src.id.split("_");
            if (arr.length > 1) {
                if (document.getElementById("'div'_" + arr[1])) {
                    if (document.getElementById("'div'_" + arr[1]).style.visibility == "hidden") {
                        document.getElementById("'div'_" + arr[1]).style.visibility = "visible";
                        document.getElementById("txtbx_" + arr[1]).disabled = false;
                    }
                    else {
                        document.getElementById("'div'_" + arr[1]).style.visibility = "hidden";
                        document.getElementById("txtbx_" + arr[1]).disabled = true;
                    }
                }
            }
        }

        function RepeatObj() {

            if (selObjs.length > 0) {

                repeat = document.getElementById(selObjs[0]).getAttribute("repeat");

                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        selObj = selObjs[i];
                        if (repeat == 'false' || repeat == null) {
                            document.getElementById(selObjs[i]).setAttribute("repeat", "true");
                        }
                        else {
                            document.getElementById(selObjs[i]).setAttribute("repeat", "false");
                        }
                    }

                    if (document.getElementById(selObjs[0]).getAttribute("repeat") == "false")
                        document.getElementById("repeatobjects").innerHTML = "Repeat";
                    else
                        document.getElementById("repeatobjects").innerHTML = "Undo Repeat";

                }
                OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S        
            }
        }


        function LockObj() {

            if (selObjs.length > 0) {

                islock = document.getElementById(selObjs[0]).getAttribute("lock");





                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        selObj = selObjs[i];
                        if (islock == 'false') {
                            document.getElementById(selObjs[i]).setAttribute("lock", "true");
                        }
                        else {
                            document.getElementById(selObjs[i]).setAttribute("lock", "false");
                        }
                    }

                    if (document.getElementById(selObjs[0]).getAttribute("lock") == "false")
                        document.getElementById("lockobjects").innerHTML = "Lock";
                    else
                        document.getElementById("lockobjects").innerHTML = "Unlock";

                }
                OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S        
            }
        }

        function SetGroup(GroupID) {


            if (GroupID != "-1" || GroupID != "-2" || GroupID != "0") {
                if (selObjs.length > 0) {
                    for (var i = selObjs.length - 1; i >= 0; i--) {
                        if (selObjs[i] != "") {
                            selObj = selObjs[i];
                            document.getElementById(selObjs[i]).setAttribute("GroupID", GroupID);
                        }
                    }
                    OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S        
                }
            }


            //** To Highlight Tags on Group **//
            var card_Div = document.getElementById('ctl00_ContentPlaceHolder1_CardDiv');
            var counterdiv = card_Div.getElementsByTagName('div');
            for (var j = 0; j < counterdiv.length; j++) {
                if (GroupID > 0) {
                    if (counterdiv[j].getAttribute("GroupID") == GroupID) {
                        counterdiv[j].style.border = "2px dotted red";
                    }
                    else {
                        if (counterdiv[j].getAttribute("objType") == 1 || counterdiv[j].getAttribute("objType") == 2) {
                            counterdiv[j].style.border = "1px dotted #ADADAD";
                        }
                    }
                }
                else {
                    if (counterdiv[j].getAttribute("objType") == 1 || counterdiv[j].getAttribute("objType") == 2) {
                        counterdiv[j].style.border = "1px dotted #ADADAD";
                    }
                }
            }
        }


        function SetHGroup(HGroupID) {

            if (HGroupID != "-1" || HGroupID != "-2" || HGroupID != "0") {
                if (selObjs.length > 0) {
                    for (var i = selObjs.length - 1; i >= 0; i--) {
                        if (selObjs[i] != "") {
                            selObj = selObjs[i];
                            document.getElementById(selObjs[i]).setAttribute("HGroupID", HGroupID);
                        }
                    }
                    OnChangeInsertIntoArray(); //Testing Undo/Redo by swetha M.S        
                }
            }


            //** To Highlight Tags on Group **//
            var card_Div = document.getElementById('ctl00_ContentPlaceHolder1_CardDiv');
            var counterdiv = card_Div.getElementsByTagName('div');
            for (var j = 0; j < counterdiv.length; j++) {
                if (HGroupID > 0) {
                    if (counterdiv[j].getAttribute("HGroupID") == HGroupID) {
                        counterdiv[j].style.border = "2px dotted red";
                    }
                    else {
                        if (counterdiv[j].getAttribute("objType") == 1 || counterdiv[j].getAttribute("objType") == 2) {
                            counterdiv[j].style.border = "1px dotted #ADADAD";
                        }
                    }
                }
                else {
                    if (counterdiv[j].getAttribute("objType") == 1 || counterdiv[j].getAttribute("objType") == 2) {
                        counterdiv[j].style.border = "1px dotted #ADADAD";
                    }
                }
            }
        }

        function ShowHideGroup(type) {
            var div_Group = document.getElementById("div_Group");
            var txtGroupName = document.getElementById("<%=txtGroupName.ClientID %>");
            var ddlGroup = document.getElementById("<%=ddlGroup.ClientID %>");


            if (type == "show") {
                if (ddlGroup.options[ddlGroup.selectedIndex].value == "-2") {
                    unSelAll();
                    document.getElementById("divBackGroundNew").style.display = "block";
                    div_Group.style.display = "block";
                    txtGroupName.value = "";
                    txtGroupName.focus();
                    showDivPopupCenter('div_Group', '200');
                }
            }
            else {
                document.getElementById("divBackGroundNew").style.display = "none";
                div_Group.style.display = "none";
                document.getElementById("spnerrGroupName").style.display = "none";
            }
        }


        function ValidateGroup() {
            var txtGroupName = document.getElementById("<%=txtGroupName.ClientID %>");
            if (trim12(txtGroupName.value) == "") {
                document.getElementById("spnerrGroupName").style.display = "block";
                return false;
            }
            else {
                ShowHideGroup('hide');
                return true;
            }
        }


        function ShowHideHGroup(type) {


            var div_HGroup = document.getElementById("div_HGroup");
            var txtHGroupName = document.getElementById("<%=txtHGroupName.ClientID %>");
            var ddlHGroup = document.getElementById("<%=ddlHGroup.ClientID %>");
            if (type == "show") {
                if (ddlHGroup.options[ddlHGroup.selectedIndex].value == "-2") {
                    unSelAll();
                    document.getElementById("divBackGroundNew").style.display = "block";
                    div_HGroup.style.display = "block";
                    txtHGroupName.value = "";
                    txtHGroupName.focus();
                    showDivPopupCenter('div_HGroup', '200');
                }
            }
            else {
                document.getElementById("divBackGroundNew").style.display = "none";
                div_HGroup.style.display = "none";
                document.getElementById("spnerrHGroupName").style.display = "none";
            }
        }

        function ValidateHGroup() {
            var txtHGroupName = document.getElementById("<%=txtHGroupName.ClientID %>");
            if (trim12(txtHGroupName.value) == "") {
                document.getElementById("spnerrHGroupName").style.display = "block";
                return false;
            }
            else {
                ShowHideHGroup('hide');
                return true;
            }
        }


        function CallAdjustProperties() {
            ValidateName('stay');
            __doPostBack('ctl00$ContentPlaceHolder1$btnUpdate', '');

            var TemplateID = '<%=TemplateID %>';
            var page = '<%=report_page %>';

            url = '<%=sitepath %>' + "common/templates_editproperty_popup.aspx?id=" + TemplateID + "&page=" + page + "&pop=yes"
            window.open(url);


        }

    </script>
    <script language="javascript" type="text/javascript">
        /// ODSEditor Scripts///
        var divsarray = new Array();
        var imgsarray = new Array();
        var divids = '';

        var isIE = document.all;
        var isNN = !document.all && document.getElementById;
        var isN4 = document.layers;
        var isHot = false; nowX = 0; nowY = 0, nowW = 0, nowH = 0;
        var movtype = 0;
        var anowX = new Array();
        var anowY = new Array();
        var anowW = new Array();
        var anowH = new Array();

        var is_ie = (/msie/i.test(navigator.userAgent) && !/opera/i.test(navigator.userAgent));
        var is_ie5 = (is_ie && /msie 5\.0/i.test(navigator.userAgent));
        var is_opera = /opera/i.test(navigator.userAgent);
        var is_khtml = /Konqueror|Safari|KHTML/i.test(navigator.userAgent);

        var idnm = 0;
        var selObj = "";
        var selObjs = new Array();
        var chkCtrl = 0;
        var typeObj = "";
        var islock = "false";
        var canMove = "1";
        var contPlNm = "ctl00_ContentPlaceHolder1_";
        var actM = 0;

        var report_page = '<%=report_page %>';
        pageLoadEvents();
        if ('<%=action %>' == "add") {
            //loadObjects();
            <%=strCreateControl %>;
        }

        function PointToPixel(val, dpi) {
            rval = parseFloat(val) * parseFloat(dpi) / parseFloat("72");
            return parseInt(rval);
        }
        function setDivWH() {
            tDivht = PointToPixel(document.getElementById(contPlNm + "CDivHPoint").value, document.getElementById(contPlNm + "sYDPI").value);
            tDivWd = PointToPixel(document.getElementById(contPlNm + "CDivWPoint").value, document.getElementById(contPlNm + "sXDPI").value);
            tDivht = '<%=EditorHeight%>';
            tDivWd = '<%=EditorWidth%>';
            document.getElementById(contPlNm + "CardDiv").style.width = tDivWd;// + "px";
            document.getElementById(contPlNm + "CardDiv").style.height = tDivht;// + "px";
            document.getElementById(contPlNm + "Div1").style.width = tDivWd;// + "px";
            document.getElementById(contPlNm + "Div1").style.height = tDivht;// + "px";
        }

        function pageLoadEvents() {
            if (screen.deviceXDPI) {
            }
            setDivWH();
            document.getElementById("tmpImgPath").value = "";
            document.getElementById(contPlNm + "chkBrows").value = isIE ? "0" : "1";
            sr = document.getElementById("tdDesign");

            if (document.getElementById(contPlNm + "DMode").value == "1") {
                if (sr.attachEvent) { // IE
                    sr.attachEvent("onclick", selDiv);
                } else if (sr.addEventListener) { // Gecko / W3C
                    sr.addEventListener("click", selDiv, true);
                } else {
                    sr["onclick"] = selDiv;
                }
                document.onkeydown = keyProcess;
            }
        }

        var valu_refresh = 0;
        document.onkeyup = KeyCheck;
        function KeyCheck(e) {
            var KeyID = (window.event) ? event.keyCode : e.keyCode;
            switch (KeyID) {
                case 46:
                    deleteselected();
                    break;
            }
            valu_refresh = 1;
            var chkCrtlKey = false;
            var isIE = /MSIE/.test(navigator.userAgent);
            var KeyID = isIE ? event.keyCode : e.which;


            var mac = (navigator.appVersion.indexOf("Mac") !== -1) ? true : false;
            if (e != null && typeof (e.ctrlKey) != "undefined") {
                if (mac) {
                    chkCrtlKey = e.metaKey;
                }
                else {
                    chkCrtlKey = e.ctrlKey;
                }

            }
            else {

                if (mac) {
                    ctrlKey = event.metaKey;
                }
                else {
                    ctrlKey = event.ctrlKey;
                }
            }




            if (isIE) {
                if (KeyID == 90 && ctrlKey == true) {
                    Undo();
                }
            }
            else if (KeyID == 90 && chkCrtlKey == true) {
                Undo();
            }

            if (isIE) {
                if (KeyID == 89 && ctrlKey == true) {
                    Redo();
                }
            }
            else if (KeyID == 89 && chkCrtlKey == true) {
                Redo();
            }
            if (isIE) {
                if (KeyID == 66 && ctrlKey == true) {
                    chngBld();
                }
            }
            else if (KeyID == 66 && chkCrtlKey == true) {
                chngBld();
            }
            if (isIE) {
                if (KeyID == 73 && ctrlKey == true) {
                    chngIt();
                }
            }
            else if (KeyID == 73 && chkCrtlKey == true) {
                chngIt();
            }
            if (isIE) {
                if (KeyID == 85 && ctrlKey == true) {
                    chngUnd();
                }
            }
            else if (KeyID == 85 && chkCrtlKey == true) {
                chngUnd();
            }
        }

        function trim(str) {
            str = this != window ? this : str;
            return str.replace(/^\s+/, '').replace(/\s+$/, '');
        }


        //-----------------------------------------GET EXTENSION---------------------------------

        function getExt(filename) {
            var dot_pos = filename.lastIndexOf(".");
            if (dot_pos == -1)
                return "";
            return filename.substr(dot_pos + 1).toLowerCase();
        }


        function mbtnOver(src) {
        }
        function mbtnOut(src) {
            src.style.borderWidth = "0px";
            src.style.borderStyle = "none";
        }

        function creatTable() {
            if (selObj != "") {
                var src = document.getElementById(selObj);
                arr = selObj.replace("'div'_", "");
                if (src.getAttribute("objtype") == 1 || src.getAttribute("objtype") == 2) {
                    document.getElementById("txtbx_" + arr).className = "fillthetextbox";
                    var txtht = src.style.height.replace("px", "");
                    var fontsz = src.style.fontSize.replace("pt", "");
                }
                var mdv = document.createElement("div");
                mdv.className = "div_wrap div_selArea";
                mdv.setAttribute("id", "MovDiv" + src.id);
                mdv.setAttribute("type", "MvDiv");

                var dv1 = document.createElement("div");
                dv1.className = "div_marqueeHoriz div_marqueeNorth";
                dv1.setAttribute("type", "MDivLN");
                mdv.appendChild(dv1);

                var dv2 = document.createElement("div");
                dv2.className = "div_marqueeVert div_marqueeEast";
                dv2.setAttribute("type", "MDivLE");
                mdv.appendChild(dv2);

                var dv3 = document.createElement("div");
                dv3.className = "div_marqueeHoriz div_marqueeSouth";
                dv3.setAttribute("type", "MDivLS");
                mdv.appendChild(dv3);

                var dv4 = document.createElement("div");
                dv4.className = "div_marqueeVert div_marqueeWest";
                dv4.setAttribute("type", "MDivLW");
                mdv.appendChild(dv4);

                var dv5 = document.createElement("div");
                dv5.className = "div_handle div_handleN";
                dv5.setAttribute("type", "MDivN");
                if (dv5.attachEvent) { dv5.attachEvent("onmousedown", ImgMove); }
                else if (dv5.addEventListener) { dv5.addEventListener("mousedown", ImgMove, true); }
                else { dv5["onmousedown"] = ImgMove; }
                mdv.appendChild(dv5);

                var dv6 = document.createElement("div");
                dv6.className = "div_handle div_handleNE";
                dv6.setAttribute("type", "MDivNE");
                if (dv6.attachEvent) { dv6.attachEvent("onmousedown", ImgMove); }
                else if (dv6.addEventListener) { dv6.addEventListener("mousedown", ImgMove, true); }
                else { dv6["onmousedown"] = ImgMove; }
                mdv.appendChild(dv6);

                var dv7 = document.createElement("div");
                dv7.className = "div_handle div_handleE";
                dv7.setAttribute("type", "MDivE");
                if (dv7.attachEvent) { dv7.attachEvent("onmousedown", ImgMove); }
                else if (dv7.addEventListener) { dv7.addEventListener("mousedown", ImgMove, true); }
                else { dv7["onmousedown"] = ImgMove; }
                mdv.appendChild(dv7);

                var dv8 = document.createElement("div");
                dv8.className = "div_handle div_handleSE";
                dv8.setAttribute("type", "MDivSE");
                if (dv8.attachEvent) { dv8.attachEvent("onmousedown", ImgMove); }
                else if (dv8.addEventListener) { dv8.addEventListener("mousedown", ImgMove, true); }
                else { dv8["onmousedown"] = ImgMove; }
                mdv.appendChild(dv8);

                var dv9 = document.createElement("div") //b m
                dv9.className = "div_handle div_handleS";
                dv9.setAttribute("type", "MDivS");
                if (dv9.attachEvent) { dv9.attachEvent("onmousedown", ImgMove); }
                else if (dv9.addEventListener) { dv9.addEventListener("mousedown", ImgMove, true); }
                else { dv9["onmousedown"] = ImgMove; }
                mdv.appendChild(dv9);

                var dv10 = document.createElement("div"); //b l
                dv10.className = "div_handle div_handleSW";
                dv10.setAttribute("type", "MDivSW");
                if (dv10.attachEvent) { dv10.attachEvent("onmousedown", ImgMove); }
                else if (dv10.addEventListener) { dv10.addEventListener("mousedown", ImgMove, true); }
                else { dv10["onmousedown"] = ImgMove; }
                mdv.appendChild(dv10);


                var dv11 = document.createElement("div"); //m l
                dv11.className = "div_handle div_handleW";
                dv11.setAttribute("type", "MDivW");
                if (dv11.attachEvent) { dv11.attachEvent("onmousedown", ImgMove); }
                else if (dv11.addEventListener) { dv11.addEventListener("mousedown", ImgMove, true); }
                else { dv11["onmousedown"] = ImgMove; }
                mdv.appendChild(dv11);

                var dv12 = document.createElement("div");
                dv12.className = "div_handle div_handleNW";
                dv12.setAttribute("type", "MDivNW");
                if (dv12.attachEvent) { dv12.attachEvent("onmousedown", ImgMove); }
                else if (dv12.addEventListener) { dv12.addEventListener("mousedown", ImgMove, true); }
                else { dv12["onmousedown"] = ImgMove; }
                mdv.appendChild(dv12);

                var dv13 = document.createElement("div");
                dv13.className = "div_clickArea";
                dv13.setAttribute("type", "MDivC");
                if (dv13.attachEvent) { dv13.attachEvent("onmousedown", ImgMove); }
                else if (dv13.addEventListener) { dv13.addEventListener("mousedown", ImgMove, true); }
                else { dv13["onmousedown"] = ImgMove; }
                mdv.appendChild(dv13);
                src.appendChild(mdv);
            }
        }

        function unSelAll() {
            for (var i = 0; i < idnm + 200; i++) {
                if (document.getElementById("'div'_" + i)) {
                    var obj = document.getElementById("'div'_" + i);
                    var obj2 = document.getElementById("MovDiv" + obj.id);
                    if (obj.getAttribute("objtype") == 1) {
                        document.getElementById("txtbx_" + i).className = "emptythetextbox";
                    }
                    if (obj2) {
                        obj.removeChild(obj2);
                    }
                }
            }
            selObj = "";
            selObjs = new Array();
        }

        function selDiv(e) {

            chkCrtlKey = false;
            if (document.getElementById(contPlNm + "DMode").value == "1") {
                var src = DefaultButton_GetSrcElement(e);

                var inputs = document.getElementById("div_CtrlList");
                var ctrltxtbx = inputs.getElementsByTagName("input"); //input
                document.getElementById("div_EditFields").style.display = "none"; //To hide edit div

                if (src.getAttribute("type") && src.getAttribute("objtype") != "13" && src.getAttribute("objtype") != "14") {
                    if (src.getAttribute("type") == "imgObj") src = src.parentNode;

                    var mac = (navigator.appVersion.indexOf("Mac") !== -1) ? true : false;
                    if (e != null && typeof (e.ctrlKey) != "undefined") {
                        if (mac) {
                            chkCrtlKey = e.metaKey;
                        }
                        else {
                            chkCrtlKey = e.ctrlKey;
                        }

                    }
                    else {

                        if (mac) {
                            ctrlKey = event.metaKey;
                        }
                        else {
                            ctrlKey = event.ctrlKey;
                        }
                    }

                    if (chkCrtlKey == true) {
                        inputs.style.display = "none"; //To hide textbox on multiple fields select
                        typeObj = src.getAttribute("type"); //src.type;
                        islock = src.getAttribute("lock"); //src.lock;
                        selObj = src.id;
                        creatTable();
                        ctrlSet();
                        selObjs[selObjs.length] = src.id;
                    }
                    else {
                        if (src.getAttribute("type") == "MDivN" || src.getAttribute("type") == "MDivNE" || src.getAttribute("type") == "MDivE" || src.getAttribute("type") == "MDivSE" || src.getAttribute("type") == "MDivS" || src.getAttribute("type") == "MDivSW" || src.getAttribute("type") == "MDivW" || src.getAttribute("type") == "MDivNW" || src.getAttribute("type") == "MDivC" || src.getAttribute("type") == "MDivLN" || src.getAttribute("type") == "MDivLE" || src.getAttribute("type") == "MDivLW" || src.getAttribute("type") == "MDivLS")
                            src = src.parentNode.parentNode;
                        unSelAll();
                        typeObj = src.getAttribute("type"); //src.type;
                        islock = src.getAttribute("lock"); //src.lock;
                        selObj = src.id;
                        selObjs[0] = src.id;
                        creatTable();
                        ctrlSet();

                        //=== To Show only the selected field textbox on edit -- By Swetha on 20/2/2010 =====//
                        var var_remove = selObj.replace("'div'", "");
                        for (var i = 0; i < idnm; i++) {
                            var txtbx = document.getElementById("txtbx_" + i);
                            var row1 = document.getElementById("row1_" + i);

                            if (txtbx != null) {

                                inputs.style.display = "none";
                                txtbx.style.display = "none";
                                row1.style.display = "none";
                            }
                        }
                        //=== To Show only the selected field textbox on edit -- By Swetha on 20/2/2010 =====//

                        //==== To display right click menu only to Edit Logo Image -- By Swetha M.S on 22/2/2010====//
                        if (document.getElementById("lockallobjects").value == 0)//src.getAttribute("objtype") == "3" &&
                        {
                            if (src != null) {
                                var objtype = src.getAttribute("objtype");
                                if (objtype == "8" || objtype == "9" || objtype == "10") {
                                    ContextMenu.hide;
                                }
                                else {
                                    ContextMenu.set("global-menu", selObj);
                                    SetRightMenuTopLeft(selObj);
                                }
                            }
                        }
                        //==== To display right click menu only to Edit Logo Image -- By Swetha M.S on 22/2/2010====//
                        //}
                    }
                }
                else {
                    unSelAll();
                    ctrlSet();
                    inputs.style.display = "none"; //To hide textbox on unselect      
                    document.getElementById("div_EditFields").style.display = "none"; //To hide edit div
                    ContextMenu.hide;
                }
            }
        }
        function DefaultButton_GetSrcElement(e) {
            if (typeof (window.event) != "undefined") {
                return window.event.srcElement;
            }
            if (e != null && typeof (e.target) != "undefined") {
                return e.target;
            }
            return null;
        }
        function chgTxt(e) {
            var src = DefaultButton_GetSrcElement(e);
            arr = src.id.split("_");
            if (arr.length > 1) {
                document.getElementById("'div'_" + arr[1]).innerHTML = src.value.replace(/\n/g, "<br>");
            }
        }
        function CheckKeyCodeInteger(e) {
            var kcode = 0;
            kcode = isIE ? event.keyCode : e.which;
            if ((kcode >= 48 && kcode <= 57) || (kcode >= 96 && kcode <= 105) || (kcode >= 37 && kcode <= 40) || (kcode == 8 || kcode == 46 || kcode == 9))
            { return true; }
            else
            { return false; }

        }
        function savecntrlList(e) {
            OnChangeInsertIntoArray();
        }

        //========================= Div move functions ============================
        function ImgMove(e) {


            if (canMove == "1" || canMove == null) {
                var src = DefaultButton_GetSrcElement(e);
                topObj = isIE ? "BODY" : "HTML";
                whichObj = src.parentNode.parentNode;
                hotObj = src;
                offsetx = isIE ? event.clientX : e.clientX;
                offsety = isIE ? event.clientY : e.clientY;
                nowX = parseInt(whichObj.style.left);
                nowY = parseInt(whichObj.style.top);
                nowW = parseInt(whichObj.style.width);
                nowH = parseInt(whichObj.style.height);
                ddEnabled = true;
                anowX = new Array();
                anowY = new Array();
                for (var i = 0; i < selObjs.length; i++) {
                    if (selObjs[i] != "") {
                        anowX[i] = parseInt(document.getElementById(selObjs[i]).style.left);
                        anowY[i] = parseInt(document.getElementById(selObjs[i]).style.top);
                        anowW[i] = parseInt(document.getElementById(selObjs[i]).style.width);
                        anowH[i] = parseInt(document.getElementById(selObjs[i]).style.height);
                    }
                    document.onmousemove = dd;

                }




            }
        }
        function dd(e) {
            if (!ddEnabled) {

                return;
            }

            // CheckCurrentTagPosition(whichObj);


            var chkBtn = 0;
            chkBtn = isIE ? event.button : e.which;

            if (chkBtn == 1) {
                var ctype = "";
                ctype = hotObj.getAttribute("type");
                if (ctype == "MDivC") {
                    var MWidth = document.getElementById(contPlNm + "Div1").style.pixelWidth;
                    var MHeight = document.getElementById(contPlNm + "Div1").style.pixelHeight;
                    if (isIE) {
                        if (nowX + event.clientX - offsetx < 0) return false;
                        if (nowX + event.clientX - offsetx + whichObj.style.pixelWidth > MWidth) return false;
                        if (nowY + event.clientY - offsety < 0) return false;
                        if (nowY + event.clientY - offsety + whichObj.style.pixelHeight > MHeight) return false;
                    }
                    else {
                        if (nowX + e.clientX - offsetx < 0) return false;
                        if (nowX + e.clientX - offsetx + whichObj.style.pixelWidth > MWidth) return false;
                        if (nowY + e.clientY - offsety < 0) return false;
                        if (nowY + e.clientY - offsety + whichObj.style.pixelHeight > MHeight) return false;
                    }
                    for (var i = selObjs.length - 1; i >= 0; i--) {
                        if (selObjs[i] != "") {
                            document.getElementById(selObjs[i]).style.left = isIE ? anowX[i] + event.clientX - offsetx : anowX[i] + e.clientX - offsetx + "px";
                            document.getElementById(selObjs[i]).style.top = isIE ? anowY[i] + event.clientY - offsety : anowY[i] + e.clientY - offsety + "px";
                        }
                    }
                }
                else if (ctype == "MDivS") {
                    whichObj.style.height = isIE ? nowH + event.clientY - offsety : nowH + e.clientY - offsety + "px";
                }
                else if (ctype == "MDivE") {
                    whichObj.style.width = isIE ? nowW + event.clientX - offsetx : nowW + e.clientX - offsetx + "px";
                }
                else if (ctype == "MDivSE") {
                    whichObj.style.width = isIE ? nowW + event.clientX - offsetx : nowW + e.clientX - offsetx + "px";
                    whichObj.style.height = isIE ? nowH + event.clientY - offsety : nowH + e.clientY - offsety + "px";
                }
                else if (ctype == "MDivW") {
                    whichObj.style.width = isIE ? nowW + offsetx - event.clientX : nowW + offsetx - e.clientX + "px";
                    whichObj.style.left = isIE ? nowX + event.clientX - offsetx : nowX + e.clientX - offsetx + "px";
                }
                else if (ctype == "MDivN") {
                    whichObj.style.height = isIE ? nowH + offsety - event.clientY : nowH + offsety - e.clientY + "px";
                    whichObj.style.top = isIE ? nowY + event.clientY - offsety : nowY + e.clientY - offsety + "px";
                }
                else if (ctype == "MDivNW") {
                    whichObj.style.height = isIE ? nowH + offsety - event.clientY : nowH + offsety - e.clientY + "px";
                    whichObj.style.top = isIE ? nowY + event.clientY - offsety : nowY + e.clientY - offsety + "px";
                    whichObj.style.width = isIE ? nowW + offsetx - event.clientX : nowW + offsetx - e.clientX + "px";
                    whichObj.style.left = isIE ? nowX + event.clientX - offsetx : nowX + e.clientX - offsetx + "px";
                }
                else if (ctype == "MDivSW") {
                    whichObj.style.height = isIE ? nowH + event.clientY - offsety : nowH + e.clientY - offsety + "px";
                    whichObj.style.width = isIE ? nowW + offsetx - event.clientX : nowW + offsetx - e.clientX + "px";
                    whichObj.style.left = isIE ? nowX + event.clientX - offsetx : nowX + e.clientX - offsetx + "px";
                }
                else if (ctype == "MDivNE") {
                    whichObj.style.height = isIE ? nowH + offsety - event.clientY : nowH + offsety - e.clientY + "px";
                    whichObj.style.top = isIE ? nowY + event.clientY - offsety : nowY + e.clientY - offsety + "px";
                    whichObj.style.width = isIE ? nowW + event.clientX - offsetx : nowW + e.clientX - offsetx + "px";
                }
            }
            return false;
        }
        document.onmouseup = Function("ddEnabled=false");
        function keyProcess(e) {
            try {
                if ((selObj != "")) {

                    var src = document.getElementById(selObj);


                    kcode = 0;
                    kcode = isIE ? event.keyCode : e.which;
                    chkCrtlKey = isIE ? event.ctrlKey : e.ctrlKey;
                    chkShiftKey = isIE ? event.shiftKey : e.shiftKey;



                    if (kcode == 40 || kcode == 37 || kcode == 39 || kcode == 38 || kcode == 46) {
                        var MWidth = parseInt(document.getElementById(contPlNm + "Div1").style.width);
                        var MHeight = parseInt(document.getElementById(contPlNm + "Div1").style.height);
                        if (chkCrtlKey == false && chkShiftKey == false) {
                            if (kcode == 40)    // Down
                            {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.top) + parseInt(document.getElementById(selObjs[i]).style.height) + 5 < MHeight) document.getElementById(selObjs[i]).style.top = parseInt(document.getElementById(selObjs[i]).style.top) + 5 + "px";
                                    }
                                }
                            }
                            else if (kcode == 38) // Up
                            {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.top) >= 0) document.getElementById(selObjs[i]).style.top = parseInt(document.getElementById(selObjs[i]).style.top) - 5 + "px";
                                    }
                                }
                            }
                            else if (kcode == 37) // Left
                            {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.left) >= 0) document.getElementById(selObjs[i]).style.left = parseInt(document.getElementById(selObjs[i]).style.left) - 5 + "px";
                                    }
                                }
                            }
                            else if (kcode == 39) // Right
                            {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.left) + parseInt(document.getElementById(selObjs[i]).style.width) + 5 < MWidth) document.getElementById(selObjs[i]).style.left = parseInt(document.getElementById(selObjs[i]).style.left) + 5 + "px";
                                    }
                                }


                            }
                        }
                        else if (chkCrtlKey == false && chkShiftKey == true) {
                            if (kcode == 40) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.top) + parseInt(document.getElementById(selObjs[i]).style.height) < MHeight) document.getElementById(selObjs[i]).style.top = parseInt(document.getElementById(selObjs[i]).style.top) + 1 + "px";
                                    }
                                }
                            }
                            else if (kcode == 38) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.top) >= 0) document.getElementById(selObjs[i]).style.top = parseInt(document.getElementById(selObjs[i]).style.top) - 1 + "px";
                                    }
                                }
                            }
                            else if (kcode == 37) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {

                                        if (parseInt(document.getElementById(selObjs[i]).style.left) >= 0) document.getElementById(selObjs[i]).style.left = parseInt(document.getElementById(selObjs[i]).style.left) - 1 + "px";
                                    }
                                }
                            }
                            else if (kcode == 39) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        if (parseInt(document.getElementById(selObjs[i]).style.left) + parseInt(document.getElementById(selObjs[i]).style.width) < MWidth) document.getElementById(selObjs[i]).style.left = parseInt(document.getElementById(selObjs[i]).style.left) + 1 + "px";
                                    }
                                }

                            }
                        }
                        else if (chkCrtlKey == true && chkShiftKey == false) {
                            if (kcode == 40) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.height = parseInt(document.getElementById(selObjs[i]).style.height) + 5 + "px";
                                    }
                                }

                            }
                            else if (kcode == 38) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.height = parseInt(document.getElementById(selObjs[i]).style.height) - 5 + "px";
                                    }
                                }

                            }
                            else if (kcode == 37) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.width = parseInt(document.getElementById(selObjs[i]).style.width) - 5 + "px";
                                    }
                                }

                            }
                            else if (kcode == 39) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {

                                        document.getElementById(selObjs[i]).style.width = parseInt(document.getElementById(selObjs[i]).style.width) + 5 + "px";
                                    }
                                }

                            }
                        }
                        else if (chkCrtlKey == true && chkShiftKey == true) {
                            if (kcode == 40) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.height = parseInt(document.getElementById(selObjs[i]).style.height) + 1 + "px";
                                    }
                                }

                            }
                            else if (kcode == 38) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.height = parseInt(document.getElementById(selObjs[i]).style.height) - 1 + "px";
                                    }
                                }

                            }
                            else if (kcode == 37) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.width = parseInt(document.getElementById(selObjs[i]).style.width) - 1 + "px";
                                    }
                                }
                            }
                            else if (kcode == 39) {
                                for (var i = selObjs.length - 1; i >= 0; i--) {
                                    if (selObjs[i] != "") {
                                        document.getElementById(selObjs[i]).style.Width = parseInt(document.getElementById(selObjs[i]).style.width) + 1 + "px";
                                    }
                                }

                            }
                        }
                        //}
                    }
                    return false;
                }
            }
            catch (err) { return false };
        }




        function CheckCurrentTagPosition(objcurrenttag) {

            var cuurentitemtop = 0;
            var itemstart = 0;
            var itemend = 0;
            var objType = 0;
            var card_Div = document.getElementById('ctl00_ContentPlaceHolder1_CardDiv');
            var counterdiv = card_Div.getElementsByTagName('div');
            for (var j = 0; j < counterdiv.length; j++) {
                objType = counterdiv[j].getAttribute("objType");
                if (objType == 9) {
                    itemstart = counterdiv[j].style.top.replace("px", "");
                }
                else if (objType == 8) {
                    itemend = counterdiv[j].style.top.replace("px", "");
                }
            }
            cuurentitemtop = objcurrenttag.style.top.replace("px", "");

            if (objcurrenttag.getAttribute("isitem") == 'n') {
                if (parseInt(cuurentitemtop) > parseInt(itemstart) && parseInt(cuurentitemtop) < parseInt(itemend)) {
                    objcurrenttag.setAttribute("isitem", '');
                    alert('This tag is available only outside the item area, Please re-position.');

                }
            }
            else if (objcurrenttag.getAttribute("isitem") == 'y') {
                if (parseInt(cuurentitemtop) < parseInt(itemstart) || parseInt(cuurentitemtop) > parseInt(itemend)) {
                    objcurrenttag.setAttribute("isitem", '');
                    alert('<%=objLanguage.GetLanguageConversion("This_Tag_Is_Available_Only_Between_The_Item_Area_Please_RePosition")%>');
                }
            }
    }

    ///////////// TO DELETE SELECTED OBJECTS//////
    var Del_Array = new Array();
    var Count_Del = 0;
    var hid_IsImgDel = document.getElementById("<%=hid_IsImgDel.ClientID %>");
    function deleteselected() {
        var DelIDs = "";
        for (var i = 0; i < divsarray.length; i++) {
            if (selObj != null) {
                if (selObj == "'div'_" + i) {
                    for (var j = 0; j < imgsarray.length; j++) {
                        if (i == j) {
                            var div_inter_img = imgsarray.splice(i, 1);
                            hid_IsImgDel.value = "yes";
                        }
                    }
                    var div_inter = divsarray.splice(i, 1);
                }
            }
        }
        for (var i = selObjs.length - 1; i >= 0; i--) {
            if (document.getElementById(selObjs[i]).getAttribute("objtype") == 8 || document.getElementById(selObjs[i]).getAttribute("objtype") == 9) {
                alert("Horizontal rule cannot be deleted");
            }
            else {
                if (selObjs[i] != null) {
                    var var_remove = document.getElementById(selObjs[i]).id.replace("'div'", "");
                    if (document.getElementById(selObjs[i]).getAttribute("objtype") == 1 || document.getElementById(selObjs[i]).getAttribute("objtype") == 2)
                        document.getElementById("txtbx" + var_remove).disabled = true;

                    document.getElementById(contPlNm + "CardDiv").removeChild(document.getElementById(selObjs[i]));

                    DelIDs = DelIDs + var_remove + "µ";
                    document.getElementById("div_CtrlList").style.display = "none";
                    document.getElementById("div_EditFields").style.display = "none";
                }
            }
        }
        if (DelIDs != "") {
            Del_Array[Del_Array.length] = DelIDs;
            Count_Del = Del_Array.length - 1;
        }
        OnChangeInsertIntoArray(); //Undo func by Swetha M.S  
    }
    ////////////// TO DELETE SELECTED OBJECTS
    //============================================================================



    </script>
    <script>
        ////== This Func is called while editing the image in Image Upload page ==//
        function BindImg(imgName, imgWidth, imgHeight, mode, imgorgpath) {
            var CompanyID = '<%=CompanyID %>';
            var ServerName = '<%=ServerName %>';
            var SecureVirtualPath = '<%=SecureVirtualPath %>';
            if (SecureVirtualPath.indexOf('~/') != 1) {
                var Securepath = SecureVirtualPath.replace('~/', "");
            }
            else {
                var securepath = SecureVirtualPath;
            }
            //var LogoPath = '<%=strSitepath %>' + Securepath + ServerName + '/' + CompanyID + '/' + imgName + '';
            var LogoPath = "http://" + location.host + imgorgpath;

            var img = new Image();
            img.onload = function () {
                // code to set the src on success
                return true;
            };
            img.onerror = function () {
                // doesn't exist or error loading
                alert("Please insert the image again");
                return false;
            };
            img.src = LogoPath; // fires off loading of image

            if (mode == "add") {
                CreateCtrl(3, '', '', LogoPath, LogoPath, '', '', '', '', '', '', '230', '150', imgWidth, imgHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
            }
            else if (mode == "edit") {
                for (var i = selObjs.length - 1; i >= 0; i--) {
                    if (selObjs[i] != "") {
                        var divobj = document.getElementById(selObjs[i]);
                        divobj.setAttribute("objname", LogoPath);
                        divobj.style.width = imgWidth + "px";
                        divobj.style.height = imgHeight + "px";

                        var imgobj = divobj.getElementsByTagName("img");
                        imgobj[0].setAttribute("src", LogoPath);
                        imgobj[0].setAttribute("width", imgWidth);
                        imgobj[0].setAttribute("height", imgHeight);
                    }
                }
            }
            OnChangeInsertIntoArray(); //Undo func by Swetha M.S   
        }
    </script>
    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        <script type="text/javascript">
            function LoadOnEdit() {
                if ('<%=action %>' == "edit") {
                    var ddlTemplatePDF = document.getElementById("<%=ddlTemplatePDF.ClientID %>");
                    var hid_PDFImageName = document.getElementById("<%=hid_PDFImageName.ClientID %>");
                    if ('<%=CheckTagsExists %>' == "yes") {
                        <%=strCreateControl %>
                    }
                    else {
                        var hidEditorValues_Edit = document.getElementById("<%=hidEditorValues_Edit.ClientID %>");
                        document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML = hidEditorValues_Edit.value;

                        var hid_ctrlListHTML = document.getElementById("<%=hid_ctrlListHTML.ClientID %>");
                        document.getElementById("div_CtrlList").innerHTML = hid_ctrlListHTML.value;
                        document.getElementById("div_CtrlList").style.display = "none";

                        //Attach events to the textbox cntrlList//
                        var inputs = document.getElementById("div_CtrlList");
                        var ctrltxtbx = inputs.getElementsByTagName("input"); //input
                        var ctrltxtbxarea = inputs.getElementsByTagName("textarea");


                        var ArrTotDivCount = new Array();
                        var totaldivs = document.getElementById("ctl00_ContentPlaceHolder1_CardDiv");

                        var totaldivscount = totaldivs.getElementsByTagName("div");
                        var divcounter = 1;
                        for (var b = 0; b < totaldivscount.length; b++) {
                            if (totaldivscount[b].getAttribute("objtype") != null) {
                                ArrTotDivCount[b] = parseInt(totaldivscount[b].id.replace("'div'_", ""));
                                divcounter++;
                            }
                        }

                        ArrTotDivCount.sort(function (a, b) { return b - a });

                        idnm = ArrTotDivCount[0];
                        idnm = idnm + 1;



                        for (var i = 0; i < idnm; i++) {
                            var txtbx = document.getElementById("txtbx_" + i);
                            if (txtbx != null) {
                                if (txtbx.nodeName == "TEXTAREA") {
                                }

                                var ReqNumericValue = 0;
                                if (txtbx.attachEvent) //IE
                                {
                                    if (ReqNumericValue == "1")
                                        txtbx.attachEvent("onkeydown", CheckKeyCodeInteger);
                                    txtbx.attachEvent("onkeyup", chgTxt);
                                    txtbx.attachEvent("onblur", savecntrlList);
                                }
                                else if (txtbx.addEventListener) {
                                    if (ReqNumericValue == "1")
                                        txtbx.addEventListener("onkeydown", CheckKeyCodeInteger, true);
                                    txtbx.addEventListener("keyup", chgTxt, true);
                                    txtbx.addEventListener("blur", savecntrlList, true);
                                }
                                else {
                                    if (ReqNumericValue == "1")
                                        txtbx["onkeyup"] = chgTxt;
                                    txtbx["onkeydown"] = CheckKeyCodeInteger;
                                    txtbx["onblur"] = savecntrlList;
                                }
                            }
                        }
                    }
                }
            }
            LoadOnEdit();
        </script>
    </asp:Panel>
    <script language="javascript" type="text/javascript">
        //=== UNDO ,REDO and SAVE control List ===//
        var globalArray = new Array();
        var ctrlListArray = new Array();
        globalArray[0] = document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML;
        ctrlListArray[0] = document.getElementById('div_CtrlList').innerHTML;
        var j = 0;
        var ctrlListCnt = 0;

        function Undo() {
            if (j > 0) {
                j = j - 1;
            }
            document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML = globalArray[j];

            if (ctrlListCnt > 0) {
                ctrlListCnt = ctrlListCnt - 1;
            }
            document.getElementById('div_CtrlList').innerHTML = ctrlListArray[ctrlListCnt];
            document.getElementById('div_CtrlList').style.display = "none";
            document.getElementById('div_EditFields').style.display = "none";
            return false;
        }
        function Redo() {
            if (j < globalArray.length - 1) {
                j = j + 1;
            }
            document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML = globalArray[j];

            if (ctrlListCnt < ctrlListArray.length - 1) {
                ctrlListCnt = ctrlListCnt + 1;
            }
            document.getElementById('div_CtrlList').innerHTML = ctrlListArray[ctrlListCnt];
            document.getElementById('div_CtrlList').style.display = "none";
            document.getElementById('div_EditFields').style.display = "none";

            return false;
        }
        function OnChangeInsertIntoArray() {
            //unSelAll();
            globalArray[globalArray.length] = document.getElementById('ctl00_ContentPlaceHolder1_Div1').innerHTML;
            j = globalArray.length - 1;

            //To save Control List
            ctrlListArray[ctrlListArray.length] = document.getElementById('div_CtrlList').innerHTML;
            ctrlListCnt = ctrlListArray.length - 1;
        }

        function checkarray() {
            for (i = 0; i < globalArray.length; i++) {
            }
            return false;
        }

        //=== UNDO ,REDO and SAVE control List ===//
    </script>
    <asp:Panel ID="pnlInsertPDFOnEdit" runat="server" Visible="false">
        <script>
            var ImageWidthOnEdit = '<%=ImageWidthOnEdit %>';
            var ImageHeightOnEdit = '<%=ImageHeightOnEdit %>';

            document.getElementById("div_MainEditor").style.width = Number(ImageWidthOnEdit) + 27 + "px";
            document.getElementById("td_MainEditor").style.height = Number(ImageHeightOnEdit) + 3 + "px";

            document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.width = Number(ImageWidthOnEdit) + 22 + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.height = ImageHeightOnEdit + "px";

            document.getElementById("tbl_Editor").style.width = Number(ImageWidthOnEdit) + 22 + "px";
            document.getElementById("tbl_Editor").style.height = Number(ImageHeightOnEdit) + 5 + "px";

            document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.width = Number(ImageWidthOnEdit) + 22 + "px";
            document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.height = Number(ImageHeightOnEdit) + 3 + "px";
        </script>
    </asp:Panel>
    <script>
        //== To Insert PDF TEmplate as Image ==//
        function InsertPDF(ddlVal) {


            InsertPDF_AsImage(ddlVal);

            scrollTo(0, 0);
        }

        function InsertPDF_AsImage(ddlVal) {
            //alert(ddlVal);          
            var str = '<%=strTemplatePDfValues %>';
            if (str != "") {
                var str1 = str.split('µ');
                for (var i = 0; i < str1.length - 1; i++) {
                    var str2 = str1[i].split('»');
                    var PDFID = str2[0];
                    var PDFImageKey = str2[1]
                    var PDFImageWidth = str2[2] == "0" ? '<%=EditorWidth %>' : str2[2];
                    var PDFImageHeight = str2[3] == "0" ? '<%=EditorHeight %>' : str2[3];

                    if (ddlVal == 0) {
                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").removeChild(document.getElementById("div_bgImage"));

                        document.getElementById("div_MainEditor").style.width = "930px";
                        document.getElementById("td_MainEditor").style.height = "933px";

                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.width = '<%=EditorWidth %>';
                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.height = '<%=EditorHeight %>';

                        document.getElementById("tbl_Editor").style.width = '<%=EditorWidth %>';
                        document.getElementById("tbl_Editor").style.height = "1290px";

                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.width = '<%=EditorWidth %>';
                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.height = '<%=EditorHeight %>';
                    }
                    else if (ddlVal == PDFID) {
                        if (document.getElementById("div_bgImage") != null) {
                            document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").removeChild(document.getElementById("div_bgImage"));
                        }

                        document.getElementById("div_MainEditor").style.width = Number(PDFImageWidth) + 27 + "px";
                        document.getElementById("td_MainEditor").style.height = Number(PDFImageHeight) + 3 + "px";

                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.width = PDFImageWidth + "px";
                        document.getElementById("ctl00_ContentPlaceHolder1_CardDiv").style.height = PDFImageHeight + "px";

                        document.getElementById("tbl_Editor").style.width = Number(PDFImageWidth) + 22 + "px";
                        document.getElementById("tbl_Editor").style.height = Number(PDFImageHeight) + 5 + "px";

                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.width = Number(PDFImageWidth) + 22 + "px";
                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.height = Number(PDFImageHeight) + 3 + "px";

                        CreateCtrl(13, '', '', PDFImageKey, PDFImageKey, '', '', '', '', '', '', '0', '0', Number(PDFImageWidth) + 22, PDFImageHeight, '', '', '', '', '0', '0', '1', '0', '0', '0', '0', '0', '0');
                    }
                }
            }
        }
        function RadWinClose() {

            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }

    </script>
    <script type="text/javascript">
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";




        function getCheckBoxListItemsChecked(elementId) {
            var elementRef = document.getElementById(elementId);
            var checkBoxArray = elementRef.getElementsByTagName('input');
            var checkedValues = '';

            for (var i = 0; i < checkBoxArray.length; i++) {
                var checkBoxRef = checkBoxArray[i];

                if (checkBoxRef.checked == true) {
                    var labelArray = checkBoxRef.parentNode.getElementsByTagName('label');

                    if (labelArray.length > 0) {
                        if (checkedValues.length > 0)
                            checkedValues += ', ';

                        checkedValues += labelArray[0].innerHTML;
                    }
                }
            }

            return checkedValues;
        }
        function readCheckBoxList() {
            var checkedItems = getCheckBoxListItemsChecked('<%= chklstCopy.ClientID %>');
            if (checkedItems != "") {
                return true;
            }
            else {
                alert("Please select an template to copy");
                return false;
            }
        }


    </script>

    <%--<script>
        var $currentlySelected = null;
        var selected = [];
        $('.grid').selectable({
            start: function (event, ui) {
                $currentlySelected = $('.grid .ui-selectee');
            },
            stop: function (event, ui) {
                for (var i = 0; i < selected.length; i++) {
                    if ($.inArray(selected[i], $currentlySelected) >= 0) {
                        $(selected[i]).removeClass('putpointer');
                    }
                }
                selected = [];
            },
            selecting: function (event, ui) {
                $currentlySelected.addClass('putpointer'); // re-apply ui-selected class to currently selected items
            },
            selected: function (event, ui) {
                selected.push(selected);
            }
        });



        $(".grid").mousedown(function (e) {
            if (e.which == 1) {
                if ((selObj == null || selObj == "") && (selObjs == null || selObjs.length == 0)) {
                    $("#big-ghost").remove();
                    $(".ghost-select111").addClass("ghost-active");
                    $(".ghost-select111").css({
                        'left': e.offsetX,
                        'top': e.offsetY
                    });

                    initialW = e.offsetX;
                    initialH = e.offsetY;

                    $(".grid").bind("mouseup", selectElements);
                    $(".grid").bind("mousemove", openSelector);
                }
            }
        });

        function openSelector(e) {
            var w = Math.abs(initialW - e.offsetX);
            var h = Math.abs(initialH - e.offsetY);

            $(".ghost-select111").css({
                'width': w,
                'height': h,
            });

            //$(".ghost-select111").css({
            //    'left': e.offsetX,
            //    "top": e.offsetY
            //});
            //debugger;
            if (e.offsetX <= initialW && e.offsetY >= initialH) {
                $(".ghost-select111").css({
                    'left': e.offsetX 
                });
            } else if (e.offsetY <= initialH && e.offsetX >= initialW) {
                $(".ghost-select111").css({
                    'top': e.clientY
                });
            } else if (e.offsetY < initialH && e.offsetX < initialW) {
                $(".ghost-select111").css({
                    'left': e.offsetX, 
                    "top": e.offsetY 
                });
            }
        }

        function doObjectsCollide(a, b) { // a and b are your objects
            //console.log(a.offset().top,a.position().top, b.position().top, a.width(),a.height(), b.width(),b.height());
            var aTop = a.offset().top;
            var aLeft = a.offset().left;
            var bTop = b.offset().top;
            var bLeft = b.offset().left;

            return !(
                ((aTop + a.height()) < (bTop)) ||
                (aTop > (bTop + b.height())) ||
                ((aLeft + a.width()) < bLeft) ||
                (aLeft > (bLeft + b.width()))
            );
        }


        function selectElements(e) {
            $("#score>span").text('0');
            $(".grid").unbind("mousemove", openSelector);
            $(".grid").unbind("mouseup", selectElements);
            var maxX = 0;
            var minX = 5000;
            var maxY = 0;
            var minY = 5000;
            var totalElements = 0;
            var elementArr = new Array();
            var Count = 0;
            $(".ui-selectee").each(function () {
                var aElem = $(".ghost-select111");
                var bElem = $(this);
                var result = doObjectsCollide(aElem, bElem);

                //console.log(result);
                if (result == true) {
                    Count++;
                }
            });
            console.log(Count);
            $(".ghost-select111").removeClass("ghost-active");
            $(".ghost-select111").width(0).height(0);
        }

        function checkMaxMinPos(a, b, aW, aH, bW, bH, maxX, minX, maxY, minY) {
            'use strict';

            if (a.left < b.left) {
                if (a.left < minX) {
                    minX = a.left;
                }
            } else {
                if (b.left < minX) {
                    minX = b.left;
                }
            }

            if (a.left + aW > b.left + bW) {
                if (a.left > maxX) {
                    maxX = a.left + aW;
                }
            } else {
                if (b.left + bW > maxX) {
                    maxX = b.left + bW;
                }
            }
            ////////////////////////////////
            if (a.top < b.top) {
                if (a.top < minY) {
                    minY = a.top;
                }
            } else {
                if (b.top < minY) {
                    minY = b.top;
                }
            }

            if (a.top + aH > b.top + bH) {
                if (a.top > maxY) {
                    maxY = a.top + aH;
                }
            } else {
                if (b.top + bH > maxY) {
                    maxY = b.top + bH;
                }
            }

            return {
                'maxX': maxX,
                'minX': minX,
                'maxY': maxY,
                'minY': minY
            };
        }

    </script>
    <style>
        .ghost-active {
            display: block !important;
        }

        .ghost-select111 > span {
            background-color: #FAFAFA;
            border: 1px solid #5D5D5D;
            width: 100%;
            height: 100%;
            float: left;
        }

        .grid {
            width: 100%;
            height: 100%;
            position: absolute;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            -o-user-select: none;
            user-select: none;
        }

        .ghost-select111 {
            display: none;
            z-index: 9000;
            position: absolute !important;
            cursor: default !important;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

