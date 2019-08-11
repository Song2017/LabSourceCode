import React from 'react'

// 直接导入的css样式表的生效范围是全局的
// cssobj默认是空对象: commentList.css没有暴露出来属性
import cssobj from '@/styles/commentList.scss'
import Comment from '@/components/styleComment'
// 引用包时, 如果包被安装到node_modules时, 可以直接通过包名进行引用
import 'bootstrap/dist/css/bootstrap.css'

export default class CommentList extends React.Component {
    constructor() {
        super()
        this.state = {
            head: "This is Comment Component",
            commentList: [
                { id: 1, user: 'user1', content: 'content1' },
                { id: 2, user: 'user2', content: 'content2' },
                { id: 3, user: 'user3', content: 'content3' },
                { id: 4, user: 'user4', content: 'content4' },
            ]
        }
    }

    render() {
        return <div>
            <h1 className={cssobj.title}>{this.state.head}</h1>
            {/* <button className={[bootcss.btn, bootcss["btn-primary"]].join(" ")}>btn</button> */}
            <button className="btn btn-primary">btn</button>
            {this.state.commentList.map(item => <Comment {...item} key={item.id}></Comment>)}
        </div >
    }
}