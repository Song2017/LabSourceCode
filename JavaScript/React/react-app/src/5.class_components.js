import React, { Component } from 'react'
import ReactDOM from 'react-dom'

class Movie extends React.Component {
    constructor() {
        super()
        // 相当于Vue中的data(){return{}}
        // 可读可写的
        this.state = {
            msg : "this is movie class"
        }
        this.test = {
            data: "test data"
        }
    }

    // 渲染组件到对应的虚拟DOM
    // class关键字中创建的组件, 使用外界传来的props参数不需要接收, 直接调用就行
    // this表示组件的实例对象
    render() {
        this.state.msg = 'this is movie class ~~'
        return <h1 id="myh1" title="this is title"> here is text in Movie --
        {this.props.name} -- {this.props.age} -- {this.state.msg} -- {this.test.data}</h1>
    }
}

const user = {
    name: 'dog', age: 3
}

ReactDOM.render(<div>
    {/* 这里的movie标签, 其实就是movie类的实例对象 */}
    <Movie {...user}></Movie>
</div>, document.querySelector('#app'))