#include <iostream>
#include <vector>
#include <stack>
#include <map>
#include <string>
#include <algorithm>
#include <functional>
#include <numeric>
using namespace std;

// 输入一个不存在重复字符的字符串，打印出字符串中字符的全排列。
//比如：  "123"   3*2*1 = 3!
// 传递引用, 指针, 修改原来的值
void swap(char *a, char *b)
{
    char temp = *a;
    *a = *b;
    *b = temp;
}
void Permutation(char *pStr, char *pPosition)
{
    // 基准点
    if (*pPosition == '\0')
    {
        cout << pStr << ". ";
    }

    for (char *pChar = pPosition; *pChar != '\0'; pChar++)
    {
        // f(123) = 1+f(23), f(23) = 2+f(3), f(3)  = 3  递归
        swap(*pChar, *pPosition);
        Permutation(pStr, pPosition + 1);
        swap(*pChar, *pPosition);
    }
};

int main()
{
    // STL standard template library algrithm
    // 所在类包: #include <algorithm> #include <functional> #include <numeric>
    // 分类: 1. 非可变序列算法: 不修改所操作的容器内容
    //      2. 可变序列算法: 修改所操作的容器内容
    //      3. 排序算法: 对序列进行排序和合并, 搜索及有序序列上的集合操作
    //      2. 数值算法: 对容器内容进行数值计算
    cout << " std lib " << endl;

    // transform
    int ones[] = {1, 2, 3, 4, 5};
    int twos[] = {11, 12, 13, 14, 15};
    int results[5];
    transform(ones, ones + 5, twos, results, std::plus<int>());
    // lambda表达式, 匿名函数 没有名字的小函数, c++ 11 后继承
    for_each(results, results + 5,
             [](int a) -> void { cout << a << endl; });

    // 全排列
    cout << "Permutation " << endl;
    char test0[] = "123";
    Permutation(test0, test0);
    cout << endl;
    cout << " next_permutation 初始值要有顺序 " << endl;
    char test[] = "231";
    do
    {
        cout << test[0] << ". " << test[1] << ". " << test[2] << endl;
    } while (next_permutation(test, test + 3));

    cout << " end " << endl;
}