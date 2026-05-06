<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="home_leftpanel.ascx.cs" Inherits="ePrint.home_leftpanel" %>

<tr valign="top">
    <td>
        <div id="div_home_main" style="display: block;">
            <div id="div_home_open" runat="server" onclick="show_home_leftpanel('none');" style="cursor: pointer;
                display: block">
                <table cellspacing="0" cellpadding="0" width="159px" border="0">
                    <tr>
                        <td valign="top" align="left" class="bgcustomize">
                            <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5px" />
                        </td>
                        <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                            <strong class="navigatorpanel" style="padding-right: 81px">
                                <%=objlang.GetLanguageConversion("Options")%></strong><img alt="" src="<%=strImagepath%>opentriangle.gif"
                                    align="absmiddle" />
                        </td>
                        <td valign="top" align="left" class="bgcustomize">
                            <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5px" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="div_home_close" runat="server" onclick="show_home_leftpanel('block');" style="cursor: pointer;
                display: none">
                <table cellspacing="0" cellpadding="0" width="159px" border="0">
                    <tr>
                        <td valign="top" align="left" class="bgcustomize">
                            <img src="<%=strImagepath%>lt_tabnotch.gif" width="5px" border="0" height="5" />
                        </td>
                        <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                            <strong style="padding-right: 81px" class="navigatorpanel">
                                <%=objlang.GetLanguageConversion("Options")%></strong><img alt="" src="<%=strImagepath%>triangle.gif"
                                    align="absmiddle" />
                        </td>
                        <td valign="top" align="left" class="bgcustomize">
                            <img src="<%=strImagepath%>rt_tabnotch.gif" width="5px" height="5" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </td>
</tr>
<tr valign="top">
    <td class="normaltext">
        <div id="div_home_contents1" style="display: block" runat="server">
            <div id="div_home_contents" style="display: block; overflow: hidden; height: <%=height%>px;">
                <ul id="verticalmenu" class='glossymenu1'>
                    <li id="lihome" runat="server" visible="true"><a href="<%=strSitepath%>welcome.aspx">
                        &nbsp;&nbsp;Home</a></li>
                    <li id="litask" runat="server" visible="true"><a href="<%=strSitepath%>common/task_add.aspx?tasktype=home&tasktypeid=0">
                        &nbsp;&nbsp;
                        <%=objlang.GetLanguageConversion("Add_Task")%></a> </li>
                    <li id="lievent" runat="server" visible="true"><a href="<%=strSitepath%>common/event_add.aspx?tasktype=home&tasktypeid=0">
                        &nbsp;&nbsp;
                        <%=objlang.GetLanguageConversion("Add_Event")%></a> </li>
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
<%--<script>
                var menuids1=new Array("verticalmenu1") //Enter id(s) of UL menus, separated by commas                
                var submenuoffset1=-2 //Offset of submenus from main menu. Default is -2 pixels.

        function createcssmenu()
        {
//           for(var i=0;i<menuids.length;i++)
//           {
//              var ultags=document.getElementById(menuids[i].getElementsByTagName("ul"));
//              alert(ultags.length);
//           }
             for (var i=0; i<menuids1.length; i++)
             {
                 var ultags='';
                 try
                 {
                  ultags=document.getElementById(menuids1[i]).getElementsByTagName("ul")
                 }
                 catch (err)
                 {
                 } 
                  
                  for (var t=0; t<ultags.length; t++)
                  {
                    var innerli=document.getElementById("innerli");
                    var spanref=document.createElement("span")
                    spanref.className="arrowdiv"
                    spanref.innerHTML="&nbsp;&nbsp;"
                    ultags[t].parentNode.getElementsByTagName("a")[0].appendChild(spanref)
                        ultags[t].parentNode.onmouseover=function()
                       {
                       //this.getElementsByTagName("ul")[0].style.left=this.parentNode.offsetWidth+submenuoffset+"px";
                       this.getElementsByTagName("ul")[0].style.left=this.parentNode.offsetWidth+submenuoffset1+"px";
                       this.getElementsByTagName("ul")[0].style.display="block";
                        }
                         ultags[t].parentNode.onmouseout=function()
                        {
                        this.getElementsByTagName("ul")[0].style.display="none"
                        }
                  }
                
                  
           }
        }


if (window.addEventListener)
window.addEventListener("load", createcssmenu, false)
else if (window.attachEvent)
window.attachEvent("onload", createcssmenu)
</script>
--%>
<script language="javascript" type="text/javascript">

    function show_home_leftpanel(val) {
        if (val == 'none') {

            //slideup('div_home_contents');
            document.getElementById("<%=div_home_open.ClientID %>").style.display = 'none';
            document.getElementById("<%=div_home_close.ClientID %>").style.display = 'block';
            document.getElementById("<%=div_home_contents1.ClientID %>").style.display = 'none';
        }
        else {

            //slidedown('div_home_contents');
            document.getElementById("<%=div_home_open.ClientID %>").style.display = 'block';
            document.getElementById("<%=div_home_close.ClientID %>").style.display = 'none';
            document.getElementById("<%=div_home_contents1.ClientID %>").style.display = 'block';

        }
    }
</script>

