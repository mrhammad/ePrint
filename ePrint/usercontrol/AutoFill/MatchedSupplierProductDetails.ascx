<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchedSupplierProductDetails.ascx.cs" Inherits="ePrint.usercontrol.AutoFill.MatchedSupplierProductDetails" %>

<asp:Panel runat="server" ID="pnlitem">
   
        
   
    <div id="divText" style="float: left; border: solid 1px #868485; width: 479px; height: 165px;
        background-color: #EEEEEE;">
        <div  style="float: left;  border-bottom:1px solid #DADADA; width:100%"  >
        <ul>
        <table  width="90%" style="table-layout:fixed" >
            <tr>
                <td align="left" style="width: 24%; font-size:10.5; font-weight:bold">
                   <asp:Label ID="lblitmheader" style="margin-left:-20px">Item Code</asp:Label>
                </td>
                <td align="left" style="width: 24%; font-size:10.5px; font-weight:bold">
                   <asp:Label ID="lbltitleheader" style="margin-left:-35px" >Item Title</asp:Label>
                </td>
                <td align="left" style="width: 16%; font-size:10.5px; font-weight:bold">
                 <asp:Label ID="Label1" style="margin-left:-32px" >Customer <br /><span style=" margin-left:-32px"> Code</span></asp:Label>
                    
                </td>
                <td align="left" style="width: 24%; font-size:10.5px; font-weight:bold">
                     <asp:Label ID="Label2" style="margin-left:-20px" >Description</asp:Label>
                </td>
            </tr>
        </table>
        </ul>
        </div>
        <div style="clear: both">
        </div>
        <div class="arrowlistmenu" style="float: left; overflow-y: scroll; overflow-x: hidden;height: 130px;width: 479px; background-color:White; ">
            <ul>
                <asp:Repeater runat="server" ID="uc" >
                    <ItemTemplate>
                        <%--  <li><a href="#" onclick="BindResultItemCodeTitle('<%#Eval("PriceCatalogueID")%>','<%#Eval("ItemCode")%>','<%#Eval("ItemTitle")%>');">
                            <%#Eval("ItemCode")%>
                            -
                            <%#Eval("ItemTitle")%>
                            -
                            <%#Eval("CustomerCode")%>
                            -
                            <%#Eval("Description")%>
                        </a></li>--%>
                        <li><a  style="color:#10357F" href="#"  onclick="BindSuplierProductDetails('<%#Eval("PriceCatalogueID")%>','<%#Eval("ItemTitle")%>','<%#Eval("Description")%>',
                        '<%#Eval("Artwork")%>','<%#Eval("Color")%>','<%#Eval("Size")%>','<%#Eval("Material")%>','<%#Eval("Delivery")%>','<%#Eval("Finishing")%>','<%#Eval("Proofs")%>',
                        '<%#Eval("Packing")%>','<%#Eval("Notes")%>','<%#Eval("Instructions")%>','<%#Eval("CustomDescription1") %>','<%#Eval("CustomDescription2") %>','<%#Eval("CustomDescription3") %>','<%#Eval("CustomDescription4") %>',
                        '<%#Eval("CustomDescription5") %>','<%#Eval("CustomDescription6") %>','<%#Eval("CustomDescription7") %>','<%#Eval("CustomDescription8") %>','<%#Eval("CustomDescription9") %>','<%#Eval("CustomDescription10") %>',
                        '<%#Eval("CustomDescription11") %>','<%#Eval("CustomDescription12") %>','<%#Eval("CustomDescription13") %>','<%#Eval("CustomDescription14") %>','<%#Eval("CustomDescription15") %>','<%#Eval("CustomDescription16") %>','<%#Eval("CustomDescription17") %>',
                        '<%#Eval("CustomDescription18") %>','<%#Eval("CustomDescription19") %>','<%#Eval("CustomDescription20") %>','<%#Eval("CustomDescription21") %>','<%#Eval("CustomDescription22") %>','<%#Eval("CustomDescription23") %>','<%#Eval("CustomDescription24") %>','<%#Eval("CustomDescription25") %>' );">
                      
                            <table width="100%" style="table-layout:fixed">
                                <tr>
                                    <td   style=" width: 20%;">    <%-- border-right: 1px solid black;--%>
                                      <%#Eval("ItemCode")%>
                                    </td>
                                    <td style="width: 25%">
                                        <%#Eval("ItemTitleDisplay")%>
                                    </td>
                                    <td style="width: 20%">
                                        <%#Eval("CustomerCode")%>
                                    </td>
                                    <td style="width: 35%">
                                        <%#Eval("DescriptionDisplay")%>
                                    </td>
                                </tr>
                            </table>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both">
        </div>
    </div>
</asp:Panel>

