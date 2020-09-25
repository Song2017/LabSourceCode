#include "Complex.h"
#include <iostream>
#include <stdio.h>
using namespace std;

int main()
{
    // 面向对象编程, 泛型编程
    // struct, class定义一个类
    // 区别, struct默认成员权限是public, class是private
    //
    // 对象的属性
    // private:
    // 	    double _real;  // 复数的实部
    // 	    double _image; // 复数的虚部
    //
    Complex a(2, 3);
    cout << a.GetReal() << endl;
    // 运算符重载
    // &c表示传过来的是引用, 不需要为参数创建新的内存
    // 左边第一个const 表示&c是不允许修改的
    // Complex &Complex::operator=(const Complex &c)
    Complex b(3, 4);
    Complex c1 = a + b;
    cout << c1 << endl;
    // 拷贝构造及临时对象的优化
    // 拷贝构造: c++重载运算符内创建临时对象时, 因为临时对象创建在栈上,
    //      当返回临时对象时, 临时对象已经被销毁 c++会返回一个副本
    // Complex(const Complex &x); // 拷贝构造
    // Complex Complex::operator+(const Complex &c) const
    // {
    //     //Complex tmp;
    //     //tmp._real = _real + x._real;
    //     //tmp._image = _image + x._image;
    //     //return tmp;
    //     // 临时对象的优化
    //     return Complex(_real + c._real, _image + c._image);
    // }
    Complex c2 = a - b;
    cout << c2 << endl;
    // 前置操作和后置操作
    // 前置 返回原来对象的引用
    // 后置 返回临时副本, 然后进行原来对象的自增
    cout << a++ << endl;
    cout << ++a << endl;

    // 标准输入和输出的重载 cout
    // friend: 友元函数是定义在类外部，但有权访问类的所有私有（private）成员和保护（protected）成员
    // friend ostream &operator<<(ostream &os, const Complex &x);
    cout << a << endl;

    cout << endl;
    // IO流基础
    // ios > istream(cin), ostream(cout, cerr, clog) > ifstream, ofstream > iostream < fstream
    // IO缓存区
    // 按块缓存: 文件系统, 按行缓存: \n, 不缓存
    // 如果输入的字符大于代码中要接收的长度, 会被缓存到缓冲区, 直接传到下一个待输入的代码处
    // 清空IO缓冲区: cin.ignore(numeric_limits<std::streamsize>::max(), '\n');
    int aa, index = 0;
    while (cin >> aa)
    {
        cout << "number is:" << aa << endl;
        index++;
        if (index == 5)
            break;
    }
    cin.ignore(numeric_limits<std::streamsize>::max(), '\n');
    char ch;
    cin >> ch;
    cout << "char is:" << ch << endl;


    // virtual虚函数的原理
    // 子类包含了父类, 父类里包含了虚函数 virtual修饰的函数, 
    //      虚函数中存储子类实现的函数的指针
    // 虚表中不包含 一般意义的函数

    // 面向对象的三大特性
    //  封装性: 将数据和代码捆绑在一起, 使得代码模块化, 简化问题, 便于抽象
    //  继承性: 让某种类型对象获得另一个类型对象的属性和方法, 减少代码重复
    //  多态性: 对象在继承父类对象的基础上, 实现自身的灵活扩充, 可以很好的实现接口重用



    return 0;
}