//#region comment region
// just 折叠



//#endregion

import React from 'react'

export default class BindEvent extends React.Component {
    constructor() {
        super()
        this.state = {
            msg: 'state msg',
            name: 'zhangsan',
            age: 18
        }
        this.data = { name: 'data name' }
    }
    render() {
        return <div>
            BindEvent
            <hr />
            {/* // react中有自己的事件绑定机制, 事件的名称必须是小驼峰规则
            // 事件只接受function作为处理函数, function()是一个函数的调用结果
            // 匿名函数(箭头函数)本身就是一个匿名的function函数,  this的指向由方法外面的this决定
            // 这里的this指向BindEvent的实例
            // <button onClick={()=>{this.clickHandler(123);}}>button</button> */}
            <button onClick={() => this.clickHandler(123)}>button</button>
            <h3>{this.state.msg}</h3>
            {/* 只是设置文本框的value, 而不提供onChange处理函数, 这是文本框是只读的
            需要提供readOnly或onChange事件, 
            要把UI中的最新数据同步到state中, 需要手动监听onChange事件 
            获取文本框中的值: 1: 通过事件参数e*/}
            <input type="text" style={{ width: '100%' }} value={this.state.msg} onChange={(e) => this.txtChange(e)}></input>
        </div>

    }
    txtChange = (e) => {
        // 获取文本框中的值: 1: 通过事件参数e
        console.log(e.target.value)
        // 2: 
        // console.log(this.refs)
        this.setState({
            // 只会把对应的state更新, 而不会覆盖其他的
            msg: e.target.value,
        }, function () { console.log(this.state.msg) })
    }
    // 实例方法
    clickHandler = (arg) => {
        console.log(this)
        console.log('clickHandler' + "~" + arg)
        // React中想为state中的数据重新赋值, 不能使用this.state.xx, 要使用this.setState({})
        this.state.msg = arg;
        // 这里执行的方法是异步的, 想要立即去到最新的值时, 需要使用callback函数
        this.setState({
            // 只会把对应的state更新, 而不会覆盖其他的
            msg: 'setState' + arg,
        }, function () { console.log(this.data.name + this.state.msg) })
    }

}
