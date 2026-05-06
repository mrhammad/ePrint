<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="other_settings.aspx.cs" Inherits="ePrint.settings.other_settings" title="Settings: Other Settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: underline;
            margin-left: -9px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-top: -8px;
        }
        .RadGrid_Default .rgAdd
        {
            display: none;
        }
        
        .RadGrid_Default .rgCommandTable
        {
            margin-top: -8px;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }
        .RadGrid_Default
        {
            outline: none;
        }
        </style>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left; width: 100%" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" Text="Other Settings" CssClass="navigatorpanel"></asp:Label>
                               </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
          
         <div align="left" style="width: 100%;" class="mis_header_panel">
                    <div id="">
                        <div style="width: 100%; padding-bottom: 2px">
                            <div style="width: 100%;">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lbltext" runat="server" CssClass="bglabel" Text="Map job with dropdown"  Style="width:175px;clear:both;word-break:break-all;"></asp:Label>&nbsp;
                                    <asp:TextBox ID="txtothersettings" runat="server" value="Job Name" CssClass="textboxnew"></asp:TextBox>
                                    <asp:DropDownList id="ddl_othersettings" runat="server" CssClass="normalText" style="width:185px;"></asp:DropDownList>
                                </td>
                               
                                </tr>
                           </table>
                        &nbsp;
                        <div>
                         <div id="div_btnSave" style="display: block">
                                    <asp:Button CssClass="button" Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                            runat="server" Text="save" OnClick="btnSave_OnClick"  OnClientClick="javascript:var a=Validate();if(a)loadingimg('div_btnSave','div_btnsaveprocess');return a;">
                                     </asp:Button>
                                </div>
                        <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                             </div>
                           </div>
                     </div>
             </div>
        </div>
               
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>



