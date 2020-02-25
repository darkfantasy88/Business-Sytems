using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace ALT_R_ManagerLibrary.DataAccess
{
    public class Dependency_Inversion_Principle
    {
        private ContainerBuilder builder;
        private IContainer container;
        public delegate void EventAggregatorHandler(object source, ConsoleBuilderArgs e);
        public event EventAggregatorHandler EventAgrregator;


        protected virtual void RegisterInstance()
        {
            if (EventAgrregator != null)
            {
                EventAgrregator(this, new ConsoleBuilderArgs() { Builder=this.builder});
            }
        }
        public Dependency_Inversion_Principle()
        {
             builder= new ContainerBuilder();
            
        }
        public void BuildContainer()
        {
            container=builder.Build();
        }

        public void RegisterInstance<T,U>(T _interface,U _implementation)
        {
            builder.RegisterType<U>().As<T>();
            container = builder.Build();

        }

        public T GetInstanceOf<T>()
        {
            var scope = container.BeginLifetimeScope();
            var instance_=scope.Resolve<T>();
            return instance_;
        }
    }
}
