using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMSupport.WeakRefrence
{
    /// <summary>
    /// Represents a base class for creating weak actions.
    /// </summary>
    internal abstract class WeakActionBase
    {
        public WeakActionBase(object target)
        {
            Target = new WeakReference(target);
        }

        /// <summary>
        /// Gets or sets the weak refrence of the target for the weak action.
        /// </summary>
        protected WeakReference Target
        {
            get { return _target; }
            set { _target = value; }
        }

        /// <summary>
        /// Gets or sets the action delegate assocuated with the weak action.
        /// </summary>
        protected Delegate Action
        {
            get { return _action; }
            set { _action = value; }
        }

        /// <summary>
        /// Gets a boolean flag denoting whether the object has been garbage collected.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if(_action != null)
                {
                    if (_target != null)
                        return _target.IsAlive;
                }

                return false;
            }
        }

        private WeakReference _target;
        private Delegate _action;
    }
}
