# pip3 install pybind11
import pydemo


def add_test(a, b):
    return pydemo.add(a, b)


def class_test():
    class Cat(pydemo.Animal):
        def go(self, times):
            return "miao!" * times

    cat = Cat()
    print("cat.go(5)", cat.go(5))
    print("pydemo.call_go(cat)", pydemo.call_go(cat))


if __name__ == "__main__":

    print(add_test(3, 4))
    print(pydemo.use_str("string in python"))
    print(pydemo.use_tuple((1, 22, "third")))
    print(pydemo.use_list([1, 2, 3]))
    class_test()
