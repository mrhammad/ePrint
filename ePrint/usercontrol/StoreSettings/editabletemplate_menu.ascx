<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editabletemplate_menu.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.editabletemplate_menu" %>

<script src="../js/animation.js" type="text/javascript"></script>
<div style="border: solid 0px gainsboro;">
    <table cellpadding="0" cellspacing="0" border="0" width="200px">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border: solid 1px #cccccc; padding-right: 10px; padding-left: 10px" width="17%"
                            valign="top">
                            <br />
                            <table cellpadding="0" cellspacing="0" border="0"  width="100%" align="center">
                                <tr>
                                    <td>
                                        <b style="padding-left:7px;">
                                            <%=objLanguage.GetLanguageConversion("Editable_Template")%></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divEdit_Temp1" runat="server" style="display: block;">
                                            <div id="divEdit_Temp" style="display: block; overflow: hidden; height: 72px; padding-bottom: 10px;"
                                                runat="server">
                                                <table id="table3" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu" onmouseover="tdOver(this,'Td62')" onmouseout="tdOut(this,'Td62')">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td62" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/system_pharsebook.aspx?type=temp_ed');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Dropdown_Options")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu" onmouseover="tdOver(this,'Td65')" onmouseout="tdOut(this,'Td65')">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td65" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/editableTemplate_manageFonts.aspx?type=color');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Manage_Color_Styles")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu" onmouseover="tdOver(this,'Td64')" onmouseout="tdOut(this,'Td64')">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td64" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/editableTemplate_manageFonts.aspx?type=font');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Manage_Font_Styles")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr2" runat="server" class="VMenu" onmouseover="tdOver(this,'Td63')" onmouseout="tdOut(this,'Td63')">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td63" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/Upload_EditableTemplate_Font.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Upload_Font") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="clear: both;">
    </div>
</div>

