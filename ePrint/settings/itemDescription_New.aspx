<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.master" AutoEventWireup="true" CodeBehind="itemDescription_New.aspx.cs" Inherits="ePrint.settings.itemDescription_New" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridSelectedCustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_4">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_5">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_6">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_7">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_8">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_9">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_10">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_11">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_12">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_13">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_14">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkEstType_15">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridItemDescription" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: none;
            }

        .RadGrid_Default .rgCommandCell {
            border: none;
            margin-top: -8px;
        }

        .RadGrid_Default .rgHeader {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }

        .RadGrid_Default {
            outline: none;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div align="left">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objLanguage.GetLanguageConversion("Settings_Item_Descriptions")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div id="" class="mis_header_panel" style="padding-right: 10px;">
                <asp:UpdatePanel ID="UpdatePanelMessage" runat="server" RenderMode="Inline" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div style="float: left;">
                    <div style="display: inline; float: left; margin-right: 5px">
                        <div id="div_btncancel" style="display: block">
                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                runat="server" Text="Cancel" CommandName="Cancel" OnClick="btnCancel_OnClick">
                            </telerik:RadButton>
                        </div>
                        <div id="div_btncancelprocess" class="button" align="center" style="width: 43px; height: 14px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left; padding-top: 0px">
                        <div id="div_btnsave" style="display: block">
                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                runat="server" Text="Save" OnClick="btnSave_OnClick">
                            </telerik:RadButton>
                        </div>
                        <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                </div>
                <div class="only5px">
                </div>
                <div class="only5px">
                </div>
                <div align="left">
                    <div id="ynnav" style="width: 100%;">
                        <ul>
                            <li id="li_Inventory" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UP1" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_1" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px; border-left: 1px solid #BDBDBD;">
                                            <asp:LinkButton ID="lnkEstType_1" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="S"><b><span id="item_1" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Single_Item")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li3" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_2" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_2" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="B"><b><span id="item_2" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Booklet")%>  </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li4" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel3" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_3" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_3" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="P"><b><span id="item_3" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Pads")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li11" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel14" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_14" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_14" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="R"><b><span id="item_14" class="lnkTabSelected">	
                                        <%=objLanguage.GetLanguageConversion("Digital_NCR")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li_StoreSupply" style="cursor: pointer; float: left; clear: right; display: none"
                                runat="server">
                                <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_4" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_4" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="L"><b><span id="item_4" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Large_Format")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li_CustomerItem" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel5" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_5" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_5" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="W"><b><span id="item_5" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Warehouse")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li1" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel6" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_6" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_6" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="O"><b><span id="item_6" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Outwork")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li2" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel7" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_7" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_7" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="U"><b><span id="item_7" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Other_Cost")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li5" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel8" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_8" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_8" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="C"><b><span id="item_8" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Product_Catalogue")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li6" style="cursor: pointer; float: left; clear: right; display: none" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel9" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div9" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_9" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="F"><b><span id="item_9" class="lnkTabSelected">
                                        <%=objLanguage.GetLanguageConversion("Offset_Single")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li8" style="cursor: pointer; float: left; clear: right; display: none" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel11" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div11" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_11" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="K"><b><span id="item_11" class="lnkTabSelected" >
                                        <%=objLanguage.GetLanguageConversion("Offset_Booklet")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li9" style="cursor: pointer; float: left; clear: right; display: none" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel12" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div12" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_12" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="D"><b><span id="item_12" class="lnkTabSelected" >
                                        <%=objLanguage.GetLanguageConversion("Offset_Pad")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li10" style="cursor: pointer; float: left; clear: right; display: none" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel13" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div13" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_13" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="N"><b><span id="item_13" class="lnkTabSelected" >
                                        <%=objLanguage.GetLanguageConversion("Offset_NCR")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li7" style="cursor: pointer; float: left; clear: right; display: none" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel10" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div10" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_10" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="Q"><b><span id="item_10" class="lnkTabSelected" >
                                        <%=objLanguage.GetLanguageConversion("Quick_Quote")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                            <li id="li12" runat="server" style="cursor: pointer; float: left; clear: right; display: none">
                                <asp:UpdatePanel ID="UpdatePanel15" RenderMode="Block" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <div id="div_15" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                                            <asp:LinkButton ID="lnkEstType_15" class="lnkTabSelected" runat="server" OnClick="btnEstType_OnClick"
                                                CommandName="T"><b><span id="item_15" class="lnkTabSelected">	
                                        <%=objLanguage.GetLanguageConversion("Delivery_Cost")%> </span></b></asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </li>
                        </ul>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div class="divBorderItem">
                    <div id="padding">
                        <div align="left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <telerik:RadGrid ID="GridItemDescription" AutoGenerateColumns="false" runat="server" BorderWidth="0"
                                        ShowStatusBar="true" ItemStyle-Height="2%" GridLines="None" Width="40%" HeaderStyle-Font-Bold="true"
                                        OnItemDataBound="OnItemDataBound_GridItemDescription"
                                        ClientSettings-AllowRowsDragDrop="true" OnRowDrop="grdScreenName_RowDrop">
                                        <MasterTableView DataKeyNames="ItemDescriptionID">
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="Field Name" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%"
                                                    HeaderStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnDescriptionID" runat="server" Value='<%#Eval("ItemDescriptionID")%>' />
                                                        <asp:HiddenField ID="hdnEstimateType" runat="server" Value='<%#Eval("EstimateType")%>' />
                                                        <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("DatabaseFieldName")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnFieldName" runat="server" Value='<%#Eval("DatabaseFieldName")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%-- By Jagat On 27/July/2012--%>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                                    <HeaderTemplate>
                                                        <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image ID="ImgisChecked" ImageUrl="~/images/check.gif" runat="server" Visible="false" />
                                                        <asp:CheckBox ID="isChecked" runat="server" Checked='<%#Eval("IsChecked")%>' />
                                                        <asp:HiddenField ID="isCheckedID" runat="server" Value="0" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--  End--%>
                                                <telerik:GridTemplateColumn HeaderText="Screen Name" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60%"
                                                    HeaderStyle-Width="60%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtScreenName" runat="server" Text='<%#Eval("ScreenName")%>' Height="15px"
                                                            Width="250px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Reorder"
                                                    UniqueName="Action" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false">
                                                    <ItemTemplate>
                                                        <div>
                                                            <center>
                                                                <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px; background-repeat: no-repeat; margin: 0px 0px 0px 12px;">
                                                            </center>
                                                        </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                            <Selecting EnableDragToSelectRows="True" />
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <%--                        <div style="float: left;>
                            <div style="display: inline; float: left; margin-right: 5px">
                                <div id="div_btncancel" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                        runat="server" Text="Cancel" CommandName="Cancel" OnClick="btnCancel_OnClick">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_btncancelprocess" class="button" align="center" style="width: 43px;
                                    height: 14px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div style="float: left; padding-top: 0px">
                                <div id="div_btnsave" style="display: block">
                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                        runat="server" Text="Save" OnClick="btnSave_OnClick">
                                    </telerik:RadButton>
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px;
                                    display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>--%>
                        <div style="clear: both;">
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function hide() {

            document.getElementById('ctl00_ContentPlaceHolder1_UpdatePanel1').style.display = 'none';
            return false;
        }


    </script>
    <script type="text/javascript">
        function CheckAll(checkAllBox) {


            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('isChecked') != -1) e.checked = ChkState;
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_1') != -1) e.checked = ChkState;
            }
        }

    </script>
    <script type="text/javascript">




        function CangeCssTab(btnID) {
            var itemID = btnID.split('_');
            for (var i = 1; i <= 14; i++) {
                if (i == itemID[1]) {
                    document.getElementById("item_" + i).style.color = "#FFA500";
                }
                else {
                    document.getElementById("item_" + i).style.color = "#000000";
                }
            }
        }
        if ('<%=EstType%>' == 'S') {
            document.getElementById("item_1").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'B') {
            document.getElementById("item_2").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'P') {
            document.getElementById("item_3").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'L') {
            document.getElementById("item_4").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'W') {
            document.getElementById("item_5").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'O') {
            document.getElementById("item_6").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'U') {
            document.getElementById("item_7").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'C') {
            document.getElementById("item_8").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'F') {
            document.getElementById("item_9").style.color = "#FFA500";
        } else if ('<%=EstType%>' == 'Q') {
            document.getElementById("item_10").style.color = "#FFA500";
        }
        else if ('<%=EstType%>' == 'K') {
            document.getElementById("item_11").style.color = "#FFA500";
        }
        else if ('<%=EstType%>' == 'N') {
            document.getElementById("item_12").style.color = "#FFA500";
        }
        else if ('<%=EstType%>' == 'D') {
            document.getElementById("item_13").style.color = "#FFA500";
        }
        else if ('<%=EstType%>' == 'R') {
            document.getElementById("item_14").style.color = "#FFA500";
        }
        else if ('<%=EstType%>' == 'T') {
            document.getElementById("item_15").style.color = "#FFA500";
        }
    </script>
</asp:Content>

