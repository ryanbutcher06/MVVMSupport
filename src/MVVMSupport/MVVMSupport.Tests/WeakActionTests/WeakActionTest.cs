using MVVMSupport.WeakRefrence;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMSupport.Tests.WeakActionTests
{
    [TestFixture]
    public class WeakActionTest
    {
        [Test]
        public void WeakActionCanBeCollected()
        {
            WeakAction action = CreateWeakAction();
            GC.Collect();

            Assert.IsFalse(action.IsAlive);
        }

        [Test]
        public void WeakActionCanExecute()
        {
            DummyClass test = new DummyClass();
            WeakAction action = new WeakAction(test, test.TestNonParameterizedMethod);

            Assert.IsTrue(action.IsAlive);
            action.Execute();
        }

        [Test]
        public void GenericWeakActionsCanbeCollected()
        {
            WeakAction<string> action = CreateGenericWeakAction();
            GC.Collect();

            Assert.IsFalse(action.IsAlive);
        }

        [Test]
        public void GenericWeakActionCanExecute()
        {
            DummyClass test = new DummyClass();
            WeakAction<string> action = new WeakAction<string>(test, test.TestMethod);

            Assert.IsTrue(action.IsAlive);
            action.Execute("Test");
        }

        private WeakAction CreateWeakAction()
        {
            DummyClass test = new DummyClass();
            WeakAction action = new WeakAction(test, test.TestNonParameterizedMethod);

            Assert.IsTrue(action.IsAlive);

            return action;
        }

        private WeakAction<string> CreateGenericWeakAction()
        {
            DummyClass test = new DummyClass();
            WeakAction<string> action = new WeakAction<string>(test, test.TestMethod);

            Assert.IsTrue(action.IsAlive);
            return action;
        }
    }
}
