#pragma once

#ifndef OBSSERVER_H
#define OBSSERVER_H
class Observer
{
public:
    Observer() { ; }
    virtual ~Observer() { ; }

    virtual void Update(void *pArg) = 0;
};

#endif