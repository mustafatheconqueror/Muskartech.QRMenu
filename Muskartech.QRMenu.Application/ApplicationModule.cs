using Autofac;
using AutoMapper;
using MediatR;
using Muskartech.QRMenu.Application.Features.Commands.Category.CreateCategory;

namespace Muskartech.QRMenu.Application;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var applicationAssembly = typeof(CreateCategoryCommandHandler).Assembly;

        builder.RegisterAssemblyTypes(applicationAssembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(applicationAssembly)
            .AsClosedTypesOf(typeof(INotificationHandler<>))
            .InstancePerLifetimeScope();

        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();
        
        builder.Register(ctx =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(applicationAssembly);
            });

            config.AssertConfigurationIsValid();

            return config;
        }).SingleInstance();

        builder.Register(ctx =>
        {
            var config = ctx.Resolve<MapperConfiguration>();
            return config.CreateMapper();
        }).As<IMapper>().InstancePerLifetimeScope();
        
    }
}