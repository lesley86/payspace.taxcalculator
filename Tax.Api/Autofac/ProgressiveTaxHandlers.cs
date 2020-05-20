using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax.Core.Progressive;

namespace Tax.Api.Autofac
{
    public class ProgressiveTaxHandlers : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Handle10PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
            builder.RegisterType<Handle15PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
            builder.RegisterType<Handle25PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
            builder.RegisterType<Handle28PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
            builder.RegisterType<Handle33PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
            builder.RegisterType<Handle35PercentTaxBracket>().As<IHandleProgressiveTaxBracket>().InstancePerLifetimeScope();
        }
    }
}
