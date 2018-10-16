using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field
        | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class AttributeTest : System.Attribute
    {
        #region 预定义特性      AttributeUsage    Conditional    Obsolete
        public AttributeTest()
        {

        }
        [Obsolete("this is the old method, please use NewMethod ", false)]
        public void OldMethod()
        {
            Console.WriteLine("this is the old method");
        }
        public void NewMethod()
        {
            Console.WriteLine("this is the new method");
        }
        #endregion

        private int bugNo;
        public int BugNo
        {
            get { return bugNo; }

        }
        private string developer;
        public string Developer
        {
            get { return developer; }

        }
        private string lastReview;
        public string LastReview
        {
            get { return lastReview; }

        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public AttributeTest(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

    }
}
