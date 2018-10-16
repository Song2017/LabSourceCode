## DOM(Document of Model)
文档对象类型用树形结构完整的呈现了html文档,包括元素之间的关系和组成元素的内容及属性

### 浏览器如何处理html文档: how browser handle html document
    received html: server respoend with html no matter what it received.
    html tags are converted to tokens
    tokens are converted to nodes:令牌被转换成树节点
    nodes are converted to the Dom 


### 按id返回页面单一元素
#### document.getElementById('footer')
    Dom中id是唯一的,所以个通过id值返回一个唯一的对象.
    id字符串区分大小写
    返回查找元素的所有子节点


### 一次返回多个元素
#### document.getElementByClassName('classname');
返回所有包含此classname的htmlCollection
document.getElementsByClassName('line-numbers language-html')
多个classname以空格符分隔
rootElement.getElementsByClassName('classname');
可以被任何的根元素调用

#### document.getElementsByTagName('tagname');
返回所有指定标签名tag的htmlCollection,
只有后代元素会被搜索
标签名应使用小写
document.getElementById("toc").getElementsByTagName("*")
可以被任何根元素调用,* 返回所有元素


### Nodes,Elements and Interfaces
[Node](https://developer.mozilla.org/en-US/docs/Web/API/Node)是类,继承自EventTarget,是树结构的中间节点,包含实例node的所有属性和方法
[Element]()是类,继承自Node,是树结构的根节点,同样是Node,但是element实例具有具体属性和方法
JavaScript Interface主要指[Web APIs](https://developer.mozilla.org/en-US/docs/Web/API)
!##### Note: $0 默认指代页面上选中的元素

### more way to access element 
#### .querySelector() - returns a single element
// find and return the element with an ID of "header"
document.querySelector('#header');
// find and return the first element with the class "header"
document.querySelector('.header');
// find and return the first <header> element
document.querySelector('header');

#### .querySelectorAll() - returns a list of elements
// find and return the element with an ID of "header"
document.querySelector('#header');
// find and return a list of elements with the class "header"
document.querySelectorAll('.header');

const allHeaders = document.querySelectorAll('header');
for(let i = 0; i < allHeaders; i++){
    console.dir(allHeaders[i]);
}




## JavaScrip创建内容:增,删,改DOM节点

### 更新已存在的页面内容
####　innerhtml 返回子节点的html code
.innerhtml:
返回当前选中元素所有子元素的html内容,返回值是string
设置元素的html内容
.outerhtml:
返回当前选中元素,及其所有子元素的html内容
<h1 id="pick-me">Greetings To <span>All</span>!</h1>
const innerResults = document.querySelector('#pick-me').innerHTML;
console.log(innerResults); // logs the string: "Greetings To <span>All</span>!"
const outerResults = document.querySelector('#pick-me').outerHTML;
console.log(outerResults); // logs the string: "<h1 id="pick-me">Greetings To <span>All</span>!</h1>"

#### textContent 返回节点所有未经css修饰的文本内容
.textContent
返回当前选中元素及其子元素的文本内容,返回值是string或null
设置文本内容,html标签作为文本被显示
myElement.textContent = 'The <strong>Greatest</strong> Ice Cream Flavors'; // doesn't work as expected
myElement.innerHTML = 'The <strong>Greatest</strong> Ice Cream Flavors';  // works as expected
#### innerText 返回页面呈现的文本内容
.innerText
返回页面显示的文本内容,行内css和html标签不会显示
设置元素的显示文本内容,其中的css样式和html标签不会进行渲染,会被显示出来

### 新增页面内容 add new page content
#### createElement 
根据html标签创建元素,调用对象是document,所以并不会添加新创建的元素到页面(DOM)中
// creates and returns a <span> element
var newspan = document.createElement('span');
newspan.innerhtml = '<em> this is a new span string </em>';
#### appendChild
发起调用的必须是一个具体的元素,新的元素将被追加到调用元素的最后一个子元素
h1element=document.querySelector('h1');
h1element.appendChild(newspan);
##### Note: 
1. 更新文本内容来说,与其新增元素并追加不如直接更新已有元素的textContent属性
2. 新建的元素只能被追加一次
    const mainHeading = document.querySelector('#main-heading');//123
    const otherHeading = document.querySelector('#other-heading');//456
    const excitedText = document.createElement('span');
    excitedText.textContent = '!!!';
    mainHeading.appendChild(excitedText);//123
    otherHeading.appendChild(excitedText);//456!!!
#### insertAdjacentHTML
element.insertAdjacentHTML(position, text);
解析text字符串为html或xml节点,然后插入到调用元素的指定位置
position的可视化示例:   <!-- beforebegin --><p><!-- afterbegin -->foo
                        <!-- beforeend --></p><!-- afterend -->
var h1element = document.querySelector('h1');
//"<h1 class="white mb-half" style="">Learn ARKit</h1>"
h1element.insertAdjacentHTML("afterbegin",'<div>asdfasd</div>');
//"<h1 class="white mb-half" style=""><div>asdfasd</div>Learn ARKit</h1>"

### 删除页面内容
#### removeChild
var oldChild = node.removeChild(child);
父元素node删除其子元素child
oldChild指向被删除的子元素child,child不再DOM中.
如果没有oldChild引用,则仍会存在内存中一段时间,最终会自动删除
#### remove
node.remove();
从node的父元素中删除node
等价于: node.parentElement.removeChild(node);

ParentNode.firstElementChild
返回父元素的第一个子元素
ParentNode.firstChild
如果有,则返回空白符或回车符

### 样式页面内容 style page content
#### .style.<prop> 一次只能修改一个css样式属性
document.querySelector('h1').style.color = 'red'

CSS优先级 CSS specificity
拥有最高级别的css属性将被应用,样式规则距离元素越近,级别就越高.
样式表中的样式<style> < 具体元素中的style
样式表中的优先级别:类型选择器(h1)和伪元素(h1:before) 
< 类选择器(.example),属性选择器(type=“radio”)和伪类(img:hover) < ID选择器(#example)
##### Note: !important修饰的样式拥有最最高级别,核武器慎用
#### .cssText() 一次可以更新多个样式属性
Note:csstext将会覆盖原有的样式属性
设置的字符串必须与样式表中的css样式一致
const mainHeading = document.querySelector('h1');
mainHeading.style.cssText = 'color: blue; background-color: orange; font-size: 3.5em';

#### .setAttribute() 一次可以设置多个样式属性
还可以设置非样式属性,例如 ID
document.querySelectorAll('h6')[4].setAttribute('id','index4ofh6');
//document.querySelectorAll('h6')[4].setAttribute('id','index4ofh6')
document.querySelector('#index4ofh6').setAttribute('style','color: red; font-size:2em;')
//document.querySelector('#index4ofh6').setAttribute('style','color: red; font-size:2em;')
#### .className
var cName = elementNodeReference.className;
获取指定元素的类的字符串
elementNodeReference.className = cName;
设置元素类,会覆盖掉原有的类的值
var listOfClasses = document.querySelector('#main-heading');// large white
操作数组:
const arrayOfClasses = listOfClasses.split(' ');//(2) ["large", "white"]
arrayOfClasses.push("white2"); //3
for(let i=0; i < arrayOfClasses.length; i++){ console.log(arrayOfClasses[i]);};//large white white2
arrayOfClasses.pop("white2"); //white2
#### .classList
const elementClasses = elementNodeReference.classList;
将元素的类的信息以DOMTokenList数据结构返回
DOMTokenList结构有自己的默认方法:
add( String [, String [, ...]] ), remove( String [, String [, ...]] ) 要删除的类不存在则报错
item( Number ), contains( String ), replace( oldClass, newClass )
toggle( String [, force] ) 如果类存在则删除,不存在则增加;若第二个参数存在,根据其bool值进行增删
document.querySelector('h6.text-center').classList
//DOMTokenList ["text-center", value: "text-center"]
document.querySelector('h6.text-center').classList.toggle('example')//true
//DOMTokenList(2) ["text-center", "example", value: "text-center example"]


## 浏览器事件 Working with browser events
DOM事件([Events](https://developer.mozilla.org/en-US/docs/Web/Events))被发送用于通知代码相关的事情已经发生了.
每个事件都是继承自Event 类的对象,可以包括自定义的成员属性及函数用于获取事件发生时相关的更多信息.
事件可以表示从基本用户交互到渲染模型中发生的事件的自动通知的所有内容.
### 查看事件
Chrome浏览器:monitorEvents(document)
monitorEvents(document); // start displaying all events on the document object
unmonitorEvents(document); // turn off the displaying of all events on the document object.

### 事件交互
[EventTarget](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget):被对象实现的接口,可以接收events和添加监听
EventTarget是顶级接口,document,Element,window等都是常见的EventTarget,都继承于此
EventTarget没有属性,只有三个方法
        .addEventListener()
        .removeEventListener()
        .dispatchEvent()
#### [Adding An Event Listener](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener)
<target>.addEventListener(<type>, <listener>)
document.querySelector(‘h1’).addEventListener(‘click’,function(){
    console.log('this is an h1 element is being clicked');
})
target: 事件的目标,浏览器中的任意元素: document, h1, class, id...
type:listen-for, user operate type, click, dbclick...
listener:function-to-run-when-an-event-happens, function(){}
[event lists](https://developer.mozilla.org/en-US/docs/Web/Events)

### 去掉事件的监听方法
#### [equality comparisons and sameness](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Equality_comparisons_and_sameness)
JavaScript如何比较两个对象是否相等
        ==  先强制转换成一致的类型 1==‘1’ //true
        === 不进行类型转换        1===‘1’ //false
    objects, arrays, and functions:
        var a = {myFunction: function quiz() { console.log('hi'); }};
        var b = {myFunction: function quiz() { console.log('hi'); }};
            a.myFunction === b.myFunction //false
        function quiz() { ... }
        var a = {myFunction: quiz};
        var b = {myFunction: quiz}；
            a.myFunction === b.myFunction //true
#### [remove an event listener](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/removeEventListener)
target.removeEventListener(type, listener[, options]);
要去掉添加在某个对象上的监听方法,需要使用添加时的方法,直接去掉方法的字面定义,不起作用
var clickfun = function () { console.log('this is a dblclick event');}；
document.addEventListener('dblclick', clickfun)；
document.removeEventListener('dblclick', clickfun)；

### Phases of an Events 事件的阶段
#### 事件的生命周期 [UI Events](https://www.w3.org/TR/uievents/)
定位阶段:事件对象通过节点传播到目标节点: window,父节点1,父节点2,... 目标节点
目标阶段:事件对象定位到目标节点上 
冒泡阶段:事件对象从目标节点反向传播到window.每个节点上的事件会被触发,可设置为不触发
#### 设置事件触发
.addEventListener()只有两个参数时,默认是在冒泡阶段触发
三个参数,且为true时,在定位阶段就会执行
document.addEventListener('click', function () {console.log('The document was clicked');}, true);
Test
document.addEventListener('click' , function(){console.log('doc');});
document.body.addEventListener('click' , function(){console.log('doc body');});
//单击界面:result:doc body/　doc
document.body.addEventListener('click' , function(){console.log('doc2');}, true);
//单击界面:result:doc2/ doc body/ 
#### 事件对象 [The Event Object](https://developer.mozilla.org/en-US/docs/Web/API/Event)
1. 每当单击,双击等事件发生,浏览器会自动包括一个事件对象,即标准的javascript对象,其中包含了大量事件自身的信息
在监听方法的参数位置添加: event,e,evt,theEvent,horse
document.addEventListener('click', function(event){console.log(event)});
2. bind(this)
var something = function (element) {	
    this.name = 'something';
    this.onclick1 = function (event){
    console.log(this.name);};
    this.onclick2 = function (event){
    console.log(this.name);};
    element.addEventListener('click' , this.onclick1, false);//undefined, this 指代传入的body
    element.addEventListener('click' , this.onclick2.bind(this), false);//something, this 指代新创建的s对象
}
var s = new Something(document.body);
3. preventDefault() 阻止对象的默认事件
例如checkbox默认选中的功能
document.querySelector("#id-checkbox").addEventListener("click", function(event) {
    document.getElementById("output-box").innerHTML += "Sorry! <code>preventDefault()</code> won't let you check this!<br>";
    event.preventDefault();
}, false);

### Avoid Too Many Events 避免过多的事件
#### 事件委托 [Event Delegation](https://javascript.info/event-delegation)
事件委托是一种委托给父节点处理子节点事件能力的方式
原因:父节点有多个子节点时,避免太多的子节点事件
实现:事件的3个阶段(冒泡阶段), 事件对象(参数)及.target属性
document.querySelector('#content').addEventListener('click', function (evt) {
    // convert nodeName to lowercase
    if (evt.target.nodeName.toLowerCase() === 'span') {
        console.log('A span was clicked with text ' + evt.target.textContent);
    }
});

### Know when the DOM is ready
Javascript中操作的元素需要已被加载到DOM中,否则会报错.
解决:1, 将javascript snippet 放到最后执行
    2, 调用事件 [DOMContentLoaded](https://developer.mozilla.org/en-US/docs/Web/Events/DOMContentLoaded)
    当初始的 HTML 文档被完全加载和解析完成之后,DOMContentLoaded 事件被触发,而无需等待样式表、图像和子框架的完成加载.
    load 应该仅用于检测一个完全加载的页面
        window.onload = function () {
            console.log('log: window.load');
        }
        document.addEventListener('load', new function(event){console.log('log: document.load');});  
        document.addEventListener('DOMContentLoaded ', 
        new function(event){console.log('log: document.DOMContentLoaded ');});  
        // log: document.load
        // log: document.DOMContentLoaded 
        // log: window.load 


## Performance 性能
### Add page content efficiently 高效的添加页面内容
#### Javascript衡量语句的执行时间,window.performance.now()
let t01 = performance.now();
for (let i = 1; i <= 100; i++) { 
  for (let j = 1; j <= 100; j++) {
    console.log('i and j are ', i, j);
  }
}
let t02 = performance.now();
console.log('this code took ' + (t02 - t01) +' milliseconds.');
#### [DocumentFragment](https://developer.mozilla.org/zh-CN/docs/Web/API/DocumentFragment)
DocumentFragment 接口表示一个没有父级文件的最小文档对象.
它被当做一个轻量版的 Document 使用,作为参数被添加(append)或被插入(inserted)的是片段的所有子节点, 而非片段本身.
因为所有的节点会被一次插入到文档中,而这个操作仅发生一个重渲染的操作
const fragment = document.createDocumentFragment();  // ← uses a DocumentFragment instead of a <div>
for (let i = 0; i < 200; i++) {
    const newElement = document.createElement('p');
    newElement.innerText = 'This is paragraph number ' + i;
    fragment.appendChild(newElement);
}
document.body.appendChild(fragment); // reflow and repaint here -- once!

### repaint & reflow 重绘和回流
重绘: 发生在改变元素外观及可见性,但是不会影响布局的情况下.例如:outline, visibility, background, or color
回流: 发生在影响页面布局(包括部分页面及整体页面)的情况下.例如:width, height, font-family, font-size.
    回流会导致元素所有子节点及相关上级节点的回流,其右节点也会回流
    避免回流: 使用类样式, 使用虚拟DOM,DomcumentFragment替换容器div
            避免多行内联样式,每一个样式都会引发一次回流,外部样式类只会引起一次
            使用固定或绝对位置的动画,引起重绘但不会发生回流
            避免table进行布局,其中的所有元素都会回流
            不在css中使用javascript表达式

### The call stack 回调栈
单线程: 一次处理一个指令,javascript是单线程的
调用堆栈:指令执行是顺序的.每当程序运行,方法栈中会入栈main()方法,它会一直保持运行.
每当有其他方法被调用,方法栈中会入栈对应的方法,方法执行完成后会对应的出栈

### The event loop 事件循环
同步:code在同一时间存在和发生,所在即执行
JavaScript event loop: javascript事件循环.
Javascript并发模型:run-to-completion:如果有代码块在运行,就一直运行完成为止
                   event loop:如果调用堆栈中没有调用方法了,就去追加事件队列中的任何事件处理.
                        选取事件队列队首的事件,运行它的处理代码,重复下一个事件

### setTimeout
.addEventListener()添加的code会在后面事件触发时执行
setTimeout()则可以指定具体延迟的时间
setTimeout(function sayHi() {console.log('Howdy');}, 0); //可以断开长语句,允许浏览器处理用户交互,不至于让用户长时间的等待
```
let count = 1
function generateParagraphs() {
    const fragment = document.createDocumentFragment();
    for (let i = 1; i <= 500; i++) {
        const newElement = document.createElement('p');
        newElement.textContent = 'This is paragraph number ' + count;
        count = count + 1;
        fragment.appendChild(newElement);
    }

    document.body.appendChild(fragment);
    if (count < 20000) {setTimeout(generateParagraphs, 0);}
}

generateParagraphs();
```