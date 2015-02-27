using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Mvp.DI
{
    // Wrapper for DI container to allow changing of particular lib.
    // Probably and excessive level of abstraction, considering that the usage 
    // is limited to ApplicationController only
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>();
        bool IsRegistered<TService>();
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}
