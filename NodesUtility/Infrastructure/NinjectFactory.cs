using System.Reflection;
using Ninject;

namespace NodesUtility.Infrastructure
{
    public static class NinjectFactory
    {
        private static IKernel _kernel;

        private static IKernel Kernel
        {
            get
            {
                if (_kernel != null) return _kernel;

                _kernel = new StandardKernel();
                _kernel.Load(Assembly.GetExecutingAssembly());
                return _kernel;
            }
        }

        public static T GetInstance<T>()
        {
            return Kernel.Get<T>();
        }
    }
}