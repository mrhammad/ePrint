<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true"  CodeBehind="job_add.aspx.cs" Inherits="ePrint.Jobs.job_add" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="ItemStage1" TagPrefix="UC" Src="~/usercontrol/Item/estimate_stage1_new.ascx" %>
<%@ Register TagName="Attachments" TagPrefix="UC" Src="~/usercontrol/Item/attachments.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function ShowAttachments() {
            window.open("<%=strSitepath %>common/common_popup.aspx?type=attachments&pg=estimate", '', 'width=700px,height=400,status=no,scrollbars=yes,resizable=yes,top=100,title=no,location=no,titlebar=no,left=270,top=100');
            selects = document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].style.display = "none";
            }
        }
        function ShowNotes() {
            document.getElementById("div_notes").style.display = "block";
            //dropdown hide//
            selects = document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].style.display = "none";
            }
        }
        function hideDiv(divid) {
            document.getElementById(divid).style.display = "none";
            //dropdown show//
            selects = document.getElementsByTagName("select");
            for (i = 0; i != selects.length; i++) {
                selects[i].style.display = "block";
            }
        }
    </script>
    <UC:ItemStage1 ID="UCStage1" runat="server" BaseSection="estimate" />
     <script>
         Load_Invoice_Page();
         function Load_Invoice_Page() {


             document.getElementById("spn_txtEstimateTitle").innerHTML = "Please enter job title ";
             document.getElementById("spn_Label3").innerHTML = "Please enter job type";
         }
    </script>
</asp:Content>



