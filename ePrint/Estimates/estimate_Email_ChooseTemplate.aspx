<%@ page language="C#" autoeventwireup="true" CodeBehind="estimate_Email_ChooseTemplate.aspx.cs" Inherits="ePrint.Estimates.estimate_Email_ChooseTemplate" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="class" Src="~/usercontrol/CallClass.ascx" %>
<script type="text/javascript" language="javascript" src="../js/JScript.js?VN='<%=VersionNumber%>'"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" language="javascript">

        function ItemOnMouseOver(oRow) {
            oRow.originalBackgroundColor = oRow.style.backgroundColor
            oRow.style.backgroundColor = '#C2C2C2'; //'#FFFF99';
        }

        function ItemOnMouseOut(oRow) {
            oRow.style.backgroundColor = oRow.originalBackgroundColor;
        }
        function desableAfterLoad() {
            alert("close..?");
            window.parent.document.getElementById("ds00").style.display = "none";
            window.parent.document.getElementById("div_Load").style.display = "none";
        }

        function onloadChangeColor() {
            window.parent.document.getElementById("li_Preview").style.display = "block";
            window.parent.document.getElementById("item_2").style.color = "blue";
            window.parent.document.getElementById("item_1").style.color = "black";
            if ('<%=PageType %>'.toLowerCase() == "printbroker") {
                window.parent.document.getElementById("li_EditTemplate").style.display = "none";
            }
            else {
                window.parent.document.getElementById("li_EditTemplate").style.display = "block";
            }
            window.parent.document.getElementById("li_EmailTemplate").style.display = "block";
        }

        function enablebtns(redirectPage, TemplateID) {
            window.parent.document.getElementById("ds00").style.display = "block";
            window.parent.document.getElementById("div_Load").style.display = "block";
            window.parent.document.getElementById("ds00").style.width = window.parent.screen.availWidth + "px";
            window.parent.document.getElementById("ds00").style.height = window.parent.screen.availHeight + "px";




            window.parent.document.getElementById("ctl00_ContentPlaceHolder1_UCtemplate1_hdnTemplateIDForPDF").value = TemplateID;



            var iframePath2 = window.parent.iframePath1;
            var iframePathpdf2 = window.parent.iframePathpdf1;
            var iframePathForEditTemplate2 = window.parent.iframePathForEditTemplate1;
            var iframeEmailPath2 = window.parent.iframeEmailPath1;
            var iframePathChooseTemp2 = window.parent.iframePathChooseTemp1;



            if (iframePath2.indexOf('&templateid=') != -1) {
                iframePath2 = iframePath2.substring(0, iframePath2.indexOf("&templateid="));

            }
            if (iframePathpdf2.indexOf('&templateid=') != -1) {
                iframePathpdf2 = iframePathpdf2.substring(0, iframePathpdf2.indexOf("&templateid="));
            }
            if (iframePathForEditTemplate2.indexOf('&templateid=') != -1) {
                iframePathForEditTemplate2 = iframePathForEditTemplate2.substring(0, iframePathForEditTemplate2.indexOf("&templateid="));
            }
            if (iframeEmailPath2.indexOf('&templateid=') != -1) {
                iframeEmailPath2 = iframeEmailPath2.substring(0, iframeEmailPath2.indexOf("&templateid="));
            }
            if (iframePathChooseTemp2.indexOf('&templateid=') != -1) {
                iframePathChooseTemp2 = iframePathChooseTemp2.substring(0, iframePathChooseTemp2.indexOf("&templateid="));
            }



            window.parent.iframePath = iframePath2 + "&templateid=" + TemplateID;
            window.parent.iframePathpdf = iframePathpdf2 + "&templateid=" + TemplateID;
            window.parent.iframePathForEditTemplate = iframePathForEditTemplate2 + "&templateid=" + TemplateID;
            window.parent.iframeEmailPath = iframeEmailPath2 + "&templateid=" + TemplateID;
            window.parent.iframePathChooseTemp = iframePathChooseTemp2 + "&templateid=" + TemplateID;





            onloadChangeColor();

            window.location = redirectPage;
        }

        function GeneratePDF(TemplateID) {
            var hdnTemplateValue = document.getElementById("<%=hdnTemplateValue.ClientID %>");
            hdnTemplateValue.value = TemplateID;
            __doPostBack('GridTemplate$ctl10$lnkTempName', '');
        }

    </script>
    <form id="form1" runat="server">
    <UC:class ID="ucClass" runat="server" />
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/press_select.asmx" />
        </Services>
    </asp:ScriptManager>
    <div>
        <div align="left" style="width: 99%">
            <asp:UpdatePanel ID="UPMessage" UpdateMode="Always" runat="server">
                <ContentTemplate>
                    <div style="float: right; padding-right: 6px; display: none">
                        <span class="normalText">Total Records:</span><b>
                            <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>
                    <div style="float: left; width: 100%">
                        <asp:GridView ID="GridTemplate" runat="server" AutoGenerateColumns="false" GridLines="Horizontal"
                            AllowPaging="false" SkinID="GridStyle" OnRowDataBound="GridTemplate_OnRowDataBound"
                            Width="100%" Style="table-layout: fixed">
                            <Columns>
                                <asp:TemplateField HeaderText="Template Name" ItemStyle-Wrap="false" ItemStyle-Width="40%">
                                    <HeaderStyle HorizontalAlign="Left" Width="40%" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkTempName" runat="server" OnCommand="lnkTempName_OnClick" CommandArgument='<%#Eval("TemplateID")%>'> <%#Eval("Name")%></asp:LinkButton>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("TemplateID")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Wrap="false" ItemStyle-Width="45%">
                                    <HeaderStyle HorizontalAlign="Left" Width="45%" Wrap="false" />
                                    <ItemTemplate>
                                        <%#Eval("Description") %>
                                        <asp:Label ID="lblIsDefault" runat="server" Text='<%#Eval("IsDefault") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div id="padding" class="emptyrecords" align="center">
                                    <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                </div>
                            </EmptyDataTemplate>
                            <PagerTemplate>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsTemplate" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                            SelectMethod="settings_templates_select"></asp:ObjectDataSource>
                    </div>
                    <div class="only10px">
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:HiddenField runat="server" ID="hdnTemplateValue" Value="0" />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function defaultcolor() {
        //alert("color..?");
        window.parent.document.getElementById("item_1").style.color = "blue";
        window.parent.document.getElementById("item_4").style.color = "black";
    }
    defaultcolor();
    window.parent.document.getElementById("ds00").style.display = "none";
    window.parent.document.getElementById("div_Load").style.display = "none";

    window.parent.document.getElementById("Iframe_forAll").style.height = window.parent.document.getElementById("Iframe_forAll").contentWindow.document.body.scrollHeight + "px";





</script>


