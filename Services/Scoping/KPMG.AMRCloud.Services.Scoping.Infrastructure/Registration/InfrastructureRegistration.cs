using Autofac;
using KPMG.AMRCloud.Services.Scoping.Domain.AggregateRoots.FundAggregate;
using KPMG.AMRCloud.Services.Scoping.Infrastructure.Persistence;
using KPMG.AMRCloud.Services.Scoping.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Infrastructure.Registration
{


    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScopingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ScopingServiceConnectionString")));


            return services;
        }

    }
}
