using MVVMSupport.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMSupport.Tests.CommandTests
{
    [TestFixture]
    public class DelegateCommandTests
    {
        [Test]
        public void CanExecuteDelegateCommand()
        {
            bool goodExecute = false;
            Action<object> action = (o) => goodExecute = true;

            ICommand delegateCommand = new DelegateCommand(action);
            delegateCommand.Execute(null);

            Assert.IsTrue(goodExecute);
        }

        [Test]
        public void CanExecuteDelegateWorks()
        {
            Predicate<object> predicate = (o) =>
                {
                    if (o is bool)
                        return (bool)o;
                    else
                        return false;
                };
            Action<object> action = o => { };

            bool canExecute = false;
            ICommand delegateCommand = new DelegateCommand(action, predicate);
            Assert.IsFalse(delegateCommand.CanExecute(canExecute));

            canExecute = true;
            Assert.IsTrue(delegateCommand.CanExecute(canExecute));
        }
    }
}
