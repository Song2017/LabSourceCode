1. Role 对象指定了它能产生作用的 Namepace
这仅限于逻辑上的“隔离”，Namespace 并不会提供任何实际的隔离或者多租户能力。
而在前面文章中用到的大多数例子里，我都没有指定 Namespace，那就是使用的是默认 Namespace：default。
2. 被作用者就需要通过 RoleBinding 来实现
RoleBinding 对象里定义了一个 subjects 字段，即“被作用者”

1. Role 想要作用于所有的 Namespace
ClusterRole 和 ClusterRoleBinding 这两个组合了。
这两个 API 对象的用法跟 Role 和 RoleBinding 完全一样。只不过，它们的定义里，没有了 Namespace 字段

1. 这个由 Kubernetes 负责管理的“内置用户”，正是我们前面曾经提到过的：ServiceAccount。

1. exec
$ kubectl create -f svc-account.yaml
$ kubectl create -f role-binding.yaml

$ kubectl create -f role.yaml
$ kubectl get sa -n default -o yaml

$ kubectl create -f pod-sa.yaml
$ kubectl describe pod sa-token-test -n default 
$ kubectl exec -it sa-token-test -n default -- /bin/bash
root@sa-token-test:/# ls /var/run/secrets/kubernetes.io/serviceaccount
ca.crt namespace  token