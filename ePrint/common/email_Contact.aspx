<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email_Contact.aspx.cs" Inherits="ePrint.common.email_Contact" masterpagefile="~/Templates/popUpMasterPage_new.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="Estyle" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgrContact">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgrContact" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <UC:Estyle ID="Estyle4" runat="server" />
    <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="update1">
                    <ContentTemplate>
                        <UC:Estyle ID="Estyle1" runat="server" />
                        <table class="txtBox" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr valign="top">
                                    <td>
                                        <input type="hidden" runat="server" value="Contact" id="hdnTabSelect" />
                                        <img height="5px" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="txtBox" border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top" width="10px">
                                                        <img alt="" class="TabSpacer" src="../images/1t.gif">
                                                    </td>
                                                    <td>
                                                        <div runat="server" style="display: none" class="searchTab selectedSearchTab" id="maindivLead"
                                                            onclick="handleTabRollover('click',this,this.id);" onmouseover="handleTabRollover('over', this,this.id);"
                                                            onmouseout="handleTabRollover('out', this,this.id);">
                                                            <table class="txtBox" border="0" cellpadding="0" cellspacing="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="leftEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                        <td class="tabBody" valign="top">
                                                                            <div class="tabText" id="divLead">
                                                                                <asp:LinkButton OnCommand="LinkButton_Select" CommandArgument="Lead" runat="server"
                                                                                    ID="lnkLead"></asp:LinkButton>
                                                                            </div>
                                                                        </td>
                                                                        <td class="rightEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                        <div runat="server" class="searchTab selectedSearchTab" id="maindivContact" onclick="handleTabRollover('click', this,this.id);"
                                                            onmouseover="handleTabRollover('over', this,this.id);" onmouseout="handleTabRollover('out', this,this.id);"
                                                            style="display: none">
                                                            <table class="txtBox" border="0" cellpadding="0" cellspacing="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="leftEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                        <td class="tabBody">
                                                                            <div class="tabText" id="divContact">
                                                                                <asp:LinkButton OnCommand="LinkButton_Select" CommandArgument="Contact" runat="server"
                                                                                    ID="lnkContact"></asp:LinkButton>
                                                                            </div>
                                                                        </td>
                                                                        <td class="rightEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                        <div runat="server" class="searchTab" style="display: none" id="maindivFriend" onclick="handleTabRollover('click', this,this.id);"
                                                            onmouseover="handleTabRollover('over', this,this.id);" onmouseout="handleTabRollover('out', this,this.id);">
                                                            <table class="txtBox" border="0" cellpadding="0" cellspacing="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="leftEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                        <td class="tabBody">
                                                                            <div class="tabText" id="divFriend">
                                                                                <asp:LinkButton OnCommand="LinkButton_Select" CommandArgument="Friend" runat="server"
                                                                                    ID="lnkSavedAddress"></asp:LinkButton>
                                                                            </div>
                                                                        </td>
                                                                        <td class="rightEdge">
                                                                            <img src="../images/invis.gif" alt="" height="100%" width="10">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                    <td width="50%">
                                                        <table class="txtBox" width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Panel ID="pnlLead" runat="server" Visible="false">
                    <table id="Table1" border="0" runat="server" class="Panel-C" cellpadding="0" cellspacing="0"
                        width="100%">
                        <tr>
                            <td height="100px">
                                <table cellspacing="0" class="txtBox" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <table width="100%" border="0" cellpadding="2" cellspacing="2" align="center">
                                                <asp:Panel ID="pnlnoofrecordsperpage" runat="server">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" align="center">
                                                                <tr>
                                                                    <td align="center" height="15">
                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <table cellspacing="3" cellpadding="0" width="0" align="left" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:PlaceHolder ID="plhAlphabeatLead" runat="server"></asp:PlaceHolder>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table border="0" class="txtBox" cellspacing="0" cellpadding="4" width="100%" align="center">
                                                                        <tr>
                                                                            <td width="30%" nowrap="nowrap">
                                                                                <asp:TextBox MaxLength="100" ID="keywordsearch" CssClass="txtBox" Width="200px" runat="server"></asp:TextBox>
                                                                                &nbsp;
                                                                                <asp:Button ID="btngolead" runat="server" OnClientClick="CheckTime();" CausesValidation="false"
                                                                                    OnClick="btngolead_OnClick" CssClass="button" Text="Go" />
                                                                            </td>
                                                                            <td width="50%" nowrap="nowrap">
                                                                                <asp:Label ID="lblCounterLead" CssClass="error_yello" Text="" Visible="false" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right" class="normaltext" nowrap="nowrap" style="width: 30%">
                                                                                <asp:Panel ID="ddlNoOfRecord_Lead" runat="server">
                                                                                    <asp:Label ID="lblshow" runat="server"><% =objLanguage.convert("Show")%></asp:Label>&nbsp;
                                                                                    <asp:DropDownList ID="ddlnoofrecordsperpage" runat="server" AutoPostBack="True" CssClass="normaltext"
                                                                                        OnSelectedIndexChanged="ddlnoofrecordsperpage_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblrecordsperpage" runat="server"><%=objLanguage.convert("Records")%></asp:Label>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table border="0" cellpadding="5" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblletter" Text="" Visible="false" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblLeadSection" Visible="false" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="4" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="dgrLead" runat="server" DataKeyNames="LeadID" AutoGenerateColumns="False"
                                                                                AllowPaging="True" AllowSorting="True" ShowHeader="true" DataSourceID="SqlDataSourceLead"
                                                                                GridLines="none" OnDataBound="dgrLead_DataBound" OnRowDataBound="dgrLead_RowDataBound"
                                                                                OnPageIndexChanging="dgrLead_PageIndexChanging">
                                                                                <HeaderStyle CssClass="bgcustomize navigatorpanel" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Campaign" HeaderStyle-Width="2%">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <input type="checkbox" runat="server" id="leadId" onclick="CheckChanged();" name="leadId"
                                                                                                value='<%# DataBinder.Eval(Container, "DataItem.email", "{0}") %>' />
                                                                                            <asp:Label ID="lblLead" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.LeadID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="20%" SortExpression="email">
                                                                                        <ItemTemplate>
                                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "email") %>'>
                                                                                            </asp:HyperLink>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Name" DataField="name" HeaderStyle-Width="20%" SortExpression="name">
                                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="Company Name" DataField="companyname" HeaderStyle-Width="20%"
                                                                                        SortExpression="companyname">
                                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="Phone" DataField="phone" HeaderStyle-Width="20%" SortExpression="phone">
                                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" style="height: 25px">
                                                                                        <tr>
                                                                                            <td class="middleText" align="center">
                                                                                                <%=objLanguage.convert("No Records Available ! ")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                                <PagerTemplate>
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <hr size="1" style="color: Gray" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="normaltext" align="right">
                                                                                                <asp:Label ID="lblpage" runat="server" CssClass="normaltext"><%=objLanguage.convert("Page")%></asp:Label>&nbsp;
                                                                                                <asp:DropDownList ID="ddlpageno" runat="server" CssClass="normaltext" AutoPostBack="true"
                                                                                                    OnSelectedIndexChanged="ddlpageno_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                &nbsp;
                                                                                                <asp:Label ID="lblof" runat="server"><%=objLanguage.convert("of")%></asp:Label>&nbsp;
                                                                                                <asp:Label ID="lblpagenoLead" runat="server" CssClass="normaltext"></asp:Label>&nbsp;
                                                                                                <asp:ImageButton ID="lbtnFirst" runat="server" CommandName="Page" CommandArgument="First"
                                                                                                    ImageUrl="~/images/icn_firstrecord.gif" ToolTip="First"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnPrev" runat="server" CommandName="Page" CommandArgument="Prev"
                                                                                                    ImageUrl="~/images/icn_previous_record.gif" ToolTip="Previous"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnNext" runat="server" CommandName="Page" CommandArgument="Next"
                                                                                                    ImageUrl="~/images/icn_next_record.gif" ToolTip="Next"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnLast" runat="server" CommandName="Page" CommandArgument="Last"
                                                                                                    ImageUrl="~/images/icn_last_record.gif" ToolTip="Last"></asp:ImageButton>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </PagerTemplate>
                                                                                <PagerStyle CssClass="normaltext" />
                                                                                <PagerSettings Position="Bottom" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:SqlDataSource ID="SqlDataSourceLead" runat="server" SelectCommand="sp_Select_Lead_Email"
                                                            SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="CompanyID" SessionField="companyID" Type="Int32" />
                                                                <asp:SessionParameter Name="UserID" SessionField="userid" Type="Int32" />
                                                                <asp:ControlParameter ControlID="lblletter" Name="Para" DefaultValue=" " PropertyName="Text"
                                                                    Type="String" Direction="Input" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlContact" runat="server">
                    <UC:Estyle ID="Estyle3" runat="server" />
                    <table border="0" runat="server" id="Contact" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE2">
                                    <tr>
                                        <td align="center">
                                            <table width="98%" border="0" cellpadding="0" cellspacing="0" align="center">
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:UpdatePanel ID="UPContact" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table border="0" cellpadding="5" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblletterContact" Text="" Visible="false" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblContactSection" Visible="false" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <div id="divmore1" style="height: 15px;">
                                                                    <div style="float: left;">
                                                                        <asp:Panel runat="server" ID="tableMoreAction">
                                                                            <asp:DropDownList Width="200px" ID="ddlLeadMoreAction" runat="server">
                                                                                <asp:ListItem Text="---------More Action-------" style="color: #cacaca" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="Add to Recipient" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Add to Bcc" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="Add to CC" Value="3"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </asp:Panel>
                                                                    </div>
                                                                    <div id="divbtnGo" style="display: none; float: left; margin-left: 4px;">
                                                                        <asp:Button Width="40px" CssClass="button" ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"
                                                                            OnClientClick="javascript:return CheckOne();" />
                                                                    </div>
                                                                </div>
                                                                <div style="height: 15px;">
                                                                    <div style="float: right; padding-right: 7px;">
                                                                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                                            cursor: pointer" runat="server" Text="Clear all Filters" />
                                                                    </div>
                                                                </div>
                                                                <telerik:RadGrid ID="dgrContact" Width="99%" runat="server" AllowAutomaticDeletes="True"
                                                                    PagerStyle-AlwaysVisible="true" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                                                    FilterItemStyle-Wrap="true" DataSourceID="SqlDataSourceContact" OnNeedDataSource="dgrContact_OnNeedDataSource"
                                                                    PageSize="50" AllowPaging="True" OnItemDataBound="dgrContact_RowDataBound" AutoGenerateColumns="False"
                                                                    AllowFilteringByColumn="true" HeaderStyle-Font-Bold="true" ItemStyle-Height="15px">
                                                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                                                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="contactId" DataSourceID="SqlDataSourceContact">
                                                                        <Columns>
                                                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-Wrap="true">
                                                                                <HeaderStyle Width="6%" HorizontalAlign="left"></HeaderStyle>
                                                                                <ItemStyle Width="6%" HorizontalAlign="left" Height="5%" />
                                                                                <HeaderTemplate>
                                                                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <input type="checkbox" runat="server" id="contactId" onclick="CheckChanged();" name="contactId"
                                                                                        value='<%# DataBinder.Eval(Container, "DataItem.email", "{0}") %>' />
                                                                                    <asp:Label ID="lblContact" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.ContactID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn SortExpression="email" DataField="email" HeaderText="Email"
                                                                                ItemStyle-Wrap="true" UniqueName="email" AllowFiltering="true" FilterControlWidth="80">
                                                                                <HeaderStyle Width="20%" HorizontalAlign="left"></HeaderStyle>
                                                                                <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEmail" runat="server" CssClass="normalText" Text='<%# DataBinder.Eval(Container.DataItem, "email") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridBoundColumn UniqueName="name" SortExpression="name" HeaderText="Name"
                                                                                DataField="name" AllowFiltering="true" FilterControlWidth="80">
                                                                                <HeaderStyle Width="18%" HorizontalAlign="left"></HeaderStyle>
                                                                                <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn UniqueName="clientname" SortExpression="clientname" HeaderText="Client Name"
                                                                                DataField="clientname" AllowFiltering="false" FilterControlWidth="80">
                                                                                <HeaderStyle Width="18%" HorizontalAlign="left"></HeaderStyle>
                                                                                <ItemStyle Width="18%" HorizontalAlign="left" />
                                                                            </telerik:GridBoundColumn>
                                                                            <telerik:GridBoundColumn UniqueName="mobile" SortExpression="mobile" HeaderText="Mobile"
                                                                                DataField="mobile" AllowFiltering="true" FilterControlWidth="80">
                                                                                <HeaderStyle Width="20%" HorizontalAlign="left"></HeaderStyle>
                                                                                <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                            </telerik:GridBoundColumn>
                                                                        </Columns>
                                                                    </MasterTableView>
                                                                    <ClientSettings Scrolling-AllowScroll="true">
                                                                        <Scrolling AllowScroll="true" ScrollHeight="250" UseStaticHeaders="true" />
                                                                    </ClientSettings>
                                                                </telerik:RadGrid>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:SqlDataSource ID="SqlDataSourceContact" runat="server" SelectCommand="sp_select_client_contact_email_new"
                                                            SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                            <%--sp_Select_Contact_Email--%>
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="CompanyID" SessionField="companyID" Type="Int32" />
                                                                <asp:QueryStringParameter QueryStringField="sectionid" Name="UserID" Type="Int32" />
                                                                <asp:ControlParameter ControlID="lblletterContact" Name="Para" DefaultValue=" " PropertyName="Text"
                                                                    Type="String" Direction="Input" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlFriend" runat="server" Visible="false">
                    <UC:Estyle ID="Estyle2" runat="server" />
                    <table border="0" runat="server" id="Friend" class="Panel-C" cellpadding="0" cellspacing="0"
                        width="100%">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="dsff">
                                    <tr>
                                        <td align="center">
                                            <table width="98%" border="0" cellpadding="2" cellspacing="2" align="center">
                                                <asp:Panel ID="pnlnoofrecordsperpageFriend" runat="server">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" align="center">
                                                                <tr>
                                                                    <td align="center" height="15">
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                            <ContentTemplate>
                                                                                <table cellspacing="3" cellpadding="0" width="0" align="left" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:PlaceHolder ID="plhAlphabeatFriend" runat="server"></asp:PlaceHolder>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanelFriend" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" align="center">
                                                                        <tr>
                                                                            <td width="30%" nowrap="nowrap">
                                                                                <asp:TextBox MaxLength="100" ID="keywordsearchFriend" CssClass="txtBox" Width="200px"
                                                                                    runat="server"></asp:TextBox>
                                                                                &nbsp;
                                                                                <asp:Button ID="btngofriend" runat="server" Text="Go" OnClientClick="CheckTime()"
                                                                                    CausesValidation="false" OnClick="btngofriend_OnClick" CssClass="button" />
                                                                            </td>
                                                                            <td width="50%" nowrap="nowrap">
                                                                                <asp:Label ID="lblCounterFrend" CssClass="error_yello" Visible="false" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right" class="normaltext" nowrap="nowrap" style="width: 30%">
                                                                                <asp:Panel ID="ddlNoOfRecord_Friend" runat="server">
                                                                                    <asp:Label ID="lblshowFriend" runat="server"><% =objLanguage.convert("Show")%></asp:Label>&nbsp;
                                                                                    <asp:DropDownList ID="ddlnoofrecordsperpageFriend" runat="server" AutoPostBack="True"
                                                                                        CssClass="normaltext" OnSelectedIndexChanged="ddlnoofrecordsperpageFriend_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblrecordsperpageFriend" runat="server"><%=objLanguage.convert("Records")%></asp:Label>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:UpdatePanel ID="UPFriend" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table border="0" cellpadding="5" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblletterFriend" Text="" Visible="false" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblDeleteConfirmation" CssClass="error" Text="" Visible="false" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblFriendSection" Visible="false" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="4" width="100%" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="dgrFriend" runat="server" DataKeyNames="addressListId" AutoGenerateColumns="False"
                                                                                AllowPaging="True" AllowSorting="True" ShowHeader="true" DataSourceID="SqlDataSourceFriend"
                                                                                GridLines="none" OnDataBound="dgrFriend_DataBound" OnRowDataBound="dgrFriend_RowDataBound"
                                                                                OnPageIndexChanging="dgrFriend_PageIndexChanging">
                                                                                <HeaderStyle CssClass="bgcustomize navigatorpanel" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Campaign" HeaderStyle-Width="2%">
                                                                                        <HeaderTemplate>
                                                                                            <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll">
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <input type="checkbox" runat="server" id="addressListId" onclick="CheckChanged();"
                                                                                                name="addressListId" value='<%# DataBinder.Eval(Container, "DataItem.AddressListid") %>' />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="AddressList" DataField="AddressListname" HeaderStyle-Width="20%"
                                                                                        SortExpression="AddressListname">
                                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="2%">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="lnkDeleteCommand" OnClientClick="javascript:return window.confirm('Are you sure, you want to delete?');"
                                                                                                runat="server" ImageUrl="~/images/delete.gif" OnCommand="lnkDeleteCommand_Click"
                                                                                                CommandArgument='<%# DataBinder.Eval(Container, "DataItem.AddressListid") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" style="height: 25px">
                                                                                        <tr>
                                                                                            <td class="empty_data_gridview" align="center">
                                                                                                <%=objLanguage.convert("No records found! ")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </EmptyDataTemplate>
                                                                                <PagerTemplate>
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <hr size="1" style="color: Gray" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="normaltext" align="right">
                                                                                                <asp:Label ID="lblpageFriend" runat="server" CssClass="normaltext"><%=objLanguage.convert("Page")%></asp:Label>&nbsp;
                                                                                                <asp:DropDownList ID="ddlpagenoFriend" runat="server" CssClass="normaltext" AutoPostBack="true"
                                                                                                    OnSelectedIndexChanged="ddlpagenoFriend_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                &nbsp;
                                                                                                <asp:Label ID="lblofFriend" runat="server"><%=objLanguage.convert("of")%></asp:Label>&nbsp;
                                                                                                <asp:Label ID="lblpagenoFriend" runat="server" CssClass="normaltext"></asp:Label>&nbsp;
                                                                                                <asp:ImageButton ID="lbtnFirstFriend" runat="server" CommandName="Page" CommandArgument="First"
                                                                                                    ImageUrl="~/images/icn_firstrecord.gif" ToolTip="First"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnPrevFriend" runat="server" CommandName="Page" CommandArgument="Prev"
                                                                                                    ImageUrl="~/images/icn_previous_record.gif" ToolTip="Previous"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnNextFriend" runat="server" CommandName="Page" CommandArgument="Next"
                                                                                                    ImageUrl="~/images/icn_next_record.gif" ToolTip="Next"></asp:ImageButton>
                                                                                                <asp:ImageButton ID="lbtnLastFriend" runat="server" CommandName="Page" CommandArgument="Last"
                                                                                                    ImageUrl="~/images/icn_last_record.gif" ToolTip="Last"></asp:ImageButton>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </PagerTemplate>
                                                                                <PagerStyle CssClass="normaltext" />
                                                                                <PagerSettings Position="Bottom" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:SqlDataSource ID="SqlDataSourceFriend" runat="server" SelectCommand="sp_Select_AddressList_Email"
                                                            SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="CompanyID" SessionField="companyID" Type="Int32" />
                                                                <asp:SessionParameter Name="UserID" SessionField="userid" Type="Int32" />
                                                                <asp:ControlParameter ControlID="lblletterFriend" Name="Para" DefaultValue=" " PropertyName="Text"
                                                                    Type="String" Direction="Input" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table id="Table3" style="display: block" runat="server" border="0" width="100%"
                    cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table border="0" cellpadding="13" cellspacing="0">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td valign="bottom" class="Normaltext" width="25%">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="Updatepanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                        <ContentTemplate>
                                                            <div id="divAddressList" style="display: none">
                                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                    <tr valign="bottom">
                                                                        <td valign="bottom" class="Normaltext" width="30%" nowrap="nowrap">
                                                                            <div id="divNewAddressList" style="display: none">
                                                                                <%=objLanguage.convert("AddressList Name")%>
                                                                                <asp:TextBox ID="txtAddtrssList" Width="200px" runat="server" CssClass="txtBox"></asp:TextBox>
                                                                            </div>
                                                                            <div id="divOldAddressList" style="display: none">
                                                                                <%=objLanguage.convert("Select AddressList Name")%>
                                                                                <asp:DropDownList ID="ddlAddressList" Width="200px" runat="server">
                                                                                </asp:DropDownList>
                                                                                <asp:LinkButton ID="lnkAddressList" OnClientClick="javascript:return ShowNewAddressList();"
                                                                                    runat="Server" Text="Add new"></asp:LinkButton>
                                                                            </div>
                                                                        </td>
                                                                        <td valign="bottom">
                                                                            <asp:Button ID="btnSave" Width="40px" Height="18px" Text="Save" runat="server" OnClientClick="javascript:return TextBoxAndDropDownValidation();"
                                                                                OnClick="btnSave_Click" CssClass="button"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td nowrap="nowrap" align="center">
                                                                        <asp:Label ID="lblConfirmation" Visible="false" CssClass="error_yello" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </table>
                <div id="divBackGroundNew" style="display: none;">
                </div>
                <div id="divrad" style="display: none; position: absolute; vertical-align: middle;
                    border: 0px solid; z-index: 100; width: 50%" align="center">
                    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
                        Opacity="100" runat="server" Width="1000" Style="z-index: 31000" Height="500"
                        OnClientClose="RadWinClose" Behaviors="Close, Move, Reload, Resize" ReloadOnShow="false">
                    </telerik:RadWindowManager>
                </div>
                <asp:Panel ID="pnl_WinClose" runat="server" Visible="false">
                    <script>
                        window.close();
                    </script>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <input type="hidden" id="hdnError" />
    <asp:Label ID="lblError" CssClass="error_yello" runat="server" Visible="false"></asp:Label>
    <script language="javascript" type="text/javascript">

        function handleTabRollover(mouseState, tab, idd) {
            var tabSelect = document.getElementById(idd);
            tabSelect.className = 'searchTab' + (mouseState == 'over' ? ' selectedSearchTab' : '');
            if (tab == 'a') {
                tabSelect.className = 'searchTab selectedSearchTab';
            }

        }

        function HideShowAddressList() {
            var lblConfirmation = document.getElementById("ctl00_ContentPlaceHolder1_lblConfirmation");
            var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
            var ddlAddressList = document.getElementById("ctl00_ContentPlaceHolder1_ddlAddressList");
            var lnkAddressList = document.getElementById("ctl00_ContentPlaceHolder1_lnkAddressList");
            var divAddressList = document.getElementById("divAddressList");
            var divNewAddressList = document.getElementById("divNewAddressList");
            var divOldAddressList = document.getElementById("divOldAddressList");
            var btnGo = document.getElementById("ctl00_ContentPlaceHolder1_btnGo");
            var divbtnGo = document.getElementById("divbtnGo");
            if ((ddl.options[ddl.selectedIndex].value == "1") || (ddl.options[ddl.selectedIndex].value == "2") || (ddl.options[ddl.selectedIndex].value == "3")) {
                divAddressList.style.display = 'none';
                try {
                    lblConfirmation.innerHTML = '';
                }
                catch (err) {
                }
                divbtnGo.style.display = 'block';
                return false;
            }
            else if (ddl.options[ddl.selectedIndex].value == "4") {
                divAddressList.style.display = 'none';
                divbtnGo.style.display = 'none';
                try {
                    lblConfirmation.innerHTML = '';
                }
                catch (err) {
                }
                return false;
            }
            else if (ddl.options[ddl.selectedIndex].value == "5") {
                divAddressList.style.display = 'block';
                divNewAddressList.style.display = 'block';
                divOldAddressList.style.display = 'none';
                try {
                    lblConfirmation.innerHTML = '';
                }
                catch (err) {
                }
                divbtnGo.style.display = 'none';
                return false;
            }
            else if (ddl.options[ddl.selectedIndex].value == "6") {
                divAddressList.style.display = 'block';
                divNewAddressList.style.display = 'none';
                divOldAddressList.style.display = 'block';
                try {
                    lblConfirmation.innerHTML = '';
                }
                catch (err) {
                }
                divbtnGo.style.display = 'none';
                return false;
            }
            else {
                divAddressList.style.display = 'none';
                try {
                    lblConfirmation.innerHTML = '';
                }
                catch (err) {
                }
                divbtnGo.style.display = 'none';
                return true;
            }
        }

        function ShowNewAddressList() {

            var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
            var divAddressList = document.getElementById("divAddressList");
            var divNewAddressList = document.getElementById("divNewAddressList");
            var divOldAddressList = document.getElementById("divOldAddressList");
            var divbtnGo = document.getElementById("divbtnGo");
            divAddressList.style.display = 'block';
            divNewAddressList.style.display = 'block';
            divOldAddressList.style.display = 'none';
            divbtnGo.style.display = 'none';
            ddl.selectedIndex = "5";
            return false;

        }
        function HideButton() {
            try {
                var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
                var divAddressList = document.getElementById("divAddressList");
                var divNewAddressList = document.getElementById("divNewAddressList");
                var divOldAddressList = document.getElementById("divOldAddressList");
                var divbtnGo = document.getElementById("divbtnGo");
                divAddressList.style.display = 'none';
                divNewAddressList.style.display = 'none';
                divOldAddressList.style.display = 'none';
                divbtnGo.style.display = 'none';
                ddl.selectedIndex = "0";
            }
            catch (err) {
            }
        }

        function TextBoxAndDropDownValidation() {
            var returnvalue = true;
            var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddlLeadMoreAction");
            var ddlAddressList = document.getElementById("ctl00_ContentPlaceHolder1_ddlAddressList");
            var txtAddtrssList = document.getElementById("ctl00_ContentPlaceHolder1_txtAddtrssList");
            if (ddl.options[ddl.selectedIndex].value == "5") {
                if (txtAddtrssList.value == '') {
                    alert('Please enter AddressListName');
                    returnvalue = false;
                }
                else {
                    returnvalue = true;
                }

            }
            else if (ddl.options[ddl.selectedIndex].value == "6") {
                if (ddlAddressList.options[ddlAddressList.selectedIndex].value == '0') {
                    alert('Please select AddressListName');
                    returnvalue = false;
                }
                else {
                    returnvalue = true;
                }
            }
            var newReturnValue = true;
            var hdnTabSelect = document.getElementById("ctl00_ContentPlaceHolder1_hdnTabSelect")
            if (hdnTabSelect.value == 'Lead') {
                grdId = 'leadId';
            }
            else if (hdnTabSelect.value == 'Contact') {
                grdId = 'contactId';
            }
            else {
                grdId = 'addressListId';
            }
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(grdId) != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert("Please check at least one row");
                newReturnValue = false;
            }
            else {
                newReturnValue = true;
            }
            if ((returnvalue) && (newReturnValue)) {
                return true;
            }
            else {
                return false;
            }
        }
        function CheckOne() {
            var hdnTabSelect = document.getElementById("ctl00_ContentPlaceHolder1_hdnTabSelect")
            if (hdnTabSelect.value == 'Lead') {
                grdId = 'leadId';
            }
            else if (hdnTabSelect.value == 'Contact') {
                grdId = 'contactId';
            }
            else {
                grdId = 'addressListId';
            }
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(grdId) != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert("Please check at least one row");
                return false;
            }
            else {
                CloseWindow();
                return true;
            }
        }

        function CloseWindow() {
            var hidleadid = "";
            var hidcontactid = "";
            var hidmixleadid = "";
            var hidmixcontactid = "";

            var hidleadidemail = "";
            var hidcontactidemail = "";
            var hidmixleadidemail = "";
            var hidmixcontactidemail = "";

            //hidid for mailid
            //hidid for mailid
            var hdnTabSelect = document.getElementById("ctl00_ContentPlaceHolder1_hdnTabSelect")

            var ddl = document.getElementById("<%=ddlLeadMoreAction.ClientID %>"); //ctl00_ContentPlaceHolder1_ddlLeadMoreAction
            var txtfirstname = "";
            var txtcc = "";
            var txtbcc = "";

            if ('<%=sectionname %>' == "client") {
                txtfirstname = window.parent.frames.document.getElementById("txtfirstname"); //("ctl00_ContentPlaceHolder1_txtfirstname");
                txtcc = window.parent.frames.document.getElementById("txtcc"); //("ctl00_ContentPlaceHolder1_txtcc");
                txtbcc = window.parent.frames.document.getElementById("txtbcc"); //("ctl00_ContentPlaceHolder1_txtbcc");                
            }
            else if ('<%=sectionname %>' == "PrintBroker") {
                txtfirstname = window.parent.frames[0].imgID.replace('imgselectleadmain', 'txtfirstname');
                txtcc = window.parent.frames[0].imgID.replace('imgselectleadmain', 'txtcc');
                txtbcc = window.parent.frames[0].imgID.replace('imgselectleadmain', 'txtbcc');

                txtfirstname = window.parent.frames[0].document.getElementById(txtfirstname);
                txtcc = window.parent.frames[0].document.getElementById(txtcc);
                txtbcc = window.parent.frames[0].document.getElementById(txtbcc);

            }
            else {
                txtfirstname = window.parent.frames[0].document.getElementById("uc1_txtfirstname"); //("ctl00_ContentPlaceHolder1_txtfirstname");               
                txtcc = window.parent.frames[0].document.getElementById("uc1_txtcc"); //("ctl00_ContentPlaceHolder1_txtcc");                
                txtbcc = window.parent.frames[0].document.getElementById("uc1_txtbcc"); //("ctl00_ContentPlaceHolder1_txtbcc");               

            }

            var finalemailids = "";
            if (hdnTabSelect.value == "Contact") {
                var grdId = 'contactId';
                var Counter = 0;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];

                    if (e.type == 'checkbox' && e.name.indexOf('contactId') != -1) {
                        if (e.checked) {
                            if (e.value != 'on') {
                                Counter = Number(Counter) + 1;
                                finalemailids += e.value.split('%27').join("'").split('%22').join('"') + ",";
                            }
                        }
                    }
                }
            }
            if (ddl.options[ddl.selectedIndex].value == "1") {
                if (txtfirstname.value == "") {
                    txtfirstname.value = txtfirstname.value + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
                else {
                    txtfirstname.value = txtfirstname.value + "," + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
            }



            if (ddl.options[ddl.selectedIndex].value == "1") {
                if (hdnTabSelect.value == 'Lead') {
                    hidleadid.value = "<%=strRedirect%>";
                    hidleadidemail.value = "<%=LeadidEmail%>";
                    hidcontactid.value = '';
                    hidmixleadid.value = '';
                    hidmixcontactid.value = '';
                    hidcontactidemail.value = '';
                    hidmixleadidemail.value = '';
                    hidmixcontactidemail.value = '';
                }
                else if (hdnTabSelect.value == 'Contact') {
                    hidleadid.value = '';
                    hidmixleadid.value = '';
                    hidmixcontactid.value = '';
                    hidleadidemail.value = '';
                    hidmixleadidemail.value = '';
                    hidmixcontactidemail.value = '';
                    hidcontactid.value = "<%=strRedirect%>";
                    hidcontactidemail.value = "<%=ContactidEmail%>";

                }
                else if (hdnTabSelect.value == 'Friend') {
                    hidleadid.value = '';
                    hidcontactid.value = '';
                    hidleadidemail.value = '';
                    hidcontactidemail.value = '';
                    hidmixleadid.value = "<%=MixLeadEmail%>";
                    hidmixcontactid.value = "<%=MixContactEmail%>";
                    hidmixleadidemail.value = "<%=MixLeadidEmail%>";
                    hidmixcontactidemail.value = "<%=MixContactidEmail%>";
                }
    }
    else if (ddl.options[ddl.selectedIndex].value == "2") {
        if (txtbcc.value == "") {

            txtbcc.value = txtbcc.value + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
                else {

                    txtbcc.value = txtbcc.value + "," + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
            }
            else if (ddl.options[ddl.selectedIndex].value == "3") {
                if (txtcc.value == "") {
                    txtcc.value = txtcc.value + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
                else {
                    txtcc.value = txtcc.value + "," + finalemailids.substring(0, finalemailids.length - 1); //"<%=strRedirect%>";  
                }
            }
    window.close();
}
    </script>
    <script language="javascript" type="text/javascript">
        var i = 0;
        var j = 0;
        var k = 0;
        var l = 0;
        var m = 0;
        function hide_Error_Message() {

            try {
                if (i == 10) {
                    i = 0;
                    var lblDeleteConfirmation = document.getElementById("ctl00_ContentPlaceHolder1_lblDeleteConfirmation");
                    lblDeleteConfirmation.innerHTML = '';
                    lblDeleteConfirmation.style.display = 'none';
                }
            }
            catch (err) {
            }
            i = i + 1;
            try {
                if (j == 10) {
                    j = 0;
                    var lblConfirmation = document.getElementById("ctl00_ContentPlaceHolder1_lblConfirmation");
                    lblConfirmation.innerHTML = '';
                    lblConfirmation.style.display = 'none';
                }
            }
            catch (err) {
            }
            j = j + 1;
            try {
                if (k == 10) {
                    k = 0;
                    var lblCounterFrend = document.getElementById("ctl00_ContentPlaceHolder1_lblCounterFrend");
                    lblCounterFrend.innerHTML = '';
                    lblCounterFrend.style.display = 'none';
                }
            }
            catch (err) {
            }
            k = k + 1;

            try {
                if (l == 10) {
                    l = 0;
                    var lblCounterLead = document.getElementById("ctl00_ContentPlaceHolder1_lblCounterLead");
                    lblCounterLead.innerHTML = '';
                    lblCounterLead.style.display = 'none';
                }
            }
            catch (err) {
            }
            l = l + 1;


            try {
                if (m == 10) {
                    m = 0;
                    var lblCounterContact = document.getElementById("ctl00_ContentPlaceHolder1_lblCounterContact");
                    lblCounterContact.innerHTML = '';
                    lblCounterContact.style.display = 'none';

                }
            }
            catch (err) {
            }
            m = m + 1;
            setTimeout("hide_Error_Message()", 1000)
        }
        setTimeout("hide_Error_Message()", 1000);
    </script>
    <script language="javascript" type="text/javascript">
        var i = 0;
        function CheckTime() {
            var hdnError = document.getElementById("hdnError");
            hdnError.value = "1";
            setTimeout("hide_Error_Message()", 500);

        }
        function hide_Error_Message() {

            try {
                var hdnError = document.getElementById("hdnError");


                if (i == 10) {
                    i = 0;
                    var lblDeleteConfirmation = document.getElementById("ctl00_ContentPlaceHolder1_lblError");
                    lblDeleteConfirmation.innerHTML = '';
                    lblDeleteConfirmation.style.display = "none";
                }

            }
            catch (err) {
            }
            i = i + 1;
            if (hdnError.value == "1") {
                setTimeout("hide_Error_Message()", 500)
                if (i == 10) {
                    hdnError.value = "0";
                }
            }

        }
    </script>
</asp:Content>


