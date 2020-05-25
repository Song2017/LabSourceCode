## 容器技术基础
### Docker解决的问题
1. PaaS 项目，最核心的组件就是一套应用的打包和分发机制, Docker 镜像解决的，恰恰就是打包这个根本性的问题
只要有这个压缩包在手，你就可以使用某种技术创建一个“沙盒”，在“沙盒”中解压这个压缩包，然后就可以运行你的程序
2. Docker 项目提供了一种非常便利的打包机制。
这种机制直接打包了应用运行所需要的整个操作系统，从而保证了本地环境和云端环境的高度一致，
避免了用户通过“试错”来匹配两种不同运行环境之间差异的痛苦过程
3. Linux容器基于Linux Namespace 的隔离能力、Linux Cgroups 的限制能力，以及rootfs 的文件系统, 
而 Docker on Mac，以及 Windows Docker（Hyper-V 实现），实际上是基于虚拟化技术实现的
#### 容器
1. 容器，其实是一种特殊的进程, **是一个“单进程”模型**. 
  实际上是一个由 Linux Namespace、Linux Cgroups 和 rootfs 三种技术构建出来的进程的隔离环境
2. 进程: 一个程序运起来后的计算机执行环境的总和
3. 容器技术的核心功能，就是通过约束和修改进程的动态表现，从而为其创造出一个“边界”
Cgroups 技术是用来制造约束的主要手段，而 Namespace 技术则是用来修改进程视图的主要方法
4. Docker 项目最核心的原理. 实际上就是为待创建的用户进程:
- 启用 Linux Namespace 配置;
- 设置指定的 Cgroups 参数;
- 切换进程的根目录（Change Root）
##### 容器的隔离与限制
1. 隔离 Namespace
- Namespace 技术实际上修改了应用进程看待整个计算机“视图”，即它的“视线”被操作系统做了限制，
只能“看到”某些指定的内容
- 其实就是对被隔离应用的进程空间做了手脚，使得这些进程只能看到重新计算过的进程编号，比如 PID=1。
可实际上，他们在宿主机的操作系统里，还是原来的第 100 号进程
- Namespace 的使用: 通过指定 Linux 创建新进程的一个可选参数: CLONE_NEWPID.
新创建的这个进程将会“看到”一个全新的进程空间，在这个进程空间里，它的 PID 是 1.      
严格说，clone()是线程操作，但linux 的线程是用进程实现      
```int pid = clone(main_function, stack_size, CLONE_NEWPID | SIGCHLD, NULL); ```
- 除了PID Namespace，Linux 操作系统还提供了 Mount、UTS、IPC、Network 和 User 这些 Namespace，
用来对各种不同的进程上下文进行隔离操作
- 隔离得不彻底, 容器只是运行在宿主机上的一种特殊的进程，
那么多个容器之间使用的就还是同一个宿主机的操作系统内核。
容器里通过 Mount Namespace 单独挂载其他不同版本的操作系统文件，但这并不能改变共享宿主机内核的事实。
这意味着，不能在Windows宿主机上运行 Linux 容器，或者在低版本的Linux宿主机上运行高版本的Linux容器
- Linux 内核中，有很多资源和对象是不能被 Namespace 化的，最典型的例子就是:时间
2. 限制 Cgroups
PID Namespace只是让容器进程看不到外部的进程, 但是容器进程占用的资源（比如 CPU、内存）是与外部共享的
- Linux Cgroups的全称是 Linux Control Group, 是 Linux 内核中用来为进程设置资源限制的一个重要功能
最主要的作用，就是限制一个进程组能够使用的资源上限，包括 CPU、内存、磁盘、网络带宽等等
此外，Cgroups 还能够对进程进行优先级设置、审计，以及将进程挂起和恢复等操作
- 在 Linux 中，Cgroups 给用户暴露出来的操作接口是文件系统，
即它以文件和目录的方式组织在操作系统的 /sys/fs/cgroup 路径下
- 它就是一个子系统目录加上一组资源限制文件的组合
```
$ ls /sys/fs/cgroup/cpu
cgroup.clone_children cpu.cfs_period_us cpu.rt_period_us  cpu.shares notify_on_release
cgroup.procs      cpu.cfs_quota_us  cpu.rt_runtime_us cpu.stat  tasks

$ cat /sys/fs/cgroup/cpu/container/cpu.cfs_quota_us
$ echo 20000 > /sys/fs/cgroup/cpu/container/cpu.cfs_quota_us
```
#### 容器镜像
1. Mount Namespace
使容器里的应用进程只能看到一份完全独立的容器自身的文件系统。
这样，它就可以在自己的容器目录（比如 /tmp）下进行操作，而完全不会受宿主机以及其他容器的影响
- Mount Namespace 修改的，是容器进程对文件系统“挂载点”的认知。
这就意味着，只有在“挂载”这个操作发生之后，进程的视图才会被改变。
而在此之前，新创建的容器会直接继承宿主机的各个挂载点
- Mount Namespace 跟其他 Namespace 的使用略有不同的地方:
它对容器进程视图的改变，一定是伴随着挂载操作（mount）才能生效
解决: 创建新进程时，除了声明要启用 Mount Namespace 之外，我们还需要重新挂载根目录
``` 
int container_main(void* arg)
{
  printf("Container - inside the container!\n");
  // 如果你的机器的根目录的挂载类型是shared，那必须先重新挂载根目录
  // mount("", "/", NULL, MS_PRIVATE, "");
  mount("none", "/tmp", "tmpfs", 0, "");
  execv(container_args[0], container_args);
  printf("Something's wrong!\n");
  return 1;
}
```
2. chroot: change root file system
在 Linux 操作系统里，chroot 命令可以改变进程的根目录到你指定的位置,
更重要的是，对于被 chroot 的进程来说，它并不会感受到自己的根目录已经被修改
```$ chroot $HOME/test /bin/bash```
3. rootfs（根文件系统）
使用Mount Namespace将操作系统的文件系统(i.e. Ubuntu16.04 的 ISO)挂载在容器根目录上、
用来为容器进程提供隔离后执行环境的文件系统，就是所谓的“容器镜像”。
- rootfs 只是一个操作系统所包含的文件、配置和目录，并不包括操作系统内核。
在 Linux 操作系统中，这两部分是分开存放的，操作系统只有在开机启动时才会加载指定版本的内核镜像。
- rootfs 里打包的不只是应用，而是整个操作系统的文件和目录，
也就意味着，应用以及它运行所需要的所有依赖，都被封装在了一起, 
- **对一个应用来说，操作系统本身才是它运行所需要的最完整的“依赖库”**
**正是由于 rootfs 的存在，容器才有了一个被反复宣传至今的重要特性:一致性**
##### 分层镜像
Docker 在镜像的设计中，引入了层（layer）的概念。
也就是说，用户制作镜像的每一步操作，都会生成一个层，也就是一个增量 rootfs
而每一层镜像是通过UnionFS联合起来的
1. UnionFS (Union File System)
最主要的功能是将多个不同位置的目录联合挂载（union mount）到同一个目录下
- Ubuntu 16.04 和 Docker CE 18.05, 默认使用的是 AuFS 这个联合文件系统的实现
- AuFS: Advance UnionFS, 它是对 Linux 原生 UnionFS 的重写和改进;
2. 容器的rootfs的组成
- 容器层: 第一部分，可读写层
它是这个容器的 rootfs 最上面的一层, 它的挂载方式为:rw，即 read write。
没有写入文件之前，目录是空的。一旦在容器里做了写操作，产生的内容就会以增量的方式出现在这个层中
删除操作实际上创建了一个名叫.wh.foo 的文件
- 第二部分，Init 层
它是一个以“-init”结尾的层，夹在只读层和读写层之间。
Init层是Docker项目单独生成的一个内部层，专门用来存放 /etc/hosts、/etc/resolv.conf等信息
需要这样一层的原因是，这些文件本来属于只读的 Ubuntu 镜像的一部分，
但是用户往往需要在启动容器时写入一些指定的值比如 hostname，所以就需要在可读写层对它们进行修改。
这些修改往往只对当前的容器有效，我们并不希望docker commit 时，把这些信息连同可读写层一起提交掉。
所以，Docker 做法是，在修改了这些文件之后，以一个单独的层挂载了出来。
- 镜像层: 第三部分，只读
是这个容器的 rootfs 基类镜像，对应 ubuntu:latest。
这一层可以包含多个layer层，都以增量的方式分别包含了 Ubuntu 操作系统的一部分
它们的挂载方式都是只读的（ro+wh，即 readonly+whiteout）
whiteout: 删除只读层里一个名叫 foo 的文件，
那么这个删除操作实际上是在可读写层创建了一个名叫.wh.foo 的文件。
这样，当这两个层被联合挂载之后，foo 文件就会被.wh.foo 文件“遮挡”起来，“消失”了。 
#### 容器案例
1. Dockerfile
- 设计思想是使用一些标准的原语（即大写高亮的词语），描述我们所要构建的 Docker 镜像。
并且这些原语，都是按顺序处理的
- **注意，Dockerfile 中的每个原语执行后，都会生成一个对应的镜像层**
- - RUN 原语就是在容器里执行 shell 命令的意思。
- - WORKDIR Dockerfile 后面的操作都以指定的目录作为当前目录 
- - CMD Dockerfile 指定这个容器的进程
- - ENTRYPOINT 和 CMD 都是 Docker 容器进程启动所必需的参数，完整执行格式是:“ENTRYPOINT CMD”
默认情况下，Docker 会为你提供一个隐含的 ENTRYPOINT，即:/bin/sh -c;
**CMD 的内容就是 ENTRYPOINT 的参数**
- - ADD 把当前目录（即 Dockerfile 所在的目录）里的文件，复制到指定容器内的目录当中
- - COPY 仅支持将本地文件复制到容器中，而 ADD还支持 本地tar提取和远程url支持
2. docker exec是怎么做到进入容器里的
- Linux Namespace 创建的隔离空间虽然看不见摸不着，
但一个进程的 Namespace 信息在宿主机上是确确实实存在的，并且是以一个文件的方式存在
```
# 当前正在运行的 Docker 容器的进程号（PID）
$ docker inspect --format '{{ .State.Pid }}'  4ddf4638572d
25686
# 25686 进程的所有 Namespace 对应的文件
$ ls -l  /proc/25686/ns
total 0
lrwxrwxrwx 1 root root 0 Aug 13 14:05 cgroup -> cgroup:[4026531835]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 ipc -> ipc:[4026532278]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 mnt -> mnt:[4026532276]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 net -> net:[4026532281]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 pid -> pid:[4026532279]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 pid_for_children -> pid:[4026532279]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 user -> user:[4026531837]
lrwxrwxrwx 1 root root 0 Aug 13 14:05 uts -> uts:[4026532277]
```
- 一个进程，可以选择加入到某个进程已有的 Namespace 当中，
从而达到“进入”这个进程所在容器的目的，这正是 docker exec 的实现原理
- 进入操作所依赖的，乃是一个名叫 setns() 的 Linux 系统调用
当前进程要加入的 Namespace 文件的路径，比如 /proc/25686/ns/net;
而第二个参数，则是你要在这个 Namespace 里运行的进程，比如 /bin/bash
3. docker commit
- 实际上就是在容器运行起来后，把最上层的“可读写层”，加上原先容器镜像的只读层，
打包组成了一个新的镜像。下面这些只读层在宿主机上是共享的，不会占用额外的空间。
- 而由于使用了联合文件系统，你在容器里对镜像 rootfs 所做的任何修改，
都会被操作系统先复制到这个可读写层，然后再修改。这就是所谓的:Copy-on-Write。
- Init 层的存在，就是为了避免你执行 docker commit 时，
把 Docker 自己对 /etc/hosts 等文件做的修改，也一起提交掉
4. Volume（数据卷）
Volume 机制，允许你将宿主机上指定的目录或者文件，挂载到容器里面进行读取和修改操作
```
$ docker run -v /test ...
$ docker run -v /home:/test ...
```
- 当容器进程被创建之后，尽管开启了 Mount Namespace，
但是在它执行 chroot（或者 pivot_root）之前，容器进程一直可以看到宿主机上的整个文件系统。
- 所以，我们只需要在 rootfs 准备好之后，在执行 chroot 之前，把 Volume 指定的宿主机目录(/home)，
挂载到指定的容器目录（/test）在宿主机上对应的目录
（即 /var/lib/docker/aufs/mnt/[可读写层 ID]/test）上，这个 Volume 的挂载工作就完成了
- 更重要的是，由于执行这个挂载操作时，“容器进程”已经创建了，
也就意味着此时 Mount Namespace 已经开启了。所以，这个挂载事件只在这个容器里可见。
你在宿主机上，是看不见容器内部的这个挂载点的。这就保证了容器的隔离性不会被 Volume 打破
- 容器进程，是 Docker 创建的一个容器初始化进程 (dockerinit)，而不是应用进程 (ENTRYPOINT + CMD)
- 而这里要使用到的挂载技术，就是 Linux 的绑定挂载（bind mount）机制。
它的主要作用就是，允许你将一个目录或者文件，而不是整个设备，挂载到一个指定的目录上。
并且，这时你在该挂载点上进行的任何操作，只是发生在被挂载的目录或者文件上，
而原挂载点的内容则会被隐藏起来且不受影响, 绑定挂载实际上是一个 inode 替换的过程。
- 由于 Mount Namespace 的隔离作用，宿主机并不知道这个绑定挂载的存在。
在宿主机看来，容器中可读写层的/test目录（/var/lib/docker/aufs/mnt/[可读写层 ID]/test），始终是空的