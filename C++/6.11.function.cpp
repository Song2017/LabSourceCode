#include <iostream>
#include <math.h>

using namespace std;

namespace space_test
{
    int test(int a)
    {
        return a;
    }
} // namespace space_test

int test(int a)
{
    return a;
}
int test(int a, double b = 2.0)
{
    return a;
}
int MinValue(int a, int b)
{
    return (a > b) ? b : a;
}
int MaxValue(int a, int b)
{
    return (a > b) ? a : b;
}
int ProcessNum(int a, int b, int (*p)(int a, int b))
{
    int result = (*p)(a, b);
    cout << result << endl;
    return result;
}

int main()
{
    // 函数
    // 1. 函数的组成部分: 返回类型, 函数名称, 参数, 函数主体
    // 函数体: 包含一组定义函数执行任务的语句
    // 函数重载: 函数名相同但是参数的个数或类型有差异
    // 2. 函数指针
    int (*p)(int);
    p = test;
    int result = (*p)(1);
    cout << result << endl;
    // 指向函数的指针和返回指针的函数
    // 函数指针: 每个函数占用一段内存单元, 指向函数入口地址的指针称为函数指针
    // int (*p)(int);
    // 返回指针的函数, 返回的值是指针: int* p(int)
    // 3. 回调函数 int ProcessNum(int a, int b, int (*p)(int a, int b))
    ProcessNum(1, 2, MinValue);
    ProcessNum(1, 2, MaxValue);
    // 4. 命名空间, 本质上是划分了一个范围
    result = space_test::test(123);
    cout << "name space:" << result << endl;
    return 0;
}
