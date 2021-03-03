# minikube
## Deployment
Deployment 是管理 Pod 创建和扩展的推荐方法。
1. minikube start / minikube start --vm=true
2. minikube dashboard
2. kubectl create deployment hello-node --image=k8s.gcr.io/echoserver:1.4
3. kubectl get deployments
Kubernetes Deployment  检查 Pod 的健康状况，并在 Pod 中的容器终止的情况下重新启动新的容器
4. kubectl get pods
Kubernetes Pod 是由一个或多个 为了管理和联网而绑定在一起的容器构成的组。 
5. kubectl get events
6. kubectl config view
## Service
要使得 hello-node 容器可以从 Kubernetes 虚拟网络的外部访问，你必须将 Pod 暴露为 Kubernetes Service。
1. kubectl expose deployment hello-node --type=LoadBalancer --port=8080
kubectl expose 命令将 Pod 暴露给公网
2. kubectl get services
查看你刚刚创建的 Service
3. minikube service hello-node
对于支持负载均衡器的云服务平台而言，平台将提供一个外部 IP 来访问该服务。 在 Minikube 上，LoadBalancer 使得服务可以通过命令 minikube service 访问
## 插件
1. minikube addons list
列出当前支持的插件
2. minikube addons enable metrics-server
启用插件
3. kubectl get pod,svc -n kube-system
查看刚才创建的 Pod 和 Service：
## 清理
1. 现在可以清理你在集群中创建的资源：
kubectl delete service hello-node
kubectl delete deployment hello-node
2. 停止 Minikube 虚拟机（VM）：
minikube stop
3. 删除 Minikube 虚拟机（VM）：
minikube delete

