<%@ Page Language="C#" AutoEventWireup="true" Title="Stock Scanning" CodeBehind="StockScanning.aspx.cs" Inherits="ePrint.settings.StockScanning" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" MasterPageFile="~/Templates/settingpage.master" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .Header {
            background-image: url(../images/header_bg.png);
            background-repeat: repeat-x;
            height: 26px;
            font-family: Verdana,Arial,Helvetica,sans-serif;
            font-size: 10px;
            font-weight: bold;
            color: #454545;
        }

        .divRightsNPrivileges {
            width: 100%;
            margin-top: 5px;
            padding-bottom: 5px;
            background-color: #EFEFEF;
        }

        .Body {
            background-color: #FCFCFC;
            font-family: Verdana,Arial,Helvetica,sans-serif;
        }
    </style>

    <div style="padding-bottom: 40px;" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel">
            <div style="width: 60%">
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <fieldset>
                <legend>Stock Scanning Options
                </legend>

                <%--  <table class="Body" style="margin-top: 4px" width="900px">--%>

                <%--  <tr>--%>

                <%-- <td>
                            <div style="float: left; margin: 3px 0px 0px 10px;">
                                <label>Job Complete</label>
                                <asp:DropDownList CssClass="textboxnew" ID="DropDownList1" Style="margin-left: 30px;"
                                    runat="server">
                                </asp:DropDownList>
                            </div>

                        </td>--%>
                <div align="left">
                    <div class="bglabel" style="width: 200px;">
                        <asp:Label ID="Label4" runat="server" Text="Default Print Sheet Size" CssClass="normaltext">Job Complete</asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 3px">
                        <asp:DropDownList ID="ddlJobComplete" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                            Width="183px" TabIndex="14">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <%--  <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>--%>
                    </div>
                </div>
                <%--</tr>--%>

                <%--  <tr>--%>

                <div align="left">
                    <div class="bglabel" style="width: 200px;">
                        <asp:Label ID="Label1" runat="server" Text="Default Print Sheet Size" CssClass="normaltext">Job Partial</asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 3px">
                        <asp:DropDownList ID="ddlJobPartial" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                            Width="183px" TabIndex="14">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <%-- <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>--%>
                    </div>
                </div>
                <%--  </tr>

                     <tr>--%>

                <%-- <td>
                            <div style="float: left; margin: 3px 0px 0px 10px;">
                                <label>Job Complete</label>
                                <asp:DropDownList CssClass="textboxnew" ID="DropDownList1" Style="margin-left: 30px;"
                                    runat="server">
                                </asp:DropDownList>
                            </div>

                        </td>--%>
                 <%--</tr>--%>

                <%--  <tr>--%>

                <div align="left">
                    <div class="bglabel" style="width: 200px;">
                        <asp:Label ID="Label6" runat="server" Text="Default Print Sheet Size" CssClass="normaltext">Partial Item Status</asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 3px">
                        <asp:DropDownList ID="ddlPartialItem" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                            Width="183px" TabIndex="14">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <%-- <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>--%>
                    </div>
                </div>
                <%--  </tr>

                     <tr>--%>

                <%-- <td>
                            <div style="float: left; margin: 3px 0px 0px 10px;">
                                <label>Job Complete</label>
                                <asp:DropDownList CssClass="textboxnew" ID="DropDownList1" Style="margin-left: 30px;"
                                    runat="server">
                                </asp:DropDownList>
                            </div>

                        </td>--%>
                <div align="left">
                    <div class="bglabel" style="width: 200px;">
                        <asp:Label ID="Label2" runat="server" Text="Default Print Sheet Size" CssClass="normaltext">PO complete</asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 3px">
                        <asp:DropDownList ID="ddlPOComplete" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                            Width="183px" TabIndex="14">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <%--  <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>--%>
                    </div>
                </div>
                <%--   </tr>

                    <tr>--%>

                <div align="left">
                    <div class="bglabel" style="width: 200px;">
                        <asp:Label ID="Label3" runat="server" Text="Default Print Sheet Size" CssClass="normaltext">PO partial</asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 3px">
                        <asp:DropDownList ID="ddlPOPartial" runat="server" CssClass="normalText" onchange="CallonChange(this.value,'spn_ddlPrintSheetSize')"
                            Width="183px" TabIndex="14">
                        </asp:DropDownList>
                        <div style="clear: both">
                        </div>
                        <%-- <div id="spn_ddlPrintSheetSize" style="display: none; width: auto; float: left">
                                                <div>
                                                    <span style="float: left; padding-left: 4px; width: auto; padding-right: 4px;" class="spanerrorMsg">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_Print_Sheet_Size")%>
                                                    </span>
                                                </div>
                                            </div>--%>
                    </div>
                </div>
               
                  

               
            </fieldset>
            <fieldset><legend>Stock release and replenishment </legend>
                 <div align="left">
                    <div class="bglabel" style="height: 19px">
                        Upload scan file(stock release)
                        <span style="color: Red; padding-left: 4px"></span>
                    </div>
                    <div class="box" style="width: 70%;">
                        <asp:FileUpload ID="fileDeductStock" runat="server" CssClass="textboxnew" />

                        <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="openFileConverter();return false;"
                            Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnDeductImport" runat="server" Text="Import" OnClick="btnDeductImport_Click"></telerik:RadButton>
                    </div>

                </div>

                <div align="left" >
                    <div class="bglabel" style="height: 19px">
                        Upload scan file(stock replenishment)
                        <span style="color: Red; padding-left: 4px"></span>
                    </div>
                    <div class="box" style="width: 70%;">
                        <asp:FileUpload ID="fileReplineshStock" runat="server" CssClass="textboxnew" />

                        <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                        <asp:LinkButton ID="lnkFileConverter" runat="server" OnClientClick="openFileConverter();return false;"
                            Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnReplineshImport" runat="server" Text="Import" OnClick="btnReplineshImport_Click"></telerik:RadButton>
                    </div>
                </div>
            </fieldset>



                       
            <fieldset><legend>Stock Update </legend>
                 <div align="left">
                    <div class="bglabel" style="height: 19px">
                        Upload scan file(stock update)
                        <span style="color: Red; padding-left: 4px"></span>
                    </div>
                    <div class="box" style="width: 70%;">
                        <asp:FileUpload ID="fileStockAdd" runat="server" CssClass="textboxnew" />

                        <%--<img src="../images/account.gif" onclick="javascript:open();"/>--%>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="openFileConverter();return false;"
                            Text="File Converter" Style="text-decoration: underline; margin-left: 3px;" Visible="false"></asp:LinkButton>
                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCSVFile" runat="server" Text="Import" OnClick="btnCSVFile_Click"></telerik:RadButton>
                    </div>

                </div>

                
            </fieldset>

            <div style="float: right; display: inline; width: 21%; padding-top: 10px; margin-right: 28%">
                <div style="display: inline; float: left">
                    <div id="div_btncancel" style="display: block">
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClientClick="loadingimage(this.id,'div_cancelprocess')"
                            CssClass="button" />
                    </div>
                    <div id="div_cancelprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="display: inline; float: left">
                    <asp:Label ID="Label5" Width="8px" runat="server" Style="visibility: hidden">spc</asp:Label>
                </div>
                <div style="display: inline; float: left">
                    <asp:Button ID="btn_Save" runat="server" OnClientClick="javascript:return validate();" Text="Save" CssClass="button" OnClick="btn_Save_Click" />
                </div>
            </div>
        </div>
       <br />
        <fieldset >
             <legend><asp:Label ID="lblImportHistory" runat="server" Style="color: #7d7d7d; font-weight: bold; font-size: 14px; margin-left: 9px;"><%=objLanguage.GetLanguageConversion("Import_History")%></asp:Label>
                </legend>
            <div style="margin-top: 20px;">
               
                <div style="margin-left: 3px;">
                    <telerik:RadGrid ID="grdImportHistory" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0" PageSize="50" AllowAutomaticInserts="false" AllowAutomaticUpdates="false"
                        AllowPaging="True" Width="50%" PagerStyle-AlwaysVisible="true" GroupingEnabled="False"
                        AllowSorting="True" ShowGroupPanel="True" GridLines="None" 
                        OnItemDataBound="grdImportHistory_ItemDataBound">
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <MasterTableView DataKeyNames="ID" ToolTip="" CommandItemDisplay="Top" AllowFilteringByColumn="true" AllowCustomSorting="true">
                            <CommandItemTemplate>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" AutoPostBackOnFilter="true" DataField="File Name">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <HeaderTemplate>
                                        <div style="height: 15px; width: 100%;">
                                            <asp:Label ID="lblFileName" runat="server">File Name</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; width: 100%;">

                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FileName")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Job/PO Code" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <HeaderTemplate>
                                        <div style="height: 15px; width: 100%;">
                                            <asp:Label ID="lblFileName" runat="server">Job/PO Code</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; width: 100%;">

                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("JobOrPoCode")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Item Code" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <HeaderTemplate>
                                        <div style="height: 15px; width: 100%;">
                                            <asp:Label ID="lblFileName" runat="server">Item Code</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; width: 100%;">

                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Qty" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <HeaderTemplate>
                                        <div style="height: 15px; width: 100%;">
                                            <asp:Label ID="lblFileName" runat="server">Qty</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; width: 100%;">

                                            <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("Qty")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Import Date" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <div style="height: 15px;">
                                            <asp:Label ID="lblDateImported" runat="server">Import Date</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px;">
                                            <asp:Label ID="lblItemDateImported" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Date", "{0}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Status" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <div style="height: 15px;">
                                            <asp:Label ID="lblStatus" runat="server"><%=objLanguage.GetLanguageConversion("Status")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px;">
                                            <asp:Label ID="lblItemStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-Height="20px" ItemStyle-Wrap="false" ItemStyle-Width="5%"
                                    AllowFiltering="true" CurrentFilterFunction="Contains"
                                                DataField="Message" AutoPostBackOnFilter="true">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                    <HeaderStyle Font-Bold="true" />
                                    <HeaderTemplate>
                                        <div style="height: 15px; width: 100%">
                                            <asp:Label ID="lblComments" runat="server">Message</asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; width: 100%;">
                                            <asp:Label ID="lblItemComments" runat="server" Text='<%#Eval("ErrorMessage")%>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" Wrap="False" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerStyle AlwaysVisible="True" />
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </fieldset>
    </div>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
