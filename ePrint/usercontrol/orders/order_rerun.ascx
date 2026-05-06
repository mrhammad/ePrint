<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="order_rerun.ascx.cs" Inherits="ePrint.usercontrol.orders.order_rerun" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/Order_rerun.js?VN='<%=VersionNumber%>'"></script>
<script>
    var Pgtype = "<%=Pgtype %>";
</script>
<div id="divMainContent">
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" id="lblheader">
                                <%=objLanguage.GetLanguageConversion("Order_Edit") %></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="content">
        <div>
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
                <div>
                    <div>
                        <div align="left">
                            <div id="divStage1" align="left" style="width: 100%; display: block;">
                                <div style="width: 100%; border: 2;">
                                    <div id="leftcol" style="width: 50%;">
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <div style="float: left;">
                                                    <asp:Label ID="Label20" runat="server" Text='Company' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Customer")%></asp:Label>
                                                </div>
                                            </div>
                                            <div>
                                                <div style="float: left; width: 70%; max-width: 70%; padding: 4;">
                                                    <asp:TextBox ID="txtName" CssClass="textboxnew_estNew" Width="99%" runat="server"
                                                        AutoCompleteType="Disabled" min-width="220px"></asp:TextBox>
                                                    <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: 184px;">Please
                                                        Select Customer </span>
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
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <div style="float: left">
                                                    <asp:Label ID="Label1" runat="server" Text='Contact' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Ordered_For")%></asp:Label>
                                                    <span style="color: Red;">*</span>
                                                </div>
                                                <div style="float: right; display: none">
                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton8" runat="server" CausesValidation="False"
                                                        ImageUrl="~/images/plus.gif" ToolTip="Add New Contact" OnClientClick="javascript:add_contact();return false;"></asp:ImageButton>
                                                </div>
                                            </div>
                                            <div class="box" style="width: 70%; max-width: 70%;">
                                                <asp:DropDownList ID="ddlcontact" CssClass="normaltext" Width="99%" runat="server"
                                                    onchange="GetContactID(this.value);">
                                                </asp:DropDownList>
                                                <span id="spn_ddlcontact" style="display: none; width: 184px;" class="spanerrorMsg">
                                                    <%=objLanguage.GetLanguageConversion("Please_Select_Attention")%></span>
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
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label4" runat="server" Text='Account No' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Ordered_By")%></asp:Label>
                                            </div>
                                            <div class="box" style="padding: 5 0 5 8px; width: 350px">
                                                <asp:Label ID="lblorderedby" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <%--removed contact email and phone by rakshith --%>
                                        <div align="left" style="display: none">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label16" runat="server" Text="Contact Email" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Contact_Email")%></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" style="width: 70%">
                                                <asp:TextBox ID="txtcontactemail" runat="server" Width="99%" MaxLength="50" SkinID="textPad"></asp:TextBox>
                                                <span id="Span_email" class="spanerrorMsg" style="display: none; width: 184px;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Email")%>
                                                </span>
                                            </div>
                                        </div>
                                        <div align="left" style="display: none">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label22" runat="server" Text="Contact Phone" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Contact_Phone")%></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" style="width: 70%">
                                                <asp:TextBox ID="txtcontactphone" runat="server" Width="99%" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                                <span id="Span_phone" class="spanerrorMsg" style="display: none; width: 184px;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Phone")%>
                                                </span>
                                            </div>
                                        </div>
                                        <%-------* - *-------%>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label2" runat="server" Text='Greeting' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Greeting")%></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" style="width: 70%; max-width: 70%;">
                                                <asp:TextBox ID="txtGreeting" runat="server" CssClass="textboxnew_estNew" MaxLength="50"
                                                    Width="99%"></asp:TextBox>
                                                <span id="spn_txtGreeting" class="spanerrorMsg" style="display: none; width: 184px;">Please Enter Greeting </span>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <div style="float: left;">
                                                    <asp:Label ID="Label3" runat="server" Text='Department' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Department")%></asp:Label>
                                                </div>
                                                <div style="float: right;">
                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton9" runat="server" CausesValidation="False"
                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Address" OnClientClick="javascript:more_address('dept');return false;"></asp:ImageButton>
                                                </div>
                                                <asp:HiddenField ID="hdnDeptNo" runat="server" Value="0" />
                                            </div>
                                            <div class="box" style="width: 70%; max-width: 70%;">
                                                <asp:TextBox ID="txtCompany" runat="server" CssClass="textboxnew_estNew" Width="99%"
                                                    MaxLength="50"></asp:TextBox>
                                            </div>
                                            <asp:HiddenField ID="hdn_DepartmentID" runat="server" Value="false" />
                                        </div>
                                        <div id="div_costcentre" runat="server" align="left" style="display: none">
                                            <div class="bglabelnew">
                                                <div style="float: left;">
                                                    <asp:Label ID="lblcostcentre" runat="server" Text='Cost Centre' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Cost_Centre")%> </asp:Label>
                                                </div>
                                                <div style="float: right;">
                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton10" runat="server" CausesValidation="False"
                                                        ImageUrl="~/images/plus.gif" OnClientClick="javascript:AddCostCentre();return false;"
                                                        ToolTip="Add Cost Centre"></asp:ImageButton>
                                                </div>
                                                <asp:HiddenField ID="hdn_costcentreid" runat="server" Value="0" />
                                            </div>
                                            <div class="box" style="width: 70%; max-width: 70%;">
                                                <asp:DropDownList ID="ddlcostcentre" runat="server" CssClass="normalText" onchange="javascript:getcostcentreid()"
                                                    Width="99%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label19" runat="server" Text='Account No' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Account_No")%></asp:Label>
                                            </div>
                                            <div class="box" style="padding: 5 0 5 8px; width: 200px">
                                                <asp:Label ID="lblAccountNumber" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <%--  <div class="only10px">
                                        </div>--%>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <div style="float: left;">
                                                    <asp:Label ID="Label6" runat="server" Text='Contact Address' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Contact_Address")%></asp:Label>
                                                </div>
                                                <div style="float: right;">
                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton5" runat="server" CausesValidation="False"
                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Address" OnClientClick="javascript:more_address('default');return false;"></asp:ImageButton>
                                                </div>
                                            </div>
                                            <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden; white-space: nowrap;">
                                                <asp:Label ID="lblAddress" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer;"></asp:Label>
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
                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Delivery Address" OnClientClick="javascript:more_address('delivery');return false;"></asp:ImageButton>
                                                    <asp:HiddenField ID="hid_InvoiceAddressID" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hid_InvoiceAddressType" runat="server" Value="M" />
                                                    <asp:HiddenField ID="hid_InvoiceAddressClientID" runat="server" Value="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden; white-space: nowrap;">
                                                <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="graytext" Width="220px"
                                                    Style="cursor: pointer;"></asp:Label>
                                                <span id="spn_lblDeliveryAddress" class="spanerrorMsg" style="display: none; width: 97%;">Please select Deli. Address</span>
                                                <asp:HiddenField ID="hid_DeliveryAddressID" runat="server" Value="0" />
                                            </div>
                                        </div>
                                        <div align="left" id="div_InvoiceAddress" runat="server" style="display: block;">
                                            <div class="bglabelnew">
                                                <div style="float: left;">
                                                    <asp:Label ID="Label21" runat="server" Text='Invoice Address' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                                </div>
                                                <div style="float: right;">
                                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton3" runat="server" CausesValidation="False"
                                                        ImageUrl="~/images/plus.gif" ToolTip="Select Invoice Address" OnClientClick="javascript:more_address('invoicenew');return false;"></asp:ImageButton>
                                                </div>
                                            </div>
                                            <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden; white-space: nowrap;">
                                                <asp:Label ID="lblInvoiceAddress" runat="server" CssClass="graytext" Width="220px"
                                                    Style="cursor: pointer;"></asp:Label>
                                                <span id="spn_lblInvoiceAddress" class="spanerrorMsg" style="display: none; width: 97%;">Please select Deli. Address</span>
                                                <asp:HiddenField ID="hdn_InvoiceAddressID" runat="server" Value="0" />
                                            </div>
                                        </div>
                                        <div id="div_headerfooter" runat="server" style="display: none">
                                            <div align="left">
                                                <div class="bglabelnew">
                                                    <div style="float: left;">
                                                        <asp:Label ID="Label7" runat="server" Text='Header' CssClass="normalText">Header</asp:Label>
                                                    </div>
                                                    <div style="float: right;">
                                                        <asp:ImageButton Style="vertical-align: top; cursor: pointer" ID="ImageButton2" runat="server"
                                                            CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Header"
                                                            OnClientClick="javascript:GetPhrase('Header');return false;"></asp:ImageButton>
                                                    </div>
                                                </div>
                                                <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden; white-space: nowrap;">
                                                    <asp:Label ID="lblHeader" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                                                    <asp:HiddenField ID="hid_HeaderID" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hid_HeaderText" runat="server" Value="" />
                                                    <span id="spn_lblHeader" class="spanerrorMsg" style="display: none; width: 97%;">Please
                                                        select Header</span>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabelnew">
                                                    <div style="float: left">
                                                        <asp:Label ID="Label9" runat="server" Text='Footer' CssClass="normalText">Footer</asp:Label>
                                                    </div>
                                                    <div style="float: right">
                                                        <asp:ImageButton Style="vertical-align: top; cursor: pointer" ID="ImageButton6" runat="server"
                                                            CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Select Footer"
                                                            OnClientClick="javascript:GetPhrase('Footer');return false;"></asp:ImageButton>
                                                    </div>
                                                </div>
                                                <div style="float: left; padding: 5 0 4 4px; width: 70%; max-width: 70%; overflow: hidden; white-space: nowrap;">
                                                    <asp:Label ID="lblFooter" runat="server" Width="200px" CssClass="graytext" Style="cursor: pointer"></asp:Label>
                                                    <asp:HiddenField ID="hid_FooterID" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hid_FooterText" runat="server" Value="" />
                                                    <span id="spn_lblFooter" class="spanerrorMsg" style="display: none; width: 97%;">Please
                                                        select Footer</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="only10px">
                                        </div>
                                        <div id="divProgressdOn" align="left" style="display: none">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lblJobProgressed" runat="server" Text="Job Progressed On" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="box" style="padding: 5 0 5 8px;">
                                                <asp:Label ID="lblJobProgressedValue" runat="server" CssClass="normaltext"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="rightcol" style="width: 49%">
                                        <div align="left" id="divSalesPerson">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label10" runat="server" Text='Sales Person' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Sales_Person")%></asp:Label>
                                            </div>
                                            <div class="ddlsetting" style="width: 71%; max-width: 71%">
                                                <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="41.8%" CssClass="normaltext"
                                                    Style="display: block">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lbltitle" runat="server" Text="Order Title" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Order_Title")%></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                            <div class="box" style="width: 33.8%; max-width: 70%">
                                                <asp:TextBox ID="txtEstimateTitle" runat="server" SkinID="textPad" Width="88%" AutoCompleteType="None"
                                                    MaxLength="70"></asp:TextBox>
                                                <span id="spn_txtEstimateTitle" class="spanerrorMsg" style="display: none; width: 184px;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Title")%>
                                                </span>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="lblstatus" runat="server" Text='Status' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Status") %></asp:Label>
                                            </div>
                                            <div>
                                                <div id="div_ddl" style="float: left; width: 36.4%; margin-left: 3px">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="textPad" CssClass="normalText"
                                                        Style="display: block" Width="82%">
                                                    </asp:DropDownList>
                                                    <span id="spn_ddlStatus" class="spanerrorMsg" style="display: none; width: 184px;">Please
                                                        Select Status </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divJobNumInfo" style="display: block">
                                            <div align="left">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="lbljobNo" runat="server" CssClass="normalText"></asp:Label><%=objLanguage.GetLanguageConversion("Order_Number")%>
                                                </div>
                                                <div class="box" style="padding: 5 0 2 3px; width: 200px">
                                                    <asp:TextBox ID="txtmainordernumber" runat="server" Width="69.10%" CssClass="textboxnew"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="div_InvoiceNumber" runat="server" align="left" style="display: none">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="Label8" runat="server" CssClass="normalText"></asp:Label><%=objLanguage.GetLanguageConversion("Invoice_Number")%>
                                                </div>
                                                <div class="box" style="padding: 5 0 2 3px; width: 200px">
                                                    <asp:TextBox ID="txtinvoicenumber" runat="server" CssClass="textboxnew" Width="69.10%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="div_jobnumber" runat="server" align="left" style="display: none">
                                                <div class="bglabelnew">
                                                    <asp:Label ID="Label23" runat="server" CssClass="normalText"></asp:Label><%=objLanguage.GetLanguageConversion("Job_Number")%>
                                                </div>
                                                <div class="box" style="padding: 5 0 2 3px; width: 200px">
                                                    <asp:TextBox ID="txtjobnumber" runat="server" CssClass="textboxnew" Width="69.10%"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div align="left" id="divEstNo">
                                            <div class="bglabelnew" style="width: 30%; display: none;">
                                                <asp:Label ID="Label14" runat="server" Text="Estimate Number" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="box" style="padding: 5 0 5 8px; width: 200px; display: none;">
                                                <asp:Label ID="lblEstimateNumber" runat="server" CssClass="normaltext"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabelnew">
                                                <asp:Label ID="Label15" runat="server" Text='Customer Order Number' CssClass="normalText"><%=objLanguage.GetLanguageConversion("Customer_Order_Number")%></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtOrderNumber" runat="server" Width="36.5%" SkinID="textPad" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="divEstiDateInfo">
                                            <div id="div_artworkdelivery" runat="server">
                                                <div align="left" id="divArtworkdelivery">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblEstimateArtwork" runat="server" CssClass="normalText"></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtOrderedDate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="Span1" class="spanerrorMsg" style="display: none; width: 175px;">Please Select
                                                            Date</span>
                                                    </div>
                                                </div>
                                                <div id="div_InvoiceDueDate" runat="server" align="left" style="display: none">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lblInvoiceDueDate" runat="server" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Invoice_DueDate") %></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%">
                                                        <asp:TextBox ID="txtInvoiceDuedate" runat="server" Width="99%" SkinID="textPad"></asp:TextBox>
                                                        <span id="spn_InvoiceDueDate" class="spanerrorMsg" style="display: none; width: 175px;">Please Enter Valid Date</span> <span id="spn_InvoiceDueDateMandatory" class="spanerrorMsg"
                                                            style="display: none; width: 175px;">Please Select Date</span>
                                                    </div>
                                                </div>
                                                <div align="left" id="div_ProofNew">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lbl_proofdate" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Delivery_Date")%></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%;">
                                                        <asp:TextBox ID="deliverydate" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span id="spn_deliverydate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                    </div>
                                                </div>


                                                <%-- start 11387 --%>

                                                <div runat="server" id="divShowHideProductionDates">



                                                    <div align="left" id="div_dateArtwork">
                                                        <div class="bglabelnew">
                                                            <asp:Label ID="lbl_dateArtwork" runat="server" CssClass="normaltext">Artwork Date</asp:Label>
                                                        </div>
                                                        <div class="box" style="width: 20%;">
                                                            <asp:TextBox ID="dateArtwork" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                            <br />
                                                            <span id="spn_dateArtwork" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                        </div>
                                                    </div>

                                                    <div align="left" id="div_dateProof">
                                                        <div class="bglabelnew">
                                                            <asp:Label ID="lbl_dateProof" runat="server" CssClass="normaltext">Proof Date</asp:Label>
                                                        </div>
                                                        <div class="box" style="width: 20%;">
                                                            <asp:TextBox ID="dateProof" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                            <br />
                                                            <span id="spn_dateProof" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                        </div>
                                                    </div>

                                                    <div align="left" id="div_dateApproval">
                                                        <div class="bglabelnew">
                                                            <asp:Label ID="lbl_dateApproval" runat="server" CssClass="normaltext">Approval Date</asp:Label>
                                                        </div>
                                                        <div class="box" style="width: 20%;">
                                                            <asp:TextBox ID="dateApproval" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                            <br />
                                                            <span id="spn_dateApproval" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                        </div>
                                                    </div>

                                                    <div align="left" id="div_dateCompletion">
                                                        <div class="bglabelnew">
                                                            <asp:Label ID="lbl_dateCompletion" runat="server" CssClass="normaltext">Completion Date</asp:Label>
                                                        </div>
                                                        <div class="box" style="width: 20%;">
                                                            <asp:TextBox ID="dateCompletion" Width="99%" runat="server" SkinID="textPad"></asp:TextBox>
                                                            <br />
                                                            <span id="spn_dateCompletion" class="spanerrorMsg" style="display: none; width: 170px"></span>
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
                                            

                                                <%-- end 11387 --%>



                                                <div align="left" id="div_ApprovalNew">
                                                    <div class="bglabelnew">
                                                        <asp:Label ID="lbl_Apprvldate" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Comments")%></asp:Label>
                                                    </div>
                                                    <div class="box" style="width: 20%; height: 150%">
                                                        <asp:TextBox ID="txtcomments" TextMode="MultiLine" Width="150%" Height="120%" runat="server"
                                                            SkinID="textPad"></asp:TextBox>
                                                        <br />
                                                        <span id="spn_txtapprovaldate" class="spanerrorMsg" style="display: none; width: 170px"></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div id="div_only_for_add">
                                                <div class="bglabelnew" style="visibility: hidden">
                                                </div>
                                                <div class="box">
                                                    <div style="float: left;">
                                                        <div style="float: left;">
                                                            <div id="btncancel" style="display: block">
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:loadingimage(this.id,'div_btncancelprocess');"
                                                                    OnClick="btncancel_onclick" CssClass="button" />
                                                            </div>
                                                            <div id="div_btncancelprocess" style="display: none">
                                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                            </div>
                                                            <asp:HiddenField ID="hid_Stage1_values" Value="" runat="server" />
                                                        </div>
                                                        <div style="float: left; width: 10px;">
                                                            &nbsp;
                                                        </div>
                                                    </div>
                                                    <div style="float: left;">
                                                        <div id="div_btnsave" style="display: block">
                                                            <asp:Button ID="btnSave" CssClass="button" Text='Save' runat="server" OnClick="btnsave_onclick"
                                                                OnClientClick="javascript:var a=validate();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                                        </div>
                                                        <div id="div_btnsaveprocess" style="display: none">
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
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
<div style="clear: both">
    </div>
    <div align="center" style="width: 800px;">
        &nbsp;
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
    <asp:HiddenField ID="hdnStatustitle" runat="server" Value="" />
    <asp:LinkButton ID="lnkEditSave" runat="server" Style="display: none"></asp:LinkButton>
    <script type="text/javascript" language="javascript">
        var Accountsonhold = <%=objLanguage.GetLanguageConversion("Accoutns_On_Hold") %>;
        var AccoutnsOnHoldOrder = '<%=objLanguage.GetLanguageConversion("Accoutns_On_Hold_Order") %>';
        var CompID = "<%=CompanyID %>";
        var strSitepath = "<%=strSitepath %>";
        var txtCustomerName = document.getElementById("<%=txtName.ClientID  %>");
        var txtName = document.getElementById("<%=txtName.ClientID %>");
        var hid_CustName = document.getElementById("<%=hid_CustName.ClientID %>");
        var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
        var ddlcontact = document.getElementById("<%=ddlcontact.ClientID %>");
        var txtGreeting = document.getElementById("<%=txtGreeting.ClientID %>");
        var txtCompany = document.getElementById("<%=txtCompany.ClientID %>");
        var lblAccountNumber = document.getElementById("<%=lblAccountNumber.ClientID %>");
        var txtEstimateTitle = document.getElementById("<%=txtEstimateTitle.ClientID %>");
        var txtOrderNumber = document.getElementById("<%=txtOrderNumber.ClientID %>");

        var lblEstimateNumber = document.getElementById("<%=lblEstimateNumber.ClientID %>");
        var ddlcostcentre = document.getElementById("<%=ddlcostcentre.ClientID %>");
        var hdn_costcentreid = document.getElementById("<%=hdn_costcentreid.ClientID %>");
        var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>");
        var hid_IsDelivery = document.getElementById("<%=hid_IsDelivery.ClientID %>");
        var lblDeliveryAddress = document.getElementById("<%=lblDeliveryAddress.ClientID %>");
        var hid_DeliveryAddressID = document.getElementById("<%=hid_DeliveryAddressID.ClientID %>");
        var hid_DelAddressType = document.getElementById("<%=hid_DelAddressType.ClientID %>");
        var txtcontactemail = document.getElementById("<%=txtcontactemail.ClientID %>");
        var txtcontactphone = document.getElementById("<%=txtcontactphone.ClientID %>");


        var ddlSalesPerson = document.getElementById("<%=ddlSalesPerson.ClientID %>");
        var ddlinvoicecontact = document.getElementById("<%=ddlinvoicecontact.ClientID %>");
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
        var hdnStatustitle = document.getElementById("<%=hdnStatustitle.ClientID %>");

        var customer_name = document.getElementById("<%=txtName.ClientID %>");
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
        var pg = '<%=UcStageSection %>';
        var req_type = '<%=req_type %>';

        var txtInvoiceDueDate = document.getElementById("<%=txtInvoiceDuedate.ClientID %>");

        var txtCustomDate1 = document.getElementById("<%=txtCustomDate1.ClientID %>");
        var txtCustomDate2 = document.getElementById("<%=txtCustomDate2.ClientID %>");
        var txtCustomDate3 = document.getElementById("<%=txtCustomDate3.ClientID %>");
        var txtCustomDate4 = document.getElementById("<%=txtCustomDate4.ClientID %>");
        var txtCustomDate5 = document.getElementById("<%=txtCustomDate5.ClientID %>");

    </script>
    <script>
        function AddCostCentre() {
            if (txtName.value == "") {
                ddlcontact.length = 0;
                alert("Please select the customer to proceed...");
                return false;
            }
            else if (hid_ClientID.value == '' || hid_ClientID.value == 0) {
                alert("Please select the customer to proceed...");
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
                    //Radcostcentre = window.radopen(strSitePath + "common/common_addnew_costcentre.aspx", '1300', '500');
                    //alert("here");
                    SetRadWindow_Ver2('div_radcostcentre', 'divBackGroundNew', '200');
                    Radcostcentre.setSize(530, 230);
                    Radcostcentre.center();
                }
            }
        }

        function getcostcentreid() {
            hdn_costcentreid.value = ddlcostcentre.options[ddlcostcentre.selectedIndex].value;
        }


        function validate() {
            var Module = "<%=Module%>";

            if (hdnStatustitle.value.toLowerCase() == "account on hold") {
                //alert(AccoutnsOnHoldOrder);
                alert(Accountsonhold);
                return false;
            }

            var DateFormat = "<%=DateFormat%>";
            if (ddlcontact.length == 0) {
                document.getElementById("spn_ddlcontact").style.display = "block";
                return false;
            }
                //            else if (document.getElementById("<%=txtcontactemail.ClientID %>").value == '') {
                //                document.getElementById("Span_email").style.display = "block";
                //                return false;
                //            }
                //            else if (document.getElementById("<%=txtcontactphone.ClientID %>").value == '') {
        //                document.getElementById("Span_phone").style.display = "block";
        //                return false;
        //            }
        else if (document.getElementById("<%=txtEstimateTitle.ClientID %>").value == '') {
            document.getElementById("spn_txtEstimateTitle").style.display = "block";
            return false;
        }
        else if (document.getElementById("<%=txtGreeting.ClientID %>").value == '') {
            document.getElementById("spn_txtGreeting").style.display = "block";
            return false;
        }

        else if (document.getElementById("<%=txtInvoiceDuedate.ClientID %>").value != '') {
                if (Module == "invoice") {
                    if (ValidateForm(txtInvoiceDueDate, 'spn_InvoiceDueDate', DateFormat) == false) {
                        return false;
                    }
                }
            }
            //            if (CheckStringMandatory(txtInvoiceDueDate.value, 'spn_InvoiceDueDateMandatory')) {
            //                return false;
            //            }
            else {
                return true;
            }
        }



    </script>
