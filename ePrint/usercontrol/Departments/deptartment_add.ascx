<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="deptartment_add.ascx.cs" Inherits="ePrint.usercontrol.Departments.deptartment_add" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
    rel="stylesheet" />
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" language="javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<style type="text/css">
    .ui-accordion .ui-accordion-content {
        padding: 1em 0.3em !important;
        border-top: 1px solid #AAAAAA !important;
    }
</style>
<script type="text/javascript">
    var asyncState = true;
    XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
    XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
        async = asyncState;
        var eventArgs = Array.prototype.slice.call(arguments);
        return this.original_open.apply(this, eventArgs);
    }

    $(document).ready(function () {

        $(function () {
            $("#accordion").accordion({
                header: "h4", collapsible: true, autoHeight: false
            });
            $("#accordion span").click(function (event) {
                event.stopImmediatePropagation();
                event.preventDefault();
            });
            var accordionindex = 1000;

            $("#accordion").accordion();

            if (accordionindex == 0) {
                $("#accordion").accordion();
            }
            else {
                $("#accordion").accordion();
                $("#accordion").accordion('activate', accordionindex);

            }

        });
    });

</script>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="content" style="width: 100%">
    <div align="left" style="float: left; width: 99.8%;">
        <div style="float: left; width: 98%;">
            <div id="div_DeptEdit" runat="server" style="float: left; width: 103%; display: block;">
                <div id="div_Dept" style="float: left; width: 100%;">
                    <div style="float: left; width: 50%;">
                        <div align="left">
                            <div style="width: 132px;" class="bglabel">
                                <asp:Label ID="lbl_DeptName" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Department_Name")%>
                                <span style="color:red">*</span></asp:Label>
                            </div>
                            <div class="box" style="padding: 0 0 2 4px;">
                                <asp:TextBox ID="txtDeptName" runat="server" CssClass="textboxnew" MaxLength="230"
                                    Rows="2" Width="250px" onblur="javascript:checkDeptDuplicacy(this.value);" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                <span id="spanDeptName" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">
                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Department_Name")%>
                                </span>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>

                        <div align="left">
                            <div style="width: 132px;" class="bglabel">
                                <asp:Label ID="lblAddressLabelCaption" runat="server" CssClass="normaltext" Text="Address Label"></asp:Label>
                            </div>
                            <div class="box" style="padding: 0 0 2 4px;">
                                <asp:Label ID="lblAddressLabel" runat="server" CssClass="normaltext"
                                    Width="240px" Style="display: none; height: 15px; overflow: hidden;"></asp:Label>

                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>


                        <div id="div_ShippingAddressInfo" align="left" style="display: block; border: 0px solid red;">
                            <div align="left">
                                <div style="width: 132px;" class="bglabel">
                                    <asp:Label ID="lbl_DeptShippingAddressInfo" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                    <div style="float: right; display: none">
                                        <asp:ImageButton Style="vertical-align: middle" ID="ImageButton2" runat="server"
                                            CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Address"
                                            OnClientClick="javascript:opencontacts('address','addsh');return false;" />
                                    </div>
                                    <asp:HiddenField ID="hdnShippingAddressID" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnShippingAddressType" runat="server" />
                                </div>
                                <div class="box">
                                    <div id="div_DeptShippingAddress" style="height: auto;">
                                        <div id="div_DeptShippingAddress1" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingAddress1" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingAddress2" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingAddress2" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingAddress3" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingAddress3" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingAddress4" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingAddress4" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingAddress5" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingAddress5" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingCountry" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingCountry" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingTelephone" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingTelephone" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                        <div id="div_DeptShippingFax" runat="server" style="display: none; height: 20px">
                                            <asp:Label ID="lbl_DeptShippingFax" runat="server" CssClass="normaltext" Width="240px"
                                                Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                        </div>
                                    </div>
                                    <div id="div_changeShipping" runat="server" style="float: left; display: block;">
                                        <div id="Divlnk_ShippingEdit" runat="server" style="float: left; padding: 0px 2px 0px 0px">
                                            <asp:LinkButton ID="lnk_ShippingEdit" runat="server" Text="Edit" OnClick="lnk_ShippingEdit_OnClick"></asp:LinkButton>
                                        </div>
                                        <div style="float: left; padding: 0px 2px 0px 2px">
                                            <asp:Label ID="lbl_ShippingSpliter" runat="server" Text="|"></asp:Label>
                                        </div>
                                        <div id="DivChangeNewAddress" runat="server" style="float: left; padding: 0px 2px 0px 0px">
                                            <asp:LinkButton ID="lbl_ShippingChange" runat="server" Text="Change/New Address"
                                                OnClick="lbl_ShippingChange_OnClick"></asp:LinkButton>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdn_DeptShippingAddressInfo" runat="server" />
                                </div>
                                <div class="onlyEmpty">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 40%; margin-left: 2.3%;">
                        <%--changed design for development 13394--%>
                        <div style="width: 100%;" id="div_Invoice" runat="server">
                            <div style="float: left; display: inline">
                                <div class="bglabel" style="width: 132px">
                                    <asp:Label ID="Label2" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Invoice_Contact")%></asp:Label>
                                </div>
                                <div class="box" style="padding: 0 0 2 4px;">
                                    <asp:DropDownList ID="ddlInvoiceContact" Width="200px" runat="server">
                                    </asp:DropDownList>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>

                        <div align="left">
                            <div style="width: 132px;" class="bglabel">
                                <asp:Label ID="lblAddressLabel_Inv_Caption" runat="server" CssClass="normaltext" Text="Address Label"></asp:Label>
                            </div>
                            <div class="box" style="padding: 0 0 2 4px;">
                                <asp:Label ID="lblAddressLabel_Inv" runat="server" CssClass="normaltext"
                                    Width="240px" Style="display: none; height: 15px; overflow: hidden;"></asp:Label>

                            </div>
                            <div class="onlyEmpty">
                            </div>
                        </div>

                        <div align="left">
                            <div class="bglabel" style="display: none;">
                                <asp:Label ID="lbl_DeptDefaultContact" runat="server" CssClass="normaltext">Default Contact</asp:Label>
                                <div style="float: right">
                                    <asp:ImageButton Style="vertical-align: middle" ID="ImgCustomerAdd" runat="server"
                                        CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Contact"
                                        OnClientClick="javascript:opencontacts('contact','view');return false;" />
                                </div>
                            </div>
                            <div class="box" style="padding: 0 0 2 4px; display: none;">
                                <asp:TextBox ID="txt_DeptDefaultContact" runat="server" CssClass="textboxnew" Rows="2"
                                    Width="250px"></asp:TextBox>
                                <asp:HiddenField ID="hdn_DefaultContactID" runat="server" />
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_AddressInfo" align="left" style="display: block; border: 0px solid green; margin: 0px 0px 0px 0px">
                                <div align="left">
                                    <div class="bglabel" style="width: 132px;">
                                        <asp:Label ID="lbl_DeptAddressInfo" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                        <div style="float: right; display: none">
                                            <asp:ImageButton Style="vertical-align: middle" ID="ImageButton1" runat="server"
                                                CausesValidation="False" ImageUrl="~/images/plus.gif" ToolTip="Add New Address"
                                                OnClientClick="javascript:opencontacts('address','add');return false;" />
                                        </div>
                                        <asp:HiddenField ID="hdnAddressID" runat="server" Value="0" />
                                        <asp:HiddenField ID="hdnAddressType" runat="server" />
                                    </div>
                                    <div class="box" style="padding: 3px 0px 10px 5px;">
                                        <div id="div_invoiceAddress" style="height: auto;">
                                            <div id="div_DeptAddress1" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptAddress1" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptAddress2" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptAddress2" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptAddress3" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptAddress3" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptAddress4" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptAddress4" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptAddress5" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptAddress5" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptCountry" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptCountry" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptTelephone" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptTelephone" runat="server" CssClass="normaltext" Width="240px"
                                                    Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                            <div id="div_DeptFax" runat="server" style="display: none; height: 20px">
                                                <asp:Label ID="lbl_DeptFax" runat="server" CssClass="normaltext" Width="240px" Style="display: none; height: 15px; overflow: hidden;"></asp:Label>
                                            </div>
                                        </div>
                                        <div id="DivEditHis" runat="server">
                                            <div id="div_change" style="float: left; display: block;">
                                                <div id="DivEdit" runat="server" style="float: left; padding: 0px 2px 0px 0px">
                                                    <asp:LinkButton ID="lnk_Edit" runat="server" Text="Edit" OnClick="lnk_Edit_OnClick"></asp:LinkButton>
                                                    <asp:Label ID="lbl_Spliter" runat="server" Text="|"></asp:Label>
                                                </div>
                                                <div id="DivChangeAddress" runat="server" style="float: left; padding: 0px 2px 0px 0px">
                                                    <asp:LinkButton ID="lnk_Change" runat="server" Text="Change/New Address" OnClick="lbl_Change_OnClick"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdn_DeptAddressInfo" runat="server" />
                                    </div>
                                    <div class="onlyEmpty">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--- added by rakshith --%>
                <div id="div_costcentrefields" runat="server" style="width: 100%;">
                    <div style="float: left; display: inline">
                        <div class="bglabel" style="width: 132px">
                            <asp:Label ID="lbldefault" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Default_Cost_Centre")%></asp:Label>
                        </div>
                        <div class="box">
                            <asp:DropDownList ID="ddlcostcenter" Width="250px" runat="server">
                            </asp:DropDownList>
                            <br />
                        </div>
                    </div>
                    <%-- <div class="box" style="float: right; display: inline; margin-left: -38px">
                        <div class="bglabel" style="width: 132px; height: 50px">
                            <asp:Label ID="lblallowcc" runat="server" Style="width: 120px" CssClass="bglabel"><span class="normaltext" ><%=objLangClass.GetLanguageConversion("cost_centres_this_departments_staff_can_use")%></span></asp:Label>
                        </div>
                        <div class="box" style="width: 68%">
                            <asp:RadioButton ID="rdbnotallow" runat="server" Checked="true" GroupName="cstcntrgroup"
                                Text="Don't allow users to change the default cost centre." /><br />
                            <asp:RadioButton ID="rdball" Text="Users can select from all cost centres." runat="server"
                                GroupName="cstcntrgroup" Style="margin-bottom: 3px" /><br />
                            <asp:RadioButton ID="rdbonlyselected" Text="Users only see cost centres selected below."
                                runat="server" GroupName="cstcntrgroup" Style="margin-bottom: 3px" /><br />
                            <asp:ListBox ID="lstcostcenters" runat="server" SelectionMode="Multiple" Width="200px"
                                Style="margin-left: 23px; margin-top: 5px"></asp:ListBox>
                        </div>
                    </div>--%>
                    <div style="float: right; display: inline; width: 390px; margin-right: 7.5%">
                        <%--- Changed Design for development 13394 --%>
                        <div align="left" id="DivApprover" runat="server">
                            <div class="bglabel" style="width: 132px;">
                                <asp:Label ID="Label1" runat="server" CssClass="normaltext"></asp:Label>
                            </div>
                            <div class="box" style="padding: 0 0 2 4px;">
                                <asp:DropDownList ID="ddlContacts" Width="198px" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--- End --%>
                        <div id="div_deptapproval" runat="server">
                            <div class="bglabel div_deptapproval" style="height: 42px;">
                                <asp:Label ID="lbldeptapproval" runat="server" CssClass="normaltext">  
                            <%=objLangClass.GetLanguageConversion("Department_does_not_require_approval")%></asp:Label>
                            </div>
                            <div style="float: left;">
                                <asp:CheckBox ID="chkdeptnotapproval" runat="server" />
                            </div>
                            <div class="DeptDefaultSettingsbox">
                                <span class="smallgraytext">
                                    <%=objLangClass.GetLanguageConversion("This_option_applies_only_when_approval_system_is_on_for_b2b")%></span>
                            </div>
                        </div>
                        <%--Department Image Upload--%>
                        <div style="width: 100%;" id="div1" runat="server">
                            <div style="float: left; display: inline">
                                <div class="bglabel" style="width: 132px; height: 18px;">
                                    <asp:Label ID="lblDeptImage" runat="server" CssClass="normaltext"><%=objLangClass.GetLanguageConversion("Department_Image")%></asp:Label>
                                </div>
                                <div class="box">
                                    <asp:FileUpload ID="ImageUpload" Width="200px" runat="server" CssClass="textboxnew"
                                        BorderStyle="None" />
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                        ControlToValidate="ImageUpload" ValidationGroup="Test"></asp:CustomValidator>
                                    <div id="DivClear" runat="server" style="margin-top: -20px; margin-left: 210px;">
                                        <a id="FileTextClear" runat="server" href="#" style="display: none; text-decoration: underline; cursor: pointer; padding-left: 5px;"
                                            onclick="javascript:FileUploadClearText(); return false;">
                                            <%=objLangClass.GetLanguageConversion("Clear") %></a>
                                    </div>
                                    <div id="ContactImage" runat="server" align="left" style="cursor: pointer; margin-top: 22px; display: none;">
                                        <div style="line-height: 150%">
                                            <asp:Label ID="lblContactImage" runat="server" CssClass="Normaltext"></asp:Label><%--Style="display: none;"--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--Department Image Upload--%>
                        <span id="Spn_ImageUploadFile" class="spanerrorMsg" style="display: none; width: 277px; white-space: nowrap; margin-left: 145px;">
                            <%=objLangClass.GetLanguageConversion("Please_upload_only_Jpeg_PDF") %>
                        </span>
                        <div style="float: left; padding-left: 6px; padding-top: 2px;">
                            <div>
                                <asp:Label runat="server" ID="lblImgguidance"><b><%=objLanguage.GetLanguageConversion("Image_guide_lines")%></b></asp:Label>
                            </div>
                            <div>
                                <asp:Label runat="server" class="smallgraytext" ID="Label15"><%=objLanguage.GetLanguageConversion("Please_upload_JPEG_or_PNG_file")%></asp:Label><br />
                                <asp:Label runat="server" class="smallgraytext" ID="Label16"><%=objLanguage.GetLanguageConversion("PDF_singlePage")%></asp:Label><br />
                                <asp:Label runat="server" class="smallgraytext" ID="Label18"><%=objLanguage.GetLanguageConversion("PDF_files_Background")%></asp:Label><br />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="Costcenter" runat="server" class="box" style="float: left; display: inline; width: 51%; margin-left: -3px;">
                    <div class="bglabel" style="width: 132px; height: 42px; margin-top: -1px;">
                        <asp:Label ID="lblallowcc" runat="server" Style="width: 120px; margin-top: -5px; margin-left: -5px;"
                            CssClass="bglabel"><span class="normaltext" ><%=objLangClass.GetLanguageConversion("cost_centres_this_departments_staff_can_use")%></span></asp:Label>
                    </div>
                    <div class="box" style="width: 65%; margin-left: -3px;">
                        <asp:RadioButton ID="rdbnotallow" runat="server" Checked="true" GroupName="cstcntrgroup"
                            Text="Don't allow users to change the default cost centre." /><br />
                        <asp:RadioButton ID="rdball" Text="Users can select from all cost centres." runat="server"
                            GroupName="cstcntrgroup" Style="margin-bottom: 3px" /><br />
                        <asp:RadioButton ID="rdbonlyselected" Text="Users only see cost centres selected below."
                            runat="server" GroupName="cstcntrgroup" Style="margin-bottom: 3px" /><br />
                        <asp:ListBox ID="lstcostcenters" runat="server" SelectionMode="Multiple" Width="200px"
                            Rows="6" Style="margin-left: 23px; margin-top: 5px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:ListBox>
                    </div>
                </div>
                <div id="div_Territory_Manager_Email" runat="server" class="box" style="float: left; display: none; width: 51%; margin-left: -3px;">
                    <div id="div_lblTerritory_Manager_Email" class="bglabel" style="width: 132px; height: 42px; margin-top: -1px;">
                        <asp:Label ID="lblTerritory_Manager_Email" runat="server" Style="width: 120px; margin-top: -5px; margin-left: -5px;"
                            CssClass="bglabel"><span class="normaltext" ><%=objLangClass.GetLanguageConversion("Territory_Manager_Email")%></span></asp:Label>
                    </div>
                    <div id="div_txtTerritory_Manager_Email" class="box" style="width: 65%; margin-left: 0px;">
                        <asp:TextBox ID="txtTerritory_Manager_Email" runat="server" CssClass="textboxnew" Width="250px">
                        </asp:TextBox>
                        <div>
                            <asp:Label runat="server" class="smallgraytext" ID="lbl_Territory_Manager_Email_Notification"><%=objLanguage.GetLanguageConversion("Territory_Manager_Email_Notification")%></asp:Label><br />
                        </div>
                    </div>
                </div>
                <div class="only10px">
                </div>
                <div id="accordion">
                    <h4>
                        <a href='#'><b style="color: Black">
                            <%=objLangClass.GetLanguageConversion("Additional_Information")%></b></a>
                    </h4>
                    <div style="display: none;">
                        <table cellpadding="2" cellspacing="2">
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom1" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc1" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom9" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc9" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom2" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc2" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom10" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc10" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom3" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc3" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom11" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc11" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom4" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc4" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom12" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc12" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom5" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc5" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom13" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc13" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom6" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc6" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom14" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc14" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom7" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc7" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom15" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc15" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="bglabel_dept" valign="top">
                                    <div>
                                        <asp:Label ID="lblcustom8" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td valign="top" class="dept_customfield_td">
                                    <asp:TextBox ID="txtc8" runat="server" CssClass="textboxnew" Width="250px" onKeydown="Javascript: if(event.keyCode==13) return false;"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="dept_div_margin">
                    <span class="smallgraytext">
                        <%=objLangClass.GetLanguageConversion("These_custom_fields_can_appear_as_default_content")%>
                    </span>
                </div>
                <div align="left" style="float: left; width: 100%; margin: 10px 0px 0px 0px">
                    <div style="float: left; width: 66%">
                        &nbsp;
                    </div>
                    <div id="div_cancel" runat="server" style="float: left; display: none; margin: 0px 10px 0px 0px;">
                        <div id="div_btncancel" style="display: block">
                            <asp:Button ID="btncancel" runat="server" Text="" CssClass="button" OnClick="btnCancel_Onclick"
                                OnClientClick="javascript:loadingimg('div_btncancel','div_cancelprocess');" />
                        </div>
                        <div id="div_cancelprocess" class="button" align="center" style="width: 35px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                    <div id="div_add" runat="server" style="float: left; display: block">
                        <div id="div_btnadd" style="display: block">
                            <asp:Button ID="btnadd" runat="server" Text="Save" CssClass="button" OnClick="btnadd_Onclick"
                                OnClientClick="javascript:var a=validate('save');if(a)loadingimg('div_btnadd','div_btnaddprocess');return a;" />
                        </div>
                        <div id="div_btnaddprocess" class="button" align="center" style="width: 30px; display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_DeptView" runat="server" style="float: left; display: none; width: 100%;">
                <div align="right" style="float: right; width: 100%; height: 35px">
                    <asp:Button ID="btn_NewDept" runat="server" CssClass="button" Text="Add New Department"
                        OnClick="btn_NewDept_Onclick" />
                </div>
                <div style="float: left; width: 100%;">
                    <asp:PlaceHolder ID="plhDeptView" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hdn_DeptID" runat="server" />
<asp:HiddenField ID="hid_ContactImage" runat="server" Value="" />
<asp:HiddenField ID="hid_Actualfilename" runat="server" Value="" />
<asp:HiddenField ID="hid_Originalfilename" runat="server" Value="" />
<asp:HiddenField ID="hid_IsProccessed" runat="server" Value="" />
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="900" Height="550" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript" language="javascript">

    var txt_DeptDefaultContact = document.getElementById("<%=txt_DeptDefaultContact.ClientID %>");
    var hdn_DefaultContactID = document.getElementById("<%=hdn_DefaultContactID.ClientID %>");

    var div_DeptAddress1 = document.getElementById("<%=div_DeptAddress1.ClientID %>");
    var div_DeptAddress2 = document.getElementById("<%=div_DeptAddress2.ClientID %>");
    var div_DeptAddress3 = document.getElementById("<%=div_DeptAddress3.ClientID %>");
    var div_DeptAddress4 = document.getElementById("<%=div_DeptAddress4.ClientID %>");
    var div_DeptAddress5 = document.getElementById("<%=div_DeptAddress5.ClientID %>");
    var div_DeptCountry = document.getElementById("<%=div_DeptCountry.ClientID %>");

    var lbl_DeptAddress1 = document.getElementById("<%=lbl_DeptAddress1.ClientID %>");
    var lbl_DeptAddress2 = document.getElementById("<%=lbl_DeptAddress2.ClientID %>");
    var lbl_DeptAddress3 = document.getElementById("<%=lbl_DeptAddress3.ClientID %>");
    var lbl_DeptAddress4 = document.getElementById("<%=lbl_DeptAddress4.ClientID %>");
    var lbl_DeptAddress5 = document.getElementById("<%=lbl_DeptAddress5.ClientID %>");
    var lbl_DeptCountry = document.getElementById("<%=lbl_DeptCountry.ClientID %>");

    var hdn_DeptAddressInfo = document.getElementById("<%=hdn_DeptAddressInfo.ClientID %>");
    var hdnAddressID = document.getElementById("<%=hdnAddressID.ClientID %>");
    var hdnAddressType = document.getElementById("<%=hdnAddressType.ClientID %>");

    var spanDeptName = document.getElementById("spanDeptName");
    var txtDeptName = document.getElementById("<%=txtDeptName.ClientID %>");
    var Pgtype = '<%=Pgtype %>';

    var div_DeptShippingAddress1 = document.getElementById("<%=div_DeptShippingAddress1.ClientID %>");
    var div_DeptShippingAddress2 = document.getElementById("<%=div_DeptShippingAddress2.ClientID %>");
    var div_DeptShippingAddress3 = document.getElementById("<%=div_DeptShippingAddress3.ClientID %>");
    var div_DeptShippingAddress4 = document.getElementById("<%=div_DeptShippingAddress4.ClientID %>");
    var div_DeptShippingAddress5 = document.getElementById("<%=div_DeptShippingAddress5.ClientID %>");
    var div_DeptShippingCountry = document.getElementById("<%=div_DeptShippingCountry.ClientID %>");
    var div_DeptShippingTelephone = document.getElementById("<%=div_DeptShippingTelephone.ClientID %>");
    var div_DeptShippingFax = document.getElementById("<%=div_DeptShippingFax.ClientID %>");

    var lbl_DeptShippingAddress1 = document.getElementById("<%=lbl_DeptShippingAddress1.ClientID %>");
    var lbl_DeptShippingAddress2 = document.getElementById("<%=lbl_DeptShippingAddress2.ClientID %>");
    var lbl_DeptShippingAddress3 = document.getElementById("<%=lbl_DeptShippingAddress3.ClientID %>");
    var lbl_DeptShippingAddress4 = document.getElementById("<%=lbl_DeptShippingAddress4.ClientID %>");
    var lbl_DeptShippingAddress5 = document.getElementById("<%=lbl_DeptShippingAddress5.ClientID %>");
    var lbl_DeptShippingCountry = document.getElementById("<%=lbl_DeptShippingCountry.ClientID %>");
    var lbl_DeptShippingTelephone = document.getElementById("<%=lbl_DeptShippingTelephone.ClientID %>");
    var lbl_DeptShippingFax = document.getElementById("<%=lbl_DeptShippingFax.ClientID %>");

    var hdn_DeptShippingAddressInfo = document.getElementById("<%=hdn_DeptShippingAddressInfo.ClientID %>");
    var hdnShippingAddressID = document.getElementById("<%=hdnShippingAddressID.ClientID %>");
    var hdnShippingAddressType = document.getElementById("<%=hdnShippingAddressType.ClientID %>");

    var lnk_Edit = document.getElementById("<%=lnk_Edit.ClientID %>");
    var lbl_Spliter = document.getElementById("<%=lbl_Spliter.ClientID %>");
    var lnk_Change = document.getElementById("<%=lnk_Change.ClientID %>");

    var lnk_ShippingEdit = document.getElementById("<%=lnk_ShippingEdit.ClientID %>");
    var lbl_ShippingSpliter = document.getElementById("<%=lbl_ShippingSpliter.ClientID %>");
    var lbl_ShippingChange = document.getElementById("<%=lbl_ShippingChange.ClientID %>");

    function opencontacts(val, type) {
        if (val == 'address') {
            if (type == 'add') {
                window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&from=dept&clientid=<%=ClientID%>&mode=add&pg=<%=pg %>";
            }
            if (type == 'addsh') {
                window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&from=deptsh&clientid=<%=ClientID%>&mode=add&pg=<%=pg %>";
                    }
                    if (type == 'change') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=<%=pg %>&pagename=Dept";
                    }
                    if (type == 'changesh') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?type=moreaddress&clientid=<%=ClientID%>&mode=view&pg=<%=pg %>&pagename=Deptsh";
                    }
                    if (type == 'edit') {
                        window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?clientid=<%=ClientID%>&type=moreaddress&mode=edit&pg=<%=pg %>&addressid=" + hdnAddressID.value + "&pagename=DeptEdit";
            }
            if (type == 'editsh') {
                window.location = "<%=nmsCommon.global.sitePath()%>common/common_popup.aspx?clientid=<%=ClientID%>&type=moreaddress&mode=edit&pg=<%=pg %>&addressid=" + hdnShippingAddressID.value + "&pagename=DeptEditSh";
            }
        }
        if (val == 'contact') {
            if (type == 'view') {
                window.radopen("<%=nmsCommon.global.sitePath()%>contact/contact_add.aspx?clientid=<%=ClientID%>&type=moreaddress&pg=<%=pg %>&pagename=Dept", '1000', '500');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }
    }

    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }

    function SendDeptAddressIDandName(AddressID, Address, AddLine1, Address2, City, State, ZipCode, Country, AddType, AddressTo) {
        if (hdnAddressID.value == AddressID && hdnShippingAddressID.value == AddressID) {
            AddressTo = 'both';
        }

        if (AddressTo.toLowerCase() == "billing") {

            hdnAddressID.value = AddressID;
            hdnAddressType.value = AddType;
            hdn_DeptAddressInfo.value = AddressID;

            if (AddLine1 != "") {
                lbl_DeptAddress1.innerHTML = AddLine1;
                lbl_DeptAddress1.style.display = "block"
                div_DeptAddress1.style.display = "block";
            }
            else {
                div_DeptAddress1.style.display = "none";
                lbl_DeptAddress1.style.display = "none"
                lbl_DeptAddress1.innerHTML = "";
            }

            if (Address2 != "") {
                div_DeptAddress2.style.display = "block";
                lbl_DeptAddress2.style.display = "block"
                lbl_DeptAddress2.innerHTML = Address2;
            }
            else {
                div_DeptAddress2.style.display = "none";
                lbl_DeptAddress2.style.display = "none"
                lbl_DeptAddress2.innerHTML = "";
            }

            if (City != "") {
                div_DeptAddress3.style.display = "block";
                lbl_DeptAddress3.style.display = "block"
                lbl_DeptAddress3.innerHTML = City;
            }
            else {
                div_DeptAddress3.style.display = "none";
                lbl_DeptAddress3.style.display = "none"
                lbl_DeptAddress3.innerHTML = "";
            }

            if (State != "") {

                div_DeptAddress4.style.display = "block";
                lbl_DeptAddress4.style.display = "block"
                lbl_DeptAddress4.innerHTML = State;
            }
            else {
                div_DeptAddress4.style.display = "none";
                lbl_DeptAddress4.style.display = "none"
                lbl_DeptAddress4.innerHTML = "";
            }

            if (ZipCode != "") {
                div_DeptAddress5.style.display = "block"
                lbl_DeptAddress5.style.display = "block"
                lbl_DeptAddress5.innerHTML = ZipCode;
            }
            else {
                div_DeptAddress5.style.display = "none";
                lbl_DeptAddress5.style.display = "none"
                lbl_DeptAddress5.innerHTML = "";
            }

            if (Country != "") {
                div_DeptCountry.style.display = "block"
                lbl_DeptCountry.style.display = "block"
                lbl_DeptCountry.innerHTML = Country;
            }
            else {
                div_DeptCountry.style.display = "none";
                lbl_DeptCountry.style.display = "none"
                lbl_DeptCountry.innerHTML = "";
            }
        }
        if (AddressTo.toLowerCase() == "shipping") {

            hdnShippingAddressID.value = AddressID;
            hdnShippingAddressType.value = AddType;
            hdn_DeptShippingAddressInfo.value = AddressID;

            lnk_ShippingEdit.style.display = "block";
            lbl_ShippingSpliter.style.display = "block";

            if (AddLine1 != "") {
                lbl_DeptShippingAddress1.innerHTML = AddLine1;
                lbl_DeptShippingAddress1.style.display = "block"
                div_DeptShippingAddress1.style.display = "block";
            }
            else {
                div_DeptShippingAddress1.style.display = "none";
                lbl_DeptShippingAddress1.style.display = "none"
                lbl_DeptShippingAddress1.innerHTML = "";
            }

            if (Address2 != "") {
                div_DeptShippingAddress2.style.display = "block";
                lbl_DeptShippingAddress2.style.display = "block"
                lbl_DeptShippingAddress2.innerHTML = Address2;
            }
            else {
                div_DeptShippingAddress2.style.display = "none";
                lbl_DeptShippingAddress2.style.display = "none"
                lbl_DeptShippingAddress2.innerHTML = "";
            }

            if (City != "") {
                div_DeptShippingAddress3.style.display = "block";
                lbl_DeptShippingAddress3.style.display = "block"
                lbl_DeptShippingAddress3.innerHTML = City;
            }
            else {
                div_DeptShippingAddress3.style.display = "none";
                lbl_DeptShippingAddress3.style.display = "none"
                lbl_DeptShippingAddress3.innerHTML = "";
            }

            if (State != "") {
                div_DeptShippingAddress4.style.display = "block";
                lbl_DeptShippingAddress4.style.display = "block"
                lbl_DeptShippingAddress4.innerHTML = State;
            }
            else {
                div_DeptShippingAddress4.style.display = "none";
                lbl_DeptShippingAddress4.style.display = "none"
                lbl_DeptShippingAddress4.innerHTML = "";
            }

            if (ZipCode != "") {
                div_DeptShippingAddress5.style.display = "block";
                lbl_DeptShippingAddress5.style.display = "block"
                lbl_DeptShippingAddress5.innerHTML = ZipCode;
            }
            else {
                div_DeptShippingAddress5.style.display = "none";
                lbl_DeptShippingAddress5.style.display = "none"
                lbl_DeptShippingAddress5.innerHTML = "";
            }

            if (Country != "") {
                div_DeptShippingCountry.style.display = "block"
                lbl_DeptShippingCountry.style.display = "block"
                lbl_DeptShippingCountry.innerHTML = Country;
            }
            else {
                div_DeptShippingCountry.style.display = "none";
                lbl_DeptShippingCountry.style.display = "none"
                lbl_DeptShippingCountry.innerHTML = "";
            }
        }
        if (AddressTo == 'both') {

            // INVOICE
            hdnAddressID.value = AddressID;
            hdnAddressType.value = AddType;
            hdn_DeptAddressInfo.value = AddressID;

            if (AddLine1 != "") {
                lbl_DeptAddress1.innerHTML = AddLine1;
                lbl_DeptAddress1.style.display = "block"
                div_DeptAddress1.style.display = "block";
            }
            else {
                div_DeptAddress1.style.display = "none";
                lbl_DeptAddress1.style.display = "none"
                lbl_DeptAddress1.innerHTML = "";
            }

            if (Address2 != "") {
                div_DeptAddress2.style.display = "block";
                lbl_DeptAddress2.style.display = "block"
                lbl_DeptAddress2.innerHTML = Address2;
            }
            else {
                div_DeptAddress2.style.display = "none";
                lbl_DeptAddress2.style.display = "none"
                lbl_DeptAddress2.innerHTML = "";
            }

            if (City != "") {
                div_DeptAddress3.style.display = "block";
                lbl_DeptAddress3.style.display = "block"
                lbl_DeptAddress3.innerHTML = City;
            }
            else {
                div_DeptAddress3.style.display = "none";
                lbl_DeptAddress3.style.display = "none"
                lbl_DeptAddress3.innerHTML = "";
            }

            if (State != "") {

                div_DeptAddress4.style.display = "block";
                lbl_DeptAddress4.style.display = "block"
                lbl_DeptAddress4.innerHTML = State;
            }
            else {
                div_DeptAddress4.style.display = "none";
                lbl_DeptAddress4.style.display = "none"
                lbl_DeptAddress4.innerHTML = "";
            }

            if (ZipCode != "") {
                div_DeptAddress5.style.display = "block"
                lbl_DeptAddress5.style.display = "block"
                lbl_DeptAddress5.innerHTML = ZipCode;
            }
            else {
                div_DeptAddress5.style.display = "none";
                lbl_DeptAddress5.style.display = "none"
                lbl_DeptAddress5.innerHTML = "";
            }

            if (Country != "") {
                div_DeptCountry.style.display = "block"
                lbl_DeptCountry.style.display = "block"
                lbl_DeptCountry.innerHTML = Country;
            }
            else {
                div_DeptCountry.style.display = "none";
                lbl_DeptCountry.style.display = "none"
                lbl_DeptCountry.innerHTML = "";
            }


            // SHIPPING
            hdnShippingAddressID.value = AddressID;
            hdnShippingAddressType.value = AddType;
            hdn_DeptShippingAddressInfo.value = AddressID;

            lnk_ShippingEdit.style.display = "block";
            lbl_ShippingSpliter.style.display = "block";

            if (AddLine1 != "") {
                lbl_DeptShippingAddress1.innerHTML = AddLine1;
                lbl_DeptShippingAddress1.style.display = "block"
                div_DeptShippingAddress1.style.display = "block";
            }
            else {
                div_DeptShippingAddress1.style.display = "none";
                lbl_DeptShippingAddress1.style.display = "none"
                lbl_DeptShippingAddress1.innerHTML = "";
            }

            if (Address2 != "") {
                div_DeptShippingAddress2.style.display = "block";
                lbl_DeptShippingAddress2.style.display = "block"
                lbl_DeptShippingAddress2.innerHTML = Address2;
            }
            else {
                div_DeptShippingAddress2.style.display = "none";
                lbl_DeptShippingAddress2.style.display = "none"
                lbl_DeptShippingAddress2.innerHTML = "";
            }

            if (City != "") {
                div_DeptShippingAddress3.style.display = "block";
                lbl_DeptShippingAddress3.style.display = "block"
                lbl_DeptShippingAddress3.innerHTML = City;
            }
            else {
                div_DeptShippingAddress3.style.display = "none";
                lbl_DeptShippingAddress3.style.display = "none"
                lbl_DeptShippingAddress3.innerHTML = "";
            }

            if (State != "") {
                div_DeptShippingAddress4.style.display = "block";
                lbl_DeptShippingAddress4.style.display = "block"
                lbl_DeptShippingAddress4.innerHTML = State;
            }
            else {
                div_DeptShippingAddress4.style.display = "none";
                lbl_DeptShippingAddress4.style.display = "none"
                lbl_DeptShippingAddress4.innerHTML = "";
            }

            if (ZipCode != "") {
                div_DeptShippingAddress5.style.display = "block";
                lbl_DeptShippingAddress5.style.display = "block"
                lbl_DeptShippingAddress5.innerHTML = ZipCode;
            }
            else {
                div_DeptShippingAddress5.style.display = "none";
                lbl_DeptShippingAddress5.style.display = "none"
                lbl_DeptShippingAddress5.innerHTML = "";
            }

            if (Country != "") {
                div_DeptShippingCountry.style.display = "block"
                lbl_DeptShippingCountry.style.display = "block"
                lbl_DeptShippingCountry.innerHTML = Country;
            }
            else {
                div_DeptShippingCountry.style.display = "none";
                lbl_DeptShippingCountry.style.display = "none"
                lbl_DeptShippingCountry.innerHTML = "";
            }
        }
    }

    var ClientID = '<%=ClientID %>';
    var CompanyID = '<%=CompanyID %>';
    var DeptID = '<%=DeptID %>';
    var mode = '<%=mode %>';
    var rtnDeptID = '<%=rtnDeptID %>';

    var ChkDeptDuplicacy = false;

    function onTimeout1(request, context) { }

    function onError1(objError) { }

    function checkDeptDuplicacy(DeptName) {
        DeptName = SpecialEncode(DeptName)
        AutoFill.CheckDept_Duplicacy(CompanyID, ClientID, DeptName, DeptID, GetResult, onTimeout1, onError1);
    }

    function GetResult(results) {
        var flag = true;
        if (results == -1) {
            spanDeptName.innerHTML = '<%=objLangClass.GetLanguageConversion("Department_name_already_exists")%>';
            spanDeptName.style.display = "block";
            ChkDeptDuplicacy = true;
            flag = false;
        }
        else {
            spanDeptName.style.display = "none";
            ChkDeptDuplicacy = false;
            flag = true;
        }

        if (flag)
            return true;
        else
            return false;
    }

    function validate(val) {
        asyncState = false;
        var flag = true;
        if (val == 'save') {
            CallonBlur(txtDeptName.value, 'spanDeptName');

            if (trim12(txtDeptName.value) == '') {
                spanDeptName.style.display = "block";
                flag = false;
            }
            else if (txtDeptName.value != '') {
                checkDeptDuplicacy(SpecialEncode(txtDeptName.value));
                if (ChkDeptDuplicacy) {
                    flag = false;
                }
            }
        }

        if (flag)
            return true;
        else
            return false;
    }

    function GetContactName(ContactID, ContactName) {
        hdn_DefaultContactID.value = ContactID;
        txt_DeptDefaultContact.value = ContactName;
    }


    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow;
        else if (window.radWindow) oWindow = window.radWindow;
        return oWindow;
    }
    function RadClose() {
        GetRadWindow().Close();
    }

</script>
<asp:Panel ID="pnlDept" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        var DeptID = '<%=rtnDeptID %>';
        var txtDeptName = document.getElementById("<%=txtDeptName.ClientID %>");

        function SendDeptDetails(DeptID, txtDeptName) {
            var pw = window.parent;
            pw.SendDeptIDandName(DeptID, txtDeptName);
            setTimeout("TakeOut()", 600);
        }
        function TakeOut() {
            window.close();
        }

        SendDeptDetails(DeptID, txtDeptName.value);

    </script>
</asp:Panel>
<script language="javascript" type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
</script>
<asp:Panel ID="pnlDept1" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function SendDept() {
            var pw = window.parent;
            pw.SetTabs('dept', 'yes');
        }
        function TakeOut() {
            window.close();
        }

        SendDept();

    </script>
</asp:Panel>
<asp:Panel ID="pnlDept_estimate" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        var DelAddress = lbl_DeptShippingAddress1.innerHTML + ' ' + lbl_DeptShippingAddress2.innerHTML + ' ' + lbl_DeptShippingAddress3.innerHTML + ' ' + lbl_DeptShippingAddress4.innerHTML + ' ' + lbl_DeptShippingAddress5.innerHTML + ' ' + lbl_DeptShippingCountry.innerHTML;
        var InvAddress = lbl_DeptAddress1.innerHTML + ' ' + lbl_DeptAddress2.innerHTML + ' ' + lbl_DeptAddress3.innerHTML + ' ' + lbl_DeptAddress4.innerHTML + ' ' + lbl_DeptAddress5.innerHTML + ' ' + lbl_DeptCountry.innerHTML;

        function SendDept_Details() {
            var pw = window.parent.parent;
            pw.SendDeptIDName(rtnDeptID, txtDeptName.value, hdnAddressID.value, hdnShippingAddressID.value, InvAddress, DelAddress);
            setTimeout("TakeOut()", 600);
            return false;
        }

        function TakeOut() {
            window.close();
        }

        SendDept_Details();

    </script>
</asp:Panel>
<script type="text/javascript" language="javascript">

    var ImageUpload = document.getElementById('<%=ImageUpload.ClientID %>');
    var lblContactImage = document.getElementById('<%=lblContactImage.ClientID %>');
    var hid_ContactImage = document.getElementById('<%=hid_ContactImage.ClientID %>');
    var ContactImage = document.getElementById('<%=ContactImage.ClientID %>');
    var hid_Actualfilename = document.getElementById('<%=hid_Actualfilename.ClientID %>');
    var hid_Originalfilename = document.getElementById('<%=hid_Originalfilename.ClientID %>');

    function FileUploadClearText() {
        ImageUpload.value = "";
        document.getElementById('<%=FileTextClear.ClientID%>').style.display = "none";
    }

    function RemoveImage() {
        hid_Actualfilename.value = "";
        hid_Originalfilename.value = "";
        lblContactImage.innerHTML = "";
        hid_ContactImage.value = "";
        ContactImage.style.display = "none";
        lblContactImage.style.display = "none";
        ImageUpload.style.display = "block";
        var img_delete = document.getElementById("img_delete");
        if (img_delete != null && img_delete != undefined) {
            img_delete.style.display = "none";
        }
    }

    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById("<%=ImageUpload.ClientID%>");
                var FileUploadPath = fuData.value;


                if (FileUploadPath == '') {
                    // There is no file selected
                    args.IsValid = false;
                }
                else {
                    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                    if (Extension == "jpg" || Extension == "png" || Extension == "gif" || Extension == "jpeg" || Extension == "pdf") {
                        var divext = document.getElementById("Spn_ImageUploadFile");
                        divext.style.display = 'none';
                        document.getElementById('<%=FileTextClear.ClientID%>').style.display = "block";
                        document.getElementById('<%=DivClear.ClientID%>').style.display = "block";
                        ContactImage.style.display = "none"
                        args.IsValid = true; // Valid file type
                    }
                    else {
                        fuData.value = '';
                        var divext = document.getElementById("Spn_ImageUploadFile");
                        divext.style.display = 'block';
                        document.getElementById('<%=FileTextClear.ClientID%>').style.display = "none";
                        document.getElementById('<%=DivClear.ClientID%>').style.display = "none";
                        args.IsValid = false; // Not valid file type                        
                    }
                }
            }
</script>

