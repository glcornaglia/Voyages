﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Voyages.SqlDataAccess;
using Voyages.WebApi.Controllers;
using Xunit;

namespace Voyages.Web.Tests.Unit
{
    public class VoyagesControllerActivatorTests
    {

        [Fact]
        public void AllControllersCanBeCreated()
        {
            // Arrange
            var sut = new VoyagesControllerActivator(
                configuration: new VoyagesConfiguration(
                    connectionString: "ConnectionString",
                    voyageRepositoryTypeName: typeof(SqlVoyageRepository).GetTypeInfo().AssemblyQualifiedName));

            foreach (Type controllerType in GetApplicationControllerTypes())
            {
                // Act
                Controller controller = CreateController(sut, controllerType);

                // Assert
                Assert.True(controller != null, $"Failed resolving {controllerType.FullName}. Create() returned null.");
                Assert.IsType(controllerType, controller);
            }
        }

        private static IEnumerable<Type> GetApplicationControllerTypes()
        {
            var controllerProvider = new ControllerFeatureProvider();

            var applicationParts = new ApplicationPart[]
            {
                new AssemblyPart(typeof(VoyageController).GetTypeInfo().Assembly)
            };

            var feature = new ControllerFeature();

            controllerProvider.PopulateFeature(applicationParts, feature);

            return feature.Controllers.Select(c => c.AsType());
        }

        private static Controller CreateController(VoyagesControllerActivator activator, Type controllerType)
        {
            try
            {
                return activator.Create(controllerType);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed resolving {controllerType.FullName}. {ex.Message}", ex);
            }
        }
    }
}