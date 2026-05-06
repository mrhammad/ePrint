<%@ Page Language="C#" Masterpagefile="/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="client_detail.aspx.cs" Inherits="ePrint.client.client_detail" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/crm/ClientSubSection.ascx" TagName="Client" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="navigatorpanel">
        
        <div class="divpadding">
            <div align="left" nowrap="nowrap" style="margin-top: -10px; margin-left: 5px; display: none">
                <span class="navigatorpanel">
                    <asp:Label ID="lbl_header" runat="server" Style="color: Black;"></asp:Label>
                    <asp:Label ID="lbl_Company" runat="server" Style="color: Black;"></asp:Label></span>
            </div>
        </div>
        <%--</div>
        </div>
        </div>--%>
        <div style="clear: both;">
        </div>
    </div>
    <div id="ds00" style="display: block;">
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="content">
        <div>
            <%--class="borderWithoutTop"--%>
            <div id="div_SubSection" align="left" style="width: 100%; padding: 12px 0px 0px 0px">
                <asp:PlaceHolder ID="plhClientSubSection" runat="server">
                    <div style="margin: -6px 2px 2px 0px">
                        <UC:Client ID="Client" runat="server" />
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
    </div>
    <div id="divrad" style="display: none;">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="580" OnClientClose="RadWinClose"
            Behaviors="Close, Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <input type="hidden" runat="server" id="hdn" />
    <input type="hidden" runat="server" id="hidid" />
    <input type="hidden" runat="server" id="hiddeleteid" />
    <input type="hidden" runat="server" id="hid_ClientID" />
    <input type="hidden" runat="server" id="hdnimagepath" />
    <input type="hidden" runat="server" id="hidtext" />
    <input type="hidden" runat="server" value="tata" id="hdntrigger" />
    <asp:HiddenField ID="hdnDispSummaryPopUp" runat="server" />
    <asp:HiddenField ID="hdnEstsumryPath" runat="server" Value="" />
    <script type="text/javascript" language="javascript" src="../js/HelpText/Mask.js?VN='<%=VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="../js/NotesSubject.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/mailaddanddelete.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/htmlemaildetail.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="../js/Float.js?VN='<%=VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="../js/attachmentaddDelete.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/attachmentadd.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/attachmentedit.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        pg = '<%=pg %>';
        function addcontact(val, type, clientid) {
            if (type == 'add') {


                window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?clientid=" + clientid + "&type=<%=companytype %>", '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else if (type == 'edit') {

                window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_edit.aspx?contactid=" + clientid + "", '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                // oWnd.centre();

            }
            else {

                window.radopen("<%=nmsCommon.global.sitePath()%>client/contact_view.aspx?clientid=" + clientid + "", '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
                // oWnd.centre();
            }
        }



        function editcontact(val, type, clientid, contactid) {
            window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?action=edit&clientid=" + clientid + "&contactid=" + contactid + "&type=<%=companytype %>", '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;
        }


        function opencontacts(val, type) {
            debugger
            if (val == 'contact') {
                if (type == 'add') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_view.aspx", '900', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'edit') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=newcontact&mode=edit&pg=" + pg, '900', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'view') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=newcontact&mode=view&pg=" + pg, '900', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
            }
            else if (val == 'address') {
                if (type == 'add') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=add&pg=" + pg + "&companytype=<%=companytype %>", '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'edit') {
                    window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=edit&pg=" + pg, '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'view') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&pg=" + pg, '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');

                }
            }
            else if (val == 'dept') {
                if (type == 'add') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&clientid=<%=ClientID%>&mode=add&pg=" + pg + "&companytype=<%=companytype %>&Pgtype=" + pg, '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'edit') {
                    window.open("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&mode=edit&pg=" + pg, '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
                else if (type == 'view') {
                    window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&mode=view&clientid=<%=ClientID%>&pg=" + pg + "&companytype=<%=companytype %>", '800', '400');
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                }
            }
        }

        function editaddress(val, type, id, clientid) {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=edit&clientid=" + clientid + "&addressid=" + id + "&pg=" + pg + "&companytype=<%=companytype %>", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

            return false;
        }


        function viewaddress(val, type, clientid) {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&mode=view&clientid=" + clientid + "&pg=" + pg, '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }

        function viewDept(val, type, clientid) {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreDept&clientid=<%=ClientID%>&mode=view&pg=<%=pg %>&pagenameDept=Dept", '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }

        function openhistory(clientid) {
            window.radopen("<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=actvityHistory&clientid=" + clientid + "", '900', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }


        function clickDelete() {
            return window.confirm('Are you sure you want to delete?');
        }

        function DeleteDept(val) {
            if (val.toLowerCase() == 'main') {
                alert("'Main' department cannot be deleted");
                return false;
            }
            else
                return window.confirm('Are you sure you want to delete?');
        }

        function Defaultcontact_click(ImageDefaultID, ImgDeleteID, ImageContactid, contactid, clientid, companyid) {
            var tablecount = document.getElementById("imgisdefault");
            var tableimages = tablecount.getElementsByTagName("img");


            for (i = 0; i < tableimages.length; i++) {
                if (tableimages[i].id.indexOf("IsDefault") != -1) {
                    if (tableimages[i].id.indexOf(ImageDefaultID) != -1) {

                        tableimages[i].src = tableimages[i].src.replace("check.gif", "check.gif");
                        tableimages[i].src = tableimages[i].src.replace("1t.gif", "check.gif");
                    }
                    else {
                        tableimages[i].src = tableimages[i].src.replace("check.gif", "1t.gif");
                        tableimages[i].src = tableimages[i].src.replace("1t.gif", "1t.gif");
                    }
                }

                if (tableimages[i].id.indexOf("ImgContact") != -1) {
                    if (tableimages[i].id == ImageContactid) {
                        tableimages[i].src = tableimages[i].src.replace("default-contact.jpg", "1t.gif");
                    }
                    else {
                        tableimages[i].src = tableimages[i].src.replace("1t.gif", "default-contact.jpg");
                    }
                }

                if (tableimages[i].id.indexOf("Imgdelete") != -1) {
                    if (tableimages[i].id == ImgDeleteID) {
                        tableimages[i].src = tableimages[i].src.replace("delete.gif", "1t.gif");
                    }
                    else {
                        tableimages[i].src = tableimages[i].src.replace("1t.gif", "delete.gif");
                    }
                }
            }

            AutoFill.GetDefaultClient(companyid, clientid, contactid);
            return false;
        }
        function RadWinClose() {

            document.getElementById("divrad").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }


      
    </script>
</asp:Content>
