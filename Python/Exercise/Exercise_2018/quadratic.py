#!/usr/bin/python3
# solve problem ax**2 + bx + c = 0

# complex math module
import cmath
print('solve the quadratic equation ax**2 + bx + c =0')


def solveqdeq(a, b, c):
    a = float(a)
    b = float(b)
    c = float(c)

    d = b**2 - 4*a*c
    if d < 0:
        return('error: b**2 < 4*a*c')

    s1 = (-b-cmath.sqrt(d))/(2*a)
    s2 = (-b+cmath.sqrt(d))/(2*a)

    return("{0}x**2 + {1}x + {2} = 0: x1 = {3}, x2 = {4}".format(a, b, c, float(s1), float(s2)))
