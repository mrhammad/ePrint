<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhraseBookMenu.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.PhraseBookMenu" %>

<script src="../js/animation.js" type="text/javascript"></script>
<div style="border: solid 0px gainsboro;">
    <%--    <asp:HiddenField ID="hdn_IsShowEstimate" runat="server" Value="" />
    <asp:HiddenField ID="hdn_NotShowEstimate" runat="server" Value="" />--%>
    <table cellpadding="0" cellspacing="0" border="0" width="200px">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border: solid 1px #cccccc; padding-right: 10px; padding-left: 10px" width="17%"
                            valign="top">
                            <br />
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                                <%-- <tr>
                                    <td>
                                        <div id="email" style="cursor: pointer; display: block; padding-left: 18px">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td id="tdEmail" onclick="javascript:HighLitedMenu1(this.id,'../StoreSettings/phrase_book.aspx?type=em');">
                                                        <b><%=objLanguage.GetLanguageConversion("Email_Message") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 8px;">
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <div id="onpage" onclick="javascript:return onpage('block');" style="cursor: pointer;">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" height="20" style="vertical-align: middle"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("On_Page_Messages") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="showonpage" onclick="javascript:return onpage('none');" style="cursor: pointer;
                                            display: none;">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" height="20" style="vertical-align: middle"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("On_Page_Messages")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divonpage" style="display: block; overflow: hidden; height: 200px;" runat="server">
                                            <table id="tableID1" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                <tr class="VMenu" onmouseover="tdOver(this,'td0')" onmouseout="tdOut(this,'td0')">
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td class="VMenuIcon">
                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="25" alt="" border="0">
                                                    </td>
                                                    <td width="100%" style="cursor: pointer" id="td0" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/phrase_book.aspx?type=li');"
                                                        nowrap="nowrap">
                                                        <%=objLanguage.GetLanguageConversion("Above_Login_Messages")%>
                                                    </td>
                                                </tr>
                                                <tr class="VMenu" onmouseover="tdOver(this,'td2')" onmouseout="tdOut(this,'td2')">
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td class="VMenuIcon">
                                                        <img src="<%=strImagepath%>branch-e.gif" width="15" height="25" alt="" border="0">
                                                    </td>
                                                    <td width="100%" style="cursor: pointer" id="td2" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/phrase_book.aspx?type=bli');"
                                                        nowrap="nowrap">
                                                        <%=objLanguage.GetLanguageConversion("Below_Login_Messages")%>
                                                    </td>
                                                </tr>
                                                <tr class="VMenu" onmouseover="tdOver(this,'Td1')" onmouseout="tdOut(this,'Td1')">
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td class="VMenuIcon">
                                                        <img src="<%=strImagepath%>branch-l.gif" width="15" height="25" alt="" border="0">
                                                    </td>
                                                    <td width="100%" id="Td1" onclick="javascript:HighLitedMenu(this.id,'../StoreSettings/phrase_book.aspx?type=lo');"
                                                        class="Caption2Out" style="cursor: pointer" nowrap="nowrap">
                                                        <%=objLanguage.GetLanguageConversion("Logout_Messages")%>
                                                    </td>
                                                </tr>
                                            </table>
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
