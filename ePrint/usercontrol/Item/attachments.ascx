<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="attachments.ascx.cs" Inherits="ePrint.usercontrol.Item.attachments" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="../js/item/general.js?VN='<%=VersionNumber%>'"></script>
<div id="div_attachments" align="left" style="width: 100%; height: 100%; border: 0px solid red;">
    <telerik:RadAjaxManager ID="ajaxMngr_Attch" runat="server">
        <AjaxSettings>
            <%--            <telerik:AjaxSetting AjaxControlID="btnUpload">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Specific" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadStrp_Attch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStrp_Attch" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage_Attach" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage_Attach">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStrp_Attch" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage_Attach" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <%--<div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" style="float: left;" nowrap="nowrap">
                        <span class="navigatorpanel">
                            <%#objLanguage.GetLanguageConversion("Attachments")%></span>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div align="left" style="width: 100%">
        <div style="width: 100%; margin-left: 10px;">
            <asp:UpdatePanel ID="UPMessage" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div>
        <%--class="borderWithoutTop"--%>
        <div style="padding-left: 5px; width: 99%; padding-top: 8px;">
            <div id="Div_Attach" runat="server">
                <div id="Div1">
                    <div class="exampleWrapper">
                        <telerik:RadTabStrip ID="RadStrp_Attch" runat="server" MultiPageID="RadMultiPage_Attach"
                            AutoPostBack="true" OnTabClick="RadStrp_Attch_OnTabClick" SelectedIndex="1">
                            <Tabs>
                                <telerik:RadTab Text="General" Width="150px" Font-Bold="true" PageViewID="RPV_General"
                                    SelectedIndex="0" ToolTip="Select General">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Item Specific" Width="150px" Font-Bold="true" PageViewID="RPV_Specific"
                                    Selected="true" SelectedIndex="1" ToolTip="Select Item Specific">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                    <div align="left" class="divBorderItem" style="border-color: #BDBDBD;">
                        <%----%>
                        <div id="Div2" style="width: 100%;">
                            <div id="div_MainExp" runat="server" style="border: none;">
                                <telerik:RadMultiPage ID="RadMultiPage_Attach" SelectedIndex="1" RenderSelectedPageOnly="true"
                                    runat="server">
                                    <telerik:RadPageView ID="RPV_General" runat="server" BorderWidth="0" TabIndex="0"
                                        Height="99%">
                                        <div style="padding: 3px 0px 2px 2px;">
                                            <asp:LinkButton ID="linkAdd_Gen" runat="server" CssClass="Normaltext" Font-Bold="true"
                                                ForeColor="Black" OnClientClick="javascript:lnk_AddNewGen_Click(); return false;"
                                                Style="display: none;" ToolTip="Click to add new file">Add New File(s)</asp:LinkButton>
                                        </div>
                                        <div id="Div_GeneralAdd" style="display: none;">
                                            <table border="0" cellpadding="2" width="99%">
                                                <tr>
                                                    <td style="float: left; padding-left: 10px;">
                                                        <asp:Label ID="lbltxt" runat="server" CssClass="normaltext" Font-Bold="true" Text="Attach New File(s)"></asp:Label>
                                                    </td>
                                                    <%--  <tr>
                                                    <td>
                                                      <asp:CheckBox ID="chk_displayFileToPdf" runat="server"></asp:CheckBox>
                                                      <asp:Label ID="lbl_displayFileToPdf" runat="server" CssClass="normaltext" Style="margin-left: -5px;">Display This File to PDF </asp:Label>
                                                   </td>
                                                 </tr>--%>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="content">
                                                            <div id="padding">
                                                                <div id="Div5" runat="server" align="left" style="width: 100%; margin-left: 8px;">
                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload4" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                                                        </div>
                                                                        <div style="float: left; width: 10px">
                                                                            &nbsp;&nbsp;
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            &nbsp;&nbsp;<span id="Spn_errorr" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_File_To_Upload")%></span>
                                                                        </div>
                                                                        <div align="left">
                                                                        </div>
                                                                        <div id="div6" style="float: left; display: none">
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="HiddenField2" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID4" runat="server" Value="0" />
                                                                        </div>
                                                                        <span id="spn_ErrIsvalidGen" class="spanerrorMsg" style="display: none; width: 380px">Please Do not upload exe, asp, aspx, php, html,, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload5" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="HiddenField4" runat="server" Value="" />
                                                                        </div>
                                                                        <div style="float: left; width: 10px">
                                                                            &nbsp;&nbsp;
                                                                        </div>
                                                                        <div id="div7" style="float: left; display: none">
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="HiddenField5" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID5" runat="server" Value="0" />
                                                                        </div>
                                                                        <span id="spn_Error2" class="spanerrorMsg" style="display: none; width: 330px">Please
                                                                            Do not upload exe, asp, aspx,php, html, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload6" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="HiddenField7" runat="server" />
                                                                        </div>
                                                                        <div id="div8" style="float: left; display: none">
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="HiddenField8" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID6" runat="server" Value="0" />
                                                                        </div>
                                                                        <span id="spn_Error3" class="spanerrorMsg" style="display: none; width: 330px">Please
                                                                            Do not upload exe, asp, aspx,php, html, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="margin-left: -6px; margin-top: 5px">
                                                                        <asp:CheckBox ID="chkPreflightGeneral" runat="server" Text="Preflight Files"></asp:CheckBox>
                                                                        <asp:DropDownList ID="ddlPreflightGeneral" runat="server" Style="margin-top: -5px; width: 185px;">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div style="clear: both">
                                                                    &nbsp;&nbsp;
                                                                </div>
                                                                <div style="float: left; border: 0px solid red; margin-left: 18.5%;">
                                                                    <div style="display: inline; float: left">
                                                                        <asp:Button ID="btn_Cancel" runat="server" CssClass="button" OnClientClick="javascript:btn_CancelGen();return false;"
                                                                            Text="Cancel" Width="65px" />
                                                                    </div>
                                                                    <div style="display: inline; float: right; margin-left: 6px;">
                                                                        <div id="div_btnupload" style="display: block;">
                                                                            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="btnUpload_OnClick_General"
                                                                                OnClientClick="javascript:var a=uploadCheck_General();if(a!=false)loadingimage(this.id,'div_btnuploadprocess');return a;"
                                                                                Text="Upload" />
                                                                        </div>
                                                                        <div id="div_btnuploadprocess" style="display: none">
                                                                            <asp:Image ID="imgloading" runat="server" AlternateText="loading" ImageUrl="~/images/radimg1.gif"
                                                                                Style="margin-top: -2px" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div style="clear: both">
                                                                    &nbsp;&nbsp;
                                                                </div>
                                                                <div style="clear: both">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                            <telerik:RadGrid ID="RadGrid_General" runat="server" AllowFilteringByColumn="false"
                                                AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true"
                                                OnItemDataBound="RadGridGenerealOne_OnItemDataBound" OnNeedDataSource="RadGrid_General_OnNeedDataSource"
                                                PagerStyle-AlwaysVisible="true" PageSize="50" ShowStatusBar="true" Visible="true"
                                                Width="100%" Style="background: no-repeat;">
                                                <MasterTableView CommandItemDisplay="Top" Width="100%">
                                                    <%--DataKeyNames="AttachmentID"--%><CommandItemTemplate>
                                                        <div id="DivAddNew" runat="server">
                                                            <table border="0" class="rgCommandTable" style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Image ID="Image_Attachment" runat="server" ImageUrl="~/images/plus.gif" onclick="return AddnewFile_General();"
                                                                            Style="cursor: pointer" ToolTip="Add new file" Visible="true" />
                                                                        <a href="javascript:void(0);" onclick="return AddnewFile_General();"
                                                                                style="padding-left: 5px;"><%#objLanguage.GetLanguageConversion("Add_New_Record")%></a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                                            <HeaderTemplate>
                                                                <input id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input id="Id1" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.AttachmentID", "{0}") %>' />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" DataField="FileName" HeaderStyle-Width="45%"
                                                            HeaderText="File Name" ItemStyle-Width="45%" SortExpression="FileName" UniqueName="FileName">
                                                            <ItemTemplate>
                                                                <div style="float: left; width: 99%; overflow: hidden; min-height: 18px;">
                                                                    <asp:LinkButton ID="lbl_FileName" runat="server" Style="display: none;" Text='<%#Eval("OriginalFileName")%>'></asp:LinkButton>
                                                                    <a id="ancFileName" href="#" name='<%#Eval("OriginalFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("FileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                                        title='<%#Eval("OriginalFileName")%>'>
                                                                        <%#Eval("OriginalFileName")%></a><br />
                                                                    <a id="ancReportFileName" href="#" name='<%#Eval("ReportFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("ReportFileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                                        title='<%#Eval("ReportFileName")%>'><%# (String.IsNullOrEmpty(Eval("ReportFileName").ToString()) ? "" : "Report File.pdf")%></a>
                                                                    <asp:HiddenField ID="hdn_ActualFileName" runat="server" Value='<%#Eval("FileName")%>' />
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" DataField="UserName" HeaderStyle-Width="20%"
                                                            HeaderText="Uploaded By" ItemStyle-Width="20%" SortExpression="UserName" UniqueName="UserName">
                                                            <ItemTemplate>
                                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                                    <asp:Label ID="lbl_UplBy" runat="server"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.UserName", "{0}"))%></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" DataField="CreatedDate" HeaderStyle-Width="20%"
                                                            HeaderText="Uploaded On" ItemStyle-Width="20%" SortExpression="CreatedDate" UniqueName="CreatedDate">
                                                            <ItemTemplate>
                                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                                    <asp:Label ID="lbl_UpldOn" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedDate", "{0}") %>'></asp:Label><%--<asp:HiddenField ID="Upld_DateGen" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.CreatedDate", "{0}") %>' />--%><%--<%#Eval("CreatedDate")%>--%>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="10%" HeaderText="Action"
                                                            ItemStyle-Width="10%">
                                                            <HeaderTemplate>
                                                                <div style="margin-left: 5%;">
                                                                    <asp:Label ID="Label" runat="server" Text="Action"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="margin-left: 15%;">
                                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("AttachmentID")%>'
                                                                        ImageUrl="~/Images/erase.png" OnClientClick="javascript:return imgdelete();"
                                                                        OnCommand="imgbtnDelete_OnClick_General" ToolTip="Delete" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <EditFormSettings EditFormType="Template">
                                                        <FormTemplate>
                                                        </FormTemplate>
                                                    </EditFormSettings>
                                                </MasterTableView><ClientSettings Scrolling-AllowScroll="true">
                                                    <Scrolling AllowScroll="true" ScrollHeight="250" UseStaticHeaders="true" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                            <%--   <asp:UpdatePanel ID="Up_general" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                <ContentTemplate>--%>
                                        </div>
                                        <div style="padding: 5px 0px 0px 2px;">
                                            <div id="div_cancel" runat="server" style="float: left; margin: 0px 10px 0px 0px;">
                                                <div id="div_btncancel_Itm" style="display: block">
                                                    <asp:Button ID="btncancel_Itm" runat="server" CommandName="Cancel" CssClass="button"
                                                        OnClientClick="javascript:loadingimg('div_btncancel_Itm','div_btncancel_Itm_process');Close_wind();"
                                                        Text="Cancel" />
                                                </div>
                                                <div id="div_btncancel_Itm_process" align="center" class="button" style="width: 42px; display: none">
                                                    <img alt="loading" border="0" class="trans" src="<%=strImagepath %>radimg1.gif" />
                                                </div>
                                            </div>
                                            <div style="float: left; margin: 0px 10px 0px 0px;">
                                                <div id="div_btndelete" style="display: block">
                                                    <asp:Button ID="btn_Delete" runat="server" CssClass="button" OnClick="DeleteSelected_OnClick"
                                                        OnClientClick="javascript:var a=CallDelete();if(a)loadingimage(this.id,'div_deleteprocess');return a;"
                                                        Text="Delete" />
                                                    <asp:Button ID="btn_AttachGeneral" runat="server" CssClass="button" OnClick="EmailAttach_OnClick"
                                                        OnClientClick="javascript:var a=Email_Attachment(); return a;" Text="Attach as Attachment"
                                                        Visible="true" />
                                                    <asp:Button ID="btn_AttachLinkGeneral" runat="server" CssClass="button" OnClick="GeneralEmailAttachLink_Onclick"
                                                        OnClientClick="javascript:var a=Email_Attachment(); return a;" Text="Attach as Link"
                                                        Visible="true" />
                                                </div>
                                                <div id="div_deleteprocess" style="display: none">
                                                    <asp:Image ID="Image1" runat="server" AlternateText="loading" ImageUrl="~/images/radimg1.gif"
                                                        Style="margin-top: -2px" />
                                                </div>
                                            </div>
                                        </div>
                                    </telerik:RadPageView>
                                    <%--Item Specific--%>
                                    <telerik:RadPageView ID="RPV_Specific" runat="server" TabIndex="1">
                                        <div style="padding: 3px 0px 2px 2px;">
                                            <asp:LinkButton ID="lnk_AddNew" runat="server" CssClass="Normaltext" Font-Bold="true"
                                                ForeColor="Black" OnClientClick="javascript:lnk_AddNew_Click(); return false;"
                                                Style="display: none;" ToolTip="Click to add new file">Add New File(s)</asp:LinkButton>
                                        </div>
                                        <div id="Div_IS" runat="server" style="display: none;">
                                            <table border="0" cellpadding="2" width="100%">
                                                <tr>
                                                    <td style="float: left; padding-left: 9px;">
                                                        <asp:Label ID="Label1" runat="server" CssClass="normaltext" Font-Bold="true"><%=objLanguage.GetLanguageConversion("Attach_New_Files") %></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="Div_Labels" runat="server" visible="true">
                                                            <table>
                                                                <tr style="float: left; margin-left: 2px;">
                                                                    <td>
                                                                        <asp:Label ID="lbl_FS" runat="server" CssClass="normaltext" Font-Bold="true"><%=objLanguage.GetLanguageConversion("File_Specific_To") %></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbl_ItemSpecific" runat="server" Width="100%"></asp:Label>
                                                                        <asp:DropDownList ID="ddl_Specific" runat="server" onchange="javascript:onchange_ddlSpecific(this,this.value);" AutoPostBack="True" OnSelectedIndexChanged="ddl_Specific_SelectedIndexChanged"
                                                                            Width="480px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chk_displayFileToEstore" runat="server"></asp:CheckBox>
                                                                        <asp:Label ID="lbl_displayFileToEstore" runat="server" CssClass="normaltext" Style="margin-left: -5px;"> <%=objLanguage.GetLanguageConversion("Display_This_File_To_eStore_User") %></asp:Label>
                                                                    </td>
                                                                </tr>
                                                        <td>
                                                            <asp:CheckBox ID="chk_IsAttachProof" runat="server"></asp:CheckBox>
                                                            <asp:Label ID="lbl_IsAttachProof" runat="server" CssClass="normaltext" Style="margin-left: -5px;"> <%=objLanguage.GetLanguageConversion("Attached_With_Proof") %></asp:Label>
                                                        </td>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chk_displayFileToPdf" runat="server"></asp:CheckBox>
                                                            <asp:Label ID="lbl_displayFileToPdf" runat="server" CssClass="normaltext" Style="margin-left: -5px;">Display This File to PDF </asp:Label>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </div>
                                        </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="content">
                                                            <div id="padding">
                                                                <div id="Div_Upload" runat="server" align="left" style="width: 100%">
                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="hdn_FileUpload1" runat="server" Value="" />
                                                                        </div>
                                                                        <div style="float: left; width: 10px">
                                                                            &nbsp;&nbsp;
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            &nbsp;&nbsp;<span id="Spn_errorr1" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_File_To_Upload")%></span>
                                                                            &nbsp;&nbsp;<span id="Spn_SameNameFileErorr" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Proof_Attachment_Already_Exist")%></span>
                                                                        </div>
                                                                        <div align="left">
                                                                        </div>
                                                                        <div id="div_FileName1" style="float: left; display: none">
                                                                            <asp:LinkButton ID="lnkbtnFileName1" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="plhOldFiles1" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="hid_FileName1" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID1" runat="server" Value="0" />
                                                                            <asp:HiddenField ID="hid_displaytoestore" runat="server" Value="" />
                                                                        </div>
                                                                        <span id="spn_ErrIsvalidIS" class="spanerrorMsg" style="display: none; width: 380px;">Please Do not upload exe, php, asp, aspx, html, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="hdn_FileUpload2" runat="server" Value="" />
                                                                        </div>
                                                                        <div style="float: left; width: 10px">
                                                                            &nbsp;&nbsp;
                                                                        </div>
                                                                        <div id="div_FileName2" style="float: left; display: none">
                                                                            <asp:LinkButton ID="lnkbtnFileName2" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="plhOldFiles2" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="hid_FileName2" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID2" runat="server" Value="0" />
                                                                        </div>
                                                                        <span id="spn_Error2" class="spanerrorMsg" style="display: none; width: 330px">Please
                                                                            Do not upload exe, php, asp, aspx, html, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>

                                                                    <div align="left">
                                                                        <div style="float: left">
                                                                            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="textboxnew" size="43px"
                                                                                Width="300px" />
                                                                            <asp:HiddenField ID="hdn_FileUpload3" runat="server" />
                                                                        </div>
                                                                        <div id="div_FileName3" style="float: left; display: none">
                                                                            <asp:LinkButton ID="lnkbtnFileName3" runat="server" Style="text-decoration: underline"></asp:LinkButton>
                                                                            <asp:PlaceHolder ID="plhOldFiles3" runat="server"></asp:PlaceHolder>
                                                                            <asp:HiddenField ID="hid_FileName3" runat="server" Value="" />
                                                                            <asp:HiddenField ID="hid_AttachmentID3" runat="server" Value="0" />
                                                                        </div>
                                                                        <span id="spn_Error3" class="spanerrorMsg" style="display: none; width: 330px">Please
                                                                            Do not upload exe, php, asp, aspx, html, dll, jar types of files</span>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="margin-left: -6px; margin-top: 5px">
                                                                        <asp:CheckBox ID="chkPreflightItem" runat="server" Text="Preflight Files"></asp:CheckBox>
                                                                        <asp:DropDownList ID="ddlPreflightItem" runat="server" Style="margin-top: -5px; width: 485px;">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div style="clear: both">
                                                                    &nbsp;&nbsp;
                                                                </div>
                                                                <div style="float: left; margin-left: 17.5%;">
                                                                    <div style="display: inline; float: left">
                                                                        <asp:Button ID="btn_CancelGen" runat="server" CssClass="button" OnClientClick="javascript:btn_Cancel();return false;"
                                                                            Text="Cancel" Width="65px" />
                                                                    </div>
                                                                    <div style="display: inline; float: left; margin-left: 6px;">
                                                                        <div id="div_btnuploaditem" style="display: block; width: 65px;">
                                                                            <asp:Button ID="btnUpload" runat="server" CssClass="button" OnClick="btnUpload_OnClick_Specific"
                                                                                OnClientClick="javascript:var a=uploadCheck_Specific();if(a!=false)loadingimage(this.id,'div_btnuploaditemprocess');return a;"
                                                                                Text="Upload" />
                                                                        </div>
                                                                        <div id="div_btnuploaditemprocess" style="display: none">
                                                                            <asp:Image ID="Image2" runat="server" AlternateText="loading" ImageUrl="~/images/radimg1.gif"
                                                                                Style="margin-top: -2px" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div style="clear: both">
                                                                &nbsp;&nbsp;
                                                            </div>
                                                            <div style="clear: both">
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                </table>
                            </div>
                            <div style="text-align: left; margin-bottom: 10px" runat="server">
                                <asp:Label runat="server" Text="Status" ID="statuslbl" Visible="false" Style="padding-right: 10px; font-weight: bold"></asp:Label>
                                <asp:DropDownList ID="proof_status" Visible="false" DataTextField="TextFieldValue" DataValueField="ValueFieldValue" runat="server" Style="width: 20%;">
                                </asp:DropDownList>
                            </div>
                            <div style="text-align: left; margin-bottom: 10px" id="ErrorDiv" Visible="false" runat="server">
                                &nbsp;&nbsp;<span id="Spn_errorr2" class="spanerrorMsg" style=" width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_File_To_Update_Proof")%></span>
                            </div>

                             <div style="text-align: left; margin-bottom: 10px" id="DivSelect1" Visible="false" runat="server">
                                &nbsp;&nbsp;<span id="Spn_errorr3" class="spanerrorMsg" style=" width: auto; padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("Please_Select_1_File_To_Update_Proof")%></span>
                            </div>
                            <telerik:RadGrid ID="RadGrid_Specific" runat="server" AllowCustomPaging="false" AllowPaging="false"
                                AllowSorting="false" AutoGenerateColumns="false" HeaderStyle-Font-Bold="true"
                                OnItemDataBound="RadGridGenereal_OnItemDataBound" OnNeedDataSource="RadGrid_Specific_OnNeedDataSource"
                                PagerStyle-AlwaysVisible="true" PageSize="50" ShowStatusBar="true" Visible="true"
                                Width="100%" Style="background: no-repeat;">
                                <MasterTableView CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <div id="DivAddNewRecords" runat="server">
                                            <table border="0" class="rgCommandTable" style="width: 100%;">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Image ID="Image_Attachment" runat="server" ImageUrl="~/images/plus.gif" onclick="return AddnewFile_Specific();"
                                                            Style="cursor: pointer" ToolTip="Add new file" Visible="true" />
                                                        <a href="javascript:void(0);" onclick="return AddnewFile_Specific();"
                                                                style="padding-left: 5px;">Add new record</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="5%" ItemStyle-Width="5%">
                                            <HeaderTemplate>
                                                <input id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input id="Id1" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.AttachmentID", "{0}") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="FileName" HeaderStyle-Width="35%" HeaderText="File Name"
                                            ItemStyle-Width="35%" SortExpression="FileName" UniqueName="FileName">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; min-height: 18px;">
                                                    <asp:LinkButton ID="lbl_FileName" runat="server" Style="display: none;" Text='<%#Eval("OriginalFileName")%>'></asp:LinkButton>
                                                    <a id="ancFileName" href="#" name='<%#Eval("OriginalFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("FileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                        title='<%#Eval("OriginalFileName")%>'>
                                                        <%#Eval("OriginalFileName")%></a><br />
                                                    <a id="ancReportFileName" href="#" name='<%#Eval("ReportFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("ReportFileName")%>&#039,&#039;<%#Eval("IsEdtiablePDF")%>&#039;);'
                                                        title='<%#Eval("ReportFileName")%>'>
                                                        <%# (String.IsNullOrEmpty(Eval("ReportFileName").ToString()) ? "" : "Report File.pdf") %></a>
                                                    <asp:HiddenField ID="hdn_ActualFileName" runat="server" Value='<%#Eval("FileName")%>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Title" HeaderStyle-Width="20%" ItemStyle-Width="20%"
                                            SortExpression="Title" UniqueName="Title" Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_Title1" runat="server" Visible="true"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.ModuleNumber", "{0}"))%></asp:Label><%----%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="EstimateTitle" HeaderStyle-Width="20%" HeaderText="Item Title"
                                            ItemStyle-Width="20%" SortExpression="EstimateTitle" UniqueName="EstimateTitle"
                                            Visible="true">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_ItemTitle" runat="server" Visible="true"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.EstimateTitle", "{0}"))%></asp:Label><%----%>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="UserName" HeaderStyle-Width="15%" HeaderText="Uploaded By"
                                            ItemStyle-Width="15%" SortExpression="UserName" UniqueName="UserName">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_UplBy" runat="server"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.UserName", "{0}"))%></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="CreatedDate" HeaderStyle-Width="17%" HeaderText="Uploaded On"
                                            ItemStyle-Width="17%" SortExpression="CreatedDate" UniqueName="CreatedDate">
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden;">
                                                    <asp:Label ID="lbl_UpldOn" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedDate", "{0}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="7%" HeaderText="Action" ItemStyle-Width="7%">
                                            <HeaderTemplate>
                                                <div style="margin-left: 5%;">
                                                    <asp:Label ID="Label" runat="server" Text="Action"></asp:Label>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="margin-left: 15%;">
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("AttachmentID")%>'
                                                        ImageUrl="~/Images/erase.png" OnClientClick="javascript:return imgdelete();"
                                                        OnCommand="imgbtnDelete_OnClick_Specific" ToolTip="Delete" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings EditFormType="Template">
                                        <FormTemplate>
                                        </FormTemplate>
                                    </EditFormSettings>
                                </MasterTableView><ClientSettings Scrolling-AllowScroll="true">
                                    <Scrolling AllowScroll="true" ScrollHeight="250" UseStaticHeaders="true" />
                                </ClientSettings>
                            </telerik:RadGrid>
                            <div id="div9" style="padding: 5px 0px 2px 2px;">
                                <div id="div_delspecific" style="display: block">
                                    <div id="div3" runat="server" style="float: left; margin: 0px 10px 0px 0px;">

                                        <%--   <div id="div_btnupdate">
                                                        
                                                    </div>--%>

                                        <div id="div_btncancel_Genrl" style="display: block">
                                           
                                           
                                        </div>
                                        <%--  <div id="div_btncreate_proof" style="display: block">
                                                      
                                                    </div>--%>
                                        <div id="div_btncancel_Genrl_process" align="center" class="button" style="width: 42px; display: none">
                                            <img alt="loading" border="0" class="trans" src="<%=strImagepath %>radimg1.gif" />
                                        </div>
                                    </div>
                                    <div style="float: left; margin: 0px 10px 0px 0px;">
                                         <asp:Button ID="btn_delSpecific" runat="server" Style="margin-right: 6px" CssClass="button" OnClick="DeleteSelected_ItemSpcfc_OnClick"
                                            OnClientClick="javascript:var a= CallDelete();if(a)loadingimage(this.id,'div_delspecificprocess');return a;"
                                            Text="Delete" />

                                        <asp:Button ID="btnclose" runat="server" Style="margin-right: 6px;" Visible="false" CssClass="button"
                                            OnClientClick="closepopup()"
                                            Text="Close" />

                                         <asp:Button ID="btncancel_Genrl" runat="server" Style="margin-right: 6px" CommandName="Cancel" CssClass="button"
                                                OnClientClick="javascript:loadingimg('div_btncancel_Genrl','div_btncancel_Genrl_process');closepopup();"
                                                Text="Cancel" />
                                        
                                        <asp:Button ID="btn_downloadAll" runat="server" Style="margin-right: 6px" CssClass="button" Visible="false" OnClick="DownloadAll_OnClick"
                                           Text="Download Selected" />

                                        <asp:Button ID="btncreate_proof" runat="server" Style="margin-right: 6px" Visible="false" CssClass="button"
                                            OnClick="Create_proof_OnClick"
                                            Text="Create Proof" />

                                         <asp:Button ID="btnupdate" runat="server" Style="margin-right: 6px" Visible="false" CssClass="button"
                                                OnClick="update_proof_OnClick" Text="Update" />

                                       
                                        <asp:Button ID="btn_AttachIS" runat="server" CssClass="button" OnClick="EmailAttach_ItemSpecific_OnClick"
                                            OnClientClick="javascript:var a=Email_Attachment(); return a;" Text="Attach as Attachment"
                                            Visible="true" />
                                        <asp:Button ID="Btn_ISAttachLink" runat="server" CssClass="button" OnClick="ISEmail_AttachLink_OnClick"
                                            OnClientClick="javascript:var a=Email_Attachment(); return a;" Text="Attach as Link"
                                            Visible="true" />
                                        <div id="div_delspecificprocess" style="display: none;">
                                            <asp:Image ID="Image3" runat="server" AlternateText="loading" ImageUrl="~/images/radimg1.gif"
                                                Style="margin-top: -2px" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            </telerik:RadPageView>
                                </telerik:RadMultiPage>
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div class=" only5px">
            </div>
        </div>
    </div>
</div>
<div style="clear: both;">
</div>
</div>
<div id="Div_Attachment" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="300" Height="250" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdn_ddlEstitemID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ddlEstType" runat="server" Value="" />
<asp:HiddenField ID="hdn_AttachFileSupRFQ_Gen" runat="server" Value="" />
<asp:HiddenField ID="hdn_IsPreFlightEnabled" runat="server" Value="0" />
<asp:Panel ID="pnlWinClose" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
            return oWindow;
        }

        setTimeout("CloseOnReload()", 000);

        function CloseOnReload() {
            GetRadWindow().Close();
        }
    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">

    function TakeOut() {
        window.close();
    }



    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

</script>
<asp:Panel ID="pnlLoadonEdit" runat="server" Visible="false">
    <script type="text/javascript">
        function ShowDivOnEdit() {
            var mode = '<%=Mode %>';
            if (mode == 'edit') {
                document.getElementById("div_FileName1").style.display = "block";
                document.getElementById("div_FileName2").style.display = "block";
                document.getElementById("div_FileName3").style.display = "block";
            }
        }
        ShowDivOnEdit();
    </script>
</asp:Panel>
<asp:Label ID="lblGetID" runat="server"></asp:Label>
<script type="text/javascript" src="<%#strSitepath%>js/HelpText/Mask.js?VN='<%#VersionNumber%>'"></script>
<script>
    var hdn_ddlEstitemID = document.getElementById("<%=hdn_ddlEstitemID.ClientID %>");
    var hdn_ddlEstType = document.getElementById("<%=hdn_ddlEstType.ClientID %>");
    var chkPreflightItem = document.getElementById("<%=chkPreflightItem.ClientID %>");
    var ddlPreflightItem = document.getElementById("<%=ddlPreflightItem.ClientID %>");
    var chkPreflightGeneral = document.getElementById("<%=chkPreflightGeneral.ClientID %>");
    var ddlPreflightGeneral = document.getElementById("<%=ddlPreflightGeneral.ClientID %>");
    var hdn_IsPreFlightEnabled = document.getElementById("<%= hdn_IsPreFlightEnabled.ClientID %>");
    var ArrEstType = new Array();
    var EstimateType = '<%=EstimateType %>';

    function onchange_ddlSpecific(objddl, ddlval) {

        hdn_ddlEstitemID.value = ddlval;
        var str = EstimateType.split('‡');
        for (var i = 0; i < str.length - 1; i++) {
            ArrEstType.push(str[i]);
            hdn_ddlEstType.value = ArrEstType[objddl.selectedIndex];
        }
    }

    function lnk_AddNew_Click() {
        var Div_IS = document.getElementById("<%=Div_IS.ClientID %>");
        var lnk_AddNew = document.getElementById("<%=lnk_AddNew.ClientID %>");
        lnk_AddNew.style.display = "none";
        Div_IS.style.display = "block";
    }
    function btn_Cancel() {
        var btn_Cancel = document.getElementById("<%=btn_Cancel.ClientID %>");
        var Div_IS = document.getElementById("<%=Div_IS.ClientID %>");
        var FileUpload1 = document.getElementById("<%=FileUpload1.ClientID %>");
        var FileUpload2 = document.getElementById("<%=FileUpload2.ClientID %>");
        var FileUpload3 = document.getElementById("<%=FileUpload3.ClientID %>");
        var lnk_AddNew = document.getElementById("<%=lnk_AddNew.ClientID %>");
        document.getElementById("Spn_errorr1").style.display = "none";
        document.getElementById("spn_ErrIsvalidIS").style.display = "none";
        Div_IS.style.display = "none";
        lnk_AddNew.style.display = "block";
        FileUpload1.value = '';
        FileUpload2.value = '';
        FileUpload3.value = '';
    }

    function lnk_AddNewGen_Click() {
        var Div_GeneralAdd = document.getElementById("Div_GeneralAdd");
        var linkAdd_Gen = document.getElementById("<%=linkAdd_Gen.ClientID %>");
        Div_GeneralAdd.style.display = "block";
        linkAdd_Gen.style.display = "none";
    }
    function btn_CancelGen() {
        var FileUpload4 = document.getElementById("<%=FileUpload4.ClientID %>");
        var FileUpload5 = document.getElementById("<%=FileUpload5.ClientID %>");
        var FileUpload6 = document.getElementById("<%=FileUpload6.ClientID %>");
        var Div_GeneralAdd = document.getElementById("Div_GeneralAdd");
        var linkAdd_Gen = document.getElementById("<%=linkAdd_Gen.ClientID %>");
        document.getElementById("Spn_errorr").style.display = "none";
        document.getElementById("spn_ErrIsvalidGen").style.display = "none";
        Div_GeneralAdd.style.display = "none";
        linkAdd_Gen.style.display = "none";
        FileUpload4.value = '';
        FileUpload5.value = '';
        FileUpload6.value = '';
    }
</script>
<script type="text/javascript">
    function imgdelete() {
        return confirm("Are you sure you want delete this record?");
    }

    var lblGetID = document.getElementById("<%=lblGetID.ClientID %>").id;
    function MakeMaskShow() {

        var w = 900; var h = 400;
        displayCommon_first('div_attachments', w, h);
    }

    var CheckFinal = false;
    function uploadCheck_Specific() {
        debugger;
        CheckFinal = true;
        //Controls which are inside the RadGrid...
        // var FileUpload1 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload1");
        // var FileUpload2 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload2");
        // var FileUpload3 = document.getElementById("ctl00_ContentPlaceHolder1_ctl00_RadGrid_General_ctl00_ctl02_ctl04_FileUpload3");
        var FileUpload1 = document.getElementById("<%=FileUpload1.ClientID %>");
        var FileUpload2 = document.getElementById("<%=FileUpload2.ClientID %>");
        var FileUpload3 = document.getElementById("<%=FileUpload3.ClientID %>");

        document.getElementById("Spn_errorr1").style.display = "none";
        document.getElementById("spn_ErrIsvalidIS").style.display = "none";

        var queryString = window.location.search;
        var urlParams = new URLSearchParams(queryString);
        var ActionPage = urlParams.get('ActionPage');
        var _action = urlParams.get('action');
        
        if ((ActionPage != null && ActionPage != '') || (_action != null && _action != '')) {
            document.getElementById("Spn_SameNameFileErorr").style.display = "none";
            var columnValue = '';
            var grid = $find('<%= RadGrid_Specific.ClientID %>'); // Get a reference to the RadGrid
            var masterTableView = grid.get_masterTableView(); // Get the master table view
            var rows = masterTableView.get_dataItems(); // Get the rows in the grid
            for (var i = 0; i < rows.length; i++) {
                columnValue = rows[i].get_cell("FileName").innerText;
                columnValue = columnValue.replace('\n', '');
                var upload1 = FileUpload1.value.split("\\");
                var fileName1 = upload1[upload1.length - 1];

                var upload2 = FileUpload2.value.split("\\");
                var fileName2 = upload2[upload2.length - 1];

                var upload3 = FileUpload3.value.split("\\");
                var fileName3 = upload3[upload3.length - 1];

                //columnValue = rows[i].findControl(controlClientId).innerHTML;
                if (fileName1 != "") {
                    if (columnValue == fileName1) {
                        document.getElementById("Spn_SameNameFileErorr").style.display = "block";
                        CheckFinal = false;
                    }
                }
                if (fileName2 != "") {
                    if (columnValue == fileName2) {
                        document.getElementById("Spn_SameNameFileErorr").style.display = "block";
                        CheckFinal = false;
                    }
                }
                if (fileName3 != "") {
                    if (columnValue == fileName3) {
                        document.getElementById("Spn_SameNameFileErorr").style.display = "block";
                        CheckFinal = false;
                    }
                }
               
            }
        }
        


        if (FileUpload1.value == '' && FileUpload2.value == '' && FileUpload3.value == '') {
            document.getElementById("Spn_errorr1").style.display = "block";
            CheckFinal = false;
        }
        if (FileUpload1.value != '') {
            var fileupload = FileUpload1.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                // var SplitedFile = "." + ArrFile[1];
            }
            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload2.value != '') {
            var fileupload = FileUpload2.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload3.value != '') {
            var fileupload = FileUpload3.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                // var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidIS").style.display = "block";
                CheckFinal = false;
            }
        }

        if (CheckFinal) {
            if (hdn_IsPreFlightEnabled.value == "1") {
                if (chkPreflightItem.checked && ddlPreflightItem.options.selectedIndex == 0) {
                    alert('Please select profile');
                    ddlPreflightItem.focus();
                    return false;
                }
            }
            document.getElementById("Spn_errorr1").style.display = "success";
        }
        else {
            return false;
        }
    }
    function getFirstRowColumnValue(columnName) {
        var grid = $find('<%= RadGrid_Specific.ClientID %>'); // Get a reference to the RadGrid
             var masterTableView = grid.get_masterTableView(); // Get the master table view
             var rows = masterTableView.get_dataItems(); // Get the rows in the grid
            for (var i = 0; i < rows.length; i++) {
                var columnValue = rows[i].get_cell(columnName).innerHTML;
            }
    }

    //File Validation for General tab...
    var CheckFinal = false;
    function uploadCheck_General() {

        CheckFinal = true;
        var FileUpload4 = document.getElementById("<%=FileUpload4.ClientID %>");
        var FileUpload5 = document.getElementById("<%=FileUpload5.ClientID %>");
        var FileUpload6 = document.getElementById("<%=FileUpload6.ClientID %>");

        document.getElementById("Spn_errorr").style.display = "none";
        document.getElementById("spn_ErrIsvalidGen").style.display = "none";
        if (FileUpload4.value == '' && FileUpload5.value == '' && FileUpload6.value == '') {
            document.getElementById("Spn_errorr").style.display = "block";
            CheckFinal = false;
        }
        if (FileUpload4.value != '') {
            var fileupload = FileUpload4.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }
            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";

                CheckFinal = false;
            }
        }
        if (FileUpload5.value != '') {
            var fileupload = FileUpload5.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";
                CheckFinal = false;
            }
        }
        if (FileUpload6.value != '') {
            var fileupload = FileUpload6.value;
            var ArrFile = new Array();
            var SplitFile = fileupload.split('.');

            var lastDot = fileupload.lastIndexOf(".");
            var namelength = fileupload.length;
            var SplitedFile = fileupload.substring(lastDot, namelength);

            for (var i = 0; i < SplitFile.length; i++) {
                ArrFile.push(SplitFile[i]);
                //var SplitedFile = "." + ArrFile[1];
            }

            if (SplitedFile.toLowerCase() == ".exe" || SplitedFile.toLowerCase() == ".php" || SplitedFile.toLowerCase() == ".html" || SplitedFile.toLowerCase() == ".aspx" || SplitedFile.toLowerCase() == ".dll" || SplitedFile.toLowerCase() == ".ascx" || SplitedFile.toLowerCase() == ".jar") {
                document.getElementById("spn_ErrIsvalidGen").style.display = "block";
                CheckFinal = false;
            }
        }
        if (CheckFinal) {
            if (hdn_IsPreFlightEnabled.value == "1") {
                if (chkPreflightGeneral.checked && ddlPreflightGeneral.options.selectedIndex == 0) {
                    alert('Please select profile');
                    ddlPreflightGeneral.focus();
                    return false;
                }
            }
            document.getElementById("Spn_errorr").style.display = "success";
        }
        else {
            return false;
        }
    }

    function CheckAll(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                e.checked = ChkState;
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1)
                e.checked = ChkState;
        }
    }
    function checkAll_new(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
        }
    }

</script>
<script>
    function CallDelete() {
        var ret = CheckOne_new();
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }
    function CheckOne_new() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;

                }
            }
        }
        if (Number(Counter) == 0) {
            //alert("Please check at least one 'row' to Delete");
            alert('<%=objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert")%>');
            return false;
        }
        else {
            //return window.confirm('Are you sure you want to delete this record(s)?');
            return window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert")%>');
        }
    }

</script>
<script>
    function Email_Attachment() {
        var ret = CheckOne_newAttach();
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckOne_newAttach() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
        }

        if (Number(Counter) > 0) {
            return true;
        }
        else {
            alert("Please check at least one file to Attach");
            return false;
        }

        var count = Counter;
    }


</script>
<script>
    function Download_Attachment() {
        var ret = CheckOne_downloadAttach();
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckOne_downloadAttach() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
        }

        if (Number(Counter) > 0) {
            return true;
        }
        else {
            alert("Please check at least one file to Download");
            return false;
        }

        var count = Counter;
    }


</script>
<script>
    // Function to view the file...
    function OpenAttach(Obj, Type) {
        debugger;
        var OpenNewInmage = "";
        if (Type == "True") {
            // OpenNewInmage = '<%=StreStorAttach%>' + Obj;
            var ext = Obj.substr(Obj.lastIndexOf('.') + 1);
            if (ext.toLowerCase() == 'png') {
                OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=previewimage&actid=" + '<%=AccountID %>' + "&filename=" + Obj;
            }
            else {
                OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=attachments&filename=" + Obj;
            }
        }
        else {
            // OpenNewInmage = '<%=StrDownload%>' + Obj;
            OpenNewInmage = '<%=strSitepath %>' + "DocManager.ashx?doctype=attachments&filename=" + Obj;
        }
        window.open(OpenNewInmage);
    }
 function DownloadAttachment(Obj,orderNumber, Type) {
        debugger;
        var OpenNewInmage = "";
        if (Type == "True") {
            // OpenNewInmage = '<%=StreStorAttach%>' + Obj;
            var ext = Obj.substr(Obj.lastIndexOf('.') + 1);
            if (ext.toLowerCase() == 'png') {
                OpenNewInmage = '<%=strSitepath %>' + "AttachmentsManager.ashx?doctype=previewimage&actid=" + '<%=AccountID %>' + "&filename=" + Obj;
            }
            else {
                OpenNewInmage = '<%=strSitepath %>' + "AttachmentsManager.ashx?doctype=attachments&filename=" + Obj + "&ordernumber=" + orderNumber;
            }
        }
        else {
            // OpenNewInmage = '<%=StrDownload%>' + Obj;
            OpenNewInmage = '<%=strSitepath %>' + "AttachmentsManager.ashx?doctype=attachments&filename=" + Obj + "&ordernumber=" + orderNumber;
        }
        window.open(OpenNewInmage);
    }

    window.onload = function () {
        debugger;
        var url_string = window.location.href;
        var url = new URL(url_string);
        var actionParms = url.searchParams.get("action");
        //var currentURL = window.Location.href;
        if (actionParms != null) {
            AddnewFile_Specific();
        }
    };

    function closepopup() {
        debugger;
        window.parent.location.reload();
        window.close();
        //opener.location.reload();
        //parent.location.reload(true);
    }
    function AddnewFile_General() {
        debugger;
        var Div_GeneralAdd = document.getElementById("Div_GeneralAdd");
        var linkAdd_Gen = document.getElementById("<%=linkAdd_Gen.ClientID %>");
        Div_GeneralAdd.style.display = "block";
        linkAdd_Gen.style.display = "none";
        return false; // ⛔ prevents link navigation or scroll
        
    }
    function AddnewFile_Specific() {
        var Div_IS = document.getElementById("<%=Div_IS.ClientID %>");
        var lnk_AddNew = document.getElementById("<%=lnk_AddNew.ClientID %>");
        lnk_AddNew.style.display = "none";
        Div_IS.style.display = "block";
        return false; // ⛔ prevents link navigation or scroll
    }

</script>
<script>
    function GetAttachments(Attached, ActualFiles) {
        var MainContainerID = "<%=AttachImageID%>";
        MainContainerID = MainContainerID.replace("Image_Attachment", "Div_Attach");
        var Div_Attach = window.parent.frames[0].document.getElementById(MainContainerID); //parent.window.document.getElementById(MainContainerID);
        var StrChckbox = '';
        var StrAttach = Attached.split('‡');
        var StrActual = ActualFiles.split('‡');
        for (var i = 0; i < StrAttach.length - 1; i++) {
            var Attach = StrAttach[i];
            var ActualFile = StrActual[i];
            StrChckbox += "<div align='left' style='float:left; border:0px solid red; clear: both; width:500px;'>";
            StrChckbox += "<input type='checkbox'  id='Chk_Attach_" + i + "' value='" + ActualFile + "' title='" + Attach + "' checked='checked' style='float:left; display:block;'/>" + Attach + "";
            StrChckbox += "</div>";
        }
        Div_Attach.innerHTML += StrChckbox;
    }

    function EnablePreFlightDdl(chkPreFlight, ddlPreFlight) {
        if (chkPreFlight.checked) {
            ddlPreFlight.disabled = false;
        }
        else {
            ddlPreFlight.disabled = true;
        }
    }
</script>
<asp:Panel ID="Pnl_AttachLinkForSupplier" runat="server" Visible="false">
    <script>

        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        var MainContainerID = "<%=AttachImageID%>";
        var Str_AttachPath = '<%=StrDownload%>';
        window.parent.frames[0].GetAttachLink_Supplier(AttachedSupRFQ, ActualSupRFQ, MainContainerID, Str_AttachPath);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttacClose" runat="server" Visible="false">
    <script>
        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        GetAttachments(AttachedSupRFQ, ActualSupRFQ);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttachCustomer" runat="server" Visible="false">
    <script>
        var AttachedSupRFQ = '<%=AttachSupRFQ %>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        window.parent.frames[0].BindAttachmentsForActual(AttachedSupRFQ, ActualSupRFQ);

    </script>
</asp:Panel>
<asp:Panel ID="pnl_AttachLinkCustomer" runat="server" Visible="false">
    <script>
        var CheckedAttachLink = '<%=AttachSupRFQ%>';
        var ActualSupRFQ = '<%=ActualSupRFQ %>';
        window.parent.frames[0].BindAttachment_Link(CheckedAttachLink, ActualSupRFQ);
    </script>
</asp:Panel>
<asp:Panel ID="pnl_WindowClose" runat="server" Visible="false">
    <script>
        setTimeout("TakeOut()", 700);
        function TakeOut() {
            window.close();
        }
    </script>
</asp:Panel>
<asp:Panel ID="pnl_CloseWebstore" runat="server" Visible="false">
    <script>
        //        RefreshParentPage();
        //        function RefreshParentPage() {
        //            var win = window.radWindow.radWindow;
        //        alert(win);
        //        win.radWindow.Reload();
        //           
        //        }

        //        function GetRadWindow() {
        //            var oWindow = null;
        //            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        //            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
        //            return oWindow;
        //        }  




        //        parent.location.reload(true);
        //        self.close();       
    </script>
</asp:Panel>
