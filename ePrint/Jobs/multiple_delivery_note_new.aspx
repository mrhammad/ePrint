<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage.master" autoeventwireup="true" CodeBehind="multiple_delivery_note_new.aspx.cs" Inherits="ePrint.multiple_delivery_note_new" title="Delivery Notes" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="scr" runat="server">
        <Services>
            <asp:ServiceReference Path="~/press_select.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div id="ds00" style="display: block;">
    </div>
    <div id="div_Load" align="left" style="display: none;" class="loading_new">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script>
        document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";
    </script>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div align="left" style="width: 100%; word-break: break-all; background-color: White;">
        <div id="padding">
            <div id="div_Main" runat="server" align="left" style="width: 100%">
                <div id="ynnav">
                    <ul>
                        <li id="li_Inventory" style="cursor: pointer; float: left; clear: right;">
                            <div id="div3" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px">
                                <b><span id="item_2" class="lnkTabSelected" style="color: orange;" onclick="javascript:LoadDelNotes();">
                                    <%--changeCssTemp(this.id);--%>
                                    <%=objLanguage.GetLanguageConversion("Raise_Delivery_Note") %>
                                </span></b>
                            </div>
                            <asp:LinkButton ID="lnkRaiseDeliveryNote" runat="server" OnClick="lnkRaiseDeliveryNote_OnClick"
                                OnClientClick="javascript:changeCssTemp('item_2');"></asp:LinkButton>
                        </li>
                        <li id="li_StoreSupply" style="cursor: pointer; float: left; clear: right;">
                            <div id="div8" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px">
                                <b><span id="item_5" class="lnkTabSelected" onclick="javascript:changeCssTemp(this.id);">
                                    <%=objLanguage.GetLanguageConversion("Box_Labels") %>
                                </span></b>
                            </div>
                        </li>
                        <li id="li1" style="cursor: pointer; float: left; clear: right; display: none">
                            <div id="div1" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px">
                                <b><span id="item_1" class="lnkTabSelected" onclick="javascript:changeCssTemp(this.id);">
                                    <%=objLanguage.GetLanguageConversion("View_Delivery_Note") %>
                                </span></b>
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="onlyEmpty">
                </div>
                <div class="divBorderItem">
                    <div id="Div2">
                        <div align="center" style="display: none">
                            <asp:Label ID="lblmessage" CssClass="successfulMsg" Text="Delivery Note Raised Succussfully"
                                runat="server"></asp:Label>
                        </div>
                        <div id="divmessage" align="center" style="width: 100%;">
                            <div style="width: 90%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="div_MainDelivery" style="display: block; float: left;">
                            <asp:RadioButton ID="rdosingle" Text="Single Address" onclick="javascript:ChangetoDelevery('single');"
                                GroupName="Delivery" runat="server" Style="display: none" /><%--Checked="true"--%>
                            <asp:RadioButton ID="rdosplit" Text="Choose Address" onclick="javascript:ChangetoDeleverytype('split');"
                                GroupName="Delivery" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="rdoChooseAddress_click" /><%--Multiple Addresses--%>
                            <asp:RadioButton ID="rdoconsolidate" Text="Consolidated" onclick="javascript:ChangetoDeleverytype('consolidate');"
                                GroupName="Delivery" runat="server" AutoPostBack="true" OnCheckedChanged="rdoConsolidate_OnClick" />
                        </div>
                        <div class="only10px">
                        </div>
                        <div align="left" style="width: 100%; display: block" id="divcustomername">
                            <span class="HeaderText" style="font-size: 12px">
                                <%=objLanguage.GetLanguageConversion("Customer") %>
                                :
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label></span>
                        </div>
                        <div class="only10px">
                        </div>
                        <div id="div_SplitDelivery" style="display: none; width: 100%" runat="server">
                            <div align="left" style="width: 100%; display: block" id="div6">
                                <span class="HeaderText" style="font-size: 12px">
                                    <%=objLanguage.GetLanguageConversion("Item_Delivery_Details") %></span>
                            </div>
                            <div class="only5px">
                            </div>
                            <asp:PlaceHolder ID="plhSplitItems" runat="server"></asp:PlaceHolder>
                            <div class="only10px">
                            </div>
                            <div class="only10px">
                            </div>
                            <div id="div_btnRefresh_split" align="left" style="width: 100%;">
                                <div style="float: right">
                                    <asp:Button ID="btnSplitAddressChange" runat="server" Text="Choose Address" CssClass="button"
                                        OnClientClick="javascript:ShowRaiseDiv('split','show');return false;" />
                                </div>
                                <div style="float: right; width: 10px;">
                                    &nbsp;</div>
                                <div style="float: right">
                                    <asp:Button ID="btnRefreshParent" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:CallParentRefresh();return false;" />
                                </div>
                            </div>
                            <div align="left" class="graytext" style="display: block">
                                <%--Add more delivery note addresses:--%>
                                <%--<img src="../images/plus.gif" title="Add more customer" style="vertical-align: top;
                                    padding-left: 5px;" onclick="javascript:More_splitaddress();return false;" />--%></div>
                            <div id="div_RaiseAddress_split" style="display: none">
                                <div align="left" style="width: 100%; border: 0px solid red" id="div_plhsplitaddress">
                                    <%--  <table id="tbladdmore">
                                    <tr>
                                        <td>--%>
                                    <div align="left" style="width: 100%; display: block" id="div7">
                                        <span class="HeaderText" style="font-size: 12px">
                                            <%=objLanguage.GetLanguageConversion("Raise_Delivery_Notes") %></span>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <asp:PlaceHolder ID="plhSplitAddress" runat="server"></asp:PlaceHolder>
                                    <%-- </td>
                                    </tr>
                                </table>--%>
                                </div>
                                <div id="divaaa" style="display: none;">
                                </div>
                                <div class="only10px">
                                </div>
                                <div style="float: left; vertical-align: top;">
                                    <asp:Button ID="lnkaddnewmore" CssClass="button" runat="server" Text="Add another address"
                                        OnClientClick="javascript:More_splitaddress();return false;" Style="display: none">
                                    </asp:Button>
                                </div>
                                <div id="div_btnRaiseDeliveyNote" style="float: right; display: block">
                                    <div style="float: left">
                                        <%--                           <asp:Button ID="btnCancelDeliveryNote" runat="server" Text="Cancel" CssClass="button"
                                            OnClientClick="javascript:ShowRaiseDiv('split','hide');return false;" /><%-- OnClientClick="javascript:window.close();"--%>
                                        <asp:Button ID="btnSavestayDeliveryNote" runat="server" Text="Raise & Stay" CssClass="button"
                                            OnClick="btnRaiseDeliveryNoteSaveStay_OnClick" OnClientClick="return SaveDeliveryNote('');" />
                                    </div>
                                    <div id="div_btnRaiseMultiple" style="float: left; border: 0px solid; display: none">
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left">
                                            <asp:Button ID="btnRaiseMultiple" runat="server" Text="Raise" CssClass="button" OnClick="btnRaiseDeliveryNote_OnClick"
                                                OnClientClick="return SaveDeliveryNote('');" />
                                        </div>
                                    </div>
                                    <div style="float: left" id="div_btnonlyRaise">
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <asp:Button ID="btnRaiseDeliveryNote" runat="server" Text="Raise & Close" CssClass="button"
                                            OnClick="btnRaiseDeliveryNote_OnClick" OnClientClick="return SaveDeliveryNote('raiseclose');" />
                                    </div>
                                </div>
                                <div id="divtest" style="float: left; clear: both; border: 0px solid; display: none">
                                    <div class="only10px">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div id="div_ConsolidatedDelivery" runat="server" align="left" style="display: none;
                            width: 100%;">
                            <div class="only10px">
                            </div>
                            <div style="float: left; width: 100%">
                                <div style="float: left; padding-right: 10px" class="graytext">
                                    <%=objLanguage.GetLanguageConversion("Please_select_the_jobs_you_want_to_include_in_this_consolidated_Delivery_Note")%></div>
                                <div id="divbuttonsup_consolidate" runat="server" style="display: none">
                                    <div style="float: left">
                                        <asp:Button ID="Button3" runat="server" Text="Cancel" CssClass="button" OnClientClick="javascript:CallParentRefresh();return false;" /><%--javascript:window.close();--%>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; display: none" id="div4">
                                        <asp:Button ID="Button1" runat="server" Text="Select Item  D/N" CssClass="button"
                                            OnClientClick="return ContinueonConsolidate('single');" OnClick="Show_Consolidated_With_Multiple_address" /><%--OnClientClick="return SaveDeliveryNote();" OnClick="btnRaiseDeliveryNote_OnClick"--%>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                    </div>
                                    <div style="float: left; display: block;" id="div5">
                                        <asp:Button ID="Button2" runat="server" Text="Select Items" CssClass="button" OnClientClick="return ContinueonConsolidate('split');"
                                            OnClick="Show_Consolidated_With_Multiple_address" />
                                    </div>
                                </div>
                            </div>
                            <div class="only5px">
                            </div>
                            <div align="left" style="width: 100%; border: 1px solid #A4A4A4;">
                                <asp:PlaceHolder ID="plhConsolidated_header" runat="server"></asp:PlaceHolder>
                                <asp:Panel ID="pnlconsolidate" Width="100%" runat="server" Style="overflow: hidden;">
                                    <asp:PlaceHolder ID="plhConsolidated" runat="server"></asp:PlaceHolder>
                                </asp:Panel>
                            </div>
                            <div class="only5px">
                            </div>
                            <div align="left" style="width: 100%">
                                <div style="float: left; width: 24%">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Total_Items_Selected")%>: <b>
                                            <asp:Label ID="lblConTotItems" runat="server" CssClass="normalText">0</asp:Label></b></span>
                                </div>
                                <div style="float: left; width: 24%">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Total_Quantity_Selected")%>: <b>
                                            <asp:Label ID="lblConTotQty" runat="server" CssClass="normalText">0</asp:Label></b></span>
                                </div>
                                <div id="div_btnsCon_Bottom" style="float: left; width: 50%">
                                    <div style="float: left; width: 31px">
                                        &nbsp;</div>
                                    <div style="float: left">
                                        <asp:Button ID="btnCancel_ConDeliveryNote" runat="server" Text="Cancel" CssClass="button"
                                            OnClientClick="javascript:CallParentRefresh();return false;" /><%--javascript:window.close();--%>
                                    </div>
                                    <div style="float: left; display: none" id="divraise_consolidate">
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <asp:Button ID="btnraise_consolidate" runat="server" Text="Single Address D/N" CssClass="button"
                                            OnClientClick="return ContinueonConsolidate('single');" OnClick="Show_Consolidated_With_Multiple_address" />
                                    </div>
                                    <div style="float: left; display: none;" id="div_btncontinue_consolidate" runat="server">
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <asp:Button ID="btncontinue" runat="server" Text="Select Items" CssClass="button"
                                            OnClientClick="return ContinueonConsolidate('split');" OnClick="Show_Consolidated_With_Multiple_address" />
                                    </div>
                                </div>
                            </div>
                            <div id="divtest_conswithsplit" style="display: none; width: 100%">
                            </div>
                        </div>
                        <div id="divConsolidate_split" style="display: none;" runat="server">
                            <div align="left" style="width: 100%; display: block" id="div9">
                                <span class="HeaderText" style="font-size: 12px">
                                    <%=objLanguage.GetLanguageConversion("Item_Delivery_Details")%></span>
                            </div>
                            <div class="only5px">
                            </div>
                            <div>
                                <asp:PlaceHolder ID="plhconsolidate_split" runat="server"></asp:PlaceHolder>
                            </div>
                            <div id="div_btnRefresh_con" align="left" style="width: 100%;">
                                <div style="float: right">
                                    <asp:Button ID="btnConAddressChange" runat="server" Text="Choose Address" CssClass="button"
                                        OnClientClick="javascript:ShowRaiseDiv('consolidate','show');return false;" />
                                </div>
                                <div style="float: right; width: 10px;">
                                    &nbsp;</div>
                                <div style="float: right">
                                    <asp:Button ID="btnRefreshParent_con" runat="server" Text="Save" CssClass="button"
                                        OnClientClick="javascript:CallParentRefresh();return false;" />
                                </div>
                            </div>
                            <%-- <div class="only10px">
                            </div>--%>
                            <div id="divaddmore_conswithsplit">
                            </div>
                            <div class="only10px">
                            </div>
                            <div id="div_conbtnRaise">
                                <div style="float: left; clear: both; border: 0px solid; vertical-align: top;">
                                    <asp:Button ID="lnk_addmore_conwithsplit" runat="server" CssClass="Button" Text="Add another address"
                                        OnClientClick="javascript:More_splitaddress_conswithsplit();return false;"></asp:Button>
                                </div>
                                <div style="float: right;">
                                    <asp:Button ID="btncancel_conswithsplit" runat="server" Text="Cancel" CssClass="button"
                                        OnClick="btncancel_conswithsplit_Onclick" />
                                    <asp:Button ID="btnRaisedelivery_conswithsplit" runat="server" Text="Raise" CssClass="button"
                                        OnClick="btnRaiseDeliveryNote_conswithsplit_OnClick" OnClientClick="return SaveDeliveryNote_conswithsplit();" />
                                </div>
                            </div>
                        </div>
                        <div id="div_BoxLabel" style="display: none; width: 100%">
                            <div id="div_BoxLabel_Step1" style="width: 100%; display: block">
                                <div align="left" style="width: 49%">
                                    <div class="graytext" style="float: left; width: 40%">
                                        <%=objLanguage.GetLanguageConversion("Select_Item_Title_From_The_List")%>
                                    </div>
                                    <div style="float: left; padding-left: 5px">
                                        <asp:DropDownList ID="ddlItemTitle" runat="server" CssClass="normalText" Width="175px"
                                            onchange="ShowonChange(this.value);">
                                            <%-- <asp:ListItem>Select/Enter Item title</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="only5px">
                                </div>
                                <%--<div class="graytext" style="float: left; width: 49%">
                                    <span>Select from multiple addresses</span><img src="../images/plus.gif" title="Select more addresses"
                                        style="vertical-align: middle; margin-left: 8px;" onclick="javascript:More_Address();return false;" />
                                </div>--%>
                                <div class="only5px">
                                </div>
                                <div align="left" style="width: 100%">
                                    <div align="left" style="width: 100%">
                                        <span class="HeaderText">
                                            <%=objLanguage.GetLanguageConversion("Customer_Address_Details")%></span>
                                        <img src="../images/plus.gif" title="Change address" style="vertical-align: middle;
                                            cursor: pointer; margin-left: 8px;" onclick="javascript:More_Address();return false;" />
                                    </div>
                                    <div style="float: left; width: 60%">
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objLanguage.GetLanguageConversion("Company")%>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtCompany" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="lbl_Deliveryaddr1" runat="server"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtAddressLine1" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="lbl_Deliveryaddr2" runat="server"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtAddressLine2" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="lbl_Deliveryaddr3" runat="server"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtAddressLine3" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="lbl_Deliveryaddr4" runat="server"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtAddressLine4" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <asp:Label ID="lbl_Deliveryaddr5" runat="server"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtAddressLine5" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                Country
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtCountry" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objLanguage.GetLanguageConversion("Telephone")%>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtTelephone" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objLanguage.GetLanguageConversion("Fax")%>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtFax" runat="server" SkinID="textPad" Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <%=objLanguage.GetLanguageConversion("Qty")%>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtTotalQty" runat="server" SkinID="textPad" Width="80px" Style="text-align: right"
                                                    Text="0" MaxLength="8" onkeyup="javascript:AllowNumber(this,this.value);"
                                                    onkeypress="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="div_OnlyWareItems" style="display: none">
                                            <div class="only5px">
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <span>Show Inventory Code</span>
                                                </div>
                                                <div class="ddlsetting">
                                                    <asp:CheckBox ID="chkShowInvCode" runat="server" /></div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel">
                                                    <span>Show Inventory Description</span>
                                                </div>
                                                <div class="ddlsetting">
                                                    <asp:CheckBox ID="chkShowInvDesc" runat="server" /></div>
                                            </div>
                                        </div>
                                        <div class="only5px">
                                        </div>
                                        <div align="left" style="width: 100%">
                                            <span class="HeaderText">Label Quantity and Mask</span>
                                        </div>
                                        <div align="left" style="width: 100%; border: 0px solid red">
                                            <div class="bglabel">
                                                <span>No. of labels required</span>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtNoOfLabels" runat="server" SkinID="textPad" Width="80px" Style="text-align: right"
                                                    MaxLength="8" onkeyup="javascript:AllowNumber(this,this.value);"
                                                    onkeypress="javascript:AllowNumber(this,this.value);">1</asp:TextBox>&nbsp;<span
                                                        class="smallgraytext">(Max you can print 100 labels at once)</span></div>
                                            <div class="onlyEmpty">
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span>Numbering mask required</span>
                                            </div>
                                            <div class="box" style="padding-left: 3px; padding-bottom: 0px; vertical-align: middle">
                                                <asp:CheckBox ID="chkNumberingMask" runat="server" onclick="javascript:ShowHideNumberingMask();" />
                                            </div>
                                        </div>
                                        <div id="div_Mask" align="left" style="display: none;">
                                            <div align="left">
                                                <div class="bglabel">
                                                    <span>No. of items per Box</span>
                                                </div>
                                                <div class="box">
                                                    <asp:TextBox ID="txtNoOfLeaves" runat="server" SkinID="textPad" Width="100px">1</asp:TextBox>
                                                    <span id="spn_itemperbox" class="spanerrorMsg" style="clear: both; width: 95px; display: none;
                                                        vertical-align: middle">Items cannot be blank</span>
                                                </div>
                                            </div>
                                            <div align="left" style="display: none">
                                                <div class="bglabel">
                                                    <span>Overflow masks required</span>
                                                </div>
                                                <div class="box">
                                                    <asp:DropDownList ID="ddlOverflowMask" runat="server" CssClass="normalText" onchange="javascript:ShowHideOverflowMask(this.value);">
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                                <div id="div_OverflowMask" align="left" style="width: 100%; display: none">
                                    <div style="float: left; width: 19%; padding-right: 10px;">
                                        &nbsp;
                                    </div>
                                    <div class="box" style="width: 75%">
                                        <div style="float: left;">
                                            <div style="float: left; width: 100px">
                                                <b>Prefix</b>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 100px">
                                                <b>Suffix</b>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 100px">
                                                <b>Start#</b>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 100px;">
                                                <b>End#</b>
                                            </div>
                                        </div>
                                        <div class="only5px">
                                        </div>
                                        <div id="div_OverflowMask1" style="float: left; display: block">
                                            <div style="float: left">
                                                <asp:TextBox ID="txtPrefix1" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtSuffix1" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtStart1" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtStart1', 'spn_txtStart1');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtEnd1" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtEnd1', 'spn_txtEnd1');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div style="float: left; clear: both; width: 100%;">
                                            <div style="float: left; width: 220px">
                                                &nbsp;</div>
                                            <div style="float: left; width: 100px">
                                                <span id="spn_reqtxtStart1" class="spanerrorMsg" style="clear: both; width: 95px;
                                                    display: none; vertical-align: middle">Start value required</span><span id="spn_txtStart1"
                                                        class="spanerrorMsg" style="clear: both; width: 95px; display: none; vertical-align: middle">Please
                                                        enter integer value</span>&nbsp;</div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left;">
                                                <span id="spn_reqtxtEnd1" class="spanerrorMsg" style="clear: both; width: 95px; display: none;
                                                    vertical-align: middle">End value required</span><span id="spn_txtEnd1" class="spanerrorMsg"
                                                        style="clear: both; width: 95px; display: none; vertical-align: middle">Please enter
                                                        integer value</span>
                                            </div>
                                        </div>
                                        <div id="div_OverflowMask2" style="float: left; display: none">
                                            <div class="only5px">
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtPrefix2" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtSuffix2" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtStart2" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtStart2', 'spn_txtStart2');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtEnd2" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtEnd2', 'spn_txtEnd2');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; clear: both; width: 100%;">
                                                <div style="float: left; width: 220px">
                                                    &nbsp;</div>
                                                <div style="float: left; width: 100px">
                                                    <span id="spn_reqtxtStart2" class="spanerrorMsg" style="clear: both; width: 95px;
                                                        display: none; vertical-align: middle">Start value required</span><span id="spn_txtStart2"
                                                            class="spanerrorMsg" style="clear: both; width: 95px; display: none; vertical-align: middle">
                                                            Please enter integer value</span>&nbsp;</div>
                                                <div style="float: left; width: 10px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <span id="spn_reqtxtEnd2" class="spanerrorMsg" style="clear: both; width: 95px; display: none;
                                                        vertical-align: middle">End value required</span><span id="spn_txtEnd2" class="spanerrorMsg"
                                                            style="clear: both; width: 95px; display: none; vertical-align: middle">Please enter
                                                            integer value</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_OverflowMask3" style="float: left; display: none">
                                            <div class="only5px">
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtPrefix3" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtSuffix3" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtStart3" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtStart3', 'spn_txtStart3');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtEnd3" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtEnd3', 'spn_txtEnd3');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; clear: both; width: 100%;">
                                                <div style="float: left; width: 220px">
                                                    &nbsp;</div>
                                                <div style="float: left; width: 100px">
                                                    <span id="spn_reqtxtStart3" class="spanerrorMsg" style="clear: both; width: 95px;
                                                        display: none; vertical-align: middle">Start value required</span><span id="spn_txtStart3"
                                                            class="spanerrorMsg" style="clear: both; width: 95px; display: none; vertical-align: middle">Please
                                                            enter integer value</span>&nbsp;</div>
                                                <div style="float: left; width: 10px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <span id="spn_reqtxtEnd3" class="spanerrorMsg" style="clear: both; width: 95px; display: none;
                                                        vertical-align: middle">End value required</span><span id="spn_txtEnd3" class="spanerrorMsg"
                                                            style="clear: both; width: 95px; display: none; vertical-align: middle">Please enter
                                                            integer value</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_OverflowMask4" style="float: left; display: none">
                                            <div class="only5px">
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtPrefix4" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtSuffix4" runat="server" SkinID="textPad" Width="100px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtStart4" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtStart4', 'spn_txtStart4');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; width: 10px">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <asp:TextBox ID="txtEnd4" runat="server" SkinID="textPad" Width="100px" onblur="javascript:AllowNumber(this,this.value);CheckReqCompare(this.value,'spn_reqtxtEnd4', 'spn_txtEnd4');"></asp:TextBox>
                                            </div>
                                            <div style="float: left; clear: both; width: 100%;">
                                                <div style="float: left; width: 220px">
                                                    &nbsp;</div>
                                                <div style="float: left; width: 100px">
                                                    <span id="spn_reqtxtStart4" class="spanerrorMsg" style="clear: both; width: 95px;
                                                        display: none; vertical-align: middle">Start value required</span><span id="spn_txtStart4"
                                                            class="spanerrorMsg" style="clear: both; width: 95px; display: none; vertical-align: middle">Please
                                                            enter integer value</span>&nbsp;</div>
                                                <div style="float: left; width: 10px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <span id="spn_reqtxtEnd4" class="spanerrorMsg" style="clear: both; width: 95px; display: none;
                                                        vertical-align: middle">End value required</span><span id="spn_txtEnd4" class="spanerrorMsg"
                                                            style="clear: both; width: 95px; display: none; vertical-align: middle">Please enter
                                                            integer value</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_BoxLabel_Step2" style="width: 100%; display: block">
                                    <div class="only5px">
                                    </div>
                                    <div align="left" style="width: 60%">
                                        <div align="left">
                                            <div class="bglabel">
                                                <span>Label Type</span>
                                            </div>
                                            <div class="box">
                                                <asp:DropDownList ID="ddlLabeltype" runat="server" CssClass="normalText" onchange="javascript:BindRowsColumns(this.value);">
                                                    <asp:ListItem Value="1">Avery L-7160: 7*3-A4</asp:ListItem>
                                                    <asp:ListItem Value="2">Avery L105149: 2*2-A4</asp:ListItem>
                                                    <asp:ListItem Value="3">Avery LS30100: 9*2-A4</asp:ListItem>
                                                    <asp:ListItem Value="4">Avery LS6799: 4*2-A4</asp:ListItem>
                                                    <asp:ListItem Value="5">BondD3396: 8*2-A4</asp:ListItem>
                                                    <asp:ListItem Value="6">Avery L(US)-7160: 4*2-A4</asp:ListItem>
                                                    <asp:ListItem Value="7">Avery L(US)-7160: 4*3-A4</asp:ListItem>
                                                    <%--<asp:ListItem Value="8">Custom(100mm x 149mm): 1*1-A4</asp:ListItem>--%><%--PPW Label--%>
                                                    <%--<asp:ListItem Value="9">Custom (100mm x 50mm): 1*1-A4</asp:ListItem>--%><%--Maspro--%>
                                                    <%--<asp:ListItem Value="8">Customized Label</asp:ListItem>-- don't delete --by swetha--%>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span>Starting Row</span>
                                            </div>
                                            <div class="box">
                                                <asp:DropDownList ID="ddlRows" onchange="javascript:getstartrowvalue();return false;"
                                                    runat="server" CssClass="normalText">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel">
                                                <span>Starting Column</span>
                                            </div>
                                            <div class="box">
                                                <asp:DropDownList ID="ddlColumns" onchange="javascript:getstartcolvalue();return false;"
                                                    runat="server" CssClass="normalText">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div id="div_Customize" align="left" style="width: 70%; display: none;">
                                        <fieldset>
                                            <legend class="HeaderText">Customized Label</legend>
                                            <div id="Div10">
                                                <div align="left" style="width: 100%;">
                                                    <asp:RadioButtonList ID="rdlstCustomized" runat="server" RepeatDirection="Horizontal"
                                                        onclick="javascript:ShowHideCustomizeLabel(this);">
                                                        <asp:ListItem Value="customize" Selected="True">Customize Label Size</asp:ListItem>
                                                        <asp:ListItem Value="ups">Specify Ups</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="only5px">
                                                </div>
                                                <div id="div_CustomizeLabel" align="left" style="width: 100%; display: block; padding-left: 5px;">
                                                    <div align="left" style="width: 100%;">
                                                        <div style="float: left">
                                                            <span>Label Width:</span>
                                                        </div>
                                                        <div style="float: left">
                                                            &nbsp;
                                                            <asp:ListBox ID="lstWidth" runat="server" Rows="2" onclick="javascript:GetLabelSize('width',this.value)">
                                                                <asp:ListItem Value="1">1'' inch</asp:ListItem>
                                                                <asp:ListItem Value="2">2'' inch</asp:ListItem>
                                                                <asp:ListItem Value="3">3'' inch</asp:ListItem>
                                                                <asp:ListItem Value="4">4'' inch</asp:ListItem>
                                                                <asp:ListItem Value="5">5'' inch</asp:ListItem>
                                                                <asp:ListItem Value="6">6'' inch</asp:ListItem>
                                                                <asp:ListItem Value="7">7'' inch</asp:ListItem>
                                                                <asp:ListItem Value="8">8'' inch</asp:ListItem>
                                                            </asp:ListBox>
                                                        </div>
                                                        <div style="float: left">
                                                            &nbsp; <span>Label Height:</span>
                                                        </div>
                                                        <div style="float: left">
                                                            &nbsp;
                                                            <asp:ListBox ID="ListBox1" runat="server" Rows="2" onclick="javascript:GetLabelSize('height',this.value)">
                                                                <asp:ListItem Value="1">1'' inch</asp:ListItem>
                                                                <asp:ListItem Value="2">2'' inch</asp:ListItem>
                                                                <asp:ListItem Value="3">3'' inch</asp:ListItem>
                                                                <asp:ListItem Value="4">4'' inch</asp:ListItem>
                                                                <asp:ListItem Value="5">5'' inch</asp:ListItem>
                                                                <asp:ListItem Value="6">6'' inch</asp:ListItem>
                                                                <asp:ListItem Value="7">7'' inch</asp:ListItem>
                                                                <asp:ListItem Value="8">8'' inch</asp:ListItem>
                                                            </asp:ListBox>
                                                        </div>
                                                    </div>
                                                    <div class="only10px">
                                                    </div>
                                                    <div align="left" class="normalText" style="width: 30%;">
                                                        <span class="HeaderText" style="font-size: 12px; color: Blue">Label size of (<span
                                                            id="spn_Width">2</span> X <span id="spn_Height">2</span>)&nbsp;inch</span>
                                                    </div>
                                                    <div class="only10px">
                                                    </div>
                                                    <div align="left" class="normalText" style="width: 50%; color: Blue">
                                                        <span class="HeaderText" style="font-size: 12px; color: Blue">20 Ups on page size (8.5
                                                            X 11) inch</span>
                                                    </div>
                                                </div>
                                                <div id="div_Ups" align="left" style="width: 100%; display: none; padding-left: 5px;">
                                                    <asp:DropDownList ID="ddlUps" runat="server" CssClass="normalText" Width="175px">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>15</asp:ListItem>
                                                        <asp:ListItem>20</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="only10px">
                                                </div>
                                                <div align="left" style="width: 70%; border: 1px solid; padding: 5px;">
                                                    <span id="spn_Label" style="display: block">Box #1 of 1<br />
                                                        Select/Enter ItemTitle<br />
                                                    </span>
                                                    <asp:TextBox ID="txtLabel" runat="server" SkinID="textPad" TextMode="MultiLine" Rows="6"
                                                        Width="100%" ReadOnly="true" Style="text-align: left; border: 0px; overflow: hidden"></asp:TextBox>
                                                </div>
                                                <div align="left" style="width: 50%;">
                                                    <div style="float: left">
                                                        <asp:CheckBox ID="chk" runat="server" Text="Use Edited Label for print" />
                                                    </div>
                                                    <div style="float: left">
                                                        <asp:CheckBox ID="chkEditBoxLabel" runat="server" Text="Edit Label" onclick="javascript:EditBoxLabel();" />
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div id="div_btnBoxLabel" align="left" style="width: 100%; display: none">
                            <div style="float: left; padding-left: 24%">
                                <div style="float: left">
                                    <asp:Button ID="btnBoxLabelCancel" runat="server" Text="Cancel" CssClass="button"
                                        OnClientClick="javascript:window.close();" />
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div id="div_btnNext" style="float: left; display: block">
                                    <asp:Button ID="btnBoxLabelNext" runat="server" Text="Next" CssClass="button" OnClientClick="javascript:validateBoxLabelStep1();return false;" /><%--ShowBoxLabelStep2();return false;--%>
                                </div>
                            </div>
                            <div id="div_btnPrevious" style="float: left; display: none">
                                <div style="float: left">
                                    <asp:Button ID="btnCancelStep2" runat="server" Text="Cancel" CssClass="button" OnClientClick="javascript:ShowBoxLabelStep1();return false;" />
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button ID="btnBoxLabelPrevious" runat="server" Text="Previous" CssClass="button"
                                        OnClientClick="javascript:ShowBoxLabelStep1();return false;" />
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button ID="btnBoxLabelPrint" runat="server" Text="Next" CssClass="button" OnClientClick="javascript:CallPrintLabel();return false;" />
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_Print" runat="server" align="center" style="width: 100%; display: none">
                <div align="left" style="width: 100%">
                    <div style="float: left; width: 23%">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="Button5" runat="server" CssClass="button" Text="Previous" OnClientClick="javascript:ShowBoxLabelStep2();return false;" /></div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="Button4" runat="server" CssClass="button" Text="Cancel" OnClientClick="return ClosePrintDiv();" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left;">
                        <asp:Button ID="btnPreviewAtTop" runat="server" CssClass="button" Text="Print/Preview"
                            OnClick="btnprint_click" OnClientClick="return GetEdited_PrintLabels();" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left; display: none">
                        <asp:Button ID="btnPrintAtTop" runat="server" CssClass="button" Text="Print" OnClientClick="printView();return false;" />
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div align="left" class="grayText" id="div_editext" runat="server">
                    <div style="float: left; width: 23%">
                        &nbsp;
                    </div>
                    Print Preview of the Labels, You can edit the label text below as you require
                </div>
                <div class="only10px">
                </div>
                <div id="div_PrintContentMain" align="left" style="width: 595px; height: 842px; border: 1px solid;">
                    <div id="div_PrintContent" align="left" width="100%" style="overflow-y: scroll; overflow-x: hidden;
                        height: 842px;">
                        <asp:Label ID="lblPrint" runat="server" CssClass="normalText" Style="display: none;"></asp:Label>
                    </div>
                </div>
                <div class="only10px">
                </div>
                <div align="left" style="width: 100%">
                    <div style="float: left; width: 23%">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnPrintPrevious" runat="server" CssClass="button" Text="Previous"
                            OnClientClick="javascript:ShowBoxLabelStep2();return false;" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnPrintCancel" runat="server" CssClass="button" Text="Cancel" OnClientClick="return ClosePrintDiv();" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <asp:Button ID="btnPreviewAtBottom" runat="server" CssClass="button" Text="Print/Preview"
                            OnClientClick="return GetEdited_PrintLabels();" OnClick="btnprint_click" />
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left; display: none">
                        <asp:Button ID="btnPrintAtBottom" runat="server" CssClass="button" Text="Print" OnClientClick="printView();return false;" />
                    </div>
                </div>
            </div>
            <div id="div_iframe" runat="server" style="display: none; vertical-align: top">
                <div style="float: left; margin-bottom: 2px">
                    <asp:Button ID="btn_BackPrintPreview" runat="server" CssClass="button" Text="Back"
                        OnClientClick="javascript:ClosePrintPreview();return false;" />
                </div>
                <iframe id="iframe_Preview" runat="server" frameborder="1" scrolling="yes" height="370"
                    width="100%"></iframe>
            </div>
        </div>
    </div>
    <div id="divrad" style="display: none; position: absolute; vertical-align: middle;
        border: 0px solid; z-index: 100; width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
            OnClientClose="RadWinClose" Behaviors="Close, Move, Resize" ReloadOnShow="false">
        </telerik:RadWindowManager>
    </div>
    <div id="div_PPWlabel" align="left" style="display: none;">
        <div align="left">
            <%--id="rotate"--%>
            <div id="div_PPWContent">
            </div>
        </div>
    </div>
    <div id="div_MasproLabel" align="left" style="display: none">
        <div id="div_MasproContent">
        </div>
    </div>
    <span id="spn_Text" runat="server"></span>
    <asp:HiddenField ID="hdn_TotItems" runat="server" Value="0" />
    <asp:HiddenField ID="hid_totItems_con_withsplit" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_SplitQty" runat="server" Value="" />
    <asp:HiddenField ID="hdn_SplitQty_conswithsplit" runat="server" Value="" />
    <asp:HiddenField ID="hdn_lblSplitBalance" runat="server" Value="" />
    <asp:HiddenField ID="hdn_TotSplitAddress" runat="server" Value="" />
    <asp:HiddenField ID="hdn_ItemNum" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_DeliveryNoteType" runat="server" Value="" />
    <asp:HiddenField ID="hdn_SaveData" runat="server" Value="" />
    <asp:HiddenField ID="hdn_ConIds" runat="server" Value="" />
    <asp:HiddenField ID="hid_value" runat="server" Value="0" />
    <%--this value is used when he click the split add more--%>
    <asp:HiddenField ID="hid_valueconswithsplit" runat="server" Value="0" />
    <%--this value is used when he click the consolidate add more--%>
    <asp:HiddenField ID="hid_thisaddressid" runat="server" Value="0" />
    <asp:HiddenField ID="hid_thisaddresstype" runat="server" Value="M" />
    <asp:HiddenField ID="hid_companyid" runat="server" Value="0" />
    <asp:HiddenField ID="hid_clientid" runat="server" Value="0" />
    <asp:HiddenField ID="hid_estimateid" runat="server" Value="" />
    <asp:HiddenField ID="hid_estimateitemid" runat="server" Value="" />
    <asp:HiddenField ID="hid_itemdescription" runat="server" Value="" />
    <asp:HiddenField ID="hid_estimatetype" runat="server" Value="" />
    <asp:HiddenField ID="hid_check" runat="server" Value="0" />
    <asp:HiddenField ID="hid_checkboxid" runat="server" Value="" />
    <asp:HiddenField ID="hdn_SaveData_conswithsplit" runat="server" Value="" />
    <asp:HiddenField ID="hid_labletype_rows" runat="server" Value="0" />
    <asp:HiddenField ID="hid_labletype_col" runat="server" Value="0" />
    <asp:HiddenField ID="hid_startrow" runat="server" Value="0" />
    <asp:HiddenField ID="hid_startcol" runat="server" Value="0" />
    <asp:HiddenField ID="hid_boxlable" runat="server" Value="0" />
    <asp:HiddenField ID="hid_nooflableonprintview" runat="server" Value="0" />
    <asp:HiddenField ID="hid_address_text" runat="server" Value="" />
    <asp:HiddenField ID="hid_rowvalue" runat="server" Value="1" />
    <asp:HiddenField ID="hid_rowvalue_cons" runat="server" Value="1" />
    <asp:HiddenField ID="hdn_contotitems" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_consolidate_raise_type" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_con_single_addressid" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_con_single_addresstype" runat="server" Value="" />
    <asp:HiddenField ID="hdn_con_raised_estimateids" runat="server" Value="" />
    <asp:HiddenField ID="hdn_PrintLabels" runat="server" Value="" />
    <asp:HiddenField ID="hdn_splitEstimateID" runat="server" Value="" />
    <asp:HiddenField ID="hdn_splitEstimateItemID" runat="server" Value="" />
    <asp:HiddenField ID="hdn_splitEstimateType" runat="server" Value="" />
    <asp:HiddenField ID="hdn_splitItemDesc" runat="server" Value="" />
    <asp:HiddenField ID="hdn_splitQtyProduced" runat="server" Value="" />
    <asp:HiddenField ID="hdn_conQtyProduced" runat="server" Value="" />
    <asp:HiddenField ID="hdn_InvCode" runat="server" Value="" />
    <asp:HiddenField ID="hdn_InvName" runat="server" Value="" />
    <asp:HiddenField ID="hdn_InvDesc" runat="server" Value="" />
    <asp:HiddenField ID="hdn_TotalQty" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_labeltype" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_InvLocation" runat="server" Value="" />
    <asp:HiddenField ID="hdn_RaisedDelNote_TotCnt" runat="server" Value="0" />
    <script type="text/javascript" src="../js/Item/general.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/multiple_delivery.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript">
        var ServerName = '<%=ServerName%>';
        var div_Main = document.getElementById("<%=div_Main.ClientID %>");
        var div_Print = document.getElementById("<%=div_Print.ClientID %>");
        var div_iframe = document.getElementById("<%=div_iframe.ClientID %>");
        var deliveryNoteRedirect = "<%=deliveryNoteRedirect %>";
        var rdosingle = document.getElementById("<%=rdosingle.ClientID %>");
        var rdosplit = document.getElementById("<%=rdosplit.ClientID %>");
        var rdoconsolidate = document.getElementById("<%=rdoconsolidate.ClientID %>");

        var lnkaddnewmore = document.getElementById("<%=lnkaddnewmore.ClientID %>");
        var lnk_addmore_conwithsplit = document.getElementById("<%=lnk_addmore_conwithsplit.ClientID %>");

        var div_MainDelivery = document.getElementById("div_MainDelivery");
        var div_SplitDelivery = document.getElementById("<%=div_SplitDelivery.ClientID %>"); //  document.getElementById("div_SplitDelivery");
        var div_ConsolidatedDelivery = document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>"); // document.getElementById("div_ConsolidatedDelivery");
        var divConsolidate_split = document.getElementById("<%=divConsolidate_split.ClientID %>"); // document.getElementById("divConsolidate_split");
        var divraise_consolidate = document.getElementById("divraise_consolidate");
        var div_btnsCon_Bottom = document.getElementById("div_btnsCon_Bottom");
        var div_plhsplitaddress = document.getElementById("div_plhsplitaddress");
        var div_RaiseAddress_split = document.getElementById("div_RaiseAddress_split");

        var divmessage = document.getElementById("divmessage");
        var divcustomername = document.getElementById("divcustomername");

        var div_btnonlyRaise = document.getElementById("div_btnonlyRaise");
        var div_btnRaiseDeliveyNote = document.getElementById("div_btnRaiseDeliveyNote");
        var divbuttonsup_consolidate = document.getElementById("<%=divbuttonsup_consolidate.ClientID %>"); // document.getElementById("divbuttonsup_consolidate");
        var div_btnRaiseMultiple = document.getElementById("div_btnRaiseMultiple");
        var div_btncontinue_consolidate = document.getElementById("<%=div_btncontinue_consolidate.ClientID %>"); //document.getElementById("div_btncontinue_consolidate");
        var div_btnRefresh_split = document.getElementById("div_btnRefresh_split");
        var div_btnRefresh_con = document.getElementById("div_btnRefresh_con");
        var div_conbtnRaise = document.getElementById("div_conbtnRaise");


        var btnRaiseDeliveryNote = document.getElementById("<%=btnRaiseDeliveryNote.ClientID %>");

        var btnRaiseMultiple = document.getElementById("<%=btnRaiseMultiple.ClientID %>");
        var btnCancel_ConDeliveryNote = document.getElementById("<%=btnCancel_ConDeliveryNote.ClientID %>");
        var btnSplitAddressChange = document.getElementById("<%=btnSplitAddressChange.ClientID %>");
        var btnRefreshParent = document.getElementById("<%=btnRefreshParent.ClientID %>");

        var lblCustomerName = document.getElementById("<%=lblCustomerName.ClientID %>");
        var lblConTotItems = document.getElementById("<%=lblConTotItems.ClientID %>");
        var lblConTotQty = document.getElementById("<%=lblConTotQty.ClientID %>");

        var hdn_TotItems = document.getElementById("<%=hdn_TotItems.ClientID %>");
        var hid_totItems_con_withsplit = document.getElementById("<%=hid_totItems_con_withsplit.ClientID %>");

        var hdn_SplitQty = document.getElementById("<%=hdn_SplitQty.ClientID %>");
        var hdn_SplitQty_conswithsplit = document.getElementById("<%=hdn_SplitQty_conswithsplit.ClientID %>");

        var hdn_lblSplitBalance = document.getElementById("<%=hdn_lblSplitBalance.ClientID %>");
        var hdn_TotSplitAddress = document.getElementById("<%=hdn_TotSplitAddress.ClientID %>");
        var hdn_ItemNum = document.getElementById("<%=hdn_ItemNum.ClientID %>");
        var hdn_DeliveryNoteType = document.getElementById("<%=hdn_DeliveryNoteType.ClientID %>");
        var hdn_SaveData = document.getElementById("<%=hdn_SaveData.ClientID %>");
        var hdn_SaveData_conswithsplit = document.getElementById("<%=hdn_SaveData_conswithsplit.ClientID %>");

        var hdn_ConIds = document.getElementById("<%=hdn_ConIds.ClientID %>");
        var hdn_RaisedDelNote_TotCnt = document.getElementById("<%=hdn_RaisedDelNote_TotCnt.ClientID %>");

        var hid_value = document.getElementById("<%=hid_value.ClientID %>");
        var hid_valueconswithsplit = document.getElementById("<%=hid_valueconswithsplit.ClientID %>");

        var hid_checkboxid = document.getElementById("<%=hid_checkboxid.ClientID %>");

        var hid_companyid = document.getElementById("<%=hid_companyid.ClientID %>");
        var hid_clientid = document.getElementById("<%=hid_clientid.ClientID %>");

        var hid_estimateid = document.getElementById("<%=hid_estimateid.ClientID %>");
        var hid_estimateitemid = document.getElementById("<%=hid_estimateitemid.ClientID %>");
        var hid_estimatetype = document.getElementById("<%=hid_estimatetype.ClientID %>");
        var hid_itemdescription = document.getElementById("<%=hid_itemdescription.ClientID %>");

        var hid_thisaddressid = document.getElementById("<%=hid_thisaddressid.ClientID %>");
        var hid_thisaddresstype = document.getElementById("<%=hid_thisaddresstype.ClientID %>");
        var hid_check = document.getElementById("<%=hid_check.ClientID %>");
        var hid_rowvalue = document.getElementById("<%=hid_rowvalue.ClientID %>");
        var hid_rowvalue_cons = document.getElementById("<%=hid_rowvalue_cons.ClientID %>");
        var hdn_contotitems = document.getElementById("<%=hdn_contotitems.ClientID %>");
        var hdn_consolidate_raise_type = document.getElementById("<%=hdn_consolidate_raise_type.ClientID %>");
        var hdn_con_single_addressid = document.getElementById("<%=hdn_con_single_addressid.ClientID %>");
        var hdn_con_single_addresstype = document.getElementById("<%=hdn_con_single_addresstype.ClientID %>");
        var hdn_con_raised_estimateids = document.getElementById("<%=hdn_con_raised_estimateids.ClientID %>");

        var hdn_splitEstimateID = document.getElementById("<%=hdn_splitEstimateID.ClientID %>");
        var hdn_splitEstimateItemID = document.getElementById("<%=hdn_splitEstimateItemID.ClientID %>");
        var hdn_splitEstimateType = document.getElementById("<%=hdn_splitEstimateType.ClientID %>");
        var hdn_splitItemDesc = document.getElementById("<%=hdn_splitItemDesc.ClientID %>");
        var hdn_splitQtyProduced = document.getElementById("<%=hdn_splitQtyProduced.ClientID %>");
        var hdn_conQtyProduced = document.getElementById("<%=hdn_conQtyProduced.ClientID %>");

        var hdn_PrintLabels = document.getElementById("<%=hdn_PrintLabels.ClientID %>");


        //Box Label
        var div_BoxLabel = document.getElementById("div_BoxLabel");
        var div_btnBoxLabel = document.getElementById("div_btnBoxLabel");
        var div_btnNext = document.getElementById("div_btnNext");
        var div_btnPrevious = document.getElementById("div_btnPrevious");
        var div_OnlyWareItems = document.getElementById("div_OnlyWareItems");

        var btnBoxLabelNext = document.getElementById("<%=btnBoxLabelNext.ClientID %>");
        var btnBoxLabelPrevious = document.getElementById("<%=btnBoxLabelPrevious.ClientID %>");
        var btnBoxLabelCancel = document.getElementById("<%=btnBoxLabelCancel.ClientID %>");
        var btnCancelStep2 = document.getElementById("<%=btnCancelStep2.ClientID %>");

        var chkShowInvCode = document.getElementById("<%=chkShowInvCode.ClientID %>");
        var chkShowInvDesc = document.getElementById("<%=chkShowInvDesc.ClientID %>");

        var chkNumberingMask = document.getElementById("<%=chkNumberingMask.ClientID %>");
        var ddlOverflowMask = document.getElementById("<%=ddlOverflowMask.ClientID %>");

        var div_Mask = document.getElementById("div_Mask");
        var div_OverflowMask = document.getElementById("div_OverflowMask");
        var div_OverflowMask1 = document.getElementById("div_OverflowMask1");
        var div_OverflowMask2 = document.getElementById("div_OverflowMask2");
        var div_OverflowMask3 = document.getElementById("div_OverflowMask3");
        var div_OverflowMask4 = document.getElementById("div_OverflowMask4");

        var div_BoxLabel_Step1 = document.getElementById("div_BoxLabel_Step1");
        var div_BoxLabel_Step2 = document.getElementById("div_BoxLabel_Step2");

        var ddlItemTitle = document.getElementById("<%=ddlItemTitle.ClientID %>");
        var ddlLabeltype = document.getElementById("<%=ddlLabeltype.ClientID %>");
        var ddlRows = document.getElementById("<%=ddlRows.ClientID %>");
        var ddlColumns = document.getElementById("<%=ddlColumns.ClientID %>");

        var spn_Width = document.getElementById("spn_Width");
        var spn_Height = document.getElementById("spn_Height");
        var spn_Label = document.getElementById("spn_Label");
        var spn_Text = document.getElementById("<%=spn_Text.ClientID %>");

        var txtLabel = document.getElementById("<%=txtLabel.ClientID %>");
        var chkEditBoxLabel = document.getElementById("<%=chkEditBoxLabel.ClientID %>");
        var rdlstCustomized = document.getElementById("<%=rdlstCustomized.ClientID %>");

        var div_Customize = document.getElementById("div_Customize");
        var div_CustomizeLabel = document.getElementById("div_CustomizeLabel");
        var div_Ups = document.getElementById("div_Ups");

        var txtCompany = document.getElementById("<%=txtCompany.ClientID %>");
        var txtAddressLine1 = document.getElementById("<%=txtAddressLine1.ClientID %>");
        var txtAddressLine2 = document.getElementById("<%=txtAddressLine2.ClientID %>");
        var txtAddressLine3 = document.getElementById("<%=txtAddressLine3.ClientID %>");
        var txtAddressLine4 = document.getElementById("<%=txtAddressLine4.ClientID %>");
        var txtAddressLine5 = document.getElementById("<%=txtAddressLine5.ClientID %>");
        var txtCountry = document.getElementById("<%=txtCountry.ClientID %>");
        var txtTelephone = document.getElementById("<%=txtTelephone.ClientID %>");
        var txtFax = document.getElementById("<%=txtFax.ClientID %>");
        var txtTotalQty = document.getElementById("<%=txtTotalQty.ClientID %>");

        var div_Label = document.getElementById("div_Label");
        var div_PrintContentMain = document.getElementById("div_PrintContentMain");
        var div_PrintContent = document.getElementById("div_PrintContent");
        var lblPrint = document.getElementById("<%=lblPrint.ClientID %>");
        var txtNoOfLabels = document.getElementById("<%=txtNoOfLabels.ClientID %>");
        var txtNoOfLeaves = document.getElementById("<%=txtNoOfLeaves.ClientID %>");

        var txtPrefix1 = document.getElementById("<%=txtPrefix1.ClientID %>");
        var txtSuffix1 = document.getElementById("<%=txtSuffix1.ClientID %>");
        var txtStart1 = document.getElementById("<%=txtStart1.ClientID %>");
        var txtEnd1 = document.getElementById("<%=txtEnd1.ClientID %>");
        var txtPrefix2 = document.getElementById("<%=txtPrefix2.ClientID %>");
        var txtSuffix2 = document.getElementById("<%=txtSuffix2.ClientID %>");
        var txtStart2 = document.getElementById("<%=txtStart2.ClientID %>");
        var txtEnd2 = document.getElementById("<%=txtEnd2.ClientID %>");
        var txtPrefix3 = document.getElementById("<%=txtPrefix3.ClientID %>");
        var txtSuffix3 = document.getElementById("<%=txtSuffix3.ClientID %>");
        var txtStart3 = document.getElementById("<%=txtStart3.ClientID %>");
        var txtEnd3 = document.getElementById("<%=txtEnd3.ClientID %>");
        var txtPrefix4 = document.getElementById("<%=txtPrefix4.ClientID %>");
        var txtSuffix4 = document.getElementById("<%=txtSuffix4.ClientID %>");
        var txtStart4 = document.getElementById("<%=txtStart4.ClientID %>");
        var txtEnd4 = document.getElementById("<%=txtEnd4.ClientID %>");

        var hid_labletype_rows = document.getElementById("<%=hid_labletype_rows.ClientID %>");
        var hid_labletype_col = document.getElementById("<%=hid_labletype_col.ClientID %>");
        var hid_startrow = document.getElementById("<%=hid_startrow.ClientID %>");
        var hid_startcol = document.getElementById("<%=hid_startcol.ClientID %>");
        var hid_boxlable = document.getElementById("<%=hid_boxlable.ClientID %>");
        var hid_nooflableonprintview = document.getElementById("<%=hid_nooflableonprintview.ClientID %>");
        var hid_address_text = document.getElementById("<%=hid_address_text.ClientID %>");
        var hdn_InvCode = document.getElementById("<%=hdn_InvCode.ClientID %>");
        var hdn_InvName = document.getElementById("<%=hdn_InvName.ClientID %>");
        var hdn_InvDesc = document.getElementById("<%=hdn_InvDesc.ClientID %>");
        var hdn_TotalQty = document.getElementById("<%=hdn_TotalQty.ClientID %>");
        var hdn_labeltype = document.getElementById("<%=hdn_labeltype.ClientID %>");
        var hdn_InvLocation = document.getElementById("<%=hdn_InvLocation.ClientID %>");

        var spn_StartEnd1 = document.getElementById("spn_StartEnd1");

        //PPW Box Labels
        var div_PPWlabel = document.getElementById("div_PPWlabel");
        var div_PPWContent = document.getElementById("div_PPWContent");
        var div_MasproLabel = document.getElementById("div_MasproLabel");
        var div_MasproContent = document.getElementById("div_MasproContent");

        hdn_DeliveryNoteType.value = "split";

        var DelRaise_Type = '<%=DelRaise_Type %>';
        var ConDelRaise_Type = '<%=ConDelRaise_Type %>';


        //DELIVERY NOTE EDIT SECTION          
        function More_Address_DelRaised(clickval) {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=<%=ClientID %>&pg=<%=pg %>&clickval=" + clickval + "&fromsplit=yes&Estid=<%=EstimateID%>&IsDel=yes&isViewAllCompanyAddress=yes").setSize('1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        var txtDelQty_No = "";
        function SaveQtyDelivered(obj, cnt, DelID, DelItemID, EstItemID, EstType, DelQty, totDelcnt, ItemNo, DelType) {
            var totalDelQty = 0;
            var txtQtyProduced = '';
            var lblQtyOrdered = '';
            var lblQtyDelivered = '';
            var lblQtyAvailable = '';
            var txtDelQty = document.getElementById("ctl00_ContentPlaceHolder1_txtDelQty_" + EstItemID + "_" + cnt + "");
            var lblDelAdd = document.getElementById("lblDelAdd_" + EstItemID + "_" + cnt + "");
            var lblDelAddID = document.getElementById("lblDelAddID_" + EstItemID + "_" + cnt + "");
            var lblDelAddType = document.getElementById("lblDelAddType_" + EstItemID + "_" + cnt + "");

            if (DelType == 'split') {
                txtQtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtQtyProduced_" + ItemNo + "");
                lblQtyOrdered = document.getElementById("lblqtyordered_" + ItemNo + "");
                lblQtyDelivered = document.getElementById("lblQtyDelivered_" + ItemNo + "");
                lblQtyAvailable = document.getElementById("lblSplitBalance_" + ItemNo + "");
            }
            else if (DelType == 'consolidate') {
                txtQtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtCon_QtyProduced_" + ItemNo + "");
                lblQtyOrdered = document.getElementById("lblconqtyordered_" + ItemNo + "");
                lblQtyDelivered = document.getElementById("lblconQtyDelivered_" + ItemNo + "");
                lblQtyAvailable = document.getElementById("lblConBalance_" + ItemNo + "");
            }

            for (var i = 0; i < totDelcnt; i++) {
                totalDelQty = totalDelQty + Number(document.getElementById("ctl00_ContentPlaceHolder1_txtDelQty_" + EstItemID + "_" + i + "").value);
            }

            txtDelQty.style.backgroundImage = 'none';

            if (trim12(txtDelQty.value) == "") {
                alert("Qty cannot be blank.");
            }
            else {
                if (totalDelQty > Number(txtQtyProduced.value)) {
                    alert("Qty Delivering is greater than the Qty Produced.");
                }
                else {

                    txtDelQty_No = txtDelQty;
                    txtDelQty.style.backgroundImage = 'url(../images/loading27.gif)';
                    txtDelQty.style.backgroundRepeat = 'no-repeat';
                    txtDelQty.style.backgroundPosition = 'left';
                    txtDelQty.style.backgroundcolor = "white";
                    txtDelQty.style.opacity = "0.6";
                    txtDelQty.style.filter = "alpha(opacity=60)";

                    ePrint.press_select.DeliveryQty_Update('<%=CompanyID %>', DelID, DelItemID, EstItemID, EstType, lblDelAddID.innerHTML, lblDelAddType.innerHTML, txtDelQty.value, OnSucc_DelQtySave)
                    var QtyAvail = Number(txtQtyProduced.value) - totalDelQty;

                    lblQtyAvailable.innerHTML = Number(QtyAvail) < 0 ? "0" : Number(QtyAvail);
                }
            }
        }
        function windowclose(path) {
            window.close();
            window.parent.location = path;
        }


        function OnSucc_DelQtySave(result) {
            txtDelQty_No.style.backgroundImage = 'none';
            txtDelQty_No.style.opacity = "1";
            txtDelQty_No.style.filter = "alpha(opacity=100)";
            txtDelQty_No = '';
        }
        //END OF DELIVERY NOTE EDIT SECTION


        function ChangetoDelevery(type) {
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";

            divraise_consolidate.style.display = "none";
            document.getElementById("<%=div_btncontinue_consolidate.ClientID %>").style.display = "none";
            document.getElementById("<%=divbuttonsup_consolidate.ClientID %>").style.display = "none";
            div_btnRaiseDeliveyNote.style.display = "none";
            div_btnRaiseMultiple.style.display = "none";
            div_btnonlyRaise.style.display = "none";

            divmessage.style.display = "none";
            divcustomername.style.display = "block";

            lnkaddnewmore.style.display = "none";
            divaaa.style.display = "none";

            if (type == 'single') {
                hdn_DeliveryNoteType.value = "single";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "block";
                div_btnonlyRaise.style.display = "block";
                divcustomername.style.display = "block";
            }
            if (type == 'split') {
                hdn_DeliveryNoteType.value = "split";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "none";
                div_btnRaiseMultiple.style.display = "block";
                lnkaddnewmore.style.display = "none";
                divaaa.style.display = "block";
                // hid_checkboxid.value = ''; //this is the identity hid value to check whethere he is in split or consolidate
            }
            if (type == 'consolidate') {
                hdn_DeliveryNoteType.value = "consolidate";
                div_ConsolidatedDelivery.style.display = "block";
                document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "block";
                document.getElementById("<%=div_btncontinue_consolidate.ClientID %>").style.display = "block";
                divraise_consolidate.style.display = "none";
                document.getElementById("<%=divbuttonsup_consolidate.ClientID %>").style.display = "block";
                div_btnonlyRaise.style.display = "none";
                //hid_checkboxid.value = '';  //by swetha to clear the prev selected consolidated items
            }
        }

        function ChangetoDeleverytype(type) {
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";
            divraise_consolidate.style.display = "none";
            document.getElementById("<%=div_btncontinue_consolidate.ClientID %>").style.display = "none";
            document.getElementById("<%=divbuttonsup_consolidate.ClientID %>").style.display = "none";
            div_btnRaiseDeliveyNote.style.display = "none";
            div_btnRaiseMultiple.style.display = "none";
            div_btnonlyRaise.style.display = "none";

            divmessage.style.display = "none";
            divcustomername.style.display = "block";

            lnkaddnewmore.style.display = "none";
            divaaa.style.display = "none";

            if (type == 'single') {
                hdn_DeliveryNoteType.value = "single";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "block";
                div_btnonlyRaise.style.display = "block";
                divcustomername.style.display = "block";
            }
            if (type == 'split') {
                document.getElementById("div_Load").style.display = "block";
                document.getElementById("ds00").style.display = "block";
                setLoadingPositionOfDivMove(div_Load);
                hdn_DeliveryNoteType.value = "split";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "none";
                div_btnRaiseMultiple.style.display = "block";
                lnkaddnewmore.style.display = "none";
                divaaa.style.display = "block";
            }
            if (type == 'consolidate') {
                document.getElementById("div_Load").style.display = "block";
                document.getElementById("ds00").style.display = "block";
                setLoadingPositionOfDivMove(div_Load);
                hdn_DeliveryNoteType.value = "consolidate";
                div_btnonlyRaise.style.display = "none";
            }
        }

        function changeCssTemp(iss) {

            document.getElementById(iss).style.color = "orange";
            for (var i = 1; i <= 5; i++) {
                var dd = "item_" + i;
                if (dd != iss) {
                    if (document.getElementById("item_" + i) != null) {
                        document.getElementById("item_" + i).style.color = "black";
                        var ff = "div_" + i;
                        ff = ff + i;
                    }
                }
                else {
                    var ff = "div_" + i;
                    ff = ff + i;
                }
            }
            div_MainDelivery.style.display = "none";
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";

            div_btnRaiseDeliveyNote.style.display = "none";
            div_btnBoxLabel.style.display = "none";
            document.getElementById("<%=div_btncontinue_consolidate.ClientID %>").style.display = "none";
            divraise_consolidate.style.display = "none";
            document.getElementById("<%=divbuttonsup_consolidate.ClientID %>").style.display = "none";
            div_btnonlyRaise.style.display = "none";

            divcustomername.style.display = "none";
            divmessage.style.display = "none";
            div_BoxLabel.style.display = "none";

            if (document.getElementById(iss).id == "item_1") {  //VIEW DELIVERY TAB
                hdn_DeliveryNoteType.value = "view";

                div_MainDelivery.style.display = "none";
            }
            if (document.getElementById(iss).id == "item_2") { //RAISE DELIVERY TAB
                document.getElementById("div_Load").style.display = "block";
                document.getElementById("ds00").style.display = "block";
                setLoadingPositionOfDivMove(div_Load);

                hdn_DeliveryNoteType.value = "single";

                div_MainDelivery.style.display = "block";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "none";
                div_btnonlyRaise.style.display = "block";

                divcustomername.style.display = "block";

                //commented on 3/1/20120 for D/n changes
                //                rdosingle.checked = true;
                //                lnkaddnewmore.style.display = "none";
                //                divaaa.style.display = "none";
                rdosplit.checked = true;
                lnkaddnewmore.style.display = "none";
                divaaa.style.display = "block";

                document.getElementById("div_Load").style.display = "none";
                document.getElementById("ds00").style.display = "none";
            }
            if (document.getElementById(iss).id == "item_3") {
                div_btnRaiseDeliveyNote.style.display = "block";
            }
            if (document.getElementById(iss).id == "item_4") {
                document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "block";
                div_btnRaiseDeliveyNote.style.display = "block";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
                document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";
            }
            if (document.getElementById(iss).id == "item_5") { //BOX LABELS
                hdn_DeliveryNoteType.value = "boxlabel";

                div_BoxLabel.style.display = "block";
                div_btnBoxLabel.style.display = "block";
                div_btnNext.style.display = "block";
                div_btnPrevious.style.display = "none";
                div_BoxLabel_Step1.style.display = "block";
                div_BoxLabel_Step2.style.display = "block";

                BindRowsColumns('1');
            }
        }

        function ShowRaiseDiv(deltype, disptype) {

            if (deltype == 'split') {
                if (disptype == 'show') {
                    div_btnRaiseDeliveyNote.style.display = "block";
                    lnkaddnewmore.style.display = "block";                 //added by INF-047
                    div_RaiseAddress_split.style.display = "block";
                    div_btnRefresh_split.style.display = "none";
                }
                else {
                    div_RaiseAddress_split.style.display = "none";
                    div_btnRefresh_split.style.display = "block";
                    div_btnRaiseDeliveyNote.style.display = "none";
                    lnkaddnewmore.style.display = "none";

                }
            }
            else {
                if (disptype == 'show') {
                    div_ConRaise.style.display = "block";
                    div_btnRefresh_con.style.display = "none";
                    div_conbtnRaise.style.display = "block";
                }
                else {
                    div_ConRaise.style.display = "none";
                    div_btnRefresh_con.style.display = "block";
                    div_conbtnRaise.style.display = "none";
                }
            }
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)				
            return oWindow;
        }

        function CallParentRefresh() {
            GetRadWindow().BrowserWindow.location.reload();
        }

        function ShowSplitDelivery() {
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "block";
            div_btnRaiseDeliveyNote.style.display = "block";
            div_btnRaiseMultiple.style.display = "none";
            hdn_DeliveryNoteType.value = "split";
        }


        function SelectItem(TypeID, EstType, ItemNo, TotItems, Qty) {
            for (var i = 0; i < TotItems; i++) {
                document.getElementById("div_SplitContent_" + i + "").style.display = "none";
                document.getElementById("div_Item_" + i + "").style.backgroundColor = "";
                if (i == ItemNo) {
                    document.getElementById("div_SplitContent_" + i + "").style.display = "block";
                    document.getElementById("div_Item_" + i + "").style.backgroundColor = "lightgray";
                    hdn_SplitQty.value = Qty;
                    hdn_lblSplitBalance.value = "lblSplitBalance_" + i + "";
                    document.getElementById("lblSplitBalance_" + ItemNo + "").innerHTML = Qty;
                    hdn_ItemNum.value = ItemNo;
                }
            }
        }

        function More_Address() {
            //PopupCenter("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=<%=ClientID %>&pg=<%=pg %>&clickval=0", '700', '400')
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=<%=ClientID %>&pg=<%=pg %>&clickval=0&isViewAllCompanyAddress=yes").setSize('1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        function More_Address_split(clickval) {
            //PopupCenter("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=<%=ClientID %>&pg=<%=pg %>&clickval=" + clickval + "&fromsplit=yes&Estid=<%=EstimateID%>", '700', '400')
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=<%=ClientID %>&pg=<%=pg %>&clickval=" + clickval + "&fromsplit=yes&Estid=<%=EstimateID%>&isViewAllCompanyAddress=yes").setSize('1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        function ViewDelNote(obj, DelID) {
            window.parent.location.href = "<%=strSitepath%>delivery/delivery_add.aspx?type=edit&id=" + DelID + "";
        }

        function ToInteger(obj, val) {
            if (val.substring(val.length - 1, val.length) == ".") {
                obj.value = val.toString().replace('.', '');
            }
            else if (val.indexOf('.') > -1) {
                obj.value = val.toString().replace('.', '');
            }
            else {
                obj.value = val;
            }
        }

        function ValidateQty(txtObj, Qty, ItemNoa, thisqtyposition) {

            if (hdn_DeliveryNoteType.value == 'split') {
                document.getElementById('divtest').innerHTML = '';
                var aaa;
                var TotalQty = '';
                var txtquantityarray = new Array();
                var hdn_SplitQtyarray = new Array();
                hdn_SplitQtyarray = hdn_SplitQty.value.split('~');

                for (var a = 0; a < Number(hdn_TotItems.value) ; a++) {
                    for (var b = 0; b <= Number(hid_value.value) ; b++) {
                        var splitqty = document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_' + b + '_' + a + '');

                        if (splitqty != null) {
                            aaa = Number(splitqty.value) + '~';
                            txtquantityarray = aaa.split('~');
                            TotalQty += (Number(hdn_SplitQtyarray[a]) + Number(txtquantityarray[b])) + '~';
                            document.getElementById('divtest').innerHTML += aaa;
                        }
                    }
                    document.getElementById('divtest').innerHTML += "±";
                }

                var arr = new Array();
                var newar = new Array();
                var mainsum = 0;
                var TotalQtyArray = new Array();
                TotalQtyArray = TotalQty.split('~');

                for (var ItemNo = 0; ItemNo < Number(hdn_TotItems.value) ; ItemNo++) {
                    arr = document.getElementById('divtest').innerHTML.split('±')[ItemNo];
                    mainsum = 0;
                    newar = arr.split('~');
                    for (var l = 0; l < newar.length - 1; l++) {
                        mainsum += Number(newar[l]);
                    }
                    var kb = Number(ItemNoa) + 1;
                    try {
                        if (ItemNo == thisqtyposition) {
                            document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_' + kb + '_' + ItemNo + '').value = Number(hdn_SplitQtyarray[ItemNo]) - Number(mainsum);
                        }
                        var txtquantity = document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_' + kb + '_' + ItemNo + '').value;
                        if (txtquantity.substring(0, 1) == '-') {
                            document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_' + kb + '_' + ItemNo + '').value = 0;
                        }
                    } catch (Error) { }

                }
            }
            else if (hdn_DeliveryNoteType.value == 'consolidate') {
                document.getElementById('divtest_conswithsplit').innerHTML = '';
                var txtqty_testconswithsplit;
                var TotalQty_conswithsplit = '';
                var txtquantityarray_conswithsplit = new Array();
                var hdn_SplitQty_conswithsplitarray = new Array();
                hdn_SplitQty_conswithsplitarray = hdn_SplitQty_conswithsplit.value.split('~');

                for (var a = 0; a < Number(hid_totItems_con_withsplit.value) ; a++) {
                    for (var b = 0; b <= Number(hid_valueconswithsplit.value) ; b++) {
                        var txtqty_test = document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_' + b + '_' + a + '');
                        if (txtqty_test != null) {
                            txtqty_testconswithsplit = Number(txtqty_test.value) + '~';
                            txtquantityarray_conswithsplit = txtqty_testconswithsplit.split('~');
                            TotalQty_conswithsplit += (Number(hdn_SplitQty_conswithsplitarray[a]) + Number(txtquantityarray_conswithsplit[b])) + '~';
                            document.getElementById('divtest_conswithsplit').innerHTML += txtqty_testconswithsplit;
                        }
                    }
                    document.getElementById('divtest_conswithsplit').innerHTML += "±";
                }

                var arr_conswithsplit = new Array();
                var newar_conswithsplit = new Array();
                var mainsum_conswithsplit = 0;
                var TotalQtyArray_conswithsplit = new Array();
                TotalQtyArray_conswithsplit = TotalQty_conswithsplit.split('~');
                for (var ItemNo = 0; ItemNo < Number(hid_totItems_con_withsplit.value) ; ItemNo++) {
                    arr_conswithsplit = document.getElementById('divtest_conswithsplit').innerHTML.split('±')[ItemNo];
                    mainsum_conswithsplit = 0;
                    newar_conswithsplit = arr_conswithsplit.split('~');
                    for (var l = 0; l < newar_conswithsplit.length - 1; l++) {
                        mainsum_conswithsplit += Number(newar_conswithsplit[l]);
                    }

                    var kb = Number(ItemNoa) + 1;
                    try {
                        if (ItemNo == thisqtyposition) {
                            var txtquantity_conswithsplit = document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_' + kb + '_' + ItemNo + '');
                            var qty_rem = Number(hdn_SplitQty_conswithsplitarray[ItemNo]) - Number(mainsum_conswithsplit);
                            //var txtquantity_conswithsplit = document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_' + ItemNo + '_' + thisqtyposition + '').value;
                            txtquantity_conswithsplit.value = qty_rem < 0 ? "0" : qty_rem;

                            //                        if (txtquantity_conswithsplit.substring(0, 1) == '-') {
                            //                            document.getElementById('ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_' + ItemNo + '_' + thisqtyposition + '').value = 0;
                            //                        }
                        }
                    }
                    catch (Error) { }

                }

            }
        }



        var checkfalse = true;
        function SaveDeliveryNote(status) {
            var FinalValue = '';
            var lbladdress = '';
            var zeroqty_cntsplit = 0;
            var checkQtyAvai = 0;
            //try {
            if (hdn_DeliveryNoteType.value == "single" || hdn_DeliveryNoteType.value == "split") {
                for (var i = 0; i <= Number(hid_value.value) ; i++) {
                    var ClientID = '<%=ClientID %>';
                    var AttentionID = '<%=AttentionID %>';

                    for (var j = 0; j < hdn_TotItems.value; j++) {
                        var txt = document.getElementById("ctl00_ContentPlaceHolder1_txtSplitQty_" + i + "_" + j + "");
                        if (j == 0) {
                            lbladdress = document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_" + i + "_" + j + "");
                            if (lbladdress != null) {
                                if (lbladdress.innerHTML == '') {
                                    alert('please select address');
                                    return false;
                                }
                            }
                        }

                        if (txt != null) {
                            if (trim12(txt.value) != "" && trim12(txt.value) != Number(0)) {

                                var Quantity = txt.value;
                                var AddressID = document.getElementById("spnAddID_" + i + "_0").innerHTML;
                                var AddressType = document.getElementById("spnAddType_" + i + "_0").innerHTML;

                                var EstimateID = document.getElementById("spnEstimateID_split_" + i + "_" + j + "").innerHTML;
                                var EstimateItemID = document.getElementById("spnEstimateItemID_split_" + i + "_" + j + "").innerHTML;
                                var EstimateType = document.getElementById("spnEstimateType_split_" + i + "_" + j + "").innerHTML;
                                var ItemDescription = document.getElementById("spnItemDesc_split_" + i + "_" + j + "").innerHTML;

                                var strValue = "";
                                if (hdn_DeliveryNoteType.value == "single") {

                                    hid_thisaddressid.value = AddressID;
                                    hid_thisaddresstype.value = AddressType;
                                    strValue = "ItemNoÇ" + i + "±" + "QuantityÇ" + Quantity + "±" + "AddressIDÇ" + AddressID + "±" + "AddressTypeÇ" + AddressType + "±" + "TotalItemÇ" + j + "±" + "EstimateIDÇ" + EstimateID + "±" + "EstimateItemIDÇ" + EstimateItemID + "±" + "EstimateTypeÇ" + EstimateType + "±" + "ItemDescriptionÇ" + ItemDescription + "~";
                                }
                                else {
                                    strValue = "ItemNoÇ" + i + "±" + "QuantityÇ" + Quantity + "±" + "AddressIDÇ" + AddressID + "±" + "AddressTypeÇ" + AddressType + "±" + "TotalItemÇ" + j + "±" + "EstimateIDÇ" + EstimateID + "±" + "EstimateItemIDÇ" + EstimateItemID + "±" + "EstimateTypeÇ" + EstimateType + "±" + "ItemDescriptionÇ" + ItemDescription + "~";

                                    //strValue = "ItemNo»" + i + "±" + "Quantity»" + Quantity + "±" + "AddressID»" + AddressID + "±" + "AddressType»" + AddressType + "±" + "TotalItem»" + j + "±" + "EstimateID»" + EstimateID + "±" + "EstimateItemID»" + EstimateItemID + "±" + "EstimateType»" + EstimateType + "±" + "ItemDescription»" + ItemDescription + "µ";
                                }
                                FinalValue += strValue;

                                if (zeroqty_cntsplit > 0) {
                                    zeroqty_cntsplit--;
                                }

                                //check for QtyAvailable
                                var lblQtyAvailale = document.getElementById("lblSplitBalance_" + j + "").innerHTML;
                                var val1 = Number(txt.value) > 0;
                                var val2 = Number(txt.value) > Number(lblQtyAvailale);
                                if (val1 && val2) {
                                    checkQtyAvai++;
                                }
                            }
                        }
                        else {
                            zeroqty_cntsplit++;
                        }
                    }
                }
            }
            else if (hdn_DeliveryNoteType.value == "consolidate") {
                var totitems = Number(lblConTotItems.innerHTML);
                var Counter = 0;
                var frm = document.forms[0];
                var Ides = "";

                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox') {//&& e.name.indexOf('Id') != -1
                        if (e.checked) {
                            Counter = Number(Counter) + 1;
                            Ides = Ides + e.value + ",";

                            var EstID = document.getElementById("spnEstID_" + e.value + "").innerHTML;
                            var EstItemID = document.getElementById("spnEstItemID_" + e.value + "").innerHTML;
                            var EstType = document.getElementById("spnEstType_" + e.value + "").innerHTML;
                            var Desc = document.getElementById("lblConDesc_" + e.value + "").innerHTML;
                            var Qty = document.getElementById("lblConQty_" + e.value + "").innerHTML;

                            var strValue = "EstID»" + EstID + "±" + "EstItemID»" + EstItemID + "±" + "EstType»" + EstType + "±" + "Description»" + Desc + "±" + "Qty»" + Qty + "µ";
                            FinalValue += strValue;
                        }
                    }
                }
            }
            else if (hdn_DeliveryNoteType.value == "single") {
                for (var j = 0; j < hdn_TotItems.value; j++) {
                    var lbldelivered = document.getElementById("lblSplitBalance_" + j + "").innerHTML;
                    if (lbldelivered == 0) {
                    }
                }
            }

            hdn_SaveData.value = FinalValue;


            for (var z = 0; z < Number(hdn_TotItems.value) ; z++) {
                var QtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtQtyProduced_" + z + "").value;
                var QtyProdEstIemID = document.getElementById("ctl00_ContentPlaceHolder1_hdn_Split_QtyProd_EstItemID_" + z + "").value;
                var QtyProdEstType = document.getElementById("ctl00_ContentPlaceHolder1_hdn_Split_QtyProd_EstType_" + z + "").value;
                hdn_splitQtyProduced.value += QtyProduced + '±' + QtyProdEstIemID + '±' + QtyProdEstType + "µ";

                var lblqtyordered = document.getElementById("lblqtyordered_" + z + "").innerHTML;
                if (Number(QtyProduced) < Number(lblqtyordered)) {
                    alert("Qty Produced cannot be less than the Qty Ordered. Please increase Qty Produced");
                    return false;
                }
            }
            if (FinalValue == "") {
                if (hdn_DeliveryNoteType.value == "consolidate") {
                    alert("Please select at least one item to raise");
                }
                else {
                    alert("Please enter some quantity to raise.");
                }
                return false;
            }
            else {
                if (zeroqty_cntsplit == Number(hdn_TotItems.value)) {
                    alert("Please enter some quantity to raise.");
                    return false;
                }
                else {

                    if (checkQtyAvai > 0) {
                        alert("Quantity raised is greater than the quantity available. Please increase available qty or change Qty Produced");
                        return false;
                    }
                    else {
                        document.getElementById("div_Load").style.display = "block";
                        document.getElementById("ds00").style.display = "block";
                        setLoadingPositionOfDivMove(div_Load);
                        if (status.toLowerCase() == "raiseclose") {
                            setTimeout(function () { Close() }, 3000);
                            return true;
                        }
                        return true;
                    }
                }
            }
            //            div_SplitDelivery.style.display = "none";
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            //           }
            //           catch (Error) { }
        }

        function Close() {
            window.frameElement.radWindow.BrowserWindow.location.reload();
            var oWindow = GetRadWindow();
            oWindow.close();
            return true;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function ShowJobCard(EstID, EstItemID, jobID) {
            //PopupCenter("<%=nmsCommon.global.sitePath()%>jobs/job_card_new.aspx?EstimateID=" + EstID + "&EstItemID=" + EstItemID + "&IsDel=yes", '1000', '500')
            window.radopen("<%=nmsCommon.global.sitePath()%>jobs/job_card_new.aspx?jID=" + jobID + "&EstimateID=" + EstID + "&EstItemID=" + EstItemID + "&IsDel=yes").setSize('1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;
        }

        function ValidateForm(dml, chkName) {
            len = dml.elements.length;
            var i = 0;
            for (i = 0; i < len; i++) {
                if ((dml.elements[i].name == chkName) && (dml.elements[i].checked == 1)) return true
            }
            alert("Please select at least one record to be deleted")
            return false;
        }

        function checkAll_new(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    e.checked = ChkState;
                }
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    e.checked = ChkState;
                }
                if (e.type == 'checkbox') {
                    e.checked = ChkState;
                }
            }
            var totitems = Number(hdn_contotitems.value);
            var TotQty = 0;
            if (ChkState) {
                for (var j = 1; j < totitems; j++) {
                    if (document.getElementById("lblConAvialbleQty_" + j) != null) {
                        var qty = Number(document.getElementById("lblConAvialbleQty_" + j + "").innerHTML);
                        var estitemid = Number(document.getElementById("spnEstItemIDChckall_" + j + "").innerHTML);
                        hid_checkboxid.value += estitemid + '~';
                        TotQty += qty;
                    }
                }
            }
            else {
                hid_checkboxid.value = "";
                TotQty = "";
            }
            if (ChkState) {
                lblConTotItems.innerHTML = totitems;
                lblConTotQty.innerHTML = TotQty;
            }
            else {
                lblConTotItems.innerHTML = "0";
                lblConTotQty.innerHTML = "0";
            }
        }

        var contotitems = 0;
        function GetConQty(chkobj, qty, estitemid) {
            if (lblConTotItems.innerHTML != '') {
                contotitems = Number(lblConTotItems.innerHTML);
            }
            lblConTotItems.innerHTML = '';
            hid_checkboxid.value += estitemid + '~';

            if (chkobj.checked) {
                lblConTotQty.innerHTML = Number(lblConTotQty.innerHTML) + qty;
                contotitems++;
            }
            else if (chkobj == 'chkinitial') {
                lblConTotQty.innerHTML = Number(lblConTotQty.innerHTML) + qty;
                contotitems++;
            }
            else {
                lblConTotQty.innerHTML = Number(lblConTotQty.innerHTML) - qty;
                contotitems--;
            }
            lblConTotItems.innerHTML = contotitems;
        }
    </script>
    <script type="text/javascript">

        function displayClientAddress(CompanyID, ClientID, Clientaddress, thisid) {

            var Clientaddress;
            var val = CompanyID + '±' + ClientID + '±' + Clientaddress + '±' + thisid;
            ePrint.press_select.GetClientAddress_Delivery(val, onResponse1);
        }

        function onResponse1(response) {
            var findtxtaddress = hid_thisaddressid.value.split('_')[3];
            document.getElementById("divCheck_" + findtxtaddress + "").style.display = 'block';
            document.getElementById("divCheck_" + findtxtaddress + "").innerHTML = response;
        }

        function onTimeout1(request, context) {

        }
        function onError1(objError) {

        }
        function ShowOff(divid) {
            //document.getElementById(divid).style.display='none';
        }
        function showon(divid) {
            document.getElementById(divid).style.display = 'block';
        }


        //More_splitaddress();//To load 2 address by default -- now changed only one to be shown by default hence commenting on 20-1-2012

        function More_splitaddress() {
            var comanyid = hid_companyid.value;
            var clientid = hid_clientid.value;
            hid_value.value = Number(hid_value.value) + 1;  //on the click of plus image.

            var k = hid_value.value;

            var div_CtrlList = document.getElementById('divaaa');

            var counter = div_CtrlList.getElementsByTagName('input');
            for (var i = 0; i < counter.length; i++) {
                if (counter[i].type == 'text') {
                    var newtextbox = document.getElementById(counter[i].id);
                    newtextbox.setAttribute('value', newtextbox.value);
                }
            }
            var divaddmoresplit = '';
            divaddmoresplit += "<div align='left' id='divMain_split_" + k + "' style='width: 100%;padding-top: 0px;'>";
            divaddmoresplit += "<table id='maintable_split' cellspacing=0 cellpadding=0 width=100% align=left style='vertical-align: top'><tR><tD>";
            divaddmoresplit += "<div id='div_SplitContent_" + k + "' style='float: left;width: 100%;table-layout: fixed;border: 1px solid #A4A4A4;border-top: 0px;'>";

            divaddmoresplit += "<div class='onlyEmpty'></div>";
            var splititemtitle = "<%=JobItemTitle_newrow%>";
            var splititemtitlearr = new Array();
            var splitestimateitemidarray = new Array();
            var splitestimateidarray = new Array();
            var splitestimatetypearray = new Array();
            var splititemdescarray = new Array();

            splititemtitlearr = splititemtitle.split('~');
            splitestimateidarray = hdn_splitEstimateID.value.split('~');
            splitestimateitemidarray = hdn_splitEstimateItemID.value.split('~');
            splitestimatetypearray = hdn_splitEstimateType.value.split('~');
            splititemdescarray = hdn_splitItemDesc.value.split('~');

            hid_rowvalue.value = Number(hid_rowvalue.value) + 1;

            for (var m = 0; m < Number(hdn_TotItems.value) ; m++) {
                divaddmoresplit += "<div align='left' style='width: 100%;height: 20px;border-left: 0px solid;clear: both;padding-bottom: 3px' class='NewTableRow normalText'>";

                if (m == 0) {
                    divaddmoresplit += "<div  style='float: left; width: 5%;padding: 2 3 2 6px;vertical-align: middle;border-right:0px solid;'>";
                    divaddmoresplit += "<label id='ctl00_ContentPlaceHolder1_splitslno_" + k + "_" + m + "'>" + hid_rowvalue.value + "</label>";
                    divaddmoresplit += "</div>";
                }
                else {
                    divaddmoresplit += "<div  style='float: left; width: 5%;padding: 2 3 2 6px;vertical-align: middle;border-right:0px solid;'>";
                    divaddmoresplit += "";
                    divaddmoresplit += "</div>";
                }

                divaddmoresplit += "<div style='float: left;width: 5px;'>&nbsp;</div>"; //CLR 

                divaddmoresplit += "<div style='float: left;width: 33%;overflow:hidden;max-width: 33%;height:16px;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white;'>"; //Qty
                divaddmoresplit += SpecialDecode(splititemtitlearr[m]);
                divaddmoresplit += "</div>";

                divaddmoresplit += "<div style='float: left;width: 5px;'>&nbsp;</div>"; //CLR 

                divaddmoresplit += "<div style='float: left;width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;'>";
                divaddmoresplit += "<input type='text' value=0  id='ctl00_ContentPlaceHolder1_txtSplitQty_" + k + "_" + m + "' class='textboxnew' style='width: 100;text-align:right;' onfocus='javascript:this.select();' onkeyup='javascript:AllowNumber(this,this.value);' onblur='javascript:ValidateQty(this,this.value," + k + "," + m + ");' />";
                divaddmoresplit += "<span style='display: none' id='spnEstimateItemID_split_" + k + "_" + m + "'>" + splitestimateitemidarray[m] + "</span><span style='display: none' id='spnEstimateType_split_" + k + "_" + m + "'>" + splitestimatetypearray[m] + "</span><span style='display: none' id='spnEstimateID_split_" + k + "_" + m + "'>" + splitestimateidarray[m] + "</span><span style='display: none' id='spnItemDesc_split_" + k + "_" + m + "'>" + splititemdescarray[m] + "</span>";
                divaddmoresplit += "</div>";

                divaddmoresplit += "<div style='float: left;width: 4%;'>&nbsp;</div>"; //CLR 

                if (m == 0) {
                    divaddmoresplit += "<div style='float: left;width: 40%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px;'>";
                    divaddmoresplit += "<img src='../images/plus.gif' title='Add address' style='vertical-align: top;padding-left: 3px;cursor:pointer;' onclick=javascript:More_Address_split('" + k + "_" + m + "');return false; />";
                    divaddmoresplit += "&nbsp;<label id='ctl00_ContentPlaceHolder1_txtaddress_" + k + "_" + m + "' >" + SpecialDecode(hid_address_text.value) + "</label>";
                    divaddmoresplit += "<div>"; //title='"+ hid_address_text.value +"'
                    divaddmoresplit += "<span style='display: block' id='spnAddID_" + k + "_" + m + "'>" + hid_thisaddressid.value + "</span><span style='display: block' id='spnAddType_" + k + "_" + m + "'>" + hid_thisaddresstype.value + "</span>";
                    divaddmoresplit += "</div>";
                    divaddmoresplit += "</div>";
                    divaddmoresplit += "<div style='float: right;'><img src='../images/erase.png' title='Delete' style='cursor:pointer;padding: 3px' onclick='javascript:More_Address_split_remove(" + k + ");return false;' />";
                    divaddmoresplit += "</div>";
                }
                else {
                    divaddmoresplit += "<div style='float: left;width: 40%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px;'>";
                    divaddmoresplit += "";
                    divaddmoresplit += "</div>";
                }
                divaddmoresplit += "</div>";
            }
            divaddmoresplit += "<div class='onlyEmpty'></div>";
            divaddmoresplit += "</div>";



            divaddmoresplit += "</td>";
            //divaddmoresplit += "<td valign='top'><img src='../images/close.gif' title='' style='cursor:pointer;vertical-align:top;padding-left: 5px' onclick='javascript:More_Address_split_remove(" + k + ");return false;' /></td>";
            divaddmoresplit += "</tR></table>";
            divaddmoresplit += "<div class='onlyEmpty'></div>";
            divaddmoresplit += "</div>";
            document.getElementById("divaaa").innerHTML += divaddmoresplit;
        }


        //function SendAddressIDandName(id, values, isdelivery, tooltip, addresstype)
        function SendAddressIDandName(id, values, AddLine1, City, State, PostCode, Country, Phone, Fax, addresstype, clickval, IsDel, AddLine2) {
            //alert(id + ', ' + values + ', ' + AddLine1 + ', ' + City + ', ' + State + ', ' + PostCode + ', ' + Country + ', ' + Phone + ', ' + Fax + ', ' + addresstype + ', ' + clickval + ', ' + IsDel + ', ' + AddLine2);
            values = trim12(values);
            if (IsDel == "yes") {
                var i = 0;
                while (i < values.length) {
                    values = values.replace('<br/>', ' ');
                    i++;
                }
                values = values.length < 35 ? values : values.substring(0, 35) + "...";
                document.getElementById("lblDelAdd_" + clickval + "").innerHTML = SpecialDecode(values);
                document.getElementById("lblDelAddID_" + clickval + "").innerHTML = id;
                document.getElementById("lblDelAddType_" + clickval + "").innerHTML = addresstype;
            }
            else {
                if (hdn_DeliveryNoteType.value == 'single' || hdn_DeliveryNoteType.value == 'split') {
                    var i = 0;
                    while (i < values.length) {
                        values = values.replace('<br/>', ' ');
                        i++;
                    }

                    // By 018
                    // document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_" + clickval + "").innerHTML = values;
                    // document.getElementById("spnAddID_" + clickval + "").innerHTML = id;
                    // hid_thisaddressid.value = id;
                    // document.getElementById("spnAddType_" + clickval + "").innerHTML = addresstype;
                    // hid_thisaddresstype.value = addresstype;


                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_" + clickval + "") != null) {
                        document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_" + clickval + "").innerHTML = SpecialDecode(values);
                        document.getElementById("spnAddID_" + clickval + "").innerHTML = id;
                        hid_thisaddressid.value = id;
                        document.getElementById("spnAddType_" + clickval + "").innerHTML = addresstype;
                        hid_thisaddresstype.value = addresstype;
                    }
                    else {
                        document.getElementById("lblDelAdd_" + clickval + "").innerHTML = SpecialDecode(values);
                        document.getElementById("lblDelAddID_" + clickval + "").innerHTML = id;
                        hid_thisaddressid.value = id;
                        document.getElementById("lblDelAddType_" + clickval + "").innerHTML = addresstype;
                        hid_thisaddresstype.value = addresstype;
                    }


                }
                else if (hdn_DeliveryNoteType.value == 'consolidate') {
                    var i = 0;
                    while (i < values.length) {
                        values = values.replace('<br/>', ' ');
                        i++;
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_conswithsplit_" + clickval + "").innerHTML = SpecialDecode(values);
                    document.getElementById("spnAddID_conswithsplit_" + clickval + "").innerHTML = id;
                    hid_thisaddressid.value = id;
                    document.getElementById("spnAddType_conswithsplit_" + clickval + "").innerHTML = addresstype;
                    hid_thisaddresstype.value = addresstype;
                }

                else if (hdn_DeliveryNoteType.value == 'boxlabel') {
                    txtAddressLine1.value = SpecialDecode(AddLine1);
                    txtAddressLine2.value = SpecialDecode(AddLine2);
                    txtAddressLine3.value = SpecialDecode(City);
                    txtAddressLine4.value = SpecialDecode(State);
                    txtAddressLine5.value = SpecialDecode(PostCode);
                    if (Country == "--- Select ---") {
                        txtCountry.value = "";
                    }
                    else {
                        txtCountry.value = Country
                    }
                    txtTelephone.value = Phone;
                    txtFax.value = Fax;
                }
            }
        }

        function ContinueonConsolidate(type) {
            hdn_consolidate_raise_type.value = type;

            //==To select at least one item before raising the delivery note -- Swetha M.S on 21/3/2011 ===//
            var cntrow = 0;
            cntrow = lblConTotItems.innerHTML;
            //==To select at least one item before raising the delivery note -- Swetha M.S on 21/3/2011 ===//

            if (cntrow == 0) {
                alert("Please select at least one item to raise");
                return false;
            }
            else {
                document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "none";
                hdn_DeliveryNoteType.value = "consolidate";
                document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";

                document.getElementById("div_Load").style.display = "block";
                document.getElementById("ds00").style.display = "block";
                setLoadingPositionOfDivMove(div_Load);

                btnRaiseDeliveryNote.style.display = "none";
                btnCancel_ConDeliveryNote.style.display = "none";

                rdoconsolidate.checked = true;
                if (type == 'single') {
                    rdosingle.checked = false;
                    rdosplit.checked = false;
                    lnkaddnewmore.style.display = "none";
                }
                else {
                    rdosplit.checked = false;
                    rdosingle.checked = false;
                }
                rdosingle.disabled = true;
                rdosplit.disabled = true;
                document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
                document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "block";

                div_btnonlyRaise.style.display = "none";
                hdn_DeliveryNoteType.value = "consolidate";
                document.getElementById("div_btnRaiseDeliveyNote").style.display = "none";

                div_conbtnRaise.style.display = "none";

                if (hdn_consolidate_raise_type.value == "single") {
                    lnk_addmore_conwithsplit.style.display = "none";
                    div_conbtnRaise.style.display = "none";
                }
                else {
                    div_btnRefresh_con.style.display = "block";
                    div_conbtnRaise.style.display = "none";
                }

                return true;
            }
        }

        if (DelRaise_Type == "" && hid_checkboxid.value == '') {
            changeCssTemp('item_2');
        }
        else if (hid_checkboxid.value != '') {
            rdoconsolidate.checked = true;
            rdosingle.checked = false;
            rdosplit.checked = false;
            rdosingle.disabled = true;
            rdosplit.disabled = true;

            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "block";

            div_btnonlyRaise.style.display = "none";
            hdn_DeliveryNoteType.value = "consolidate";
            document.getElementById("div_btnRaiseDeliveyNote").style.display = "none";

            if (hdn_consolidate_raise_type.value == "single") {
                lnk_addmore_conwithsplit.style.display = "none";
                div_conbtnRaise.style.display = "none";
            }
            else {
                //lnk_addmore_conwithsplit.style.display = "block";
                //lnk_addmore_conwithsplit.style.display = "none";//on 9-1-2012

                div_btnRefresh_con.style.display = "block";
                div_conbtnRaise.style.display = "none";
            }
        }


    //More_splitaddress_conswithsplit();
    function More_splitaddress_conswithsplit() {

        var comanyid = hid_companyid.value;
        var clientid = hid_clientid.value;
        hid_valueconswithsplit.value = Number(hid_valueconswithsplit.value) + 1;  //on the click of plus image.
        var k_s = hid_valueconswithsplit.value;

        var div_CtrlList = document.getElementById('divaddmore_conswithsplit');

        var counter = div_CtrlList.getElementsByTagName('input');
        for (var i = 0; i < counter.length; i++) {
            if (counter[i].type == 'text') {
                var newtextbox = document.getElementById(counter[i].id);
                newtextbox.setAttribute('value', newtextbox.value);
            }
        }
        var divaddmoreconsolidate = '';
        divaddmoreconsolidate += "<div id='divMain_split_conswithsplit_" + k_s + "' align='left' style='width: 100%;padding-top: 0px;'>";
        divaddmoreconsolidate += "<table id='maintable_split' cellspacing=0 cellpadding=0 align=left width='100%' style='vertical-align: top'><tR><tD>";
        divaddmoreconsolidate += "<div id='div_SplitContent_conswithsplit_" + k_s + "'  style='float: left;width: 100%;table-layout: fixed;border:1px solid black;border-top:0px solid white;'>";

        var splititemtitle = "<%=JobItemTitle_conswithsplit_newrow%>";
            var splititemtitlearr = new Array();
            var splitestimateitemidarray = new Array();
            var splitestimateidarray = new Array();
            var splitestimatetypearray = new Array();
            var splititemdescarray = new Array();

            splititemtitlearr = splititemtitle.split('~');
            splitestimateitemidarray = hid_estimateitemid.value.split('~');
            splitestimateidarray = hid_estimateid.value.split('~');
            splitestimatetypearray = hid_estimatetype.value.split('~');
            splititemdescarray = hid_itemdescription.value.split('~');

            hid_rowvalue_cons.value = Number(hid_rowvalue_cons.value) + 1;
            for (var m = 0; m < Number(hid_totItems_con_withsplit.value) ; m++) {
                divaddmoreconsolidate += "<div align='left' style='width: 100%;height: 20px;border-left: 0px solid;clear: both' class='NewTableRow normalText'>";

                if (m == 0) {
                    divaddmoreconsolidate += "<div  style='float: left; width: 6%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>";
                    divaddmoreconsolidate += "<label id='ctl00_ContentPlaceHolder1_splitslno_conswithsplit_" + k_s + "_" + m + "'>" + hid_rowvalue_cons.value + "</label>";
                    divaddmoreconsolidate += "</div>";
                }
                else {
                    divaddmoreconsolidate += "<div  style='float: left; width: 6%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>";
                    divaddmoreconsolidate += "";
                    divaddmoreconsolidate += "</div>";
                }

                divaddmoreconsolidate += "<div style='float: left;width: 5px'>&nbsp;</div>"; //CLR  

                divaddmoreconsolidate += "<div style='overflow:hidden;float: left;width: 36%;max-width: 36%padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid white'>"; //Qty
                divaddmoreconsolidate += "&nbsp;" + splititemtitlearr[m];
                divaddmoreconsolidate += "</div>";

                divaddmoreconsolidate += "<div style='float: left;width: 5px'>&nbsp;</div>"; //CLR  

                divaddmoreconsolidate += "<div style='text-align:right;float: left; width: 10%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid'>";
                divaddmoreconsolidate += "<input type='text' value=0  id='ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_" + k_s + "_" + m + "' class='textboxnew' style='width:100;text-align:right;' onfocus='javascript:this.select();' onkeyup='javascript:AllowNumber(this,this.value);' onblur='javascript:ValidateQty(this,this.value," + k_s + "," + m + ");' />";
                divaddmoreconsolidate += "<span style='display: none' id='spnEstimateItemID_conswithsplit_" + k_s + "_" + m + "'>" + splitestimateitemidarray[m] + "</span><span style='display: none' id='spnEstimateType_conswithsplit_" + k_s + "_" + m + "'>" + splitestimatetypearray[m] + "</span><span style='display: none' id='spnEstimateID_conswithsplit_" + k_s + "_" + m + "'>" + splitestimateidarray[m] + "</span><span style='display: none' id='spnItemDesc_conswithsplit_" + k_s + "_" + m + "'>" + splititemdescarray[m] + "</span>";
                divaddmoreconsolidate += "</div>";

                divaddmoreconsolidate += "<div style='float: left;width: 4%'>&nbsp;</div>"; //CLR  

                if (m == 0) {
                    divaddmoreconsolidate += "<div style='float: left;width: 35%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px'>";
                    divaddmoreconsolidate += "<img src='../images/plus.gif' title='Add address' style='vertical-align: top;padding-left: 5px;cursor:pointer;' onclick=javascript:More_Address_split('" + k_s + "_" + m + "');return false; />";
                    divaddmoreconsolidate += "<label id='ctl00_ContentPlaceHolder1_txtaddress_conswithsplit_" + k_s + "_" + m + "'>" + hid_address_text.value + "</label>";
                    divaddmoreconsolidate += "<div>";
                    divaddmoreconsolidate += "<span style='display: none' id='spnAddID_conswithsplit_" + k_s + "_" + m + "'>" + hid_thisaddressid.value + "</span><span style='display: none' id='spnAddType_conswithsplit_" + k_s + "_" + m + "'>" + hid_thisaddresstype.value + "</span>";
                    divaddmoreconsolidate += "</div>";
                    divaddmoreconsolidate += "</div>";
                    divaddmoreconsolidate += "<div style='float: right;'><img src='../images/erase.png' title='Delete' style='cursor:pointer;padding: 3px' onclick='javascript:More_Address_split_remove_conswithsplit(" + k_s + ");return false;' />";
                    divaddmoreconsolidate += "</div>";
                }
                else {
                    divaddmoreconsolidate += "<div style='float: left;width: 35%;padding: 2 3 2 3px;vertical-align: middle;border-right:0px solid;overflow:hidden; max-width: 40%;height:15px'>";
                    divaddmoreconsolidate += "";
                    divaddmoreconsolidate += "</div>";
                }
                divaddmoreconsolidate += "<div class='onlyEmpty'></div>";
                divaddmoreconsolidate += "</div>";
            }
            divaddmoreconsolidate += "</div>";
            divaddmoreconsolidate += "</td>";
            divaddmoreconsolidate += "</tR></table>";
            divaddmoreconsolidate += "</div>";
            document.getElementById("divaddmore_conswithsplit").innerHTML += divaddmoreconsolidate;
        }

        function More_Address_split_remove_conswithsplit(clickval) {

            for (var m = 1; m <= Number(hid_valueconswithsplit.value) ; m++) {
                var child = document.getElementById('div_SplitContent_conswithsplit_' + clickval + '');
                var parent = document.getElementById('divMain_split_conswithsplit_' + clickval + '');
                if (child != null) {
                    parent.removeChild(parent.childNodes[Number(m) - 1]);
                }
            }

            for (var z = 1; z < Number(hid_valueconswithsplit.value) ; z++) {
                try {
                    var val = document.getElementById("ctl00_ContentPlaceHolder1_splitslno_conswithsplit_" + (clickval + z) + "_0").innerHTML;
                    document.getElementById("ctl00_ContentPlaceHolder1_splitslno_conswithsplit_" + (clickval + z) + "_0").innerHTML = val - 1;
                } catch (Error) { }

            }
            hid_rowvalue_cons.value = Number(hid_rowvalue_cons.value) - 1;
        }

        function SaveDeliveryNote_conswithsplit() {

            var checkfalse_conswithsplit = true;
            var FinalValue = '';
            var zeroqty_cnt = 0;
            var rowscnt = 0;
            var checkQtyAvai = 0;
            for (var i = 0; i <= Number(hid_valueconswithsplit.value) ; i++) {
                var ClientID = '<%=ClientID %>';
                var AttentionID = '<%=AttentionID %>';
                hdn_con_raised_estimateids.value = "";
                hdn_conQtyProduced.value = "";
                for (var j = 0; j < hid_totItems_con_withsplit.value; j++) {
                    var txt = document.getElementById("ctl00_ContentPlaceHolder1_txtSplitQty_conswithsplit_" + i + "_" + j + "");
                    if (j == 0) {
                        var lbladdress_conswithsplit = document.getElementById("ctl00_ContentPlaceHolder1_txtaddress_conswithsplit_" + i + "_" + j + "");
                        if (lbladdress_conswithsplit != null) {
                            if (lbladdress_conswithsplit.innerHTML == '') {
                                checkfalse_conswithsplit = false;
                                alert('please select address');
                                return false;
                            }
                        }
                    }
                    if (txt != null) {
                        var lblQtyAvailale = document.getElementById("lblConBalance_" + j + "");

                        if (trim12(txt.value) != "" && trim12(txt.value) != "0") {
                            var Quantity = txt.value;
                            var AddressID = document.getElementById("spnAddID_conswithsplit_" + i + "_0").innerHTML;
                            var AddressType = document.getElementById("spnAddType_conswithsplit_" + i + "_0").innerHTML;
                            var EstimateID = document.getElementById("spnEstimateID_conswithsplit_" + i + "_" + j + "").innerHTML;
                            var EstimateItemID = document.getElementById("spnEstimateItemID_conswithsplit_" + i + "_" + j + "").innerHTML;
                            var EstimateType = document.getElementById("spnEstimateType_conswithsplit_" + i + "_" + j + "").innerHTML;
                            var ItemDescription = document.getElementById("spnItemDesc_conswithsplit_" + i + "_" + j + "").innerHTML;

                            // for Consolidate -single split address type
                            hdn_con_single_addressid.value = AddressID;
                            hdn_con_single_addresstype.value = AddressType;
                            hdn_con_raised_estimateids.value += EstimateID + "Ç" + EstimateItemID + "~";

                            var strValue = "ItemNoÇ" + i + "±" + "QuantityÇ" + Quantity + "±" + "AddressIDÇ" + AddressID + "±" + "AddressTypeÇ" + AddressType + "±" + "TotalItemÇ" + j + "±" + "EstimateIDÇ" + EstimateID + "±" + "EstimateItemIDÇ" + EstimateItemID + "±" + "EstimateTypeÇ" + EstimateType + "±" + "ItemDescriptionÇ" + ItemDescription + "~";
                            FinalValue += strValue;

                            var QtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtCon_QtyProduced_" + j + "").value;
                            hdn_conQtyProduced.value += QtyProduced + '±' + EstimateID + '±' + EstimateItemID + '±' + EstimateType + "µ";

                            var lblconqtyordered = document.getElementById("lblconqtyordered_" + j + "").innerHTML;
                            if (QtyProduced < lblconqtyordered) {
                                alert("Qty Produced cannot be less than the Qty Ordered. Please increase Qty Produced");
                                return false;
                            }

                            //check for QtyAvailable;
                            if ((Number(txt.value) > 0) && (Number(txt.value) > Number(lblQtyAvailale.innerHTML))) {
                                checkQtyAvai++;
                            }

                            if (zeroqty_cnt > 0) {
                                zeroqty_cnt--;
                            }
                        }
                        else {
                            zeroqty_cnt++;
                        }
                        rowscnt++;
                    }
                }
            }
            hdn_SaveData_conswithsplit.value = FinalValue;

            if (zeroqty_cnt == rowscnt)//Number(hid_totItems_con_withsplit.value)
            {
                alert("Please enter some quantity to raise.");
                return false;
            }
            else {
                //divConsolidate_split.style.display = "none";
                if (checkQtyAvai > 0) {
                    alert("Quantity raised is greater than the quantity available. Please increase available qty or change Qty Produced");
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        function More_Address_split_remove(clickval) {

            for (var m = 1; m <= Number(hid_value.value) ; m++) {
                var child = document.getElementById('div_SplitContent_' + clickval + '');
                var parent = document.getElementById('divMain_split_' + clickval + '');
                if (child != null) {
                    parent.removeChild(parent.childNodes[Number(m) - 1]);

                }
            }

            for (var m = 1; m < Number(hid_value.value) ; m++) {
                try {
                    var val = document.getElementById("ctl00_ContentPlaceHolder1_splitslno_" + (clickval + m) + "_0").innerHTML;
                    document.getElementById("ctl00_ContentPlaceHolder1_splitslno_" + (clickval + m) + "_0").innerHTML = val - 1;
                } catch (Error) { }

            }
            hid_rowvalue.value = Number(hid_rowvalue.value) - 1;
        }
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";


        function check() {
            var chk = 0;
            var hidval = "";
            var frm = document.aspnetForm;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox') {
                    if (e.checked == true) {
                        hidval = hidval + e.value + ",";
                        chk = chk + 1;
                    }
                }

            }
            if (hidval == "") {
                alert('please check at least one record');
                return false;
            }
            return true;
        }

        function fillQtyProduced(objQtyProduced, txtno, EstimateItem, EstimateType, QtyOrdered) {
            if (trim12(objQtyProduced.value) == "" || trim12(objQtyProduced.value) == "0") {
                objQtyProduced.value = QtyOrdered;
            }

        }

        function ShowHideDeliveryNote(ItemNo, type) {
            var divSplitorConViewDelivery = '';
            var imgsplitorCon_ViewDeliveryNote = '';
            if (type == "consolidate") {
                divSplitorConViewDelivery = document.getElementById("divConViewDelivery_" + ItemNo + "");
                imgsplitorCon_ViewDeliveryNote = document.getElementById("imgcon_ViewDeliveryNote_" + ItemNo + "");
            }
            else {
                divSplitorConViewDelivery = document.getElementById("divSplitViewDelivery_" + ItemNo + "");
                imgsplitorCon_ViewDeliveryNote = document.getElementById("imgsplit_ViewDeliveryNote_" + ItemNo + "");
            }

            if (divSplitorConViewDelivery.style.display == "none") {
                divSplitorConViewDelivery.style.display = "block";
                imgsplitorCon_ViewDeliveryNote.src = '../images/minus.gif';
                //imgsplitorCon_ViewDeliveryNote.innerHTML = "Hide Details";
            }
            else {
                divSplitorConViewDelivery.style.display = "none";
                imgsplitorCon_ViewDeliveryNote.src = '../images/plus.gif';
                //imgsplitorCon_ViewDeliveryNote.innerHTML = "Show Details";
            }
        }

        var txtQtyProd_No = '';
        function SaveQtyProduced(ItemNo, QtyProd, EstID, EstItemID, EstType, DelType) {
            var txtQtyProduced = '';
            var lblQtyOrdered = '';
            var lblQtyDelivered = '';
            var lblQtyAvailable = '';
            if (DelType == 'split') {
                txtQtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtQtyProduced_" + ItemNo + "");
                lblQtyOrdered = document.getElementById("lblqtyordered_" + ItemNo + "");
                lblQtyDelivered = document.getElementById("lblQtyDelivered_" + ItemNo + "");
                lblQtyAvailable = document.getElementById("lblSplitBalance_" + ItemNo + "");
            }
            else if (DelType == 'consolidate') {
                txtQtyProduced = document.getElementById("ctl00_ContentPlaceHolder1_txtCon_QtyProduced_" + ItemNo + "");
                lblQtyOrdered = document.getElementById("lblconqtyordered_" + ItemNo + "");
                lblQtyDelivered = document.getElementById("lblconQtyDelivered_" + ItemNo + "");
                lblQtyAvailable = document.getElementById("lblConBalance_" + ItemNo + "");
            }
            txtQtyProduced.style.backgroundImage = 'none';

            if (trim12(txtQtyProduced.value) == "") {
                alert("Qty Produced cannot be blank.");
            }
            else {
                if (Number(txtQtyProduced.value) < Number(lblQtyOrdered.innerHTML)) {
                    alert("Qty Produced cannot be less than the Qty Ordered.");
                }
                else {
                    txtQtyProd_No = txtQtyProduced;
                    txtQtyProduced.style.backgroundImage = 'url(../images/loading27.gif)';
                    txtQtyProduced.style.backgroundRepeat = 'no-repeat';
                    txtQtyProduced.style.backgroundPosition = 'left';
                    txtQtyProduced.style.backgroundcolor = "white";
                    txtQtyProduced.style.opacity = "0.6";
                    txtQtyProduced.style.filter = "alpha(opacity=60)";

                    PageMethods.QtyProduced_Update('<%=CompanyID %>', EstID, EstItemID, EstType, txtQtyProduced.value, OnSucc)
                    var QtyAvail = Number(txtQtyProduced.value) - Number(lblQtyDelivered.innerHTML);

                    lblQtyAvailable.innerHTML = Number(QtyAvail) < 0 ? "0" : Number(QtyAvail);
                }
            }
        }

        function OnSucc(result) {
            txtQtyProd_No.style.backgroundImage = 'none';
            txtQtyProd_No.style.opacity = "1";
            txtQtyProd_No.style.filter = "alpha(opacity=100)";
            txtQtyProd_No = '';
        }

        function LoadDelNotes() {
            hid_checkboxid.value = '';
            div_BoxLabel.style.display = "none";
            div_btnBoxLabel.style.display = "none";
            document.getElementById("div_Load").style.display = "block";
            document.getElementById("ds00").style.display = "block";
            setLoadingPositionOfDivMove(div_Load);
            __doPostBack('ctl00$ContentPlaceHolder1$lnkRaiseDeliveryNote', '')
        }

        var win = null;
        function OpenTemplateWin(url) {
            try {
                if ((win != null)) {
                    if (win.name == "TempWin") {
                        win.location.replace(url);
                    }
                }

                else {
                    win = window.open(url, "TempWin");
                }
            }
            catch (e) { win = window.open(url, "TempWin"); }

        }

    </script>
    <asp:Panel ID="pnl_viewonlydelivery" runat="server" Visible="false">
        <script type="text/javascript">
            div_MainDelivery.style.display = "none";
            changeCssTemp('item_2');
            ChangetoDelevery(DelRaise_Type);
            rdosingle.checked = false;
            //            alert('ash2');
            rdosplit.checked = false;
            rdoconsolidate.checked = false;
            if (DelRaise_Type == "single") {
                rdosingle.checked = true;
            }
            else if (DelRaise_Type == "split") {
                //                alert('ash3');
                rdosplit.checked = true;
            }
            else {
                hdn_DeliveryNoteType.value = "consolidate";
                rdoconsolidate.checked = true;
                if (hid_checkboxid.value != '') {
                    //divConsolidate_split.style.display = "block";
                    document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "block";
                }
            }
        document.getElementById("divmessage").style.display = "block";
        </script>
    </asp:Panel>
    <%--BOX LABEL SECTION--%>
    <script type="text/javascript">
        function ShowonChange(ddlval) {
            var CompID = '<%=CompanyID %>';
            if (ddlval > 0) {
                ePrint.press_select.GetWarehouse_Details(CompID, ddlval, GetResult);
            }
            else {
                hdn_InvLocation.value = '';
                hdn_TotalQty.value = 0;
                txtTotalQty.value = hdn_TotalQty.value;
            }
        }

        function GetResult(result) {
            if (result != "") {
                var str = result.split('µ');
                if (str[0] == "W") {
                    div_OnlyWareItems.style.display = "block";

                    var str = str[1].split('±');
                    hdn_InvCode.value = str[0];
                    hdn_InvDesc.value = str[1];
                    hdn_InvName.value = str[2];
                    hdn_TotalQty.value = str[3];
                    hdn_InvLocation.value = str[4];
                }
                else {
                    hdn_TotalQty.value = str[1];
                    hdn_InvLocation.value = '';
                    div_OnlyWareItems.style.display = "none";
                    chkShowInvCode.checked = false;
                    chkShowInvDesc.checked = false;
                }
                txtTotalQty.value = hdn_TotalQty.value;
            }
        }

        function ShowHideNumberingMask() {
            div_Mask.style.display = "none";
            div_OverflowMask.style.display = "none";

            if (chkNumberingMask.checked) {
                div_Mask.style.display = "block";
                div_OverflowMask.style.display = "block";

                ddlOverflowMask.selectedIndex = 0;
                div_OverflowMask1.style.display = "block";
                div_OverflowMask2.style.display = "none";
                div_OverflowMask3.style.display = "none";
                div_OverflowMask4.style.display = "none";
            }
        }

        function ShowHideOverflowMask(ddlval) {
            div_OverflowMask1.style.display = "none";
            div_OverflowMask2.style.display = "none";
            div_OverflowMask3.style.display = "none";
            div_OverflowMask4.style.display = "none";
            if (ddlval == "1") {
                div_OverflowMask1.style.display = "block";
            }
            else if (ddlval == "2") {
                div_OverflowMask1.style.display = "block";
                div_OverflowMask2.style.display = "block";
            }
            else if (ddlval == "3") {
                div_OverflowMask1.style.display = "block";
                div_OverflowMask2.style.display = "block";
                div_OverflowMask3.style.display = "block";
            }
            else if (ddlval == "4") {
                div_OverflowMask1.style.display = "block";
                div_OverflowMask2.style.display = "block";
                div_OverflowMask3.style.display = "block";
                div_OverflowMask4.style.display = "block";
            }
        }

        function ShowBoxLabelStep2() {
            div_Main.style.display = "block";
            div_Print.style.display = "none";
            div_BoxLabel.style.display = "block";

            div_BoxLabel_Step2.style.display = "block";
            div_BoxLabel_Step1.style.display = "block";

            div_btnNext.style.display = "block";
            div_btnPrevious.style.display = "none";

            btnCancelStep2.style.display = "none";
            btnBoxLabelCancel.style.display = "block";
        }

        function ShowBoxLabelStep1() {
            div_BoxLabel_Step2.style.display = "none";
            div_BoxLabel_Step1.style.display = "block";

            div_btnNext.style.display = "block";
            div_btnPrevious.style.display = "none";

            btnBoxLabelCancel.style.display = "block";
        }

        function BindRowsColumns(ddlval) {
            ddlRows.length = 0;
            ddlColumns.length = 0;
            div_Customize.style.display = "none";
            hdn_labeltype.value = ddlval;
            //ddlRows.options.add(new Option("--- Select ---", "0", 0));
            if (ddlval == "1") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));
                ddlRows.options.add(new Option("5", "5", 4));
                ddlRows.options.add(new Option("6", "6", 5));
                ddlRows.options.add(new Option("7", "7", 6));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
                ddlColumns.options.add(new Option("3", "3", 2));
            }
            else if (ddlval == "2") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
            }
            else if (ddlval == "3") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));
                ddlRows.options.add(new Option("5", "5", 4));
                ddlRows.options.add(new Option("6", "6", 5));
                ddlRows.options.add(new Option("7", "7", 6));
                ddlRows.options.add(new Option("8", "8", 7));
                ddlRows.options.add(new Option("9", "9", 8));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
            }
            else if (ddlval == "4") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
            }
            else if (ddlval == "5") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));
                ddlRows.options.add(new Option("5", "5", 4));
                ddlRows.options.add(new Option("6", "6", 5));
                ddlRows.options.add(new Option("7", "7", 6));
                ddlRows.options.add(new Option("8", "8", 7));


                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
            }
            else if (ddlval == "6") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
            }
            else if (ddlval == "7") {
                ddlRows.options.add(new Option("1", "1", 0));
                ddlRows.options.add(new Option("2", "2", 1));
                ddlRows.options.add(new Option("3", "3", 2));
                ddlRows.options.add(new Option("4", "4", 3));

                ddlColumns.options.add(new Option("1", "1", 0));
                ddlColumns.options.add(new Option("2", "2", 1));
                ddlColumns.options.add(new Option("3", "3", 2));
            }
            else if (ddlval == "8") {
                if (ServerName == "ppw" || ServerName == "printmonkey" || ServerName == "studio1" || ServerName == "centurionprint") {
                    ddlRows.options.add(new Option("1", "1", 0));
                    ddlColumns.options.add(new Option("1", "1", 0));
                }
                else {
                    ddlRows.options.add(new Option("1", "1", 0));
                    ddlRows.options.add(new Option("2", "2", 1));
                    ddlRows.options.add(new Option("3", "3", 2));

                    ddlColumns.options.add(new Option("1", "1", 0));
                    ddlColumns.options.add(new Option("2", "2", 1));
                }
            }
            else if (ddlval == "9") {//Customized Label
                div_Customize.style.display = "block";

                ddlRows.options.add(new Option("1", "1", 0));

                ddlColumns.options.add(new Option("1", "1", 0));
            }

            ddlRows.selectedIndex = 0;
            ddlColumns.selectedIndex = 0;

            hid_startrow.value = ddlRows.options[ddlRows.selectedIndex].text;
            hid_startcol.value = ddlColumns.options[ddlColumns.selectedIndex].text;
            //        if (ddlval == "8")
            //        {
            //            hid_labletype_rows.value="1";
            //            hid_labletype_col.value="1";
            //            hid_startrow.value="1";
            //            hid_startcol.value="1";
            //        }
            //        else{
            Getlabeltypetext(ddlLabeltype.options[ddlLabeltype.selectedIndex].text, hid_startrow.value, hid_startcol.value);
            //        }

        }

        function GetLabelSize(type, lstval) {
            if (type == "width") {
                spn_Width.innerHTML = lstval;
            }
            else {
                spn_Height.innerHTML = lstval;
            }
        }

        function ShowHideCustomizeLabel(RdID) {
            var radio = RdID.getElementsByTagName("input");
            for (var ii = 0; ii < radio.length; ii++) {

                if (radio[ii].checked) {
                    div_CustomizeLabel.style.display = "none";
                    div_Ups.style.display = "none";

                    if (radio[ii].value == "customize") {
                        div_CustomizeLabel.style.display = "block";
                    }
                    else {
                        div_Ups.style.display = "block";
                    }
                }
            }
        }

        function EditBoxLabel() {
            if (chkEditBoxLabel.checked) {
                txtLabel.style.border = "1px solid";
                txtLabel.style.overflow = "auto";
                txtLabel.removeAttribute("readonly");
            }
            else {
                txtLabel.style.border = "0px solid";
                txtLabel.style.overflow = "hidden";
                txtLabel.setAttribute("readonly", true);
            }
        }

        function ClosePrintDiv() {
            div_Main.style.display = "block"
            div_Print.style.display = "none";
            return false;
        }

        //Bridge Motors
        //Units 3 & 4 Trinder House,Stansworth Street,
        //Southampton, Kent, United Kingdom
        //S032 1EE
        //01489 891035-02
        var str = '';
        var TotalLabels = '';
        var strmask = '';
        function CallPrintLabel() {
            div_Main.style.display = "none"
            div_Print.style.display = "block";

            var ItemTitle = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;
            str = ItemTitle + "\n";
            if (chkShowInvCode.checked) {
                str += hdn_InvCode.value + "\n";
            }
            if (chkShowInvDesc.checked) {
                str += hdn_InvDesc.value + "\n";
            }
            if (lblCustomerName.innerHTML != '') {
                str += lblCustomerName.innerHTML + "\n";
            }
            if (txtAddressLine1.value != '') {
                str += txtAddressLine1.value + "\n";
            }
            if (txtAddressLine2.value != '') {
                str += txtAddressLine2.value + "\n";
            }
            if (txtAddressLine3.value != '') {
                str += txtAddressLine3.value + "\n";
            }
            if (txtAddressLine4.value != '') {
                str += txtAddressLine4.value + "\n";
            }
            if (txtAddressLine5.value != '') {
                str += txtAddressLine5.value + "\n";
            }
            if (txtCountry.value != '') {
                str += txtCountry.value + "\n";
            }
            if (txtTelephone.value != '') {
                str += txtTelephone.value + "\n";
            }

            lblPrint.innerHTML = str;

            var NoOfLabels = Number(txtNoOfLabels.value);
            TotalLabels = Number(txtNoOfLabels.value);
            div_PrintContent.innerHTML = '';

            //ddlOverflowMask  
            var startval = '';
            var endval = '';
            var diffval = '';
            var range = '';
            var MaskStartVal = 0;
            var MaskEndVal = 0;
            var nooflableonprintview = 0;
            if (chkNumberingMask.checked && txtNoOfLeaves.value > 0) {
                var MaskNum = ddlOverflowMask.options[ddlOverflowMask.selectedIndex].value;
                if (MaskNum == 1) {
                    MaskStartVal = Number(txtStart1.value);
                    MaskEndVal = Number(txtEnd1.value);
                }
                else if (MaskNum == 2) {
                    MaskStartVal = Number(txtStart2.value);
                    MaskEndVal = Number(txtEnd2.value);
                }
                else if (MaskNum == 3) {
                    MaskStartVal = Number(txtStart3.value);
                    MaskEndVal = Number(txtEnd3.value);
                }
                else if (MaskNum == 4) {
                    MaskStartVal = Number(txtStart4.value);
                    MaskEndVal = Number(txtEnd4.value);
                }
                TotalLabels = Math.ceil(MaskEndVal / Number(txtNoOfLeaves.value));
                if (TotalLabels == 1) {
                    TotalLabels = 2;
                }
                startval = Number(txtStart1.value);
                diffval = Number(txtNoOfLeaves.value);
                endval = startval + (diffval - 1);
            }

            hid_nooflableonprintview.value = TotalLabels;

            div_PPWContent.innerHTML = '';
            div_MasproContent.innerHTML = '';

            for (var i = 1; i <= TotalLabels; i++) {
                var strbox = "Box # " + i + " of " + NoOfLabels + "" + "\n";

                if (chkNumberingMask.checked) {
                    //if (startval <= NoOfLabels && endval <= NoOfLabels)   
                    //{
                    if (endval <= MaskEndVal) {
                        //strmask = "From " + txtPrefix1.value + "" + startval + "  TO " + txtSuffix1.value + "" + endval + " ";
                        strmask = "From " + txtPrefix1.value + "" + startval + txtSuffix1.value + "  TO " + txtPrefix1.value + "" + endval + txtSuffix1.value + " ";

                        var finalstring = ""; //strbox + str + strmask;

                        //PPW
                        if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "8") {

                            if (ServerName.toLowerCase() == "ppw") {
                                var ppwstr = '';
                                ppwstr += "<div style='height:577px; padding-bottom: 26px;'>";
                                ppwstr += "<div class='ppwmargin' style='padding-top:91px; padding-bottom: 13px;'>";
                                ppwstr += "<div id='company' class='ppwfn' style='padding-bottom: 26px;'><strong style='padding-right: 18px;'>Company:</strong>" + txtCompany.value.toUpperCase() + "</div>";
                                ppwstr += "<div id='address1' class='ppwaddress ppwfn'>";
                                //ppwstr += "<span style='padding-bottom: 26px;'>" + txtAddressLine1.value.toUpperCase() + "</span>";
                                ppwstr += "<div class='ppwfn' style='padding-bottom: 26px; color:black;'>" + txtAddressLine1.value.toUpperCase() + "</div>";
                                if (txtAddressLine2.value.toString().length > 0) {
                                    ppwstr += "<span>" + txtAddressLine2.value.toUpperCase() + "</span></div>"; //<br>
                                }
                                else {
                                    ppwstr += "<span>&nbsp;</span></div>"; //<br>
                                }
                                ppwstr += "<div id='attention' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Attention:</strong>" + '<%=AttentionName %>'.toUpperCase() + "</div>"; //<br>
                                ppwstr += "<div id='orderno' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Order Number:</strong>" + '<%=OrderNo %>' + "</div>"; //<br>
                                ppwstr += "<div id='totalqty' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Total Qty:</strong>" + hdn_TotalQty.value + "</div>"; //<br>

                                var products = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;
                                //ppwstr += "<div id='products' class='ppwfn'><strong>Products:&nbsp;&nbsp;&nbsp;</strong>" + products + "<br></div>";
                                ppwstr += "</div>"; //<br>
                                ppwstr += "<div id='box1' class='ppwboxofmargin ppwfn'>";
                                ppwstr += "<span style='padding-right: 12px;'>Box</span>" + i + "<span style='padding-left: 30px; padding-right: 37px;'>of</span>" + NoOfLabels + "";
                                ppwstr += "</div>";
                                ppwstr += "</div>"; //<br /><br />

                                div_PPWContent.innerHTML += ppwstr;
                                finalstring = div_PPWlabel.innerHTML;

                                div_PrintContent.innerHTML = div_PPWlabel.innerHTML;
                                div_PrintContent.style.whiteSpace = "nowrap";
                            }
                            else if (ServerName.toLowerCase() == "printmonkey" || ServerName.toLowerCase() == "studio1" || ServerName.toLowerCase() == "centurionprint") {
                                var maspstr = '';
                                var products = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;
                                maspstr += "<table class='Ocpplabel' cellpadding='0' cellspacing='0'>";
                                maspstr += "<tr>";
                                maspstr += "<td colspan='2' class='Ocppheader' >";
                                maspstr += "" + products + "";
                                maspstr += "</td>";
                                maspstr += "</tr>";
                                maspstr += "<tr>";
                                maspstr += "<td colspan='2' class='OcppQty' >QTY  " + txtTotalQty.value + "</td>";
                                maspstr += "</tr>";
                                maspstr += "<tr >"
                                maspstr += "<td class='OcppJN' >Cust PO: " + '<%=OrderNo %>' + "</td>";
                                maspstr += "<td class='OcppJN' align='right' >Job Ref: " + '<%=MainJobNumber %>' + "</td>";
                                maspstr += "</tr>"
                                maspstr += "<tr> <td colspan='2' class='Ocppbox'> Box  " + i + " of " + NoOfLabels + "</td></tr> ";
                                maspstr += "</table>";

                                maspstr += "<div style='height:13px'></div>";

                                maspstr += "<table class='Ocpplabel' cellpadding='0'  cellspacing='0' >";

                                if (txtCompany.value != "") {
                                    maspstr += "<tr><td class='Ocppaddress'> " + txtCompany.value + "</td></tr>  ";
                                }
                                if (txtAddressLine1.value == "" && txtAddressLine2.value == "") {
                                }
                                else {
                                    maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine1.value + ", " + txtAddressLine2.value; +"</td></tr>";
                                }
                                if (txtAddressLine3.value == "" && txtAddressLine4.value == "") {
                                }
                                else {
                                    maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine3.value + ", " + txtAddressLine4.value + "</td></tr>";
                                }
                                if (txtAddressLine5.value != "") {
                                    maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine5.value + "</td></tr>";
                                }
                                if (txtTelephone.value != "") {
                                    maspstr += "<tr><td class='Ocppaddress'>" + txtTelephone.value + "</td></tr>";
                                }

                                maspstr += "<tr>";
                                maspstr += "<td class='Ocppaddress'> Attn: " + '<%=AttnName %>' + "</td></tr><tr>";
                                maspstr += "<td class='Ocppbox'>Box  " + i + " of " + NoOfLabels + "</td></tr></table>";

                                maspstr += "<div style='height:13px'></div>";

                                div_MasproContent.innerHTML += maspstr;
                                finalstring = div_MasproLabel.innerHTML;
                                div_PrintContent.innerHTML = div_MasproLabel.innerHTML;
                                div_PrintContent.style.whiteSpace = "nowrap";
                            }
                    }
                    else {
                        finalstring = strbox + str + strmask;
                        div_PrintContent.innerHTML += "<textarea   type='text' id='txtPrint_" + i + "'  rows='10' wrap='virtual' class='boxlabelonprint' style='overflow-y: hidden; overflow-x: scroll' onKeyUp='return limitLines(this, event)' onKeyPress='return limitLines(this, event)' onkeydown='return limitLines(this, event)' onPaste='return limitLines(this, event)' onCut='return limitLines(this, event)' onBlur='return limitLines(this, event)'>" + finalstring + "</textarea>";
                    }

                    startval = startval + diffval;
                    endval = endval + diffval;

                    if (MaskNum == 2 && startval == Number(txtEnd1.value)) {
                        startval = Number(txtStart2.value);
                        endval = endval;
                    }
                    nooflableonprintview++;
                }
            }
            else {
                var finalstring = "";

                if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "8") {
                    if (ServerName.toLowerCase() == "ppw") {
                        var ppwstr = '';
                        ppwstr += "<div style='height:577px; padding-bottom: 26px;'>";
                        ppwstr += "<div class='ppwmargin' style='padding-top: 91px; padding-bottom: 13px;'>";
                        ppwstr += "<div id='company' class='ppwfn' style='padding-bottom: 26px;'><strong style='padding-right: 18px;'>Company:</strong>" + txtCompany.value.toUpperCase() + "</div>";
                        ppwstr += "<div id='address1' class='ppwaddress ppwfn'>";
                        //ppwstr += "<span style='padding-bottom: 26px;'>" + txtAddressLine1.value.toUpperCase() + "</span>";
                        ppwstr += "<div class='ppwfn' style='padding-bottom: 26px; color:black;'>" + txtAddressLine1.value.toUpperCase() + "</div>";
                        if (txtAddressLine2.value.toString().trim().length > 0) {
                            ppwstr += "<span>" + txtAddressLine2.value.toUpperCase() + "</span></div>"; //<br>
                        }
                        else {
                            ppwstr += "<span>&nbsp;</span></div>"; //<br>
                        }
                        ppwstr += "<div id='attention' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Attention:</strong>" + '<%=AttentionName %>'.toUpperCase() + "</div>"; //<br>
                            ppwstr += "<div id='orderno' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Order Number:</strong>" + '<%=OrderNo %>' + "</div>"; //<br>
                            ppwstr += "<div id='totalqty' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Total Qty:</strong>" + hdn_TotalQty.value + "</div>"; //<br>

                            var products = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;
                            //ppwstr += "<div id='products' class='ppwfn'><strong>Products:&nbsp;&nbsp;&nbsp;</strong>" + products + "<br></div>";
                            ppwstr += "</div>"; //<br>
                            ppwstr += "<div id='box1' class='ppwboxofmargin ppwfn'>";
                            ppwstr += "<span style='padding-right: 12px;'>Box</span>" + i + "<span style='padding-left: 30px; padding-right: 37px;'>of</span>" + NoOfLabels + "";
                            ppwstr += "</div>";
                            ppwstr += "</div>"; //<br /><br />

                            div_PPWContent.innerHTML += ppwstr;
                            finalstring = div_PPWlabel.innerHTML;

                            div_PrintContent.innerHTML = div_PPWlabel.innerHTML;
                            div_PrintContent.style.whiteSpace = "nowrap";
                        }
                        else if (ServerName.toLowerCase() == "printmonkey" || ServerName.toLowerCase() == "studio1" || ServerName.toLowerCase() == "centurionprint") {

                            var maspstr = '';
                            var products = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;

                            maspstr += "<table class='Ocpplabel' cellpadding='0' cellspacing='0'>";
                            maspstr += "<tr>";
                            maspstr += "<td colspan='2' class='Ocppheader' >";
                            maspstr += "" + products + "";
                            maspstr += "</td>";
                            maspstr += "</tr>";
                            maspstr += "<tr>";
                            maspstr += "<td colspan='2' class='OcppQty' >QTY  " + txtTotalQty.value + "</td>";
                            maspstr += "</tr>";
                            maspstr += "<tr >"
                            maspstr += "<td class='OcppJN' >Cust PO: " + '<%=OrderNo %>' + "</td>";
                            maspstr += "<td class='OcppJN' align='right' >Job Ref: " + '<%=MainJobNumber %>' + "</td>";
                            maspstr += "</tr>"
                            maspstr += "<tr> <td colspan='2' class='Ocppbox'> Box  " + i + " of " + NoOfLabels + "</td></tr> ";
                            maspstr += "</table>";

                            maspstr += "<div style='height:13px'></div>";

                            maspstr += "<table class='Ocpplabel' cellpadding='0'  cellspacing='0' >";

                            if (txtCompany.value != "") {
                                maspstr += "<tr><td class='Ocppaddress'> " + txtCompany.value + "</td></tr>  ";
                            }
                            if (txtAddressLine1.value == "" && txtAddressLine2.value == "") {
                            }
                            else {
                                maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine1.value + ", " + txtAddressLine2.value; +"</td></tr>";
                            }
                            if (txtAddressLine3.value == "" && txtAddressLine4.value == "") {
                            }
                            else {
                                maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine3.value + ", " + txtAddressLine4.value + "</td></tr>";
                            }
                            if (txtAddressLine5.value != "") {
                                maspstr += "<tr><td class='Ocppaddress'>" + txtAddressLine5.value + "</td></tr>";
                            }
                            if (txtTelephone.value != "") {
                                maspstr += "<tr><td class='Ocppaddress'>" + txtTelephone.value + "</td></tr>";
                            }

                            maspstr += "<tr>";
                            maspstr += "<td class='Ocppaddress'> Attn: " + '<%=AttnName %>' + "</td></tr><tr>";
                            maspstr += "<td class='Ocppbox'>Box  " + i + " of " + NoOfLabels + "</td></tr></table>";

                            maspstr += "<div style='height:13px'></div>";


                            div_MasproContent.innerHTML += maspstr;
                            finalstring = div_MasproLabel.innerHTML;

                            div_PrintContent.innerHTML = div_MasproLabel.innerHTML;
                            div_PrintContent.style.whiteSpace = "nowrap";
                        }
                        else {
                            finalstring = strbox + str;
                            div_PrintContent.innerHTML += "<textarea  type='text' id='txtPrint_" + i + "'  rows='10' wrap='virtual' class='boxlabelonprint' style='overflow-y: hidden; overflow-x: scroll' onKeyUp='return limitLines(this, event)' onKeyPress='return limitLines(this, event)' onkeydown='return limitLines(this, event)' onPaste='return limitLines(this, event)' onCut='return limitLines(this, event)' onBlur='return limitLines(this, event)'>" + finalstring + "</textarea>";
                        }
                }
                else {
                    finalstring = strbox + str;
                    div_PrintContent.innerHTML += "<textarea  type='text' id='txtPrint_" + i + "'  rows='15' wrap='virtual' class='boxlabelonprint' style='overflow-y: hidden; overflow-x: scroll' onKeyUp='return limitLines(this, event)' onKeyPress='return limitLines(this, event)' onkeydown='return limitLines(this, event)' onPaste='return limitLines(this, event)' onCut='return limitLines(this, event)' onBlur='return limitLines(this, event)'>" + finalstring + "</textarea>";
                }
                    //                    else {

                    //                        var ppwstr = '';
                    //                        ppwstr += "<div style='height:577px;'>";
                    //                        ppwstr += "<div class='ppwmargin'><br /><br /><br /><br /><br /><br />";
                    //                        ppwstr += "<div id='company' class='ppwfn'><strong style='padding-right: 18px;'>Company:</strong>" + txtCompany.value.toUpperCase() + "<br><br></div>";
                    //                        ppwstr += "<div id='address1' class='ppwaddress ppwfn'>";
                    //                        ppwstr += "<span>" + txtAddressLine1.value.toUpperCase() + "</span><br><br>";
                    //                        ppwstr += "<span>" + txtAddressLine2.value.toUpperCase() + "</span><br><br></div>";
                    //                        ppwstr += "<div id='attention' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Attention:</strong>" + '<%=AttentionName %>'.toUpperCase() + "<br></div>";
                    //                        ppwstr += "<div id='orderno' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Order Number:</strong>" + '<%=OrderNo %>' + "<br></div>";
                    //                        ppwstr += "<div id='totalqty' class='ppwfn' style='margin-bottom: 5px'><strong style='padding-right: 18px;'>Total Qty:</strong>" + hdn_TotalQty.value + "<br></div>";

                    //                        var products = ddlItemTitle.selectedIndex == 0 ? "" : ddlItemTitle.options[ddlItemTitle.selectedIndex].text;
                    //                        ppwstr += "<div id='products' class='ppwfn'><strong style='padding-right: 18px;'>Products:</strong>" + products + "<br></div>";
                    //                        ppwstr += "</div><br>";
                    //                        ppwstr += "<div id='box1' class='ppwboxofmargin ppwfn'>";
                    //                        ppwstr += "Box&nbsp;&nbsp;" + i + "&nbsp;&nbsp;&nbsp;&nbsp;  of &nbsp;&nbsp;&nbsp;&nbsp; " + NoOfLabels + "";
                    //                        ppwstr += "</div>";
                    //                        ppwstr += "</div><br /><br />";

                    //                        div_PPWContent.innerHTML += ppwstr;
                    //                        finalstring = div_PPWlabel.innerHTML;

                    //                        div_PrintContent.innerHTML = div_PPWlabel.innerHTML;
                    //                        div_PrintContent.style.whiteSpace = "nowrap";
                    //                    }
                }
            }
        }

        function GetEdited_PrintLabels() {
            hdn_PrintLabels.value = '';

            if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "8" && (ServerName.toLowerCase() == "printmonkey" || ServerName.toLowerCase() == "studio1" || ServerName.toLowerCase() == "ppw" || ServerName.toLowerCase() == "centurionprint")) //PPW & Maspro
            {
                hdn_PrintLabels.value = div_PrintContent.innerHTML;
            }
            else {
                for (var i = 1; i <= TotalLabels; i++) {
                    var txtval = document.getElementById("txtPrint_" + i + "");
                    var text = "";
                    text = txtval.value.replace(/\s+$/g, "");
                    var split = text.split("\n")
                    var linescnt = split.length;
                    var concat_editval = '';

                    for (var j = 1; j < linescnt; j++) {
                        concat_editval += split[j] + "~";
                    }
                    if (linescnt < 8) {
                        for (var k = linescnt; k < 8; k++) {
                            concat_editval += "" + "~";
                        }
                    }
                    hdn_PrintLabels.value += concat_editval + "µ";
                }
            }

            div_MainDelivery.style.display = "none";
            //            div_SplitDelivery.style.display = "none";
            document.getElementById("<%=div_SplitDelivery.ClientID %>").style.display = "none";
            //            div_ConsolidatedDelivery.style.display = "none";
            document.getElementById("<%=div_ConsolidatedDelivery.ClientID %>").style.display = "none";
            //            divConsolidate_split.style.display = "none";
            document.getElementById("<%=divConsolidate_split.ClientID %>").style.display = "none";

            // window.open('../printlayout_delivery.aspx?LR=' + hid_labletype_rows.value + '&LC=' + hid_labletype_col.value + '&SR=' + hid_startrow.value + '&SC=' + hid_startcol.value + '&nooflableonprintview=' + txtNoOfLabels.value + '&nooflables=' + hid_nooflableonprintview.value + '&maskcheck=' + chkNumberingMask.checked + '&prefix=' + txtPrefix1.value + '&suffix=' + txtSuffix1.value + '&maskstartval=' + txtStart1.value + '&noofitemperbox=' + txtNoOfLeaves.value + '&maskendval=' + txtEnd1.value + '','','width=1100,height=500,status=no,align=center,scrollbars=yes,resizable=yes,top=200,title=yes,location=no,titlebar=no,left=170,top=100');
            return true;

            //New to open popup
            /*changeCssTemp('item_5');
            CallPrintLabel();  
           
            var lblstr = hdn_PrintLabels.value;       
            //document.cookie = "spcookie=" + lblstr + ";            
            if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "8" || ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "9") //PPW & Maspro respectively
            {
            var qstr = '';
            if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "8")
            {
            qstr = "ispw";
            }
            else if (ddlLabeltype.options[ddlLabeltype.selectedIndex].value == "9")
            {
            qstr = "ismp";
            }
            window.open('../printlayout_delivery.aspx?LR=' + hid_labletype_rows.value + '&LC=' + hid_labletype_col.value + '&SR=' + hid_startrow.value + '&SC=' + hid_startcol.value + '&nooflableonprintview=' + txtNoOfLabels.value + '&nooflables=' + hid_nooflableonprintview.value + '&maskcheck=' + chkNumberingMask.checked + '&prefix=' + txtPrefix1.value + '&suffix=' + txtSuffix1.value + '&maskstartval=' + txtStart1.value + '&noofitemperbox=' + txtNoOfLeaves.value + '&maskendval=' + txtEnd1.value + '&' + qstr + '=yes','','width=1100,height=500,status=no,align=center,scrollbars=yes,resizable=yes,top=200,title=yes,location=no,titlebar=no,left=170,top=100');
            }
            else
            {
            window.open('../printlayout_delivery.aspx?LR=' + hid_labletype_rows.value + '&LC=' + hid_labletype_col.value + '&SR=' + hid_startrow.value + '&SC=' + hid_startcol.value + '&nooflableonprintview=' + txtNoOfLabels.value + '&nooflables=' + hid_nooflableonprintview.value + '&maskcheck=' + chkNumberingMask.checked + '&prefix=' + txtPrefix1.value + '&suffix=' + txtSuffix1.value + '&maskstartval=' + txtStart1.value + '&noofitemperbox=' + txtNoOfLeaves.value + '&maskendval=' + txtEnd1.value+'','','width=1100,height=500,status=no,align=center,scrollbars=yes,resizable=yes,top=200,title=yes,location=no,titlebar=no,left=170,top=100');
            }
            return false;*/
        }

        var keynum, lines = 1;
        function limitLines(obj, e) {
            var text = obj.value.replace(/\s+$/g, "")
            var split = text.split("\n")
            lines = split.length;

            // IE
            if (window.event) {
                keynum = e.keyCode;
                // Netscape/Firefox/Opera
            }
            else if (e.which) {
                keynum = e.which;
            }

            if (keynum == 13) {
                if (lines == 9) {
                    return false;
                }
                else {
                    if (lines <= 9) {
                        lines++;
                    }
                }
            }
        }

        function printView() {
            window.print();
        }

        var CheckFinal = false;
        function validateBoxLabelStep1() {
            // CheckReqCompare(txtValue, span1, span2)
            CheckFinal = true;
            document.getElementById("spn_reqtxtStart1").style.display = "none";
            document.getElementById("spn_reqtxtStart2").style.display = "none";
            document.getElementById("spn_reqtxtStart3").style.display = "none";
            document.getElementById("spn_reqtxtStart4").style.display = "none";
            document.getElementById("spn_reqtxtEnd1").style.display = "none";
            document.getElementById("spn_reqtxtEnd2").style.display = "none";
            document.getElementById("spn_reqtxtEnd3").style.display = "none";
            document.getElementById("spn_reqtxtEnd4").style.display = "none";
            if (chkNumberingMask.checked) {
                if (div_OverflowMask1.style.display == "block") {
                    if (txtStart1.value == "") {
                        document.getElementById("spn_reqtxtStart1").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtStart1.value, 'spn_reqtxtStart1', 'spn_txtStart1') == true) {
                            CheckFinal = false;
                        }
                    }
                    if (txtEnd1.value == "") {
                        document.getElementById("spn_reqtxtEnd1").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtEnd1.value, 'spn_reqtxtEnd1', 'spn_txtEnd1') == true) {
                            CheckFinal = false;
                        }
                    }
                    if (txtNoOfLeaves.value == "") {
                        document.getElementById("spn_itemperbox").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtNoOfLeaves.value, 'spn_itemperbox', 'spn_itemperbox') == true) {
                            CheckFinal = false;
                        }
                    }

                }
                if (div_OverflowMask2.style.display == "block") {
                    if (txtStart2.value == "") {
                        document.getElementById("spn_reqtxtStart2").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtStart2.value, 'spn_reqtxtStart2', 'spn_txtStart2') == true) {
                            CheckFinal = false;
                        }
                    }
                    if (txtEnd2.value == "") {
                        document.getElementById("spn_reqtxtEnd2").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtEnd2.value, 'spn_reqtxtEnd2', 'spn_txtEnd2') == true) {
                            CheckFinal = false;
                        }
                    }
                }
                if (div_OverflowMask3.style.display == "block") {
                    if (txtStart3.value == "") {
                        document.getElementById("spn_reqtxtStart3").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtStart3.value, 'spn_reqtxtStart3', 'spn_txtStart3') == true) {
                            CheckFinal = false;
                        }
                    }
                    if (txtEnd3.value == "") {
                        document.getElementById("spn_reqtxtEnd3").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtEnd3.value, 'spn_reqtxtEnd3', 'spn_txtEnd3') == true) {
                            CheckFinal = false;
                        }
                    }
                }
                if (div_OverflowMask4.style.display == "block") {
                    if (txtStart4.value == "") {
                        document.getElementById("spn_reqtxtStart4").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtStart4.value, 'spn_reqtxtStart4', 'spn_txtStart4') == true) {
                            CheckFinal = false;
                        }
                    }
                    if (txtEnd4.value == "") {
                        document.getElementById("spn_reqtxtEnd4").style.display = "block";
                        CheckFinal = false;
                    }
                    else {
                        if (CheckReqCompare(txtEnd4.value, 'spn_reqtxtEnd4', 'spn_txtEnd4') == true) {
                            CheckFinal = false;
                        }
                    }
                }
            }
            if (CheckFinal) {
                ShowBoxLabelStep2();
                CallPrintLabel();
            }
            else {
                return false;
            }
        }

        function ClosePrintPreview() {
            div_iframe.style.display = "none";
            div_Main.style.display = "block";
            changeCssTemp('item_5');
        }


    </script>
    <script language="JavaScript">

        function Minimize() {
            window.innerWidth = 100;
            window.innerHeight = 100;
            window.screenX = screen.width;
            window.screenY = screen.height;
            alwaysLowered = true;
        }

        function Maximize() {
            window.innerWidth = screen.width;
            window.innerHeight = screen.height;
            window.screenX = 0;
            window.screenY = 0;
            alwaysLowered = false;
        }
        function RadWinClose() {

            // document.getElementById("ds00").style.display = "none";
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";

        }
    </script>
    <%--Below lines added for 2701--%>
    <asp:Panel ID="pnlCloseWindow" runat="server" Visible="false">
        <script type="text/javascript">
            function windowclose() {
                //  window.close();
                if (deliveryNoteRedirect != '') {
                    window.parent.location = deliveryNoteRedirect;
                }
            }
            windowclose();
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlLoadDelNotes" runat="server" Visible="false">
        <script type="text/javascript">
            LoadDelNotes();
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
