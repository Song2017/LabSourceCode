class Teacher:
    _id = '123'

    def worker_id(self):
        return self._id

    def worker_id_number(self):
        return self._id

    def worker_id_cached(self):
        return self._id


if __name__ == "__main__":
    s = Teacher()
    s._id = "345"
    assert s.worker_id() == "345"
    assert s.worker_id_number == "345"
    assert s.worker_id_cached == "345"

    s._id = "678"
    assert s.worker_id_number == "678"
    assert s.worker_id_cached == "345"
