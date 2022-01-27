using Autofac;
using FluentValidation;
using KPMG.AMRCloud.Services.Scoping.Application.Behaviours;
using KPMG.AMRCloud.Services.Scoping.Application.DbOps;
using KPMG.AMRCloud.Services.Scoping.Domain.Contracts;
using KPMG.AMRCloud.Services.Scoping.Domain.ContractValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Application.Registration
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(CreateFundRequest).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

           builder.
                RegisterAssemblyTypes(typeof(CreateFundRequest).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequest<>)))
                .AsImplementedInterfaces();


           builder.RegisterAssemblyTypes(typeof(CreateFundDBHandler).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces();

            builder
              .RegisterAssemblyTypes(typeof(CreateFundValidator).GetTypeInfo().Assembly)
              .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
              .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(UnhandledExceptionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));           

        }
    }
}
