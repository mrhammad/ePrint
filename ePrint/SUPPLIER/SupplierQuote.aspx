<%@ page title="Supplier Quote" language="C#" masterpagefile="~/Templates/Supplier.Master" autoeventwireup="true" CodeBehind="SupplierQuote.aspx.cs" Inherits="ePrint.SUPPLIER.SupplierQuote" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .div2
        {
            float: left;
            width: 90%;
            padding-top: 5px;
        }
        
        .thBottom
        {
            border-bottom: 1px solid #CCCCCC;
            min-width: 1000px;
        }
        
        #tblStatic
        {
            padding: 10px 10px;
        }
        
        .TextBox
        {
            width: 100%;
        }
        
        .buttonDisabled
        {
            display: inline-block;
            outline: none;
            cursor: auto;
            text-align: center;
            text-decoration: none;
            font: 11px "Verdana" , Verdana, Arial, Helvetica, sans-serif;
            padding-left: 8px;
            padding-top: 3px;
            padding-bottom: 5px;
            padding-right: 8px;
            text-shadow: 0 1px 1px rgba(0,0,0,.3);
            -webkit-border-radius: .5em;
            -moz-border-radius: .5em;
            border-radius: .5em;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            box-shadow: 0 1px 2px rgba(0,0,0,.2);
            color: #7A7A7A;
            border: solid 1px #D3D3D3;
            background: #EEEEEE;
            background: -webkit-gradient(linear, left top, left bottom, from(#EEEEEE), to(#F9F8F8));
            background: -moz-linear-gradient(top,  #EEEEEE,  #F9F8F8);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#EEEEEE', endColorstr='#F9F8F8');
        }
        
        
        /*-------------------------
	Simple reset
--------------------------*/
        
        
        *
        {
            margin: 0;
            padding: 0;
        }
        
        
        /*-------------------------
	General Styles
--------------------------*/
        
        
        html
        {
            /*-<%--background: url('../img/tile_bg.jpg') #b0b0b0;
            position: relative;--%>---------*/
        }
        
        body
        {
            /*-background: url('../img/page_bg_center.jpg') no-repeat center center;
            min-height: 600px;
            padding: 200px 0 0;
            font: 14px/1.3 'Segoe UI' ,Arial, sans-serif;-*/
        }
        
        a, a:visited
        {
            text-decoration: none;
            outline: none;
            color: #54a6de;
        }
        
        a:hover
        {
            text-decoration: underline;
        }
        
        section, footer
        {
            display: block;
        }
        
        
        /*----------------------------
	Main Section
-----------------------------*/
        
        #note
        {
            color: #3A3A3A;
            margin: 0 auto;
            padding: 4px;
            text-align: center;
            letter-spacing: 0.3px;
            font-family: "Verdana" ,Verdana,Arial,Helvetica;
            font-size: 11px;
        }
        
        
        /*----------------------------
	The Footer
-----------------------------*/
        
        
        footer
        {
            background-color: #111111;
            bottom: 0;
            box-shadow: 0 -1px 2px #111111;
            height: 45px;
            left: 0;
            position: fixed;
            width: 100%;
            z-index: 100000;
        }
        
        footer h2
        {
            color: #EEEEEE;
            font-size: 14px;
            font-weight: normal;
            left: 50%;
            margin-left: -400px;
            padding: 13px 0 0;
            position: absolute;
            width: 540px;
        }
        
        footer h2 i
        {
            font-style: normal;
            color: #888;
        }
        
        footer a.tzine, a.tzine:visited
        {
            color: #999999;
            font-size: 12px;
            left: 50%;
            margin: 16px 0 0 110px;
            position: absolute;
            text-decoration: none;
            top: 0;
        }
        
        footer a i
        {
            color: #ccc;
            font-style: normal;
        }
        
        footer a i b
        {
            color: #c92020;
            font-weight: normal;
        }
        
        .countdownHolder
        {
            margin: 0 auto;
            font: 15px/1.5 'Open Sans Condensed' ,sans-serif;
            text-align: right;
            letter-spacing: -3px;
            padding-right: 10px;
            padding-top: 7px;
        }
        
        .position
        {
            display: inline-block;
            height: 1.6em;
            overflow: hidden;
            position: relative;
            width: 1.05em;
        }
        
        .digit
        {
            position: absolute;
            display: block;
            width: 1em;
            background-color: #444;
            border-radius: 0.2em;
            text-align: center;
            color: #fff;
            letter-spacing: -1px;
        }
        
        .digit.static
        {
            box-shadow: 1px 1px 1px rgba(4, 4, 4, 0.35);
            background-image: linear-gradient(bottom, #3A3A3A 50%, #444444 50%);
            background-image: -o-linear-gradient(bottom, #3A3A3A 50%, #444444 50%);
            background-image: -moz-linear-gradient(bottom, #3A3A3A 50%, #444444 50%);
            background-image: -webkit-linear-gradient(bottom, #3A3A3A 50%, #444444 50%);
            background-image: -ms-linear-gradient(bottom, #3A3A3A 50%, #444444 50%);
            background-image: -webkit-gradient(linear,left bottom,left top,color-stop(0.5, #3A3A3A),color-stop(0.5, #444444));
        }
        
        /**
 * You can use these classes to hide parts
 * of the countdown that you don't need.
 */
        
        .countDays
        {
            /* display:none !important;*/
        }
        .countDiv0
        {
            /* display:none !important;*/
        }
        .countHours
        {
        }
        .countDiv1
        {
        }
        .countMinutes
        {
        }
        .countDiv2
        {
        }
        .countSeconds
        {
        }
        
        
        .countDiv
        {
            display: inline-block;
            width: 16px;
            height: 1.6em;
            position: relative;
        }
        
        .countDiv:before, .countDiv:after
        {
            position: absolute;
            width: 3px;
            height: 3px;
            background-color: #444;
            border-radius: 90%;
            left: 50%;
            margin-left: -3px;
            top: 0.5em;
            box-shadow: 1px 1px 1px rgba(4, 4, 4, 0.5);
            content: '';
        }
        
        .countDiv:after
        {
            top: 0.9em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/item/item_summary_reeng.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="<%=strSitepath %>js/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        function CheckDeliveryIncluded(chk, txt) {
            var ChkBox = document.getElementById(chk);
            var TxtBox = document.getElementById("ctl00_ContentPlaceHolder1_" + txt);

            if (ChkBox.checked) {
                TxtBox.disabled = true;
            }
            else {
                TxtBox.disabled = false;
                TxtBox.focus();
            }
        }

        function Eprint_ReturnFinal_Formated_Amount1(Amount) {
            var settingScale = '2';
            return roundNumber_new(Amount, settingScale);
        }

        function todecimal_function1(txtobj) {
            var value = txtobj.value;
            if (!isNaN(txtobj.value) && Number(txtobj.value)) {
                txtobj.value = Eprint_ReturnFinal_Formated_Amount1(txtobj.value);
            }
            else {
                txtobj.value = Eprint_ReturnFinal_Formated_Amount1(0);
            }
        }

        function TermsNConditions() {
            var AcceptBtn = document.getElementById("ctl00_ContentPlaceHolder1_btnAccept");
            var ChkAgree = document.getElementById("ctl00_ContentPlaceHolder1_chkIAgree");

            if (ChkAgree.checked) {
                AcceptBtn.disabled = false;
                AcceptBtn.className = 'button';
                AcceptBtn.enabled = true;
            }
            else {
                AcceptBtn.disabled = true;
                AcceptBtn.className = 'buttonDisabled';
            }
        }

    </script>
    <style type="text/css">
        .label
        {
            background-color: #EEEEEE;
            clear: left;
            vertical-align: middle;
            margin: 0px 0px 2px 0px;
            font-size: 11px;
        }
        
        .imageclose
        {
            /*background-image: url(../..../../images/close_new.gif);*/
            background-position: center;
            background-repeat: no-repeat;
            height: 13px;
            width: 13px;
        }
        
        .popuptable_Address
        {
            width: 285px;
            height: 165px;
        }
        
        .web_dialog_title_Address
        {
            /*font-size: 13px;     padding: 5px 5px 5px 15px;     color: Black;*/
            font: 12px/1.55 Calibri,Helvetica,sans-serif;
            padding: 5px 0px 0px 12px;
            margin: 0px;
            font-size: 16px;
            display: table-cell;
            vertical-align: middle;
            font-weight: bold;
            color: rgb(0, 126, 211);
        }
        
        .web_dialog_Address
        {
            -webkit-border-radius: 5px;
            -webkit-box-shadow: 1px 1px 5px 5px #E9E9E9;
            box-shadow: 1px 1px 5px 5px #E9E9E9;
            -ms-border-radius: 7px;
            -webkit-border-top-right-radius: 5px 5px;
            -webkit-border-top-left-radius: 5px 5px;
            -webkit-border-bottom-right-radius: 5px 5px;
            -webkit-border-bottom-left-radius: 5px 5px;
            border-top-left-radius: 5px 5px;
            border-top-right-radius: 5px 5px;
            border-bottom-left-radius: 5px 5px;
            border-bottom-right-radius: 5px 5px;
            display: none;
            position: fixed;
            width: 285px;
            height: 165px;
            top: 57%;
            left: 57%;
            margin-left: -18%;
            margin-top: -185px;
            background-color: #ffffff;
            padding: 0px;
            z-index: 102;
        }
        
        .web_dialog_overlay_Address
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: Black;
            opacity: .25;
            filter: alpha(opacity=25);
            -moz-opacity: .25;
            z-index: 101;
            display: none;
        }
        
        .msg-success
        {
            font-size: 11px;
            font-family: "Verdana" , Verdana;
            background: url(../..../../images/Ok-icon.png) no-repeat;
            height: 15px;
            text-align: center;
            font-weight: bold;
            padding-right: 4px;
            padding-left: 26px;
            padding-bottom: 4px;
            padding-top: 4px;
            color: #FD8404;
        }
        
        .msg-reject
        {
            font-size: 11px;
            font-family: "Verdana" , Verdana;
            background: url(../..../../images/fail-icon.png) no-repeat;
            height: 15px;
            text-align: center;
            font-weight: bold;
            padding-right: 4px;
            padding-left: 26px;
            padding-bottom: 4px;
            padding-top: 4px;
            color: #FD8404;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#btnClose_bill").click(function (e) {
                HideDialog();
                e.preventDefault();
            });
        });

        function ShowDialog() {
            $("#overlay").show();
            $("#dialog").fadeIn(300);
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(100);
        }

        function TimeOut() {
            var isAuthentic = document.getElementById("ctl00_ContentPlaceHolder1_isAuthentic").value;
            if (isAuthentic == "authentic") {
                $("#overlay").show();
                $("#countdown").hide();

                var DivTimeOut = $('#DivTimeOut');
                DivTimeOut.html("This quote request has closed.<br/>Please contact your customer directly if you wish to provide a quote");

                $("#DivTimeOut").show();
            }
            else {
                $("#countdown").hide();
            }
        }


        function CopyDate(txtValue) {
            var DelDate1 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery1");
            var DelDate2 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery2");
            var DelDate3 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery3");
            var DelDate4 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery4");

            var lblQty1 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity1");
            var lblQty2 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity2");
            var lblQty3 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity3");
            var lblQty4 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity4");

            if (lblQty1.innerText != "0") {
                if (lblQty2.innerText != "0" && DelDate2.value == "") {
                    DelDate2.value = DelDate1.value;
                }
                if (lblQty3.innerText != "0" && DelDate3.value == "") {
                    DelDate3.value = DelDate1.value;
                }
                if (lblQty4.innerText != "0" && DelDate4.value == "") {
                    DelDate4.value = DelDate1.value;
                }
            }
        }

        function validate() {

            var DelDate1 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery1");
            var DelDate2 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery2");
            var DelDate3 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery3");
            var DelDate4 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelivery4");

            var lblQty1 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity1");
            var lblQty2 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity2");
            var lblQty3 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity3");
            var lblQty4 = document.getElementById("ctl00_ContentPlaceHolder1_lblQuantity4");

            var chkDelInc1 = document.getElementById("ctl00_ContentPlaceHolder1_chkDelInc1");
            var chkDelInc2 = document.getElementById("ctl00_ContentPlaceHolder1_chkDelInc2");
            var chkDelInc3 = document.getElementById("ctl00_ContentPlaceHolder1_chkDelInc3");
            var chkDelInc4 = document.getElementById("ctl00_ContentPlaceHolder1_chkDelInc4");

            var txtDelCost1 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelCost1");
            var txtDelCost2 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelCost2");
            var txtDelCost3 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelCost3");
            var txtDelCost4 = document.getElementById("ctl00_ContentPlaceHolder1_txtDelCost4");

            if (lblQty1.innerText != "0") {
                if (DelDate1.value == "" && lblQty1.innerText != "0") {
                    alert('Please select Delivery Date');
                    return false;
                }
                if (lblQty2.innerText != "0" && DelDate2.value == "") {
                    alert('Please select Delivery Date');
                    return false;
                }
                if (lblQty3.innerText != "0" && DelDate3.value == "") {
                    alert('Please select Delivery Date');
                    return false;
                }
                if (lblQty4.innerText != "0" && DelDate4.value == "") {
                    alert('Please select Delivery Date');
                    return false;
                }
            }

            if (lblQty1.innerText != "0") {
                if (chkDelInc1.checked == false && lblQty1.innerText != "0" && txtDelCost1.value == "0.00") {
                    alert('Please enter Delivery Cost');
                    return false;
                }
                if (lblQty2.innerText != "0" && chkDelInc2.checked == false && txtDelCost2.value == "0.00") {
                    alert('Please enter Delivery Cost');
                    return false;
                }
                if (lblQty3.innerText != "0" && chkDelInc3.checked == false && txtDelCost3.value == "0.00") {
                    alert('Please enter Delivery Cost');
                    return false;
                }
                if (lblQty4.innerText != "0" && chkDelInc4.checked == false && txtDelCost4.value == "0.00") {
                    alert('Please enter Delivery Cost');
                    return false;
                }
            }
            else {
                return true;
            }
        }


        //var Timeleft = document.getElementById("ctl00_ContentPlaceHolder1_Timeleft");

    </script>
    <asp:ScriptManager ID="scptmanager" runat="server">
    </asp:ScriptManager>
    <script src="<%=strSitepath %>js/script.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="<%=strSitepath %>js/jquery.countdown.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="countdown" class="countdownHolder" style="float: right;">
        <div style="text-align: center; letter-spacing: 0.3px; font-family: Verdana,Verdana,Arial,Helvetica;
            font-size: 11px;">
            Time Left to Quote
        </div>
        <div class="countdownHolder" style="text-align: center;">
            <span class="countDays"><span class="position"><span class="digit static"></span></span>
                <span class="position"><span class="digit static"></span></span><span class="position">
                    <span class="digit static"></span></span></span><span class="countDiv countDiv0">
            </span><span class="countHours"><span class="position"><span class="digit static"></span>
            </span><span class="position"><span class="digit static"></span></span></span><span
                class="countDiv countDiv1"></span><span class="countMinutes"><span class="position">
                    <span class="digit static"></span></span><span class="position"><span class="digit static">
                    </span></span></span>
            <%--<span class="countDiv countDiv2"></span><span class="countSeconds">
                        <span class="position"><span class="digit static"></span></span><span class="position">
                            <span class="digit static"></span></span></span>--%>
        </div>
        <div style="margin-top: -7px;">
            <span style="letter-spacing: 0.3px; font-family: Verdana,Verdana,Arial,Helvetica;
                font-size: 11px; padding-right: 19px; font-weight: bold;">Days</span><span style="letter-spacing: 0.3px;
                    font-family: Verdana,Verdana,Arial,Helvetica; font-size: 11px; padding-right: 26px;
                    font-weight: bold;">Hrs</span><span style="letter-spacing: 0.3px; font-family: Verdana,Verdana,Arial,Helvetica;
                        font-size: 11px; padding-right: 16px; font-weight: bold;">Min</span><%--<span style="letter-spacing: 0.3px;
                            font-family: Verdana,Verdana,Arial,Helvetica; font-size: 11px; padding-right: 14px;
                            font-weight: bold;">Sec</span>--%>
        </div>
        <div id="note" style="display: none;">
        </div>
        <asp:TextBox ID="isAuthentic" runat="server" Style="display: none;"></asp:TextBox>
        <asp:TextBox ID="Timeleft" runat="server" Style="display: none;"></asp:TextBox>
    </div>
    <div id="DivTimeOut" style="float: right; color: Red; padding-right: 10px; padding-top: 10px;">
    </div>
    <div align="center">
        <div style="padding-left: 260px">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivError" runat="server">
        <table style="height: 100%; background-color: #FFFFFF" frame="border" width="98%"
            border="0" cellspacing="0" cellpadding="0" align="center">
            <tr valign="top">
                <td>
                    <table width="779" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF">
                        <tr>
                            <td align="left" style="width: 138px" class="toptext1">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <table width="76%" border="0" cellspacing="0" cellpadding="0" align="right">
                                    <tr>
                                        <td align="left" class="normaltext">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 9">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="images_home/header.gif" width="779" height="193">--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%; height: 100%;
                                    margin-top: 18%">
                                    <tr>
                                        <td align="center">
                                            <div class="messageboxSessionLogoutNew" style="padding: 15px 0px 0px 0px">
                                                <div id="DivNotAvailable" runat="server">
                                                    Sorry, this feature is not available to your system
                                                </div>
                                                <div id="DivWrongKey" runat="server">
                                                    The Key Code is not authentic. Please contact Administrator.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr valign="top">
                        <td>
                            <asp:PlaceHolder ID="plhheader" EnableViewState="false" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="div_RemainingTime" runat="server" style="width: 100%; z-index: 1000;">
        <table style="width: 100%; text-align: right;">
            <tr>
                <td style="width: 40%; text-align: left; padding-left: 14px;">
                    <div id="div_Welcome" runat="server" visible="false">
                        <b>Welcome&nbsp;
                            <asp:Label ID="lblSupplierName" runat="server"></asp:Label></b>
                    </div>
                </td>
                <td style="width: 60%; text-align: right; padding-right: 30px;">
                </td>
            </tr>
        </table>
    </div>
    <div id="DivHideAll" runat="server">
        <table id="tblStatic" width="100%">
            <tr>
                <td class="thBottom">
                    <table id="tblEstInfo">
                        <tr>
                            <th align="left" style="width: 200px; padding-bottom: 5px;">
                                ESTIMATE INFORMATION
                            </th>
                        </tr>
                        <tr>
                            <td class="label" style="width: 160px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    Estimate Number</div>
                            </td>
                            <td style="width: 200px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblEstNumber" runat="server"></asp:Label></div>
                            </td>
                            <td class="label" style="width: 200px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    RFQ Due by</div>
                            </td>
                            <td style="padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblRfqDue" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" style="width: 160px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    Estimate Title</div>
                            </td>
                            <td style="width: 200px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblEstTitle" runat="server"></asp:Label></div>
                            </td>
                            <td class="label" style="width: 200px; padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    Job Completion Date</div>
                            </td>
                            <td style="padding-bottom: 5px;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblJobComp" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" style="width: 160px; vertical-align: top;">
                                <div style="float: left; padding: 5px;">
                                    Artwork Included?</div>
                            </td>
                            <td style="width: 200px; vertical-align: top;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblArtInc" runat="server"></asp:Label></div>
                            </td>
                            <td class="label" style="width: 200px; vertical-align: top;">
                                <div style="float: left; padding: 5px;">
                                    Artwork File name</div>
                            </td>
                            <td style="vertical-align: top;">
                                <div style="float: left; padding: 5px;">
                                    <asp:Label ID="lblArtFileName" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; padding-right: 10px; padding-bottom: 10px;">
                        <table id="tblDynamic">
                            <tr>
                                <th colspan="2" align="left" style="padding-bottom: 10px;">
                                    ITEM DESCRIPTION
                                </th>
                            </tr>
                            <tr>
                                <td class="label" width="200px">
                                    <div style="float: left; padding: 5px;">
                                        Item Title</div>
                                </td>
                                <td style="padding-left: 6px">
                                    <div>
                                        <asp:Label ID="lblItemTitle" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label" style="vertical-align: top">
                                    <div style="float: left; padding: 5px;">
                                        Description</div>
                                </td>
                                <td style="padding-left: 6px">
                                    <div style="overflow: auto; height: 233px;">
                                        <asp:PlaceHolder ID="plhDescription" runat="server"></asp:PlaceHolder>
                                    </div>
                                </td>
                            </tr>
                            <asp:PlaceHolder ID="plhItemDesc" runat="server"></asp:PlaceHolder>
                        </table>
                    </div>
                    <div style="float: left;">
                        <table id="tblYourEstimate">
                            <%-- cellspacing="1"--%>
                            <tr>
                                <th align="left" colspan="5" style="padding-bottom: 5px;">
                                    YOUR ESTIMATE
                                </th>
                            </tr>
                            <tr>
                                <td class="label" style="width: 200px;">
                                    <div class="div2">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            <asp:Label ID="lblQuoteNumber" runat="server" Text=" RFQ Number"></asp:Label>
                                        </div>
                                    </div>
                                </td>
                                <td colspan="4" style="padding-left: 7px">
                                    <asp:TextBox ID="lblSupplierRefNo" runat="server" Style="margin-left: -1px"></asp:TextBox>
                                    <asp:Label ID="lblCompanyID" runat="server" Style="display: none"></asp:Label>
                                    <asp:Label ID="lblEmailID" runat="server" Style="display: none"></asp:Label>
                                    <asp:Label ID="lblEmailSenderID" runat="server" Style="display: none"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <div class="div2" style="width: 150px">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            Quantity
                                        </div>
                                    </div>
                                </td>
                                <td align="right" style="padding-left: 7px">
                                    <div class="div2" id="divQuantity1" runat="server" style="width: 78px">
                                        <asp:Label ID="lblQuantity1" runat="server">0</asp:Label></div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divQuantity2" runat="server" style="width: 78px">
                                        <asp:Label ID="lblQuantity2" runat="server">0</asp:Label></div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divQuantity3" runat="server" style="width: 78px">
                                        <asp:Label ID="lblQuantity3" runat="server">0</asp:Label></div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divQuantity4" runat="server" style="width: 78px">
                                        <asp:Label ID="lblQuantity4" runat="server">0</asp:Label></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <div class="div2" style="width: 150px">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            Price Exc Tax
                                        </div>
                                    </div>
                                </td>
                                <td style="padding-left: 7px; width: 85px">
                                    <div class="div2" id="divPriceEx1" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtPriceEx1" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox></div>
                                </td>
                                <td style="width: 85px">
                                    <div class="div2" id="divPriceEx2" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtPriceEx2" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox></div>
                                </td>
                                <td style="width: 85px">
                                    <div class="div2" id="divPriceEx3" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtPriceEx3" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox></div>
                                </td>
                                <td>
                                    <div class="div2" id="divPriceEx4" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtPriceEx4" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <div style="width: 150px">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            <asp:Label ID="LblDeliverydate" runat="server" Text="Delivery Date"></asp:Label>
                                            <span id="DelveryMandatory" style="color: Red;">*</span>
                                        </div>
                                    </div>
                                </td>
                                <td style="padding-left: 7px">
                                    <div class="div2" id="divDelivery1" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelivery1" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:CopyDate(this.value);"></asp:TextBox>
                                        <ajax:CalendarExtender ID="calDelivery1" runat="server" TargetControlID="txtDelivery1">
                                        </ajax:CalendarExtender>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelivery2" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelivery2" runat="server" CssClass="TextBox" Style="text-align: right;"></asp:TextBox>
                                        <ajax:CalendarExtender ID="calDelivery2" runat="server" TargetControlID="txtDelivery2">
                                        </ajax:CalendarExtender>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelivery3" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelivery3" runat="server" CssClass="TextBox" Style="text-align: right;"></asp:TextBox>
                                        <ajax:CalendarExtender ID="calDelivery3" runat="server" TargetControlID="txtDelivery3">
                                        </ajax:CalendarExtender>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelivery4" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelivery4" runat="server" CssClass="TextBox" Style="text-align: right;"></asp:TextBox>
                                        <ajax:CalendarExtender ID="calDelivery4" runat="server" TargetControlID="txtDelivery4">
                                        </ajax:CalendarExtender>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <div class="div2" style="width: 150px">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            <asp:Label ID="Label1" runat="server" Text="Delivery Included ?"></asp:Label>
                                        </div>
                                    </div>
                                </td>
                                <td align="right" style="padding-left: 7px">
                                    <div class="div2" id="divDelInc1" runat="server" style="width: 78px;">
                                        <asp:CheckBox ID="chkDelInc1" runat="server" onClick="javascript:CheckDeliveryIncluded(this.id,'txtDelCost1');">
                                        </asp:CheckBox>
                                    </div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divDelInc2" runat="server" style="width: 78px;">
                                        <asp:CheckBox ID="chkDelInc2" runat="server" onClick="javascript:CheckDeliveryIncluded(this.id,'txtDelCost2');">
                                        </asp:CheckBox>
                                    </div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divDelInc3" runat="server" style="width: 78px;">
                                        <asp:CheckBox ID="chkDelInc3" runat="server" onClick="javascript:CheckDeliveryIncluded(this.id,'txtDelCost3');">
                                        </asp:CheckBox>
                                    </div>
                                </td>
                                <td align="right">
                                    <div class="div2" id="divDelInc4" runat="server" style="width: 78px;">
                                        <asp:CheckBox ID="chkDelInc4" runat="server" onClick="javascript:CheckDeliveryIncluded(this.id,'txtDelCost4');">
                                        </asp:CheckBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">
                                    <div style="width: 150px">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            <asp:Label ID="Label2" runat="server" Text="Delivery Cost"></asp:Label>
                                            <span id="DeliveryIncMand" style="color: Red;">*</span>
                                        </div>
                                    </div>
                                </td>
                                <td style="padding-left: 7px">
                                    <div class="div2" id="divDelCost1" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelCost1" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelCost2" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelCost2" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelCost3" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelCost3" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div class="div2" id="divDelCost4" runat="server" style="width: 75px">
                                        <asp:TextBox ID="txtDelCost4" runat="server" CssClass="TextBox" Style="text-align: right;"
                                            onblur="javascript:todecimal_function1(this,this.value);AllowNumber(this,this.value);"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="label" style="vertical-align: top;">
                                    <div style="padding-top: 5px;">
                                        <div style="float: left; padding: 0px 5px 5px 5px;">
                                            Comments
                                        </div>
                                    </div>
                                </td>
                                <td colspan="4" style="padding-left: 7px">
                                    <div class="div2" style="width: 100%; padding-top: 5px;">
                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Style="width: 502px;
                                            margin: 2px 0px; height: 91px; padding: 3px;"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="width: 200px;">
                                <div>
                                    &nbsp;
                                </div>
                            </td>
                            <td colspan="4" style="padding-top: 5px; padding-left: 7px">
                                <div class="div2" style="display: none;">
                                    <asp:CheckBox ID="chkIAgree" runat="server" Text=" I agree to Estimate's Terms and Conditions"
                                        onClick="javascript:TermsNConditions();" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    &nbsp;
                                    <asp:Label ID="lbl_QuoteStats" runat="server" Style="display: none"></asp:Label>
                                </div>
                            </td>
                            <td colspan="4" style="padding-top: 10px; padding-left: 8px;">
                                <div style="float: left">
                                    <div id="DivbtnDecline" style="float: left; padding-top: 0px;">
                                        <%--<asp:Button ID="btnDecline" runat="server" CssClass="button" OnClientClick="javascript:ShowDialog();"
                                            Text="Decline Request" />OnClientClick="javascript:loadingimg('DivbtnDecline','div_process');" OnClick="btnDecline_Click"--%>
                                        <div id="btnDecline" class="button" align="center" style="width: 77.5px;" onclick="javascript:ShowDialog();">
                                            <span>Reject</span>
                                        </div>
                                    </div>
                                    <div id="div_process" class="button" align="center" style="width: 77.5px; height: 15px;
                                        display: none;">
                                        <img src="<%=strImagepath %>radimg1.gif" alt="loading" border="0" style="margin-top: -2px;" />
                                    </div>
                                </div>
                                <div style="float: left; padding-left: 10px;">
                                    <div id="DivbtnAccept" style="float: left;">
                                        <asp:Button ID="btnAccept" runat="server" Text="Accept & Quote" CssClass="button"
                                            OnClientClick="javascript:var a=validate();if(a)loadingimg('DivbtnAccept','DivImage'); return a;"
                                            OnClick="btnAccept_Click" Enabled="true" /><%--CssClass="buttonDisabled"--%>
                                    </div>
                                    <div id="DivImage" class="button" align="center" style="width: 94px; height: 15px;
                                        display: none;">
                                        <img src="<%=strImagepath %>radimg1.gif" alt="loading" border="0" style="margin-top: -2px;" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr style="height: 100%" valign="bottom" class="normalText">
            <td style="width: 631px">
                <asp:PlaceHolder ID="plhFooter" EnableViewState="false" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
    <div>
        <div id="output">
        </div>
        <div id="overlay" class="web_dialog_overlay_Address">
        </div>
        <div id="dialog" class="web_dialog_Address">
            <table align="center" class="popuptable_Address">
                <tr>
                    <td class="web_dialog_title_Address">
                        <div>
                            <b>Reject with Reason</b> <a href="#" id="btnClose_bill" title="Close" style="float: right;
                                padding-right: 11px;">
                                <img alt="" class="imageclose" src="../images/close_new.gif" /></a>
                        </div>
                        <div style="height: 10px;">
                        </div>
                        <div>
                            <asp:TextBox ID="txtRejectReason" runat="server" Width="250px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div style="padding-top: 5px; float: right; padding-right: 11px;">
                            <asp:Button ID="btnReject" runat="server" Text="Send" CssClass="button" OnClick="btnReject_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

