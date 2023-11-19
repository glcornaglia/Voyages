using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Voyages.Domain;
using Voyages.SqlDataAccess;
using Voyages.WebApi.Controllers;

namespace Voyages.Web
{
    public class VoyagesControllerActivator : IControllerActivator
    {
        private readonly VoyagesConfiguration configuration;

        public VoyagesControllerActivator(VoyagesConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            this.configuration = configuration;
        }

        public object Create(ControllerContext context) => 
            this.Create(context.ActionDescriptor.ControllerTypeInfo.AsType());

        public void Release(ControllerContext context, object controller) =>
            (controller as IDisposable)?.Dispose();

        public Controller Create(Type type)
        {
            var context = new VoyagesContext(this.configuration.ConnectionString);

            switch (type.Name)
            {
                case nameof(VoyageController):
                    return new VoyageController(
                        new VoyageService(
                            this.CreateVoyageRepository(context)));

                default: throw new InvalidOperationException($"Invalid controller {type}.");
            }
        }

        private IVoyageRepository CreateVoyageRepository(VoyagesContext context) =>
            (IVoyageRepository)Activator.CreateInstance(this.configuration.VoyageRepositoryType, context);

    }
}