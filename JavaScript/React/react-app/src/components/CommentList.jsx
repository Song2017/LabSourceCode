import React from 'react'
import Comment from '@/components/Comment'

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
            <h1 style={{ color: "red", fontWeight: 200, textAlign: "center" }}>{this.state.head}</h1>
            {this.state.commentList.map(item => <Comment {...item} key={item.id}></Comment>)}
        </div >
    }
}