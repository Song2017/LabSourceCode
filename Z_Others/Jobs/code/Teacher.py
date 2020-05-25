from cached_property import cached_property


class Teacher:
    _id = 'xxx'

    @cached_property
    def id(self):
        return self._id

    @property
    def id2(self):
        return self._id


if __name__ == "__main__":
    s = Teacher()
    print(s.id)
    print(s.id2)
    s._id = '***'
    print(s.id)
    print(s.id2)
