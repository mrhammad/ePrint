<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="Dates.aspx.cs" Inherits="ePrint.settings.Dates" %>
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
               
                         <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">
                                    <%=objlang.GetLanguageConversion("Estimate_Valid_For")%></span>
                                <span style="color: red">*</span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left">
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtValidFor" runat="server" Width="50px" SkinID="textPad" MaxLength="6"
                                            onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);">30</asp:TextBox><span
                                                class="normaltext" style="padding-left: 4px;"><%=objlang.GetLanguageConversion("Days_from_todays_date")%></span>
                                    </div>
                                    <div class="ValidationMessage">
                                        <asp:RequiredFieldValidator ID="rfv_txtValidFor" runat="server" ControlToValidate="txtValidFor"
                                            ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                            CssClass="spanerrorMsg"><%=objLanguage.GetLanguageConversion("Default_days_Validation")%>
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext"><b>
                                    <%=objLanguage.GetLanguageConversion("Default_Number_of_Days_from_Todays_Date")%></b></span>
                            </div>
                        </div>
                        <div align="left" id="div_Default_Arkwork" runat="server">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_ArtWork") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateArtwork" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtDefaultEstimated');"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtDefaultEstimated" runat="server" MaxLength="3" Width="50px" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDefaultEstimated"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" CssClass="spanerrorMsg"
                                        ValidationGroup="AddEstimate"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left" id="div_DefaultProof" runat="server">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Proof") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateProof" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateProof');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimateProof" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEstimateProof"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Approval") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateApproval" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_TxtEstimateApproval');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="TxtEstimateApproval" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                        onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtEstimateApproval"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Production") %></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateProduction" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateProduction');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimateProduction" runat="server" Width="50px" MaxLength="3"
                                        SkinID="textPad" onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEstimateProduction"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Completion")%></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateCompletion" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimatedCompletion');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="DefaultSettingsbox">
                                <div align="left" style="float: left;">
                                    <asp:TextBox ID="txtEstimatedCompletion" runat="server" Width="50px" MaxLength="3"
                                        SkinID="textPad" onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                                </div>
                                <div class="ValidationMessage">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEstimatedCompletion"
                                        ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                        CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                <%=objlang.GetLanguageConversion("Default_Estimated_Delivery")%></span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkEstimateDelivery" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtEstimateDelivery');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtEstimateDelivery" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                            <div class="ValidationMessage">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEstimateDelivery"
                                    ErrorMessage="Please enter Valid Days_from_todays_date" ValidationGroup="AddEstimate"
                                    CssClass="spanerrorMsg"> <span class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Default_days_Validation")%></span>
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>

         
                <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Custom Date 1
                                            </span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkCustomDate1" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtCustomDate1');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtCustomDate1" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                             <div align="left" style="float: left;">
                                   &nbsp;&nbsp;  
                                   <asp:Label ID="lblCustomDateTitle1" runat="server" Text="Title:" AssociatedControlID="txtCustomDateTitle1"></asp:Label>
                                <asp:TextBox ID="txtCustomDateTitle1" runat="server" Width="100px" MaxLength="200" SkinID="textPad"
                                  ></asp:TextBox>
                            </div>
                           
                        </div>


                <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Custom Date 2
                                            </span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkCustomDate2" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtCustomDate2');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtCustomDate2" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                             <div align="left" style="float: left;">
                                   &nbsp;&nbsp;  
                                 <asp:Label ID="lblCustomDateTitle2" runat="server" Text="Title:" AssociatedControlID="txtCustomDateTitle2"></asp:Label>     
                                <asp:TextBox ID="txtCustomDateTitle2" runat="server" Width="100px" MaxLength="200" SkinID="textPad"
                                  ></asp:TextBox>
                            </div>
                           
                        </div>


                <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Custom Date 3
                                            </span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkCustomDate3" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtCustomDate3');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtCustomDate3" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                             <div align="left" style="float: left;">
                                   &nbsp;&nbsp;  
                                    <asp:Label ID="lblCustomDateTitle3" runat="server" Text="Title:" AssociatedControlID="txtCustomDateTitle3"></asp:Label>         
                                <asp:TextBox ID="txtCustomDateTitle3" runat="server" Width="100px" MaxLength="200" SkinID="textPad"
                                  ></asp:TextBox>
                            </div>
                            
                        </div>

                        

                <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                 Custom Date 4
                                            </span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkCustomDate4" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtCustomDate4');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtCustomDate4" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div>
                             <div align="left" style="float: left;">
                                  &nbsp;&nbsp;  
                                 <asp:Label ID="lblCustomDateTitle4" runat="server" Text="Title:" AssociatedControlID="txtCustomDateTitle4"></asp:Label>

                                <asp:TextBox ID="txtCustomDateTitle4" runat="server" Width="100px" MaxLength="200" SkinID="textPad"
                                  ></asp:TextBox>
                            </div>
                       
                        </div>

                       

                        <div align="left">
                            <div class="bglabelcheckboxinsettingpage" style="width: 200px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <span class="normaltext Estimatespn">
                                                Custom Date 5
                                            </span>
                                        </td>
                                        <td style="float: right;">
                                            <asp:CheckBox ID="chkCustomDate5" runat="server" onclick="enableDisable(this.checked,'ctl00_ContentPlaceHolder1_txtCustomDate5');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="DefaultSettingsbox">
                            <div align="left" style="float: left;">
                                <asp:TextBox ID="txtCustomDate5" runat="server" Width="50px" MaxLength="3" SkinID="textPad"
                                    onkeyup="javascript:ToInteger(this,this.value)" onblur="javascript:AllowNumber(this,this.value);"></asp:TextBox>
                            </div> 
                              <div align="left" style="float: left;">
                                  &nbsp;&nbsp;  
                                  <asp:Label ID="lblCustomDateTitle5" runat="server" Text="Title:" AssociatedControlID="txtCustomDateTitle5"></asp:Label>

                                <asp:TextBox ID="txtCustomDateTitle5" runat="server" Width="100px" MaxLength="200" SkinID="textPad"
                                  ></asp:TextBox>
                            </div>

                          
                           
                        </div>







                <div align="left">
                        <div class="bglabelEmpty">
                        </div>
                        <div class="DefaultSettingsbox">
                            <div style="float: left;">
                                <div id="div_btnsave" style="display: block; margin-top: -1px;">
                                    <asp:Button ID="btnSave" CssClass="button" Text="Save" Width="65px" runat="server"
                                        OnClick="btnSave_OnClick" ValidationGroup="AddEstimate" OnClientClick="return validateForm();" />
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
      var txtDefaultEstimated = document.getElementById("<%=txtDefaultEstimated.ClientID %>");
      var txtEstimateProof = document.getElementById("<%=txtEstimateProof.ClientID %>");
      var TxtEstimateApproval = document.getElementById("<%=TxtEstimateApproval.ClientID %>");
      var txtEstimateProduction = document.getElementById("<%=txtEstimateProduction.ClientID %>");
      var txtEstimatedCompletion = document.getElementById("<%=txtEstimatedCompletion.ClientID %>");
      var txtEstimateDelivery = document.getElementById("<%=txtEstimateDelivery.ClientID %>");
      var txtValidFor = document.getElementById("<%=    txtValidFor.ClientID %>");

      var chkEstimateArtwork = document.getElementById("<%=chkEstimateArtwork.ClientID %>");
      var chkEstimateProof = document.getElementById("<%=chkEstimateProof.ClientID %>");
      var chkEstimateApproval = document.getElementById("<%=chkEstimateApproval.ClientID %>");
      var chkEstimateProduction = document.getElementById("<%=chkEstimateProduction.ClientID %>");
      var chkEstimateCompletion = document.getElementById("<%=chkEstimateCompletion.ClientID %>");
      var chkEstimateDelivery = document.getElementById("<%=chkEstimateDelivery.ClientID %>");

      var txtCustomDate1 = document.getElementById("<%=txtCustomDate1.ClientID %>");
      var txtCustomDate2 = document.getElementById("<%=txtCustomDate2.ClientID %>");
      var txtCustomDate3 = document.getElementById("<%=txtCustomDate3.ClientID %>");
      var txtCustomDate4 = document.getElementById("<%=txtCustomDate4.ClientID %>");
      var txtCustomDate5 = document.getElementById("<%=txtCustomDate5.ClientID %>");

      var chkCustomDate1 = document.getElementById("<%=chkCustomDate1.ClientID %>");
      var chkCustomDate2 = document.getElementById("<%=chkCustomDate2.ClientID %>");
      var chkCustomDate3 = document.getElementById("<%=chkCustomDate3.ClientID %>");
      var chkCustomDate4 = document.getElementById("<%=chkCustomDate4.ClientID %>");
      var chkCustomDate5 = document.getElementById("<%=chkCustomDate5.ClientID %>");

      var txtCustomDateTitle1 = document.getElementById("<%=txtCustomDateTitle1.ClientID %>");
      var txtCustomDateTitle2 = document.getElementById("<%=txtCustomDateTitle2.ClientID %>");
      var txtCustomDateTitle3 = document.getElementById("<%=txtCustomDateTitle3.ClientID %>");
      var txtCustomDateTitle4 = document.getElementById("<%=txtCustomDateTitle4.ClientID %>");
      var txtCustomDateTitle5 = document.getElementById("<%=txtCustomDateTitle5.ClientID %>");

      function PageLoad() {
          // alert(chkEstimateArtwork);

          if (chkCustomDate1.checked == true) {
              txtCustomDate1.style.backgroundColor = "#FFFFFF";
              txtCustomDate1.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtCustomDate1.style.backgroundColor = "#F0F0F0";
              txtCustomDate1.style.cursor = "default";
              txtCustomDate1.readOnly = true;
          }

          if (chkCustomDate2.checked == true) {
              txtCustomDate2.style.backgroundColor = "#FFFFFF";
              txtCustomDate2.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtCustomDate2.style.backgroundColor = "#F0F0F0";
              txtCustomDate2.style.cursor = "default";
              txtCustomDate2.readOnly = true;
          }
          if (chkCustomDate3.checked == true) {
              txtCustomDate3.style.backgroundColor = "#FFFFFF";
              txtCustomDate3.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtCustomDate3.style.backgroundColor = "#F0F0F0";
              txtCustomDate3.style.cursor = "default";
              txtCustomDate3.readOnly = true;
          }
          if (chkCustomDate4.checked == true) {
              txtCustomDate4.style.backgroundColor = "#FFFFFF";
              txtCustomDate4.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtCustomDate4.style.backgroundColor = "#F0F0F0";
              txtCustomDate4.style.cursor = "default";
              txtCustomDate4.readOnly = true;
          }
          if (chkCustomDate5.checked == true) {
              txtCustomDate5.style.backgroundColor = "#FFFFFF";
              txtCustomDate5.readOnly = false;
              // document.getElementById('ctl00_ContentPlaceHolder1_txtDefaultEstimated').disabled = 'false';
          }
          else {
              txtCustomDate5.style.backgroundColor = "#F0F0F0";
              txtCustomDate5.style.cursor = "default";
              txtCustomDate5.readOnly = true;
          }
          applyCustomDate(chkEstimateArtwork, txtDefaultEstimated);
          applyCustomDate(chkEstimateProof, txtEstimateProof);
          applyCustomDate(chkEstimateApproval, TxtEstimateApproval);
          applyCustomDate(chkEstimateProduction, txtEstimateProduction);
          applyCustomDate(chkEstimateCompletion, txtEstimatedCompletion);
          applyCustomDate(chkEstimateDelivery, txtEstimateDelivery);

         



      }

      function applyCustomDate(chk, txt) {
          if (chk && chk.checked === true) {
              txt.style.backgroundColor = "#FFFFFF";
              txt.readOnly = false;
          } else {
              txt.style.backgroundColor = "#F0F0F0";
              txt.style.cursor = "default";
              txt.readOnly = true;
          }
      }

    

      function enableDisable(bEnable, textBoxID) {
          var textboxclientid = document.getElementById(textBoxID);
          var validatorId = textBoxID.replace('txt', 'RequiredFieldValidator');
          if (textBoxID.includes('DefaultEstimated')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator1';
          else if (textBoxID.includes('EstimateProof')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator2';
          else if (textBoxID.includes('EstimateApproval')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator3';
          else if (textBoxID.includes('EstimateProduction')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator4';
          else if (textBoxID.includes('EstimatedCompletion')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator5';
          else if (textBoxID.includes('EstimateDelivery')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator6';
          else if (textBoxID.includes('CustomDate1')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator7';
          else if (textBoxID.includes('CustomDate2')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator8';
          else if (textBoxID.includes('CustomDate3')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator9';
          else if (textBoxID.includes('CustomDate4')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator10';
          else if (textBoxID.includes('CustomDate5')) validatorId = 'ctl00_ContentPlaceHolder1_RequiredFieldValidator11';
          
          var validator = document.getElementById(validatorId);
          if (bEnable == true) {
              textboxclientid.style.backgroundColor = "#FFFFFF";
              textboxclientid.readOnly = false;
              if (validator) ValidatorEnable(validator, true);
          }
          else {
              textboxclientid.style.backgroundColor = "#F0F0F0";
              textboxclientid.style.cursor = "default";
              textboxclientid.readOnly = true;
              if (validator) ValidatorEnable(validator, false);
          }
      }

      function isValidEstimateValue(value) {
          // Only allow positive integers up to 3 digits
          var num = parseInt(value, 10);
          return !isNaN(num) && num >= 0 && value.length <= 3;
      }

      function validateEstimateFields() {
          var fields = [
              txtValidFor,
              txtDefaultEstimated,
              txtEstimateProof,
              TxtEstimateApproval,
              txtEstimateProduction,
              txtEstimatedCompletion,
              txtEstimateDelivery
          
          ];
          var isValid = true;
          for (var i = 0; i < fields.length; i++) {
              var val = fields[i].value.trim();
              if (val === "") {
                  fields[i].style.borderColor = 'red';
                  isValid = false;
              } else if (!isValidEstimateValue(val)) {
                  fields[i].style.borderColor = 'red';
                  isValid = false;
              } else {
                  fields[i].style.borderColor = '';
              }
          }
          return isValid;
      }

      function validateForm() {
          var isValid = true;
          // Validate all ASP.NET validators (still needed for integration)
          var validators = Page_Validators || [];
          for (var i = 0; i < validators.length; i++) {
              var validator = validators[i];
              if (validator.validationGroup == 'AddEstimate' && validator.enabled) {
                  ValidatorValidate(validator);
                  if (!validator.isvalid) {
                      isValid = false;
                  }
              }
          }

          // Extra JS validation for Artwork–Delivery fields
          if (!validateEstimateFields()) {
              isValid = false;
              alert('Minimum default day is 0.');
          }

          if (isValid) {
              javascript: loadingimage('ctl00_ContentPlaceHolder1_btnSave', 'div_btnsaveprocess');
              return true; // allow postback
          }
          return false; // block postback!
      }








      //function validateForm() {
      //    debugger;
      //    var isValid = true;
      //    var validators = Page_Validators;
          
      //    for (var i = 0; i < validators.length; i++) {
      //        var validator = validators[i];
      //        if (validator.validationGroup == 'AddEstimate' && validator.enabled) {
      //            ValidatorValidate(validator);
      //            if (!validator.isvalid) {
      //                isValid = false;
      //            }
      //        }
      //    }
          
      //    if (isValid) {
      //        javascript:loadingimage('ctl00_ContentPlaceHolder1_btnSave','div_btnsaveprocess');
      //        return true;
      //    }
      //    return false;
      //}
      
      window.onload = PageLoad();
    

  </script>
  
    <script src="../js/settings.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>

      <%--<script src="../js/settings.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
