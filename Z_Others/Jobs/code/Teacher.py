from cached_property import cached_property, threaded_cached_property


class Singleton(type):
    """
    An metaclass for singleton purpose.
    Every singleton class should inherit from this class by
        'metaclass=Singleton'
    """
    _instances = {}

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = \
                super(Singleton, cls).__call__(*args, **kwargs)
        import pdb
        pdb.set_trace()
        return cls._instances[cls]

class Class:
    name = "test"
class Teacher():
    _id = 'xxx'

    def __init__(self):
        print("init")

    @threaded_cached_property
    def id(self):
        cla = Class()
        return cla

    @cached_property
    def id2(self):
        cla = self.id
        cla.name="222"
        return cla


if __name__ == "__main__":
    s = Teacher()
    # print("call1", s())

    print(id(s.id.name), s.id.name)
    print(id(s.id2.name), s.id2.name)
    # s._id = '***'
    # print(s.id)
    # print(s.id2)
    # # print("call2", s())

    # s = Teacher()
    # print("---" * 10)
    # print(s.id)
    # print(s.id2)
