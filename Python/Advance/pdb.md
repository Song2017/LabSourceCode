1. 单步执行代码,通过命令 `python -m pdb xxx.py` 启动脚本，进入单步执行模式
2. 直接在代码里需要调试的地方放一个 `import pdb; pdb.set_trace()`，就可以设置一个断点， 
程序会在pdb.set_trace()暂停并进入pdb调试环境，可以用pdb 变量名查看变量，或者c继续运行    
3. vars(): 查看当前上下文
4. dir(Object): 获得对象的所有属性和方法
pdb命令行：
```
    常用
    w：（where）打印当前执行堆栈
    s：（step）执行下一条命令
            如果本句是函数调用，则s会执行到函数的第一句
    n：（next）执行下一条语句
            如果本句是函数调用，则执行函数，接着执行当前执行语句的下一条。
    r：（return）执行当前运行函数到结束
    c：（continue）继续执行，直到遇到下一条断点
    l：（list）列出源码
                l 列出当前执行语句周围11条代码
                l first 列出first行周围11条代码
    a：（args）列出当前执行函数的函数
    
    少用
    h：（help）帮助
    d：（down）执行跳转到在当前堆栈的深一层（个人没觉得有什么用处）
    u：（up）执行跳转到当前堆栈的上一层
    b：（break）添加断点
              b 列出当前所有断点，和断点执行到统计次数
              b line_no：当前脚本的line_no行添加断点
              b filename:line_no：脚本filename的line_no行添加断点
              b function：在函数function的第一条可执行语句处添加断点
    tbreak：（temporary break）临时断点
              在第一次执行到这个断点之后，就自动删除这个断点，用法和b一样
    cl：（clear）清除断点
             cl 清除所有断点
             cl bpnumber1 bpnumber2... 清除断点号为bpnumber1,bpnumber2...的断点
             cl lineno 清除当前脚本lineno行的断点
             cl filename:line_no 清除脚本filename的line_no行的断点
    disable：停用断点，参数为bpnumber，和cl的区别是，断点依然存在，只是不启用
    enable：激活断点，参数为bpnumber
    p expression：（print）输出expression的值
    pp expression：好看一点的p expression
    run：重新启动debug，相当于restart
    q：（quit）退出debug
    j lineno：（jump）设置下条执行的语句函数
            只能在堆栈的最底层跳转，向后重新执行，向前可直接执行到行号
    unt：（until）执行到下一行（跳出循环），或者当前堆栈结束
 
 
    注意：

    1：直接输入Enter，会执行上一条命令；
    2：输入PDB不认识的命令，PDB会把他当做Python语句在当前环境下执行；
```
