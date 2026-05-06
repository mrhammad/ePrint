
function openHelp(section,subsection)
{
    var openwin;    
    //openwin = "http://www.eclientes.net/help/userhelp.aspx?section=" + section + "&subsection=" +  subsection;
    openwin = "../help/userhelp.aspx?section=" + section + "&subsection=" +  subsection;
    //openwin = "http://localhost/Aoc/help/userhelp.aspx?section=" + section + "&subsection=" +  subsection;
    window.open(openwin, '','width=775,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=120,top=100');
}




