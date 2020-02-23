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
        ContainerBuilder builder;
        IContainer container;
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
        }

        public T GetInstanceOf<T>()
        {
            var scope = container.BeginLifetimeScope();
            var instance_=scope.Resolve<T>();
            return instance_;
        }
    }
}
