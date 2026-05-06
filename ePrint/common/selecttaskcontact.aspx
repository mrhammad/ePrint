<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selecttaskcontact.aspx.cs" masterpagefile="~/Templates/popUpMasterPage_new.master" Inherits="ePrint.common.selecttaskcontact" %>

<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="Estyle" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/AliasPopUp/aliaspopup.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <div id="ds00" style="display: block;">
    </div>
    <script>
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";        
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView2" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <UC:Estyle ID="Estyle1" runat="server" />
    <br />
    <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
        <%--class="borderWithoutTop"--%>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblquickviewerror" CssClass="error" Width="100%" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlcreatecontact" runat="server" Visible="false">
                        <tr>
                            <td>
                                <table cellspacing="1" cellpadding="3" width="95%" border="0" align="center">
                                    <tr valign="top">
                                        <td width="20%" class="label" valign="top" nowrap="nowrap">
                                            <%--class="newLabelText"--%>
                                            &nbsp;<asp:Label ID="lblfirstname" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td align="left" width="80%" valign="top">
                                            <asp:TextBox ID="txtfirstname" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter first name" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtfirstname"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td width="20%" valign="middle" class="label" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblname" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtname" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter last name" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtname"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" align="justify" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblalias" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtalias" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter contact alias" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtalias"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top" align="left">
                                        <td valign="middle" align="left" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblmailcity" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtmailcity" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblmailstate" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtmailstate" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblmailzip" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtmailzip" MaxLength="20" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblothercity" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtothercity" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblotherstate" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtotherstate" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label" width="20%" nowrap="nowrap">
                                            &nbsp;<asp:Label ID="lblotherzip" runat="server" CssClass="normaltext"></asp:Label>
                                        </td>
                                        <td width="80%" valign="top">
                                            <asp:TextBox ID="txtotherzip" MaxLength="20" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnsave" CssClass="button" runat="server" Text="Save" Width="50px"
                                                            OnClick="btnsave_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="button" runat="server"
                                                            Text="Cancel" Width="50px" OnClick="lnkcreatenew_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlcreatelead" runat="server" Visible="false">
                        <tr>
                            <td>
                                <table cellspacing="1" cellpadding="1" width="95%" border="0" align="center">
                                    <tr valign="top">
                                        <td width="20%" class="label" valign="middle">
                                            <asp:Label ID="lblfirstlead" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtfirstlead" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter first name" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtfirstlead"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td width="20%" valign="middle" class="label">
                                            <%--class="newLabelText"--%>
                                            <asp:Label ID="lbllastlead" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtlastlead" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter last name" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtlastlead"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label">
                                            <%--class="newLabelText""--%>
                                            <asp:Label ID="lblcompanylead" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcompanylead" MaxLength="200" CssClass="txtbox" Width="150px"
                                                runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter company name" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtcompanylead"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td valign="middle" class="label">
                                            <%--class="newLabelText"--%>
                                            <asp:Label ID="lblleadalias" runat="server" CssClass="normaltext"></asp:Label><span
                                                class="redver7">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtleadalias" MaxLength="200" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
                                            <div class="error_top">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="error"
                                                    ForeColor="" ErrorMessage="Please enter lead alias" Display="Dynamic" Width="150px"
                                                    ControlToValidate="txtleadalias"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img height="7" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="Button2" CssClass="button" runat="server" Text="Save" Width="50px"
                                                OnClick="btnsave_Click" />
                                            &nbsp;&nbsp;<asp:Button ID="Button1" CausesValidation="false" CssClass="button" runat="server"
                                                Text="Cancel" Width="50px" OnClick="lnkcreatenew_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td>
                            <asp:Panel ID="Up1" runat="server">
                                <UC:Estyle ID="Estyle3" runat="server" />
                                <table cellspacing="0" cellpadding="0" width="97%" border="0" align="center">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnllead" runat="server">
                                                <asp:Label ID="lblletter" Text="" Visible="false" runat="server"></asp:Label>
                                                <asp:GridView AllowPaging="true" CellSpacing="1" PageSize="10" AllowSorting="true"
                                                    ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None"
                                                    Width="100%" Height="20" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <%--DataSourceID="SqlDataSource1"--%>
                                                    <HeaderStyle CssClass="bgcustomize navigatorpanel" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a href="javascript:f1('<%#Eval("firstname")%> <%#Eval("lastname")%>','<%#Eval("leadid")%>');"
                                                                    class="normaltext">
                                                                    <%=objLanguage.convert("Select")%>
                                                                </a>
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                                <%=objLanguage.convert("Select")%>
                                                            </HeaderTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="navigatorpanel" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="companyname" HeaderText="Company Name" SortExpression="companyname">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" style="height: 25px">
                                                            <tr>
                                                                <td class="middleText" align="center">
                                                                    <%=objLanguage.convert("No record(s) found")%>
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
                                                                        OnSelectedIndexChanged="ddlpageno1_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    &nbsp;
                                                                    <asp:Label ID="lblof" runat="server"><%=objLanguage.convert("of")%></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblpageno" runat="server" CssClass="normaltext"></asp:Label>&nbsp;
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
                                            </asp:Panel>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="crm_common_select_TaskType_inpopup"
                                                SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="companyID" SessionField="companyID" Type="Int32" />
                                                    <asp:SessionParameter Name="userID" SessionField="userID" Type="Int32" />
                                                    <asp:QueryStringParameter Name="type" DefaultValue="lead" QueryStringField="contacttype"
                                                        Type="string" Size="50" />
                                                    <asp:ControlParameter ControlID="lblletter" Name="Para" DefaultValue=" " PropertyName="Text"
                                                        Type="String" Direction="Input" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img height="7" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="div_Contact" style="display: block;">
                                                <asp:Panel ID="Panel_Contact" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                    <div id="a" style="width: 100%">
                                                        <div style="height: 18px">
                                                            <div style="float: left; padding-left: 5px">
                                                                <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                                    cursor: pointer" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <telerik:RadGrid ID="GridView2" runat="server" ShowStatusBar="true" PagerStyle-AlwaysVisible="true"
                                                            Width="99%" FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                                            PageSize="25" AllowPaging="True" AutoGenerateColumns="False" AllowFilteringByColumn="true"
                                                            OnNeedDataSource="GridView2_OnNeedDataSource" OnItemDataBound="GridView2_OnRowDataBound"
                                                            PagerStyle-Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-Height="30px" GroupingSettings-CaseSensitive="false">
                                                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <MasterTableView OverrideDataSourceControlSorting="true" PagerStyle-AlwaysVisible="true">
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                        DataField="contactname" SortExpression="contactname" UniqueName="contactname"
                                                                        FilterControlWidth="150" ItemStyle-Wrap="false" AutoPostBackOnFilter="true">
                                                                        <HeaderStyle HorizontalAlign="left" Wrap="false" Width="50%" />
                                                                        <ItemStyle HorizontalAlign="left" Width="25%" Height="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_ContactName" runat="server"></asp:Label>
                                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                                <asp:HiddenField ID="hdnFirstLastName" Value='<%#Eval("FirstName")%>' runat="server" />
                                                                                <asp:HiddenField ID="hdnLastName" Value='<%#Eval("LastName")%>' runat="server" />
                                                                                <asp:HiddenField ID="hdnContactID" Value='<%#Eval("contactid")%>' runat="server" />
                                                                                <a id="Contacts" runat="server" class="normaltext">
                                                                                    <%--href="javascript:f1('<%#Eval("FirstName")%> <%#Eval("LastName")%>','<%#Eval("contactid")%>');"--%>
                                                                                    <%#Eval("FirstName")%>
                                                                                    <%#Eval("LastName")%>
                                                                                </a>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                        CurrentFilterFunction="Contains" DataField="Email" FilterControlWidth="150" ItemStyle-Wrap="false"
                                                                        UniqueName="Email" SortExpression="Email" HeaderText="Email" AutoPostBackOnFilter="true">
                                                                        <HeaderStyle HorizontalAlign="left" Wrap="false" Width="50%" />
                                                                        <ItemStyle HorizontalAlign="left" Width="25%" Height="15%" />
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                                <asp:Label ID="lbl_Email" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email", "{0}") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                            <ClientSettings>
                                                                <Scrolling AllowScroll="True" SaveScrollPosition="true" EnableVirtualScrollPaging="true"
                                                                    UseStaticHeaders="True"></Scrolling>
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <img height="7" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        function f1(sub, hid) {
            var str_page_url = "'" + parent.parent.location + "'";   //IE & All Browsers issue, changed on 30.09.2011
            str_page_url = str_page_url.toLowerCase();
            var pw = window.parent;

            if (str_page_url.search("estimate_add.aspx") > -1) {
                //THIS IS ONLY FOR TASK ADD PAGE
                var ContactName = sub;
                var ContactID = hid;
                parent.parent.FromSelecttaskPage(ContactName, ContactID);
            }
            else if (str_page_url.search("task_add.aspx") > -1 || str_page_url.search("task_edit.aspx") > -1 || str_page_url.search("event_edit.aspx") > -1 || str_page_url.search("event_add.aspx") > -1) {
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_contactid_hidden'].value='" + hid + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_contacttxt_hidden'].value='" + sub + "'");
                pw.SetFollowupContact(sub, hid);
            }
            else if (str_page_url.search("purchase_add.aspx") > -1) {
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCTask_contactid_hidden'].value='" + hid + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCTask_contacttxt_hidden'].value='" + sub + "'");
                pw.SetFollowupContact(sub, hid);
            } else if (str_page_url.search("delivery_add.aspx") > -1) {
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCDeliveryNote_UCTask_contactid_hidden'].value='" + hid + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCDeliveryNote_UCTask_contacttxt_hidden'].value='" + sub + "'");
                pw.SetFollowupContact(sub, hid);
            }
            else {
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCItemDescription_UCTask_txtcontacttype'].value='" + sub + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCItemDescription_UCTask_contactid_hidden'].value='" + hid + "'");
                eval("parent.window.document.forms[0][\'ctl00_ContentPlaceHolder1_UCItemDescription_UCTask_contacttxt_hidden'].value='" + sub + "'");

            }
            window.close();

        }
    </script>
    <script language="javascript" type="text/javascript">
        var i = 0;
        function CheckTime() {
            var hdnError = document.getElementById("hdnError");
            hdnError.value = "1";
            setTimeout("hide_Error_Message()", 100);

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
                setTimeout("hide_Error_Message()", 100)
                if (i == 10) {
                    hdnError.value = "0";
                }
            }

        }
    </script>
    <script type="text/javascript">
        var GridItemTitle = document.getElementById("<%=GridView2.ClientID %>");
        function CallOverflow() {

            SetGridOverflow(GridItemTitle);
        }
        CallOverflow();

        document.getElementById("ds00").style.display = "none";
        // document.getElementById("div_Load").style.display = "none";


    </script>
</asp:Content>

