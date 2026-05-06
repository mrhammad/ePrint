<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contacts_add.ascx.cs" Inherits="ePrint.usercontrol.contacts_add" %>

<div class="navigatorpanel">
    <div class="t">
        <div class="t">
            <div class="t">
                <div class="divpadding">
                    <div style="float: left" nowrap="nowrap">
                        <asp:Label ID="lblHeader" runat="server" CssClass="navigatorpanel">Customer Contacts</asp:Label>
                    </div>
                    <div id="div_lnkadd" style="float: right; display: block">
                        <a href="javascript:add_new('show');" onclick="javascript:Minimize();" class="subnavigator">Add a new Contact</a></div>
                    <div id="div_lnkview" style="float: right; display: none">
                        <a href="javascript:add_new('hide');" class="subnavigator">View Contacts</a></div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>

<div class="borderWithoutTop">
    <div id="padding">
        <div id="div_add" style="width: 100%; display: none">
            <div id="leftcol">
                <div class="bglabel">
                    <asp:Label ID="lblcustomer" runat="server" Text="Title" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox3" runat="server" Width="70px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label1" runat="server" Text="First Name" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label4" runat="server" Text="Middle Name" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox5" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label2" runat="server" Text="Last Name" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel" style="height: 38px">
                    <asp:Label ID="Label5" runat="server" Text="Business Address" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox6" runat="server" Width="200px" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label6" runat="server" Text="Business City" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox7" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label7" runat="server" Text="Business State" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox8" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label8" runat="server" Text="Business Post Code" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox9" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label9" runat="server" Text="Business Country" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox10" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label10" runat="server" Text="Business Phone" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox11" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label11" runat="server" Text="Business Fax" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox12" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label12" runat="server" Text="Business URL" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox13" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel" style="height: 38px">
                    <asp:Label ID="Label13" runat="server" Text="Notes" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox14" runat="server" Width="200px" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox></div>
            </div>
            <div id="rightcol">
                <div class="header">
                    &nbsp;
                </div>
                <div style="height: 25px">
                    &nbsp;</div>
                <div class="bglabel">
                    <asp:Label ID="Label22" runat="server" Text="Company" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox19" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel" style="height: 38px">
                    <asp:Label ID="Label3" runat="server" Text="Home Address" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox4" runat="server" Width="200px" CssClass="textboxnew" TextMode="MultiLine"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label14" runat="server" Text="Home City" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox15" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label15" runat="server" Text="Home State" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox16" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label16" runat="server" Text="Home Post Code" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox17" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label17" runat="server" Text="Home Country" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox18" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label18" runat="server" Text="Home Phone" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox20" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label19" runat="server" Text="Mobile" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox21" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label20" runat="server" Text="Email" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox22" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label21" runat="server" Text="Pager" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox23" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label23" runat="server" Text="Department" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox24" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                <div class="bglabel">
                    <asp:Label ID="Label24" runat="server" Text="Job Title" CssClass="normalText"></asp:Label></div>
                <div class="box">
                    <asp:TextBox ID="TextBox25" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
            </div>
            <div style="clear: both">
                &nbsp;
            </div>
            <div style="float: left; width: 100%">
                <div style="float: left">
                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" Width="65px"
                        OnClientClick="javascript:return false;" /></div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left">
                    <asp:Button ID="btncancel_address" runat="server" Text="Cancel" CssClass="button"
                        Width="65px" OnClientClick="javascript:return false;" /></div>
            </div>
            <div style="clear: both">
            </div>
        </div>
        <div id="div_view" style="width: 100%;">
            <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                <%--<col width="5%" />--%>
                <col width="25%" />
                <col width="30%" />
                <col width="20%" />
                <tr class="label">
                    <td style="display:none">
                        <asp:Label ID="Label25" runat="server" Text="Action" CssClass="normaltext"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label26" runat="server" Text="Name" CssClass="normaltext"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="Telephone" CssClass="normaltext"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label30" runat="server" Text="Email" CssClass="normaltext"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="display:none">
                        <img src="../images/ico-edit.gif" />&nbsp;<img src="../images/delete.gif" />
                    </td>
                    <td>
                        <a href="#" onclick="javascript:select_name('Joe Bloggs');">Joe Bloggs</a>
                    </td>
                    <td>
                        +44 (0) 115 921 556
                    </td>
                    <td>
                        joe@jvcelectrics.com
                    </td>
                </tr>
                <tr>
                    <td style="display:none">
                        <img src="../images/ico-edit.gif" />&nbsp;<img src="../images/delete.gif" />
                    </td>
                    <td>
                        <a href="#" onclick="javascript:select_name('JSteve Martin');">JSteve Martin</a>
                    </td>
                    <td>
                        +44 (0) 115 922 6215
                    </td>
                    <td>
                        steve@jvcelectrics.co.uk
                    </td>
                </tr>
                <tr>
                    <td style="display:none">
                        <img src="../images/ico-edit.gif" />&nbsp;<img src="../images/delete.gif" />
                    </td>
                    <td>
                        <a href="#" onclick="javascript:select_name('Sharon Smith');">Sharon Smith</a>
                    </td>
                    <td>
                        +44 (0) 1202 828222
                    </td>
                    <td>
                        test@dummy.com
                    </td>
                </tr>
            </table>
        </div>
        <div style="clear: both">
        </div>
    </div>
</div>
<div style="float: left; width: 750px">
    &nbsp;</div>

<script>
    function select_name(name) {

        window.close();

        //parent.window.document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value=name;
        eval("opener.window.document.forms[0][\'ctl00_ContentPlaceHolder1_TextBox1'].value='" + name + "'");
    }
    function Minimize() {
        alert("hi");
        this.ShowInTaskbar = true;
        window.innerWidth = 100;
        window.innerHeight = 100;
        window.screenX = 500;
        window.screenY = 900;
        alwaysLowered = true;
    }
    function add_new(type) {
        if (type == 'show') {
            document.getElementById("div_add").style.display = "block";
            document.getElementById("div_view").style.display = "none";
            document.getElementById("div_lnkview").style.display = "block";
            document.getElementById("div_lnkadd").style.display = "none";
        }
        else if (type == 'hide') {
            document.getElementById("div_add").style.display = "none";
            document.getElementById("div_view").style.display = "block";
            document.getElementById("div_lnkview").style.display = "none";
            document.getElementById("div_lnkadd").style.display = "block";
        }
    }



    function load_onmode() {
        var mode = '<%=mode%>';

        if (mode == 'add' || mode == 'edit') {
            document.getElementById("div_add").style.display = "block";
            document.getElementById("div_view").style.display = "none";
            document.getElementById("div_lnkview").style.display = "none";
            document.getElementById("div_lnkadd").style.display = "none";
        }
        //        else if(mode == 'view')
        //        {
        //            document.getElementById("div_add").style.display = "block";
        //            document.getElementById("div_view").style.display = "none";
        //            document.getElementById("div_lnkview").style.display = "block";
        //            document.getElementById("div_lnkadd").style.display = "none";            
        //        }
    }
    load_onmode();
</script>

