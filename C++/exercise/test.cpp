#include <iostream>
using namespace std;
#define MA(x) x * (x - 1)

int main()
{
    int a = 1, b = 2;
    cout << MA(1 + a + b) << endl; // 8  1 + a + b(1 + a + b -1)
    return 1;
