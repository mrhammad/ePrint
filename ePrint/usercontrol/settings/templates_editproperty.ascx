<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="templates_editproperty.ascx.cs" Inherits="ePrint.usercontrol.settings.templates_editproperty" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="<%=strSitepath %>js/item/general.js"></script>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript">
    var path = "<%=sitepath %>";
    var div_Load = document.getElementById("div_Load");
    setLoadingPositionOfDivMove(div_Load);
</script>
<%--<telerik:RadScriptManager ID="ScriptManager2" runat="server">
</telerik:RadScriptManager>--%>
<div align="left" style="width: 100%;display:none" id="main" runat="server">
    <div style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel" runat="server" id="spnheader">Templates Property Edit</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="content">
        <div class="borderWithoutTop">
            <div style="width: 100%;">
                <div id="padding">
                    <div align="left" style="width: 100%">
                        <div style="width: 60%">
                            <asp:UpdatePanel ID="UPMessage" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 100%;" align="left">
                        <div id="div_topbtns" runat="server" style="float: left; width: 100%; display: block">
                            <div id="div_topbtnspace" style="float: left; width: 79%">
                                &nbsp;</div>
                            <div id="div_btncanl" style="float: left; display: none">
                                <asp:Button ID="btnTopCancel" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                    runat="server" OnClientClick="CallCancel();" />
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;</div>
                            <div style="float: left; padding-right: 10px">
                                <asp:Button ID="btnTopClose" Text="Cancel" CssClass="button" 
                                    OnClientClick="javascript:self.close();" runat="server" />
                            </div>
                            <div style="float: left;">
                                <asp:Button ID="btnTopSave" Text="Save & Close" CssClass="button" OnClick="btnUpdate_OnClick"
                                    OnClientClick="javascript:return Validation('save');" runat="server" />
                            </div>
                            <div style="float: left; display: none">
                                <div style="float: left; width: 10px">
                                    &nbsp;</div>
                                <asp:Button ID="btnTopUpdate" Text="Save & Stay" CssClass="button" OnClick="btnUpdate_OnClick"
                                    OnClientClick="javascript:return Validation('stay');" runat="server" />
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                        <div id="div_Grid" style="padding-left: 10px; padding-right: 10px;">
                            <telerik:RadGrid Width="100%" ID="GridTemplateProperties" GridLines="None" runat="server"
                                 PageSize="50" AllowAutomaticDeletes="True"
                                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" AllowPaging="false"
                                AllowSorting="true" AutoGenerateColumns="False" AllowFilteringByColumn="false"
                                HeaderStyle-Font-Bold="true" CellPadding="0" OnItemDataBound="GridTemplateProperties_OnItemDataBound">
                                <MasterTableView Width="100%" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                                    DataKeyNames="TemplatePropertiesID" PagerStyle-AlwaysVisible="true" OverrideDataSourceControlSorting="true">
                                    <%--<CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 80%;">
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                        cursor: pointer" runat="server" Visible="false" Text="Clear all Filters" />
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>--%>
                                    <%-- <EditItemStyle></EditItemStyle>--%>
                                    <Columns>
                                        <%--<telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="objTag"
                                            HeaderText="Tag" HeaderStyle-Width="15%" ItemStyle-Width="15%" UniqueName="objTag"
                                            Visible="true" HeaderStyle-HorizontalAlign="Left" DataField="objTag">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <%#Eval("objTag")%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="objName"
                                            HeaderText="" DataField="objName" HeaderStyle-Width="18%" ItemStyle-Width="18%"
                                            UniqueName="objName" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Wrap="false" />
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label1" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Title")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdn_TemplatePropertiesID" runat="server" Value='<%#Eval("TemplatePropertiesID") %>' />
                                                <%--<div style="float: left; width: 99%; overflow: hidden; height: 15px; max-width: 99%">--%>
                                                <asp:Label ID="lbl_title" runat="server"><%#Eval("objValue")%></asp:Label>
                                                <asp:HiddenField ID="hdn_objTitle" runat="server" Value='<%#Eval("Title")%>' />
                                                <asp:HiddenField ID="hdn_objType" runat="server" Value='<%#Eval("objType") %>' />
                                                <asp:HiddenField ID="hdn_objValue" runat="server" Value='<%#Eval("objValue") %>' />
                                                <%--  </div>--%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="Align"
                                            DataField="Align" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%" UniqueName="Align"
                                            Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label2" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Align") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:HiddenField ID="hdn_Align" runat="server" Value='<%#Eval("textalign") %>' />
                                                    <asp:DropDownList ID="ddl_align" runat="server" Width="60px" CssClass="normalText">
                                                        <asp:ListItem Value="left">Left</asp:ListItem>
                                                        <asp:ListItem Value="right">Right</asp:ListItem>
                                                        <asp:ListItem Value="center">Center</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="Top"
                                            DataField="Top" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%" UniqueName="Top"
                                            Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label3" runat="server"><%#objLanguage.GetLanguageConversion("Top") %></asp:Label></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:TextBox ID="txtTop" runat="server" Text='<%#Eval("Top")%>' SkinID="textPad"
                                                        Width="60px" Style="text-align: right" onblur="javascript:SetNumber(this,this.value)"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="Left"
                                            DataField="Left" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%" UniqueName="Left"
                                            Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label4" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Left") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:TextBox ID="txtLeft" runat="server" Text='<%#Eval("Left")%>' SkinID="textPad"
                                                        Width="60px" Style="text-align: right" onblur="javascript:SetNumber(this,this.value)"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="Width"
                                            DataField="Width" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%" UniqueName="Width"
                                            Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label5" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Width") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:TextBox ID="txtWidth" runat="server" Text='<%#Eval("Width")%>' SkinID="textPad"
                                                        Width="60px" Style="text-align: right" onblur="javascript:SetNumber(this,this.value)"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="Height"
                                            DataField="Height" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%"
                                            UniqueName="Height" Visible="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label6" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Height")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:TextBox ID="txtHeight" runat="server" Text='<%#Eval("Height")%>' SkinID="textPad"
                                                        Width="60px" Style="text-align: right" onblur="javascript:SetNumber(this,this.value)"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="FontFamily"
                                            DataField="FontFamily" HeaderText="" HeaderStyle-Width="11%" ItemStyle-Width="11%"
                                            UniqueName="FontFamily" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label7" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Font_Family")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 17px">
                                                    <asp:DropDownList ID="ddl_font" runat="server" CssClass="normalText" Width="90px">
                                                        <%--
                                                        <asp:ListItem Value="Arial" Selected="selected" style="font-family: Arial; font-size: 14px;">
                                                            Arial </asp:ListItem>
                                                        <asp:ListItem Value="Abadi Cond ExtraBold" style="font-family: Abadi Cond ExtraBold;
                                                            font-size: 14px;">
                                                            Abadi Cond ExtraBold</asp:ListItem>
                                                        <asp:ListItem Value="Abadi Cond light" style="font-family: Abadi Cond light; font-size: 14px;">
                                                            Abadi Cond light</asp:ListItem>
                                                        <asp:ListItem Value="Calibri" style="font-family: Calibri; font-size: 14px;">Calibri</asp:ListItem>
                                                        <asp:ListItem Value="century-gothic" style="font-family: century gothic; font-size: 14px;">
                                                            Century Gothic</asp:ListItem>
                                                        <asp:ListItem Value="Comic-Sans-Ms" style="font-family: Comic Sans MS; font-size: 14px;">Comic
                                                            Sans MS</asp:ListItem>
                                                        <asp:ListItem Value="Courier-New" style="font-family: Courier New; font-size: 14px;">Courier
                                                            New</asp:ListItem>
                                                        <asp:ListItem Value="Futura Heavy-italic" style="font-family: Futura Heavy-italic;
                                                            font-size: 14px;">
                                                            Futura Heavy-italic</asp:ListItem>
                                                        <asp:ListItem Value="Futura Light-italic" style="font-family: Futura Light-italic;
                                                            font-size: 14px;">
                                                            Futura Light-italic</asp:ListItem>                                                       
                                                        <asp:ListItem Value="Georgia" style="font-family: Georgia; font-size: 14px;">Georgia</asp:ListItem>
                                                        <asp:ListItem Value="Gill Sans" style="font-family: Gill Sans; font-size: 14px;">Gill Sans</asp:ListItem>
                                                        <asp:ListItem Value="Gill Sans Bold" style="font-family: Gill Sans Bold; font-size: 14px;">
                                                            Gill Sans Bold</asp:ListItem>
                                                        <asp:ListItem Value="Gill Sans Light" style="font-family: Gill Sans Light; font-size: 14px;">
                                                            Gill Sans Light</asp:ListItem>
                                                        <asp:ListItem Value="Gotham" style="font-family: Gotham; font-size: 14px;">Gotham </asp:ListItem>
                                                        <asp:ListItem Value="Gotham Book" style="font-family: Gotham Book; font-size: 14px;">Gotham
                                                            Book</asp:ListItem>
                                                        <asp:ListItem Value="Gotham Light" style="font-family: Gotham Light; font-size: 14px;">Gotham
                                                            Light</asp:ListItem>
                                                        <asp:ListItem Value="Gotham Medium" style="font-family: Gotham Medium; font-size: 14px;">Gotham
                                                            Medium</asp:ListItem>
                                                        <asp:ListItem Value="HelveticaNeue Bold" style="font-family: HelveticaNeue Bold;
                                                            font-size: 14px;">
                                                            HelveticaNeue Bold</asp:ListItem>
                                                        <asp:ListItem Value="Helvetica-Neue-light" style="font-family: Helvetica Neue light;
                                                            font-size: 14px;">
                                                            Helvetica Neue light</asp:ListItem>
                                                        <asp:ListItem Value="HelveticaNeue Roman" style="font-family: HelveticaNeue Roman;
                                                            font-size: 14px;">
                                                            HelveticaNeue Roman</asp:ListItem>
                                                        <asp:ListItem Value="Impact" style="font-family: Impact; font-size: 14px;">Impact</asp:ListItem>
                                                        <asp:ListItem Value="ITC Century Book Cond" style="font-family: ITC Century Book Cond;
                                                            font-size: 14px;">ITC Century Book Cond</asp:ListItem>
                                                        <asp:ListItem Value="ITC Century Bold Cond" style="font-family: ITC Century Bold Cond;
                                                            font-size: 14px;">ITC Century Bold Cond</asp:ListItem>
                                                        <asp:ListItem Value="ITC Garamond Bold Cond" style="font-family: ITC Garamond Bold Cond;
                                                            font-size: 14px;">ITC Garamond Bold Cond</asp:ListItem>
                                                        <asp:ListItem Value="ITC Garamond Book Cond" style="font-family: ITC Garamond Book Cond;
                                                            font-size: 14px;">ITC Garamond Book Cond</asp:ListItem>
                                                        <asp:ListItem Value="ITC Garamond Bold-italic" style="font-family: ITC Garamond Bold-italic;
                                                            font-size: 14px;">ITC Garamond Bold-italic</asp:ListItem>
                                                        <asp:ListItem Value="ITC Garamond Book-italic" style="font-family: ITC Garamond Book-italic;
                                                            font-size: 14px;">ITC Garamond Book-italic</asp:ListItem>
                                                        <asp:ListItem Value="News Gothic Bold-italic" style="font-family: News Gothic Bold-italic;
                                                            font-size: 14px;">News Gothic Bold-italic</asp:ListItem>
                                                        <asp:ListItem Value="News Gothic-italic" style="font-family: News Gothic-italic;
                                                            font-size: 14px;">
                                                            News Gothic-italic</asp:ListItem>
                                                        <asp:ListItem Value="Tahoma" style="font-family: Tahoma; font-size: 14px;">Tahoma</asp:ListItem>
                                                        <asp:ListItem Value="Times-New-Roman" style="font-family: Times New Roman; font-size: 14px;">
                                                            Times New Roman</asp:ListItem>
                                                        <asp:ListItem Value="Trebuchet-Ms" style="font-family: Trebuchet Ms; font-size: 14px;">Trebuchet
                                                            Ms</asp:ListItem>
                                                        <asp:ListItem Value="verdana" style="font-family: Verdana; font-size: 14px;">Verdana</asp:ListItem>
                                                        <asp:ListItem Value="Wedding-Text" style="font-family: Wedding Text; font-size: 14px;">Wedding
                                                            Text</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdn_font" runat="server" Value='<%#Eval("FontFamily") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="FontSize"
                                            DataField="FontSize" HeaderText="" HeaderStyle-Width="8%" ItemStyle-Width="8%"
                                            UniqueName="FontSize" Visible="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label8" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Font_Size_pt")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 100%; overflow: hidden; height: 17px">
                                                    <asp:TextBox ID="txtFontSize" runat="server" Text='<%#Eval("FontSize")%>' SkinID="textPad"
                                                        Width="60px" Style="text-align: right" onblur="javascript:SetFontSize(this,this.value)"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="GroupName"
                                            DataField="GroupName" HeaderText="" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            UniqueName="GroupName" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label9" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Vertical_Group") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="normalText" Width="80px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnGroup" runat="server" Value='<%#Eval("GroupID") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="GroupName"
                                            DataField="HGroupName" HeaderText="" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            UniqueName="HGroupName" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label10" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Horizontal_Group")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:DropDownList ID="ddlHGroup" runat="server" CssClass="normalText" Width="80px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnHGroup" runat="server" Value='<%#Eval("HGroupID") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="objValue"
                                            DataField="objValue" HeaderText="" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            UniqueName="objValue" Visible="true" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label11" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Associate_Label")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:DropDownList ID="ddlassociatelbl" runat="server" CssClass="normalText" Width="77px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnAssociatedLabel" runat="server" Value='<%#Eval("AssociatedLabel") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="objValue"
                                            DataField="objValue" HeaderText="" HeaderStyle-Width="7%" ItemStyle-Width="7%"
                                            UniqueName="objValue" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label12" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Is_Group_Name")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden;">
                                                    <input type="checkbox" runat="server" id="chkIsHgroupMain" onclick="CheckHGroupIsMain(this);"
                                                        name="chkIsHgroupMain" value='<%# DataBinder.Eval(Container, "DataItem.HGroupID", "{0}") %>' />
                                                    <asp:HiddenField ID="hdnIsHGroupMain" runat="server" Value='<%#Eval("IsHGroupMain") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" SortExpression="objValue"
                                            DataField="objValue" HeaderText="" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                            UniqueName="objValue" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label13" runat="server"></asp:Label><%#objLanguage.GetLanguageConversion("Lock") %></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden;">
                                                    <input type="checkbox" runat="server" id="chkLock" name="chkLock" value='<%# DataBinder.Eval(Container, "DataItem.Lock", "{0}") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <%-- <ClientSettings>
                                    <Scrolling AllowScroll="True" SaveScrollPosition="true" UseStaticHeaders="True">
                                    </Scrolling>
                                </ClientSettings>--%>
                            </telerik:RadGrid>
                            <asp:ObjectDataSource ID="odsTemplateProperties" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                SelectMethod="settings_templates_properties_select">
                                <SelectParameters>
                                    <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                                    <asp:QueryStringParameter Name="TemplateID" QueryStringField="id" Type="Int64" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <div class="only5px">
                        </div>
                        <div id="div_rightbtns" runat="server" style="float: left; width: 100%">
                            <div id="div_btnspace" style="float: left; width: 79%">
                                &nbsp;</div>
                            <div id="div_btnCancel" style="float: left; display: none">
                                <asp:Button ID="btnCancel" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                    runat="server" OnClientClick="CallCancel();" />
                                <div style="float: left; width: 10px">
                                    &nbsp;</div>
                            </div>
                            <div style="float: left; padding-right: 10px">
                                <asp:Button ID="btnBottomClose" Text="Cancel" CssClass="button" 
                                    OnClientClick="javascript:self.close();" runat="server" />
                            </div>

                            <div style="float: left;">
                                <asp:Button ID="btnSave" Text="Save & Close" CssClass="button" OnClick="btnUpdate_OnClick"
                                    OnClientClick="javascript:return Validation('save');" runat="server" />
                            </div>
                            <div style="float: left; display: none">
                                <div style="float: left; width: 10px">
                                    &nbsp;</div>
                                <asp:Button ID="btnUpdate" Text="Save & Stay" CssClass="button" OnClick="btnUpdate_OnClick"
                                    OnClientClick="javascript:return Validation('stay');" runat="server" />
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField runat="server" ID="hdnID" Value="0" />
<asp:HiddenField runat="server" ID="hdn_PropertySaveType" Value="" />
<asp:LinkButton ID="lnkUpdate" runat="server" OnClick="btnUpdate_OnClick"></asp:LinkButton>
<asp:LinkButton ID="lnkParentSave" runat="server" OnClick="lnkParentSave_OnClick"></asp:LinkButton>

<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js"></script>
<script type="text/javascript">
    var pop = '<%=pop %>';
    var TemplID = '<%=id %>';
    var pw = window.parent;
    var hdn_PropertySaveType = document.getElementById("<%=hdn_PropertySaveType.ClientID %>");
    var div_topbtns = document.getElementById("<%=div_topbtns.ClientID %>");
    var div_btnspace = document.getElementById("div_btnspace");
    var div_btnCancel = document.getElementById("div_btnCancel");
    var div_btncanl = document.getElementById("div_btncanl");

    if (pop != "") {
        //        div_topbtnspace.style.display = "none";  
        //        div_btnspace.style.display = "none";
        div_btnCancel.style.display = "none";
        div_btncanl.style.display = "none";
    }
    else {
        //        div_btnspace.style.display = "block";  
        div_btnCancel.style.display = "block";
        div_btncanl.style.display = "block";
    }

    function CallCancel() {
        if (pop != "" && pop == "yes") {
            window.parent.document.getElementById("ds00").style.display = "none";
            window.close();
            return false;
        }
        else {
            return true;
        }
    }

    function SetFontSize(obj, val) {
        if (trim12(val) != '') {
            if (!isNaN(val)) {
                val = val;
                return true;
            }
            else {
                obj.value = '9pt';
                return false;
            }
        }
        else {
            obj.value = '9pt';
            return false;
        }
    }

    var nextwhat = false;
    function Validation(savetype) {
        nextwhat = true;
        var GridTemplate = document.getElementById("<%=GridTemplateProperties.ClientID %>");
        var check = GridTemplate.getElementsByTagName("checktop");
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'text' && e.name.indexOf('checktop') != -1) {
                if (isNaN(e.value) || e.value == '') {
                    e.focus();
                    nextwhat = false;
                    break;
                }
            }

            else if (e.type == 'text' && e.name.indexOf('checkLeft') != -1) {
                if (isNaN(e.value) || e.value == '') {
                    e.focus();
                    nextwhat = false;
                    break;
                }
            }

            else if (e.type == 'text' && e.name.indexOf('checkwidth') != -1) {
                if (isNaN(e.value) || e.value == '') {
                    e.focus();
                    nextwhat = false;
                    break;
                }
            }

            else if (e.type == 'text' && e.name.indexOf('checkheight') != -1) {
                if (isNaN(e.value) || e.value == '') {
                    e.focus();
                    nextwhat = false;
                    break;
                }
            }

            else if (e.type == 'text' && e.name.indexOf('checkfontsize') != -1) {
                if (e.value == '') {
                    e.focus();
                    nextwhat = false;
                    break;
                }
            }
        }

        if (nextwhat) {
            hdn_PropertySaveType.value = savetype;
            return true;
        }
        else {
            alert('Please enter Correct Values');
            return false;
        }
    }

    function CheckHGroupIsMain(chkObj) {
        var frm = document.forms[0];
        var ChkState = chkObj.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('chkIsHgroupMain') != -1 && (e.value == chkObj.value)) {
                if (e.id != chkObj.id) {
                    e.checked = false;
                }
                else {
                    e.checked = e.checked == true ? true : false;
                }
            }
        }
    }


</script>
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script>
        window.parent.document.getElementById("ds00").style.display = "none";
        window.parent.location = "../settings/templates_add.aspx?page=" + '<%=Request.Params["page"].ToString() %>' + "&action=edit&ID=" + TemplID + "";
        window.close();
    </script>
</asp:Panel>
<script>
    document.getElementById("div_Load").style.display = "none";
    function ParentCall() {
        __doPostBack('ctl00$ContentPlaceHolder1$tempeditprop$lnkParentSave', '');
    }
</script>
