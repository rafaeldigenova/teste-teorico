using Castle.MicroKernel;
using Castle.Windsor;

namespace TesteTecnico.Infrastructure
{
    public class Factory
    {
        private readonly WindsorContainer _container;
        private readonly IKernel _kernel;
        private static Factory _instance;

        public WindsorContainer Container { get { return _container; } }

        public IKernel Kernel { get { return _kernel; } }

        public static Factory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Factory))
                    {
                        _instance = new Factory();
                    }
                }

                return _instance;
            }
        }

        private Factory()
        {
            _container = new WindsorContainer();
            _kernel = _container.Kernel;
        }

        public T Get<T>()
        {
            return _kernel.Resolve<T>();
        }
    }
}
