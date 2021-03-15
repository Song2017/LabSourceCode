#include <iostream>
#include <vector>
#include <stack>
#include <map>
#include <string>
using namespace std;

struct Display
{
    void operator()(int i)
    {
        cout << i << endl;
    };
};

struct DisplayMap
{
    void operator()(pair<string, float> p)
    {
        cout << p.first << ", " << p.second << endl;
    };
};

template <class T>
bool MySortT(T const &a, T const &b)
{
    return a < b;
};
template <class T>
inline void DisplayT(T const &a)
{
    cout << a << ", " << endl;
};
template <class T>
struct MySortFunT
{
    inline bool operator()(T const &a, T const &b) const
    {
        return a > b;
    };
};
template <class T>
struct DisplayFunT
{
    inline void operator()(T const &i)
    {
        cout << i << endl;
    };
};

int main()
{
    // STL standard template library
    // 1. stl算法是泛型的, 不与特定的数据结构和对象绑定,
    // 6个组件: 空间配置器, 容器, 迭代器, 适配器, 仿函数, 算法
    cout << " std lib " << endl;

    // 容器
    // 序列式容器 vector, list, deque,  容器适配器: stack, queue, priority_queue
    // 关联式容器 set, multiset, map, multimap

    int iArr[] = {1, 2, 3, 4, 5};
    vector<int> iVector(iArr, iArr + 4);
    deque<int> iDeque(iArr, iArr + 4);
    stack<int> iStack(iDeque);
    for_each(iVector.begin(), iVector.end(), Display());
    while (!iStack.empty())
    {
        cout << iStack.top() << endl;
        iStack.pop();
    };

    map<string, float> stuScores;
    stuScores["zhangsan"] = 99.9;
    stuScores.insert(pair<string, float>("lisi", 90.1));
    stuScores.insert(pair<string, float>("wangwu", 80.1));
    stuScores.insert(pair<string, float>("wanger", 60));
    stuScores.insert(pair<string, float>("liliu", 50));
    for_each(stuScores.begin(), stuScores.end(), DisplayMap());
    cout << endl;

    map<string, float>::iterator iter;
    iter = stuScores.find("lisi");
    if (iter != stuScores.end())
    {
        cout << "Found lisi: " << iter->second << endl;
    }
    iter = stuScores.begin();
    while (iter != stuScores.end())
    {
        if (iter->second < 60)
        {
            stuScores.erase(iter++);
        }
        else
        {
            iter++;
        }
    }

    for_each(stuScores.begin(), stuScores.end(), DisplayMap());
    cout << endl;

    for (iter = stuScores.begin(); iter != stuScores.end(); iter++)
    {
        if (iter->second < 70)
        {
            iter = stuScores.erase(iter++); // 注意：迭代器失效问题
        }
    }
    for_each(stuScores.begin(), stuScores.end(), DisplayMap());
    cout << endl;

    // 仿函数使用
    // inline: 代码替换, 而不是创建函数
    int iArr2[] = {122, 12, 3, 84, 5};
    // 模版
    sort(iArr2, iArr2 + 5, MySortT<int>); // 偏移量
    for_each(iArr2, iArr2 + 5, DisplayT<int>);
    // 仿函数模版
    sort(iArr2, iArr2 + 5, MySortFunT<int>()); // 偏移量
    for_each(iArr2, iArr2 + 5, DisplayFunT<int>());
}