<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client_add.aspx.cs" Inherits="ePrint.client_add" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="ctl00_Head1">

<style>
<!--
.shadow_right {
    background-image: url( "https://demo.eprintsoftware.com/document/securedoc/demo/1534/1pixel.jpg" );
}
-->
</style>

    <title>
	ePrint MIS: Add New Company
</title>
    <noscript>
        Your browser does not support JavaScript! ...
    </noscript>
    <script type="text/javascript">
        var roundoff = '2';
        var currentdate = '3/22/2016';
    </script>
<link href="../App_Themes/Theme1/_vti_cnf/cropper.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/_vti_cnf/css.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/_vti_cnf/dimming.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/_vti_cnf/item.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/_vti_cnf/user.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/Button.EprintbtnSkin.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/checkbox.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/ComboBox.Eprint_Skin.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/Grid.Eprint_Skin.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/item.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/ListBox.Eprint_Skin.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/menu.css" type="text/css" rel="stylesheet" /><link href="../App_Themes/Theme1/Menu.Eprint_Skin.css" type="text/css" rel="stylesheet" /><link rel='shortcut icon' href='1534/favicon.ico'><link href="/WebResource.axd?d=XMkoyCKnRdZClBAGqhi7_uOWQ9Fu67L6EoSy3JYLei6YlltNdj2eHtbm3PeF8abC9mxUlTyS7jNBYJcZ-AJObqbadPFZOfaaUF37R2cHDMZVjxmgHeataTpoShmPt1wLI2i1dA2&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=tl-kH-pef3tf0PlOgBXWUjdKsIhfKqzTPpP-QqswZnvRMWyOL_lg8pSwLRjoYT4cshGxCL-NIJ7vDK2O6oZqwj6PTG0Z3yVCWfcYSxBtgRwa5Pm1IpheRcMU-UC__5pW35uYaQF6ojW7HJr8I1QHZkgFoYw1&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=pJjZU_y5tmWGRr_G4ZZH-v_1k_VeMDkBPXco0lBwL2KODkbmPzeVx2-sLkNEgybQhdv2ftsQoxZSvhkb-4K0ArQEZG3UWZYzDvJMLsZ7ny0OqAJYdzDNBFWSiYuNR3HOkCv5Pw2&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=6XOt_yYcmftokeNoodYaRshb7aI3yqsmpFqkDkxuD8f4xFjDb5n7E8End_bWnx0ieRiyVULYH0PTwW8-jjs_F-476jR1soxafmoPvAkRiOyzWQPOsJ_oD-coF4ogxf-C2KTqgW8Vxu6IrzfT0vRskuVIVfE1&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=JD2xdfMm9ryaw4Ae1JzqD8HwTTN0lFrFZHWaxGrOxAq-6kka2PyuvS2m4aagFFlTM9uBg124ffRljteor-MjY_klGRCm9P88YR595rYR8kjF6UEyRjFmwslzFq0MJpmCw748CQ2&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=eWR37-b1d4EN2Ng7mWRA9GPHNAgrroPbW3yg0gpDAU4d1ivMpQHp0xNqQd1GGLtpbQFFuHc8PXcuR4OIiXrn6Ir_bfK1tOW7CrvR4PpfilSWMkEiFMV-o3_Kqo_QCKti2EMbbw2&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=3H5dsTTutLEPLsjIOO987j1gvc70NWGjJo3ZCMQODUVQ372ciribhFnk_6mp20c6fjPayURBXkh-Sm0WLY1UAtFbS8X5fxFdqUWBvMGRs6pvzavI2X7r3GCDAazKEem3ryq8Cu35SOm9uczMu6LVhHZowyw1&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=nsxomYHQe6jRXiAiEkBSA2fBxglcPqIEExIjZlncjC_tp5EikVWUG98BeqU7PIHEJLAuAGDCwVMATQ6C-xXFnh7mpto9ziOxB9HkFF5-XY_Wr2mKpyXIw7VZM-Rzp1Ye1FA1kKnnZsSywmENRuzdbVaVvHY1&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=Vv6BI_dPykyNbTcnfD1YqTKcIeJE-ayZ0qCT2V_dBLNzbMcwg_ZZfElimgTOdjqJ9TDaZ3NF6Ri4BPOm7noZoHG7Br40nL3Pi7UvNKfXNQmXMkVJGhgycI3VwdVzWLGQ_JMlHg2&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /><link href="/WebResource.axd?d=6136r4Vxh4hmAMILklG7ERIBuTtx0AoexQ0Y3rGn9zbfaCHEgpu9Ki_HqG4MjQtEs9nSb_0-4S9n4chHorkpUSK81InWRwb7NBgl_-VEe5EhYsuEb0B5ymi7Mbrc2YtUzl4HsCkHL9abIYk4Yez1ZqCydDI1&amp;t=634279334100000000" type="text/css" rel="stylesheet" class="Telerik_stylesheet" /></head>
<body id="myBody">
    <style>.navigator{font-size:11px;color:#FFFFFF;font-family:Verdana,Arial;font-weight: Bold;vertical-align: middle;}.navigatorpanel,.loggedin{font-size:11px;color:#FFFFFF;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;font-weight: Bold;vertical-align: middle;}.bgcustomize{background-color:#2259D7;color:#FFFFFF;}A.subnavigator,A.subnavigator:hover,A.subnavigator:visited{text-decoration: none;COLOR:#FFFFFF;FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;font-weight: Bold;FONT-SIZE: 11px;}.norecords{font-size:11px;color:#FFFFFF;vertical-align: middle;}div.t{height: 23px;padding: 0;margin: 0;overflow: hidden;vertical-align:middle;color:#FFFFFF;background:#2259D7 url(https://demo.eprintsoftware.com/images/j_border.png) 0 0 repeat-x;}div.t div.t{background:url(https://demo.eprintsoftware.com/images/rt_tabnotch.gif) 100% 0 no-repeat;}div.t div.t div.t{background: url(https://demo.eprintsoftware.com/images/lt_tabnotch.gif) 0 0 no-repeat;}</style>
    <div id="divXIWL">
        <form method="post" action="client_add.aspx?type=Customer" id="aspnetForm">

	<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="A967E43E" />
            <input id="ctl00_header1_ddl_Search_ClientState" name="ctl00_header1_ddl_Search_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker6_FromHeader_ClientState" name="ctl00_header1_RadTimePicker6_FromHeader_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker6_FromHeader_timeView_ClientState" name="ctl00_header1_RadTimePicker6_FromHeader_timeView_ClientState" type="hidden" />
			<input id="ctl00_header1_RadTimePicker6_FromHeader_dateInput_ClientState" name="ctl00_header1_RadTimePicker6_FromHeader_dateInput_ClientState" type="hidden" /><input id="ctl00_header1_RadTimePicker5_FromHeader_ClientState" name="ctl00_header1_RadTimePicker5_FromHeader_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker5_FromHeader_timeView_ClientState" name="ctl00_header1_RadTimePicker5_FromHeader_timeView_ClientState" type="hidden" />
			<input id="ctl00_header1_RadTimePicker5_FromHeader_dateInput_ClientState" name="ctl00_header1_RadTimePicker5_FromHeader_dateInput_ClientState" type="hidden" />
                                                                                    <input type="hidden" name="ctl00$header1$hdnTaskID" id="ctl00_header1_hdnTaskID" />
                                                                                <input id="ctl00_header1_RadTimePicker1_FromHeader_ClientState" name="ctl00_header1_RadTimePicker1_FromHeader_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker1_FromHeader_timeView_ClientState" name="ctl00_header1_RadTimePicker1_FromHeader_timeView_ClientState" type="hidden" />
			<input id="ctl00_header1_RadTimePicker1_FromHeader_dateInput_ClientState" name="ctl00_header1_RadTimePicker1_FromHeader_dateInput_ClientState" type="hidden" /><input id="ctl00_header1_RadTimePicker4_FromHeader_ClientState" name="ctl00_header1_RadTimePicker4_FromHeader_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker4_FromHeader_timeView_ClientState" name="ctl00_header1_RadTimePicker4_FromHeader_timeView_ClientState" type="hidden" />
			<input id="ctl00_header1_RadTimePicker4_FromHeader_dateInput_ClientState" name="ctl00_header1_RadTimePicker4_FromHeader_dateInput_ClientState" type="hidden" />
                                                                                        <input type="hidden" name="ctl00$header1$hdncallHours" id="ctl00_header1_hdncallHours" />
                                                                                        <input type="hidden" name="ctl00$header1$hdncallstaTime" id="ctl00_header1_hdncallstaTime" />
                                                                                        <input id="ctl00_header1_RadTimePicker_FromHeader_ClientState" name="ctl00_header1_RadTimePicker_FromHeader_ClientState" type="hidden" />
            <input id="ctl00_header1_RadTimePicker_FromHeader_timeView_ClientState" name="ctl00_header1_RadTimePicker_FromHeader_timeView_ClientState" type="hidden" />
			<input id="ctl00_header1_RadTimePicker_FromHeader_dateInput_ClientState" name="ctl00_header1_RadTimePicker_FromHeader_dateInput_ClientState" type="hidden" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl11$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl11_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl10$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl10_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl09$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl09_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl08$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl08_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl07$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl07_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl06$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl06_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl05$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl05_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl04$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl04_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl03$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl03_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl02$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl02_hdn_Forecolor" value="#FFFFFF" />
                                                                                        <input type="hidden" name="ctl00$header1$upperRepeater$ctl00$hdn_Forecolor" id="ctl00_header1_upperRepeater_ctl00_hdn_Forecolor" value="#FFFFFF" />
<div>
<input type="hidden" name="__LASTFOCUS" id="__LASTFOCUS" value="" />
<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTMwMTkxMzQ0MA9kFgJmD2QWBGYPZBYCAgEPFQIBMgkzLzIyLzIwMTZkAgIPZBYGAgQPZBYCZg8PFgIeBFRleHQFwQI8c3BhbiBjbGFzcz0nbmF2aWdhdG9ycGFuZWxibGFjayc+PGI+PGEgaHJlZj0uLi93ZWxjb21lLmFzcHggY2xhc3M9J3N1Ym5hdmlnYXRvcmJsYWNrJyBzdHlsZT10ZXh0LWRlY29yYXRpb246dW5kZXJsaW5lPkhvbWU8L2E+Jm5ic3A7PiZuYnNwOzxhIGhyZWY9Y2xpZW50X3ZpZXcuYXNweCBjbGFzcz0nc3VibmF2aWdhdG9yYmxhY2snIHN0eWxlPXRleHQtZGVjb3JhdGlvbjp1bmRlcmxpbmU+Q1JNIFZpZXc8L2E+PC9iPjwvc3Bhbj48c3BhbiBjbGFzcz0nbmF2aWdhdG9ycGFuZWxibGFjayc+PGI+Jm5ic3A7PiZuYnNwOyBDdXN0b21lciBBZGQgPC9iPjwvc3Bhbj5kZAIFD2QWAgIBDxYCHgVzdHlsZQUNZGlzcGxheTpub25lOxYEAgMPZBYCAgEPZBYCZg8PFgIeB1Zpc2libGVnZGQCBQ9kFgICAQ9kFgICBg9kFgYCBQ9kFgICAQ8UKwACFCsAAmQQFgNmAgECAhYDFCsAAmRkFCsAAg9kFgQeBVN0eWxlBRBjdXJzb3I6IHBvaW50ZXI7HgdvbmNsaWNrBTZqYXZhc2NyaXB0OlNob3dQcm9ncmVzc1RvSm9iRnJvbU9yZGVycygpO3JldHVybiBmYWxzZTtkFCsAAg9kFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBR1qYXZhc2NyaXB0OlNob3dBdHRhY2htZW50cygpO2QPFgNmZmYWAQV1VGVsZXJpay5XZWIuVUkuUmFkUGFuZWxJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0ZBYGZg9kFgICAQ8UKwACFCsAAmQQFgFmFgEUKwACD2QWAh8DBQ9jdXJzb3I6IHBvaW50ZXIQFgJmAgEWAhQrAAIPZBYCHwMFEGN1cnNvcjogcG9pbnRlcjtkFCsAAg9kFgIfAwUQY3Vyc29yOiBwb2ludGVyO2QPFgJmZhYBBXRUZWxlcmlrLldlYi5VSS5SYWRNZW51SXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNA8WAWYWAQV0VGVsZXJpay5XZWIuVUkuUmFkTWVudUl0ZW0sIFRlbGVyaWsuV2ViLlVJLCBWZXJzaW9uPTIwMTAuMy4xMjE1LjIwLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTEyMWZhZTc4MTY1YmEzZDRkFgJmDw9kFgIfAwUPY3Vyc29yOiBwb2ludGVyFgRmDw9kFgIfAwUQY3Vyc29yOiBwb2ludGVyO2QCAQ8PZBYCHwMFEGN1cnNvcjogcG9pbnRlcjtkAgEPD2QWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFNmphdmFzY3JpcHQ6U2hvd1Byb2dyZXNzVG9Kb2JGcm9tT3JkZXJzKCk7cmV0dXJuIGZhbHNlO2QCAg8PZBYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUdamF2YXNjcmlwdDpTaG93QXR0YWNobWVudHMoKTtkAgkPZBYCAgEPFCsAAhQrAAJkEBYGZgIBAgICAwIEAgUWBhQrAAIPZBYCHwMFC3otaW5kZXg6IDA7ZBQrAAIPFgIfAAUIQWRkIEl0ZW0WAh8DBRBjdXJzb3I6IHBvaW50ZXI7EBYBZhYBFCsAAg9kFgIfAwUlbWFyZ2luLXRvcDogMTBweDsgbWFyZ2luLWJvdHRvbTogMTBweGQPFgFmFgEFdVRlbGVyaWsuV2ViLlVJLlJhZFBhbmVsSXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNBQrAAIPFgIfAAUPUHJvZ3Jlc3MgdG8gSm9iFgQfAwUeY3Vyc29yOiBwb2ludGVyOyBkaXNwbGF5OiBub25lHwQFLGphdmFzY3JpcHQ6U2hvd1Byb2dyZXNzVG9Kb2IoKTtyZXR1cm4gZmFsc2U7ZBQrAAIPFgIfAAULQXR0YWNobWVudHMWAh8DBRBjdXJzb3I6IHBvaW50ZXI7ZBQrAAIPFgIfAAUNQ29weSBFc3RpbWF0ZWQQFgJmAgEWAhQrAAIPFgIfAAUQVG8gU2FtZSBDdXN0b21lchYEHwQFMmphdmFzY3JpcHQ6RXN0aW1hdGVDb3B5dG9fU2FtZUN1c3QoKTtyZXR1cm4gZmFsc2U7HwMFEGN1cnNvcjogcG9pbnRlcjtkFCsAAg8WAh8ABQ9UbyBOZXcgQ3VzdG9tZXIWBB8EBTFqYXZhc2NyaXB0OkVzdGltYXRlQ29weXRvX05ld0N1c3QoKTtyZXR1cm4gZmFsc2U7HwMFEGN1cnNvcjogcG9pbnRlcjtkDxYCZmYWAQV1VGVsZXJpay5XZWIuVUkuUmFkUGFuZWxJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0FCsAAg8WAh8ABRJSZXZlcnQgdG8gRXN0aW1hdGUWAh8DBTxjdXJzb3I6IHBvaW50ZXI7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgZGlzcGxheTogbm9uZTtkDxYGZmZmZmZmFgEFdVRlbGVyaWsuV2ViLlVJLlJhZFBhbmVsSXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNGQWDGYPD2QWAh8DBQt6LWluZGV4OiAwOxYCAgEPFCsAAhQrAAJkEBYBZhYBFCsAAg8WAh8ABQtQcmludC9FbWFpbBYCHwMFSWN1cnNvcjogcG9pbnRlcjsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgei1pbmRleDogMDsQFgNmAgECAhYDFCsAAg9kFgIfAwUQY3Vyc29yOiBwb2ludGVyO2QUKwACD2QWAh8DBRBjdXJzb3I6IHBvaW50ZXI7ZBQrAAIPZBYCHwMFEGN1cnNvcjogcG9pbnRlcjtkDxYDZmZmFgEFdFRlbGVyaWsuV2ViLlVJLlJhZE1lbnVJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0DxYBZhYBBXRUZWxlcmlrLldlYi5VSS5SYWRNZW51SXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNGQWAmYPDxYCHwAFC1ByaW50L0VtYWlsFgIfAwVJY3Vyc29yOiBwb2ludGVyOw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB6LWluZGV4OiAwOxYGZg8PZBYCHwMFEGN1cnNvcjogcG9pbnRlcjtkAgEPD2QWAh8DBRBjdXJzb3I6IHBvaW50ZXI7ZAICDw9kFgIfAwUQY3Vyc29yOiBwb2ludGVyO2QCAQ8PFgIfAAUIQWRkIEl0ZW0WAh8DBRBjdXJzb3I6IHBvaW50ZXI7FgJmDw9kFgIfAwUlbWFyZ2luLXRvcDogMTBweDsgbWFyZ2luLWJvdHRvbTogMTBweBYCAgEPFCsAAhQrAAJkEBYIZgIBAgICAwIEAgUCBgIHFggUKwACDxYCHwAFEVNoZWV0IEZlZCBEaWdpdGFsZBAWA2YCAQICFgMUKwACDxYCHwAFC1NpbmdsZSBJdGVtFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBSxqYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdTJyk7cmV0dXJuIGZhbHNlO2QUKwACDxYCHwAFB0Jvb2tsZXQWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0InKTtyZXR1cm4gZmFsc2U7ZBQrAAIPFgIfAAUEUGFkcxYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnUCcpO3JldHVybiBmYWxzZTtkDxYDZmZmFgEFdFRlbGVyaWsuV2ViLlVJLlJhZE1lbnVJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0FCsAAg8WAh8ABRBTaGVldCBGZWQgT2Zmc2V0ZBAWBGYCAQICAgMWBBQrAAIPFgIfAAULU2luZ2xlIEl0ZW0WBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0YnKTtyZXR1cm4gZmFsc2U7ZBQrAAIPFgIfAAUHQm9va2xldBYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnSycpO3JldHVybiBmYWxzZTtkFCsAAg8WAh8ABQNOQ1IWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ04nKTtyZXR1cm4gZmFsc2U7ZBQrAAIPFgIfAAUEUGFkcxYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnRCcpO3JldHVybiBmYWxzZTtkDxYEZmZmZhYBBXRUZWxlcmlrLldlYi5VSS5SYWRNZW51SXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNBQrAAIPFgIfAAUHT3V0d29yaxYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnTycpO3JldHVybiBmYWxzZTtkFCsAAg8WAh8ABRFQcm9kdWN0IENhdGFsb2d1ZRYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnQycpO3JldHVybiBmYWxzZTtkFCsAAg8WAh8ABQtPdGhlciBDb3N0cxYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnVScpO3JldHVybiBmYWxzZTtkFCsAAg8WAh8ABQxMYXJnZSBGb3JtYXQWAh8DBRBjdXJzb3I6IHBvaW50ZXI7EBYCZgIBFgIUKwACD2QWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0wnKTtyZXR1cm4gZmFsc2U7ZBQrAAIPZBYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUtamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnU3EnKTtyZXR1cm4gZmFsc2U7ZA8WAmZmFgEFdFRlbGVyaWsuV2ViLlVJLlJhZE1lbnVJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0FCsAAg8WAh8ABQlJbnZlbnRvcnkWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ1cnKTtyZXR1cm4gZmFsc2U7ZBQrAAIPFgIfAAULUXVpY2sgUXVvdGUWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ1EnKTtyZXR1cm4gZmFsc2U7ZA8WCGZmZmZmZmZmFgEFdFRlbGVyaWsuV2ViLlVJLlJhZE1lbnVJdGVtLCBUZWxlcmlrLldlYi5VSSwgVmVyc2lvbj0yMDEwLjMuMTIxNS4yMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0xMjFmYWU3ODE2NWJhM2Q0ZBYQZg8PFgIfAAURU2hlZXQgRmVkIERpZ2l0YWxkFgZmDw8WAh8ABQtTaW5nbGUgSXRlbRYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnUycpO3JldHVybiBmYWxzZTtkAgEPDxYCHwAFB0Jvb2tsZXQWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0InKTtyZXR1cm4gZmFsc2U7ZAICDw8WAh8ABQRQYWRzFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBSxqYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdQJyk7cmV0dXJuIGZhbHNlO2QCAQ8PFgIfAAUQU2hlZXQgRmVkIE9mZnNldGQWCGYPDxYCHwAFC1NpbmdsZSBJdGVtFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBSxqYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdGJyk7cmV0dXJuIGZhbHNlO2QCAQ8PFgIfAAUHQm9va2xldBYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnSycpO3JldHVybiBmYWxzZTtkAgIPDxYCHwAFA05DUhYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnTicpO3JldHVybiBmYWxzZTtkAgMPDxYCHwAFBFBhZHMWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0QnKTtyZXR1cm4gZmFsc2U7ZAICDw8WAh8ABQdPdXR3b3JrFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBSxqYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdPJyk7cmV0dXJuIGZhbHNlO2QCAw8PFgIfAAURUHJvZHVjdCBDYXRhbG9ndWUWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0MnKTtyZXR1cm4gZmFsc2U7ZAIEDw8WAh8ABQtPdGhlciBDb3N0cxYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnVScpO3JldHVybiBmYWxzZTtkAgUPDxYCHwAFDExhcmdlIEZvcm1hdBYCHwMFEGN1cnNvcjogcG9pbnRlcjsWBGYPD2QWBB8DBRBjdXJzb3I6IHBvaW50ZXI7HwQFLGphdmFzY3JpcHQ6QWRkQW5JdGVtX0NhbGwoJ0wnKTtyZXR1cm4gZmFsc2U7ZAIBDw9kFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBS1qYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdTcScpO3JldHVybiBmYWxzZTtkAgYPDxYCHwAFCUludmVudG9yeRYEHwMFEGN1cnNvcjogcG9pbnRlcjsfBAUsamF2YXNjcmlwdDpBZGRBbkl0ZW1fQ2FsbCgnVycpO3JldHVybiBmYWxzZTtkAgcPDxYCHwAFC1F1aWNrIFF1b3RlFgQfAwUQY3Vyc29yOiBwb2ludGVyOx8EBSxqYXZhc2NyaXB0OkFkZEFuSXRlbV9DYWxsKCdRJyk7cmV0dXJuIGZhbHNlO2QCAg8PFgIfAAUPUHJvZ3Jlc3MgdG8gSm9iFgQfAwUeY3Vyc29yOiBwb2ludGVyOyBkaXNwbGF5OiBub25lHwQFLGphdmFzY3JpcHQ6U2hvd1Byb2dyZXNzVG9Kb2IoKTtyZXR1cm4gZmFsc2U7ZAIDDw8WAh8ABQtBdHRhY2htZW50cxYCHwMFEGN1cnNvcjogcG9pbnRlcjtkAgQPDxYCHwAFDUNvcHkgRXN0aW1hdGVkFgRmDw8WAh8ABRBUbyBTYW1lIEN1c3RvbWVyFgQfBAUyamF2YXNjcmlwdDpFc3RpbWF0ZUNvcHl0b19TYW1lQ3VzdCgpO3JldHVybiBmYWxzZTsfAwUQY3Vyc29yOiBwb2ludGVyO2QCAQ8PFgIfAAUPVG8gTmV3IEN1c3RvbWVyFgQfBAUxamF2YXNjcmlwdDpFc3RpbWF0ZUNvcHl0b19OZXdDdXN0KCk7cmV0dXJuIGZhbHNlOx8DBRBjdXJzb3I6IHBvaW50ZXI7ZAIFDw8WAh8ABRJSZXZlcnQgdG8gRXN0aW1hdGUWAh8DBTxjdXJzb3I6IHBvaW50ZXI7DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgZGlzcGxheTogbm9uZTtkAg0PZBYCZg8WAh8CaGQCBg8WAh8BBRd3aWR0aDoxMDAlO2hlaWdodDoxMDAlOxYCAgEPZBYCAgEPZBYEAgMPZBYqAgEPDxYCHwAFCEN1c3RvbWVyZGQCAg8QDxYCHwJoZGRkZAIDDxAPFgIfAmhkZGRkAgcPD2QWAh4Hb25mb2N1cwUbamF2YXNjcmlwdDpHZXRDbGllbnRBbGlhcygpZAIJDxQrAAIPFgoeDkRhdGFWYWx1ZUZpZWxkBQJpZB4LXyFEYXRhQm91bmRnHhdFbmFibGVBamF4U2tpblJlbmRlcmluZ2geDURhdGFUZXh0RmllbGQFC2NvbXBhbnl0eXBlHhNjYWNoZWRTZWxlY3RlZFZhbHVlBQUgTm9uZWQPFCsACRQrAAIPFgYfAAUSQ2FyZSBIb21lIFByb3ZpZGVyHgVWYWx1ZQUBNR4IU2VsZWN0ZWRoZGQUKwACDxYGHwAFCENvdXJpZXJzHwsFATgfDGhkZBQrAAIPFgYfAAUaRGlzdHJpYnV0aW9uIGFuZCBsb2dpc3RpY3MfCwUBMR8MaGRkFCsAAg8WBh8ABQ5HcmFwaGljIGRlc2lnbh8LBQEzHwxoZGQUKwACDxYGHwAFDU1hbnVmYWN0dXJpbmcfCwUCMTAfDGhkZBQrAAIPFgYfAAUOT2Zmc2V0IHByaW50ZXIfCwUBNB8MaGRkFCsAAg8WBh8ABRVQYXBlciBhbmQgY29uc3VtYWJsZXMfCwUBMh8MaGRkFCsAAg8WBh8ABQZSZXRhaWwfCwUBNx8MaGRkFCsAAg8WBh8ABQpVbml2ZXJzaXR5HwsFATkfDGhkZA8UKwEJZmZmZmZmZmZmFgEFeFRlbGVyaWsuV2ViLlVJLlJhZENvbWJvQm94SXRlbSwgVGVsZXJpay5XZWIuVUksIFZlcnNpb249MjAxMC4zLjEyMTUuMjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MTIxZmFlNzgxNjViYTNkNBYWZg8PFgQeCENzc0NsYXNzBQlyY2JIZWFkZXIeBF8hU0ICAmRkAgEPDxYEHw0FCXJjYkZvb3Rlch8OAgJkZAICDw8WBh8ABRJDYXJlIEhvbWUgUHJvdmlkZXIfCwUBNR8MaGQWAgIBDxAPFgIfAAUSQ2FyZSBIb21lIFByb3ZpZGVyZGRkZAIDDw8WBh8ABQhDb3VyaWVycx8LBQE4HwxoZBYCAgEPEA8WAh8ABQhDb3VyaWVyc2RkZGQCBA8PFgYfAAUaRGlzdHJpYnV0aW9uIGFuZCBsb2dpc3RpY3MfCwUBMR8MaGQWAgIBDxAPFgIfAAUaRGlzdHJpYnV0aW9uIGFuZCBsb2dpc3RpY3NkZGRkAgUPDxYGHwAFDkdyYXBoaWMgZGVzaWduHwsFATMfDGhkFgICAQ8QDxYCHwAFDkdyYXBoaWMgZGVzaWduZGRkZAIGDw8WBh8ABQ1NYW51ZmFjdHVyaW5nHwsFAjEwHwxoZBYCAgEPEA8WAh8ABQ1NYW51ZmFjdHVyaW5nZGRkZAIHDw8WBh8ABQ5PZmZzZXQgcHJpbnRlch8LBQE0HwxoZBYCAgEPEA8WAh8ABQ5PZmZzZXQgcHJpbnRlcmRkZGQCCA8PFgYfAAUVUGFwZXIgYW5kIGNvbnN1bWFibGVzHwsFATIfDGhkFgICAQ8QDxYCHwAFFVBhcGVyIGFuZCBjb25zdW1hYmxlc2RkZGQCCQ8PFgYfAAUGUmV0YWlsHwsFATcfDGhkFgICAQ8QDxYCHwAFBlJldGFpbGRkZGQCCg8PFgYfAAUKVW5pdmVyc2l0eR8LBQE5HwxoZBYCAgEPEA8WAh8ABQpVbml2ZXJzaXR5ZGRkZAIKDxYCHwEFDWRpc3BsYXk6bm9uZTtkAgwPEA8WBh8JBQtTdGF0dXNUaXRsZR8GBQhTdGF0dXNJRB8HZ2QQFQUETm9uZQ9BY2NvdW50IG9uIEhvbGQOQWNjb3VudHMgQ2xlYXIDQ09EEVBybyBGb3JtYSBBY2NvdW50FQUBMAMxMDcDMTA2AzU1NwMxMDgUKwMFZ2dnZ2dkZAIcDw8WAh8ABQNUYXhkZAIdDxAPFgYfCQUHVGF4TmFtZR8GBQVUYXhJRB8HZ2QQFQkETm9uZQM1ICUDQlRXA0dTVAZVSyBWQVQDVkFUBlZBVCAwJQdWQVQgMjMlClplcm8gUmF0ZWQVCQEwBDE5NDgEMTkzOQMyNDMEMTk0OQQxOTQxBDE5NDIEMTkzNwQxOTQwFCsDCWdnZ2dnZ2dnZ2RkAh4PZBYCAgMPEA8WBh8JBQdUYXhOYW1lHwYFBVRheElEHwdnZBAVCQROb25lAzUgJQNCVFcDR1NUBlVLIFZBVANWQVQGVkFUIDAlB1ZBVCAyMyUKWmVybyBSYXRlZBUJATAEMTk0OAQxOTM5AzI0MwQxOTQ5BDE5NDEEMTk0MgQxOTM3BDE5NDAUKwMJZ2dnZ2dnZ2dnZGQCIg8QDxYGHwkFBE5hbWUfBgUNUGF5bWVudHRlcm1JRB8HZ2QQFQQETm9uZQczMCBEYXlzBzMwIERheXMJSW1tZWRpYXRlFQQBMAEyATQBMxQrAwRnZ2dnZGQCLg8PZBYCHgdvbkNsaWNrBUhqYXZhc2NyaXB0OmV2ZW50LmNhbmNlbEJ1YmJsZT10cnVlO3RoaXMuc2VsZWN0KCk7bGNzKHRoaXMsJ2RkL21tL3l5eXknKTtkAjYPEA8WBh8JBQROYW1lHwYFBlVzZXJJRB8HZ2QQFQQETm9uZQxDbGFyZSBBaW5kb3cMSmltIEhvdWdodG9uDFN1cHBvcnQgVGVhbRUEAi0xBDM4MTIEMzgxNQQxOTczFCsDBGdnZ2dkZAI3Dw8WAh8ABQtSZWZlcnJlZCBCeWRkAjkPD2QWAh4MYXV0b2NvbXBsZXRlBQNvZmZkAjoPEA8WBh8JBQROYW1lHwYFDFJlZmVyZW5jZWRJRB8HZ2QQFQgETm9uZQZBbmdlbGEDQk5JB0Nhcm9seW4NQ3NhYmEgTWFyw6FjegdFeGFtcGxlCUhvdXNlIEEvQwpKb2huIFNtaXRoFQgBMAIyNgIyMgIyNAIyMQIyMwIyNQIyMBQrAwhnZ2dnZ2dnZ2RkAjwPFgIfAQUNZGlzcGxheTpub25lO2QCQA9kFg5mDw8WAh8ABQhTdHJlZXQgMWRkAgIPDxYCHwAFCFN0cmVldCAyZGQCBA8PFgIfAAUEQ2l0eWRkAgYPDxYCHwAFBVN0YXRlZGQCCA8PFgIfAAUIUG9zdGNvZGVkZAIKD2QWAgIDDxAPFgYfCQULQ291bnRyeW5hbWUfBgUJQ291bnRyeWlkHwdnZBAV7gEOLS0tIFNlbGVjdCAtLS0LQWZnaGFuaXN0YW4HQWxiYW5pYQdBbGdlcmlhDkFtZXJpY2FuIFNhbW9hB0FuZG9ycmEGQW5nb2xhCEFuZ3VpbGxhCkFudGFyY3RpY2ETQW50aWd1YSBBbmQgQmFyYnVkYQlBcmdlbnRpbmEHQXJtZW5pYQVBcnViYQlBdXN0cmFsaWEHQXVzdHJpYQpBemVyYmFpamFuB0JhaGFtYXMHQmFocmFpbgpCYW5nbGFkZXNoCEJhcmJhZG9zB0JlbGFydXMHQmVsZ2l1bQZCZWxpemUFQmVuaW4HQmVybXVkYQZCaHV0YW4HQm9saXZpYRZCb3NuaWEgYW5kIEhlcnplZ292aW5hCEJvdHN3YW5hDUJvdXZldCBJc2xhbmQGQnJhemlsHkJyaXRpc2ggSW5kaWFuIE9jZWFuIFRlcnJpdG9yeQZCcnVuZWkIQnVsZ2FyaWEMQnVya2luYSBGYXNvB0J1cnVuZGkIQ2FtYm9kaWEIQ2FtZXJvb24GQ2FuYWRhCkNhcGUgVmVyZGUOQ2F5bWFuIElzbGFuZHMYQ2VudHJhbCBBZnJpY2FuIFJlcHVibGljBENoYWQFQ2hpbGUFQ2hpbmEYQ2hpbmEgKEhvbmcgS29uZyBTLkEuUi4pFENoaW5hIChNYWNhdSBTLkEuUi4pEENocmlzdG1hcyBJc2xhbmQXQ29jb3MgKEtlZWxpbmcpIElzbGFuZHMIQ29sb21iaWEHQ29tb3JvcwVDb25nbwxDb29rIElzbGFuZHMKQ29zdGEgUmljYRtDb3RlIERgSXZvaXJlIChJdm9yeSBDb2FzdCkHQ3JvYXRpYQRDdWJhBkN5cHJ1cw5DemVjaCBSZXB1YmxpYwdEZW5tYXJrCERqaWJvdXRpCERvbWluaWNhEkRvbWluaWNhbiBSZXB1YmxpYwpFYXN0IFRpbW9yB0VjdWFkb3IFRWd5cHQLRWwgU2FsdmFkb3IRRXF1YXRvcmlhbCBHdWluZWEHRXJpdHJlYQdFc3RvbmlhCEV0aGlvcGlhIUZhbGtsYW5kIElzbGFuZHMgKElzbGFzIE1hbHZpbmFzKQ1GYXJvZSBJc2xhbmRzDEZpamkgSXNsYW5kcwdGaW5sYW5kBkZyYW5jZQ1GcmVuY2ggR3VpYW5hEEZyZW5jaCBQb2x5bmVzaWEbRnJlbmNoIFNvdXRoZXJuIFRlcnJpdG9yaWVzBUdhYm9uBkdhbWJpYQdHZW9yZ2lhB0dlcm1hbnkFR2hhbmEJR2licmFsdGFyBkdyZWVjZQlHcmVlbmxhbmQHR3JlbmFkYQpHdWFkZWxvdXBlBEd1YW0JR3VhdGVtYWxhBkd1aW5lYQ1HdWluZWEtQmlzc2F1Bkd1eWFuYQVIYWl0aRpIZWFyZCBhbmQgTWNEb25hbGQgSXNsYW5kcwhIb25kdXJhcwdIdW5nYXJ5B0ljZWxhbmQFSW5kaWEJSW5kb25lc2lhBElyYW4ESXJhcQdJcmVsYW5kBklzcmFlbAVJdGFseQdKYW1haWNhBUphcGFuBkpvcmRhbgpLYXpha2hzdGFuBUtlbnlhCEtpcmliYXRpC0tvcmVhLU5vcnRoC0tvcmVhLVNvdXRoBkt1d2FpdApLeXJneXpzdGFuBExhb3MGTGF0dmlhB0xlYmFub24HTGVzb3RobwdMaWJlcmlhBUxpYnlhDUxpZWNodGVuc3RlaW4JTGl0aHVhbmlhCkx1eGVtYm91cmcJTWFjZWRvbmlhCk1hZGFnYXNjYXIGTWFsYXdpCE1hbGF5c2lhCE1hbGRpdmVzBE1hbGkFTWFsdGEQTWFyc2hhbGwgSXNsYW5kcwpNYXJ0aW5pcXVlCk1hdXJpdGFuaWEJTWF1cml0aXVzB01heW90dGUGTWV4aWNvCk1pY3JvbmVzaWEHTW9sZG92YQZNb25hY28ITW9uZ29saWEKTW9udHNlcnJhdAdNb3JvY2NvCk1vemFtYmlxdWUHTXlhbm1hcgdOYW1pYmlhBU5hdXJ1BU5lcGFsC05ldGhlcmxhbmRzFE5ldGhlcmxhbmRzIEFudGlsbGVzDU5ldyBDYWxlZG9uaWELTmV3IFplYWxhbmQJTmljYXJhZ3VhBU5pZ2VyB05pZ2VyaWEETml1ZQ5Ob3Jmb2xrIElzbGFuZBhOb3J0aGVybiBNYXJpYW5hIElzbGFuZHMGTm9yd2F5BE9tYW4IUGFraXN0YW4FUGFsYXUGUGFuYW1hEFBhcHVhIE5ldyBHdWluZWEIUGFyYWd1YXkEUGVydQtQaGlsaXBwaW5lcw9QaXRjYWlybiBJc2xhbmQGUG9sYW5kCFBvcnR1Z2FsC1B1ZXJ0byBSaWNvBVFhdGFyB1JldW5pb24HUm9tYW5pYQZSdXNzaWEGUndhbmRhDFNhaW50IEhlbGVuYRVTYWludCBLaXR0cyBBbmQgTmV2aXMLU2FpbnQgTHVjaWEZU2FpbnQgUGllcnJlIGFuZCBNaXF1ZWxvbiBTYWludCBWaW5jZW50IEFuZCBUaGUgR3JlbmFkaW5lcwVTYW1vYQpTYW4gTWFyaW5vFVNhbyBUb21lIGFuZCBQcmluY2lwZQxTYXVkaSBBcmFiaWEHU2VuZWdhbApTZXljaGVsbGVzDFNpZXJyYSBMZW9uZQlTaW5nYXBvcmUIU2xvdmFraWEIU2xvdmVuaWEPU29sb21vbiBJc2xhbmRzB1NvbWFsaWEMU291dGggQWZyaWNhLFNvdXRoIEdlb3JnaWEgQW5kIFRoZSBTb3V0aCBTYW5kd2ljaCBJc2xhbmRzBVNwYWluCVNyaSBMYW5rYQVTdWRhbghTdXJpbmFtZR5TdmFsYmFyZCBBbmQgSmFuIE1heWVuIElzbGFuZHMJU3dhemlsYW5kBlN3ZWRlbgtTd2l0emVybGFuZAVTeXJpYQZUYWl3YW4KVGFqaWtpc3RhbghUYW56YW5pYQhUaGFpbGFuZARUb2dvB1Rva2VsYXUFVG9uZ2ETVHJpbmlkYWQgQW5kIFRvYmFnbwdUdW5pc2lhBlR1cmtleQxUdXJrbWVuaXN0YW4YVHVya3MgQW5kIENhaWNvcyBJc2xhbmRzBlR1dmFsdQZVZ2FuZGEHVWtyYWluZRRVbml0ZWQgQXJhYiBFbWlyYXRlcw5Vbml0ZWQgS2luZ2RvbQ1Vbml0ZWQgU3RhdGVzJFVuaXRlZCBTdGF0ZXMgTWlub3IgT3V0bHlpbmcgSXNsYW5kcwdVcnVndWF5ClV6YmVraXN0YW4HVmFudWF0dR1WYXRpY2FuIENpdHkgU3RhdGUgKEhvbHkgU2VlKQlWZW5lenVlbGEHVmlldG5hbRhWaXJnaW4gSXNsYW5kcyAoQnJpdGlzaCkTVmlyZ2luIElzbGFuZHMgKFVTKRlXYWxsaXMgQW5kIEZ1dHVuYSBJc2xhbmRzDldlc3Rlcm4gU2FoYXJhBVllbWVuCll1Z29zbGF2aWEGWmFtYmlhCFppbWJhYndlFe4BATABMQEyATMBNAE1ATYBNwE4ATkCMTACMTECMTICMTMCMTQCMTUCMTYCMTcCMTgCMTkCMjACMjECMjICMjMCMjQCMjUCMjYCMjcCMjgCMjkCMzACMzECMzICMzMCMzQCMzUCMzYCMzcCMzgCMzkCNDACNDECNDICNDMCNDQCNDUCNDYCNDcCNDgCNDkCNTACNTECNTICNTMCNTQCNTUCNTYCNTcCNTgCNTkCNjACNjECNjICNjMCNjQCNjUCNjYCNjcCNjgCNjkCNzACNzECNzICNzMCNzQCNzUCNzYCNzcCNzgCNzkCODACODECODICODMCODQCODUCODYCODcCODgCODkCOTACOTECOTICOTMCOTQCOTUCOTYCOTcCOTgCOTkDMTAwAzEwMQMxMDIDMTAzAzEwNAMxMDUDMTA2AzEwNwMxMDgDMTA5AzExMAMxMTEDMTEyAzExMwMxMTQDMTE1AzExNgMxMTcDMTE4AzExOQMxMjADMTIxAzEyMgMxMjMDMTI0AzEyNQMxMjYDMTI3AzEyOAMxMjkDMTMwAzEzMQMxMzIDMTMzAzEzNAMxMzUDMTM2AzEzNwMxMzgDMTM5AzE0MAMxNDEDMTQyAzE0MwMxNDQDMTQ1AzE0NgMxNDcDMTQ4AzE1MAMxNDkDMTUxAzE1MgMxNTMDMTU0AzE1NQMxNTYDMTU3AzE1OAMxNTkDMTYwAzE2MQMxNjIDMTYzAzE2NAMxNjUDMTY2AzE2NwMxNjgDMTY5AzE3MAMxNzEDMTcyAzE3MwMxNzQDMTc1AzE3NgMxNzcDMTc4AzE3OQMxODADMTgxAzE4MgMxODMDMTg0AzE4NQMxODYDMTg3AzE4OAMxODkDMTkwAzE5MQMxOTIDMTkzAzE5NAMxOTUDMTk2AzE5NwMxOTgDMTk5AzIwMAMyMDEDMjAyAzIwMwMyMDQDMjA1AzIwNgMyMDcDMjA4AzIwOQMyMTADMjExAzIxMgMyMTMDMjE0AzIxNQMyMTYDMjE3AzIxOAMyMTkDMjIwAzIyMQMyMjIDMjIzAzIyNAMyMjUDMjI2AzIyNwMyMjgDMjI5AzIzMAMyMzEDMjMyAzIzMwMyMzQDMjM1AzIzNgMyMzcUKwPuAWdnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dnZ2dkZAILD2QWAmYPDxYCHwAFCVRlbGVwaG9uZWRkAkEPZBYCZg8PFgIfAAULRGVzY3JpcHRpb25kZAJCDw8WAh8ABQZDYW5jZWxkZAJDD2QWAmYPDxYCHwAFBFNhdmVkZAIEDxQrAAIUKwADDxYCHwhoZGRkZGQYAwUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0tleV9fFjUFJ2N0bDAwJGhlYWRlcjEkaW1nX0FkZFN1YmplY3RfRnJvbUhlYWRlcgUpY3RsMDAkaGVhZGVyMSRJbWdfQ2xlYXJTdWJqZWN0X0Zyb21IZWFkZXIFKWN0bDAwJGhlYWRlcjEkaW1nX09wZW5DdXN0b21lcl9Gcm9tSGVhZGVyBSpjdGwwMCRoZWFkZXIxJGltZ19DbGVhckN1c3RvbWVyX0Zyb21IZWFkZXIFKGN0bDAwJGhlYWRlcjEkaW1nX09wZW5Db250YWN0X0Zyb21IZWFkZXIFKmN0bDAwJGhlYWRlcjEkaW1nX0NsZWFyY29udGFjdHNfRnJvbUhlYWRlcgUmY3RsMDAkaGVhZGVyMSRSYWRUaW1lUGlja2VyX0Zyb21IZWFkZXIFL2N0bDAwJGhlYWRlcjEkUmFkVGltZVBpY2tlcl9Gcm9tSGVhZGVyJHRpbWVWaWV3BRtjdGwwMCRoZWFkZXIxJEltYWdlQnV0dG9uMTEFJGN0bDAwJGhlYWRlcjEkaW1nYnRuU2hvd0NhbGxDdXN0b21lcgUlY3RsMDAkaGVhZGVyMSRpbWdidG5DbGVhckNhbGxDdXN0b21lcgUaY3RsMDAkaGVhZGVyMSRJbWFnZUJ1dHRvbjQFHGN0bDAwJGhlYWRlcjEkUmRvQ3VycmVudENhbGwFHmN0bDAwJGhlYWRlcjEkUmRvQ29tcGxldGVkQ2FsbAUeY3RsMDAkaGVhZGVyMSRSZG9Db21wbGV0ZWRDYWxsBR5jdGwwMCRoZWFkZXIxJFJkb1NjaGVkdWxlZENhbGwFHmN0bDAwJGhlYWRlcjEkUmRvU2NoZWR1bGVkQ2FsbAUnY3RsMDAkaGVhZGVyMSRSYWRUaW1lUGlja2VyNF9Gcm9tSGVhZGVyBTBjdGwwMCRoZWFkZXIxJFJhZFRpbWVQaWNrZXI0X0Zyb21IZWFkZXIkdGltZVZpZXcFGWN0bDAwJGhlYWRlcjEkQ2hrQmlsbGFibGUFH2N0bDAwJGhlYWRlcjEkaW1nZWRpdGFkZGNvbnRhY3QFJWN0bDAwJGhlYWRlcjEkaW1nX1Rhc2tFZGl0T3BlbkNvbnRhY3QFJmN0bDAwJGhlYWRlcjEkaW1nX1Rhc2tFZGl0Q2xlYXJDb250YWN0BSdjdGwwMCRoZWFkZXIxJFJhZFRpbWVQaWNrZXIxX0Zyb21IZWFkZXIFMGN0bDAwJGhlYWRlcjEkUmFkVGltZVBpY2tlcjFfRnJvbUhlYWRlciR0aW1lVmlldwUaY3RsMDAkaGVhZGVyMSRJbWFnZUJ1dHRvbjYFG2N0bDAwJGhlYWRlcjEkSW1hZ2VCdXR0b24xMAUnY3RsMDAkaGVhZGVyMSRSYWRUaW1lUGlja2VyNV9Gcm9tSGVhZGVyBTBjdGwwMCRoZWFkZXIxJFJhZFRpbWVQaWNrZXI1X0Zyb21IZWFkZXIkdGltZVZpZXcFIGN0bDAwJGhlYWRlcjEkaW1nZWRpdGNhbGxzdWJqZWN0BRtjdGwwMCRoZWFkZXIxJEltYWdlQnV0dG9uMTIFJ2N0bDAwJGhlYWRlcjEkUmFkVGltZVBpY2tlcjZfRnJvbUhlYWRlcgUwY3RsMDAkaGVhZGVyMSRSYWRUaW1lUGlja2VyNl9Gcm9tSGVhZGVyJHRpbWVWaWV3BR1jdGwwMCRoZWFkZXIxJENoa0VkaXRCaWxsYWJsZQUYY3RsMDAkaGVhZGVyMSRkZGxfU2VhcmNoBRljdGwwMCRoZWFkZXIxJFJhZFNpdGVNYXAxBS5jdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJGRkbF90eXBlBTZjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJGRkbF90eXBlJGkwJGNoazEFNmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkZGRsX3R5cGUkaTEkY2hrMQU2Y3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRkZGxfdHlwZSRpMiRjaGsxBTZjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJGRkbF90eXBlJGkzJGNoazEFNmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkZGRsX3R5cGUkaTQkY2hrMQU2Y3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRkZGxfdHlwZSRpNSRjaGsxBTZjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJGRkbF90eXBlJGk2JGNoazEFNmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkZGRsX3R5cGUkaTckY2hrMQU2Y3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRkZGxfdHlwZSRpOCRjaGsxBTBjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJGNoa2NhcnJpZXIFP2N0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkY2hrX2RlZmF1bHRpbnZvaWNlYWRkcmVzcwVAY3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRjaGtfZGVmYXVsdGRlbGl2ZXJ5YWRkcmVzcwU2Y3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRJbWdSZWZmZXJlZEJ5QWRkBUFjdGwwMCRDb250ZW50UGxhY2VIb2xkZXIxJENsaWVudEFkZElEJENoa2NyZWF0ZV9pZGVudGljYWxfY29udGFjdAU1Y3RsMDAkQ29udGVudFBsYWNlSG9sZGVyMSRDbGllbnRBZGRJRCRDaGtSb3lhbGl0eUZyZWUFN2N0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkUmFkV2luZG93TWFuYWdlcjEFLmN0bDAwJENvbnRlbnRQbGFjZUhvbGRlcjEkQ2xpZW50QWRkSUQkZGRsX3R5cGUPFCsAAmUFBSBOb25lZAUYY3RsMDAkaGVhZGVyMSRkZGxfU2VhcmNoDxQrAAIFA0FsbAUDQWxsZKPVRnvBC1erfonL8ngircCRqPB1" />
</div>

<script type="text/javascript">
    //<![CDATA[
    var theForm = document.forms['aspnetForm'];
    if (!theForm) {
        theForm = document.aspnetForm;
    }
    function __doPostBack(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.__EVENTTARGET.value = eventTarget;
            theForm.__EVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
    //]]>
</script>


        <script type="text/javascript">
            //<![CDATA[
            Sys.WebForms.PageRequestManager._initialize('ctl00$sm1', document.getElementById('aspnetForm'));
            Sys.WebForms.PageRequestManager.getInstance()._updateControls([], [], [], 90);
            //]]>
</script>

        <input name="ctl00$Hidden1" type="hidden" id="ctl00_Hidden1" />
        <table id="outerTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;"
            align="center">
            <!--HEADER-->
            <tr class="SrchResHeight">
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <!-- Navigation -->
                        

<script type="text/javascript">
    var EnableAdvancedCRM = "true";
    var tabcolor = "#2259D7";
    var headerforecolor = "#FFFFFF";
    var IsWebstore = "yes";
    var GetRolesRight_SettingIcon = "true";
    var MISsettingHeight = "";
    var eStoreSettingHeight = "";
    var IsSettingTabDisplay = "true";
    var IsReportsDisplay = "true";
    var GetRolesRight_ReportIcon = "";
    var Ink = 'Ink';
</script>
<style type="text/css">
    .AllnotesbckFade {
        background-color: White;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 5055;
    }

    .center {
        min-height: 270px;
        height: auto;
        width: 450px;
        z-index: 99999;
        opacity: 1;
        position: fixed;
        left: 50%;
        top: 50%;
        transform: translate(-50%, -50%);
        margin-left: -40px;
        margin-top: -1%;
    }

    .position {
        display: inline;
        position: fixed;
        left: 50%;
        top: 50%;
        transform: translate(-50%, -50%);
    }
</style>


<input type="hidden" name="ctl00$header1$hdnSessionCntr" id="ctl00_header1_hdnSessionCntr" value="6000" />
<input type="hidden" name="ctl00$header1$hdnClientID_FromHeader" id="ctl00_header1_hdnClientID_FromHeader" value="0" />
<input type="hidden" name="ctl00$header1$AttID" id="ctl00_header1_AttID" />
<input type="hidden" name="ctl00$header1$hdntodaydate_FromHeader" id="ctl00_header1_hdntodaydate_FromHeader" value="22/03/2016" />
<input type="hidden" name="ctl00$header1$hdnCommanID_FromHeader" id="ctl00_header1_hdnCommanID_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnSectionName_FromHeader" id="ctl00_header1_hdnSectionName_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnSectionID_FromHeader" id="ctl00_header1_hdnSectionID_FromHeader" value="0" />
<input type="hidden" name="ctl00$header1$hdnbuttonid_FromHeader" id="ctl00_header1_hdnbuttonid_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnTaskFollowParentID_FromHeader" id="ctl00_header1_hdnTaskFollowParentID_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnTaskFollowParentType_FromHeader" id="ctl00_header1_hdnTaskFollowParentType_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnCallFollowParentID_FromHeader" id="ctl00_header1_hdnCallFollowParentID_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnCallFollowParentType_FromHeader" id="ctl00_header1_hdnCallFollowParentType_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnTaskFollowParentIDDet_FromHeader" id="ctl00_header1_hdnTaskFollowParentIDDet_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnTaskFollowParentTypeDet_FromHeader" id="ctl00_header1_hdnTaskFollowParentTypeDet_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnCallFollowParentIDDet_FromHeader" id="ctl00_header1_hdnCallFollowParentIDDet_FromHeader" />
<input type="hidden" name="ctl00$header1$hdnCallFollowParentTypeDet_FromHeader" id="ctl00_header1_hdnCallFollowParentTypeDet_FromHeader" />
<input type="hidden" name="ctl00$header1$hdn_Type" id="ctl00_header1_hdn_Type" />
<input type="hidden" name="ctl00$header1$hdn_SelectedClientID" id="ctl00_header1_hdn_SelectedClientID" value="0" />
<input type="hidden" name="ctl00$header1$hdn_ContactID" id="ctl00_header1_hdn_ContactID" value="0" />
<input type="hidden" name="ctl00$header1$hdn_ModuleID_FromHeader" id="ctl00_header1_hdn_ModuleID_FromHeader" value="0" />
<input type="hidden" name="ctl00$header1$hdn_ModuleName_FromHeader" id="ctl00_header1_hdn_ModuleName_FromHeader" />
<input type="hidden" name="ctl00$header1$hdn_SystemDateTime" id="ctl00_header1_hdn_SystemDateTime" value="22/03/2016 11:53 AM" />
<input type="hidden" name="ctl00$header1$hdn_DefaultTaskSubjectID_FromHeader" id="ctl00_header1_hdn_DefaultTaskSubjectID_FromHeader" value="0" />
<input type="hidden" name="ctl00$header1$hdn_DefaultCallSubjectID_FromHeader" id="ctl00_header1_hdn_DefaultCallSubjectID_FromHeader" value="0" />

<script language="javascript" type="text/javascript">
    var jsCurrencySymbol = '$';
</script>


<link href="../css/RadComboBox_eprintSkin.css" rel="stylesheet" type="text/css" />
<tr>
    <td style="background-color: White; padding-top: 17px;" valign="top">
        <input type="hidden" name="ctl00$header1$HiddenField1" id="ctl00_header1_HiddenField1" value="English" />
        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="Table1">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="height: 25; display: none">
                <td bgcolor="Clients" class="normalText" align="left">
                    <table cellspacing="0" cellpadding="0" border="0" width="100%">
                        <tr valign="top">
                            <td class="normaltext" align="right" nowrap="nowrap">
                                <span id="ctl00_header1_lblUserName">&nbsp;Logged in as&nbsp;<b>Jim Houghton  (ePrint Software)</b>&nbsp|&nbsp;<a href=https://demo.eprintsoftware.com/logout.aspx><b>Logout</b></a></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </td>
</tr>
<div id="divDrpdwn" style="margin-top: 40px; margin-left: 17px;">
    <nav style="height: 0px;">
        <ul id="ulDrpdwn">
            <div id="div_dropdown_crm" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/client/client_view.aspx" style="color: #FFFFFF">
                    View Customers</a> </li>
                <li><a href="https://demo.eprintsoftware.com/client/client_add.aspx?type=Customer" style="color: #FFFFFF">
                    Add New Customer
                </a></li>
                
                <li class=""><a href="https://demo.eprintsoftware.com/client/client_view.aspx?type=Supplier" style="color: #FFFFFF">
                    View Suppliers
                </a></li>
                <li><a href="https://demo.eprintsoftware.com/client/client_add.aspx?type=Supplier" style="color: #FFFFFF">
                    Add New Supplier
                </a></li>
                
                <li class=""><a href="https://demo.eprintsoftware.com/client/client_view.aspx?type=Prospect" style="color: #FFFFFF">
                    View Prospects
                </a></li>
                <li><a href="https://demo.eprintsoftware.com/client/client_add.aspx?type=Prospect" style="color: #FFFFFF">
                    Add New Prospect
                </a></li>
                
                <li class=""><a href="https://demo.eprintsoftware.com/contact/contact_view.aspx" style="color: #FFFFFF">
                    View Contacts
                </a></li>
              
                <li id="ctl00_header1_liclients" style="display:block;" onmouseover="javascript:showInventoryToolsDiv();"><a href="#" style="color: #FFFFFF">
                    Reports</a>
                    <ul id="Ul2" style="margin-left: 153px; margin-top: -27px;">
                        <li class="crmreportmenulst" style="background-color: #2259D7;">
                            <a href="https://demo.eprintsoftware.com/client/client_report.aspx" style="border: solid 1px #2259D7; color: #FFFFFF">
                                Customer</a></li>
                        <li id="ctl00_header1_liCallReport" class="crmreportmenulst show_hide" style="display:block">
                            <a href="https://demo.eprintsoftware.com/client/activity_callreport.aspx" style="color: #FFFFFF">
                                Call</a></li>
                        <li class="crmreportmenulst" style="background-color: #2259D7;">
                            <a href="https://demo.eprintsoftware.com/client/activity_taskeventreport.aspx" style="color: #FFFFFF">
                                Task</a></li>
                    </ul>
                </li>
            </div>
            <div id="div_dropdown_estimate" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/estimates/estimates_add.aspx?type=add" style="color: #FFFFFF;">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/estimates/estimate_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblEstscreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Estimate_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/estimates/estimate_report.aspx" style="color: #FFFFFF">
                    Reports
                </a></li>
            </div>
            <div id="div_dropdown_jobs" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/jobs/job_add.aspx?type=add" style="color: #FFFFFF">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/Jobs/jobs_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblJobscreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Job_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/jobs/job_report.aspx" style="color: #FFFFFF">
                    Reports</a></li>
            </div>
            <div id="div_dropdown_purchase" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/Purchase/purchase_add.aspx?type=add" style="color: #FFFFFF">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/Purchase/purchase_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblPurchasescreenname"></span></a></li>
                
                
            </a></li>
             <li id="ctl00_header1_li_Purchase_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/Purchase/purchase_report.aspx" style="color: #FFFFFF">
                 Reports</a></li>
            </div>
            <div id="div_dropdown_deliverynotes" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/delivery/delivery_add.aspx" style="color: #FFFFFF">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/Delivery/delivery_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblDeliveryscreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Delivery_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/delivery/delivery_report.aspx" style="color: #FFFFFF">
                    Reports</a></li>
            </div>
            <div id="div_dropdown_invoice" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/invoice/invoices_add.aspx?type=add" style="color: #FFFFFF">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/Invoice/invoice_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblInvoicescreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Invoice_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/invoice/invoice_report.aspx" style="color: #FFFFFF">
                    Reports</a></li>
            </div>
            <div id="div_dropdown_inventry" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/warehouse/inventory_add.aspx" style="color: #FFFFFF">
                    Add New
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/warehouse/warehouse.aspx?type=inventory" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblWarehousescreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Warehouse_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/warehouse/inventory_report.aspx" style="color: #FFFFFF">
                    Reports</a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/Settings/inventory_settings.aspx" style="color: #FFFFFF">
                    View/Add Categories</a> </li>
                
                <li onmouseover="javascript:showInventoryToolsDiv();"><a href="#" style="color: #FFFFFF">
                    Tools</a>
                    <ul id="slideUL" style="margin-left: 153px; margin-top: -27px;">
                        <li style="min-width: 100px; height: 31px; background-color: #2259D7; margin-top: -5px; margin-left: -4px;">
                            <a href="https://demo.eprintsoftware.com/warehouse/inventoryexport.aspx" style="border: solid 1px #2259D7; color: #FFFFFF">
                                Export</a></li>
                        <li style="min-width: 100px; height: 31px; background-color: #2259D7; margin-top: -5px; margin-left: -4px;">
                            <a href="https://demo.eprintsoftware.com/Settings/inventory_import.aspx" style="color: #FFFFFF">
                                Import</a></li>
                        <li style="min-width: 100px; height: 31px; background-color: #2259D7; margin-top: -5px; margin-left: -4px;">
                            <a href="https://demo.eprintsoftware.com/Settings/inventory_adjustment.aspx" style="color: #FFFFFF">
                                Mass Adjustment</a></li>
                    </ul>
                </li>
                
            </div>
            <div id="div_dropdown_reports" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li id="ctl00_header1_li_CRM" style="display:block"><a href="https://demo.eprintsoftware.com/client/client_report.aspx?pg=report" style="color: #FFFFFF">
                    Client
                </a></li>
                <li id="ctl00_header1_li_Estimates" style="display:block"><a href="https://demo.eprintsoftware.com/estimates/estimate_report.aspx?pg=report" style="color: #FFFFFF">
                    Estimates
                </a></li>
                <li id="ctl00_header1_li_Order" style="display:block"><a href="https://demo.eprintsoftware.com/Orders/order_report.aspx?pg=report" style="color: #FFFFFF">
                    Order
                </a></li>
                <li id="ctl00_header1_li_Job" style="display:block"><a href="https://demo.eprintsoftware.com/jobs/job_report.aspx?pg=report" style="color: #FFFFFF">
                    Job
                </a></li>
                <li id="ctl00_header1_li_Purchase" style="display:block"><a href="https://demo.eprintsoftware.com/Purchase/purchase_report.aspx?pg=report" style="color: #FFFFFF">
                    Purchase
                </a></li>
                <li id="ctl00_header1_li_Delivery" style="display:block"><a href="https://demo.eprintsoftware.com/delivery/delivery_report.aspx?pg=report" style="color: #FFFFFF">
                    Delivery
                </a></li>
                <li id="ctl00_header1_li_Invoice" style="display:block"><a href="https://demo.eprintsoftware.com/invoice/invoice_report.aspx?pg=report" style="color: #FFFFFF">
                    Invoice
                </a></li>
                <li id="ctl00_header1_li_Inventory" style="display:block"><a href="https://demo.eprintsoftware.com/warehouse/inventory_report.aspx?pg=report" style="color: #FFFFFF">
                    Inventory
                </a></li>
                <li id="ctl00_header1_li_Product" style="display:block"><a href="https://demo.eprintsoftware.com/common/productcatalogue_report.aspx?pg=report" style="color: #FFFFFF">
                    Product Catalogue
                </a></li>
            </div>
            <div id="div_dropdown_campaign" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/campaign/campaign_add.aspx" style="color: ">
                    Add New</a></li>
                <li><a href="https://demo.eprintsoftware.com/campaign/campaign_view.aspx" style="color: ">
                    View All
                    <span id="ctl00_header1_lblCamaignscreenname"></span></a></li>
                
            </div>
            <div id="div_dropdown_orders" style="display: none;" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">
                <li><a href="https://demo.eprintsoftware.com/orders/order_view.aspx" style="color: #FFFFFF">
                    View All
                    <span id="ctl00_header1_lblOrderscreenname"></span></a></li>
                
                
                <li id="ctl00_header1_li_Order_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/orders/order_Report.aspx" style="color: #FFFFFF">
                    Reports
                </a></li>
            </div>
            <div id="div_ProductCatalogue" style="display: none; width: 160px" onmouseover="javascript:showThisDiv(this.id);"
                onmouseout="javascript:HideThisDiv(this.id);">

                <li id="ctl00_header1_li_Product_Add" class=""><a href="https://demo.eprintsoftware.com/ProductCatalogue/ProductCatalogue_item.aspx" style="color: #FFFFFF">
                    Add New Product
                </a></li>
                <li><a href="https://demo.eprintsoftware.com/ProductCatalogue/PriceCatalogue.aspx" style="color: #FFFFFF">
                    View All Products
                </a></li>
                <li><a href="https://demo.eprintsoftware.com/ProductCatalogue/ProductCatalogueCategory.aspx?&mode=add" style="color: #FFFFFF">
                    View/Add Categories</a></li>
                
                <li class=""><a style="width: 150px; color: #FFFFFF" href="https://demo.eprintsoftware.com/ProductCatalogue/Othercost_webstore.aspx?type=add">
                    Add New Additional Option</a></li>
                <li><a href="https://demo.eprintsoftware.com/ProductCatalogue/OtherCost_webStore_View.aspx" style="color: #FFFFFF">
                    View All Additional Options
                </a></li>
                <li class=""><a href="https://demo.eprintsoftware.com/ProductCatalogue/Pricecatalog_import.aspx" style="color: #FFFFFF">
                    Import/Export</a></li>
                <li id="ctl00_header1_li_Product_Report" style="display:block;"><a href="https://demo.eprintsoftware.com/common/productcatalogue_report.aspx" style="color: #FFFFFF">
                    Reports</a></li>
            </div>
            <div style="display: none;">
                <div id="divForecastmodule" style="display: none; width: 160px" onmouseover="javascript:showThisDiv(this.id);"
                    onmouseout="javascript:HideThisDiv(this.id);">
                    <li><a href="https://demo.eprintsoftware.com/forecast/forecast_add.aspx" style="color: ">Add New</a></li>
                    <li><a href="https://demo.eprintsoftware.com/forecast/forecast.aspx" style="color: ">View Forecast
                    </a></li>
                </div>
            </div>
        </ul>
    </nav>
</div>
<div id="div_settings" onmouseover="javascript:showThisDiv(this.id);" onmouseout="javascript:HideThisDiv(this.id);">
    <div id="CatWrapper" class="Wrapper">
        <div id="ctl00_header1_RadSiteMap1" class="RadSiteMap RadSiteMap_Hay">
	<ul class="rsmList rsmColumn rsmLevel rsmTwoLevels" style="width:50%;">
		<li class="rsmItem mainlink"><a class="rsmLink" href="javascript:return false;">Plant &amp; Presses</a><ul class="rsmList rsmLevel1">
			<li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i0_i0_lnkDigView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i0$i0$lnkDigView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i0_i0_lnkDigAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i0$i0$lnkDigAdd','')">Add Digital</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i0_i1_lnkOffView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i0$i1$lnkOffView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i0_i1_lnkOffAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i0$i1$lnkOffAdd','')">Add Offset</a>
                            
			</div></li>
		</ul></li><li class="rsmItem mainlink"><a class="rsmLink" href="javascript:return false;">Product Catalogue</a><ul class="rsmList rsmLevel1">
			<li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i1_i0_lnkcategory" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i1$i0$lnkcategory','')">View / Add Category</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i1_i1_lnkProdView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i1$i1$lnkProdView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i1_i1_lnkProdAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i1$i1$lnkProdAdd','')">Add Products</a>
                            
			</div></li>
		</ul></li><li class="rsmItem mainlink"><a class="rsmLink" href="javascript:return false;">Other Costs</a><ul class="rsmList rsmLevel1">
			<li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i2_i0_lnkCostView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i2$i0$lnkCostView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i2_i0_lnkCostAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i2$i0$lnkCostAdd','')">Add Costs</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i2_i1_lnksequence" href="../Settings/Othercost_sequence.aspx?EstType=S" style="display:inline-block;width:72%;">Sequence</a>
                            
			</div></li>
		</ul></li>
	</ul><ul class="rsmList rsmColumn rsmLevel rsmTwoLevels" style="width:50%;">
		<li class="rsmItem mainlink"><a class="rsmLink" href="javascript:return false;">Templates</a><ul class="rsmList rsmLevel1">
			<li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i0_lnkEstViewSettings" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i0$lnkEstViewSettings','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i3_i0_lnkEstAddSettings" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i0$lnkEstAddSettings','')">Add Estimates</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i1_lnkSupView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i1$lnkSupView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i3_i1_lnkSupAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i1$lnkSupAdd','')">Add Supplier RFQs</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i2_lnkJobView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i2$lnkJobView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i3_i2_lnkJobAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i2$lnkJobAdd','')">Add Jobs</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i3_lnkPurcView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i3$lnkPurcView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i3_i3_lnkPurcAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i3$lnkPurcAdd','')">Add Purchase</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i4_lnkInvView" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i4$lnkInvView','')">View</a>
                                <span>|</span>
                                <a id="ctl00_header1_RadSiteMap1_i3_i4_lnkInvAdd" href="javascript:__doPostBack('ctl00$header1$RadSiteMap1$i3$i4$lnkInvAdd','')">Add Invoices</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i3_i5_lnkjobcard" href="../Settings/JobCardSettings.aspx">Job Card Settings</a>
                            
			</div></li>
		</ul></li><li class="rsmItem mainlink"><a class="rsmLink" href="javascript:return false;">Accounting</a><ul class="rsmList rsmLevel1">
			<li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i4_i0_lnkxero" href="../Settings/accounting_export.aspx" style="display:inline-block;width:72%;">XERO</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i4_i1_lnkmyob" href="../Settings/MYOBAccounting.aspx" style="display:inline-block;width:72%;">MYOB</a>
                            
			</div></li><li class="rsmItem"><div class="rsmTemplate">
				
                                <a id="ctl00_header1_RadSiteMap1_i4_i2_lnkacounting" href="../Settings/General_ledger_codes.aspx" style="display:inline-block;width:72%;">Accounting Code</a>
                            
			</div></li><li class="rsmItem sublink"><a class="rsmLink" href="../Settings/settings.aspx">View all Options</a></li>
		</ul></li>
	</ul><input id="ctl00_header1_RadSiteMap1_ClientState" name="ctl00_header1_RadSiteMap1_ClientState" type="hidden" />
</div>
    </div>
    <input type="hidden" name="ctl00$header1$hdntotalCount" id="ctl00_header1_hdntotalCount" value="0" />
</div>

<div id="divallnotesbckfade" class="AllnotesbckFade" style="display: none;">
</div>




<div class="show_hide">
    Powered by Infomaze Technologies
</div>
<script type="text/javascript">
    var CompanyID = "1534";
    var UserID = "3815";
    var sitePath = 'https://demo.eprintsoftware.com/';
    var bordercolor = "#2259D7";
    var hdntotalCount = document.getElementById("ctl00_header1_hdntotalCount");
    var imgreports = document.getElementById("imgreports");
    var isreportimgclick = false;
    var TodDate = "22/03/2016";
    var Createddate = "3/22/2016 10:53:43 PM";
    var DateFormatforValidate = "dd/mm/yyyy";
    var SelectedID = document.getElementById("ctl00_header1_hdn_SelectedClientID").value;
</script>
<script type="text/javascript">

    if (IsReportsDisplay == "true") {
        imgreports.style.display = 'block';
    }
    else {
        imgreports.style.display = 'none';
        document.getElementById("ctl00_header1_div_empty").style.display = 'block';
        document.getElementById("ctl00_header1_divMainAlert").style.margin = "10px 0px 0px 30px";
        document.getElementById('divheadericons').style.marginLeft = '-2px';
    }


    if (GetRolesRight_ReportIcon == "false") {
        imgreports.style.display = 'none';
        document.getElementById("ctl00_header1_div_empty").style.display = 'block';
        document.getElementById("ctl00_header1_divMainAlert").style.margin = "10px 0px 0px 30px";
        document.getElementById('divheadericons').style.marginLeft = '-2px';
    }
    else {
        if (IsReportsDisplay == "true") {
            imgreports.style.display = 'block';
        }
        else {
            imgreports.style.display = 'none';
        }

    }


    $(document).click(function (event) {
        if (document.getElementById('div_Reportsmenu') != null) {
            if (isreportimgclick == true) {
                document.getElementById('div_Reportsmenu').style.display = 'block';
            }
            else {
                document.getElementById('div_Reportsmenu').style.display = 'none';
            }

            isreportimgclick = false;
        }
    });

    $("#imgreports").click(function (event) {

        if (document.getElementById('div_Reportsmenu') != null) {
            if (document.getElementById('div_Reportsmenu').style.display == 'block') {
                isreportimgclick = false;
                document.getElementById('div_Reportsmenu').style.display = 'none';
            }
            else {
                isreportimgclick = true;
                document.getElementById('div_Reportsmenu').style.display = 'block';
            }
            return;
        }
    });

</script>
<script type="text/javascript">

    $(document).click(function (event) {

        if ((document.getElementById('divalertcontant') != null)) {
            if (document.getElementById("DivOpenActiDetails_FromHeader").style.display == "block" || document.getElementById("DivtaskPopUpEdit_FromHeader").style.display == "block"
                || document.getElementById("DivNotesPopup_FromHeader").style.display == "block" || document.getElementById("DivAddNotePopup_FromHeader").style.display == "block"
                || document.getElementById("DivCallPopup_FromHeader").style.display == "block" || document.getElementById("DivEditCallPopup_FromHeader").style.display == "block") {
                isAlertImgclick = true;
                document.getElementById("divallnotesbckfade").style.display = "block";
            }

            if (isAlertImgclick == true) {
                if (Norecord == false) {
                    document.getElementById('divalertcontant').style.display = 'block';
                }
                else {
                    document.getElementById('divalertcontant').style.display = 'none';
                }
            }
            else {
                document.getElementById('divalertcontant').style.display = 'none';
            }

            isAlertImgclick = false;
        }
    });

    var isAlertImgclick = false;
    $("#ctl00_header1_lnkalert").click(function (event) {

        load_ddlCustomers(CompanyID); // For loading Customer to the DropDown when only AlertNotification onClick

        if (document.getElementById('divalertcontant') != null) {
            if (document.getElementById('divalertcontant').style.display == 'block') {
                isAlertImgclick = false;
                document.getElementById('divalertcontant').style.display = 'none';
            }
            else {
                isAlertImgclick = true;
                if (Norecord == false) {
                    document.getElementById('divalertcontant').style.display = 'block';
                    AutoFill.GetAlertNotification(onResponseAlert);
                }
                else {
                    document.getElementById('divalertcontant').style.display = 'none';
                }
            }
            return;
        }
    });

</script>
<script type="text/javascript">
    var Isdisplay = false;
    var IsTaskdisplay = false;
    var Ishidesuccess = false;
    var Norecord = false;

    setTimeout(GetTime, 1000);

    function GetTime() {
        //if (EnableAdvancedCRM == "true") {
        AutoFill.GetNotificationCount(onResponseCount);
        setTimeout(GetTime, 180000);
        //}
    }

    function onResponseCount(result) {
        var lblalertcontant = document.getElementById("ctl00_header1_lblalertcontant");
        var lblalertCount = document.getElementById("ctl00_header1_lblalertCount");

        //  if (result > 0) {
        hdntotalCount.value = result;
        lblalertCount.innerHTML = result;
        document.getElementById("ctl00_header1_divMainAlert").style.display = "block";
        //        }
        //        else {
        //            document.getElementById("ctl00_header1_divMainAlert").style.display = "none";
        //        }
        if (result > 99) {
            document.getElementById("ctl00_header1_DivRadAlert").style.width = "28px";
        } else if (result > 9) {
            lblalertCount.style.marginLeft = "0px";
        }
        else {
            lblalertCount.style.marginLeft = "5px";
        }
    }

    function onResponseAlert(result) {
        var lblalertcontant = document.getElementById("ctl00_header1_lblalertcontant");
        var lblalertCount = document.getElementById("ctl00_header1_lblalertCount");
        var resultFirst = result.split('†');

        //if (parseInt(resultFirst[1]) > 0) {

        hdntotalCount.value = parseInt(resultFirst[1]);
        if (Isdisplay == true) {
            Isdisplay = false;
            lblalertcontant.innerHTML = resultFirst[0];
            lblalertCount.innerHTML = resultFirst[1];
            document.getElementById("divalertcontant").style.display = "block";

            if (document.getElementById("divalertcontant") != null) {
                document.getElementById("divalertcontant").style.border = "0px solid" + "#B9B9B9";
                document.getElementById("taskborderright").style.borderRight = "1px solid" + "#F2F2F2";
            }

            if (CallActive == true) {
                opencalldiv();
            } else {
                opentaskdiv();
            }
            if (IsTaskdisplay == true) {
                document.getElementById("taskborderright").style.color = "#000000";
                document.getElementById("Callborderright").style.color = "#000000";
                document.getElementById("divtashbottomcolor").style.display = "block";
                document.getElementById("divcallbottomcolor").style.display = "none";
            }
        }
        else {
            lblalertcontant.innerHTML = resultFirst[0];
            lblalertCount.innerHTML = resultFirst[1];

            document.getElementById("taskborderright").style.color = "#000000";
            document.getElementById("Callborderright").style.color = "#000000";
            document.getElementById("divtashbottomcolor").style.display = "block";
            document.getElementById("divcallbottomcolor").style.display = "none";

            if (document.getElementById("divalertcontant") != null) {
                document.getElementById("divalertcontant").style.display = "block";
                document.getElementById("divalertcontant").style.border = "0px solid" + "#B9B9B9";
                document.getElementById("taskborderright").style.borderRight = "1px solid" + "#F2F2F2";
            }
            if (document.getElementById("taskheaderback") != null) {

            }
            if (document.getElementById("notaskrecords") == null) {
                if (document.getElementById("DivtaskNorecords") != null & document.getElementById("DivtaskNorecords") != undefined) {
                    document.getElementById("DivtaskNorecords").style.display = "none";
                }
                //document.getElementById("CallDiv_1").style.display = "block";
                document.getElementById("divtashbottomcolor").style.display = "none";
                document.getElementById("divcallbottomcolor").style.display = "block";
                document.getElementById("taskborderright").style.marginTop = "-9px";
                document.getElementById("taskborderright").style.Height = "24px";
                opencalldiv();
            }
        }

        if (parseInt(resultFirst[1]) > 99) {
            document.getElementById("ctl00_header1_DivRadAlert").style.width = "28px";
        } else if (parseInt(resultFirst[1]) > 9) {
            lblalertCount.style.marginLeft = "0px";
            document.getElementById("ctl00_header1_DivRadAlert").style.width = "22px";
            document.getElementById("div_lblalertCount").style.marginLeft = "3px";
        }
        else {
            lblalertCount.style.marginLeft = "5px";
        }

        if (Browser().toLocaleLowerCase().trim() == "firefox") {
            document.getElementById("div_imgarrowup").style.marginTop = "-5px";
            document.getElementById("div_imgarrowup").style.marginLeft = "41px";
        }
        //        }
        //        else {
        //            if (document.getElementById("divalertcontant") != null || document.getElementById("divalertcontant") != undefined) {
        //                document.getElementById("divalertcontant").style.display = "none";
        //                document.getElementById("ctl00_header1_divMainAlert").style.display = "none";
        //                var lblalertCount = document.getElementById("ctl00_header1_lblalertCount");
        //                lblalertCount.innerHTML = "0";
        //                lblalertCount.style.marginLeft = "5px";
        //                Norecord = true;
        //            }
        //        }

        if (Ishidesuccess == true) {
            if (document.getElementById("divloadingdisplay") != null) {
                document.getElementById("divloadingdisplay").style.display = "block";
                Ishidesuccess = false;
                HideMessage();
            }
        }

        var he = document.getElementById("divalertcontant");
        if (document.getElementById("divalertcontant") != null) {
            //if (EnableAdvancedCRM == "true") {
            document.getElementById("Callborderright").style.display = "block";
            //}
            //            else {
            //                document.getElementById("Callborderright").style.display = "none";
            //                document.getElementById("taskborderright").style.width = "305px";
            //                document.getElementById("taskborderright").style.borderTopRightRadius = "3px";
            //            }
        }
    }
</script>
<script type="text/javascript" language="javascript">
    var ClientID = '';
    var SectionID = '';
    var CompanyName = '';
    var CompanyType = '';
    var redirectFrom = '';
    var UniqueID = '';
    var Types = '';

    var isTimeSelected = false;
    function DateSelected(sender, args) {

    }
    function ClientTimeSelected(sender, args) {
        isTimeSelected = true;
    }

    var CallActive = false;

    function opentaskdiv() {
        Close_CallPopup_FromHeader();
        document.getElementById("taskborderright").style.marginTop = "-5px";
        CallActive = false;
        document.getElementById("taskborderright").style.color = "#000000";
        document.getElementById("Callborderright").style.color = "#000000";
        document.getElementById("divtashbottomcolor").style.display = "block";
        document.getElementById("divcallbottomcolor").style.display = "none";
        document.getElementById("Notesborderright").style.marginTop = "-5px";
        document.getElementById("Notesborderright").style.color = "#000000";

        if (parseInt(hdntotalCount.value) > 0) {
            var Count = parseInt(hdntotalCount.value);
            for (var i = 1; i <= Count; i++) {

                if (document.getElementById("TaskDiv_" + i) != null && document.getElementById("TaskDiv_" + i) != undefined) {
                    document.getElementById("TaskDiv_" + i).style.display = "block";

                    if (document.getElementById("DivtaskNorecords") != null) {
                        document.getElementById("DivtaskNorecords").style.display = "none";
                    }
                    if (document.getElementById("DivcallNorecords") != null) {
                        document.getElementById("DivcallNorecords").style.display = "none";
                    }
                }
                if (document.getElementById("CallDiv_" + i) != null && document.getElementById("CallDiv_" + i) != undefined) {
                    document.getElementById("CallDiv_" + i).style.display = "none";
                    if (document.getElementById("DivtaskNorecords") != null) {
                        document.getElementById("DivtaskNorecords").style.display = "block";
                    }
                    if (document.getElementById("DivcallNorecords") != null) {
                        document.getElementById("DivcallNorecords").style.display = "none";
                    }
                }
            }
        }
        if (document.getElementById("notaskrecords") == null) {
            if (document.getElementById("DivtaskNorecords") != null || document.getElementById("DivtaskNorecords") != undefined) {
                document.getElementById("DivtaskNorecords").style.display = "block";
            }
            if (document.getElementById("DivcallNorecords") != null || document.getElementById("DivcallNorecords") != undefined) {
                document.getElementById("DivcallNorecords").style.display = "none";
            }
        }
    }

    function opencalldiv() {
        Close_TaskPopup_FromHeader();
        CallActive = true;
        document.getElementById("taskborderright").style.marginTop = "-9px";
        document.getElementById("taskborderright").style.color = "#000000";
        document.getElementById("Callborderright").style.color = "#000000";
        document.getElementById("Notesborderright").style.marginTop = "-9px";
        document.getElementById("Notesborderright").style.color = "#000000";
        // document.getElementById("divtaskbackground").className = 'tabunselected';
        // document.getElementById("divcallbackground").className = 'tabselected';
        document.getElementById("divtashbottomcolor").style.display = "none";
        document.getElementById("divcallbottomcolor").style.display = "block";

        if (parseInt(hdntotalCount.value) > 0) {
            var Count = parseInt(hdntotalCount.value);

            for (var i = 1; i <= Count; i++) {

                if (document.getElementById("TaskDiv_" + i) != null && document.getElementById("TaskDiv_" + i) != undefined) {
                    document.getElementById("TaskDiv_" + i).style.display = "none";

                    if (document.getElementById("DivtaskNorecords") != null) {
                        document.getElementById("DivtaskNorecords").style.display = "none";
                    }
                    if (document.getElementById("DivcallNorecords") != null) {
                        document.getElementById("DivcallNorecords").style.display = "none";
                    }
                }
                if (document.getElementById("CallDiv_" + i) != null && document.getElementById("CallDiv_" + i) != undefined) {
                    document.getElementById("CallDiv_" + i).style.display = "block";
                    if (document.getElementById("DivtaskNorecords") != null) {
                        document.getElementById("DivtaskNorecords").style.display = "none";
                    }
                    if (document.getElementById("DivcallNorecords") != null) {
                        document.getElementById("DivcallNorecords").style.display = "block";
                    }
                }
            }
        }

        if (document.getElementById("nocallrecords") == null) {
            if (document.getElementById("DivcallNorecords") != null || document.getElementById("DivcallNorecords") != undefined) {
                document.getElementById("DivcallNorecords").style.display = "block";
            }
            if (document.getElementById("DivtaskNorecords") != null || document.getElementById("DivtaskNorecords") != undefined) {
                document.getElementById("DivtaskNorecords").style.display = "none";
            }
        }
    }

    function dismiss_alert_notification(ID, CompantID, SectionName) {

        document.getElementById("divalertcontant").style.display = "block";
        if (SectionName == "task") {
            IsTaskdisplay = true;
        }
        else {
            IsTaskdisplay = false;
        }
        Ishidesuccess = true;
        Isdisplay = true;
        AutoFill.DismissAlertNotification(ID, CompantID, SectionName, onResponseAlert);
        //Ishidesuccess = false;
    }

    function HideMessage() {

        window.setTimeout(function () {
            var label = document.getElementById('divloadingdisplay');

            if (label != null) {
                label.style.display = 'none';
            }
        }, 2000);
    }

    function openalertcontant() {
        AutoFill.GetAlertNotification(onResponseAlert);
    }

    function hidealertcontant() {
        document.getElementById("divalertcontant").style.display = "none";
    }

    function Task_details(EditPage) {
        window.location = EditPage;
    }

    function Open_task_Call_details_FromHeader(str, btnid) {
        if (str != '' && str != undefined) {
            var ary = str.split('&');
            var Arrar = '';
            for (var a = 0; a < ary.length; a++) {
                Arrar = ary[a].split('=');
                if (Arrar[0] == "clientid") {
                    ClientID = Arrar[1];
                    SectionID = Arrar[1];
                    document.getElementById("ctl00_header1_hdnClientID_FromHeader").value = Arrar[1];
                    document.getElementById("ctl00_header1_hdnSectionID_FromHeader").value = Arrar[1];
                }
                if (Arrar[0] == "isnew") {
                    CompanyName = Arrar[1];
                }
                if (Arrar[0] == "type") {
                    CompanyType = Arrar[1];
                }
                if (Arrar[0] == "TaskID") {
                    UniqueID = Arrar[1];
                }
                if (Arrar[0] == "ActivityType") {
                    Types = Arrar[1];
                    //document.getElementById('ctl00_header1_hdnSectionName_FromHeader').value = Arrar[1];
                }
            }
            var btnID = btnid;
            Load_AllDropdownlist(CompanyID, ClientID);
            Open_Activity_details_FromHeader(UniqueID, Types, btnID);

        } else {
            document.getElementById('divalertcontant').style.display = 'none';
        }
    }

    function OpenMoreActionsPopup_FromHeader(btnid) {
        //var txt = document.getElementById(btnid);
        //var p = GetScreenCordinatesForMoreActionsPopup(txt);
        //document.getElementById("ctl00_header1_DivMoreActionForPopup_FromHeader").style.left = p.x;
        //document.getElementById("ctl00_header1_DivMoreActionForPopup_FromHeader").style.top = p.y;
        //document.getElementById("ctl00_header1_DivMoreActionForPopup_FromHeader").style.display = "block";
        //document.getElementById("DivEditCallPopup_FromHeader").style.display = "none";
        //document.getElementById("DivAddNotePopup_FromHeader").style.display = "none";
    }

    function CloseMoreActionsPopup_FromHeader(btnid) {
        //document.getElementById("ctl00_header1_DivMoreActionForPopup_FromHeader").style.display = "none";
    }

    function GetScreenCordinatesForMoreActionsPopup(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 0;
            p.y = p.y + obj.offsetParent.offsetTop - 0;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function fcposition(obj) {
        //var p = {};
        //p.x = obj.offsetLeft;
        //p.y = obj.offsetTop;
        //while (obj.offsetParent) {
        //    p.x = p.x + obj.offsetLeft - 0;
        //    p.y = p.y + obj.offsetTop - 0;
        //    if (obj == document.getElementsByTagName("body")[0]) {
        //        break;
        //    }
        //    else {
        //        obj = obj.offsetParent;
        //    }
        //}
        document.getElementById("fc").style.display = "inline";
        document.getElementById("fc").style.position = "fixed";
        document.getElementById("fc").style.left = "50%";
        document.getElementById("fc").style.top = "50%";
        document.getElementById("fc").styletransform = " translate(-50%, -50%)";
        document.getElementById("fc").style.width = "auto";
        //document.getElementById("fc").style.marginLeft = p.x + "px";
        //document.getElementById("fc").style.marginTop = p.y + "px";
    }

    function ShowCallDetailType_FromHeader() {
        var ddlCallDetailsType = document.getElementById("ctl00_header1_ddlCallDetailsType");

        ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].text;
        var finalCallType = ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].value;

        if (finalCallType == "1") {
            document.getElementById("DurationStar_FromHeader").style.display = "none";
            document.getElementById("DivCallTimer_FromHeader").style.display = "none";
            document.getElementById("DivCallStartTime_FromHeader").style.display = "block";
            document.getElementById("DivCallStartTime1_FromHeader").style.display = "block";
            document.getElementById("DivCallDuration_FromHeader").style.display = "block";
            document.getElementById("DivCallDuration1_FromHeader").style.display = "block";
            document.getElementById("Span_MinuteSecond_FromHeader").style.display = "none";
        }
        if (finalCallType == "2") {
            document.getElementById("DurationStar_FromHeader").style.display = "none";
            document.getElementById("DivCallTimer_FromHeader").style.display = "none";
            document.getElementById("DivCallStartTime_FromHeader").style.display = "block";
            document.getElementById("DivCallStartTime1_FromHeader").style.display = "block";
            document.getElementById("DivCallDuration_FromHeader").style.display = "block";
            document.getElementById("DivCallDuration1_FromHeader").style.display = "block";
            document.getElementById("Span_MinuteSecond_FromHeader").style.display = "none";
        }
    }

</script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $("#ctl00_header1_imgclose").click(function () {
            AutoFill.UpgradeNotificationClose(GetResult, onTimeout, onError);
            $("#ctl00_header1_divmessage").fadeOut(1000);
            $("#tblNotification").fadeOut(1000);
        });
    });

    function GetResult(result) {

    }



    function onTimeout(request, context) {
    }
    function onError(objError) {

    }
</script>
<script type="text/javascript">
    var sitepath = 'https://demo.eprintsoftware.com/';
    var sessionTimeout = "6000";
    var hdnSessionCntr = document.getElementById("ctl00_header1_hdnSessionCntr");


    //search functionality
    function capturekey(e) {
        var evt = e ? e : window.event;
        if (evt) {
            if (evt.keyCode == 13) {
                var combo = $find('ctl00_header1_ddl_Search');
                //var comboValue = combo.get_selectedItem().get_text();
                var comboValue = combo.get_selectedItem().get_value();
                if (comboValue.toLowerCase() == 'inventory') {
                    comboValue = 'warehouse';
                }
                var id = "searchDdlItem";
                createCookie(id, comboValue, 0);
                Onclick_Search();
                return false;
            }
        }
    }


    function Onclick_Search() {

        var modulename;
        var combo = $find('ctl00_header1_ddl_Search');
        //var module = combo.get_selectedItem().get_text();
        var module = combo.get_selectedItem().get_value();
        if (module.toLowerCase() == 'all') {
            modulename = "all";
        }
        else if (module.toLowerCase() == 'crm') {
            modulename = "crm";
        }
        else if (module.toLowerCase() == 'estimates') {
            modulename = "estimates";
        }
        else if (module.toLowerCase() == 'order') {
            modulename = "order";
        }
        else if (module.toLowerCase() == 'job') {
            modulename = "job";
        }
        else if (module.toLowerCase() == 'purchase order') {
            modulename = "purchaseorder";
        }
        else if (module.toLowerCase() == 'delivery notes') {
            modulename = "deliverynotes";
        }
        else if (module.toLowerCase() == 'inventory') {
            modulename = "warehouse";
        }
        else if (module.toLowerCase() == 'invoice') {
            modulename = "invoice";
        }

        var txt_search = document.getElementById("ctl00_header1_txt_search");
        //var serch_string = txt_search.value;
        var serch_string = SpecialEncode(txt_search.value);
        serch_string = serch_string.trim();
        if (txt_search.value == "") {
            alert("Please enter the string in search field");
        }
        else if (serch_string.length < 3) {
            alert("Please enter minimum of 3 character");
        }
        else {
            //window.location = "https://demo.eprintsoftware.com/" + "TestSearch.aspx?srch_val=" + serch_string + "?module=" + modulename;
            var a = window.location = "https://demo.eprintsoftware.com/" + "search_results.aspx?srch_val=" + serch_string + "&module=" + modulename;
            // waitingDialog({});
            return a;
        }
    }


    function calldefaulttext() {
        var defaulttext = document.getElementById("ctl00_header1_txt_search").value;
        if (defaulttext == "") {
            document.getElementById("ctl00_header1_txt_search").value = "Search....";
        }
    }


    function Cleardefault_SearchText() {
        var defaulttext = document.getElementById("ctl00_header1_txt_search").value;
        if (defaulttext.toLowerCase() == "search....") {
            document.getElementById("ctl00_header1_txt_search").value = "";
        }
    }
</script>
<script type="text/javascript">
    // to set serchbox position
    //    var scrnLeft = screen.width - 250;
    //    function setSerachboxposition() {
    //        document.getElementById("divsearch").style.left = scrnLeft + "px";
    //    }
    //    setSerachboxposition();

    //search functionality
    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    // for loading screen in searchresults page
    $(document).ready(function () {
        // create the loading window and set autoOpen to false

        $("#loadingScreen").dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "loadingScreenWindow",
            closeOnEscape: false,
            draggable: false,
            Width: 100,
            minHeight: 100,
            modal: true,
            buttons: {},
            resizable: false,
            open: function () {
                // scrollbar fix for IE
                $('body').css('overflow', 'hidden');
            },
            close: function () {
                // reset overflow
                $('body').css('overflow', 'auto');
            }
        }); // end of dialog
    });
    function waitingDialog(waiting) { // I choose to allow my loading screen dialog to be customizable, you don't have to        
        $("#loadingScreen").html(waiting.message && '' != waiting.message ? waiting.message : '');
        $("#loadingScreen").dialog("option", "width", 100);
        $("#loadingScreen").dialog('open');
    }
    function closeWaitingDialog() {
        $("#loadingScreen").dialog('close');
    }

    if (document.body.clientWidth) {
        var divposition = (document.body.clientWidth / 2) - 200;
        if (document.getElementById("ctl00_header1_divmessage") != null || document.getElementById("ctl00_header1_divmessage") != undefined) {
            document.getElementById("ctl00_header1_divmessage").style.left = divposition + 'px';
        }
        if (document.getElementById("tblNotification") != null || document.getElementById("tblNotification") != undefined) {
            document.getElementById("tblNotification").style.left = divposition + 'px';
        }
    }
</script>
<script type="text/javascript">

    $(document).click(function (event) {

        if (document.getElementById('div_SettingsMenu') != null) {

            if (issettingimgclick == true) {

                if ("yes" == "no") {
                    document.getElementById('div_SettingsMenu').style.display = 'none';
                    window.location.href = "https://demo.eprintsoftware.com/" + "settings/settings.aspx";
                }
                else if (MISsettingHeight == "" && eStoreSettingHeight == "false") {
                    document.getElementById('div_SettingsMenu').style.display = 'none';
                    window.location.href = "https://demo.eprintsoftware.com/" + "settings/settings.aspx";
                }
                else if (MISsettingHeight == "false" && eStoreSettingHeight == "") {
                    document.getElementById('div_SettingsMenu').style.display = 'none';
                    window.location.href = "https://demo.eprintsoftware.com/" + "StoreSettings/StoreSettings.aspx";
                }
                else {
                    document.getElementById('div_SettingsMenu').style.display = 'block';
                }
            }
            else {
                document.getElementById('div_SettingsMenu').style.display = 'none';
            }
            issettingimgclick = false;
        }
    });
    var issettingimgclick = false;
    if (GetRolesRight_SettingIcon == "false") {

        document.getElementById("settingimg").style.display = 'none';
        document.getElementById("ctl00_header1_div_empty").style.display = 'block';
    }
    else {
        document.getElementById("settingimg").style.display = 'block';
        if (MISsettingHeight == "false" || eStoreSettingHeight == "false") {
            document.getElementById("div_SettingsMenu").style.height = '35px';
            if (MISsettingHeight == "false") {
                document.getElementById("ctl00_header1_eStore").style.margin = "-7px 0px 0px 0px";
            }
        }
        else {
            document.getElementById("div_SettingsMenu").style.height = '58px';
        }
    }


    if (IsWebstore == "no") {
        document.getElementById("div_SettingsMenu").style.height = '35px';
    }
    else {
        document.getElementById("div_SettingsMenu").style.height = '58px';
    }




    if (IsSettingTabDisplay == "true") {
        document.getElementById("settingimg").style.display = 'block';
    }
    else {
        document.getElementById("settingimg").style.display = 'none';
        //document.getElementById("ctl00_header1_div_empty").style.display = 'block';
        document.getElementById("ctl00_header1_divMainAlert").style.margin = "10px 0px 0px -9px";
        document.getElementById('divheadericons').style.marginLeft = '33px';
        imgreports.style.marginBottom = '0px';
    }

    $("#settingimg").click(function (event) {

        if (document.getElementById('div_SettingsMenu') != null) {
            if (document.getElementById('div_SettingsMenu').style.display == 'block') {
                issettingimgclick = false;
                document.getElementById('div_SettingsMenu').style.display = 'none';
            }
            else {
                issettingimgclick = true;
                document.getElementById('div_SettingsMenu').style.display = 'block';
            }
            return;
        }
    });


    $(document).click(function (event) {
        if (document.getElementById('pnluserprofile') != null) {
            if (isimgclick == true) {
                document.getElementById('pnluserprofile').style.display = 'block';
            }
            else {
                document.getElementById('pnluserprofile').style.display = 'none';
            }

            isimgclick = false;
        }
    });

    var isimgclick = false;
    $("#imgprofile").click(function (event) {
        if (document.getElementById('pnluserprofile') != null) {
            if (document.getElementById('pnluserprofile').style.display == 'block') {
                isimgclick = false;
                document.getElementById('pnluserprofile').style.display = 'none';
            }
            else {
                isimgclick = true;
                document.getElementById('pnluserprofile').style.display = 'block';
            }
            return;
        }
    });


    if (document.getElementById('settingimg').style.display == 'none' && document.getElementById('imgreports').style.display == 'none') {
        document.getElementById('divheadericons').style.marginLeft = '36px';
        document.getElementById("ctl00_header1_divMainAlert").style.margin = "10px 0px 0px 30px";
    }


    $(document).keypress(function (e) {
        var keyCode = (window.event) ? e.which : e.keyCode;
        if (keyCode && keyCode == 13) {
            if (document.activeElement.tagName.toLowerCase() != "textarea") {
                e.preventDefault();
                return false;
            }
        }
    });

    var UserImage1 = '';
    var UserImage2 = '';
    if (UserImage1 != "") {
        $("#imgprofile").attr("src", UserImage1);

    }
    if (UserImage2 != "") {

        $("#imgprofilelarge").attr("src", UserImage2);
    }

</script>

<input type="hidden" name="ctl00$header1$editViewID" id="ctl00_header1_editViewID" value="0" />
<input type="hidden" name="ctl00$header1$hdnestimateViewID" id="ctl00_header1_hdnestimateViewID" value="0" />
<script type="text/javascript">
    changeBorderColor(tabcolor);
</script>

                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" id="borderright" width="100%">
                                    <tr valign="top">
                                        <td style="width: 100%; background-color: white" align="center">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <table id="middleTable" cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: white">
                                                            
<script type="text/javascript">
    function openHelp(section, subsection) {
        var openwin;
        openwin = "https://demo.eprintsoftware.com/" + "help/userhelp.aspx?section=" + section + "&subsection=" + subsection;
        window.open(openwin, '', 'width=775,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=120,top=100');
    }
</script>

<tr valign="middle" style="border-color: Red; border-width: 1px" width="50%">
    <td class="tabheadertext bgcustomize" height="25px" width="50%">
        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="Table11" style="padding-right: 5px;"
            class="normaltext">
            <tr>
                <td colspan="10" height="3px">
                </td>
            </tr>
            <tr>
                <td class="NavigationArea_td" align="left" nowrap="nowrap">
                    <b>&nbsp;
                        
                        <span id="ctl00_header2_lblsitepath" style="padding-left:3px;"><span class='navigatorpanelblack'><b><a href=../welcome.aspx class='subnavigatorblack' style=text-decoration:underline>Home</a>&nbsp;>&nbsp;<a href=client_view.aspx class='subnavigatorblack' style=text-decoration:underline>CRM View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;>&nbsp; Customer Add </b></span></span>
                        <a id="ctl00_header2_lnkHome" href="javascript:__doPostBack('ctl00$header2$lnkHome','')"></a><span id="ctl00_header2_lblHome"></span><a id="ctl00_header2_lnkSection" href="javascript:__doPostBack('ctl00$header2$lnkSection','')"></a><span id="ctl00_header2_lblSection"></span><a id="ctl00_header2_lnkSubsection" href="javascript:__doPostBack('ctl00$header2$lnkSubsection','')"></a><span id="ctl00_header2_lnkTask"></span>
                    </b>
                </td>
                <td style="display: none" width="100%" align="right" class="normaltext" valign="middle">
                    
                </td>
                <td align="right" style="color: White; padding-top: 3px; display: none;" nowrap="nowrap"
                    valign="middle">
                    
                </td>
                <td align="right" class="normaltext" nowrap="nowrap" valign="middle" style="display: none;">
                    <strong style="color: White">&nbsp;|&nbsp;</strong>
                </td>
                <td align="right" class="normaltext" nowrap="nowrap" valign="middle">
                    
                </td>
            </tr>
        </table>
    </td>
</tr>

                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="">
                                                                        <tr valign="top" class="border_leftonly">
                                                                            <td>
                                                                                <div class="onlyEmpty">
                                                                                    <img src="https://demo.eprintsoftware.com/images/nil.gif" width="1" border="0" height="10px">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr valign="top">
                                                                            <td class="bodypanel" align="center" style="background-color: White">
                                                                                <table style="height: 100%; width: 99.4%" align="right" id="innerTable" border="0"
                                                                                    cellpadding="0" cellspacing="0">
                                                                                    <tr valign="top">
                                                                                        <!--LEFTPANEL-->
                                                                                        <td id="ctl00_tdLeftpanel" style="height: 100%; width: 175px;" valign="top">
                                                                                            <div id="ctl00_DivLeftpanel" style="display:none;">
                                                                                                <table style="float: left" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            
                                                                                                            <div id="ctl00_panel_company">
	
                                                                                                                <div id="ctl00_Printbroker1_pnlcompany">
		
    <tr valign="top">
        <td>
            <div id="div_copmpany_main" style="display: block;">
                <div id="ctl00_Printbroker1_div_copmpany_open" onclick="show_company_leftpanel('none');" style="cursor: pointer; display: block">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="https://demo.eprintsoftware.com/images/lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong class="navigatorpanel" style="padding-right: 81px">Options</strong><img alt=""
                                    src="https://demo.eprintsoftware.com/images/opentriangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="https://demo.eprintsoftware.com/images/rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="ctl00_Printbroker1_div_copmpany_close" onclick="show_company_leftpanel('block');" style="cursor: pointer; display: none">
                    <table cellspacing="0" cellpadding="0" width="159px" border="0">
                        <tr>
                            <td valign="top" align="left" class="bgcustomize">
                                <img src="https://demo.eprintsoftware.com/images/lt_tabnotch.gif" width="5px" border="0" height="5">
                            </td>
                            <td nowrap="nowrap" width="149px" class="bgcustomize" height="23">
                                <strong style="padding-right: 81px" class="navigatorpanel">Options</strong><img alt=""
                                    src="https://demo.eprintsoftware.com/images/triangle.gif" align="absmiddle" />
                            </td>
                            <td valign="top" align="right" class="bgcustomize">
                                <img src="https://demo.eprintsoftware.com/images/rt_tabnotch.gif" width="5px" height="5">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </td>
    </tr>
    <tr valign="top">
        <td class="normaltext">
            <div id="ctl00_Printbroker1_div_copmpany_contents1" style="display: block">
                <ul id="verticalmenu" class="glossymenu1">
                    
                    
                    
                    
                    
                    
                    <li id="ctl00_Printbroker1_li_Customers"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;Customer</a>
                        <ul style="border-top: solid 1px #ccc" id="ul1" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            
                            <li>
                                <a id="ctl00_Printbroker1_lnKAddCustomer" href="javascript:__doPostBack('ctl00$Printbroker1$lnKAddCustomer','')">&nbsp;&nbsp;Add</a></li>
                            
                            <li>
                                <a id="ctl00_Printbroker1_lnKViewCustomer" href="javascript:__doPostBack('ctl00$Printbroker1$lnKViewCustomer','')">&nbsp;&nbsp;View</a></li>
                        </ul>
                    </li>
                    <li id="ctl00_Printbroker1_li_Suppliers"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;Supplier</a>
                        <ul style="border-top: solid 1px #ccc" id="ul3" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            
                            <li>
                                <a id="ctl00_Printbroker1_lnKAddSupplier" href="javascript:__doPostBack('ctl00$Printbroker1$lnKAddSupplier','')">&nbsp;&nbsp;Add</a></li>
                            <li>
                                <a id="ctl00_Printbroker1_lnKViewSupplier" href="javascript:__doPostBack('ctl00$Printbroker1$lnKViewSupplier','')">&nbsp;&nbsp;View</a></li>
                        </ul>
                    </li>
                    <li id="ctl00_Printbroker1_li_Prospects"><a href="#" onmouseover="javascript:hidedropdown()"
                        onmouseout="javascript:showdropdown()">&nbsp;&nbsp;Prospect</a>
                        <ul style="border-top: solid 1px #ccc" id="ul4" onmouseover="javascript:hidedropdown()"
                            onmouseout="javascript:showdropdown()">
                            
                            <li>
                                <a id="ctl00_Printbroker1_lnKAddProspect" href="javascript:__doPostBack('ctl00$Printbroker1$lnKAddProspect','')">&nbsp;&nbsp;Add</a></li>
                            <li>
                                <a id="ctl00_Printbroker1_lnKViewProspect" href="javascript:__doPostBack('ctl00$Printbroker1$lnKViewProspect','')">&nbsp;&nbsp;View</a></li>
                        </ul>
                    </li>
                    <li id="ctl00_Printbroker1_licontactview">
                        
                        <a id="ctl00_Printbroker1_LnkViewContacts" href="javascript:__doPostBack('ctl00$Printbroker1$LnkViewContacts','')">&nbsp;&nbsp;View Contacts</a>
                    </li>
                    
                    
                    <li id="ctl00_Printbroker1_report">
                        
                        <a id="ctl00_Printbroker1_lnkCRMReports" href="javascript:__doPostBack('ctl00$Printbroker1$lnkCRMReports','')">&nbsp;&nbsp;Reports</a>
                    </li>
                    
                </ul>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <img alt="" src="https://demo.eprintsoftware.com/images/nil.gif" height="10" />
        </td>
    </tr>

	</div>

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
            if (qrystr[0] == 'type') {
                pgtype = qrystr[1];
            }
        }
        window.location.href = "https://demo.eprintsoftware.com/" + "client/CustomViewCRM.aspx?type=edit&id=" + ddl.options[ddl.selectedIndex].value + "&cid=" + 1534 + "&pgtype=" + pgtype;
    }
    function checkpath1() {
        var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddl_View_cust");
        var pgtype = "accounts";
        if (window.location.search.substring(1) != '') {
            var qrystr = window.location.search.substring(1).split("=");
            if (qrystr[0] == 'type') {
                pgtype = qrystr[1];
            }
        }
        window.location.href = "https://demo.eprintsoftware.com/" + "accounts/accounts_edit_view.aspx?type=edit&id=" + ddl.options[ddl.selectedIndex].value + "&cid=" + 1534 + "&pgtype=" + pgtype;
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

                                                                                                            
</div>
                                                                                                            
                                                                                                            <div id="ctl00_printcenter_leftpanel">
	
                                                                                                                
<script src="../js/Item/javascript.js?VN='3.9.7'" type="text/javascript"></script>
<script src="../js/approvalsystem.js?VN='3.9.7'" type="text/javascript"></script>

<script src="../js/item/item_summary.js?VN='3.9.7'" type="text/javascript"></script>
<script type="text/javascript" src="https://demo.eprintsoftware.com/js/item/item_summary_reeng.js?VN='3.9.7'"></script>

<div id="ctl00_tint_divLoadingImageCus" style="display: none;">
    <div id="DivLayer" class="loading_background">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="https://demo.eprintsoftware.com/images/loading_new.gif" border="0" style="border-radius: 2px;" />
    </div>
</div>









<style type="text/css">
    .RadPanelBar, .RadPanelBar .rpSlide, .RadPanelBar .rpGroup, .RadPanelBar .rpItem, .RadPanelBar .rpTemplate
    {
        overflow: visible !important;
    }
    div.RadPanelBar .rpLevel1 .rpItem
    {
        padding: 0;
    }
    * html .RadPanelBar .RadMenu ul.rmRootGroup
    {
        zoom: 1;
    }
    div.RadMenu .rmRootGroup
    {
        border: 0;
    }
    div.RadMenu .rmLink
    {
        float: none;
    }
    .leftPanelBarContainer
    {
        float: left;
        width: 250px;
        height: 250px;
        overflow: auto;
        position: relative; /* Required to workaround IE rendering bug*/
    }
</style>


<input type="hidden" name="ctl00$tint$hdnPCPath" id="ctl00_tint_hdnPCPath" />
<input type="hidden" name="ctl00$tint$hdnIDs" id="ctl00_tint_hdnIDs" value="0" />
<input type="hidden" name="ctl00$tint$editViewID" id="ctl00_tint_editViewID" value="0" />
<input type="hidden" name="ctl00$tint$CompanyID_change" id="ctl00_tint_CompanyID_change" />
<input type="hidden" name="ctl00$tint$hidchkDeletepo" id="ctl00_tint_hidchkDeletepo" value="false" />
<input type="hidden" name="ctl00$tint$hidchkDeleteDel" id="ctl00_tint_hidchkDeleteDel" value="false" />
<input type="hidden" name="ctl00$tint$hdnReduceStockTypeForCancelledNew" id="ctl00_tint_hdnReduceStockTypeForCancelledNew" value="false" />
<input type="hidden" name="ctl00$tint$hdnStockCancelChk" id="ctl00_tint_hdnStockCancelChk" value="false" />
<a id="ctl00_tint_lnk_RevertToJob" href="javascript:__doPostBack('ctl00$tint$lnk_RevertToJob','')" style="display: none"></a>
<input type="hidden" name="ctl00$tint$hdnOrderID" id="ctl00_tint_hdnOrderID" value="0" />
<input type="hidden" name="ctl00$tint$hdnEstimateID" id="ctl00_tint_hdnEstimateID" value="0" />

<script>
    var strSitepath = 'https://demo.eprintsoftware.com/';
    var CompanyID_change = document.getElementById("ctl00_tint_CompanyID_change");
    var hdnReduceStockTypeForCancelledNew = document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew");
    var hidchkDeletepo = document.getElementById("ctl00_tint_hidchkDeletepo");
    var hidchkDeleteDel = document.getElementById("ctl00_tint_hidchkDeleteDel");
    var ManageStockPermission = '1';
    var StockCancellationType = 'a';
    var hdnEstimateID = document.getElementById("ctl00_tint_hdnEstimateID");

    function editview() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_job() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_invoice() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_order() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_purchase() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_delivery() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_inventory() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_store() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View1');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }
    function editview_item() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View2');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function editview_campaign() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_sectionView_ddl_View');
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = ddl.options[ddl.selectedIndex].value;
        if (ddl.selectedIndex == 0) {
            CompanyID_change.value = 0;
        }
    }

    function Copy_campaign() {
        var editViewID = document.getElementById("ctl00_tint_editViewID");
        editViewID.value = campaignid;
    }



    function CheckchkOne(type) {
        var PageType = '';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        var Ides = "";

        hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                }
            }
        }
        hdnIDs.value = Ides;

        if (Number(Counter) == 0) {
            if (type == "delete") {
                alert("Please check at least one row to Delete");
            }
            else if (type == "archive") {
                alert("Please check at least one row to Archive");
            }
            else if (type == "unarchive") {
                alert("Please check at least one row to Un-Archive");
            }
            return false;
        }
        else {
            var check = "";
            if (type == "delete") {
                check = window.confirm('Are you sure you want to delete this record(s)?');
            }
            else if (type == "archive") {
                check = window.confirm('Are you sure you want to archive this record(s)?');
            }
            else if (type == "unarchive") {
                check = window.confirm('Are you sure you want to un-archive this record(s)?');
            }
            if (check) {
                if (type == "delete") {
                    if (PageType == "purchase") {
                        DeletePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        DeleteDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        DeleteOrder(Ides);
                    }
                    else {
                        DeleteInv();
                    }
                }
                else if (type == "archive") {
                    if (PageType == 'estimate') {
                        ArchiveEstimate();
                    }
                    else if (PageType == 'job') {
                        ArchiveJob();
                    }
                    else if (PageType == 'invoice') {
                        ArchiveInvoice();
                    }
                    else if (PageType == "purchase") {
                        ArchivePurchase(Ides);
                    }
                    else if (PageType == "delivery") {
                        ArchiveDelivery(Ides);
                    }
                    else if (PageType == "orders") {
                        ArchiveOrder(Ides);
                    }
                    else {
                        ArchiveInv();
                    }
                }
                else if (type == "unarchive") {
                    UnArchiveInv();
                }
                return false;
            }
            else {
                return check;
            }
            //  return true;
        }
    }

    function DelArc_Estimate(type) {
        var PageType = '';
        var check = "";
        if (type == "delete") {
            check = window.confirm('Are you sure you want to delete this record?');
        }
        else {
            check = window.confirm('Are you sure you want to archive this record?');
        }
        if (check) {
            if (PageType == 'estimate' && type == "archive") {
                Archive_Estimate();
            }
            else if (PageType == 'estimate' && type == "delete") {
                Delete_Estimate();
            }
            //return false;
        }
        else {
            return check;
        }
    }
    function CheckchkOnlyOne() {
        var PageType = '';
        //-----------------------------
        var Counter = 0;
        var frm = document.forms[0];
        hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
        var Ides = "";
        var EstIDs = "";
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked) {
                    Counter = Number(Counter) + 1;
                    Ides = Ides + e.value + ",";
                    if (PageType == 'job' || PageType == 'invoice') {
                        var EstimateID = document.getElementById("hid_EstimateID_" + e.value + "").value;
                        EstIDs = EstIDs + EstimateID + ",";
                    }
                }
            }
        }
        hdnIDs.value = Ides;
        if (Number(Counter) == 0) {
            if (PageType == 'estimate') {
                alert("Please select at least one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == 'job') {
                alert("Please select at least one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                // alert("Please select at least one Purchase to Copy To New Purchase");
                alert('Please select at least one purchase to copy to new purchase');
                return false;
            }
        }
        else if (Number(Counter) == 1) {
            if (PageType == 'estimate') {
                CopyEstimate();
                return false;
            }
            else if (PageType == 'job') {
                CopyJob(Ides, EstIDs);
                return false;
            }
            else if (PageType == 'invoice') {
                CopyInvoice(Ides, EstIDs);
                return false;
            }
            else if (PageType == "purchase") {
                CopyPurchase(Ides);
                return false;
            }
        }
        else if (Number(Counter) > 1) {
            if (PageType == 'estimate') {
                alert("Please select only one Estimate to Copy To New Estimate");
                return false;
            }
            else if (PageType == "job") {
                alert("Please select only one Job to Copy To New Job");
                return false;
            }
            else if (PageType == "purchase") {
                alert("Please select only one Purchase to Copy To New Purchase");
                return false;
            }
        }
    }
</script>
<script type="text/javascript">
    function hideDivNew1() {
        document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');

    }

    function Save1(val) {

        if (val == 'Y') {

            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');

        }
        else {

            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
            __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        }
    }

    function RevertJobNew() {
        var chkInvadjusted = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkInvadjusted");
        if (chkInvadjusted.checked) {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "true";
        }
        else {
            document.getElementById("ctl00_tint_hdnReduceStockTypeForCancelledNew").value = "false";
        }

        var chkDeletepo = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeletepo");
        var chkDeleteDel = document.getElementById("ctl00_ContentPlaceHolder1_UCItemSummary_chkDeleteDel");
        if (chkDeletepo.checked) {
            hidchkDeletepo.value = "true";
        }
        if (chkDeleteDel.checked) {
            hidchkDeleteDel.value = "true";
        }
        __doPostBack('ctl00$tint$lnkRevertJobNew', '');
        return false;
    }
</script>
<script>
    var menuids = new Array("verticalmenu", "jobverticalmenu") //Enter id(s) of UL menus, separated by commas                
    var submenuoffset = -2 //Offset of submenus from main menu. Default is -2 pixels.

    function createcssmenu() {
        //           for(var i=0;i<menuids.length;i++)
        //           {
        //              var ultags=document.getElementById(menuids[i].getElementsByTagName("ul"));
        //              alert(ultags.length);
        //           }
        for (var i = 0; i < menuids.length; i++) {
            var ultags = '';
            try {
                ultags = document.getElementById(menuids[i]).getElementsByTagName("ul")
            }
            catch (err) {
            }

            for (var t = 0; t < ultags.length; t++) {
                var spanref = document.createElement("span")

                spanref.className = "arrowdiv";
                spanref.innerHTML = "&nbsp;&nbsp;";

                //ultags[t].parentNode.getElementsByTagName("a")[0].appendChild(spanref)

                ultags[t].parentNode.onmouseover = function () {
                    this.getElementsByTagName("ul")[0].style.left = this.parentNode.offsetWidth + submenuoffset + "px";
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
    function set_height(divid, divheight) {

        document.getElementById("div6").style.height = "140px";
    }
    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }

    function estimate(val) {

        //ctl00_divrecentitem1.style.display=val;
        if (val == 'none') {
            //recentitems.slideup();divrecentitem
            //slideup('divrecentitem_1');
            //ctl00_tint_divestimateopen.style.display='block';
            //ctl00_tint_divestimateclosed.style.display='none';
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'none';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'block';
            document.getElementById("divrecentitem_1").style.display = 'none';
            //WriteCookie('NO3');
        }
        else {
            //ctl00_divrecentitem1_1.style.display=val;
            //recentitems.slidedown();
            // slidedown('divrecentitem_1');
            document.getElementById("ctl00_tint_divestimateclosed").style.display = 'block';
            document.getElementById("ctl00_tint_divestimateopen").style.display = 'none';
            document.getElementById("divrecentitem_1").style.display = 'block';
            //ctl00_recentitem.style.display='block';
            //WriteCookie('YES3');
        }
    }
</script>
<script>
    //====== Customized Left panel  ========//
    function CustLeftPanel(val) {
        if (val == 'none') {
            //            slideup('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='block';
            //            ctl00_tint_divcustclose.style.display='none';     
            document.getElementById("ctl00_tint_divcustclose").style.display = 'none';
            document.getElementById("ctl00_tint_divcustshow").style.display = 'block';
            document.getElementById("divCustContent").style.display = 'none';
        }
        else {
            //            slidedown('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='none';
            //            ctl00_tint_divcustclose.style.display='block';   
            document.getElementById("ctl00_tint_divcustclose").style.display = 'block';
            document.getElementById("ctl00_tint_divcustshow").style.display = 'none';
            document.getElementById("divCustContent").style.display = 'block';
        }
    }

    function CustLeftPaneljob(val) {
        if (val == 'none') {
            //document.getElementById("ctl00_tint_divjobcustclose").style.display = 'none';
            // document.getElementById("ctl00_tint_divjobcustshow").style.display = 'block';
            //document.getElementById("divjobCustContent").style.display = 'none';
        }
        else {
            //document.getElementById("ctl00_tint_divjobcustclose").style.display = 'block';
            //document.getElementById("ctl00_tint_divjobcustshow").style.display = 'none';
            //document.getElementById("divjobCustContent").style.display = 'block';
        }
    }

    function CustLeftPanel2(val) {
        if (val == 'none') {
            //            slideup('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='block';
            //            ctl00_tint_divcustclose.style.display='none';     
            document.getElementById("ctl00_tint_divcustclose2").style.display = 'none';
            document.getElementById("ctl00_tint_divcustshow2").style.display = 'block';
            document.getElementById("divCustContent2").style.display = 'none';
        }
        else {
            //            slidedown('ctl00_tint_divCustContent');
            //            ctl00_tint_divcustshow.style.display='none';
            //            ctl00_tint_divcustclose.style.display='block';   
            document.getElementById("ctl00_tint_divcustclose2").style.display = 'block';
            document.getElementById("ctl00_tint_divcustshow2").style.display = 'none';
            document.getElementById("divCustContent2").style.display = 'block';
        }
    }
</script>
<script>
    function CallConfirm() {
        var ret = window.confirm("Are you sure you want to create delivery note against this job?");
        if (ret) {
            return true;
        }
        else {
            return false;
        }
    }

</script>

<script>
    //    $(document).ready(function() {
    //        $("#imgleftpanelClick").click(function(event) {

    //            event.preventDefault();
    //            $("#divLeftpanel").fadeOut(0);

    //            document.getElementById("RightPanel").style.display = "none";
    //            $("#RightPanel").fadeOut(0);
    //            $("#tdLeftpanel").fadeIn(0);
    //            $("#RightPanel").fadeIn(0);
    //            setCookie('username', "open", 2);
    //            checkCookie();


    //        });
    //        $("#imgClosepanel").click(function(event) {

    //            setCookie('username', "close", 2);
    //            checkCookie();

    //            event.preventDefault();

    //            $("#tdLeftpanel").fadeOut(0);
    //            document.getElementById("tdLeftpanel").style.display = "none";
    //            document.getElementById("RightPanel").style.display = "none";

    //            $("#divLeftpanel").fadeIn(0);
    //            $("#RightPanel").fadeIn(0);
    //        });
    //    });

    // By Pradeep
    function Open_ProductCatalogue(EstItemID, EstId, i) {
        var hdnEstType = document.getElementById("hdnEstType_" + i).value;
        var strTypes = hdnEstType.split('~')
        var strPath = document.getElementById("ctl00_tint_hdnPCPath").value;
        window.location = strPath + "?EstID=" + EstId + "&EstItemID=" + EstItemID + "&ToConvert=Yes&EstType=" + strTypes[0] + "&pgFrom=" + strTypes[1] + "";
        //window.location = strPath;
    }

    //    function Edit_ProductCatalogue(id) {        
    //        var strPath = document.getElementById("ctl00_tint_hdnPCPath").value;
    //        window.open(strPath + "?action=edit&id=" + id + "", '_blank');
    //    }
    //End By Pradeep

    function OpenCreateInvoice(EstID) {
        var hdnOrderID = document.getElementById("ctl00_tint_hdnOrderID");
        var url = window.location.href;
        var module;
        //alert(url.indexOf("Jobs/job"));
        if (url.toLowerCase().indexOf("job_order_summary") != -1) {
            module = "ProgressToInvoiceFromOrder";
        }
        else if (url.toLowerCase().indexOf("job_summary_reeng") != -1) {
            module = "ProgressToInvoiceFromJob";
        }

        var RadWindow_Paid = window.radopen("https://demo.eprintsoftware.com/common/Invoice_Paid.aspx?EstimateID=" + EstID + "&IsPaid=0&Module=" + module + "&OrderID=" + hdnOrderID.value);
        //        SetRadWindow('divrad', 'divBackGroundNew', '200');
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(510, 520);
        RadWindow_Paid.center();
        //        var a = ProgressJob_reeng();
        //                return a;
        return false;
    }

    function OpenCreateInvoiceForRecordView(EstID, IsJobFromWebstore) {
        var RadWindow_Paid = window.radopen("https://demo.eprintsoftware.com/common/Invoice_Paid.aspx?EstimateID=" + EstID + "&IsPaid=1&Module=JobRecordView&&IsJobFromWebstore=" + IsJobFromWebstore + "");
        SetRadWindow_Ver2('divrad', 'divBackGroundNew');
        RadWindow_Paid.setSize(680, 500);
        RadWindow_Paid.center();
        return false;
    }
</script>

                                                                                                            
</div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="only5px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>

                                                                                        
                                                                                        <!--BODY TD START-->
                                                                                        <td id="ctl00_RightPanel" valign="top" style="width:100%;height:100%;">
                                                                                            <table class="Tb_BGcolor" style="height: 100%" cellspacing="0" cellpadding="0" border="0"
                                                                                                width="100%" align="right">
                                                                                                <tr>
                                                                                                    <td valign="top">
                                                                                                        
   <div>
        
<script type="text/javascript" src="https://demo.eprintsoftware.com/common/calendar.js?VN='3.9.7'"></script>


<script src="https://demo.eprintsoftware.com/js/item/purchaseadd.js?VN='3.9.7'" type="text/javascript"></script>
<script type="text/javascript">
    var CompanyID = '1534';
    var UserID = '3815';
    var currentdate = 'dd/mm/yyyy';
    var DateFormat = 'dd/mm/yyyy';

</script>
<style type="text/css">
    .rcbItem {
        font-family: "Verdana", Verdana, Arial, Helvetica, sans-serif !important;
        color: #000000 !important;
        font-weight: normal !important;
        font-size: 11px !important;
    }

    .rcbInput {
        color: #000000 !important;
        font-family: "Verdana", Verdana, Arial, Helvetica, sans-serif !important;
        font-weight: normal !important;
        font-size: 11px !important;
        height: 15px;
    }

    .RadComboBox_Default .rcbInputCell .rcbEmptyMessage {
        font-style: normal !important;
        font-size: 11px !important;
    }
</style>

<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdnsystemname" id="ctl00_ContentPlaceHolder1_ClientAddID_hdnsystemname" value="demo" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdncmpnyaddressid" id="ctl00_ContentPlaceHolder1_ClientAddID_hdncmpnyaddressid" />
<div id="ctl00_ContentPlaceHolder1_ClientAddID_ColourPanel" class="navigatorpanel show_hide">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div align="left" nowrap="nowrap">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lblAddCompany" class="navigatorpanel">Add New Company</span>
                        
                    </div>
                    <div align="left" nowrap="nowrap">
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="ctl00_ContentPlaceHolder1_ClientAddID_content">
    <div id="padding" class="div_spacingcrm">
        <div align="left" style="width: 100%;">
            <span style="float: right; color: red">*
                Fields are mandatory</span>
        </div>
        <div style="clear: both">
        </div>
        <div align="left" style="width: 100%;">
            <div id="leftcol" style="width: 49%;">
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lblcomptype" class="normaltext">Company Type</span>
                    </div>
                    <div class="box">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lblCompanyType" class="graytext">Customer</span>
                        &nbsp;&nbsp;
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyname" class="normaltext">Company Name</span>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_companyname" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_companyname" class="textboxnew" onkeypress="javascript:return SaveFocValForMondatoryFld(event);" style="width:75%;" />
                        <span id="spn_companyname" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            Please enter company name</span>
                        
                    </div>
                    
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyalias" class="normaltext">Company Alias</span>
                        <span style="color: red">*</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_companyalias" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_companyalias" class="textboxnew" onfocus="javascript:GetClientAlias()" style="width:75%;" />
                        <span id="spn_companyalias" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">
                            Please enter Company Alias
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_type" class="normaltext">Type</span>
                    </div>
                    <div class="box">
                        
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type" class="RadComboBox RadComboBox_Default" ClientDropDownClosing="onDropDownClosing" style="width:75%;white-space:normal;">
	<table summary="combobox" style="border-width:0;border-collapse:collapse;width:100%">
		<tr>
			<td style="width:100%;" class="rcbInputCell rcbInputCellLeft"><input name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type" type="text" class="rcbInput rcbEmptyMessage" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_Input" value=" None" tabindex="2" /></td>
			<td class="rcbArrowCell rcbArrowCellRight"><a id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_Arrow" style="overflow: hidden;display: block;position: relative;outline: none;">select</a></td>
		</tr>
	</table>
	<div class="rcbSlide" style="z-index:6000;"><div id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_DropDown" class="RadComboBoxDropDown RadComboBoxDropDown_Default " style="display:none;"><div class="rcbScroll rcbWidth rcbNoWrap" style="width:100%;"><ul class="rcbList" style="list-style:none;margin:0;padding:0;zoom:1;"><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i0_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i0$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i0_chk1">Care Home Provider</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i1_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i1$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i1_chk1">Couriers</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i2_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i2$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i2_chk1">Distribution and logistics</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i3_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i3$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i3_chk1">Graphic design</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i4_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i4$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i4_chk1">Manufacturing</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i5_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i5$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i5_chk1">Offset printer</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i6_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i6$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i6_chk1">Paper and consumables</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i7_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i7$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i7_chk1">Retail</label>
                                </div>
                            </li><li class="rcbItem  rcbTemplate">
                                <div onclick="StopPropagation(event)">
                                    <input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i8_chk1" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_type$i8$chk1" onclick="onCheckBoxClick(this);" /><label for="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_i8_chk1">University</label>
                                </div>
                            </li></ul></div></div></div><input id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_ClientState" name="ctl00_ContentPlaceHolder1_ClientAddID_ddl_type_ClientState" type="hidden" />
</div>
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Carrier" align="left" style="display:none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lblcarrier" class="normaltext">Carrier</span>
                    </div>
                    <div class="box">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chkcarrier" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chkcarrier" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_status" class="normaltext">Account Status</span>
                    </div>
                    <div class="box">
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_status" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_status" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option value="107">Account on Hold</option>
	<option selected="selected" value="106">Accounts Clear</option>
	<option value="557">COD</option>
	<option value="108">Pro Forma Account</option>

</select>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_account" class="normaltext">Account Number</span>
                        
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_accountno" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_accountno" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        
                        <span id="spn_account" style="display: none; width: 170px" class="spanerrorMsg">
                            Please enter Account No
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_email" class="normaltext">Business Email</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_email" type="text" maxlength="150" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_email" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_emailValue" style="margin: 5px 0px 0px 2px; display: none;"></span>
                        
                        <span id="spn_Email" style="display: none; width: 233px" class="spanerrorMsg">
                            Please enter valid Email Address
                        </span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_url" class="normaltext">URL</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_url" type="text" maxlength="300" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_url" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_urlValue" style="margin: 5px 0px 0px 2px; display: none;"></span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_defaultinv" class="normaltext">Default Invoice Address</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chk_defaultinvoiceaddress" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chk_defaultinvoiceaddress" />
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddress1" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_defaultdel" class="normaltext">Default Delivery Address</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_chk_defaultdeliveryaddress" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$chk_defaultdeliveryaddress" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_credit" class="normaltext">Credit Limit</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_creditlimit" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_creditlimit" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_creditref" class="normaltext">Credit Reference</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_creditref" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_creditref" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_tax1" class="normaltext">Tax</span>
                    </div>
                    <div class="box">
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_tax1" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_tax1" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option value="1948">5 %</option>
	<option value="1939">BTW</option>
	<option selected="selected" value="243">GST</option>
	<option value="1949">UK VAT</option>
	<option value="1941">VAT</option>
	<option value="1942">VAT 0%</option>
	<option value="1937">VAT 23%</option>
	<option value="1940">Zero Rated</option>

</select>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Tax2" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_tax2" class="normaltext">Tax2</span>
                    </div>
                    <div class="box">
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_tax2" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_tax2" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option value="1948">5 %</option>
	<option value="1939">BTW</option>
	<option value="243">GST</option>
	<option value="1949">UK VAT</option>
	<option value="1941">VAT</option>
	<option value="1942">VAT 0%</option>
	<option value="1937">VAT 23%</option>
	<option value="1940">Zero Rated</option>

</select>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddressView" style="display: none;">
                    <div id="div_DeliveryAddressHeader" style="display: block; float: left;" class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryAddress">Delivery Address</span>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverycountryValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryphoneValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryfaxValue"></span>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <a onclick="javascript:opencontacts('deliveryaddress','edit');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryEdit" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_DeliveryEdit','')">Edit</a>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverySpliter">| </span>
                            </div>
                            <div style="float: left;">
                                <a onclick="javascript:opencontacts('deliveryaddress','change');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryChange" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_DeliveryChange','')">Change/New Address</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_InvoiceAddressView" style="display: none;">
                    <div id="div_InvoiceAddressHeader" style="display: block; float: left;" class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoiceAddress">Invoice Address</span>
                    </div>
                    <div style="float: left; padding-left: 5px;">
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr1Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr2Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr3Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr4Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr5Value"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicecountryValue"></span>
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicephoneValue"></span>
                        </div>
                        <div class="only5px">
                        </div>
                        <div class="only5px">
                        </div>
                        <div style="margin: 5px 0px 0px 0px;">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicefaxValue"></span>
                        </div>
                        <div style="padding: 8px 5px 5px 0px;">
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <a onclick="javascript:opencontacts('invoiceaddress','edit');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceEdit" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_InvoiceEdit','')">Edit</a>
                            </div>
                            <div style="float: left; padding: 0px 2px 0px 0px">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoiceSpliter">| </span>
                            </div>
                            <div style="float: left;">
                                <a onclick="javascript:opencontacts('invoiceaddress','change');return false;" id="ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceChange" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$ClientAddID$lnk_InvoiceChange','')">Change/New Address</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="rightcol" style="width: 49%;">
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_terms" class="normaltext">Payment Terms</span>
                    </div>
                    <div class="box">
                        
                        
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_PaymentTerms" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_PaymentTerms" class="normaltext" onchange="Javascript:GetDays();return false;" style="width:75%;">
	<option value="0">None</option>
	<option value="2">30 Days</option>
	<option selected="selected" value="4">30 Days</option>
	<option value="3">Immediate</option>

</select>
                        <input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_PaymentTerm" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_PaymentTerm" value="0‡2»30‡4»0‡3»" />
                        <input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_PaymenttermID" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_PaymenttermID" value="0" />
                        
                        
                        
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_profit" class="normaltext">Profit Margin</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_profitmargin" type="text" maxlength="8" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_profitmargin" class="textboxnew" onkeypress="javascript:return onlyNumbers(event);" onblur="javascript:todecimal_function(this,this.value);" style="width:20%;text-align: right" />
                        
                        <span>%</span>
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_taxno" class="normaltext">Tax Reg No</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_taxregno" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_taxregno" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_companyno" class="normaltext">Company Number</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_companyno" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_companyno" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_acopened" class="normaltext">A/C Opened</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_acopened" type="text" value="22/03/2016" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_acopened" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" onClick="javascript: event.cancelBubble = true; this.select(); lcs(this, 'dd/mm/yyyy');" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_code" class="normaltext">Bank Code</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_bankcode" type="text" maxlength="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_bankcode" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_bankacno" class="normaltext">Bank Account Number</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_bankacno" type="text" maxlength="200" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_bankacno" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_acname" class="normaltext">Account Name</span>
                    </div>
                    <div class="box">
                        <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_accountname" type="text" maxlength="150" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_accountname" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label15" class="normaltext">Sales Person</span>
                    </div>
                    <div class="box">
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_salesperson" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_salesperson" class="normaltext" style="width:75%;">
	<option value="-1">None</option>
	<option value="3812">Clare Aindow</option>
	<option value="3815">Jim Houghton</option>
	<option value="1973">Support Team</option>

</select>
                    </div>
                </div>
                <div id="Div_Referencedby" align="left">
                    <div class="bglabel">
                        <div style="float: left">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby">Referred By</span>
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_DivImgRefferedByAdd" style="float: right">
                            <input type="image" name="ctl00$ContentPlaceHolder1$ClientAddID$ImgRefferedByAdd" id="ctl00_ContentPlaceHolder1_ClientAddID_ImgRefferedByAdd" title="Add New" src="../images/plus.gif" onclick="javascript: OpenNewReffered(); return false;" style="border-width:0px;vertical-align: middle" />
                        </div>
                    </div>
                    <div class="box">
                        
                        <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_Referencedby" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby" class="normaltext" style="width:75%;">
	<option value="0">None</option>
	<option selected="selected" value="26">Angela</option>
	<option value="22">BNI</option>
	<option value="24">Carolyn</option>
	<option value="21">Csaba Mar&#225;cz</option>
	<option value="23">Example</option>
	<option value="25">House A/C</option>
	<option value="20">John Smith</option>

</select>
                        <span id="spn_Referencedby" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                            class="spanerrorMsg">This is a required field</span>
                        <input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_Referencedby" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_Referencedby" />
                        <div id="divCheck" onmouseover="ShowName('divCheck');" onmouseout="NotShowName('divCheck');">
                        </div>
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Supplier" align="left" style="display:none;">
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label2" class="normaltext">Tax Number</span>
                        </div>
                        <div class="box">
                            <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_taxnumber" type="text" maxlength="200" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_taxnumber" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div align="left">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label3" class="normaltext">Balance</span>
                        </div>
                        <div class="box">
                            <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_balance" type="text" maxlength="200" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_balance" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                        </div>
                    </div>
                    
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_create_identical_contact" align="left">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label4" class="normaltext">Create Identical Contact</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_Chkcreate_identical_contact" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$Chkcreate_identical_contact" />
                    </div>
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_DivChkRoyalityFree" align="left" style="display: none;">
                    <div class="bglabel">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label5" class="normaltext">Royality Free</span>
                    </div>
                    <div class="ddlsetting" style="padding-left: 2px">
                        <input id="ctl00_ContentPlaceHolder1_ClientAddID_ChkRoyalityFree" type="checkbox" name="ctl00$ContentPlaceHolder1$ClientAddID$ChkRoyalityFree" />
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <div style="clear: both">
            </div>
            <div style="width: 100%; margin: 0px 0px 0px 0px;">
                <div style="width: 50%; margin: 15px 0px 5px 0px;">
                    <div style="padding-left: 5px;">
                        <span id="ctl00_ContentPlaceHolder1_ClientAddID_AddressHeader" class="headerText">Address</span>
                    </div>
                </div>
                <div id="div_CompanyAddressAdd" style="float: left; width: 100%;">
                    <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddress" style="float: left; width: 49%; display: block;">
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1" class="normaltext">Street 1</span>
                                
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryaddr1" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr1" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                
                                <span id="spn_addr1" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 1</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2" class="normaltext">Street 2</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryaddr2" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr2" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                <span id="spn_addr2" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 2</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3" class="normaltext">City</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryaddr3" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr3" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                <span id="spn_addr3" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 3</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4" class="normaltext">State</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryaddr4" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr4" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                <span id="spn_addr4" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 4</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div align="left">
                            <div class="bglabel">
                                
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5" class="normaltext">Postcode</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryaddr5" type="text" maxlength="250" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr5" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                <span id="spn_addr5" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">
                                    Please enter address line 5</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliverycountry" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliverycountry" class="normaltext">Country</span>
                            </div>
                            <div class="box">
                                <select name="ctl00$ContentPlaceHolder1$ClientAddID$ddl_Deliverycountry" id="ctl00_ContentPlaceHolder1_ClientAddID_ddl_Deliverycountry" class="normaltext" style="width:75%;">
	<option value="0">--- Select ---</option>
	<option value="1">Afghanistan</option>
	<option value="2">Albania</option>
	<option value="3">Algeria</option>
	<option value="4">American Samoa</option>
	<option value="5">Andorra</option>
	<option value="6">Angola</option>
	<option value="7">Anguilla</option>
	<option value="8">Antarctica</option>
	<option value="9">Antigua And Barbuda</option>
	<option value="10">Argentina</option>
	<option value="11">Armenia</option>
	<option value="12">Aruba</option>
	<option value="13">Australia</option>
	<option value="14">Austria</option>
	<option value="15">Azerbaijan</option>
	<option value="16">Bahamas</option>
	<option value="17">Bahrain</option>
	<option value="18">Bangladesh</option>
	<option value="19">Barbados</option>
	<option value="20">Belarus</option>
	<option value="21">Belgium</option>
	<option value="22">Belize</option>
	<option value="23">Benin</option>
	<option value="24">Bermuda</option>
	<option value="25">Bhutan</option>
	<option value="26">Bolivia</option>
	<option value="27">Bosnia and Herzegovina</option>
	<option value="28">Botswana</option>
	<option value="29">Bouvet Island</option>
	<option value="30">Brazil</option>
	<option value="31">British Indian Ocean Territory</option>
	<option value="32">Brunei</option>
	<option value="33">Bulgaria</option>
	<option value="34">Burkina Faso</option>
	<option value="35">Burundi</option>
	<option value="36">Cambodia</option>
	<option value="37">Cameroon</option>
	<option value="38">Canada</option>
	<option value="39">Cape Verde</option>
	<option value="40">Cayman Islands</option>
	<option value="41">Central African Republic</option>
	<option value="42">Chad</option>
	<option value="43">Chile</option>
	<option value="44">China</option>
	<option value="45">China (Hong Kong S.A.R.)</option>
	<option value="46">China (Macau S.A.R.)</option>
	<option value="47">Christmas Island</option>
	<option value="48">Cocos (Keeling) Islands</option>
	<option value="49">Colombia</option>
	<option value="50">Comoros</option>
	<option value="51">Congo</option>
	<option value="52">Cook Islands</option>
	<option value="53">Costa Rica</option>
	<option value="54">Cote D`Ivoire (Ivory Coast)</option>
	<option value="55">Croatia</option>
	<option value="56">Cuba</option>
	<option value="57">Cyprus</option>
	<option value="58">Czech Republic</option>
	<option value="59">Denmark</option>
	<option value="60">Djibouti</option>
	<option value="61">Dominica</option>
	<option value="62">Dominican Republic</option>
	<option value="63">East Timor</option>
	<option value="64">Ecuador</option>
	<option value="65">Egypt</option>
	<option value="66">El Salvador</option>
	<option value="67">Equatorial Guinea</option>
	<option value="68">Eritrea</option>
	<option value="69">Estonia</option>
	<option value="70">Ethiopia</option>
	<option value="71">Falkland Islands (Islas Malvinas)</option>
	<option value="72">Faroe Islands</option>
	<option value="73">Fiji Islands</option>
	<option value="74">Finland</option>
	<option value="75">France</option>
	<option value="76">French Guiana</option>
	<option value="77">French Polynesia</option>
	<option value="78">French Southern Territories</option>
	<option value="79">Gabon</option>
	<option value="80">Gambia</option>
	<option value="81">Georgia</option>
	<option value="82">Germany</option>
	<option value="83">Ghana</option>
	<option value="84">Gibraltar</option>
	<option value="85">Greece</option>
	<option value="86">Greenland</option>
	<option value="87">Grenada</option>
	<option value="88">Guadeloupe</option>
	<option value="89">Guam</option>
	<option value="90">Guatemala</option>
	<option value="91">Guinea</option>
	<option value="92">Guinea-Bissau</option>
	<option value="93">Guyana</option>
	<option value="94">Haiti</option>
	<option value="95">Heard and McDonald Islands</option>
	<option value="96">Honduras</option>
	<option value="97">Hungary</option>
	<option value="98">Iceland</option>
	<option value="99">India</option>
	<option value="100">Indonesia</option>
	<option value="101">Iran</option>
	<option value="102">Iraq</option>
	<option value="103">Ireland</option>
	<option value="104">Israel</option>
	<option value="105">Italy</option>
	<option value="106">Jamaica</option>
	<option value="107">Japan</option>
	<option value="108">Jordan</option>
	<option value="109">Kazakhstan</option>
	<option value="110">Kenya</option>
	<option value="111">Kiribati</option>
	<option value="112">Korea-North</option>
	<option value="113">Korea-South</option>
	<option value="114">Kuwait</option>
	<option value="115">Kyrgyzstan</option>
	<option value="116">Laos</option>
	<option value="117">Latvia</option>
	<option value="118">Lebanon</option>
	<option value="119">Lesotho</option>
	<option value="120">Liberia</option>
	<option value="121">Libya</option>
	<option value="122">Liechtenstein</option>
	<option value="123">Lithuania</option>
	<option value="124">Luxembourg</option>
	<option value="125">Macedonia</option>
	<option value="126">Madagascar</option>
	<option value="127">Malawi</option>
	<option value="128">Malaysia</option>
	<option value="129">Maldives</option>
	<option value="130">Mali</option>
	<option value="131">Malta</option>
	<option value="132">Marshall Islands</option>
	<option value="133">Martinique</option>
	<option value="134">Mauritania</option>
	<option value="135">Mauritius</option>
	<option value="136">Mayotte</option>
	<option value="137">Mexico</option>
	<option value="138">Micronesia</option>
	<option value="139">Moldova</option>
	<option value="140">Monaco</option>
	<option value="141">Mongolia</option>
	<option value="142">Montserrat</option>
	<option value="143">Morocco</option>
	<option value="144">Mozambique</option>
	<option value="145">Myanmar</option>
	<option value="146">Namibia</option>
	<option value="147">Nauru</option>
	<option value="148">Nepal</option>
	<option value="150">Netherlands</option>
	<option value="149">Netherlands Antilles</option>
	<option value="151">New Caledonia</option>
	<option value="152">New Zealand</option>
	<option value="153">Nicaragua</option>
	<option value="154">Niger</option>
	<option value="155">Nigeria</option>
	<option value="156">Niue</option>
	<option value="157">Norfolk Island</option>
	<option value="158">Northern Mariana Islands</option>
	<option value="159">Norway</option>
	<option value="160">Oman</option>
	<option value="161">Pakistan</option>
	<option value="162">Palau</option>
	<option value="163">Panama</option>
	<option value="164">Papua New Guinea</option>
	<option value="165">Paraguay</option>
	<option value="166">Peru</option>
	<option value="167">Philippines</option>
	<option value="168">Pitcairn Island</option>
	<option value="169">Poland</option>
	<option value="170">Portugal</option>
	<option value="171">Puerto Rico</option>
	<option value="172">Qatar</option>
	<option value="173">Reunion</option>
	<option value="174">Romania</option>
	<option value="175">Russia</option>
	<option value="176">Rwanda</option>
	<option value="177">Saint Helena</option>
	<option value="178">Saint Kitts And Nevis</option>
	<option value="179">Saint Lucia</option>
	<option value="180">Saint Pierre and Miquelon</option>
	<option value="181">Saint Vincent And The Grenadines</option>
	<option value="182">Samoa</option>
	<option value="183">San Marino</option>
	<option value="184">Sao Tome and Principe</option>
	<option value="185">Saudi Arabia</option>
	<option value="186">Senegal</option>
	<option value="187">Seychelles</option>
	<option value="188">Sierra Leone</option>
	<option value="189">Singapore</option>
	<option value="190">Slovakia</option>
	<option value="191">Slovenia</option>
	<option value="192">Solomon Islands</option>
	<option value="193">Somalia</option>
	<option value="194">South Africa</option>
	<option value="195">South Georgia And The South Sandwich Islands</option>
	<option value="196">Spain</option>
	<option value="197">Sri Lanka</option>
	<option value="198">Sudan</option>
	<option value="199">Suriname</option>
	<option value="200">Svalbard And Jan Mayen Islands</option>
	<option value="201">Swaziland</option>
	<option value="202">Sweden</option>
	<option value="203">Switzerland</option>
	<option value="204">Syria</option>
	<option value="205">Taiwan</option>
	<option value="206">Tajikistan</option>
	<option value="207">Tanzania</option>
	<option value="208">Thailand</option>
	<option value="209">Togo</option>
	<option value="210">Tokelau</option>
	<option value="211">Tonga</option>
	<option value="212">Trinidad And Tobago</option>
	<option value="213">Tunisia</option>
	<option value="214">Turkey</option>
	<option value="215">Turkmenistan</option>
	<option value="216">Turks And Caicos Islands</option>
	<option value="217">Tuvalu</option>
	<option value="218">Uganda</option>
	<option value="219">Ukraine</option>
	<option value="220">United Arab Emirates</option>
	<option selected="selected" value="221">United Kingdom</option>
	<option value="222">United States</option>
	<option value="223">United States Minor Outlying Islands</option>
	<option value="224">Uruguay</option>
	<option value="225">Uzbekistan</option>
	<option value="226">Vanuatu</option>
	<option value="227">Vatican City State (Holy See)</option>
	<option value="228">Venezuela</option>
	<option value="229">Vietnam</option>
	<option value="230">Virgin Islands (British)</option>
	<option value="231">Virgin Islands (US)</option>
	<option value="232">Wallis And Futuna Islands</option>
	<option value="233">Western Sahara</option>
	<option value="234">Yemen</option>
	<option value="235">Yugoslavia</option>
	<option value="236">Zambia</option>
	<option value="237">Zimbabwe</option>

</select>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliveryphone" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone" class="normaltext">Telephone</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryphone" type="text" maxlength="100" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryphone" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                                <span id="spn_Deliveryphone" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                    class="spanerrorMsg">This is a required field</span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_divDeliveryfax" align="left">
                            <div class="bglabel">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryfax" class="normaltext" MaxLength="100">Fax</span>
                            </div>
                            <div class="box">
                                <input name="ctl00$ContentPlaceHolder1$ClientAddID$txt_Deliveryfax" type="text" maxlength="100" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryfax" class="textboxnew" onkeypress="javascript:return SavefocusWithValidation(event);" style="width:75%;" />
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                        <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_edit_changeDelivery" align="left" style="display: none;">
                            <div class="bglabel" style="background-color: White;">
                                <span id="ctl00_ContentPlaceHolder1_ClientAddID_Label1" class="normaltext"></span>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div id="ctl00_ContentPlaceHolder1_ClientAddID_div_Description" style="float: right; width: 49%; padding: 0px 0px 0px 0px;">
                        <div class="bglabel">
                            <span id="ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc" class="normaltext">Description</span>&nbsp;
                        </div>
                        <div class="box">
                            <textarea name="ctl00$ContentPlaceHolder1$ClientAddID$txt_description" rows="2" cols="20" id="ctl00_ContentPlaceHolder1_ClientAddID_txt_description" class="textboxnew" style="height:155px;width:100%;"></textarea>
                            <span id="spn_description" style="display: none; width: auto; padding-left: 4px; padding-right: 4px"
                                class="spanerrorMsg">This is a required field</span>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="only5px">
        </div>
        <div align="left" style="width: 100%;">
            <div style="float: left; width: 66%">
                &nbsp;
            </div>
            <div style="float: left;">
                <div id="div_btnCancel" style="float: left">
                    <div id="div_btncnl" style="display: block">
                        <input type="submit" name="ctl00$ContentPlaceHolder1$ClientAddID$btncancel" value="Cancel" onclick="javascript: loadingimage(this.id, 'div_btncancelprocess');" id="ctl00_ContentPlaceHolder1_ClientAddID_btncancel" tabindex="1" class="button" />
                    </div>
                    <div id="div_btncancelprocess" style="display: none">
                        <img src="https://demo.eprintsoftware.com/images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;
                </div>
                <div id="ctl00_ContentPlaceHolder1_ClientAddID_Divdiv_btnsave" style="float: left">
                    <div id="div_btnsave" style="display: block">
                        <input type="submit" name="ctl00$ContentPlaceHolder1$ClientAddID$btnsave" value="Save" onclick="javascript: EmailValidate(); var b = Validate(); if (b) loadingimage(this.id, 'div_btnsaveprocess'); return b;" id="ctl00_ContentPlaceHolder1_ClientAddID_btnsave" class="button" />
                    </div>
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="https://demo.eprintsoftware.com/images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
<div style="float: left; width: 700px; margin-top: -8px;">
    &nbsp;
</div>
<div id="divrad" style="display: none; position: absolute; vertical-align: middle; border: 0px solid; z-index: 100; width: 50%"
    align="center">
    <div id="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1" style="z-index:31000;display:none;">
	<div id="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1_alerttemplate" style="display:none;">
		<div class="rwDialogPopup radalert">			
			<div class="rwDialogText">
			{1}				
			</div>
			
			<div>
				<a  onclick="$find('{0}').close();"
				class="rwPopupButton" href="javascript:void(0);">
					<span class="rwOuterSpan">
						<span class="rwInnerSpan">##LOC[OK]##</span>
					</span>
				</a>				
			</div>
		</div>
		</div><div id="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1_prompttemplate" style="display:none;">
		 <div class="rwDialogPopup radprompt">			
			    <div class="rwDialogText">
			    {1}				
			    </div>		
			    <div>
				    <script type="text/javascript">
				        function RadWindowprompt_detectenter(id, ev, input) {
				            if (!ev) ev = window.event;
				            if (ev.keyCode == 13) {
				                var but = input.parentNode.parentNode.getElementsByTagName("A")[0];
				                if (but) {
				                    if (but.click) but.click();
				                    else if (but.onclick) {
				                        but.focus(); var click = but.onclick; but.onclick = null; if (click) click.call(but);
				                    }
				                }
				                return false;
				            }
				            else return true;
				        }
				    </script>
				    <input title="Eneter Value" onkeydown="return RadWindowprompt_detectenter('{0}', event, this);" type="text"  class="rwDialogInput" value="{2}" />
			    </div>
			    <div>
				    <a onclick="$find('{0}').close(this.parentNode.parentNode.getElementsByTagName('input')[0].value);"				
					    class="rwPopupButton" href="javascript:void(0);" ><span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[OK]##</span></span></a>
				    <a onclick="$find('{0}').close(null);" class="rwPopupButton"  href="javascript:void(0);"><span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[Cancel]##</span></span></a>
			    </div>
		    </div>				       
		</div><div id="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1_confirmtemplate" style="display:none;">
		<div class="rwDialogPopup radconfirm">			
			<div class="rwDialogText">
			{1}				
			</div>						
			<div>
				<a onclick="$find('{0}').close(true);"  class="rwPopupButton" href="javascript:void(0);" ><span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[OK]##</span></span></a>
				<a onclick="$find('{0}').close(false);" class="rwPopupButton"  href="javascript:void(0);"><span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[Cancel]##</span></span></a>
			</div>
		</div>		
		</div><input id="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1_ClientState" name="ctl00_ContentPlaceHolder1_ClientAddID_RadWindowManager1_ClientState" type="hidden" />
</div>
</div>
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hid_ClientID" id="ctl00_ContentPlaceHolder1_ClientAddID_hid_ClientID" value="0" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_DeliveryaddressID" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_DeliveryaddressID" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_InvoiceaddressID" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_InvoiceaddressID" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_companytype" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_companytype" value="customer" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_selectedcounter" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_selectedcounter" value="221" />
<script type="text/javascript">
    var currentdate = '';
    var DeliveryAddressID = '0';

    var txt_companyname = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_companyname");
    var txt_companyalias = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_companyalias");
    var txt_accountno = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_accountno");
    var txt_Deliveryaddr1 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr1");
    var txt_Deliveryaddr2 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr2");
    var txt_Deliveryaddr3 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr3");
    var txt_Deliveryaddr4 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr4");
    var txt_Deliveryaddr5 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryaddr5");
    var txt_description = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_description");
    var txt_Deliveryphone = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Deliveryphone");
    var txt_email = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_email")
    var ddl_Referencedby = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby");
    var hdn_companytype = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_companytype").value;
    var hid_ClientID = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hid_ClientID");
    var rdProspect = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_rdProspect");
    var rdCustomer = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_rdCustomer");
    var action = "";
    var lbl_Deliveryaddr1 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1");
    var lbl_Deliveryaddr2 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2");
    var lbl_Deliveryaddr3 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3");
    var lbl_Deliveryaddr4 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4");
    var lbl_Deliveryaddr5 = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5");


    var lbl_Deliveryaddr1Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1Value");
    var lbl_Deliveryaddr2Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2Value");
    var lbl_Deliveryaddr3Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3Value");
    var lbl_Deliveryaddr4Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4Value");
    var lbl_Deliveryaddr5Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5Value");
    var lbl_DeliverycountryValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverycountryValue");
    var lbl_DeliveryphoneValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryphoneValue");
    var lbl_DeliveryfaxValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliveryfaxValue");
    var lbl_emailValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_emailValue");
    var lbl_urlValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_urlValue");
    var div_DeliveryAddress = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddress");
    var div_DeliveryAddressView = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_div_DeliveryAddressView");
    var lnk_DeliveryEdit = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryEdit");
    var lbl_DeliverySpliter = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_DeliverySpliter");
    var lnk_DeliveryChange = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lnk_DeliveryChange");
    var hdn_DeliveryaddressID = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_DeliveryaddressID");
    var systemname = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdnsystemname").value;

    var lbl_Invoiceaddr1Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr1Value");
    var lbl_Invoiceaddr2Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr2Value");
    var lbl_Invoiceaddr3Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr3Value");
    var lbl_Invoiceaddr4Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr4Value");
    var lbl_Invoiceaddr5Value = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_Invoiceaddr5Value");
    var lbl_InvoicecountryValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicecountryValue");
    var lbl_InvoicephoneValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicephoneValue");
    var lbl_InvoicefaxValue = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoicefaxValue");
    var div_InvoiceAddressView = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_div_InvoiceAddressView");
    var lnk_InvoiceEdit = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceEdit");
    var lbl_InvoiceSpliter = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_InvoiceSpliter");
    var lnk_InvoiceChange = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lnk_InvoiceChange");
    var hdn_InvoiceaddressID = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_InvoiceaddressID");
    var strisreqAdd = '';
    var RequiredAddressCustomer = ''

    function GetClientAlias() {
        txt_companyalias.value = txt_companyname.value.replace(' ', '');
    }
    function removespace() {
        //txt_companyname.value = txt_companyname.value.replace(/^\s+/, '');
    }

    if (rdProspect == null) {
        rdProspect = false;
    }
    var CheckFinal = 0;
    function Validate() {

        CheckFinal = 0;


        var RequiredAddress = 0;
        var ClientID = '0';
        if (txt_companyname.value.trim() == "") {
            document.getElementById("spn_companyname").style.display = "block";
            txt_companyname.focus();
            CheckFinal = 1;
        }
        else {
            document.getElementById("spn_companyname").style.display = "none";
            CheckFinal = 0;
        }

        if (strisreqAdd != '') {
            var isreqAdd = strisreqAdd.split(',')
            for (var i = 0; i < isreqAdd.length; i++) {
                if (isreqAdd[i] == '1') {
                    if (txt_Deliveryaddr1.value.trim() == '') {
                        document.getElementById('spn_addr1').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr1').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '2') {
                    if (txt_Deliveryaddr2.value.trim() == '') {
                        document.getElementById('spn_addr2').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr2').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '3') {
                    if (txt_Deliveryaddr3.value.trim() == '') {
                        document.getElementById('spn_addr3').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr3').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '4') {
                    if (txt_Deliveryaddr4.value.trim() == '') {
                        document.getElementById('spn_addr4').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr4').style.display = "none";
                    }
                }
                if (isreqAdd[i] == '5') {
                    if (txt_Deliveryaddr5.value.trim() == '') {
                        document.getElementById('spn_addr5').style.display = "block";
                        RequiredAddress = 1;
                    }
                    else {
                        document.getElementById('spn_addr5').style.display = "none";
                    }
                }
            }
        }

        //For only fsg system. systemname == "fsg" &&   && systemname == "fsg" && action=="" && action==""
        if ((systemname == "fsg" && hdn_companytype == "prospect" && action == "") || (rdProspect.checked == true && systemname == "fsg" && action == "")) {


            if (txt_Deliveryaddr1.value.trim() == '') {
                document.getElementById('spn_addr1').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr1').style.display = "none";
            }

            //if (txt_Deliveryaddr2.value.trim() == '') {
            //    document.getElementById('spn_addr2').style.display = "block";
            //    CheckFinal = 1;
            //}
            //else {
            //    document.getElementById('spn_addr2').style.display = "none";
            //}

            if (txt_Deliveryaddr3.value.trim() == '') {
                document.getElementById('spn_addr3').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr3').style.display = "none";
            }

            if (txt_Deliveryaddr4.value.trim() == '') {
                document.getElementById('spn_addr4').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr4').style.display = "none";
            }

            if (txt_Deliveryaddr5.value.trim() == '') {
                document.getElementById('spn_addr5').style.display = "block";
                CheckFinal = 1;
            }
            else {
                document.getElementById('spn_addr5').style.display = "none";
            }

            if (txt_Deliveryphone.value.trim() == "") {
                document.getElementById("spn_Deliveryphone").style.display = "block";
                txt_Deliveryphone.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Deliveryphone").style.display = "none";
            }

            if (ddl_Referencedby.value == "0") {
                document.getElementById("spn_Referencedby").style.display = "block";
                ddl_Referencedby.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Referencedby").style.display = "none";
            }

            if (txt_description.value == "" || txt_description.value.trim() == "") {
                document.getElementById("spn_description").style.display = "block";
                txt_description.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_description").style.display = "none";
                txt_description.focus();
            }
        }//ends here

        if ((systemname == "fsg" && hdn_companytype == "prospect") && action == "edit") {

            if (txt_description.value == "" || txt_description.value.trim() == "") {
                document.getElementById("spn_description").style.display = "block";
                txt_description.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_description").style.display = "none";
                txt_description.focus();
            }

            if (ddl_Referencedby.value == "0") {
                document.getElementById("spn_Referencedby").style.display = "block";
                ddl_Referencedby.focus();
                CheckFinal = 1;
            }
            else {
                document.getElementById("spn_Referencedby").style.display = "none";
            }
        }


        //    //if (ClientID != 0) {
        //    //    if (CheckFinal == 1) {
        //    //        return false;
        //    //    }
        //    //    else {
        //    //        return true;
        //    //    }
        //    //    }
        //    //else {
        //        if (RequiredAddress == 1 || CheckFinal == 1) {
        //            return false;
        //        }
        //    else {
        //            return true;
        //    }
        ////}

        //if (ClientID != 0) {
        //    if (CheckFinal == 1) {
        //        return false;
        //    }
        //    else {
        //        return true;
        //    }
        //}
        //else {
        if (hdn_companytype != "customer" && action == "edit" && RequiredAddress == 1) {
            if (txt_companyname.value.trim() == "") {
                document.getElementById("spn_companyname").style.display = "block";
                txt_companyname.focus();
                CheckFinal = 1;

            }
            else {
                document.getElementById("spn_companyname").style.display = "none";
                //CheckFinal = 0;
                return true;
            }

        }
        if (RequiredAddress == 1 || CheckFinal == 1) {
            return false;
        }
        else {
            return true;
        }
        //}

    }

    function customerrdbclick() {

        //systemname == "fsg" &&
        if (systemname == "fsg" && rdCustomer.checked == true) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc').innerHTML = 'Description';
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone').innerHTML = 'Telephone';
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby').innerHTML = 'Referred By';

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.replace('*', '').trim();

            //var RequiredAddressCustomer = '';
            if (RequiredAddressCustomer != '') {
                var RequiredAddressCustomer1 = RequiredAddressCustomer.split(',')
                for (var i = 0; i < RequiredAddressCustomer1.length; i++) {
                    if (RequiredAddressCustomer1[i] == '1') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "1,";
                    }
                    if (RequiredAddressCustomer1[i] == '2') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "2,";
                    }
                    if (RequiredAddressCustomer1[i] == '3') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "3,";
                    }
                    if (RequiredAddressCustomer1[i] == '4') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "4,";
                    }
                    if (RequiredAddressCustomer1[i] == '5') {
                        document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
                        strisreqAdd = strisreqAdd + "1,";
                    }
                }
            }
            document.getElementById("spn_companyname").style.display = "none";
            document.getElementById("spn_description").style.display = "none";
            document.getElementById("spn_Deliveryphone").style.display = "none";
            document.getElementById("spn_Referencedby").style.display = "none";
            document.getElementById('spn_addr5').style.display = "none";
            document.getElementById('spn_addr4').style.display = "none";
            document.getElementById('spn_addr3').style.display = "none";
            document.getElementById('spn_addr2').style.display = "none";
            document.getElementById('spn_addr1').style.display = "none";
        }
        //systemname == "fsg" &&
        if (systemname == "fsg" && rdProspect.checked == true) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_desc').innerHTML = 'Description' + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryphone').innerHTML = 'Telephone' + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Referencedby').innerHTML = 'Referred By' + "<span style='color: red;'>&nbsp;*</span>";

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.replace('*', '').trim();
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.replace('*', '').trim();

            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr1').innerHTML = lbl_Deliveryaddr1.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            //document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr2').innerHTML = lbl_Deliveryaddr2.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr3').innerHTML = lbl_Deliveryaddr3.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr4').innerHTML = lbl_Deliveryaddr4.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_lbl_Deliveryaddr5').innerHTML = lbl_Deliveryaddr5.textContent.toString() + "<span style='color: red;'>&nbsp;*</span>";

            strisreqAdd = '';

            document.getElementById("spn_companyname").style.display = "none";
            document.getElementById("spn_description").style.display = "none";
            document.getElementById("spn_Deliveryphone").style.display = "none";
            document.getElementById("spn_Referencedby").style.display = "none";
            document.getElementById('spn_addr5').style.display = "none";
            document.getElementById('spn_addr4').style.display = "none";
            document.getElementById('spn_addr3').style.display = "none";
            document.getElementById('spn_addr2').style.display = "none";
            document.getElementById('spn_addr1').style.display = "none";
        }
    }

    // by natraj, calling Onblur.
    function EmailValidate() {

        var BusinessEmail = document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_txt_email').value;
        value = BusinessEmail
        var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (value.trim() != "") {
            if (!EmailExn.test(value)) {
                document.getElementById("spn_Email").style.display = "block";
                return false
            }
            else {
                document.getElementById("spn_Email").style.display = "none";
            }
        }
        else {
            document.getElementById("spn_Email").style.display = "none";
        }
    }

    function SendClientAddressIDandName(AddressID, AddLine1, City, State, ZipCode, Country, Phone, Fax, Email, AddressLine2, URL, AddressTo) {
        //alert(AddressID + ',' + AddLine1 + ',' + City + ',' + State + ',' + ZipCode + ',' + Country + ',' + Phone + ',' + Fax + ',' + Email);
        if (hdn_InvoiceaddressID.value == AddressID && hdn_InvoiceaddressID.value == AddressID) {
            AddressTo = 'both';
        }

        if (AddressTo == 'delivery') {
            hdn_DeliveryaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Deliveryaddr1Value.innerHTML = AddLine1;
            else
                lbl_Deliveryaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Deliveryaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Deliveryaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Deliveryaddr3Value.innerHTML = City;
            else
                lbl_Deliveryaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Deliveryaddr4Value.innerHTML = State;
            else
                lbl_Deliveryaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Deliveryaddr5Value.innerHTML = ZipCode;
            else
                lbl_Deliveryaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_DeliverycountryValue.innerHTML = Country;
            else
                lbl_DeliverycountryValue.innerHTML = '';

            if (Phone != '')
                lbl_DeliveryphoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_DeliveryphoneValue.innerHTML = '';

            if (Fax != '')
                lbl_DeliveryfaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_DeliveryfaxValue.innerHTML = '';

            lnk_DeliveryEdit.style.display = "block";
            lbl_DeliverySpliter.style.display = "block";
        }
        if (AddressTo == 'invoice') {
            hdn_InvoiceaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Invoiceaddr1Value.innerHTML = AddLine1;
            else
                lbl_Invoiceaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Invoiceaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Invoiceaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Invoiceaddr3Value.innerHTML = City;
            else
                lbl_Invoiceaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Invoiceaddr4Value.innerHTML = State;
            else
                lbl_Invoiceaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Invoiceaddr5Value.innerHTML = ZipCode;
            else
                lbl_Invoiceaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_InvoicecountryValue.innerHTML = Country;
            else
                lbl_InvoicecountryValue.innerHTML = '';

            if (Phone != '')
                lbl_InvoicephoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_InvoicephoneValue.innerHTML = '';

            if (Fax != '')
                lbl_InvoicefaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_InvoicefaxValue.innerHTML = '';

            lnk_InvoiceEdit.style.display = "block";
            lbl_InvoiceSpliter.style.display = "block";
        }
        if (AddressTo == 'both') {
            // DELIVERY
            hdn_DeliveryaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Deliveryaddr1Value.innerHTML = AddLine1;
            else
                lbl_Deliveryaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Deliveryaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Deliveryaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Deliveryaddr3Value.innerHTML = City;
            else
                lbl_Deliveryaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Deliveryaddr4Value.innerHTML = State;
            else
                lbl_Deliveryaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Deliveryaddr5Value.innerHTML = ZipCode;
            else
                lbl_Deliveryaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_DeliverycountryValue.innerHTML = Country;
            else
                lbl_DeliverycountryValue.innerHTML = '';

            if (Phone != '')
                lbl_DeliveryphoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_DeliveryphoneValue.innerHTML = '';

            if (Fax != '')
                lbl_DeliveryfaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_DeliveryfaxValue.innerHTML = '';

            lnk_DeliveryEdit.style.display = "block";
            lbl_DeliverySpliter.style.display = "block";

            // INVOICE
            hdn_InvoiceaddressID.value = AddressID;
            if (AddLine1 != '')
                lbl_Invoiceaddr1Value.innerHTML = AddLine1;
            else
                lbl_Invoiceaddr1Value.innerHTML = '';

            if (AddressLine2 != '')
                lbl_Invoiceaddr2Value.innerHTML = AddressLine2;
            else
                lbl_Invoiceaddr2Value.innerHTML = '';

            if (City != '')
                lbl_Invoiceaddr3Value.innerHTML = City;
            else
                lbl_Invoiceaddr3Value.innerHTML = '';

            if (State != '')
                lbl_Invoiceaddr4Value.innerHTML = State;
            else
                lbl_Invoiceaddr4Value.innerHTML = '';

            if (ZipCode != '')
                lbl_Invoiceaddr5Value.innerHTML = ZipCode;
            else
                lbl_Invoiceaddr5Value.innerHTML = '';

            if (Country != '')
                lbl_InvoicecountryValue.innerHTML = Country;
            else
                lbl_InvoicecountryValue.innerHTML = '';

            if (Phone != '')
                lbl_InvoicephoneValue.innerHTML = 'P: ' + Phone;
            else
                lbl_InvoicephoneValue.innerHTML = '';

            if (Fax != '')
                lbl_InvoicefaxValue.innerHTML = 'F: ' + Fax;
            else
                lbl_InvoicefaxValue.innerHTML = '';

            lnk_InvoiceEdit.style.display = "block";
            lbl_InvoiceSpliter.style.display = "block";
        }

    }

    function opencontacts(val, type) {
        if (val == 'deliveryaddress') {
            if (type == 'change') {
                window.radopen("https://demo.eprintsoftware.com/common/common_popup.aspx?type=moreaddress&clientid=0&mode=view&pg=client&pagename=clientchange&addressto=delivery", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'edit') {
                window.radopen("https://demo.eprintsoftware.com/common/common_popup.aspx?type=moreaddress&clientid=0&mode=edit&pg=client&addressid=" + hdn_DeliveryaddressID.value + "&pagename=clientedit&addressto=delivery", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        if (val == 'invoiceaddress') {
            if (type == 'change') {
                window.radopen("https://demo.eprintsoftware.com/common/common_popup.aspx?type=moreaddress&clientid=0&mode=view&pg=client&pagename=clientchange&addressto=invoice", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            if (type == 'edit') {
                window.radopen("https://demo.eprintsoftware.com/common/common_popup.aspx?type=moreaddress&clientid=0&mode=edit&pg=client&addressid=" + hdn_InvoiceaddressID.value + "&pagename=clientedit&addressto=invoice", '800', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
    }

    function onlyNumbers(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode != 43 && charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }

    function todecimal_function(txtobj) {
        var value = txtobj.value;
        if (!isNaN(txtobj.value) && Number(txtobj.value)) {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, txtobj.value, 0, '', false, false, false);
        }
        else {
            txtobj.value = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, 0, 0, '', false, false, false);
        }
        //alert(txtobj.value);
    }

    function RadWinClose() {
        //document.getElementById("ds00").style.display = "none";
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
</script>
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_ddlreferedbySel" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_ddlreferedbySel" />
<input type="hidden" name="ctl00$ContentPlaceHolder1$ClientAddID$hdn_ddlRefSelIndexOnEditLoad" id="ctl00_ContentPlaceHolder1_ClientAddID_hdn_ddlRefSelIndexOnEditLoad" value="0" />
<script>
    var ddl_Referencedby = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby");
    var hdn_ddlreferedbySel = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_ddlreferedbySel");
    var hdn_ddlRefSelIndexOnEditLoad = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_ddlRefSelIndexOnEditLoad");
    //    function GetddlSelValue(SelIndex) {
    //        if (SelIndex == "" || SelIndex == 0) {
    //            SelIndex = 0;
    //            ddl_Referencedby.options[SelIndex].text = "None";
    //        }
    //        else
    //            hdn_ddlreferedbySel.value = ddl_Referencedby.options[SelIndex].text;
    //    }
    // GetddlSelValue(hdn_ddlRefSelIndexOnEditLoad.value);

    //    function CallNames(ReferenceName) {
    //        //        AutoFill.ClientReferencedByName_Select(ReferenceName, Onsuccuss);
    //        AutoFill.ClientReferencedByName_Select(ReferenceName, Onsuccuss);
    //    }
    //    function Onsuccuss(result) {
    //        if (result != '') {
    //            var StrName = '';
    //            ShowName('divCheck');
    //            var divCheck = document.getElementById("divCheck");
    //            var SpltName = result.split('¶');
    //            for (var i = 0; i < SpltName.length - 1; i++) {
    //                StrName += "<div class='divpad' style='height:16px;z-index:1000;'>";
    //                StrName += "&nbsp;&nbsp;<a href='#' style='color:black;' onclick=\"javascript:GetReferencedName('" + SpltName[i] + "')\">" + SpltName[i] + "</a>";
    //                StrName += "</div>";
    //            }
    //            divCheck.innerHTML = StrName;
    //        }
    //        else {
    //            NotShowName('divCheck');
    //        }
    //    }
    function ShowName(Div) {
        document.getElementById(Div).style.display = "block";

    }
    function NotShowName(Div) {
        document.getElementById(Div).style.display = "none";
    }
    //    function GetReferencedName(ReferencedName) {
    //        //        var txt_Referencedby = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_txt_Referencedby");
    //        var ddl_Referencedby = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby");
    //        ddl_Referencedby.value = ReferencedName;
    //        NotShowName('divCheck');
    //    }

</script>
<style>
    #divCheck {
        float: left;
        position: absolute;
        display: none;
        border: solid 1px silver;
        overflow-x: hidden;
        overflow-y: scroll;
        width: 237px;
        height: 70px;
        background-color: white;
    }

    #div_list {
        float: left;
        position: absolute;
        display: none;
        border: solid 1px silver;
        overflow-x: hidden;
        overflow-y: scroll;
        width: 175px;
        height: 75px;
        background-color: white;
    }

    .divpad {
        padding: 2px;
    }
</style>
<script>
    function GetDays() {
        var ddl_PaymentTerm = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_ddl_PaymentTerms");
        var hdn_PaymentTerm = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_PaymentTerm");
        var lbl_PaymentTerm = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_lbl_PaymentTerm");
        var hdn_PaymenttermID = document.getElementById("ctl00_ContentPlaceHolder1_ClientAddID_hdn_PaymenttermID");

        var splitPayment = hdn_PaymentTerm.value.split('»');
        for (var i = 0; i < splitPayment.length; i++) {
            var Payment = splitPayment[i].split('‡');
            if (Payment[1] == ddl_PaymentTerm.value) {
                lbl_PaymentTerm.innerHTML = Payment[0];
                hdn_PaymenttermID.value = Payment[1];

            }
        }
    }
    function SaveFocValForMondatoryFld() {

        if (typeof e == 'undefined' || window.event) { e = window.event; }
        if (e.keyCode == 13) {
            if (txt_companyname.value != "") {
                document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_btnsave').click();
            }
            else {
                Validate();
                return false;
            }
        }
    }
    function SavefocusWithValidation() {
        if (typeof e == 'undefined' || window.event) { e = window.event; }
        if (e.keyCode == 13) {
            document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_btnsave').click();
            return false;
        }
    }
</script>
<script type="text/javascript">
    function OpenNewReffered() {
        window.radopen("https://demo.eprintsoftware.com/common/add_new_referredby.aspx", '800', '400');
        SetRadWindow('divrad', 'divBackGroundNew', '200');
    }
</script>



<script language="javascript" type="text/javascript">
    function Close() {
        //alert("close");
        var oWindow = GetRadWindow();
        //alert(oWindow);
        //oWindow.argument = "hai";
        oWindow.close();
        return false;
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
</script>
<script language="javascript" type="text/javascript">

    function onDropDownClosing(sender, args) {
        cancelDropDownClosing = false;
    }

    function onBlurA(sender) {
        cancelFirstCombo = false;
    }

    function StopPropagation(e) {
        //cancel bubbling
        e.cancelBubble = true;
        if (e.stopPropagation) {
            e.stopPropagation();
        }
    }

    function onCheckBoxClick(chk) {

        var combo = $find("ctl00_ContentPlaceHolder1_ClientAddID_ddl_type");
        //Prevent second RadComboBox from closing.
        cancelDropDownClosing = true;
        var text = "";
        var values = "";
        var items = combo.get_items();
        for (var i = 0; i < items.get_count() ; i++) {
            var item = items.getItem(i);
            var chk1 = $get(combo.get_id() + "_i" + i + "_chk1");
            if (chk1.checked) {
                text += item.get_text() + ", ";
                values += item.get_value() + ",";
            }
        }
        text = removeLastComma(text);
        values = removeLastCommaNew(values);

        if (text.length > 0) {
            combo.set_text(text);
        }
        else {
            combo.set_text(" None");
        }
    }

    function removeLastComma(str) {

        return str.replace(/, $/, "");
    }

    function removeLastCommaNew(str) {

        return str.replace(/,$/, "");
    }

    function pageLoad() {

        var combo = $find("ctl00_ContentPlaceHolder1_ClientAddID_ddl_type");
        var input = combo.get_inputDomElement();
        input.onkeydown = onKeyDownHandler;
    }
    function onKeyDownHandler(e) {
        if (!e)
            e = window.event;
        e.returnValue = false;
        if (e.preventDefault) {
            e.preventDefault();
        }
    }

</script>




    </div>

                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>

                                                                                        <!--BODY TD END-->
                                                                                        
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 10px">
                                                                            <td colspan="1">
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="bodypanel" style="display: none">
                                                                            <td colspan="1" align="right">
                                                                                <table width="100%" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img style="height: 6px; width: 1; border: 0" alt="" src="https://demo.eprintsoftware.com/images/nil.gif" />
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            

                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <!--navigator end -->
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="border_views">
                    </div>
                </td>
            </tr>
            <tr style="height: 100%" valign="bottom" class="normalText">
                <td style="width: 631px;">
                    <table width='100%' style='padding-left: 7px;'><tr><td align=left class=NormalText>© ePrint MIS  2011-2016. All Rights Reserved.</td></tr></table>
                    
                </td>
            </tr>
        </table>
        

</form>
    </div>
</body>
</html>
<script type="text/javascript" src="../common/swazz_calendar.js?VN='3.9.7'"></script>
<script type="text/javascript" src="../js/item/inner_master_withleftTD.js?VN='3.9.7'"></script>
<script src="../js/jquery-1.3.2.js?VN='3.9.7'" type="text/javascript"></script>
<script src="../js/jquery-ui-1.7.2.custom.min.js?VN='3.9.7'" type="text/javascript"></script>
<script src="../js/commonloading.js?VN='3.9.7'" type="text/javascript"></script>


<script type="text/javascript">

    //   var showquickcreate = document.getElementById("<showquickcreate.ClientID%>");
    //    var quickcreate = document.getElementById("<quickcreate.ClientID%>");
    //    var divquicktask1 = document.getElementById("<divquicktask1.ClientID %>");

    var pgName = 'client';

    function showarrow(divid) {
        //        var leftpanelid = document.getElementById(divid);
        //        document.getElementById('divarrow').style.display = "block";

    }

    function hidearrow(divid) {
        //        var leftpanelid = document.getElementById(divid);
        //        document.getElementById('divarrow').style.display = "none";

    }

    //    function showArrowtooltip() {
    //        document.getElementById('divArrowTooltip').style.display = "block";
    //    }
    //    function hideArrowtooltip() {
    //        document.getElementById('divArrowTooltip').style.display = "none";
    //    }

    //    function showArrowtooltip1() {
    //        document.getElementById('divopentooltip').style.display = "block";
    //    }
    //    function hideArrowtooltip1() {
    //        document.getElementById('divopentooltip').style.display = "none";
    //    }

</script>
