class Cls(object):
    def foo(self):
        print('foo in class')
        self.bar()
    def bar(self):
        print('bar in class')
cls = Cls() 
cls.foo()
 