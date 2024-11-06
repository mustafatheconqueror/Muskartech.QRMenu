using Autofac;
using Muskartech.QRMenu.Domain.Aggregates.CategoryAggregate;

namespace Muskartech.QRMenu.Domain;

public class DomainModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new CategoryModule());
    }
}