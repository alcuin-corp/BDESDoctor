using Ninject;

namespace Alcuin.BDES.Ninject
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel;

        static ServiceLocator()
        {
            Kernel = new StandardKernel();
            Kernel.Load(new Bindings());
        }

        public static T Resolve<T>()
        {
            return Kernel.Get<T>();
        }

        public static T Resolve<T>(string name)
        {
            return Kernel.Get<T>(name);
        }

        public static void Resolve<T>(out T instance)
        {
            instance = Resolve<T>();
        }

        public static void RegisterInstance<T>(T instance)
        {
            Kernel.Rebind<T>().ToConstant(instance);
        }
    }
}
