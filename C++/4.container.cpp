#include <iostream>
#include <vector>
#include <string>

using namespace std;
const int MAX_LEN_NUM = 16;

int main()
{
    // 数组: 物理位置也是紧邻的, 随机访问
    // 差一错误: off-by-one error, 求 10 <= x <=20中x的个数
    int arr[10] = {1, 2, 3, 4, 5, 6, 7};
    // 数组下标使用左闭右开的非对称区间
    // 循环时尽可能满足 空间局部性: 访问的变量地址越近越好, CPU会有预读取及减少切换
    int len = sizeof(arr) / sizeof(arr[0]);
    cout << sizeof(arr) << endl;
    for (int i = 0; i < len; ++i)
        cout << arr[i] << " ";
    cout << endl;
    // 新型数组vector:面向对象方式的动态数组
    vector<int> vec;
    vec = {1, 2, 3, 4};
    cout << "size is " << vec.size() << endl;
    cout << "capacity is " << vec.capacity() << endl;
    vec.push_back(9);
    vec.insert(--vec.end(), 5);
    cout << "size is " << vec.size() << endl;
    cout << "capacity is " << vec.capacity() << endl;
    vec.pop_back();
    vec.pop_back();
    cout << "size is " << vec.size() << endl;
    cout << "capacity is " << vec.capacity() << endl;
    for (int i = 0; i < vec.size(); ++i)
        cout << vec[i] << ", ";
    cout << endl
         << endl;

    // 字符串变量
    // 字符串是以空字符('\0')结束的字符数组
    // 声明字符串变量时要为空结束符额外预留一个元素空间
    char strHello[10] = {"helloworl"};
    for (int i = 0; i < strlen(strHello); ++i)
        cout << strHello[i] << " ";
    cout << endl;

    // 基本操作: strlen(s), strcmp(s1, s2), strcpy(s1, s3)
    // strncpy(s1, s2, n), strcat(s1, s2), strchr(s1, ch), strstr(s1, s2)
    char str1[] = {"hello"};
    char str2[] = {"world"};
    char str3[] = {"helloworl"};
    cout << "strlen(helloworl) is " << strlen(strHello) << endl;
    cout << "sizeof(helloworl) is " << sizeof(strHello) << endl;
    cout << "strcmp(hello, iello) is " << strcmp("hello", "iello") << endl;
    cout << "strcmp(hello, gello1) is " << strcmp("hello", "gello1") << endl;
    cout << "strcmp(hello, hello) is " << strcmp("hello", "hello") << endl;
    char str9[MAX_LEN_NUM] = {0};
    cout << "strcpy(str9, \"hello\") is " << strcpy(str9, "hello") << endl;
    cout << "strncpy(str9, \"world\", 3)) is " << strncpy(str9, "world", 3) << endl;
    cout << "strcat(str9, \"123\") is " << strcat(str9, "123") << endl;
    // ascii 西文字符集 0:48 A:65 a:97
    // utf-8 1byte表示字符, 兼容ascii码. 存储效率高, 变长但是不支持随机内部访问
    // utf-32 4bytes表示一个字符 定长可以随机内部访问. 有字节序BOM问题, windows系统
    // 字节序 大端字节序和小端字节序 数值0x2211使用两个字节储存：高位字节是0x22，低位字节是0x11
    //  大端字节序：高位字节在前，低位字节在后，这是人类读写数值的方法。
    //  小端字节序：低位字节在前，高位字节在后，即以0x1122形式储存
    char c1 = 0;    // 0x00
    char c2 = '\0'; // 0x00 空字符串
    char c3 = '0';  // 0x30
    cout << "0 is " << int(c1) << endl;
    cout << "\\0 is " << int(c2) << endl;
    cout << "'0' is " << int(c3) << endl;
    // 指针表示方法: 指针变量存的是变量的地址
    char *pStr1 = str3; // 常量区
    cout << "char* pStr1 is " << pStr1 << endl;

    cout << "string 库: 比C风格方法更安全和方便, 适用于性能要求不高的场景" << endl;
    string s10, s11;
    string s2 = "hello world";
    string s3("hello s3");
    cout << "s2.length() is " << s2.length() << endl;
    cout << "s2.size() is " << s2.size() << endl;
    cout << "s2.capacity() is " << s2.capacity() << endl;
    cout << "string 的C风格字符串 s2.c_str() is " << s2.c_str() << endl;
    cout << "string 随机访问 is s2[1] " << s2[1] << endl;
    // 拷贝 = ;  连接: +=
    string s4 = s2;
    s4 += " end";
    cout << "string s4 = s2; s4 += \" end\"; " << s4 << endl;
    for (int i = 0; i < s2.length(); ++i)
        cout << s2[i] << " ";
    cout << endl
         << endl;
}