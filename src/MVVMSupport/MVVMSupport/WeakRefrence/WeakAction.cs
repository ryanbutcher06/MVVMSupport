using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMSupport.WeakRefrence
{
    /// <summary>
    /// Represents a weak action. This is an action refrence that will not keep the 
    /// containing target alive.
    /// </summary>
    public class WeakAction
    {
        /// <summary>
        /// Initializes a new instance of WeakAction.
        /// </summary>
        /// <param name="target">The target type that holds the action.</param>
        /// <param name="action">The action to be executed.</param>
        public WeakAction(object target, Action action)
        {
            _refrence = new WeakReference(target);

            try
            {
                Type targetType = _refrence == null ? typeof(object) : target.GetType();
                Type delegateType = typeof(OpenInstanceDelegate<>).MakeGenericType(targetType);

                _action = Delegate.CreateDelegate(delegateType, action.Method);
            }
            catch
            {
                //TODO Add logger information.
                Console.WriteLine("Anonymous delegates cannot be used with this type.");
            }
        }

        /// <summary>
        /// Gets a boolean flag marking whether the target has been garbage collected.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (_refrence != null)
                    return _refrence.IsAlive;
                else
                    return false;
            }
        }

        /// <summary>
        /// Executes the action this class refrences if the target objet is alive.
        /// </summary>
        /// <returns>A boolean flag representing whether the action executed.</returns>
        public bool Execute()
        {
            try
            {
                if (IsAlive && _action != null)
                {
                    _action.DynamicInvoke(_refrence.Target);
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Failed to execute the attached action");
            }

            return false;
        }

        private Delegate _action;
        private WeakReference _refrence;

        private delegate void OpenInstanceDelegate<TTarget>(TTarget @this);
    }

    /// <summary>
    /// Represnts a WeakAction class that allows the target class to be garbage collected.
    /// </summary>
    /// <typeparam name="TParam">The type of parameter that the action takes as an argument.</typeparam>
    public class WeakAction<TParam>
    {
        /// <summary>
        /// Initializes a new instance of WeakAction<TParam>.
        /// </summary>
        /// <param name="target">The target type that holds the action.</param>
        /// <param name="action">The action to be executed.</param>
        public WeakAction(object target, Action<TParam> action)
        {
            _refrence = new WeakReference(target);

            try
            {
                Type targetType = target == null ? typeof(object) : target.GetType();
                Type delegateType = typeof(OpenInstanceDelegate<>).MakeGenericType(typeof(TParam), targetType);

                _action = Delegate.CreateDelegate(delegateType, action.Method);
            }
            catch
            {
                //TODO Add logger information.
                Console.WriteLine("Anonymous delegates cannot be used with this type.");
            }
        }

        /// <summary>
        /// Gets a boolean flag marking whether the target has been garbage collected.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (_refrence != null)
                    return _refrence.IsAlive;
                else
                    return false;
            }
        }

        /// <summary>
        /// Executes the action this class refrences if the target objet is alive.
        /// </summary>
        /// <param name="param">The parameter to the action.</param>
        /// <returns>A boolean flag representing whether the action executed.</returns>
        public bool Execute(TParam param)
        {
            try
            {
                if (IsAlive && _action != null)
                {
                    _action.DynamicInvoke(_refrence.Target, param);
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Failed to execute the attached action");
            }

            return false;
        }

        private Delegate _action;
        private WeakReference _refrence;

        private delegate void OpenInstanceDelegate<TTarget>(TTarget @this, TParam param);
    }
}
