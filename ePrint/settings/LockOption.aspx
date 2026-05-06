<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LockOption.aspx.cs" Inherits="ePrint.settings.LockOption" title="Lock Options" masterpagefile="~/Templates/settingpage.master"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
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
                                
                            </div>
                            <div style="float: left; width: 80%; border: solid 0px">
                                <div id="divDigital_PODeliveryAddres" runat="server" align="left">
                                    <div align="left">
                                        <div class="bglabel">
                                            <asp:Label ID="lblDigital_PODeliveryAddres" runat="server" Text="What method of lock would you like to use" CssClass="normalText"></asp:Label></div>
                                        <div class="box">
                                            <div style="float: left">
                                                <asp:DropDownList runat="server" ID="ddlLockTypes" CssClass="normalText"  AutoPostBack="false"
                                                    Width="350px">
                                                    <asp:ListItem Value="LockEditing">Lock product editing</asp:ListItem>
                                                    <asp:ListItem Value="LockEditingDesc">Lock product editing and descriptions</asp:ListItem>
                                                    <asp:ListItem Value="LockEditingDescStatus">Lock product editing, descriptions and status changes</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="width: 75%; border: 0px solid">
                            <div class="bglabelEmpty" style="width: 17%">
                            </div>
                            <div class="box">
                                <div style="float: right; margin-bottom: 10px">
                                    <div id="div_btnSave_PODeliveryAddres" style="display: block">
                                        <asp:Button CssClass="button" Skin="EprintbtnSkin" OnClick="btnSave_Click" EnableEmbeddedSkins="false" ID="btnSave"
                                            runat="server" Text="save"  ></asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess_PODeliveryAddres" class="button" align="center" style="height: 14px;
                                        width: 33px; display: none">
                                        <%--<img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />--%>
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

