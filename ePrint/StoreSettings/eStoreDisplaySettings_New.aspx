<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="eStoreDisplaySettings_New.aspx.cs" Inherits="ePrint.StoreSettings.eStoreDisplaySettings_New" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grd_eStore_DisplaySettings">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grd_eStore_DisplaySettings" LoadingPanelID="RadAjaxLoadingPanel" />
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
            text-decoration: none;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
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
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" SkinID="Windows7" runat="server" />
    <div align="left" id="pnldetails" class="estore_settingBox">
        <div align="left" id="Div1">
            <div align="left">
                <UC:Header ID="header" runat="server" />
                <div style="width: 100%; display: none;" class="navigatorpanel">
                    <div class="t">
                        <div class="t">
                            <div class="t">
                                <div class="divpadding">
                                    <div align="left" style="float: left;" nowrap="nowrap">
                                        <span class="navigatorpanel">
                                            <asp:Label ID="Label1" runat="server">eStore Settings:&nbsp;CheckOut Screens: &nbsp;</asp:Label><%--Display Settings--%>
                                            <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                                href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                                <asp:Label ID="lbl_change" runat="server" Text="Change">Change</asp:Label>
                                            </a></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
                <%-- <div style="float: left; width: 230px; height: 20px">
                </div>--%>
                <div style="min-height: 350px">
                    <div id="div_GridAdmin" style="display: block; padding: 7px 0px 50px 10px">
                        <div align="left" style="width: 100%; padding: 0px 0px 0px 0px; border: 0px solid red">
                            <div style="width: 60%">
                                <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="OrderInformation" runat="server" style="margin-top: -30px;margin-bottom:5px;">
                            <div class="bglabel" style="width: 17%; margin-bottom: 5px;">
                                <asp:Label ID="Label2" runat="server" CssClass="normaltext">Step 1: <%=objLanguage.GetLanguageConversion("Show_Order_Information")%> </asp:Label>
                            </div>
                            <div style="margin-top: 33px;">
                                <asp:CheckBox ID="chk_EnableOrder" onchange="Show_EnableOrder()" runat="server" />
                            </div>
                        </div>
                        <div id="div5" style="padding: 5px 0px 0px 0px; display: block;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div id="div_Grid">
                                        <telerik:RadGrid ID="grd_eStore_DisplaySettings" runat="server" GridLines="None"
                                            BorderWidth="0" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="false"
                                            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" PageSize="10" GroupingEnabled="false"
                                            ShowGroupPanel="false" ShowStatusBar="true" Width="50%" OnItemDataBound="grd_eStore_DisplaySettings_ItemDataBound">
                                            <%--ClientSettings-AllowRowsDragDrop="true"--%>
                                            <HeaderStyle Font-Bold="true" />
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false" />
                                            <MasterTableView AutoGenerateColumns="False" HorizontalAlign="NotSet" OverrideDataSourceControlSorting="true"
                                                DataKeyNames="FieldName,Mandatory,Display" Width="100%">
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" UniqueName="FieldName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderTitle" runat="server" Text='<%#Eval("FieldName") %>' Width="100%"></asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        UniqueName="ScreenName" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtScreenName" autocomplete="off" Width="200px" runat="server" Text='<%#Eval("ScreenName") %>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        UniqueName="Mandatory" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkIsMandatory" runat="server" Checked='<%#Eval("Mandatory") %>' />
                                                            <asp:HiddenField ID="hdnIsMandatory" runat="server" Value='<%#Eval("Mandatory") %>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="2%" ItemStyle-Width="2%" UniqueName="Display" HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkIsDisplay" runat="server" onchange="Order_Displaycheck()" Checked='<%#Eval("Display") %>' />
                                                            <asp:HiddenField ID="hdnIsDisplay" runat="server" Value='<%#Eval("Display") %>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                            <%--  <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                <ClientEvents />
                                            </ClientSettings>--%>
                                        </telerik:RadGrid>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div id="ShowAddressInformation" runat="server">
                                <div style="margin-top: 20px;">
                                    <div class="bglabel" style="width: 17%; margin-bottom: 5px;">
                                        <asp:Label ID="Label3" runat="server" CssClass="normaltext">Step 2: <%=objLanguage.GetLanguageConversion("Show_Address_Information")%></asp:Label>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="Chk_EnableAddress" onchange="Check_ShowAddressInfo()" runat="server" />
                                    </div>
                                </div>
                                <div style="float: left; width: 100%; padding-bottom: 10px;">
                                    <table id="tbl_address" style="width: 50%; border-top: 1px;" cellpadding="0" cellspacing="0">
                                        <tr style="height: 28px;">
                                            <th scope="col" class="rg_Header" style="font-weight: bold; text-align: left;">
                                                <asp:Label ID="lblFieldName" runat="server"><%=objLanguage.GetLanguageConversion("Field_Name")%></asp:Label>
                                            </th>
                                            <th scope="col" class="rg_Header" style="font-weight: bold; text-align: center;">
                                                <asp:Label ID="lblMandatory" runat="server"><%=objLanguage.GetLanguageConversion("Mandatory")%></asp:Label>
                                            </th>
                                            <th scope="col" class="rg_Header" style="font-weight: bold; text-align: center;">
                                                <asp:Label ID="lblDisplay" runat="server"><%=objLanguage.GetLanguageConversion("Display")%></asp:Label>
                                            </th>
                                        </tr>
                                        <tr style="height: 30px;">
                                            <td style="padding-left: 7px;">
                                                <asp:Label ID="lblDelAddress" runat="server"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="Chk_Mandotory_Del" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="Chk_Display_Del" onchange="Check_ToShowDel_InvAddress()" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="background: #f2f2f2; height: 30px;">
                                            <td style="padding-left: 7px;">
                                                <asp:Label ID="lbl_InvAddress" runat="server"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="chk_Mandotory_Inv" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="Chk_Display_Inv" onchange="Check_ToShowDel_InvAddress()" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div style="padding-top: 10px; padding-right: 10px">
                                <div id="div_btnUpdate" style="display: block">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update" OnClientClick="javascript:return validate_Account();"
                                        OnClick="btnUpdate_Click" />
                                </div>
                                <div id="div_btnUpdateprocess" style="display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 2px;" class="loadingimg"
                                        alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <script type="text/javascript" language="javascript">
        function Show_accountListDiv() {
            showDivPopupCenter('div_accountsList', '200');
          
        }    
    </script>--%>
    <script type="text/javascript" language="javascript">

        var txtScreenName1 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl04_txtScreenName');
        var txtScreenName2 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl06_txtScreenName');
        var txtScreenName3 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl08_txtScreenName');
        var txtScreenName4 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl10_txtScreenName');

        var Mandatory1 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl04_chkIsMandatory');
        var Mandatory2 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl06_chkIsMandatory');
        var Mandatory3 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl08_chkIsMandatory');
        var Mandatory4 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl10_chkIsMandatory');

        var Dispaly1 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl04_chkIsDisplay');
        var Dispaly2 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl06_chkIsDisplay');
        var Dispaly3 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl08_chkIsDisplay');
        var Dispaly4 = document.getElementById('ctl00_ContentPlaceHolder1_grd_eStore_DisplaySettings_ctl00_ctl10_chkIsDisplay');

        var chk_EnableOrder = document.getElementById('ctl00_ContentPlaceHolder1_chk_EnableOrder');

        var Show_Address_Information = document.getElementById('ctl00_ContentPlaceHolder1_Chk_EnableAddress');

        var Is_DelAddress_Mand = document.getElementById('ctl00_ContentPlaceHolder1_Chk_Mandotory_Del');
        var Is_InvAddress_Mand = document.getElementById('ctl00_ContentPlaceHolder1_chk_Mandotory_Inv');
        var Is_DelAddress_Disp = document.getElementById('ctl00_ContentPlaceHolder1_Chk_Display_Del')
        var Is_InvAddress_Disp = document.getElementById('ctl00_ContentPlaceHolder1_Chk_Display_Inv')



        function Show_EnableOrder() {
            if (chk_EnableOrder.checked) {
                txtScreenName1.disabled = false;
                txtScreenName2.disabled = false;
                txtScreenName3.disabled = false;
                txtScreenName4.disabled = false;

                Mandatory1.disabled = false;
                Mandatory2.disabled = false;
                Mandatory3.disabled = false;
                Mandatory4.disabled = false;

                Dispaly1.disabled = false;
                Dispaly2.disabled = false;
                Dispaly3.disabled = false;
                Dispaly4.disabled = false;

                if (Dispaly1.checked == false && Dispaly2.checked == false && Dispaly3.checked == false && Dispaly4.checked == false) {

                    Dispaly1.checked = true;
                }

            }
            else {
                txtScreenName1.disabled = true;
                txtScreenName2.disabled = true;
                txtScreenName3.disabled = true;
                txtScreenName4.disabled = true;

                Mandatory1.disabled = true;
                Mandatory2.disabled = true;
                Mandatory3.disabled = true;
                Mandatory4.disabled = true;

                Dispaly1.disabled = true;
                Dispaly2.disabled = true;
                Dispaly3.disabled = true;
                Dispaly4.disabled = true;
            }

        }

        function Order_Displaycheck() {

            if (Dispaly1.checked == false && Dispaly2.checked == false && Dispaly3.checked == false && Dispaly4.checked == false) {
                chk_EnableOrder.checked = false;
                Show_EnableOrder();
            }
        }

        function Check_ShowAddressInfo() {
            if (Show_Address_Information.checked) {
                //Is_DelAddress_Mand.disabled = false;
                //Is_InvAddress_Mand.disabled = false;
                Is_DelAddress_Disp.disabled = false;
                Is_InvAddress_Disp.disabled = false;
                Is_DelAddress_Disp.checked = true;

                if (Is_DelAddress_Disp.checked == false && Is_InvAddress_Disp.checked == false) {
                    Is_DelAddress_Disp.checked = true;
                }
            }
            else {
                //Is_DelAddress_Mand.disabled = true;
                //Is_InvAddress_Mand.disabled = true;
                Is_DelAddress_Disp.disabled = true;
                Is_InvAddress_Disp.disabled = true;
            }

        }

        function Check_ToShowDel_InvAddress() {
            if (Is_DelAddress_Disp.checked == false && Is_InvAddress_Disp.checked == false) {
                Show_Address_Information.checked = false;
                Check_ShowAddressInfo();
            }
            else {
                if (Is_DelAddress_Disp.checked == true && Is_InvAddress_Disp.checked == true)
                    Show_Address_Information.checked = true;
            }
        }

        if (chk_EnableOrder.checked == false) {
            txtScreenName1.disabled = true;
            txtScreenName2.disabled = true;
            txtScreenName3.disabled = true;
            txtScreenName4.disabled = true;

            Mandatory1.disabled = true;
            Mandatory2.disabled = true;
            Mandatory3.disabled = true;
            Mandatory4.disabled = true;

            Dispaly1.disabled = true;
            Dispaly2.disabled = true;
            Dispaly3.disabled = true;
            Dispaly4.disabled = true;
        }


        if (Show_Address_Information.checked == false) {

            Is_DelAddress_Disp.disabled = true;
            Is_InvAddress_Disp.disabled = true;
        }

    </script>
    <style>
        .rg_Header
        {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
            color: #333;
            background: #eaeaea 0 -2300px repeat-x url('WebResource.axd?d=FhO7sHU2X59IGv3nsa9YgwI1i6Oo4Q1133FcFdiRsP9gSi2c5Wc6KvEeb-oPVaq293Vb7bqMFL9ShBpEala14w2&t=634343108725108722');
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
            padding-left: 7px;
            padding-right: 7px;
            cursor: default;
        }
    </style>
</asp:Content>

