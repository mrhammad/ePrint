<%@ Page Title="" Language="C#" MasterPageFile="~/innerMasterPage_withoutLeftTD.Master" AutoEventWireup="true" CodeBehind="proof_add.aspx.cs" Inherits="ePrint.Proofs.proof_add" %>
<%@ Register TagName="ItemStage1" TagPrefix="UC" Src="~/usercontrol/Item/estimate_stage1_new.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
        var currentdate = '<%=newdate%>';
        function ShowAttachments() {
            PopupCenter("<%=strSitepath %>common/common_popup.aspx?type=attachments&pg=estimate", 900, 500);
        }
        function Hide_Dropdown(para) {
            //dropdown hide//
            if (para == "hide") {
                selects = document.getElementsByTagName("select");
                for (i = 0; i != selects.length; i++) {
                    selects[i].style.display = "none";
                }
            }
            else {
                selects = document.getElementsByTagName("select");
                for (i = 0; i != selects.length; i++) {
                    selects[i].style.display = "block";
                }
            }
        }
        function ShowNotes() {
            setLoadingPositionOfDivMove(document.getElementById("div_notes"));
            document.getElementById("div_notes").style.display = "block";
            selects = document.getElementsByTagName("select");
            Hide_Dropdown('hide');
        }
        function hideDiv(divid) {
            document.getElementById(divid).style.display = "none";
            //dropdown show//
            Hide_Dropdown('show');
        }
    </script>
    <script type="text/javascript" language="javascript">

        ////This should fix yr error. It is work around however

        // Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
        function endRequest(sender, args) {
            // Check to see if there's an error on this request.
            if (args.get_error() != undefined) {
                //// $get('Error').style.visibility = "visible";
                // Let the framework know that the error is handled, 
                // so it doesn't throw the JavaScript alert. 
                args.set_errorHandled(true);
            }
        }


    </script>
    <UC:ItemStage1 ID="UCStage1" runat="server" BaseSection="estimate" />
</asp:Content>
