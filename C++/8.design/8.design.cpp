#include "Singleton.h"
#include "Observer.h"
#include "Observerable.h"

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
    return 0;
}