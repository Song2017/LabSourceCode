using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace WindowsFormsApplication1
{
    class TestIContainer : IContainer
    {
        private ArrayList m_bookList;

        public TestIContainer()
        {
            m_bookList = new ArrayList();
        }

        public ComponentCollection Components
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual void Add(IComponent book)
         {
             m_bookList.Add(book);
         }

        public void Add(IComponent component, string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
