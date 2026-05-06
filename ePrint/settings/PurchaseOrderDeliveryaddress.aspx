<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/settingpage.master" CodeBehind="PurchaseOrderDeliveryaddress.aspx.cs" Inherits="ePrint.settings.PurchaseOrderDeliveryaddress" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div align="left" id="pnldetails">
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div style="width: 100%; padding-left: 10px; margin-top: -3px;">
                    <div id="">
                        <div align="left" style="width: 100%; padding-top: 10px; margin-bottom: -10px;">
                            <div style="width: 100%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <div align="left" style="width: 100%">
                            <div align="left" style="padding-bottom: 10px;">
                                <div>
                                    <asp:Label ID="lblDeliveryTo_POselecttext" runat="server" CssClass="normalText" Style="font-weight: bold;">
                                    </asp:Label>
                                </div>
                                <div style="margin-bottom: 5px;">
                                </div>
                                <div>
                                    <asp:Label ID="lblDeliveryTo_PODeliveryAddres" runat="server" Text="Delivey To" CssClass="normalText"
                                        Style="font-weight: bold;"></asp:Label></div>
                            </div>
                            <div style="float: left; width: 49%; border: solid 0px">
                                <div id="divDigital_PODeliveryAddres" runat="server" align="left">
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="lblDigital_PODeliveryAddres" runat="server" Text="Digital" CssClass="normalText"></asp:Label></div>
                                        <div class="box">
                                            <div style="float: left">
                                                <asp:DropDownList runat="server" ID="ddlDigital_PODeliveryAddres" CssClass="normalText"
                                                    Width="185px">
                                                    <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                    <asp:ListItem Value="r">System Address</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divOffset_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblOffset_PODeliveryAddres" runat="server" Text="Offset" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlOffset_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divLargeFormat_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblLargeformat_PODeliveryAddres" runat="server" Text="Large Format"
                                            CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlLargeformat_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divOutwork_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblOutwork_PODeliveryAddres" runat="server" Text="Outwork" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlOutwork_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hid_Organisation" runat="server" Value=""></asp:HiddenField>
                                </div>
                                <div id="divProdCatlogue_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblProdCatlogue_PODeliveryAddres" runat="server" Text="Product Catalogue"
                                            CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlProdCatlogue_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divOthercost_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblOtherCost_PODeliveryAddres" runat="server" Text="Other Costs" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlOtherCost_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divQuickquote_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblQuickQuote_PODeliveryAddres" runat="server" Text="Quick Quote"
                                            CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlQuickQuote_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divWarehouse_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblWarehouse_PODeliveryAddres" runat="server" Text="Warehouse" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlWarehouse_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divWebstoreorder_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblWebstoreorder_PODeliveryAddres" runat="server" Text="Order" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlWebstoreorder_PODeliveryAddres" CssClass="normalText"
                                                Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r" Selected="True">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divDirectPO_PODeliveryAddres" runat="server" align="left">
                                    <div class="bglabel">
                                        <asp:Label ID="lblDirectPO_PODeliveryAddres" runat="server" Text="Direct PO" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlDirectPO_PODeliveryAddres" CssClass="normalText"
                                                Enabled="false" Style="cursor: not-allowed;" Width="185px">
                                                <asp:ListItem Value="a">Job Customer Address</asp:ListItem>
                                                <asp:ListItem Value="r" Selected="True">System Address</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="divInventoryPO_include_description" runat="server" align="left">   
                                    <div class="bglabel">
                                        <asp:Label ID="lblInventoryPO_include_description" runat="server" Text="Inventory PO's include the inventory description as well as the inventory item title" CssClass="normalText"></asp:Label></div>
                                    <div class="box">
                                        <div style="float: left">
                                            <asp:DropDownList runat="server" ID="ddlInventoryPO_include_description" CssClass="normalText"
                                                Enabled="true" Width="185px">
                                                <asp:ListItem Value="a">Enable</asp:ListItem>
                                                <asp:ListItem Value="r" Selected="True">Disable</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="width: 81%; border: 0px solid">
                            <div class="bglabelEmpty" style="width: 17%">
                            </div>
                            <div class="box">
                                <div style="float: left; margin-bottom: 10px">
                                    <div id="div_btnSave_PODeliveryAddres" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave_PODeliveryAddres"
                                            runat="server" Text="save" OnClick="btnSave_OnClick" OnClientClick="loadingimg(this.id,'div_btnsaveprocess_PODeliveryAddres');"></asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess_PODeliveryAddres" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

