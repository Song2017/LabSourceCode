const path = require('path')
const HtmlWebpackPlugin = require('html-webpack-plugin')
const htmlPlugin = new HtmlWebpackPlugin({
    //source file
    template: path.join(__dirname, './src/index.html'),
    //内存中首页的名称
    filename: 'index.html'
});

// 导出一个配置项
module.exports = {
    mode: 'development', //production: 压缩 
    //webpack4.x中的一个特性: 约定大于配置, 用来减小配置文件 默认入口: src> index.js
    entry: ["./src/index.js"],
    plugins:[
        htmlPlugin
    ]
}