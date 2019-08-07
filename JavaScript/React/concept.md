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

## babel 
//转换jsx为js, jsx: js中混合标准的html标签
//jsx文件的本质还是在运行的时候被转换成了js
npm i babel-core babel-loader@7 babel-plugin-transform-runtime -D
npm i babel-preset-env babel-preset-stage-0 -D
//jsx => js
npm i babel-preset-react -D
// config webpack.config.js
// config .babelrc