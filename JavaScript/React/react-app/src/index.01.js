console.log('index.js')
import React from 'react'
import ReactDOM from 'react-dom'

// 参数: 元素的类型, 对象或null(DOM的属性), 子节点(其他DOM或文本子节点), 其他子节点...
//<h1 id="myh1" title="this is title"> here is text </h1>
const myh1 = React.createElement('h1', { id: "myh1", title: "this is title" }, ' here is text ')

//参数: 要渲染的DOM, 页面上的容器
ReactDOM.render(myh1, document.querySelector('#app'))