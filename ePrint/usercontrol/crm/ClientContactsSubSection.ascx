<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientContactsSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.ClientContactsSubSection" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
                        <div>
                            <asp:UpdatePanel ID="up_ContactDetails" runat="server">
                                <ContentTemplate>
                                    <div id="div1" runat="server" style="display: block;">
                                        <div align="left" style="width: 100%; padding-bottom: 0px;">
                                            <div style="width: 100%; margin: 5px 0px 0px 5px">
                                                <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                                    <ContentTemplate>
                                                        <asp:PlaceHolder ID="plhContact" runat="server"></asp:PlaceHolder>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div>
                                            <div id="div_popupAction" style="display: none; z-index: 999999; position: absolute; margin: 35px 0px 0px 16px"
                                                onmouseover="show();" onmouseout="hide();">
                                                <telerik:RadListBox runat="server" ID="RadListBox_Contact" SelectionMode="Single"
                                                    AutoPostBack="false">
                                                    <Items>
                                                        <%--Ticket Id : 13951--%>
                                                        <telerik:RadListBoxItem id="UserSpendlimit" runat="server" Text="Spend limit" Style="border-bottom: 1px solid #CBCBCB; display: none; cursor: pointer"
                                                            onclick="javascript:return CheckOne_new('spendlimituser');" Checked="false" />
                                                        <telerik:RadListBoxItem id="UserSpendlimitDeactivate" runat="server" Style="border-bottom: 1px solid #CBCBCB; display: none; cursor: pointer"
                                                            onclick="javascript:return CheckOne_new('spendlimitdeactivate');" Checked="false" />
                                                        <telerik:RadListBoxItem id="Delete_Hide" runat="server" Text="Delete" onclick="javascript:return CheckOne_new('delete');"
                                                            Checked="false" />
                                                        <telerik:RadListBoxItem Text="Activate" onclick="javascript:return CheckOne_new('activate');"
                                                            Checked="false" />
                                                        <telerik:RadListBoxItem Text="Deactivate" onclick="javascript:return CheckOne_new('deactivate');"
                                                            Checked="false" />


                                                         <telerik:RadListBoxItem id="RadListboxActiverStoreUser" runat="server" Text="Activate Store Credit" Style="border-bottom: 1px solid #CBCBCB;  cursor: pointer"
                                                            onclick="javascript:return CheckOne_new('activatestorecredit');" Checked="false" />
                                                        <telerik:RadListBoxItem id="RadListboxDeActiverStoreUser" runat="server" Style="border-bottom: 1px solid #CBCBCB;  cursor: pointer"
                                                            onclick="javascript:return CheckOne_new('deactivatestorecredit');" Checked="false" Text="Deactivate Store Credit" />
                                                    

                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdn_ContactIDs" runat="server" />
                                        <asp:LinkButton ID="lnk_ContactsRadList" runat="server" OnClick="RadListBox_Contact_SelectedIndexChanged"></asp:LinkButton>
                                        <div id="div_Contact" class="eprint-crm-contacts-grid-host" style="display: block; width: 100%;">
                                            <div id="div8" style="display: block;">
                                                <telerik:RadGrid ID="RadGrid_Contact" runat="server" AllowPaging="true" AllowSorting="true"
                                                    AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="false" OnItemCommand="RadGrid_Contact_ItemCommand"
                                                    PageSize="50" Width="100%" ShowGroupPanel="false" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
                                                    OnItemDataBound="RadGridContact_OnRowDataBound" AllowFilteringByColumn="true" loadingpanelid="RadAjaxLoadingPanel1"
                                                    OnNeedDataSource="RadGrid_Contact_OnNeedDataSource"  GridLines="none" CssClass="AddBorders eprint-crm-contacts-grid"
                                                    EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="None"
                                                    BorderColor="White" FilterItemStyle-HorizontalAlign="Justify" Skin="Default" GroupingSettings-CaseSensitive="false" 
						                            OnPageIndexChanged="RadGrid_Contact_PageIndexChanged" AllowCustomPaging="true">
                                                    <AlternatingItemStyle BackColor="White" />
                                                    <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
                                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                    <MasterTableView DataKeyNames="ContactID" OverrideDataSourceControlSorting="true"
                                                     AllowFilteringByColumn="true" CommandItemDisplay="Top" Width="100%">

                                                        <CommandItemTemplate>
                                                            <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                                                            </div>
                                                        </CommandItemTemplate>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="4%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                                ItemStyle-Width="4%">
                                                                <HeaderTemplate>
                                                                    <div id="div_checkBox" style="float: left;">
                                                                        <div style="float: left; display: none;">
                                                                        </div>
                                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div style="float: left;">
                                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                                type="checkbox" />
                                                                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                            <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                                onclick="show();" alt='' />
                                                                                            <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                                onclick="hide();" alt='' />
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <input id="checkBox_Contact" runat="server" name="Id" type="checkbox" style="margin-left: 8px;" onclick="CheckChanged_Contact();"
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>' />
                                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="ContactName" HeaderStyle-HorizontalAlign="Left"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="80"
                                                                HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%" SortExpression="ContactName"
                                                                UniqueName="ContactName" Visible="true">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_ContactName" runat="server"></asp:Label>
                                                                            <asp:HiddenField ID="hdn_ContactFirstName" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.FirstName", "{0}")) %>'></asp:HiddenField>
                                                                            <asp:HiddenField ID="hdn_ContactLastName" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.LastName", "{0}")) %>'></asp:HiddenField>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="Department" HeaderStyle-HorizontalAlign="Left"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="80"
                                                                HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%" SortExpression="Department"
                                                                UniqueName="Department" Visible="true">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_Department" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Department", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Department", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="JobTitle1" HeaderStyle-HorizontalAlign="Left"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="70"
                                                                HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="7%" SortExpression="JobTitle1"
                                                                UniqueName="JobTitle1" Visible="true">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_JobTitle1" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobTitle1", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.JobTitle1", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="Email" HeaderStyle-HorizontalAlign="Left"
                                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                                HeaderStyle-Width="16%" HeaderText="" ItemStyle-Width="16%" SortExpression="Email"
                                                                Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="Email">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_Email" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Email", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Email", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="HomeTelephone" HeaderStyle-HorizontalAlign="Left"
                                                                FilterControlWidth="60" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                HeaderStyle-Width="12%" HeaderText="" ItemStyle-Width="12%" SortExpression="HomeTelephone"
                                                                Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="HomeTelephone">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_Phone" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.HomeTelephone", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.HomeTelephone", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="PersonalPhone" HeaderStyle-HorizontalAlign="Left"
                                                                FilterControlWidth="70" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                HeaderStyle-Width="11%" HeaderText="" ItemStyle-Width="11%" SortExpression="PersonalPhone"
                                                                Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="PersonalPhone">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_PersonalPhone" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.PersonalPhone", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.PersonalPhone", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="Mobile" HeaderStyle-HorizontalAlign="Left"
                                                                FilterControlWidth="60" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                HeaderStyle-Width="9%" HeaderText="" ItemStyle-Width="9%" SortExpression="Mobile"
                                                                Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="Mobile">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_Mobile" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Mobile", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Mobile", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <%--Ticket Id : 13951--%>
                                                            <telerik:GridTemplateColumn DataField="SpendLimit" HeaderStyle-HorizontalAlign="Left"
                                                                FilterControlWidth="60" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                HeaderStyle-Width="12%" HeaderText="" ItemStyle-Width="12%" SortExpression="SpendLimit"
                                                                Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="SpendLimit">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:newPopup(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'<%=isView%>');return false;">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                            <asp:Label ID="lbl_SpendLimit" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.SpendLimit", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.SpendLimit", "{0}")) %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderStyle-HorizontalAlign="Left"
                                                                HeaderStyle-Width="5%" HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="5%"
                                                                UniqueName="restoreDefault">
                                                                <ItemTemplate>
                                                                    <div style="text-align: left;">
                                                                        <asp:Label ID="lbl_Activate" runat="server" Text="Active"></asp:Label>
                                                                        <asp:HiddenField ID="hdn_Activate" runat="server" Value='<%#Eval("IsActive")%>' />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" Visible="true" HeaderStyle-HorizontalAlign="Center"
                                                                HeaderStyle-Width="13%" HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%"
                                                                UniqueName="approverType">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_ApproverType" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.ApproverType", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.ApproverType", "{0}")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="DefaultContact" HeaderStyle-HorizontalAlign="Center"
                                                                AllowFiltering="false" HeaderStyle-Width="5%" HeaderText="" ItemStyle-Width="5%"
                                                                SortExpression="Enabled" UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.ContactID", "{0}") %>,'contact');">
                                                                        <div style="float: left; width: 100%; overflow: hidden; height: 18px;">
                                                                            <asp:HiddenField ID="hdn_DefaultContact" runat="server" Value='<%#Eval("DefaultContact")%>' />
                                                                            <asp:HiddenField ID="hdn_DefaultContactID" runat="server" Value='<%#Eval("ContactID")%>' />
                                                                            <asp:ImageButton ID="img_DefaultContact" runat="server" CommandName="Set as default"
                                                                                CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("ContactID")%>'
                                                                                OnCommand="setDefaultContact_OnClick"></asp:ImageButton>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                                HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="8%" HeaderText="" ItemStyle-HorizontalAlign="Right"
                                                                ItemStyle-Width="8%" UniqueName="restoreDefaultButton">
                                                                <ItemTemplate>
                                                                    <div id="DivLoginKey" runat="server" style="text-align: center;">
                                                                        <a runat="server" id="anchor">
                                                                            <div style="text-align: center;">
                                                                                <asp:ImageButton ID="ImgButtonLoginContacts" runat="server" CausesPostBack="false" OnClientClick="return false;" />
                                                                                <asp:HiddenField ID="hdn_LoginEmail" runat="server" Value='<%#Eval("Email")%>' />
                                                                                <asp:HiddenField ID="hdn_LoginPwd" runat="server" Value='<%#Eval("Password")%>' />
                                                                            </div>
                                                                        </a>
                                                                    </div>
                                                                    <div id="DivContact" runat="server" style="float: right; border: 0px solid red; margin-top: -13px">
                                                                        <div style="text-align: center; float: left; width: 25px; display: none;">
                                                                            <a href="javascript:void(0);" onclick="AddContactNotes('<%#Eval("ContactID")%>','<%#Eval("ClientID")%>');"
                                                                                title="Add New Contact">
                                                                                <asp:ImageButton ID="btnNotes" ImageUrl="~/Images/clipboard_task.png" Text="Notes"
                                                                                    ToolTip="Notes" UniqueName="NotesColumn" runat="server"></asp:ImageButton>
                                                                            </a>
                                                                        </div>
                                                                        <div style="text-align: center; float: left; width: 20px">
                                                                            <asp:ImageButton ID="ImgButtonDeleteContacts" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                                CommandArgument='<%#Eval("ContactID")%>' Text="Delete" OnCommand="DeleteImgContact_OnClick"
                                                                                UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return imgbtnDelete_ClientClick('contacts','0');"></asp:ImageButton>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                        <NoRecordsTemplate>
                                                            <div style="padding: 5px 0px 0px 10px">
                                                                <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                                            </div>
                                                        </NoRecordsTemplate>
                                                    </MasterTableView>
                                                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                                        AllowDragToGroup="false" Scrolling-AllowScroll="true">
                                                        <Selecting AllowRowSelect="True" />
                                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                        <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                                                        <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
