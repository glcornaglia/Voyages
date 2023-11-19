using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Voyages.Domain;
using Voyages.WebApi.Controllers;
using Xunit;
using Microsoft.AspNetCore.Http;

namespace Voyages.Web.Tests.Unit.Controllers
{
    public class VoyageControllerTests
    {

        [Fact]
        public void CreateWithNullVoyageServiceWillThrow()
        {
            // Act
            Action action = () => new VoyageController(voyageService: null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void GetClientWillNotReturnAction()
        {
            // Arrange
            var sut = new VoyageController(new StubVoyageService());

            // Act
            IActionResult result = sut.GetClient(1);
            var notFoundResult = result as ObjectResult;

            // Assert
            Assert.Null(notFoundResult);
        }

        [Fact]
        public void GetClientByNameWillNotReturnAction()
        {
            // Arrange
            var sut = new VoyageController(new StubVoyageService());

            // Act
            IActionResult result = sut.GetClientByName("Name", "LastName");
            var notFoundResult = result as ObjectResult;

            // Assert
            Assert.Null(notFoundResult);
        }

        [Fact]
        public void GetClientWillReturnActionWithCorrectClient()
        {
            // Arrange
            var expected = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var service = new StubVoyageService
            {
                Clients = new[]
                {
                    new Client(){ Id = expected.Id, Name = expected.Name, LastName = expected.LastName, Address = expected.Address, Telephone = expected.Telephone, Email = expected.Email, BirthDate = expected.BirthDate, IdFile = expected.IdFile }
                }
            };

            var sut = new VoyageController(service);

            // Act
            IActionResult result = sut.GetClient(1);
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.NotNull(okResult.Value);
            Assert.IsType<Client>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(okResult.Value is Client);
            var clientResult = okResult.Value as Client;
            Assert.Equal(expected, actual: new { clientResult.Id, clientResult.Name, clientResult.LastName, clientResult.Address, clientResult.Telephone, clientResult.Email, clientResult.BirthDate, clientResult.IdFile });

        }

        [Fact]
        public void GetClientByNameWillReturnActionWithCorrectClient()
        {
            // Arrange
            var expected = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var service = new StubVoyageService
            {
                Clients = new[]
                {
                    new Client(){ Id = expected.Id, Name = expected.Name, LastName = expected.LastName, Address = expected.Address, Telephone = expected.Telephone, Email = expected.Email, BirthDate = expected.BirthDate, IdFile = expected.IdFile }
                }
            };

            var sut = new VoyageController(service);

            // Act
            IActionResult result = sut.GetClientByName("Name", "LastName");
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.NotNull(okResult.Value);
            Assert.IsType<Client>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(okResult.Value is Client);
            var clientResult = okResult.Value as Client;
            Assert.Equal(expected, actual: new { clientResult.Id, clientResult.Name, clientResult.LastName, clientResult.Address, clientResult.Telephone, clientResult.Email, clientResult.BirthDate, clientResult.IdFile });

        }

        [Fact]
        public void GetFileWillNotReturnAction()
        {
            // Arrange
            var sut = new VoyageController(new StubVoyageService());

            // Act
            IActionResult result = sut.GetFile(1);
            var notFoundResult = result as ObjectResult;

            // Assert
            Assert.Null(notFoundResult);
        }

        [Fact]
        public void GetFileWillReturnActionWithCorrectFile()
        {
            // Arrange
            var expected = new { Id = 1, IdProduct = 2, Type = "Type", ArrivalDate = "ArrivalDate", Duration = 3, FlightNumber = "FlightNumber", Place = "Place", Travelers = 4, Price = 123m };

            var service = new StubVoyageService
            {
                Files = new[]
                {
                    new File(){ Id = expected.Id, IdProduct = expected.IdProduct, Type = expected.Type, ArrivalDate = expected.ArrivalDate, Duration = expected.Duration, FlightNumber = expected.FlightNumber, Place = expected.Place, Travelers = expected.Travelers, Price = expected.Price }
                }
            };

            var sut = new VoyageController(service);

            // Act
            IActionResult result = sut.GetFile(1);
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.NotNull(okResult.Value);
            Assert.IsType<File>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(okResult.Value is File);
            var FileResult = okResult.Value as File;
            Assert.Equal(expected, actual: new { FileResult.Id, FileResult.IdProduct, FileResult.Type, FileResult.ArrivalDate, FileResult.Duration, FileResult.FlightNumber, FileResult.Place, FileResult.Travelers, FileResult.Price });

        }

        [Fact]
        public void GetProductWillNotReturnAction()
        {
            // Arrange
            var sut = new VoyageController(new StubVoyageService());

            // Act
            IActionResult result = sut.GetProduct(1);
            var notFoundResult = result as ObjectResult;

            // Assert
            Assert.Null(notFoundResult);
        }

        [Fact]
        public void GetProductWillReturnActionWithCorrectProduct()
        {
            // Arrange
            var expected = new { Id = 1, Type = "Type", Name = "Name", Description = "Description", Address = "Address", Telephone = "Telephone", PhotoLink = "PhotoLink" };

            var service = new StubVoyageService
            {
                Products = new[]
                {
                    new Product(){ Id = expected.Id, Type = expected.Type, Name = expected.Name, Description = expected.Description, Address = expected.Address, Telephone = expected.Telephone, PhotoLink = expected.PhotoLink }
                }
            };

            var sut = new VoyageController(service);

            // Act
            IActionResult result = sut.GetProduct(1);
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.NotNull(okResult.Value);
            Assert.IsType<Product>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.True(okResult.Value is Product);
            var ProductResult = okResult.Value as Product;
            Assert.Equal(expected, actual: new { ProductResult.Id, ProductResult.Type, ProductResult.Name, ProductResult.Description, ProductResult.Address, ProductResult.Telephone, ProductResult.PhotoLink });

        }

        private class StubVoyageService : IVoyageService
        {
            public IEnumerable<Client> Clients { get; set; } = Enumerable.Empty<Client>();
            public Client GetClient(int idClient) => Clients.Where(x => x.Id == idClient).FirstOrDefault();
            public Client GetClientByName(string name, string lastname) => Clients.Where(x => x.Name == name && x.LastName == lastname).FirstOrDefault();

            public IEnumerable<File> Files { get; set; } = Enumerable.Empty<File>();
            public File GetFile(int idFile) => Files.Where(x => x.Id == idFile).FirstOrDefault();

            public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
            public Product GetProduct(int idProduct) => Products.Where(x => x.Id == idProduct).FirstOrDefault();
        }
    }
}