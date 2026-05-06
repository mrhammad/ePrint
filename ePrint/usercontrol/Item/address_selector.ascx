<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="address_selector.ascx.cs" Inherits="ePrint.usercontrol.Item.address_selector" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" style="display: block; width: 200px; height: 50px; position: absolute; top: 45%; left: 45%">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript">
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>
<%--<div align="left" class="navigatorpanel" style="width: 100%;">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <span id="spancustomer" visible="false" runat="server" class="navigatorpanel">(<asp:Label
                            ID="lblcustomername" runat="server"></asp:Label>)</span><span class="navigatorpanel">
                                <asp:Label ID="lbl_headerName" runat="server" Text="Address"></asp:Label></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>--%>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content" style="width: 100%">
    <div align="left" style="height: auto;">
        <%--class="borderWithoutTop"--%>
        <div id="padding">
            <div align="left" style="width: 100%">
                <div id="div_add" runat="server" style="float: left; width: 100%; display: none;">
                    <div style="float: left; width: 450px;">
                        <div align="left" id="div_CompanyName" runat="server">
                            <div class="bglabel">
                                <asp:Label ID="lblCompanyName" runat="server" CssClass="normaltext">Company Name
                            <span style="color:red">*</span></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtName" CssClass="textboxnew_estNew" Width="300px" runat="server"
                                    AutoCompleteType="disabled" onchange='javascript:get_changedcustomername(this.value);' TabIndex="0"></asp:TextBox>
                                <span id="spn_txtName" class="spanerrorMsg" style="display: none; width: 225px;"></span>
                                <div class="onlyEmpty">
                                </div>
                                <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                </div>
                                <asp:HiddenField ID="hid_CustName" runat="server" />
                                <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                                <asp:HiddenField ID="hid_CustName_old" runat="server" />
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_AddressLabel" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Address_Label")%> </asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_AddressLabel" runat="server" Width="300px" CssClass="textboxnew"
                                    TabIndex="1" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Address1" runat="server" CssClass="normaltext">Address 1</asp:Label>
                                <%--<span id="spnaddress1" style="color: red; display: none;">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="textboxnew" Rows="2" Width="300px"
                                    TabIndex="2" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                <span id="span_txtaddress1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"></span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Address2" runat="server" Text="Address 2" CssClass="normaltext"></asp:Label><%--<span
                                    id="spnaddress2" style="color: red; display: none;">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_address2" runat="server" Width="300px" CssClass="textboxnew"
                                    TabIndex="3" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                <span id="span_txtaddress2" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"></span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Address3" runat="server" Text="City" CssClass="normaltext"></asp:Label>
                                <%--<span id="spnaddress3" style="color: red; display: none;">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_city" runat="server" Width="300px" CssClass="textboxnew" TabIndex="4"
                                    onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox><span id="span_txtaddress3"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    </span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Address4" runat="server" Text="Suburb" CssClass="normaltext"></asp:Label>
                                <%--<span id="spnaddress4" style="color: red; display: none;">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_suburb" runat="server" Width="300px" CssClass="textboxnew" TabIndex="5"
                                    onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox><span id="span_txtaddress4"
                                        class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    </span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="lbl_Address5" runat="server" Text="Post Code" CssClass="normaltext"></asp:Label>
                                <%--<span id="spnaddress5" style="color: red; display: none;">*</span>--%>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txt_postCode" runat="server" Width="300px" MaxLength="20" CssClass="textboxnew"
                                    TabIndex="6" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                <span id="span_txtaddress5" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"></span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label42" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Country")%></asp:Label>
                            </div>
                            <div class="ddlsetting">
                                <asp:DropDownList ID="ddlcountry" runat="server" Width="300px" CssClass="normaltext"
                                    TabIndex="7">
                                </asp:DropDownList>
                                <span id="span_ddlcountry" class="spanerrorMsg" style="display: none; width: 300px"></span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label43" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Telephone")%></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txttelephone" runat="server" Width="300px" CssClass="textboxnew"
                                    TabIndex="8" MaxLength="70" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label44" runat="server" CssClass="normaltext"> <%=objLangClass.GetLanguageConversion("Fax")%> </asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtfax" runat="server" Width="300px" CssClass="textboxnew" TabIndex="9"
                                    MaxLength="60" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left" style="display: none;">
                            <div class="bglabel">
                                <asp:Label ID="Label5" runat="server" Text="Ref/ FAO" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtref" runat="server" Width="200px" CssClass="textboxnew" TabIndex="10"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <asp:Label ID="Label1" runat="server" Text="Email" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtemail" runat="server" Width="300px" CssClass="textboxnew" MaxLength="100"
                                    TabIndex="11"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left" style="display: none;">
                            <div class="bglabel">
                                <asp:Label ID="Label2" runat="server" Text="URL" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box">
                                <asp:TextBox ID="txtURL" runat="server" Width="200px" CssClass="textboxnew" TabIndex="12"></asp:TextBox>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div align="left" style="display: block;">
                            <div class="bglabel" style="background-color: White">
                            </div>
                            <div class="box">
                                <asp:CheckBox ID="chkpostbox" runat="server" />
                                <%=objLangClass.GetLanguageConversion("This_Is_A_Post_Box_Address")%>
                            </div>
                            <div class="bglabel" style="background-color: White">
                            </div>
                            <div id="DivHideAddress" runat="server" class="HideChkBox show_hide">
                                <asp:CheckBox ID="chkhideaddress" runat="server" />
                                <%=objLangClass.GetLanguageConversion("Hide_this_address_from_estore_pages")%>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                        <div class="header" style="float: left; width: 100%; padding: 5px 0px 0px 0px">
                            <div style="float: left; width: 100%; display: none">
                                <asp:CheckBox ID="chkemail" runat="server" Text="The email selected is default to send invoices" />
                            </div>
                            <div style="float: left; width: 100%; display: none;" id="div_delivery" runat="server">
                                <asp:CheckBox ID="chkdelivery" runat="server" Text="This is the Default Delivery Address (used in deliverynotes)" />
                            </div>
                            <div style="float: left; width: 100%; display: none;">
                                <asp:CheckBox ID="chkbilling" runat="server" Text="This is the Default Billing Address (used in invoices)" />
                            </div>
                            <div style="float: left; width: 100%; margin: 5px 0px 0px 5px; display: none;">
                                <asp:Label ID="lbl_Note" runat="server" Text="Note any changes made to this address will affect any area of the CRM where this address is used"
                                    Style="color: Gray; font-size: 10px" Visible="false" />
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>
                    </div>
                    <div align="left" style="display: block;">
                        <div class="bglabel" style="background-color: White; width: 12%">
                        </div>
                        <div class="box" style="margin-left: 15px;">
                            <div style="float: left">
                                <asp:Button ID="btncancel_address" Style="display: block; margin: 0px 10px 0px 0px"
                                    runat="server" Text="Cancel" CssClass="button" OnClientClick="javascript:var a=validateClose();if(a)loadingimage(this.id,'div_btncancel');return a;"
                                    OnClick="OnClick_btncancel" /><%--OnClick="OnClick_btncancel" --%>
                                <div id="div_btncancel" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>
                            <div id="Divbtnadd" runat="server" style="float: left">
                                <div id="div_btnadd" style="display: block">
                                    <asp:Button ID="btnadd" runat="server" Text="Save" CssClass="button" OnClick="btnadd_OnClick"
                                        Style="margin: 0px 10px 0px 0px" OnClientClick="javascript:var a= btnadd_save('save');if(a)loadingimg('div_btnadd','div_btnaddprocess');return a;" />
                                    <%--   this has been been commented to resolve onclick of cancel button in window pop up == by sharan--%>
                                    <%--   OnClientClick="javascript:var a=btnadd_save('save');loadingimg('div_btnadd','div_btnaddprocess');return a;"--%>
                                </div>
                                <div id="div_btnaddprocess" class="button" align="center" style="width: 30px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                        <%--104975--%>
                        <div id="DivSaveAs" runat="server" style="float: left; display: block; margin-left: -290px">
                            <asp:Button ID="btnSaveAs" runat="server" Text="Save as new Address" CssClass="button"
                                OnClick="btnSaveAs_OnClick" OnClientClick="javascript:var a= btnadd_save('saveas');if(a)loadingimage(this.id,'div_SaveasnewAddress');return a;;"
                                Style="display: block;" />
                            <div id="div_SaveasnewAddress" class="button" align="center" style="width: 30px; display: none;">
                                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="div_RadGrid_AddressSelector" runat="server" style="padding-bottom: 5px; border: solid 0px green; display: block;">
                    <asp:HiddenField Value="yes" ID="hdnClearFilter" runat="server" />
                    <asp:HiddenField ID="hdnisViewAllCompanyAddress" runat="server" />
                    <telerik:RadGrid ID="RadGrid_AddressSelector" runat="server" AllowPaging="true" AllowSorting="false"
                        AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="true"
                        PageSize="50" Width="100%" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
                        OnItemDataBound="RadGrid_AddressSelector_OnRowDataBound" Height="355px" AllowFilteringByColumn="true" OnItemCommand="RadGrid_AddressSelector_ItemCommand"
                        OnNeedDataSource="RadGrid_AddressSelector_OnNeedDataSource">
                        <%--OnItemCommand="RadGrid_AddressSelector_OnItemCommand"--%>
                        <GroupingSettings CaseSensitive="false" />
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <MasterTableView DataKeyNames="AddressID" AutoGenerateColumns="False" HorizontalAlign="NotSet"
                            OverrideDataSourceControlSorting="true" Width="100%" CommandItemDisplay="Top"
                            PagerStyle-AlwaysVisible="true">
                            <CommandItemTemplate>
                                <table class="rgCommandTable" border="0" style="width: 100%;">
                                    <tr>
                                        <td align="left" style="width: 49%;">
                                            <%-- <div style="float: left;">--%>
                                            <a href="javascript:void(0);" onclick="javascript:add_new('show');" title="Add New Address">
                                                <button id="btnAddNewRecord" class="rgAdd" type="button">
                                                </button>
                                                <%=objLangClass.GetLanguageConversion("Add_New_Address")%>
                                            </a>
                                        </td>
                                        <td align="right" style="width: 49%;">
                                            <asp:LinkButton ID="btnclrFilters" runat="server" Style="text-decoration: underline; cursor: pointer"
                                                Text="" OnClick="clrFilters_Click"><%=objLangClass.GetLanguageConversion("Search_All_Addresses") %></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn DataField="CompanyName" HeaderStyle-HorizontalAlign="Left"
                                    FilterControlWidth="100" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Width="25%" HeaderText="Company Name" ItemStyle-Width="25%" SortExpression="CompanyName"
                                    UniqueName="CompanyName" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <div style="float: left; width: 99%; overflow: hidden; cursor: pointer; cursor: hand;">
                                            <div style="float: left; width: 200px; overflow: hidden; height: 15px;">
                                                <asp:Label ID="lbl_CompanyName" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdn_CompanyName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CompanyName", "{0}") %>' />
                                                <asp:HiddenField ID="hdn_CompanyID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ClientID", "{0}") %>' />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="AddressLabel" HeaderStyle-HorizontalAlign="Left"
                                    AllowFiltering="true" FilterControlWidth="100" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Width="25%" HeaderText="" ItemStyle-Width="25%" SortExpression="AddressLabel"
                                    UniqueName="AddressLabel" Visible="true">
                                    <ItemTemplate>
                                        <div id="div_addressLabel" runat="server" style="float: left; width: 100%; overflow: hidden; height: 16px; cursor: pointer; cursor: hand;">
                                            <asp:Label ID="lbl_AddressLabel" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}")) %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="NewAddress" HeaderStyle-HorizontalAlign="Left"
                                    AllowFiltering="true" FilterControlWidth="200" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Width="45%" HeaderText="" ItemStyle-Width="45%" SortExpression="Address"
                                    UniqueName="NewAddress" Visible="true">
                                    <ItemTemplate>
                                        <div id="div_address" runat="server" style="float: left; width: 100%; overflow: hidden; height: 16px; cursor: pointer; cursor: hand;">
                                            <asp:Label ID="lnkAddress" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address", "{0}") %>'
                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.NewAddress", "{0}") %>'></asp:Label>
                                            <asp:HiddenField ID="hdn_AddressID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.AddressId", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_Address" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.NewAddress", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_City" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.City", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_Suburb" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.State", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_PostCode" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ZipCode", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_Country" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Country", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_Fax" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Fax", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_Email" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Email", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_AddressLabel" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_AddressLine2" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.AddressLine2", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_URL" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.URL", "{0}") %>' />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="Telephone" HeaderStyle-HorizontalAlign="Left"
                                    AllowFiltering="true" FilterControlWidth="120" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Width="20%" HeaderText="" ItemStyle-Width="20%" SortExpression="Telephone"
                                    UniqueName="Telephone" Visible="true">
                                    <ItemTemplate>
                                        <div style="float: left; width: 100%; overflow: hidden; height: 16px; cursor: pointer; cursor: hand;">
                                            <asp:Label ID="lbl_Telephone" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.Telephone", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.Telephone", "{0}")) %>'></asp:Label>
                                            <asp:HiddenField ID="hdn_Telephone" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Telephone", "{0}") %>' />
                                            <asp:HiddenField ID="hdn_IsDefaultPostBox" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsDefaultPostBoxAddress", "{0}") %>' />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <div style="padding: 0px 0px 0px 10px">
                                    No records found
                                </div>
                            </NoRecordsTemplate>
                        </MasterTableView>
                        <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                            AllowDragToGroup="false" Scrolling-AllowScroll="true">
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                            <Scrolling UseStaticHeaders="true" ScrollHeight="209" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
                <div style="clear: both">
                </div>
                <div id="div_note" runat="server" style="float: left">
                    <asp:Label ID="lbl_PostNote" runat="server" Text="Note: Post Box address cannot be used as Contact/Delivery Address"
                        CssClass="graytext"><%=objLangClass.GetLanguageConversion("Address_Selector_Note")%></asp:Label>
                </div>
                <div style="clear: both">
                </div>
                <div style="float: left; margin: 0px 0px 0px 10px;">
                    <asp:Button ID="btncancel_addressSelector" Style="display: none;" runat="server"
                        Text="Cancel" CssClass="button" OnClick="OnClick_btncancel_addressSelector" OnClientClick="javascript:return loadingimage(this.id,'div_btncanceladdressSelector')" />
                    <div id="div_btncanceladdressSelector"" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hid_CliID" runat="server" Value="0" />
<asp:HiddenField ID="hdnRequiredAddress" runat="server" Value="0" />
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<style type="text/css">
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
<script type="text/javascript" language="ecmascript">
    var Pgtype = '<%=pg %>';
    var addtype = '<%=type %>';
    var type = '<%=type %>';
    var mode = '<%=mode %>';
    var pg = '<%=pg %>';
    var pagenameDept = '<%=pagenameDept %>';
    var pagename = '<%=pagename %>';
    var ParentPage = '<%=ParentPage %>';
    var clientid = '<%=clientid %>';
    var ContactID = '<%=ContactID %>';
    var companytype = '<%=companytype %>';
    var redirectTo = '<%=redirectTo %>';
    var action = '<%=action %>';
    var wintype = '<%=wintype %>';
    var AddressTo = '<%=AddressTo %>';
    var vartype = '<%=addresstype %>';
    var txtName = document.getElementById("<%=txtName.ClientID %>");
    var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>")
    hid_ClientID.value = '<%=clientid %>';
    var controlid = '<%=controlid %>';

    //    var strisreqAdd = '<%=RequiredAddress %>';

    //    if (strisreqAdd != '') {
    //        var isreqAdd = strisreqAdd.split(',')
    //        for (var i = 0; i < isreqAdd.length; i++) {
    //            if (isreqAdd[i] == '1') {
    //                document.getElementById('spnaddress1').style.display = "block";
    //            }
    //            if (isreqAdd[i] == '2') {
    //                document.getElementById('spnaddress2').style.display = "block";
    //            }
    //            if (isreqAdd[i] == '3') {
    //                document.getElementById('spnaddress3').style.display = "block";
    //            }
    //            if (isreqAdd[i] == '4') {
    //                document.getElementById('spnaddress4').style.display = "block";
    //            }
    //            if (isreqAdd[i] == '5') {
    //                document.getElementById('spnaddress5').style.display = "block";
    //            }
    //        }
    //    }

    function OpenAddEditPage(id, val, isdelivery, tooltip, addresstype, clickval, DeliveryCompanyName, DeliveryCompanyID) {
        if (pg == 'estimate' || pg == 'purchase' || pg == 'deliverynote' || pg == 'campaign') {
            GetAddress(id, val, isdelivery, tooltip, addresstype, DeliveryCompanyName, DeliveryCompanyID);
        }
    }

    //*** to get the address for Estimate add page ****//
    function GetAddress(id, value, isdelivery, tooltip, addresstype, DeliveryCompanyName, DeliveryCompanyID) {
        debugger;
        if (pg == 'estimate' || pg == 'purchase' || pg == 'deliverynote' || pg == 'campaign') {
            var pw = window.parent;
            var AddressType;
            if (pg == 'campaign' && addtype == "deliveryaddress") {
                pw.SendDeliveryAddressIDandName(id, value, isdelivery, tooltip, addresstype, controlid);
                window.close();
            }
            if ((pg == 'estimate' && addtype == "deliveryaddress") || (pg == 'deliverynote' && addtype == "deliveryaddress")) {

                pw.SendDeliveryAddressIDandName(id, value, isdelivery, tooltip, addresstype, 'deleveryaddress');
                window.close();
            }
            if (pg == 'estimate' && addtype == 'moreaddress') {

                if (vartype == 'invoice') {
                    pw.SendDeliveryAddressIDandName(id, value, isdelivery, tooltip, addresstype, 'invoiceAddress');
                    window.close();
                }
                else if (vartype == 'contact') {
                    pw.SendDeliveryAddressIDandName(id, value, isdelivery, tooltip, addresstype, 'contactAddress');
                    window.close();
                }
            }

            if (pg == 'purchase' && addtype == "moreaddress") {

                if (vartype == 'Delivery') {
                    pw.SendContactAddressIDandName(id, value, isdelivery, tooltip, addresstype, 'Delivery', DeliveryCompanyName, DeliveryCompanyID);
                    window.close();
                }
                else if (vartype == 'Contact') {
                    pw.SendContactAddressIDandName(id, value, isdelivery, tooltip, addresstype, 'Contact', DeliveryCompanyName, DeliveryCompanyID);
                    window.close();
                }
            }

            if (pg == 'deliverynote' && addtype == "moreaddress") {
                if (vartype == 'Delivery') {
                    pw.SendDeliveryAddressIDandName(id, value, isdelivery, tooltip, addresstype);
                    window.close();
                }
            }
        }
        // window.close();
        return false;
    }
    //*** End of to get the address for Estimate add page ****//

    function SelAddress(id, TotAddress, AddLine1, City, State, PostCode, Country, Phone, Fax, AddType, clickcval, Email, Address2, URL, IsDel) {
        debugger
        var pw = window.parent;
        var item = '<%=item %>';
        var id1 = '<%=id %>';
        var pg = '<%=pg %>';

        //alert(pg + ", " + redirectTo + ", " + pagenameDept);

        if ((pg.toLowerCase() == 'client' || pg.toLowerCase() == 'estimate' || pg.toLowerCase() == 'estimates') || pagename.toLowerCase() == 'contactaddress' || pg == 'deliverynote' || pg == 'purchase' || pg.toLowerCase() == 'jobs' || pg.toLowerCase() == 'invoice') {
            // Redirecting to CLIENT PAGE
            if (pagename.toLowerCase() == 'clientchange') {
                var pw = window.parent;
                pw.SendClientAddressIDandName(id, AddLine1, City, State, PostCode, Country, Phone, Fax, Email, Address2, URL, AddressTo);
            }
            if (pagenameDept.toLowerCase() == 'contactaddress') {
                if (redirectTo.toLowerCase() == 'contacteditmode_ch' || redirectTo.toLowerCase() == 'contacteditmode_edit') {
                    if (action.toLowerCase() == 'edit') {
                        if (wintype.toLowerCase() == 'main') {
                            var pw = window.parent;
                            pw.SendAddressIDandNameToContact(id, TotAddress, AddLine1, Address2, City, State, PostCode, Country, Phone, Fax, '', 'contactaddress');
                            setTimeout("TakeOut()", 600);
                            return false;
                        }
                        else if (wintype.toLowerCase() == 'contactview') {
                            window.location = "<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?clientid=" + clientid + "&type=" + pg + "&pg=" + pg + "&action=edit&contactaddressid=" + id + "&contactid=" + ContactID + "&wintype=contactview&type=customer";
                            return false;
                        }
                        else {
                            window.location = "<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?clientid=" + clientid + "&type=" + pg + "&pg=" + pg + "&action=edit&contactaddressid=" + id + "&contactid=" + ContactID;
                            return false;
                        }
                }
                else {
                    window.location = "<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?clientid=" + clientid + "&type=" + pg + "&pg=" + pg + "&mode=" + mode + "&contactaddressid=" + id + "&contactid=" + ContactID + "&item=" + item + "&id=" + id1;
                        return false;
                    }
                }
            }
            else {
                // Redirecting to DEPARTMENT PAGE
                if (pagenameDept.toLowerCase() == 'deptsh') {
                    if (redirectTo.toLowerCase() == 'deptaddmode') {
                        if (ParentPage.toLowerCase() == 'editcontact') {
                            window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage + "&wintype=" + wintype;
                            return false;
                        }
                        else if (ParentPage.toLowerCase() == 'newcontact') {
                            window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage + "&item=" + item + "&id=" + id1 + "&wintype=" + wintype;
                            return false;
                        }
                        else {
                            window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&wintype=" + wintype;
                            return false;
                        }
                }
                if (redirectTo.toLowerCase() == 'depteditmode') {
                    if (ParentPage.toLowerCase() == 'editcontact') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=" + clientid + "&mode=edit&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage + "&wintype=" + wintype;
                        return false;
                    }
                    else if (ParentPage.toLowerCase() == 'newcontact') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=newcontact&addressto=shipping&clientid=" + clientid + "&mode=edit&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage;
                        return false;
                    }
                    else {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=shipping&clientid=" + clientid + "&mode=edit&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&parentpage=" + redirectTo + "&wintype=" + wintype;
                        return false;
                    }
            }
        }
        else {
            if (redirectTo.toLowerCase() == 'deptaddmode') {
                if (ParentPage.toLowerCase() == 'newcontact' || ParentPage.toLowerCase() == 'editcontact') {
                    window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage + "&item=" + item + "&id=" + id1 + "&wintype=" + wintype;
                        return false;
                    }
                    else {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id;
                        return false;
                    }
                }
                if (redirectTo.toLowerCase() == 'depteditmode') {
                    if (ParentPage.toLowerCase() == 'newcontact' || ParentPage.toLowerCase() == 'editcontact') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=" + clientid + "&mode=edit&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&ContactID=" + ContactID + "&parentpage=" + ParentPage + "&item=" + item + "&id=" + id1 + "&wintype=" + wintype;
                        return false;
                    }
                    else {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&from=addressSelect&addressto=billing&clientid=" + clientid + "&mode=edit&pg=" + pg + "&companytype=" + companytype + "&Pgtype=" + pg + "&addressID=" + id + "&parentpage=" + redirectTo;
                        return false;
                    }
                }
            }
        }
    }
    if (pg == 'estimate') {
        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=deptselect&addressto=billing&companytype=customer&clientid=" + clientid + "&mode=add&pg=" + pg + "&addressID=" + id + "&ContactID=" + ContactID;
            return false;
        }

        if (pg == 'job') {
            //to send to multiple delvery note page
            pw.SendAddressIDandName(id, TotAddress, AddLine1, City, State, PostCode, Country, Phone, Fax, AddType, clickcval, IsDel, Address2);
        }
        if (pg.toLowerCase() == 'contact') {
            var pw = window.parent;
            var AddressLine2 = clickcval;
            // Redirecting to CONTACT PAGE
            if (pagename.toLowerCase() == 'contactsh') {
                pw.SendAddressIDandNameToContact(id, TotAddress, AddLine1, City, State, PostCode, Country, Phone, Fax, AddType, AddressLine2, Email, "Shipping");
            }
            else {
                pw.SendAddressIDandNameToContact(id, TotAddress, AddLine1, City, State, PostCode, Country, Phone, Fax, AddType, AddressLine2, Email, "Billing");
            }
        }
        setTimeout("TakeOut()", 600);
        return false;
    }

    function TakeOut() {
        window.close();
    }

    function add_new(type) {
        if (type == 'show') {
            document.getElementById("<%=btncancel_addressSelector.ClientID %>").style.display = "none";
            document.getElementById("<%=btnSaveAs.ClientID %>").style.display = "none";
            document.getElementById("<%=div_add.ClientID %>").style.display = "block";
            document.getElementById("<%=txt_AddressLabel.ClientID %>").value = ""; // Clearing fields when add new address--Start
            document.getElementById("<%=txtaddress.ClientID %>").value = "";
            document.getElementById("<%=txt_address2.ClientID %>").value = "";
            document.getElementById("<%=txt_suburb.ClientID %>").value = "";
            document.getElementById("<%=txt_postCode.ClientID %>").value = "";
            document.getElementById("<%=txttelephone.ClientID %>").value = "";
            document.getElementById("<%=txtfax.ClientID %>").value = "";
            document.getElementById("<%=chkpostbox.ClientID %>").checked = false;
            document.getElementById("<%=chkhideaddress.ClientID %>").checked = false;
            document.getElementById("<%=txt_city.ClientID %>").value = ""; // Clearing fields when add new address--End
            document.getElementById("<%=div_RadGrid_AddressSelector.ClientID %>").style.display = "none";
            document.getElementById('<%=txtaddress.ClientID %>').focus();
        }
    }

    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
    function Show() {
        if (document.getElementById("divrad").style.display == "none") {
            setLoadingPositionOfDivMove(document.getElementById("divrad"));
            showDivPopupCenter('divrad', '200');
        }
        else {
            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
    }


    var checkwhat = false;
    function btnadd_save(val) {
        debugger
        var span_ddlcountry = document.getElementById("span_ddlcountry");
        // var span_txtaddress = document.getElementById("span_txtaddress");
        var ddlcountry = document.getElementById('<%=ddlcountry.ClientID%>');
        var txtName = document.getElementById('<%=txtName.ClientID %>');
        var txtaddress = document.getElementById('<%=txtaddress.ClientID %>').value;
        var txtaddress2 = document.getElementById('<%=txt_address2.ClientID %>').value;
        var txtaddress3 = document.getElementById('<%=txt_city.ClientID %>').value;
        var txtaddress4 = document.getElementById('<%=txt_suburb.ClientID %>').value;
        var txtaddress5 = document.getElementById('<%=txt_postCode.ClientID %>').value;
        var spn_txtName = document.getElementById('spn_txtName');
        var NoOfAddress = '<%=NoOfAddress %>';
        checkwhat = true;
        var chkAddress = false;
        var RequiredAddress = 0;
        var strisreqAdd = '<%=RequiredAddress %>';
        if (NoOfAddress != 0 || txtName.value == "") {
            if (txtName.value.trim() == "") {
                spn_txtName.style.display = "block";
                spn_txtName.innerHTML = "Please select Customer Name";
                return false;
            }
            else
                spn_txtName.style.display = "none";
        }

        if (strisreqAdd != '') {
            var isreqAdd = strisreqAdd.split(',')
            for (var i = 0; i < isreqAdd.length; i++) {
                if (isreqAdd[i] == '1') {
                    if (txtaddress.trim() == '') {
                        document.getElementById('span_txtaddress1').style.display = "block";
                        document.getElementById('span_txtaddress1').innerHTML = "Please enter address line 1";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('span_txtaddress1').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '2') {
                    if (txtaddress2.trim() == '') {
                        document.getElementById('span_txtaddress2').style.display = "block";
                        document.getElementById('span_txtaddress2').innerHTML = "Please enter address line 2";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('span_txtaddress2').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '3') {
                    if (txtaddress3.trim() == '') {
                        document.getElementById('span_txtaddress3').style.display = "block";
                        document.getElementById('span_txtaddress3').innerHTML = "Please enter address line 3";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('span_txtaddress3').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '4') {
                    if (txtaddress4.trim() == '') {
                        document.getElementById('span_txtaddress4').style.display = "block";
                        document.getElementById('span_txtaddress4').innerHTML = "Please enter address line 4";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('span_txtaddress4').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '5') {
                    if (txtaddress5.trim() == '') {
                        document.getElementById('span_txtaddress5').style.display = "block";
                        document.getElementById('span_txtaddress5').innerHTML = "Please enter address line 5";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('span_txtaddress5').style.display = "none";
                    }
                }
            }
        }

        if (RequiredAddress == 1) {
            return false;
        }
        else {

        }

        if (val == 'save') {
            if (mode == 'add' && type == 'moreaddress') {

                checkwhat = true;
            }
            else {
                if (mode != 'view') {
                    if (confirm("This address is used in other departments AND/OR contacts. This changes will effect other departments and contacts. Do you want to continue?")) {

                        checkwhat = true;

                    }
                    else {
                        checkwhat = false;
                    }
                }
                else {

                    checkwhat = true;
                }
            }
        }
        // if (window.location.href.indexOf('pg=purchase') > -1) {
        //txtName_old  && SpecialEncode(clientname) != SpecialEncode(txtName.value)
        var txttelephone_1 = document.getElementById('<%=txttelephone.ClientID %>').value;
        var txtfax_1 = document.getElementById('<%=txtfax.ClientID %>').value;
        var txt_AddressLabel_1 = document.getElementById('<%=txt_AddressLabel.ClientID %>').value;
        var clientid = document.getElementById('<%=hid_ClientID.ClientID %>').value;
        var clientname = document.getElementById('<%=hid_CustName.ClientID %>').value;
        var clientname_old = document.getElementById('<%=hid_CustName_old.ClientID %>').value;
        if ((clientid != '0' && SpecialEncode(clientname) != SpecialEncode(txtName.value) && clientname_old == '') || (clientid == '0')) {
            checkwhat = false;
            spn_txtName.style.display = "block";
            spn_txtName.innerHTML = "Please select valid customer";
        }
        if ((clientname != '' && clientid != '0') || (clientname_old != '' && clientid != '0')) {
            checkwhat = true;
        }
        //}
        if (checkwhat) {

            if (window.location.href.indexOf('pg=purchase') > -1) {
                var strcountry = SpecialEncode(ddlcountry.options[ddlcountry.selectedIndex].text);
                var address_new = SpecialEncode(txt_AddressLabel_1 + ' ' + txtaddress + ' ' +
                 txtaddress2 + ' ' + txtaddress3 + ' ' + txtaddress4 + ' ' + txtaddress5 + ' ' + strcountry + ' ' + txttelephone_1 + ' ' + txtfax_1);
                var pw = window.parent;
                var txtNam1 = SpecialEncode(txtName.value)
                pw.get_address_newsaved(txtNam1, address_new);
            }

            return true;
        }
        else {

            return false;
        }
    }
    var txtname_new = '';
    function get_changedcustomername(txtname) {
        txtname_new = txtname;
        document.getElementById('<%=hid_ClientID.ClientID %>').value = '0';
    }
    function SpecialEncode(OriginalString) {
        OriginalString = OriginalString.split("'").join('%27');
        OriginalString = OriginalString.split('"').join('%22');
        return OriginalString;
    }
    function SpecialDecode(OriginalString) {
        OriginalString = OriginalString.split('%27').join("'");
        OriginalString = OriginalString.split('%22').join('"');
        return OriginalString;
    }

    function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
        txtName.value = SpecialDecode(ClientName);
        hid_ClientID.value = ClientID;
        document.getElementById('<%=hid_CustName.ClientID %>').value = ClientName;
    }

    function validateAddress(obj, spnerror) {
        var txtvalue = document.getElementById(obj.id).value;

        if (txtvalue.trim() == '' || txtvalue == '') {
            var spnerrorMsg = document.getElementById(spnerror)
            spnerrorMsg.style.display = "block";
            spnerrorMsg.innerHTML = "Please enter address";
        }
        else {
            document.getElementById(spnerror).style.display = "none";
        }
    }
</script>
<script type="text/javascript" language="javascript">

    var pagename = '<%=pagename %>';
    var rtn = '<%=rtn %>';
    var redirectTo = '<%=redirectTo %>';
    var pg = '<%=pg %>';

    var txtaddress = document.getElementById("<%=txtaddress.ClientID %>");
    var txt_city = document.getElementById("<%=txt_city.ClientID %>");
    var txt_suburb = document.getElementById("<%=txt_suburb.ClientID %>");
    var txt_postCode = document.getElementById("<%=txt_postCode.ClientID %>");
    var ddlcountry = document.getElementById("<%=ddlcountry.ClientID %>");
    var txttelephone = document.getElementById("<%=txttelephone.ClientID %>");
    var txtfax = document.getElementById("<%=txtfax.ClientID %>");
    var txtemail = document.getElementById("<%=txtemail.ClientID %>");
    var txtURL = document.getElementById("<%=txtURL.ClientID %>");
    var txt_address2 = document.getElementById("<%=txt_address2.ClientID %>");
    var addressTotal = txtaddress.value + ' ' + txt_city.value + ' ' + txt_suburb.value + ' ' + txt_postCode.value + ' ' + txt_address2.value + ' ' + ddlcountry.options[ddlcountry.selectedIndex].text;
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    function checkchanged(obj, id) {
        var chkdelivery = document.getElementById('<%=chkdelivery.ClientID %>');
        var chkbilling = document.getElementById('<%=chkbilling.ClientID %>');
        if (obj == 'delivery') {
            chkbilling.checked = false;
        }
        else {
            chkdelivery.checked = false;
        }
    }

    function validateClose() {
        var pageFrom = '<%=pageFrom %>';
        var pagename = '<%=pagename %>';

        if (pg == 'purchase') {
            document.getElementById("<%=btncancel_addressSelector.ClientID %>").style.display = "none";
            document.getElementById("<%=btnSaveAs.ClientID %>").style.display = "none";
            document.getElementById("<%=div_add.ClientID %>").style.display = "block";
            document.getElementById("<%=div_RadGrid_AddressSelector.ClientID %>").style.display = "none";
            document.getElementById('<%=txtaddress.ClientID %>').focus();
        }
        else if (pagename == '' && pageFrom == '') {
            setTimeout("TakeOut()", 600);
            return true;
        }
        return true;
    }

</script>
<asp:Panel ID="pnl_Dept_Contact" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function sendDeptAddressDetails() {

            if (pg.toLowerCase() == 'client') {
                if (redirectTo.toLowerCase() == 'deptsh') {
                    // Redirection to DEPARTMENT ADD PAGE (Delivery Address)
                    var pw = window.parent;
                    pw.SendDeptAddressIDandName(rtn, '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value, ddlcountry.options[ddlcountry.selectedIndex].text, 'A', txtaddressline5.value, "Shipping");
                    setTimeout("TakeOut()", 600);
                }
                else {
                    // Redirection to DEPARTMENT ADD PAGE (Business Address)
                    var pw = window.parent;
                    pw.SendDeptAddressIDandName(rtn, '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value, ddlcountry.options[ddlcountry.selectedIndex].text, 'A', txtaddressline5.value, "Billing");
                    setTimeout("TakeOut()", 600);
                }
            }

            // Redirection to CONTACT ADD NEW PAGE
            if (pg.toLowerCase() == 'contact') {
                var pw = window.parent;
                pw.SendAddressIDandNameToContact(rtn, addressTotal, txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value, ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, 'A', txtaddressline5.value, txtemail.value, 'Billing');
                setTimeout("TakeOut()", 600);
            }
            // Redirection to CONTACT ADD NEW PAGE
            if (pg.toLowerCase() == 'contactsh') {
                var pw = window.parent;
                pw.SendAddressIDandNameToContact(rtn, addressTotal, txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value, ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, 'A', txtaddressline5.value, txtemail.value, 'Shipping');
                setTimeout("TakeOut()", 600);
            }
        }
        function TakeOut() {
            window.close();
        }
        sendDeptAddressDetails();

    </script>
</asp:Panel>
<asp:Panel ID="pnlSendAddressDetails" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function SendAddressDetails() {
            // Redirecting to CONTACT PAGE (Contact Address)
            if (pagename.toLowerCase() == 'contact') {
                var pw = window.parent;
                pw.SendAddressIDandNameToContact('<%=addressid %>', '', txtaddress.value, txt_address2.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, '', 'contactaddress');
                setTimeout("TakeOut()", 600);
                return false;
            }
            // Redirecting to CLIENT PAGE
            if (pagename.toLowerCase() == 'clientedit') {
                var pw = window.parent;
                pw.SendClientAddressIDandName('<%=addressid %>', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, txtemail.value, txt_address2.value, txtURL.value, AddressTo);
                setTimeout("TakeOut()", 600);
                return false;
            }
            // Redirecting to CONTACT PAGE (Business Address)
            if (pagename.toLowerCase() == 'contactedit') {
                var pw = window.parent;
                pw.SendAddressIDandNameToContact('<%=addressid %>', '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, 'A', '', txtemail.value, "Billing");
                setTimeout("TakeOut()", 600);
                return false;
            }
            // Redirecting to CONTACT PAGE (Delivery Address)
            if (pagename.toLowerCase() == 'contacteditsh') {
                var pw = window.parent;
                pw.SendAddressIDandNameToContact('<%=addressid %>', '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, 'A', '', txtemail.value, "Shipping");
                setTimeout("TakeOut()", 600);
                return false;
            }
            // Redirecting to DEPARTMENT PAGE (Business Address)
            if (pagename.toLowerCase() == 'deptedit') {
                var pw = window.parent;
                pw.SendDeptAddressIDandName('<%=addressid %>', '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, 'A', txtaddressline5.value, "Billing");
                setTimeout("TakeOut()", 600);
                return false;
            }
            // Redirecting to DEPARTMENT PAGE (Delivery Address)
            if (pagename.toLowerCase() == 'depteditsh') {
                var pw = window.parent;
                pw.SendDeptAddressIDandName('<%=addressid %>', '', txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value,
                    ddlcountry.options[ddlcountry.selectedIndex].text, 'A', txtaddressline5.value, "Shipping");
                setTimeout("TakeOut()", 600);
                return false;
            }
            if (pg.toLowerCase() == 'client') {
                var pw = window.parent;
                pw.SetTabs('address', 'yes');
                setTimeout("TakeOut()", 600);
                return false;
            }
        }
        function TakeOut() {
            window.close();
        }
        SendAddressDetails();


    </script>
</asp:Panel>
<asp:Panel ID="pn_close" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function closeCurrentPopupWindow() {
            setTimeout("TakeOut()", 600);
            return false;
        }
        function TakeOut() {
            window.close();
        }
        closeCurrentPopupWindow();

    </script>
</asp:Panel>
<asp:Panel ID="pnl_ContactAddress" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        var ContactAddress = '<%=ContactAddress %>';
        var addresstype = '<%=addresstype %>';

        var isDefaultPostBox = '<%=isDefaultPostBox %>';
        function Contact_Address() {
            if (isDefaultPostBox == 'false') {
                if (addresstype == "contact") {
                    window.parent.SendDeliveryAddressIDandName(rtn, ContactAddress, false, ContactAddress, 'A', 'contactAddress');

                }
                else if (addresstype == "invoice") {
                    window.parent.SendDeliveryAddressIDandName(rtn, ContactAddress, false, ContactAddress, 'A', 'invoiceAddress');

                }
                else {
                    window.parent.SendDeliveryAddressIDandName(rtn, ContactAddress, false, ContactAddress, 'A', 'deleveryaddress');

                }
            }
            else if (addresstype == "invoice") {
                window.parent.SendDeliveryAddressIDandName(rtn, ContactAddress, false, ContactAddress, 'A', 'invoiceAddress');
            }
            else {
                alert("Note: Post Box address cannot be used as Contact/Delivery Address");
            }
            setTimeout("TakeOut()", 1000);
        }
        function TakeOut() {
            window.close();
        }
        Contact_Address();
    </script>
</asp:Panel>
<asp:Panel ID="Pnl_DeliveryNote" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        var DeliveryAddress = '<%=DeliveryAddress %>';
        var addressid = '<%=addressid %>';

        var isDefaultPostBox = '<%=isDefaultPostBox %>';
        function sendDeliveryAddress() {

            if (isDefaultPostBox == 'false') {            //---------------to check for PO checkbox
                window.parent.SendDeliveryAddressIDandName(rtn, DeliveryAddress, false, DeliveryAddress, 'A');
            }
                //---------------Added for Note Popup-------------------------------------------
            else {
                alert("Note: Post Box address cannot be used as Contact/Delivery Address");
            }
            //------------------------------------------------------------------------------
            setTimeout("TakeOut()", 1000);
        }
        function TakeOut() {
            window.close();
        }
        sendDeliveryAddress();
    </script>
</asp:Panel>
<asp:Panel ID="Pnl_purchase" runat="server" Visible="false">
    <asp:HiddenField ID="hdnDeliveryToCompanyID" runat="server" Value="0" />
    <script type="text/javascript" language="javascript">
        var addresstype = '<%=addresstype %>';
        var DeliveryAddress = '<%=DeliveryAddress %>';
        var addressid = '<%=addressid %>';
        var DefaultCompany = '<%=DefaultCompany %>';

        var isDefaultPostBox = '<%=isDefaultPostBox %>';
        function sendDeliveryAddress() {

            var hdnDeliveryToCompanyID = document.getElementById("<%=hdnDeliveryToCompanyID.ClientID %>")
            if (isDefaultPostBox == 'false') {            //---------------to check for PO checkbox
                window.parent.SendDeliveryAddressIDandName(DefaultCompany, rtn, DeliveryAddress, addresstype, hdnDeliveryToCompanyID.value)
            }
                //---------------Added for Note Popup-------------------------------------------
            else {
                alert("Note: Post Box address cannot be used as Contact/Delivery Address");
            }
            //------------------------------------------------------------------------------
            setTimeout("TakeOut()", 600);
        }
        function TakeOut() {
            window.close();
        }
        sendDeliveryAddress();
    </script>
</asp:Panel>
<asp:Panel ID="Pnl_job" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        var rtn = '<%=rtn %>';
        var DeliveryAddress = '<%=DeliveryAddress %>';
        var clickvalfromsplitaddress = '<%=clickvalfromsplitaddress %>';

        function sendAddress() {
            window.parent.SendAddressIDandName(rtn, DeliveryAddress, txtaddress.value, txt_city.value, txt_suburb.value, txt_postCode.value, ddlcountry.options[ddlcountry.selectedIndex].text, txttelephone.value, txtfax.value, '', clickvalfromsplitaddress, 0, txt_address2.value);
            setTimeout("TakeOut()", 500);
        }
        function TakeOut() {
            window.close();
        }
        sendAddress();
    </script>
</asp:Panel>
<script language="javascript" type="text/javascript">
    function Close() {
        //alert("close");
        var oWindow = GetRadWindow();
        //alert(oWindow);
        //oWindow.argument = "hai";
        oWindow.close();
        return false;
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
</script>
