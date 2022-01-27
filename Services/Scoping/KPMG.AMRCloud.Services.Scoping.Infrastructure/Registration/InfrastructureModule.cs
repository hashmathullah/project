using Autofac;
using KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate;
using KPMG.AMRCloud.Services.Scoping.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Infrastructure.Registration
{
    public class InfrastructureModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<FundRepository>()
              .As<IFundRepository>()
              .InstancePerLifetimeScope();

        }

    }
}
