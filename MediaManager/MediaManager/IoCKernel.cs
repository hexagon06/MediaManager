using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager
{
    class IoCKernel
    {
        private static IKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static T Get<T>(params IParameter[] parameters)
        {
            return _kernel.Get<T>(parameters);
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }

        public static IParameter Param(string name, object value)
        {
            return new ConstructorArgument(name, value);
        }
    }
}
