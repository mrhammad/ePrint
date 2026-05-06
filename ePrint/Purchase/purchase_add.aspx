<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true"  CodeBehind="purchase_add.aspx.cs" Inherits="ePrint.Purchase.purchase_add" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Task" Src="~/usercontrol/Item/estimate_task_add.ascx" %>
<%@ Register TagName="Notes" TagPrefix="UC" Src="~/usercontrol/Item/notes.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>common/calendar.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath %>js/item/purchaseadd.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../js/item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <asp:HiddenField ID="hdnDrawStockFrom" runat="server" Value="" />
    <asp:HiddenField ID="hdnAdditionalID" runat="server" Value="" />
    <asp:HiddenField ID="hdnOnlyItemTitle" runat="server" Value="" />
    <asp:HiddenField ID="hdn_StockDetails" runat="server" Value="" />
    <asp:HiddenField ID="hdn_IDs" runat="server" Value="" />
    <asp:HiddenField ID="hdn_PurchaseItemIDs" runat="server" Value="" />
    <asp:HiddenField ID="hdnSave_Self" runat="server" Value="" />
    <asp:HiddenField ID="hdnSave_Additional" runat="server" Value="" />
    <asp:HiddenField ID="hid_ItemValues" runat="server" Value="" />
    <asp:HiddenField ID="hid_TaxValues" runat="server" Value="" />
    <asp:HiddenField ID="hid_DeletedItemID" runat="server" Value="" />
    <asp:HiddenField ID="hid_DefaultTax" runat="server" Value="" />
    <asp:HiddenField ID="hid_ACcode" runat="server" Value="" />
    <asp:HiddenField ID="hdn_Previous_PurchaseID" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_JobId" runat="server" Value="" />

    <UC:Notes ID="UCNotes" runat="server" />
    
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_Load_Purchase" class="loading_new"  style="display: none;">
        <UC:Loading ID="ucLoading_Purchase" runat="server" />
    </div>

    <asp:ScriptManagerProxy ID="smpPurchaseStatus" runat="server">
        <Services>
            <asp:ServiceReference Path="~/item_summary.asmx" />
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div id="Div_SuccMsg" style="display: none;">
        <asp:UpdatePanel ID="UPMessage" runat="server">
            <ContentTemplate>
                <table align="center" width="99%" border="0px">
                    <tr>
                        <td align="center">
                            <div align="center" style="float: left; margin-left: 40%;">
                                <asp:Label ID="lblUpdateMsg" runat="server" CssClass="msg-success" Text="Status updated successfully"
                                    Style="text-align: left;"></asp:Label>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="padding" class="div_spacing2">
        <div align="left" style="width: 100%;">
            <span style="float: right; color: red">*
                <%=objLangClass.GetLanguageConversion("Fields_Are_Mandatory")%></span>
        </div>
        <div class="onlyEmpty">
        </div>
        <div align="left" style="width: 100%;">
            <div id="leftcol" style="width: 49%">
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="Label28" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div id="DivAddSupplier" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: middle" ID="ImgSupplierAdd" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip=""></asp:ImageButton>
                        </div>
                    </div>
                    <div class="ddlsetting">
                        <div style="float: left; white-space: nowrap;">
                            <asp:TextBox ID="txtSupplier" SkinID="textPad" runat="server" AutoCompleteType="disabled"
                                Width="240px"></asp:TextBox><%--onkeyup="BindSupplierName(this.value,event,this);" onblur="CallonBlur(this.value,'spn_txtSupplier');"--%>
                            <asp:HiddenField ID="hid_Suppname" runat="server" Value="" />
                            <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                            <asp:HiddenField ID="hid_PurchaseID" runat="server" Value="0" />
                            <asp:HiddenField ID="hid_AddressType" runat="server" Value="" />
                            <div class="onlyEmpty">
                            </div>
                            <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                            </div>
                        </div>
                        <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none;">
                            <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindSupplierName('',event,this);"
                                style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="spn_txtSupplier" style="display: none; width: auto; float: left;">
                            <div class="RFV_Message">
                                <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Supplier_Name")%>
                                </span>
                            </div>
                        </div>
                    </div>
                    <style>
                        #divCheck {
                            float: left;
                            position: absolute;
                            display: none;
                            border: solid 1px silver;
                            overflow-x: hidden;
                            overflow-y: scroll;
                            width: 270px;
                            height: 100px;
                            background-color: white;
                        }

                        .divpad {
                            padding: 2px;
                        }
                    </style>
                    <script>
                        function showddl(divid) {
                            document.getElementById(divid).style.display = "block";
                            document.getElementById("<%=ddlcontact.ClientID %>").style.display = "none";
                            document.getElementById("spn_txtSupplier").style.display = "none";
                            document.getElementById("spn_ddlcontact").style.display = "none";
                            document.getElementById("spn_lblAddress").style.display = "none";
                        }
                        function ShowOff(divid) {

                            document.getElementById(divid).style.display = "none";
                            document.getElementById("<%=ddlcontact.ClientID %>").style.display = "block";
                        }


                        var pg = "purchase";
                        function PopUpWarehouse() {
                            var txtName = document.getElementById("<%=txtSupplier.ClientID %>").value;
                            if (txtName == "") {
                                alert("Please select the supplier to proceed...");
                                return false;
                            }
                            else {
                                var itemtype = "";
                                // if (item == "inv") {
                                itemtype = "Inventory";
                                //  }
                                //                                    else if (item == "sto") {
                                //                                        itemtype = "Store Supply";
                                //                                    }
                                //                                    else if (item == "cus") {
                                //                                        itemtype = "Customer Item";
                                //                                    }
                                var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
                                //window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=purwarehouse&clientid="+hid_ClientID.value+"&item=" +itemtype+ "&pg=" + pg, '', 'width=700px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');   
                                //  PopupCenter("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=purwarehouse&clientid=" + hid_ClientID.value + "&item=" + itemtype + "&pg=" + pg, '900', '400');
                                var Invntry_popup = window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=purwarehouse&clientid=" + hid_ClientID.value + "&item=" + itemtype + "&pg=" + pg);
                                Invntry_popup.setSize(1100, 535);
                                SetRadWindow_Ver2('Div_Invntry', 'divBackGroundNew');
                                Invntry_popup.center();
                                return true;
                            }
                        }


                        function PopUpProductList() {
                            var txtName = document.getElementById("<%=txtSupplier.ClientID %>").value;
                            //                                if (txtName == "") {
                            //                                    alert("Please select the supplier to proceed...");
                            //                                    return false;
                            //                                }
                            //                                else {
                            var itemtype = "";
                            itemtype = "warehouse";
                            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
                            var Invntry_popup = window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=productlist&item=" + itemtype + "&pg=" + pg);
                            Invntry_popup.setSize(1100, 535);
                            SetRadWindow_Ver2('Div_Invntry', 'divBackGroundNew');
                            Invntry_popup.center();
                            return true;
                            //                                }
                        }
                        var commonpath = "<%=nmsCommon.global.sitePath()%>";
                        var txtName = document.getElementById("<%=txtSupplier.ClientID %>");
                        var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
                        var hid_Suppname = document.getElementById("<%=hid_Suppname.ClientID %>");

                        // By Natraj, Popup Size Changed..
                        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
                            var div_Accountcode = document.getElementById(divMaskID);
                            var divBackGroundNew = document.getElementById(divBackgroundID);
                            if (document.getElementById(divMaskID).style.display == "none") {

                                if (navigator.appName != "Microsoft Internet Explorer") {
                                    setLoadingPositionOfDivCenter_Ver2(Div_Invntry);
                                }
                                showDivPopupCenter_Ver2(divMaskID);
                            }
                            else {
                                showDivPopupCenter_Ver2(divMaskID);
                                // document.getElementById(divMaskID).style.display = "none";
                                //divBackGroundNew.style.display = "none";
                            }
                        }

                    </script>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="Label35" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div id="DivContact" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="imgbtnContact" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="" OnClientClick="javascript:add_contact();return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" id="div_ddlcontact">
                        <asp:DropDownList ID="ddlcontact" CssClass="normaltext" Width="240px" runat="server"
                            onchange="javascript:GetContactID(this.value);CallonChange(this.value,'spn_ddlcontact');return false;">
                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hid_ContactID" runat="server" Value="0" />
                        <div style="clear: both">
                        </div>
                        <div id="spn_ddlcontact" style="display: none; width: auto; float: left">
                            <div class="RFV_Message">
                                <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                    <%=objLangClass.GetLanguageConversion("Please_Select_Contact")%>
                                </span>
                            </div>
                        </div>
                        <script>
                            function ReloadContact(FinalContact, retContactID) {
                                var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
                                var ContactName = '';
                                var ContactID = '';
                                ddlcontact.length = 0;
                                var str_con1 = FinalContact.split('µ');
                                ddlcontact.options.add(new Option('--- Select ---', 0, 0)); // Ticket - 12831
                                for (var k = 0; k < str_con1.length; k++) {
                                    if (str_con1[k] != '') {
                                        var ContactIDName = str_con1[k].split('±');
                                        ContactID = ContactIDName[0];
                                        ContactName = SpecialDecode(ContactIDName[1]);
                                        ddlcontact.options.add(new Option(ContactName, ContactID, k));

                                        if (retContactID == ContactID) {
                                            ddlcontact.selectedIndex = k + 1;
                                        }
                                    }
                                }

                                GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected
                            }
                        </script>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="Label36" runat="server" Text="" CssClass="normaltext"></asp:Label>
                            <span style="color: Red;">*</span>
                        </div>
                        <div id="DivContactAddress" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="ingbtnAddress" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="" OnClientClick="javascript:more_address();return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" id="div_address">
                        <%--<div style="float: left; padding: 5 0 0 0px; width: 265px" nowrap="nowrap">--%>
                        <div class="box" style="float: left; width: 240px; overflow: hidden; white-space: nowrap;">
                            <asp:Label ID="lblAddress" runat="server" CssClass="graytext" Style="cursor: pointer; padding-top: 2px;"></asp:Label><%--Blackthorne Road, Sydney--%>
                            <asp:HiddenField ID="hdnAddressID" runat="server" Value="0" />
                        </div>
                        <%--<div nowrap="nowrap">--%>
                        <div style="clear: both">
                        </div>
                        <div id="spn_lblAddress" style="display: none; width: auto; float: left">
                            <div class="RFV_Message">
                                <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                    <%=objLangClass.GetLanguageConversion("Please_Select_Address")%></span>
                            </div>
                        </div>
                    </div>
                    <%--</div>--%>
                    <%--</div>--%>
                    <script>
                        function SendAddressIDandName(id, values, isdelivery, tooltip, addresstype) {

                            for (var i = 0; i < values.length; i++) {
                                values = values.replace('<br/>', '');
                                i++;
                            }

                            var hid_AddressType = document.getElementById("<%=hid_AddressType.ClientID %>");
                            var lblAddress = "<%=lblAddress.ClientID %>";

                            hid_AddressType.value = addresstype; //"C"-- Contact Address, "A"-- Main Address
                            var trimvalues = trim12(values);
                            document.getElementById(lblAddress).title = tooltip;
                            document.getElementById(lblAddress).innerHTML = trimvalues;
                            document.getElementById(lblAddress).style.cursor = "pointer";

                            document.getElementById("<%=hdnAddressID.ClientID %>").value = id;
                            document.getElementById("spn_lblAddress").style.display = "none";
                        }
                    </script>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="lbl_deliveryAddress" runat="server" Text="" ToolTip="" CssClass="normaltext"></asp:Label>
                        </div>
                        <div id="DivDeliveryTo" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="img_deliveryAddress" runat="server"
                                Visible="false" CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address"
                                OnClientClick="javascript:more_address();return false;"></asp:ImageButton>
                            <asp:ImageButton Style="vertical-align: top" ID="ImageButton2" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:Show_DeliveryAddressDiv();return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" id="div2">
                        <div class="box" style="float: left; width: 240px; overflow: hidden; white-space: nowrap; margin: -5px 0px 0px 0px;">
                            <asp:Label ID="lbl_CompanyName" runat="server" CssClass="graytext" Style="display: none; cursor: pointer; height: 18px; padding-top: 2px;"></asp:Label>
                            <asp:Label ID="lbl_deliveryAddress_Value" runat="server" ToolTip="" CssClass="graytext"
                                Style="padding-top: 2px; cursor: pointer;"></asp:Label>
                            <asp:HiddenField ID="hdn_deliveryAddress" runat="server" Value="0" />
                            <asp:HiddenField ID="hdn_CompanyName" runat="server" Value="0" />
                            <asp:HiddenField ID="hdn_deliveryAddressID" runat="server" />
                            <asp:HiddenField ID="hdn_deliveryAddressType" runat="server" />
                            <asp:HiddenField ID="hdn_CompanyID" Value="0" runat="server" />
                        </div>
                        <%--<div nowrap="nowrap">--%>
                        <div style="clear: both">
                        </div>
                    </div>
                    <script>
                        function SendAddressIDandName(id, values, isdelivery, tooltip, addresstype) {

                            for (var i = 0; i < values.length; i++) {
                                values = values.replace('<br/>', '');
                                i++;
                            }

                            var hid_AddressType = document.getElementById("<%=hid_AddressType.ClientID %>");
                            var lblAddress = "<%=lblAddress.ClientID %>";

                            hid_AddressType.value = addresstype; //"C"-- Contact Address, "A"-- Main Address
                            var trimvalues = trim12(values);
                            document.getElementById(lblAddress).title = tooltip;
                            document.getElementById(lblAddress).innerHTML = trimvalues;
                            document.getElementById(lblAddress).style.cursor = "pointer";
                            document.getElementById("<%=hdnAddressID.ClientID %>").value = id;
                            document.getElementById("spn_lblAddress").style.display = "none";
                        }
                    </script>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lblD_InstructionsTitle" runat="server" Text="" CssClass="normaltext"
                            Height="80px" Width="90px"></asp:Label>
                        <div id="DivCommentDeliveryInstructions" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="imgbtnDelivery_Instructions" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="" OnClientClick="javascript:popup_phrasebook('Delivery Instructions');return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtComments" runat="server" Width="240px" SkinID="textPad" TextMode="MultiLine"
                            Height="80px" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"></asp:TextBox>
                        <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 175px; white-space: nowrap">
                            <%=objLangClass.GetLanguageConversion("Max_Length_Of_Textbox_Is_3000")%></span>
                        <asp:HiddenField ID="hdn_Commenttxt" runat="server" Value="" />
                        <asp:HiddenField ID="hdn_CommenttID" runat="server" Value="0" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="lblHeaderTitle" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        </div>
                        <div id="DivHeader" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="imgbtnheader" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="" OnClientClick="javascript:popup_phrasebook('Purchase Header');return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" style="float: left; padding: 5 0 0 5px; overflow: hidden; white-space: nowrap; width: 225px">
                        <asp:Label ID="lblheader" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--©All rights-2009--%>
                        <asp:HiddenField ID="hid_HeaderText" runat="server" Value="" />
                        <asp:HiddenField ID="hid_HeaderID" runat="server" Value="0" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="Label38" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        </div>
                        <div id="DivFooter" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="ImageButton6" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="" OnClientClick="javascript:popup_phrasebook('Purchase Footer');return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" style="float: left; padding: 5 0 0 5px; overflow: hidden; white-space: nowrap; width: 225px">
                        <asp:Label ID="lblFooter" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--©All rights-2009--%>
                        <asp:HiddenField ID="hid_FootNote" runat="server" Value="" />
                        <asp:HiddenField ID="hid_FooterID" runat="server" Value="0" />
                    </div>
                    <div align="left" runat="server" id="div_AccountCode">
                        <div class="bglabel">
                            <asp:Label ID="lblAccountCode" runat="server" Text="" CssClass="normalText"></asp:Label>
                        </div>
                        <div class="ddlsetting" style="padding-left: 5px">
                            <asp:DropDownList ID="ddlAccountCode" runat="server" CssClass="normaltext" Width="240px">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <script type="text/javascript">
                        function SendPhraseIDandName(id, values, phrasetype, tooltip) {
                            if (phrasetype == 'Purchase Footer') {
                                var lblFooter = "<%=lblFooter.ClientID %>";
                                var hid_FooterID = document.getElementById("<%=hid_FooterID.ClientID %>");
                                var hid_FootNote = document.getElementById("<%=hid_FootNote.ClientID %>");
                                var lblPhraseText = '';
                                if (phrasetype == 'Purchase Footer') {
                                    lblPhraseText = lblFooter;
                                    hid_FooterID.value = id;
                                }
                                var trimvalues = trim12(values);
                                document.getElementById(lblPhraseText).title = tooltip;
                                document.getElementById(lblPhraseText).innerHTML = trimvalues;
                                hid_FootNote.value = trimvalues;
                                document.getElementById(lblPhraseText).style.cursor = "pointer";
                            }
                            else if (phrasetype == 'Purchase Header') {
                                //Purchase Header
                                var lblheader = "<%=lblheader.ClientID %>";
                                var hid_HeaderID = document.getElementById("<%=hid_HeaderID.ClientID %>");
                                var hid_HeaderText = document.getElementById("<%=hid_HeaderText.ClientID %>");
                                var lblPhraseHeaderText = '';
                                if (phrasetype == 'Purchase Header') {
                                    lblPhraseHeaderText = lblheader;
                                    hid_HeaderID.value = id;
                                }

                                var trimvalues = trim12(values);
                                document.getElementById(lblPhraseHeaderText).title = tooltip;
                                document.getElementById(lblPhraseHeaderText).innerHTML = trimvalues;
                                hid_HeaderText.value = trimvalues;
                                document.getElementById(lblPhraseHeaderText).style.cursor = "pointer";


                            }

                            else if (phrasetype == 'Delivery Instructions') {
                                var txtComments = "<%=txtComments.ClientID %>";
                                var hdn_CommenttID = document.getElementById("<%=hdn_CommenttID.ClientID %>");
                                var hdn_Commenttxt = document.getElementById("<%=hdn_Commenttxt.ClientID %>");
                                var txtPhraseCommentText = '';
                                if (phrasetype == 'Delivery Instructions') {
                                    txtPhraseCommentText = txtComments;
                                    hdn_CommenttID.value = id;
                                }

                                var trimvalues = trim12(values);
                                document.getElementById(txtPhraseCommentText).title = tooltip;
                                document.getElementById(txtPhraseCommentText).innerHTML = trimvalues;
                                hdn_Commenttxt.value = trimvalues;
                                document.getElementById(txtPhraseCommentText).style.cursor = "pointer";

                            }
                }

                    </script>
                </div>
            </div>
            <div align="left" style="display: none">
                <div class="bglabel">
                    <asp:Label ID="Label46" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:CheckBox ID="chkGoodsReceived" runat="server" />
                </div>
            </div>
            <div id="rightcol" style="width: 49%">
                <div align="left" id="divPoNo" runat="server" visible="false">
                    <div class="bglabel">
                        <asp:Label ID="Label39" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="box">
                        <asp:Label ID="lblPONo" runat="server" CssClass="normaltext" Text=""></asp:Label>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span>
                            <%=objLangClass.GetLanguageConversion("Status")%></span> <span style="color: Red">*</span>
                    </div>
                    <div class="box" id="div_ddlStatus">
                        <asp:DropDownList ID="ddlStatus" SkinID="onlyDDL" runat="server" Width="175px" onchange="javascript:ShowPopUp(this.value);PurchaseOrdStatusUpdate(this.value);">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <div id="spanddlStatus" style="display: none; width: auto; float: left">
                            <div class="RFV_Message">
                                <span style="padding-left: 4px; padding-right: 4px; width: auto;">
                                    <%=objLangClass.GetLanguageConversion("Please_Select_Status")%></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label44" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="ddlsetting" id="div_ddlRaisedBy">
                        <asp:DropDownList ID="ddlRaisedBy" runat="server" CssClass="normaltext" Width="175px"
                            onchange="javascript:CallonChange(this.value,'spn_ddlRaisedBy');return false;">
                            <asp:ListItem>John Doe</asp:ListItem>
                            <asp:ListItem>Sally Goodsell</asp:ListItem>
                            <asp:ListItem>Reg McQuote</asp:ListItem>
                            <asp:ListItem>Mark Cash</asp:ListItem>
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <div id="spn_ddlRaisedBy" style="display: none; width: auto; float: left">
                            <div class="RFV_Message">
                                <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto">
                                    <%=objLangClass.GetLanguageConversion("Please_Select_RaisedBy")%></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label41" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtDate" runat="server" SkinID="textPad" onblur="CallonBlur(this.value,'spn_txtDate');"
                            Width="175.5px"></asp:TextBox>
                        <div style="clear: both">
                        </div>
                        <div id="spn_txtDate" style="display: none; width: auto; float: left; background-color: #FFEBE8; border: 1px solid #DD3C10; font-size: 11px; color: #333333; font-family: Verdana, Arial, Helvetica; vertical-align: middle; padding: 2px 0px 2px 0px; font-weight: bold; position: relative;">
                            <%--<div class="RFV_Message">--%>
                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto">
                                <%=objLangClass.GetLanguageConversion("Please_Enter_Date")%></span>
                            <%--</div>--%>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <asp:Label ID="lbl_CourierInfo" runat="server" Text="Carrier Information" CssClass="normaltext"></asp:Label>
                            <span style="color: Red;" id="spn_CourierInfo" runat="server">*</span>
                        </div>
                        <div id="DivCarrierInformation" runat="server" style="float: right">
                            <asp:ImageButton Style="vertical-align: top" ID="img_CourierInfo" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add Carrier" OnClientClick="javascript:ImageButtonPlus_Click();return false"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box" style="float: left;" id="div_ddlCourierInfo">
                        <asp:DropDownList ID="ddlCourierInfo" CssClass="normaltext" runat="server" Width="175px"
                            onchange="javascript:onchange_ddlCourierInfo(this.value);">
                            <%--onchange="javascript:CallonChange(this.value,'spn_ddlSupplier');return false;"--%>
                        </asp:DropDownList>
                    </div>
                    <div id="spn_Carrier" style="display: none; width: auto; float: left">
                        <div class="RFV_Message">
                            <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto">
                                <%=objLangClass.GetLanguageConversion("Please_Select_Carrier_Information")%></span>
                        </div>
                    </div>

                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label42" runat="server" Text="" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtRefNo" runat="server" SkinID="textPad" MaxLength="2000"></asp:TextBox>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label148" runat="server" Text="Supp. Quote#" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSuppQuote" runat="server" SkinID="textPad" MaxLength="2000"></asp:TextBox>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label43" runat="server" Text="Supplier Invoice#" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSuppInv" runat="server" SkinID="textPad" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="lblSuppInvDate" runat="server" Text="" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtSuppInvDate" runat="server" SkinID="textPad" Width="175.5px"></asp:TextBox>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label45" runat="server" Text="Delivery Date" CssClass="normaltext"></asp:Label>
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txtReqDate" runat="server" SkinID="textPad" onblur="CallonBlur(this.value,'spn_txtReqDate');"
                            Width="175.5px"></asp:TextBox>
                        <div style="clear: both">
                        </div>
                        <div id="spn_txtReqDate" style="display: none; width: 174px; float: left;">
                            <div class="RFV_Message">
                                <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto">
                                    <%=objLangClass.GetLanguageConversion("Please_Enter_delivery_Date")%></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <asp:Label ID="Label47" runat="server" Text="Invoice Received" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box" style="padding: 2px 0px 2px 2px;">
                        <asp:CheckBox ID="chkInvoiceReceived" runat="server" />
                    </div>
                </div>
                <div align="left">
                    <asp:Panel ID="pnl_followup_task" Visible="false" runat="server">
                        <div align="left">
                            <div class="bglabel">
                                <span>
                                    <%=objLangClass.GetLanguageConversion("Create_FollowUp_Task")%></span>
                            </div>
                            <div class="box" style="padding: 2px 0px 2px 2px;">
                                <asp:CheckBox ID="chk_FollowupTask" runat="server" onclick="OpenTaskPage_New(this.checked)" />
                            </div>
                        </div>
                        <asp:HiddenField ID="hidFollowupTask" runat="server" />
                        <script type="text/javascript">
                            var hidFollowupTask = document.getElementById("<%=hidFollowupTask.ClientID %>");
                            var chk_FollowupTask = document.getElementById("<%=chk_FollowupTask.ClientID %>");
                        </script>
                    </asp:Panel>
                </div>
            </div>
            <div class="only10px">
            </div>
            <div align="left" style="width: 100%; display: block">
                <div style="float: left; width: 90%">
                    <table id="tblHeader" align="left" class="ex" cellspacing="0" border="1" width="100%"
                        cellpadding="4">
                        <col width="2%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="8%" />
                        <col width="8%" />
                        <col width="8%" />
                        <col width="10%" />
                        <col width="9%" />
                        <col width="2%" />
                        <tr class="label" height="23px">
                            <td>
                                <span style="width: 1%">&nbsp;</span>
                            </td>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label25" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label22" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label26" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td id="tdACcode" runat="server" style="width: 13%;">
                                <asp:Label ID="lblaccode" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td style="width: 15%;">
                                <asp:Label ID="Label27" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td id="TDLabel102" runat="server">
                                <asp:Label ID="Label102" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td id="TDLabel1" runat="server">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label101" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" style="width: 100%;">
                        <div style="float: left; width: 40%">
                            &nbsp;
                        </div>
                        <div style="float: left;">
                            <span id="spn_tblHeader" class="spanerrorMsg" style="display: none; padding-left: 4px; padding-right: 4px; width: auto">
                                <%=objLangClass.GetLanguageConversion("Please_Add_Atleast_One_Item_To_Save_PO")%></span>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <table id="tblItem" align="left" class="ex" cellspacing="0" border="0" width="100%"
                        cellpadding="4" style="display: none">
                        <col width="1%" />
                        <col width="10%" />
                        <col width="25%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="20%" />
                        <tr id="trItemRow">
                            <td>
                                <input type="checkbox" name="chk" style="width: 15px" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemCode123" runat="server" SkinID="textPad" Width="100px">ITM-00012</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" SkinID="textPad" TextMode="multiLine" Rows="2"
                                    Width="150px">Laser Guarantee 100gsm SRA2 100</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" SkinID="textPad" Width="100px">12</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox14" runat="server" SkinID="textPad" Width="100px">500</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" SkinID="textPad" Width="100px">0.38</asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTaxa" runat="server" CssClass="normaltext" Width="80px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox20" runat="server" SkinID="textPad" Width="100px">$0.00</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox22" runat="server" SkinID="textPad" TextMode="multiLine"
                                    Rows="2" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <script>
                    var strTax = document.getElementById('<%=hid_TaxValues.ClientID %>');
                    var table = document.getElementById("tblHeader");
                    var hid_DeletedItemID = document.getElementById("<%=hid_DeletedItemID.ClientID %>");
                    var hid_DefaultTax = document.getElementById('<%=hid_DefaultTax.ClientID %>');
                    var hid_ACcode = document.getElementById("<%=hid_ACcode.ClientID %>");
                        
                </script>
                <div style="float: left">
                    <div align="left" style="display: none">
                        &nbsp;<asp:ImageButton Style="vertical-align: top" ID="ImageButton1" runat="server"
                            CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Phrase"
                            OnClientClick="javascript:return false;"></asp:ImageButton>
                    </div>
                    <div align="left">
                        &nbsp;<asp:Button ID="Button1" runat="server" Text="" CssClass="button" />
                    </div>
                    <div align="left" class="only5px">
                    </div>
                    <div align="left">
                        &nbsp;<asp:Button ID="Button2" runat="server" Text="" CssClass="button" OnClientClick="javascript:deleteRow('tblHeader');return false;" />
                    </div>
                    <script>
                        var ItemID = "";
                        var ItemCode = "";
                        var ItemName = "";
                        var Qty = "";
                        var PackedIn = "";
                        var Price = "";
                        var ItemType = "";
                        var rowNo = 1;
                        var JustCheck = 1;
                        var PackedPrice = "";
                        var StockType = "";
                        function BindItemValues(PopItemID, PopItemCode, PopDesc, PopQty, PopPackedIn, PopPrice, PopItemType, PerQty, PerPrice, PackedPrice, StockType, SalesTaxRate)//ItemID,ItemCode,Desc,Qty,PackedIn,Price,Tax,TaxValue,Note
                        {
                            ItemID = PopItemID;
                            ItemCode = SpecialDecode(PopItemCode);
                            ItemName = SpecialDecode(PopDesc);
                            Qty = PopQty;
                            PackedIn = PopPackedIn;
                            Price = PopPrice;
                            ItemType = PopItemType;

                            AddMoreItem(ItemID, ItemCode, ItemName, Qty, PackedIn, Price, ItemType, '', PerQty, PerPrice, PackedPrice, StockType, SalesTaxRate);
                            CalculateTotalTax();
                        }
                    </script>
                </div>
                <div style="clear: both">
                    &nbsp;
                </div>
                <div style="float: left; width: 100%;">
                    <div align="left" style="width: 100%">
                        <div class="header" style="width: 51%; border: 0px solid">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 48%; border: 0px solid;">
                            <div style="float: left; width: 21%; text-align: left;">
                                <asp:Label ID="Label31" runat="server" CssClass="HeaderText normalText" Text=""></asp:Label>
                            </div>

                            <div style="float: left; padding-left: 0px">
                                <span class="HeaderText">&nbsp;&nbsp;<%= objComn.GetCurrencyinRequiredFormate("",true) %>&nbsp;</span>
                                <asp:Label ID="lblTotalExcTax" runat="server" CssClass="HeaderText" Style="text-align: right; direction: rtl;">0.00</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div align="left" style="width: 100%">
                        <div class="header" style="width: 51%; border: 0px solid">
                            &nbsp;
                        </div>
                        <div style="float: left; width: 48%; border: 0px solid;">
                            <div style="float: left; width: 21%; text-align: left">
                                <asp:Label ID="Label33" runat="server" CssClass="HeaderText normalText" Text=""></asp:Label>
                            </div>

                            <div style="float: left; padding-left: 0px">
                                <span class="HeaderText">&nbsp;&nbsp;<%= objComn.GetCurrencyinRequiredFormate("",true) %>&nbsp;</span>
                                <asp:Label ID="lblTotalIncTax" runat="server" CssClass="HeaderText" Style="text-align: right; direction: rtl;">0.00</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div align="left" style="width: 100%">
                <div style="float: left; width: 65%;">
                    &nbsp;
                </div>
                <div style="float: right; width: 34%;">
                    <div style="float: left">
                        <div style="float: left">
                            <div id="div_Delete">
                                <asp:Button ID="btnDelete" runat="server" Text="" CssClass="button" Width="65px"
                                    Visible="false" OnClick="btnDelete_OnClick" OnClientClick="javascript:var a=Delete_Confirmation(); if(a)loadingimg('div_Delete','div_btnDeleteprocess'); return a;" />
                            </div>
                            <div id="div_btnDeleteprocess" class="button" align="center" style="width: 47px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="delvisible" runat="server" style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div id="div_cancel" style="display: block">
                                <asp:Button ID="btnCancel" runat="server" Text="" CssClass="button" Width="65px" OnClick="btnCancel_OnClick"
                                    OnClientClick="loadingimg('div_cancel','div_btnCancelprocess');" /><%--OnClick="btnCancel_OnClick" --%>
                            </div>
                            <div id="div_btnCancelprocess" class="button" align="center" style="width: 47px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div id="div_btnsave" style="display: block">
                                <asp:Button ID="btnSave" runat="server" Text="" CssClass="button" Width="65px" OnClick="btnSave_Onclick"
                                    OnClientClick="javascript:var a=Validate('save');if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a;" />
                                <asp:Button ID="btnSavegoodsrcvd" runat="server" Style="display: none;" OnClick="btnSave_Onclick"
                                    OnClientClick="javascript:var a=Validate2();return a;" />
                            </div>
                            <div id="div_btnsaveprocess" class="button" align="center" style="width: 47px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                        <div id="Div1" runat="server" style="float: left; width: 10px">
                            &nbsp;
                        </div>
                        <div style="float: left">
                            <div id="div_btnsavestay" style="display: block">
                                <asp:Button ID="Button3" runat="server" Text="" CssClass="button" OnClick="btnSaveandStay_Onclick"
                                    OnClientClick="javascript:var a=Validate('stay');if(a)loadingimg('div_btnsavestay','div_btnsavestayprocess');return a;" />
                                <asp:Button ID="btnSaveandStaygoodsrcvd" runat="server" Style="display: none;" OnClick="btnSaveandStay_Onclick"
                                    OnClientClick="javascript:var a=Validate2();return a;" />
                            </div>
                            <div id="div_btnsavestayprocess" class="button" align="center" style="width: 78px; display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>

                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="only5px">
        </div>
    </div>
    <div id="div_Task" style="display: none;">
        <asp:PlaceHolder ID="plhTask" runat="server"></asp:PlaceHolder>
        <UC:Task ID="UCTask" runat="server" />
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="false"
            Width="1000" Height="450" DestroyOnClose="true" Opacity="100" Behaviors="Close, Move,Reload,Resize"
            OnClientClose="RadWinClose">
        </telerik:RadWindowManager>
    </div>
    <div id="Div_Attachment" style="display: none; position: absolute; vertical-align: middle; z-index: 100;"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_Attachment" DestroyOnClose="true"
            Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
            Behaviors="Close" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
    <div id="Div_Invntry" style="display: none;">
        <telerik:RadWindowManager ID="RadMangr_Invntry" runat="server" EnableShadow="false"
            DestroyOnClose="true" Opacity="100" Behaviors="Close, Move,Reload,Resize" OnClientClose="RadWinClose">
        </telerik:RadWindowManager>
    </div>
    <asp:HiddenField ID="hdnTaskID" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_supplierID" runat="server" Value="0" />
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Alert"
        Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="DeliveryStatus" DestroyOnClose="true" Width="350" Height="150"
                runat="server">
                <ContentTemplate>
                    <div class="StatusMain">
                        <div align="center">
                            <asp:Label ID="StatusChangeNote" runat="server"><%=objLangClass.GetLanguageConversion("This_status_change_will_send_Purchase_Order_data_to_Kings_Do_you_want_to_proceed")%></asp:Label>
                        </div>
                        <div class="StatusBtnSpace">
                        </div>
                        <div class="BtnMain" align="center">
                            <div style="float: left">
                                <div id="div_btnyes" style="display: block">
                                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="button" OnClientClick="javascript:YesClick();return false;" />
                                </div>

                            </div>
                            <div>
                            </div>
                            <div style="margin-left: 50px">
                                <div id="div_btnno" style="display: block;">
                                    <asp:Button ID="btnNo" runat="server" Text="No" CssClass="button" OnClientClick="javascript:NoClick();return false;" />
                                </div>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">

        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }

        var isOther = "<%=isOther %>";
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var Pgtype = '<%=pg %>';
        var PurchaseID = "<%=PurchaseID %>";
        var POCODE = "<%=POCODE %>";
        var PurEstimateID = "<%=PurEstimateID %>";
        var ReplenishPurchaseID = "<%=PurchaseID %>";
        var ServerName = "<%=ServerName %>";
        var pgmode = "<%=Type %>";
        var EstimateID = "<%=EstimateID %>";
        var Date_Format = "<%=DateFormat %>";
        var hid_PurchaseID = document.getElementById("<%=hid_PurchaseID.ClientID %>");
        var currentdate = '<%=newdate %>';
        var AccountingCode = '<%=AccountingCode %>';
        var lblTotalExcTax = document.getElementById("<%=lblTotalExcTax.ClientID %>");
        var lblTotalIncTax = document.getElementById("<%=lblTotalIncTax.ClientID %>");
        var hid_ItemValues = document.getElementById("<%=hid_ItemValues.ClientID %>");
        var hdnDrawStockFrom = document.getElementById("<%=hdnDrawStockFrom.ClientID %>");
        var hdnAdditionalID = document.getElementById("<%=hdnAdditionalID.ClientID %>");
        var hdnOnlyItemTitle = document.getElementById("<%=hdnOnlyItemTitle.ClientID %>");
        var hdn_StockDetails = document.getElementById("<%=hdn_StockDetails.ClientID %>");
        var hdn_IDs = document.getElementById("<%=hdn_IDs.ClientID %>");
        var hdn_PurchaseItemIDs = document.getElementById("<%=hdn_PurchaseItemIDs.ClientID %>");
        var hdnSave_Self = document.getElementById("<%=hdnSave_Self.ClientID %>");
        var hdnSave_Additional = document.getElementById("<%=hdnSave_Additional.ClientID %>");
        //left side//
        var txtSupplierID = document.getElementById("<%=txtSupplier.ClientID %>");
        txtSupplierID.focus();
        var ddlContactID = document.getElementById("<%=ddlcontact.ClientID %>");
        var lblAddressID = document.getElementById("<%=lblAddress.ClientID %>");

        //rightside//
        var ddlRaisedByID = document.getElementById("<%=ddlRaisedBy.ClientID %>");
        var txtDateID = document.getElementById("<%=txtDate.ClientID %>");
        var txtReqDateID = document.getElementById("<%=txtReqDate.ClientID %>");
        var txtSuppInvDate = document.getElementById("<%=txtSuppInvDate.ClientID %>");

        var tblHeaderID = document.getElementById("tblHeader");

        var chk_FollowupTask = document.getElementById("<%=chk_FollowupTask.ClientID %>");

        var hdn_supplierID = document.getElementById("<%=hdn_supplierID.ClientID %>");
        var ddlSupplierID = document.getElementById("<%=ddlCourierInfo.ClientID %>");
        var ddlCourierInfo = document.getElementById("<%=ddlCourierInfo.ClientID %>");

        var Please_Add_Atleast_One_Item_To_Save_Purchase = '<%=objLangClass.GetLanguageConversion("DeletePurchaseItem")%>';
        var Delete_Confirmation_Alert = '<%=objLangClass.GetLanguageConversion("Delete_Confirmation_Alert")%>';
        var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>");
        var Goods_Received_Display = '<%=Goods_Received_Display %>';


        function SetFollowupContact(sub, hid) {
            document.getElementById("ctl00_ContentPlaceHolder1_UCTask_txtcontacttype").value = SpecialDecode(sub);
        }

        function ShowNotes() {
            var RadWindow_Paid = window.radopen(strSitepath + "common/Summary_Page_Common_popup.aspx?id=" + <%=PurchaseID %> + "&type=ActivityHistory&pg=Purchase");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            RadWindow_Paid.setSize(1000, 500);
            RadWindow_Paid.center();
        }
        function hideDiv(divid) {

            document.getElementById(divid).style.display = "none";
            //dropdown show//
            selects = document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].style.display = "block";
            }
            if (divid == "div_ActivityHistory_add") {
                document.getElementById("divBackGroundNew").style.display = "block";
            }
            else {
                document.getElementById("divBackGroundNew").style.display = "none";
            }
        }

        this.pointer = 0;
        function BindSupplierName(txtval, e, objectname) {

            var ac = this;
            this.textbox = document.getElementById(objectname.id);
            this.div = document.getElementById('divCheck');
            this.list = this.div.getElementsByTagName('div');
            var innertextbox = document.getElementById(objectname.id);
            if (e != undefined) {
                e = e || window.event;
                switch (e.keyCode) {
                    case 38: //up
                        ac.selectDiv(-1);
                        break;
                    case 40: //down
                        ac.selectDiv(1);
                        break;
                    case 13: //hide div
                        ShowOff("divCheck");
                        break;

                    default:
                        {
                            if (txtval.length > 2) {
                                this.pointer = 0;
                                var CompID = '<%=CompanyID %>';
                                var val = CompID + "±" + txtval;
                                PageMethods.GetSupplierName(val, FindSuccsss, ShowMsg_Failure);
                            }
                            break;
                        }
                }
            }
            this.selectDiv = function (inc) {
                if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
                    this.list[this.pointer].className = 'active1';
                    this.pointer += inc;
                    this.list[this.pointer].className = 'active';
                    this.newList = this.list[this.pointer].getElementsByTagName('a')
                    this.newList[0].focus();
                    this.newList[0].onkeydown = function (e)// 
                    {

                        e = e || window.event;
                        switch (e.keyCode) {
                            case 38: //up
                                {
                                    innertextbox.focus();
                                    break;
                                }
                            case 40: //down
                                {
                                    innertextbox.focus();
                                    break;
                                }
                        }
                    }

                }

            }
        }
        function ShowMsg_Failure(error) { }
        function FindSuccsss(result) {
            if (trim12(result) != '') {
                showddl('divCheck');
                var divCheck = document.getElementById("divCheck");

                var str_prop1 = result.split('µ');
                var store_Name = '';
                var store_ID = '';
                var store_contacts = '';
                var store_accountno = '';
                var store_address = '';

                var finalval = '';
                for (var i = 0; i < str_prop1.length - 1; i++) {
                    var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^  
                    store_ID = str_prop2[0];
                    store_Name = str_prop2[1];
                    store_contacts = str_prop2[2];
                    store_accountno = str_prop2[3];
                    store_address = str_prop2[4];
                    var color1 = "#DADADA";
                    if (i % 2 == 0) {
                        color1 = "#EFEFEF";
                    }
                    finalval += " <div class='divpad' style='height:20px;z-index:1000;'>";
                    finalval += " <a href='#' onclick=\"javaScript:GetClientName11('" + store_ID + "','" + store_Name + "','" + store_contacts + "','" + store_accountno + "','" + store_address + "')\">" + store_Name + "</a>";
                    finalval += "</div>";
                }
                divCheck.innerHTML = finalval;
            }
            else {
                ShowOff('divCheck');
            }
        }


        function GetContactID(ddlval) {
            var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
            hid_ContactID.value = ddlval;

            //To get Contact Address//
            var CompID = '<%=CompanyID %>';
            PageMethods.GetContactAddress(CompID, ddlval, GetAddress);
            //end
        }

        function GetAddress(result) {

            var hid_AddressType = document.getElementById("<%=hid_AddressType.ClientID %>");
            var lblAddress = document.getElementById("<%=lblAddress.ClientID %>");
            var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");

            hid_AddressType.value = 'C'; //'C' -- contact Address, 'A'-- Mian Address
            hdnAddressID.value = 0;
            lblAddress.innerHTML = '';

            var Address = '';
            var add = result.split('±');
            for (var j = 0; j < add.length; j++) {
                var str = add[j].split('»');
                if (trim12(str[0]) == "ContactAddressID") {
                    hdnAddressID.value = str[1];
                }
                if (trim12(str[0]) == "ContactAddress") {
                    Address = str[1];
                    lblAddress.innerHTML = SpecialDecode(str[1]);
                    lblAddress.title = SpecialDecode(str[1]);
                }
            }
        }       

    </script>
    <%-- WHILE EDIT--%>
    <asp:Panel ID="pnlLoadOnEdit" runat="server" Visible="false">
        <asp:HiddenField ID="hid_PO_values" runat="server" Value="" />
        <script type="text/javascript">
            var str = document.getElementById("<%=hid_PO_values.ClientID %>");
            load("<%=Goods_Received_Display%>");
        </script>
        <script src="<%=strSitepath %>js/item/purchaseadd.js?VN='<%=VersionNumber%>'" type="text/javascript">

            var txtSupplier = document.getElementById("<%=txtSupplier.ClientID %>");
            var spn_tblHeader = document.getElementById("spn_tblHeader");
            var spn_txtSupplier = document.getElementById("spn_txtSupplier");
            var spn_ddlcontact = document.getElementById("spn_ddlcontact");
            var spn_lblAddress = document.getElementById("spn_lblAddress");
            var spn_ddlRaisedBy = document.getElementById("spn_ddlRaisedBy");
            var spn_txtDate = document.getElementById("spn_txtDate");
            var spn_txtReqDate = document.getElementById("spn_txtReqDate");


            //left side//
            var txtSupplierID = document.getElementById("<%=txtSupplier.ClientID %>");
            var ddlContactID = document.getElementById("<%=ddlcontact.ClientID %>");
            var lblAddressID = document.getElementById("<%=lblAddress.ClientID %>");

            //rightside//
            var ddlRaisedByID = document.getElementById("<%=ddlRaisedBy.ClientID %>");
            var txtDateID = document.getElementById("<%=txtDate.ClientID %>");
            var txtReqDateID = document.getElementById("<%=txtReqDate.ClientID %>");

            var tblHeaderID = document.getElementById("tblHeader");
            var divbtn = document.getElementById('divbtn');
            var tblpaper = document.getElementById("tblpaper");
            var tblink = document.getElementById("tblink");
            var tblfilm = document.getElementById("tblfilm");
            var tblplate = document.getElementById("tblplate");
            var tblsearch = document.getElementById("tblsearch");
            var tblnote = document.getElementById("tblnote");
            var tdaddnew = document.getElementById("tdaddnew");
            var tdpaper = document.getElementById("tdpaper");
            var tdfilm = document.getElementById("tdfilm");
            var tdpaperheader = document.getElementById("tdpaperheader");
            var tdinkheader = document.getElementById("tdinkheader");
            var tdfilmheader = document.getElementById("tdfilmheader");
            var tdplateheader = document.getElementById("tdplateheader");
            var tdbtnSupplier = document.getElementById("tdbtnSupplier");
            var btnstockonly = document.getElementById("btnstockonly");

            
          

           
        </script>
    </asp:Panel>
    <asp:HiddenField ID="hid_Mode" runat="server" Value="" />
    <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Onclick"></asp:LinkButton>
    <script type="text/javascript" language="javascript">
        document.getElementById("divBackGroundNew").style.display = "none";
        document.getElementById("div_Load_Purchase").style.display = "none";
        function printemail() {
            var check = Check_contact();
            if (check) {
                alert("Please select the supplier to proceed...");
                return false;
            }
            document.getElementById("divBackGroundNew").style.display = "block";
            document.getElementById("div_Load_Purchase").style.display = "block";
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            var val = Validate();
            if (val) {
                document.getElementById("<%=hid_Mode.ClientID %>").value = "print";
                __doPostBack('ctl00$ContentPlaceHolder1$lnkSave', '');
            }
            else {
                return false;
            }
        }

        function Show_DeliveryAddressDiv() {
            CustomerID = '<%=CustomerID %>';
            if (txtName.value == "") {

                alert('<%=objLangClass.GetLanguageConversion("Please_Select_The_Supplier_To_Proceed")%>');
                return false;
            }
            else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
                alert("Please select the supplier to proceed...");
                return false;
            }

            else {

                window.radopen(commonpath + "common/common_popup.aspx?type=moreaddress&addresstype=Delivery&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes&DeliveryToID=" + hdn_CompanyID.value,null, '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                return true;
            }
        }

        function SendDeliveryAddressIDandName(CompanyName, AddressID, Address, AddressType, DeliveryCompanyID) {
            if (AddressType != 'Contact') {

                lbl_deliveryAddress_Value.innerHTML = Address;
                lbl_CompanyName.style.display = "block";
                lbl_CompanyName.innerHTML = SpecialDecode(CompanyName);
                lbl_CompanyName.title = SpecialDecode(CompanyName);
                hdn_CompanyName.value = CompanyName;
                hdn_deliveryAddress.value = Address;
                hdn_deliveryAddressID.value = AddressID;
                hdn_deliveryAddressType.value = AddressType;
                hdn_CompanyID.value = DeliveryCompanyID;

            }
            else {
                lblAddress.innerHTML = trim12(Address);
                hdnAddressID.value = AddressID;
                lblAddress.title = SpecialDecode(Address);
                lblAddress.innerHTML = SpecialDecode(Address);
                lblAddress.style.cursor = "pointer";
            }

        }
        function get_address_newsaved(companyname, address) {
            lbl_deliveryAddress_Value.title = SpecialDecode(address);
            lbl_deliveryAddress_Value.innerHTML = SpecialDecode(address);
            lbl_CompanyName.title = SpecialDecode(companyname);
            lbl_CompanyName.value = SpecialDecode(companyname);
        }
        function RadWinClose() {
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
        var lbl_deliveryAddress_Value = document.getElementById("<%=lbl_deliveryAddress_Value.ClientID %>");
        var lbl_CompanyName = document.getElementById("<%=lbl_CompanyName.ClientID %>");
        var hdn_CompanyName = document.getElementById("<%=hdn_CompanyName.ClientID %>");
        var hdn_CompanyID = document.getElementById("<%=hdn_CompanyID.ClientID %>");
        var hdn_deliveryAddress = document.getElementById("<%=hdn_deliveryAddress.ClientID %>");
        var hdn_deliveryAddressID = document.getElementById("<%=hdn_deliveryAddressID.ClientID %>");
        var hdn_deliveryAddressType = document.getElementById("<%=hdn_deliveryAddressType.ClientID %>");

        function ImageButtonPlus_Click() {
            window.radopen("<%=strSitepath %>common/Client_add_new.aspx?type=Supplier&post=" + "<%=pg%>" + "&mode=edit&sender=popup",null, 1000, 500);
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }
        function onchange_ddlCourierInfo(ddlValue) {
            hdn_supplierID.value = ddlValue;
        }

        function ReBind_Supplier(SupplierID, SuppName) {
            ddlSupplierID.options.add(new Option(SuppName, SupplierID, ddlSupplierID.length))
            hdn_supplierID.value = SupplierID;
            for (var i = 0; i < ddlSupplierID.length; i++) {
                if (ddlSupplierID.options[i].value == SupplierID) {
                    ddlSupplierID.selectedIndex = i;
                }
            }
        }
        var lblAddress = document.getElementById("<%=lblAddress.ClientID %>");
        var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");
        function ShowAttachments() {
            var pagetype = 'general';
            var Radwindow_Attachment = window.radopen("<%=strSitepath %>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&purchaseID=" + PurchaseID + "&estid=" + EstimateID + "&pg=" + Pgtype + "");
            SetRadWindow_Ver2('Div_Attachment', 'divBackGroundNew');
            Radwindow_Attachment.setSize(1035, 555);
            Radwindow_Attachment.center();
        }
        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
            var div_Accountcode = document.getElementById(divMaskID);
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
        function Delete_Confirmation() {
            return window.confirm('<%=objLangClass.GetLanguageConversion("Delete_Confirmation_Alert") %>');
        }

        function ShowPopUp(val) {
            var PurchaseStatusID = "<%=PurcahseStatusID %>";
            var ServerName = "<%=ServerName %>";

            if (ServerName.toLowerCase() == "dmc" || ServerName.toLowerCase() == "dmc2") {
                if (PurchaseStatusID == val) {
                    var oWnd = $find("<%=DeliveryStatus.ClientID%>");
                    oWnd.show();
                }
            }
        }

        function PurchaseOrdStatusUpdate(ddlStatusValue) {
            var PID = "<%=PurchaseID %>";
            if (PID != 0) {
                item_summary.DelPurchaseOrdStatusUpdate(CompanyID, "purchase", ddlStatusValue, PID, "", OnSuccess);
            }
        }
        function OnSuccess(result) {
            document.getElementById("Div_SuccMsg").style.display = "block";
            setTimeout("Timeout()", 5000);
        }
        function Timeout() {
            document.getElementById("Div_SuccMsg").style.display = "none";
        }
        function NoClick() {
            var ddl = document.getElementById("<%=ddlStatus.ClientID %>");
            var hdn_Previous_PurchaseID = document.getElementById("<%=hdn_Previous_PurchaseID.ClientID %>");
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].value == hdn_Previous_PurchaseID.value) {
                    ddl.options[i].selected = true;
                }
            }
            RadWinClose1();
            return false;
        }

        function YesClick() {
            var hdn_Previous_PurchaseID = document.getElementById("<%=hdn_Previous_PurchaseID.ClientID %>");
            var ddl = document.getElementById("<%=ddlStatus.ClientID %>");
            hdn_Previous_PurchaseID.value = ddl.value
            RadWinClose1();
            return false;
        }

        function RadWinClose1() {
            var oWnd = $find("<%=DeliveryStatus.ClientID%>");
            oWnd.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script language="javascript">
        function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {

            var txtName = document.getElementById("<%=txtSupplier.ClientID %>");
            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
            var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
            var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
            var hid_Suppname = document.getElementById("<%=hid_Suppname.ClientID %>");
            hid_Suppname.value = SpecialDecode(ClientName);
            txtName.value = SpecialDecode(ClientName);
            hid_ClientID.value = ClientID;
            var lblAddress = document.getElementById("<%=lblAddress.ClientID %>");
            lblAddress.innerHTML = "";
            var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");

            //*** to bind attention from clientID *****//
            var ContactName = '';
            var ContactID = '';
            ddlcontact.length = 0;
            //Changes Made on 28.07.2011.
            var ISDefaultContact = '';
            var DefaultConInd = 0;

            var str_con1 = Contacts.split('^'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain
            ddlcontact.options.add(new Option('--- Select --- ', 0, 0)); // Ticket -- 12831
            for (var k = 0; k < str_con1.length; k++) {
                if (str_con1[k] != '') {
                    var ContactIDName = str_con1[k].split('±');
                    ContactID = ContactIDName[0];
                    ContactName = SpecialDecode(trim12(ContactIDName[1]));
                    ISDefaultContact = ContactIDName[2];

                    if (ISDefaultContact == "1") {
                        DefaultConInd = k;
                    }
                    ddlcontact.options.add(new Option(ContactName, ContactID, k));
                }
            }
            ddlcontact.selectedIndex = DefaultConInd + 1;

            if (ddlcontact.selectedIndex == -1) {
                ddlcontact.selectedIndex = 0;
            }

            if (ddlcontact.length != '') {
                hid_ContactID.value = ddlcontact.options[0].value;
                GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected    
            }


            var str_add1 = Address.split('»'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain
            for (var i = 0; i < str_add1.length; i++) {
                if (str_add1[i] != '') {
                    var AddressID = str_add1[0];
                    var Address = str_add1[1];
                    var LimitAddress = str_add1[2];
                    var IsDelivery = str_add1[3];
                    hdnAddressID.value = AddressID;

                    lblAddress.title = Address;
                }
            }
            // *** End of address *****//    
        }
    </script>
</asp:Content>
