#include <iostream>
#include <math.h>

using namespace std;

bool isLeapYear(unsigned int year)
{
    // 双分支if
    //if ( (year % 400 == 0) ||  (year%4==0 && year%100 != 0) )
    if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
    {
        return true;
    }
    else
    {
        return false;
    }
}

int sum_100()
{
    int sum = 0;
    int index = 1;

    while (index <= 100)
    {
        sum += index;
        index++;
    }

    sum = 0;
    for (index = 1; index <= 10; ++index)
    {
        sum += index;
    }

    sum = 0;
    index = 1;
    do
    {
        sum += index;
        index++;
    } while (index <= 100);
    return sum;
}

void aabb_sqrt()
{
    int n = 0;
    for (int i = 30; i < 101; i++)
    {
        n = i * i;
        if (n < 1000)
            continue;
        if (n % 100 / 10 == n % 100 % 10 && n / 1000 == n / 100 % 10)
            cout << n << endl;
    }
}

int main()
{
    // 程序的三种基本结构: 顺序, 条件, 循环
    // if 和 switch的区别:
    // 汇编级别中, if是条件树; switch通过对比表定位到符合的语句

    // 自定义结构
    //  1. 枚举
    // 使用 #define const创建符号常量
    // enum不仅能创建符号常量, 还可以定义新的数据类型
    // 细节: 枚举值不能做左值, 非枚举变量不可以赋值给枚举变量, 反之可以
    // 声明
    enum wT
    {
        Monday,
        Tuesday,
        Wendnesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };
    //定义
    wT weekday;
    weekday = Monday;
    weekday = Tuesday;
    cout << weekday << endl;
    int a = Wendnesday;
    cout << a << endl;

    //  2. 结构体和联合体
    // 联合体公用同一块内存, 取单元类型最大的长度
    union Score {
        double sc;
        char level;
    };
    // 结构体: 缺省对其原则
    // 内存由最大长度元素的长度, 元素的个数, 以及最大长度元素的位置决定
    struct Student
    {
        char name[6];
        int age;
        Score score;
    };
    cout << "sizeof(Score)" << sizeof(Score) << "sizeof(Student)" << sizeof(Student) << endl;
    // 3. 循环语句
    cout << "1+2+3+...+100=" << sum_100() << endl;
    aabb_sqrt();
    return 0;
}
