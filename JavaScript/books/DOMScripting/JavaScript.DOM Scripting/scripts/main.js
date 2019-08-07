function addloadEvent(func) {
    let oldonLoad = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func
    } else {
        window.onload = function () {
            oldonLoad();
            func();
        }
    }
}

function insertAfter(newElement, targetElement) {
    let parent = targetElement.parentNode;
    if (parent.lastChild == targetElement)
        parent.appendChild(newElement);
    else
        parent.insertBefore(newElement, targetElement.nextSibling);
}

function preparePlaceholder() {
    if (!document.createElement || !document.createTextNode) return false;
    if (!document.getElementById || !document.getElementById('imagallery')) return false;
    // <img id="placeholder" src="images/first.jpg" alt="image gallery" height="" />
    // <p id="imgdesc">choose an image.</p>
    let placeholder = document.createElement('img');
    placeholder.setAttribute("id", "placeholder");
    placeholder.setAttribute("src", "images/first.jpg");
    placeholder.setAttribute("alt", "image gallery");
    let imgdesc = document.createElement("p");
    imgdesc.setAttribute("id", "imgdesc");
    let desc = document.createTextNode("choose an image.");
    imgdesc.appendChild(desc);
    let gallery = document.getElementById("imagallery");
    insertAfter(placeholder, gallery);
    insertAfter(desc, placeholder);
}
addloadEvent(preparePlaceholder);

function showPic(e) {
    let placeholder = document.getElementById("placeholder");
    if (!placeholder || placeholder.nodeName != "IMG") return false;
    placeholder.setAttribute("src", e.getAttribute("href"));

    let imgdesc = document.getElementById("imgdesc");
    if (imgdesc)
        imgdesc.firstChild.nodeValue = e.getAttribute("title") ? e.getAttribute("title") : "";
    return true;
}

function prepareGallery() {
    if (!document.getElementsByTagName || !document.getElementById) return false; //向后兼容
    if (!document.getElementById("imagallery")) return false;
    let gallery = document.getElementById("imagallery");
    let links = gallery.getElementsByTagName("a");
    for (let i = 0; i < links.length; i++) {
        if (!links[i].onclick)
            links[i].onclick = function () {
                return !showPic(this);
            };
        // if (!links[i].onkeypress)
        //     links[i].onkeypress = links[i].onclick;
    }
}
addloadEvent(prepareGallery);

function prepareLinks() {
    if (!document.getElementsByTagName) return false; //向后兼容
    let links = document.getElementsByTagName('a');
    for (let i = 0; i < links.length; i++)
        if (links[i].getAttribute("class") == "popUp") {
            links[i].onclick = function () {
                popUp(this.getAttribute("href"));
                return false;
            }
        }
}
addloadEvent(prepareLinks);


//test
function countBodyChildren() {
    let bodyElement = document.getElementsByTagName("body")[0];
    //console.log(bodyElement.childNodes.length);
}

function popUp(winURL) {
    window.open(winURL, "popup", "width=320,height=480");
}