#include "Singleton.h"

Singleton *Singleton::This = nullptr;
const Singleton *Singleton::getInstance()
{
    if (!This)
    {
        This = new Singleton;
    };

    return This;
}

Singleton::Singleton()
{
}

Singleton::~Singleton()
{
}