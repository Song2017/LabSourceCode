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