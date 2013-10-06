using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMSupport.WeakRefrence
{
    public class WeakActionGeneric<TParam> : WeakActionBase
    {
        public WeakActionGeneric(object target, Action<TParam> action)
            : base(target)
        {
            try
            {
                Type targetType = target == null ? typeof(object) : target.GetType();
                Type delegateType = typeof(OpenInstanceDelegate<object, TParam>).MakeGenericType(targetType);

                if (action != null)
                    Action = Delegate.CreateDelegate(delegateType, null, action.Method);
            }
            catch
            {
                Action = null;
            }
        }

        public void Execute(TParam param)
        {
            if (IsAlive)
                Action.DynamicInvoke(param);
        }

        private delegate void OpenInstanceDelegate<TTarget, TParam>(TTarget @this, TParam param);
    }
}
