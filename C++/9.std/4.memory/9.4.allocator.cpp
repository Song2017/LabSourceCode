#include <iostream>
#include <list>
using namespace std;

int main()
{
    // 空间配置器 allocator

    cout << " allocator " << endl;
    cout << " allocator 可以体现c++再性能和资源管理上的优化思想" << endl;
    list<int> v;
    v.push_back(3);
    v.push_back(4);
    v.push_front(2);
    v.push_front(1);
    list<int>::const_iterator it;
    // list<int>::iterator it; 可修改值
    // !!! 迭代器不支持 >, <,  wrong: it > v.end()
    for (it = v.begin(); it != v.end(); it++)
    {
        cout << *it << " ";
    }
    list<int>::reverse_iterator it2;
    for (it2 = v.rbegin(); it2 != v.rend(); it2++)
    {
        cout << *it2 << " ";
    }
    cout << " end " << endl;
}