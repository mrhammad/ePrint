<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="notes.ascx.cs" Inherits="ePrint.usercontrol.Item.notes" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="../js/Item/pricecatalogfeatures.js?VN='<%=VersionNumber%>'"></script>
<style>
    .RadGrid_Default .rgEditForm {
        border-bottom: none;
        padding-bottom: 3px;
    }
</style>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadGrid2">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<div id="divBackGroundNew" style="display: none;">
</div>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<asp:HiddenField ID="hid_EstUserNotesID" runat="server" Value="0" />
<script type="text/javascript">
    function ErrorCheck(val, id) {
        if (val == "Error") {
            document.getElementById(id).disabled = false;
        }
        else {
            document.getElementById(id).disabled = true;
        }
    }
</script>
<div id="div_notes" runat="server" style="display: none; position: absolute; z-index: 100;
    width: 80%;">
    <table cellpadding="0" cellspacing="0" width="100%;">
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="height: 350px">
                            <div style="padding: 5px 5px 10px 0px; width: 98%">
                                <div class="" style="width: 100%">
                                    <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" OnItemDataBound="OnItemDataBound_RadGrid2"
                                        DataSourceID="ObjectDataSource1" AllowPaging="True" PageSize="10" AllowSorting="True"
                                        AutoGenerateColumns="False" ShowStatusBar="true" HorizontalAlign="NotSet" Width="100%"
                                        AllowAutomaticInserts="true" OnInsertCommand="RadGrid2_InsertCommand" AlternatingItemStyle-Wrap="true">
                                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                        <MasterTableView AllowAutomaticInserts="true" CommandItemDisplay="Top" DataKeyNames="NotesID"
                                            DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
                                            <CommandItemTemplate>
                                                <table id="act_hist" runat="server" class="rgCommandTable" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Button ID="Button1" runat="server" class="rgAdd" CommandName="InitInsert" />
                                                            <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server">
                                                    <%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <EditItemStyle></EditItemStyle>
                                            <EditFormSettings InsertCaption="Add new Notes" CaptionFormatString="NotesID: {0}"
                                                CaptionDataField="NotesID" EditFormType="Template">
                                                <FormTemplate>
                                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Label ID="Label3" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Type") %></asp:Label>
                                                            </td>
                                                            <td>
                                                                <div class="ActivityNotes">
                                                                    <asp:RadioButton ID="rdoGeneral" runat="server" GroupName="Type" Text="General" Checked="true" />
                                                                    <asp:RadioButton ID="rdoError" runat="server" GroupName="Type" Text="Error" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Error_Type") %></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlErrorType" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:Label ID="lblfeatureddescription" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Notes") %></asp:Label>
                                                                <span style="color: Red; padding-left: 4px">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUserNotes" runat="server" Width="600px" Height="100px" TextMode="MultiLine"
                                                                    Text='<%# Bind("Description") %>'></asp:TextBox>
                                                                <div>
                                                                    <asp:RequiredFieldValidator ID="rfvUserNotes" runat="server" ErrorMessage="" ControlToValidate="txtUserNotes"
                                                                        CssClass="errorMsg box" Display="Dynamic" Style="width: auto; padding-left: 4px;
                                                                        padding-right: 4px;" ForeColor=""><%=objLanguage.GetLanguageConversion("Please_Enter_Note")%></asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td align="right">
                                                                <div style="float: left" align="right">
                                                                    <asp:Button ID="RadButton1" runat="server" EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                                                                        CssClass="Button" Text="Cancel" CommandName="Cancel" CausesValidation="False">
                                                                    </asp:Button>
                                                                    <asp:Button ID="btnOk" runat="server" EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false"
                                                                        CssClass="Button" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                    </asp:Button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                    <HeaderTemplate>
                                                        <div class="absmiddle">
                                                            &nbsp;</div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="margin-left: -2px">
                                                            <asp:PlaceHolder ID="plh_IsError" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn UniqueName="Description" HeaderText="Notes" DataField="Description"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true">
                                                    <HeaderStyle Width="45%" Wrap="true"></HeaderStyle>
                                                    <ItemStyle Width="45%" Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="Type" HeaderText="Type" DataField="Type" HeaderStyle-Font-Bold="true"
                                                    ItemStyle-Wrap="true">
                                                    <HeaderStyle Width="15%" Wrap="true"></HeaderStyle>
                                                    <ItemStyle Width="15%" Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="CreateUser" HeaderText="User" DataField="CreateUser"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true">
                                                    <HeaderStyle Width="15%" Wrap="true"></HeaderStyle>
                                                    <ItemStyle Width="15%" Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="CreateDate" HeaderText="Created Date" DataField="CreateDate"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true">
                                                    <HeaderStyle Width="15%" Wrap="true"></HeaderStyle>
                                                    <ItemStyle Width="15%" Wrap="true" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="NoteType" HeaderText="NoteType" DataField="NoteType"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" Visible="false">
                                                    <HeaderStyle Width="15%" Wrap="true"></HeaderStyle>
                                                    <ItemStyle Width="15%" Wrap="true" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="estimates_notes_select_PerItem"
                                        TypeName="Printcenter.UI.Estimates.EstimateBasePage">
                                    </asp:ObjectDataSource>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</div>
<div id="div_ActivityHistory_add" style="display: none; position: absolute; z-index: 100;
    width: 50%">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                    padding-left: 1px">
                    <b>Add New Note</b>
                    <asp:Label ID="Label2" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:hideDiv('div_ActivityHistory_add');return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" src="../js/HelpText/Mask.js?VN='<%=VersionNumber%>'"></script>
<script>

    function MakeMaskShow_Notes() {
        var w = 734; var h = 400;
        displayCommon_first('div_notes', w, h);
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
    
</script>
