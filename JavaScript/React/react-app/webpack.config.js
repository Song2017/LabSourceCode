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
    plugins: [
        htmlPlugin
    ],
    // webpack默认处理.js文件, .png等无法处理的, 会直接找module
    // 第三方模块的配置规则
    module: {
        rules: [
            { test: /\.js|jsx$/, use: 'babel-loader', exclude: /node_modules/ },
            // css-loader?modules: 启用模块化
            // css模块化只对ID和类样式有效果, 标签样式不生效
            {
                test: /\.css$/, use: [{
                    loader: "style-loader"
                },
                {
                    loader: "css-loader",
                    options: {
                        modules: {
                            localIdentName: '[path][name]__[local]--[hash:base64:5]',
                        },
                    }
                }]
            }
        ]
    },
    resolve: {
        extensions: ['.js', '.jsx', '.json'],
        alias: {
            '@': path.join(__dirname, './src')
        }
    }
}