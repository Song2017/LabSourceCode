#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
     // 计算机中的存储层次: 网络存储, 本地磁盘, 主存(DRAM内存, 断电丢失), CPU内存, 寄存器
     // 内存由内存单元组成, 每个内存单元进行了编号, 编号就是内存地址, 地址决定了内存中的位置
     // C++ 编译器让我们通过名字(变量名)访问内存地址
     cout << "计算机中的存储层次: 网络存储, 本地磁盘, 主存(DRAM内存, 断电丢失), CPU内存, 寄存器" << endl;
     int a = 112, b = -1;
     float c = 3.14f;
     int *d = &a;
     float *e = &c;

     // 指针: 本身是一个变量, 存储的是值的地址.
     // 对类型T, T*是到T的指针类型, 类型为T*的变量能保存一个类型为T的对象的地址
     // 间接访问的符号是(T*)
     // 指针变量指向的地址可能是另一个指针变量
     cout << "指针: 本身是一个变量, 存储的是值的地址" << endl;
     cout << " &a " << &a << "  d " << d << "  (*d) " << (*d) << endl;
     cout << " &c " << &c << "  e " << e << "  (*e) " << (*e) << endl;
     cout << endl
          << endl;
     // 原始指针的形式: 一般类型 T*, T是泛型, 泛指任何一种类型, 指针类型中用的空间是一样的 4bytes
     // 指针的数组, 每个元素都是T类型的指针 T* t[]; 数组的指针 T(*t)[]
     double cc[4] = {0x80000000, 0xFFFFFFFF, 0x00000000, 0x7FFFFFFF};
     double *aa[4];  // array of pointers
     double(*bb)[4]; // a pointer to an array
     bb = &cc;       // 个数要匹配
     for (int i = 0; i < sizeof(cc) / sizeof(cc[0]); ++i)
     {
          cout << " cc[i] " << cc[i] << " ";
          aa[i] = &cc[i];
          cout << " aa[i] " << aa[i] << ";   ";
     }
     cout << endl
          << endl;

     // const pointer & pointer to const
     // const修饰的部分: 看左侧最近的部分, 如果没有则看右侧
     char str[] = {"hello"};
     char const *pstr1 = "hello"; //修饰的是char, 指针指向的地址可以改变, 但是地址里的内容不能变
     // for (int i =0; i <strnlen(pstr1, 16); ++i)
     //     pstr1[i] += 1;
     cout << *(pstr1) << " pstr1 " << pstr1 << endl;
     char *const pstr2 = str; //修饰的是指针, 指针指向的地址不可以改变, 地址里的内容能变, 会更新原始变量
     // pstr2 = str;
     for (int i = 0; i < 4; ++i)
          pstr2[i] += 1;
     cout << *(pstr2) << " pstr2 " << pstr2 << endl;
     char const *const pstr3 = "hello"; //修饰的是指针 和 char
     // pstr3 = str;
     // for (int i =0; i <strnlen(pstr3, 16); ++i)
     //     pstr3[i] += 1;
     cout << *(pstr3) << " pstr3 " << pstr3 << endl;

     // 指向指针的指针 **c2相当于*(*c2)
     int a2 = 123;   // a2 123
     int *b2 = &a2;  // b2 &a2; *b2 a2
     int **c2 = &b2; // c2 &b2; *c2 b2; **c2 a2
     cout << " a2 = 123 " << a2 << " &a2 " << &a2 << endl;
     cout << " *b2 = &a2 "
          << " b2 &a2 " << b2 << " *b2 a2 " << *(b2) << endl;
     cout << " **c2 = &b2 "
          << " c2 &b2 " << c2 << " *c2 b2 " << *c2 << " **c2 a2 " << **c2 << endl;

     // 未初始化和非法的指针
     // !!! 用指针进行间接访问前, 必须确保他已经初始化并恰当的赋值
     // int *a3; // a可能定位到一个非法地址, 也可能定位到一个可访问的地址, 修改后会导致与原先操作的代码完全不相干的错误
     // *a2 = 12;
     // NULL指针 表示不指向任何东西
     // 使用指针前要判断NULL指针, 指针不使用时要置为NULL
     int *a4 = NULL;
     a4 = &a2;
     if (a4 != NULL)
     {
          *a4 = 12;
          cout << " if (*a4 == NULL){ *a4 = 12 )" << *a4 << endl;
     }
     a4 = NULL;
     // 野指针
     // 1. 指针变量没有初始化
     // 2. 已经释放不用的指针没有置NULL, 如delete和free的指针
     // 3. 指针超越了变量的作用范围, 比如指向了已经被编译器释放的内存

     // 指针的运算操作
     // 1. & 地址操作符: 取地址, 得到的都是4bytes的整型变量 0x7ffeef38c654.
     //    * 间接引用操作符: 取值
     char ch = 'a';
     char *pch = &ch;
     cout << " char ch = 'a'; char *pch = &ch;"
          << " &ch " << &ch << "; *pch " << *pch << "; *pch + 1 " << *pch + 1 << "; *(pch + 1) " << *(pch + 1) << endl;
     // ++, --操作符
     // !!! * ++pch = * (++pch), pch自身的地址也会移向下一个地址
     char a5 = 'b';
     // char *cp2 = ++a5; //++a5返回自增后的值的地址, 但是没有变量指向它
     // char *cp3 = a5++; //a5++ 返回a5的地址
     // ++++ 等运算符, 编译器通过 贪心法 处理字符
     int aa2 = 1, bb2 = 2, cc2;
     cc2 = aa2++ + bb2;
     // cc2 = aa2++ ++bb2;
     cout << " aa2++ + bb2 "
          << " cc2 " << cc2 << " aa2 " << aa2 << endl;
}