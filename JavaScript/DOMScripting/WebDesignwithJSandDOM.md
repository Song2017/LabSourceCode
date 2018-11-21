##chapter 2: JavaScript 语法
JavaScript嵌入到html中的方式: 3种
    作为一种解释型语言直接被浏览器读入并执行
语法
    语句: 像英语中的句子,只不过受体是浏览器
    注释: 受体是开发和维护的人.方式: //, /*...*/
    变量: 计算机中的一小块固定的内存区域,变量指向这块内存的地址,内存代表的值就是变量的值.
        程序运行过程中,变量的值可以改变.变量的名字区分大小写.
    数据类型: 弱类型语言,在声明变量的时候可以不指定具体的数据类型,给予开发者更大的使用自由,但也容易出现运行时错误.
        字符串: 单引号,双引号是等价的.内容中的特殊字符可以转义,'this is \'escaping\'.'
        数值: 直接使用的是浮点数,整数只是其子集
        布尔值: 只有两个值true/false,对应电路的开与关,电流的有无
        数组: 用一个变量表示值的集合.同一个数组中元素的类型可以不一致.
            var ary = Array(12,'as',true);
        对象: 对象也用一个名字表示一组值,对象的值都是其属性,与数组不一样的,属性的名字可以是有意义的字符串.
            var obj = {name:'obj',year:'1999',living:false };
操作
    算术操作符: + - * /, ++, (),
    拼接操作符: + 非数字
    比较操作符: 
    逻辑操作符:  
条件语句和循环语句
    if
    for/while
函数和对象
    函数: 一组允许在代码里随时调用的语句.每个函数都是一个短小的脚本
        函数体对变量来说是局部作用域
    对象: 是可以自定义的非常重要的数据类型.对象里数据的访问形式: 属性和方法
        内建对象: JavaScript自定义的对象 数组
        宿主对象: 浏览器自定义的对象 document
        用户自定义对象: 


##chapter 3: DOM Document Object Model 文档对象模型
1. 一份文档就是一棵节点树
2. 节点分为不同的类型: 共12种,常用,**元素节点1,属性节点2,文本节点3,注释节点8**
3. getElementId: 对应文档里的一个特定的元素节点
4. getElementByTagName和getElementByclassName将返回一个对象数组,分别对应文档里的一组元素节点
5. 每个节点都是一个对象
6. 获取属性 node.getAttribute("href");
7. 设置属性 node.setAttribute("src", "test");


##chapter 4: JavaScript图片库
DOM提供的API编写JavaScript脚本,使用事件处理函数将脚本与网友连接起来
事件处理函数: 特定的事件发生时调用特定的JavaScript代码.被调用的JavaScript的函数会默认返回一个值,例如true.
    如果我们要阻止浏览器执行默认操作,只要认为写入return false；
    阻止用户单击图片链接后跳转界面

```
<a href="images/second.jpg" title='second' onclick="showPic(this);return false;"> second</a>
function showPic(e) {
    let placeholder = document.getElementById("placeholder");
    placeholder.setAttribute("src", e.getAttribute("href"));
    if (!e.getAttribute("title")) return;
    let imgdesc = document.getElementById("imgdesc");
    imgdesc.firstChild.nodeValue = e.getAttribute("title");
}
```
DOM的属性
childNodes 标准的,它返回指定元素的子元素集合,包括HTML节点,所有属性,文本. 
    let bodyElement = document.getElementsByTagName("body")[0];
    console.log(bodyElement.childNodes.length);
nodeType 判断是哪种类型的节点
    **1是元素节点,2是属性节点,3是文本节点**
nodeValue
    imgdesc.firstChild.nodeValue = e.getAttribute("title");
firstChild/lastChild
    firstChild实际上是bodyElement.childNode[0]


##chapter 5: 标记良好的内容就是一切
平稳退化: 用户在浏览器不支持JavaScript的情况下仍能完成基本的操作.
    <a href="http://www.baidu.com" onclick="popUp(this.href);return false;" title='Stationary degradation'>Stationary degradation</a>
    JavaScript伪协议,不推荐
    <a href="JavaScript:popUp('http://www.baidu.com')" title='fourth'> new tab</a>
分离JavaScript,参考CSS: 层叠样式表 渐进增强原则
    css: 将web文档的内容结构（标记）和版面设计（样式）分离开来
向后兼容
浏览器嗅探技术
性能考虑
    尽量减少访问DOM和尽量减少标记
        每次访问DOM标记都会搜索整个DOM树
    合并和放置脚本
        script标签放到</body>标签之前可以让页面变得更快
    压缩文件
        去掉空格,注释等


##chapter 6
原则: 行为与表现分离
    如果想用JavaScript给某个网页添加一些行为,就不应该让JavaScript代码对这个网页的结构有任何依赖
尽量让JavaScript代码不依赖于没有保证的假设,通过测试和检查实现代码的平稳退化
    let placeholder = document.getElementById("placeholder");
    if (!placeholder || placeholder.nodeName != "IMG") return false;
    placeholder.setAttribute("src", e.getAttribute("href"));
没有使用onkeypress事件处理函数,保证代码的可访问性
    if (!links[i].onclick)
        links[i].onclick = function () {
            return !showPic(this);
        };
    // if (!links[i].onkeypress)
    //     links[i].onkeypress = links[i].onclick;
把事件处理函数从html标记文档分离到外部的JavaScript文件,使JavaScript代码不对这个网页的结构有任何依赖
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
DOM Core和HTML-DOM
    [DOM Core](https://www.w3.org/TR/dom/): 定义了一个面向事件和树结构的跨平台模型.它规定了一套可以在浏览器,编译器等平台运行的树结构的模型的API.
    HTML-DOM: 用JavaScript实现的在浏览器中运行的DOM,为了方便使用,简写一些API.
    DOM Core                        HTML-DOM
    element.getAttribute("src");    element.src;


##chapter 7 动态创建标记
JavaScript通过创建新元素和修改现有元素来改变网页结构
```
//在window.onload后面追加函数
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
//在targetElement后边插入newElement
function insertAfter(newElement, targetElement) {
    let parent = targetElement.parentNode;
    if (parent.lastChild == targetElement)
        parent.appendChild(newElement);
    else
        parent.insertBefore(newElement, targetElement.nextSibling);
}
//图片展示区域通过JavaScript代码加载
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
```
Ajax 异步加载页面内容的技术
Ajax可以只更新页面中的一部分,优势就是对页面的请求以异步方式发送到服务器.
核心是XmlHttpRequest对象,充当着浏览器中脚本和服务器中间人的角色


##chapter 8: 充实文档的内容
1. 不要用JavaScript添加内容到网页上,因为不支持JavaScript的用户将看不到重要内容
    渐进增强: 从最核心的部分开始,也就是从内容开始.应该根据内容使用标记实现良好的结构.
    平稳退化: 渐进增强的实现必然支持平稳退化.按照渐进增强的原则去充实内容,那些缺乏css和dom支持的访问者仍可以访问到核心内容.
        display属性,inline: 横向排列；block: 独占一行；none: 不显示
2. dom技术为网页添加的实用小功能,最终可以用另一种结构呈现核心内容
    得到隐藏在属性里的信息
    创建标记封装这些信息
    将标记插入到文档中
    基本思路: 用js函数先把文档中的现有信息提炼出来,然后将信息以清晰有意义的方式重新插入到文档中.
3. DOM方法
    **检索信息: getElementById, getElementsByTagName, getAttribute**
    **添加信息: createElement, createTextNode, appendChild, insertBefore, setAttribute**


##chapter 9: CSS-DOM
网页: 
    结构层: HTML这类的标记语言创建,标签描述网页的语义    
        <p>this is text desc</p> 
    表示层: CSS来完成,描述页面如何呈现
        p { color: red;}
    行为层: JavaScript和DOM主宰的领域,负责如何响应事件
        let paras = document.getElementsByTagName('p');
        for(let i =0; i< paras.length;i++) paras[i].onclick = function(){alert("clicked.");}
style属性
1. document.getElementById('id').style 这是一个对象
2. 获取属性: 
    color element.style.color
    属性中有连字符*-*的,JavaScript会解释为减号,所以要去掉并使用驼峰命名法
    font-family element.style.fontFamily
3. style属性只能返回内嵌样式,就是紧跟在html标签内部style中的样式.
    但是用DOM只能设置内嵌样式,可以用style属性获取到
4. 设置样式: document.getElementById('id').style.color = "black";
5. 使用场景: 
    1. 根据元素在DOM树里的位置设置样式
        let headers = document.getElementsByTagName("h1");
        for (let i=0; i < headers.length; i++) {
            let elem = getNextElement(headers[i].nextSibling);
            elem.style.color = "red";
        }  
        function getNextElement(node) {
            if(node.nodeType == 1) {
                return node;
            }
            if (node.nextSibling) {
                return getNextElement(node.nextSibling);
            }
            return null;
        }
    2. 遍历节点集合设置样式, table标签中设置奇偶行的样式
        let tab = document.getElementsByTagName('table')[0];
        let rows = tab.getElementsByTagName('tr');
        let odd = false;
        for (let i =0; i< rows.length; i++){
            if(odd == true){
            rows[i].style.color = "orange";
            odd = false;
        }else{
            odd = true;
        }}
    3. 事件发生时设置元素样式
        let rows = document.getElementsByTagName('tr');
        for (let i=0;i< rows.length;i++){
        rows[i].onmouseover = function(){this.style.fontWeight = "bold";}
        rows[i].onmouseout = function(){this.style.fontWeight = "normal";}
        }
classname属性
    与其用DOM直接改变某个元素的样式,不如通过JavaScript更新元素的class属性
    odd { color: red; }
    function addClass(ele, value){
        if(!ele.className) { ele.className = value;}
        else {ele.className = ele.className + " " + value;	 }
    }
    let tab = document.getElementsByTagName('table')[0];
    let rows = tab.getElementsByTagName('tr');
    let odd = false;
    for (let i =0; i< rows.length; i++){
        if(odd == true){
        addClass(rows[i],"odd");
        odd = false;
    }else{
        odd = true;
    }}


##chapter10 JavaScript实现动画
动画: 随时间而改变某个元素在浏览器窗口里的显示位置
元素的位置 position, element.style.top
position:   static 默认值,元素将按照在标记里出现的先后顺序出现在浏览器窗口
            relative = static + float
            absolute 绝对位置, 所处容器的绝对位置
                top距离顶端 left距离左端 right bottom,对应的位置属性最好只设置一个
                element {
                    position: absolute;
                    top: 50px;
                    left: 100px;
                }
setTimeout 设置函数经过一段时间后执行
    let sample = setTimeout("function",interval);
    clearTimeout(sample);
    for(let i=0; i<5 ; i++){ setTimeout('alert(123)',2000*i); }
    Note: 同时执行两个movement（）会产生变量争用,,因为js是单线程的,会导致死循环
        解决: 介于全局变量和局部变量,作用于正在被移动的元素整个生命周期的的变量,元素的属性
        movement("message",300,400,100);movement("message",100,200,100); 
        movement = function (eleid, fx, fy, interval){
            let ele = document.getElementById(eleid);
            if(!ele) return false;
            if(ele.move) clearTimeout(ele.move);

            let px = parseInt(ele.style.left);
            let py = parseInt( ele.style.top);

            if(fx == px && fy ==py) return true;
            console.log(px +","+ py);
            if(fx>px) px++;
            if(fx<px) px--;
            if(fy>py) py++;
            if(fy<py) py--; 
            ele.style.left = px + "px";
            ele.style.top = py + "px";

            let repeat = "movement('"+eleid+"',"+fx+","+fy+","+interval+")";console.log(repeat);
            let ele.move = setTimeout(repeat,interval); 
        }
CSS overflow 处理元素尺寸超过容器尺寸的情况
    1. visible 不裁剪溢出的图片
    2. hidden 隐藏溢出的内容,只显示指定大小的图片
    3. scroll 类似于hidden,但会显示一个滚动条
    4. auto 类似于scroll,但只有内容溢出时才会显示滚动条


##chapter11 HTML5
HTML5: 网页三层的一个集合,提供了升级的技术并且向后兼容.
使用: 文档声明类型改为**<!DOCTYPE html>**
[HTML5 技术](https://www.w3.org/TR/html/) ([中文](http://www.w3school.com.cn/html5/html_5_app_cache.asp))
    1. 结构层 HTML : section,article,header,footer；canvas,audio,video
    2. 样式层 CSS : 高级选择器,渐变,变换和动画
    3. 行为层 DOM + javascrit API : 新元素有新的API；自定义video以改变其播放方式,form元素支持进度控制
                        canvas元素可以绘制图形,添加图片及其他对象
    4. 新模块 : Geolocation,Storage,Drap-and-Drop,Socket and web worker
canvas 图片交互功能, JavaScript作为画笔的画布
video & audio 
不同的浏览器和视频解码算法是主要的阻碍,使用时注意向后兼容
  <video id="video1" width="420" style="margin-top:15px;">
    <source src="/example/html5/mov_bbb.mp4" />
    <source src="/example/html5/mov_bbb.mp4" type="video/mp4" />
    <source src="/example/html5/mov_bbb.ogg" type="video/ogg" />
    Your browser does not support HTML5 video.
  </video>
form
为了应对不兼容的浏览器使用特性检测准备另一个方案
Features
    [webstorage](https://html.spec.whatwg.org/multipage/webstorage.html)
    [websocket](https://html.spec.whatwg.org/multipage/web-sockets.html#network)
    [web workers](https://html.spec.whatwg.org/multipage/workers.html#workers)
    [drag and drop](https://html.spec.whatwg.org/multipage/dnd.html#dnd)
    [HTML Living Standard](https://html.spec.whatwg.org/)
    [W3C HTML5 Eorking Draft](https://html.spec.whatwg.org/multipage/dnd.html#dnd)
    [Demos](https://developers.google.com/web/)

##chapter12 example


