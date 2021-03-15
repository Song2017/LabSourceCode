### Introduce
C++ 是一种静态类型的、编译式的、通用的、大小写敏感的、不规则的编程语言，支持过程化编程、面向对象编程和泛型编程.

### Note 
1. .cpp 文件和 .h 文件的区别：   
cpp文件用于存放类的定义 definition，h 文件用于存放类的声明 declaration。
在头文件中声明了一个函数或者类，需要定义或者使用这个函数或者类时，需要在 cpp 文件中 include 这个头文件
2. include 头文件时 <> 和 "" 的区别：   
<>：会先去系统目录中找头文件，如果没有找到再去当前目录下寻找，像是标准的头文件，如 stdio.h，stdlib.h 使用这个方法。
""：会先在当前目录下寻找，如果找不到再去系统目录下寻找，适用于自己定义的头文件
3. using namespace std; 这行代码的作用：   
声明一个命名空间，在多人合作时，即使有函数同名了，但是因为所在的命名空间不同，也不会导致出现错误。
std 是系统标准的命名空间。
4.  :: 是运算符中等级最高的
  - 作用域符号 ::      
    前面一般是类名称，后面一般是该类的成员名称，C++ 为例避免不同的类有名称相同的成员而采用作用域的方式进行区分。
  - 全局作用域符号
    ```
    char  zhou;  //全局变量
    void  sleep()
    {
    char  zhou; //全局变量
    char(局部变量) = char(局部变量)*char(局部变量);
    ::char(全局变量) =::(全局变量) *char(全局变量)
    }
    ```
  - 作用域分解运算符：
    声明了一个类 A，类 A 里声明了一个成员函数 void f()，
    但没有在类的声明里给出f的定义，那么在类外定义 f 时，就要写成 voidA::f()，表示这个 f() 函数是类 A 的成员函数
    ```
    class CA 
    {
    public:
    int ca_var;
    int add(int a, int b);
    int add(int a);
    }
    //那么在实现这个函数时，必须这样写：
    int CA::add(int a, int b)
    {
    return a + b;
    }
    //另外，双冒号也常常用于在类变量内部作为当前类实例的元素进行表示，比如：
    int CA::add(int a)
    {
    return a + ::ca_var;
    }
    //表示当前类实例中的变量ca_var    
    ```
5. const char*, char const*的区别
    - const离谁近，谁就不能被修改
    - const在谁后面谁就不可以修改，const在最前面则将其后移一位，二者等效
    ```
    char  * const cp; ( * 读成 pointer to ) 
    cp is a const pointer to char 

    const char * p; 
    p is a pointer to const char; 

    char const * p;
    ```

### Note 
#### Books
1. STL源码剖析 侯捷