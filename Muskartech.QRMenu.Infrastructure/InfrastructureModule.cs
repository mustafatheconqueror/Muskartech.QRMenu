using Autofac;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Muskartech.QRMenu.Domain.Interfaces;
using Muskartech.QRMenu.Infrastructure.Persistance.MongoDb;
using Muskartech.QRMenu.Infrastructure.Persistance.Repository;
using Muskartech.QRMenu.Infrastructure.Settings;

namespace Muskartech.QRMenu.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context =>
            {
                var dbSettings = context.Resolve<IOptions<MongoDbSettings>>().Value;

                var mongoClient = new MongoClient(dbSettings.ConnectionString);

                return mongoClient.GetDatabase(dbSettings.DatabaseName);
            })
            .As<IMongoDatabase>()
            .AutoActivate()
            .SingleInstance();

        builder.Register(context =>
            {
                var dbSettings = context.Resolve<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(dbSettings.ConnectionString);
            })
            .As<MongoClient>()
            .AutoActivate()
            .SingleInstance();

        builder.RegisterType<MuskartechRestoranDb>()
            .As<IMuskartechRestoranDb>()
            .SingleInstance();

        
        //Todo: aslnda bu domainModule'dan refere olmalı gibi ama o zaman da domain katmanı Infradan referans alıyor CategoryRepo sebebiyle ?
        builder.RegisterType<CategoryRepository>()
            .As<ICategoryRepository>()
            .InstancePerLifetimeScope();

    }
}