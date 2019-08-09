import React, { Component } from 'react'
import ReactDOM from 'react-dom'

import CommentList from '@/components/CommentList'


ReactDOM.render(<div>
    {/* 这里的movie标签, 其实就是movie类的实例对象 */}
    <CommentList></CommentList>
</div>, document.querySelector('#app'))