#pragma once
#include "Observer.h"

#include <string>
#include <list>
using namespace std;

class Observerable
{

public:
    Observerable();
    virtual ~Observerable();
    int GetObseverCount() const
    {
        return _Obs.size();
    }
    void Attach(Observer *pOb);
    void Detach(Observer *pOb);
    virtual void GetNews(string news)
    {
        SetChange(news);
    }

protected:
    void SetChange(string news);
    void Notify(void *pArg);

private:
    bool _bChange;
    list<Observer *> _Obs;
};