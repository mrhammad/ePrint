<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="delivery_add.ascx.cs" Inherits="ePrint.usercontrol.Delivery.delivery_add" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Task" Src="~/usercontrol/Item/estimate_task_add.ascx" %>
<%@ Register TagName="Notes" TagPrefix="UC" Src="~/usercontrol/Item/notes.ascx" %>
<%@ Register TagName="Attachments" TagPrefix="UC" Src="~/usercontrol/Item/attachments.ascx" %>
<script type="text/javascript" src="<%=strSitepath %>js/item/delivery.js?VN='<%=VersionNumber%>'"></script>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var path = "<%=strSitepath %>";
    var Pgtype = "<%=pg %>";
    var ServerName = "<%=ServerName %>";
    var Config_DeliveryID = "<%=Config_DeliveryID %>";

    function showmsg() {
        return false;
    }

    function DisplayStatusMsg(msg) {
        //alert(msg);
    }

</script>
<style>
    .active {
        background-color: #DADADA;
    }

    .active1 {
        background-color: white;
    }

    html body .RadInput_Default .riTextBox, html body .RadInputMgr_Default {
        border-right: 2px solid #737373;
        border-bottom: 1px solid #737373;
        border-top: 1px solid silver;
        border-left: 1px solid silver;
        height: 15%;
        padding: 1% 5%;
        margin-top: 0px;
    }
</style>
<UC:Notes ID="UCNotes" runat="server" />
<div id="divBackGroundNew" style="display: none;">
</div>
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
<div id="Div_CarInfoSuccMsg" style="display: none;">
    <asp:UpdatePanel ID="UPCarInfoSuccMsg" runat="server">
        <ContentTemplate>
            <table align="center" width="99%" border="0px">
                <tr>
                    <td align="center">
                        <div align="center" style="float: left; margin-left: 40%;">
                            <asp:Label ID="lblCarInfoSuccMsg" runat="server" CssClass="msg-success" Text="Carrier Information updated successfully"
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
        <div style="float: left; width: 60%">
            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
        </div>
        <div style="float: right; color: red">
            *
            <%=objLangClass.GetLanguageConversion("Fields_Are_Mandatory")%>
        </div>
    </div>
    <div class="onlyEmpty">
    </div>
    <div align="left" style="width: 100%">
        <div id="leftcol">
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label20" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div id="DivImgCustomerAdd" runat="server" style="float: right">
                        <asp:ImageButton ID="ImgCustomerAdd" runat="server" CausesValidation="false" ImageUrl="~/images/plus.gif"
                            Style="vertical-align: middle" ToolTip="" />
                    </div>
                </div>
                <div class="box">
                    <div style="float: left;">
                        <asp:TextBox ID="txtName" runat="server" AutoCompleteType="disabled" SkinID="textPad"
                            Width="240px"></asp:TextBox><%--onkeyup="BindClientName(this.value,event,this);"--%>
                        <div class="onlyEmpty">
                        </div>
                        <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                        </div>
                    </div>
                    <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none">
                        <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindClientName('',event,this);"
                            style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                    </div>
                    <div style="clear: both">
                    </div>
                    <div id="spn_txtName" style="display: none; width: auto; float: left">
                        <div class="RFV_Message">
                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLangClass.GetLanguageConversion("Please_Select_Customer_Name")%></span>
                        </div>
                    </div>
                    <asp:HiddenField ID="hid_DeliveryToClientID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_Clientname" runat="server" Value="" />
                    <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_DeliveryID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_AddressType" runat="server" Value="" />
                    <asp:HiddenField ID="hid_DelAddressType" runat="server" Value="" />
                    <asp:HiddenField ID="hdn_selectedcentre" runat="server" Value="0" />
                    <script>
                        var SelectedCostCentre = document.getElementById("<%=hdn_selectedcentre.ClientID %>").value;
                    </script>
                    <style>
                        #divCheck {
                            float: left;
                            position: absolute;
                            display: none;
                            border: solid 1px silver;
                            overflow-x: hidden;
                            overflow-y: scroll;
                            width: 175px;
                            height: 100px;
                            background-color: white;
                        }

                        #div_list {
                            float: left;
                            position: absolute;
                            display: none;
                            border: solid 1px silver;
                            overflow-x: hidden;
                            overflow-y: scroll;
                            width: 175px;
                            height: 75px;
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
                        }
                        function ShowOff(divid) {
                            document.getElementById(divid).style.display = "none";
                            document.getElementById("<%=ddlcontact.ClientID %>").style.display = "block";
                        }
                        function addTotxt(divid, divValue) {
                            document.getElementById("<%=txtName.ClientID %>").value = leftTrim(document.getElementById(divid).innerHTML);
                            ShowOff('div_list')
                        }
                        function leftTrim(str) {

                            var str = str.replace(/^\s\s*/, ''),
                                ws = /\s/,
                                i = str.length;
                            while (ws.test(str.charAt(--i)));
                            return str.slice(0, i + 1);

                        }

                    </script>
                    <script>
                        //********** web service to autocomplete clientname *********//
                        this.pointer = 0;
                        function BindClientName(txtval, e, objectname) {
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
                                                document.getElementById("spn_ddlcontact").style.display = "none";
                                                document.getElementById("spn_txtName").style.display = "none";
                                                document.getElementById("spn_lblDeliveryAddress").style.display = "none";
                                                PageMethods.GetClientName(val, FindSuccCName, ShowMsg_Failure);
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
                        function FindSuccCName(result) {
                            if (trim12(result) != '') {
                                showddl('divCheck');
                                document.getElementById('spn_txtName').style.display = "none";
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
                        function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
                            var txtName = document.getElementById("<%=txtName.ClientID %>");
                                var txtCompany = document.getElementById("<%=txtCompany.ClientID %>");
                                var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
                                var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
                                var hid_Clientname = document.getElementById("<%=hid_Clientname.ClientID %>");
                                var hid_DeliveryToClientID = document.getElementById("<%=hid_DeliveryToClientID.ClientID %>");

                                hid_Clientname.value = ClientName;
                                txtName.value = SpecialDecode(ClientName);
                                txtCompany.value = SpecialDecode(ClientName);
                                hid_ClientID.value = ClientID;
                                hid_DeliveryToClientID.value = ClientID;


                                var ContactName = '';
                                var ContactID = '';
                                ddlcontact.length = 0;
                                var DefaultContct = '';
                                var IsDefltContct = '';

                                var str_con1 = Contacts.split('^');

                                for (var k = 0; k < str_con1.length; k++) {
                                    if (str_con1[k] != '') {
                                        var ContactIDName = str_con1[k].split('±');
                                        ContactID = ContactIDName[0];
                                        ContactName = SpecialDecode(trim12(ContactIDName[1]));
                                        IsDefltContct = ContactIDName[2];

                                        if (IsDefltContct == "1") {
                                            DefaultContct = k;
                                        }
                                        ddlcontact.options.add(new Option(ContactName, ContactID, k));
                                    }
                                }
                                ddlcontact.selectedIndex = DefaultContct;


                                //to bind greeting//   
                                if (str_con1 != '') {
                                    var firstname = ddlcontact.options[ddlcontact.selectedIndex].text.split(' ');

                                    GetContactID(ddlcontact.options[ddlcontact.selectedIndex].value); //To bind Contact Address on Contact selected                                                                              
                                }
                                //  end   

                                ShowOff("divCheck");
                                //*** End of to bind attention from clientID *****//


                                //*** to bind address from clientID *****//  
                                /* */
                                var hid_IsDelivery = document.getElementById("<%=hid_IsDelivery.ClientID %>");
                                var lblDeliveryAddress = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
                                var hid_DeliveryAddressID = document.getElementById("<%=hid_DeliveryAddressID.ClientID %>");
                                var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");

                            hid_DeliveryAddressID.value = 0;
                            lblDeliveryAddress.innerHTML = '';
                            var str_add1 = Address.split('»'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain
                            for (var i = 0; i < str_add1.length; i++) {
                                if (str_add1[i] != '') {
                                    var AddressID = str_add1[0];
                                    var Address = str_add1[1];
                                    var LimitAddress = str_add1[2];
                                    var IsDelivery = str_add1[3];
                                    var AddressType = str_add1[4];
                                    hid_IsDelivery.value = IsDelivery;

                                    if (Contacts == "") {
                                        lblDeliveryAddress.innerHTML = '';

                                    }
                                    else {
                                        lblDeliveryAddress.innerHTML = LimitAddress;
                                    }

                                    //'C' -- contact Address, 'A'-- Mian Address
                                    hid_DelAddressType.value = AddressType;
                                    hid_DeliveryAddressID.value = AddressID;
                                    lblDeliveryAddress.title = Address;
                                    //                                    }
                                }
                            }
                            // *** End of address *****//                                                    
                        }
                        function GetContactID(ddlval) {
                            var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
                                var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
                                hid_ContactID.value = ddlval;
                                //To get Contact Address//
                                var CompID = '<%=CompanyID %>';
                                PageMethods.GetContactAddress(CompID, ddlval, GetAddress); //To bind Contact Addressses

                                //to bind greeting// 
                                for (var i = 0; i < ddlcontact.length; i++) {
                                    if (ddlcontact.options[i].value == ddlval) {
                                        var firstname = ddlcontact.options[i].text.split(' ');
                                    }
                                }
                                //  end  
                                AutoFill.LoadDDLCostCentre(<%=CompanyID%>, hid_ClientID.value, 0, hid_ContactID.value, LoadCostCentre);

                        }

                        function LoadCostCentre(CostCentreList) {
                            var ddlcostcentre = document.getElementById("<%=ddlcostcentre.ClientID %>");
                                ddlcostcentre.length = 0;
                                var costsplit = CostCentreList.split('~');
                                if (costsplit != '') {
                                    var DefaultCostCentreID = '';
                                    var DefaultCostCentreName = '';
                                    var Defaultcost = costsplit[0].split('±');
                                    DefaultCostCentreID = Defaultcost[0];
                                    DefaultCostCentreName = Defaultcost[1];
                                    var CostCentreID = '';
                                    var CostCentreName = '';
                                    ddlcostcentre.options.add(new Option(DefaultCostCentreName, DefaultCostCentreID, 0));

                                    ddlcostcentre.options.add(new Option('----------Other Cost Centre----------', 'Other Cost Centre', 1));
                                    ddlcostcentre.options[1].disabled = true;

                                    var strcost = costsplit[1].split('^');
                                    var count = 2;
                                    for (var c = 0; c < strcost.length; c++) {
                                        if (strcost[c] != '') {
                                            var CostCentreConCat = strcost[c].split('±');
                                            if (Number(CostCentreConCat[0]) != Number(DefaultCostCentreID)) {
                                                CostCentreID = CostCentreConCat[0];
                                                CostCentreName = CostCentreConCat[1];
                                                ddlcostcentre.options.add(new Option(CostCentreName, CostCentreID, count));
                                                count = count + 1;
                                            }
                                        }
                                    }

                                    if (SelectedCostCentre != 0) {
                                        var a = document.getElementById("<%=ddlcostcentre.ClientID %>");
                     for (i = 0; i < a.length; i++) {
                         if (a.options[i].value == SelectedCostCentre) {
                             a.selectedIndex = i;
                             document.getElementById("<%=hdn_costcentreid.ClientID %>").value = SelectedCostCentre;
                         }
                     }
                 }
                 else {
                     ddlcostcentre.selectedIndex = 0;
                     document.getElementById("<%=hdn_costcentreid.ClientID %>").value = document.getElementById("<%=ddlcostcentre.ClientID %>").options[document.getElementById("<%=ddlcostcentre.ClientID %>").selectedIndex].value;
                                }
                            }
                        }

                        function CallLoadCostCentre(CompID, ClientID, DepartmentID, SelectedCentre) {
                            if (SelectedCentre != 0) {
                                SelectedCostCentre = SelectedCentre;
                            }
                            AutoFill.LoadDDLCostCentre(CompID, ClientID, DepartmentID, 0, LoadCostCentre);
                        }

                        function GetAddress(result) {

                            var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
    var hid_IsDelivery = document.getElementById("<%=hid_IsDelivery.ClientID %>");
    var lblDeliveryAddress = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
    var hid_DeliveryAddressID = document.getElementById("<%=hid_DeliveryAddressID.ClientID %>");
    var hdn_departmentid = document.getElementById("<%=hdn_departmentid.ClientID %>");

                            hid_DelAddressType.value = 'C'; //'C' -- contact Address, 'A'-- Mian Address
                            hid_DeliveryAddressID.value = 0;
                            lblDeliveryAddress.innerHTML = '';


                            var Address = '';
                            var add = result.split('±');
                            for (var j = 0; j < add.length; j++) {
                                var str = add[j].split('»');

                                var str = add[j].split('»');
                                if (trim12(str[0]) == "DeptNo") { //added by rakshith
                                    hdn_departmentid.value = str[1];
                                }

                                if (trim12(str[0]) == "DeliveryAddressID") {
                                    hid_DeliveryAddressID.value = str[1];
                                }
                                if (trim12(str[0]) == "DeliveryAddress") {
                                    lblDeliveryAddress.innerHTML = str[1];
                                    lblDeliveryAddress.title = str[1];
                                }

                            }
                        }
                            //********** End of web service to autocomplete clientname *********//
                    </script>
                    <script>
                        function changeTheHeightOfText() {
                            if (navigator.appName.toLowerCase() == "microsoft internet explorer") {
                                document.getElementById("<%=txtName.ClientID %>").style.height = "15px";
                            }
                            else if (navigator.appName.toLowerCase() == "netscape") {
                                document.getElementById("<%=txtName.ClientID %>").style.marginTop = "1px";
                            }
                        }
                    </script>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label1" runat="server" Text="Contact" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div id="DivImageButton8" runat="server" style="float: right">
                        <asp:ImageButton Style="vertical-align: top" ID="ImageButton8" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" ToolTip="Select Attention" OnClientClick="javascript:add_contact();return false;"></asp:ImageButton>
                    </div>
                </div>
                <div class="box" id="div_ddlAttention">
                    <asp:DropDownList ID="ddlcontact" CssClass="normaltext" Width="240px" runat="server"
                        onchange="GetContactID(this.value);">
                    </asp:DropDownList>
                    <div style="clear: both">
                    </div>
                    <div id="spn_ddlcontact" style="display: none; width: auto; float: left">
                        <div class="RFV_Message">
                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLangClass.GetLanguageConversion("Please_Select_Attention")%>
                            </span>
                        </div>
                    </div>
                    <asp:HiddenField ID="hid_ContactID" runat="server" Value="0" />
                </div>
            </div>
            <%--added by rakshith --%>
            <div id="div_costcentre" runat="server" align="left" style="display: none">
                <div class="bglabel">
                    <div style="float: left;">
                        <asp:Label ID="lblcostcentre" runat="server" Text='Cost Centre' CssClass="normalText">Cost Centre</asp:Label>
                    </div>
                    <div style="float: right;">
                        <asp:ImageButton Style="vertical-align: top;" ID="ImageButton10" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" OnClientClick="javascript:AddCostCentre();return false;"
                            ToolTip="Add Cost Centre"></asp:ImageButton>
                    </div>
                    <asp:HiddenField ID="hdn_costcentreid" runat="server" Value="0" />
                </div>
                <div class="box" style="width: 50%; max-width: 50%;">
                    <asp:DropDownList ID="ddlcostcentre" onchange="getcostcentreid();" runat="server"
                        CssClass="normalText" Width="240px">
                    </asp:DropDownList>
                </div>
                <script>
                    function getcostcentreid() {
                        document.getElementById("<%=hdn_costcentreid.ClientID %>").value = document.getElementById("<%=ddlcostcentre.ClientID %>").options[document.getElementById("<%=ddlcostcentre.ClientID %>").selectedIndex].value;

                    }

                    function AddCostCentre() {
                        if (txtNameID.value == "") {
                            alert("Please select the supplier to proceed...");
                            return false;
                        }
                        else if (document.getElementById("<%=ddlcontact.ClientID %>").length == 0) {
                            alert("Please add contact to proceed...");
                            return false;
                        }
                        else {
                            var ClientID = document.getElementById("<%=hid_ClientID.ClientID %>").value;
                            var DepartmentID = document.getElementById("<%=hdn_departmentid.ClientID %>").value;
                            var ContactID = document.getElementById("<%=ddlcontact.ClientID %>").options[document.getElementById("<%=ddlcontact.ClientID %>").selectedIndex].value;

                            if (document.getElementById("<%=ddlcostcentre.ClientID %>").length == 0) {
                                alert("Please assign a Department to contact");
                                return false;
                            }
                            else {
                                Radcostcentre = window.radopen("<%=strSitepath %>common/common_addnew_costcentre.aspx?DeptID=" + DepartmentID + "&ClientID=" + ClientID + "&ContactID=" + ContactID + " ");

                                SetRadWindow_Ver2('div_radcostcentre', 'divBackGroundNew', '200');
                                Radcostcentre.setSize(530, 250);
                                Radcostcentre.center();
                            }
                        }
                    }

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


                </script>
            </div>
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label2" runat="server" Text="Shipped To" CssClass="normaltext"></asp:Label>
                    </div>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtCompany" runat="server" SkinID="textPad" MaxLength="200" Width="240px"></asp:TextBox>
                </div>
            </div>
            <div align="left" nowrap="nowrap">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label12" runat="server" Text="" CssClass="normaltext"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div id="DivImageButton1" runat="server" style="float: right">
                        <asp:ImageButton Style="vertical-align: top" ID="ImageButton1" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:Show_DeliveryAddressDiv();return false;"></asp:ImageButton>
                    </div>
                </div>
                <div class="box" style="float: left; margin: -5px 0px 0px 0px; overflow: hidden; white-space: nowrap; width: 225px;">
                    <asp:Label ID="lbl_CompanyName" runat="server" CssClass="graytext" Style="display: block; cursor: pointer; height: 18px; padding-top: 2px;"></asp:Label>
                    <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="graytext" Style="padding: 2px 0px 5px 0px; cursor: pointer"
                        Text=""></asp:Label>
                    <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value="0" />
                    <div style="clear: both">
                    </div>
                    <div id="spn_lblDeliveryAddress" style="display: none; width: auto; float: left">
                        <div class="RFV_Message">
                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLangClass.GetLanguageConversion("Please_Select_Delivery_Address")%>
                            </span>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hid_IsDelivery" runat="server" Value="false" />
                <script type="text/javascript" language="javascript">
                    function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype) {
                        for (var i = 0; i < values.length; i++) {
                            values = values.replace('<br/>', '');
                            i++;
                        }
                        var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
                        var lblDeliveryAddress = "<%=lblDeliveryAddress.ClientID %>";

                        hid_DelAddressType.value = addresstype;
                        document.getElementById(lblDeliveryAddress).title = SpecialDecode(tooltip);
                        document.getElementById(lblDeliveryAddress).innerHTML = SpecialDecode(trim12(values));

                        document.getElementById(lblDeliveryAddress).style.cursor = "pointer";

                        document.getElementById("<%=hid_DeliveryAddressID.ClientID %>").value = id;
                    }
                </script>
            </div>
            <div align="left">
                <div class="bglabel" style="height: 80px">
                    <asp:Label ID="Label5" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box" style="padding: 1px 0px 0px 5px;">
                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="textPad"
                        Height="80px" Width="240px"></asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="lblHeader" runat="server" Text="" CssClass="normaltext"></asp:Label>
                    </div>
                    <div id="DivimgcmdHeader" runat="server" style="float: right">
                        <asp:ImageButton Style="vertical-align: top" ID="imgcmdHeader" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" ToolTip="Select Header" OnClientClick="javascript:popup_phrasebook('Delivery Note Header');return false;"></asp:ImageButton>
                    </div>
                </div>
                <div class="box" style="float: left; padding: 5 0 0 5px; overflow: hidden; white-space: nowrap; width: 225px;">
                    <asp:Label ID="lblHeaderText" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--©All rights-2009--%>
                    <asp:HiddenField ID="hid_HeaderID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_HeaderText" runat="server" Value="" />
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label9" runat="server" Text="" CssClass="normaltext"></asp:Label>
                    </div>
                    <div id="DivImageButton6" runat="server" style="float: right">
                        <asp:ImageButton Style="vertical-align: top" ID="ImageButton6" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" ToolTip="Select Footer" OnClientClick="javascript:popup_phrasebook('Delivery Note Footer');return false;"></asp:ImageButton>
                    </div>
                </div>
                <div class="box" style="float: left; padding: 5 0 0 5px; overflow: hidden; white-space: nowrap; width: 225px;">
                    <asp:Label ID="lblFooter" runat="server" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--©All rights-2009--%>
                    <asp:HiddenField ID="hid_FooterID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_FooterText" runat="server" Value="" />
                </div>
                <script type="text/javascript">
                    function SendPhraseIDandName(id, values, phrasetype, tooltip) {
                        if (phrasetype == 'Delivery Note Footer') {
                            var lblFooter = "<%=lblFooter.ClientID %>";
                            var hid_FooterID = document.getElementById("<%=hid_FooterID.ClientID %>");
                            var lblPhraseText = '';
                            if (phrasetype == 'Delivery Note Footer') {
                                lblPhraseText = lblFooter;
                                document.getElementById("<%=hid_FooterText.ClientID %>").value = trim12(values);
                                hid_FooterID.value = id;
                            }
                            document.getElementById(lblPhraseText).title = tooltip;
                            document.getElementById(lblPhraseText).innerHTML = trim12(values);
                            document.getElementById(lblPhraseText).style.cursor = "pointer";
                        }
                        else {
                            var lblHeaderText = "<%=lblHeaderText.ClientID %>";
                            var hid_HeaderID = document.getElementById("<%=hid_HeaderID.ClientID %>");
                            var lblPhraseHeaderText = '';
                            if (phrasetype == 'Delivery Note Header') {
                                lblPhraseHeaderText = lblHeaderText;
                                document.getElementById("<%=hid_HeaderText.ClientID %>").value = trim12(values);
                                hid_HeaderID.value = id;
                            }
                            document.getElementById(lblPhraseHeaderText).title = tooltip;
                            document.getElementById(lblPhraseHeaderText).innerHTML = trim12(values);
                            document.getElementById(lblPhraseHeaderText).style.cursor = "pointer";
                        }
                    }
                </script>
            </div>
        </div>
        <div id="rightcol">
            <div align="left" id="divEstNo" runat="server" visible="false">
                <div class="bglabel">
                    <asp:Label ID="Label14" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box" style="padding: 5 0 5 8px;">
                    <asp:Label ID="lblDeliveryNumber" runat="server" CssClass="normaltext"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <%=objLangClass.GetLanguageConversion("Status") %>
                </div>
                <div class="box" id="div_ddlStatus">
                    <asp:DropDownList ID="ddlStatus" SkinID="onlyDDL" runat="server" Width="175px" onchange="javascript: DeliveryNoteStatusUpdate(this.value);"
                        Style="float: left">
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <span id="spanddlStatus" style="display: none; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 3px"
                    class="spanerrorMsg">
                    <%=objLangClass.GetLanguageConversion("Please_Select_Status")%></span>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="Label13" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="textPad" MaxLength="255"></asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="Label15" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtOrderNumber" runat="server" SkinID="textPad" MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <div style="float: left">
                        <asp:Label ID="Label3" runat="server" Text="Carrier Information" CssClass="normaltext"></asp:Label><span
                            style="color: Red;" id="spn_CourierInfo" runat="server">*</span>
                    </div>
                    <div id="DivimgbtnSupplier" runat="server" style="float: right">
                        <asp:ImageButton Style="vertical-align: top" ID="imgbtnSupplier" runat="server" CausesValidation="False"
                            ImageUrl="~/images/plus.gif" ToolTip="Add Carrier"></asp:ImageButton>
                    </div>
                </div>
                <div class="box" style="float: left;" id="div_ddlSupplier">
                    <asp:DropDownList ID="ddlSupplier" CssClass="normaltext" runat="server" Width="175px"
                        onchange="javascript:bindconsigneeurl();DeliveryNoteCarInfoUpdate(this.value)">
                    </asp:DropDownList>
                </div>
                <div id="spn_Carrier" style="display: none; width: auto; float: left; margin-left: 3px;">
                    <div class="RFV_Message">
                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;">
                            <%=objLangClass.GetLanguageConversion("Please_Select_Carrier_Information")%></span>
                    </div>
                </div>
                <script>
                    function ReloadContact(FinalContact, retContactID) {
                        var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
                        var ContactName = '';
                        var ContactID = '';
                        ddlcontact.length = 0;
                        var str_con1 = FinalContact.split('µ');
                        for (var k = 0; k < str_con1.length; k++) {
                            if (str_con1[k] != '') {
                                var ContactIDName = str_con1[k].split('±');
                                ContactID = ContactIDName[0];
                                ContactName = SpecialDecode(ContactIDName[1]);
                                ddlcontact.options.add(new Option(ContactName, ContactID, k));

                            }
                        }
                        for (var j = 0; j < ddlcontact.length; j++) {
                            if (retContactID == ddlcontact.options[j].value) {
                                ddlcontact.selectedIndex = j;
                            }
                        }
                        GetContactID(ddlcontact.value); //To bind Contact Address on Contact selected                        
                    }
                </script>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="lblConsig_Note_Numb" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtConsignment_Note_Number" runat="server" SkinID="textPad"></asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="lblConsingneeurl" runat="server" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtconsigneeurl" runat="server" SkinID="textPad"></asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="Label16" runat="server" Text="Delivery Date" CssClass="normaltext"></asp:Label>
                    <span style="color: Red">*</span>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtDeliveryDate" runat="server" SkinID="textPad"></asp:TextBox>
                    <div style="clear: both">
                    </div>
                    <div id="spn_txtDeliveryDate" style="display: none; width: auto; float: left">
                        <div class="RFV_Message">
                            <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                <%=objLangClass.GetLanguageConversion("Please_Enter_delivery_Date")%>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <%=objLangClass.GetLanguageConversion("Accounting_Code") %>
                </div>
                <div class="box" id="div_Account_Code">
                    <asp:DropDownList ID="ddlAccount_Code" SkinID="onlyDDL" runat="server" Width="175px"
                        Style="float: left">
                    </asp:DropDownList>
                </div>
            </div>
            <div align="left">
                <div class="bglabel">
                    <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box" style="padding: 2px 0px 2px 2px;">
                    <asp:CheckBox ID="chkGoodsDelivered" runat="server" onclick="javascript:showActualDeliveryDate(this.id);" />
                </div>
            </div>
            <div id="div_ActualDeliveryDate" runat="server" align="left">
                <div class="bglabel">
                    <asp:Label ID="lblActualDeliveryDate" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="txtActualDeliveryDate" runat="server" SkinID="textPad" Width="90px"></asp:TextBox>
                    <telerik:RadTimePicker ID="RadTimePicker" runat="server" Width="107px"
                        ZIndex="30001" inputmode="TimePicker" CssClass="normaltext">
                        <DateInput ID="DateInput1" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                        </DateInput>
                        <ClientEvents OnDateSelected="DateSelected" />
                        <TimeView ID="TimeView1" runat="server" TimeFormat="hh:mm:ss tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                            Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                        </TimeView>
                        <Calendar ID="Calendar1" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                    </telerik:RadTimePicker>
                    <div style="clear: both">
                    </div>
                </div>
            </div>
            <div align="left">
                <asp:Panel ID="pnl_followup_task" Visible="false" runat="server">
                    <div align="left">
                        <div class="bglabel">
                            <span>
                                <%=objLangClass.GetLanguageConversion("Create_FollowUp_Task")%>
                            </span>
                        </div>
                        <div class="box" style="padding: 2px 0px 2px 2px;">
                            <asp:CheckBox ID="chk_FollowupTask" runat="server" onclick="OpenTaskPage_New(this.checked)" />
                        </div>
                    </div>
                    <asp:HiddenField ID="hidFollowupTask" runat="server" />
                </asp:Panel>
            </div>
        </div>
    </div>
    <div id="div_Task" style="display: none;">
        <asp:PlaceHolder ID="plhTask" runat="server"></asp:PlaceHolder>
        <UC:Task ID="UCTask" runat="server" />
    </div>
    <div class="only10px">
    </div>
    <div align="left" style="width: 100%">
        <div style="float: left; width: 90%">
            <table id="tblHeader" align="left" class="ex" cellspacing="0" border="1" width="100%"
                cellpadding="4">

                <thead>
                    <tr class="label" height="23px">
                        <td>
                            <span style="width: 4%">&nbsp;</span>
                        </td>
                        <td style="width: 15%">
                            <asp:Label ID="lblItemNo" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                        </td>
                        <td style="width: 15%">
                            <asp:Label ID="Label21" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemNotes" runat="server" Text="" CssClass="HeaderText"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label29" runat="server" Text="Description" CssClass="HeaderText"></asp:Label>
                        </td>
                    </tr>
                </thead>
                <tbody id="tblBody">
                    <tr class="label" height="23px" style="display: none;">
                    </tr>
                </tbody>
            </table>
            <div class="onlyEmpty">
            </div>
            <div align="left" style="width: 100%;">
                <div style="float: left; width: 40%">
                    &nbsp;
                </div>
                <div style="float: left; margin-top: 2px">
                    <span id="spn_tblHeader" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                        <%=objLangClass.GetLanguageConversion("Please_Add_Atleast_One_Item_To_Save_Delivery")%>
                    </span>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
        <div style="float: left">
            <div align="left" style="display: none">
                &nbsp;<asp:ImageButton Style="vertical-align: top" ID="ImageButton2" runat="server"
                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Phrase"
                    OnClientClick="javascript:return false;"></asp:ImageButton>
            </div>
            <div id="DivButton1" runat="server" align="left">
                &nbsp;<asp:Button ID="Button1" runat="server" Text="" CssClass="button" Width="65px"
                    OnClientClick="javascript:AddMoreItem('0', '0', 'Enter line detail here', '-2', 'Enter line detail here','');return false;" />
            </div>

            <div align="left" class="only5px">
            </div>
            <div id="DivButton2" runat="server" align="left">
                &nbsp;<asp:Button ID="Button2" runat="server" Text="" CssClass="button" Width="65px"
                    OnClientClick="javascript:deleteRow('tblBody');return false;" />
            </div>
        </div>
    </div>
    <div class="onlyEmpty">
        &nbsp;
    </div>
    <div align="left" style="width: 100%">
        <div style="float: left; width: 69%;">
            &nbsp;
        </div>
        <div style="float: right; width: 38%;">
            <div style="float: left">
                <div id="DivbtnDelete" runat="server" style="float: left">
                    <asp:Button ID="btnDelete" runat="server" Text="" CssClass="button" Width="65px"
                        Visible="false" OnClick="btnDelete_OnClick" OnClientClick="javascript:return window.confirm('Are you sure you want to delete this record?');" />
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>

                <div style="float: left">
                    <asp:Button ID="btnCancel" runat="server" Text="" CssClass="button" Width="65px"
                        OnClientClick="javascript:return cancelClick(path+'delivery/delivery_view.aspx');" /><%--OnClick="btnCancel_OnClick"--%>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>
                <div id="Divdiv_btnsave" runat="server" style="float: left">
                    <div id="div_btnsave" style="display: block">
                        <asp:Button ID="btnSave" runat="server" Text="" CssClass="button" Width="65px" OnClientClick="javascript:var a=Validate_delivery();if(a)loadingimg('div_btnsave','div_btnsaveprocess');return a;"
                            OnClick="btnSave_Onclick" />
                    </div>
                    <div id="div_btnsaveprocess" class="button" align="center" style="width: 47px; display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                    </div>
                </div>
            </div>
            <%--By Natraj,on 13.12.2011 --%>
            <div style="float: left; width: 10px">
                &nbsp;
            </div>
            <div id="DivStay" runat="server" style="float: left">
                <div id="div_btnsavestay" style="display: block">
                    <asp:Button ID="btn_SaveandStay" runat="server" Text="" CssClass="button" OnClick="btnSaveandStay_Onclick"
                        OnClientClick="javascript:var a=Validate_delivery();if(a)loadingimg('div_btnsavestay','div_savestayprocess');return a;" />
                    <asp:HiddenField ID="hdnsavestay" runat="server" />
                </div>
                <div id="div_savestayprocess" class="button" align="center" style="width: 78px; display: none">
                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:LinkButton ID="lnkDeliveryCopy" runat="server" Text=" " OnClick="lnkDeliveryCopy_OnClick"
                            CausesValidation="false" Visible="true"></asp:LinkButton>--%>

    <div style="clear: both;">
    </div>
    <div class="onlyEmpty">
    </div>
</div>
<div class="onlyEmpty">
</div>
<div class="only5px">
</div>
<%--</div>--%>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload, Resize">
    </telerik:RadWindowManager>
</div>
<div id="Div_Attachment" style="display: none; position: absolute; vertical-align: middle; z-index: 100;"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindow_Attachment" DestroyOnClose="true"
        Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
        Behaviors="Close" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>

<asp:HiddenField ID="hid_ItemValues" runat="server" Value="" />
<asp:HiddenField ID="hid_DeletedItemID" runat="server" Value="" />
<asp:HiddenField ID="hid_Del_Edit_values" runat="server" Value="" />
<asp:HiddenField ID="hdnTaskID" runat="server" Value="0" />
<asp:HiddenField ID="hdnItemType" runat="server" Value="d" />
<asp:HiddenField ID="hdn_departmentid" runat="server" Value="0" />
<asp:HiddenField ID="hdn_KitStockValues" runat="server" Value="" />
<asp:HiddenField ID="GetSaveCount" runat="server" Value="0" />
<asp:HiddenField ID="hdnDeleteMsg" runat="server" Value="" />
<asp:HiddenField ID="hdnGetItemTitle" runat="server" Value="" />
<asp:HiddenField ID="hdngetItemTitelID" runat="server" Value="" />
<asp:HiddenField ID="hid_Max_Del_Item_No" runat="server" Value="" />
<div id="div_radcostcentre" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>

<script type="text/javascript" language="javascript">
    var isTimeSelected = false;
    function DateSelected(sender, args) {
    }
    function ClientTimeSelected(sender, args) {
        isTimeSelected = true;
    }

</script>
<script type="text/javascript" language="javascript">
    var currentdate = '<%=newdate %>';
    var pg = '<%=pg %>';
    var rowNo = 1;
    var takeCount = 0;
    var tblHeaderID = document.getElementById("tblHeader");
    var txtNameID = document.getElementById("<%=txtName.ClientID %>");
    var ddlContactID = document.getElementById("<%=ddlcontact.ClientID %>");
    var lblDeliveryAddressID = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
    var txtDeliveryDateID = document.getElementById("<%=txtDeliveryDate.ClientID %>");
    var hid_ItemValues = document.getElementById("<%=hid_ItemValues.ClientID %>");
    var GetSaveCount = document.getElementById("<%=GetSaveCount.ClientID %>");

    var CustomerID = '<%=CustomerID %>';
    var commonpath = "<%=nmsCommon.global.sitePath()%>";

    var hidFollowupTask = document.getElementById("<%=hidFollowupTask.ClientID %>");
    var chk_FollowupTask = document.getElementById("<%=chk_FollowupTask.ClientID %>");

    if (document.getElementById(txtNameID) != null) { // IEB, Customer Selection txtbx is disabled,so checking the null value,on 26.09.2011
        txtNameID.focus();
    }

<%--    function AddMoreItem(ItemID, ItemQty, ItemDesc, ItemNo, ItemNotes, ItemType) {
        debugger;
        //*** new code to generate row from 1st row ***//
        //add a row to the rows collection and get a reference to the newly added row  

        if (typeof rowNo === 'undefined' || isNaN(rowNo)) {
            rowNo = document.querySelectorAll("#tblBody tr").length; // Get number of existing rows
        }
        rowNo = parseInt(rowNo) || 0;

        spn_tblHeader.style.display = "none";
        var newRow = document.all("tblBody").insertRow(rowNo);
        newRow.id = "trRow_" + rowNo;

        //var notes = "tISiPpwQ5PugyBcP1jQIo1ciKyVGArD7ZWQkyKSQi0Fd7lmemGSf43YhbHCi87nUFOJXInUmvPJc39JegCWp5AB6xtKuklJd7EnSc3DtCm3KbAkdoLpi9sfIpM0qlynn0Vi6oFy7U86ZKFuvAfb88wgIbLhMbGJQRGQ3t2aroCgJVbBUG0Jz7FMWyNRqDdruTF27ACqBjQEDzaYsOudDTglmwUkr7a6wYgSXJnJWnomsgdhzt27zzYJzmcMDZDW6";

        //add cells (<td>) to the new row and set the innerHTML to contain text boxes                            
        var oCell = newRow.insertCell(0);
        oCell.id = "tdcol_" + rowNo;
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='checkbox' name='chk" + rowNo + "' id='chk" + rowNo + "' value='0' /><label name='lblItemType" + rowNo + "' id='lblItemType" + rowNo + "' class='normalText' style='display:none'>" + ItemType + "</label><label name='lblItemID" + rowNo + "' id='lblItemID" + rowNo + "' class='normalText' style='display:none'>0</label>";

        if (ItemNo != "-2") {
            if (ItemNo != "0") {
                oCell = newRow.insertCell(1);
                oCell.style.verticalAlign = "top";
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + ItemNo + "' onblur='AllowNumber(this,this.value)'>";
            }
            else {
                oCell = newRow.insertCell(1);
                oCell.style.verticalAlign = "top";
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + rowNo + "' onblur='AllowNumber(this,this.value)'>";
            }
        }
        else // item no == -2
        {
            var itemNo = document.getElementById("<%=hid_Max_Del_Item_No.ClientID %>");

            itemNo = itemNo ? parseInt(itemNo.value) : NaN;

            if (isNaN(itemNo)) {
                console.warn("Error: Hidden field not found or invalid value. Using rowNo.");
                itemNoValue = rowNo;
            }

            oCell = newRow.insertCell(1);
            oCell.style.verticalAlign = "top";
            if (parseInt(itemNo.value) < parseInt(rowNo)) {
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + rowNo + "' onblur='AllowNumber(this,this.value)'>";

                document.getElementById("<%=hid_Max_Del_Item_No.ClientID %>").value = (parseInt(rowNo)) + 1;
            }
            else {
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + itemNo.value + "' onblur='AllowNumber(this,this.value)'>";

                document.getElementById("<%=hid_Max_Del_Item_No.ClientID %>").value = (parseInt(itemNo.value)) + 1;
            }

        }

        oCell = newRow.insertCell(2);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='text' name='txtItemQty" + rowNo + "' id='txtItemQty" + rowNo + "' class='textboxnew' maxlength='10' style='width:85px' value='" + ItemQty + "' onblur='AllowNumber(this,this.value)'>";

        oCell = newRow.insertCell(3);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='7' style='width:100%'>" + ItemNotes + "</textarea><input type='hidden' name='Rownumber' id='hdn_Rownumber_" + rowNo + "' value='" + rowNo + "'>";
        var isShowDescHeadings = "<%=isShowDescHeadings %>"
        if (isShowDescHeadings=='True') { 
            const pattern = /\b\w+:\s*/g;
            ItemDesc = ItemDesc.replace('Item Title: ', '').replace('Item title: ', '').replace('item title: ', '');
        // Use replace to remove all matches of the pattern
        ItemDesc = ItemDesc.replace(pattern, '');
        }

        oCell = newRow.insertCell(4);
        oCell.innerHTML = "<textarea name='txtDescription" + rowNo + "' id='txtDescription" + rowNo + "' class='textboxnew' rows='7' style='width:100%'>" + ItemDesc + "</textarea><input type='hidden' name='Rownumber' id='hdn_Rownumber_" + rowNo + "' value='" + rowNo + "'>";

        rowNo = rowNo + 1;
        //** End **//
    }--%>

    function AddMoreItem(ItemID, ItemQty, ItemDesc, ItemNo, ItemNotes, ItemType) {
        debugger;
        //*** new code to generate row from 1st row ***//
        //add a row to the rows collection and get a reference to the newly added row  

        if (typeof rowNo === 'undefined' || isNaN(rowNo)) {
            rowNo = document.querySelectorAll("#tblBody tr").length;
        }
        rowNo = parseInt(rowNo) || 0;

        spn_tblHeader.style.display = "none";
        var newRow = document.all("tblBody").insertRow(rowNo);
        newRow.id = "trRow_" + rowNo;

        var oCell = newRow.insertCell(0);
        oCell.id = "tdcol_" + rowNo;
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='checkbox' name='chk" + rowNo + "' id='chk" + rowNo + "' value='0' />" +
            "<label name='lblItemType" + rowNo + "' id='lblItemType" + rowNo + "' class='normalText' style='display:none'>" + ItemType + "</label>" +
            "<label name='lblItemID" + rowNo + "' id='lblItemID" + rowNo + "' class='normalText' style='display:none'>0</label>";

        if (ItemNo !== "-2") {
            oCell = newRow.insertCell(1);
            oCell.style.verticalAlign = "top";
            var itemValue = (ItemNo !== "0") ? ItemNo : rowNo;
            oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + itemValue + "' onblur='AllowNumber(this,this.value)'>";
        }
        else {
            var itemNoField = document.getElementById("<%=hid_Max_Del_Item_No.ClientID %>");
            var itemNoValue = itemNoField ? parseInt(itemNoField.value) : NaN;

            if (isNaN(itemNoValue)) {
                itemNoValue = rowNo;
            }

            oCell = newRow.insertCell(1);
            oCell.style.verticalAlign = "top";

            if (itemNoValue < rowNo) {
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + rowNo + "' onblur='AllowNumber(this,this.value)'>";
                if (itemNoField) {
                    itemNoField.value = rowNo + 1;
                }
            }
            else {
                oCell.innerHTML = "<input type='text' name='txtItemNo" + rowNo + "' id='txtItemNo" + rowNo + "' class='textboxnew' maxlength='10' disabled style='width:85px' value='" + itemNoValue + "' onblur='AllowNumber(this,this.value)'>";
                if (itemNoField) {
                    itemNoField.value = itemNoValue + 1;
                }
            }
        }

        oCell = newRow.insertCell(2);
        oCell.style.verticalAlign = "top";
        oCell.innerHTML = "<input type='text' name='txtItemQty" + rowNo + "' id='txtItemQty" + rowNo + "' class='textboxnew' maxlength='10' style='width:85px' value='" + ItemQty + "' onblur='AllowNumber(this,this.value)'>";

        oCell = newRow.insertCell(3);
        oCell.innerHTML = "<textarea name='txtNotes" + rowNo + "' id='txtNotes" + rowNo + "' class='textboxnew' rows='7' style='width:100%'>" + ItemNotes + "</textarea>" +
            "<input type='hidden' name='Rownumber' id='hdn_Rownumber_" + rowNo + "' value='" + rowNo + "'>";

        var isShowDescHeadings = "<%=isShowDescHeadings %>";
        if (isShowDescHeadings == 'True') {
            const pattern = /\b\w+:\s*/g;
            ItemDesc = ItemDesc.replace(/Item Title:\s*|Item title:\s*|item title:\s*/gi, '');
            ItemDesc = ItemDesc.replace(pattern, '');
        }

        oCell = newRow.insertCell(4);
        oCell.innerHTML = "<textarea name='txtDescription" + rowNo + "' id='txtDescription" + rowNo + "' class='textboxnew' rows='7' style='width:100%'>" + ItemDesc + "</textarea>" +
            "<input type='hidden' name='Rownumber' id='hdn_Rownumber_" + rowNo + "' value='" + rowNo + "'>";

        rowNo = rowNo + 1;
    }
    //*** Func to DELETE ROWS *****//
    function deleteRow(tableID) {

        var Mode = "<%=Mode %>";
        var id = document.getElementById("<%=hdnsavestay.ClientID %>").value;
        var hdnDeleteMsg = document.getElementById("<%=hdnDeleteMsg.ClientID %>");

        try {
            var hid_DeletedItemID = document.getElementById("<%=hid_DeletedItemID.ClientID %>");
            var table = document.getElementById(tableID);

            var rowCount = table.rows.length;
            var NewrowCount = table.rows.length - 1;

            if (tblHeaderID.rows.length == 2) {
                alert('<%=objLangClass.GetLanguageConversion("DeleteDelivertItem")%>');
            }
            else {
                if (takeCount == 0) {
                    takeCount = rowCount;
                }

                var ChkdItemsCount = 0;
                var ChkdItems = '';

                for (var i = 1; i < rowCount; i++) {
                    var row = table.rows[i];
                    var chkbox = row.cells[0].childNodes[0];
                    if (chkbox.checked) {
                        if (chkbox.value != "0") {
                            hid_DeletedItemID.value += chkbox.value + "µ";
                        }
                        ChkdItemsCount++;
                        ChkdItems += i + ",";
                    }
                }

                if (ChkdItemsCount == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                }
                else {
                    var ret = false;
                    var dltmsg = '<%=objLangClass.GetLanguageConversion("Delete_Confirmation_Common_Msg")%>'
                    ret = window.confirm(dltmsg);

                    if (ret) {
                        hdnDeleteMsg.value = "DeleteMsg";
                        ChkdItems = ChkdItems.substring(0, ChkdItems.length - 1);
                        var ChkdItemsList = ChkdItems.split(',');
                        if (ChkdItemsList.length == (rowCount - 1)) {
                            alert('<%=objLangClass.GetLanguageConversion("DeleteDelivertItem")%>');
                        }
                        else {
                            var Length = ChkdItemsList.length;
                            for (var i = Length - 1; i != -1; i--) {
                                var l = ChkdItemsList[i];
                                var row = table.rows[l];
                                var chkbox = row.cells[0].childNodes[0];
                                if (null != chkbox && true == chkbox.checked) {
                                    table.deleteRow(l);
                                }
                            }

                            if (Mode == "edit" && id != "" && hid_DeletedItemID.value.length > 1) {
                                PageMethods.DeleteDeliveryItem("<%=CompanyID %>", hid_DeletedItemID.value, "<%=DeliveryID %>", "<%=UserID %>", FindDeleteItem, ShowMsg_Failure);
                            }
                        }
                    }
                }
            }
        } catch (e) {
            alert(e);
        }
    }

    function FindDeleteItem(result) {
    }
    //*** END of Func to DELETE ROWS *****//


    function more_address(addtype) {
        var txtName = document.getElementById("<%=txtName.ClientID %>").value;
        var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
        var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
        var hid_Clientname = document.getElementById("<%=hid_Clientname.ClientID %>");
        if (txtName == "") {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else if (hid_Clientname.value != txtName) {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else {
            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
            if (addtype == "default") {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else if (addtype == "delivery") {
                window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + pg, '700', '400');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            return true;
        }
    }

    //To add new contact for that particular supplier
    function add_contact() {
        var pgmode = '<%=Type %>';
    var DeliveryID = document.getElementById("<%=hid_DeliveryID.ClientID %>").value;
    var txtName = document.getElementById("<%=txtName.ClientID %>").value;
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
    var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
    var hid_Clientname = document.getElementById("<%=hid_Clientname.ClientID %>");
    if (txtName == "") {
        ddlcontact.length = 0;
        alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else {
            if (pgmode == "edit") {
                window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?type=customer&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode + "&id=" + DeliveryID).setSize('1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else {
                window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?type=customer&IsAddMode=yes&clientid=" + hid_ClientID.value + "&pg=" + pg + "&mode=" + pgmode).setSize('1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            return true;
        }
    }

    function popup_phrasebook(type) {
        window.radopen("<%=nmsCommon.global.sitePath()%>common/phrase_book.aspx?type=" + type).setSize('1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }

    var chkcount = 0;
    function getItemValues(tableID)//(ItemID,ItemCode,ItemName,Qty,PackedIn,Price,ItemType)
    {
        hid_ItemValues.value = "";
        var table = document.getElementById(tableID);
        var rowCount = table.rows.length;
        var ItemValuesConcat = "";
        if (takeCount != 0) {
            rowCount = takeCount;
        }
        for (var i = 1; i < rowCount; i++) {
            if (document.getElementById("chk" + i) != null) {
                var tblDeliveryItemID = document.getElementById("chk" + i).value;
                var tblItemID = document.getElementById("lblItemID" + i).innerHTML;
                var tblItemType = document.getElementById("lblItemType" + i).innerHTML;
                var tblItemQty = trim12(document.getElementById("txtItemQty" + i).value);
                var tblItemDesc = document.getElementById("txtDescription" + i).value;
                var tblItemNo = document.getElementById("txtItemNo" + i).value;
                var tblItemNotes = document.getElementById("txtNotes" + i).value;
                var RowNumber = document.getElementById("hdn_Rownumber_" + i).value;

                if (tblItemType == '') {
                    tblItemType = "D";
                }
                ItemValuesConcat += "DeliveryItemID" + "«" + tblDeliveryItemID + "‡" + "ItemID" + "«" + tblItemID + "‡" +
                    "ItemType" + "«" + tblItemType + "‡" + "ItemQty" + "«" + tblItemQty + "‡" + "RowNumber" + "«" + RowNumber + "‡" +
                    "ItemNo" + "«" + tblItemNo + "‡" +
                    "ItemNotes" + "«" + tblItemNotes + "‡" +
                    "ItemDesc" + "«" + tblItemDesc + "§";
            }
        }
        hid_ItemValues.value = ItemValuesConcat;
        chkcount = 1;
    }

    var CheckFinal = false;
    function Validate_delivery() {
        CheckFinal = false;
        var DateFormat = "<%=DateFormat%>";
        //leftcol//
        if (tblHeaderID.rows.length == 1) {
            document.getElementById("spn_tblHeader").style.display = "block";
            CheckFinal = true;
        }
        var txtName = trim12(txtNameID.value);
        if (txtName == '') {
            document.getElementById("spn_txtName").style.display = "block";
            CheckFinal = true;
        }
        var ddlContact = ddlContactID.length;
        if (ddlContact == '') {
            document.getElementById("spn_ddlcontact").style.display = "block";
            CheckFinal = true;
        }
        var lblDeliveryAddress = trim12(lblDeliveryAddressID.innerHTML);
        if (lblDeliveryAddress == '') {
            document.getElementById("spn_lblDeliveryAddress").style.display = "block";
            CheckFinal = true;
        }

        //rightcol//   
        var txtDeliveryDate = trim12(txtDeliveryDateID.value);
        if (txtDeliveryDate == '') {
            document.getElementById("spn_txtDeliveryDate").style.display = "block";
            CheckFinal = true;
        }
        else {
            if (ValidateForm(txtDeliveryDateID, 'spn_txtDeliveryDate', DateFormat) == false) {
                CheckFinal = true;
            }
        }

        var ddlcontact1 = document.getElementById("<%=ddlcontact.ClientID %>");
        if (ddlcontact1.selectedIndex >= 0) {
            var selectedContactText = ddlcontact1.options[ddlcontact1.selectedIndex].text;
            if ((selectedContactText.toLowerCase().indexOf("-select-") > -1) && ddlcontact1.selectedIndex == 0 && selectedContactText == "") {
                document.getElementById("spn_ddlcontact").style.display = "block";
                CheckFinal = true;
            }
        }

        var ddlSupplier = document.getElementById("<%=ddlSupplier.ClientID %>");
        if (ServerName.toLowerCase() == "dmc" || ServerName.toLowerCase() == "dmc2") {
            if (ddlSupplier.selectedIndex == 0) {
                document.getElementById("spn_Carrier").style.display = "block";
                CheckFinal = true;
            }
            else {
                document.getElementById("spn_Carrier").style.display = "none";
            }
        }

        if (CheckFinal) {
            return false;
        }
        else {
            getItemValues('tblHeader');
            return true;
        }
    }
    var txtName = document.getElementById("<%=txtName.ClientID %>");
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
    var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
    var hid_Clientname = document.getElementById("<%=hid_Clientname.ClientID %>");

    var lbl_CompanyName = document.getElementById("<%=lbl_CompanyName.ClientID %>");


    var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
    var lblDeliveryAddress = "<%=lblDeliveryAddress.ClientID %>";
    var hid_DeliveryToClientID = document.getElementById("<%=hid_DeliveryToClientID.ClientID %>");

    var chkGoodsDelivered = document.getElementById('<%=chkGoodsDelivered.ClientID %>');
    var txtActualDeliveryDate = document.getElementById('<%=txtActualDeliveryDate.ClientID %>');
    var div_ActualDeliveryDate = document.getElementById('<%=div_ActualDeliveryDate.ClientID %>');
    var ddlsupplier = document.getElementById('<%=ddlSupplier.ClientID %>');

    function Show_DeliveryAddressDiv() {
        if (txtName.value == "") {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }
        else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            alert('<%=objLangClass.GetLanguageConversion("Customer_Select_Alert") %>');
            return false;
        }

        else {
            window.radopen(commonpath + "common/common_popup.aspx?type=moreaddress&addresstype=Delivery&mode=view&clientid=" + hid_DeliveryToClientID.value + "&pg=" + pg + "&isViewAllCompanyAddress=yes").setSize('1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return true;
        }
    }

    function SendDeliveryAddressIDandName1(CompanyName, AddressID, Address, AddressType, DeliveryTo_ClientID) {
        hid_DeliveryToClientID.value = DeliveryTo_ClientID;
        hid_DelAddressType.value = AddressType;
        document.getElementById(lblDeliveryAddress).innerHTML = trim12(Address);
        document.getElementById("<%=hid_DeliveryAddressID.ClientID %>").value = AddressID;
        lbl_CompanyName.style.display = "block";
        lbl_CompanyName.innerHTML = SpecialDecode(CompanyName);
        lbl_CompanyName.title = SpecialDecode(CompanyName);
    }


    function showActualDeliveryDate(chID) {
        var chCheck = document.getElementById(chID).checked;
        if (chCheck) {
            document.getElementById('<%=div_ActualDeliveryDate.ClientID %>').style.display = "block";
        }
        else {
            document.getElementById('<%=div_ActualDeliveryDate.ClientID %>').style.display = "none";
        }
    }

    function bindconsigneeurl() {
        var ClientID = ddlsupplier.options[ddlsupplier.selectedIndex].value;
        AutoFill.Get_Carrier_Consigneeurl(ClientID, bindurltotextbox);
    }
    function bindurltotextbox(Result) {
        document.getElementById('<%=txtconsigneeurl.ClientID%>').value = Result;
    }

</script>
<asp:Panel ID="pnlLoadOnEdit" runat="server" Visible="false">
    <script type="text/javascript">
        var str = document.getElementById("<%=hid_Del_Edit_values.ClientID %>");

        document.getElementById("img_down01").style.display = "none";
        load();
        function load() {
            debugger;
            decallowed = 2;
            var strArr1 = str.value.split('§');
            for (var i = 0; i <= strArr1.length - 1; i++) {
                var strArr2 = strArr1[i].split('‡');
                if (strArr1[i] != '') {
                    var DeliveryItemID = '';
                    var ItemID = '';
                    var ItemType = '';
                    var ItemQty = '';
                    var ItemDesc = '';
                    var ItemNo = '';
                    var ItemNotes = '';

                    for (var j = 0; j <= strArr2.length - 1; j++) {
                        var strArr3 = strArr2[j].split('«');
                        if (strArr3[0] == "DeliveryItemID") {
                            DeliveryItemID = strArr3[1];
                        }
                        else if (strArr3[0] == "ItemID") {
                            ItemID = strArr3[1];
                        }
                        else if (strArr3[0] == "ItemType") {
                            ItemType = strArr3[1];
                        }
                        else if (strArr3[0] == "ItemQty") {
                            ItemQty = strArr3[1];
                        }
                        else if (strArr3[0] == "ItemDesc") {
                            ItemDesc = SpecialDecode(strArr3[1]);
                            ItemDesc = ItemDesc.replace(/:\s*/g, ": ");
                        }
                        else if (strArr3[0] == "ItemNo") {
                            ItemNo = SpecialDecode(strArr3[1]);
                        }
                        else if (strArr3[0] == "ItemNotes") {
                            ItemNotes = SpecialDecode(strArr3[1]);
                        }
                        else if (strArr3[0] == "ItemQty") {
                            ItemQty = strArr3[1];
                        }
                    }
                    AddMoreItem(ItemID, ItemQty, ItemDesc, ItemNo, ItemNotes, ItemType);
                    var table = document.getElementById("tblHeader");
                    document.getElementById("lblItemID" + (i + 1)).innerHTML = ItemID;
                    document.getElementById("chk" + (i + 1)).value = DeliveryItemID;
                    document.getElementById("lblItemType" + (i + 1)).innerHTML = ItemType;
                }
            }
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

    </script>
</asp:Panel>
<script type="text/javascript">
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    function ShowAttachments() {
        var DeliveryID = "<%=DeliveryID %>";
        var pagetype = 'general';
        var EstimateID = "<%=EstimateID %>";
        var Radwindow_Attachment = window.radopen("<%=strSitepath %>common/common_popup.aspx?pagetype=" + pagetype + "&type=attachments&DeliveryID=" + DeliveryID + "&estid=" + EstimateID + "&pg=" + Pgtype + "");
        SetRadWindow_Ver2('Div_Attachment', 'divBackGroundNew');
        Radwindow_Attachment.setSize(1035, 555);
        Radwindow_Attachment.center();

    }
    function DeliveryNoteStatusUpdate(ddlStatusValue) {
        debugger
        // Ready for kings pop up
        var serverName = "<%=ServerName%>";
        var DeliveryStatusID = "<%=DeliveryStatusID%>";

        // if((serverName.toLowerCase() == "demo" || serverName.toLowerCase() == "dmc2") && (ddlStatusValue == DeliveryStatusID))
        if ((serverName.toLowerCase() == "dmc" || serverName.toLowerCase() == "dmc2") && (ddlStatusValue == DeliveryStatusID)) {
            ShowPopUp();
        }
        else {
            getItemValues('tblHeader');
            var DeliveryID = "<%=DeliveryID %>";
            if (DeliveryID != 0) {
                item_summary.DelPurchaseOrdStatusUpdate(CompanyID, "delivery", ddlStatusValue, DeliveryID, hid_ItemValues.value, OnSuccess);
            }
        }

    }
    //added by chethan for Carrier information update (only for DMC) TNo.13392
    function DeliveryNoteCarInfoUpdate(ddlCarInfoValue) {
        if (ServerName.toLowerCase() == "dmc" || ServerName.toLowerCase() == "dmc2") {
            var DeliveryID = "<%=DeliveryID %>";
            if (DeliveryID != 0) {
                item_summary.DelNoteCarInfoUpdate(CompanyID, "delivery", ddlCarInfoValue, DeliveryID, OnSuccessCarInfo);
            }
        }
    }
    function OnSuccessCarInfo(result) {
        if (result) {
            document.getElementById("Div_CarInfoSuccMsg").style.display = "block";
            setTimeout("Timeout()", 5000);
        }
    }
    ///end
    function OnSuccess(result) {
        if (result == true) {
            document.getElementById("Div_SuccMsg").style.display = "block";
            setTimeout("Timeout()", 5000);
        }
        else {
            alert("Status not changed due to insufficient stock");
        }
    }
    function Timeout() {
        document.getElementById("Div_SuccMsg").style.display = "none";
        document.getElementById("Div_CarInfoSuccMsg").style.display = "none";
    }

    $(document).ready(function () {
        $('#tblBody').sortable({
            helper: fixWidthHelper,
            update: function (event, ui) {

                var TotalRow = document.getElementById("tblBody").rows.length;
                var new_position = ui.item.index() + 1;
                var hdn_RowNumber;
                var j = 0;
                for (var i = 0; i < $("#tblBody tr").length - 1; i++) {
                    var ID = $("#tblBody tr")[i + 1].firstChild.attributes[0].value.split('_');
                    var index = ID[1];
                    hdn_RowNumber = document.getElementById("hdn_Rownumber_" + index);
                    hdn_RowNumber.value = j;
                    j++;
                }
            }

        }).disableSelection();

        function fixWidthHelper(e, ui) {
            ui.children().each(function () {
                $(this).width($(this).width());
            });
            return ui;
        }
    });
</script>
<asp:HiddenField ID="hid_Mode" runat="server" Value="" />
<asp:LinkButton ID="lnkSave" runat="server" OnClick="btnSave_Onclick"></asp:LinkButton>
<asp:LinkButton ID="lnkDeliveryCopy" runat="server" OnClick="lnkDeliveryCopy_OnClick"></asp:LinkButton>
<telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Alert"
    Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
    <Windows>
        <telerik:RadWindow ID="DeliveryStatus" DestroyOnClose="true" Width="350" Height="150"
            runat="server">
            <ContentTemplate>
                <div class="StatusMain">
                    <div align="center">
                        <asp:Label ID="StatusChangeNote" runat="server"><%=objLangClass.GetLanguageConversion("This_status_change_will_send_Delivery_data_to_Kings_Do_you_want_to_proceed")%></asp:Label>
                    </div>
                    <div class="StatusBtnSpace">
                    </div>
                    <div class="BtnMain" align="center">
                        <div style="float: left">
                            <div id="div_btnyes" style="display: block">
                                <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="button" OnClientClick="javascript:ReadyForKingStatusUpdate();" />
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
    function ShowPopUp() {
        var oWnd = $find("<%=DeliveryStatus.ClientID%>");
        oWnd.show();
    }

    function ReadyForKingStatusUpdate() {
        debugger

        var DeliveryStatusID = "<%=DeliveryStatusID%>";
        getItemValues('tblHeader');
        var DeliveryID = "<%=DeliveryID %>";
        if (DeliveryID != 0) {
            //item_summary.DelPurchaseOrdStatusUpdate(CompanyID, "delivery", ddlStatusValue, DeliveryID, hid_ItemValues.value, OnSuccess);
            item_summary.DelPurchaseOrdStatusUpdate(CompanyID, "delivery", DeliveryStatusID, DeliveryID, hid_ItemValues.value, OnSuccess);

        }
        var oWnd = $find("<%=DeliveryStatus.ClientID%>");
        oWnd.close();
        top.location.reload();
        return false;
    }

    function NoClick() {

        // RadWinClose1();
        var oWnd = $find("<%=DeliveryStatus.ClientID%>");
        oWnd.close();
        return false;
    }
</script>
