<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accounts_new_create.ascx.cs" Inherits="ePrint.usercontrol.Accounts.accounts_new_create" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">
    var currentdate = '<%=newdate%>';
    var Pgtype = '<%=Pgtype %>';  
</script>
<asp:ScriptManagerProxy ID="SMproxy" runat="server">
    <services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </services>
</asp:ScriptManagerProxy>
<div align="left" nowrap="nowrap" style="margin-top: -12px;">
    <asp:Label ID="lblAddCompany" runat="server" CssClass="navigatorpanel" Text="Accounts Add"
        Visible="false"></asp:Label>
</div>
<div align="left" nowrap="nowrap">
    <asp:Label ID="lblEditCompany" runat="server" CssClass="navigatorpanel" Text="Edit Company"
        Visible="false"></asp:Label>
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content">
    <div>
        <div align="center" style="width: 50%; margin-top: -12px">
            <div id="divMessage" runat="server" style="width: 100%;">
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="div_accountdetails" runat="server" align="left" class="div_accountmargin">
            <div align="left">
                <%-- Account Type --%>
                <div id="account_Type" runat="server" >
                    <div class="bglabel_accountdetails">
                        <asp:Label ID="lbl_accountType" runat="server" Text="Account Type" CssClass="normaltext"></asp:Label>
                    </div>
                    <div align="left" class="box">
                        <asp:RadioButton ID="rbtnPrivate" runat="server" Text="Private" Checked="true" GroupName="Account"
                            onclick="javascript:show_div()" />
                        <asp:RadioButton ID="rbtnPublic" runat="server" Text="Public" Checked="false" GroupName="Account"
                            onclick="javascript:hide_div()" />
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <%-- Company Name --%>
                <div id="div_companyName" runat="server" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_companyName" runat="server" Text="Company Name" CssClass="normaltext"></asp:Label>
                        <span style="color: red">*</span>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: middle" ID="ImgCustomerAdd" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Customer" />
                            <%--OnClientClick="javascript:add_new();return false;"--%>
                        </div>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_companyName" runat="server" MaxLength="250" SkinID="textPad"
                            AutoCompleteType="disabled" Width="100%" TabIndex="1">
                        </asp:TextBox>
                        <span id="spn_companyName" style="display: none; width: 170px" class="spanerrorMsg">Please enter company name</span>
                        <asp:Label ID="lblCustomerName1" runat="server" Text="" Visible="false"></asp:Label>
                        <div class="onlyEmpty">
                        </div>
                        <div id="div1" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                        </div>
                        <span id="Span1" class="spanerrorMsg" style="display: none; width: 500px;">Please select
                            Customer Name </span>
                    </div>
                    <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none">
                        <img id="img1" src="<%=strImagepath %>down01.gif" onclick="BindClientName('',event,this);"
                            style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                    </div>
                    <asp:HiddenField ID="hid_CustName" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_EstimateID" runat="server" Value="0" />
                    <asp:HiddenField ID="hid_AddressType" runat="server" Value="" />
                    <asp:HiddenField ID="hid_DelAddressType" runat="server" Value="" />
                    <asp:HiddenField ID="hid_addressID" runat="server" Value="" />
                </div>
                <div style="clear: both">
                </div>
                <%-- Account Name --%>
                <div align="left" id="div_accountName">
                    <div class="bglabel_accountdetails">
                        <asp:Label ID="lbl_accountName" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Account_Name")%> </asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_accountName" runat="server" MaxLength="250" SkinID="textPad"
                            onkeypress="javascript:return notSpecialChar(event);" Width="380px" TabIndex="2"></asp:TextBox>
                        <div style="clear: both; color: Gray; font-size: 10px">
                            (<%=objLangClass.GetLanguageConversion("Only_Number_Name_And_Hyphen_underscore")%>)
                        </div>
                        <span id="spn_accountName" style="display: none; width: 200px" class="spanerrorMsg">
                            <%=objLangClass.GetLanguageConversion("Please_Enter_Account_Name")%></span>
                        <asp:HiddenField ID="hid_accountName" runat="server" />
                        <asp:HiddenField ID="hid_accountPrefix" runat="server" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <%-- Account Prefix --%>
                <div align="left" id="div_accountPrefix" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_accountPrefix" runat="server" Text="Account Prefix" CssClass="normaltext"></asp:Label>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_accountPrefix" runat="server" MaxLength="5" SkinID="textPad"
                            Width="70px" TabIndex="3"></asp:TextBox>
                        <div style="clear: both; color: Gray; font-size: 10px">
                            (Only 5 digits)
                        </div>
                        <span id="spn_accountPrefix" style="display: none; width: 200px" class="spanerrorMsg">Please enter account prefix</span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <%-- Default Contact Name --%>
                <div align="left" id="div_defContactName" runat="server" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_def_ContactName" runat="server" Text="Main User" CssClass="normaltext"></asp:Label>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: middle" ID="ImgContact" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Add New Contact" OnClientClick="javascript:add_contact();return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box">
                        <asp:DropDownList ID="ddlcontact" CssClass="normaltext" Width="100%" runat="server"
                            onchange="GetContactID(this.value);" TabIndex="4">
                        </asp:DropDownList>
                        <span id="spn_ddlcontact" style="display: none; width: 100%" class="spanerrorMsg">Please
                            select Attention </span>
                        <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                        <asp:HiddenField ID="hid_ContactID" runat="server" Value="0" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <%-- Default Delivery Address --%>
                <div align="left" id="div_defDeliveryName" runat="server" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="lbl_def_DeliveryAddress" runat="server" Text="Default Delivery Address"
                            CssClass="normaltext"></asp:Label>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: middle" ID="ImgContactDefAdd" runat="server"
                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Delivery Address"
                                OnClientClick="javascript:more_address('default');return false;"></asp:ImageButton>
                        </div>
                    </div>
                    <div class="box">
                        <asp:TextBox ID="txt_def_DeliveryAddress" runat="server" MaxLength="250" SkinID="textPad"
                            Width="100%" ReadOnly="true" TabIndex="5" BorderStyle="None"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <%--To display accountType--%>
                <div align="left" id="div_accountType" runat="server" visible="false">
                    <div class="bglabel" style="width: 250px; margin-left: -14px">
                        <asp:Label ID="lblaccountType" runat="server" Text="Account Type" CssClass="normaltext"></asp:Label>
                    </div>
                    <div class="box">
                        <asp:Label ID="lblaccountTypeData" Height="25px" runat="server" Text="" Width="100%"></asp:Label>
                    </div>
                </div>
                <%--Email session--%>
                <div align="left" id="div_email" runat="server" style="display: none;">
                    <div class="bglabel">
                        <asp:Label ID="Label1" runat="server" Text="Email login details to the main user"
                            Height="25px" Width="100%" Style="padding-top: 5px;"></asp:Label>
                    </div>
                    <div class="box" style="margin: 5px 0px 0px 0px">
                        <asp:CheckBox ID="ckbEmail" runat="server" CssClass="normalText" Checked="false"
                            TabIndex="6" Text="" OnCheckedChanged="ckbEmail_CheckedChanged" />
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
            <%--Footer (buttons)--%>
            <div align="left" style="width: 100%; margin: 5px 0px 0px 0px">
                <div style="float: left; width: 250px">
                    &nbsp;
                </div>
                <div style="float: left;">
                    <div style="float: left">
                        <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                            Width="65px" TabIndex="7" OnClick="btncancel_Click"></asp:Button>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" Width="65px"
                            TabIndex="8" Visible="true" OnClientClick="javascript:return txtValidation();"
                            OnClick="btnsave_Click"></asp:Button>
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnmodify" runat="server" CssClass="button" TabIndex="9" Text="Save"
                            Width="65px" Visible="false" OnClick="btnmodify_Click"></asp:Button>
                        <%--OnClientClick="javascript:return ChangesInValue();"--%>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <br />
            </div>
        </div>
    </div>
</div>
<asp:Panel ID="phAccessDenite" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        alert("Current file using by some other processor.");
    </script>
</asp:Panel>
<asp:Panel ID="phB2BTab" runat="server" Visible="false">
    <script type="text/javascript" src="../../js/item/crm.js"></script>
    <script type="text/javascript" language="javascript">

        var IsB2BCreated = '<%=IsB2BCreated %>';
        var AccountNameUrl = '<%=AccountNameUrl %>';

        window.parent.LoadB2BTabNew(IsB2BCreated, AccountNameUrl);

        setTimeout("TakeOut()", 700);
        function TakeOut() {
            window.close();
        }

    </script>
</asp:Panel>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Top="15px" Left="125px" Behaviors="Close,Move,Reload, Resize" ReloadOnShow="false">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript" src="<%=strSitepath %>js/item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript">

    var companyName = document.getElementById("<%=txt_companyName.ClientID %>");
    var ddl_contact = document.getElementById("<%=ddlcontact.ClientID %>");
    var def_DeliveryAddress = document.getElementById("<%=txt_def_DeliveryAddress.ClientID %>");
    var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
    var hid_addressID = document.getElementById("<%=hid_addressID.ClientID %>");
    var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
    var div_accountType = document.getElementById("<%=div_accountType.ClientID %>");
    var lblaccountTypeData = document.getElementById("<%=lblaccountTypeData.ClientID %>");
    var txt_accountName = document.getElementById("<%=txt_accountName.ClientID %>");
    var txt_accountPrefix = document.getElementById("<%=txt_accountPrefix.ClientID %>");


    var hid_accountName = document.getElementById("<%=hid_accountName.ClientID %>");
    var hid_accountPrefix = document.getElementById("<%=hid_accountPrefix.ClientID %>");


    var CheckFinal = false;
    function add_new() {
        //PopupCenter(strSitepath + "client/client_add.aspx?type=Customer&post=accounts&mode=add", '980', '500')
        window.radopen(strSitepath + "client/client_add.aspx?type=Customer&post=accounts&mode=add", '', '1000', '500');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
        return true;

        if (CheckFinal) {
            return false;
        }
        else {
            return true;
        }
    }

    var account_editType = '<%=account_editType %>';
    var CheckFinal = false;
    function add_contact() {
        if (account_editType == "add") {
            if (companyName.value == "") {
                alert("Please select the customer to proceed");
                companyName.focus();
                return false;
            }
            if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
                alert("Please select the customer to proceed");
                companyName.focus();
                return false;
            }
            else {

                window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + hid_ClientID.value + "&pg=Customer" + "&mode=add", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                return true;
            }
        }
        else if (account_editType == "edit") {
            window.radopen(strSitepath + "contact/contact_add.aspx?type=Customer&clientid=" + '<%=clientID %>' + "&pg=Customer" + "&mode=add", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                return true;
            }
        if (CheckFinal) {
            return false;
        }
        else {
            return true;
        }
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    function GetClientNameNew(ClientID, ClientName, Contacts, AccountNo, Address) {
        Clearvalues();
        companyName.value = ClientName;
        hid_ClientID.value = ClientID;
        txt_accountName.value = ClientName;

        //*** to bind attention from clientID *****//
        var ContactName = '';
        var ContactID = '';
        ddl_contact.length = 0;
        var str_con1 = Contacts.split('^');
        var defContactID = 0;
        var defContactIDIndex = 0;
        var cnt = 0;

        for (var k = 0; k < str_con1.length; k++) {
            if (str_con1[k] != '') {
                var ContactIDName = str_con1[k].split('±');
                ContactID = ContactIDName[0];
                ContactName = trim12(ContactIDName[1]);
                ddl_contact.options.add(new Option(ContactName, ContactID, k));
                if (ContactIDName[2] == 1) {
                    defContactID = ContactIDName[0];
                    defContactIDIndex = k;
                    cnt++;
                }
            }
        }
        if (cnt == 0) {
            ddl_contact.selectedIndex = "0";
            hid_ContactID.value = ddl_contact.options[ddl_contact.selectedIndex].value;
        }
        else {
            ddl_contact.selectedIndex = defContactIDIndex;
            hid_ContactID.value = defContactID;
        }

        //*** to bind address from clientID *****//
        if (Address != '') {
            var str_add1 = Address.split('»'); //Plain1^Silk^Graphic^gfdsgbfs^test^Plain.

            for (var i = 0; i < str_add1.length; i++) {
                if (str_add1[i] != '') {
                    var AddressID = str_add1[0];
                    var Address1 = str_add1[1];
                    var LimitAddress = str_add1[2];
                    var IsDelivery = str_add1[3];
                    var AddressType = str_add1[4];

                    def_DeliveryAddress.value = Address1;
                    hid_addressID.value = AddressID;
                    hid_DelAddressType.value = 'C';
                }
            }
        }
    }

    function GetContactID(ddlval) {
        hid_ContactID.value = ddlval;
    }

    function hide_div() {
        document.getElementById("<%=div_companyName.ClientID%>").style.display = "none";
        document.getElementById("<%=div_defContactName.ClientID%>").style.display = "none";
        document.getElementById("<%=div_email.ClientID%>").style.display = "none";
        txt_accountName.focus();
    }

    function show_div() {
        document.getElementById("<%=div_companyName.ClientID%>").style.display = "block";
        document.getElementById("<%=div_defContactName.ClientID%>").style.display = "block";
        document.getElementById("<%=div_email.ClientID%>").style.display = "none";
        companyName.focus();
    }

    var CheckFinal = false;
    function txtValidation() {
        var companyName = document.getElementById("<%=txt_companyName.ClientID %>");
        var accountName = document.getElementById("<%=txt_accountName.ClientID %>");
        var accountPrefix = document.getElementById("<%=txt_accountPrefix.ClientID %>");

        CheckFinal = false;
        if (accountName.value == "" || accountName.value.trim() == "") {
            document.getElementById("spn_accountName").style.display = "block";
            CheckFinal = true;
        }

        if (CheckFinal) {
            return false;
        }
        else {
            return true;
        }
    }

    function notSpecialChar(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;

        if ((charCode >= 48 && charCode <= 57) || (charCode >= 97 && charCode <= 122) ||
            //      (charCode >= 65 && charCode <= 90) || (charCode == 45 || charCode == 95 || charCode == 32 || charCode == 8)) {
        (charCode >= 65 && charCode <= 90) || (charCode == 45 || charCode == 95 || charCode == 8)) {
            return true;
        }
        else {
            return false;
        }
    }

    function Clearvalues() {
        companyName.value = "";
        def_DeliveryAddress.value = "";
    }

    var pg = '<%=UcStageSection %>';
    var strSitepath = "<%=strSitepath %>";
    var account_editType = '<%=account_editType %>';

    function more_address(addtype) {
        if (account_editType == "add") {
            if (companyName == "") {
                alert("Please select the company name to proceed...");
                companyName.focus();
                return false;
            }
            else {

                window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + hid_ClientID.value + "&pg=" + "estimate", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                return true;
            }
        }
        else if (account_editType == "edit") {
            if (addtype == "default") {

                window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + '<%=clientID %>' + "&pg=" + "estimate", '', '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else if (addtype == "delivery") {

                window.radopen(strSitepath + "common/common_popup.aspx?type=deliveryaddress&mode=view&clientid=" + '<%=clientID %>' + "&pg=" + "estimate", '', '1000', '500');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');

                }
            return true;
        }

    if (CheckFinal) {
        return false;
    }
    else {
        return true;
    }
}

function new_contact() {

    window.radopen(strSitepath + "common/common_popup.aspx?type=newcontact&mode=add&pg=" + "estimate", '', '1000', '500');
    SetRadWindow('divrad', 'divBackGroundNew', '200');

}

function ChangesInValue() { //&& hid_accountPrefix != txt_accountPrefix
    if (hid_accountName != txt_accountName) {
        if (window.confirm("If Account name is changed it will affect all existing order's prefix for that account"))
            return true;
        else
            return false;
    }
    else {
        return false;
    }
}

function SendDeliveryAddressIDandName(id, values, isdelivery, tooltip, addresstype) {
    if (values.length != 0) {
        for (var i = 0; i < values.length; i++) {
            values = values.replace('<br/>', '');
            i++;
        }
    }
    def_DeliveryAddress.value = values;
}

function ReloadContact1(FinalContact) {
    var ContactName = '';
    var ContactID = '';
    ddl_contact.length = 0;
    var str_con1 = FinalContact.split('µ');
    for (var k = 0; k < str_con1.length; k++) {
        if (str_con1[k] != '') {
            var ContactIDName = str_con1[k].split('±');
            ContactID = ContactIDName[0];
            hid_ContactID.value = ContactIDName[0];
            ContactName = ContactIDName[1];
            ddl_contact.options.add(new Option(ContactName, ContactID, k));
            ddl_contact.selectedIndex = k;
        }
    }
}

</script>

