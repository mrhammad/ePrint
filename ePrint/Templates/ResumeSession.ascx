<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumeSession.ascx.cs" Inherits="ePrint.Templates.ResumeSession" %>




<script language="JavaScript" src="<%=strSitepath%>js/dimmingdiv.js?VN='<%=VersionNumber%>'">
</script>

<script language="JavaScript" src="<%=strSitepath%>js/js_class.js?VN='<%=VersionNumber%>'">
</script>

<div style="width: 2px; height: 2px; visibility: hidden" class="dimmer_new" id="windowcontent">
    <table id="table_ResumeSession" style="display: none" class="error_yello" border="0"
        cellspacing="2" width="50%" align="center">
        <tr>
            <td colspan="3">
                <table class="floatingHeader" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td ondblclick="void(0);" onmouseover="over=true;" onmouseout="over=false;" style="cursor: move;
                            height: 18px">
                            Resume Session
                        </td>
                        <td style="width: 18px" align="right">
                            <img style="cursor: hand" onclick="javascript:Rediret_Window(); return false;" src="<%=strImagepath%>close.jpg"
                                alt="Close" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 10px">
                <%--<iframe id="ifrm" src="<%=strSitepath%>Estimates/SessionExpire.aspx?first=<%=first%>&second=<%=second%>&url=<%=currenturl%>">
                </iframe>--%>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 10px">
            </td>
        </tr>
    </table>
</div>

<script language="javascript">
      
        var ifrm=document.getElementById("ifrm");      
      
            function Rediret_Window()
            {
            window.location.href="<%=strSitepath%>logout.aspx";
            return false;
            }
            function cloaseWindow()
            {
            hiddenFloatingDiv('windowcontent');
            }
		    function displayWindow()
		    {
		        var txtPassword=document.getElementById("ctl00_header1_ucResumesession_txtPassword")
		        var w, h, l, t;
		        w = 250;
		        h = 10;
		        l = screen.width/4;
		        t = screen.height/4;
		        displayFloatingDiv('windowcontent', 'Resume Session', w, h, l, t);
		    }
	
		    var totalTime="<%=int_TimeOut%>";
		    
		    var RedirectPage="<%=str_RedirectPage%>";
		   
		    if(RedirectPage=='yes')
		    {		     
		        if(totalTime!="59940000")//never
		        {
	            window.setInterval('Rediret_Window()',"<%=int_MilliSecondsTimeOut.ToString()%>"); 
	            }
	        }
	        else
	        {
	         if(totalTime!="59940000")
		        {
		         // alert('kumar');
	             window.setInterval('displayWindow()',"<%=int_MilliSecondsTimeOut.ToString()%>"); 
	            }
	        }
		
</script>



