<%@ Page Language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="UpdateJobStatusWithScanner.aspx.cs" Inherits="ePrint.Jobs.UpdateJobStatusWithScanner" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %> 



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%--<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList" TagPrefix="UC" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript" language="javascript" src="../js/item/ProductCatalogue.js"></script>--%>
    <script type="text/javascript" src="../js/jquery.scannerdetection.js?VN='<%#VersionNumber%>'"></script>
    
   <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lnk_loadCatagory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMenu1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdallocatedcustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Image_Attachment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <!--POPUP START-->
    <div>
        
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose" Top="115" Left="174"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" OnClientClose="bindUploadimgname"
                    Title="Category Image"  KeepInScreenBounds="true"
                    VisibleTitlebar="true" VisibleStatusbar="true" Modal="true" ShowContentDuringLoad="false"
                    Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
   <%-- <script type="text/javascript" src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'"
        language="javascript"></script>
    <script type="text/javascript" src="../js/Item/price_catalogue.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var DecimalValue = 0;
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);


    </script>--%>
    <div style="padding-top: 1%;">
        <div style="width: 100%;">
            <asp:Panel ID="Panel1" runat="server" class="div_prod_margin">
                <fieldset style="border:solid 1px #fff">
                    <legend class="HeaderText">
                       Scan The Job Item Number Then Scan The Status</legend>
                    <div align="left" style="width: 100%; padding: 0px; border: 0px solid red">
                        <div style="width: 65%;">
                            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 65%; padding: 10px;">
                        <div class="onlyEmpty" id="divitemcode" runat="server">
                            <div class="bglabel">
                                Scan Job Item No and Status
                                <span style="color: red">*</span>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:TextBox runat="server" ID="txtJobItemStatus" SkinID="textPad" Style="display: block;"
                                         Width="40%"></asp:TextBox>
                                    <span id="spn_accountName" style="display: none; width: auto; padding-left: 4px; padding-right: 4px" class="spanerrorMsg">
                                        Please Scan Job Item No and Status
                                    </span>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty" id="div_catagoryType" runat="server" visible="false">
                            <div class="bglabel">
                                <div style="float: left; width: 88%;">
                                    <%--<span><%=objlang.GetLanguageConversion("Allocate_Sub_Options")%></span>--%>
                                    Scan Job Item Status
                                    <span style="color: red">*</span>
                                </div>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:TextBox runat="server" ID="txtJobStatus" SkinID="textPad" Style="display: block;" Width="40%" ></asp:TextBox>
                                    <span id="Span1" style="display: none; width: auto; padding-left: 4px; padding-right: 4px" class="spanerrorMsg">
                                        Please Scan Job Status
                                    </span>                                    
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <%--<div align="left" style="float: left; width: 50%;">
                                <div align="left" class="onlyEmpty" style="height: 20px;">
                                    <div id="div_selectLnk" style="float: left; padding-left: 5px; padding-top: 3px;">
                                        <a id="Select" runat="server" href="javascript:void(0);">
                                            <%=objlang.GetLanguageConversion("Select") %></a>
                                    </div>
                                </div>
                            </div>--%>
                            <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_categoryName" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_fromflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_validateflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_finalvalues" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_iscopychecked" runat="server" Value="false" />
                            <asp:HiddenField ID="hdn_WebOtherCostIDs" runat="server" Value="" />
                            <asp:HiddenField ID="hid_Delete_IDs" runat="server" Value="" />
                            <%--optimization--%>
                            <asp:HiddenField ID="hdn_addoption_groupid" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_addoption_groupname" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_addoption_mode" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_SubCount" runat="server" Value="" />
                        </div>


                        <div class="onlyEmpty" style="padding-top: 10px;">
                            <div class="bglabel" style="visibility: hidden">
                                &nbsp;
                            </div>
                            <div class="box" style="visibility:hidden">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_cancel" style="display: block">
                                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="" Style="padding-top: 3px;"
                                            OnClick="btnCancel_Click" CommandName="Cancel" CausesValidation="false" OnClientClick="javascript:return loadingimage(this.id,'div_cancelprocess');"></asp:Button>
                                        
                                    </div>
                                    <div id="div_cancelprocess" class="button" align="center" style="width: 38px; height: 14px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div id="Divdiv_btnsave" runat="server" style="display: inline; float: left">
                                    <div id="div_btnsave" style="display: block"> 
                                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="" Style="padding-top: 3px;"  OnClientClick="javascript:var a=txtValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                            OnClick="btnSave_Click"></asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset id="Hidefieldset" runat="server" style="border:solid 1px #fff">
                    <legend class="HeaderText">Scanned Job Items and Status</legend>
                    <div id="div_Resize" align="left" style="width: 80%; display: block">
                        <div align="left" style="padding: 0px 0px 0px 10px;">
                            <div style="width: 65%">
                                <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage_Delete" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        
                        <div>
                            <div id="div_popupAction" style="display: none; z-index: 999999; width: 130px; position: absolute; margin: 66px 0px 0px 20px" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete Selected" CommandName="Delete"
                                                        CausesValidation="false" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                        OnClick="btnDelete_OnClick"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 100%;">

                                <div style="clear: both">
                                </div>
                                <div align="left" style="padding-top: 10px; padding-left: 10px; width: 100%;">
                                    <div id="div_Main" runat="server">
                                        <div id="div_Grid">
                                            <telerik:RadGrid ID="GridView1" runat="server" AllowFilteringByColumn="true" AllowPaging="true"
                                                AllowSorting="true" AutoGenerateColumns="false" GridLines="None" GroupingEnabled="false"
                                                 OnItemDataBound="OnRowDataBound_GridView1"
                                                HeaderStyle-Font-Bold="true" AllowCustomPaging="false" Width="100%"
                                                PagerStyle-CssClass="RadComboBox_Eprint_Skin" PageSize="50" ShowGroupPanel="false"
                                                ShowStatusBar="true">
                                                <GroupingSettings CaseSensitive="false" />
                                                <%--<HeaderStyle Width="100px" />--%>
                                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                <PagerStyle Mode="NextPrevAndNumeric" />
                                                <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" HorizontalAlign="NotSet"
                                                    OverrideDataSourceControlSorting="true" Width="100%" PagerStyle-AlwaysVisible="true">
                                                    <CommandItemTemplate>
                                                        <table border="0" class="rgCommandTable" style="width: 100%;">
                                                            <tr>
                        
                                                                <td align="right">
                                                                    <asp:LinkButton ID="btnclrFilters" runat="server" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                                                                        Text=""><%=objlang.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                                                                                
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="JobItemNumber"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Job Item Number"
                                                            ItemStyle-Width="20%" SortExpression="JobItemNumber" UniqueName="JobItemNumber"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                    <div style="float: left; width: 99%; height: auto">
                                                                    <asp:label id="lblgroupname" runat = "server" Text= '<%#Eval("JobItemNumber")%>'>  </asp:label>   
                                                                    </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="ItemStatusTitle"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Job Item Status"
                                                            ItemStyle-Width="20%" SortExpression="ItemStatusTitle" UniqueName="ItemStatusTitle"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>                                                               
                                                                <div style="float: left; width: 99%; height: auto">
                                                                <asp:label id="Label1" runat = "server" Text= '<%#Eval("ItemStatusTitle")%>'>  </asp:label>   
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="DateTime"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Date Time"
                                                            ItemStyle-Width="20%" SortExpression="DateTime" UniqueName="DateTime"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>                                                               
                                                                <div style="float: left; width: 99%; height: auto">
                                                                <asp:label id="Label2" runat = "server" Text= '<%#Eval("DateTime")%>'>  </asp:label>   
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="CustomerName"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Customer Name"
                                                            ItemStyle-Width="20%" SortExpression="CustomerName" UniqueName="CustomerName"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>                                                               
                                                                <div style="float: left; width: 99%; height: auto">
                                                                <asp:label id="Label3" runat = "server" Text= '<%#Eval("CustomerName")%>'>  </asp:label>   
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="ItemTitle"
                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Item Title"
                                                            ItemStyle-Width="30%" SortExpression="ItemTitle" UniqueName="ItemTitle"
                                                            Visible="true" AutoPostBackOnFilter="true">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>                                                               
                                                                <div style="float: left; width: 99%; height: auto">
                                                                <asp:label id="Label4" runat = "server" Text= '<%#Eval("ItemTitle")%>'>  </asp:label>   
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView><ClientSettings AllowColumnsReorder="false" AllowDragToGroup="false"
                                                    ReorderColumnsOnClient="true" EnableRowHoverStyle="true">
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="onlyEmpty" style="padding-top: 10px;">
                            <div class="bglabel" style="visibility: hidden">
                                &nbsp;
                            </div>
                            <div class="box">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div1" style="display: none">
                                        <asp:Button ID="btnSaveStay" CssClass="button" runat="server" Text="Save All" Style="padding-top: 3px;"
                                            CommandName="Cancel" CausesValidation="false" OnClientClick="javascript:return loadingimage(this.id,'div_savestay');" OnClick="btnSaveStay_Click" ></asp:Button>
                                        
                                    </div>
                                    <div id="div_savestay" class="button" align="center" style="width: 38px; height: 14px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div id="Div3" runat="server" style="display:none; float: left">
                                    <div id="div4" style="display: block">
                                        <asp:Button ID="btnSaveAll" CssClass="button" runat="server" Text="Save & Stay" Style="padding-top: 3px;" OnClientClick="javascript:return loadingimage(this.id,'div_saveall');"
                                             OnClick="btnSaveAll_Click" ></asp:Button>
                                    </div>
                                    <div id="div_saveall" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                                <div style="clear: both">
                                    &nbsp;
                                </div>
                                
                            </div>
                        </div>
                </fieldset>
                &nbsp;&nbsp;
            </asp:Panel>
            
             
        </div>
    </div>
   
    <%--<script type="text/javascript" language="javascript">
         $('#<%=txtJobItemStatus.ClientID %>').keydown(function (e) {
             debugger;
             var code = (e.keyCode ? e.keyCode : e.which);
             if (code == 13) { //Enter keycode
                 //$('#<%=txtJobStatus.ClientID %>').focus();
                 __doPostBack('<%=btnSave.UniqueID%>', "");
             }
             //else if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105) || (code == 8) || (code >= 37 && code <= 40) || (code == 46))
             //        return true;
             else if (code > 0) {
                 var x = $('#<%=txtJobItemStatus.ClientID %>').val();
                 //$('#txtJobItemStatus').val(addCommas(x));
                 return true;
             }
             else
                 return false;
         });
        function addCommas(x) {
            var item = x.toString() + ',';
            return item;
            //var parts = x.toString().split(".");
            //parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            //return parts.join(".");
        }


    </script>--%>  
   <%-- <script type="text/javascript">
        $('#txtJobItemStatus').keypress(function () {
            var txtVal = this.value;
            $("#txtJobItemStatus").text("You have entered " + txtVal);
        });
</script>--%>
     <%--<script type="text/javascript" language="javascript">
         $(window).ready(function () {
             debugger;
             $(window).scannerDetection();
             $(window).bind('scannerDetectionComplete', function (e, data) {
                 console.log('complete ' + data.string);
                 $("#txtJobItemStatus").val(data.string);
             })
             .bind('scannerDetectionError', function (e, data) {
                 console.log('detection error ' + data.string);
             })
             .bind('scannerDetectionReceive', function (e, data) {
                 console.log('Recieve');
                 console.log(data.evt.which);
             })
         });
     </script>--%>
     <script type="text/javascript" language="javascript">
         $(document).scannerDetection({
             timeBeforeScanTest: 200, // wait for the next character for upto 200ms
             startChar: [120], // Prefix character for the cabled scanner (OPL6845R)
             endChar: [13], // be sure the scan is complete if key 13 (enter) is detected
             avgTimeByChar: 40, // it's not a barcode if a character takes longer than 40ms
             onComplete: function (barcode, qty) {
                 debugger;
                 
                 var cur_val = $('#<%=txtJobItemStatus.ClientID %>').val();
                 if (cur_val) {
                     $('#<%=txtJobItemStatus.ClientID %>').val(cur_val + ",");
                     $('#<%=txtJobItemStatus.ClientID %>').focus();
                 }
                 else
                     $('#<%=txtJobItemStatus.ClientID %>').val(barcode);

                 //if ($(this).val().length === 0) { $("#results").html(""); return false };
                 var isAlphaNumeric = ctype_alnum(barcode);
                 if (!isAlphaNumeric)
                 {
                     if (ctype_alpha)
                     {
                         __doPostBack('<%=btnSave.UniqueID%>', "");
                     }
                 }
                 
                 //alert(isAlphaNumeric);
                 //var result = '';
                 //result += barcode + ',';
                 
                 //barcode += barcode + ',';
                 //$('#<%=txtJobItemStatus.ClientID %>').val().append(',');
                 //console.log('complete ' + barcode.string);
                 //$("#txtJobItemStatus").val(barcode.string + ',');
                 //$('#<%=txtJobItemStatus.ClientID %>').val(barcode + ',');
                 //barcode = barcode + ',';
               //  alert('barcode scanner found')
             } // main callback function
             
         });

         function ctype_alnum(str) {
             var code, i, len;
             var isNumeric = false, isAlpha = false; //I assume that it is all non-alphanumeric

             loop1:
                 for (i = 0, len = str.length; i < len; i++) {
                     code = str.charCodeAt(i);


                     switch (true) {
                         case code > 47 && code < 58: // check if 0-9
                             isNumeric = true;
                             break;
                         case (code > 64 && code < 91) || (code > 96 && code < 123): //check if A-Z or a-z
                             isAlpha = true;
                             break;
                         //default: // not 0-9, not A-Z or a-z
                         //    return false; //stop function with false result, no more checks

                     }

                 }

             return isNumeric && isAlpha; //return the loop results, if both are true, the string is certainly alphanumeric
         };
         function ctype_alpha(str) {
             var code, i, len;
             var isNumeric = false, isAlpha = false; //I assume that it is all non-alphanumeric

             loop1:
                 for (i = 0, len = str.length; i < len; i++) {
                     code = str.charCodeAt(i);


                     switch (true) {
                         case code > 47 && code < 58: // check if 0-9
                             isNumeric = true;
                             break;
                         case (code > 64 && code < 91) || (code > 96 && code < 123): //check if A-Z or a-z
                             isAlpha = true;
                             break;
                             //default: // not 0-9, not A-Z or a-z
                             //    return false; //stop function with false result, no more checks

                     }

                 }

             return  isAlpha; //return the loop results, if both are true, the string is certainly alphanumeric
         };
     </script>
    <script type="text/javascript" language="javascript">
        $('#<%=txtJobStatus.ClientID %>').keydown(function (e) {
            debugger;
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) { //Enter keycode
                __doPostBack('<%=btnSave.UniqueID%>', "");
            }
            else if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105) || (code == 8) || (code >= 37 && code <= 40) || (code == 46))
                return true;
            else
                return false;
        });
    </script>
    <script type="text/javascript" language="javascript">
        function txtValidation() {
            debugger;
            var Actiontype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value;
            var txtJobItemStatus = document.getElementById("<%=txtJobItemStatus.ClientID %>");
            CheckFinal = false;
            if (txtJobItemStatus.value == "" || trim12(txtJobItemStatus.value) == "") {
                document.getElementById("spn_accountName").style.display = "block";
                //txtEstimateItemID.focus();
                CheckFinal = true;
            }
            var HdnID = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>");
            var CustumerCount = document.getElementById("<%=hdn_SubCount.ClientID %>").value
            var Mode = document.getElementById("<%=hdn_addoption_mode.ClientID %>").value
            if (Mode == "edit") {
                if (CustumerCount == '0') {
                    if (HdnID.value == "" || trim12(HdnID.value) == "") {
                        alert("Please select Sub Options to save this Additional Option Group");
                        CheckFinal = true;
                    }
                }
            }
            else {
                if (HdnID.value == "" || trim12(HdnID.value) == "") {
                    alert("Please select Sub Options to save this Additional Option Group");
                    CheckFinal = true;
                }
            }
            if (Actiontype == '' || Actiontype == 'add' || Actiontype == 'edit') {
                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }

        }
    </script>
     <%--<script type="text/javascript" language="javascript">
         function submitButton(event) {
             debugger;
             if (event.which == 13) {
                 $('#btnSave').trigger('click');
             }
         }
    </script>--%>  
    <%--<script type="text/javascript" language="javascript">

        var categoryID = '<%=PriceCatalogueGroupID %>';
        var checkBoxID = '';
        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");

        // Check for Browser Name (If IE Browser then change style) BY 018
        function checkBrowserName() {
            if (navigator.appName.toLowerCase() == 'microsoft internet explorer') {
                document.getElementById("div_popupAction").style.margin = "100px 0px 0px 17px"
            }
        }
        checkBrowserName();

        function EraseCheck() {
            return window.confirm('Are you sure you want to delete this record?');
        }
        function CallDelete() {

            var ret = CheckOne();
            if (ret) {
                var IDs = '';
                var frm = document.getElementById("<%=GridView1.ClientID %>").getElementsByTagName("input");
                var i = 1;
                for (l = 0; l < frm.length; l++) {
                    if (frm[l].id.indexOf('checkBox_Copy1') != -1) {
                        if (frm[l].checked) {
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }
                document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = IDs;
                return true;
            }
            else {
                return false;
            }
        }
        function CheckOne() {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Copy1') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');
                //  return true;
            }
        }

        var CheckFinal = false;
        function txtValidation() {
            var Actiontype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value;
            var txtJobId = document.getElementById("<%=txtJobId.ClientID %>");
            CheckFinal = false;
            if (txtJobId.value == "" || trim12(txtJobId.value) == "") {
                document.getElementById("spn_accountName").style.display = "block";
                txtJobId.focus();
                CheckFinal = true;
            }
            var HdnID = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>");
            var CustumerCount = document.getElementById("<%=hdn_SubCount.ClientID %>").value
            var Mode = document.getElementById("<%=hdn_addoption_mode.ClientID %>").value
            if (Mode == "edit") {
                if (CustumerCount == '0') {
                    if (HdnID.value == "" || trim12(HdnID.value) == "") {
                        alert("Please select Sub Options to save this Additional Option Group");
                        CheckFinal = true;
                    }
                }
            }
            else {
                if (HdnID.value == "" || trim12(HdnID.value) == "") {
                    alert("Please select Sub Options to save this Additional Option Group");
                    CheckFinal = true;
                }
            }
            if (Actiontype == '' || Actiontype == 'add' || Actiontype == 'edit') {
                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }

        }

        function show() {
            img_actionsHide.style.display = "block";
            img_actionsShow.style.display = "none";

            div_chk.style.border = "inset 1px";
            div_chk.style.background = "#CBCBCB";

            div_popupAction.style.display = "block";
        }

        function hide() {
            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";

            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";

            div_popupAction.style.display = "none";
        }

        function Show_CopyAccountsDiv() {
            hide();
            showDivPopupCenter('div_CopyAccounts', '220');
        }



        function checkAll_new(checkAllBox) {
            checkBoxID = 'checkBox_Copy';
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(checkBoxID) != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }


        function openPopUp(PriceCatalogueGroupID, action, Name) {
            var txtJobId = document.getElementById("<%=txtJobId.ClientID %>");
            if (txtJobId.value == "" || trim12(txtJobId.value) == "") {
                alert("Please enter Additional Option Group name");
            }
            else {
                window.radopen(path + "ProductCatalogue/ProductCatalogueSubAdditionOption_Allocation.aspx?id=" + PriceCatalogueGroupID + "&action=" + action + "&Name=" + Name);
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }

        function clearCookie(name) {
            var date = new Date();
            date.setDate(date.getDate() - 1);
            document.cookie = name + "=''; expires=" + date + "; path=/";
            // alert('Successfully erased Cookie ' + name);
        }

        function readCookie(name) {
            return (name = new RegExp('(?:^|;\\s*)' + ('' + name).replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&') + '=([^;]*)').exec(document.cookie)) && name[1];
        }


        function OnClientPageLoad(sender, args) {
            if (contentCell && loadingSign) {
                contentCell.removeChild(loadingSign);
                contentCell.style.verticalAlign = "";
                loadingSign.style.display = "none";
            }
        }
        //optimization
        var groupname_ongridclick = '';
        var groupid_ongridclick = '0';
        var groupmode_ongrdclick = 'add';
        function Additions_options_group_edit(JobItemNumber, groupid, SubCount) {
            document.getElementById("<%=txtJobId.ClientID %>").value = SpecialDecode(JobItemNumber);
            document.getElementById("<%=hdn_addoption_groupid.ClientID %>").value = groupid;
            document.getElementById("<%=hdn_addoption_groupname.ClientID %>").value = JobItemNumber;
            document.getElementById("<%=hdn_addoption_mode.ClientID %>").value = 'edit';
            document.getElementById("<%=hdn_SubCount.ClientID %>").value = SubCount;
        }

        function openPopUp1(groupid_ongridclick, groupmode_ongrdclick, groupname_ongridclick) {
            groupid_ongridclick = document.getElementById("<%=hdn_addoption_groupid.ClientID %>").value;
            groupname_ongridclick = document.getElementById("<%=hdn_addoption_groupname.ClientID %>").value
            groupmode_ongrdclick = document.getElementById("<%=hdn_addoption_mode.ClientID %>").value;
            groupname_ongridclick = SpecialEncode(groupname_ongridclick);

            if (groupmode_ongrdclick == "") {
                groupmode_ongrdclick = 'add';
            }
            if (groupid_ongridclick == "") {
                groupid_ongridclick = '0';
            }
            var txtJobId = document.getElementById("<%=txtJobId.ClientID %>");
            if (txtJobId.value == "" || trim12(txtJobId.value) == "") {
                alert("Please enter Additional Option Group name");
            }
            else {
                window.radopen(path + "ProductCatalogue/ProductCatalogueSubAdditionOption_Allocation.aspx?id=" + groupid_ongridclick + "&action=" + groupmode_ongrdclick + "&Name=" + groupname_ongridclick);
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
        function SpecialEncode(OriginalString) {
            OriginalString = OriginalString.split("'").join('%27');
            OriginalString = OriginalString.split('"').join('%22');
            return OriginalString;
        }
        function SpecialDecode(OriginalString) {
            OriginalString = OriginalString.split('%27').join("'");
            OriginalString = OriginalString.split('%22').join('"');
            return OriginalString;
        }
    </script>--%>

</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>--%>

