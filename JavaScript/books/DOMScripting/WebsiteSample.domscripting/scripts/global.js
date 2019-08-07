function addLoadEvent(func) {
    let oldonload = window.onload;
    if (typeof window.onload != 'function')
        window.onload = func();
    else
        window.onload = function () {
            oldonload();
            func();
        };

}

function insertAfter(newElement, targetElement) {
    let parent = targetElement.parenet;
    if (parent.lastChild == targetElement)
        targetElement.appendChild(newElement);
    else
        parent.insertBefore(newElement, targetElement.nextSibling);
}

function addClass(element, value) {
    if (!element.className) element.className = value;
    else element.className = element.className + ' ' + value;
}

function highlightPage() {
    if (!document.getElementsByTagName || !document.getElementById) return false;
    let headers = document.getElementsByTagName('header');
    if (headers.length <= 0) return false;
    let links = headers[0].getElementsByTagName('nav')[0].getElementsByTagName('a');
    for (let i = 0; i < links.length; i++) {
        if (window.location.href.indexOf(links[i].getAttribute("href")) != -1) {
            links[i].className = "here";
            document.body.setAttribute("id", links[i].lastChild.nodeValue.toLowerCase());
        }
    }
}
addLoadEvent(highlightPage);

function moveElement(elementID, fx, fy, interval) {
    if (!document.getElementById || !document.getElementById(elementID)) return false;
    let ele = document.getElementById(elementID);
    if (ele.movement) clearTimeout(ele.movement);

    if (!ele.style.left) ele.style.left = "0px";
    if (!ele.style.top) ele.style.top = "0px";

    let px = parseInt(ele.style.left);
    let py = parseInt(ele.style.top);

    if (px == fx && py == fy) return true;

    if (px < fx) px = px + Math.ceil((fx - px) / 10);
    if (px > fx) px = px - Math.ceil((px - fx) / 10);
    if (py < fy) py = py + Math.ceil((fy - py) / 10);
    if (py > fy) py = py - Math.ceil((py - fy) / 10);

    ele.style.left = px + "px";
    ele.style.top = py + "px";

    let repeat = "movement()";
}

function addLoadEvent(func) {
    let oldonload = window.onload;
    if (typeof window.onload != 'function')
        window.onload = func();
    else
        window.onload = function () {
            oldonload();
            func();
        };

}

function insertAfter(newElement, targetElement) {
    let parent = targetElement.parentNode;
    if (parent.lastChild == targetElement)
        targetElement.appendChild(newElement);
    else
        parent.insertBefore(newElement, targetElement.nextSibling);
}

function addClass(element, value) {
    if (!element.className) element.className = value;
    else element.className = element.className + ' ' + value;
}

//home
function highlightPage() {
    if (!document.getElementsByTagName || !document.getElementById) return false;
    let headers = document.getElementsByTagName('header');
    if (headers.length <= 0) return false;
    let links = headers[0].getElementsByTagName('nav')[0].getElementsByTagName('a');
    for (let i = 0; i < links.length; i++) {
        if (window.location.href.indexOf(links[i].getAttribute("href")) != -1) {
            links[i].className = "here";
            document.body.setAttribute("id", links[i].lastChild.nodeValue.toLowerCase());
        }
    }
}
addLoadEvent(highlightPage);

function moveElement(elementID, fx, fy, interval) {
    if (!document.getElementById || !document.getElementById(elementID)) return false;
    let ele = document.getElementById(elementID);
    if (ele.movement) clearTimeout(ele.movement);

    if (!ele.style.left) ele.style.left = "0px";
    if (!ele.style.top) ele.style.top = "0px";

    let px = parseInt(ele.style.left);
    let py = parseInt(ele.style.top);

    if (px == fx && py == fy) return true;

    if (px < fx) px = px + Math.ceil((fx - px) / 10);
    if (px > fx) px = px - Math.ceil((px - fx) / 10);
    if (py < fy) py = py + Math.ceil((fy - py) / 10);
    if (py > fy) py = py - Math.ceil((py - fy) / 10);

    ele.style.left = px + "px";
    ele.style.top = py + "px";

    let repeat = "moveElement('" + elementID + "'," + fx + "," + fy + "," + interval + ")";
    ele.movement = setTimeout(repeat, interval);
}

function prepareSlideShow() {
    if (!document.getElementById("intro")) return false;
    let intro = document.getElementById("intro");
    let slideshow = document.createElement("div");
    slideshow.setAttribute("id", "slideshow");
    let frame = document.createElement("img");
    frame.setAttribute("src", "images/frame.gif");
    frame.setAttribute("alt", "");
    frame.setAttribute("id", "frame");
    slideshow.appendChild(frame);

    let preview = document.createElement("img");
    preview.setAttribute("src", "images/slideshow.gif");
    preview.setAttribute("alt", "glimpse slide show");
    preview.setAttribute("id", "preview");
    slideshow.appendChild(preview);
    insertAfter(slideshow, intro);
    let links = document.getElementsByTagName("a");
    let destination;

    for (let i = 0; i < links.length; i++) {
        links[i].onmouseover = function () {
            destination = this.getAttribute("href");
            if (destination.indexOf("index.html") != -1) moveElement("preview", 0, 0, 5);
            if (destination.indexOf("about.html") != -1) moveElement("preview", -150, 0, 5);
            if (destination.indexOf("photos.html") != -1) moveElement("preview", -300, 0, 5);
            if (destination.indexOf("live.html") != -1) moveElement("preview", -450, 0, 5);
            if (destination.indexOf("contact.html") != -1) moveElement("preview", -600, 0, 5);
        }
    }


}
addLoadEvent(prepareSlideShow);


//about
function showSection(id) {
    let sections = document.getElementsByTagName("section");
    for (let i = 0; i < sections.length; i++) {
        if (sections[i].getAttribute("id") != id)
            sections[i].style.display = "none";
        else
            sections[i].style.display = "block";
    }
}

function prepareInternalnav() {
    if (!document.getElementById) return false;
    if (!document.getElementsByTagName) return false;

    let articles = document.getElementsByTagName("article");
    if (typeof articles == "undefined" || articles.length == 0) return false;

    let navs = articles[0].getElementsByTagName("nav");
    if (typeof navs == "undefined" || navs.length == 0) return false;

    let links = navs[0].getElementsByTagName("a");
    for (let i = 0; i < links.length; i++) {
        let sectionID = links[i].getAttribute("href").split("#")[1];
        if (!document.getElementById(sectionID)) continue;
        document.getElementById(sectionID).style.display = "none";

        links[i].desc = sectionID;
        links[i].onclick = function () {
            showSection(sectionID);
            return false;
        }
    }
}
addLoadEvent(prepareInternalnav);


function showPic(whichPic) {
    if (!document.getElementById("placeholder")) return true;
    let source = whichPic.getAttribute("href");
    let placeholder = document.getElementById("placeholder");
    placeholder.setAttribute("src", source);
    console.log(placeholder.src);

    if (!document.getElementById("description")) return false;
    let description = document.getElementById("description");

    if (description.firstChild.nodeType != 3) return false;

    if (whichPic.getAttribute("title")) {
        description.firstChild.nodeValue = whichPic.getAttribute("title");
    } else {
        description.firstChild.nodeValue = "";
    }
    return false;
}

function preparePlaceholder() {
    if (!document.getElementById || !document.createElement || !document.createTextNode) return false;
    let placeholder = document.createElement("img");
    placeholder.setAttribute("id", "placeholder");
    placeholder.setAttribute("src", "images/placeholder.gif");
    placeholder.setAttribute("alt", "image gallery");

    let desc = document.createElement("p");
    desc.setAttribute("id", "description");
    let desctext = document.createTextNode("choose an image");
    desc.appendChild(desctext);

    let gallery = document.getElementById("imagegallery");
    if (!gallery) return false;
    insertAfter(desc, gallery);
    insertAfter(placeholder, desc);
}

function prepareGallery() {
    if (!document.getElementsByTagName || !document.getElementById("imagegallery")) return false;
    let gallery = document.getElementById("imagegallery");
    let links = gallery.getElementsByTagName("a");

    for (let i = 0; i < links.length; i++)
        links[i].onclick = function () {
            return showPic(this);
        };
}
addLoadEvent(preparePlaceholder);
addLoadEvent(prepareGallery);

// live 
function stripeTables() {
    if (!document.getElementsByTagName) return false;
    let tables = document.getElementsByTagName("table");
    for (let i = 0; i < tables.length; i++) {
        let odd = false;
        let rows = tables[i].getElementsByTagName("tr");

        for (let j = 0; j < rows.length; j++) {
            if (odd == true) {
                addClass(rows[j], "odd");
                odd = false;
            } else {
                odd = true;
            }
        }
    }
}

function highlightRows() {
    if (!document.getElementsByName) return false;
    let rows = document.getElementsByTagName("tr");
    for (let i = 0; i < rows.length; i++) {
        rows[i].oldClassName = rows[i].className;
        rows[i].onmouseover = function () {
            addClass(this, "highlight");
        }
        rows[i].onmouseout = function () {
            rows[i].className = rows[i].oldClassName;
        }
    }
}

function displayAbbreviations() {
    if (!document.getElementsByTagName || !document.createElement ||
        !document.createTextNode) return false;

    let abbreviations = document.getElementsByTagName("abbr");
    if (abbreviations.length <= 0) return false;

    let defs = new Array();
    for (let i = 0; i < abbreviations.length; i++) {
        let curr_abbr = abbreviations[i];
        if (curr_abbr.childNodes.length < 1) continue;
        let def = curr_abbr.getAttribute("title");
        let key = curr_abbr.lastChild.nodeValue;
        defs[key] = def;
    }

    let dlist = document.createElement("dl");
    for (key in defs) {
        let dtitle = document.createElement("dt");
        let dt_text = document.createTextNode(key);
        dtitle.appendChild(dt_text);

        let ddesc = document.createElement("dd");
        let dd_text = document.createTextNode(defs[key]);
        ddesc.appendChild(dd_text);

        dlist.appendChild(dtitle);
        dlist.appendChild(ddesc);
    }

    if (dlist.childNodes.length < 1) return false;
    let header = document.createElement("h4");
    let h_text = document.createTextNode("abbreviations");
    header.appendChild(h_text);

    let articles = document.getElementsByTagName("article");
    if (articles.length <= 0) return false;
    articles[0].appendChild(header);
    articles[0].appendChild(dlist);
}
addLoadEvent(stripeTables);
addLoadEvent(highlightRows);
addLoadEvent(displayAbbreviations);

// contact
function focusLabels() {
    if (document.getElementsByTagName) return false;
    let labels = document.getElementsByTagName("label");
    for (let i = 0; i < labels.length; i++) {
        labels[i].onclick = function () {
            let eleid = this.getAttribute("for");
            let ele = this.getElementById(eleid);
            ele.focus();
        }
    }
}
addLoadEvent(focusLabels);

function resetFields(targetForm) {
    if (!'placeholder' in document.createElement('input')) return;
    for (let i = 0; i < targetForm.elements.length; i++) {
        let ele = targetForm.elements[i];
        if (ele.type == "submit") continue;
        if (!ele.getAttribute("placeholder")) return false;
        ele.onfocus = function () {
            let text = this.placeholder || this.getAttribute("placeholder");
            if (this.value == text) {
                this.className = "";
                this.value = "";
            }
        }
        ele.onblur = function () {
            if (this.value == "") {
                this.className = "placeholder";
                this.value = this.placeholder || this.getAttribute("placeholder");
            }
        }
        ele.onblur();
    }
}



// ajax
function getHTTPObject() {
    if (typeof XMLHttpRequest == "undefined") {
        XMLHttpRequest = function () {
            try {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            } catch (e) {}
            try {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            } catch (e) {}
            try {
                return new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {}
        }
    }

    return new XMLHttpRequest();
}

function displayAjaxLoading(element) {
    while (element.hasChildNodes()) {
        element.removeChild(element.lastChild);
    }

    let content = document.createElement("img");
    content.setAttribute("src", "images/loading.gif");
    content.setAttribute("alt", "Loading...");
    // Append the loading element.
    element.appendChild(content);
}

function submitFormWithAjax(whichForm, thetarget) {
    let request = getHTTPObject();
    if (!request) return false;
    displayAjaxLoading(thetarget);

    let dataParts = [];
    let element;
    for (let i = 0; i < whichForm.elements.length; i++) {
        element = whichForm.elements[i];
        dataParts[i] = element.name + '-' + encodeURIComponent(element.value);
    }
    let data = dataParts.join('&');

    request.open("POST", whichForm.getAttribute("action"), true);
    request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            if (request.status == 200 || request.status == 0) {
                let matches = request.responseText.match(/<article>([\s\S]+)<\/article>/);

                if (matches && matches.length > 0) thetarget.innerHTML = matches[1];
                else thetarget.innerHTML = "<p> ajax error. </p>";
            } else {
                thetarget.innerHTML = "<p> request error. </p>";
            }
        }
    }
    request.send(data);
    return true;
}

function prepareForms() {
    for (let i = 0; i < document.forms.length; i++) {
        let thisform = document.forms[i];
        resetFields(thisform);
        thisform.onsubmit = function () {
            let article = document.getElementsByTagName("article")[0];
            if (submitFormWithAjax(this, article)) return false;
            return true;
        }
    }
}
addLoadEvent(prepareForms);




function getActiveImgIndex(element, arrow) {
    if(!element||!arrow) return;
    var index = 0;
    var beforeIndex = 0;
    if(element.indexOf('L') > 0){
        beforeIndex = _leftImagesIndex;
        if (arrow == 'pre') {
            if (_leftImagesIndex == 0) _leftImagesIndex = _leftImages.length - 1;
            else _leftImagesIndex--;
        } else {
            if (_leftImagesIndex == _leftImages.length - 1) _leftImagesIndex = 0;
            else _leftImagesIndex++;
        } 
        index = _leftImagesIndex;
    } else{
        beforeIndex = _rightImagesIndex;
        if (arrow == 'pre') {
            if (_rightImagesIndex == 0) _rightImagesIndex = _rightImages.length - 1;
            else _rightImagesIndex--;
        } else {
            if (_rightImagesIndex == _rightImages.length - 1) _rightImagesIndex = 0;
            else _rightImagesIndex++;
        } 
        index = _rightImagesIndex;
    }

    var gallerialList = document.getElementById(element); 
    var gallerialThumbnailsContainer = gallerialList.getElementsByClassName('galleria-thumbnails')[0];
    if (!element || !document.getElementById(element)) return;
    if (!gallerialThumbnailsContainer) return;
    var gallerialThumbnails = gallerialThumbnailsContainer.getElementsByClassName('galleria-image');
    if (!gallerialThumbnails) return; 
    var divGalleriaImg  = gallerialThumbnails[index];
    divGalleriaImg.className = divGalleriaImg.className.replace(' active', '');
    divGalleriaImg.getElementsByTagName('img')[0].style.opacity = 0.4; 
    var beforeDivGalleriaImg  = gallerialThumbnails[beforeIndex]; 
    beforeDivGalleriaImg.className = beforeDivGalleriaImg.className + ' active';
    beforeDivGalleriaImg.getElementsByTagName('img')[0].style.opacity = 1;

    return ;
}