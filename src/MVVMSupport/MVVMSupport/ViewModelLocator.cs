using System;
using System.Collections.Generic;
using System.Dynamic;
using Ninject;

namespace MVVMSupport
{
    /// <summary>
    /// Represents a view model locator class that will resolve objects registered to it.
    /// </summary>
    public class ViewModelLocator : DynamicObject
    {
        /// <summary>
        /// Initializes a new instance of ViewModelLocator.
        /// </summary>
        public ViewModelLocator()
        {
            OnLoad();
        }

        /// <summary>
        /// Gets the inversion of control container for the locator.
        /// </summary>
        public IKernel IOC
        {
            get { return _ioc; }
        }

        /// <summary>
        /// Gets the resolution of the passed property name.
        /// This resolution is set by registering a type with a property name and registering a type with the IOCContainer.
        /// </summary>
        /// <param name="propertyName">The name of the property to be resolved.</param>
        /// <returns>The resolved object or null if the property name has not been bound properly.</returns>
        public object this[string propertyName]
        {
            get
            {
                return ResolveViewModel(propertyName);
            }
        }

        /// <summary>
        /// Registers the type with a property name.
        /// </summary>
        /// <param name="propertyName">The name of the property to which the type should be bound.</param>
        /// <param name="viewModelType">The viewmodel type that should be resolved when the property is called.</param>
        public void RegisterType<TViewModelType>(string propertyName)
        {
            if (_typeRegistry.ContainsKey(propertyName))
                _typeRegistry[propertyName] = typeof(TViewModelType);
            else
                _typeRegistry.Add(propertyName, typeof(TViewModelType));
        }

        /// <summary>
        /// This method is called when the type registry and IOC container have ben initialized.
        /// Types should be registed with the locator here.
        /// NOTE: The base does not need to be called.
        /// </summary>
        protected virtual void OnLoad()
        {   }

        /// <summary>
        /// Attempts to retrieve the value of the desired viewmodel from the resolver.
        /// If no viewmodel is registerd with the resolver, this method returns null;
        /// </summary>
        /// <param name="binder">Provides information about the requested object.</param>
        /// <param name="result">The result of the get opeeration.</param>
        /// <returns>A bool represnting whether or not the get operation was successful.</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }

        private object ResolveViewModel(string indexer)
        {
            Type viewModelType = null;
            if (_typeRegistry.ContainsKey(indexer))
                viewModelType = _typeRegistry[indexer];

            if (viewModelType == null)
                return null;

            bool bindingExists = _ioc.GetBindings(viewModelType) == null ? false : true;
            if (bindingExists)
                return _ioc.Get(viewModelType);
            else
                return null;
        }

        private IKernel _ioc = new StandardKernel();
        private Dictionary<string, Type> _typeRegistry = new Dictionary<string, Type>();
    }
}
