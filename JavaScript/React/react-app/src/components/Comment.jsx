import React from 'react'

import styles from "@/components/styles"
// const itemStyle = { border: "1px dashed #ccc", margin: '10px', padding: '5px', boxShadow: "0 0 5px #ccc" }
// const userStyle = { fontSize: "14px" }
// const contentStyle = { fontSize: "12px" }

// const styles = {
//     itemStyle: { border: "1px dashed #ccc", margin: '10px', padding: '5px', boxShadow: "0 0 5px #ccc" },
//     userStyle: { fontSize: "14px" },
//     contentStyle: { fontSize: "12px" },
// }

export default function Comment(props) {
    return <div style={styles.itemStyle}>
        <h5 style={styles.userStyle}>评论人: {props.user}</h5>
        <p style={styles.contentStyle}>评论内容: {props.content}</p>
    </div>
}