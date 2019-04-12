#!/usr/bin/env python
# -*- coding: utf-8 -*-
from datetime import datetime


def squareByTaylor(num, precise=2):
    '''
    根据泰勒展开式计算平方根
    precise:正整数
    负数返回复数集
    '''
    appendix = ''
    if num == 0:
        return 0
    if num == -1:
        return 'i'
    if num < 0:
        num = -num
        appendix = ' i'
    if precise < 0:
        precise = 2

    result, preresult = 1, 0
    while abs(result - preresult) > 0.1 ** precise:
        preresult = result
        result = (result + num / result) / 2
    return str(result) + appendix


def squareByBinary(num, precise=2):
    '''
    根据二分法逼近答案
    precise应该是正整数
    负数返回复数集
    '''
    appendix = ''
    if num == 0:
        return 0
    if num == -1:
        return 'i'
    if num < 0:
        num = -num
        appendix = ' i'
    if precise < 0:
        precise = 2
    result, preresult = num/2, 0
    while abs(result**2 - num) > 0.1 ** precise:
        if result**2 > num:
            result = (result + preresult) / 2
        elif result**2 < num:
            preresult, result = result,  (result + num) / 2

    return str(result) + appendix


if __name__ == '__main__':
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('squareByTaylor:', squareByTaylor(32, 5))
    print(datetime.now().strftime('%H:%M:%S.%f'))
    print('squareByTaylor:', squareByBinary(32, 5))
    print(datetime.now().strftime('%H:%M:%S.%f'))
