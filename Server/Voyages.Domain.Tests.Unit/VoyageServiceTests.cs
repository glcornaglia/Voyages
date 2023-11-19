using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Voyages.Domain.Tests.Unit
{
    public class VoyageServiceTests
    {
        
        [Fact]
        public void CreateWithNullRepositoryWillThrow()
        {
            // Arrange
            IVoyageRepository nullRepository = null;

            // Act
            Action action = () => new VoyageService(nullRepository);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void GetClientWillReturnNull()
        {
            // Arrange
            var sut = new VoyageService(new StubVoyageRepository());

            // Act
            var result = sut.GetClient(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetClientByNameWillReturnNull()
        {
            // Arrange
            var sut = new VoyageService(new StubVoyageRepository());

            // Act
            var result = sut.GetClientByName("Name", "LastName");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetClientWillReturnCorrectClient()
        {
            // Arrange
            var expected = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var repository = new StubVoyageRepository
            {
                Clients =  new[]
                {
                    new Client { Id = expected.Id, Name = expected.Name, LastName = expected.LastName, Address = expected.Address, Telephone = expected.Telephone, Email = expected.Email, BirthDate = expected.BirthDate, IdFile = expected.IdFile }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetClient(1);

            // Assert
            Assert.Equal(expected, actual: new { result.Id, result.Name, result.LastName, result.Address, result.Telephone, result.Email, result.BirthDate, result.IdFile });
        }

        [Fact]
        public void GetClientByNameWillReturnCorrectClient()
        {
            // Arrange
            var expected = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var repository = new StubVoyageRepository
            {
                Clients = new[]
                {
                    new Client { Id = expected.Id, Name = expected.Name, LastName = expected.LastName, Address = expected.Address, Telephone = expected.Telephone, Email = expected.Email, BirthDate = expected.BirthDate, IdFile = expected.IdFile }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetClientByName("Name", "LastName");

            // Assert
            Assert.Equal(expected, actual: new { result.Id, result.Name, result.LastName, result.Address, result.Telephone, result.Email, result.BirthDate, result.IdFile });
        }

        [Fact]
        public void GetClientWillNotReturnNotExistingClient()
        {
            // Arrange
            var existing = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var repository = new StubVoyageRepository
            {
                Clients = new[]
                {
                    new Client { Id = existing.Id, Name = existing.Name, LastName = existing.LastName, Address = existing.Address, Telephone = existing.Telephone, Email = existing.Email, BirthDate = existing.BirthDate, IdFile = existing.IdFile }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetClient(2);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetClientByNameWillNotReturnNotExistingClient()
        {
            // Arrange
            var existing = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1 };

            var repository = new StubVoyageRepository
            {
                Clients = new[]
                {
                    new Client { Id = existing.Id, Name = existing.Name, LastName = existing.LastName, Address = existing.Address, Telephone = existing.Telephone, Email = existing.Email, BirthDate = existing.BirthDate, IdFile = existing.IdFile }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetClientByName("Name2", "LastName2");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFileWillReturnNull()
        {
            // Arrange
            var sut = new VoyageService(new StubVoyageRepository());

            // Act
            var result = sut.GetFile(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetFileWillReturnCorrectFile()
        {
            // Arrange
            var expected = new { Id = 1, IdProduct = 2, Type = "Type", ArrivalDate = "ArrivalDate", Duration = 3, FlightNumber = "FlightNumber", Place = "Place", Travelers = 4, Price = 123m };

            var repository = new StubVoyageRepository
            {
                Files = new[]
                {
                    new File { Id = expected.Id, IdProduct = expected.IdProduct, Type = expected.Type, ArrivalDate = expected.ArrivalDate, Duration = expected.Duration, FlightNumber = expected.FlightNumber, Place = expected.Place, Travelers = expected.Travelers, Price = expected.Price }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetFile(1);

            // Assert
            Assert.Equal(expected, actual: new { result.Id, result.IdProduct, result.Type, result.ArrivalDate, result.Duration, result.FlightNumber, result.Place, result.Travelers, result.Price });
        }

        [Fact]
        public void GetFileWillNotReturnNotExistingFile()
        {
            // Arrange
            var existing = new { Id = 1, IdProduct = 2, Type = "Type", ArrivalDate = "ArrivalDate", Duration = 3, FlightNumber = "FlightNumber", Place = "Place", Travelers = 4, Price = 123m };

            var repository = new StubVoyageRepository
            {
                Files = new[]
                {
                    new File { Id = existing.Id, IdProduct = existing.IdProduct, Type = existing.Type, ArrivalDate = existing.ArrivalDate, Duration = existing.Duration, FlightNumber = existing.FlightNumber, Place = existing.Place, Travelers = existing.Travelers, Price = existing.Price }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetFile(2);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetProductWillReturnNull()
        {
            // Arrange
            var sut = new VoyageService(new StubVoyageRepository());

            // Act
            var result = sut.GetProduct(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetProductWillReturnCorrectProduct()
        {
            // Arrange
            var expected = new { Id = 1, Type = "Type", Name = "Name", Description = "Description", Address = "Address", Telephone = "Telephone", PhotoLink = "PhotoLink" };

            var repository = new StubVoyageRepository
            {
                Products = new[]
                {
                    new Product { Id = expected.Id, Type = expected.Type, Name = expected.Name, Description = expected.Description, Address = expected.Address, Telephone = expected.Telephone, PhotoLink = expected.PhotoLink }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetProduct(1);

            // Assert
            Assert.Equal(expected, actual: new { result.Id, result.Type, result.Name, result.Description, result.Address, result.Telephone, result.PhotoLink });
        }

        [Fact]
        public void GetProductWillNotReturnNotExistingProduct()
        {
            // Arrange
            var existing = new { Id = 1, Type = "Type", Name = "Name", Description = "Description", Address = "Address", Telephone = "Telephone", PhotoLink = "PhotoLink" };

            var repository = new StubVoyageRepository
            {
                Products = new[]
                {
                    new Product { Id = existing.Id, Type = existing.Type, Name = existing.Name, Description = existing.Description, Address = existing.Address, Telephone = existing.Telephone, PhotoLink = existing.PhotoLink }
                }
            };

            var sut = new VoyageService(repository);

            // Act
            var result = sut.GetProduct(2);

            // Assert
            Assert.Null(result);
        }

        private class StubVoyageRepository : IVoyageRepository
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