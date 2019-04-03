#!/usr/bin/env python
# -*- coding: utf-8 -*-

import requests  # pip install requests
import json
import execjs  # pip install PyExecJS
import urllib3  # pip install urllib3

'''
author by Benji
date at 2018.12.07

实现: 模拟浏览器中Google翻译的url请求
    不同于Baidu直接给出API, Google翻译需要调用其封装的lib

参考:   https://www.jianshu.com/p/95cf6e73d6ee
        https://cloud.google.com/translate/docs/apis

'''


class PyJsParams():
    def __init__(self):
        self.ctx = execjs.compile("""
        function TL(a) {
        var k = "";
        var b = 406644;
        var b1 = 3293161072;
        var jd = ".";
        var $b = "+-a^+6";
        var Zb = "+-3^+b+-f";
        for (var e = [], f = 0, g = 0; g < a.length; g++) {
            var m = a.charCodeAt(g);
            128 > m ? e[f++] = m : (2048 > m ? e[f++] = m >> 6 | 192 : (55296 == (m & 64512) && g + 1 < a.length && 56320 == (a.charCodeAt(g + 1) & 64512) ? (m = 65536 + ((m & 1023) << 10) + (a.charCodeAt(++g) & 1023),
            e[f++] = m >> 18 | 240,
            e[f++] = m >> 12 & 63 | 128) : e[f++] = m >> 12 | 224,
            e[f++] = m >> 6 & 63 | 128),
            e[f++] = m & 63 | 128)
        }
        a = b;
        for (f = 0; f < e.length; f++) a += e[f],
        a = RL(a, $b);
        a = RL(a, Zb);
        a ^= b1 || 0;
        0 > a && (a = (a & 2147483647) + 2147483648);
        a %= 1E6;
        return a.toString() + jd + (a ^ b)
    };
    function RL(a, b) {
        var t = "a";
        var Yb = "+";
        for (var c = 0; c < b.length - 2; c += 3) {
            var d = b.charAt(c + 2),
            d = d >= t ? d.charCodeAt(0) - 87 : Number(d),
            d = b.charAt(c + 1) == Yb ? a >>> d: a << d;
            a = b.charAt(c) == Yb ? a + d & 4294967295 : a ^ d
        }
        return a
    }
    """)

    def getTk(self, text):
        return self.ctx.call("TL", text)


def buildUrl(text, tk):
    baseUrl = 'https://translate.google.com/translate_a/single?client=webapp&'
    baseUrl += '&sl=auto&tl=' + toLang
    baseUrl += '&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&source=btn&ssel=0&tsel=0&kc=0&'
    baseUrl += 'tk='+str(tk)+'&'
    baseUrl += 'q='+text
    return baseUrl


def translate(text, jsParas):
    url = buildUrl(text, jsParas.getTk(text))
    try:
        # 添加headers, 模仿浏览器行为
        headers = requests.utils.default_headers()
        headers['User-Agent'] = 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36'
        # https://urllib3.readthedocs.io/en/latest/advanced-usage.html#ssl-warnings
        urllib3.disable_warnings()
        # solve: SSL: CERTIFICATE_VERIFY_FAILED] certificate verify failed: unable to get local issuer certificate
        r = requests.get(url, headers=headers, verify=False)
        result = json.loads(r.text)
        res = str(result[0][0][0])
    except Exception as e:
        res = ''
        print("翻译"+text+"失败")
        print("错误信息:")
        print(e)
    finally:
        return res


toLang = 'en'

if __name__ == '__main__':
    jsParas = PyJsParams()
    res = translate('小顺子给春宫娘娘请安了', jsParas)
    print(res)

'''
output
Xiaoshun gave the Spring Palace girl an appointment.
'''
