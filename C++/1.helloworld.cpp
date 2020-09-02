#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
    // vector<string> msg = {"Hello", "C++", "World", "from", "VS Code", "and the C++ extension!"};

    // for (const string &word : msg)
    // {
    //     // output
    //     cout << word << " ";
    // }
    cout << endl;
    // 算术运算符
    cout << 10 / 20 << endl;
    cout << 10.0 / 20 << endl;
    int a = 10;
    cout << ++a << endl;
    cout << a-- << endl;
    cout << endl;
    // 关系运算符
    cout << (10 == 20) << endl; //0
    cout << endl;
    // 逻辑运算符
    bool bA = false, bB = false;
    assert(bA == true || bA != true); //1
    assert(bB == true || bB != true); //1
    cout << endl;
    // 赋值运算符
    int aa = 10, b = 20;
    int c = aa + b;
    cout << c << endl;
    c = 3;
    c <<= 2; // c * 2^n
    cout << c << endl;
    cout << endl;
    // 位运算符
    bool p = true, q = false;
    cout << (p & q) << endl;
    cout << (p | q) << endl;
    cout << (p ^ q) << endl;
    cout << endl;
    // a 10 01010; b 20 10100
    cout << (a & b) << endl; // 00000
    cout << (a | b) << endl; // 11110 30
    cout << (a ^ b) << endl; // 11110 30
    cout << (a ^ b) << endl; // 11110 30
    cout << (~a) << endl;    // ~00000000 00001010 > 4 > 00000000 00001011
    cout << endl;
    // sizeof
    cout << (sizeof(a)) << endl;
    cout << (sizeof(char));
    cout << (sizeof(short));
    cout << (sizeof(int));
    cout << (sizeof(float));
    cout << (sizeof(double));
    cout << (a < b ? "xiao" : "da") << endl;
    cout << endl;
    // &取地址, *指针
    float e = float(a);
    cout << e << endl;
    cout << &e << endl;
    float *f = &e;
    cout << f << endl;
    cout << *f << endl;
}