<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="company_leftpanel.ascx.cs" Inherits="ePrint.usercontrol.company_leftpanel" %>


<%@ Register TagPrefix="UC" TagName="Task" Src="~/usercontrol/Item/estimate_task_add.ascx" %>
<asp:Panel runat="server" ID="pnlcompany" Visible="false">
    <tr valign="top">
        <td>
            <div id="div_copmpany_main" style="display: block;">
                <div id="div_copmpany_open" runat="server" onclick="show_company_leftpanel('none');"
                    style="cursor: pointer; display: block">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 81px">Options</strong><img alt=""
                                    src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_copmpany_close" runat="server" onclick="show_company_leftpanel('block');"
                    style="cursor: pointer; display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong style="padding-right: 81px" class="navigatorpanel">Options</strong><img alt=""
                                    src="<%=strImagepath%>triangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td class="normaltext">
            <div id="div_copmpany_contents1" style="display: block" runat="server">
                <ul id="verticalmenu" class="glossymenu1">
                    <%--Create on 04-05-2011, Praveen, START--%>
                    <li id="Accouts_View" runat="server" visible="false"><a href="<%=strSitepath%>accounts/accounts_view.aspx?type=customer"
                        title="Click to view estore accounts">&nbsp;&nbsp;eStore Accounts</a></li>
                    <li id="createAccount" runat="server" visible="false"><a href="<%=strSitepath%>Accounts/accounts_new_create.aspx?type=Customer"
                        title="Click to create eStore Account">&nbsp;&nbsp;Create eStore Acct.</a></li>
                    <li id="addNewView" runat="server" visible="false"><a href="<%=strSitepath%>Accounts/Accounts_edit_view.aspx"
                        title="Click to add new view">&nbsp;&nbsp;Add New View</a> </li>
                    <li id="editView" runat="server" visible="false" style="cursor: pointer"><a onclick="javascript:checkpath1()">
                        &nbsp;&nbsp;Edit View</a> </li>
                    <%--Create on 04-05-2011, Praveen, END--%>
                    <li id="li_Customers" runat="server" visible="true"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Customer") %></a>
                        <ul style="border-top: solid 1px #ccc" id="ul1" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            <%-- <li><a href="<%=strSitepath%>client/client_add.aspx?type=Customer">&nbsp;&nbsp;Add</a></li>--%>
                            <li>
                                <asp:LinkButton ID="lnKAddCustomer" runat="server" OnClick="lnkAddCustomer_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Add") %></asp:LinkButton></li>
                            <%-- <li><a href="<%=strSitepath%>client/client_view.aspx?type=Customer">&nbsp;&nbsp;View</a></li>--%>
                            <li>
                                <asp:LinkButton ID="lnKViewCustomer" runat="server" OnClick="lnKViewCustomer_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("View") %></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li id="li_Suppliers" runat="server" visible="true"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Supplier") %></a>
                        <ul style="border-top: solid 1px #ccc" id="ul3" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            <%--<li><a href="<%=strSitepath%>client/client_add.aspx?type=Supplier">&nbsp;&nbsp;Add</a></li>
                            <li><a href="<%=strSitepath%>client/client_view.aspx?type=Supplier">&nbsp;&nbsp;View</a></li>--%>
                            <li>
                                <asp:LinkButton ID="lnKAddSupplier" runat="server" OnClick="lnKAddSupplier_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Add") %></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnKViewSupplier" runat="server" OnClick="lnKViewSupplier_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("View") %></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li id="li_Prospects" runat="server" visible="true"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Prospect") %></a>
                        <ul style="border-top: solid 1px #ccc" id="ul4" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            <%--<li><a href="<%=strSitepath%>client/client_add.aspx?type=Prospect">&nbsp;&nbsp;Add</a></li>
                            <li><a href="<%=strSitepath%>client/client_view.aspx?type=Prospect">&nbsp;&nbsp;View</a></li>--%>
                            <li>
                                <asp:LinkButton ID="lnKAddProspect" runat="server" OnClick="lnKAddProspect_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Add") %></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnKViewProspect" runat="server" OnClick="lnKViewProspect_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("View") %></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li id="licontactview" runat="server" visible="true">
                        <%--<a href="<%=strSitepath%>contact/contact_view.aspx">
                        &nbsp;&nbsp;View Contacts</a>--%>
                        <asp:LinkButton ID="LnkViewContacts" runat="server" OnClick="LnkViewContacts_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("View_Contacts") %></asp:LinkButton>
                    </li>
                    <li id="liaddview" runat="server" visible="false"><a href="<%=strSitepath%>client/CustomViewCRM.aspx<%=Path %>">
                        &nbsp;&nbsp;Add New View</a> </li>
                    <li id="lieditview" runat="server" visible="false" style="cursor: pointer"><a onclick="javascript:checkpath()">
                        &nbsp;&nbsp;Edit View</a> </li>
                    <li id="report" runat="server" visible="true">
                        <%--<a href="<%=strSitepath%>contact/contact_view.aspx">
                        &nbsp;&nbsp;View Contacts</a>--%>
                        <asp:LinkButton ID="lnkCRMReports" runat="server" OnClick="lnkCRMReports_OnClick">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Reports") %></asp:LinkButton>
                    </li>
                    <%--  <li id="report" runat="server" visible="true"><a href="<%=strSitepath%>client/client_report.aspx">
                        &nbsp;&nbsp;Reports</a></li>--%>
                </ul>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<asp:Panel runat="server" ID="pnlhome" Visible="false">
    <tr valign="top">
        <td>
            <div id="div_home_main" style="display: none;">
                <div id="div_home_open" runat="server" onclick="show_home_leftpanel('none');" style="cursor: pointer;
                    display: block">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5" border="0" height="5px">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 81px">Options1</strong><img
                                    alt="" src="<%=strImagepath%>opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="div_home_close" runat="server" onclick="show_home_leftpanel('block');" style="cursor: pointer;
                    display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong style="padding-right: 81px" class="navigatorpanel">Options1</strong><img
                                    alt="" src="<%=strImagepath%>triangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td class="normaltext">
            <div id="div_home_contents1" style="display: none" runat="server"> 
                <div id="div_home_contents" style="display: block; overflow: hidden; height: 55px;">
                    <ul id="Ul2" class="glossymenu11">
                        <li id="lihome" runat="server" visible="true"><a href="<%=strSitepath%>welcome.aspx">
                            &nbsp;&nbsp;Home</a></li>
                        <li id="litask" runat="server" visible="true"><a href="<%=strSitepath%>common/task_add.aspx?tasktype=home&tasktypeid=0">
                            &nbsp;&nbsp;Add Task1</a> </li>
                        <li id="lievent" runat="server" visible="true"><a href="<%=strSitepath%>common/event_add.aspx?tasktype=home&tasktypeid=0">
                            &nbsp;&nbsp;Add Event1</a> </li>
                    </ul>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="<%=strImagepath%>nil.gif" height="10" />
        </td>
    </tr>
</asp:Panel>
<script type="text/javascript" language="javascript">
    function show_company_leftpanel(val) {

        //ctl00_divrecentitem1.style.display=val;show_home_leftpanel
        //alert(val);
        if (val == 'none') {

            //slideup('div_copmpany_contents');
            document.getElementById("ctl00_Printbroker1_div_copmpany_open").style.display = 'none';
            document.getElementById("ctl00_Printbroker1_div_copmpany_close").style.display = 'block';
            document.getElementById("ctl00_Printbroker1_div_copmpany_contents1").style.display = val;

        }
        else {
            //slidedown('div_copmpany_contents');
            document.getElementById("ctl00_Printbroker1_div_copmpany_open").style.display = 'block';
            document.getElementById("ctl00_Printbroker1_div_copmpany_close").style.display = 'none';
            document.getElementById("ctl00_Printbroker1_div_copmpany_contents1").style.display = val;
        }
    }
    function show_home_leftpanel(val) {
        if (val == 'none') {

            slideup('div_home_contents');
            document.getElementById("ctl00_Printbroker1_div_home_open").style.display = 'none';
            document.getElementById("ctl00_Printbroker1_div_home_close").style.display = 'block';


        }
        else {

            slidedown('div_home_contents');
            document.getElementById("ctl00_Printbroker1_div_home_open").style.display = 'block';
            document.getElementById("ctl00_Printbroker1_div_home_close").style.display = 'none';
            document.getElementById("ctl00_Printbroker1_div_home_contents1").style.display = val;

        }
    }
    
    function hidedropdown() {
        try {
            document.getElementById("ctl00_ContentPlaceHolder1_sectionView_ddlsectionView").style.display = "none";
        }
        catch (err) {

        }

    }
    function showdropdown() {
        try {
            document.getElementById("ctl00_ContentPlaceHolder1_sectionView_ddlsectionView").style.display = "block";
        }
        catch (err) {

        }
    }
    function checkpath() {
        var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddl_View_cust");
        var pgtype = "customer";
        if (window.location.search.substring(1) != '') {
            var qrystr = window.location.search.substring(1).split("=");
            if(qrystr[0] == 'type')
            {
              pgtype = qrystr[1];
            }
        }
        window.location.href = "<%=strSitepath%>" + "client/CustomViewCRM.aspx?type=edit&id=" + ddl.options[ddl.selectedIndex].value + "&cid=" + <%=companyid%> + "&pgtype=" + pgtype;
    }
    function checkpath1() {
        var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddl_View_cust");
        var pgtype = "accounts";
        if (window.location.search.substring(1) != '') {
            var qrystr = window.location.search.substring(1).split("=");
            if(qrystr[0] == 'type')
            {
              pgtype = qrystr[1];
            }
        }
        window.location.href = "<%=strSitepath%>" + "accounts/accounts_edit_view.aspx?type=edit&id=" + ddl.options[ddl.selectedIndex].value + "&cid=" + <%=companyid%> + "&pgtype=" + pgtype;
    }
</script>
<script>
    var menuids1 = new Array("verticalmenu1") //Enter id(s) of UL menus, separated by commas                
    var submenuoffset1 = -2 //Offset of submenus from main menu. Default is -2 pixels.

    function createcssmenu() {
        //           for(var i=0;i<menuids.length;i++)
        //           {
        //              var ultags=document.getElementById(menuids[i].getElementsByTagName("ul"));
        //              alert(ultags.length);
        //           }
        for (var i = 0; i < menuids1.length; i++) {
            var ultags = '';
            try {
                ultags = document.getElementById(menuids1[i]).getElementsByTagName("ul")
            }
            catch (err) {
            }

            for (var t = 0; t < ultags.length; t++) {
                var innerli = document.getElementById("innerli");
                var spanref = document.createElement("span")
                spanref.className = "arrowdiv"
                spanref.innerHTML = "&nbsp;&nbsp;"
                ultags[t].parentNode.getElementsByTagName("a")[0].appendChild(spanref)
                ultags[t].parentNode.onmouseover = function () {
                    //this.getElementsByTagName("ul")[0].style.left=this.parentNode.offsetWidth+submenuoffset+"px";
                    this.getElementsByTagName("ul")[0].style.left = this.parentNode.offsetWidth + submenuoffset1 + "px";
                    this.getElementsByTagName("ul")[0].style.display = "block";
                }
                ultags[t].parentNode.onmouseout = function () {
                    this.getElementsByTagName("ul")[0].style.display = "none"
                }
            }
        }
    }

    if (window.addEventListener)
        window.addEventListener("load", createcssmenu, false)
    else if (window.attachEvent)
        window.attachEvent("onload", createcssmenu)



        
</script>
<script type="text/javascript" language="javascript">

    function ShowTask() {
        document.getElementById("div_Task").style.display = "block";
        showDivPopupCenter('div_task_add', '250');
        return false;
    }
        
</script>
