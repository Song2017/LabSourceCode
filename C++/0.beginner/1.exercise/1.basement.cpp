#include <iostream>
#include <vector>
#include <stdio.h>
#include <time.h>
#include <ctime>

using namespace std;

extern int aaa;
int g;

int SumCustom(int a, int b = 20)
{
    return a + b;
};

string GetCurrentTime()
{
    time_t now = time(nullptr);
    char tmp[64];
    strftime(tmp, sizeof(tmp), "%Y-%m-%d %H:%M:%S", localtime(&now));
    return tmp;
}

struct Books
{
    char title[50];
    int book_id;
};
void GetBooks(struct Books book)
{
    cout << " book title, book id " << book.title << book.book_id << endl;
};
typedef Books Book;
void GetBookPointer(Book *book)
{
    // 使用指向该结构的指针访问结构的成员，您必须使用 -> 运算符
    cout << " book title, book id " << book->title << book->book_id << endl;
};
int main()
{
    // comment
    /*
        multiple line
    */
    cout << "hello, world" << endl;
    // 宏定义，发生在预处理阶段，也就是编译之前
#if 1 == 1
    cout << "hello, world2" << endl;
#else
    code2
#endif
    // typedef 为一个已有的类型取一个新的名字  typedef 有利于程序的通用与移植
    typedef int int_self;
    int_self aaa = 44;
    float fTest = 11111111111.23423;

    g = aaa;
    cout << g << endl;
    cout << SumCustom(23) << endl;

    // Lambda 函数与表达式
    // [capture](parameters)->return-type{body}
    vector<int> vv = {1, 2, 3, 4, 5, 6, 7};
    auto lambda_self = [aaa, &fTest]() -> int {
        fTest = 123;
        return aaa + 111;
    };
    cout << "lambda_self " << lambda_self() << "  aaa " << aaa << "  fTest " << fTest << ", " << endl;
    int even_count = 0;
    for_each(vv.begin(), vv.end(), [&even_count](int value) -> int {
        if (!(value & 1))
        {
            cout << value << ", ";
            even_count++;
        }
        return 1;
    });
    cout << "even_count " << even_count << ", ";

    // 随机数 5 - 10
    srand((unsigned)time(NULL));
    for (int i = 0; i < 10; i++)
    {
        cout << "随机数 [5, 10]" << (rand() % (10 - 4)) + 5 << endl;
    }
    // 数组
    //  char 型数组中的每一个元素都是一字节，所以每一个字符之间的地址都是 +1 的是连续的，
    // 所以当 cout 输出时读到字符数组中的 \0 便停止输出;
    // 而 int 数组每个元素占 4 个字节所以数个数组中每个元素地址的间隔是 4，但其实它也是连续的，出现乱码是因没找到结束符。
    int n[10];
    cout << "sizeof(n[0])" << sizeof(n[0]) << "sizeof(n) / sizeof(n[0])" << sizeof(n) / sizeof(n[0]) << endl;

    char greeting[16] = {'H', 'e', 'l', 'l', 'o', '\0', 'w'};
    cout << "sizeof(n[0])" << sizeof(greeting) << " greeting " << greeting << " <" << greeting[5] << "> " << endl;
    // 当适用一个结构类型或变量时， sizeof 返回实际的大小；当适用一静态地空间数组， sizeof 归还全部数组的尺寸
    // sizeof 是运算符，strlen 是函数
    char str[20] = "0123456789";
    cout << "strlen(str)" << strlen(str) << endl; // a=10;
    cout << "sizeof(str)" << sizeof(str) << endl; // 而 b=20;

    // 指针 &：取址。* ：取值
    // 指针是一个变量，其值为另一个变量的地址，即，内存位置的直接地址
    // type *var-name;
    int var = 20;
    int *p;
    p = &var;
    cout << "Value of var variable: ";
    cout << var << endl;
    // 输出在指针变量中存储的地址
    cout << "Address stored in p variable: ";
    cout << p << endl;
    // 访问指针中地址的值
    cout << "Value of *p variable: ";
    cout << *p << endl;
    // 引用变量是一个别名，也就是说，它是某个已存在变量的另一个名字
    // int& r = i; 和 int r = i; 不同之处应该是内存的分配吧，后者会再开辟一个内存空间
    int &r = var;
    //  引用必须在声明时将其初始化，不能先声明后赋值
    // int &r2; //error: r2 declared as reference but not initialized

    // 日期
    cout << GetCurrentTime().c_str() << endl;

    // char name[50];
    // cout << " please input your name: " << endl;
    // cin >> name;
    // cout << "your name: " << name << endl;

    //结构体
    // .（点）运算符和 ->（箭头）运算符用于引用类、结构和共用体的成员: 
    //  点运算符应用于实际的对象。箭头运算符与一个指向对象的指针一起使用
    Books Book1;
    Book1.book_id = 1;
    strcpy(Book1.title, "test");
    GetBooks(Book1);
    GetBookPointer(&Book1);

    // enter 结尾
    getchar();
    return 0;
}