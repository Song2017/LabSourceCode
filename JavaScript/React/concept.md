## 虚拟DOM virtual document object model
react框架中, 用JS对象来模拟页面上DOM元素和DOM元素的嵌套
目的: 实现DOM元素的高效更新
浏览器中的DOM, 可以用JS对象表示页面上的元素, 提供了操作的API

## Diff算法
tree diff: 新旧两个虚拟DOM树中逐层对比的过程, 就是tree diff. 用来找到所有需要更新的元素
component diff: 每一层中的组件的对比过程, 若对比前后, 组件类型相同, 则暂时认为不需要更新
element diff: 组件的类型相同, 则需要进行元素对比

## react lib
// react: 创建组件和虚拟DON
// react-dom: 展示和操作组件和虚拟DOM
// -S: 到上线前都要用的 -D: 工具
npm i react react-dom -S

## create element
//导入包 
//创建虚拟DON, 渲染DOM
```
// 参数: 元素的类型, 对象或null(DOM的属性), 子节点(其他DOM或文本子节点), 其他子节点...
//<h1 id="myh1" title="this is title"> here is text </h1>
const myh1 = React.createElement('h1', { id: "myh1", title: "this is title" }, ' here is text ')

//参数: 要渲染的DOM, 页面上的容器
ReactDOM.render(myh1, document.querySelector('#app'))
```

## jsx
// babel 转换jsx为js, jsx: js中混合标准的html标签
//jsx文件的本质还是在运行的时候被转换成了js
npm i babel-core babel-loader@7 babel-plugin-transform-runtime -D
npm i babel-preset-env babel-preset-stage-0 -D
//jsx => js
npm i babel-preset-react -D
// config webpack.config.js
// config .babelrc

// jsx中标签都要有反斜线, 注释要加大括号{//, /*  */}
// 花括号{}内部的是js, ES6中 ...是展开运算符, 用来获取对象的属性
// 因为与js的关键字冲突, class>className, for>htmlfor

## 组件
// 创建组件
// 1. 构造函数就是一个组件, 但是必须放回合法的虚拟DOM, 接收调用方传入数据的形参props是只读的
// 因为标签的首字母都是大写, 所以构造函数的首字母要大写
// 将组件分离到.jsx文件中, 文件中要引用react类包并暴露组件函数
// 2. class关键字创建组件
// class关键字中创建的组件, 使用外界传来的props参数不需要接收, 直接调用就行
// this表示组件的实例对象
// 构造函数和class关键字创建的组件的形参props都是只读的
// 1. 构造函数组件是无状态组件 class为有状态组件
// 2. 有状态组件可以自己定义属性并且有生命周期函数
// 3. 无状态组件的运行效率会高一些
// 4. props中的数据都是外界传递过来的, 只读, 不能重新赋值
// 5. state/data 中的数据是组件私有的, 可读可写, 一般是ajax获取回来的数据

## 类 class基本使用
// 类class 语法
// 类内部不能使用 var, class只是语法糖, 本质仍然是function
// class内部, this指代类实例
// class Animal {}
    // 构造器, 默认有一个形参为空的构造器, 作用: new类的时候优先执行构造器中的代码
    // 实例属性: 通过new出来的实例访问
    // 静态属性: 通过构造函数直接访问, 类级别的属性
    // 实例方法: 本质是挂载到protptype
    // 静态方法: 挂载到构造函数上, 通过类调用的方法
// Class Extends 类继承
// 父类的属性和函数在子类的上一级原型链中
// 子类中的属性和函数, 构造器自定义后, 就重写了父类    
    // super: 语法规范, 子类使用extends父类后, 必须通过super调用父类的构造器, super就是父类构造器
    // 子类中this只能在super之后使用 语法规范

## 样式表 style
// 行内样式, 在jsx中, 不能用字符床设置style, 使用object映射规范 style={{ color: "red" }}
// 分散的样式对象
// 合并成一个样式对象
// 分出到独立的.js样式文件中
// 使用独立的.css样式文件: 配置webpack
// 样式冲突: vue解决方法: <style scoped></style>
//      react中没有指令的概念, 没有scoped指令, 通过webpack设置css模块化
//      webpack css模块化只对ID和类样式有效果, 标签样式不生效
// 安装bootstrarp
npm i bootstrap -D -S --dev
// 处理字体文件
npm i url-loader file-loader -D -S --dev
// 约定: 第三方的样式文件以.css结尾, 自己定义的样式文件以.scss或.less结尾
npm i sass-loader node-sass -D -S --dev

## 事件 Event
// react中有自己的事件绑定机制, 事件的名称必须是小驼峰规则
// 事件只接受function作为处理函数, function()是一个函数的调用结果
// 匿名函数(箭头函数)本身就是一个匿名的function函数,  this的指向由方法外面的this决定
<button onClick={()=>{this.clickHandler();}}>button</button>
clickHandler=(arg)=>{
    console.log('clickHandler'+"~"+arg)
}
setTimeout()方法中的this指向window, 因为是window的函数
// React中想为state中的数据重新赋值, 不能使用this.state.xx, 要使用this.setState({})
// 这里执行的方法是异步的, 想要立即去到最新的值时, 需要使用callback函数
this.setState({
    // 只会把对应的state更新, 而不会覆盖其他的
    msg: 'setState' + arg,
}, function () { console.log(this.data.name + this.state.msg) })
// react中有自己的事件绑定机制, 事件的名称必须是小驼峰规则
// 事件只接受function作为处理函数, function()是一个函数的调用结果
// 匿名函数(箭头函数)本身就是一个匿名的function函数,  this的指向由方法外面的this决定
// 这里的this指向BindEvent的实例
<button onClick={() => this.clickHandler(123)}>button</button>
// 只是设置文本框的value, 而不提供onChange处理函数, 这是文本框是只读的
// 需要提供readOnly或onChange事件, 要把UI中的最新数据同步到state中, 需要手动监听onChange事件 
// 获取文本框中的值: 1: 通过事件参数
<input type="text" value={this.state.msg} onChange={(e) =>this.txtChange(e)} />
