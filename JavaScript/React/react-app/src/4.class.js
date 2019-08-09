function Person(name, age) {
    this.name = name // 实例属性
    this.age = age
}
const p1 = new Person('wangwu', 18)
console.log(p1)
Person.info = 'person'
console.log(Person.info)
Person.prototype.say = function () {
    console.log('person say instance function')
}
console.log(p1.say())
Person.show = function () {
    console.log('person class show')
}
Person.show()
// 类class 语法
// 类内部不能使用 var, class只是语法糖, 本质仍然是function
class Animal {
    // 构造器, 默认有一个形参为空的构造器, 作用: new类的时候优先执行构造器中的代码
    // 实例属性: 通过new出来的实例访问
    // 静态属性: 通过构造函数直接访问, 类级别的属性
    // 实例方法: 本质是挂载到protptype
    // 静态方法: 挂载到构造函数上, 通过类调用的方法
    static info = 'animal show'
    static show() {
        console.log('animal class show')
    }
    constructor(name, age) {
        this.name = name// 实例属性
        this.age = age
    }
    say() {
        console.log('animal say instance function')
    }
}

const a1 = new Animal('lisi', 3)
console.log(a1)
console.log(Animal.info)
console.log(a1.say())
Animal.show()

// Class Extends 类继承
// 父类的属性和函数在子类的上一级原型链中
// 子类中的属性和函数, 构造器自定义后, 就重写了父类
class Human {
    constructor(name, age) {
        this.name = name
        this.age = age
    }
    sayHello() {
        console.log(this.name + " say Hello")
    }
}
class American extends Human {
}
const a = new American('a1', 11)
console.log(a)
console.log(a.sayHello())
class Chinese extends Human {
    constructor(name, age, IDNumber){
        // super: 语法规范, 子类使用extends父类后, 必须通过super调用父类的构造器, super就是父类构造器
        // 子类中this只能在super之后使用 语法规范
        super()
        this.ID = IDNumber
    }
}
const c = new Chinese('c1', 11, '377xxx')
console.log(c)
console.log(c.sayHello())