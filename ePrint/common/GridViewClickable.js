// JScript File

function RequestData(linkId, cellElement, evt)
    {
        var evtSource;
        evt = (evt)? evt : window.event;
        evtSource = (evt.srcElement)? evt.srcElement : evt.target; 

        //When a hyperlink is clicked, Safari returns the text node as the source element rather
        //than the hyperlink. parentNode will give us the hyperlink element.
        //ref: http://developer.apple.com/internet/webcontent/eventmodels.html
        if (evt.target) {

            if (evt.target.nodeType == 3) {

                evtSource = evtSource.parentNode;
            }
        }

        //If event was raised from an element other than the LinkButton
        if ((evtSource.getAttribute("id") != linkId) && (evt.type == "click")) { 

            //Get a collection of "a" tags inside the cell
            var linkCollection = cellElement.getElementsByTagName("a");
            for (var i = 0; i < linkCollection.length; i++) {

               //If the link button has an onclick attribute, call the onclick.
               //The onclick attribute is present when the GridView is using callback
               //example: onclick="java script:__gvGridSort1_GridView1.callback(...); return false;"

               var onClickAttribute = linkCollection[i].getAttribute("onclick");   
               if (onClickAttribute != null) {
                linkCollection[i].onclick();  
                break;

               }

               //If the link button has a href attribute, set the location of the page to the href value.
               //The href attribute is used when the GridView is not using callbacks
               //example: href="java script:__doPostBack('GridSort1$GridView1','Sort$UnitsOnOrder')" 

               var hrefAttribute = linkCollection[i].getAttribute("href");
               this.location.href = hrefAttribute;
               break;
            }
        }
    }
