<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="quickquote_items_subitem.ascx.cs" Inherits="ePrint.usercontrol.Item.quickquote_items_subitem" %>

<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<div id="divMainContent">
    <div class="navigatorpanel">
    </div>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/quickquote.js?VN='<%=VersionNumber%>'"></script>
    <div id="content">
        <div>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" cellpadding="1" cellspacing="1">
                            <tr>
                                <td>
                                    <div align="left" style="display: block;">
                                        <div class="bglabel" style="width: 180px">
                                            <asp:Label ID="label10" runat="server" Text="Item Title" CssClass="normaltext"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="box" style="float: left;">
                                            <asp:TextBox ID="txtitemtitle" SkinID="textpad" Width="260px" runat="server" MaxLength="75"
                                                onblur="CallonBlur(this.value,'spn_txtItemTitle');"></asp:TextBox>
                                            <span id="spn_txtItemTitle" class="spanerrorMsg" style="display: none; width: auto;
                                                float: right; margin-right: 400px; padding-left: 4px; padding-right: 4px;margin-top:0px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Item_Title") %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" id="div_description" runat="server" visible="false">
                                        <div class="bglabel" style="width: 180px; height: 36px">
                                            <asp:Label ID="label6" runat="server" Text="Item Description" CssClass="normaltext"></asp:Label>
                                        </div>
                                        <div class="box" style="float: left;">
                                            <asp:TextBox ID="txtdescription" SkinID="textpad" Width="365px" TextMode="MultiLine"
                                                runat="server" MaxLength="70"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left">
                                        <div class="bglabel" style="height: 35px; border: 0px solid blue; width: 180px;">
                                            <div id="div_FinishedQty" style="float: left; border: 0px solid;">
                                                <%=objLanguage.GetLanguageConversion("Quantity")%><span style="color: Red"> *</span>
                                            </div>
                                            <div id="divhrefQtyMore" style="float: right; vertical-align: bottom; border: 0px solid red;">
                                                <a id="hrefQtyMore" href='#' onclick="javascript:moreQty('more');return false;" style="display: block;">
                                                </a><a id="hrefQtySingle" href='#' onclick="javascript:moreQty('single');return false;"
                                                    style="display: none;"></a>
                                                <asp:HiddenField ID="hid_QtyType" Value="S" runat="server" />
                                                <asp:HiddenField ID="hid_Q1" Value="0" runat="server" />
                                                <asp:HiddenField ID="hid_Q2" Value="0" runat="server" />
                                                <asp:HiddenField ID="hid_Q3" Value="0" runat="server" />
                                                <asp:HiddenField ID="hid_Q4" Value="0" runat="server" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 1px; border: 0px solid">
                                        </div>
                                        <div>
                                            <div style="float: left; width: auto">
                                                <div class="box" style="float: left; width: 92px; border: 0px solid red; vertical-align: top;">
                                                    <%=objLanguage.GetLanguageConversion("Qty1")%><br />
                                                    <asp:TextBox ID="txtQuantity" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);chkspace(this,this.value);"
                                                        runat="server" MaxLength="8" onkeyup="javascript:ToInteger(this,this.value);"></asp:TextBox>                                                   
                                                </div>
                                                <div class="box" id="div_Addmore" style="float: left; /*display: none;*/ width: 92px;
                                                    border: 0px solid red; white-space: nowrap;" nowrap="nowrap">
                                                    <%=objLanguage.GetLanguageConversion("Qty2")%><br />
                                                    <asp:TextBox ID="txtQuantity_2" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);chkspace(this,this.value);"
                                                        runat="server" MaxLength="8" onkeyup="javascript:ToInteger(this,this.value);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="div_Qty_2to4" style="/*display: none;*/ border: 0px solid; float: left; width: 200px">
                                                <div align="left" style="border: 0px solid">
                                                    <div class="box" style="float: left; width: 95px; border: 0px solid">
                                                        <%=objLanguage.GetLanguageConversion("Qty3")%><br />
                                                        <asp:TextBox ID="txtQuantity_3" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);chkspace(this,this.value);"
                                                            runat="server" MaxLength="8" onkeyup="javascript:ToInteger(this,this.value);"></asp:TextBox>
                                                    </div>
                                                    <div class="box" style="float: left; width: 92px; border: 0px solid">
                                                        <%=objLanguage.GetLanguageConversion("Qty4")%><br />
                                                        <asp:TextBox ID="txtQuantity_4" Width="75px" SkinID="textPad" onblur="AllowNumber(this,this.value);chkspace(this,this.value);"
                                                            runat="server" MaxLength="8" onkeyup="javascript:ToInteger(this,this.value);"></asp:TextBox>
                                                    </div>
                                                    <div id="div_qty_3to4" style="float: left; border: 0px solid">
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <span id="spn_txtQuantity" class="spanerrormsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px; margin-top: 13px; <%=qtystyle %>">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span>
                                            </div>
                                            <div>
                                                 <span id="spn_txtQuantity_number" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px; margin-top: 13px; <%=qtystyle %>">
                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Quantity") %></span>
                                            </div>
                                        </div>
                                    </div>                                  
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" style="display: block; width: 100%; border: 0px solid">
                                        <div class="bglabel" style="float: left; width: 180px">
                                            <asp:Label ID="label1" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Cost") %></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="estquickquotemargin">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtcost" SkinID="textpad" Width="75px" onblur="javascript:getcost();return false;"
                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <div id="divcost" <%--style="display: none;"--%>>
                                                            <table>
                                                                <tr>
                                                                    <td width="10px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtcost1" SkinID="textpad" Width="75px" onblur="javascript:getcost();return false;"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtcost2" SkinID="textpad" Width="75px" onblur="javascript:getcost();return false;"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtcost3" SkinID="textpad" Width="75px" onblur="javascript:getcost();return false;"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <span id="spn_itemcost" class="spanerrormsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Cost") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" style="display: block;">
                                        <div class="bglabel" style="width: 180px">
                                            <div style="float: left">
                                                <asp:Label ID="label2" runat="server" Text="Profit Margin" CssClass="normaltext"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                            <div style="float: right;">
                                                <asp:DropDownList ID="ddlprofitmargin" Width="50px" onchange="javascript:getcost();"
                                                    runat="server" CssClass="normalText">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="estquickquotemargin">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtproftimarge" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                            MaxLength="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <div id="divprofitmargin" <%--style="display: none"--%>>
                                                            <table>
                                                                <tr>
                                                                    <td width="10px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtproftimarge1" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtproftimarge2" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtproftimarge3" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <span id="spn_profitmargin" class="spanerrormsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Profit_Margin") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" style="display: block;">
                                        <div class="bglabel" style="width: 180px">
                                            <asp:Label ID="label3" runat="server" Text="Sub Total" CssClass="normaltext"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="estquickquotemargin">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtsubtotal" SkinID="textpad" onblur="javascript:getsubtotal();"
                                                            Width="75px" runat="server" MaxLength="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <div id="divsubtotal" <%--style="display: none"--%>>
                                                            <table>
                                                                <tr>
                                                                    <td width="10px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsubtotal1" SkinID="textpad" onblur="javascript:getsubtotal();"
                                                                            Width="75px" runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsubtotal2" SkinID="textpad" onblur="javascript:getsubtotal();"
                                                                            Width="75px" runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsubtotal3" SkinID="textpad" onblur="javascript:getsubtotal();"
                                                                            Width="75px" runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <span id="spn_subtotal" class="spanerrormsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_SubTotal") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" style="display: block;">
                                        <div class="bglabel" style="width: 180px">
                                            <div style="float: left;">
                                                <asp:Label ID="label4" runat="server" Text="Tax" CssClass="normaltext"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                            <div style="float: right;">
                                                <asp:DropDownList ID="ddltax" Width="50px" runat="server" onchange="javascript:gettaxvalue(this.value);"
                                                    CssClass="normalText">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="estquickquotemargin">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="lbltax" SkinID="textpad" ReadOnly="true" Width="75px" runat="server"
                                                            MaxLength="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <div id="divtax" <%--style="display: none"--%>>
                                                            <table>
                                                                <tr>
                                                                    <td width="10px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="lbltax1" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="lbltax2" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="lbltax3" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                                            MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <span id="spn_tax" class="spanerrormsg" style="display: none; width: auto; padding-left: 4px;
                                                            padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Tax") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" style="display: block;">
                                        <div class="bglabel" style="width: 180px">
                                            <asp:Label ID="label5" runat="server" Text="Selling Price" CssClass="normaltext"></asp:Label>
                                            <span style="color: red">*</span>
                                        </div>
                                        <div class="estquickquotemargin">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtsellingprice" ReadOnly="true" SkinID="textpad" Width="75px" runat="server"
                                                            MaxLength="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <div id="divselling" <%--style="display: none"--%>>
                                                            <table>
                                                                <tr>
                                                                    <td width="10px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsellingprice1" ReadOnly="true" SkinID="textpad" Width="75px"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsellingprice2" ReadOnly="true" SkinID="textpad" Width="75px"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                    <td width="15px">
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtsellingprice3" ReadOnly="true" SkinID="textpad" Width="75px"
                                                                            runat="server" MaxLength="70"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <span id="spn_sellingprice" class="spanerrormsg" style="display: none; width: auto;
                                                            padding-left: 4px; padding-right: 4px">
                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Selling_Price") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 0px solid red;">
                                    <div align="left" id="Div_ItemDescn" runat="server" visible="false">
                                        <div class="bglabelnewLarge" style="float: left; width: 180px;">
                                            <asp:Label ID="Label7" runat="server" Text="Update Item Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_Description") %></asp:Label>
                                            <a id="img_UpdateDescription" runat="server" href="javascript:void(0);" cssclass="tooltip"
                                                title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                                                <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                                                    style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                    cssclass="tooltip" title="Untick this box if you want the item description fields not to be overwritten during the rerun process." /></a>
                                        </div>
                                        <div class="box" style="float: left;">
                                            <div id="div2" align="left">
                                                <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="false" />
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="left" id="Div_Productcatalogue" runat="server" visible="false">
                                        <div class="bglabelnewLarge" style="float: left; width: 180px;">
                                            <asp:Label ID="Label17" runat="server" Text="Product Catalogue" CssClass="normaltext"></asp:Label>
                                            <a href="javascript:void(0);" class="tooltip" title="Quantity may be Updated/added">
                                                <img alt="" id="Img1" src="../../images/Help-icon.png" runat="server" style="cursor: pointer;
                                                    width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                    class="tooltip" /></a>
                                        </div>
                                        <div class="box" style="float: left;">
                                            <div id="div3" align="left">
                                                <asp:CheckBox ID="chkPoduct1" runat="server" Checked="true" Text="Update Product Info/Price"
                                                    onclick="javascript:OnChkchanged1();" />
                                                <asp:CheckBox ID="chkPoduct2" runat="server" Text="Delete and Recreate" onclick="javascript:OnChkchanged2();" />
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align="left" runat="server" id="div_AccountCode">
                            <div class="bglabel" style="width: 15%">
                                <asp:Label ID="lblAccountCode" runat="server" Text="Accounting Code" CssClass="normalText"></asp:Label></div>
                            <div class="ddlsetting" style="padding-left: 5px">
                                <asp:DropDownList ID="ddlAccountCode" runat="server" Width="260px">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td width="42%">
                                </td>
                                <td>
                                    <div id="div_btncancel" style="display: block">
                                        <asp:Button ID="btncancel" CssClass="button" OnClick="btnprevious_onclick" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');"
                                            runat="server" Text="Previous" />
                                    </div>
                                    <div id="div_cancelprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                                <td>
                                    <div id="div_btnprint" runat="server" style="display: block">
                                        
                                        <asp:Button ID="btnprintemail" CssClass="button" runat="server" Text="Save" OnClick="btnsave_OnClick"
                                             OnClientClick="javascript:var a=check_Validation(); if(a) loadingimage(this.id,'div_btnprintprocess'); return a;" />
                                    </div>
                                    <div id="div_btnprintprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                                <td>
                                    <%--<div id="div_btnsave" style="display: block">
                                        OnClick="btsave_onclick"
                                        <asp:Button ID="btnsave" CssClass="button" runat="server" 
                                            Text="Finish" OnClientClick="javascript:var a=check_Validation();if(a) loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                    </div>--%>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdntaxvalue" runat="server" />
<asp:HiddenField ID="hid_quickquoteID" runat="server" />
<script type="text/javascript">

    var IsQtyDisabled = false;
    var hid_QtyType = "M";
    var div_Qty2to4 = "div_Qty_2to4";
    var QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");
    var hid_QtyType = document.getElementById("<%=hid_QtyType.ClientID %>");
    var txtQuantity = document.getElementById("<%=txtQuantity.ClientID %>");

    var lbltax = document.getElementById("<%=lbltax.ClientID%>");
    var lbltax1 = document.getElementById("<%=lbltax1.ClientID%>");
    var lbltax2 = document.getElementById("<%=lbltax2.ClientID%>");
    var lbltax3 = document.getElementById("<%=lbltax3.ClientID%>");

    var txtQuantity = document.getElementById("<%=txtQuantity.ClientID%>");
    var txtQuantity_2 = document.getElementById("<%=txtQuantity_2.ClientID%>");
    var txtQuantity_3 = document.getElementById("<%=txtQuantity_3.ClientID%>");
    var txtQuantity_4 = document.getElementById("<%=txtQuantity_4.ClientID%>");

    var txtproftimarge = document.getElementById("<%=txtproftimarge.ClientID%>");
    var txtproftimarge1 = document.getElementById("<%=txtproftimarge1.ClientID%>");
    var txtproftimarge2 = document.getElementById("<%=txtproftimarge2.ClientID%>");
    var txtproftimarge3 = document.getElementById("<%=txtproftimarge3.ClientID%>");

    var txtsubtotal = document.getElementById("<%=txtsubtotal.ClientID%>");
    var txtsubtotal1 = document.getElementById("<%=txtsubtotal1.ClientID%>");
    var txtsubtotal2 = document.getElementById("<%=txtsubtotal2.ClientID%>");
    var txtsubtotal3 = document.getElementById("<%=txtsubtotal3.ClientID%>");

    var txtsellingprice = document.getElementById("<%=txtsellingprice.ClientID%>");
    var txtsellingprice1 = document.getElementById("<%=txtsellingprice1.ClientID%>");
    var txtsellingprice2 = document.getElementById("<%=txtsellingprice2.ClientID%>");
    var txtsellingprice3 = document.getElementById("<%=txtsellingprice3.ClientID%>");


    var cost = document.getElementById("<%=txtcost.ClientID%>");
    var cost1 = document.getElementById("<%=txtcost1.ClientID%>");
    var cost2 = document.getElementById("<%=txtcost2.ClientID%>");
    var cost3 = document.getElementById("<%=txtcost3.ClientID%>");

    var ddlprofitmargin = document.getElementById("<%=ddlprofitmargin.ClientID%>");
    var hdntaxvalue = document.getElementById("<%=hdntaxvalue.ClientID%>");
    var txtitemtitle = document.getElementById("<%=txtitemtitle.ClientID%>");
    var hid_quickquoteID = document.getElementById("<%=hid_quickquoteID.ClientID%>");
    var ddltax = document.getElementById("<%=ddltax.ClientID%>");

    var txtitemtitle = document.getElementById("<%=txtitemtitle.ClientID%>");
    var QueryType = '<%=QueryType%>';
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';

    if (QueryType == 'add') {
        lbltax.value = 0;
    }
    if (QueryType == "add") {
        moreQty('more');
    }
    else {
        moreQty("<%=str_QtyType %>");
    }

    var modulename = '<%=modulename%>';
    if (modulename == 'jobs' || modulename == 'invoice' || modulename == 'orders') {
        document.getElementById('divhrefQtyMore').style.display = "none";
        moreQty('single');
    }
    
</script>
<script type="text/javascript">

    function onlyNumbers(evt) {
        var e = evt
        if (window.event) {   // IE
            var charCode = e.keyCode;

        } else if (e.which) {  // Safari 4, Firefox 3.0.4
            var charCode = e.which
        }
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }


</script>
<script type="text/javascript">
    function getcost() {
        if (!isNaN(cost.value)) {
            cost.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value), 0, '', false, false, false);
        }
        else {
            cost.value = "0.00";
        }

        if (!isNaN(cost1.value)) {
            cost1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1.value), 0, '', false, false, false);
        }
        else {
            cost1.value = "0.00";
        }
        if (!isNaN(cost2.value)) {
            cost2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2.value), 0, '', false, false, false);
        }
        else {
            cost2.value = "0.00";
        }
        if (!isNaN(cost3.value)) {
            cost3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3.value), 0, '', false, false, false);
        }
        else {
            cost3.value = "0.00";
        }

        var ddlprofitmarginvalue = Number(ddlprofitmargin.options[ddlprofitmargin.selectedIndex].text.split('%')[0]);

        txtproftimarge.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value) * Number(ddlprofitmarginvalue) / 100, 0, '', false, false, false);
        txtproftimarge1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1.value) * Number(ddlprofitmarginvalue) / 100, 0, '', false, false, false);
        txtproftimarge2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2.value) * Number(ddlprofitmarginvalue) / 100, 0, '', false, false, false);
        txtproftimarge3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3.value) * Number(ddlprofitmarginvalue) / 100, 0, '', false, false, false);


        txtsubtotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost.value) + Number(txtproftimarge.value), 0, '', false, false, false);
        txtsubtotal1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost1.value) + Number(txtproftimarge1.value), 0, '', false, false, false);
        txtsubtotal2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost2.value) + Number(txtproftimarge2.value), 0, '', false, false, false);
        txtsubtotal3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(cost3.value) + Number(txtproftimarge3.value), 0, '', false, false, false);


        txtsellingprice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost.value) * ddlprofitmarginvalue) / 100 + Number(cost.value) + Number(lbltax.value), 0, '', false, false, false);
        txtsellingprice1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost1.value) * ddlprofitmarginvalue) / 100 + Number(cost1.value) + Number(lbltax1.value), 0, '', false, false, false);
        txtsellingprice2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost2.value) * ddlprofitmarginvalue) / 100 + Number(cost2.value) + Number(lbltax2.value), 0, '', false, false, false);
        txtsellingprice3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(cost3.value) * ddlprofitmarginvalue) / 100 + Number(cost3.value) + Number(lbltax3.value), 0, '', false, false, false);

        gettaxvalue(Number(ddltax.options[ddltax.selectedIndex].value));
    }
    

    function getsubtotal() {

        txtsubtotal.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtsubtotal.value, 0, '', false, false, false);
        txtsubtotal1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtsubtotal1.value, 0, '', false, false, false);
        txtsubtotal2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtsubtotal2.value, 0, '', false, false, false);
        txtsubtotal3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtsubtotal3.value, 0, '', false, false, false);
        gettaxvalue(Number(ddltax.options[ddltax.selectedIndex].value));

        txtsellingprice.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal.value) + Number(lbltax.value)), 0, '', false, false, false);
        txtsellingprice1.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal1.value) + Number(lbltax1.value)), 0, '', false, false, false);
        txtsellingprice2.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal2.value) + Number(lbltax2.value)), 0, '', false, false, false);
        txtsellingprice3.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, (Number(txtsubtotal3.value) + Number(lbltax3.value)), 0, '', false, false, false);

    }

    function OnChkchanged1() {

        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct1.checked) {
            chkPoduct2.checked = false;
        }
        else {
            chkPoduct1.checked = false;
        }
    }

    function OnChkchanged2() {
        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct2.checked) {
            chkPoduct1.checked = false;
        }
        else {
            chkPoduct2.checked = false;
        }
    }
    function chkspace(textbox, txtvalue) {
        if (!isNaN(cost.value)) {
            textbox.value = txtvalue.replace(/\s+/g, ' ');
        }

    }

   
</script>

