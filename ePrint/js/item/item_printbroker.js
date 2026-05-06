// JScript File
        
        function SendPhraseBookToPB(id, values, phrasetype, tooltip) 
        {
            values = trim12(values);
            if (phrasetype == 'PrintBroker Title') {
                txtTitleDescription.value = values;
                txtPBItemTitle.value = values;
            }
            if (phrasetype == 'PrintBroker Artwork') {
                txtArtworkDescription.value = values;
                txtPBArtwork.value = values;
            }
            if (phrasetype == 'PrintBroker Description') {
                txtOriginationDescription.value = values;
                txtPBDesign.value = values;
            }
            if (phrasetype == 'PrintBroker Colours') {
                txtColorDescription.value = values;
                txtPBColour.value = values;
            }
            if (phrasetype == 'PrintBroker Size') {
                txtSizeDescription.value = values;
                txtPBSize.value = values;
            }
            if (phrasetype == 'PrintBroker Material') {
                txtMaterialDescription.value = values;
                txtPBMaterials.value = values;
            }
            if (phrasetype == 'PrintBroker Delivery') {
                txtDeliveryDescription.value = values;
                txtPBDelivery.value = values;
            }
            if (phrasetype == 'PrintBroker Finishing') {
                txtFinishingDescription.value = values;
                txtPBFinishing.value = values;
            }
            if (phrasetype == 'PrintBroker Notes') {
                txtNotesDescription.value = values;
                txtPBNotes.value = values;
            }
            if (phrasetype == 'PrintBroker Terms') {
                txtTermsDescription.value = values;
                txtPBInstructions.value = values;
            }
        }
        function GetPBPhraseBook(para,type)
        {
            if(para=="header")
            {
                //PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
                window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
            else if(para=="footer")
            {
               // PopupCenter(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400')
                window.radopen(strSitepath + "common/phrase_book.aspx?type=" + type, '800', '400');
                SetRadWindow('divrad', 'divBackGroundNew', '200');

            }
        }
        function Send_PrintBroker_Phrases(id, values, phrasetype, tooltip)
        {
            if(phrasetype=="PrintBroker Header")
            {
               spn_PrintBroker_Header.innerHTML = values;
               spn_PrintBroker_Header.title  = values;
            }
            else if(phrasetype=="PrintBroker Footer")
            {
               spn_PrintBroker_Footer.innerHTML = values;
               spn_PrintBroker_Footer.title  = values;
            }
        }
        
        var IsEntered = false;
        var roundTrip = 0;
        function CreatePriceComparison(supObj) 
        {
            debugger
            var supValue = supObj.options[supObj.selectedIndex].value;

            for (var i = 1; i < labelCount; i++) 
            {
                var supObj_2 = document.getElementById("ddlSupplier_" + i);
                if (supObj_2 != null) 
                {
                    if (supObj_2.id != supObj.id) 
                    {
                        if (supObj_2.value == supValue) 
                        {
                            supObj.selectedIndex = 0;
                            var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                            if (divPriceObj != null) 
                            {
                                var PriceTable = document.getElementById("PriceTable");
                                var chil = document.getElementById("Price_tr_" + supObj.id + "");
                                PriceTable.removeChild(chil);
                            }
                            return false;
                        }
                        else 
                        {
                            var divPriceObj = document.getElementById("divPriceComparision_" + supObj.id);
                            if (divPriceObj != null) 
                            {
                                var PriceTable = document.getElementById("PriceTable");
                                var chil = document.getElementById("Price_tr_" + supObj.id + "");
                                PriceTable.removeChild(chil);
                            }
                        }
                    }
                }
            }

            var txtSingleQty = '';
            var txtRunQty1 = ''; var txtRunQty2 = '';
            var txtMultiQty1 = ''; var txtMultiQty2 = ''; var txtMultiQty3 = ''; var txtMultiQty4 = '';

            var uniData = '';
            if (supValue != "0" && supValue != '') 
            {
                //TotalSup +=supObj.options[supObj.selectedIndex].value+"±"+supObj.options[supObj.selectedIndex].text+"µ";
                if (qtyType == "single") 
                {
                    qtyCount = 1;
                    txtSingleQty = txtSingleQty1.value;
                }
                else if (qtyType == "multiple") 
                {
                    qtyCount = 4;
                    txtMultiQty1 = txtMultiQty11.value;
                    txtMultiQty2 = txtMultiQty22.value;
                    txtMultiQty3 = txtMultiQty33.value;
                    txtMultiQty4 = txtMultiQty44.value;
                }
                else if (qtyType == "runon") 
                {
                    qtyCount = 2;
                    txtRunQty1 = txtRunQty11.value;
                    txtRunQty2 = txtRunQty22.value;
                }
                uniData += "<div id=divPriceComparision_" + supObj.id + ">";

                for (var j = 1; j <= qtyCount; j++) 
                {
                    var name = supObj.options[supObj.selectedIndex].text;
                    if (j != 1) 
                    {
                        name = '&nbsp;';
                    }
                    var QtyValue = '';
                    if (qtyType == "single") 
                    {
                        QtyValue = txtSingleQty;
                    }
                    else if (qtyType == "runon") 
                    {
                        if (j == 1) 
                        {
                            QtyValue = txtRunQty1;
                        }
                        else if (j == 2) 
                        {
                            QtyValue = txtRunQty2;
                        }
                    }
                    else if (qtyType == "multiple") 
                    {
                        if (j == 1) 
                        {
                            QtyValue = txtMultiQty1;
                        }
                        else if (j == 2) 
                        {
                            QtyValue = txtMultiQty2;
                        }
                        else if (j == 3) 
                        {
                            QtyValue = txtMultiQty3;
                        }
                        else if (j == 4) 
                        {
                            QtyValue = txtMultiQty4;
                        }
                    }
                    
                    var comnID = supValue + '_' + j;
                    uniData += "<div class='onlyEmpty'></div>";
                    uniData += "<div align='left' >";
                    uniData += "<div style='float: left; width: 13%'>" + name + "</div>";
                    uniData += "<div style='float: left; width: 10%'><input id='txtQty_" + comnID + "' type='text'  value='" + QtyValue + "' class='textboxnew' style='Width:95%;' disabled='true' /></div>";
                    uniData += "<div style='float: left; width: 10%'><input id='txtCost_" + comnID + "' type='text'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');NumberToDecimal(this.id,this.value);\"' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                    uniData += "<div style='float: left; width: 10%'><select id='ddlDeliveryIncluded_" + comnID + "' onchange=DropdownChange(this,'txtDeliveryCost_" + comnID + "'); style='Width:85%' class='normaltext'><option value='yes'>yes</option><option value='no'>No</option></select></div>";
                    if (roundTrip == 0) 
                    {
                        uniData += "<div style='float: left; width: 10%'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" onblur=\"javascript:CopyDate(" + supValue + "," + qtyCount + ",this.value);\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                    }
                    else 
                    {
                        uniData += "<div style='float: left; width: 10%'><input id='txtDeliveryDate_" + comnID + "'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'" + DateFormatNEW + "');\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                    }
                    uniData += "<div style='float: left; width: 10%'><input id='txtDeliveryCost_" + comnID + "' disabled='true'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                    if (roundTrip == 0) 
                    {
                        uniData += "<div style='float: left; width: 10%'><select id='ddlMarkup_" + comnID + "' style='Width:85%' onchange=javascript:CopyMarkup(this.value," + supValue + "," + qtyCount + ");  class='normaltext'><option value='percentage'>%</option><option value='fixedvalue'>" + GetCurrencyinRequiredFormate("",true) + "</option></select></div>";
                        uniData += "<div style='float: left; width: 9%'><input id='txtMarkup_" + comnID + "'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');NumberToDecimal(this.id,this.value);CopyMarkupValue(this.value," + supValue + "," + qtyCount + ");\"' type='text' class='textboxnew' style='Width:95%' value='' maxlength='5'  /></div>";
                    }
                    else 
                    {
                        uniData += "<div style='float: left; width: 10%'><select id='ddlMarkup_" + comnID + "' style='Width:85%'  class='normaltext'><option value='percentage'>%</option><option value='fixedvalue'>" + GetCurrencyinRequiredFormate("",true) + "</option></select></div>";
                        uniData += "<div style='float: left; width: 9%'><input id='txtMarkup_" + comnID + "'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%' value='' maxlength='5'  /></div>";
                    }

                    uniData += "<div style='float: left; width: 10%'><input id='txtTotalPrice_" + comnID + "' onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');\" type='text' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                    uniData += "<div style='float: left; width: 10%'><input id='txtPer1000TotalPrice_" + comnID + "'readonly onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('" + comnID + "');\" type='text' class='textboxnew' style='Width:95%' maxlength='9' /></div>";

                    uniData += "<div style='float: right; width: 6%;padding-right:10px'><input id='chk_" + comnID + "' name='chk_ow' type='checkbox' onclick=\"javascript:SelectOneSuppler('" + comnID + "');\" /></div>";
                    uniData += "</div>";
                    uniData += "<div class='onlyEmpty'></div>";

                } // last for
                uniData += "<div style='padding:2px 0px 4px 0px;'><div class='onlyEmpty' style='border:1px solid #ccc;'></div></div>";
                uniData += "</div>";
            } // end of if

            var row = document.createElement("tr");
            row.id = "Price_tr_" + supObj.id + "";
            var cell = document.createElement("td");
            cell.innerHTML = uniData;
            row.appendChild(cell);
            document.getElementById("PriceTable").appendChild(row);

            priceNo++;
            roundTrip++;
            
            if(funreqtype()!="edit")
            {
                var input_cc = new Array();
                input_cc = document.getElementsByName("chk_ow");
                for (var i = 0; i < input_cc.length; i++) 
                {
                    var ch_arr = input_cc[i].id.split('_');
                    if (i == 0) 
                    {
                        input_cc[i].checked = true;
                    }
                    else 
                    {
                        if (ch_arr[2] == 1) 
                        {
                            //input_cc[i].disabled = true;
                        }
                    }
                }
            }
        }

        //***** To Bind Default RFQ Data of PrintBroker BY SWETHA******///
        function BindDefaultRFQData() 
        {
            var txtPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBItemTitle");
            var txtPBDesign = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBDesign");
            var txtPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBArtwork");
            var txtPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBColour");
            var txtPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBSize");
            var txtPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBMaterials");
            var txtPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBFinishing");
            var txtPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBDelivery");
            var txtPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBNotes");
            var txtPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txtPBInstructions");

            var txt_lblPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBItemTitle");
            var txt_lblPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBDescription");
            var txt_lblPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBArtwork");
            var txt_lblPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBColour");
            var txt_lblPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBSize");
            var txt_lblPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBMaterials");
            var txt_lblPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBFinishing");
            var txt_lblPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBDelivery");
            var txt_lblPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBNotes");
            var txt_lblPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_txt_lblPBInstructions");

            var chkPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBItemTitle");
            var chkPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBDescription");
            var chkPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBArtwork");
            var chkPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBColour");
            var chkPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBSize");
            var chkPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBMaterials");
            var chkPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBDelivery");
            var chkPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBFinishing");
            var chkPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBNotes");
            var chkPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_chkPBInstructions");

            var hdn_lblPBItemTitle = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBItemTitle");
            var hdn_lblPBDescription = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBDescription");
            var hdn_lblPBArtwork = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBArtwork");
            var hdn_lblPBColour = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBColour");
            var hdn_lblPBSize = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBSize");
            var hdn_lblPBMaterials = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBMaterials");
            var hdn_lblPBDelivery = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBDelivery");
            var hdn_lblPBFinishing = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBFinishing");
            var hdn_lblPBNotes = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBNotes");
            var hdn_lblPBInstructions = document.getElementById("ctl00_ContentPlaceHolder1_UCStage1_UCItemAdd_hdn_lblPBInstructions");

            //Values//
            txtPBItemTitle.value = txtTitleDescription.value;
            txtPBDesign.value = txtOriginationDescription.value;
            txtPBArtwork.value = txtArtworkDescription.value;
            txtPBColour.value = txtColorDescription.value;
            txtPBSize.value = txtSizeDescription.value;
            txtPBMaterials.value = txtMaterialDescription.value;
            txtPBFinishing.value = txtFinishingDescription.value;
            txtPBDelivery.value = txtDeliveryDescription.value;
            txtPBNotes.value = txtNotesDescription.value;
            txtPBInstructions.value = txtTermsDescription.value;

            //Label//
            txt_lblPBItemTitle.value = txtTitle.value;
            hdn_lblPBDescription.value = txtOrigination.value;
            hdn_lblPBArtwork.value = txtArtwork.value;
            hdn_lblPBColour.value = txtColor.value;
            hdn_lblPBSize.value = txtSize.value;
            hdn_lblPBMaterials.value = txtMaterial.value;
            hdn_lblPBFinishing.value = txtFinishing.value;
            hdn_lblPBDelivery.value = txtDelivery.value;
            hdn_lblPBNotes.value = txtNotes.value;
            hdn_lblPBInstructions.value = txtTerms.value;

            hdn_lblPBItemTitle.value = txtTitle.value;
            txt_lblPBDescription.value = txtOrigination.value;
            txt_lblPBArtwork.value = txtArtwork.value;
            txt_lblPBColour.value = txtColor.value;
            txt_lblPBSize.value = txtSize.value;
            txt_lblPBMaterials.value = txtMaterial.value;
            txt_lblPBFinishing.value = txtFinishing.value;
            txt_lblPBDelivery.value = txtDelivery.value;
            txt_lblPBNotes.value = txtNotes.value;
            txt_lblPBInstructions.value = txtTerms.value;


            //Chk Boxes//
            chkPBItemTitle.checked = chkOutItemTitle.checked;
            chkPBDescription.checked = chkOutDescription.checked;
            chkPBArtwork.checked = chkOutArtwork.checked;
            chkPBColour.checked = chkOutColour.checked;
            chkPBSize.checked = chkOutSize.checked;
            chkPBMaterials.checked = chkOutMaterial.checked;
            chkPBDelivery.checked = chkOutDelivery.checked;
            chkPBFinishing.checked = chkOutFinishing.checked;
            chkPBNotes.checked = chkOutNotes.checked;
            chkPBInstructions.checked = chkOutInstructions.checked;
        }

        function OpenUpload() 
        {
           // PopupCenter(strSitepath + "estimates/artwork_files_upload_0.aspx?pg=" + UcPage, '800', '400');
            window.radopen(strSitepath + "estimates/artwork_files_upload_0.aspx?pg=" + UcPage, '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        
        function getPBItemTitle(txtVal)
        {
            //To make Item desc values null in case of Sub Item //
            if (IsMain == 'no')
            {
                txtTitleDescription.value = txtVal;
                txtOriginationDescription.value = "";
                txtArtworkDescription.value = "";
                txtColorDescription.value = "";
                txtSizeDescription.value = "";
                txtMaterialDescription.value = "";
                txtDeliveryDescription.value = "";
                txtFinishingDescription.value = "";
                txtNotesDescription.value = "";
                txtTermsDescription.value = "";
            }
            
            //Only In Add Case//
            if (hdn_OutworkDesc.value != '')
            {
                txtTitleDescription.value = txtVal;                
            }
        }

        function BindOutworkDesc() {
            if (hdn_OutworkDesc.value != '') {
                var str = hdn_OutworkDesc.value.split('µ');
                var str2 = '';
                for (var i = 0; i < str.length; i++) {
                    str2 = str[i].split('»');
                    if (str2[1] == "ItemTitle" && str2[3] == "1") {
                        div_OutItemTitle.style.display = "block";
                        txtTitle.value = str2[2];
                    }
                    if (str2[1] == "Description" && str2[3] == "1") {
                        div_OutDescription.style.display = "block";
                        txtOrigination.value = str2[2];
                    }
                    else {
         // Changes Made on 25.07.2011 
                        txtOrigination.value != '' ? div_OutDescription.style.display = "block" : div_OutDescription.style.display = "none";
                    }
                    if (str2[1] == "Artwork" && str2[3] == "1") {
                        div_OutArtwork.style.display = "block";
                        txtArtwork.value = str2[2];
                    }
                    else {
                        txtArtwork.value != '' ? div_OutArtwork.style.display = "block" : div_OutArtwork.style.display = "none";          
                    }
                    
                    if (str2[1] == "Color1" && str2[3] == "1") {
                        div_OutColour.style.display = "block";
                        txtColor.value = str2[2];
                    }
                    else {
                        txtColor.value != '' ? div_OutColour.style.display = "block" : div_OutColour.style.display = "none";    
                    }
                    
                    if (str2[1] == "Size" && str2[3] == "1") {
                        div_OutSize.style.display = "block";
                        txtSize.value = str2[2];
                    }
                    else {
                        txtSize.value != '' ? div_OutSize.style.display = "block" : div_OutSize.style.display = "none";    
                    }
                    
                    if (str2[1] == "Material" && str2[3] == "1") {
                        div_OutMaterial.style.display = "block";
                        txtMaterial.value = str2[2];
                    }
                    else {
                        txtMaterial.value != '' ? div_OutMaterial.style.display = "block" : div_OutMaterial.style.display = "none";             
                    }
                    
                    
                    if (str2[1] == "Delivery" && str2[3] == "1") {
                        div_OutDelivery.style.display = "block";
                        txtDelivery.value = str2[2];
                    }
                    else {
                        txtDelivery.value != '' ? div_OutDelivery.style.display = "block" : div_OutDelivery.style.display = "none"; 
                    }
                    
                    
                    if (str2[1] == "Finishing" && str2[3] == "1") {
                        div_OutFinishing.style.display = "block";
                        txtFinishing.value = str2[2];
                    }
                    else {
                        txtFinishing.value != '' ? div_OutFinishing.style.display = "block" : div_OutFinishing.style.display = "none";
                    }

                    if (str2[1] == "Proofs" && str2[3] == "1") {
                        div_OutProofs.style.display = "block";
                        txtProofs.value = str2[2];
                    }
                    else {
                        txtProofs.value != '' ? div_OutProofs.style.display = "block" : div_OutProofs.style.display = "none";
                    }

                    if (str2[1] == "Packing" && str2[3] == "1") {
                        div_OutPacking.style.display = "block";
                        txtPacking.value = str2[2];
                    }
                    else {
                        txtPacking.value != '' ? div_OutPacking.style.display = "block" : div_OutPacking.style.display = "none";
                    }


                    if (str2[1] == "Notes" && str2[3] == "1") {
                        div_OutNotes.style.display = "block";
                        txtNotes.value = str2[2];
                    }
                    else {
                        txtNotes.value != '' ? div_OutNotes.style.display = "block" : div_OutNotes.style.display = "none";             
                    }
                    
                    
                    if (str2[1] == "Instructions" && str2[3] == "1") {
                        div_OutInstructions.style.display = "block";
                        txtTerms.value = str2[2];
                    }
                    else {
                        txtTerms.value != '' ? div_OutInstructions.style.display = "block" : div_OutInstructions.style.display = "none";
                    }
                }
            }
        }
//            else
//            {
//                if(IsMain=="yes")
//                {
//                    txtOrigination.value != '' ? div_OutDescription.style.display = "block" : div_OutDescription.style.display = "none";  
//                    txtArtwork.value != '' ? div_OutArtwork.style.display = "block" : div_OutArtwork.style.display = "none";          
//                    txtColor.value != '' ? div_OutColour.style.display = "block" : div_OutColour.style.display = "none";    
//                    txtSize.value != '' ? div_OutSize.style.display = "block" : div_OutSize.style.display = "none";    
//                    txtMaterial.value != '' ? div_OutMaterial.style.display = "block" : div_OutMaterial.style.display = "none";             
//                    txtDelivery.value != '' ? div_OutDelivery.style.display = "block" : div_OutDelivery.style.display = "none"; 
//                    txtFinishing.value != '' ? div_OutFinishing.style.display = "block" : div_OutFinishing.style.display = "none";

//                    txtProofs.value != '' ? div_OutProofs.style.display = "block" : div_OutProofs.style.display = "none";
//                    txtPacking.value != '' ? div_OutPacking.style.display = "block" : div_OutPacking.style.display = "none";
//                    
//                    txtNotes.value != '' ? div_OutNotes.style.display = "block" : div_OutNotes.style.display = "none";             
//                    txtTerms.value != '' ? div_OutInstructions.style.display = "block" : div_OutInstructions.style.display = "none";             
//                }
//                else
//                {
//                    div_OutDescription.style.display = "block";
//                    div_OutArtwork.style.display = "block";          
//                    div_OutColour.style.display = "block";    
//                    div_OutSize.style.display = "block";    
//                    div_OutMaterial.style.display = "block";             
//                    div_OutDelivery.style.display = "block";
//                    div_OutFinishing.style.display = "block";

//                    div_OutProofs.style.display = "block";
//                    div_OutPacking.style.display = "block";
//                    
//                    div_OutNotes.style.display = "block";             
//                    div_OutInstructions.style.display = "block";  
//                }
//            }
//        }
        
        var si=0;
        function ArtWorkMore()
        {
          if(si<=1)
          {  
              var ArtWork_Content=document.getElementById("div_ArtWork_Content");  
              var ArtWork_More=document.getElementById("div_ArtWork_More");
              var str="<div align='left' id='div_art_"+si+"' ><div class='bglabel'><span class='normaltext'>Art Work<span> </div>";
              str +="<div class='box' style='padding-top:5px;'> <input id='txt_Art_work_"+si+"' type='file'  class='UploadClass' /></div></div>"
              ArtWork_More.innerHTML= ArtWork_More.innerHTML + str;
              si++;
          }
        }
                    
                    function ArtWorkMoreRemove(para1)
                    {
                        if(si>0)
                        {
                            si=si-1;
                            var ctrl;
                            ctrl = document.getElementById('div_ArtWork_More');
                            var chil=document.getElementById("div_art_"+si+"");
                            ctrl.removeChild(chil);
                        }
                    }
                    
                    function GenrateSupplierList()
                    {
                        if(OptionData=='')
                        {
                            OptionData = "<option selected='selected' value=0>--- Select ---</option>"                        
                            var supData = '';//strSupList.value;
                            //supData = supData.replace(/'/gi, "`");
                            PageMethods.GetSuppliers_List(CompanyID,function SList(retnValue)
                            {
                                var strSupArray = retnValue.split('±');
                                for (var i = 0; i < strSupArray.length; i++)
                                {
                                    var arr1 = strSupArray[i].split('»');
                                    //////ddl1.options.add(new Option(arr1[1],arr1[0],i+1));
                                    if(arr1[1]!='')
                                    {
                                        OptionData+="<option value='"+arr1[0]+"'>"+arr1[1]+"</option>"
                                    }
                                }
                                
                            },SList_error);
                        }
                    }
                   
                 function SList_error(err){}
                    
                 function add_more()
                 {
                      var Suppliers=OptionData; 
                      
                      var div_content=document.getElementById("divtest");
                      var div_add=document.getElementById("div_added");
                      var tcount=document.getElementById("hdn_count");
                      var finalcontent="";
                      if(supCount<=12)
                      {
                          var SupData="<div id='div_supplier"+labelCount+"'>";
                              SupData+="<div align='left' style='width:49%;'>";
                                    SupData+="<div align='left'><span class='HeaderText' id='spn_supheader_"+labelCount+"' >Supplier "+labelCount+"</span></div>";
                                    SupData+="<div align='left'>";
                                        SupData+="<div class='bglabel'>Name</div>";
                                        SupData+="<div class='box'><select id='ddlSupplier_"+labelCount+"' onchange=\"javascript:loadContacts(this.value,"+labelCount+");CreatePriceComparison(this);\"  class='normaltext' style='width:175px;'>"+Suppliers+"</select></div>";
                                    SupData+="</div>";
                                    //////*******//////
                                    SupData+="<div align='left'>";
                                       SupData+="<div class='bglabel'>Contact</div>";
                                       SupData+="<div class='box'><select id='ddlSupplierContact_"+labelCount+"' class='normaltext' style='width:175px;'><option value='0' >--- Select ---</option></select>";
                                       
                                       SupData+="&nbsp;<a href='#' onclick=javascript:RemoveThisSupplier('"+labelCount+"');RemoveTableRow('"+rowno+"'); >Remove</a>";
                                       
                                       SupData+="</div>";
                                    SupData+="</div>";
                              SupData+="</div>";
                              SupData+="<div class='onlyEmpty' style='border-bottom: 1px solid silver;width:99%;'></div>";
                              SupData+="</div>";
                              //div_add.innerHTML = div_add.innerHTML + SupData;                                    
                            
                            var row = document.createElement("tr");
                            row.id ="tr_"+rowno+"";
                            var cell = document.createElement("td");
                            cell.innerHTML = SupData;
                            row.appendChild(cell);
                            tableSup.appendChild(row);
                                
                            rowno++;  
                            labelCount++;
                            supCount++;
                            var nu=1;
                            for(var i=1;i<labelCount;i++)
                            {
                                if(document.getElementById("spn_supheader_"+i+"")!=null)
                                {
                                   document.getElementById("spn_supheader_"+i+"").innerHTML="Supplier "+nu+"";
                                   nu++;
                                }
                            }
                       }  
                      document.getElementById("div_scroll").scrollTop=5000;
                  }  
                          
                  function loadContacts(val,num,conID)
                  {
                        
                        var ddl=document.getElementById("ddlSupplierContact_"+num);
                        var ddlsupp = document.getElementById("ddlSupplier_"+num);
                        ddl.length=0;
                        ddl.options.add(new Option('--- Select ---','0',0));   
                        
                        var k=0;
                        ///var strContArray = strContList.value.split('±');
                        if(val==0)
                        {
                           return false;
                        }
                        var defaultIndex = 0;
                        
                        PageMethods.GetContacts(CompanyID,val,function Clist(retnValue)
                                {
                                    retnValue = retnValue.replace(/'/gi, "`");
                                    var strContArray = retnValue.split('±');
                                    var OptionDataContact='';
                                    for (var j = 0; j < strContArray.length; j++)
                                    {
                                        var arr2 = strContArray[j].split('»');
                                        
                                        if(arr2[1]!='' && arr2[1]!=null)
                                        {
                                            ddl.options.add(new Option(arr2[1],arr2[0],j));
                                            if(conID!=null)//WHEN EDIT
                                            {
                                                if(arr2[0]==conID)
                                                {
                                                    defaultIndex= Number(j)+ 1;
                                                }
                                            }
                                            else 
                                            {
                                                if(arr2[2]==1)
                                                {
                                                    defaultIndex= Number(j)+ 1;
                                                }
                                            }
                                        }
                                        k++;
                                    }
                                    ddl.selectedIndex = defaultIndex;
                                },Clist_error);
                         
                  }
                  function Clist_error(err){}
                          
                            function remove_supplier()
                            {
                                if(supCount!=2)
                                { 
                                    supCount=supCount-1;
                                    var nu=Number(supCount);
                                    var ctrl;
                                    ctrl = document.getElementById('div_added');
                                    var chil=document.getElementById("div_supplier"+supCount+"");
                                    ctrl.removeChild(chil);
                                }
                            }
                            function RemoveTableRow(nu)
                            {
                               var chil = document.getElementById("tr_"+nu+"");
                               tableSup.removeChild(chil);
                               
                                var nu=1;
                                for(var i=1;i<labelCount;i++)
                                {
                                    if(document.getElementById("spn_supheader_"+i+"")!=null)
                                    {
                                       document.getElementById("spn_supheader_"+i+"").innerHTML="Supplier "+nu+"";
                                       nu++;
                                    }
                                }
                            }
                            function RemoveThisSupplier(supCNT)
                            {
                                var supObj = document.getElementById("ddlSupplier_"+supCNT);
                                if(supObj!=null)
                                {
                                    var PriceTable = document.getElementById("PriceTable");
                                    var chil = document.getElementById("Price_tr_"+supObj.id+"");
                                    if(chil!=null)
                                    {
                                        PriceTable.removeChild(chil);
                                    }
                                    supCount--;
                                } 
                             }
                             
                            function CheckQuoteReceived(chkid,divChk)
                            {
                                var chk=document.getElementById(chkid);
                                if(chk.checked==true)
                                 {
                                    document.getElementById(divChk).style.display="block";
                                 }
                                 else
                                 {
                                  document.getElementById(divChk).style.display="none";
                                 }
                             }
                              function ChangeLabel()
                            {
                                document.getElementById("lblheader").innerHTML=Stage4Name;
                            }
                            
                    var qtyCount = 0;
                    var priceNo = 0;
                    function PbNextBtn(next,prev)
                    {
                        document.getElementById("div_none").style.display="none";
                        document.getElementById("div_qty").style.display="none";
                        document.getElementById("div_print_broker_step_1").style.display="none";
                        document.getElementById("div_print_broker_step_2").style.display="none";
                        document.getElementById("div_print_broker_step_3").style.display="none";
                        //summary
                        document.getElementById("div_stage_4").style.display="none";
                        document.getElementById(div_PrintBrokerSummary).style.display="none";
                        btn_Outwork_PrintEmail.style.display="none";
                        document.getElementById("li_print_email").style.display="none";
                        
                        if(next=="1")
                        {
                            document.getElementById("div_print_broker_step_1").style.display="block";
                            document.getElementById("lblheader").innerHTML="RFQ Description";
                        }
                        else if(next=="2")
                        {
                            CheckQtyType();                
                            if(Stpe1Vaild())
                            {
                                document.getElementById("div_print_broker_step_2").style.display="block";
                                document.getElementById("lblheader").innerHTML="Supplier Selection";
                                
                                btn_Outwork_PrintEmail.style.display="block";
                                document.getElementById("li_print_email").style.display="block";
                            }
                            else
                            {
                               document.getElementById("div_print_broker_step_1").style.display="block";
                               document.getElementById("lblheader").innerHTML="RFQ Description";
                            }
                        }
                        else if(next=="3")
                        {
                              if(SupplierSelectionCheck())
                              {
                                document.getElementById("div_print_broker_step_3").style.display="block";
                                document.getElementById("lblheader").innerHTML="Price Comparison";
                                
                                  if (ddlCostingType.selectedIndex == 0)
                                  {
                                      document.getElementById("div_simplecosting").style.display = "none";
                                      document.getElementById("div_unitcosting").style.display = "block";
                                      document.getElementById("div_per1000costing").style.display = "none";
                                  }
                                  if (ddlCostingType.selectedIndex == 1)
                                  {
                                      document.getElementById("div_simplecosting").style.display = "block";
                                      document.getElementById("div_unitcosting").style.display = "none";
                                      document.getElementById("div_per1000costing").style.display = "none";
                                  }
                                  if (ddlCostingType.selectedIndex == 2) {
                                      document.getElementById("div_simplecosting").style.display = "none";
                                      document.getElementById("div_unitcosting").style.display = "none";
                                      document.getElementById("div_per1000costing").style.display = "block";
                                  }
                              }  
                              else
                              {
                                document.getElementById("div_print_broker_step_2").style.display="block";
                                document.getElementById("lblheader").innerHTML="Supplier Selection";
                              }
                        }
                        else if(next=="4")
                        {
                            if(Step4Validation())
                            {
                                if(IsPrintBrokerDirect)
                                {
                                    document.getElementById("div_stage_4").style.display="block";
                                    document.getElementById(div_PrintBrokerSummary).style.display="block";
                                    document.getElementById("lblheader").innerHTML="Item Description";                        
                                    BindDefaultRFQData();
                                    //BindOutworkDesc();//To bind Outwork/Print Broker item description
                                    beforeChange = document.getElementById("div_load").innerHTML;
                                }
                                else
                                {
                                    SaveOutWork();
                                    ShowOutworkList();
                                    document.getElementById("div_print_broker_step_1").style.display="block";
                                    PrintBrokerPrevious('CreateItem');
                                    tempEstimateType = '';  
                                }
                            }
                            else
                            {
                                document.getElementById("div_print_broker_step_3").style.display="block";
                            }
                        }
                         
                    }
                        
                         function DivPriceCompClear()
                        {
                            var doChnage=true;
                            if(IsEdit && document.getElementById("div_load").innerHTML!='')
                            {
                                doChnage = window.confirm('If you change the Costing Type this will erase the Previous Data. Do want to go ? ');
                            }
                            if(doChnage)
                            {
                                DivPriceCompClear_part_2();
                            }
                            else
                            {
                                //When changes 
                                ddlCostingType.value = ddlCostingType.value=="unit" ? "simple" : "unit";
                            }
                        }
                        
                        function DivPriceCompClear_part_2()
                        {
                            document.getElementById("div_load").innerHTML='';
                            for(var i=1; i<labelCount;i++)
                            {
                                var supObj = document.getElementById("ddlSupplier_"+i);
                                if(supObj!=null)
                                {
                                    var PriceTable = document.getElementById("PriceTable");
                                    var chil = document.getElementById("Price_tr_"+supObj.id+"");
                                    if(chil!=null)
                                    {
                                        PriceTable.removeChild(chil);
                                    }
                                    supCount--;
                                    
                                    var contObj=document.getElementById("ddlSupplierContact_"+i);
                                    supObj.selectedIndex=0;
                                    contObj.selectedIndex=0;
                                }
                            }
                         } 
                         
                         

        function CopyDate(supplierID,RowCount,txtValue)
        {
            var tableObj = document.getElementById("PriceTable");
            var collection = tableObj.getElementsByTagName('INPUT');
            for (var x=0; x<collection.length; x++) 
            {
               var txtID = collection[x].id;
               if (collection[x].type.toUpperCase()=='TEXT' && txtID.search("txtDeliveryDate_") > -1)
               {
                   if(collection[x].value =="")
                   {
                       collection[x].value=txtValue;
                   }
               }
            }
            
            /*
            for(var i=1;i<=RowCount;i++)
            {
              if(document.getElementById("txtQty_"+supplierID+"_"+i+"").value!='')
              {
                  if(txtValue!='')
                  {
                    document.getElementById("txtDeliveryDate_"+supplierID+"_"+i+"").value=txtValue;
                  }
              }
            }
            */
        }
        
        function CopyMarkup(ddlvalue,supplierID,RowCount)
        {
            var tableObj = document.getElementById("PriceTable");
            var collection = tableObj.getElementsByTagName('SELECT');
            for (var x=0; x<collection.length; x++) 
            {
               var ddlID = collection[x].id;
               if (ddlID.search("ddlMarkup_") > -1)
               {
                    if(ddlvalue=='fixedvalue')
                    {  
                        collection[x].selectedIndex=1;
                    }
                    else
                    {
                        collection[x].selectedIndex=0;
                    }
               }
            }
            
            /*for(var i=1;i<=RowCount;i++)
            {
             if(document.getElementById("txtQty_"+supplierID+"_"+i+"").value!='')
              {
                  if(ddlvalue=='fixedvalue')
                  {  
                    document.getElementById("ddlMarkup_"+supplierID+"_"+i+"").selectedIndex=1;
                  }
                  else
                  {
                     document.getElementById("ddlMarkup_"+supplierID+"_"+i+"").selectedIndex=0;
                  }
              }
            }
            */
        }
         
       function CopyMarkupValue(txtvalue,supplierID,RowCount)
       {
            var tableObj = document.getElementById("PriceTable");
            var collection = tableObj.getElementsByTagName('INPUT');
            for (var x=0; x<collection.length; x++) 
            {
               var txtID = collection[x].id;
               if (collection[x].type.toUpperCase()=='TEXT' && txtID.search("txtMarkup_") > -1)
               {
                   if(collection[x].value =="")
                   {
                       collection[x].value=txtvalue;
                   }
               }
            }
            /*for(var i=1;i<=RowCount;i++)
            {
              if(document.getElementById("txtQty_"+supplierID+"_"+i+"").value!='')
              {
                  if(txtvalue!='')
                  {
                     document.getElementById("txtMarkup_"+supplierID+"_"+i+"").value=txtvalue;
                    var comnID=supplierID+'_'+i;
                    CalculatePrice(comnID);
                  }
               }
            }
            */
        }
        
        var beforechange = '';
        function printbrokerprevious4()
        {
          document.getElementById("div_print_broker_step_3").style.display="block";
          document.getElementById("lblheader").innerhtml="price comparison";
          document.getElementById("div_stage_4").style.display="none";
        }
        
          function CalculatePrice(ext)
        {
           var txtCost=document.getElementById("txtCost_"+ext).value;
           var ddlDeliveryIncluded=document.getElementById("ddlDeliveryIncluded_"+ext).value;
           var txtDeliveryCost=document.getElementById("txtDeliveryCost_"+ext).value;
           var ddlMarkup=document.getElementById("ddlMarkup_"+ext).value;
           var txtMarkup=document.getElementById("txtMarkup_"+ext).value;
           var txtTotalPrice=document.getElementById("txtTotalPrice_"+ext);
           
           var Delivery=0;
           var Markup=0;
           if(trim12(txtCost)!='')
           {
                
                if(ddlDeliveryIncluded=="no")
                {
                    if(trim12(txtDeliveryCost)!='')
                    {
                       Delivery=Number(txtDeliveryCost);
                    }
                }
                if(ddlMarkup=="percentage")
                {
                    Markup=Number(Number(txtCost)* Number(txtMarkup)/Number(100));
                }
                else if(ddlMarkup=="fixedvalue")
                {
                    Markup=Number(txtMarkup); 
                }
                var total=Number(txtCost)+Number(Delivery)+Number(Markup);
                txtTotalPrice.value=total;
                
                NumberToDecimal(txtTotalPrice.id,txtTotalPrice.value);
           }
           
           //document.getElementById("txtTotalPrice_"+ext).value;
        }
        
        
         function SupplierSelectionCheck()
        {
            var IsValidToGo=false;
            var checkcnt=labelCount-1;
            //duplicacy check
            var arr1 =new Array();
            var arr2 =new Array();
            for(var i=1;i<=checkcnt;i++)
            {
                var supObj=document.getElementById("ddlSupplier_"+i);
                if(supObj!=null)
                {
                    var contObj=document.getElementById("ddlSupplierContact_"+i);
                    var supValue=supObj.options[supObj.selectedIndex].value;
                    
                    if(supValue!="0")
                    {
                        IsValidToGo=true;
                        arr1.push(supValue);
                        arr2.push(supValue);
                    }
                }    
            }    
            if(IsValidToGo==false)
            {
                document.getElementById("div_none").style.display="block";
                document.getElementById("span_none").innerHTML="Please select at least one supplier";
            }
            /*
            for(var i=0;i<arr1.length;i++)
            {
                for(var j=0;j<arr2.length;j++)
                {
                    if(i!=j)
                    {
                        if(arr1[i]==arr1[j])
                        {
                            IsValidToGo=false;
                            document.getElementById("div_none").style.display="block";
                            document.getElementById("span_none").innerHTML="Spplier Name is selected twice, please check once again !";
                        }
                    }
                }    
            }
            */
            return IsValidToGo;
        }
        
        function SelectOneSuppler(num)
        {   
            
            var ComnIDArray=num.split('_');
            var RowIndex = ComnIDArray[1]; // by  VINAY
            
            var checkcnt=labelCount-1;            
            for(var i=1;i<=checkcnt;i++)
            {
                var supObj=document.getElementById("ddlSupplier_"+i);
                if(supObj !=null)
                {
                    var supValue=supObj.options[supObj.selectedIndex].value;
                    
                    if(supValue!='0')
                    {
                        for(var j=1;j<=qtyCount;j++)
                        {
                            var comnID=supValue+'_'+j;
                            if(ComnIDArray[0]!=supValue)
                            {
                                if(j==RowIndex)
                                {
                                    if(document.getElementById("chk_"+num).checked)
                                    {
                                        document.getElementById("chk_"+comnID).checked = false;
                                    }
                                    else
                                    {
                                        //document.getElementById("chk_"+comnID).disabled = false;
                                        //BY VIN document.getElementById("chk_"+comnID).checked = true;
                                        
                                    }
                                }    
                            }
                        }
                        /*for(var j=1;j<=qtyCount;j++)
                        {                            
                            var comnID=supValue+'_'+j; 
                            if(ComnIDArray[0]!=supValue)
                            {
                                document.getElementById("chk_"+comnID).checked=false;
                            }
                        }*/                        
                    }
                }
            }
        }
        
        
        
        function Step4Validation()
        {
            var Chk_Count = 0; 
            var EmptyCheck=true;
            var SupSelected=false;
            var checkcnt=labelCount-1;
            for(var i=1;i<=checkcnt;i++)
            {
                var supObj=document.getElementById("ddlSupplier_"+i);
                if(supObj!=null)
                {
                    var supValue=supObj.options[supObj.selectedIndex].value;
                    if(supValue!='0')
                    {
                        for(var j=1;j<=qtyCount;j++)
                        {
                            var comnID=supValue+'_'+j;
                            if( trim12(document.getElementById("txtCost_"+comnID).value)=='' ||
                                trim12(document.getElementById("txtTotalPrice_"+comnID).value)=='')
                            {
                                //EmptyCheck=false;
                            }
                            if(document.getElementById("txtQty_"+comnID).value!='' && Number(document.getElementById("txtQty_"+comnID).value) !=0)
                            {
                                if(document.getElementById("chk_"+comnID).checked)
                                {
                                    SupSelected=true;
                                    Chk_Count++;
                                }
                            }
                        }
                     }
                }
            }
            
            if(Chk_Count > 4)
            {
               document.getElementById("div_none").style.display="block";
               document.getElementById("span_none").innerHTML="Please select maximum of 4 quantities"; 
               return false;
            }
            if(EmptyCheck==false)
            {
               document.getElementById("div_none").style.display="block";
               document.getElementById("span_none").innerHTML="One of the information is missing, please enter"; 
               return false;
            }
            if(SupSelected==false)
            {
                document.getElementById("div_none").style.display="block";
                document.getElementById("span_none").innerHTML="Please select either 1 quantity or 4 quantities";
                return false;
            }
            return true;
        }
       
        
        function Stpe1Vaild()
        {
            var CheckStep1 = true;
            var CheckDate = true;
            if(txtRFQReturnDate.value=='')
            {
                CheckDate=false;
                document.getElementById("spn_txtRFQReturnDate").style.display="block";
            }
            else
            {
                document.getElementById("spn_txtRFQReturnDate").style.display="none";
            }
            if(txtJobCompletionDate.value=='')
            {
                CheckDate=false;
                document.getElementById("spn_txtJobCompletionDate").style.display="block"; 
            }
            else
            {
                document.getElementById("spn_txtJobCompletionDate").style.display="none"; 
            }
               
            if( trim12(txtTitle.value)=='' || trim12(txtTitleDescription.value) =='' )
            {
                CheckStep1=false;
                document.getElementById("div_none").style.display="block";
                document.getElementById("span_none").innerHTML="Please enter Title";
            }
            else 
            {
                if(qtyType=="single")
                {
                    if(trim12(txtSingleQty.value)=='')
                    {
                       CheckStep1=false; 
                    }
                    else
                    {
                       var Test = Allow_Integer_Only(txtSingleQty,false);
                       if(Test==false)
                       {
                        document.getElementById("div_qty").style.display="block";
                        document.getElementById("span_qty").innerHTML="Please enter numeric value";
                        return false;
                       }
                    }
                }
                else if(qtyType=="runon")
                {
                    if(trim12(txtRunQty1.value)==''&& trim12(txtRunQty2.value)=='')
                    {
                       CheckStep1=false; 
                    }
                }
                else if(qtyType=="multiple")
                {
                    if(trim12(txtMultiQty1.value)==''&& trim12(txtMultiQty2.value)=='' && trim12(txtMultiQty3.value)==''
                        && trim12(txtMultiQty4.value)=='')
                    {
                       CheckStep1=false; 
                    }
                    else
                    {
                       var Test = true;
                       if(txtMultiQty1.value !='')
                       {
                           Test = Allow_Integer_Only(txtMultiQty1,false);                       
                           if(Test==false)
                           {
                            document.getElementById("div_qty").style.display="block";
                            document.getElementById("span_qty").innerHTML="Please enter numeric value";
                            return false;
                           }
                       }  
                       if(txtMultiQty2.value !='')
                       {  
                           Test = Allow_Integer_Only(txtMultiQty2,false);
                           if(Test==false)
                           {
                            document.getElementById("div_qty").style.display="block";
                            document.getElementById("span_qty").innerHTML="Please enter numeric value";
                            return false;
                           }
                       }  
                       if(txtMultiQty3.value !='')
                       {
                           Test = Allow_Integer_Only(txtMultiQty3,false);
                           if(Test==false)
                           {
                            document.getElementById("div_qty").style.display="block";
                            document.getElementById("span_qty").innerHTML="Please enter numeric value";
                            return false;
                           }
                       }  
                       if(txtMultiQty4.value !='')
                       {
                           Test = Allow_Integer_Only(txtMultiQty4,false);
                           if(Test==false)
                           {
                            document.getElementById("div_qty").style.display="block";
                            document.getElementById("span_qty").innerHTML="Please enter numeric value";
                            return false;
                           }
                       }
                    }
                }
            }
            
            if(CheckDate==false)
            {
                return false;
            }
            if(CheckStep1==false)
            {
                document.getElementById("div_qty").style.display="block";
                document.getElementById("span_qty").innerHTML="Please enter at least one Quantity";
                
                return false;
            }
            return true;
        }
        
        function cleanForm(val)
       {              
            Decrease(val);
            grow(val);
       }
       function grow(val)
       { 
             var textareaa=document.getElementById(val); 
             while(textareaa.scrollHeight > textareaa.clientHeight && !window.opera)
             {
                //textareaa.style.height='100%';  
                 textareaa.rows += 1;
             } 
       }
       function Decrease(val)
       { 
            var textareaa=document.getElementById(val);
            while(textareaa.rows>2)
            {
              textareaa.rows -= 1;
            }
            if(textareaa.rows==1)
            {
             //textareaa.style.height='15px';
            } 
       }
       function getName(RdID)
       {    
            var Rdl = document.getElementById(RdID);
            var RdlName= Rdl.getElementsByTagName("input");
            return RdlName;       
       }     
     
             var qtyType;          
        var costType;  
        function CostSelected()
        {   
          for(var k=0; k<CostTypeArray.length;k++)
          {
            if(CostTypeArray[k].checked)
            {
              costType=CostTypeArray[k].value;
            }
          }
       } 
       function QtySelected()
       {    
           for(var i=0; i<QtyTypeArray.length ;i++)
           {
               if(QtyTypeArray[i].checked)
               {
                    qtyType=QtyTypeArray[i].value;
               }         
           }
       }
       
       var singlerun = false;
       var PreviousVal = '';
       function CheckQtyType(fromClick)
       {
            
            var winCon = true;
            if(fromClick=="yes")
            {
                /*
                winCon = window.confirm('Are you sure, it will Erase all data ?');
                if(winCon)
                {
                    DivPriceCompClear_part_2();
                }
                */
            }
            if(winCon)
            {
                QtySelected(); 
                
                document.getElementById("div_singleQty").style.display="none";
                document.getElementById("div_runQty").style.display="none";
                document.getElementById("div_MultyQty").style.display="none";                
                
                if(qtyType=="single")
                { 
                   document.getElementById("div_singleQty").style.display="block";
                }             
                else if(qtyType=="multiple")          
                {
                   document.getElementById("div_MultyQty").style.display="block";
                }
                else if(qtyType=="runon")             
                {
                  document.getElementById("div_runQty").style.display="none";
                }   
            }
            
            for(var i=0; i<QtyTypeArray.length ;i++)
            {
                if(QtyTypeArray[i].value==qtyType)
                {
                    QtyTypeArray[i].checked=true;     
                }
            }
        }

    function DropdownChange(obj,txtid)
    {
      var txt=document.getElementById(txtid);
      if(obj.value=='no')
        {
            txt.disabled=false;
            txt.focus();
        }
        else
        {
            txt.value="";
            txt.disabled=true;
        }
    }
    
    var ArrayBroker=new Array();//This is for saving the Item Title in Print Broker for the case of Both main and  sub Item
    function BrokerData()
    {
        this.Title='';
        this.TitleDescription='';
        this.Origination='';
        this.OriginationDescription='';
        this.Artwork='';
        this.ArtworkDescription='';
        this.Color='';
        this.ColorDescription='';
        this.Size='';
        this.SizeDescription='';
        this.Material='';
        this.MaterialDescription='';
        this.Finishing='';
        this.FinishingDescription='';
        this.Delivery='';
        this.DeliveryDescription='';
        this.Notes='';
        this.NotesDescription='';
        this.Terms='';
        this.TermsDescription='';            
    }
    var ArrayPrint=new Array();
        function RFQData()
        {
            this.EstOutworkID='';//// For both EstItemOutworkID and EstOutworkID
            this.CostingType='';
            this.RFQReturnDate='';
            this.JobCompletionDate='';
            this.ArtWork='';
            this.Quantity='';
            this.QtyType='';
            this.Header='';
            this.Footer='';
            
            this.Title='';
            this.TitleDescription='';
            this.TitleIsChecked='';
            this.Origination='';
            this.OriginationDescription='';
            this.OriginationIsChecked='';
            this.Artwork='';
            this.ArtworkDescription='';
            this.ArtworkIsChecked='';
            this.Color='';
            this.ColorDescription='';
            this.ColorIsChecked='';
            this.Size='';
            this.SizeDescription='';
            this.SizeIsChecked='';
            this.Material='';
            this.MaterialDescription='';
            this.MaterialIsChecked='';
            this.Finishing='';
            this.FinishingDescription='';
            this.FinishingIsChecked='';
            this.Delivery='';
            this.DeliveryDescription='';
            this.DeliveryIsChecked='';
            this.Notes='';
            this.NotesDescription='';
            this.NotesIsChecked='';
            this.Terms='';
            this.TermsDescription='';  
            this.TermsIsChecked='';         
            this.SupplierList=[];
            this.PriceList=[];
        }
        function SupplierInfo()
        {
            this.SupplierID;
            this.SupplierName;
            this.ContactID;
        }
        function PriceComparison()
        {
            this.SupplierID;
            this.SupplierContactID;
            this.Quantity;
            this.Cost;
            this.DeliveryIncluded;
            this.DeliveryCost;
            this.DeliveryDate;
            this.MarkupType;
            this.MarkupValue;
            this.TotalPrice;
            this.IsSelected;
            this.IsMailSent;
            this.QuantityNumber;
            
        }
        
        
        function SaveOutWork(para)
        {
            var rfq=new RFQData();
            
            rfq.CostingType = ddlCostingType.value;
            rfq.RFQReturnDate = txtRFQReturnDate.value;
            rfq.JobCompletionDate = txtJobCompletionDate.value;
            rfq.ArtWork = UploadedFiles;//Files which are uploaded and there name
            rfq.Header = spn_PrintBroker_Header.innerHTML;
            rfq.Footer = spn_PrintBroker_Footer.innerHTML;

            QtySelected();
            
            rfq.QtyType = qtyType;
            if(qtyType=="single")
            { 
               rfq.Quantity = txtSingleQty1.value;
            }             
            else if(qtyType=="multiple")          
            {
              rfq.Quantity = txtMultiQty11.value +'|'+ txtMultiQty22.value +'|'+ txtMultiQty33.value +'|'+ txtMultiQty44.value;
            }
            else if(qtyType=="runon")             
            {
              rfq.Quantity = txtRunQty11.value+'|'+txtRunQty22.value;
            } 
            
            //FOR PRINT EMAIL
            var QuantityList = rfq.Quantity;
            
            rfq.Title = txtTitle.value;
            rfq.TitleDescription = txtTitleDescription.value;
            rfq.TitleIsChecked = chkOutItemTitle.checked;
            rfq.Origination = txtOrigination.value;
            rfq.OriginationDescription = txtOriginationDescription.value;
            rfq.OriginationIsChecked = chkOutDescription.checked;
            rfq.Artwork = txtArtwork.value;
            rfq.ArtworkDescription = txtArtworkDescription.value;
            rfq.ArtworkIsChecked = chkOutArtwork.checked;
            rfq.Color = txtColor.value;
            rfq.ColorDescription = txtColorDescription.value;
            rfq.ColorIsChecked = chkOutColour.checked;
            rfq.Size = txtSize.value;
            rfq.SizeDescription = txtSizeDescription.value;
            rfq.SizeIsChecked = chkOutSize.checked;
            rfq.Material = txtMaterial.value;
            rfq.MaterialDescription = txtMaterialDescription.value;
            rfq.MaterialIsChecked = chkOutMaterial.checked;
            rfq.Finishing = txtFinishing.value;
            rfq.FinishingDescription = txtFinishingDescription.value;
            rfq.FinishingIsChecked = chkOutFinishing.checked;
            rfq.Delivery = txtDelivery.value;
            rfq.DeliveryDescription = txtDeliveryDescription.value;
            rfq.DeliveryIsChecked = chkOutDelivery.checked;
            rfq.Notes = txtNotes.value;
            rfq.NotesDescription = txtNotesDescription.value;
            rfq.NotesIsChecked = chkOutNotes.checked;
            rfq.Terms = txtTerms.value;
            rfq.TermsDescription = txtTermsDescription.value;
            rfq.TermsIsChecked = chkOutInstructions.checked;
            
            //FOR PHRASE BOOK
            var rfq_data = new BrokerData();
            if(chk_broker_Phrase_Title.checked)
            {
                rfq_data.Title = txtTitle.value;
                rfq_data.TitleDescription = txtTitleDescription.value;
            }
            if(chk_broker_Phrase_Design.checked)
            {
                rfq_data.Origination = txtOrigination.value;
                rfq_data.OriginationDescription = txtOriginationDescription.value;
            }
            if(chk_broker_Phrase_Artwork.checked)
            {
                rfq_data.Artwork = txtArtwork.value;
                rfq_data.ArtworkDescription = txtArtworkDescription.value;
            }
            if(chk_broker_Phrase_Color.checked)
            {
                rfq_data.Color = txtColor.value;
                rfq_data.ColorDescription = txtColorDescription.value;
            }
            if(chk_broker_Phrase_Size.checked)
            {
                rfq_data.Size = txtSize.value;
                rfq_data.SizeDescription = txtSizeDescription.value;
            }
            if(chk_broker_Phrase_Material.checked)
            {
                rfq_data.Material = txtMaterial.value;
                rfq_data.MaterialDescription = txtMaterialDescription.value;
            }
            if(chk_broker_Phrase_Finishing.checked)
            {
                rfq_data.Finishing = txtFinishing.value;
                rfq_data.FinishingDescription = txtFinishingDescription.value;
            }
            if(chk_broker_Phrase_Delivery.checked)
            {
                rfq_data.Delivery = txtDelivery.value;
                rfq_data.DeliveryDescription = txtDeliveryDescription.value;
            }
            if(chk_broker_Phrase_Notes.checked)
            {
                rfq_data.Notes = txtNotes.value;
                rfq_data.NotesDescription = txtNotesDescription.value;
            }
            if(chk_broker_Phrase_Terms.checked)
            {
                rfq_data.Terms = txtTerms.value;
                rfq_data.TermsDescription = txtTermsDescription.value;
            }
            
            var PCount=0;
            var supplierCount=labelCount-1;
            
            if(para=='printemail')
            {
               var JustCount = 0;
               for(var i=1;i<=supplierCount;i++)
                {
                    var supObj=document.getElementById("ddlSupplier_"+i);
                    var contObj=document.getElementById("ddlSupplierContact_"+i);
                    if(supObj!=null)
                    {
                        if(supObj.options[supObj.selectedIndex].value !='0')
                        {
                            //supplier Save
                            var sup=new SupplierInfo();
                            sup.SupplierID=supObj.options[supObj.selectedIndex].value;
                            sup.SupplierName=supObj.options[supObj.selectedIndex].text;
                            if(contObj.options[contObj.selectedIndex].value !='0')
                            {
                                sup.ContactID=contObj.options[contObj.selectedIndex].value;
                            }
                            else
                            {
                                sup.ContactID='0';
                            }
                            rfq.SupplierList[i-1]=sup;        ////i=1                               
                            
                            var priceCount=0; 
                            
                            var QtyArray = QuantityList.split('|');                            
                            for(var j=0;j<=QtyArray.length;j++)
                            {                        
                                if(QtyArray[j]!='')
                                {
                                    var PriceComp=new PriceComparison();
                                    PriceComp.SupplierID = sup.SupplierID;
                                    PriceComp.SupplierContactID = sup.ContactID;
                                    PriceComp.Quantity = QtyArray[j];
                                    PriceComp.Cost= "0";
                                    PriceComp.DeliveryIncluded = "no";
                                    PriceComp.DeliveryDate = "";
                                    PriceComp.DeliveryCost = "0";
                                    PriceComp.MarkupType = "percentage";
                                    PriceComp.MarkupValue = "0";
                                    PriceComp.TotalPrice = "0";
                                    PriceComp.IsSelected = JustCount=="0" ? "true": "false";
                                    PriceComp.QuantityNumber = Number(Number(j)+Number(1));
                                    
                                    rfq.PriceList[PCount]=PriceComp;////j=1
                                    priceCount++;
                                    
                                    PCount++;
                                    JustCount++;
                                }
                            }
                        }  
                    }      
                }
            }
            else
            {
                for(var i=1;i<=supplierCount;i++)
                {
                    var supObj=document.getElementById("ddlSupplier_"+i);
                    var contObj=document.getElementById("ddlSupplierContact_"+i);
                    if(supObj!=null)
                    {
                        if(supObj.options[supObj.selectedIndex].value !='0')
                        {
                            //supplier Save
                            var sup=new SupplierInfo();
                            sup.SupplierID=supObj.options[supObj.selectedIndex].value;
                            sup.SupplierName=supObj.options[supObj.selectedIndex].text;
                            if(contObj.options[contObj.selectedIndex].value !='0')
                            {
                                sup.ContactID=contObj.options[contObj.selectedIndex].value;
                            }
                            else
                            {
                                sup.ContactID='0';
                            }
                            rfq.SupplierList[i-1]=sup;        ////i=1                               
                            
                            //PriceList Save
                            //txtQty_  txtCost_    ddlDeliveryIncluded_    txtDeliveryDate_
                            var priceCount=0;                        
                            for(var j=1;j<=qtyCount;j++)
                            {                        
                                var comnId=sup.SupplierID+'_'+j;
                                //if(document.getElementById("txtQty_"+comnId).value!="0" && document.getElementById("txtQty_"+comnId).value!='')
                                //{                                
                                    var PriceComp=new PriceComparison();
                                    PriceComp.SupplierID=sup.SupplierID;
                                    PriceComp.SupplierContactID=sup.ContactID;
                                    PriceComp.Quantity=document.getElementById("txtQty_"+comnId).value;
                                    PriceComp.Cost=document.getElementById("txtCost_"+comnId).value;
                                    PriceComp.DeliveryIncluded=document.getElementById("ddlDeliveryIncluded_"+comnId).value;
                                    PriceComp.DeliveryDate=document.getElementById("txtDeliveryDate_"+comnId).value;
                                    PriceComp.DeliveryCost=document.getElementById("txtDeliveryCost_"+comnId).value;
                                    PriceComp.MarkupType=document.getElementById("ddlMarkup_"+comnId).value;
                                    PriceComp.MarkupValue=document.getElementById("txtMarkup_"+comnId).value;
                                    PriceComp.TotalPrice=document.getElementById("txtTotalPrice_"+comnId).value;
                                    PriceComp.IsSelected=document.getElementById("chk_"+comnId).checked; 
                                    PriceComp.QuantityNumber=j;
                                    
                                    rfq.PriceList[PCount]=PriceComp;  ////j=1                                
                                    priceCount++;                                
                                //}    
                                PCount++;
                            }
                        }  
                    }      
                }
            }
            if(IsEdit)
            {
               rfq.EstOutworkID = ArrayPrint[EditNo].EstOutworkID;
               ArrayPrint.splice(EditNo,1);
               
               ArrayPrint.push(rfq);
               ArrayBroker.push(rfq_data);
            }
            else //when add
            {
               ArrayPrint.push(rfq);
               ArrayBroker.push(rfq_data);
            }
            ClearAllPrintProker();
        }
        
        function RemoveOutWork(ids)
        {
           ArrayPrint.splice(ids,1);           
           ArrayBroker.splice(ids,1);
           ShowOutworkList();
        }
        
        function ShowOutworkList()
        {
            var completeData='';
            var dd='';
            
            if(ArrayPrint.length>0)
            {
                document.getElementById("href_ShowOutwork").style.display="block";
            }
            else
            {
                document.getElementById("href_ShowOutwork").style.display="none";
            }
            for(var i=0;i<ArrayPrint.length;i++)
            {
              dd+="<div align='left' style='height:20px;'>";
              if(ArrayPrint[i].EstOutworkID=='')
              {
                    dd+="<div style='float:left;width:220px;overflow:hidden;'>"+ArrayPrint[i].Title+"</div>";
              }
              else
              {
                    dd+="<div style='float:left;width:220px;overflow:hidden;'><a href='#' onclick='ShowPrintBroker();LoadToPBbox("+i+")'>"+ArrayPrint[i].Title+"</a></div>";
              }
              dd+="<div style='float:left;'><a href='#' onclick=javascript:RemoveOutWork("+i+"); class='normaltext'>Remove</a></div>";
              dd+="</div>";
              /*
              WORKING CODE
              var supArr=ArrayPrint[i].SupplierList;
              for(j=0;j<supArr.length;j++)
              {
              }    
              var pirArr=ArrayPrint[i].PriceList;
              for(k=0;k<pirArr.length;k++)
              {
              }      
              */
            }
            document.getElementById("div_OutworkItems_Add").innerHTML=dd;
        }
        function ClearAllPrintProker()
        {
            //BindOutworkDesc();//To Bind RFQ DATA on Sub Item ADD case//
            
            ddlCostingType.selectedIndex = 0;
            txtRFQReturnDate.value='';
            txtJobCompletionDate.value='';
            UploadedFiles='';
            
            txtSingleQty.value='';
            txtRunQty1.value='';
            txtRunQty2.value='';
            txtMultiQty1.value='';
            txtMultiQty2.value='';
            txtMultiQty3.value='';
            txtMultiQty4.value='';
            
            document.getElementById("div_added").innerHTML="";
            for(var i=tableSup.rows.length;i>0;i--)
            {
                tableSup.deleteRow(i-1);
            }
            var PriceTable = document.getElementById("PriceTable");
            for(var i=PriceTable.rows.length;i>0;i--)
            {
                PriceTable.deleteRow(i-1);
            }
            supCount=1;
            labelCount=1;
            IsEdit = false;
            for(var i=0; i<QtyTypeArray.length ;i++)
            {
              QtyTypeArray[i].disabled=false;
            }

            chk_broker_Phrase_Title.checked = false;
            chk_broker_Phrase_Design.checked = false;
            chk_broker_Phrase_Artwork.checked = false;
            chk_broker_Phrase_Color.checked = false;
            chk_broker_Phrase_Size.checked = false;
            chk_broker_Phrase_Material.checked = false;
            chk_broker_Phrase_Finishing.checked = false;
            chk_broker_Phrase_Delivery.checked = false;
            chk_broker_Phrase_Notes.checked = false;
            chk_broker_Phrase_Terms.checked = false;        
            
            IsEntered = false;    
            roundTrip=0;
        }
    
     function Use_add_more()
     {  
        add_more();//supplier 1
        add_more();//supplier 2
        add_more();//supplier 3
        add_more();//supplier 4
        add_more();//supplier 5
     }
     function LoadToPBbox(s)
     {
        var DateFormatNEW = dateformatnew();
        IsEdit=true;
        EditNo=s;
        //-----
        txtTitle.value = ArrayPrint[s].Title;
        txtTitleDescription.value =ArrayPrint[s].TitleDescription;
        txtOrigination.value = ArrayPrint[s].Origination;
        txtOriginationDescription.value =ArrayPrint[s].OriginationDescription;
        txtArtwork.value = ArrayPrint[s].Artwork;
        txtArtworkDescription.value =ArrayPrint[s].ArtworkDescription;
        txtColor.value = ArrayPrint[s].Color;
        txtColorDescription.value = ArrayPrint[s].ColorDescription;
        txtSize.value = ArrayPrint[s].Size;
        txtSizeDescription.value = ArrayPrint[s].SizeDescription;
        txtMaterial.value = ArrayPrint[s].Material;
        txtMaterialDescription.value = ArrayPrint[s].MaterialDescription;
        txtFinishing.value = ArrayPrint[s].Finishing;
        txtFinishingDescription.value = ArrayPrint[s].FinishingDescription;
        txtDelivery.value = ArrayPrint[s].Delivery;
        txtDeliveryDescription.value = ArrayPrint[s].DeliveryDescription;
        txtNotes.value = ArrayPrint[s].Notes;
        txtNotesDescription.value = ArrayPrint[s].NotesDescription;
        txtTerms.value = ArrayPrint[s].Terms;
        txtTermsDescription.value = ArrayPrint[s].TermsDescription;
        
        txtRFQReturnDate.value = ArrayPrint[s].RFQReturnDate =="01/01/1900" ? '': ArrayPrint[s].RFQReturnDate;
        txtJobCompletionDate.value = ArrayPrint[s].JobCompletionDate =="01/01/1900" ? '': ArrayPrint[s].JobCompletionDate;
        spn_PrintBroker_Header.innerHTML = ArrayPrint[s].Header;
        spn_PrintBroker_Footer.innerHTML = ArrayPrint[s].Footer;
        
        UploadedFiles = ArrayPrint[s].ArtWork;
        //ddlCostingType.value = ArrayPrint[s].CostingType =="U" ? 'unit': 'simple';
         if (ArrayPrint[s].CostingType == "U") {
             ddlCostingType.value = 'unit';
         } else if (ArrayPrint[s].CostingType == "S") {
             ddlCostingType.value = 'simple';
         } else if (ArrayPrint[s].CostingType == "P") {
             ddlCostingType.value = 'per1000';
         }

        txtSingleQty1 .value = '';
        txtRunQty11.value = '';
        txtRunQty22.value = '';
        txtMultiQty11.value = '';
        txtMultiQty22.value = '';
        txtMultiQty33.value = '';
        txtMultiQty44.value = '';
        
        
        var qt = trim12(ArrayPrint[s].QtyType);
        
        if(qt=="S" || qt=="single")
        {
            var Qarr1 = ArrayPrint[s].Quantity.split('|');
            txtSingleQty1 .value = Qarr1[0]==null ? '':Qarr1[0]; 
            for(var i=0; i<QtyTypeArray.length ;i++)
            {
                if(QtyTypeArray[i].value=="single")
                {
                    QtyTypeArray[i].checked=true; 
                    CheckQtyType(QtyTypeArray[i].value);                        
                }
                else
                {
                    QtyTypeArray[i].disabled=true;
                }
                
            }    
        } 
        else if(qt=="R" || qt=="runon")
        {
            var Qarr1 = ArrayPrint[s].Quantity.split('|');
            
            txtRunQty11.value = Qarr1[0]==null ? '':Qarr1[0];
            txtRunQty22.value = Qarr1[1]==null ? '':Qarr1[1];
            for(var i=0; i<QtyTypeArray.length ;i++)
            {
                if(QtyTypeArray[i].value=="runon")
                {
                    QtyTypeArray[i].checked=true; 
                    CheckQtyType(QtyTypeArray[i].value);
                }
                else
                {
                    QtyTypeArray[i].disabled=true;
                }
            }
        }    
        else if(qt=="M" || qt=="multiple")
        {
            var Qarr1 = ArrayPrint[s].Quantity.split('|');
            txtMultiQty11.value = Qarr1[0]==null ? '':Qarr1[0];
            txtMultiQty22.value = Qarr1[1]==null ? '':Qarr1[1];
            txtMultiQty33.value = Qarr1[2]==null ? '':Qarr1[2];
            txtMultiQty44.value = Qarr1[3]==null ? '':Qarr1[3];
            for(var i=0; i<QtyTypeArray.length ;i++)
            {
               if(QtyTypeArray[i].value=="multiple")
                {
                    QtyTypeArray[i].checked=true; 
                    CheckQtyType(QtyTypeArray[i].value);
                }
                else
                {
                    QtyTypeArray[i].disabled=true;
                }
            }
        } 
        
        supCount=1;
        labelCount=1;
        qtyCount=0;
        document.getElementById("div_added").innerHTML='';
        document.getElementById("div_load").innerHTML='';

        for(var p=0; p<ArrayPrint[s].SupplierList.length;p++)
        {            
            add_more();
            var supnum = Number(p+1);
            var supObj = document.getElementById("ddlSupplier_"+supnum+"");
            for(var i=0;i<supObj.length;i++)
            {
                if(supObj.options[i].value==ArrayPrint[s].SupplierList[p].SupplierID)
                {  
                  supObj.selectedIndex=i;
                  loadContacts(supObj.value,supnum,ArrayPrint[s].SupplierList[p].ContactID);
                  var ContObj = document.getElementById("ddlSupplierContact_"+supnum);
                  for(var j=0;j<ContObj.length;j++)
                  {
                    if(ContObj.options[j].value==ArrayPrint[s].SupplierList[p].ContactID)
                    {
                      ContObj.selectedIndex=j;
                    }
                  }
                  var uniData='';
                  
                  if(qtyType=="single")
                  {
                       qtyCount=1;
                  }
                  else if(qtyType=="multiple")
                  {
                       qtyCount=4;
                  }
                  else if(qtyType=="runon")
                  {
                       qtyCount=2;
                  }
                  uniData+="<div id=divPriceComparision_"+ supObj.id +">"; 
                  for(var j=1;j<=qtyCount;j++)
                  {
                        var name = supObj.options[supObj.selectedIndex].text;
                        var supValue = supObj.options[supObj.selectedIndex].value;
                        if(j!=1)
                        {
                            name='&nbsp;';
                        }
                        var QtyValue='';
                        if(qtyType=="single")
                        {
                            QtyValue=txtSingleQty1.value;
                        }
                        else if(qtyType=="runon")
                        {
                            if(j==1)
                            {   
                                QtyValue=txtRunQty11.value ;
                            }
                            else if(j==2)
                            {
                                QtyValue=txtRunQty22.value;
                            }    
                        }
                        else if(qtyType=="multiple")
                        {
                            if(j==1)
                            {
                                QtyValue=txtMultiQty11.value;
                            }
                            else if(j==2)
                            {
                                QtyValue=txtMultiQty22.value;
                            }
                            else if(j==3)
                            {
                                QtyValue=txtMultiQty33.value;
                            }
                            else if(j==4)
                            {    
                                QtyValue=txtMultiQty44.value;
                            }    
                        }
                        var comnID=supValue+'_'+j;
                        
                        uniData+="<div class='onlyEmpty'></div>";
                        uniData+="<div align='left' >";
                        uniData+="<div style='float: left; width: 13%;'>"+name+"</div>";
                        uniData+="<div style='float: left; width: 10%;'><input id='txtQty_"+comnID+"' type='text' value='"+QtyValue+"'  class='textboxnew' style='Width:95%;' disabled='true' /></div>";
                        uniData+="<div style='float: left; width: 10%;'><input id='txtCost_"+comnID+"' type='text'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('"+comnID+"');NumberToDecimal(this.id,this.value);\"' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                        uniData+="<div style='float: left; width: 10%;'><select id='ddlDeliveryIncluded_"+comnID+"' onchange=DropdownChange(this,'txtDeliveryCost_"+comnID+"'); style='Width:85%' class='normaltext'><option value='yes'>yes</option><option value='no'>No</option></select></div>";
                        if(j==1)
                        {
                            uniData+="<div style='float: left; width: 10%;'><input id='txtDeliveryDate_"+comnID+"'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'"+DateFormatNEW+"');\" onblur=\"javascript:CopyDate("+supValue+","+qtyCount+",this.value);\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                        }
                        else
                        {
                            uniData+="<div style='float: left; width: 10%;'><input id='txtDeliveryDate_"+comnID+"'  onClick=\"javascript:event.cancelBubble=true;this.select();lcs(this,'"+DateFormatNEW+"');\" type='text' class='textboxnew' style='Width:95%' readonly='readonly' /></div>";
                        }
                        uniData+="<div style='float: left; width: 10%;'><input id='txtDeliveryCost_"+comnID+"' disabled='true'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('"+comnID+"');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                        if(j==1)
                        {
                            uniData+="<div style='float: left; width: 10%;'><select id='ddlMarkup_"+comnID+"' style='Width:85%'  onchange=javascript:CopyMarkup(this.value,"+supValue+","+qtyCount+");   class='normaltext'><option value='percentage'>%</option><option value='fixedvalue'>" + GetCurrencyinRequiredFormate("",true) + "</option></select></div>";
                            uniData+="<div style='float: left; width: 9%;'><input id='txtMarkup_"+comnID+"'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('"+comnID+"');NumberToDecimal(this.id,this.value);CopyMarkupValue(this.value,"+supValue+","+qtyCount+");\"' type='text' class='textboxnew' style='Width:95%' value='' maxlength='9'  /></div>";
                        }
                        else
                        {
                            uniData+="<div style='float: left; width: 10%;'><select id='ddlMarkup_"+comnID+"' style='Width:85%'  class='normaltext'><option value='percentage'>%</option><option value='fixedvalue'>" + GetCurrencyinRequiredFormate("",true) + "</option></select></div>";
                            uniData+="<div style='float: left; width: 9%;'><input id='txtMarkup_"+comnID+"'  onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('"+comnID+"');NumberToDecimal(this.id,this.value);\"' type='text' class='textboxnew' style='Width:95%' value='' maxlength='9'  /></div>";
                        }                        
                        uniData+="<div style='float: left; width: 10%;'><input id='txtTotalPrice_"+comnID+"' onblur=\"javascript:AllowNumber(this,this.value);CalculatePrice('"+comnID+"');\" type='text' class='textboxnew' style='Width:95%' maxlength='9' /></div>";
                        uniData+="<div style='float: right; width: 6%;padding-right:10px'><input id='chk_"+comnID+"' type='checkbox' onclick=\"javascript:SelectOneSuppler('"+comnID+"');\" /></div>";
                        uniData+="</div>";
                        uniData+="<div class='onlyEmpty'></div>";
                        
                  }// last for
                  uniData+="<div style='padding:2px 0px 4px 0px;'><div class='onlyEmpty' style='border:1px solid #ccc;'></div></div>"; 
                  uniData+="</div>";
                  ////document.getElementById("div_load").innerHTML +=uniData;
                    var row = document.createElement("tr");
                    row.id ="Price_tr_"+supObj.id+"";
                    var cell = document.createElement("td");
                    cell.innerHTML = uniData;
                    row.appendChild(cell);
                    document.getElementById("PriceTable").appendChild(row);

                    priceNo ++;

                }  
            }
        }   
        
       
       for(var p=0; p<ArrayPrint[s].PriceList.length;p++)
       {     
            for(var q=1; q<=qtyCount; q++)
            {
                supValue = ArrayPrint[s].PriceList[p].SupplierID;                
                var comnID=supValue+'_'+ Number(q);                   
                
                if(supValue!='' && document.getElementById("txtQty_"+comnID+"")!=null)
                {
                    if(document.getElementById("txtQty_"+comnID+"").value==ArrayPrint[s].PriceList[p].Quantity)
                    {
                        //document.getElementById("txtQty_"+comnID+"").value = ArrayPrint[s].PriceList[p].Quantity; 
                        document.getElementById("txtCost_"+comnID+"").value = ArrayPrint[s].PriceList[p].Cost; 
                        document.getElementById("ddlDeliveryIncluded_"+comnID+"").value = ArrayPrint[s].PriceList[p].DeliveryIncluded=="yes" ? "yes":"no"; 
                        document.getElementById("txtDeliveryDate_"+comnID+"").value = ArrayPrint[s].PriceList[p].DeliveryDate=="01/01/1900" ? '':ArrayPrint[s].PriceList[p].DeliveryDate; 
                        document.getElementById("txtDeliveryCost_"+comnID+"").value = ArrayPrint[s].PriceList[p].DeliveryCost; 
                        document.getElementById("txtDeliveryCost_"+comnID+"").disabled=ArrayPrint[s].PriceList[p].DeliveryIncluded=="yes" ? true : false;
                        var MarType = "fixedvalue";
                        if(ArrayPrint[s].PriceList[p].MarkupType =="percentage" || ArrayPrint[s].PriceList[p].MarkupType =="P")
                        {
                            MarType = "percentage";
                        }
                        document.getElementById("ddlMarkup_"+comnID+"").value = MarType; 
                        
                        document.getElementById("txtMarkup_"+comnID+"").value = ArrayPrint[s].PriceList[p].MarkupValue; 
                        document.getElementById("txtTotalPrice_"+comnID+"").value = ArrayPrint[s].PriceList[p].TotalPrice; 
                        document.getElementById("chk_"+comnID+"").checked = ArrayPrint[s].PriceList[p].IsSelected=="1" ? true:false; 
                    }
                }
            }
       }
    }
    
    
    function ChangeOfQty(qtyNo,QtyVal)
    {
       if(IsEdit)
       {
           var s=EditNo;
           for(var p=0; p<ArrayPrint[s].PriceList.length;p++)
           {     
               
                var q=qtyNo;            
                supValue = ArrayPrint[s].PriceList[p].SupplierID;                
                var comnID=supValue+'_'+ Number(q);                   
                
                if(supValue!='' && document.getElementById("txtQty_"+comnID+"")!=null)
                {
                    document.getElementById("txtQty_"+comnID+"").value = QtyVal;
                }
           }
       }
    }
 
 
 function Only_Single_Qty()
 {
    for(var i=0;i<qtyarray.length;i++)
    {
       if (qtyarray[i].value == 'single') 
       {
            qtyarray[i].checked = true;
       }
       else
       {
            qtyarray[i].checked = false;
            qtyarray[i].disabled = true;
       }
    }
 }
 
    function CallPrintEmail() 
    {
        if(SupplierSelectionCheck())
        {
            try
            {
                document.getElementById("ds00").style.width = document.getElementById("Table1").offsetWidth + "px";
                document.getElementById("ds00").style.height = Number(Number(window.screen.availHeight)+50) +"px";
                document.getElementById("ds00").style.display = "block";
                document.getElementById("abs").style.display = "block";
                document.getElementById("div_00").focus();
            }catch(e){}
            
            document.getElementById("div_print_broker_step_2").style.display="none";
            document.getElementById("div_blank_OW").style.display="block";
            
            hid_Pub_ClientID.value = ClientID;
            BindDefaultRFQData();
            SaveOutWork("printemail");
            
            if(IsPrintBrokerDirect)
            {
                SaveData();
                __doPostBack('ctl00$ContentPlaceHolder1$UCStage1$UCItemAdd$lnkPrintEmail','');
            }
            else
            {
                SubItem_CallPrintEmail();
            }
        }
        else
        {
            return false;
        }
    }
     //This function is used in the ItemAdd
    function ArrangePrintBroker(para) 
    {
        var QtyTypeArray = qtyarray;
        for (var i = 0; i < QtyTypeArray.length; i++) {
            if (para == 'S' && QtyTypeArray[i].value == 'single') {
                QtyTypeArray[i].checked = true;
                qtyType = QtyTypeArray[i].value;
                //------
                txtSingleQty1.value = txtQuantity.value;
                //------
                div_singleQty.style.display = 'block';
                div_runQty.style.display = 'none';
                div_MultyQty.style.display = 'none';
            }
            else if (para == 'R' && QtyTypeArray[i].value == 'runon') {
                QtyTypeArray[i].checked = true;
                QtyTypeArray[i].disabled = false;
                //------
                txtRunQty11.value = txtQuantity.value;
                txtRunQty22.value = txtRunOnQty.value;
                //------
                div_singleQty.style.display = 'none';
                div_runQty.style.display = 'block';
                div_MultyQty.style.display = 'none';
            }
            else if (para == 'M' && QtyTypeArray[i].value == 'multiple') {
                QtyTypeArray[i].checked = true;
                qtyType = QtyTypeArray[i].value;
                QtyTypeArray[i].disabled = false;
                //------
                txtMultiQty11.value = txtQuantity.value;
                txtMultiQty22.value = txtQuantity_2.value;
                txtMultiQty33.value = txtQuantity_3.value;
                txtMultiQty44.value = txtQuantity_4.value;
                //------
                div_singleQty.style.display = 'none';
                div_runQty.style.display = 'none';
                div_MultyQty.style.display = 'block';
            }
            QtyTypeArray[i].disabled = true;
        }
    }