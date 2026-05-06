<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/loginPopoupMaster.master" CodeBehind="common_addstocklocation.aspx.cs" Inherits="ePrint.common.common_addstocklocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 0px; margin-top: 0px;
                                        margin-bottom: 0px;" width="100%">
                                        <tr>
                                            <td class="bglabel" style="width: 88%" >
                                                <asp:Label ID="lblLocationName" runat="server"><%=objLanguage.GetLanguageConversion("Location_Name") %><span style="color:red">*</span> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtlocationName" Width="300px"  CssClass="textboxnew" runat="server" AutoCompleteType="disabled"></asp:TextBox>
                                                 <span style="color: Red">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldlocationname" ControlToValidate="txtlocationName"
                                                                ErrorMessage='Please enter Location Name' runat="server">
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="lbl_Address1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Address1")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox Font-Size="11px" ID="txtaddress" runat="server"   Width="300px" CssClass="textboxnew"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="lbl_Address3" runat="server" Text="City" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("City")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox  ID="txtcity" runat="server" CssClass="textboxnew"  Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="lbl_Address4" runat="server" Text="Suburb" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Suburb")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_suburb" CssClass="textboxnew" runat="server"  Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="lbl_Address5" runat="server" Text="Post Code" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Post_Code")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_postCode" CssClass="textboxnew" runat="server"  Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="Label42" runat="server" Text="Country" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Country") %></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="texboxnew"  Width="308px">
                                                </asp:DropDownList>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="Label43" runat="server" Text="Telephone" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Telephone") %></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txttelephone" runat="server"  CssClass="textboxnew" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel" style="width: 88%">
                                                <asp:Label ID="Label1" runat="server" Text="Default Location" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Location")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkdefault"  runat="server" />
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <div style="display: inline; float: left">
                                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_onclick" CssClass="button" Style="margin: 0px 10px 0px 0px"
                                                         />
                                                </div>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <script>
                                        function GetRadWindow() {
                                            var oWindow = null;
                                            if (window.radWindow)
                                                oWindow = window.radWindow;
                                            else if (window.frameElement.radWindow)
                                                oWindow = window.frameElement.radWindow;
                                            return oWindow;
                                        }


                                        function SetTopLocation() {
                                         var LocationId = <%=LocationID %>;
                                         var LocationName ='<%=LocationName %>';
                                            var pw = window.parent;
                                            pw.GetTopLocation(LocationId,LocationName);
                                            return false;
                                        }
                                    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


