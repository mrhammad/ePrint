

var readSizeFromCookie = false; // Determines if size and position of windows should be set/retreved by use of cookie
var windowMinSize = [80, 30]; // Mininum width and height of windows.

var moveCounter = -1;
var startEventPos = new Array();
var startPosWindow = new Array();
var startWindowSize = new Array();
var initResizeCounter = -1;
var activeWindow = false;
var activeWindowContent = false;
var windowSizeArray = new Array();
var windowPositionArray = new Array();
var currentZIndex = 10000;
var windowStateArray = new Array(); // Minimized or maximized
var activeWindowIframe = false;
var divCounter = 0;


function moveWindow(e) {

    if (document.all) e = event;
    if (moveCounter >= 10) {
        activeWindow.style.left = startPosWindow[0] + e.clientX - startEventPos[0] + 'px';
        activeWindow.style.top = startPosWindow[1] + e.clientY - startEventPos[1] + 'px';
    }

    if (initResizeCounter >= 10) {
        var newWidth = Math.max(windowMinSize[0], startWindowSize[0] + e.clientX - startEventPos[0]);
        var newHeight = Math.max(windowMinSize[1], startWindowSize[1] + e.clientY - startEventPos[1]);
        activeWindow.style.width = newWidth + 'px';
        activeWindowContent.style.height = newHeight + 'px';


        if (MSIEWIN && activeWindowIframe) {
            activeWindowIframe.style.width = (newWidth) + 'px';
            activeWindowIframe.style.height = (newHeight + 20) + 'px';
        }
    }
    /*********   To hide dragable content while resizing  **********/

//    dragDropMoveLayer.style.display = 'none';
//    dragDropMoveLayer.innerHTML = '';

    /***************************************************************/
    if (!document.all) return false;
}

function switchElement(e, inputElement) {
    if (!inputElement) inputElement = this;
    var numericId = inputElement.id.replace(/[^0-9]/g, '');
    var state = '0';
    if (windowStateArray[numericId]) state = '1';

    if (activeWindow && activeWindowContent) {
        Set_Cookie(activeWindow.id + '_attr', activeWindow.style.left.replace('px', '') + ',' + activeWindow.style.top.replace('px', '') + ',' + activeWindow.style.width.replace('px', '') + ',' + activeWindowContent.style.height.replace('px', '') + ',' + activeWindow.style.zIndex + ',' + state, 50);

    }
    currentZIndex = currentZIndex / 1 + 1;
    activeWindow = document.getElementById('dhtml_goodies_id' + numericId);
    activeWindow.style.zIndex = currentZIndex;
    activeWindowContent = document.getElementById('windowContent' + numericId);

    Set_Cookie(activeWindow.id + '_attr', activeWindow.style.left.replace('px', '') + ',' + activeWindow.style.top.replace('px', '') + ',' + activeWindow.style.width.replace('px', '') + ',' + activeWindowContent.style.height.replace('px', '') + ',' + activeWindow.style.zIndex + ',' + state, 50);
}

function hideWindow() {
    switchElement(false, document.getElementById('dhtml_goodies_id' + this.id.replace(/[^\d]/g, '')));
    activeWindow.style.display = 'none';
}

function initWindows(e, divObj) {
    divCounter = 0;
    initdragableElements();
    var divs = document.getElementsByTagName('DIV');

    for (var no = 0; no < divs.length; no++) {

        if (divs[no].className == 'dhtmlgoodies_window') {

            if (divObj) {
                divs[no].style.zIndex = currentZIndex;
                currentZIndex = currentZIndex / 1 + 1;
            }
            divCounter = divCounter + 1;
            if (divCounter == 1) activeWindow = divs[no];
            divs[no].id = 'dhtml_goodies_id' + divCounter;
            if (readSizeFromCookie) var cookiePos = Get_Cookie(divs[no].id + '_attr') + ''; else cookiePos = '';
            if (divObj) cookiePos = '';
            var cookieValues = new Array();


            if (cookiePos.indexOf(',') > 0) {
                cookieValues = cookiePos.split(',');
                if (!windowPositionArray[divCounter]) windowPositionArray[divCounter] = new Array();
                windowPositionArray[divCounter][0] = Math.max(0, cookieValues[0]);
                windowPositionArray[divCounter][1] = Math.max(0, cookieValues[1]);
            }

            if (cookieValues.length == 5 && !zIndexSet) {
                divs[no].style.zIndex = cookieValues[4];
                if (cookieValues[4] / 1 > currentZIndex) currentZIndex = cookieValues[4] / 1;
            }
            if (windowPositionArray[divCounter]) {
                divs[no].style.left = windowPositionArray[divCounter][0] + 'px';
                divs[no].style.top = windowPositionArray[divCounter][1] + 'px';
            }
        }
    }
    return divCounter;
}

/* This function illustrates how you can create a new custom window dynamically */

var rectangleBorderWidth = 2; // Used to set correct size of the rectangle with red dashed border
var useRectangle = false;
var autoScrollSpeed = 4; // Autoscroll speed	- Higher = faster

//------------------------------------
var dragableElementsParentBox;
var opera = navigator.appVersion.indexOf('Opera') >= 0 ? true : false;

var rectangleDiv = false;
var insertionMarkerDiv = false;
var mouse_x;
var mouse_y;

var el_x;
var el_y;

var dragDropTimer = -1;
var dragObject = false;
var dragObjectNextObj = false;
var dragableObjectArray = new Array();
var destinationObj = false;
var currentDest = false;
var allowRectangleMove = true;
var dragDropMoveLayer;
var autoScrollActive = false;
var documentHeight = false;
var documentScrollHeight = false;
var dragableAreaWidth = false;

function getTopPos(inputObj) {
    var returnValue = inputObj.offsetTop;
    while ((inputObj = inputObj.offsetParent) != null) {
        if (inputObj.tagName != 'HTML') returnValue += inputObj.offsetTop;
    }
    return returnValue;
}

function getLeftPos(inputObj) {
    var returnValue = inputObj.offsetLeft;
    while ((inputObj = inputObj.offsetParent) != null) {
        if (inputObj.tagName != 'HTML') returnValue += inputObj.offsetLeft;
    }
    return returnValue;
}

function getObjectFromPosition(x, y) {
    var height = dragObject.offsetHeight;
    var width = dragObject.offsetWidth;
    var indexCurrentDragObject = -5;
    for (var no = 0; no < dragableObjectArray.length; no++) {
        ref = dragableObjectArray[no];
        if (ref['obj'] == dragObject) indexCurrentDragObject = no;
        if (no < dragableObjectArray.length - 1 && dragableObjectArray[no + 1]['obj'] == dragObject) indexCurrentDragObject = no + 1;
        if (ref['obj'] == dragObject && useRectangle) continue;
        if (x > ref['left'] && y > ref['top'] && x < (ref['left'] + (ref['width'] / 2)) && y < (ref['top'] + ref['height'])) {
            if (!useRectangle && dragableObjectArray[no]['obj'] == dragObject) return 'self';
            if (indexCurrentDragObject == (no - 1)) return 'self';
            return Array(dragableObjectArray[no], no);
        }

        if (x > (ref['left'] + (ref['width'] / 2)) && y > ref['top'] && x < (ref['left'] + ref['width']) && y < (ref['top'] + ref['height'])) {
            if (no < dragableObjectArray.length - 1) {
                if (no == indexCurrentDragObject || (no == indexCurrentDragObject - 1)) {
                    return 'self';
                }
                if (dragableObjectArray[no]['obj'] != dragObject) {
                    return Array(dragableObjectArray[no + 1], no + 1);
                } else {
                    if (!useRectangle) return 'self';
                    if (no < dragableObjectArray.length - 2) return Array(dragableObjectArray[no + 2], no + 2);
                }
            } else {
                if (dragableObjectArray[dragableObjectArray.length - 1]['obj'] != dragObject) return 'append';

            }
        }
        if (no < dragableObjectArray.length - 1) {
            if (x > (ref['left'] + ref['width']) && y > ref['top'] && y < (ref['top'] + ref['height']) && y < dragableObjectArray[no + 1]['top']) {
                return Array(dragableObjectArray[no + 1], no + 1);
            }
        }
    }
    if (x > ref['left'] && y > (ref['top'] + ref['height'])) return 'append';
    return false;
}

function initDrag(e) {

    if (document.all) e = event;
    mouse_x = e.clientX;
    mouse_y = e.clientY;
    if (!documentScrollHeight) documentScrollHeight = document.documentElement.scrollHeight + 100;
    el_x = getLeftPos(this) / 1;
    el_y = getTopPos(this) / 1;
    dragObject = this;
    dragDropTimer = 0;
    dragObjectNextObj = false;
    if (this.nextSibling) {
        dragObjectNextObj = this.nextSibling;
        if (!dragObjectNextObj.tagName) dragObjectNextObj = dragObjectNextObj.nextSibling;
    }
    initDragTimer();
    return false;
}

function initDragTimer() {
    if (dragDropTimer >= 0 && dragDropTimer < 10) {
        dragDropTimer++;
        setTimeout('initDragTimer()', 5);
        return;
    }
    if (dragDropTimer == 10) {

        if (useRectangle) {
            dragObject.style.opacity = 0.5;
            dragObject.style.filter = 'alpha(opacity=50)';
            dragObject.style.cursor = 'default';
        } else {
            var newObject = dragObject.cloneNode(true);
           // dragDropMoveLayer.appendChild(newObject);
        }
    }
}


function autoScroll(direction, yPos) {
    if (document.documentElement.scrollHeight > documentScrollHeight && direction > 0) return;

    window.scrollBy(0, direction);

    if (direction < 0) {
        if (document.documentElement.scrollTop > 0) {
            mouse_y = mouse_y - direction;
            if (useRectangle) {
                dragObject.style.top = (el_y - mouse_y + yPos) + 'px';
            } else {
                dragDropMoveLayer.style.top = (el_y - mouse_y + yPos) + 'px';
            }
        } else {
            autoScrollActive = false;
        }
    } else {
        if (yPos > (documentHeight - 50)) {

            mouse_y = mouse_y - direction;
            if (useRectangle) {
               // dragObject.style.top = (el_y - mouse_y + yPos) + 'px';
            } else {
               // dragDropMoveLayer.style.top = (el_y - mouse_y + yPos) + 'px';
            }
        } else {
            autoScrollActive = false;
        }
    }
    if (autoScrollActive) setTimeout('autoScroll(' + direction + ',' + yPos + ')', 5);
}

function moveDragableElement(e) {
    if (document.all) e = event;

    if (dragDropTimer < 10) return;
    if (!allowRectangleMove) return false;


    if (e.clientY < 50 || e.clientY > (documentHeight - 50)) {
        if (e.clientY < 50 && !autoScrollActive) {
            autoScrollActive = true;
            autoScroll((autoScrollSpeed * -1), e.clientY);
        }

        if (e.clientY > (documentHeight - 50) && document.documentElement.scrollHeight <= documentScrollHeight && !autoScrollActive) {
            autoScrollActive = true;
            autoScroll(autoScrollSpeed, e.clientY);
        }
    } else {
        autoScrollActive = false;
    }
    if (useRectangle) {
        if (dragObject.style.position != 'absolute') {
            dragObject.style.position = 'absolute';
        }
    }

    if (useRectangle) {
    } else {
      //  dragDropMoveLayer.style.display = 'block';
    }

    if (useRectangle) {
        dragObject.style.left = (el_x - mouse_x + e.clientX + Math.max(document.body.scrollLeft, document.documentElement.scrollLeft)) + 'px';
        dragObject.style.top = (el_y - mouse_y + e.clientY) + 'px';
    } else {
        //dragDropMoveLayer.style.left = (el_x - mouse_x + e.clientX + Math.max(document.body.scrollLeft, document.documentElement.scrollLeft)) + 'px';
       // dragDropMoveLayer.style.top = (el_y - mouse_y + e.clientY) + 'px';
    }
    dest = getObjectFromPosition(e.clientX + Math.max(document.body.scrollLeft, document.documentElement.scrollLeft), e.clientY + Math.max(document.body.scrollTop, document.documentElement.scrollTop));

    if (dest !== false && dest != 'append' && dest != 'self') {
        destinationObj = dest[0];

        if (currentDest !== destinationObj) {
            currentDest = destinationObj;
        }
    }

    if (dest == 'self' || !dest) {
        destinationObj = dest;
    }

    if (dest == 'append') {
        if (useRectangle) {

            dragableElementsParentBox.appendChild(document.getElementById('clear'));
        } else {
            var tmpRef = dragableObjectArray[dragableObjectArray.length - 1];
        }
        destinationObj = dest;

    }

    if (useRectangle && !dest) {
        destinationObj = currentDest;
    }

    allowRectangleMove = false;
    setTimeout('allowRectangleMove=true', 50);
}

function stop_dragDropElement() {
    dragDropTimer = -1;

    if (destinationObj && destinationObj != 'append' && destinationObj != 'self') {
        destinationObj['obj'].parentNode.insertBefore(dragObject, destinationObj['obj']);
    }
    if (destinationObj == 'append') {
        dragableElementsParentBox.appendChild(dragObject);
    }

    if (dragObject && useRectangle) {
        dragObject.style.opacity = 1;
        dragObject.style.filter = 'alpha(opacity=100)';
        dragObject.style.cursor = 'move';
        dragObject.style.position = 'static';
    }

    dragObject = false;
    currentDest = false;
    resetObjectArray();
    destinationObj = false;
    if (dragDropMoveLayer) {
//        dragDropMoveLayer.style.display = 'none';
//        dragDropMoveLayer.innerHTML = '';
    }
    autoScrollActive = false;
    //documentScrollHeight = document.documentElement.scrollHeight + 100;
}


function resetObjectArray() {
    dragableObjectArray.length = 0;
    var subDivs = dragableElementsParentBox.getElementsByTagName('*');
    var countEl = 0;

    for (var no = 0; no < subDivs.length; no++) {
        var attr = subDivs[no].getAttribute('dragableBox');
        if (opera) attr = subDivs[no].dragableBox;
        if (attr == 'true') {
            var index = dragableObjectArray.length;
            dragableObjectArray[index] = new Array();
            ref = dragableObjectArray[index];
            ref['obj'] = subDivs[no];
            ref['width'] = subDivs[no].offsetWidth;
            ref['height'] = subDivs[no].offsetHeight;
            ref['left'] = getLeftPos(subDivs[no]);
            ref['top'] = getTopPos(subDivs[no]);
            ref['index'] = countEl;
            countEl++;
        }
    }
}

function initdragableElements() {
    dragableElementsParentBox = document.getElementById('dragableElementsParentBox');
    dragableAreaWidth = dragableElementsParentBox.offsetWidth;

    if (!useRectangle) {
//        dragDropMoveLayer = document.createElement('DIV');
//        dragDropMoveLayer.id = 'dragDropMoveLayer';
//        document.body.appendChild(dragDropMoveLayer);
    }

    var subDivs = dragableElementsParentBox.getElementsByTagName('*');
    var countEl = 0;
    for (var no = 0; no < subDivs.length; no++) {
        var attr = subDivs[no].getAttribute('dragableBox');
        if (opera) attr = subDivs[no].dragableBox;
        if (attr == 'true') {
            subDivs[no].style.cursor = 'move';
            subDivs[no].onmousedown = initDrag;

            var index = dragableObjectArray.length;
            dragableObjectArray[index] = new Array();
            ref = dragableObjectArray[index];
            ref['obj'] = subDivs[no];
            ref['width'] = subDivs[no].offsetWidth;
            ref['height'] = subDivs[no].offsetHeight;
            ref['left'] = getLeftPos(subDivs[no]);
            ref['top'] = getTopPos(subDivs[no]);
            ref['index'] = countEl;
            countEl++;
        }
    }

    document.body.onmousemove = moveDragableElement;
    document.body.onmouseup = stop_dragDropElement;
    // document.body.onselectstart = cancelSelectionEvent;
    //document.body.ondragstart = cancelEvent;
    //window.onresize = repositionDragObjectArray;
    documentHeight = document.documentElement.clientHeight;
}
window.onload = initWindows;