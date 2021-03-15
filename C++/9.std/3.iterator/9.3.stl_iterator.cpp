#include <iostream>
#include <list>
using namespace std;

int main()
{
    // STL iterator
    // 迭代器是一种smart pointer, 用于访问顺序容器和关联容器中的元素
    // 相当于容器和操作容器的算法的之间的中介
    cout << " std iterator " << endl;
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