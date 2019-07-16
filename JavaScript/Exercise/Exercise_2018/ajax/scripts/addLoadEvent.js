function addLoadEvent(func) {
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