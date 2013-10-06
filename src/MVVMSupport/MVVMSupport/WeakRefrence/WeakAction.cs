using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSupport.WeakRefrence
{
    /// <summary>
    /// Represents a class that supports parameterless weakactions.
    /// NOTE because of the nature of weak actions, lambdas cannot be used with them.
    /// This is due to lambdas not having strong ties to the class in which they are created.
    /// </summary>
    public class WeakAction : WeakActionBase
    {
        /// <summary>
        /// Initializes a new instance of WeakAction.
        /// </summary>
        /// <param name="target">The target object which requires the weak refrence.</param>
        /// <param name="action">The action delegate.</param>
        public WeakAction(object target, Action action)
            : base(target)
        {
            try
            {
                Type targetType = target == null ? typeof(object) : target.GetType();
                Type delegateType = typeof(GenericActionDelegate<>).MakeGenericType(targetType);

                if (action != null)
                    Action = Delegate.CreateDelegate(delegateType, null, action.Method);
            }
            catch
            {
                Action = null;
            }
        }

        /// <summary>
        /// Executes the action attached to the target.
        /// This will check if the target and action are alive before attempting to execute.
        /// </summary>
        public void Execute()
        {
            if (IsAlive)
                Action.DynamicInvoke();
        }

        private delegate void GenericActionDelegate<TTarget>(TTarget @this);
    }
}
