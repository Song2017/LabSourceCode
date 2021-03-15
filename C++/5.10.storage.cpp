#include <iostream>
#include <vector>
#include <string>

using namespace std;

int a = 0; //(GVAR)全局初始化区
int *p1;   //(bss)全局未初始化区
void Test_unique_ptr()
{
    { // 在这个范围之外，unique_ptr被释放
        auto i = unique_ptr<int>(new int(10));
        cout << *i << endl;
    };
    // unique_ptr
    auto w = std::make_unique<int>(10);
    cout << *(w.get()) << endl; // 10
    //auto w2 = w; // 编译错误如果想要把 w 复制给 w2, 是不可以的。
    //  因为复制从语义上来说，两个对象将共享同一块内存。
    // unique_ptr 只支持移动语义, 即如下
    auto w2 = std::move(w);                                     // w2 获得内存所有权，w 此时等于 nullptr
    cout << ((w.get() != nullptr) ? (*w.get()) : -1) << endl;   // -1
    cout << ((w2.get() != nullptr) ? (*w2.get()) : -1) << endl; // 10
};
void Test_shared_ptr()
{
    //shared_ptr 代表的是共享所有权，即多个 shared_ptr 可以共享同一块内存。
    auto wA = shared_ptr<int>(new int(20));
    {
        auto wA2 = wA;
        cout << ((wA2.get() != nullptr) ? (*wA2.get()) : -1) << endl; // 20
        cout << ((wA.get() != nullptr) ? (*wA.get()) : -1) << endl;   // 20
        cout << wA2.use_count() << endl;                              // 2
        cout << wA.use_count() << endl;   a                            // 2
    }
    //cout << wA2.use_count() << endl;
    cout << wA.use_count() << endl;                             // 1
    cout << ((wA.get() != nullptr) ? (*wA.get()) : -1) << endl; // 20
};
// weak_ptr 是为了解决 shared_ptr 双向引用的问题。
struct BW;
struct AW
{
    shared_ptr<BW> pb;
    ~AW()
    {
        cout << "~AW()" << endl;
    }
};
struct BW
{
    weak_ptr<AW> pa;
    ~BW()
    {
        cout << "~BW()" << endl;
    }
};

void Test_weak_ptr()
{
    cout << "Test weak_ptr and shared_ptr:  " << endl;
    shared_ptr<AW> tA(new AW());
    shared_ptr<BW> tB(new BW());
    cout << tA.use_count() << endl; // 1
    cout << tB.use_count() << endl; // 1
    tA->pb = tB;
    tB->pa = tA;
    cout << tA.use_count() << endl; // 1
    cout << tB.use_count() << endl; // 2
};

// 编写一个函数，输入两个int型变量a,b
// 实现在函数内部将a,b的值进行交换。
void swap(int &a, int &b)
{
    int tmp = a;
    a = b;
    b = tmp;
};
int main()
{
    cout << "计算机中的存储区域"
         << "栈: 先进后出"
         << "队列: 先进先出" << endl;

    int b = 1;              //(stack)栈区变量
    char s[] = "abc";       //(stack)栈区变量
    int *p2 = NULL;         //(stack)栈区变量
    char *p3 = "123456";    //123456\0在常量区, p3在(stack)栈区
    static int c = 0;       //(GVAR)全局(静态)初始化区
    p1 = new int(10);       //(heap)堆区变量
    p2 = new int(20);       //(heap)堆区变量
    char *p4 = new char[7]; //(heap)堆区变量
    // strcpy_s(p4, 7, "123456"); //(text)代码区

    //(text)代码区
    if (p1 != NULL)
    {
        delete p1;
        p1 = NULL;
    }
    if (p2 != nullptr)
    {
        delete p2;
        p2 = NULL;
    }
    if (p4 != NULL)
    {
        delete[] p4;
        p4 = NULL;
    }
    // 从高地址到低地址
    // 栈 系统, 编译器分配, 分配顺序从高到低, 函数体内 {}
    // 待分配空间
    // 堆 程序分配, c++考虑内存回收 delete 从低到高, 整个程序范围 new -> delete
    // 常量区 内容不可变的
    // 全局未初始化区
    // 全局初始化区
    // 代码区

    // 堆 heap 动态分配资源
    // 动态内存带来不确定性: 分配耗时, 实时性低
    // 内存管理器的三个操作: c++ 1,2; java 1,3
    // 1, 分配一个内存块; 2, 释放一个内存块; 3, 垃圾回收操作

    // RAII 资源管理方式 Resource Acquistion Is Initialization
    // 通过栈和析构函数来管理所有的资源, 包括堆内存

    // 内存泄漏问题 Memory Leak
    // 堆内存由于程序原因未释放或无法释放, 造成系统内存的浪费

    // 智能指针 std:shared_ptr, std:weak_ptr
    // C++ 11判断指针是否为空 nullptr, 区别NULL(C)的二义性
    
    // auto_ptr: auto_ptr	C++ 17中移除	拥有严格对象所有权语义的智能指针
    //      auto_ptr对象销毁时, 管理的对象也会自动delete
    //      所有权转移, 被管理对象被传递给另外的智能指针后, 原来的指针就不再拥有这个对象了
    // unique_ptr: 专属所有权, unique_ptr管理的内存, 只能被一个对象持有, 不支持赋值和复制
    //      移动语义, 通过std:move()进行所有权转移
    // 在这个范围之外，unique_ptr被释放
    Test_unique_ptr();
    // shared_ptr: 通过一个引用计数共享一个对象, 引用计数在额外的内存上, 为0时调用析构
    //      循环引用, 导致堆内存无法释放
    //      内部是利用引用计数来实现内存的自动管理，每当复制一个 shared_ptr，
    //	    引用计数会 + 1。当一个 shared_ptr 离开作用域时，引用计数会 - 1。
    //	    当引用计数为 0 的时候，则 delete 内存。
    Test_shared_ptr();
    // weak_ptr: 被设计为为与shared_ptr共同工作, 用观察者模式工作
    //      解决循环饮用的问题, 依附于shared_ptr, 可以观测但不会影响其引用计数,
    //      同时shared_ptr失效时, weak_ptr也失效
    Test_weak_ptr();
    // c++的引用 int x=1; int& rx = x;
    // 就是特殊的指针, 不允许修改的指针
    // 不存在空引用, 必须初始化, 永远指向初始化的对象
    // 有了指针为什么还需要引用? 为了支持函数运算符重载
    // 有了引用为什么还需要指针? 为了兼容C语言
    int x = 1, x2 = 3;
    int &rx = x;
    rx = 2; // 等价于x = 2;
    cout << "rx = 2; // 等价于x = 2;" << x << rx << endl;
    rx = x2; // 等价于x = x2;
    cout << "rx = x2; // 等价于x = x2;" << x << rx << endl;

    int a2 = 3, b2 = 4;
    swap(a2, b2);
    assert(a2 == 4 && b2 == 3);

    return 0; //(text)代码区
}
