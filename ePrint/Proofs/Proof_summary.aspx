<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proof_summary.aspx.cs" Inherits="ePrint.Proofs.Proof_summary" MasterPageFile="~/Templates/innerMasterPage_withLeftTD.master" %>

<%--<%@ Register TagName="UcItemSummaryMain" TagPrefix="UC" Src="~/usercontrol/Item/item_summary_main.ascx" %>--%>
<%@ Register TagName="UcProofSummaryMain" TagPrefix="UC" Src="~/usercontrol/Item/proof_summary_main.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:UcProofSummaryMain ID="UCProofSummaryMain" runat="server" />

    <script type="text/javascript">

        function ShowAttachment(fileName, OriginalFileName) {
            var dataValue = { "fileName": fileName, 'OriginalFileName': OriginalFileName };
            $.ajax({
                type: "POST",
                url: "Proof_summary.aspx/OnSubmit",
                data: JSON.stringify(dataValue),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    debugger;
                    window.open(result.d, '_blank');
                }
            });
        }
        function ChangeAttachment(estimateItemID, proofID) {
            debugger;
            var e = document.getElementById("ddlProofFiles_" + estimateItemID + "");
            var attachmentID = e.options[e.selectedIndex].value;
            var dataValue = { "proofID": proofID, 'estimateItemID': estimateItemID, 'attachmentID': attachmentID };
            $.ajax({
                type: "POST",
                url: "Proof_summary.aspx/ChangeAttachment",
                data: JSON.stringify(dataValue),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    debugger;
                    var data = JSON.parse(result.d);
                    var myobj = document.getElementById("historyTable_" + proofID + "_" + estimateItemID + "");
                    myobj.innerHTML = "";
                    var _html = "";
                    var _comment = "";
                    _html += "<tr>";
                    _html += "<th style='padding:5px;min-width:115px'>";
                    _html += "<label style='padding-top:10px;font-weight:bold'>Data/Time</label>";
                    _html += "</th>";
                    _html += "<th style='padding:5px;min-width:95px'>";
                    _html += "<label style='padding-top:10px;font-weight:bold'>User</label>";
                    _html += "</th>";
                    _html += "<th style='padding:5px;width:231px'>";
                    _html += "<label style='padding-top:10px;font-weight:bold'>Message</label>";
                    _html += "</th>";
                    _html += "<th style='padding:5px;min-width:115px'>";
                    _html += "<label style='padding-top:10px;font-weight:bold'>Status</label>";
                    _html += "</th>";
                    _html += "</tr>";
                    $.each(data, function (ind, val) {
                        if (val.Comments == null) {
                            _comment = "";
                        }
                        else {
                            _comment = val.Comments;
                        }
                        //var d = new Date(val.CreatedDate);
                        //var datestring = ("0" + (d.getMonth() + 1)).slice(-2) + "/" + ("0" + d.getDate()).slice(-2) + "/" +
                        //    d.getFullYear() + " " + ("0" + d.getHours()).slice(-2) + ":" + ("0" + d.getMinutes()).slice(-2);                        _html += "<tr id='tr_" + proofID + "_" + estimateItemID + "'>";
                        _html += "<td style='padding:5px'>";
                        _html += "<label style='padding-top:10px'>" + val.CreatedDate + "</label>";
                        _html += "</td>";
                        _html += "<td style='padding:5px'>";
                        _html += "<label style='padding-top:10px'>" + val.User + "</label>";
                        _html += "</td>";
                        _html += "<td style='padding:5px'>";
                        _html += "<label style='padding-top:10px'>" + _comment + "</label>";
                        _html += "</td>";
                        _html += "<td style='padding:5px'>";
                        _html += "<label style='padding-top:10px'>" + val.Status + "</label>";
                        _html += "</td>";
                        _html += "</tr>";

                    })
                    myobj.innerHTML = _html;
                }
            });
        }
        function ChangeAttachmentImage(estimateItemID, proofID) {
            var e = document.getElementById("ddlProofFiles_" + estimateItemID + "");
            var attachmentID = e.options[e.selectedIndex].value;
            var dataValue = { "proofID": proofID, 'estimateItemID': estimateItemID, 'attachmentID': attachmentID };
            $.ajax({
                type: "POST",
                url: "Proof_summary.aspx/ChangeAttachmentImage",
                data: JSON.stringify(dataValue),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    //var data = JSON.parse(result.d);
                    var tbl_td = document.getElementById("td_" + proofID + "_" + estimateItemID + "");
                    tbl_td.innerHTML = "";
                    var td_html = "";
                    td_html += "<img src=" + result.d.imagePath + "  style='height:330px;width:330px;overflow:hidden;object-fit:contain;' onmouseover='changeCurser(this)'   onclick=javascript:ShowAttachment('" + result.d.fileName + "','" + result.d.orignalFileName + "');>&nbsp;&nbsp;";
                    //$.each(data, function (ind, val) {
                    //})
                    tbl_td.innerHTML = td_html;
                }
            });
        }

        function DisplayEmailAndName(ProofItemID) {
            var checkBox = document.getElementById("approval_chk_" + ProofItemID + "");
            var approverNameLbl = document.getElementById("approver_name_lbl_" + ProofItemID + "");
            var approverName = document.getElementById("approver_name_" + ProofItemID + "");
            var approverEmailLbl = document.getElementById("approver_email_lbl_" + ProofItemID + "");
            var approverEmail = document.getElementById("approver_email_" + ProofItemID + "");
            if (checkBox.checked) {
                approverNameLbl.style.display = "block";
                approverName.style.display = "block";
                approverEmailLbl.style.display = "block";
                approverEmail.style.display = "block";
            }
            else {
                approverNameLbl.style.display = "none";
                approverName.style.display = "none";
                approverEmailLbl.style.display = "none";
                approverEmail.style.display = "none";
            }
        }
        function UpdateTwoStageApproval(ProofItemID) {
            var checkBox = document.getElementById("approval_chk_" + ProofItemID + "");
            var approverName = document.getElementById("approver_name_" + ProofItemID + "");
            var approverEmail = document.getElementById("approver_email_" + ProofItemID + "");
            if (approverName.value != '' && approverEmail.value != '') {
                if (validateEmail(approverEmail.value)) {
                    var dataValue = { "IsChecked": checkBox.checked, 'ProofItemID': ProofItemID, 'ApproverName': approverName.value, 'ApproverEmail': approverEmail.value };
                    $.ajax({
                        type: "POST",
                        url: "Proof_summary.aspx/UpdateTwoStageApproval",
                        data: JSON.stringify(dataValue),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                        },
                        success: function (result) {
                        }
                    });
                }
                else {
                    alert("You have entered an invalid email address!");

                }
            }
            else {
                alert("Please enter Approver Name and Email!");
            }
        }
        function validateEmail(email) {
            var re = /\S+@\S+\.\S+/;
            return re.test(email);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


