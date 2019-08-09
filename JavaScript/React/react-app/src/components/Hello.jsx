import React from 'react'

export default function Hello3(props) {
    return <div>hello world --- {props.name} --- {props.age}</div>
}

// 把组件暴露出去
// export default Hello3