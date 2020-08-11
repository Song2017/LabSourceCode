#include <iostream>
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
typedef enum __COLOR 
{
	RED,
	GREEN,
	BLUE,
	UNKOWN
}COLOR;
int main()
{
    // 程序的三种基本结构: 顺序, 条件, 循环
    // if 和 switch的区别: 
    // 汇编级别中, if是条件树; switch通过对比表定位到符合的语句

    // 自定义结构, 枚举 
    // __COLOR 声明
    __COLOR color; //定义
        


    return 0;
}
