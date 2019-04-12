function getNewContent(){
    let request =getHTTPObject();
    if(request){
        request.open("GET","example.txt",true);
        request.onreadystatechange=function(){
            if(request.readyState==4){
                alert("response received");
                let para = document.createElement("p");
                let txt = document.createTextNode(request.responseText);
                para.appendChild(txt);
                document.getElementById("new").appendChild(para);
            }
        }
        request.send(null);
    }else{
        alert("Sorry, your browser does not support XMLHttpRequest");
    }
    alert("function done");
}
addLoadEvent(getNewContent);