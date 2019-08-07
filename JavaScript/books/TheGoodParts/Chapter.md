# JavaScript: The Good Parts
JacaScript精粹(小结)

## 1. Good Parts
JavaScript 是面向浏览器的语言,运行的环境是浏览器;操作的对象是HTML DOM(Document object type)的节点. 
### Good Parts：
#### 函数
    基于词法作用域的顶级对象,第一个成为主流的lambda语言.披着C外衣的Lisp
    词法作用域的函数中遇到既不是形参也不是函数内部定义的局部变量的变量时,去函数定义时的环境中查询.
    动态域的函数中遇到既不是形参也不是函数内部定义的局部变量的变量时,到函数调用时的环境中查.
#### 弱类型和动态对象
    编译器不能检测出类型错误,但也无须建立复杂的类层次
    弱类型语言：可以绕过类型系统
    动态类型：在程序运行时会将值分类,每种类型有对应的限制,有冲突时,在运行时报出动态类型错误
        静态类型有自己的类型系统,在运行前的编译阶段(通过解释器或编译器)进行校验
#### 对象字面量表示法 expressive object literal notation
    通过列出对象的组成部分,他们就能被创建出来.JSON的灵感
#### 原型继承
    无类别的对象系统, 对象直接从其他对象继承
### 坏的想法
#### 全局变量的编程模型
    依赖全局变量进行连接.所有编译单元的所有顶级变量及河道一个公共命名空间-全局对象
    全局变量：所有作用域中都可见的变量,这也意味着全局变量可以在任意时间被程序的任意部分改变.而且全局变量与子程序中变量名称互相冲突会导致程序无法运行.
        定义全局变量的3种方式：
            1, 函数外部的var语句：　var foo = value;
            2, web浏览器中,全局对象名为window： window.foo = value;
            3, 隐式的全局变量, 未经声明的变量: foo = value;

JSLint：编程工具,分析JavaScript并报告包含的缺点


## 2. Grammer 语法
### 1,WhiteSpace 空白
用来分隔字符序列
注释的形式： // , /* */
### 2,Names 标志符 
以字符开头,后面加字符/数字/_,不能使用保留字
[letter][letter|digit|_]* - reserves letter
### 3,Numbers 数字
只有一个单一的数字类型,内部表示为64位浮点数
没有整数类型：1和1.0是一致的
NaN是一个数值,表示不能产生正常结果的运算结果,NaN不等于任何值,可以用isNaN检测
Infinity表示大于1.7976e+308的值
Math是一套javscript作用于数字的方法：Math.floor(8.7)=8
### 4,Strings 字符串
字符串被单引号或双引号包围,可包含0或多个字符.所有字符都是16位的,因为Unicode是16位的
没有Char类型,'c' = "c"
字符串一旦创建就不能改变,但可以通过'+'连接得到一个新的字符串: 'i'+"s"==='is'
### 5,Statements 语句
一个编译单元包含一组可执行的语句,每个script标签提供一个已编译且立即执行的编译单元.
因为缺少链接器,JavaScript将所有代码抛入一个公共的全局命名空间中
代码块：JavaScript中的代码块不会创建新的作用域,因此变量应该定义在函数的顶端
var用在函数内部时定义的变量是函数的私有变量,作用域为函数内部.
语句执行顺序,默认是顺序的
    条件语句： if 和 switch
    循环语句： while,for,do
    强制跳转语句： break, return, throw
    函数
    if()then {} else {}
    为假的值：false,null,undefined,空字符串'',数字0,数字NaN.字符串'false'也被当作真
    
    if (typeof varSample != undefined) then { ... }
    switch (){ case: ...; break; ... default: ...; }
    while () {}
    do {}while()
    for(initialization;condition;increment) condition如果被省略则返回真
    for(myvar in obj){if (obj.hasOwnProperty(myvar){...})} 枚举对象的所有属性名(键名)
    try{ }catch(){ }
    return 使一个函数提前返回,可以指定返回的值.如果没有指定,返回值是undefined
        不允许在return和表达式之间换行
    break 退出循环语句或switch语句.可以指定标签
    continue 退出当前循环语句,进入下一次循环
        cars=["BMW","Volvo","Saab","Ford"];
        list:
        {
            document.write(cars[0] + "<br>");
            document.write(cars[1] + "<br>");
            document.write(cars[2] + "<br>");
            break list;
            document.write(cars[3] + "<br>");
        }
### 6,Expressions 表达式
    包括： 字面量值(字符串或数字),变量,内置的值(true,false,null,undefined,NaN和Infinity)
            new和delete前导的表达式,函数调用,三目运算符
    运算符优先级： 操作符在没有圆括号的情况下决定其执行优先级的属性
        属性存取及函数调用 . [] () 
        一元运算符 delete new typeof + - ! 
        乘除,取模,加减 
        不等式运算符,等式运算符
        与,或,三元 && || ?：
### 7,Literals 字面量  
    字面量：直接量,用简单的字面值标记指向数字,字符串,数组,对象,函数等
    对象字面量：字面量名不是变量名,所以对象的属性在编译时才能知道.属性的值就是表达式
        
        var test = 'hello'; 
        test "hello";
        var testarr = ["arr1","arr2"];
        testarr[1] "arr2"
        var testobject = { o1: 'this is o1',fun: function () { return 'return form function'; } };
        testobject.fun  ƒ(){ return 'return form function'; };
        testobject.fun() "return form function"
### 8, Functions 函数
    函数字面量定义了函数值：函数名字,参数列表,函数主体(变量定义,语句)     


## 3 Objects 对象  
JavaScript的简单类型：数字,字符串,布尔(true/false),null,undefined和对象(数组也是对象).
对象是
    1. 可变的键控集合
    2. 是属性的容器,每个属性都拥有名字和值.名字可以是包含空字符串的任意字符串.只可以为除undefined的任意值
    3. 无类别的,对新属性的名字和值没有约束.适用于收集和管理数据.对象可以包含其他对象.
    4. 原型链特性,允许对象继承另一对象的属性
### 1,Object Literals 对象字面量
对象字面量是一种非常方便的创建新对象的表示法,本质上是一对包围在一对花括号中零或多个键/值对.
作用域等同于表达式
    
    var student = {
        "first-name": 'song',
        first_name : 'song2',
        "last-name": "ben",
        "age": 28,
        company：{
            name：'ge',
            strong：'y'
        }
    };
### 2,research 检索
检索不存在的成员元素得到undefined
|| 用来填充默认值
student['first-name'];
'name is '||student.company.name;
检索undefined值导致TyoeError异常,用&&来避免错误
student['undefined']//undefined
student['undefined']&& student['undefined'].anything//undefined
### 3, updates 更新
student['first-name']='first-name';
若属性名不存在则会被扩充到对象中
student['undefined']= 'nowdefined';//nowdefined
### 4,reference 引用
对象通过引用传递,他们永远不会被拷贝
JavaScript按值传递,但当一个变量指向对象时,变量的值是这个指向对象的的地址
改变变量的值不会改变原始的基础类型或是object的值,只是将变量指向一个新的基础类型或是object
但是当变量指向对象的属性,改变变量值,就会改变对象的值
    
    function f(a,b,c) {
        //基础类型按值传递,不会影响原始值,所以x还是4
        a = 3;
        //数组也是object,传进来的是原始值的地址,所以原始值也改变
        b.push("foo");
        // c指向z, 同数组,c是对象所以会直接改变传入的实参的值
        c.first = false;
    }

    var x = 4;
    var y = ["eeny","miny","mo"];
    var z = {first: true};
    f(x,y,z);
    console.log(x,y,z.first); // 4,["eeny","miny","mo","foo"],false

    var a = ["1","2",{foo:"bar"}];
    var b = a[1]; // 按值传递, b是"2";
    var c = a[2]; // c是{foo:"bar"}
    a[1] = "4";   // a is now ["1","4",{foo:"bar"}]; b仍是被声明时的值 2
    a[2] = "5";   // a is now ["1","4","5"];  
    console.log(b,c.foo); // "2" "bar"
    b=13;
    console.log(a); //["1","4","5"]


## 4 Functions 函数  
JavaScript的函数包含一组语句,是基础模块单元,用于代码复用&信息隐藏&组合调用.
函数指定对象的行为.一般性的,编程就是将需求分解成一组函数与数据结构的技能.
### 1,Function Objects 函数对象
JavaScript中函数就是对象.对象=名/值对集合+连接到原型对象的隐藏连接
函数对象连接到Function.prototype(该原型本身连接到Object.prototype).
函数对象创建时会设置一个'调用'属性,调用函数可以理解为调用此函数的'调用'属性
函数对象也有一个prototype属性,其值是拥有constructor属性的对象,该对象的值就是该函数.不同于Function.prototype
函数是对象,所以也可以被存放在变量,对象和数组中.函数也可以作为参数,可以返回函数,还可以拥有方法!与众不同之处是可以被调用
### 2, FunctionLiteral 函数字面量 
组成包括四个部分：保留字 function,函数名 可被省略,参数 逗号分隔,语句 包围在花括号中 是函数的主题
var add = function (a,b) { return a + b;};
通过函数字面量创建的函数对象包含一个连到外部上下文的连接,这被称为闭包
### 3, Invocation 调用
调用一个函数将暂停当前函数的执行,传递控制权和参数给新函数.
实参与形参不一致不会导致运行时错误,多的被忽略,少的补为undefined
每个方法都会收到两个附加参数：this和arguments.this的值取决于调用的模式,调用模式：方法,函数,构造器和apply调用模式
this被赋值发生在被调用的时刻.不同的调用模式可以用call方法实现
    
    var myObject = {
        value: 0,
        increment: function (inc) {
            this.value += typeof inc === 'number' ? inc : 1;
        }
    };
    myObject.double = function(){
        var helper = function(){
            console.log(this);// this Point to window
            }
        console.log(this);// this Point to object myObject    
        helper();
    }
    myObject.double();//myObject  Window 

### 3.1 The Method Invocation Pattern 方法调用模式 
方法：函数被保存为对象的属性.当方法被调用时,this被绑定到该对象
公共方法：通过this取得他们所属对象的上下文的方法
    
    myObject.increment();
    document.writeln(myObject.value);    // 1
底层实现： myObject.increment.call(myObject,0);
### 3.2 The Function Invocation Pattern 函数调用模式
当函数并非对象的属性时就被当作函数调用(有点废话..),this被绑定到全局对象(window)
ECMAScript5中新增strict mode, 在这种模式中,为了尽早的暴露出问题,方便调试.this被绑定为undefined
    
    var add = function (a,b) { return a + b;};
    var sum = add(3,4);// sum的值为7
底层实现：add.call(window,3,4)
        strict mode：add.call(undefined,3,4)
方法调用模式和函数调用模式的区别
    
    function hello(thing) {
    console.log(this + " says hello " + thing);
    }
    person = { name: "Brendan Eich" }
    person.hello = hello; 
    person.hello("world") // [object Object] says hello world 等价于 person.hello.call(person,“world”)
    hello("world") // "[object DOMWindow]world" 等价于 hello.call(window,“world”)
### 3.3 The Constructor Invocation Pattern
JavaScript是基于原型继承的语言,同时提供了一套基于类的语言的对象构建语法.
this指向new返回的对象
    
    var Quo = function (string) {
        this.status = string;
    }; 
    Quo.prototype.get_status = function (  ) {
        return this.status;
    };
    var myQuo = new Quo("this is new quo"); //new容易漏写,有更优替换
    myQuo.get_status(  );// this is new quo
### 3.4 The Apply Invocation Pattern
apply和call是JavaScript的内置参数,都是立刻将this绑定到函数,前者参数是数组,后者要一个个的传递
apply也是由call底层实现的
    
    apply(this,arguments[]);
    call(this,arg1,arg2...);
    var person = {  
    name: "James Smith",
    hello: function(thing,thing2) {
        console.log(this.name + " says hello " + thing + thing2);
    }
    }
    person.hello.call({ name: "Jim Smith" },"world","!"); // output: "Jim Smith says hello world!"
    var args = ["world","!"];
    person.hello.apply({ name: "Jim Smith" },args); // output: "Jim Smith says hello world!"
相对的bind函数将绑定this到函数和调用函数分离开来,使得函数可以在一个特定的上下文中调用,尤其是事件
bind的apply实现
    
    Function.prototype.bind = function(ctx){
        var fn = this; //fn是绑定的function
        return function(){
            fn.apply(ctx, arguments);
        };
    };
bind用于事件中
    
    function MyObject(element) {
        this.elm = element;

        element.addEventListener('click', this.onClick.bind(this), false);
    };
//this对象指向的是MyObject的实例
    
    MyObject.prototype.onClick = function(e) { 
        var t=this;  //do something with [t]... 
    };
### 4 Arguments 参数
函数被调用时会附加一个参数arguments,通过它可以访问函数被调用时传递的参数列表,包括多余的参数.
arguments并不是真正的数组,是类似数组的对象.有length属性,但没有所有的数组方法
    
    var sum = function() {
        let i,sum =0;
        for(i=0;i<arguments.length;i++){
        sum += arguments[i];	
    }
    return sum;
    } 
    document.writeln(sum(1,23,4,2,3,4,2,3,4543))//4585
### 5 Return 返回
函数被调用时,从第一个语句开始执行到}结束,将控制权交还给函数的调用部分.
return会立即交还给函数的调用部分
函数总会返回值,默认是undefined
以new方式调用的函数,若返回值不是对象,则返回this(新对象)
### 6 Exception 异常
throw语句中断函数的执行,抛出exception对象.该对象包含可识别异常类型的属性：name和message,及自定义属性
try代码块中抛出异常,则恐是全就跳转到catch从句
    
    var add = function(a,b){
        if(typeof a != 'number' ||typeof b != 'number')
            throw {
                name : 'TypeError',
                message: 'add needs number'
            }; 
            return a+b;
    }

    var tryit = function(){
        try{
            add('ss');
        }catch(e){
            document.writeln(e.name + ':' + e.message);
        }
    }
    tryit();//TypeError:add needs number
### 7 Augmenting Types给类型增加方法
JavaScript允许给基本类型增加方法.
for in语句在原型时表现很糟糕,可以用hasOwnProperty属性筛选出继承而来的属性
Function.prototype增加方法使得是对所有函数可用.通过给Function.prototype增加method方法,我们就不用键入prototype这个属性名
    
    Function.prototype.method = function (name, func){
        if(!this.prototype[name]){
            this.prototype[name] = func;
        }
    }
整数类型的取整函数
    
    Number.method('integer', function (  ) {
        return Math[this < 0 ? 'ceil' : 'floor'](this);
    });
    document.writeln((-10 / 3).integer(  ));  // −3 
字符串去掉空白
    
    String.method('trim',function(){
        return this.replace(/^\s+|\s+$/g,'');
    })
document.writeln("begin."+"   3space3   ".trim()+"end");//begin.3space3end
### 8 Recursion 递归
递归函数是直接或间接的调用自身的一种函数.递归,将一个问题分解为一组相似的子问题,每个子问题用一个寻常解去解决.
尾递归：如果函数返回自身递归调用的结果.那么调用的过程会被替换为循环,只是JS不支持尾递归优化.
汉诺塔的递归解法:理解递归两层之间的交接,以及递归终结的条件.
盘分为最大盘和非最大盘,
    
    var hanoi = function (disc, s, a, d) {
        if (disc > 0) {
            hanoi(disc - 1, s, d, a);//辅助位置作为目标位
            console.log('move disc' + disc + ' from ' + s + ' to ' + d + "\n");
            hanoi(disc - 1, a, s, d);//辅助位置作为起始位
        }
    }
    hanoi(3, 'a1','a2','a3')
    move disc1 from a1 to a3
    move disc2 from a1 to a2
    move disc1 from a3 to a2
    move disc3 from a1 to a3
    move disc1 from a2 to a1
    move disc2 from a2 to a3
    move disc1 from a1 to a3

递归函数可以非常高效的操作树形结构.
    
    var walkTheDOM = function walk(node,func){
        func(node);
        node = node.firstChild;
        while(node){
        walk(node,func);
        node = node.nextSibling;	
    }
    }; 
    var getElementsByAttribute = function(att, value){
    var results = [];
    walkTheDOM(document.body,function(node){
        var actual = node.nodeType === 1 && node.getAttribute(att);
        if(typeof actual === 'string' && (actual === value || typeof value !== 'string')){
            results.push(node);
        }
    });
    return results;
    }
### 9 Scope 作用域
作用域控制着变量与参数的可见性及生命周期.可以减少名称冲突,并提供自动内存管理.
JS实际上不支持作用域.
通过var声明变量,作用域是最近的方法块内,意味着定义在函数中的参数和变量在函数外部不可见,
但在函数内部任何位置定义的变量在此函数的任何地方都可见.Note：不用var声明的变量实际是一个全局变量.
ES6中增加let关键字,let声明的变量作用域是最近的封闭块,具有真正的块级作用域
let在strict模式(句首加'use strict';)下重复声明会报错
    
    var foo = function(){
        var a =3,b=5;
        var bar = function(){
            var b=7,c=11;
            a += b+c;
            console.log(a+','+b+','+c);//21,7,11
        }; 
    console.log(a+','+b);//3,5
    bar();
    console.log(a+','+b);//21,5
    } 

    let x = 1;
    if (x === 1) {
    let x = 2;
    console.log(x);// expected output: 2
    }
    console.log(x);// expected output: 1
### 10 Closure 闭包
[闭包](https://stackoverflow.com/questions/111102/how-do-JavaScript-closures-work)是函数和声明该函数的词法环境的组合 
#### 1
闭包是一种实现函数作为参数的方式,是一个表达式,用途有：访问变量(在变量的作用域内,多在外部函数中声明),被赋值给一个变量,
作为函数的实参被传递,作为函数结果被返回
或者说是一个栈帧,在函数开始是被分配到堆,当函数返回后仍然不会被释放.

	function sayHello(name) {
	  var text = 'Hello ' + name; // Local variable
	  var say = function() { console.log(text); }
	  say();
	}
	sayHello('Joe');//Hello Joe
#### 2
函数作为引用被返回

	function sayHello2(name) {
	  var text = 'Hello2 ' + name; // Local variable
	  return function() { console.log(text); }
	}
	sayHello2('Joe')();//Hello2 Joe 等价于 var say2 = sayHello2('Joe');say2();
#### 3
与C指针不同的是,JavaScript中函数引用变量不仅指向函数,还包括隐藏的指针指向闭包,一块儿分配在堆上的函数所处上下文环境的内存
C等其他语言中在函数返回后,因为栈帧被销毁,其局部变量就不再可访问.相对的,JavaScript中在函数中声明一个函数,即使调用的函数被返回,外部函数中的局部变量仍旧可用.
论证,sayHello2('Joe')();中的text是局部变量,匿名方法可以访问text,就是因为sayHello2()仍旧保存在一个闭包中.
所以神奇的地方在于,JavaScript中函数引用有一个对它的闭包的秘密引用,类似于委托是方法指针加上一个对对象的秘密引用.
本地变量不被复制,它们按引用保存.外部函数退出时,栈帧仍保存在内存中
	
	function sayHello3() {
	  // Local variable that ends up within closure
	  var num = 42;
	  var say = function() { console.log(num); }
	  num++;
	  return say;
	}
	var sayNumber = sayHello3();
	sayNumber(); // logs 43
#### 4
同一个闭包可以同时被多个函数所访问,setupSomeGlobals()中的局部变量可以同时被3个方法调用
但是,setupSomeGlobals一旦被重新调用,新的闭包就会被创建,堆上一块新的内存被分配.
	
	var gLogNumber, gIncreaseNumber, gSetNumber;
	function setupSomeGlobals() {
	  // Local variable that ends up within closure
	  var num = 42;
	  // Store some references to functions as global variables
	  gLogNumber = function() { console.log(num); }
	  gIncreaseNumber = function() { num++; }
	  gSetNumber = function(x) { num = x; }
	} 
	setupSomeGlobals();gIncreaseNumber();
	gLogNumber(); //43 
	gSetNumber(6);
	gLogNumber();//6 
	var oldLog = gLogNumber; setupSomeGlobals();
	gLogNumber(); //42 
	oldLog();//6
#### 5
JavaScript函数中var/let声明的函数作用域为整个函数内部,所以,闭包包含外部函数中所有的在其return之前的局部变量.
JavaScript的特性：variable hoisting： 变量提前化,变量会被挪到其作用域(函数,代码块...)的最开始位置

	function sayAlice() {
	    var say = function() { console.log(alice); } //anonymous function declared first
	    var alice = 'Hello Alice';     // Local variable that ends up within closure
	    return say;
	}
	sayAlice()();// logs "Hello Alice"
#### 6
返回共享一个闭包的函数数组
buildList返回的是根据list的个数生成的方法数组,共享一个闭包,也包括其局部变量i
当fnlist[j]()调用匿名函数(function(){console.log(item + '_' + i +'_'+ list[i])})时,都指向同一闭包
**此时var声明的索引变量i作用域是整个for循环体,因为for循环已经遍历完成,匿名函数对应的局部变量都变成了3**
**而let声明的变量k的作用域是匿名函数,不同的遍历阶段,匿名函数中的k值是不一致的**

	//var
	function buildList(list){
		var result = [];
		for(var i=0; i<list.length; i++){
			var item = 'item' + i;
			result.push(function(){console.log(item + '_' + i +'_'+ list[i])});
		}
		return result;
	}
	function testList() {
	    var fnlist = buildList([1,2,3]);
	    // Using j only to help prevent confusion -- could use i.
	    for (var j = 0; j < fnlist.length; j++) {
	        fnlist[j]();
	    }
	}
	testList() // 打印3次 item2_3_undefined
	//let
	function buildList(list){
		var result = [];
		for(let k=0; k<list.length; k++){
			let item = 'item' + k;
			result.push(function(){console.log(item + '_' + k +'_'+ list[k])});
		}
		return result;
	}
	testList(); //item0_0_1 \n item1_1_2 \n item2_2_3
#### 7
每次调用主函数都建立一个独立的闭包

	function newClosure(someNum,someRef){
		var num = someNum;
		var anArray = [1,2,3];
		var ref = someRef;
		return function(x){
			num += x;
			anArray.push(num);
			console.log('num:'+num+',anArray:'+anArray.toString()+",ref.someVar:"+ref.someVar);
		}
	}
	obj = {someVar:4}
	fn1 = newClosure(4,obj) 
	fn2 = newClosure(5,obj) 
	fn1(1) // num:5,anArray:1,2,3,5,ref.someVar:4 
	fn2(1) // num:6,anArray:1,2,3,6,ref.someVar:4
#### Note
1. 在function中使用另一个function,就会使用闭包.但是构造器函数New Function()不会使用闭包
2. 闭包可以视作一个函数的入口以及与此函数的相关的局部变量(函数退出时的局部变量的副本)的组合
3. 每次调用有闭包的函数,都会保留一组新的局部变量(如果函数包含一个内部函数,并且内部函数的引用被返回或以某种方式保留)
4. 因为隐秘的闭包,两个函数看起来可能有相同的源代码,但实际的作用完全不同
5. 闭包在处理速度和内存消耗方面对脚本有负面影响
6. 闭包可用来构建[JavaScript私有成员](http://www.crockford.com/JavaScript/private.html)
### 11 Callbacks 回调
回调让不连续事件的处理变得更容易.异步方法多采用回调函数
伪代码：用户交互,向服务器发送请求,最终显示服务器的响应.同步实现
request = prepare_teh_request();
response = send_request_synchronously(request);
display(response);
异步实现,display作为回调函数返回
request = prepare_the_request();
send_request_asynchronously(request, function(response){display(response)});//**不理解这里的response是如何得到的**
### 12 Module 模块
模块是提供接口却隐藏状态与实现的函数或对象.实现：函数+闭包,利用函数作用域和闭包来创建绑定对象与私有成员的关联.
通过函数产生模块,几乎可以替代全局变量的使用.

    Function.prototype.method = function (name, func){
        if(!this.prototype[name]){
            this.prototype[name] = func;
        }
    }
    String.method('deentityify',function(){
        var entity = {quot:'"', lt:'<', gt:'>'};
        return function(){
            //replace() 方法返回一个由替换值替换一些或所有匹配的模式后的新字符串.模式可以是一个字符串或者一个正则表达式, 
            //替换值可以是一个字符串或者一个每次匹配都要调用的函数.
            return this.replace(/&([^&;]+);/g, function(a,b){ //查找&开头和;结束的字符串
                return typeof entity[b] === 'string' ? entity[b] : a;
            });
        };
    }())
    '&lt;&quot;&gt;'.deentityify() // <">
//模块模式的一般形式是定义了私有变量和函数的函数;利用闭包创建可以访问变量和函数的特权函数;最后返回特权函数或保存到可访问的地方
//生产序列号的对象
   
    var serial_maker = function(){
        var prefix = '';
        var seq = 0;
        return {
            set_prefix: function(p){ prefix = String(p);},
            set_seq: function(s){seq=s;},
            gensym:function(){ return prefix + seq++;}
        };
    };
    var seqer = serial_maker();
    seqer.set_prefix('Q');seqer.set_seq(1000);
    seqer.gensym() //"Q1000"
    seqer.gensym() //"Q1001"
### 13 Cascade 级联
有些方法没有返回值(默认undefined),例如,设置或修改对象的某个状态却不返回值的方法.
若我们让这些方法返回this,就可以启用级联.级联可以产生出具备很强表现力的接口.
### 14 Curry 套用
函数也是值,所以我们可以去操作函数值.套用允许我们将函数与传递给它的参数相结合去产生一个新的函数
Function.prototype.method = function(name,func){if(!this.prototype[name]) this.prototype[name]=func;}//给方法类型增加method方法

    Function.method('curry', function(){
        var slice = Array.prototype.slice, args = slice.apply(arguments), that = this;//this arguments value is 1
        return function(){return that.apply(null,args.concat(slice.apply(arguments)));};//this arguments value is 5
    });  
    var add = function (a,b){return a+b} ;
    var add2 = add.curry(1);
    add2(5);//6
### 15 Memoization 记忆
函数可以用对象去记住向前操作的结果,从而避免无谓的运算,这种优化被称为记忆.Javascript中多用对象和数组实现这种优化

    var memoizer = function(memo,fundamental){
        var shell = function(n){
            var result = memo[n];//memo作为入参,在单次调用时保持一致
            if(typeof result !== 'number'){ //如果memo[n]未被缓存,result = undefined
                result = fundamental(shell,n); memo[n]=result; 
            } 
            return result;
        };
        return shell;
    }
    var fibonacci = memoizer([0,1],function(shell,n){return shell(n-1)+shell(n-2);});//fibonacci(0) = 0, fibonacci(1) = 1, so memo is [0,1]
    fibonacci(4);
    var factorial = memoizer([1,1],function(shell,n){return n*shell(n-1);})


## 5 Inheritance 继承 
继承提供两个重要作用,1,他是代码重用的一种形式;2,包括了一套类型系统的规范.
Javascript是弱类型语言(动态弱类型),不需要类型转换.对象的起源无关紧要,对对象来说,重要的是他能做什么.
Javascript是基于原型的语言,对象可直接从其他对象继承,这提供更为丰富的代码重用模式.可以模拟基于类的模式以及其他的模式.
### 1,Pseudoclassical 伪类
ECMAScript2015(ES6)中引入的JavaScript类实质是基于原型的继承的语法糖
类实际上是个特殊的函数,包括：类表达式和类声明.类的首字母大写
#### 1.1
类声明：class关键字.函数声明会提升但类声明不会,所以必须先声明类,然后才能访问它
    
    class Rectangle {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    }
类表达式：是定义类的另一种方式,主要包括命名和匿名
/* 匿名类 */ 
    
    let Rectangle = class {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    };
    /* 命名的类 */ 
    let Rectangle = class Rectangle {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    };
#### 1.2 类体和方法定义
类声明和类表达式的主体都执行在严格模式下.比如,构造函数,静态方法,原型方法,getter和setter都在严格模式下执行
constructor方法是一个特殊的方法,其用于创建和初始化使用class创建的一个对象.一个类只能拥有一个名为 “constructor”的特殊方法. 
一个构造函数可以使用 super 关键字来调用一个父类的构造函数.
    
    class Rectangle {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
        get area(){return this.calcArea()}
        calcArea(){return this.height * this.width}
    }
    //原型链：(10, 10) -→ Rectangle.prototype ----> Object.prototype ----> null
    const square = new Rectangle(10, 10);//如果不写new,就是一个普通函数,返回undefined
    console.log(square.area);//100
#### 1.3 属性私有,共享方法的对象
Class.prototype指向实例化的原型对象,Class.constructor指向Class函数自身
原型对象实例的__proto__可以查看Class函数
    
    'use strict';
    function Cat(name) {
        this.name = name;
    }
    Cat.prototype.say = function (){
        return 'Hello, '+this.name+'!';
    }   
    // 测试:
    var kitty = new Cat('Kitty');
    var doraemon = new Cat('哆啦A梦');
    if (kitty && kitty.name === 'Kitty' && kitty.say && typeof kitty.say === 'function' && kitty.say() === 'Hello, Kitty!' && kitty.say === doraemon.say) {
        console.log('测试通过!');
    } else {
        console.log('测试失败!');
    }
#### 1.4 原型继承
借助中间函数实现原型链继承,并在新的构造函数的原型上定义新方法
    
    function inherits(Child, Parent) {
        var F = function () {};
        F.prototype = Parent.prototype;
        Child.prototype = new F();
        Child.prototype.constructor = Child;
    }
    function Student(props) {
        this.name = props.name || 'Unnamed';
    }
    Student.prototype.hello = function () {
        console.log('Hello, ' + this.name + '!');
    }
    function PrimaryStudent(props) {
        Student.call(this, props);
        this.grade = props.grade || 1;
    }
    // 实现原型继承链:
    inherits(PrimaryStudent, Student);
    // 绑定其他方法到PrimaryStudent原型:
    PrimaryStudent.prototype.getGrade = function () {
        return this.grade;
    };
    s.__proto__ === PrimaryStudent.prototype;//true
    s.__proto__.__proto__ === Student.prototype;//true
    var t = new PrimaryStudent({name:'jack',grade:12})
    t.hello()//Hello, jack!
    t.getGrade()//12
    #### 1.5 class继承
    "use strict";
    class Polygon {
    constructor(height, width) {
        this.height = height;
        this.width = width;
    }
    }
    class Square extends Polygon {
    constructor(sideLength) {
        super(sideLength, sideLength);//Polygon.constructor(height, width)
    }
    get area() {
        return this.height * this.width;
    }
    set sideLength(newLength) {
        this.height = newLength;
        this.width = newLength;
    }
    toString (){
        console.log('this.height:'+this.height+'; this.width:'+this.width);
    }
    }
    var square = new Square(3);
    square.sideLength = 5
    square.toString()// this.height:5; this.width:5
#### 1.5 静态方法
static关键字定义类的静态方法,调用静态方法不需要实例化类,同时类实例不能调用静态方法
    
    class Point{
        constructor(x,y){this.x=x;this.y=y;}
        static distance(a,b){return Math.hypot(a.x-b.x,a.y-b.y); } 
    } 
    Point.distance(new Point(1,1),new Point(4,5));
#### 1.6 Object.create
ECMAScript 5 中引入了一个新方法：Object.create().可以调用这个方法来创建一个新对象
新对象的原型就是调用 create 方法时传入的第一个参数
    
    var a = {a: 1}; 
    // a ---> Object.prototype ---> null
    a.__proto__ === Object.prototype//true
    var b = Object.create(a);
    // b ---> a ---> Object.prototype ---> null
    console.log(b.a); // 1 (继承而来)
    b.__proto__.__proto__=== Object.prototype//true
    var c = Object.create(b);
    // c ---> b ---> a ---> Object.prototype ---> null
    var d = Object.create(null);
    // d ---> null
    console.log(d.hasOwnProperty); // undefined, 因为d没有继承Object.prototype
### 2 Object Specifiers 对象说明符
构造器参数很多时,通过指定实参的名称,可以实现乱序排列
形参新的特性：默认参数,剩余参数
剩余参数语法允许我们将一个不定数量的参数表示为一个数组.
    var func = function(a,b=a+1,c=2,...args){
            console.log('a:'+a+'; b:'+b+'; c:'+c+'; args.length:'+args.length);
    }
    func(1,...[234,12,34,3]) //a:1; b:234; c:12; args.length:2
### 3 Prototype 原型
原型模式中会摒弃类的概念,转而专注于对象,一个对象可以继承一个旧对象的属性.
通过Object.create实现差异化继承
    
    var Mammal = {
        name:"mammal",
        says: function(){ return this.name + this.saying || '';}
    }
    var cat = Object.create(Mammal) 
    cat.saying = 'meow' 
    cat.name = 'cat' 
    cat.says() //"catmeow"
### 4 Functional 函数化
通过模型模式实现属性私有.感觉有点过时
    
    var mamal = function(spec){
        var that = {};
        that.getNmae = function (){return spec.name;}
        that.says = function (){ return spec.saying || '';}
        return that;
    }

    var cat = mamal({name:'cat',saying:'miaow'})
    cat.says() // "miaow"
    var dog = mamal({name:'dog',saying:'wowang'})
    dog.getNmae()// "dog"
### 5 Parts 部件
通过从一套部件中组合出对象,代码复用的一种方式.
构造能添加简单事件处理特性到任何对象的函数,它包括on,fire,注册表对象
    
    var eventutilize = function (that) {
	var registry = {};
	that.fire = function (event){
		var array,func,handler,i,type = typeof event === 'string'?event:event.type;
		if(registry.hasOwnProperty(type)){
			array = registry[type];
			for(i=0;i<array.length;i++){
                handler = array[i];
                func = handler.method;
                if(typeof func === 'string')
                    func = this[func];
                func.apply(this,hanler.parameters || [event]);
            }
		}
        return this;
	}
    that.on =function(type,method,parameters){
        var handler = {
            method: method,
            parameters:parameters
        }
        if(registry.hasOwnProperty(type)){
            registry[type].push(handler)
        }else{
            registry[type] = [handler];
        }
        return this;
    }
    return that;
}
eventutilize(new Object())//{fire: ƒ, on: ƒ}    


## 6 Arrays 数组
数组是一段线性分配的内存,通过整数计算偏移去访问其中的元素.不过JavaScript中没有数组数据结构,
而是提供一种拥有数组特性的对象.JavaScript中数组的下标是字符串,比真正的数组结构慢,但也不再限制数组元素的数据类型,
同时提供了数组字面量格式.
### 1 Array Literals 数组字面量
数组字面量是在一对中括号中零个或多个用逗号分隔的值的表达式,属性名是固定的1,2,3...
继承自Array.prototype
对象字面量需要指定属性名,继承自Object.prototype
    
    numbers=[1,'12','asd',{'a':'asd','b':'bnm'}] 
    numbers[4] //undefined
    numbers[3] //{a: "asd", b: "bnm"}
    objects = {1:'asd','2':'2test','final':[1,2,3]}
    objects[2] //"2test"
    objects[3] //undefined
    objects['final'] //(3) [1, 2, 3]
### 2 Length 长度
数组都有length属性,JavaScript中的length没有上界,将自动增大来容纳新元素,不会发生边界错误
    
    numbers=[1,2] 
    numbers[numbers.length]=numbers.length ;
    numbers.push(numbers.length);//[1, 2, 2, 3]
### 3 Delete 删除
    
    delete numbers[2] //删除元素,但保留下标,相当于抠出元素
    numbers //(4) [1, 2, empty, 3]
    numbers.splice(2,1)//删除元素及标号,后面元素的标号重排
    numbers //(3) [1, 2, 3]
### 4 Enumeration 枚举
数组可以用[for in](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Statements/for...in)遍历,但是会乱序输出,一般用来遍历object
    for (var property1 in numbers) {
    console.log(numbers[property1]);
    }
for遍历
    for(let i =0;i<numbers.length;i++) console.log(numbers[i]);
ES6引入[for of](https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Statements/for...of), 类似于for
    for(let i of numbers) console.log(i);
### 5 Confusion 混淆
JavaScript本身对数组和对象的区别是混乱的,数组可以看作有内置方法的对象的子集
使用数组还是对象的规则：属性名是小而连续的整数时,应该使用数组,否则用对象.
区分数组与对象的方法

    var isArray = function(value){
        return value && typeof value === 'object' && typeof value.length === 'number' && typeof value.splice === 'function' && 
                !(value.propertyIsEnumerable('length'))
    }
### 6 Methods 方法
Array.prototype中有一套内置的方法,也可以自己扩充.
    
    Array.prototype.method = function(name, func){
        if(!this.prototype[name])
            this.prototype[name]=func;
    }
    Array.prototype.method('reduce',function(f,value){
        for(let i of this)
            value = f(i,value);
        return value;
    })
    var add = function(a,b){return a+b;} ;
    numbers.reduce(add,0);
### 7 Dimensions 维度
    
    JavaScript没有多维数组,但是像c语言一样,它支持元素为数组
    ƒ (m,n,initial){
        var a=[],matrix=[];
        for(let i=0;i<m;i++){
            for(let j=0;j<n;j++)
                a[j]=initial;
            
            matrix[i]=a;
            a=[];
        }
        return matrix;
    }
    var myMatrix = Array.matrix(5,2,9)  
    0:(2) [9, 9]
    1:(2) [9, 9]
    2:(2) [9, 9]
    3:(2) [9, 9]
    4:(2) [9, 9]

## 7 Regualr Expression 正则表达式
Javascript的许多特性借鉴自其他语言,语法出自Java,函数借鉴Scheme,原型继承出自Self,而正则表达式则借鉴自Perl
略过
## 8 Methods 方法
### Array
array.concat(a,b)
array.join('')
array.pop()
array.push(a)
array.reverse()
array.shift() 移除第一个元素
array.unshift() 添加元素到第一个元素
array.slice(1,2) 浅复制第2,3个元素
array.splice(1,2,'test') 移出第2,3个元素并替换成test
array.sort((
### Number
number.toExponential(20) 指数形式字符串
number.tofixed(20) to string
number.toprecision(20)
number.tostring()
### Function
function.apply(( apply调用模式
### Object
object.hasOwnProperty(name) 对象是否包含属性name,原型链中的同名属性不检查
### Regexp
regexp.exec(string( 强大但慢
regexp.test(( 简单但快
### String
string.charat(2(
string.charcodeat(( 整数形式的字符码
string.concat(( +
string.indexof('test',2( 
string.compare()
string.replace() 可以使用正则表达式
string.slice(-3( 浅复制新的字符串
string.split('',5(


## 9 Style 代码风格 
学习python


## 10 Beautiful Features 优美的特性
### 函数是头等对象
函数是有词法作用域的闭包
### 基于原型继承的动态对象
对象是无类别的
可以通过普通的赋值给任何对象增加一个新成员元素
一个对象可以下哦那个另一个对象继承成员元素
### 对象字面量和数组字面量
字面量是json的灵感之源
### Note
保留字策略
块级作用域
特性有规定成本,设计成本和开发成本,文档成本.


## A Awful Part
### 1 global variable 全局变量
全局变量就是所有作用域中都可见的变量.因为全局变量可以被程序的任意位置任意时间改变,降低了程序的可靠性和维护性.
运行独立子程序变得更难,子程序的变量名可能与全局变量相同,导致冲突.
JavaScript的问题在于不仅允许全局变量,还要求使用它们.Java中的public static成员元素就是全局变量,不能被修改
### 2 Scope
没有块级作用域,代码块中的变量在函数的任意位置都可见.
ES6引入了let代替var
### 3 Semicolon Insertion 句末自动插入分号
会出现return;
return 
{
    status: true
};
解决
return {
    status: true
};
### Reserved Words
### Unicode
Unicode视一对字符为一个单一的字符,而JavaScript认为那是两个不同的字符
### typeof
typeof null //object
检测null的方式：my_value === null
### parseInt
parseInt('16')// 16
parseInt('16 asdf')//16
### +
### Floating Point
0.1+0.2 reutrn 0.30000000000000004
### NaN
NaN是一个特殊的数量值,用来表示不是一个数字
typeof NaN === 'number'//true
### Phony Arrays 伪数组
JavaScript的数组实质是对象,容易使用且不会有越界错误,但性能很糟糕
### Falsy Values 假值
0,NaN,'', false,null,undefined
Note：undefined,NaN是全局变量,不是常量,我们可以改变它的值
### hasOwnProperty
是方法而非运算符,所以可能被其他的函数替换
### Object
JavaScript中的对象永远不会有真的空对象,因为可以从原型链中取得成员元素


## Bad Parts
### ==
== 会先进行类型转换后对比值
=== 类型一致且值相同
### eval
eval((传递一个字符串给JavaScript编译器并执行结果.使性能显著降低.
### continue
continue跳到循环的顶部,代码移除continue语句后,性能会改善
### switch的贯穿
case条件贯穿很难发现错误
### ++ --
容易造成溢出错误
### 位运算
JavaScript中只有双精度的浮点数,位运算现将数字运算数转换成整数,然后运算,最后转换回去
### new
JavaScript的new运算符创建一个继承其运算数的原词那个的新对象,然后调用此运算数,再将新创建的对象绑定给this.
运算数(构造函数(可以在返回给请求者前去自定义新创建的对象


## JSLint
[JSLint](https://www.jslint.com/)是JavaScript的辅助程序,通过扫描文件来查找问题


## Json
### grammer
类型：对象,数组,字符串,数字,bool和null
空白可被插到任何值的前后,也可省略
对象是容纳'键/值'对的无序集合,值可以为任何类型,可以无限层的嵌套
数组是一个值的有序序列
字符串要被包围在双引号之间.\用于转义
数字的首字符不能为0,区别于其他语言的八进制
### json的解析器