<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhraseBookMenu.ascx.cs" Inherits="ePrint.usercontrol.settings.PhraseBookMenu" %>

<script src="../js/item/javascript.js?VN='<%#VersionNumber%>" type="text/javascript"></script>
<%--<script src="../js/animation.js?VN='<%#VersionNumber%>" type="text/javascript"></script>--%>
<%--<script src="../js/item/general.js?VN='<%#VersionNumber%>" type="text/javascript"></script>--%>
<div style="border: solid 0px gainsboro;">
    <%--    <asp:HiddenField ID="hdn_IsShowEstimate" runat="server" Value="" />
    <asp:HiddenField ID="hdn_NotShowEstimate" runat="server" Value="" />--%>
    <table cellpadding="0" cellspacing="0" border="0" width="200px" style="color: Black">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="border: solid 1px #cccccc; padding-right: 10px; padding-left: 10px" width="17%"
                            valign="top">
                            <br />
                            <table id="tblPhresebook" visible="false" runat="server" cellpadding="0" cellspacing="0"
                                border="0" width="100%" align="center">
                                <tr>
                                    <td>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td class="phrasebooktd">
                                                    </td>
                                                    <td>
                                                        <div id="estimate" onclick="javascript:return estimate('block');" class="phrasebookminusicon">
                                                            <img src="<%=strImagepath%>mminus.gif" width="18" height="20" style="vertical-align: middle;"
                                                                alt="" border="0">
                                                        </div>
                                                        <div id="showestimate" onclick="javascript:return estimate('none');" class="phrasebookplusicon">
                                                            <img src="<%=strImagepath%>mplus.gif" width="18" height="20" style="vertical-align: middle;"
                                                                alt="" border="0">
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <b>
                                                            <%=objLanguage.GetLanguageConversion("Estimate") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <%-- <div id="showestimate" onclick="javascript:return estimate('none');" style="cursor: pointer;">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" height="20" style="vertical-align: middle"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("Estimate") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divestimate1" runat="server" style="display: block">
                                            <div id="divestimate" style="display: none; overflow: hidden; height: 785px;" runat="server">
                                                <table id="tableID1" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="td0" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=eh');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Estimate_Header") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td1" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ef');"
                                                            class="Caption2Out" style="cursor: pointer" nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Estimate_Footer") %>
                                                        </td>
                                                    </tr>
                                                    <%--=== Commented By Shivappa, Bug ID 692 ===--%>
                                                    <%--<tr class="VMenu" onmouseover="tdOver(this,'Td2')" onmouseout="tdOut(this,'Td2')">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td id="Td2" width="100%" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ep');"
                                                            nowrap="nowrap">
                                                            Estimate Paragraph
                                                        </td>
                                                    </tr>--%>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td3" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=et');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Title") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td4" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=eo');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Description") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td5" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ea');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("ArtWork") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td6" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec');"
                                                            nowrap="nowrap">
                                                            <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td7" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=es');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Size") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td8" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=em');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Material") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td9" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ed');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Delivery") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td10" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=efinish');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Finishing") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td33" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=eproofs');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Proofs") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td34" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=epacking');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Packing") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td11" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=en');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Notes") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td12" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ei');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Terms_Instructions") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd1" style="cursor: pointer" class="Caption2Out" nowrap="nowrap"
                                                            onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec1');">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description1") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd2" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec2');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description2") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd3" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec3');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description3") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd4" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec4');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description4") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd5" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec5');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description5") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd6" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec6');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description6") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd7" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec7');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description7") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd8" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec8');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description8") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd9" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec9');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description9") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd10" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec10');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description10") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd11" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec11');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description11") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd12" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec12');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description12") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd13" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec13');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description13") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd14" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec14');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description14") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd15" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec15');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description15") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd16" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec16');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description16") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd17" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec17');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description17") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd18" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec18');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description18") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd19" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec19');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description19") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd20" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec20');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description20") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd21" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec21');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description21") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd22" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec22');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description22") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd23" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec23');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description23") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd24" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec24');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description24") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="NewTd25" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ec25');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_description25") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td class="phrasebooktd">
                                                    </td>
                                                    <td>
                                                        <div id="job" onclick="javascript:return job('none');" class="phrasebookminusicon">
                                                            <img src="<%=strImagepath%>mminus.gif" width="18" height="20" style="vertical-align: middle;"
                                                                alt="" border="0"></div>
                                                        <div id="showjob" onclick="javascript:return job('block');" class="phrasebookplusicon">
                                                            <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle;"
                                                                height="20" alt="" border="0"></div>
                                                    </td>
                                                    <td>
                                                        <b>Job</b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <%--<div id="showjob" onclick="javascript:return job('block');" style="cursor: pointer;
                                            display: block">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("Job") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divjob1" runat="server" style="display: block">
                                            <div id="divjob" style="display: none; overflow: hidden; height: 50px;" runat="server">
                                                <table id="table2" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td13" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=jh');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Job_Header") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td14" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=jf');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Job_Footer") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td class="phrasebooktd">
                                                </td>
                                                <td>
                                                    <div id="invoice" onclick="javascript:return invoice('none');" class="phrasebookminusicon">
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" height="20" style="vertical-align: middle"
                                                            alt="" border="0">
                                                    </div>
                                                    <div id="showinvoice" onclick="javascript:return invoice('block');" class="phrasebookplusicon">
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"></div>
                                                </td>
                                                <td>
                                                    <b>
                                                        <%=objLanguage.GetLanguageConversion("Invoice") %></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--  <div id="showinvoice" onclick="javascript:return invoice('block');" style="cursor: pointer;
                                            display: block">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("Invoice") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divinvoice1" runat="server" style="display: block">
                                            <div id="divinvoice" style="display: none; overflow: hidden; height: 50px;" runat="server">
                                                <table id="tableID2" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td15" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ih');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Invoice_Header") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td16" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=if');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Invoice_Footer") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td class="phrasebooktd">
                                                </td>
                                                <td>
                                                    <div id="purchase" onclick="javascript:return purchase('none');" class="phrasebookminusicon">
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" style="vertical-align: middle"
                                                            height="20" alt="" border="0">
                                                    </div>
                                                    <div id="showpurchase" onclick="javascript:return purchase('block');" class="phrasebookplusicon">
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"></div>
                                                </td>
                                                <td>
                                                    <b>
                                                        <%=objLanguage.GetLanguageConversion("Purchase_Orders") %></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <%-- <div id="showpurchase" onclick="javascript:return purchase('block');" style="cursor: pointer;
                                            display: block">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("Purchase_Orders") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divpurchase1" runat="server" style="display: block">
                                            <div id="divpurchase" style="display: none; overflow: hidden; height: 70px;" runat="server">
                                                <table id="tableID3" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td17a" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ph');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Purchase_Header") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td17" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=pf');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Purchase_Footer") %>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td18" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=pi');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Comments_Delivery_Instructions")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td class="phrasebooktd">
                                                </td>
                                                <td>
                                                    <div id="delivery" onclick="javascript:return delivery('none');" class="phrasebookminusicon">
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" style="vertical-align: middle"
                                                            height="20" alt="" border="0">
                                                    </div>
                                                    <div id="showdelivery" onclick="javascript:return delivery('block');" class="phrasebookplusicon">
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"></div>
                                                </td>
                                                <td>
                                                    <b>
                                                        <%=objLanguage.GetLanguageConversion("Delivery_Note")%></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--    <div id="showdelivery" onclick="javascript:return delivery('block');" style="cursor: pointer;
                                            display: block">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"><b><%=objLanguage.GetLanguageConversion("Delivery_Note")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divdelivery1" runat="server" style="display: block">
                                            <div id="divdelivery" style="display: none; overflow: hidden; height: 65px; border: 0px solid blue"
                                                runat="server">
                                                <table id="table1" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td19" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=dh');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Delivery_Note_Header")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" style="cursor: pointer" id="Td20" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=df');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Delivery_Note_Footer")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td class="phrasebooktd">
                                                </td>
                                                <td>
                                                    <div id="printbroker" onclick="javascript:return printbroker('block');" class="phrasebookplusicon">
                                                        <img src="<%=strImagepath%>mplus.gif" width="18" style="vertical-align: middle" height="20"
                                                            alt="" border="0"></div>
                                                    <div id="showprintbroker" onclick="javascript:return printbroker('none');" class="phrasebookminusicon">
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" style="vertical-align: middle"
                                                            height="20" alt="" border="0"></div>
                                                </td>
                                                <td>
                                                    <b>
                                                        <%=objLanguage.GetLanguageConversion("Outwork")%></b>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--    <div id="showprintbroker" onclick="javascript:return printbroker('none');" style="cursor: pointer;">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 2%">
                                                    </td>
                                                    <td>
                                                        <img src="<%=strImagepath%>mminus.gif" width="18" style="vertical-align: middle"
                                                            height="20" alt="" border="0"><b><%=objLanguage.GetLanguageConversion("OutWork")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divprintbroker1" runat="server" style="display: block">
                                            <div id="divprintbroker" style="display: none; overflow: hidden; height: 785px;"
                                                runat="server">
                                                <table id="tableID4" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td2" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ot');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Title")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0" />
                                                        </td>
                                                        <td width="100%" id="Td21" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oo');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Description")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td22" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oa');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("ArtWork")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td23" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc');"
                                                            nowrap="nowrap">
                                                            <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td24" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=os');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Size")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td25" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=om');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Material")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td26" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=od');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Delivery")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td27" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ofinish');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Finishing")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td28" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oproofs');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Proofs")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td29" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=opacking');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Packing")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td30" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=on');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Notes")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td31" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oi');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Terms_Instructions")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td32" style="cursor: pointer" class="Caption2Out" nowrap="nowrap"
                                                            onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc1');">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description1")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td37" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc2');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description2")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td38" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc3');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description3")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td39" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc4');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description4")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td40" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc5');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description5")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td41" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc6');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description6")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td42" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc7');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description7")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td43" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc8');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description8")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td44" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc9');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description9")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td45" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc10');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description10")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td46" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc11');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description11")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td47" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc12');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description12")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td48" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc13');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description13")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td49" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc14');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description14")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td50" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc15');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description15")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td51" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc16');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description16")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td52" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc17');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description17")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td53" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc18');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description18")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td54" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc19');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description19")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td55" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc20');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description20")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td56" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc21');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description21")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td57" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc22');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description22")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td58" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc23');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description23")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td59" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc24');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description24")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td60" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=oc25');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Description25")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td35" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ohe');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Outwork_Header")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td36" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=ofo');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Outwork_Footer")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="Div1" style="cursor: pointer; display: block">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 12%">
                                                    </td>
                                                    <td onclick="javascript:HighLitedMenu(this.id,'../Settings/system_pharsebook.aspx?Mtype=PB&type=act_hist');">
                                                        <b>
                                                            <%=objLanguage.GetLanguageConversion("Activity_History_Error")%></b>
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
                            <table id="tblEmail" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%"
                                align="center">
                                <tr>
                                    <td>
                                        <b style="padding-left: 7px;">
                                            <%=objLanguage.GetLanguageConversion("System_Emails")%></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divCont" runat="server" style="display: block;">
                                            <div id="divcont_msg" style="display: block; overflow: hidden; padding-bottom: 10px;"
                                                runat="server">
                                                <table id="table3" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr id="Tr4" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td66" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_emailsignature.aspx?type=mfs');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Footer_Signature")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0" />
                                                        </td>
                                                        <td width="100%" id="Td62" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_emailbody.aspx?type=mb');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Customers_and_Suppliers")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu" runat="server" id="tr30">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td65" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/supplier_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Emails_from_Suppliers")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                   <tr id="prooftr1" runat="server">
                                        <td>
                                            <b style="padding-left: 7px;">Proof Approval emails</b>
                                        </td>
                                    </tr>
                                    <tr id="prooftr2" runat="server">
                                        <td>
                                            <div id="div4" runat="server" style="display: block;">
                                                <div id="div5" style="display: block; overflow: hidden; padding-bottom: 10px;"
                                                    runat="server">
                                                    <table id="table8" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                        <tr id="Tr1" runat="server" class="VMenu">
                                                            <td style="width: 2%;"></td>
                                                            <td class="VMenuIcon">
                                                                <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                            </td>
                                                            <td width="100%" id="Td88" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/ProofApproval_emailbody.aspx?type=mfs');"
                                                                nowrap="nowrap">First Approver
                                                            </td>
                                                        </tr>
                                                        <tr class="VMenu">
                                                            <td style="width: 2%"></td>
                                                            <td class="VMenuIcon">
                                                                <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0" />
                                                            </td>
                                                            <td width="100%" id="Td90" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/SecondApprovalEmail.aspx?type=mb');"
                                                                nowrap="nowrap"> <%=objLanguage.GetLanguageConversion("Emails_Second_Approval")%>
                                                            <%--Body--%>
                                                            </td>
                                                        </tr>
                                                        <tr class="VMenu">
                                                            <td style="width: 2%"></td>
                                                            <td class="VMenuIcon">
                                                                <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0" />
                                                            </td>
                                                            <td width="100%" id="Td90" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/ProofReturnEmailBody.aspx?type=mb');"
                                                                nowrap="nowrap">Admin Notification
                                                            <%--Body--%>
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                <tr>
                                    <td>
                                        <b style="padding-left: 7px;">
<%--                                            <%=objLanguage.GetLanguageConversion("Alerts_and_Warnings")%></b>--%>
                                                <%=objLanguage.GetLanguageConversion("External_Alerts")%></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="divcont2" runat="server" style="display: block;">
                                            <div id="divcont_msg2" style="display: block; overflow: hidden; padding-bottom: 10px;"
                                                runat="server">
                                                <table id="table4" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td64" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_autojobalert_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Auto_job_Alert")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr id="Tr3" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td61" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/lowstockreminder_email.aspx?type=lsr');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Low_Stock_Reminder_Inventory")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr2" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td63" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_productlowstock_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Product_Low_Stock_Reminder")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr5" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td67" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/unauth_access_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Unauthorised_Access")%>
                                                        </td>
                                                    </tr>--%>
                                                     <tr id="Tr122" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td6336" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_autodeliveryalert_email.aspx');"
                                                            nowrap="nowrap">                                                           
                                                            External Delivery Alert Emails                                                        
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="DivAlertNotificationSetting" runat="server">
                                        <b style="padding-left: 7px;">
<%--                                            <%=objLanguage.GetLanguageConversion("Sales_Person_Task_Alerts")%></b>--%>
                                            <%=objLanguage.GetLanguageConversion("Internal_Alerts")%></b>
                                    </td>
                                </tr>
                                <tr>
                                    <td id="DivAlertNotificationSetting1" runat="server">
                                        <div id="div2" runat="server" style="display: block;">
                                            <div id="div3" style="display: block; overflow: hidden; padding-bottom: 10px;" runat="server">
                                                <table id="table5" width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                                    <tr id="Tr7" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td69" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/alert_notifications.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Alert_Notifications")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr3" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td61" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/lowstockreminder_email.aspx?type=lsr');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Low_Stock_Reminder_Inventory")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr2" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td63" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/system_productlowstock_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Product_Low_Stock_Reminder")%>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr5" runat="server" class="VMenu">
                                                        <td style="width: 2%;">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-l.gif" width="15" height="20" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td67" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/unauth_access_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Unauthorised_Access")%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td70" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/internal_estimate_alert_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Internal_Estimate_Alert_Email")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td71" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/internal_job_alert_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Internal_Job_Alert_Email")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td72" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/internal_delivery_alert_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Internal_Delivery_Alert_Email")%>
                                                            <%--Body--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="VMenu">
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td class="VMenuIcon">
                                                            <img src="<%=strImagepath%>branch-e.gif" width="15" alt="" border="0">
                                                        </td>
                                                        <td width="100%" id="Td73" style="cursor: pointer" class="Caption2Out" onclick="javascript:HighLitedMenu(this.id,'../Settings/internal_proof_alert_email.aspx');"
                                                            nowrap="nowrap">
                                                            <%=objLanguage.GetLanguageConversion("Internal_Proof_Alert_Email")%>
                                                            <%--Body--%>
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
<script type="text/javascript">
    function HighLitedMenu(x, url) {
        window.location.href = url;
    }
    function tdOver(obj, id) {
        obj.className = 'VMenu-Focus';
        document.getElementById(id).className = 'normalText_Focus';
        //onmouseover="this.className='VMenu-Focus';document.getElementById('td0').className='normalText_Focus'"       
    }
    function tdOut(obj, id) {

        obj.className = 'VMenu';
        document.getElementById(id).className = 'Caption2Out';

    }
</script>
<script type="text/javascript" language="javascript">

    function estimate(val) {
        try {
            if (val == 'none') {

                slidedown("<%=divestimate.ClientID %>");
                document.getElementById("showestimate").style.display = 'none'
                document.getElementById("estimate").style.display = 'block'
            }
            else {

                slideup("<%=divestimate.ClientID %>");
                document.getElementById("showestimate").style.display = 'block'
                document.getElementById("estimate").style.display = 'none'
            }
        }
        catch (err) {

        }
        return false;
    }



    function job(val) {
        try {


            if (val == 'none') {
                slideup("<%=divjob.ClientID %>");
                document.getElementById("showjob").style.display = 'block';
                document.getElementById("job").style.display = 'none';

            }
            else {
                slidedown("<%=divjob.ClientID %>");
                document.getElementById("showjob").style.display = 'none';
                document.getElementById("job").style.display = 'block';
            }
        }
        catch (err) {
        }
    }
    function invoice(val) {
        try {

            if (val == 'none') {
                slideup("<%=divinvoice.ClientID %>");
                document.getElementById("showinvoice").style.display = 'block';
                document.getElementById("invoice").style.display = 'none';

            }
            else {
                slidedown("<%=divinvoice.ClientID %>");
                document.getElementById("showinvoice").style.display = 'none';
                document.getElementById("invoice").style.display = 'block';
            }
        }
        catch (err) {
        }
    }

    function purchase(val) {
        try {

            if (val == 'none') {
                slideup("<%=divpurchase.ClientID %>");
                document.getElementById("showpurchase").style.display = 'block';
                document.getElementById("purchase").style.display = 'none';
            }
            else {
                slidedown("<%=divpurchase.ClientID %>");
                document.getElementById("showpurchase").style.display = 'none';
                document.getElementById("purchase").style.display = 'block';
            }
        }
        catch (err) {
        }
    }

    function delivery(val) {
        try {

            if (val == 'none') {
                slideup("<%=divdelivery.ClientID %>");
                document.getElementById("showdelivery").style.display = 'block';
                document.getElementById("delivery").style.display = 'none';
            }
            else {
                slidedown("<%=divdelivery.ClientID %>");
                document.getElementById("showdelivery").style.display = 'none';
                document.getElementById("delivery").style.display = 'block';
            }
        }
        catch (err) {
        }
    }


    function printbroker(val) {
        try {
            if (val == 'none') {
                slideup("<%=divprintbroker.ClientID %>");
                document.getElementById("showprintbroker").style.display = 'none';
                document.getElementById("printbroker").style.display = 'block';
            }
            else {

                slidedown("<%=divprintbroker.ClientID %>");
                document.getElementById("showprintbroker").style.display = 'block';
                document.getElementById("printbroker").style.display = 'none';
            }
        }
        catch (err) {
        }
    }

    estimate('block');
    job('none');
    invoice('none');
    purchase('none');
    printbroker('none');
    delivery('none');

</script>

