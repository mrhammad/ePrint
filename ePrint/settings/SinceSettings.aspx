<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="SinceSettings.aspx.cs" Inherits="ePrint.settings.SinceSettings" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px" class="mis_header_panel">
            <div id="">
                  If enabled, this column will display in red when the number of days reaches below the specified threshold.
                <div class="divpadding" style="width: 200px;">
                  
                                <span class="normaltext">
                                    <b>Days Since Last Status Update</b></span>
                            </div>
                        <div id="divestimate" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Estimate Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtEstimateStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                         <div id="divorder" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Order Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkOrderStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtOrderStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                               <div align="left" style="float: left;">

                                <asp:TextBox ID="txtOrderStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                         <div id="divproof" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Proof Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkProofStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtProofStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtProofStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                 <div id="divprooffile" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Proof File Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkProoffileStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtProofFileStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtProofFileStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                 <div id="divjob" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Job Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkJobStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtJobStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtJobStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                  <div id="divPO" runat="server" align="left">
                                 <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                PO Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkPOStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtPOStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtPOStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                  <div id="divInv" runat="server" align="left">
                                 <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Invoice Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkInvStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtInvoiceStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtInvoiceStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                   <div id="divDN" runat="server" align="left">
                                  <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Delivery Note Status Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkDNStatus" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDNStatus');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                              <div align="left" style="float: left;">

                                <asp:TextBox ID="txtDNStatus" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>

                    <div class="divpadding" style="width: 200px;">
                                <span class="normaltext"><b>Days Since Last Email Sent</b></span>
                            </div>

                         <div id="divEstEmail" runat="server" align="left">
                             <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Estimate Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtEstimateEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div1" runat="server" align="left">
                           <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Order Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkOrdEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtOrderEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtOrderEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div2" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Proof Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkProofEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtProofEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtProofEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div3" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Proof File Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkProofFileEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtProofFileEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtProofFileEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div4" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Job Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkJobEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtJobEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtJobEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div5" runat="server" align="left">
                             <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                PO Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkPOEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtPOEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtPOEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div6" runat="server" align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Invoice Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkInvoiceEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtInvoiceEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtInvoiceEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                <div id="div7" runat="server" align="left">
                              <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Delivery Note Email Update</span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkDNEmail" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDNEmail');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="left" style="float: left;">

                                <asp:TextBox ID="txtDNEmail" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                               
                            </div>
                         </div>
                         <div align="left">
                        <div class="bglabelEmpty">
                        </div>
                        <div class="DefaultSettingsbox">
                            <div style="float: left;">
                                <div id="div_btnsave" style="display: block; margin-top: -1px;">
                                    <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                                        OnClick="btnSave_OnClick" OnClientClick="if(Page_ClientValidate()){javascript:loadingimage(this.id,'div_btnsaveprocess');}else{return false;}" />
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                         
                        
            </div>

        </div>
         
        <div style="clear: both;">
        </div>
    </div>
  <script type="text/javascript">
      var path = "<%=strSitepath %>";
      var txtEstimateStatus = document.getElementById("<%=txtEstimateStatus.ClientID %>");
      var txtOrderStatus = document.getElementById("<%=txtOrderStatus.ClientID %>");
      var txtProofStatus = document.getElementById("<%=txtProofStatus.ClientID %>");
      var txtProofFileStatus = document.getElementById("<%=txtProofFileStatus.ClientID %>");
      var txtJobStatus = document.getElementById("<%=txtJobStatus.ClientID %>");
      var txtPOStatus = document.getElementById("<%=txtPOStatus.ClientID %>");
      var txtInvoiceStatus = document.getElementById("<%=txtInvoiceStatus.ClientID %>");
      var txtDNStatus = document.getElementById("<%=txtDNStatus.ClientID %>");
      var txtEstimateEmail = document.getElementById("<%=txtEstimateEmail.ClientID %>");
      var txtOrderEmail = document.getElementById("<%=txtOrderEmail.ClientID %>");
      var txtProofEmail = document.getElementById("<%=txtProofEmail.ClientID %>");
      var txtProofFileEmail = document.getElementById("<%=txtProofFileEmail.ClientID %>");
      var txtJobEmail = document.getElementById("<%=txtJobEmail.ClientID %>");
      var txtPOEmail = document.getElementById("<%=txtPOEmail.ClientID %>");
      var txtInvoiceEmail = document.getElementById("<%=txtInvoiceEmail.ClientID %>");
      var txtDNEmail = document.getElementById("<%=txtDNEmail.ClientID %>");


      var chkEstimateStatus = document.getElementById("<%=chkEstimateStatus.ClientID %>");
      var chkOrderStatus = document.getElementById("<%=chkOrderStatus.ClientID %>");
      var chkProofStatus = document.getElementById("<%=chkProofStatus.ClientID %>");
      var chkProofFileStatus = document.getElementById("<%=chkProoffileStatus.ClientID %>");
      var chkJobStatus = document.getElementById("<%=chkJobStatus.ClientID %>");
      var chkPOStatus = document.getElementById("<%=chkPOStatus.ClientID %>");
      var chkInvoiceStatus = document.getElementById("<%=chkInvStatus.ClientID %>");
      var chkDNStatus = document.getElementById("<%=chkDNStatus.ClientID %>");
      var chkEstimateEmail = document.getElementById("<%=chkEstEmail.ClientID %>");
      var chkOrderEmail = document.getElementById("<%=chkOrdEmail.ClientID %>");
      var chkProofEmail = document.getElementById("<%=chkProofEmail.ClientID %>");
      var chkProofFileEmail = document.getElementById("<%=chkProofFileEmail.ClientID %>");
      var chkJobEmail = document.getElementById("<%=chkJobEmail.ClientID %>");
      var chkPOEmail = document.getElementById("<%=chkPOEmail.ClientID %>");
      var chkInvoiceEmail = document.getElementById("<%=chkInvoiceEmail.ClientID %>");
      var chkDNEmail = document.getElementById("<%=chkDNEmail.ClientID %>");



      function PageLoad() {
          // alert(chkEstimateArtwork);

          if (chkEstimateStatus.checked == true) {
              txtEstimateStatus.style.backgroundColor = "#FFFFFF";
              txtEstimateStatus.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtEstimateStatus.style.backgroundColor = "#F0F0F0";
              txtEstimateStatus.style.cursor = "default";
              txtEstimateStatus.readOnly = true;
          }

          if (chkOrderStatus.checked == true) {
              txtOrderStatus.style.backgroundColor = "#FFFFFF";
              txtOrderStatus.readOnly = false;
          }
          else {
              txtOrderStatus.style.backgroundColor = "#F0F0F0";
              txtOrderStatus.style.cursor = "default";
              txtOrderStatus.readOnly = true;
          }

          if (chkProofStatus.checked == true) {
              txtProofStatus.style.backgroundColor = "#FFFFFF";
              txtProofStatus.readOnly = false;
          }
          else {
              txtProofStatus.style.backgroundColor = "#F0F0F0";
              txtProofStatus.style.cursor = "default";
              txtProofStatus.readOnly = true;
          }

          if (chkProofFileStatus.checked == true) {
              txtProofFileStatus.style.backgroundColor = "#FFFFFF";
              txtProofFileStatus.readOnly = false;
          }
          else {
              txtProofFileStatus.style.backgroundColor = "#F0F0F0";
              txtProofFileStatus.style.cursor = "default";
              txtProofFileStatus.readOnly = true;
          }

          if (chkJobStatus.checked == true) {
              txtJobStatus.style.backgroundColor = "#FFFFFF";
              txtJobStatus.readOnly = false;
          }
          else {
              txtJobStatus.style.backgroundColor = "#F0F0F0";
              txtJobStatus.style.cursor = "default";
              txtJobStatus.readOnly = true;
          }

          if (chkPOStatus.checked == true) {
              txtPOStatus.style.backgroundColor = "#FFFFFF";
              txtPOStatus.readOnly = false;
          }
          else {
              txtPOStatus.style.backgroundColor = "#F0F0F0";
              txtPOStatus.style.cursor = "default";
              txtPOStatus.readOnly = true;
          }

          if (chkInvoiceStatus.checked == true) {
              txtInvoiceStatus.style.backgroundColor = "#FFFFFF";
              txtInvoiceStatus.readOnly = false;
          }
          else {
              txtInvoiceStatus.style.backgroundColor = "#F0F0F0";
              txtInvoiceStatus.style.cursor = "default";
              txtInvoiceStatus.readOnly = true;
          }

          if (chkDNStatus.checked == true) {
              txtDNStatus.style.backgroundColor = "#FFFFFF";
              txtDNStatus.readOnly = false;
          }
          else {
              txtDNStatus.style.backgroundColor = "#F0F0F0";
              txtDNStatus.style.cursor = "default";
              txtDNStatus.readOnly = true;
          }

          if (chkEstimateEmail.checked == true) {
              txtEstimateEmail.style.backgroundColor = "#FFFFFF";
              txtEstimateEmail.readOnly = false;
          }
          else {
              txtEstimateEmail.style.backgroundColor = "#F0F0F0";
              txtEstimateEmail.style.cursor = "default";
              txtEstimateEmail.readOnly = true;
          }

          if (chkOrderEmail.checked == true) {
              txtOrderEmail.style.backgroundColor = "#FFFFFF";
              txtOrderEmail.readOnly = false;
          }
          else {
              txtOrderEmail.style.backgroundColor = "#F0F0F0";
              txtOrderEmail.style.cursor = "default";
              txtOrderEmail.readOnly = true;
          }

          if (chkProofEmail.checked == true) {
              txtProofEmail.style.backgroundColor = "#FFFFFF";
              txtProofEmail.readOnly = false;
          }
          else {
              txtProofEmail.style.backgroundColor = "#F0F0F0";
              txtProofEmail.style.cursor = "default";
              txtProofEmail.readOnly = true;
          }

          if (chkProofFileEmail.checked == true) {
              txtProofFileEmail.style.backgroundColor = "#FFFFFF";
              txtProofFileEmail.readOnly = false;
          }
          else {
              txtProofFileEmail.style.backgroundColor = "#F0F0F0";
              txtProofFileEmail.style.cursor = "default";
              txtProofFileEmail.readOnly = true;
          }

          if (chkJobEmail.checked == true) {
              txtJobEmail.style.backgroundColor = "#FFFFFF";
              txtJobEmail.readOnly = false;
          }
          else {
              txtJobEmail.style.backgroundColor = "#F0F0F0";
              txtJobEmail.style.cursor = "default";
              txtJobEmail.readOnly = true;
          }

          if (chkPOEmail.checked == true) {
              txtPOEmail.style.backgroundColor = "#FFFFFF";
              txtPOEmail.readOnly = false;
          }
          else {
              txtPOEmail.style.backgroundColor = "#F0F0F0";
              txtPOEmail.style.cursor = "default";
              txtPOEmail.readOnly = true;
          }

          if (chkInvoiceEmail.checked == true) {
              txtInvoiceEmail.style.backgroundColor = "#FFFFFF";
              txtInvoiceEmail.readOnly = false;
          }
          else {
              txtInvoiceEmail.style.backgroundColor = "#F0F0F0";
              txtInvoiceEmail.style.cursor = "default";
              txtInvoiceEmail.readOnly = true;
          }

          if (chkDNEmail.checked == true) {
              txtDNEmail.style.backgroundColor = "#FFFFFF";
              txtDNEmail.readOnly = false;
          }
          else {
              txtDNEmail.style.backgroundColor = "#F0F0F0";
              txtDNEmail.style.cursor = "default";
              txtDNEmail.readOnly = true;
          }


        
        
      }

      function enableDisable(bEnable, textBoxID) {
          var textboxclientid = document.getElementById(textBoxID);
          if (bEnable == true) {
              textboxclientid.style.backgroundColor = "#FFFFFF";
              //$(textboxclientid).attr("readonly", false);
              textboxclientid.readOnly = false;
          }
          else {
              textboxclientid.style.backgroundColor = "#F0F0F0";
              textboxclientid.style.cursor = "default";
              textboxclientid.readOnly = true;
          }
      }
      window.onload = PageLoad();

  </script>

      <%--<script src="../js/settings.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
