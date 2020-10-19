#include "Singleton.h"
#include "Observer.h"
#include "Observerable.h"
#include <string.h>
class News : public Observerable
{
public:
    virtual void GetNews(string news)
    {
        SetChange("class News: " + news);
    }
};

class User1 : public Observer
{
public:
    virtual void Update(void *pArg)
    {
        cout << "User1 get some news" << reinterpret_cast<char *>(pArg) << endl;
    }
};
class User2 : public Observer
{
public:
    virtual void Update(void *pArg)
    {
        cout << "User2 get some news" << reinterpret_cast<char *>(pArg) << endl;
    }
};

int Test()
{
    cout << "test: 0" << endl;
    return 0;
}

class Base
{
public:
    Base() : _i(0) { ; }
    virtual void T() { cout << "this is Base" << _i << endl; }

private:
    int _i;
};

class Derived : public Base
{
private:
    int _j;

public:
    Derived() : _j(0) { ; }
    virtual void T() { cout << "this is Derived" << _j << endl; }
};

// 适配器模式
class LegacyRect
{
public:
    LegacyRect(double x1, double x2, double y1, double y2)
    {
        _x1 = x1;
        _x2 = x2;
        _y1 = y1;
        _y2 = y2;
    }
    void LegacyDraw()
    {
        cout << "LegacyRect Draw" << _x1 << _x2 << _y1 << _y2 << endl;
    }

private:
    double _x1;
    double _x2;
    double _y1;
    double _y2;
};
class Rect
{
public:
    virtual void Draw(string text) { ; }
};
// 继承形式的适配器
class AdapterRect : public Rect, public LegacyRect
{
public:
    AdapterRect(double x1, double x2, double y1, double y2) : LegacyRect(x1, x2, y1, y2)
    {
        cout << "AdapterRect  " << x1 << x2 << y1 << y2 << endl;
    }
    virtual void Draw(string text)
    {
        LegacyDraw();
    }
};
// 组合形式的适配器
class AdapterRect2 : public Rect
{
public:
    AdapterRect2(
        double x1, double x2, double y1, double y2) : _rect(x1, x2, y1, y2)
    {
        cout << "AdapterRect2  " << x1 << x2 << y1 << y2 << endl;
    }
    virtual void Draw(string text)
    {
        _rect.LegacyDraw();
    }

private:
    LegacyRect _rect;
};

// 泛型编程
template <class TT>
TT custom_max(TT a, TT b)
{
    return a > b ? a : b;
}
template <>
char *custom_max(char *a, char *b)
{
    cout << "char *custom_max ";
    return strcmp(a, b) > 0 ? a : b;
}
template <class T1, class T2>
T1 custom_max(T1 a, T2 b)
{
    return static_cast<T1>(a > b ? a : b);
}

template <int n>
struct Sum
{
    enum Value
    {
        N = Sum<n - 1>::N + n
    };
};
template <>
struct Sum<1>
{
    enum Value
    {
        N = 1
    };
};

int main()
{
    // 软件设计模式
    // 模式描述了一个不断发生的问题及解决这个问题的方法
    // 23种面向对象的可复用的设计模式
    // 适用于 代码会被重复使用的情况

    // 1. 单例模式
    // 整个程序中有且只有一个实例
    // 常见 系统日志, 数据库分配主键
    // 思路 1, 拥有私有构造函数, 确保用户无法通过new直接实例;
    //      2, 一个静态私有成员变量和静态公有方法 instance()
    Singleton::getInstance()->DoSomething();

    Singleton::getInstance()->DoSomething();

    //2. 观察者模式
    User1 u1;
    User2 u2;
    News n;
    n.GetNews("news 1");
    cout << n.GetObseverCount() << endl;

    n.Attach(&u1);
    n.Attach(&u2);
    n.GetNews("news 2");
    cout << n.GetObseverCount() << endl;

    n.Detach(&u1);
    n.GetNews("news 3");
    cout << n.GetObseverCount() << endl;

    // void* 表示一个没有类型的指针
    // c 中 #define NULL ((void*)0)
    // c++ 11 中 NULL为0, nullptr是((void*)0)
    // 类型转换
    // const_cast 用于指针或引用的转换, 去掉类型的const属性
    const int a = 100;
    int *pA = const_cast<int *>(&a);
    *pA = 100;
    cout << *pA << a << endl;
    // reinterpret_cast 重新解释类型, 比C强转安全
    // 不检查指向的内容及指针类型本身, 要求转换前后类型所占内存大小一致, 否则引发编译错误
    typedef void (*FuncPtr)();
    FuncPtr funcp;
    // funcp = &Test;
    funcp = reinterpret_cast<FuncPtr>(&Test);
    funcp();

    // static_cast 基本类型转换及有继承关系的类对象和类指针之间的转换, 但是不会检查转换后的类型
    // dynamic_cast 只能用于含有虚函数的类, 用于类层次间的向上和向下转换, 向下转化(父类转成子类)时有错返回NULL
    int i = 5;
    double d = static_cast<double>(i);
    double dd = 5.3;
    int ii = static_cast<int>(dd);
    cout << d << " " << ii << endl;
    Base b;
    Base *pb;
    Derived *pd;
    pb = static_cast<Base *>(&b);
    pb = dynamic_cast<Base *>(&b);
    // 向下转换 父类转成子类
    pd = static_cast<Derived *>(&b);
    if (pd == NULL)
    {
        cout << "error cast static_cast" << endl;
    }
    pd = dynamic_cast<Derived *>(&b);
    if (pd == NULL)
    {
        cout << "error cast dynamic_cast" << endl;
    }

    // Adapter 适配器模式
    // 将类接口转换为客户期望的另一个接口
    // 继承形式的适配器 class AdapterRect : public Rect, public LegacyRect
    // 组合形式的适配器 class AdapterRect2 : public Rect { private: LegacyRect _rect;}
    double x = 10.0, x2 = 12.0, y = 20.0, y2 = 22.0;
    AdapterRect ar(x, x2, y, y2);
    Rect *rect = &ar;
    rect->Draw("asd");
    AdapterRect2 ar2(x, x2, y, y2);
    Rect *rect2 = &ar2;
    rect2->Draw("asd");

    // 泛型编程
    // 面向对象 通过间接层来调用函数, 是一种动态期多态
    // 泛型编程是更直接的抽象吗不会因为间接层损失效率, 是一种静态期多态
    cout << custom_max(1, 2) << endl;
    cout << custom_max(11.2, 2.2) << endl;
    cout << custom_max("hello", "world") << endl;
    char *s1 = "hello", *s2 = "world";
    cout << custom_max(s1, s1) << endl;
    cout << custom_max(12, 22.2) << endl;
    // 在编译时完成
    cout << Sum<100>::N << endl;
    return 0;
}