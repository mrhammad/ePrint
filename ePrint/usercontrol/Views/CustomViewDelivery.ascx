<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomViewDelivery.ascx.cs" Inherits="ePrint.usercontrol.Views.CustomViewDelivery" %>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>--%>
<%--<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
    var path = "<%=strSitepath %>";
</script>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnReMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lstClumns" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lstSelectedCols" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="btnReMove" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lstClumns" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="lstSelectedCols" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="btnMove" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
</telerik:RadAjaxLoadingPanel>
<%--<div class="navigatorpanel">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" nowrap="nowrap">
                        <span class="navigatorpanel" style="padding-left: 10px"> <%=objLangClass.GetLanguageConversion("Delivery_Note_Custom_View")%> 
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>--%>
<div id="content">
    <%-- <div class="borderWithoutTop">--%>
    <div id="padding" class="div_purchase_vwmargin">
        <table width="100%">
            <tr align="center">
                <td align="center">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    <b>
                                      Step 1:Configure Grouping</b>
                                    <hr style="border-top: 1px solid #BDBDBD;" />
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; padding-left: 2px">
                                        <asp:CheckBox ID="chkGrouping" runat="server" Text="Enable Grouping?" />
                                    </div>
                                     <div class="only5px">
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 125px; padding-top: 2px">
                                        Group by Column:
                                    </div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddlGroupBy" CssClass="normaltext" Width="150px" runat="server">
                                                <asp:ListItem Text="-- Select Column --" Value="" />
                                                <asp:ListItem Text="Customer Name" Value="CustomerID" />
                                                <asp:ListItem Text="Status" Value="Status" />
                                               
                                                <asp:ListItem Text="Created On" Value="CreatedDate" />
                                              
                                                <asp:ListItem Text="Delivery Date" Value="DeliveryDate" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </td>
                            </tr>--%>

            <tr>
                <td>
                    <b>
                        Step 1: Select the Columns for this View
                    </b>
                    <hr style="border-top: 1px solid #BDBDBD;" />
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:CheckBoxList ID="chkColumnName" RepeatLayout="Table" RepeatColumns="5" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList>--%>
                    <div id="div_Columns">
                        <asp:Panel ID="pnllst" runat="server">
                            <div id="divMain" style="border: 0px solid black; width: 100%; float: left">
                                <%-- <div id="div_Main" style="border:1px solid red;width:200px">--%>
                                <div id="div_lstAllCols" style="width: 215px; float: left">
                                    <b>
                                        <asp:Label ID="lblAvailableCols" runat="server"></asp:Label></b>
                                    <telerik:RadListBox ID="lstClumns" runat="server" CheckBoxes="true" Width="215px" SelectionMode="Multiple"
                                        Height="200px" CssClass="normaltext" OnItemDataBound="lstClumns_OnItemDataBound">
                                    </telerik:RadListBox>
                                    <%--<asp:CustomValidator ID="CustValidateAllCols" runat="server" ClientValidationFunction="ValidationCriteria"
                                            ErrorMessage=""> 
                                        </asp:CustomValidator>--%>
                                </div>
                                <div style="width: 45px; vertical-align: middle; float: left; padding-left: 10px">
                                    <div style="width: 20%">
                                        &nbsp;</div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    <div class="only10px">
                                        &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    <asp:Button ID="btnMove" runat="server" Text=">>" ToolTip="Move" CssClass="button"
                                        OnClick="btnMove_OnClick" OnClientClick="ValidationCriteria();" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnReMove" runat="server" Text="<<" ToolTip="Remove" CssClass="button"
                                        OnClick="btnReMove_OnClick" OnClientClick="ValidateSelectedCols();" />
                                </div>
                                <div style="border: 0px solid blue; width: 47%; float: left; padding-left: 10px">
                                    <b>
                                        <asp:Label ID="lblSelectedcols" runat="server"></asp:Label></b>
                                    <telerik:RadListBox ID="lstSelectedCols" runat="server" Width="215px" Height="200px"
                                        CssClass="normaltext" CheckBoxes="true" AllowReorder="True" EnableDragAndDrop="True" SelectionMode="Multiple"
                                        OnItemDataBound="lstSelectedCols_OnItemDataBound" OnClientItemChecking="OnClientItemCheckingHandler">
                                        <ButtonSettings ShowReorder="false" />
                                    </telerik:RadListBox>
                                    <%--<asp:CustomValidator ID="CustValidateSelectedCols" runat="server" ClientValidationFunction="ValidateSelectedCols"
                                            ErrorMessage=""> 
                                        </asp:CustomValidator>--%>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="only5px">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <b>
                        Step 2: Enable Live or Archived Records </b>
                    <hr style="border-top: 1px solid #BDBDBD;" />
                    <div class="only5px">
                    </div>

                    <div style="float: left; width: 85px;">
                        <%=objLanguage.GetLanguageConversion("Records")%>
                    </div>
                    <div style="float: left">
                        <asp:DropDownList ID="ddlShowRecords" CssClass="normaltext" Width="150px" Style="margin-left: -33px;" runat="server">
                            <asp:ListItem Text="Live" Value="Live"></asp:ListItem>
                            <asp:ListItem Text="Archive" Value="Archive"></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="only5px">
                    </div>
                    <div style="margin-left: -3px;">
                        <asp:CheckBox ID="chk_Searchby" runat="server" CssClass="rlbCheck" Text="Search by the following criteria" onclick="javascript:checkone();" Checked="false" />
                    </div>





                    <%--<div>
                        <asp:RadioButton ID="rdb_Showall" runat="server" Text="" GroupName="rdb" onclick="javascript:checkone();"
                            Checked="true" /></div>
                    <div>
                        <asp:RadioButton ID="rdb_Searchby" runat="server" Text="" GroupName="rdb" onclick="javascript:checkone();"
                            Checked="false" /></div>--%>
                    <div class="only5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <div class="only5px">
                    </div>
                    <%--<div style="float: left; width: 85px">
                        <%=objLanguage.GetLanguageConversion("Show_Records")%></div>
                    <div style="float: left">
                        <asp:DropDownList ID="ddlShowRecords" CssClass="normaltext" Width="150px" runat="server">
                            <asp:ListItem Text="Live" Value="Live"></asp:ListItem>
                            <asp:ListItem Text="Archive" Value="Archive"></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                        </asp:DropDownList>
                    </div>--%>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:PlaceHolder ID="plh1" runat="server">
                        <div id="div_Searchcriteria" style="display: none; margin-left: 13px; margin-top: -16px;" runat="server">
                            <table cellspacing="2" cellpadding="2" width="100%" align="center" border="0">
                                <tr valign="top">
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="165px">
                                                    <span style="width: 160px; font-weight: bold">
                                                        <%=objLangClass.GetLanguageConversion("Column_Name")%></span>
                                                </td>
                                                <td width="165px">
                                                    <span style="width: 160px; font-weight: bold">
                                                        <%=objLangClass.GetLanguageConversion("Filter")%></span>
                                                </td>
                                                <td width="165px">
                                                    <span style="width: 200px; font-weight: bold">
                                                        <%=objLangClass.GetLanguageConversion("Conditions")%></span>
                                                </td>
                                                <td>
                                                    <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield1" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition1" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria1" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria1" runat="server" CssClass="normaltext"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror1" runat="server" CssClass="error" Width="514px" Visible="False">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normaltext" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield2" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition2" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria2" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria2" runat="server" CssClass="normaltext"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror2" runat="server" CssClass="error" Width="514px" BorderWidth="1px"
                                            BorderStyle="Solid"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield3" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition3" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria3" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria3" runat="server" CssClass="normaltext"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror3" runat="server" CssClass="error" Width="515px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield4" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition4" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria4" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria4" runat="server" CssClass="normaltext"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror4" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield5" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition5" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria5" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                          <asp:DropDownList ID="DrpdwnSearchCritria5" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror5" runat="server" CssClass="error" Width="515px"></asp:Label>
                                        <div class="only5px">
                                        </div>
                                    </td>
                                </tr>
                                
                                    <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield6" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition6" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria6" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria6" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror6" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>

                                    <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield7" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition7" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria7" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria7" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="lblerror7" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>

                                    <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield8" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition8" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria8" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria8" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                      
                                        <br />
                                        <asp:Label ID="lblerror8" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield9" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition9" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria9" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="DrpdwnSearchCritria9" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>
                                      
                                        <br />
                                        <asp:Label ID="lblerror9" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                    <td class="normaltext" valign="top" nowrap="nowrap">
                                        <asp:DropDownList ID="ddlsearchfield10" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlsearchcondition10" runat="server" CssClass="normaltext" Width="150px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtsearchcriteria10" runat="server" CssClass="txtBox" Width="200px"
                                            MaxLength="100">
                                        </asp:TextBox>
                                      <%--  <asp:DropDownList ID="DropDownList10" CssClass="normaltext" runat="server"
                                            Width="100px">
                                            <asp:ListItem Text="And" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Or"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                      
                                        <br />
                                        <asp:Label ID="lblerror10" runat="server" CssClass="error" Width="513px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table cellspacing="2" cellpadding="2" width="100%" align="center" border="0">
                            <tr>
                                <td>
                                    <b>
                                        Step 3: Select Sorting </b>
                                    <hr style="border-top: 1px solid #BDBDBD;" />
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        <%=objLangClass.GetLanguageConversion("Sort_By")%></div>
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddl_sortby" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 80px; padding-top: 2px">
                                        <%=objLangClass.GetLanguageConversion("Direction")%></div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddl_direction" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>

                                     <span style="color: red;">And Then</span>
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        <%=objLanguage.GetLanguageConversion("Sort_By") %>
                                    </div>
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddl_sortby2" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 80px; padding-top: 2px">
                                        <%=objLanguage.GetLanguageConversion("Direction")%>
                                    </div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddl_direction2" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                   <span style="color: red;">And Then</span>
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        <%=objLanguage.GetLanguageConversion("Sort_By") %>
                                    </div>
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddl_sortby3" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 80px; padding-top: 2px">
                                        <%=objLanguage.GetLanguageConversion("Direction")%>
                                    </div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddl_direction3" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <span style="color: red;">And Then</span>
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        <%=objLanguage.GetLanguageConversion("Sort_By") %>
                                    </div>
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddl_sortby4" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 80px; padding-top: 2px">
                                        <%=objLanguage.GetLanguageConversion("Direction")%>
                                    </div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddl_direction4" CssClass="normaltext" Width="150px" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    <b>
                                        Step 4: Do not Display Records Older Than</b>
                                    <hr style="border-top: 1px solid #BDBDBD;" />
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        Date Type
                                    </div>
                                    <div style="float: left">
                                        <asp:DropDownList ID="ddlDateType" CssClass="normaltext" Width="150px" runat="server">
                                             <asp:ListItem Text="None" Value="None" selected="true" />
                                             
                                                <asp:ListItem Text="Delivery" Value="DeliveryDate" />
                                                <asp:ListItem Text="CreationDate"  Value="CreatedDate" />
                                              <%--   <asp:ListItem Text="Artwork" Value="ArtworkDate" />
                                                <asp:ListItem Text="Proof" Value="ProofDate" />
                                                <asp:ListItem Text="Approval" Value="ApprovalDate" />
                                                <asp:ListItem Text="Production" Value="ProductionDate" />
                                                <asp:ListItem Text="Completion" Value="CompletionDate" />
                                                <asp:ListItem Text="Custom Date 1" Value="CustomDate1" />
                                                <asp:ListItem Text="Custom Date 2" Value="CustomDate2" />
                                                <asp:ListItem Text="Custom Date 3" Value="CustomDate3" />--%>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                    <div style="float: left; width: 80px; padding-top: 2px">
                                       Date Range
                                    </div>
                                    <div style="float: left; padding-top: 2px">
                                        <asp:DropDownList ID="ddlDateRange" CssClass="normaltext" Width="150px" runat="server">
                                            <asp:ListItem Text="All Time" Value="All" Selected="True" />
                                            <asp:ListItem Text="1 Month" Value="1M" />
                                            <asp:ListItem Text="3 Months" Value="3M" />
                                            <asp:ListItem Text="6 Months" Value="6M" />
                                            <asp:ListItem Text="1 Year" Value="1Y" />
                                            <asp:ListItem Text="2 Year" Value="2Y" />
                                            <asp:ListItem Text="3 Year" Value="3Y" />
                                          
                                        </asp:DropDownList>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                </td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>
                                        <%--<%=objLangClass.GetLanguageConversion("Step4_Save_This_View_For_Future_Use")%>--%>
                                         Step 5: Save this view
                                    </b>
                                    <hr style="border-top: 1px solid #BDBDBD;" />
                                    <div class="only5px">
                                    </div>
                                    <div style="float: left; width: 80px">
                                        <b>
                                            <%=objLangClass.GetLanguageConversion("View_Name")%>
                                        </b>
                                    </div>
                                    <div style="float: left; border: 0px solid;">
                                        <asp:TextBox ID="txt_ViewName" SkinID="textPad" runat="server" MaxLength="200"><%--onblur="javascript:CheckViewDuplicacy();"--%>
                                        </asp:TextBox>
                                        <div style="display: block;" class="error_top">
                                            <span id="spn_txtViewName" class="spanerrorMsg" style="display: none; width: 170px;">
                                                <%=objLangClass.GetLanguageConversion("View_Name_Already_Exists")%></span>
                                        </div>
                                        <div style="display: block;" class="error_top">
                                            <span id="spn_txtViewName1" class="spanerrorMsg" style="display: none; width: 170px;">
                                                <%=objLangClass.GetLanguageConversion("Please_Enter_View_Name")%></span>
                                            <%-- <asp:RequiredFieldValidator ID="RFV_txtViewName" ControlToValidate="txt_ViewName"
                                                     ErrorMessage="Please enter View Name" ForeColor="" runat="server" CssClass="errorMsg"
                                                    Width="200px" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div style="float: left; padding-left: 2px">
                                        <asp:CheckBox ID="chk_setdefault" runat="server" Text="" />
                                        <%=objLangClass.GetLanguageConversion("Set_This_View_As_My_Default")%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="only10px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div style="float: left; display: none">
                                        <div id="div_btncancel" style="display: block">
                                            <asp:Button ID="btn_Cancel" runat="server" Text="" CssClass="button" OnClientClick="javascript:var a= cancelClick(path+'Delivery/delivery_view.aspx');loadingimage(this.id,'div_cancelprocess');return a;" />
                                        </div>
                                        <div id="div_cancelprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <%--OnClick="btncancel_OnClick"--%>
                                    <div style="float: left; width: 10px">
                                        &nbsp;</div>
                                    <div id="Divdiv_btndelete" runat="server" style="float: left;">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btn_delete" runat="server" Text="" CssClass="button" Width="65px"
                                                OnClick="btndelete_OnClick" OnClientClick="javascript:var a=window.confirm('Are you sure you want to Delete this view?'); if(a) loadingimage(this.id,'div_deleteprocess'); return a;"
                                                Visible="false" Style="margin-left: -10px" />
                                        </div>
                                        <div id="div_deleteprocess" style="display: none; min-width:47px;">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;</div>
                                    <div id="Divdiv_btnsave" runat="server" style="float: left;">
                                        <div id="div_btnsave" style="display: block">
                                            <asp:Button ID="btn_Save" runat="server" Text="" CssClass="button" OnClick="btnsave_OnClick"
                                                OnClientClick="javascript:var a= validate();if(a)loadingimage(this.id,'div_saveprocess');return a;"
                                                Style="margin-left: 60px" />
                                        </div>
                                        <div id="div_saveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>

                                    <div id="Divdiv_btnsaveasnewview" runat="server" style="float: left;">
                                        <div id="div_btnsaveasnewview" style="display: block">
                                            <asp:Button ID="btn_saveasnewview" runat="server" Text="" CssClass="button" OnClick="btnsaveasnewview_OnClick"
                                                OnClientClick="javascript:var a= validate();if(a)loadingimage(this.id,'div_saveasnewviewprocess');return a;"
                                                Style="margin-left: 10px" />
                                        </div>
                                        <div id="div_saveasnewviewprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>

                                </td>
                            </tr>
                        </table>
                    </asp:PlaceHolder>
                     <script type="text/javascript">
                         Telerik.Web.UI.RadListBox.prototype.saveClientState = function () {
                             return "{" +
                                 "\"isEnabled\":" + this._enabled +
                                 ",\"logEntries\":" + this._logEntriesJson +
                                 ",\"selectedIndices\":" + this._selectedIndicesJson +
                                 ",\"checkedIndices\":" + this._checkedIndicesJson +
                                 ",\"scrollPosition\":" + Math.round(this._scrollPosition) +
                                 "}";
                         }
                    </script>
                    <script>
                        function checkone() {
                            document.getElementById('spn_txtViewName').style.display = "none";
                            var chk_searchby = document.getElementById("<%=chk_Searchby.ClientID%>");
                            if (chk_searchby.checked) {
                                document.getElementById("<%=div_Searchcriteria.ClientID%>").style.display = "block";
                            }
                            else {
                                document.getElementById("<%=div_Searchcriteria.ClientID%>").style.display = "none";
                            }
                        }
                        var IsDuplicate = false;
                        function CheckViewDuplicacy() {
                            var compID = '<%=companyId %>';
                            var val1 = document.getElementById("<%=txt_ViewName.ClientID %>").value;
                            document.getElementById('spn_txtViewName1').style.display = "none";
                            var viewID = '<%=dupViewID %>';
                            var val = compID + "±" + val1 + "±" + viewID;
                            PageMethods.GetViewName(val, ShowViewMsg, ShowMsg_Failure);
                            return IsDuplicate;
                        }
                        function ShowMsg_Failure(error) { }
                        function ShowViewMsg(result) {
                            document.getElementById('spn_txtViewName').style.display = "none";
                            if (result == -1) {
                                document.getElementById('spn_txtViewName').style.display = "block";
                                IsDuplicate = false;
                            }
                            else {
                                IsDuplicate = true;
                            }
                        }

                        var CheckFinal = false;
                        function validate() {
                            var spn_txtViewName1 = document.getElementById('spn_txtViewName1');
                            var spn_txtViewName = document.getElementById('spn_txtViewName');
                            spn_txtViewName1.style.display = "none";
                            spn_txtViewName.style.display = "none";
                            var txt_ViewName = document.getElementById('<%=txt_ViewName.ClientID%>');

                            //                               if(CheckViewDuplicacy())
                            //                                {
                            if (document.getElementById('spn_txtViewName').style.display == "block") {
                                CheckFinal = false;
                            }

                            if (trim12(txt_ViewName.value) == '') {
                                spn_txtViewName1.style.display = "block";
                                CheckFinal = false;
                            }
                            else {
                                CheckFinal = true;
                            }

                            if (CheckFinal) {
                                return true;
                                /*if (IsDuplicate) 
                                {
                                return true;
                                }
                                else 
                                {
                                spn_txtViewName.style.display = "block";
                                return false;
                                }*/
                            }
                            else {
                                //spn_txtViewName.style.display = "block";
                                return false;
                            }
                            //                                }
                            //                                else
                            //                                {
                            //                                    return false;
                            //                                }
                        }

                        function callstart() {
                            if ('<%=isshowallrecords%>' == 1) {
                                document.getElementById("<%=div_Searchcriteria.ClientID%>").style.display = "block";
                            }
                            else {
                                document.getElementById("<%=div_Searchcriteria.ClientID%>").style.display = "none";
                            }
                        }

                        window.onload = callstart
                  
                
                    </script>
                    <script type="text/javascript">
                        function ValidationCriteria(source, args) {
                            var listbox = $find('<%= lstClumns.ClientID %>');
                            var check = 0;
                            var items = listbox.get_items();
                            for (var i = 0; i <= items.get_count() - 1; i++) {
                                var item = items.getItem(i);
                                if (item.get_checked()) {
                                    check = 1;
                                }
                            }
                            if (check) {
                                //args.IsValid = true;                                    
                                return true;
                            }
                            else {
                                //args.IsValid = false;
                                //return false;
                                if (items.get_count() == 0) {
                                    alert('There are no records for move');
                                    return false;
                                }
                                else {
                                    alert('Please select at least one check box');
                                    return false;
                                }
                            }
                        }

                        function ValidateSelectedCols(source, args) {
                            var listbox = $find('<%= lstSelectedCols.ClientID %>');
                            var check = 0;
                            var items = listbox.get_items();
                            for (var i = 0; i <= items.get_count() - 1; i++) {
                                var item = items.getItem(i);
                                if (item.get_checked()) {
                                    check = 1;
                                }
                            }
                            if (check)
                            //args.IsValid = true;
                                return true;
                            else {
                                //args.IsValid = false;
                                if (items.get_count() == 2) {
                                    alert('There are no records for re-move');
                                    return false;
                                }
                                else {
                                    alert('Please select at least one check box');
                                    return false;
                                }
                            }
                        }

                        function OnClientItemCheckingHandler(sender, eventArgs) {
                            var item = eventArgs.get_item();
                            if (item.get_text() == "Delivery No.") {
                                var message = "You are not allowed to ";
                                message += item.get_checked() ? "uncheck" : "check";
                                message += " the item " + item.get_text();
                                alert(message);
                                eventArgs.set_cancel(true);
                            }
                            if (item.get_text() == "Customer Name") {
                                var message = "You are not allowed to ";
                                message += item.get_checked() ? "uncheck" : "check";
                                message += " the item " + item.get_text();
                                alert(message);
                                eventArgs.set_cancel(true);
                            }
                        }  
                    </script>
                </td>
            </tr>
        </table>
    </div>
    <%--  </div>--%>
</div>
