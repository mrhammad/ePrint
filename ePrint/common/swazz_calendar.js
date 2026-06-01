/* --- Swazz Javascript Calendar ---
/* --- v 1.0 3rd November 2006
By Oliver Bryant
http://calendar.swazz.org */


var CurrentClientDate = new Date();

function getObj(objID) {
    if (document.getElementById) { return document.getElementById(objID); }
    else if (document.all) { return document.all[objID]; }
    else if (document.layers) { return document.layers[objID]; }
}

function checkClick(e) {
    e ? evt = e : evt = event;
    CSE = evt.target ? evt.target : evt.srcElement;
    if (getObj('fc'))
        if (!isChild(CSE, getObj('fc')))
        getObj('fc').style.display = 'none';
}

function isChild(s, d) {
    while (s) {
        if (s == d)
            return true;
        s = s.parentNode;
    }
    return false;
}

function Left(obj) {
    var curleft = 0;
    if (obj.offsetParent) {
        while (obj.offsetParent) {
            curleft += obj.offsetLeft
            obj = obj.offsetParent;
        }
    }
    else if (obj.x)
        curleft += obj.x;
    return curleft;
}

function Top(obj) {
    var curtop = 0;
    if (obj.offsetParent) {
        while (obj.offsetParent) {
            curtop += obj.offsetTop
            obj = obj.offsetParent;
        }
    }
    else if (obj.y)
        curtop += obj.y;
    return curtop;
}

document.write('<table id="fc" style="width:200px;z-index:5555555555; position:absolute;border-collapse:collapse;background:#FFFFFF;border:1px solid #ABABAB;display:none" cellpadding=2>');
document.write('<tr><td style="cursor:pointer" onclick="csubm()"><img src="../images/arrowleftmonth.gif"></td><td colspan=5 id="mns" align="center" style="font:bold 13px Arial"></td><td align="right" style="cursor:pointer" onclick="caddm()"><img src="../images/arrowrightmonth.gif"></td></tr>');
document.write('<tr><td align=center style="background:#ABABAB;font:12px Arial">S</td><td align=center style="background:#ABABAB;font:12px Arial">M</td><td align=center style="background:#ABABAB;font:12px Arial">T</td><td align=center style="background:#ABABAB;font:12px Arial">W</td><td align=center style="background:#ABABAB;font:12px Arial">T</td><td align=center style="background:#ABABAB;font:12px Arial">F</td><td align=center style="background:#ABABAB;font:12px Arial">S</td></tr>');
/////////For Today Date//////




var d = new Date(CurrentClientDate);
var todaydate = d.getDate();
var currentmonth = d.getMonth();
var currentyear = d.getYear();
for (var kk = 1; kk <= 6; kk++) {
    document.write('<tr>');
    for (var tt = 1; tt <= 7; tt++) {
        num = 7 * (kk - 1) - (-tt);
        document.write('<td id="v' + num + '" style="width:18px;height:18px">&nbsp;</td>');
    }
    document.write('</tr>');
}
document.write('</table>');

document.all ? document.attachEvent('onclick', checkClick) : document.addEventListener('click', checkClick, false);


// Calendar script
var now = new Date(CurrentClientDate );
var sccm = now.getMonth();
var sccy = now.getFullYear();
var sccd = now.getDate();
var ccm = now.getMonth();
var ccy = now.getFullYear();

var updobj;
var DateFormat;
var curdate = new Array;
var cur_day;
var cur_month;
var cur_year;

try {
   

    curdate = CurrentClientDate .split('/');
   
}
catch (err) {
    curdate = Number(now.getMonth() + 1) + '/' + now.getDate() + '/' + now.getFullYear();
}


function lcs(ielem, format) {    
    DateFormat = format;        // by vinay
    updobj = ielem;
    var fc = getObj('fc');
    fc.style.display = '';
    fc.style.position = 'fixed';
    fc.style.zIndex = '10001';
    var rect = ielem.getBoundingClientRect();
    var calHeight = fc.offsetHeight || 200;
    var calWidth = fc.offsetWidth || 200;
    var calTop = rect.bottom + 2;
    var calLeft = rect.left;
    if (calTop + calHeight > window.innerHeight - 8) {
        calTop = rect.top - calHeight - 2;
    }
    if (calTop < 8) {
        calTop = 8;
    }
    if (calLeft + calWidth > window.innerWidth - 8) {
        calLeft = window.innerWidth - calWidth - 8;
    }
    if (calLeft < 8) {
        calLeft = 8;
    }
    fc.style.left = calLeft + 'px';
    fc.style.top = calTop + 'px';

    // First check date is valid
    curdt = ielem.value;
    if (format == 'mm/dd/yyyy') {
        if (curdt == '') {
            var date = new Date();
            var dd = date.getDate();
            var mm = date.getMonth() + 1;
            var yy = date.getFullYear();
            curdt = mm + "/" + dd + "/" + yy;
        }
    }
    curdtarr = curdt.split('/');
    // by vinay

    if (format == 'mm/dd/yyyy') {
        curdt = curdtarr[1] + '/' + curdtarr[0] + '/' + curdtarr[2];
        curdtarr = curdt.split('/');
    }
    else if (format == 'dd/mm/yyyy') {
        curdt = curdtarr[0] + '/' + curdtarr[1] + '/' + curdtarr[2];
        curdtarr = curdt.split('/');
    }
    else {

        curdt = curdtarr[0] + '/' + curdtarr[1] + '/' + curdtarr[2];
        curdtarr = curdt.split('/');
    }

    //For local mm/dd/yyyy format	


    //End

    isdt = true;
    for (var k = 0; k < curdtarr.length; k++) {
        if (isNaN(curdtarr[k]))
            isdt = false;
    }
    if (isdt & (curdtarr.length == 3)) {
        ccm = curdtarr[1] - 1;
        ccy = curdtarr[2];
        
        prepcalendar(curdtarr[0], curdtarr[1] - 1, curdtarr[2], curdt);
    }

}


function evtTgt(e) {

    var el;
    if (e.target) el = e.target;
    else if (e.srcElement) el = e.srcElement;
    if (el.nodeType == 3) el = el.parentNode; // defeat Safari bug    
    return el;
}
function EvtObj(e) { if (!e) e = window.event; return e; }
function cs_over(e) {
    evtTgt(EvtObj(e)).style.background = '#FFCC66';
}
function cs_out(e) {
    evtTgt(EvtObj(e)).style.background = '#C4D3EA';
}
///Today date 
function cs_todaydate(e) {
    evtTgt(EvtObj(e)).style.background = 'Orange';
}
function cs_click(e) {
    updobj.value = calvalarr[evtTgt(EvtObj(e)).id.substring(1, evtTgt(EvtObj(e)).id.length)];
    getObj('fc').style.display = 'none';
    updobj.focus();
}

var mn = new Array('JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC');
var mnn = new Array('31', '28', '31', '30', '31', '30', '31', '31', '30', '31', '30', '31');
var mnl = new Array('31', '29', '31', '30', '31', '30', '31', '31', '30', '31', '30', '31');
var calvalarr = new Array(42);

function f_cps(obj) {
    obj.style.background = '#C4D3EA';
    obj.style.font = '10px Arial';
    obj.style.color = '#333333';
    obj.style.textAlign = 'center';
    obj.style.textDecoration = 'none';
    obj.style.border = '1px solid #6487AE';
    obj.style.cursor = 'pointer';
}

function f_cpps(obj) {
    obj.style.background = '#C4D3EA';
    obj.style.font = '10px Arial';
    obj.style.color = '#333333';
    obj.style.textAlign = 'center';
    obj.style.textDecoration = 'none';
    obj.style.border = '1px solid #6487AE';
    obj.style.cursor = 'pointer';
}

function f_hds(obj) {
    obj.style.background = '#C4D3EA';
    obj.style.font = '10px Arial';
    obj.style.color = '#333333';
    obj.style.textAlign = 'center';
    obj.style.textDecoration = 'none';
    obj.style.border = '1px solid #6487AE';
    obj.style.cursor = 'pointer';
}

// day selected
function prepcalendar(hd, cm, cy, txtdate) {



    if (txtdate != '') {
        CurrentClientDate  = txtdate;
    }

    now = new Date(CurrentClientDate );
    sd = now.getDate();
    td = new Date(CurrentClientDate );
    td.setDate(1);
    td.setFullYear(cy);
    td.setMonth(cm);
    cd = td.getDay();
    getObj('mns').innerHTML = mn[cm] + ' ' + cy;
    marr = ((cy % 4) == 0) ? mnl : mnn;
    for (var d = 1; d <= 42; d++) {
        f_cps(getObj('v' + parseInt(d)));
        if ((d >= (cd - (-1))) && (d <= cd - (-marr[cm]))) {
            dip = ((d - cd < sd) && (cm == sccm) && (cy == sccy));
            htd = ((hd != '') && (d - cd == hd));
            //if (dip)
            //f_cpps(getObj('v'+parseInt(d)));
            //else if (htd)
            //f_hds(getObj('v'+parseInt(d)));
            //else

            f_cps(getObj('v' + parseInt(d)));

            getObj('v' + parseInt(d)).onmouseover = (false) ? null : cs_over;
            getObj('v' + parseInt(d)).onmouseout = (false) ? null : cs_out;
            getObj('v' + parseInt(d)).onclick = (false) ? null : cs_click;
            getObj('v' + parseInt(d)).innerHTML = d - cd;
            //            cur_day = curdate[1];
            //            cur_month = curdate[0] - 1;
            //            cur_year = curdate[2];


            if (hd.toString().substr(0, 1) == 0) {

                hd=parseInt(hd.toString().substr(1, 1))
            }

            cur_day = hd;
            cur_month = cm;
            cur_year = cy;



            /*var curdate= new Array;
			
			if(CurrentClientDate !=null && CurrentClientDate !='')
            {
            curdate=CurrentClientDate .split('/');
            var cur_day;
            var cur_month;
            var cur_year;
			    
			    if(DateFormat == 'mm/dd/yyyy')
            {
            cur_day=curdate[1];
            cur_month=curdate[0]-1;
            cur_year=curdate[2];
            }
            else if(DateFormat == 'dd/mm/yyyy')
            {
            cur_day=curdate[0];
            cur_month=curdate[1]-1;
            cur_year=curdate[2];   
            }
            else
            {
            cur_day=curdate[0];
            cur_month=curdate[1]-1;
            cur_year=curdate[2];      
            }
            
			      
			}*/






            if (getObj('v' + parseInt(d)).innerHTML == cur_day && cm == cur_month && cy == cur_year) {
                getObj('v' + parseInt(d)).style.background = 'Orange';
                getObj('v' + parseInt(d)).onmouseover = (false) ? null : cs_todaydate;
                getObj('v' + parseInt(d)).onmouseout = (false) ? null : cs_todaydate;
            }

            //For local dd/mm/yyyy format			
            //calvalarr[d]=''+(d-cd)+'/'+(cm-(-1))+'/'+cy;
            //End

            //For local mm/dd/yyyy format
            //calvalarr[d]=''+(cm-(-1))+'/'+(d-cd)+'/'+cy;
            //End

            // added by vinay and Final Click            
            if (DateFormat == 'mm/dd/yyyy') {
                calvalarr[d] = '' + (cm - (-1)) + '/' + (d - cd) + '/' + cy;
            }
            else if (DateFormat == 'dd/mm/yyyy') {
                calvalarr[d] = '' + (d - cd) + '/' + (cm - (-1)) + '/' + cy;
            }
            else {
                calvalarr[d] = '' + (d - cd) + '/' + (cm - (-1)) + '/' + cy;  //dd/mm/yyyy
            }

        }
        else {
            getObj('v' + d).innerHTML = '&nbsp;';
            getObj('v' + parseInt(d)).onmouseover = null;
            getObj('v' + parseInt(d)).onmouseout = null;
            getObj('v' + parseInt(d)).style.cursor = 'default';
        }
    }
}

prepcalendar('', ccm, ccy, '');
//getObj('fc'+cc).style.visibility='hidden';

function caddm() {
    marr = ((ccy % 4) == 0) ? mnl : mnn;

    ccm += 1;
    if (ccm >= 12) {
        ccm = 0;
        ccy++;
    }
    prepcalendar('', ccm, ccy, '');
}

function csubm() {
    marr = ((ccy % 4) == 0) ? mnl : mnn;

    ccm -= 1;
    if (ccm < 0) {
        ccm = 11;
        ccy--;
    }
    prepcalendar('', ccm, ccy, '');
}

function cdayf() {
    if ((ccy > sccy) | ((ccy == sccy) && (ccm >= sccm)))
        return;
    else {
        ccy = sccy;
        ccm = sccm;
    }
}
function CloseSwazzCalender() {
    try {
        document.getElementById("fc").style.display = "none";
    } catch (err) {
    }
}

