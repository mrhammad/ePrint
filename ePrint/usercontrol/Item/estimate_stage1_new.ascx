<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="estimate_stage1_new.ascx.cs" Inherits="ePrint.usercontrol.Item.estimate_stage1_new" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>

<script type="text/javascript">
    var UserID = '<%=UserID %>';
    var currentdate = '<%=newdate%>';
    //document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    //document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //document.getElementById("ds00").style.display = "block";        
</script>
<script type="text/javascript">
    var div_Load = document.getElementById("div_Load"); //IEB Issue, Changes Made on 07.09.2011
    setLoadingPositionOfDivMove(div_Load);
    
</script>

<script type="text/javascript">
    var ClientID = "<%=Pub_CustomerID %>";
    var ClienName = "<%=Pub_CustomerName %>";
    var DateFormat_stage = "<%=DateFormat%>";
    var Pgtype = "<%=Pgtype %>";
    var strSitepath = "<%=strSitepath %>";
    var req_type = "<%=Type %>";
    var Pgtype = "<%=Pgtype %>";
    var CompID = "<%=CompanyID %>";
    var Customer_Select_Alert = '<%=objLanguage.GetLanguageConversion("Customer_Select_Alert") %>';
    var Please_Select_Customer = '<%=objLanguage.GetLanguageConversion("Please_Select_Customer") %>';
    var Please_select_valid_Customer = '<%=objLanguage.GetLanguageConversion("Please_select_valid_Customer") %>';

    var Accountsonhold = <%=objLanguage.GetLanguageConversion("Accoutns_On_Hold") %>;

    var AccoutnsOnHoldEstimate = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Estimate") %>';
    var AccoutnsOnHoldJob = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Job") %>';
    var AccoutnsOnHoldEstimate = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Estimate") %>';
    var AccoutnsOnHoldJob = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Job") %>';

    var DateAccordingToTimeZone = "<%=strInvduedate %>";
</script>
<asp:HiddenField ID="hdn_selectedcentre" runat="server" Value="0" />
<script>
    var SelectedCostCentre = document.getElementById("<%=hdn_selectedcentre.ClientID %>").value;
</script>
<div id="divMainContent">
    <div class="navigatorpanel" style="display: none">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" id="lblheader">
                                <%=objLanguage.GetLanguageConversion("Create_Estimate")%></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="content">
        <div class="onlyEmpty">
        </div>
        <div style="width: 100%;">
            <div id="div_none" style="display: none; padding-top: 4px;" align="center">
                <div align="center" style="width: 50%; padding: 3px;">
                    <span id="span_none" class="spanerrorMsg" style="width: 100%;">Please select Estimate
                        Type from stage 2</span>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div class="div_addnewmargin">
                <div>
                    <div align="left">
                        <div id="divStage1" align="left" style="width: 100%; display: none;">
                            <div style="width: 100%; border: 2;">
                                <div id="leftcol" style="width: 50%;">
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label20" runat="server" Text='Company' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Company")%></asp:Label>
                                                <span style="color: Red;">*</span>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: middle;" ID="ImgCustomerAdd" runat="server"
                                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Customer">
                                                </asp:ImageButton>
                                            </div>
                                        </div>
                                        <div>
                                            <div style="float: left; width: 70%; max-width: 70%; padding: 4;">
                                                <asp:TextBox ID="txtName" CssClass="textboxnew_estNew" Width="99%" runat="server"
                                                    AutoCompleteType="Disabled" min-width="220px" onkeydown="javascript:button_click(event);"></asp:TextBox>
                                                <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                    padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Select_Customer")%>
                                                </span>
                                                <%--raghavendra  changes width  to 184px line no-101 18th july 2012 --%>
                                                <div class="onlyEmpty">
                                                </div>
                                                <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                                </div>
                                            </div>
                                            <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none;">
                                                <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindClientName('',event,this);"
                                                    style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                                            </div>
                                            <asp:HiddenField ID="hid_CustName" runat="server" />
                                            <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hid_EstimateID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hid_AddressType" runat="server" Value="" />
                                            <asp:HiddenField ID="hid_DelAddressType" runat="server" Value="" />
                                            <asp:HiddenField ID="hid_OldClientID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdn_IsEstoreInvoice" runat="server" />
                                            <asp:HiddenField ID="hdnStatusTitle" runat="server" Value="" />
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left">
                                                <asp:Label ID="Label1" runat="server" Text='Contact' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Contact")%></asp:Label>
                                                <span style="color: Red;">*</span>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton8" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Add New Contact" OnClientClick="javascript:add_contact();return false;">
                                                </asp:ImageButton>
                                            </div>
                                        </div>
                                        <div class="box" style="width: 70%; max-width: 70%;">
                                            <asp:DropDownList ID="ddlcontact" CssClass="normaltext" Width="99%" runat="server"
                                                onchange="GetContactID(this.value);">
                                            </asp:DropDownList>
                                            <%--raghavendra  changes width  to 184px line no-136 18th july 2012 --%>
                                            <span id="spn_ddlcontact" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                                class="spanerrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Contact")%></span>
                                            <asp:HiddenField ID="hid_ContactID" runat="server" Value="0" />
                                        </div>
                                    </div>

                                         <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left">
                                                <asp:Label ID="Label24" runat="server" Text='Contact' CssClass="normalText">Invoice Contact</asp:Label>
                                           <%--     <span style="color: Red;">*</span>--%>
                                            </div>
                                           <%-- <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton11" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Add New Contact" OnClientClick="javascript:add_contact();return false;">
                                                </asp:ImageButton>
                                            </div>--%>
                                        </div>
                                        <div class="box" style="width: 70%; max-width: 70%;">
                                            <asp:DropDownList ID="ddlinvoicecontact"  CssClass="normaltext" Width="99%" runat="server"
                                                >
                                            </asp:DropDownList>
                                            <%--raghavendra  changes width  to 184px line no-136 18th july 2012 --%>
                                           
                                        </div>
                                    </div>



                                    <div class="only5px">
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label2" runat="server" Text='Greeting' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Greeting")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="box" style="width: 70%; max-width: 70%;">
                                            <asp:TextBox ID="txtGreeting" runat="server" CssClass="textboxnew_estNew" MaxLength="50"
                                                onkeypress="javascript:notredirect(event,this.value)" onblur="validateblank(this.value,'spn_txtGreeting')"
                                                Width="99%" onkeydown="javascript:button_click(event);"></asp:TextBox>
                                            <span id="spn_txtGreeting" class="spanerrorMsg" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px">
                                                <%--raghavendra  changes width  to 184px line no-151 18th july 2012 --%>
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Greeting")%>
                                            </span>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label3" runat="server" Text='Department' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Department")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton9" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Address" OnClientClick="javascript:more_address('dept');return false;">
                                                </asp:ImageButton></div>
                                            <asp:HiddenField ID="hdnDeptNo" runat="server" Value="0" />
                                        </div>
                                        <div class="box" style="width: 70%; max-width: 70%;">
                                            <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxnew_estNew" Width="99%"
                                                MaxLength="50" onkeydown="javascript:button_click(event);"></asp:TextBox>
                                            
                                        </div>
                                        <asp:HiddenField ID="hdn_DepartmentID" runat="server" Value="false" />
                                    </div>
                                    <%--added by rakshith --%>
                                    <div id="div_costcentre" runat="server" align="left" style="display: none">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="lblcostcentre" runat="server" Text='Cost Centre' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Cost_Centre") %></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton10" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" OnClientClick="javascript:AddCostCentre();return false;"
                                                    ToolTip="Add Cost Centre"></asp:ImageButton></div>
                                            <asp:HiddenField ID="hdn_costcentreid" runat="server" Value="0" />
                                        </div>
                                        <div class="box" style="width: 70%; max-width: 70%;">
                                            <asp:DropDownList ID="ddlcostcentre" runat="server" CssClass="normalText" Width="99%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label19" runat="server" Text='Account No' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Account_No")%></asp:Label></div>
                                        <div class="box" style="padding: 5 0 5 8px; width: 200px">
                                            <asp:Label ID="lblAccountNumber" runat="server" CssClass="normalText"></asp:Label></div>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label6" runat="server" Text='Contact Address' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Contact_Address")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton5" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Address" OnClientClick="javascript:more_address('default');return false;">
                                                </asp:ImageButton></div>
                                        </div>
                                        <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden;
                                            white-space: nowrap;">
                                            <asp:Label ID="lblAddress" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer;"></asp:Label><%--Blackthorne Road, Sydney--%>
                                            
                                            <asp:HiddenField ID="hdnAddressID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hid_IsDelivery" runat="server" Value="false" />
                                            <asp:HiddenField ID="hdn_ContactAddressID" runat="server" Value="0" />
                                        </div>
                                    </div>
                                    <div align="left" id="div_DeliveryAddress">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label12" runat="server" Text='Delivery Address' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton7" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:more_address('delivery');return false;">
                                                </asp:ImageButton>
                                                <asp:HiddenField ID="hid_InvoiceAddressID" runat="server" Value="0" />
                                                <asp:HiddenField ID="hid_InvoiceAddressType" runat="server" Value="M" />
                                                <asp:HiddenField ID="hid_InvoiceAddressClientID" runat="server" Value="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden;
                                            white-space: nowrap;">
                                            <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="graytext" Width="220px"
                                                Style="cursor: pointer;"></asp:Label>
                                            <span id="spn_lblDeliveryAddress" class="spanerrorMsg" style="display: none; width: 97%;">
                                                Please select Deli. Address</span>
                                            <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value="0" />
                                        </div>
                                    </div>
                                    <div align="left" id="div_InvoiceAddress" runat="server" style="display: none;">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label21" runat="server" Text='Invoice Address' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top;" ID="ImageButton3" runat="server" CausesValidation="False"
                                                    ImageUrl="~/images/plus.gif" ToolTip="Select Invoice Address" OnClientClick="javascript:more_address('invoicenew');return false;">
                                                </asp:ImageButton></div>
                                        </div>
                                        <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden;
                                            white-space: nowrap;">
                                            <asp:Label ID="lblInvoiceAddress" runat="server" CssClass="graytext" Width="220px"
                                                Style="cursor: pointer;"></asp:Label>
                                            <span id="spn_lblInvoiceAddress" class="spanerrorMsg" style="display: none; width: 97%;">
                                                Please select Deli. Address</span>
                                            <asp:HiddenField ID="hdn_InvoiceAddressID" runat="server" Value="0" />
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left;">
                                                <asp:Label ID="Label7" runat="server" Text='Header' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Header")%></asp:Label>
                                            </div>
                                            <div style="float: right;">
                                                <asp:ImageButton Style="vertical-align: top; cursor: pointer" ID="ImageButton2" runat="server"
                                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Header"
                                                    OnClientClick="javascript:GetPhrase('Header');return false;"></asp:ImageButton>
                                            </div>
                                        </div>
                                        <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden;
                                            white-space: nowrap;">
                                            <asp:Label ID="lblHeader" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--Print Center--%>
                                            <asp:HiddenField ID="hid_HeaderID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hid_HeaderText" runat="server" Value="" />
                                            <span id="spn_lblHeader" class="spanerrorMsg" style="display: none; width: 97%;">Please
                                                select Header</span>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <div style="float: left">
                                                <asp:Label ID="Label9" runat="server" Text='Footer' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Footer")%></asp:Label>
                                            </div>
                                            <div style="float: right">
                                                <asp:ImageButton Style="vertical-align: top; cursor: pointer" ID="ImageButton6" runat="server"
                                                    CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Footer"
                                                    OnClientClick="javascript:GetPhrase('Footer');return false;"></asp:ImageButton></div>
                                        </div>
                                        <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden;
                                            white-space: nowrap;">
                                            <asp:Label ID="lblFooter" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer"></asp:Label><%--©All rights-2009--%>
                                            <asp:HiddenField ID="hid_FooterID" runat="server" Value="0" />
                                            <asp:HiddenField ID="hid_FooterText" runat="server" Value="" />
                                            <span id="spn_lblFooter" class="spanerrorMsg" style="display: none; width: 97%;">Please
                                                select Footer</span>
                                        </div>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left" id="divSalesPerson">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label10" runat="server" Text='Sales Person' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Sales_Person")%></asp:Label></div>
                                        <div class="ddlsetting" style="width: 70%; max-width: 70%">
                                            <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="99%" CssClass="normaltext"
                                                Style="display: block">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div id ="dvEstimator">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label22" runat="server" Text="Estimator" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Estimator")%></asp:Label>
                                        </div>
                                        <div class="ddlsetting" style="width: 70%; max-width: 70%">
                                            <asp:DropDownList ID="ddlEstimator" runat="server" Width="99%" CssClass="normalText"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div id="divProgressdOn" align="left" style="display: none">
                                        <div class="bglabelnew">
                                            <asp:Label ID="lblJobProgressed" runat="server" Text="Job Progressed On" CssClass="normalText"></asp:Label></div>
                                        <div class="box" style="padding: 5 0 5 8px;">
                                            <asp:Label ID="lblJobProgressedValue" runat="server" CssClass="normaltext"></asp:Label></div>
                                    </div>
                                </div>
                                <div id="rightcol" style="width: 49%">
                                    <div align="left">
                                        <div class="bglabelnew" id="dive" runat="server">
                                            <asp:Label ID="lblestimatetype" runat="server" Text='Item Type' CssClass="normalText"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddlsetting" style="width: 30%;">
                                            <asp:DropDownList ID="ddlEstimateType" Width="99%" onchange="javascript:Getddlestimatetype();MakeArrayNull();"
                                                CssClass="normalText" runat="server">
                                                <asp:ListItem Text="-- Select --" Selected="True" Value=""></asp:ListItem>
                                            </asp:DropDownList>
                                            <span id="spn_Label3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                                class="spanErrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Estimate_Type")%>
                                            </span>
                                            <%--raghavendra  changes width  to 184px line no-322 18th july 2012 --%>
                                        </div>
                                    </div>
                                    <div id="div_ProductType" style="display: none;">
                                        <div class="bglabelnew" id="divp" runat="server">
                                            <asp:Label ID="Label8" runat="server" Text='Product Type' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Product_Type")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddlsetting" style="width: 30%;">
                                            <asp:DropDownList ID="ddlProductType" onchange="javascript:MakeArrayNull();" CssClass="normalText"
                                                Width="99%" runat="server">
                                            </asp:DropDownList>
                                            <span id="spn_Label4" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                                class="spanErrorMsg">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Product_Type")%></span>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hiddenDigitalNCR" runat="server" />
                                    <div id="div_calcType" style="display: none;">
                                        <div class="bglabelnew" id="div2" runat="server">
                                            <asp:Label ID="Label16" runat="server" Text='Product Type' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Calculation_Type")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddlsetting" style="width: 30%;">
                                            <asp:DropDownList ID="ddlCalcType" onchange="javascript:MakeArrayNull();" CssClass="normalText"
                                                Width="99%" runat="server">
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label13" runat="server" Text="Estimate Title" CssClass="normalText"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        
                                        <div class="box_EstimateTitle">
                                            <div style="width: 100%;">
                                                <div style="float: left;">
                                                    <asp:TextBox ID="txtEstimateTitle" onblur="validateEstTitle(this.value)" runat="server"
                                                        SkinID="textPad" Width="360px" AutoCompleteType="Disabled" MaxLength="500"></asp:TextBox>
                                                </div>
                                                <div>
                                                    <asp:CheckBox ID="Chk_isDefaultTitle" runat="server" ToolTip="Save to Phrasebook" />
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                            </div>
                                            <span id="spn_txtEstimateTitle" class="spanerrorMsg" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px">
                                                <%=objLanguage.GetLanguageConversion("Enter_Estimate_Title")%></span>
                                        </div>
                                    </div>
                                    <div id="divJobNumInfo" style="display: none">
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lbljobNo" runat="server" CssClass="normalText"></asp:Label></div>
                                            <div class="box" style="padding: 5 0 5 8px; width: 200px">
                                                <asp:Label ID="lblJobNoValue" runat="server" CssClass="normaltext"></asp:Label></div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lblCompletionDate" runat="server" Text="Completion Date" CssClass="normalText"></asp:Label></div>
                                            <div class="box" style="padding: 5 0 5 8px; width: 200px">
                                                <asp:Label ID="lblCompletionDateValue" runat="server" CssClass="normaltext"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div align="left" id="divEstNo">
                                        <div class="bglabelnew" style="width: 30%; display: none;">
                                            <asp:Label ID="Label14" runat="server" Text="Estimate Number" CssClass="normalText"></asp:Label></div>
                                        <div class="box" style="padding: 5 0 5 8px; width: 200px; display: none;">
                                            <asp:Label ID="lblEstimateNumber" runat="server" CssClass="normaltext"></asp:Label></div>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label15" runat="server" Text='Customer Order Number' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Customer_Order_Number")%></asp:Label></div>
                                        <div class="box">
                                            <asp:TextBox ID="txtOrderNumber" onkeydown="javascript:button_click(event);" runat="server" Width="180px" SkinID="textPad" MaxLength="100"></asp:TextBox></div>
                                    </div>
                                    <div align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label17" runat="server" Text='Status' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Status")%></asp:Label>
                                            <span style="color: Red">*</span>
                                        </div>
                                        <div class="ddl">
                                            <div id="div_blank" class="ddl" style="float: left; display: none">
                                                &nbsp;</div>
                                            <div id="div_ddl" style="float: left; display: block; margin-left: -4px">
                                                <%--raghavendra  addded  margin-left:-4px line no-395 18th july 2012 --%>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="normalText" Style="display: block"
                                                    Width="180px">
                                                </asp:DropDownList>
                                                <span id="spn_ddlStatus" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Select_Status")%>
                                                    <%--raghavendra  changes width  to 184px line no-399 18th july 2012 --%>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                        <div id="div_priority" runat="server" align="left">
                                        <div class="bglabelnew">
                                            <asp:Label ID="Label25" runat="server" Text='Priority' CssClass="normalText">Priority</asp:Label>
                                            
                                        </div>
                                        <div class="ddl">
                                            <div id="div_blank" class="ddl" style="float: left; display: none">
                                                &nbsp;</div>
                                            <div id="div_ddl" style="float: left; display: block; margin-left: -4px">
                                             
                                                <asp:DropDownList ID="ddlpriority" runat="server" CssClass="normalText" Style="display: block"
                                                    Width="180px">
                                                     <asp:ListItem Text="Pending" Value="Pending" Selected="true" />
                                                        <asp:ListItem Text="1" Value="1" />
                                                        <asp:ListItem Text="2" Value="2" />
                                                        <asp:ListItem Text="3" Value="3" />
                                                        <asp:ListItem Text="4" Value="4" />
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="6" Value="6" />
                                                        <asp:ListItem Text="7" Value="7" />
                                                        <asp:ListItem Text="8" Value="8" />
                                                        <asp:ListItem Text="9" Value="9" />
                                                        <asp:ListItem Text="10" Value="10" />
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                    </div>


                                    <div class="only10px">
                                    </div>
                                    <div id="divEstiDateInfo">
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lblEstimateDate" runat="server" Text="Estimate Date" CssClass="normalText"></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" style="width: auto">
                                                <asp:TextBox ID="txtEstimateDate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                <div>
                                                    <span id="spn_txtEstimateDate" class="spanerrorMsg" style="display: none; width: auto;
                                                        padding-left: 4px; padding-right: 4px">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Date")%></span></div>
                                                <%--raghavendra  changes width  to 184px line no-414 18th july 2012 --%>
                                            </div>
                                        </div>
                                        <div class="hidejobdatecss">
                                            <div id="div_artworkdelivery" runat="server">
                                                <div align="left" id="divArtworkdelivery" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblEstimateArtwork" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtEstimateartworkDate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Select_Date")%></span>
                                                    </div>
                                                </div>
                                                <%--Only in Estimate--%>
                                                <%--Added New Dates--%>
                                                <div align="left" id="div_ProofNew" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lbl_proofdate" runat="server" CssClass="normaltext"></asp:Label></div>
                                                    <div class="box" style="width: 20%;">
                                                        <asp:TextBox ID="txtproofdate" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span id="spn_txtproofdate" class="spanerrorMsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px"></span>
                                                    </div>
                                                </div>
                                                <div align="left" id="div_ApprovalNew" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lbl_Apprvldate" runat="server" CssClass="normaltext"></asp:Label></div>
                                                    <div class="box" style="width: 20%;">
                                                        <asp:TextBox ID="txtapprovaldate" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span id="spn_txtapprovaldate" class="spanerrorMsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px"></span>
                                                    </div>
                                                </div>
                                                <div align="left" id="divProductionDate" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lbl_Prdcndate" runat="server" CssClass="normaltext"></asp:Label></div>
                                                    <div class="box" style="width: 20%;">
                                                        <asp:TextBox ID="txtproductiondate" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span id="spn_txtproductiondate" class="spanerrorMsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px"></span>
                                                    </div>
                                                </div>
                                                <div align="left" id="divJobCompletionDate" runat="server">
                                                    <div align="left">
                                                        <div class="bglabelnew">
                                                            <asp:Label ID="lbl_Complndate" runat="server" CssClass="normalText"></asp:Label>
                                                        </div>
                                                        <div class="box" style="width: 20%">
                                                            <asp:TextBox ID="txtjobcompletiondate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                            <span id="Span4" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px">Please select date</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div align="left" id="divEstimateDeliveryDate" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblEstimateDelivery" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtEstimatedeliveryDate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                             
                                            </div>
                                         
                                            <div align="left" id="div_InvoiceDueDate" style="display: none" runat="server">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="lblInvoiceDueDate" runat="server" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Invoice_DueDate") %></asp:Label>
                                                    <span style="color: Red; padding-left: 4px">*</span></div>
                                                <div class="box" style="width: auto">
                                                    <div align="left">
                                                        <asp:TextBox ID="txtInvoiceDueDate" runat="server" Width="87%" SkinID="textPad"></asp:TextBox>
                                                    </div>
                                                    <div align="left">
                                                        <span id="spn_InvoiceDueDate" class="spanerrorMsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Select_Valid_Days")%></span>
                                                    </div>
                                                    <div align="left">
                                                        <span id="spn_InvoiceDueDateMandatory" class="spanerrorMsg" style="display: none;
                                                            width: auto; padding-left: 4px; padding-right: 4px">Please enter due date</span>
                                                    </div>
                                                </div>
                                            </div>
                                                   <div align="left" id="divCustomDate1" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblCustomDate1" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtCustomDate1" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                                   <div align="left" id="divCustomDate2" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblCustomDate2" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtCustomDate2" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                                   <div align="left" id="divCustomDate3" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblCustomDate3" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtCustomDate3" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                                   <div align="left" id="divCustomDate4" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblCustomDate4" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtCustomDate4" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                                   <div align="left" id="divCustomDate5" runat="server">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblCustomDate5" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtCustomDate5" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">Please select date</span>
                                                    </div>
                                                </div>
                                            <div id="div_InvoiceNumber" runat="server" align="left" style="display: none">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="lblInvoicenumber" runat="server" CssClass="normalText"></asp:Label><%=objLanguage.GetLanguageConversion("Invoice_Number")%>
                                                </div>
                                                <div class="box" style="width: 20%">
                                                    <asp:TextBox ID="txtinvoicenumber" runat="server" CssClass="textboxnew" Width="99%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="Label18" runat="server" Text='Valid For' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Valid_For")%></asp:Label></div>
                                                <div class="box">
                                                    <div align="left">
                                                        <asp:TextBox ID="txtValidFor" runat="server" Width="50px" SkinID="textPad" MaxLength="6">30</asp:TextBox><span
                                                            class="normaltext">&nbsp;<%=objLanguage.GetLanguageConversion("Days") %></span>
                                                    </div>
                                                    <div align="left">
                                                        <span id="spn_txtValidFor" class="spanerrorMsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Select_Valid_Days")%></span>
                                                    </div>
                                                </div>
                                            </div>
                                             <div align="left" id="div_comment" style="display:none" <%--id="div_ApprovalNew"--%>>
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="Label23" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Comments")%></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%; height: 150%">
                                                        <asp:TextBox ID="txtcomments" TextMode="MultiLine" Width="150%" Height="120%" runat="server"
                                                            SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span <%--id="spn_txtapprovaldate"--%> class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div id="div_only_for_add">
                                        <div class="bglabelnew" style="visibility: hidden">
                                        </div>
                                        <div class="box">
                                            <div style="float: left;"><%--btnEditSave--%>
                                                <div id="div_next" style="display: block">
                                                    <asp:Button ID="btnNext" CssClass="button" Text='Next' Width="65px" runat="server"
                                                        OnClick="btnNext_OnClick" OnClientClick="javascript:var a=Stage1ToStage2();if(a)loadingimg('div_next','div_process');return a" /></div>
                                                <div id="div_process" class="button" align="center" style="width: 47px; display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left;">
                                                <div style="float: left;">
                                                    <asp:Button ID="btnCancel" runat="server" Visible="false" Text="Cancel" CssClass="button"
                                                        PostBackUrl="~/Estimates/estimate_view.aspx" />
                                                    <asp:HiddenField ID="hid_Stage1_values" Value="" runat="server" />
                                                </div>
                                                <div style="float: left; width: 10px;">
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="left" id="div_Estimate_btnEdit" style="display: none;">
                                        <div class="bglabelEmpty" style="width: 24%">
                                        </div>
                                        <div class="box">
                                            <div style="float: left;">
                                                <div id="div_btneditcancel" style="display: block">
                                                    <asp:Button ID="btnEditCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnEditCancel_OnClick"
                                                        OnClientClick="javascript:loadingimage(this.id,'div_btneditcancelprocess');" />
                                                </div>
                                                <div id="div_btneditcancelprocess" style="height: 15px; display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; width: 10px;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left;">
                                                <div id="div_btneditsave" style="display: block">
                                                    <asp:Button ID="btnEditSave" runat="server" Text="Save" CssClass="button" OnClick="OnClick_btnEditSave"
                                                        OnClientClick="javascript:var a= Estimate_Edit_Save();if(a)loadingimage(this.id,'div_btneditsaveprocess');return a;" />
                                                </div>
                                                <div id="div_btneditsaveprocess" style="height: 15px; display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="only10px">
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; width: 100%;">
                                <div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnldiv_only_for_add" runat="server" Visible="false">
                            <script type="text/javascript">
                                document.getElementById("div_only_for_add").style.display = "none";
                                document.getElementById("div_Estimate_btnEdit").style.display = "block";
                                  
                            </script>
                        </asp:Panel>
                        <asp:Panel ID="pnlForStage1" runat="server" Visible="false">
                            <script>
                                document.getElementById("divStage1").style.display = "block";  
                                                                      
                            </script>
                        </asp:Panel>
                    </div>
                    <div align="left">
                        <div id="divaddress" style="display: none">
                            <div id="div_deladdress" class="topbar">
                                <div align="center" class="bgcustomize" style="width: 100%; padding: 3px">
                                    <div style="float: left; width: 95%; border: 0px solid">
                                        <span id="spnDelheader" class="navigatorpanel" style="vertical-align: middle">Delivery
                                            Address</span>
                                    </div>
                                    <div style="float: right; border: 0px solid">
                                        <a href="" onclick="javascript:closebar('div_deladdress');showhideDDL('show');return false;">
                                            <img src="<%=strImagepath%>close1.jpg" border="0" /></a></div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div class="border1px" style="float: left; width: 100%; padding: 2px">
                                    <div id="divCompany" align="left" style="width: 100%; margin-bottom: 2px">
                                        <div class="bglabel">
                                            <asp:Label ID="Label11" runat="server" Text="Company" CssClass="HeaderText"></asp:Label></div>
                                        <div class="box">
                                            <asp:TextBox ID="TextBox11" runat="server" SkinID="textPad"></asp:TextBox>
                                            <asp:ImageButton Style="vertical-align: middle" ID="ImageButton4" runat="server"
                                                CausesValidation="False" ImageUrl="~/images/plus.gif" OnClientClick="javascript:more_address();return false;">
                                            </asp:ImageButton></div>
                                    </div>
                                    <div class="bglabel" style="height: 49px">
                                        <asp:Label ID="Label39" runat="server" Text="Address" CssClass="normalText"></asp:Label></div>
                                    <div style="float: left; padding-left: 3px; padding-bottom: 2px">
                                        <div style="float: left;">
                                            <asp:TextBox ID="TextBox13" runat="server" TextMode="multiLine" SkinID="textPad"
                                                Rows="3" Columns="20"></asp:TextBox>&nbsp;</div>
                                        <div style="float: left;">
                                            <asp:ImageButton Style="vertical-align: top" ID="imgViewAddress" runat="server" CausesValidation="False"
                                                ImageUrl="~/images/plus.gif" OnClientClick="javascript:more_address();return false;">
                                            </asp:ImageButton></div>
                                    </div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label40" runat="server" Text="City" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox16" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label41" runat="server" Text="State" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox27" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label42" runat="server" Text="Country" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox28" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label43" runat="server" Text="Telephone" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox29" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label44" runat="server" Text="Fax" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox30" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div class="bglabel">
                                        <asp:Label ID="Label45" runat="server" Text="Zip Code" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox31" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    <div id="divRef" style="float: left; width: 100%; margin-bottom: 2px">
                                        <div class="bglabel">
                                            <asp:Label ID="Label5" runat="server" Text="Ref/ FAO" CssClass="normalText"></asp:Label></div>
                                        <div class="box">
                                            <asp:TextBox ID="TextBox5" runat="server" SkinID="textPad"></asp:TextBox></div>
                                    </div>
                                    <div class="header" style="float: left; width: 100%">
                                        <div style="float: left; width: 42%">
                                            &nbsp;</div>
                                        <div style="float: left">
                                            <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="button" Width="65px"
                                                OnClientClick="javascript:return false;" /></div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;</div>
                                        <div style="float: left">
                                            <asp:Button ID="btncancel_address" runat="server" Text="Cancel" CssClass="button"
                                                Width="65px" OnClientClick="javascript:closebar('div_deladdress');showhideDDL('show');return false;" />
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <%-- </div>--%>
    </div>
</div>
<div style="clear: both">
</div>
<div id="div_StockAlert" style="display: none; position: absolute; z-index: 100;
    width: 35%" align="center">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                    padding-left: 1px">
                    <b>Stock Alert </b>
                    <asp:Label ID="Label4" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClick="OnClick_btnEditSave" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    Do you want the quantity to be added back to the inventory?
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnYes" Text="Yes" UseSubmitBehavior="false" CssClass="button" runat="server"
                                        OnClientClick="javascript:Save('Y');" />
                                    <asp:Button ID="btnNo" Text="No" UseSubmitBehavior="false" CssClass="button" runat="server"
                                        OnClientClick="javascript:Save('N');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="530" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<div id="div_radcostcentre" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdnReduceStockTypeForCancelled" Value="false" runat="server" />
<asp:HiddenField ID="hdnInvoiceDueDate" runat="server" Value="0" />
<asp:LinkButton ID="lnkEditSave" runat="server" Style="display: none" OnClick="OnClick_btnEditSave"></asp:LinkButton>
<script type="text/javascript" language="javascript">
    (function () {
        if (window.location.href.indexOf("invoice/invoices_add.aspx") != -1) {
            document.getElementById("div_comment").style.display = "block";
        }
        else {
            document.getElementById("div_comment").style.display = "block";
        }
    })();    var txtCustomerName = document.getElementById("<%=txtName.ClientID  %>");
    var txtName = document.getElementById("<%=txtName.ClientID %>");
    var hid_CustName = document.getElementById("<%=hid_CustName.ClientID %>");
    var hdnStatusTitle = document.getElementById("<%=hdnStatusTitle.ClientID %>");
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
    var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
    var ddlinvoicecontact = document.getElementById("<%=ddlinvoicecontact.ClientID %>");
    var txtGreeting = document.getElementById("<%=txtGreeting.ClientID %>");
    var txtCompany = document.getElementById("<%=txtCompany.ClientID %>");
    var lblAccountNumber = document.getElementById("<%=lblAccountNumber.ClientID %>");
    var txtEstimateTitle = document.getElementById("<%=txtEstimateTitle.ClientID %>");
    var txtOrderNumber = document.getElementById("<%=txtOrderNumber.ClientID %>");
    var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>");

    var ddlPriority = document.getElementById("<%=ddlpriority.ClientID %>");

    var txtValidFor = document.getElementById("<%=txtValidFor.ClientID %>");
    var lblEstimateNumber = document.getElementById("<%=lblEstimateNumber.ClientID %>");
    var ddlcostcentre = document.getElementById("<%=ddlcostcentre.ClientID %>");
    var hdn_costcentreid = document.getElementById("<%=hdn_costcentreid %>");

    var hid_IsDelivery = document.getElementById("<%=hid_IsDelivery.ClientID %>");
    var lblDeliveryAddress = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
    var hid_DeliveryAddressID = document.getElementById("<%=hid_DeliveryAddressID.ClientID %>");
    var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
    var txtEstimateDate = document.getElementById("<%=txtEstimateDate.ClientID %>");
    var txtEstimateartworkDate = document.getElementById("<%=txtEstimateartworkDate.ClientID %>");
    var txtEstimatedeliveryDate = document.getElementById("<%=txtEstimatedeliveryDate.ClientID %>");
    var txtjobcompletiondate = document.getElementById("<%=txtjobcompletiondate.ClientID %>");

    var txtCustomDate1 = document.getElementById("<%=txtCustomDate1.ClientID %>");
    var txtCustomDate2 = document.getElementById("<%=txtCustomDate2.ClientID %>");
    var txtCustomDate3 = document.getElementById("<%=txtCustomDate3.ClientID %>");
    var txtCustomDate4 = document.getElementById("<%=txtCustomDate4.ClientID %>");
    var txtCustomDate5 = document.getElementById("<%=txtCustomDate5.ClientID %>");

    var txtInvoiceDueDate = document.getElementById("<%=txtInvoiceDueDate.ClientID %>");
    var hdnInvoiceDueDate = document.getElementById("<%=hdnInvoiceDueDate.ClientID %>");


    var ddlSalesPerson = document.getElementById("<%=ddlSalesPerson.ClientID %>");
    var ddlEstimator = document.getElementById("<%=ddlEstimator.ClientID%>")
    var hid_ContactID = document.getElementById("<%=hid_ContactID.ClientID %>");
    var hid_AddressType = document.getElementById("<%=hid_AddressType.ClientID %>");
    var lblAddress = document.getElementById("<%=lblAddress.ClientID %>");
    var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");

    var hid_EstimateID = document.getElementById("<%=hid_EstimateID.ClientID %>");

    var hid_HeaderText = document.getElementById("<%=hid_HeaderText.ClientID %>");
    var hid_FooterText = document.getElementById("<%=hid_FooterText.ClientID %>");
    var hid_HeaderID = document.getElementById("<%=hid_HeaderID.ClientID %>");
    var hid_FooterID = document.getElementById("<%=hid_FooterID.ClientID %>");
    var lblHeader = document.getElementById("<%=lblHeader.ClientID %>");
    var lblFooter = document.getElementById("<%=lblFooter.ClientID %>");


    var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
    var lblDeliveryAddress = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
    var ddlProductType = document.getElementById("<%=ddlProductType.ClientID %>");
    var imgViewAddress = document.getElementById("<%=imgViewAddress.ClientID %>");

    var customer_name = document.getElementById("<%=txtName.ClientID %>");
    var pg = '<%=UcStageSection %>';
    var currentdate = '<%=newdate %>';
    var hid_Stage1_values = document.getElementById("<%=hid_Stage1_values.ClientID %>");

    ClienName = customer_name.value;

    var ArrayOtherCost = new Array();
    ArrayOtherCost.length = 0;

    var hid_InvoiceAddressID = document.getElementById("<%=hid_InvoiceAddressID.ClientID %>");
    var hid_InvoiceAddressType = document.getElementById("<%=hid_InvoiceAddressType.ClientID %>");
    var lblInvoiceAddress = document.getElementById("<%=lblInvoiceAddress.ClientID %>");
    var hid_InvoiceAddressClientID = document.getElementById("<%=hid_InvoiceAddressClientID.ClientID %>");

    var div_artworkdelivery = document.getElementById("<%=div_artworkdelivery.ClientID %>");

    var hdn_InvoiceAddressID = document.getElementById("<%=hdn_InvoiceAddressID.ClientID %>");
    var hdn_DepartmentID = document.getElementById("<%=hdn_DepartmentID.ClientID %>");
    var hdn_ContactAddressID = document.getElementById("<%=hdn_ContactAddressID.ClientID %>");
    
    
</script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/stage1_new.js?VN='<%=VersionNumber%>'">
</script>
<asp:Panel ID="panelddlestimatefromconfig" Visible="false" runat="server">
    <script>
        var DigitalSingleItem = '<%=DigitalSingleItem %>';
        var DigitalNCR = '<%=DigitalNCR %>';
        var DigitalBooklet = '<%=DigitalBooklet %>';
        var DigitalPads = '<%=DigitalPads %>';
        var OffsetSingleItem = '<%=OffsetSingleItem %>';
        var OffsetPad = '<%=OffsetPad %>';
        var OffsetNCR = '<%=OffsetNCR %>';
        var OffsetBooklet = '<%=OffsetBooklet %>';


        function Getddlestimatetype() {
            var ddd = document.getElementById("<%=ddlEstimateType.ClientID %>");
            var ddlProductType = document.getElementById("<%=ddlProductType.ClientID%>");
            if (ddd != null) {

                if (ddd.selectedIndex == '0' || ddd.options[ddd.selectedIndex].value == 'largeformat' || ddd.options[ddd.selectedIndex].value == 'printbroker' || ddd.options[ddd.selectedIndex].value == 'warehouse' || ddd.options[ddd.selectedIndex].value == 'othercost' || ddd.options[ddd.selectedIndex].value == 'pricecatalogue' || ddd.options[ddd.selectedIndex].value == 'QuickQuote' || ddd.options[ddd.selectedIndex].value == 'DeliveryCost') {
                    document.getElementById("div_ProductType").style.display = "none";
                    if (ddd.options[ddd.selectedIndex].value == 'largeformat') {
                        document.getElementById("div_calcType").style.display = "block";
                    }
                    else {
                        document.getElementById("div_calcType").style.display = "none";
                    }

                }
                else {
                    document.getElementById("div_ProductType").style.display = "block";
                    document.getElementById("<%=ddlProductType.ClientID%>").options[1].style.display = 'block';
                    document.getElementById("<%=ddlProductType.ClientID%>").options[2].style.display = 'block';
                    document.getElementById("div_calcType").style.display = "none";

                    for (var i = 0; i < ddlProductType.length; i++) {
                        ddlProductType.remove(i);
                    }
                }

                if (ddd.options[ddd.selectedIndex].value == 'SheetFedOffset') {

                    document.getElementById("div_ProductType").style.display = "block";

                    for (var i = 0; i < ddlProductType.length; i++) {
                        ddlProductType.remove(i);
                    }
                    ddlProductType.remove(0);
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Single_Item") %>', "OffsetSingleItem");
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Booklet") %>', "OffsetBooklet");
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("NCR") %>', "OffsetNCR");
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Pads") %>', "OffsetPad");
                    if (req_type == 'edit') {
                        var estimatetype = '<%=estimatetype%>';
                        if (estimatetype.toLowerCase() == 'f') {
                            ddlProductType.selectedIndex = 0;
                        }
                        if (estimatetype.toLowerCase() == 'k') {
                            ddlProductType.selectedIndex = 1;
                        }
                        if (estimatetype.toLowerCase() == 'n') {
                            ddlProductType.selectedIndex = 2;
                        }
                        if (estimatetype.toLowerCase() == 'd') {
                            ddlProductType.selectedIndex = 3;
                        }
                    }
                }
                else {

                    for (var i = 0; i < ddlProductType.length; i++) {
                        ddlProductType.remove(i);
                    }
                    var digitalNCR = document.getElementById('<%= hiddenDigitalNCR.ClientID %>').value;

                    ddlProductType.remove(0);
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Single_Item") %>', "DigitalSingleItem");
                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Booklet") %>', "DigitalBooklet");
                    //addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("NCR") %>', "DigitalNCR");
                    if (digitalNCR === null || digitalNCR === undefined || digitalNCR === '') {
                        
                    } else {
                        addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("NCR") %>', "DigitalNCR");
                    }

                    addOption(ddlProductType, '<%=objLanguage.GetLanguageConversion("Pads") %>', "DigitalPads");
                    if (req_type == 'edit') {
                        var estimatetype = '<%=estimatetype%>';
                        if (estimatetype.toLowerCase() == 's') {
                            ddlProductType.selectedIndex = 0;
                        }
                        if (estimatetype.toLowerCase() == 'b') {
                            ddlProductType.selectedIndex = 1;
                        }
                        if (estimatetype.toLowerCase() == 'r') {
                            ddlProductType.selectedIndex = 2;
                        }
                        if (estimatetype.toLowerCase() == 'p') {
                            ddlProductType.selectedIndex = 3;
                        }
                    }
                }
            }
        }
        function addOption(selectbox, text, value) {
            var optn = document.createElement("OPTION");
            optn.text = text;
            optn.value = value;
            selectbox.options.add(optn);
        }
        Getddlestimatetype();        
    
    </script>
</asp:Panel>
<style>
    #divCheck
    {
        float: left;
        position: absolute;
        display: none;
        border: solid 1px silver;
        overflow-x: hidden;
        overflow-y: scroll;
        width: 225px;
        height: 100px;
        background-color: white;
    }
    #div_list
    {
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
    .divpad
    {
        padding: 2px;
    }
</style>
<script>
    var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeNew%>';
    var InventoryManagement = '<%=InventoryManagement %>';
    var PgtypeNew = '<%=Pgtype %>';


    var hdnReduceStockTypeForCancelled = document.getElementById("<%= hdnReduceStockTypeForCancelled.ClientID%>");

    function Estimate_Edit_Save() {
        debugger
        if (hdnStatusTitle.value.toLowerCase() == "account on hold" && PgtypeNew.toLowerCase() == "estimate") {
            alert(Accountsonhold);
            return false;
        }
        if (hdnStatusTitle.value.toLowerCase() == "account on hold" && PgtypeNew.toLowerCase() == "job") {
            alert(Accountsonhold);
            return false;
        }

        if (Stage1Validation()) {
            StoreTheEstimateStage1();
            var hid_Stage1_values = document.getElementById("<%=hid_Stage1_values.ClientID %>");
            hid_Stage1_values.value = stage1_values;
            InventpryPrmpt();
            return true;
        }
        else {
            return false;
        }
    }

    function reduceStockTypeForCancelledNew11() {

        if (PgtypeNew.toLowerCase() == "job" || PgtypeNew.toLowerCase() == "invoice") {

            if (InventoryManagement.toString().toLowerCase() == "im") {

                if (ReduceStockTypeForCancelledVal.toLowerCase() == "p") {
                    if (ddlStatus.options[ddlStatus.selectedIndex].text.toLowerCase() == "cancelled") {
                        showDivPopupCenter('div_StockAlert', '200');
                        return false;
                    }
                }
            }

        }
        __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$lnkEditSave', '');
        return false;
    }
    function hideDivNew() {

        hdnReduceStockTypeForCancelled.value = "false";
        __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$lnkEditSave', '');
        return false;
    }

    function Save(val) {
        if (val == 'Y') {
            hdnReduceStockTypeForCancelled.value = "true";

            __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$lnkEditSave', '');
            return false;
        }
        else {
            hdnReduceStockTypeForCancelled.value = "false";
            __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$lnkEditSave', '');
            return false;
        }
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }


</script>
<script>
    var dddesttype = document.getElementById('<%=ddlEstimateType.ClientID %>');

    function MakeArrayNull() {
        ArrayOtherCost.length = 0;
    }

    function MakeNCRPartDisp(val) {
        if (val == "N") {
            document.getElementById("div_NCRPart").style.display = "block";
        }
        else {
            document.getElementById("div_NCRPart").style.display = "none";
        }
    }
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>
<script type="text/javascript">
    var DeliverNote = '<%=DeliveryNOte %>';

    if (DeliverNote == 'true') {

        document.getElementById("div_DeliveryAddress").style.display = "block";
    }
    else {
        document.getElementById("div_DeliveryAddress").style.display = "none";
    }

   <%-- if ('<%=serverName %>'.toLowerCase() == "maspro") {
        document.getElementById("divArtworkdelivery").style.display = "none";
    }
    else {
        document.getElementById("divArtworkdelivery").style.display = "block";
    }--%> 


    //Temporarily comments by Amin
</script>
<script>
    function CopyDelDate() {
        if (txtEstimatedeliveryDate.value != "") {
            txtjobcompletiondate.value = txtEstimatedeliveryDate.value;
        }
    }

</script>
<script>
    function Call_Address() {
        var ClientID = hid_ClientID.value;
        var pg = '<%=Pgtype %>';
        window.radopen("<%=strSitepath %>common/Common_Address_Selector.aspx?Page=" + pg + "&type=AddressSelect&clientid=" + ClientID + "");
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
    

</script>

<script>
    function button_click(event) {
        if (event.keyCode == 13) {
            document.getElementById('ctl00_ContentPlaceHolder1_UCStage1_btnNext').focus();
            document.getElementById('ctl00_ContentPlaceHolder1_UCStage1_btnNext').click();
        }
    }
    function AddCostCentre() {
        if (txtName.value == "") {
            ddlcontact.length = 0;
            alert(Customer_Select_Alert);
            return false;
        }
        else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
            alert(Customer_Select_Alert);
            return false;
        }
        else {
            var ClientID = hid_ClientID.value;
            var DepartmentID = hdn_DepartmentID.value;
            var ContactID = ddlcontact.options[ddlcontact.selectedIndex].value;
            if (txtCompany.value == "") {
                alert("Please assign a Department to contact");
                return false;
            }
            else {
                Radcostcentre = window.radopen("<%=strSitepath %>common/common_addnew_costcentre.aspx?DeptID=" + DepartmentID + "&ClientID=" + ClientID + "&ContactID=" + ContactID + " ");
                SetRadWindow_Ver2('div_radcostcentre', 'divBackGroundNew', '200');
                Radcostcentre.setSize(430, 300);
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

    function InventpryPrmpt() {
        var InventoryManagement = '<%=InventoryManagement %>';
        var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
        var ReduceStockType = '<%=ReduceStockTypeNew %>';
        if (req_type == 'edit') {
            if (InventoryManagement.toString().toLowerCase() == "im") {                     // Still to work on this case.
                if (Pgtype.toLowerCase() == "job" || Pgtype.toLowerCase() == "invoice") {
                    if (ReduceStockTypeForCancelledVal.toString().toLowerCase() == "p" && ddlStatus.options[ddlStatus.selectedIndex].text.toLowerCase() == "cancelled") {
                        if (window.confirm('Do you want the quantity to be added back to the inventory?')) {
                            hdnReduceStockTypeForCancelled.value = "true";
                        }
                        else { hdnReduceStockTypeForCancelled.value = "false"; }
                    }
                }
            }
        }
    }
</script>
