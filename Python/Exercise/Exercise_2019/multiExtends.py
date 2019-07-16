class A():
    def __init__(self):
        print('enter A')
        print('leave A')


class B(A):
    def __init__(self):
        print('enter B')
        super().__init__()
        print('leave B')


class C(A):
    def __init__(self):
        print('enter C')
        super().__init__()
        print('leave C')


class D(B):
    def __init__(self):
        print('enter D')
        super().__init__()
        print('leave D')


class E(C):
    def __init__(self):
        print('enter E')
        super().__init__()
        print('leave E')


class F(D, E):
    def __init__(self):
        print('enter F')
        super().__init__()
        print('leave F')

# 深度遍历优先
F()
# enter F
# enter D
# enter B
# enter E
# enter C
# enter A
# leave A
# leave C
# leave E
# leave B
# leave D
# leave F