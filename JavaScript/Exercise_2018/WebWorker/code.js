self.onmessage = function (event) {
    self.postMessage("code.js say" + event.data);
};


