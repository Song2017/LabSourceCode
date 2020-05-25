# Redis
## 定义
1. 是一个非常快速的非关系数据库: 内存数据库,
2. 它存储了五种不同类型值的键映射: 字符串,列表,集合,哈希,排序集
3. Redis支持磁盘上的内存持久存储: 支持通过命令将内存数据写入磁盘文件,
    也支持使用仅附加文件,配置为每秒同步或每次操作完成后同步
4. 支持读取性能的复制以及扩展写入性能的客户端分片.

## 数据类型
### 字符串(string)
字符串类似于我们在其他语言或其他键值存储中看到的字符串

### 列表(list)
列表这种数据类型支持存储一组数据.
这种数据类型对应两种实现方法,一种是压缩列表(ziplist),另一种是双向循环链表.
当列表中存储的数据量比较小的时候,列表就可以采用压缩列表的方式实现.具体需要同时满足下面两个条件: 
    列表中保存的单个数据(有可能是字符串类型的)小于 64 字节；
    列表中数据个数少于 512 个
压缩列表并不是基础数据结构,而是 Redis 自己设计的一种数据存储结构.
它有点儿类似数组,通过一片连续的内存空间,来存储数据.不过,它跟数组不同的一点是,它允许存储的数据大小不同

### 字典(hash)
字典类型用来存储一组数据对.每个数据对又包含键值两部分.
字典类型也有两种实现方式.一种是我们刚刚讲到的压缩列表,另一种是散列表.
同样,只有当存储的数据量比较小的情况下,Redis 才使用压缩列表来实现字典类型.具体需要满足两个条件: 
    字典中保存的键和值的大小都要小于 64 字节；
    字典中键值对的个数要小于 512 个.
Redis 使用MurmurHash2这种运行速度快,随机性好的哈希算法作为哈希函数.
对于哈希冲突问题,Redis 使用链表法来解决.除此之外,Redis 还支持散列表的动态扩容,缩容.

### 集合(set)
集合这种数据类型用来存储一组不重复的数据.
这种数据类型也有两种实现方法,一种是基于有序数组,另一种是基于散列表.
当要存储的数据,同时满足下面这样两个条件的时候,Redis 就采用有序数组,来实现集合这种数据类型.
    存储的数据都是整数；
    存储的数据元素个数不超过 512 个.

### 有序集合(sortedset)
有序集合用来存储一组数据,并且每个数据会附带一个得分.
通过得分的大小,我们将数据组织成跳表这样的数据结构,以支持快速地按照得分值,得分区间获取数据.
当数据量比较小的时候,Redis 会用压缩列表来实现有序集合, 比较大时就使用散列表来存储集合中的数据.
具体点说就是,使用压缩列表来实现有序集合的前提,有这样两个:
    所有数据的大小都要小于 64 字节；
    元素个数要小于 128 个.

## 数据结构持久化
尽管 Redis 经常会被用作内存数据库,但是,它也支持数据落盘,也就是将内存中的数据存储到硬盘中.
这样,当机器断电的时候,存储在 Redis 中的数据也不会丢失.
在机器重新启动之后,Redis 只需要再将存储在硬盘中的数据,重新读取到内存,就可以继续工作了.
刚刚我们讲到,Redis 的数据格式由"键"和"值"两部分组成.
而"值"又支持很多数据类型,比如字符串,列表,字典,集合,有序集合.
像字典,集合等类型,底层用到了散列表,散列表中有指针的概念,而指针指向的是内存中的存储地址.
那 Redis 是如何将这样一个跟具体内存地址有关的数据结构存储到磁盘中的呢?
我们把它叫作数据结构的持久化问题,或者对象的持久化问题.这里的"持久化",你可以笼统地可以理解为"存储到磁盘".
主要有两种解决思路.
第一种是清除原有的存储结构,只将数据存储到磁盘中.
当我们需要从磁盘还原数据到内存的时候,再重新将数据组织成原来的数据结构.实际上,Redis 采用的就是这种持久化思路.
不过,这种方式也有一定的弊端.那就是数据从硬盘还原到内存的过程,会耗用比较多的时间
第二种方式是保留原来的存储格式,将数据按照原有的格式存储在磁盘中.
我们拿散列表这样的数据结构来举例.我们可以将散列表的大小,每个数据被散列到的槽的编号等信息,都保存在磁盘中.
有了这些信息,我们从磁盘中将数据还原到内存中的时候,就可以避免重新计算哈希值.

## 用途
String: 缓存,限流,计数器,分布式锁,分布式Session
Hash: 存储用户信息,用户主页访问量,组合查询
List: 微博关注人时间轴列表,简单队列
Set: 赞,踩,标签,好友关系
Zset: 排行榜

## Note
1. [the-little-redis-book](https://github.com/JasonLai256/the-little-redis-book/blob/master/cn/redis.md)
2. [redis-py-s-documentation](https://redis-py.readthedocs.io/en/latest/index.html?redis.Redis.pipeline#welcome-to-redis-py-s-documentation)
3. [redis.io/commands](https://redis.io/commands)

## Code 
```
import redis
# set redis-py
r = redis.Redis(host='localhost', port=6379, db=0)
r.set('begin', 'begin...')
print(r.get('begin'))
```
### 数据结构
#### 字符串(Strings)
##### Redis的字符串数据结构能很好地用于分析用途
##### 你的值可以是任何东西.我更喜欢将他们称作"标量"(Scalars)
print('字符串(Strings)')
r.set('users:leto', '{name: leto, planet: dune, likes: [spice]}')
print(r.strlen('users:leto'))
print(r.getrange('users:leto', 27, 40))
print(r.append('users:leto', ' over 9000!!'))
print(r.get('users:leto'))
##### increase 1
r.incr('stats:page:about')
print(r.incr('stats:page:about'))
##### increase number
r.incrby('ratings:video:123', 5)
print(r.incrby('ratings:video:123', 3))
##### redis.exceptions.ResponseError: value is not an integer or out of range
##### r.incrby('users:leto')

#### 散列(Hashes)
##### 散列数据结构很像字符串数据结构.两者显著的区别在于,散列数据结构提供了一个额外的间接层: 一个域(Field)
##### 对于散列数据结构,可以从一个经过明确定义的对象的角度来考虑,例如一个用户,关键之处在于要理解他们是如何工作的.
##### 如何用散列数据结构去组织你的数据,使查询变得更为实效.在我看来,这是散列真正耀眼的地方
print('散列(Hashes)')
if r.exists('users:goku'):
    r.delete('users:goku')
r.hset('users:goku', 'powerlevel', 9000)
if r.hexists('users:goku', 'powerlevel'):
    print(r.hget('users:goku', 'powerlevel'))
d = {'race': 'saiyan', 'age': 737}
if not r.hexists('users:goku', 'race'):
    r.hmset('users:goku', d)
print(r.hmget('users:goku', 'powerlevel', 'age'))
print(r.hkeys('users:goku'))
r.hdel('users:goku', 'age')
print(r.hgetall('users:goku'))

#### 列表(Lists)
##### 对于一个给定的关键字,列表数据结构让你可以存储和处理一组值
print('列表(Lists)')
r.delete('newusers')
r.lpush('newusers', 'goku')
r.lpush('newusers', 'leto')
##### LTRIM Key start stop.
##### 要理解ltrim命令,首先要明白Key所存储的值是一个列表,理论上列表可以存放任意个值.
##### 对于指定的列表,根据所提供的两个范围参数start和stop,ltrim命令会将指定范围外的值都删除掉,只留下范围内的值
r.ltrim('newusers', 0, 50)
keys = r.lrange('newusers', 0, 10)
print(keys)
print(['users:'+user.decode('utf-8') for user in keys])
print(r.mget(['users:'+user.decode('utf-8') for user in keys]))

#### 集合(Sets)
##### 集合数据结构常常被用来存储只能唯一存在的值,并提供了许多的基于集合的操作
##### 集合数据结构没有对值进行排序,但是其提供了高效的基于值的操作
print('集合(Sets)')
r.delete('friends:leto')
r.sadd('friends:leto', 'ghanima', 'paul', 'chani', 'jessica')
r.delete('friends:duncan')
r.sadd('friends:duncan', 'paul', 'alia', 'jessica')
print(r.sismember('friends:leto', 'jessica'))
print(r.sismember('friends:leto', 'vladimir'))
print(r.sinter('friends:leto', 'friends:duncan'))
r.sinterstore('friends:leto_duncan', 'friends:leto', 'friends:duncan')
print('sinterstore', r.smembers('friends:leto_duncan'))

#### 分类集合(Sorted Sets)
##### 分类集合数据结构类似于集合数据结构,主要区分是标记(score)的概念.
##### 标记提供了排序(sorting)和秩划分(ranking)的功能
print('分类集合(Sorted Sets)')
r.delete('friends:duncan')
r.zadd('friends:duncan', {'ghanima': 70,  'paul': 95,  'chani': 95,
                          'jessica': 85, 'vladimir': 1})
print(r.zcount('friends:duncan', 90, 100))
##### 译注: zrank命令的具体构成是ZRANK Key menber,
##### 要知道Key存储的Sorted Set默认是根据Score对各个menber进行升序的排列,
##### 该命令就是用来获取menber在该排列里的次序,这就是所谓的秩
print(r.zrevrank('friends:duncan', 'chani'))

### 第3章 - 使用数据结构
#### 仿多关键字查询(Pseudo Multi Key Queries)
##### 散列 使用散列数据结构来使查询更灵活一些
r.delete('users:9001')
r.set('users:9001', "{id: 9001, email: leto@dune.gov, ...}")
r.hset('users:lookup:email', 'leto@dune.gov', 9001)
print('get user', r.get('users:9001'))
id = r.hget('users:lookup:email', 'leto@dune.gov').decode('utf-8')
print(id, 'users'+id)
print("r.get('users'+id)",  r.get('users:'+id))

#### 引用和索引(References and Indexes)
##### 对于那些值与值间的索引和引用,我们都必须手动的去管理.集合数据结构很常被用来实现这类索引
r.delete('friends:leto2')
r.sadd('friends:leto2', 'ghanima', 'paul', 'chani', 'jessica')
r.delete('friends_of:chani')
r.sadd('friends_of:chani', 'leto', 'paul')
print(r.smembers('friends:leto2'), r.smembers('friends_of:chani'))

#### 数据交互和流水线(Round Trips and Pipelining)
##### 我们已经提到过,与服务器频繁交互是Redis的一种常见模式,
##### 许多命令能接受一个或更多的参数,也有一种关联命令(sister-command)可以接受多个参数
print('数据交互和流水线(Round Trips and Pipelining)')
keys = r.lrange('newusers', 0, 10)
print(keys)
print(['users:'+user.decode('utf-8')
       for user in keys], r.hgetall('users:goku'))
print(r.mget(['users:'+user.decode('utf-8') for user in keys]))
r.delete('friends:leto3')
r.sadd('friends:leto3', 'ghanima', 'paul', 'chani', 'jessica')
print(r.smembers('friends:leto3'))
##### 通常情况下,当一个客户端发送请求到Redis后,在发送下一个请求之前必须等待Redis的答复.
##### 使用流水线功能,你可以发送多个请求,而不需要等待Redis响应.这不但减少了网络开销,还能获得性能上的显著提高.
##### 值得一提的是,Redis会使用存储器去排列命令,因此批量执行命令是一个好主意.
##### 至于具体要多大的批量,将取决于你要使用什么命令(更明确来说,该参数有多大).
##### 另一方面来看,如果你要执行的命令需要差不多50个字符的关键字,你大概可以对此进行数千或数万的批量操作
r.delete('bing')
r.set('bing', 'baz')
pipe = r.pipeline()
pipe.delete('foo')
pipe.set('foo', 'bar')
pipe.get('bing')
print(pipe.execute())
##### chained
result = pipe.set('foo', 'bar_pipe').sadd(
    'faz', 'baz').incr('auto_number').execute()
print(result, r.get('foo'), r.smembers('faz'), r.get('auto_number'))

#### 事务(Transactions)
##### 每一个Redis命令都具有原子性,包括那些一次处理多项事情的命令.此外,对于使用多个命令,Redis支持事务功能
##### Redis实际上是单线程运行的,这就是为什么每一个Redis命令都能够保证具有原子性.
##### 当一个命令在执行时,没有其他命令会运行
#####   incr命令实际上就是一个get命令然后紧随一个set命令.
#####   getset命令设置一个新的值然后返回原始值.
#####   setnx命令首先测试关键字是否存在,只有当关键字不存在时才设置值
##### 首先要执行multi命令,紧随其后的是所有你想要执行的命令(作为事务的一部分),
##### 最后执行exec命令去实际执行命令,或者使用discard命令放弃执行命令
#####  Redis的事务功能保证了什么
##### 事务中的命令将会按顺序地被执行
##### 事务中的命令将会如单个原子操作般被执行(没有其它的客户端命令会在中途被执行)
#####   虽然Redis是单线程运行的,但是我们可以同时运行多个Redis客户端进程,常见的并发问题还是会出现(watch)
##### 事务中的命令要么全部被执行,要么不会执行
##### In redis-py MULTI and EXEC can only be used through a Pipeline object.
##### https://redis-py.readthedocs.io/en/latest/index.html?redis.Redis.pipeline#redis.Redis.pipeline
r.set('powerlevel', 12)
r.watch('powerlevel')
pipe.multi()
current = int(r.get('powerlevel'))
pipe.set('powerlevel', current+1).incr('powerlevel')
print(pipe.execute())
print(r.get('powerlevel'))

#### 关键字反模式(Keys Anti-Pattern)
##### keys命令.这个命令需要一个模式,然后查找所有匹配的关键字.
##### 这个命令看起来很适合一些任务,但这不应该用在实际的产品代码里.
##### 为什么?因为这个命令通过线性扫描所有的关键字来进行匹配.或者,简单地说,这个命令太慢了
print('关键字反模式(Keys Anti-Pattern)')
##### 不推荐
r.set('bug:12:1', 'bug1')
r.set('bug:12:2', 'bug2')
print(r.keys('bug:12:*'))
##### 推荐
r.hset('bug:123', 1, "{id:1, account: 1233, subject: '...'}")
r.hset('bug:123', 2, "{id:2, account: 1233, subject: '...'}")
print(r.hkeys('bug:123'))

### 第4章 超越数据结构
#### 使用期限(Expiration)
##### Redis允许你标记一个关键字的使用期限
##### 你可以给予一个Unix时间戳形式(自1970年1月1日起)的绝对时间,或者一个基于秒的存活时间
##### 关键字需要存在, expire后ttl: -2, persist后ttl: -1
##### 将会在30秒后删除掉关键字(包括其关联的值)
print('第4章 超越数据结构')
print('使用期限(Expiration)')
r.delete('pages:about')
r.set('pages:about', 'this is a page')
r.expire('pages:about', 30)
print(r.get('pages:about'), r.ttl('pages:about'))
##### 2012年12月31日上午12点删除掉关键字
r.expireat('pages:about', 1356933600)
print(r.get('pages:about'), r.ttl('pages:about'))
r.set('pages:about', 'this is a page')
r.persist('pages:about')
print(r.get('pages:about'), r.ttl('pages:about'))
r.setex('pages:about', 30, '<h1>about us</h1>....')
print(r.get('pages:about'), r.ttl('pages:about'))

#### 队列
##### Redis的列表数据结构有blpop和brpop命令,
##### 能从列表里返回且删除第一个(或最后一个)元素,或者被堵塞,直到有一个元素可供操作.
##### 对于blpop和brpop命令,如果列表里没有关键字可供操作,
##### 连接将被堵塞,直到有另外的Redis客户端使用lpush或rpush命令推入关键字为止.

#### 监控和延迟日志(Monitor and Slow Log)
##### monitor命令可以让你查看Redis正在做什么
##### 在实际生产环境里,你应该谨慎运行monitor命令,这真的仅仅就是一个很有用的调试和开发工具
##### slowlog命令,这是一个优秀的性能剖析工具.其会记录执行时间超过一定数量微秒的命令

### 排序(Sort)
##### sort命令是Redis最强大的命令之一.
##### 它让你可以在一个列表,集合或者分类集合里对值进行排序(分类集合是通过标记来进行排序,而不是集合里的成员)
print('排序(Sort)')
r.delete('users:leto:guesses')
r.rpush('users:leto:guesses', 5, 6, 9, 10, 2, 5, 20, 19, 10, 2)
print(r.sort('users:leto:guesses'))
##### 对已排序的记录进行分页(通过limit),如何返回降序排序的结果(通过desc),
##### 以及如何用字典序排序代替数值序排序(通过alpha)
r.sadd('friends:ghanima', 'leto', 'paul', 'chani', 'jessica', 'alia', 'duncan')
print(r.sort('friends:ghanima', 0, 3, None, alpha=True))
##### sort命令的真正力量是其基于引用对象来进行排序的能力
##### 列表,集合和分类集合很常被用于引用其他的Redis对象,sort命令能够解引用这些关系,而且通过潜在值来进行排序
r.delete('watch:leto')
r.sadd('watch:leto', 12339, 1382, 338, 9338)
r.set('severity:12339', 3)
r.set('severity:1382', 2)
r.set('severity:338', 5)
r.set('severity:9338', 4)
print(r.sort('watch:leto', by='severity:*', desc=True))
##### sort命令也可以工作在散列数据结构及其相关域里
r.hset('bug:12339', 'severity', 3)
r.hset('bug:12339', 'priority', 1)
r.hset('bug:12339', 'details', '{id: 12339, ....}')
r.hmset('bug:1382', {'severity': 2, 'priority': 2,
                     'details': "{id: 1382, ....}"})
r.hmset('bug:338', {'severity': 5, 'priority': 3,
                    'details': "{id: 338, ....}"})
r.hmset('bug:9338', {'severity': 4, 'priority': 2,
                     'details': "{id: 9338, ....}"})
r.hmset('bug:93381', {'severity': 6, 'priority': 5,
                      'details': "{id: 93381, ....}"})
print(r.hgetall('bug:12339'), r.hgetall('bug:1382'))
##### 相同的值替代出现了,但Redis还能识别->符号,用它来查看散列中指定的域.
##### 里面还包括了get参数,这里也会进行值替代和域查看,从而检索出Bug的细节(details域的数据
print(r.sort('watch:leto', by="bug:*->priority", get="bug:*->details"))
##### 对于太大的集合,sort命令的执行可能会变得很慢.好消息是,sort命令的输出可以被存储起来
sr = r.sort('watch:leto', by="bug:*->priority",
            get="bug:*->details", store='watch_by_priority:leto')
print(sr, r.lrange('watch_by_priority:leto', 0, 10))


# Course
## 小结
1. 基于内存的, 快
2. K, V
3. 线程池: 单线程worker, 运行在CPU的一个核心上·
4. 连接池: 支持很多连接. linux使用epoll机制
5. 值类型: 5种
6. 本地方法: 计算向数据移动, 存储的数据是有类型的(不同的类型对应不同的本地方法)
    例如, 客户端请求列表的某一个元素, redis服务器会返回具体的值. 优化了IO
7. 串行/单线程worker 
    6.x版本后, IO线程可以放在其他的线程
    并行: 访问连接
    串行: 交易, 扣减库存时要保持强一致性, 走串行
    解决并行和串行的链接: 栈数据结构

## 数值类型使用的场景
1. 存储是基于字节的, 所以strlen取得是字节长度
2. 二进制安全: 数据以byte[]存储.     
- 没有数据类型的概念, 也就不会有类型内存溢出, 但是读写的编码规则要保持一致
- 图片可以作为key
3. ascii基础集
    A 65 01000001  
    B 66 01000010  
4. 动态排序 
反向取数据不会重排, 数据量多余64条使用skiplist

### String
1. 字符串
session, kv缓存, 内存级别的小文件系统
2. 数字
数值计数器
3. 二进制位
- setbit 二进制串从左向右设置
- 统计用户一年中的登录次数, 二进制可以操作位, 所以用户要对应到二进制串中的一位
    创建偏移量为365的二进制字节串
### List
1. 栈, 同向指令: lpush lpop
2. 队列, 异向指令: lpush rpop
3. 数组 lindex, lrange k1 0 -1
4. 优化redis内存量, 只保留部分记录, ltrim删除最后一个元素: ltrim k1 0 -2 
### Hash
hset s name song; hset s age 111
hgetall s; hincrby s age 1
1. 聚集数据, 详情页, 用户详情
### Set
集合, 无序, 不重复. 不推荐, 单线程worker易卡住
1. 随机事件: 抽奖, 二维码
2. 并集: 共同好友
3. 交集: 商品推荐
### ZSet sorted_set
有序集合, 每个元素固定增加score, rank属性
1. 排行榜
2. 分页

## 集群(分布式)
### 持久化
1. 快照, 基于时间点. rdb, images, bak
全量存储, 体积与实际数据相近, 回复速度快
2. 日志 aof
物理文件会不断的累加
操作系统IO: pagecache
3. redis默认开启rdb
需要手工开启aof, 此时重启只会读取aof. 
redis为了避免无用的重复占用太多体积, 4.x之后会先保存一个rdb文件, 然后在其基础上追加aof
### 单机的通用问题
1. 单点故障不可用
* 全量的主备集群
* 分布式协调: zab, raft
* 实现的依据, paxos论文, Paxos算法是基于消息传递且具有高度容错特性的一致性算法，
是目前公认的解决分布式一致性问题最有效的算法之一
2. 压力/性能
* 非全量的数据分片扩容, 将数据分散到不同的集群节点
* 请求分片算法的位置: client, 代理层server, redis server
### redis HA(强一致性)
同步数据, CAP: 数据一致性, 可用性, 分区容错性最多只能同时实现两点
强一致性会导致不可用
redis的分布式锁是弱分布式锁, 类似的有zookeeper, etcd
最终一致性: 必须存在某个不会挂的数据server: 多机集群 journalnode