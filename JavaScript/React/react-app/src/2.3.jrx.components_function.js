console.log('index.js')
import React from 'react'
import ReactDOM from 'react-dom'
// 默认不能省略后缀名
// @表示 src目录
import Hello3 from '@/components/Hello.jsx'

// 创建组件
function Hello(props) {
    return <div>hello world --- {props.name.name} --- {props.name.age}</div>
}
function Hello2(props) {
    return <div>hello world --- {props.name} --- {props.age}</div>
}

const user = {
    name: 'dog', age: 3
}

const mydiv = <div id="divid" title="divtitle" style={{ color: "red" }}>
    this is div
    <Hello name={user}></Hello>
    <Hello2 {...user}></Hello2>
    <Hello3 {...user}></Hello3>
</div>
//参数: 要渲染的DOM, 页面上的容器
ReactDOM.render(mydiv, document.querySelector('#app'))