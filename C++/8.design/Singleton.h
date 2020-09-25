#pragma once
#include <iostream>
using namespace std;

class Singleton
{
public:
    static const Singleton *getInstance();
    // private 访问外部实例化
    static void DoSomething()
    {
        cout << "do something" << endl;
    }

private:
    Singleton();
    ~Singleton();
    // static修饰的静态变量位于全局区, 解决资源的分配和释放, 不受堆栈, 多线程资源争用的影响
    static Singleton *This;
};