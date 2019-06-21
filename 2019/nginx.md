## 应用场景
1. 静态资源服务
通过本地文件系统提供服务
2. 反向代理服务
负载均衡: 容灾
缓存: css, js
3. API服务
应用服务性能受限, 但数据库没有到达瓶颈, 直接访问数据库
## 出现的原因
1. 互联网迅速发展, 物联网
2. apache的缺点: 一个连接对应一个进程, 但进程间的切换代价高. 现在并发的连接数很高
## 使用优点
1. 高并发, 高性能: 每个连接消耗的内存要小
2. 可拓展性好: 模块化好
3. 高可靠性: 可长时间运行
4. 热部署: 不停止服务器时进行服务部署, 不会清理掉缓存
5. BSD
## 组成部分
1. 二进制可执行文件: 
2. 配置文件 nginx.conf
3. 访问日志 access.log: 运营
4. 错误日志 error.log: 定位错误
## 配置文件的语法
1. # 注释
2. $ 变量
3. 正则表达式
4. {}, ;, include
## nginx命令行
1. -c: 配置文件
2. -g: 配置指令
3. -p: 指定运行目录
4. -s: 停止服务
5. -t: 测试配置文件
6. -v: 版本信息
重载配置文件: nginx -s reload
热部署: 服务器正在运行的.备份原有二进制文件; 更换二进制文件; kill -USER2 13195; kill -which 13195; 手动kill process/ 回退
日志切割: 备份access.log, nginx -s reopen. 最好设为每日或每周写入日志文件
## 静态资源web服务器
alias/route
gzip on; autoindex on; set $limit_rate 1K;
access_log, format: 内置变量
## 搭建具有缓存的反向代理服务
nginx_http_proxy_module
反向代理: 一台nginx服务器按照反向代理算法, 把request分发给多台服务器
上游服务器一般不对公网访问: listen 127.0.0.1 8080; 只对本机访问
http {
    proxy_cache_path ...;

    upstream local{
        # 算法分配
        server 127.0.0.1: 8080;
    }
    server {
        server_name geek.learn;
        listen:80;

        location / {
            proxy_set_header Host $host; #传递浏览器的Host地址发送给上游服务器
            proxy_set_header X-Real-IP $remote_addr;#传递浏览器的IP地址发送给上游服务器
            proxy_cahce name_cache; 
            proxy_cahce_key $host$uri$is_args$args;
            proxy_cahce_valid 200;
            proxy_pass http://local; # 上游服务器地址
        }
    }
}