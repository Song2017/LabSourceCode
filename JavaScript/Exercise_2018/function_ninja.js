JavaScript Function
//[Function](https://johnresig.com/apps/learn/)

  //log info
console.log(Math);//show at Console in browser
assert(true, "message");
log(variable);//show value of var
assert( true, "I'll pass." );  //pass
assert( "truey", "So will I." );  //pass
assert( false, "I'll fail." );  //false
assert( null, "So will I." );  //false
log( "Just a simple log", "of", "values.", true ); //LOG Just a simple log of values. true
error( "I'm an error!" ); //error


//*** Defining Function
function isNimble() { return true; }
var canFly = function () { return true; };
window.isDeadly = function () { return true; };
log(isNimble, canFly, isDeadly);//LOG function isNimble(){ return true; } function (){ return true; } function (){ return true; }
//方法定义要在使用之前
assert( typeof canFly == "undefined", "canFly doesn't get that benefit." ); //PASS canFly doesn't get that benefit.
assert( typeof isDeadly == "undefined", "Nor does isDeadly." ); //PASS Nor does isDeadly.
var canFly = function () { return true; };
window.isDeadly = function () { return true; };
//方法定义在return之后
function stealthCheck() {
  log(stealth());
  return stealth();
  function stealth() { return "below return"; }
}
stealthCheck();


//*** Named Functions
//在方法内部调用同名方法，递归
function yell(n) {
  return n > 0 ? yell(n - 1) + "a" : "hiy";
}
log(yell(4)); //  "hiyaaaa"
//myNinja是内部方法名称，外部无效
var ninja = function myNinja() {
  assert(ninja == myNinja, "This function is named two things - at once!");
};
ninja();//PASS This function is named two things - at once!
assert(typeof myNinja == "undefined", "But myNinja isn't defined outside of the function.");//PASS But myNinja isn't defined outside of the function.
log(ninja);//LOG function myNinja(){ assert( ninja == myNinja, "This function is named two things - at once!" ); }
//对象属性声明为方法
var ninja = {
  yell: function (n) {
    return n > 0 ? ninja.yell(n - 1) + "a" : "hiy";
  }
};
log( ninja.yell(4)); // "hiyaaaa"
//方法引用时要给匿名方法一个名称，不然方法实际指向原方法，删除原方法会报错
var ninja = {
  yell: function yell(n) {
    return n > 0 ? yell(n - 1) + "a" : "hiy";
  }
};
log( ninja.yell(4)); // "hiyaaaa"
var samurai = { yell: ninja.yell };
var ninja = null;
log( samurai.yell(4));//"hiyaaaa"
//arguments.callee is the function itself
var ninja = {
  yell: function (n) {
    return n > 0 ? arguments.callee(n - 1) + "a" : "hiy";
  }
};
log( ninja.yell(4));//  "hiyaaaa"


//*** Functions as Objects
//Functions and Objects Both are objects, both have the property
var obj = {};
var fn = function () { };
obj.prop = "some value";
fn.prop = "some value";
assert( obj.prop == fn.prop, "Both are objects, both have the property." );//pass
//缓存方法结果
function isPrime(num) {
  var prime = num != 1; // Everything but 1 can be prime
  for (var i = 2; i < num; i++) {
    if (num % i == 0) {
      prime = false;
      break;
    }
  }
  isPrime.cache = prime;
  return prime;
}
isPrime.cache;
assert(isPrime(5), "Make sure the function works, 5 is prime.");
log(isPrime.cache);


//*** Context
//注意this代表的对象
function katana() {
  this.isSharp = true;
}
katana();
log(isSharp === true);// true "A global object now exists with that name and value." );
var shuriken = {
  toss: function () {
    this.isSharp = true;
  }
};
shuriken.toss();
log(shuriken.isSharp === true);// true "When it's an object property, the value is set within the object." );
//call/apply会指向具体的上下文，局部变量
var object = {};
function fn() {
  return this;
}
assert( fn() == this, "The context is the global object." );
assert( fn.call(object) == object, "The context is changed to a specific object." );
// call() takes any function arguments separately.
// apply() takes any function arguments as an array
Math.max(1, 2, 3);
Math.max.apply(null, [1, 2, 3]);
Math.max.call(null, 1, 2, 3);
//loop循环实现
function loop(array, fn) {
  for (var i = 0; i < array.length; i++)
    fn.call(array, array[i], i);
}
var num = 0;
loop([0, 1, 2], function (value, i) {
  assert(value == num++, "Make sure the contents are as we expect it.");
  assert(this instanceof Array, "The context should be the full array.");
});


//*** Instantiation
//new会创建object或是function，调用构造函数，this指向新创建的对象，返回新创建的object
function Ninja() {
  this.name = "Ninja";
}
var ninjaA = Ninja();
assert( !ninjaA, "Is undefined, not an instance of Ninja." );
var ninjaB = new Ninja();
assert( ninjaB.name == "Ninja", "Property exists on the ninja instance." );
//this指向新创建的对象
function Ninja() {
  this.swung = false;
  // Should return true
  this.swingSword = function () {
    this.swung = !this.swung;
    return this.swung;
  };
}
var ninja = new Ninja();
assert(ninja.swingSword(), "Calling the instance method.");
assert(ninja.swung, "The ninja has swung the sword.");
var ninjaB = new Ninja();
assert(!ninjaB.swung, "Make sure that the ninja has not swung his sword.");
//set name
function Ninja(name) {
  // Implement!
  this.changeName = function changeName(name2) {
    return this.name = name2;
  }
  return this.changeName(name);
}
var ninja = new Ninja("John");
assert(ninja.name == "John", "The name has been set on initialization");
ninja.changeName("Bob");
assert(ninja.name == "Bob", "The name was successfully changed.");
//function对new关键字的替换实现
function User(first, last) {
  if ( !(this instanceof arguments.callee) )
    return new User(first, last);

  this.name = first + " " + last;
}
var name = "Resig";
var user = User("John", name);
assert( user, "This was defined correctly, even if it was by mistake." );
assert( name == "Resig", "The right name was maintained." );


//*** Flexible Arguments
//arguments获取传入的所有参数，传入多个参数默认取首个
function  multiMax(multi) {
  // Make an array of all but the first argument 
  var  allButFirst  =  Array().slice.call( arguments,  1 );
  // Find the largest number in that array of arguments 
  var  largestAllButFirst  =  Math.max.apply( Math,  allButFirst );
  // Return the multiplied result 
  return  multi  *  largestAllButFirst;
}
assert( multiMax(3,  1,  2,  3)  ==  9,  "3*3=9 (First arg, by largest.)" );


//*** Closures 闭包作用域, 隐藏函数内部状态
var num = 10;
function addNum(myNum) {
  return num + myNum;
}
num = 15;
assert(addNum(5) == 20, "Add two numbers together, one from a closure.");
//used with event listeners
var count = 1;
var elem = document.createElement("li");
elem.innerHTML = "Click me!";
elem.onclick = function () {
  log( "Click #", count++ );
};
document.getElementById("results").appendChild( elem );
assert( elem.parentNode, "Clickable element appended." );
//variable value
var a = 5;
function runMe(a) {
  assert(a == 6, "Check the value of a.");
  function innerRun() {
    assert(b == 7, "Check the value of b.");
    assert(c == undefined, "Check the value of c.");
  }
  var b = 7;
  innerRun();
  var c = 8;
}
runMe(6);
for (var d = 0; d < 2; d++) {
  setTimeout(function () {
    assert(d == d, "Check the value of d.");
  }, 100);
}


//*** Temporary Scope
//
var myLib = (function () {
  function myLib() {
    // Initialize 
  }

  // ... 

  return myLib;
})();
var count = 0;
for (var i = 0; i < 4; i++) (function (a) {
  setTimeout(function () {
    assert(a == count++, "Check the value of i.");
    log(a);//0,1,2,3
  }, i * 200);
})(i);


//*** Function Prototypes
//构造函数重写原型方法
function Ninja() {
  this.swingSword = function () {
    return "true";
  };
}
// Should return false, but will be overridden
Ninja.prototype.swingSword = function () {
  return "false";
};
var ninja = new Ninja();
log(ninja.swingSword());//true
//原型方法会影响所有相同构造函数的对象
function Ninja() {
  this.swung = "this is swung";
}
var ninjaA = new Ninja();
var ninjaB = new Ninja();
Ninja.prototype.swingSword = function () {
  return this.swung;
};
log(ninjaA.swingSword());
//方法链必须返回this 
function Ninja() {
  this.swung = true;
}
var ninjaA = new Ninja();
Ninja.prototype.swing = function () {
  this.swung = false;
  return this;
};
log(ninjaA.swing().swung)//false


//*** Instance Type
function Ninja() { }
var ninja = new Ninja();
assert( typeof ninja == "object", "However the type of the instance is still an object." );
assert( ninja instanceof Ninja, "The object was instantiated properly." );
assert( ninja.constructor == Ninja, "The ninja object was created by the Ninja function." );
//constructor() 函数
var ninja = (function () {
  function Ninja() { }
  return new Ninja();
})();
// Make another instance of Ninja 
var ninjaB = new ninja.constructor();
assert( ninja.constructor == ninjaB.constructor, "The ninjas come from the same source." );


//*** Inheritance
//原型链继承
function Person() { }
Person.prototype.dance = function () { };
function Ninja() { }
// Achieve similar, but non-inheritable, results
Ninja.prototype = Person.prototype;
Ninja.prototype = { dance: Person.prototype.dance };
assert((new Ninja()) instanceof Person, "Will fail with bad prototype chain.");//fail
// Only this maintains the prototype chain
Ninja.prototype = new Person();
var ninja = new Ninja();
assert(ninja instanceof Ninja, "ninja receives functionality from the Ninja prototype");
assert(ninja instanceof Person, "... and the Person prototype");
assert(ninja instanceof Object, "... and the Object prototype");


//*** Built-in Prototypes
//foreach
if (!Array.prototype.forEach) {
  Array.prototype.forEach = function (fn) {
    for (var i = 0; i < this.length; i++)
      fn(this[i], i, this);
  };
}
["a", "b", "c"].forEach(function (value, index, array) {
  assert(value, "Is in position " + index + " out of " + (array.length - 1));
});
//keys
Object.prototype.keys = function () {
  var keys = [];
  for (var i in this)
    keys.push(i);
  return keys;
}
var obj = { a: 1, b: 2, c: 3 };
log(obj.keys());
delete Object.prototype.keys;


//*** Enforcing Function Context
//绑定方法到单击事件
var Button = {
  click: function () { this.clicked = true; }
}
var elem = document.createElement("li");
elem.innerHTML = "ClickMe";
elem.click = Button.click;
document.getElementById("results").appendChild(elem);//??
elem.onclick();
log(elem.clicked);//true
//all function allow context enforcement
Function.prototype.bind = function (object) {
  var fn = this;
  return function () {
    return fn.apply(object, arguments);
  };
};
elem.onclick = Button.click.bind(Button);
//.bind method from Prototype.js 
Function.prototype.bind = function () {
  var fn = this, args = Array.prototype.slice.call(arguments), object = args.shift();
  return function () {
    return fn.apply(object,
      args.concat(Array.prototype.slice.call(arguments)));
  };
};
elem.onclick = Button.click.bind(Button, false);

//***Bonus: Function Length
//方法签名的个数
function makeNinja(name) { }
function makeSamurai(name, rank) { }
log(makeNinja.length == 1);
log(makeSamurai.length == 2);
//overload
function addMethod(object, name, fn) {
  // Save a reference to the old method 
  var old = object[ name ];

  // Overwrite the method with our new one 
  object[ name ] = function () {
    // Check the number of incoming arguments, 
    // compared to our overloaded function 
    if ( fn.length == arguments.length )
      // If there was a match, run the function 
      return fn.apply( this, arguments );

    // Otherwise, fallback to the old method 
    else if ( typeof old === "function" )
      return old.apply( this, arguments );
  };
}



//*** appending
//call/apply
// call() takes any function arguments separately.
// apply() takes any function arguments as an array
Math.max(1, 2, 3);
Math.max.apply(null, [1, 2, 3]);
Math.max.call(null, 1, 2, 3);

//new
arguments.callee
function User(first, last) {
  if ( !(this instanceof arguments.callee) )
    return new User(first, last);

  this.name = first + " " + last;
}

//Flexible Arguments
arguments代替function的参数
function merge(root) {
  for (var i = 1; i < arguments.length; i++)
    for (var key in arguments[i])
      root[key] = arguments[i][key];
  return root;
}
var merged = merge({ name: "John" }, { city: "Bostonasd" });
assert(merged.name == "John", "The original name is intact.");
log(merged.city);

//slice 截取数组 
//splice(1,1,array2)
//var fruits = ["Banana", "Orange", "Apple", "Mango"];
//fruits.slice.call(fruits, 1);   //Orange,Apple,Mango
//Array().splice.call(fruits,2, 1, "Lemon", "Kiwi");  //Banana,Orange,Lemon,Kiwi,Mango
function multiMax(multi) {
  // Make an array of all but the first argument 
  var allButFirst = Array().slice.call( arguments, 1 );
  // Find the largest number in that array of arguments 
  var largestAllButFirst = Math.max.apply( Math, allButFirst );
  // Return the multiplied result 
  return multi * largestAllButFirst;
}
assert( multiMax(3, 1, 2, 3) == 9, "3*3=9 (First arg, by largest.)" );
