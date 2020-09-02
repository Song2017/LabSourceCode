#include <string>
#include <fstream>
#include <iostream>
using namespace std;

static const int bufferLen = 2048;
bool WriteFile(const string &name, const string &txt)
{
    // 打开源文件和目标文件
    // 源文件以二进制读的方式打开
    // 目标文件以二进制写的方式打开
    // ios::in 读操作
    // ios::out 写操作
    // ios::app 尾部追加
    // ios::trunc 文件存在则清除文件原有内容
    // ios::binary 以二进制方式打开
    fstream fout;
    fout.open(name, ios::app);
    // 判断文件打开是否成功，失败返回false
    if (!fout)
    {
        cout << "打开失败" << name << endl;
        return false;
    }

    // 从源文件中读取数据，写到目标文件中
    // 通过读取源文件的EOF来判断读写是否结束
    fout << txt << endl;

    // 关闭源文件和目标文件
    fout.close();

    return true;
}
bool CopyFile(const string &src, const string &dest)
{
    // 打开源文件和目标文件
    // 源文件以二进制读的方式打开
    ifstream in(src.c_str(), ios::in | ios::binary);
    ofstream out(dest.c_str(), ios::out | ios::binary | ios::trunc);
    // 判断文件打开是否成功，失败返回false
    if (!in || !out)
    {
        cout << "打开失败" << endl;
        return false;
    }

    char temp[bufferLen];
    while (!in.eof())
    {
        in.read(temp, bufferLen);
        streamsize count = in.gcount();
        out.write(temp, bufferLen);
    }

    // 关闭源文件和目标文件
    in.close();
    out.close();

    return true;
}
int main()
{
    // 打开源文件和目标文件
    // ios::in 读操作
    // ios::out 写操作
    // ios::app 尾部追加
    // ios::trunc 文件存在则清除文件原有内容
    // ios::binary 以二进制方式打开

    // 判断文件打开是否成功，失败返回false

    // 从源文件中读取数据，写到目标文件中
    // 通过读取源文件的EOF来判断读写是否结束

    // 关闭源文件和目标文件
    cout << WriteFile("new.txt", "123") << endl;
    cout << CopyFile("new.txt", "new2.txt") << endl;


    // 头文件重复问题
    // 1, 定义宏: 宏的名字重复
    // 2, 编译器去重: #pragma once
}