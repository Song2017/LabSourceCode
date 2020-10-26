#include <iostream>
#include <vector>
#include <stack>
#include <map>
#include <string>
#include <algorithm>
#include <functional>
#include <numeric>
using namespace std;

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

}