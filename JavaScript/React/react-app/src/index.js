console.log('index.js')
import React from 'react'
import ReactDOM from 'react-dom'

// 参数: 元素的类型, 对象或null(DOM的属性), 子节点(其他DOM或文本子节点), 其他子节点...
let a = 10
let str = 'hellow world'
let title = 'this is title'

const myh1 = <h1>h1 tag</h1>
const arr = [
    <h2>h2 tag</h2>,
    <h3>h3 tag</h3>
]
const arrStr = ['zhangsan', 'lisi', 'wangwu']
const nameArr = []
// map函数要有返回值
const arrStr2 = arrStr.map(item => {
    return item + '~~~'
})
arrStr2.forEach(item => {
    let temp = <p key={item}>{item}</p>
    nameArr.push(temp)
})


const mydiv = <div id="divid" title="divtitle" style={{ color: "red" }}>
    this is div{a + 2} {str}
    <hr />
    <p id={title}>{title}</p>
    {myh1}
    {/* {arr} */}
    <hr />
    {nameArr}
    {/* {arrStr.map(item => {
        return <p>{item + '~~'}</p>
    })} */}
    {arrStr.map(item => <p key={item}>{item + '~'}</p>)}
</div>
//参数: 要渲染的DOM, 页面上的容器
ReactDOM.render(mydiv, document.querySelector('#app'))