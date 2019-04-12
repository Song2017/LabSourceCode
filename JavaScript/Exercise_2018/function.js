'use strict';

// alert("this is function.js");
console.log("now this is function.js !!!");
//define
function abs(x) {
    if (x >= 0)
        return x;
    else
        return -x;
}

console.log(abs(-5));
console.log(abs());

//arguments 作用域是函数内部，永远指向当前函数调用者传入的所有参数
function foo(x) {
    console.log(x);
    console.log(JSON.stringify(arguments))
}

foo(10, 2, 30);

//...rest只能位于参数最后，会收到一个数组，并取得所有未显式接收的参数
//return和返回的语句必须在同一行，JavaScript引擎会在行末自动添加分号
function sum(a, b, ...rest) {
    console.log(rest);
    var sum = 0;//需要付初值
    for (var temp of rest)
        sum += temp;
    sum = sum + a + b;
    return sum;
}

console.log(sum(1, 2.3, 1, 2, 31, 23));

//var 声明的变量有作用域， 'use strict';用来限制变量必须用var声明
//JavaScript会扫描所有函数体语句，把所有变量的声明提升到函数顶部，但是变量赋值位置不会变化
function foo() {
    var sum = 1; //名称一致但是作用域不同，不会出错
    var name;
    var x = "hello " + name;
    console.log(x);
    name = 'Jack';
}
window.foo();

//window: JavaScript默认的全局对象，全局作用域的变量实际上绑定为window的一个属性
var course = 'Learn JavaScript';
console.log(window.course);
var _alert = window.alert;
window.alert = function () { }
alert('now is invalid');
window.alert = _alert;//
// alert('now is valid');


//名字空间
var MYAPP = {};
MYAPP.name = 'myapp';
MYAPP.version = 1.0;
MYAPP.foo = function () {
    return 'MYAPP.foo';
}

//局部作用域
//for无法定义有局部作用域的变量，但let可以声明会计作用域的变量
function foo() {
    var x = 1;
    if (true) {
        var x = 2; console.log(x);
    }
    console.log(x);
}
function foo() {
    var x = 1;
    if (true) {
        let x = 2; console.log(x);
    }
    console.log(x);
}

//常量 大写 const
const PI = 3.14;
//MYPI = 3.1415926; //error
//PI = 3;//error
// MYPI = 3;//error
const CONARY = [];
CONARY.push('A');
console.log(CONARY[0]);
CONARY[0] = 'C';
console.log(CONARY[0]);
// CONARY = 'D';//error

//解构赋值
var employee = {
    name: "Jim",
    age: 90,
    gender: 'man',
    school: {
        city: 'tsing',
        school_name: 'school_name',
    }
};
var { name, gender, other = 'others', school: { school_name } } = employee;
//school 不是变量，只是为了构造合适的结构
console.log(name + ", " + gender + ", " + other + ", " + school_name);

//方法
//this在函数内部时，以对象的方法形式调用时指向被调用的对象；但单独调用时指向全局变量，window
//解决，var that=this; 必须用object.fun()形式调用；fun.apply(object,[paras]);
function getAge() {
    var y = new Date().getFullYear();
    return y - this.birth;
}
var Jim = {
    name: 'Jim',
    birth: 1990,
    age: getAge
}
console.log(getAge.apply(Jim, []));
console.log(Jim.age());
// console.log(getAge()); //Uncaught TypeError strict模式下让函数的this指向undefined
var Jack = {
    name: 'Jack',
    birth: 1990,
    age: function () {
        var that = this;
        function getBirth() {
            var y = new Date().getFullYear();
            return y - that.birth;
        }
        return getBirth();
    }
}
console.log('var that = this; ' + Jack.age());

//decorator
var count = 0;
var oldParseInt = parseInt;
window.praseInt = function () {
    count += 1;
    return oldParseInt.apply(null, arguments);
};
praseInt(10);
praseInt('20');
praseInt('20');
console.log(count);//3

// test for interview
// var x =10;
// function test(){
//      console.log(a);
//      console.log(aa());
//      var a =1 ;
//      function aa(){
//          return 4;
//      }
// }
// test();// undefined 4

// Higher-order function 高阶函数
// define: javascript的函数都指向某个变量，接受另一个函数作为参数的函数就是高阶函数
function add(x, y, f) {
    return f(x) + f(y);
}
console.log(add(-5, 6, Math.abs));//11
//map(function)并发的对作用域集合的每个元素进行相同的function处理，最终得到一个集合
var arr = [1, 2, 3, 4, 56, 7];
function pow(x) {
    return x * x;
}
var results = arr.map(pow);
console.log(results);//(6) [1, 4, 9, 16, 3136, 49]
//reduce
//[x,y,z].reduce(f)= f(f(x,y),z)
var arr = ['1', '2', '3'];
console.log(arr.map(x => praseInt(x)).reduce(function (x, y) {
    return x * 10 + y;
}));//123
//filter
//去掉重复值
var arr = ['apple', 'banana', 'orange', 'apple', 'pear', 'pear'];
var r = arr.filter(function (ele, index, self) {
    console.log(ele);
    console.log(index);
    console.log(self);
    //Returns the index of the last occurrence of a specified value in an array.
    return self.indexOf(ele) === index;
})
console.log(r);
//sort array => string array => sort
var arr = [1, 4, 3, 6, 2, 44];
console.log(arr.sort());
console.log(arr.sort(function (x, y) {
    if (x > y)
        return 1;
    if (x < y)
        return -1;
    return 0;
}));


//闭包 就是携带状态的函数，并且状态可以对外完全隐藏起来
//把函数作为结果值返回，返回函数不要引用任何循环变量
function funccount() {
    var arr = [];
    for (var i = 1; i <= 3; i++) {
        arr.push(function () {
            return i * i;
        });
    }
    return arr;
}
var results = funccount();
console.log(results[0]);//return i * i;
var f1 = results[0];
console.log(f1());//16
var f2 = results[1];
console.log(f2());//16
var f3 = results[2];
console.log(f3());//16

//引用循环变量 再创建一个函数，用函数的参数绑定当前循环变量的值
function funccount22() {
    var arr = [];
    for (var i = 1; i <= 3; i++) {
        arr.push((function (n) {
            return function () { return n * n; }
        })(i));
    }
    return arr;
}
var results2 = funccount22();
var f21 = results2[0];
console.log(f21());//1
var f22 = results2[1];
console.log(f22());//4
var f23 = results2[2];
console.log(f23()); //9

//箭头函数 类似于lambda
//var fn = x => x * x;
var arr = [1, 2, 11, 1, 0, 18, 12];
arr.sort((x, y) => {
    if (x > y)
        return 1;
    if (x < y)
        return -1;
    return 0;
});
console.log(arr);

//generator  function*
//可以用yield返回多次
function* foo(x) {
    yield x + 1;
    yield x + 2;
    return x + 3;
}

var r = foo(1);
for (var x of r)
    console.log(x);
 