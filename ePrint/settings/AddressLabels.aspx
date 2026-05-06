<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="AddressLabels.aspx.cs" Inherits="ePrint.settings.AddressLabels" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style>
    .RadGrid_Default .rgCommandRow 
     {

background:none;

}
.RadGrid_Default .rgCommandRow a {
color: #10357F;
text-decoration: none;

}
.RadGrid_Default .rgCommandCell {
border:none;
margin-top:-8px;

}
.RadGrid_Default .rgHeader {
border: 0;
border-top: 1px solid #828282;
border-bottom: 1px solid #828282;
}
.RadGrid_Default {

 outline:none;
}



    </style>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"></asp:Label><%--<%=colorformat%>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div align="left" style="width: 60%;margin-top:10px;margin-left:10px" >
                    <div>
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <telerik:RadGrid ID="GridAddressLabel" AutoGenerateColumns="false" runat="server" BorderWidth="0"
                            itemstyle-heigh="2%" GridLines="None" PageSize="50" Width="65%" HeaderStyle-Font-Bold="true">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="System Defined" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%"
                                        HeaderStyle-Width="40%">
                                        <HeaderTemplate>
                                            <div>
                                                <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("System_Defined")%></div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnLabelID" runat="server" Value='<%#Eval("LabelID")%>' />
                                            <asp:Label ID="lblAddressLabel" runat="server" Text='<%#Eval("AddressLabel")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="User Defined" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60%"
                                        HeaderStyle-Width="60%">
                                        <HeaderTemplate>
                                            <div>
                                                <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("User_Defined")%></div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAddressValue" runat="server" Text='<%#Eval("AddressValue")%>'
                                                Height="15px" Width="200px" MaxLength="200"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Required" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                                        HeaderStyle-Width="100%">
                                        <HeaderTemplate>
                                            <div>
                                                <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Required")%></div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                           <center> <asp:CheckBox Checked='<%#Eval("isRequired")%>' ID="chkRequired" runat="server" /></center>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting EnableDragToSelectRows="false" />
                            </ClientSettings>
                        </telerik:RadGrid>
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="width: 100%;" align="left">
                        <div id="div_btnupdate" style="display: block;">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_OnClick"
                                OnClientClick="loadingimage(this.id,'div_btnupdateprocess');" class="button">
                            </asp:Button>
                        </div>
                        <div id="div_btnupdateprocess" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="width: 100%; padding-left: 10px;">
                        <asp:Label ID="LblNote" runat="server" Text=" Please log out and log back into the system to ensure this change takes effect"
                            CssClass="smallgraytext"><%=objLanguage.GetLanguageConversion("Please_Log_Out_And_Log_Back_Into_The_System_To_Ensure_This_Change_Takes_Effect")%></asp:Label>
                    </div>
                    <div class="only5px">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
