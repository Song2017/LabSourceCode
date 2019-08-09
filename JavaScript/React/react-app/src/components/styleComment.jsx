import React from 'react'

import cssob2 from '@/styles/comment.css'
console.log(cssob2)

export default function Comment(props) {
    return <div className={cssob2.item} >
        <h1 className={cssob2.title}>评论人: {props.user}</h1>
        <p className={cssob2.content}>评论内容: {props.content}</p>
    </div>
}