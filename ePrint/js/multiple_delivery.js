

function getstartrowvalue() {
    hid_startrow.value = ddlRows.options[ddlRows.selectedIndex].text;
}
function getstartcolvalue() {
    hid_startcol.value = ddlColumns.options[ddlColumns.selectedIndex].text;
}

function Getlabeltypetext(labletypetext, startrow, startcol) {
    var labletype;
    if (ServerName == "printmonkey" || ServerName == "centurionprint" || ServerName == "studio1") {
        labletype = labletypetext;
        hid_labletype_rows.value = "0";
        hid_labletype_col.value = "0";
    }
    else {
        labletype = (labletypetext.toString().split(':')[1]).split('-')[0];
        hid_labletype_rows.value = labletype.split('*')[0];
        hid_labletype_col.value = labletype.split('*')[1];
    }
    hid_startrow.value = startrow;
    hid_startcol.value = startcol;
}

