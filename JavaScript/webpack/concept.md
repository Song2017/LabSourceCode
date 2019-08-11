## webpack
npm init -y
//folder dist: 产品目录, src: 源码
//-D 本地安装web pack
npm i webpack webpack-cli -D
//add webpack.config.js
//webpack4.x中的一个特性: 约定大于配置, 用来减小配置文件 默认入口: src>index.js, 输出dist>main.js
webpack
//自动打包
npm i webpack-dev-server -D
// package.json add command
//打包的文件main.js, 放在根目录下的main.js
npm run dev
// 将html缓存到内存中, html-webpack-plugin
npm i html-webpack-plugin -D
// 省略后缀名, extensions中的顺序就是补全的顺序
    resolve: {
        extensions: ['.js', '.jsx', '.json']
    }
//配置 @表示 src目录
    resolve: {
        alias:{
            '@':path.join(__dirname, './src')
        }
//安装css loader
npm i style-loader css-loader -D
// babel 转换jsx为js, jsx: js中混合标准的html标签
//jsx文件的本质还是在运行的时候被转换成了js
npm i babel-core babel-loader@7 babel-plugin-transform-runtime -D
npm i babel-preset-env babel-preset-stage-0 -D
//jsx => js
npm i babel-preset-react -D
// config webpack.config.js
// config .babelrc     

## 样式表 style
// 行内样式, 在jsx中, 不能用字符床设置style, 使用object映射规范 style={{ color: "red" }}
// 分散的样式对象
// 合并成一个样式对象
// 分出到独立的.js样式文件中
// 使用独立的.css样式文件: 配置webpack
// 样式冲突: vue解决方法: <style scoped></style>
//      react中没有指令的概念, 没有scoped指令, 通过webpack设置css模块化
//      webpack css模块化只对ID和类样式有效果, 标签样式不生效
// 安装bootstrarp
npm i bootstrap -D -S --dev
// 处理字体文件
npm i url-loader file-loader -D -S --dev
// 约定: 第三方的样式文件以.css结尾, 自己定义的样式文件以.scss或.less结尾
npm i sass-loader node-sass -D -S --dev