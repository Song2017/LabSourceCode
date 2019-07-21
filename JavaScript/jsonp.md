jsonp
原因: 因为浏览器的安全性限制, 认为下面的数据接口不安全, 不允许ajax访问 
    包括协议不同, 域名不同, 端口号不同的数据接口
原理: 动态创建script标签的形式, 把src属性指向数据接口的地址
    因为script标签不存在跨域限制, 这种数据获取方式称为JSONP
Note: jsonp只支持Get请求

jsonp.client.html
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>

<body>
    <script>

        function show(data) {
            console.log(data)
        }
    </script>
    <!-- <script scr='http://127.0.0.1:8080/getscript?callback=show'></script>
    <script>
        show(data)
    </script> -->
</body>

</html>

jsonp.server.js
const http = require('http')
const urlModule = require('url')

const server = http.createServer()
server.on('request', function (req, res) {
    const { pathname: url, query } = urlModule.parse(req.url, true)
    if (url === '/getsctipt') {
        var data = {
            name: 'xxx',
            age: 18,
        }
        var scriptStr = `${query.callback}(${JSON.stringify(data)})`
        res.end(scriptStr)
    }
    else {
        res.end('404')
    }

})