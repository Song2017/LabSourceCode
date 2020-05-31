#  MRO method resolution order (方法解释顺序)：C3算法,
# 		        没有共同祖先时, 类似深度优先
# 		        有共同祖先时,先进行深度优先查找,查到共同祖先就返回进行广度优先

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
print(F.__mro__)
# A
# B C
# D E
# F
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

class F(E, D):
    def __init__(self):
        print('enter F')
        super().__init__()
        print('leave F')
print(F.__mro__)