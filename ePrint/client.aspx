<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client.aspx.cs" Inherits="ePrint.client" %>


<form id="form1" runat="server">
      <asp:Button id="btnsave" 
         runat="server" 
         onclick="btnsave_onclick" 
         Text="Save" >
       </asp:Button>
  </form>



<%--<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="ctl00_Head1">
<body id="myBody">       
        
    
 <form method="post" action="client_add.aspx?type=Customer" id="aspnetForm">




<div id="content">

    <div id="padding" class="div_spacingcrm">
        <div align="left" style="width: 100%;">
            <div id="leftcol" style="width: 49%;">
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyname" class="normaltext">Company Name</span>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">                                                

                        <asp:TextBox runat="server" maxlength="250"  ID="txt_companyname" class="textboxnew" onkeypress="javascript:return SaveFocValForMondatoryFld(event);" style="width:75%;"></asp:TextBox>

                        <span id="spn_companyname" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            Please enter company name</span>
                        
                    </div>
                    
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyalias" class="normaltext">Company Alias</span>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_companyalias" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_companyalias" class="textboxnew" onfocus="javascript:GetClientAlias()" style="width:75%;" />
                        <span id="spn_companyalias" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            Please enter Company Alias
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        
                        
                    </div>
                    <div class="box">
                        
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type" class="RadComboBox RadComboBox_Default" ClientDropDownClosing="onDropDownClosing" style="width:75%;white-space:normal;">
	<table summary="combobox" style="border-width:0;border-collapse:collapse;width:100%">
		<tr>
			<td style="width:100%;" class="rcbInputCell rcbInputCellLeft">
                <input runat="server" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type" type="text" class="rcbInput rcbEmptyMessage" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_Input" value=" None" tabindex="2" /></td>
			<td class="rcbArrowCell rcbArrowCellRight"><a id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_Arrow" style="overflow: hidden;display: block;position: relative;outline: none;">select</a></td>
		</tr>
	</table>
	<div class="rcbSlide" style="z-index:6000;"><div id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_DropDown" class="RadComboBoxDropDown RadComboBoxDropDown_Default " style="display:none;"><div class="rcbScroll rcbWidth rcbNoWrap" style="width:100%;"><ul class="rcbList" style="list-style:none;margin:0;padding:0;zoom:1;"><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i0_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i0$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i0_chk1">Care Home Provider</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i1_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i1$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i1_chk1">Couriers</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i2_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i2$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i2_chk1">Distribution and logistics</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i3_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i3$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i3_chk1">Graphic design</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i4_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i4$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i4_chk1">Manufacturing</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i5_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i5$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i5_chk1">Offset printer</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i6_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i6$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i6_chk1">Paper and consumables</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i7_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i7$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i7_chk1">Retail</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i8_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i8$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i8_chk1">University</label>
                                </div>
                            </li></ul></div></div></div><input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_ClientState" name="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_ClientState" type="hidden" />
</div>
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Carrier" align="left" style="display:none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lblcarrier" class="normaltext">Carrier</span>
                    </div>
                    <div class="box">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chkcarrier" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chkcarrier" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_status" class="normaltext">Account Status</span>
                    </div>
                    <div class="box">
                        <select runat="server" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_status" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_status" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option value="107">Account on Hold</option>
	<option selected="selected" value="106">Accounts Clear</option>
	<option value="557">COD</option>
	<option value="108">Pro Forma Account</option>

</select>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_account" class="normaltext">Account Number</span>
                        
                    </div>
                    <div class="box">                        
                        <asp:TextBox  runat="server" type="text" maxlength="20" id="txt_accountno" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;"></asp:TextBox>
                        <span id="spn_account" style="display: none; width: 170px" class="spanerrorMsg">
                            Please enter Account No
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_email" class="normaltext">Business Email</span>
                    </div>
                    <div class="box">                        
                        
                        <asp:TextBox  runat="server" type="text" maxlength="150" id="txt_email" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" ></asp:TextBox>

                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_emailValue" style="margin: 5px 0px 0px 2px; display: none;"></span>
                        
                        <span id="spn_Email" style="display: none; width: 233px" class="spanerrorMsg">
                            Please enter valid Email Address
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_url" class="normaltext">URL</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox  runat="server" type="text" maxlength="150" id="txt_url" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" ></asp:TextBox>

                        <span id="lbl_urlValue" style="margin: 5px 0px 0px 2px; display: none;"></span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_defaultinv" class="normaltext">Default Invoice Address</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chk_defaultinvoiceaddress" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chk_defaultinvoiceaddress" />
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddress1" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_defaultdel" class="normaltext">Default Delivery Address</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chk_defaultdeliveryaddress" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chk_defaultdeliveryaddress" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_credit" class="normaltext">Credit Limit</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox runat="server"  name="txt_creditlimit" type="text" maxlength="20" id="txt_creditlimit" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_creditref" class="normaltext">Credit Reference</span>
                    </div>
                    <div class="box">
                        
                        <asp:TextBox runat="server" name="txt_creditref" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_creditref" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" ></asp:TextBox>
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_tax1" class="normaltext">Tax</span>
                    </div>
                    <div class="box">
                        <asp:DropDownList runat="server" ID="ddl_tax1">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>5%</asp:ListItem>                                    
                        </asp:DropDownList>
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>

                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Tax2" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_tax2" class="normaltext">Tax2</span>
                    </div>
                    <div class="box">
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_tax2" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_tax2" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option value="1948">5 %</option>
	<option value="1939">BTW</option>
	<option value="243">GST</option>
	<option value="1949">UK VAT</option>
	<option value="1941">VAT</option>
	<option value="1942">VAT 0%</option>
	<option value="1937">VAT 23%</option>
	<option value="1940">Zero Rated</option>

</select>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddressView" style="display: none;">
                    <div id="div_DeliveryAddressHeader" style="display: block; float: left;" class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryAddress">Delivery Address</span>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverycountryValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryphoneValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryfaxValue"></span>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <a onclick="javascript:opencontacts('deliveryaddress','edit');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryEdit" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_DeliveryEdit','')">Edit</a>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverySpliter">| </span>
                            </div>
                            <div style="float: left;">
                                <a onclick="javascript:opencontacts('deliveryaddress','change');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryChange" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_DeliveryChange','')">Change/New Address</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_InvoiceAddressView" style="display: none;">
                    <div id="div_InvoiceAddressHeader" style="display: block; float: left;" class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoiceAddress">Invoice Address</span>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr1Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr2Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr3Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr4Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr5Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicecountryValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicephoneValue"></span>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicefaxValue"></span>
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <a onclick="javascript:opencontacts('invoiceaddress','edit');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceEdit" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_InvoiceEdit','')">Edit</a>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoiceSpliter">| </span>
                            </div>
                            <div style="float: left;">
                                <a onclick="javascript:opencontacts('invoiceaddress','change');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceChange" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_InvoiceChange','')">Change/New Address</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="rightcol" style="width: 49%;">
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_terms" class="normaltext">Payment Terms</span>
                    </div>
                    <div class="box">
                        
                        <asp:DropDownList runat="server" ID="ddl_PaymentTerms">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>30 Days</asp:ListItem>                                    
                        </asp:DropDownList>                           
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_profit" class="normaltext">Profit Margin</span>
                    </div>
                    <div class="box">                        

                        <asp:TextBox runat="server" type="text" maxlength="8" id="txt_profitmargin" class="textboxnew" onkeypress="javascript:return onlyNumbers(event);" onblur="javascript:todecimal_function(this,this.value);" style="width:20%;text-align: right" ></asp:TextBox>
                        
                        <span>%</span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_taxno" class="normaltext">Tax Reg No</span>
                    </div>
                    <div class="box">                        

                        <asp:TextBox runat="server" type="text" maxlength="20" id="txt_taxregno" class="textboxnew" style="width:75%;"></asp:TextBox>

                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyno" class="normaltext">Company Number</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox runat="server" type="text" maxlength="20" id="txt_companyno" class="textboxnew" style="width:75%;"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_acopened" class="normaltext">A/C Opened</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox runat="server" name="txt_acopened" type="text" value="22/03/2016" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_acopened" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" onClick="javascript: event.cancelBubble = true; this.select(); lcs(this, 'dd/mm/yyyy');" style="width:75%;" ></asp:TextBox>

                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_code" class="normaltext">Bank Code</span>
                    </div>
                    <div class="box">
                         <asp:TextBox runat="server" type="text" maxlength="20" id="txt_bankcode" class="textboxnew" style="width:75%;"></asp:TextBox>

                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_bankacno" class="normaltext">Bank Account Number</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox runat="server" type="text" maxlength="20" id="txt_bankacno" class="textboxnew" style="width:75%;"></asp:TextBox>

                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_acname" class="normaltext">Account Name</span>
                    </div>
                    <div class="box">                        
                        <asp:TextBox runat="server" type="text" maxlength="20" id="txt_accountname" class="textboxnew" style="width:75%;"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label15" class="normaltext">Sales Person</span>
                    </div>
                    <div class="box">                        

                                <asp:DropDownList runat="server" ID="ddl_salesperson">
                                    <asp:ListItem>None</asp:ListItem>
                                    <asp:ListItem>Angela</asp:ListItem>                                    
                                </asp:DropDownList>

                    </div>
                </div>
                <div id="Div_Referencedby" align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby">Referred By</span>
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_DivImgRefferedByAdd" style="float: right">
                            <input type="image" name="ctl00$ContentPlaceHolder1$ClientAddID$ImgRefferedByAdd" id="ctl00_ContentPlaceHolder1_ClientAddID_ImgRefferedByAdd" title="Add New" src="../images/plus.gif" onclick="javascript: OpenNewReffered(); return false;" style="border-width:0px;vertical-align: middle" />
                        </div>
                    </div>
                    <div class="box">
                        
                                <asp:DropDownList runat="server" ID="ddl_Referencedby">
                                    <asp:ListItem>None</asp:ListItem>
                                    <asp:ListItem>Angela</asp:ListItem>                                    
                                </asp:DropDownList>
                        
                        <span id="spn_Referencedby" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">This is a required field</span>
                        <input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_Referencedby" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_Referencedby" />
                        <div id="divCheck" onmouseover="ShowName('divCheck');" onmouseout="NotShowName('divCheck');">
                        </div>
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Supplier" align="left" style="display:none;">
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label2" class="normaltext">Tax Number</span>
                        </div>
                        <div class="box">
                            <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_taxnumber" type="text" maxlength="200" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_taxnumber" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label3" class="normaltext">Balance</span>
                        </div>
                        <div class="box">
                            <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_balance" type="text" maxlength="200" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_balance" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        </div>
                    </div>
                    
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_create_identical_contact" align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label4" class="normaltext">Create Identical Contact</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_Chkcreate_identical_contact" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$Chkcreate_identical_contact" />
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_DivChkRoyalityFree" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label5" class="normaltext">Royality Free</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_ChkRoyalityFree" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ChkRoyalityFree" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; margin: 0px 0px 0px 0px;">
                <div style="width: 50%; margin: 15px 0px 5px 0px;">
                    <div style="padding-left: 5px;">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_AddressHeader" class="headerText">Address</span>
                    </div>
                </div>
                <div id="div_CompanyAddressAdd" style="float: left; width: 100%;">
                    <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddress" style="float: left; width: 49%; display: block;">
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1" class="normaltext">Street 1</span>
                                
                            </div>
                            <div class="box">                                

                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryaddr1" class="textboxnew" style="width:75%;"></asp:TextBox>
                                
                                <span id="spn_addr1" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 1</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2" class="normaltext">Street 2</span>
                            </div>
                            <div class="box">
                                
                                
                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryaddr2" class="textboxnew" style="width:75%;"></asp:TextBox>

                                <span id="spn_addr2" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 2</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3" class="normaltext">City</span>
                            </div>
                            <div class="box">                                
                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryaddr3" class="textboxnew" style="width:75%;"></asp:TextBox>

                                <span id="spn_addr3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 3</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4" class="normaltext">State</span>
                            </div>
                            <div class="box">                                

                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryaddr4" class="textboxnew" style="width:75%;"></asp:TextBox>

                                <span id="spn_addr4" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 4</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5" class="normaltext">Postcode</span>
                            </div>
                            <div class="box">                                

                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryaddr5" class="textboxnew" style="width:75%;"></asp:TextBox>

                                <span id="spn_addr5" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 5</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliverycountry" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliverycountry" class="normaltext">Country</span>
                            </div>
                            <div class="box">
                                <asp:DropDownList runat="server" ID="ddl_Deliverycountry">
                                    <asp:ListItem>Australia</asp:ListItem>
                                    <asp:ListItem>United Kingdom</asp:ListItem>                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliveryphone" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone" class="normaltext">Telephone</span>
                            </div>
                            <div class="box">                                

                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryphone" class="textboxnew" style="width:75%;"></asp:TextBox>

                                <span id="spn_Deliveryphone" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">This is a required field</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliveryfax" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryfax" class="normaltext" MaxLength="100">Fax</span>
                            </div>
                            <div class="box">                                
                                <asp:TextBox runat="server" type="text" maxlength="250" id="txt_Deliveryfax" class="textboxnew" style="width:75%;"></asp:TextBox>

                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_edit_changeDelivery" align="left" style="display: none;">
                            <div class="bglabel" style="background-color: White;">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label1" class="normaltext"></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Description" style="float: right; width: 49%; padding: 0px 0px 0px 0px;">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc" class="normaltext">Description</span>&nbsp;
                        </div>
                        <div class="box">
                            <textarea name="ctl00$ContentPlaceHolder1$ClientAddID$txt_description" rows="2" cols="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_description" class="textboxnew" style="height:155px;width:100%;"></textarea>
                            <span id="spn_description" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                class="spanerrorMsg">This is a required field</span>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="only5px">
        </div>
        <div align="left" style="width: 100%;">
            <div style="float: left; width: 66%">
                &nbsp;
            </div>
            <div style="float: left;">
                <div id="div_btnCancel" style="float: left">
                    <div id="div_btncnl" style="display: block">
                        <input type="submit" name="ctl00$ContentPlaceHolder1$ClientAddID$btncancel" value="Cancel" onclick="javascript: loadingimage(this.id, 'div_btncancelprocess');" id="ctl00_ContentPlaceHolder1_ClientAddID_btncancel" tabindex="1" class="button" />
                    </div>
                    <div id="div_btncancelprocess" style="display: none">
                        <img src="https://demo.eprintsoftware.com/images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_Divdiv_btnsave" style="float: left">
                    <div id="div_btnsave" style="display: block">
                        <input type="submit" name="ctl00$ContentPlaceHolder1$ClientAddID$btnsave" value="Save" onclick="javascript: EmailValidate(); var b = Validate(); if (b) loadingimage(this.id, 'div_btnsaveprocess'); return b;" id="ctl00_ContentPlaceHolder1_ClientAddID_btnsave" class="button" />
                    </div>
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="https://demo.eprintsoftware.com/images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
        
</form>    
</body>
</html>--%>
