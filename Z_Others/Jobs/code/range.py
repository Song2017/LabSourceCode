import copy


def get_range(n, last_range, cnt=0):
    if n == 0:
        print(last_range)
        return
    for i in ["a", "b", "c", "d", "e"]:
        get_range(n - 1, copy.deepcopy(last_range) + i, cnt + 1)


if __name__ == "__main__":
    get_range(5, '')