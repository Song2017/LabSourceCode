# fibonacci numbers module 
def fib(n):
    '''write Fibonacci series up to n'''
    print('fib. __name__', __name__)
    a, b = 0, 1
    while b < n:
        print(b, end=' ')
        a, b = b, a+b
    print()


def fib_ary(n):
    '''return Fibonacci series up to n'''
    print('fib_ary. __name__', __name__)
    a, b = 0, 1
    ary_fibo = []
    while b < n:
        ary_fibo.append(b)
        a, b = b, a+b
    return ary_fibo


if __name__ == "__main__":
    import sys
    fib(int(sys.argv[1]))
