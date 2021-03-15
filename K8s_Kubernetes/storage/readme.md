## Kubernetes 项目处理容器持久化存储的核心原理
1. PVC 描述的，是 Pod 想要使用的持久化存储的属性，比如存储的大小、读写权限等。
2. PV 描述的，则是一个具体的 Volume 的属性，比如 Volume 的类型、挂载目录、远程存储服务器地址等。
3. 而 StorageClass 的作用，则是充当 PV 的模板。并且，只有同属于一个 StorageClass 的 PV 和 PVC，才可以绑定在一起。
当然，StorageClass 的另一个重要作用，是指定 PV 的 Provisioner（存储插件）。
这时候，如果你的存储插件支持 Dynamic Provisioning 的话，Kubernetes 就可以自动为你创建 PV 了。
Dynamic Provisioning 机制工作的核心，在于一个名叫 StorageClass 的 API 对象。
    PV 和 PVC 的 YAML 文件之后，Kubernetes 就会根据它们俩的属性，以及它们指定的 StorageClass 来进行绑定。
    只有绑定成功后，Pod 才能通过声明这个 PVC 来使用对应的 PV

## 整体流程
用户提交请求创建pod，Kubernetes发现这个pod声明使用了PVC，那就靠PersistentVolumeController帮它找一个PV配对。
没有现成的PV，就去找对应的StorageClass，帮它新创建一个PV，然后和PVC完成绑定。
新创建的PV，还只是一个API 对象，需要经过“两阶段处理”变成宿主机上的“持久化 Volume”才真正有用：
    第一阶段Attach, 由运行在master上的AttachDetachController负责，为这个PV完成 Attach 操作，为宿主机挂载远程磁盘；
    第二阶段Mount, 是运行在每个节点上kubelet组件的内部，把第一步attach的远程磁盘 mount 到宿主机目录。
        这个控制循环叫VolumeManagerReconciler，运行在独立的Goroutine，不会阻塞kubelet主循环。
完成这两步，PV对应的“持久化 Volume”就准备好了，POD可以正常启动，将“持久化 Volume”挂载在容器内指定的路径。


## Local Persistent Volume 本地持久化存储
Local Persistent Volume 的应用必须具备数据备份和恢复的能力
1. 如何把本地磁盘抽象成 PV: 一个 PV 一块盘
不应该把一个宿主机上的目录当作 PV 使用。这是因为，这种本地目录的存储行为完全不可控
2. 调度器如何保证 Pod 始终能被正确地调度到它所请求的 Local Persistent Volume 所在的节点
在调度的时候考虑 Volume 分布。在 Kubernetes 的调度器里，有一个叫作 VolumeBindingChecker 的过滤条件专门负责
本地持久化存储是跟node绑定的, 所以要先确定pod执行所在的node, 然后找到对应的pv
Local Persistent Volume 里一个非常重要的特性，即：延迟绑定, volumeBindingMode=WaitForFirstConsumer
实时发生的 PVC 和 PV 的绑定过程，就被延迟到了 Pod 第一次调度的时候在调度器中进行，从而保证了这个绑定结果不会影响 Pod 的正常调度
3. 要注意的是，我们上面手动创建 PV 的方式，即 Static 的 PV 管理方式，在删除 PV 时需要按如下流程执行操作：
    删除使用这个 PV 的 Pod；从宿主机移除本地磁盘（比如，umount 它）；删除 PVC；删除 PV


## 存储插件的开发有两种方式：FlexVolume 和 CSI
1. FlexVolume
PV 被创建后，一旦和某个 PVC 绑定起来，这个 FlexVolume 类型的 Volume 就会进入“两阶段处理”，即“Attach 阶段”和“Mount 阶段”
它们的主要作用，是在 Pod 所绑定的宿主机上，完成这个 Volume 目录的持久化过程
实际上调用的 就是 pkg/volume/flexvolume 这个目录里的代码 SetUpAt()
SetUpAt() 实际上只做了一件事，那就是封装出了一行命令（即：NewDriverCall），由 kubelet 在“Mount 阶段”去执行
`/usr/libexec/kubernetes/kubelet-plugins/volume/exec/k8s~nfs/nfs mount <mount dir> <json param>`
当你编写完了 FlexVolume 的实现之后，一定要把它的可执行文件放在每个节点的插件目录下, 可执行文件可以是 shell 
kubelet 的 VolumeManagerReconcile 控制循环里的一次mount 阶段的“调谐”操作的执行流程
```
kubelet --> pkg/volume/flexvolume.SetUpAt() --> 
/usr/libexec/kubernetes/kubelet-plugins/volume/exec/k8s~nfs/nfs mount <mount dir> <json param>
```
局限 FlexVolume 每一次对插件可执行文件的调用，都是一次完全独立的操作

1. CSI  Container Storage Interface
CSI 的设计思想，把插件的职责从“两阶段处理”，扩展成了 Provision、Attach 和 Mount 
Provision 等价于“创建磁盘”，
Attach 等价于“挂载磁盘到虚拟机”，
Mount 等价于“将该磁盘格式化后，挂载在 Volume 的宿主机目录上”。
External Components
    Driver Registrar 组件，负责将插件注册到 kubelet 里面, 将可执行文件放在插件目录下
    External Provisioner 组件，负责的正是 Provision 阶段。监听（Watch）了 APIServer 里的 PVC 对象。
        当一个 PVC 被创建时，它就会调用 CSI Controller 的 CreateVolume 方法，为你创建对应 PV
    External Attacher 组件，负责的正是“Attach 阶段”. 监听了 APIServer 里 VolumeAttachment 对象的变化。
    VolumeAttachment 对象是 Kubernetes 确认一个 Volume 可以进入“Attach 阶段”的重要标志
CSI 插件的里三个服务：CSI Identity、CSI Controller 和 CSI Node
CSI 插件的 CSI Identity 服务，负责对外暴露这个插件本身的信息
CSI Controller 服务，定义的则是对 CSI Volume（对应 Kubernetes 里的 PV）的管理接口
    CSI Controller 服务里定义的这些操作都无需在宿主机上进行, 实际调用者是 External Provisioner 和 External Attacher
CSI Node 的服务都需要在宿主机上执行的操作
    “Mount 阶段”在 CSI Node 里的接口，是由 NodeStageVolume 和 NodePublishVolume 两个接口共同实现的