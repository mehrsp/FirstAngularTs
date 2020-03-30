using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Application.Service;
using Application.Interfaces;
using firstAPI.Controllers;
using System.Web.Http;
using Domain.Interfaces;
using Infra.Data.Repository;
using Infra.Data;

using System.Data.Common;


namespace firstAPI
{
    public static class CastleConfig
 {
    public static IWindsorContainer GetContainer()
    {
            var container = new WindsorContainer();
            container.Register(Component.For<AppDbContext>()
              .Forward<AppDbContext>()
              .LifestylePerWebRequest());
            container.Register(Component.For<DbConnection>()
     .UsingFactoryMethod(a =>
     {
         var connection = ConnectionFactory.Create("MyFirstDb");
         connection.Open();
         return connection;

     })
     .LifestylePerWebRequest());
            //.OnDestroy(a =>
            //{
            //    a.Close();
            //}));
            container.Register(Component.For<UnitOfWork>()
                                          .ImplementedBy<UnitOfWork>());

            container.Register(Component.For<IEntryRepository>()
                                    .ImplementedBy<EntryRepository>());
            container.Register(Component.For<IEntryService>()
                                    .ImplementedBy<EntryService>());

        //container.Register(Component.For<UserController>().LifestylePerWebRequest());
        container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestylePerWebRequest());

        return container;
    }
}

    
}