using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMSupport.Tests.WeakActionTests
{
    public class DummyClass
    {
        public void TestMethod(string testObj)
        {
            Console.WriteLine(testObj);
        }

        public void TestNonParameterizedMethod()
        {
            Console.WriteLine("No Args test good!");
        }
    }
}
