//Python.h头文件中包含了所有需要的类型(Python对象类型的表示)和函数定义(对Python对象的操作) 
#include <Python.h>

static PyObject* addList_add(PyObject* self, PyObject* args){
    PyObject * listObj;
    //PyArg_ParseTuple(入参,"i"整型/"s"字符串类型/"O"Python对象, 保存的变量[])
    //PyArg_ParseTuple(args, "siO", &n, &s, &list);
    if(!PyArg_ParseTuple(args,"O", &listObj))
        return NULL;
    //PyList_Size()函数来获取它的长度
    long length = PyList_Size(listObj);
    //求和
    int i=0, sum=0; 
    PyObject* temp;
    for (i = 0; i< length;i++){
        //get an element out of the list - the element is also a python objects
        temp = PyList_GetItem(listObj, i);
        //we know that object represents an integer - so convert it into C long
        long elem = PyLong_AsLong(temp);
        sum += elem;
    }
    //Py_BuildValue()返回给Python代码, i表示整型
    return Py_BuildValue("i", sum);
}

static char addList_docs[] = "add(): add all elements of the list\n";

//填写想在模块内实现函数的相关信息表
static PyMethodDef addList_funcs[] = {
    {"add", (PyCFunction)addList_add, METH_VARARGS, addList_docs },
    {NULL, NULL,0,NULL}
};

static struct PyModuleDef hellomodule = {
    PyModuleDef_HEAD_INIT,
    "add", /* module name */
    addList_docs, /* module documentation, may be NULL */
    -1,
    addList_funcs /* the methods array */
};

//模块初始化块签名为PyMODINIT_FUNC init{模块名}
PyMODINIT_FUNC initaddList_add(void){
     return PyModule_Create(&hellomodule);
}