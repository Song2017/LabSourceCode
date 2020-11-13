# g++ -fpic -shared -o lib_test.so foo.cpp
from ctypes import cdll
lib = cdll.LoadLibrary("./lib_test.so")


class Foo:
    def __init__(self):
        self.obj = lib.Foo_new()

    def bar(self):
        lib.Foo_bar(self.obj)


if __name__ == "__main__":
    foo = Foo()
    foo.bar()
