#include <pybind11/pybind11.h> // pybind11的头文件
#include <pybind11/stl.h>      // 转换标准容器必须的头文件

using namespace std;

// Mac OS
// clang++ -O3 -Wall -shared -std=c++11 -fPIC `python3 -m pybind11 --includes` pybind11_example.cpp -o pydemo`python3-config --extension-suffix` `python3-config --ldflags`
// clang++ -O3 -Wall -shared -std=c++11 -fPIC `python3 -m pybind11 --includes` pybind11_example.cpp -o pydemo.so `python3-config --ldflags`
// g++ pybind.cpp               \                  #编译的源文件
//    -std=c++11 -shared -fPIC   \                 #编译成动态库
//   `python3 -m pybind11 --includes` \            #获得包含路径
//   -o pydemo`python3-config --extension-suffix`  #生成的动态库名字

namespace py = pybind11; // pybind11的头文件

class Animal
{
  // private:
  //   Animal(std::string); // private constructor
public:
  virtual ~Animal() {}
  virtual std::string go(int n_times) = 0;
};

class PyAnimal : public Animal
{
public:
  /* Inherit the constructors */
  using Animal::Animal;

  /* Trampoline (need one for each virtual function) */
  std::string go(int n_times) override
  {
    PYBIND11_OVERRIDE_PURE(
        std::string, /* Return type */
        Animal,      /* Parent class */
        go,          /* Name of function in C++ (must match Python name) */
        n_times      /* Argument(s) */
    );
  }
};
std::string call_go(Animal *animal)
{
  return animal->go(3);
}

PYBIND11_MODULE(pydemo, m) // 定义Python模块pydemo
{
  // 模块的说明文档
  m.doc() = "pybind11 demo doc";
  // 定义Python函数// 定义一个lambda表达式
  m.def("info",
        []() {
          py::print("c++ version =", __cplusplus); // pybind11自己的打印函数
          py::print("gcc version =", __VERSION__);
          // py::print("libstdc++ =", __GLIBCXX__);
        });
  // 定义Python函数 有参数的lambda表达式
  m.def("add",
        [](int a, int b) { return a + b; });
  m.def("use_str",            // 定义Python函数
        [](const string &str) // 入参是string
        {
          py::print(str);
          return str + "!!"; // 返回string
        });

  m.def("use_tuple",                  // 定义Python函数
        [](tuple<int, int, string> x) // 入参是tuple
        {
          get<0>(x)++;
          get<1>(x)++;
          get<2>(x) += "??";
          return x; // 返回元组
        });
  // 定义Python函数
  m.def("use_list",
        [](const vector<int> &v) // 入参是vector
        {
          auto vv = v;
          py::print("input :", vv);
          vv.push_back(100);
          return vv; // 返回列表
        });

  //  class
  // py::class_<Animal>(m, "Animal")
  //     .def("go", &Animal::go);
  py::class_<Animal, PyAnimal>(m, "Animal")
      .def(py::init())
      .def("go", &Animal::go);
  m.def("call_go", &call_go);
}

