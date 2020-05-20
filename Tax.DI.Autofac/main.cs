using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core;

namespace Tax.DI.Autofac
{
    public class Main
    {
        public ContainerBuilder RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterType<FlateRateCalculator>().As<ITaxTypeCalculator>();

            return builder;
        }
     
    }
}
